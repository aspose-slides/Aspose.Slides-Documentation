---
title: Installatie
type: docs
weight: 70
url: /nl/python-java/installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- Aspose.Slides installatie
- Windows
- macOS
- Linux
- Python
description: "Installeer Aspose.Slides voor Python via Java op Windows, Linux of macOS"
---
Aspose.Slides for Python via Java is een platformonafhankelijke API en kan op elk platform (Windows, Linux en macOS) worden gebruikt waar de `Python`, `Java` en `jpype1` bridge geïnstalleerd zijn.

## **Vereisten voor programma's en versies**

Om een correcte werking van Aspose.Slides for Python via Java te garanderen, moeten de volgende programma's en pakketten geïnstalleerd zijn:

- JRE‑versie >=8 (JPype1 is getest op Java‑versies van 1.8 tot 11).
- Python‑versie >=3.7, <=3.12.
- JPype1‑pakketversie: >=1.5.0.

## **Installeren via pip**

U kunt Aspose.Slides for Python via Java eenvoudig installeren vanuit[pip](https://pypi.org/) zolang u alle vereiste programma's (Java, Python) geïnstalleerd heeft.

Maak een nieuwe projectmap aan.

[Installeer JPype1](https://jpype.readthedocs.io/en/latest/install.html) met het volgende commando:
```
$ pip install JPype1
```

Installeer Aspose.Slides for Python via Java met het volgende commando:
```
$ pip install aspose-slides-java
```

## **Installeren vanuit ZIP-archief**

Om Aspose.Slides for Python via Java vanuit een ZIP-archief te installeren en te gebruiken, volgt u in plaats daarvan deze instructies:

### **Windows**

1. Installeer JDK8 en configureer de omgevingsvariabele `JAVA_HOME`.
2. [Installeer Python](https://www.python.org/downloads/) versie >=3.7 en voeg python.exe toe aan `PATH`.
3. [Installeer Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Installeer JPype1](https://jpype.readthedocs.io/en/latest/install.html). U kunt de onderstaande commando's in de python‑terminal uitvoeren:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/nl/python-java/) en pak het uit naar `aspose-slides-java`.
6. Maak een bestand genaamd `example.py` in de map `aspose-slides-java` met de volgende voorbeeldcode:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Voer nu `py example.py` uit in de opdrachtprompt om het te starten.

### **Linux**

1. Installeer JDK8 voor Linux en configureer de omgevingsvariabele `JAVA_HOME`.
2. [Installeer Python](https://www.python.org/downloads/) versie >=3.7
3. Installeer ``g++`` en ``python-dev``. 

- Voor Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
```
- Voor RedHat-gebaseerd:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Installeer JPype1](https://jpype.readthedocs.io/en/latest/install.html). U kunt de onderstaande commando's in de python‑terminal uitvoeren:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/nl/python-java/) en pak het uit naar `aspose-slides-java`.
6. Maak een testbestand genaamd `example.py` met deze voorbeeldcode in de map `aspose-slides-java`:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Voer nu `py example.py` uit in de opdrachtprompt om het te starten.

### **Mac**

1. Installeer JDK8 voor Mac en configureer de omgevingsvariabele `JAVA_HOME`.
2. Pas de JVMCapabilities‑sectie in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` aan met root‑privileges. `jdk1.8.x_xxx.jdk` hangt af van uw jdk‑versie. Zorg dat het er als volgt uitziet:
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
3. [Installeer Python](https://www.python.org/downloads/) versie >=3.7.
4. Installeer GCC‑ of Clang‑compiler afhankelijk van de versie van Python en het platform.
5. [Installeer JPype1](https://jpype.readthedocs.io/en/latest/install.html). U kunt de onderstaande commando's in de python‑terminal uitvoeren:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/nl/python-java/) en pak het uit in `aspose-slides-java`.
7. Maak een testbestand genaamd `example.py` met deze voorbeeldcode in de map `aspose-slides-java`:
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Voer nu `python example.py` uit in de opdrachtprompt om het te starten.