package com.example.orm.api

import org.springframework.stereotype.Controller
import com.example.orm.entity.User
import com.example.orm.service.UserService
import org.springframework.http.ResponseEntity
import org.springframework.web.bind.annotation.*

@Controller
@RequestMapping("/")
class UserController(
    private val userService: UserService
) {
    @GetMapping
    fun index(): String {
        return "index"
    }

    @PostMapping("/select_data")
    fun selectData(@RequestParam("user_prompt") userPrompt: String): ResponseEntity<List<User>> {
        val users = userService.getUsersByName(userPrompt)
        return ResponseEntity.ok(users)
    }
}
