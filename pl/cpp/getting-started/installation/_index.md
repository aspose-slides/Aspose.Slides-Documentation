---
title: Instalacja
type: docs
weight: 70
url: /pl/cpp/installation/
keywords:
- zainstaluj Aspose.Slides
- pobierz Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Zainstaluj Aspose.Slides dla C++ w systemie Windows z NuGet w Visual Studio lub w systemie Linux z pakietu ZIP przy użyciu CMake i sprawdź instalację pierwszym programem."
---
## **Przegląd**

Aspose.Slides for C++ jest dystrybuowany w dwóch formach:

| Forma | Do czego używać | Gdzie ją uzyskać |
|---|---|---|
| Pakiety NuGet: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64-bit) oraz [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32-bit) | Projekty C++ w Visual Studio na systemie Windows | NuGet |
| Pakiety ZIP dla Windows, Linux i macOS | Budowy bez NuGet, takie jak projekty CMake | Strona [strona pobierania](https://releases.aspose.com/slides/pl/cpp/) |

Ten artykuł pokazuje, jak zainstalować pakiet NuGet w Visual Studio w systemie Windows oraz jak używać pakietu ZIP z CMake w systemie Linux. Obie ścieżki kończą się tym samym sprawdzeniem: zbuduj i uruchom pierwszy przykład w [Tworzenie prezentacji](/slides/pl/cpp/create-presentation/).

## **Windows**

W systemie Windows dodaj pakiet NuGet do projektu C++ w Visual Studio. Pakiet instaluje również swoją zależność CodePorting.Translator.Cs2Cpp.Framework i kopiowanie plików DLL potrzebnych programowi do folderu wyjściowego kompilacji.

Wybierz pakiet odpowiedni dla platformy, na której budujesz: **Aspose.Slides.Cpp** dla x64 oraz **Aspose.Slides.Cpp.x86** dla Win32 (x86). Pakiet Aspose.Slides.Cpp nie jest stosowany w kompilacji Win32, więc kompilator nie może znaleźć jego plików nagłówkowych.

Pakiet ZIP dla Windows jest również dostępny na [stronie pobierania](https://releases.aspose.com/slides/pl/cpp/).

### **Metoda 1: Zainstaluj lub zaktualizuj Aspose.Slides z Menedżera Pakietów NuGet**

1. Otwórz Microsoft Visual Studio.  
2. Utwórz projekt C++ **Console App**, lub otwórz istniejący projekt.  
3. W **Solution Explorer**, kliknij prawym przyciskiem projektu i wybierz **Manage NuGet Packages** (lub przejdź do **Project** > **Manage NuGet Packages**).  
4. W zakładce **Browse** wyszukaj *Aspose.Slides.Cpp*.  
   ![Searching for Aspose.Slides.Cpp in the NuGet Package Manager](installation_1.png)  
5. Kliknij **Aspose.Slides.Cpp** (lub **Aspose.Slides.Cpp.x86** dla kompilacji 32-bitowej) i następnie kliknij **Install**.  
   * Jeśli już zainstalowałeś Aspose.Slides i chcesz go zaktualizować, kliknij **Update**.  

Pakiet zostaje pobrany i dodany jako odwołanie w Twoim projekcie.

### **Metoda 2: Zainstaluj lub zaktualizuj Aspose.Slides przez Konsolę Menedżera Pakietów**

1. Otwórz Microsoft Visual Studio.  
2. Utwórz projekt C++ **Console App**, lub otwórz istniejący projekt.  
3. Przejdź do **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Opening the Package Manager Console](installation_2.png)  
4. Uruchom tę komendę:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Dla kompilacji 32-bitowej (Win32) zainstaluj pakiet x86 zamiast tego:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Running the Install-Package command](installation_3.png)

   Po zakończeniu instalacji pojawiają się komunikaty potwierdzające. Pakiet jest rozpowszechniany na warunkach [Aspose EULA](https://about.aspose.com/legal/eula).  
   ![Installation confirmation messages](installation_4.png)

   Aby zaktualizować pakiet, uruchom `Update-Package Aspose.Slides.Cpp` (lub `Update-Package Aspose.Slides.Cpp.x86`) w Konsoli Menedżera Pakietów.

### **Sprawdź instalację**

1. Zastąp zawartość głównego pliku *.cpp* projektu (pliku zawierającego `main`) pierwszym przykładem w [Tworzenie prezentacji](/slides/pl/cpp/create-presentation/).  
2. W pasku narzędzi wybierz platformę **x64**, lub **x86** jeśli zainstalowałeś Aspose.Slides.Cpp.x86.  
3. Naciśnij **Ctrl+F5**, aby zbudować i uruchomić program.  

Program zapisuje *hello.pptx* w folderze projektu, który jest domyślnym katalogiem roboczym podczas uruchamiania programu w Visual Studio.

## **Linux**

W systemie Linux użyj pakietu ZIP Linux z CMake. Zawiera on bibliotekę Aspose.Slides, jej zależność CodePorting.Translator.Cs2Cpp.Framework oraz plik konfiguracyjny CMake dla każdej z nich. Biblioteki są zbudowane dla Linux x86_64 z glibc 2.23 lub nowszą.

1. Zainstaluj kompilator C++, make, CMake, unzip oraz bibliotekę fontconfig, od której zależą biblioteki Aspose.Slides. Na Debianie i Ubuntu:

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Utwórz folder projektu i przejdź do niego:

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Pobierz Linux ZIP (**Aspose.Slides for C++ Linux**) ze [strony pobierania](https://releases.aspose.com/slides/pl/cpp/) do folderu projektu i rozpakuj go do podfolderu *aspose-slides-cpp*:

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Utwórz plik o nazwie *CMakeLists.txt* w folderze projektu z następującą treścią:

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

   Dwie wywołania `find_package` ładowują pliki konfiguracyjne CMake z rozpakowanego pakietu. Framework jest znajdowany najpierw, ponieważ Aspose.Slides od niego zależy. Łączenie docelowego `Aspose.Slides.Cpp` dodaje foldery include oraz obie biblioteki do kompilacji.

5. Zapisz pierwszy przykład z [Tworzenie prezentacji](/slides/pl/cpp/create-presentation/) jako *main.cpp* w folderze projektu.  
6. Zbuduj i uruchom program:

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Program zapisuje *hello.pptx* w bieżącym folderze. CMake zapisuje lokalizację bibliotek w programie, więc nie musisz ustawiać `LD_LIBRARY_PATH`, pod warunkiem że folder *aspose-slides-cpp* pozostaje na miejscu.

Czcionki używane w prezentacjach, lub odpowiednie zamienniki, muszą być zainstalowane w systemie, aby tekst był prawidłowo renderowany przy konwersji slajdów na PDF lub obrazy.

## **FAQ**

**Czy istnieje wersja darmowa lub ograniczenia wersji próbnej?**

Tak. Bez licencji Aspose.Slides działa w trybie ewaluacyjnym: dodaje znak wodny ewaluacji do każdego zapisanego slajdu i przycina tekst odczytywany z prezentacji. Aby usunąć te ograniczenia, zastosuj ważną [licencję](/slides/pl/cpp/licensing/).

**Dlaczego kompilator zgłasza, że nie może otworzyć *DOM/Presentation.h*?**

Zainstalowany pakiet nie odpowiada platformie, na której budujesz. Aspose.Slides.Cpp działa wyłącznie dla kompilacji x64, a Aspose.Slides.Cpp.x86 tylko dla kompilacji Win32. Wybierz odpowiednią platformę w Visual Studio lub zainstaluj drugi pakiet.