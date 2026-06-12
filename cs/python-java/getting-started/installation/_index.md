---
title: Instalace
type: docs
weight: 70
url: /cs/python-java/installation/
keywords:
- stáhnout Aspose.Slides
- nainstalovat Aspose.Slides
- Instalace Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Nainstalujte Aspose.Slides for Python via Java ve Windows, Linuxu nebo macOS"
---
Aspose.Slides for Python via Java je platformově nezávislé API a lze jej použít na jakékoli platformě (Windows, Linux a macOS), kde jsou nainstalovány `Python`, `Java` a most `jpype1`.

## **Požadavky na programy a verze**

- JRE verze >=8 (JPype1 byl testován na verzích Java od 1.8 do 11).
- Python verze >=3.7, <=3.12.
- JPype1 balíček verze: >=1.5.0.

## **Instalace z pip**

Aspose.Slides for Python via Java můžete snadno nainstalovat z [pip](https://pypi.org/) za předpokladu, že máte nainstalovány všechny požadované programy (Java, Python).

Vytvořte novou složku projektu.

[Installujte JPype1](https://jpype.readthedocs.io/en/latest/install.html) pomocí následujícího příkazu:
```
$ pip install JPype1
```

Nainstalujte Aspose.Slides for Python via Java pomocí následujícího příkazu:
```
$ pip install aspose-slides-java
```

## **Instalace ze ZIP archivu**

Pro instalaci a použití Aspose.Slides for Python via Java ze ZIP archivu postupujte podle těchto instrukcí:

### **Windows**

1. Nainstalujte JDK8 a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
2. [Nainstalujte Python](https://www.python.org/downloads/) verze >=3.7 a přidejte python.exe do `PATH`.
3. [Nainstalujte Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Nainstalujte JPype1](https://jpype.readthedocs.io/en/latest/install.html). Níže můžete spustit příkazy v python terminálu:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Stáhněte Aspose.Slides for Python via Java](https://releases.aspose.com/slides/cs/python-java/) a rozbalte jej do `aspose-slides-java`.
6. Vytvořte soubor s názvem `example.py` ve složce `aspose-slides-java` pomocí následujícího ukázkového kódu:
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
7. Nyní spusťte `py example.py` v příkazovém řádku, abyste ho spustili.

### **Linux**

1. Nainstalujte JDK8 pro Linux a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
2. [Nainstalujte Python](https://www.python.org/downloads/) verze >=3.7
3. Nainstalujte ``g++`` a ``python-dev``. 

- Pro Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Pro RedHat‑based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Nainstalujte JPype1](https://jpype.readthedocs.io/en/latest/install.html). Níže můžete spustit příkazy v python terminálu:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Stáhněte Aspose.Slides for Python via Java](https://releases.aspose.com/slides/cs/python-java/) a rozbalte jej do `aspose-slides-java`.
6. Vytvořte testovací soubor s názvem `example.py` pomocí tohoto ukázkového kódu ve složce `aspose-slides-java`:
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
7. Nyní spusťte `py example.py` v příkazovém řádku.

### **Mac**

1. Nainstalujte JDK8 pro Mac a nakonfigurujte proměnnou prostředí `JAVA_HOME`.
2. Upravte sekci JVMCapabilities v `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` s oprávněním root. `jdk1.8.x_xxx.jdk` závisí na vaší verzi JDK. Mělo by to vypadat takto:
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
3. [Nainstalujte Python](https://www.python.org/downloads/) verze >=3.7.
4. Nainstalujte kompilátory GCC nebo Clang podle verze Pythonu a platformy.
5. [Nainstalujte JPype1](https://jpype.readthedocs.io/en/latest/install.html). Níže můžete spustit příkazy v python terminálu:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Stáhněte Aspose.Slides for Python via Java](https://releases.aspose.com/slides/cs/python-java/) a rozbalte jej do `aspose-slides-java`.
7. Vytvořte testovací soubor s názvem `example.py` pomocí tohoto ukázkového kódu ve složce `aspose-slides-java`:
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
9. Nyní spusťte `python example.py` v příkazovém řádku.