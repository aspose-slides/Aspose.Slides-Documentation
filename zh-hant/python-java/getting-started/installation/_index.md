---
title: 安裝
type: docs
weight: 70
url: /zh-hant/python-java/installation/
keywords:
- 下載 Aspose.Slides
- 安裝 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- macOS
- Linux
- Python
description: "在 Windows、Linux 或 macOS 上安裝 Aspose.Slides for Python via Java"
---
Aspose.Slides for Python via Java 是跨平台的 API，可在任何安裝了 `Python`、`Java` 和 `jpype1` 橋接的平台（Windows、Linux 和 MacOS）上使用。

## **程式與版本需求**

- JRE 版本 >=8（已在 1.8 至 11 版的 Java 上測試 JPype1）。
- Python 版本 >=3.7，<=3.12。
- JPype1 套件版本：>=1.5.0。

## **從 pip 安裝**

只要已安裝所有必需的程式（Java、Python），您就可以輕鬆從 [pip](https://pypi.org/) 安裝 Aspose.Slides for Python via Java。

建立一個新的專案資料夾。

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) 使用以下指令：
```
$ pip install JPype1
```

使用以下指令安裝 Aspose.Slides for Python via Java：
```
$ pip install aspose-slides-java
```

## **從 ZIP 壓縮檔安裝**

若要從 ZIP 壓縮檔安裝並使用 Aspose.Slides for Python via Java，請遵循以下說明：

### **Windows**

1. 安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
2. [安裝 Python](https://www.python.org/downloads/) 版本 >=3.7，並將 python.exe 加入 `PATH`。
3. [安裝 Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/)。
4. [安裝 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 終端機中執行以下指令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [下載 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/zh-hant/python-java/) 並解壓至 `aspose-slides-java`。
6. 在 `aspose-slides-java` 資料夾中建立名為 `example.py` 的檔案，使用以下範例程式碼：
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
7. 現在在命令提示字元執行 `py example.py` 以執行它。

### **Linux**

1. 在 Linux 上安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
2. [安裝 Python](https://www.python.org/downloads/) 版本 >=3.7
3. 安裝 ``g++`` 與 ``python-dev``。

- 對於 Debian/Ubuntu：
    ```
    sudo apt-get install g++ python3-dev
    ```
- 對於 RedHat 系列：
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [安裝 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 終端機中執行以下指令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [下載 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/zh-hant/python-java/) 並解壓至 `aspose-slides-java`。
6. 在 `aspose-slides-java` 資料夾中建立名為 `example.py` 的測試檔案，使用以下範例程式碼：
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
7. 現在在命令提示字元執行 `py example.py` 以執行它。

### **Mac**

1. 在 Mac 上安裝 JDK8 並設定 `JAVA_HOME` 環境變數。
2. 使用根權限修改 `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` 中的 JVMCapabilities 部分。`jdk1.8.x_xxx.jdk` 取決於您的 JDK 版本。請將其調整為如下所示：
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
3. [安裝 Python](https://www.python.org/downloads/) 版本 >=3.7。
4. 根據 Python 版本與平台安裝 GCC 或 Clang 編譯器。
5. [安裝 JPype1](https://jpype.readthedocs.io/en/latest/install.html)。您可以在 Python 終端機中執行以下指令：
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [下載 Aspose.Slides for Python via Java](https://releases.aspose.com/slides/zh-hant/python-java/) 並解壓至 `aspose-slides-java`。
7. 在 `aspose-slides-java` 資料夾中建立名為 `example.py` 的測試檔案，使用以下範例程式碼：
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
9. 現在在命令提示字元執行 `python example.py` 以執行它。