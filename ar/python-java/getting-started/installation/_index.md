---
title: التثبيت
type: docs
weight: 70
url: /python-java/installation/
keySlides: "تنزيل Aspose.Slides، تثبيت Aspose.Slides، تثبيت Aspose.Slides، ويندوز، macOS، لينوكس، بايثون"
description: "قم بتثبيت Aspose.Slides لـ Python عبر Java على ويندوز أو لينوكس أو macOS"
---

Aspose.Slides لـ Python عبر Java هو واجهة برمجة تطبيقات مستقلة عن النظام الأساسي ويمكن استخدامها على أي نظام أساسي (ويندوز، لينوكس وMacOS) حيث تم تثبيت `Python` و`Java` و`jpype1`.

## **المتطلبات للبرامج والإصدارات**

لتوفير التشغيل الصحيح لـ Aspose.Slides لـ Python عبر Java، يجب تثبيت البرامج والحزم التالية:

- إصدار JRE >=8 (تم اختبار JPype1 على إصدارات Java من 1.8 إلى 11).
- إصدار بايثون >=3.7،<=3.12.
- إصدار حزمة JPype1: >=1.5.0.

## **التثبيت من pip**

يمكنك بسهولة تثبيت Aspose.Slides لـ Python عبر Java من [pip](https://pypi.org/) طالما أن لديك جميع البرامج المطلوبة (Java، بايثون) مثبتة.

قم بإنشاء مجلد مشروع جديد.

[قم بتثبيت JPype1](https://jpype.readthedocs.io/en/latest/install.html) باستخدام الأمر التالي:
```
$ pip install JPype1
```

قم بتثبيت Aspose.Slides لـ Python عبر Java باستخدام الأمر التالي:
```
$ pip install aspose-slides-java
```

## **التثبيت من ملف ZIP**

لتثبيت واستخدام Aspose.Slides لـ Python عبر Java من ملف ZIP، اتبع هذه التعليمات بدلاً من ذلك:

### **ويندوز**

1. قم بتثبيت JDK8 وتكوين متغير البيئة `JAVA_HOME`.
2. [قم بتثبيت بايثون](https://www.python.org/downloads/) إصدار >=3.7 وأضف python.exe إلى `PATH`.
3. [قم بتثبيت أدوات بناء Microsoft C++](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [قم بتثبيت JPype1](https://jpype.readthedocs.io/en/latest/install.html). يمكنك تشغيل الأوامر أدناه في محطة بايثون:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [قم بتنزيل Aspose.Slides لـ Python عبر Java](https://releases.aspose.com/slides/python-java/) و استخراجها إلى `aspose-slides-java`.
6. قم بإنشاء ملف باسم `example.py` في مجلد `aspose-slides-java` باستخدام الكود النموذجي التالي:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. الآن قم بتشغيل `py example.py` في موجه الأوامر لتشغيله.

### **لينوكس**

1. قم بتثبيت JDK8 على لينوكس وتكوين متغير البيئة `JAVA_HOME`.
2. [قم بتثبيت بايثون](https://www.python.org/downloads/) إصدار >=3.7
3. قم بتثبيت ``g++`` و ``python-dev``. 

- لDebian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- لRedHat-based:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [قم بتثبيت JPype1](https://jpype.readthedocs.io/en/latest/install.html). يمكنك تشغيل الأوامر أدناه في محطة بايثون:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [قم بتنزيل Aspose.Slides لـ Python عبر Java](https://releases.aspose.com/slides/python-java/) و استخراجها إلى `aspose-slides-java`.
6. قم بإنشاء ملف اختبار باسم `example.py` باستخدام هذا الكود النموذجي في مجلد `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. الآن قم بتشغيل `py example.py` في موجه الأوامر لتشغيله.

### **ماك**

1. قم بتثبيت JDK8 على ماك وتكوين متغير البيئة `JAVA_HOME`.
2. عدل قسم JVMCapabilities في `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` بصلاحيات الجذر. يعتمد `jdk1.8.x_xxx.jdk` على إصدار JDK الخاص بك. اجعله يبدو مثل هذا:
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
3. [قم بتثبيت بايثون](https://www.python.org/downloads/) إصدار >=3.7.
4. قم بتثبيت مترجمي GCC أو Clang اعتمادًا على إصدار بايثون والنظام الأساسي.
5. [قم بتثبيت JPype1](https://jpype.readthedocs.io/en/latest/install.html). يمكنك تشغيل الأوامر أدناه في محطة بايثون:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [قم بتنزيل Aspose.Slides لـ Python عبر Java](https://releases.aspose.com/slides/python-java/) و استخراجها إلى `aspose-slides-java`.
7. قم بإنشاء ملف اختبار باسم `example.py` باستخدام هذا الكود النموذجي في مجلد `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("عنوان الشريحة")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. الآن قم بتشغيل `python example.py` في موجه الأوامر لتشغيله.
