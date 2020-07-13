get_filename_component(ProjectId ${CMAKE_CURRENT_SOURCE_DIR} NAME)

if ( LAB2 OR ALL)
	set(ProjectId "${ProjectId}")
	project( ${ProjectId} )
	message( STATUS "-- " ${ProjectId} )

	file(GLOB_RECURSE header_files "include/*.h")
	file(GLOB_RECURSE source_files "*.cpp")

	add_executable(${ProjectId} ${source_files} ${header_files})

else( LAB2 OR ALL)
	message( STATUS "-- ${ProjectId} - NOT BUILD!"  )
endif( LAB2 OR ALL)
