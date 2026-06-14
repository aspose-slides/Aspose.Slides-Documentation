---
title: Cài đặt
type: docs
weight: 70
url: /vi/python-java/installation/
keywords:
- tải xuống Aspose.Slides
- cài đặt Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- macOS
- Linux
- Python
description: "Cài đặt Aspose.Slides for Python via Java trên Windows, Linux hoặc macOS"
---
Aspose.Slides for Python via Java là API không phụ thuộc vào nền tảng và có thể được sử dụng trên bất kỳ nền tảng nào (Windows, Linux và MacOS) nơi đã cài đặt `Python`, `Java` và cầu nối `jpype1`.

## **Yêu cầu cho chương trình và phiên bản**

Để đảm bảo hoạt động đúng của Aspose.Slides for Python via Java, các chương trình và gói sau phải được cài đặt:

- JRE phiên bản >=8 (JPype1 đã được thử nghiệm trên các phiên bản Java từ 1.8 tới 11).
- Python phiên bản >=3.7, <=3.12.
- Phiên bản gói JPype1: >=1.5.0.

## **Cài đặt từ pip**

Bạn có thể dễ dàng cài đặt Aspose.Slides for Python via Java từ [pip](https://pypi.org/) miễn là bạn đã cài đặt tất cả các chương trình cần thiết (Java, Python) rồi.

Tạo một thư mục dự án mới.

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) sử dụng lệnh sau:
```
$ pip install JPype1
```

Cài đặt Aspose.Slides for Python via Java bằng lệnh sau:
```
$ pip install aspose-slides-java
```

## **Cài đặt từ tệp ZIP**

Để cài đặt và sử dụng Aspose.Slides for Python via Java từ tệp ZIP, hãy làm theo các hướng dẫn sau:

### **Windows**

1. Cài đặt JDK8 và cấu hình biến môi trường `JAVA_HOME`.
2. [Cài đặt Python](https://www.python.org/downloads/) phiên bản >=3.7 và thêm python.exe vào `PATH`.
3. [Cài đặt Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Cài đặt JPype1](https://jpype.readthedocs.io/en/latest/install.html). Bạn có thể chạy các lệnh dưới đây trong terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Tải xuống Aspose.Slides for Python via Java](https://releases.aspose.com/slides/vi/python-java/) và giải nén vào `aspose-slides-java`.
6. Tạo một tệp có tên `example.py` trong thư mục `aspose-slides-java` bằng cách sử dụng đoạn mã mẫu sau:
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
7. Bây giờ chạy `py example.py` trong command prompt để thực thi.

### **Linux**

1. Cài đặt JDK8 cho Linux và cấu hình biến môi trường `JAVA_HOME`.
2. [Cài đặt Python](https://www.python.org/downloads/) phiên bản >=3.7
3. Cài đặt ``g++`` và ``python-dev``. 

- Đối với Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Đối với RedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Cài đặt JPype1](https://jpype.readthedocs.io/en/latest/install.html). Bạn có thể chạy các lệnh dưới đây trong terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Tải xuống Aspose.Slides for Python via Java](https://releases.aspose.com/slides/vi/python-java/) và giải nén vào `aspose-slides-java`.
6. Tạo một tệp thử nghiệm có tên `example.py` bằng đoạn mã mẫu này trong thư mục `aspose-slides-java`:
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
7. Bây giờ chạy `py example.py` trong command prompt để thực thi.

### **Mac**

1. Cài đặt JDK8 cho Mac và cấu hình biến môi trường `JAVA_HOME`.
2. Sửa đổi phần JVMCapabilities trong `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` với quyền root. `jdk1.8.x_xxx.jdk` phụ thuộc vào phiên bản jdk của bạn. Đặt nó như sau:
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
3. [Cài đặt Python](https://www.python.org/downloads/) phiên bản >=3.7.
4. Cài đặt trình biên dịch GCC hoặc Clang tùy thuộc vào phiên bản Python và nền tảng.
5. [Cài đặt JPype1](https://jpype.readthedocs.io/en/latest/install.html). Bạn có thể chạy các lệnh dưới đây trong terminal python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Tải xuống Aspose.Slides for Python via Java](https://releases.aspose.com/slides/vi/python-java/) và giải nén vào `aspose-slides-java`.
7. Tạo một tệp thử nghiệm có tên `example.py` bằng đoạn mã mẫu này trong thư mục `aspose-slides-java`:
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
9. Bây giờ chạy `python example.py` trong command prompt để thực thi.