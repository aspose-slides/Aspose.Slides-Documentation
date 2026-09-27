---
title: Instalcja
type: docs
weight: 70
url: /pl/nodejs-java/installation/
keywords:
- zainstaluj Aspose.Slides
- pobierz Aspose.Slides
- użyj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zainstaluj Aspose.Slides for Node.js via Java z npm w systemach Windows, Linux i macOS: potrzebny JDK, Python oraz narzędzia kompilacji C++, polecenie npm oraz pierwszy skrypt do sprawdzenia instalacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak zainstalować Aspose.Slides for Node.js via Java w systemach Windows, Linux i macOS oraz jak sprawdzić, czy instalacja działa.

Aspose.Slides for Node.js via Java jest dystrybuowany jako pakiet `aspose.slides.via.java` w npm. Uruchamia Aspose.Slides w maszynie wirtualnej Javy za pośrednictwem pakietu [`java`](https://github.com/joeferner/node-java), natywnego dodatku Node.js, który npm kompiluje na Twoim komputerze podczas instalacji. Dlatego oprócz Node.js instalacja wymaga:
- **Pakiet Java Development Kit (JDK) 8 lub nowszy.** Same środowisko uruchomieniowe Javy nie wystarczy: kompilacja wymaga plików nagłówkowych JDK.
- **Python 3**, którego używa narzędzie budujące [node-gyp](https://github.com/nodejs/node-gyp).
- **Łańcuch narzędzi kompilacji C++** dla Twojego systemu operacyjnego.

## **Zainstaluj wymagania wstępne**

### **Windows**

1. Zainstaluj [Node.js](https://nodejs.org/en/download) w wersji 20 lub nowszej.
2. Zainstaluj JDK, na przykład [Eclipse Temurin](https://adoptium.net/), i ustaw zmienną środowiskową `JAVA_HOME` na jego folder instalacyjny. Kompilacja używa JDK, na które wskazuje `JAVA_HOME`.
3. Zainstaluj [Python 3](https://www.python.org/downloads/).
4. Zainstaluj [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) z zestawem funkcji **Desktop development with C++**. Zachowaj domyślne składniki tego zestawu, które obejmują **MSVC v143 - VS 2022 C++ x64/x86 build tools** oraz **Windows 11 SDK**. Visual Studio 2026 nie działa: wersja node-gyp, której używa pakiet `java`, jej nie rozpoznaje.

### **Linux**

Zainstaluj Node.js w wersji 20 lub nowszej z [nodejs.org](https://nodejs.org/en/download) lub z repozytorium swojej dystrybucji. Następnie zainstaluj JDK, Python 3 oraz narzędzia kompilacji C++. Na Debianie i Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

W systemie Linux kompilacja automatycznie znajduje zainstalowane JDK bez dodatkowej konfiguracji. Jeśli zainstalowano kilka JDK, ustaw `JAVA_HOME` na to, którego chcesz używać.

### **macOS**

Zainstaluj Node.js w wersji 20 lub nowszej, JDK oraz Xcode Command Line Tools, które zawierają Python 3 i kompilator C++. Zobacz [Troubleshooting Installation](/slides/pl/nodejs-java/troubleshooting-installation/) poświęcony specyficznym uwagom dla macOS.

## **Instalacja z npm**

Utwórz folder projektu i zainstaluj pakiet:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm pobiera Aspose.Slides i kompiluje most `java`, co może potrwać kilka minut. Jeśli kompilacja się nie powiedzie, zobacz [Troubleshooting Installation](/slides/pl/nodejs-java/troubleshooting-installation/).

## **Sprawdź instalację**

Utwórz plik o nazwie *hello.js* w folderze projektu z następującym kodem. Tworzy on prezentację, dodaje pole tekstowe do pierwszego slajdu i zapisuje wynik jako *hello.pptx*:

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides działa w maszynie wirtualnej Javy, która utrzymuje działanie Node.js, więc zakończ proces wyraźnie.
process.exit(0);
```

Uruchom skrypt:

```bash
node hello.js
```

Jeśli *hello.pptx* pojawi się w folderze projektu, instalacja działa. Maszyna wirtualna Javy, która uruchamia Aspose.Slides, uniemożliwia samodzielne zakończenie procesu Node.js, dlatego skrypt kończy się wywołaniem `process.exit(0)`. [Create Presentations](/slides/pl/nodejs-java/create-presentation/) wyjaśnia kod.

## **Instalacja z archiwum ZIP**

Pakiet jest również dostępny jako archiwum ZIP zawierające te same pliki co pakiet npm. Aby zainstalować go z archiwum:
1. Zainstaluj wymagania wstępne dla swojego systemu operacyjnego, jak opisano powyżej.
2. Pobierz archiwum ze [strony pobierania Aspose.Slides for Node.js via Java](https://releases.aspose.com/slides/pl/nodejs-java/).
3. Utwórz folder projektu:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Rozpakuj archiwum do podfolderu o nazwie *aspose.slides.via.java* wewnątrz folderu projektu, tak aby plik *package.json* z archiwum znajdował się pod ścieżką *hello-slides/aspose.slides.via.java/package.json*.
5. Zainstaluj pakiet z tego folderu:

    ```bash
    npm install ./aspose.slides.via.java
    ```

npm instaluje most `java`, od którego zależy pakiet, i kompiluje go, tak jak ma to miejsce przy pakiecie npm.

6. Sprawdź instalację zgodnie z opisem w [Check the Installation](#check-the-installation).

## **FAQ**

**Czy istnieje darmowa wersja lub ograniczenie wersji próbnej?**

Tak. Bez licencji Aspose.Slides działa w trybie oceny: dodaje znak wodny „evaluation” do każdego zapisanego slajdu i przycina tekst odczytany z prezentacji. Aby usunąć te ograniczenia, zastosuj ważną [licencję](/slides/pl/nodejs-java/licensing/).

**Dlaczego mój skrypt nie kończy się po zakończeniu?**

Pakiet `java` uruchamia maszynę wirtualną Javy wewnątrz procesu Node.js, a ta maszyna utrzymuje proces w działaniu. Wywołaj `process.exit`, gdy Twój skrypt zakończy pracę.