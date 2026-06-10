---
title: Telepítés
type: docs
weight: 70
url: /hu/python-java/installation/
keywords:
- Aspose.Slides letöltése
- Aspose.Slides telepítése
- Aspose.Slides telepítése
- Windows
- macOS
- Linux
- Python
description: "Az Aspose.Slides for Python via Java telepítése Windows, Linux vagy macOS rendszerekre"
---
Az Aspose.Slides for Python via Java egy platformfüggetlen API, és bármely platformon (Windows, Linux és macOS) használható, ahol a `Python`, a `Java` és a `jpype1` híd telepítve van.

## **Programok és verziók követelményei**

Az Aspose.Slides for Python via Java megfelelő működésének biztosítása érdekében a következő programokat és csomagokat kell telepíteni:

- JRE verzió >=8 (A JPype1 tesztelve lett a Java 1.8-tól 11-ig terjedő verzióin).
- Python verzió >=3.7, <=3.12.
- JPype1 csomag verzió: >=1.5.0.

## **Telepítés pip‑ből**

Az Aspose.Slides for Python via Java könnyedén telepíthető a [pip](https://pypi.org/) segítségével, amennyiben az összes szükséges program (Java, Python) telepítve van.

Hozzon létre egy új projektmappát.

[Telepítse a JPype1‑et](https://jpype.readthedocs.io/en/latest/install.html) a következő paranccsal:
```
$ pip install JPype1
```

Az Aspose.Slides for Python via Java telepítéséhez használja a következő parancsot:
```
$ pip install aspose-slides-java
```

## **Telepítés ZIP‑archívumból**

Az Aspose.Slides for Python via Java ZIP‑archívumból történő telepítéséhez és használatához kövesse inkább ezeket az utasításokat:

### **Windows**

1. Telepítse a JDK8‑at, és állítsa be a `JAVA_HOME` környezeti változót.
2. [Telepítse a Python‑t](https://www.python.org/downloads/) >=3.7 verzióval, és adja hozzá a python.exe‑t a `PATH`‑hez.
3. [Telepítse a Microsoft C++ Build Tools‑t](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Telepítse a JPype1‑et](https://jpype.readthedocs.io/en/latest/install.html). Az alábbi parancsokat futtathatja a python terminálban:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Töltse le az Aspose.Slides for Python via Java‑t](https://releases.aspose.com/slides/hu/python-java/) és csomagolja ki a `aspose-slides-java` könyvtárba.
6. Hozzon létre egy `example.py` nevű fájlt a `aspose-slides-java` mappában a következő mintakóddal:
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
7. Most futtassa a `py example.py` parancsot a parancssorban.

### **Linux**

1. Telepítse a JDK8‑at Linuxra, és állítsa be a `JAVA_HOME` környezeti változót.
2. [Telepítse a Python‑t](https://www.python.org/downloads/) >=3.7 verzióval
3. Telepítse a ``g++`` és ``python-dev`` csomagokat.
- Debian/Ubuntu esetén:```
    sudo apt-get install g++ python3-dev
    ```
- RedHat-alapú rendszerek esetén:```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```
4. [Telepítse a JPype1‑et](https://jpype.readthedocs.io/en/latest/install.html). Az alábbi parancsokat futtathatja a python terminálban:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Töltse le az Aspose.Slides for Python via Java‑t](https://releases.aspose.com/slides/hu/python-java/) és csomagolja ki a `aspose-slides-java` könyvtárba.
6. Hozzon létre egy `example.py` nevű tesztfájlt a `aspose-slides-java` mappában a következő mintakóddal:
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
7. Most futtassa a `py example.py` parancsot a parancssorban.

### **Mac**

1. Telepítse a JDK8‑at Mac-re, és állítsa be a `JAVA_HOME` környezeti változót.
2. Módosítsa a JVMCapabilities részt a `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` fájlban rendszergazdai jogosultsággal. A `jdk1.8.x_xxx.jdk` a JDK verziójától függ. Így nézzen ki:
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
3. [Telepítse a Python‑t](https://www.python.org/downloads/) >=3.7 verzióval.
4. Telepítse a GCC vagy Clang fordítókat a Python verziójától és platformjától függően.
5. [Telepítse a JPype1‑et](https://jpype.readthedocs.io/en/latest/install.html). Az alábbi parancsokat futtathatja a python terminálban:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Töltse le az Aspose.Slides for Python via Java‑t](https://releases.aspose.com/slides/hu/python-java/) és csomagolja ki a `aspose-slides-java` könyvtárba.
7. Hozzon létre egy `example.py` nevű tesztfájlt a `aspose-slides-java` mappában a következő mintakóddal:
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
9. Most futtassa a `python example.py` parancsot a parancssorban.