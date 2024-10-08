---
title: 安装
type: docs
weight: 70
url: /python-java/installation/
keySlides: "下载 Aspose.Slides，安装 Aspose.Slides，Aspose.Slides 安装，Windows，macOS，Linux，Python"
description: "在 Windows、Linux 或 macOS 上通过 Java 安装 Aspose.Slides for Python"
---

通过 Java 的 Aspose.Slides for Python 是一个跨平台 API，可以在安装了 `Python`、`Java` 和 `jpype1` 桥接的任何平台（Windows、Linux 和 macOS）上使用。

## **程序和版本要求**

为了确保通过 Java 的 Aspose.Slides for Python 的正常操作，必须安装以下程序和包：

- JRE 版本 >=8（JPype1 已在 Java 版本 1.8 至 11 上测试）。
- Python 版本 >=3.7，<=3.12。
- JPype1包版本：>=1.5.0。

## **从 pip 安装**

只要您安装了所有必要的程序（Java、Python），就可以轻松通过 [pip](https://pypi.org/) 安装通过 Java 的 Aspose.Slides for Python。

创建一个新的项目文件夹。

使用以下命令 [安装 JPype1](https://jpype.readthedocs.io/en/latest/install.html)：
```
$ pip install JPype1
```

使用以下命令安装通过 Java 的 Aspose.Slides for Python：
```
$ pip install aspose-slides-java
```

## **从 ZIP 压缩包安装**

要从 ZIP 压缩包安装并使用通过 Java 的 Aspose.Slides for Python，请按照以下说明操作：

### **Windows**

1. 安装 JDK8 并配置 `JAVA_HOME` 环境变量。
2. [安装 Python](https://www.python.org/downloads/) 版本 >=3.7，并将 python.exe 添加到 `PATH`。
3. [安装 Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/)。
4. [安装 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 终端中运行以下命令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [下载 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) 并解压到 `aspose-slides-java` 目录。
6. 在 `aspose-slides-java` 文件夹中创建一个名为 `example.py` 的文件，使用以下示例代码：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. 现在在命令提示符中运行 `py example.py` 来执行它。

### **Linux**

1. 安装适用于 Linux 的 JDK8 并配置 `JAVA_HOME` 环境变量。
2. [安装 Python](https://www.python.org/downloads/) 版本 >=3.7
3. 安装 `g++` 和 `python-dev`。 

- 对于 Debian/Ubuntu：
    ```
    sudo apt-get install g++ python3-dev
    ```
- 对于基于 RedHat 的系统：
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [安装 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 终端中运行以下命令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [下载 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) 并解压到 `aspose-slides-java` 目录。
6. 在 `aspose-slides-java` 文件夹中创建一个名为 `example.py` 的测试文件，使用此示例代码：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. 现在在命令提示符中运行 `py example.py` 来执行它。

### **Mac**

1. 安装适用于 Mac 的 JDK8 并配置 `JAVA_HOME` 环境变量。
2. 使用 root 权限修改 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 中的 JVMCapabilities 部分。 `jdk1.8.x_xxx.jdk` 取决于您的 jdk 版本。使其看起来像这样：
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
3. [安装 Python](https://www.python.org/downloads/) 版本 >=3.7。
4. 根据 Python 的版本和平台安装 GCC 或 Clang 编译器。
5. [安装 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 终端中运行以下命令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [下载 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/python-java/) 并解压到 `aspose-slides-java` 目录。
7. 在 `aspose-slides-java` 文件夹中创建一个名为 `example.py` 的测试文件，使用此示例代码：

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("幻灯片标题")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. 现在在命令提示符中运行 `python example.py` 来执行它。