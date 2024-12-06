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

/*
@Repository("userCustomRepositoryImpl")
class UserCustomRepositoryImpl(
    @PersistenceContext private val entityManager: EntityManager
) : UserCustomRepository {
    override fun unsafeFindUsersByName(name: String): List<User> {
        val query = "SELECT u FROM User u WHERE u.name = '$name'"
        return entityManager.createQuery(query, User::class.java).resultList
    }
}
*/
