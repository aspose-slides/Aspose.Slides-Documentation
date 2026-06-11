---
title: Instalcja
type: docs
weight: 70
url: /pl/python-java/installation/
keywords:
- pobierz Aspose.Slides
- zainstaluj Aspose.Slides
- instalacja Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Zainstaluj Aspose.Slides for Python via Java w systemie Windows, Linux lub macOS"
---
Aspose.Slides for Python via Java jest platformowo niezależnym API i może być używany na dowolnej platformie (Windows, Linux i macOS), na której zainstalowano most `Python`, `Java` oraz `jpype1`.

## **Wymagania dotyczące programów i wersji**

Aby zapewnić prawidłowe działanie Aspose.Slides for Python via Java, należy zainstalować następujące programy i pakiety:

- Wersja JRE >=8 (JPype1 był testowany na wersjach Java od 1.8 do 11).
- Wersja Pythona >=3.7,<=3.12.
- Wersja pakietu JPype1: >=1.5.0.

## **Instalacja z pip**

Możesz łatwo zainstalować Aspose.Slides for Python via Java z [pip](https://pypi.org/), o ile masz zainstalowane wszystkie wymagane programy (Java, Python).

Utwórz nowy folder projektu.

[Zainstaluj JPype1](https://jpype.readthedocs.io/en/latest/install.html) używając następującego polecenia:
```
$ pip install JPype1
```

Zainstaluj Aspose.Slides for Python via Java używając następującego polecenia:
```
$ pip install aspose-slides-java
```

## **Instalacja z archiwum ZIP**

Aby zainstalować i używać Aspose.Slides for Python via Java z archiwum ZIP, postępuj zgodnie z następującymi instrukcjami:

### **Windows**

1. Zainstaluj JDK8 i skonfiguruj zmienną środowiskową `JAVA_HOME`.
2. [Zainstaluj Python](https://www.python.org/downloads/) w wersji >=3.7 i dodaj python.exe do `PATH`.
3. [Zainstaluj Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Zainstaluj JPype1](https://jpype.readthedocs.io/en/latest/install.html). Możesz uruchomić poniższe polecenia w terminalu Pythona:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Pobierz Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pl/python-java/) i rozpakuj go do `aspose-slides-java`.
6. Utwórz plik o nazwie `example.py` w folderze `aspose-slides-java` używając poniższego przykładowego kodu:
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
7. Teraz uruchom `py example.py` w wierszu poleceń, aby go wykonać.

### **Linux**

1. Zainstaluj JDK8 dla Linuxa i skonfiguruj zmienną środowiskową `JAVA_HOME`.
2. [Zainstaluj Python](https://www.python.org/downloads/) w wersji >=3.7
3. Zainstaluj ``g++`` i ``python-dev``. 

- Dla Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Dla systemów opartych na RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Zainstaluj JPype1](https://jpype.readthedocs.io/en/latest/install.html). Możesz uruchomić poniższe polecenia w terminalu Pythona:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Pobierz Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pl/python-java/) i rozpakuj go do `aspose-slides-java`.
6. Utwórz plik testowy o nazwie `example.py` używając tego przykładowego kodu w folderze `aspose-slides-java`:
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
7. Teraz uruchom `py example.py` w wierszu poleceń, aby go wykonać.

### **Mac**

1. Zainstaluj JDK8 dla Mac i skonfiguruj zmienną środowiskową `JAVA_HOME`.
2. Zmodyfikuj sekcję JVMCapabilities w `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` z uprawnieniami administratora. `jdk1.8.x_xxx.jdk` zależy od wersji twojego JDK. Powinno to wyglądać tak:
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
3. [Zainstaluj Python](https://www.python.org/downloads/) w wersji >=3.7.
4. Zainstaluj kompilatory GCC lub Clang w zależności od wersji Pythona i platformy.
5. [Zainstaluj JPype1](https://jpype.readthedocs.io/en/latest/install.html). Możesz uruchomić poniższe polecenia w terminalu Pythona:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Pobierz Aspose.Slides for Python via Java](https://releases.aspose.com/slides/pl/python-java/) i rozpakuj go do `aspose-slides-java`.
7. Utwórz plik testowy o nazwie `example.py` używając tego przykładowego kodu w folderze `aspose-slides-java`:
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
9. Teraz uruchom `python example.py` w wierszu poleceń, aby go wykonać.