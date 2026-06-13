---
title: स्थापना
type: docs
weight: 70
url: /hi/python-java/installation/
keywords:
- Aspose.Slides डाउनलोड
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- विंडोज़
- macOS
- Linux
- Python
description: "Windows, Linux या macOS में Java के माध्यम से Python के लिए Aspose.Slides स्थापित करें"
---
Aspose.Slides for Python via Java एक प्लेटफ़ॉर्म‑स्वतंत्र API है और इसे किसी भी प्लेटफ़ॉर्म (Windows, Linux और MacOS) पर उपयोग किया जा सकता है जहाँ `Python`, `Java` और `jpype1` ब्रिज स्थापित हों।

## **प्रोग्राम और संस्करणों की आवश्यकताएँ**

Aspose.Slides for Python via Java के सही संचालन के लिये, निम्नलिखित प्रोग्राम और पैकेज स्थापित होना आवश्यक है:

- JRE का संस्करण >=8 (JPype1 का परीक्षण Java संस्करण 1.8 से 11 तक किया गया है)।
- Python का संस्करण >=3.7, <=3.12।
- JPype1 पैकेज संस्करण: >=1.5.0।

## **pip से स्थापित करें**

आप आसानी से Aspose.Slides for Python via Java को [pip](https://pypi.org/) से स्थापित कर सकते हैं, बशर्ते कि सभी आवश्यक प्रोग्राम (Java, Python) स्थापित हों।

एक नया प्रोजेक्ट फ़ोल्डर बनाएँ।

[Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) का उपयोग करके निम्न कमांड चलाएँ:
```
$ pip install JPype1
```

निम्न कमांड का उपयोग करके Aspose.Slides for Python via Java स्थापित करें:
```
$ pip install aspose-slides-java
```

## **ZIP आर्काइव से स्थापित करें**

Aspose.Slides for Python via Java को ZIP आर्काइव से स्थापित करने और उपयोग करने के लिये, इस निर्देश का पालन करें:

### **Windows**

1. JDK8 स्थापित करें और `JAVA_HOME` एनवायरनमेंट वेरिएबल को कॉन्फ़िगर करें।
2. [Install Python](https://www.python.org/downloads/) का संस्करण >=3.7 स्थापित करें और python.exe को `PATH` में जोड़ें।
3. [Install Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/) स्थापित करें।
4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) स्थापित करें। आप नीचे दिए गए कमांड को python टर्मिनल में चला सकते हैं:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/hi/python-java/) डाउनलोड करें और इसे `aspose-slides-java` फ़ोल्डर में निकालें।
6. `aspose-slides-java` फ़ोल्डर में `example.py` नामक फ़ाइल बनाकर निम्न नमूना कोड डालें:

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

7. अब कमांड प्रॉम्प्ट में `py example.py` चलाकर इसे कार्यान्वित करें।

### **Linux**

1. Linux के लिये JDK8 स्थापित करें और `JAVA_HOME` एनवायरनमेंट वेरिएबल को कॉन्फ़िगर करें।
2. [Install Python](https://www.python.org/downloads/) का संस्करण >=3.7 स्थापित करें।
3. ``g++`` और ``python-dev`` स्थापित करें।  

- Debian/Ubuntu के लिये:
    ```
    sudo apt-get install g++ python3-dev
    ```
- RedHat‑आधारित सिस्टम के लिये:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) स्थापित करें। आप नीचे दिए गए कमांड को python टर्मिनल में चला सकते हैं:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/hi/python-java/) डाउनलोड करें और इसे `aspose-slides-java` फ़ोल्डर में निकालें।
6. `aspose-slides-java` फ़ोल्डर में `example.py` नामक परीक्षण फ़ाइल बनाकर इस नमूना कोड को डालें:

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
7. अब कमांड प्रॉम्प्ट में `py example.py` चलाकर इसे कार्यान्वित करें।

### **Mac**

1. Mac के लिये JDK8 स्थापित करें और `JAVA_HOME` एनवायरनमेंट वेरिएबल को कॉन्फ़िगर करें।
2. `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` फ़ाइल में `JVMCapabilities` सेक्शन को रूट अधिकार के साथ संशोधित करें। `jdk1.8.x_xxx.jdk` आपके JDK संस्करण पर निर्भर करता है। इसे इस प्रकार दिखाएँ:
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
3. [Install Python](https://www.python.org/downloads/) का संस्करण >=3.7 स्थापित करें।
4. Python के संस्करण और प्लेटफ़ॉर्म के अनुसार GCC या Clang कंपाइलर स्थापित करें।
5. [Install JPype1](https://jpype.readthedocs.io/en/latest/install.html) स्थापित करें। आप नीचे दिए गए कमांड को python टर्मिनल में चला सकते हैं:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Download Aspose.Slides for Python via Java](https://releases.aspose.com/slides/hi/python-java/) डाउनलोड करें और इसे `aspose-slides-java` में निकालें।
7. `aspose-slides-java` फ़ोल्डर में `example.py` नामक परीक्षण फ़ाइल बनाकर इस नमूना कोड को डालें:

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
9. अब टर्मिनल में `python example.py` चलाकर इसे कार्यान्वित करें।