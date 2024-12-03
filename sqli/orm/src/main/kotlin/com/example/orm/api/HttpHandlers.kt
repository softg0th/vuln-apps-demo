package com.example.orm.api

import com.example.orm.entity.User
import com.example.orm.service.UserService
import org.springframework.http.ResponseEntity
import org.springframework.stereotype.Controller
import org.springframework.web.bind.annotation.*

@Controller
@RequestMapping("/")
class MainController {
    @GetMapping
    fun index(): String {
        return "index"
    }
}

@RestController
@RequestMapping("/api")
class UserController(
    private val userService: UserService
) {
    @PostMapping("/select_data")
    fun selectData(@RequestParam("user_prompt") userPrompt: String): ResponseEntity<List<User>> {
        // Возвращает данные в формате JSON
        val users = userService.getUsersByName(userPrompt)
        return ResponseEntity.ok(users)
    }
}
