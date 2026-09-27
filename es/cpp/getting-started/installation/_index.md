---
title: Instalación
type: docs
weight: 70
url: /es/cpp/installation/
keywords:
- instalar Aspose.Slides
- descargar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Instale Aspose.Slides para C++ en Windows desde NuGet en Visual Studio, o en Linux desde el paquete ZIP con CMake, y compruebe la instalación con un primer programa."
---
## **Descripción general**

Aspose.Slides for C++ is distributed in two forms:

| Forma | Uso | Dónde obtenerlo |
|---|---|---|
| Paquetes NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64 bits) y [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32 bits) | Proyectos C++ de Visual Studio en Windows | NuGet |
| Paquetes ZIP para Windows, Linux y macOS | Compilaciones sin NuGet, como proyectos CMake | La [página de descarga](https://releases.aspose.com/slides/es/cpp/) |

Este artículo muestra cómo instalar el paquete NuGet en Visual Studio en Windows y cómo usar el paquete ZIP con CMake en Linux. Ambas rutas terminan con la misma comprobación: compilar y ejecutar el primer ejemplo en [Crear presentaciones](/slides/es/cpp/create-presentation/).

## **Windows**

En Windows, añada el paquete NuGet a un proyecto C++ de Visual Studio. El paquete también instala su dependencia, CodePorting.Translator.Cs2Cpp.Framework, y copia los DLL que su programa necesita en la carpeta de salida de la compilación.

Elija el paquete según la plataforma para la que compile: **Aspose.Slides.Cpp** para x64 y **Aspose.Slides.Cpp.x86** para Win32 (x86). El paquete Aspose.Slides.Cpp no se aplica a una compilación Win32, por lo que el compilador no puede encontrar sus archivos de encabezado allí.

También hay un paquete ZIP para Windows disponible en la [página de descarga](https://releases.aspose.com/slides/es/cpp/).

### **Método 1: Instalar o actualizar Aspose.Slides desde el Administrador de paquetes NuGet**

1. Abra Microsoft Visual Studio.  
2. Cree un proyecto **Console App** de C++, o abra un proyecto existente.  
3. En **Solution Explorer**, haga clic con el botón derecho del ratón sobre el proyecto y seleccione **Manage NuGet Packages** (o vaya a **Project** > **Manage NuGet Packages**).  
4. En **Browse**, busque *Aspose.Slides.Cpp*.  
   ![Searching for Aspose.Slides.Cpp in the NuGet Package Manager](installation_1.png)  
5. Haga clic en **Aspose.Slides.Cpp** (o **Aspose.Slides.Cpp.x86** para una compilación de 32 bits) y luego haga clic en **Install**.  
   * Si ya instaló Aspose.Slides y desea actualizarlo, haga clic en **Update** en su lugar.

El paquete se descarga y se referencia en su proyecto.

### **Método 2: Instalar o actualizar Aspose.Slides mediante la consola del Administrador de paquetes**

1. Abra Microsoft Visual Studio.  
2. Cree un proyecto **Console App** de C++, o abra un proyecto existente.  
3. Vaya a **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Opening the Package Manager Console](installation_2.png)  
4. Ejecute este comando:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Para una compilación de 32 bits (Win32), instale el paquete x86 en su lugar:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Running the Install-Package command](installation_3.png)

   Cuando la instalación finaliza, aparecen mensajes de confirmación. El paquete se distribuye bajo la [Aspose EULA](https://about.aspose.com/legal/eula).  
   ![Installation confirmation messages](installation_4.png)

   Para actualizar el paquete, ejecute `Update-Package Aspose.Slides.Cpp` (o `Update-Package Aspose.Slides.Cpp.x86`) en la consola del Administrador de paquetes.

### **Comprobar la instalación**

1. Reemplace el contenido del archivo *.cpp* principal del proyecto (el archivo que contiene `main`) con el primer ejemplo en [Crear presentaciones](/slides/es/cpp/create-presentation/).  
2. En la barra de herramientas, seleccione la plataforma **x64**, o **x86** si instaló Aspose.Slides.Cpp.x86.  
3. Pulse **Ctrl+F5** para compilar y ejecutar el programa.

El programa guarda *hello.pptx* en la carpeta del proyecto, que es el directorio de trabajo predeterminado cuando Visual Studio ejecuta un programa.

## **Linux**

En Linux, utilice el paquete ZIP de Linux con CMake. Contiene la biblioteca Aspose.Slides, su dependencia CodePorting.Translator.Cs2Cpp.Framework y un archivo de configuración CMake para cada una de ellas. Las bibliotecas están compiladas para Linux x86_64 con glibc 2.23 o posterior.

1. Instale un compilador C++, make, CMake, unzip y la biblioteca fontconfig, de la que dependen las bibliotecas Aspose.Slides. En Debian y Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Cree una carpeta de proyecto y navegue a ella:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Descargue el ZIP de Linux (**Aspose.Slides for C++ Linux**) de la [página de descarga](https://releases.aspose.com/slides/es/cpp/) en la carpeta del proyecto y descomprímalo en la subcarpeta *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Cree un archivo llamado *CMakeLists.txt* en la carpeta del proyecto con el siguiente contenido:

   ```cmake
   cmake_minimum_required(VERSION 3.13)
   project(HelloSlides CXX)

   set(CMAKE_CXX_STANDARD 14)
   set(CMAKE_CXX_STANDARD_REQUIRED ON)

   set(ASPOSE_SLIDES_DIR "${CMAKE_CURRENT_SOURCE_DIR}/aspose-slides-cpp")
   find_package(CodePorting.Translator.Cs2Cpp.Framework REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)
   find_package(Aspose.Slides.Cpp REQUIRED CONFIG PATHS "${ASPOSE_SLIDES_DIR}" NO_DEFAULT_PATH)

   add_executable(hello main.cpp)
   target_link_libraries(hello PRIVATE Aspose.Slides.Cpp)
   ```

   Las dos llamadas `find_package` cargan los archivos de configuración CMake del paquete descomprimido. El framework se encuentra primero porque Aspose.Slides depende de él. Enlazar el objetivo `Aspose.Slides.Cpp` añade las carpetas de inclusión y ambas bibliotecas a la compilación.

5. Guarde el primer ejemplo en [Crear presentaciones](/slides/es/cpp/create-presentation/) como *main.cpp* en la carpeta del proyecto.  
6. Compile y ejecute el programa:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

El programa guarda *hello.pptx* en la carpeta actual. CMake registra la ubicación de las bibliotecas en el programa, por lo que no es necesario establecer `LD_LIBRARY_PATH` mientras la carpeta *aspose-slides-cpp* permanezca en su lugar.

Las fuentes usadas en sus presentaciones, o sustitutos adecuados, deben estar instaladas en el sistema para que el texto se renderice correctamente al convertir diapositivas a PDF o imágenes.

## **Preguntas frecuentes**

**¿Existe una versión gratuita o limitación de prueba?**

Sí. Sin una licencia, Aspose.Slides se ejecuta en modo de evaluación: añade una marca de agua de evaluación a cada diapositiva que guarda y trunca el texto leído de las presentaciones. Para eliminar estas limitaciones, aplique una [licencia](/slides/es/cpp/licensing/) válida.

**¿Por qué el compilador indica que no puede abrir *DOM/Presentation.h*?**

El paquete instalado no coincide con la plataforma para la que compila. Aspose.Slides.Cpp solo se aplica a compilaciones x64, y Aspose.Slides.Cpp.x86 solo a compilaciones Win32. Seleccione la plataforma adecuada en Visual Studio o instale el otro paquete.