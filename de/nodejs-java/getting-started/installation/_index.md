---
title: Installation
type: docs
weight: 70
url: /de/nodejs-java/installation/
keywords:
- Aspose.Slides installieren
- Aspose.Slides herunterladen
- Aspose.Slides verwenden
- Aspose.Slides-Installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Installieren Sie Aspose.Slides für Node.js via Java über npm unter Windows, Linux und macOS: das benötigte JDK, Python und die C++-Build-Tools, der npm-Befehl und ein erstes Skript, um die Installation zu überprüfen."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Aspose.Slides für Node.js via Java unter Windows, Linux und macOS installiert und wie man überprüft, ob die Installation funktioniert.

Aspose.Slides für Node.js via Java wird als das Paket `aspose.slides.via.java` auf npm verteilt. Es führt Aspose.Slides in einer Java‑Virtuellen Maschine über das [`java`](https://github.com/joeferner/node-java)-Paket aus, ein nativer Node.js‑Addon, das npm während der Installation auf Ihrem Computer kompiliert. Deshalb benötigt die Installation neben Node.js:

- **Ein Java Development Kit (JDK) 8 oder höher.** Eine reine Java‑Laufzeit reicht nicht aus: Der Build benötigt die Header‑Dateien des JDK.
- **Python 3**, das vom Build‑Tool [node-gyp](https://github.com/nodejs/node-gyp) verwendet wird.
- **Ein C++‑Build‑Toolchain** für Ihr Betriebssystem.

## **Voraussetzungen installieren**

### **Windows**

1. Installieren Sie [Node.js](https://nodejs.org/en/download) 20 oder höher.  
2. Installieren Sie ein JDK, zum Beispiel [Eclipse Temurin](https://adoptium.net/), und setzen Sie die Umgebungsvariable `JAVA_HOME` auf dessen Installationsordner. Der Build verwendet das JDK, auf das `JAVA_HOME` zeigt.  
3. Installieren Sie [Python 3](https://www.python.org/downloads/).  
4. Installieren Sie [Build Tools for Visual Studio 2022](https://aka.ms/vs/17/release/vs_BuildTools.exe) mit dem **Desktop development with C++**‑Workload. Behalten Sie die Standardkomponenten des Workloads bei, die **MSVC v143 - VS 2022 C++ x64/x86 build tools** und das **Windows 11 SDK** umfassen. Visual Studio 2026 funktioniert nicht: Die node‑gyp‑Version, mit der das `java`‑Paket kompiliert wird, erkennt es nicht.

### **Linux**

Installieren Sie Node.js 20 oder höher von [nodejs.org](https://nodejs.org/en/download) oder aus den Paketquellen Ihrer Distribution. Installieren Sie anschließend ein JDK, Python 3 und die C++‑Build‑Tools. Auf Debian und Ubuntu:

```bash
sudo apt-get update
sudo apt-get install -y default-jdk python3 build-essential
```

Unter Linux findet der Build das installierte JDK ohne weitere Konfiguration. Wenn mehrere JDKs installiert sind, setzen Sie `JAVA_HOME` auf das gewünschte.

### **macOS**

Installieren Sie Node.js 20 oder höher, ein JDK und die Xcode‑Command‑Line‑Tools, die Python 3 und den C++‑Compiler enthalten. Siehe [Troubleshooting Installation](/slides/de/nodejs-java/troubleshooting-installation/) für macOS-spezifische Hinweise.

## **Installation über npm**

Erstellen Sie einen Projektordner und installieren Sie das Paket:

```bash
mkdir hello-slides
cd hello-slides
npm init -y
npm install aspose.slides.via.java
```

npm lädt Aspose.Slides herunter und kompiliert die `java`‑Brücke, was einige Minuten dauern kann. Wenn die Kompilierung fehlschlägt, siehe [Troubleshooting Installation](/slides/de/nodejs-java/troubleshooting-installation/).

## **Installation prüfen**

Erzeugen Sie im Projektordner eine Datei namens *hello.js* mit folgendem Code. Sie erstellt eine Präsentation, fügt der ersten Folie ein Textfeld hinzu und speichert das Ergebnis als *hello.pptx*:

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

// Aspose.Slides läuft in einer Java-virtuellen Maschine, die Node.js am Laufen hält, daher muss der Prozess ausdrücklich beendet werden.
process.exit(0);
```

Führen Sie das Skript aus:

```bash
node hello.js
```

Wenn *hello.pptx* im Projektordner erscheint, funktioniert die Installation. Die Java‑Virtuelle Maschine, die Aspose.Slides ausführt, verhindert, dass Node.js von selbst beendet wird, weshalb das Skript mit `process.exit(0)` endet. [Create Presentations](/slides/de/nodejs-java/create-presentation/) erklärt den Code.

## **Installation aus einem ZIP‑Archiv**

Das Paket ist auch als ZIP‑Archiv mit dem selben Inhalt wie das npm‑Paket verfügbar. So installieren Sie es aus dem Archiv:

1. Installieren Sie die Voraussetzungen für Ihr Betriebssystem, wie oben beschrieben.  
2. Laden Sie das Archiv von der [Aspose.Slides for Node.js via Java download page](https://releases.aspose.com/slides/de/nodejs-java/) herunter.  
3. Erstellen Sie einen Projektordner:

    ```bash
    mkdir hello-slides
    cd hello-slides
    npm init -y
    ```

4. Entpacken Sie das Archiv in einen Unterordner namens *aspose.slides.via.java* im Projektordner, sodass die *package.json* des Archivs unter *hello-slides/aspose.slides.via.java/package.json* liegt.  
5. Installieren Sie das Paket aus diesem Ordner:

    ```bash
    npm install ./aspose.slides.via.java
    ```

    npm installiert die `java`‑Brücke, von der das Paket abhängt, und kompiliert sie, wie es beim npm‑Paket geschieht.  
6. Prüfen Sie die Installation wie in [Check the Installation](#check-the-installation) beschrieben.

## **FAQ**

**Gibt es eine kostenlose Version oder Testbeschränkungen?**

Ja. Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Folie ein Evaluierungs‑Wasserzeichen hinzu und kürzt Text, der aus Präsentationen gelesen wird. Um diese Einschränkungen zu entfernen, wenden Sie eine gültige [license](/slides/de/nodejs-java/licensing/) an.

**Warum beendet mein Skript nicht, wenn es fertig ist?**

Das `java`‑Paket startet eine Java‑Virtuelle Maschine im Node.js‑Prozess, und diese virtuelle Maschine hält den Prozess am Laufen. Rufen Sie `process.exit` auf, wenn Ihr Skript seine Arbeit abgeschlossen hat.