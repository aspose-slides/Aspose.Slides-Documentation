---
title: Installation
type: docs
weight: 70
url: /sv/python-java/installation/
keywords:
- ladda ner Aspose.Slides
- installera Aspose.Slides
- Aspose.Slides-installation
- Windows
- macOS
- Linux
- Python
description: "Installera Aspose.Slides för Python via Java i Windows, Linux eller macOS"
---
Aspose.Slides för Python via Java är ett plattformsoberoende API och kan användas på alla plattformar (Windows, Linux och macOS) där `Python`, `Java` och `jpype1`‑bron är installerade.

## **Krav för program och versioner**

För att säkerställa korrekt funktion av Aspose.Slides för Python via Java måste följande program och paket installeras:

- JRE version >=8 (JPype1 har testats på Java‑versioner från 1.8 till 11).
- Python version >=3.7,<=3.12.
- JPype1‑paketversion: >=1.5.0.

## **Installera från pip**

Du kan enkelt installera Aspose.Slides för Python via Java från [pip](https://pypi.org/) så länge du har alla nödvändiga program (Java, Python) installerade.

Skapa en ny projektmapp.

[Installera JPype1](https://jpype.readthedocs.io/en/latest/install.html) med följande kommando:
```
$ pip install JPype1
```

Installera Aspose.Slides för Python via Java med följande kommando:
```
$ pip install aspose-slides-java
```

## **Installera från ZIP‑arkiv**

För att installera och använda Aspose.Slides för Python via Java från ett ZIP‑arkiv, följ dessa instruktioner istället:

### **Windows**

1. Installera JDK8 och konfigurera miljövariabeln `JAVA_HOME`.
2. [Installera Python](https://www.python.org/downloads/) version >=3.7 och lägg till python.exe i `PATH`.
3. [Installera Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Installera JPype1](https://jpype.readthedocs.io/en/latest/install.html). Du kan köra nedanstående kommandon i Python‑terminalen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Ladda ner Aspose.Slides för Python via Java](https://releases.aspose.com/slides/sv/python-java/) och extrahera det till `aspose-slides-java`.
6. Skapa en fil med namn `example.py` i mappen `aspose-slides-java` med följande exempelprogram:
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
7. Kör nu `py example.py` i kommandotolken för att köra det.

### **Linux**

1. Installera JDK8 för Linux och konfigurera miljövariabeln `JAVA_HOME`.
2. [Installera Python](https://www.python.org/downloads/) version >=3.7
3. Installera ``g++`` och ``python-dev``. 

- För Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- För RedHat‑baserade:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Installera JPype1](https://jpype.readthedocs.io/en/latest/install.html). Du kan köra nedanstående kommandon i Python‑terminalen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Ladda ner Aspose.Slides för Python via Java](https://releases.aspose.com/slides/sv/python-java/) och extrahera det till `aspose-slides-java`.
6. Skapa en testfil med namn `example.py` med denna exempelprogram i mappen `aspose-slides-java`:
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
7. Kör nu `py example.py` i kommandotolken för att köra det.

### **Mac**

1. Installera JDK8 för Mac och konfigurera miljövariabeln `JAVA_HOME`.
2. Modifiera JVMCapabilities‑sektionen i `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` med administratörsrättigheter. `jdk1.8.x_xxx.jdk` beror på din JDK‑version. Gör så här:
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
3. [Installera Python](https://www.python.org/downloads/) version >=3.7.
4. Installera GCC‑ eller Clang‑kompilatorer beroende på Python‑version och plattform.
5. [Installera JPype1](https://jpype.readthedocs.io/en/latest/install.html). Du kan köra nedanstående kommandon i Python‑terminalen:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Ladda ner Aspose.Slides för Python via Java](https://releases.aspose.com/slides/sv/python-java/) och extrahera det till `aspose-slides-java`.
7. Skapa en testfil med namn `example.py` med detta exempelprogram i mappen `aspose-slides-java`:
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
9. Kör nu `python example.py` i kommandotolken för att köra det.