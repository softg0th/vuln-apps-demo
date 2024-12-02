package com.example.orm.service

import com.example.orm.entity.User
import com.example.orm.repository.UserRepository
import org.springframework.stereotype.Service

@Service
class UserService(
    private val userRepository: UserRepository
) {
    fun getUsersByName(name: String): List<User> {
        return userRepository.findByUsername(name)
    }
}
