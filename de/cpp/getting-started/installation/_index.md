---
title: Installation
type: docs
weight: 70
url: /de/cpp/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides Installation
- NuGet
- CMake
- Windows
- Linux
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für C++ unter Windows über NuGet in Visual Studio oder unter Linux über das ZIP-Paket mit CMake und prüfen Sie die Installation mit einem ersten Programm."
---
## **Übersicht**

Aspose.Slides for C++ wird in zwei Formen bereitgestellt:

| Form | Verwendung | Wo erhalten |
|---|---|---|
| NuGet-Pakete: [Aspose.Slides.Cpp](https://www.nuget.org/packages/Aspose.Slides.Cpp/) (64‑Bit) und [Aspose.Slides.Cpp.x86](https://www.nuget.org/packages/Aspose.Slides.Cpp.x86/) (32‑Bit) | Visual‑Studio‑C++‑Projekte unter Windows | NuGet |
| ZIP‑Pakete für Windows, Linux und macOS | Builds ohne NuGet, z. B. CMake‑Projekte | Die [Download‑Seite](https://releases.aspose.com/slides/cpp/) |

Dieser Artikel zeigt, wie das NuGet‑Paket in Visual Studio unter Windows installiert wird und wie das ZIP‑Paket mit CMake unter Linux verwendet wird. Beide Wege enden mit derselben Überprüfung: Das erste Beispiel in [Präsentationen erstellen](/slides/de/cpp/create-presentation/) bauen und ausführen.

## **Windows**

Unter Windows fügen Sie das NuGet‑Paket zu einem Visual‑Studio‑C++‑Projekt hinzu. Das Paket installiert außerdem seine Abhängigkeit CodePorting.Translator.Cs2Cpp.Framework und kopiert die DLLs, die Ihr Programm benötigt, in den Ausgabebereich des Builds.

Wählen Sie das Paket entsprechend der Plattform, für die Sie bauen: **Aspose.Slides.Cpp** für x64 und **Aspose.Slides.Cpp.x86** für Win32 (x86). Das Aspose.Slides.Cpp‑Paket wird nicht für einen Win32‑Build verwendet, sodass der Compiler dort seine Header nicht finden kann.

Ein Windows‑ZIP‑Paket ist ebenfalls auf der [Download‑Seite](https://releases.aspose.com/slides/cpp/) verfügbar.

### **Methode 1: Aspose.Slides über den NuGet‑Paket‑Manager installieren oder aktualisieren**

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie ein C++ **Console App**‑Projekt oder öffnen Sie ein bestehendes Projekt.  
3. Im **Solution Explorer** klicken Sie mit der rechten Maustaste auf das Projekt und wählen **Manage NuGet Packages** (oder gehen Sie zu **Project** > **Manage NuGet Packages**).  
4. Unter **Browse** suchen Sie nach *Aspose.Slides.Cpp*.  
   ![Suche nach Aspose.Slides.Cpp im NuGet‑Paket‑Manager](installation_1.png)  
5. Klicken Sie auf **Aspose.Slides.Cpp** (oder **Aspose.Slides.Cpp.x86** für einen 32‑Bit‑Build) und dann auf **Install**.  
   * Wenn Sie Aspose.Slides bereits installiert haben und es aktualisieren möchten, klicken Sie stattdessen auf **Update**.

Das Paket wird heruntergeladen und in Ihrem Projekt referenziert.

### **Methode 2: Aspose.Slides über die Package‑Manager‑Konsole installieren oder aktualisieren**

1. Öffnen Sie Microsoft Visual Studio.  
2. Erstellen Sie ein C++ **Console App**‑Projekt oder öffnen Sie ein bestehendes Projekt.  
3. Gehen Sie zu **Tools** > **NuGet Package Manager** > **Package Manager Console**.  
   ![Öffnen der Package‑Manager‑Konsole](installation_2.png)  
4. Führen Sie diesen Befehl aus:

   ```powershell
   Install-Package Aspose.Slides.Cpp
   ```

   Für einen 32‑Bit‑(Win32‑)Build installieren Sie stattdessen das x86‑Paket:

   ```powershell
   Install-Package Aspose.Slides.Cpp.x86
   ```

   ![Ausführen des Install‑Package‑Befehls](installation_3.png)

Wenn die Installation abgeschlossen ist, erscheinen Bestätigungsnachrichten. Das Paket wird unter der [Aspose EULA](https://about.aspose.com/legal/eula) bereitgestellt.  
![Bestätigungsnachrichten der Installation](installation_4.png)

Um das Paket zu aktualisieren, führen Sie `Update-Package Aspose.Slides.Cpp` (oder `Update-Package Aspose.Slides.Cpp.x86`) in der Package‑Manager‑Konsole aus.

### **Installation prüfen**

1. Ersetzen Sie den Inhalt der *.cpp*‑Hauptdatei des Projekts (die Datei, die `main` enthält) durch das erste Beispiel in [Präsentationen erstellen](/slides/de/cpp/create-presentation/).  
2. Wählen Sie in der Symbolleiste die Plattform **x64** aus, oder **x86**, wenn Sie Aspose.Slides.Cpp.x86 installiert haben.  
3. Drücken Sie **Ctrl+F5**, um das Programm zu bauen und auszuführen.

Das Programm speichert *hello.pptx* im Projektordner, der das Standard‑Arbeitsverzeichnis ist, wenn Visual Studio ein Programm ausführt.

## **Linux**

Unter Linux verwenden Sie das Linux‑ZIP‑Paket mit CMake. Es enthält die Aspose.Slides‑Bibliothek, ihre Abhängigkeit CodePorting.Translator.Cs2Cpp.Framework und für jede eine CMake‑Konfigurationsdatei. Die Bibliotheken wurden für x86_64‑Linux mit glibc 2.23 oder neuer erstellt.

1. Installieren Sie einen C++‑Compiler, make, CMake, unzip und die Bibliothek fontconfig, von der die Aspose.Slides‑Bibliotheken abhängen. Auf Debian und Ubuntu:  

   ```bash
   sudo apt-get update && sudo apt-get install -y g++ make cmake unzip libfontconfig1
   ```

2. Erstellen Sie einen Projektordner und wechseln Sie in diesen:  

   ```bash
   mkdir hello-slides
   cd hello-slides
   ```

3. Laden Sie das Linux‑ZIP (**Aspose.Slides for C++ Linux**) von der [Download‑Seite](https://releases.aspose.com/slides/cpp/) in den Projektordner herunter und entpacken Sie es in den Unterordner *aspose-slides-cpp*:  

   ```bash
   unzip aspose-slides-cpp-linux-*.zip -d aspose-slides-cpp
   ```

4. Erstellen Sie im Projektordner eine Datei mit dem Namen *CMakeLists.txt* mit folgendem Inhalt:  

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

   Die beiden `find_package`‑Aufrufe laden die CMake‑Konfigurationsdateien aus dem entpackten Paket. Das Framework wird zuerst gefunden, da Aspose.Slides davon abhängt. Das Verlinken des `Aspose.Slides.Cpp`‑Ziels fügt die Include‑Ordner und beide Bibliotheken dem Build hinzu.

5. Speichern Sie das erste Beispiel aus [Präsentationen erstellen](/slides/de/cpp/create-presentation/) als *main.cpp* im Projektordner.  
6. Bauen und führen Sie das Programm aus:  

   ```bash
   cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
   cmake --build build
   ./build/hello
   ```

Das Programm speichert *hello.pptx* im aktuellen Ordner. CMake speichert den Speicherort der Bibliotheken im Programm, sodass Sie `LD_LIBRARY_PATH` nicht setzen müssen, solange der *aspose-slides-cpp*‑Ordner an seinem Platz bleibt.

Die in Ihren Präsentationen verwendeten Schriften oder geeignete Ersatzschriften müssen im System installiert sein, damit der Text beim Konvertieren von Folien in PDF oder Bilder korrekt dargestellt wird.

## **FAQ**

**Gibt es eine kostenlose Version oder Testbeschränkung?**

Ja. Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Blatt ein Evaluierungs‑Wasserzeichen hinzu und kürzt Text, der aus Präsentationen gelesen wird. Um diese Einschränkungen zu entfernen, verwenden Sie eine gültige [Lizenz](/slides/de/cpp/licensing/).

**Warum meldet der Compiler, dass er *DOM/Presentation.h* nicht öffnen kann?**

Das installierte Paket stimmt nicht mit der Plattform überein, für die Sie bauen. Aspose.Slides.Cpp gilt nur für x64‑Builds und Aspose.Slides.Cpp.x86 nur für Win32‑Builds. Wählen Sie die passende Plattform in Visual Studio aus oder installieren Sie das andere Paket.