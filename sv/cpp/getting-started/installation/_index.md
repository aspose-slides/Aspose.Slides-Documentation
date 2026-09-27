---
title: Installation
type: docs
weight: 70
url: /sv/cpp/installation/
keywords:
- installera Aspose.Slides
- ladda ner Aspose.Slides
- använd Aspose.Slides
- Aspose.Slides-installation
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Installera Aspose.Slides för C++ på Windows från NuGet i Visual Studio, eller på Linux från ZIP-paketet med CMake, och kontrollera installationen med ett första program."
---
## **Översikt**

Aspose.Slides for C++ is distributed in two forms:

| Form | Använd den för | Var får du den |
|---|---|---|
| NuGet-paket: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) and [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | Visual Studio C++‑projekt på Windows | NuGet |
| ZIP‑paket för Windows, Linux och macOS | Byggningar utan NuGet, t.ex. CMake‑projekt | [nedladdningssidan](https://releases.aspose.com/slides/sv/cpp/) |

This article shows how to install the NuGet package in Visual Studio on Windows and how to use the ZIP package with CMake on Linux. Both routes end with the same check: build and run the first example in [Create Presentations](/slides/sv/cpp/create-presentation/).

## **Windows**

På Windows lägger du till NuGet‑paketet i ett Visual Studio C++‑project. Paketet installerar också dess beroende, CodePorting.Translator.Cs2Cpp.Framework, och kopierar DLL‑filerna som ditt program behöver till byggoutput‑mappen.

Välj paketet efter den plattform du bygger för: **Aspose.Slides.Cpp** för x64, och **Aspose.Slides.Cpp.x86** för Win32 (x86). Paketet Aspose.Slides.Cpp tillämpas inte på en Win32‑byggnation, så kompilatorn kan inte hitta dess rubriker där.

Ett Windows ZIP‑paket finns också tillgängligt på [nedladdningssidan](https://releases.aspose.com/slides/sv/cpp/).

### **Metod 1: Installera eller uppdatera Aspose.Slides från NuGet‑pakethanteraren**

1. Öppna Microsoft Visual Studio.
2. Skapa ett C++ **Console App**‑projekt, eller öppna ett befintligt projekt.
3. I **Solution Explorer**, högerklicka på projektet och välj **Manage NuGet Packages** (eller gå till **Project** > **Manage NuGet Packages**).
4. Under **Browse**, sök efter *Aspose.Slides.Cpp*.
![Söker efter Aspose.Slides.Cpp i NuGet‑pakethanteraren](installation_1.png)
5. Klicka på **Aspose.Slides.Cpp** (eller **Aspose.Slides.Cpp.x86** för en 32‑bit‑byggnation) och klicka sedan på **Install**.
   * Om du redan har installerat Aspose.Slides och vill uppdatera det, klicka på **Update** istället.

Paketet laddas ner och refereras i ditt projekt.

### **Metod 2: Installera eller uppdatera Aspose.Slides via Package Manager Console**

1. Öppna Microsoft Visual Studio.
2. Skapa ett C++ **Console App**‑projekt, eller öppna ett befintligt projekt.
3. Gå till **Tools** > **NuGet Package Manager** > **Package Manager Console**.
![Öppnar Package Manager Console](installation_2.png)
4. Kör detta kommando:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   För en 32‑bit (Win32) byggnation, installera x86‑paketet istället:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

![Kör Install-Package‑kommandot](installation_3.png)

När installationen är klar visas bekräftelsemeddelanden. Paketet distribueras enligt [Aspose EULA](https://about.aspose.com/legal/eula).
![Bekräftelsemeddelanden för installation](installation_4.png)

För att uppdatera paketet, kör `Update-Package Aspose.Slides.Cpp` (eller `Update-Package Aspose.Slides.Cpp.x86`) i Package Manager Console.

### **Kontrollera installationen**

1. Ersätt innehållet i projektets huvud‑*.cpp*-fil (filen som innehåller `main`) med det första exemplet i [Skapa presentationer](/slides/sv/cpp/create-presentation/).
2. I verktygsfältet väljer du plattformen **x64**, eller **x86** om du installerade Aspose.Slides.Cpp.x86.
3. Tryck på **Ctrl+F5** för att bygga och köra programmet.

Programmet sparar *hello.pptx* i projektmappen, vilket är standardarbetskatalogen när Visual Studio kör ett program.

## **Linux**

På Linux används Linux‑ZIP‑paketet med CMake. Det innehåller Aspose.Slides‑biblioteket, dess beroende CodePorting.Translator.Cs2Cpp.Framework och en CMake‑konfigurationsfil för var och en av dem. Biblioteken är byggda för x86_64‑Linux med glibc 2.23 eller senare.

1. Installera en C++‑kompilator, make, CMake, unzip och fontconfig‑biblioteket, som Aspose.Slides‑biblioteken är beroende av. På Debian och Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Skapa en projektmapp och gå in i den:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Ladda ner Linux‑ZIP‑paketet (**Aspose.Slides for C++ Linux**) från [nedladdningssidan](https://releases.aspose.com/slides/sv/cpp/) till projektmappen och packa upp det i underkatalogen *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Skapa en fil med namnet *CMakeLists.txt* i projektmappen med följande innehåll:

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

   De två `find_package`‑anropen läser in CMake‑konfigurationsfilerna från det uppackade paketet. Ramverket hittas först eftersom Aspose.Slides är beroende av det. Länkning av mål `Aspose.Slides.Cpp` lägger till inkluderingsmapparna och båda biblioteken i bygget.

5. Spara det första exemplet i [Skapa presentationer](/slides/sv/cpp/create-presentation/) som *main.cpp* i projektmappen.
6. Bygg och kör programmet:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Programmet sparar *hello.pptx* i den aktuella mappen. CMake lagrar bibliotekens plats i programmet, så du behöver inte sätta `LD_LIBRARY_PATH` så länge *aspose-slides-cpp*-mappen förblir på plats.

Typsnitten som används i dina presentationer, eller lämpliga ersättningar, måste vara installerade på systemet för att text ska renderas korrekt när du konverterar bilder till PDF eller bildfiler.

## **FAQ**

**Finns det en gratis version eller begränsning i provperioden?**

Ja. Utan licens kör Aspose.Slides i evalueringsläge: det lägger till ett evalueringsvattenmärke på varje bild den sparar och trunkerar text som läses från presentationer. För att ta bort dessa begränsningar, tillämpa en giltig [licens](/slides/sv/cpp/licensing/).

**Varför rapporterar kompilatorn att den inte kan öppna *DOM/Presentation.h*?**

Det installerade paketet matchar inte plattformen du bygger för. Aspose.Slides.Cpp gäller endast för x64‑byggen, och Aspose.Slides.Cpp.x86 endast för Win32‑byggen. Välj rätt plattform i Visual Studio, eller installera det andra paketet.