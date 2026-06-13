---
title: نصب
type: docs
weight: 70
url: /fa/python-java/installation/
keywords:
- دانلود Aspose.Slides
- نصب Aspose.Slides
- نصب Aspose.Slides
- ویندوز
- macOS
- لینوکس
- پایتون
description: "نصب Aspose.Slides برای Python از طریق Java در ویندوز، لینوکس یا macOS"
---
Aspose.Slides برای Python از طریق Java یک API مستقل از پلتفرم است و می‌تواند در هر پلتفرمی (Windows، Linux و MacOS) که پل `Python`، `Java` و `jpype1` نصب شده باشد، استفاده شود.

## **نیازمندی‌های برنامه‌ها و نسخه‌ها**

برای اطمینان از عملکرد صحیح Aspose.Slides برای Python از طریق Java، برنامه‌ها و بسته‌های زیر باید نصب شوند:

- نسخه JRE >=8 (JPype1 بر روی نسخه‌های Java از 1.8 تا 11 تست شده است).
- نسخه Python >=3.7,<=3.12.
- نسخه بسته JPype1: >=1.5.0.

## **نصب از pip**

می‌توانید به راحتی Aspose.Slides برای Python از طریق Java را از [pip](https://pypi.org/) نصب کنید، به شرط اینکه تمام برنامه‌های مورد نیاز (Java، Python) نصب شده باشند.

یک پوشه پروژه جدید ایجاد کنید.

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) با استفاده از فرمان زیر:
```
$ pip install JPype1
```

Aspose.Slides برای Python از طریق Java را با استفاده از فرمان زیر نصب کنید:
```
$ pip install aspose-slides-java
```

## **نصب از آرشیو ZIP**

برای نصب و استفاده از Aspose.Slides برای Python از طریق Java از یک آرشیو ZIP، به جای آن دستورالعمل‌های زیر را دنبال کنید:

### **ویندوز**

1. JDK8 را نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.
2. نسخه >=3.7 [Python](https://www.python.org/downloads/) را نصب کنید و python.exe را به `PATH` اضافه کنید.
3. [Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/) را نصب کنید.
4. [JPype1](https://jpype.readthedocs.io/en/latest/install.html) را نصب کنید. می‌توانید دستورات زیر را در ترمینال پایتون اجرا کنید:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Aspose.Slides برای Python از طریق Java](https://releases.aspose.com/slides/fa/python-java/) را دانلود کنید و در `aspose-slides-java` استخراج کنید.
6. فایلی با نام `example.py` در پوشه `aspose-slides-java` ایجاد کنید و از کد نمونه زیر استفاده کنید:
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
7. حالا `py example.py` را در خط فرمان اجرا کنید.

### **لینوکس**

1. JDK8 را برای لینوکس نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.
2. نسخه >=3.7 [Python](https://www.python.org/downloads/) را نصب کنید
3. ``g++`` و ``python-dev`` را نصب کنید. 

- برای Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- برای توزیع‌های مبتنی بر RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```
4. [JPype1](https://jpype.readthedocs.io/en/latest/install.html) را نصب کنید. می‌توانید دستورات زیر را در ترمینال پایتون اجرا کنید:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Aspose.Slides برای Python از طریق Java](https://releases.aspose.com/slides/fa/python-java/) را دانلود کنید و در `aspose-slides-java` استخراج کنید.
6. فایلی آزمایشی به نام `example.py` ایجاد کنید و از این کد نمونه در پوشه `aspose-slides-java` استفاده کنید:
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
7. حالا `py example.py` را در خط فرمان اجرا کنید.

### **مک**

1. JDK8 را برای مک نصب کنید و متغیر محیطی `JAVA_HOME` را پیکربندی کنید.
2. بخش JVMCapabilities را در مسیر `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` با دسترسی روت تغییر دهید. `jdk1.8.x_xxx.jdk` بسته به نسخه JDK شما متفاوت است. آن را به شکل زیر درآورید:
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
3. نسخه >=3.7 [Python](https://www.python.org/downloads/) را نصب کنید.
4. بسته به نسخه Python و پلتفرم، کامپایلرهای GCC یا Clang را نصب کنید.
5. [JPype1](https://jpype.readthedocs.io/en/latest/install.html) را نصب کنید. می‌توانید دستورات زیر را در ترمینال پایتون اجرا کنید:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Aspose.Slides برای Python از طریق Java](https://releases.aspose.com/slides/fa/python-java/) را دانلود کنید و در `aspose-slides-java` استخراج کنید.
7. فایلی آزمایشی به نام `example.py` ایجاد کنید و از این کد نمونه در پوشه `aspose-slides-java` استفاده کنید:
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
9. حالا `python example.py` را در خط فرمان اجرا کنید.