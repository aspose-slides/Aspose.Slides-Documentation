---
title: Instalasi
type: docs
weight: 70
url: /id/python-java/installation/
keywords:
- unduh Aspose.Slides
- pasang Aspose.Slides
- instalasi Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Instal Aspose.Slides for Python via Java di Windows, Linux, atau macOS"
---
Aspose.Slides for Python via Java adalah API yang independen platform dan dapat digunakan pada platform apa pun (Windows, Linux, dan MacOS) di mana jembatan `Python`, `Java`, dan `jpype1` telah diinstal.

## **Persyaratan untuk program dan versi**

Untuk memastikan operasi yang tepat dari Aspose.Slides for Python via Java, program dan paket berikut harus diinstal:

- Versi JRE >=8 (JPype1 telah diuji pada versi Java dari 1.8 hingga 11).
- Versi Python >=3.7, <=3.12.
- Versi paket JPype1: >=1.5.0.

## **Instalasi melalui pip**

Anda dapat dengan mudah menginstal Aspose.Slides for Python via Java dari [pip](https://pypi.org/) selama semua program yang diperlukan (Java, Python) telah terinstal.

Buat folder proyek baru.

Gunakan perintah berikut untuk [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html):
```
$ pip install JPype1
```

Instal Aspose.Slides for Python via Java menggunakan perintah berikut:
```
$ pip install aspose-slides-java
```

## **Instalasi dari arsip ZIP**

Untuk menginstal dan menggunakan Aspose.Slides for Python via Java dari arsip ZIP, ikuti petunjuk berikut:

### **Windows**

1. Instal JDK8 dan konfigurasikan variabel lingkungan `JAVA_HOME`.
2. Instal [Python](https://www.python.org/downloads/) versi >=3.7 dan tambahkan python.exe ke `PATH`.
3. Instal [Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. Instal [JPype1](https://jpype.readthedocs.io/en/latest/install.html). Anda dapat menjalankan perintah di bawah ini di terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. Unduh [Aspose.Slides for Python via Java](https://releases.aspose.com/slides/id/python-java/) dan ekstrak ke `aspose-slides-java`.
6. Buat file bernama `example.py` di folder `aspose-slides-java` menggunakan contoh kode berikut:

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

7. Sekarang jalankan `py example.py` di command prompt untuk mengeksekusinya.

### **Linux**

1. Instal JDK8 untuk Linux dan konfigurasikan variabel lingkungan `JAVA_HOME`.
2. Instal [Python](https://www.python.org/downloads/) versi >=3.7
3. Instal ``g++`` dan ``python-dev``.

- Untuk Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Untuk berbasis RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. Instal [JPype1](https://jpype.readthedocs.io/en/latest/install.html). Anda dapat menjalankan perintah di bawah ini di terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. Unduh [Aspose.Slides for Python via Java](https://releases.aspose.com/slides/id/python-java/) dan ekstrak ke `aspose-slides-java`.
6. Buat file uji bernama `example.py` menggunakan contoh kode ini di folder `aspose-slides-java`:

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
7. Sekarang jalankan `py example.py` di command prompt untuk mengeksekusinya.

### **Mac**

1. Instal JDK8 untuk Mac dan konfigurasikan variabel lingkungan `JAVA_HOME`.
2. Modifikasi bagian JVMCapabilities di `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` dengan hak istimewa root. `jdk1.8.x_xxx.jdk` tergantung pada versi jdk Anda. Buat tampilan seperti ini:
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
3. Instal [Python](https://www.python.org/downloads/) versi >=3.7.
4. Instal kompiler GCC atau Clang tergantung pada versi Python dan platform.
5. Instal [JPype1](https://jpype.readthedocs.io/en/latest/install.html). Anda dapat menjalankan perintah di bawah ini di terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. Unduh Aspose.Slides for Python via Java dan ekstrak ke dalam `aspose-slides-java`.
7. Buat file uji bernama `example.py` menggunakan contoh kode ini di folder `aspose-slides-java`:

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
9. Sekarang jalankan `python example.py` di command prompt untuk mengeksekusinya.