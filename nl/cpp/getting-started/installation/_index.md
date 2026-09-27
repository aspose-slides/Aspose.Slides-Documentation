---
title: Installatie
type: docs
weight: 70
url: /nl/cpp/installation/
keywords:
- Aspose.Slides installeren
- Aspose.Slides downloaden
- Aspose.Slides gebruiken
- Aspose.Slides installatie
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Installeer Aspose.Slides voor C++ op Windows via NuGet in Visual Studio, of op Linux vanuit het ZIP-pakket met CMake, en controleer de installatie met een eerste programma."
---
## **Overzicht**

Aspose.Slides voor C++ wordt in twee vormen geleverd:

| Vorm | Gebruik het voor | Waar te verkrijgen |
|---|---|---|
| NuGet‑pakketten: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑bit) en [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑bit) | Visual Studio C++‑projecten op Windows | NuGet |
| ZIP‑pakketten voor Windows, Linux en macOS | Bouwprocessen zonder NuGet, zoals CMake‑projecten | De [download‑pagina](https://releases.aspose.com/slides/cpp/) |

Dit artikel laat zien hoe u het NuGet‑pakket installeert in Visual Studio onder Windows en hoe u het ZIP‑pakket gebruikt met CMake onder Linux. Beide routes eindigen met dezelfde controle: bouw en voer het eerste voorbeeld uit in [Create Presentations](/slides/nl/cpp/create-presentation/) .

## **Windows**

Onder Windows voegt u het NuGet‑pakket toe aan een Visual Studio C++‑project. Het pakket installeert ook de afhankelijkheid CodePorting.Translator.Cs2Cpp.Framework en kopieert de DLL‑s die uw programma nodig heeft naar de output‑map van de build.

Kies het pakket op basis van het platform waarvoor u bouwt: **Aspose.Slides.Cpp** voor x64 en **Aspose.Slides.Cpp.x86** voor Win32 (x86). Het Aspose.Slides.Cpp‑pakket wordt niet toegepast op een Win32‑build, waardoor de compiler de headers daar niet kan vinden.

Een ZIP‑pakket voor Windows is ook beschikbaar via de [download‑pagina](https://releases.aspose.com/slides/cpp/) .

### **Methode 1: Installeer of werk Aspose.Slides bij via de NuGet Package Manager**

1. Open Microsoft Visual Studio.  
2. Maak een C++ **Console‑app**‑project, of open een bestaand project.  
3. Klik in **Solution Explorer** met de rechtermuisknop op het project en kies **Manage NuGet Packages** (of ga naar **Project** > **Manage NuGet Packages**).  
4. Zoek onder **Browse** naar *Aspose.Slides.Cpp*.  
   ![Zoeken naar Aspose.Slides.Cpp in de NuGet Package Manager](installation_1.png)  
5. Klik op **Aspose.Slides.Cpp** (of **Aspose.Slides.Cpp.x86** voor een 32‑bit build) en klik vervolgens op **Install**.  
   * Als u Aspose.Slides al geïnstalleerd hebt en wilt bijwerken, klikt u in plaats daarvan op **Update**.

Het pakket wordt gedownload en in uw project opgenomen.

### **Methode 2: Installeer of werk Aspose.Slides bij via de Package Manager Console**

1. Open Microsoft Visual Studio.  
2. Maak een C++ **Console‑app**‑project, of open een bestaand project.  
3. Ga naar **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![De Package Manager Console openen](installation_2.png)  
4. Voer dit commando uit:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Voor een 32‑bit (Win32) build installeert u in plaats daarvan het x86‑pakket:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Het Install‑Package‑commando uitvoeren](installation_3.png)

   Wanneer de installatie voltooid is, verschijnen er bevestigingsberichten. Het pakket wordt verspreid onder de [Aspose EULA](https://about.aspose.com/legal/eula).  
   ![Bevestigingsberichten van de installatie](installation_4.png)

   Om het pakket bij te werken, voert u `Update-Package Aspose.Slides.Cpp` (of `Update-Package Aspose.Slides.Cpp.x86`) uit in de Package Manager Console.

### **Controleren of de installatie gelukt is**

1. Vervang de inhoud van het *.cpp*‑bestand van het project (het bestand dat `main` bevat) door het eerste voorbeeld in [Create Presentations](/slides/nl/cpp/create-presentation/).  
2. Selecteer in de werkbalk het **x64**‑platform, of **x86** als u Aspose.Slides.Cpp.x86 hebt geïnstalleerd.  
3. Druk op **Ctrl+F5** om het programma te bouwen en uit te voeren.

Het programma slaat *hello.pptx* op in de projectmap, die de standaardwerkomgeving is wanneer Visual Studio een programma uitvoert.

## **Linux**

Onder Linux gebruikt u het Linux ZIP‑pakket met CMake. Het bevat de Aspose.Slides‑bibliotheek, de afhankelijkheid CodePorting.Translator.Cs2Cpp.Framework en een CMake‑configuratiebestand voor elk van beide. De bibliotheken zijn gebouwd voor x86_64‑Linux met glibc 2.23 of hoger.

1. Installeer een C++‑compiler, make, CMake, unzip en de fontconfig‑bibliotheek, waarvan de Aspose.Slides‑bibliotheken afhankelijk zijn. Op Debian en Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Maak een projectmap aan en ga ernaartoe:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Download het Linux ZIP (**Aspose.Slides for C++ Linux**) van de [download‑pagina](https://releases.aspose.com/slides/cpp/) naar de projectmap en pak het uit in de submap *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Maak een bestand *CMakeLists.txt* aan in de projectmap met de volgende inhoud:

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

   De twee `find_package`‑aanroepen laden de CMake‑configuratiebestanden uit het uitgepakte pakket. Het framework wordt eerst gevonden omdat Aspose.Slides ervan afhankelijk is. Door het `Aspose.Slides.Cpp`‑target te linken, worden de include‑mappen en beide bibliotheken aan de build toegevoegd.

5. Sla het eerste voorbeeld uit [Create Presentations](/slides/nl/cpp/create-presentation/) op als *main.cpp* in de projectmap.  
6. Build en voer het programma uit:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Het programma slaat *hello.pptx* op in de huidige map. CMake registreert de locatie van de bibliotheken in het programma, zodat u `LD_LIBRARY_PATH` niet hoeft in te stellen zolang de map *aspose-slides-cpp* op zijn plek blijft.

De lettertypen die in uw presentaties worden gebruikt, of geschikte vervangers, moeten op het systeem geïnstalleerd zijn zodat tekst correct wordt gerenderd bij het converteren van slides naar PDF of afbeeldingen.

## **FAQ**

**Is er een gratis versie of een proefbeperking?**  
Ja. Zonder licentie werkt Aspose.Slides in evaluatiemodus: er wordt een evaluatiewatermerk aan elke slide toegevoegd die wordt opgeslagen en wordt tekst uit presentaties afgekapt. Om deze beperkingen te verwijderen, past u een geldige [licentie](/slides/nl/cpp/licensing/) toe.

**Waarom meldt de compiler dat hij *DOM/Presentation.h* niet kan openen?**  
Het geïnstalleerde pakket komt niet overeen met het platform waarvoor u bouwt. Aspose.Slides.Cpp is alleen van toepassing op x64‑builds, en Aspose.Slides.Cpp.x86 alleen op Win32‑builds. Selecteer het juiste platform in Visual Studio, of installeer het andere pakket.