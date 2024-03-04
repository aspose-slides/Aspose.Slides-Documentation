---
title: Installation
type: docs
weight: 70
url: /python-java/installation/
keySlides: "Download Aspose.Slides, Install Aspose.Slides, Aspose.Slides Installation, Windows, macOS, Linux, Python"
description: "Install Aspose.Slides for Python via Java in Windows, Linux or macOS"
---

Aspose.Slides for Python via Java is platform-independent API and can be used on any platform (Windows, Linux and MacOS) where `Python`, `Java` and `jpype` bridge are installed.

## **Version requirements**
- JRE version >=8 (JPype has been tested on Java versions from 1.8 to 13).
- Python version >=3.7.
- JPype package version: >=1.4.1.

## **Install from pip**

You can easily install Aspose.Slides for Python via Java from [pip](https://pypi.org/).

Create a new project folder. Fill in the title and version fields (leave the remaining fields with default values).

Install JPype1 using the following command:
```
$ pip install JPype1
```

Install Aspose.Slides for Python via Java using the following command:
```
$ pip install aspose-slides-java
```

## **Install from ZIP archive**

To install and use Aspose.Slides for Python via Java from a ZIP archive, follow these instructions instead:

### **Windows**

1. Install JDK8 and configure `JAVA_HOME` environment variable.
2. [Install Python](https://www.python.org/downloads/) version >=3.7 and add python.exe to `PATH`.
3. [Install Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. Install JPype1. You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) and extract it to `aspose-slides-java`.
6. Create a file named `example.py` in `aspose-slides-java` folder using the following sample code:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

print("Done")

jpype.shutdownJVM()
```

7. Now run `py example.py` @command prompt to run it.

### **Linux**

1. Install JDK8 for Linux and configure `JAVA_HOME` environment variable.
2. [Install Python](https://www.python.org/downloads/) version >=3.7
3. Install ``g++`` and ``python-dev``. 

- For Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- For RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. Install JPype1. You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) and extract it to `aspose-slides-java`.
6. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

print("Done")

jpype.shutdownJVM()
```
7. Now run `py example.py` @command prompt to run it.

### **Mac**

1. Install JDK8 for Mac and configure `JAVA_HOME` environment variable.
2. Modify JVMCapabilities section in `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` with root privilege. `jdk1.8.x_xxx.jdk` depends on your jdk version. Make it look like this:
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
3. [Install Python](https://www.python.org/downloads/) version >=3.7.
4. Install GCC or Clang compilers depending on the Python`s version and platform.
5. Install JPype1. You can run below commands in python terminal:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) and extract it into `aspose-slides-java`.
7. Create a test file named `example.py` using this sample code in `aspose-slides-java` folder:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Slide Title Heading")
pres.save("out.pptx", SaveFormat.Pptx)

print("Done")

jpype.shutdownJVM()
```
9. Now run `python example.py` @command prompt to run it.


