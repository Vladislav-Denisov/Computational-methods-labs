cmake_minimum_required( VERSION 3.8 )

include( "${CMAKE_CURRENT_SOURCE_DIR}/cmake/Config.cmake" )

project( "Laboratory work on computational methods" )

message( STATUS "LABORATORY WORS ON COMPUTATIONAL METHODS" )

################################ LAB1 ################################
option(LAB1 OFF)

################################ LAB2 ################################
option(LAB2 OFF)

################################ LAB3 ################################
option(LAB3 OFF)

################################ LAB4 ################################
option(LAB4 OFF)

################################ ALL ################################
option(ALL OFF)

add_subdirectory(labs)