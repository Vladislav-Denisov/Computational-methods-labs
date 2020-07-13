get_filename_component(ProjectId ${CMAKE_CURRENT_SOURCE_DIR} NAME)

if ( LAB4 OR ALL)
	set(ProjectId "${ProjectId}")
	project(${ProjectId} LANGUAGES CSharp)
	message( STATUS "-- " ${ProjectId} )

	# Include CMake utilities for CSharp, for WinForm and WPF application support.
	include(CSharpUtilities)

	# Define the executable, including any .cs files. 
	# The .resx and other Properties files are optional here, but including them makes them visible in the VS solution for easy editing. 
	add_executable(${ProjectId}
		App.config
		Form1.cs
		Form1.Designer.cs
		Program.cs
		Thermal.cs
		Properties/AssemblyInfo.cs
		Properties/Resources.Designer.cs
		Properties/Resources.resx
		Properties/Settings.Designer.cs
		Properties/Settings.settings
	)

	# Set the .NET Framework version for the executable.
	set_property(TARGET ${ProjectId} PROPERTY VS_DOTNET_TARGET_FRAMEWORK_VERSION "v4.6.1")
	# Set the executable to be 32-bit.
	set_property(TARGET ${ProjectId} PROPERTY WIN32_EXECUTABLE TRUE)
	# Set the C# language version (defaults to 3.0).
	set(CMAKE_CSharp_FLAGS "/langversion:latest")

	# Set the source file properties for Windows Forms use.
	csharp_set_windows_forms_properties(
		Form1.cs
		Form1.Designer.cs
		Program.cs
		Thermal.cs
		Properties/AssemblyInfo.cs
		Properties/Resources.Designer.cs
		Properties/Resources.resx
		Properties/Settings.Designer.cs
		Properties/Settings.settings
	)

	# Add in the .NET reference libraries.
	set_property(TARGET ${ProjectId} PROPERTY VS_DOTNET_REFERENCES
		"Microsoft.CSharp"
		"System"
		"System.Core"
		"System.Data"
		"System.Drawing"
		"System.Windows.Forms"
		"System.Windows.Forms.DataVisualization"
	)
else( LAB4 OR ALL)
	message( STATUS "-- ${ProjectId} - NOT BUILD!"  )
endif( LAB4 OR ALL)