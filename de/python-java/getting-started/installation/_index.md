---
title: Installation
type: docs
weight: 70
url: /python-java/installation/
keySlides: "Laden Sie Aspose.Slides herunter, Installieren Sie Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, Python"
description: "Installieren Sie Aspose.Slides für Python über Java in Windows, Linux oder macOS"
---

Aspose.Slides für Python über Java ist eine plattformunabhängige API und kann auf jeder Plattform (Windows, Linux und MacOS) verwendet werden, auf der `Python`, `Java` und `jpype1` Brücke installiert sind.

## **Voraussetzungen für Programme und Versionen**

Um den ordnungsgemäßen Betrieb von Aspose.Slides für Python über Java sicherzustellen, müssen die folgenden Programme und Pakete installiert sein:

- JRE-Version >=8 (JPype1 wurde mit Java-Versionen von 1.8 bis 11 getestet).
- Python-Version >=3.7,<=3.12.
- JPype1-Paketversion: >=1.5.0.

## **Installieren Sie über pip**

Sie können Aspose.Slides für Python über Java einfach über [pip](https://pypi.org/) installieren, solange Sie alle erforderlichen Programme (Java, Python) installiert haben.

Erstellen Sie einen neuen Projektordner.

[Installieren Sie JPype1](https://jpype.readthedocs.io/en/latest/install.html) mit folgendem Befehl:
```
$ pip install JPype1
```

Installieren Sie Aspose.Slides für Python über Java mit folgendem Befehl:
```
$ pip install aspose-slides-java
```

## **Installieren Sie aus ZIP-Archiv**

Um Aspose.Slides für Python über Java aus einem ZIP-Archiv zu installieren und zu verwenden, befolgen Sie stattdessen diese Anweisungen:

### **Windows**

1. Installieren Sie JDK8 und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
2. [Installieren Sie Python](https://www.python.org/downloads/) Version >=3.7 und fügen Sie python.exe zu `PATH` hinzu.
3. [Installieren Sie Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Installieren Sie JPype1](https://jpype.readthedocs.io/en/latest/install.html). Sie können die folgenden Befehle im Python-Terminal ausführen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Laden Sie Aspose.Slides für Python über Java herunter](https://releases.aspose.com/slides/python-java/) und extrahieren Sie es in `aspose-slides-java`.
6. Erstellen Sie eine Datei namens `example.py` im Ordner `aspose-slides-java` mit dem folgenden Beispielcode:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Folie Titel Überschrift")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. Führen Sie jetzt `py example.py` @Eingabeaufforderung aus, um es auszuführen.

### **Linux**

1. Installieren Sie JDK8 für Linux und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
2. [Installieren Sie Python](https://www.python.org/downloads/) Version >=3.7.
3. Installieren Sie ``g++`` und ``python-dev``. 

- Für Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Für RedHat-basiert:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Installieren Sie JPype1](https://jpype.readthedocs.io/en/latest/install.html). Sie können die folgenden Befehle im Python-Terminal ausführen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Laden Sie Aspose.Slides für Python über Java herunter](https://releases.aspose.com/slides/python-java/) und extrahieren Sie es in `aspose-slides-java`.
6. Erstellen Sie eine Testdatei namens `example.py` mit diesem Beispielcode im Ordner `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Folie Titel Überschrift")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Führen Sie jetzt `py example.py` @Eingabeaufforderung aus, um es auszuführen.

### **Mac**

1. Installieren Sie JDK8 für Mac und konfigurieren Sie die Umgebungsvariable `JAVA_HOME`.
2. Ändern Sie den Abschnitt JVMCapabilities in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` mit Root-Recht. `jdk1.8.x_xxx.jdk` hängt von Ihrer JDK-Version ab. Lassen Sie es so aussehen:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Installieren Sie Python](https://www.python.org/downloads/) Version >=3.7.
4. Installieren Sie GCC- oder Clang-Compiler abhängig von der Python-Version und der Plattform.
5. [Installieren Sie JPype1](https://jpype.readthedocs.io/en/latest/install.html). Sie können die folgenden Befehle im Python-Terminal ausführen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Laden Sie Aspose.Slides für Python über Java herunter](https://releases.aspose.com/slides/python-java/) und extrahieren Sie es in `aspose-slides-java`.
7. Erstellen Sie eine Testdatei namens `example.py` mit diesem Beispielcode im Ordner `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Folie Titel Überschrift")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Führen Sie jetzt `python example.py` @Eingabeaufforderung aus, um es auszuführen.