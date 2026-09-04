---
title: स्थापना
type: docs
weight: 70
url: /hi/python-java/installation/
keywords:
- Aspose.Slides डाउनलोड करें
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- पाइथन
- जावा
- JPype
- विंडोज
- macOS
- लिनक्स
description: "विंडोज, लिनक्स या macOS पर Java के माध्यम से पाइथन के लिए Aspose.Slides स्थापित करें, Java और JPype को कॉन्फ़िगर करें, और एक कार्यशील उदाहरण के साथ सेटअप को सत्यापित करें।"
---
Aspose.Slides for Python via Java Windows, Linux और macOS पर चलता है। यह JPype का उपयोग करके Python से Java लाइब्रेरी तक पहुँचता है। Microsoft PowerPoint आवश्यक नहीं है।

## **पूर्व आवश्यकताएँ**

Python पैकेज स्थापित करने से पहले, Python और एक JDK स्थापित करें जो [System Requirements](/slides/hi/python-java/system-requirements/) को पूरा करता हो। उस पृष्ठ में संगत संस्करण, आर्किटेक्चर आवश्यकताएँ और JPype को स्रोत से बनाने के लिए आवश्यक कोई भी निर्भरताएँ सूचीबद्ध हैं।

`JAVA_HOME` को JDK इंस्टॉल डायरेक्टरी पर सेट करें, न कि उसकी `bin` उपडायरेक्टरी पर, और JDK की `bin` डायरेक्टरी को `PATH` में जोड़ें। पर्यावरण वेरिएबल बदलने के बाद एक नया टर्मिनल खोलें।

## **PyPI से स्थापित करें**

निम्नलिखित कमांड्स एक टर्मिनल में चलाएँ, Python इंटरैक्टिव प्रॉम्प्ट में नहीं। पैकेजों को अन्य प्रोजेक्ट्स से अलग रखने के लिए एक प्रोजेक्ट डायरेक्टरी और एक वर्चुअल एन्वायरनमेंट बनाएं।

### **Windows**

आपके चुने हुए Python इंटरप्रेटर को `PATH` पर `python` के रूप में उपलब्ध होने पर, Command Prompt में निम्नलिखित कमांड्स चलाएँ:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux और macOS**

आपके चुने हुए Python संस्करण को `python3` के रूप में उपलब्ध होने पर, Bash या zsh में निम्नलिखित कमांड्स चलाएँ:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian या Ubuntu पर, यदि एन्वायरनमेंट बनाने में `ensurepip` उपलब्ध नहीं होने के कारण विफलता होती है, तो `sudo apt-get install python3-venv` के साथ `python3-venv` पैकेज इंस्टॉल करें, फिर एन्वायरनमेंट निर्माण कमांड दोहराएँ। अलग से इंस्टॉल किए गए Python संस्करण को उसके संगत संस्करण-विशिष्ट `venv` पैकेज की आवश्यकता हो सकती है।

### **पैकेजों को स्थापित करें**

वर्चुअल एन्वायरनमेंट सक्रिय होने पर, JPype और Aspose.Slides स्थापित करें:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` का उपयोग यह सुनिश्चित करता है कि पैकेज उसी इंटरप्रेटर के लिए स्थापित हों जिसका उपयोग आपका एप्लिकेशन चलाने में किया जाता है।

मौजूदा Aspose.Slides इंस्टालेशन को अपडेट करने के लिए, उसी एन्वायरनमेंट में `python -m pip install --upgrade aspose-slides-java` चलाएँ।

## **ZIP अभिलेख से स्थापित करें**

आप लाइब्रेरी को [Aspose.Slides डाउनलोड पेज](https://releases.aspose.com/slides/hi/python-java/) से भी उपयोग कर सकते हैं:

1. उपरोक्त [Prerequisites](#prerequisites) के अनुसार Python और Java स्थापित करें।
2. ऊपर दी गई निर्देशों का उपयोग करके एक वर्चुअल एन्वायरनमेंट बनाएं और सक्रिय करें।
3. `python -m pip install JPype1` के साथ JPype स्थापित करें।
4. Aspose.Slides for Python via Java ZIP अभिलेख डाउनलोड करें और निकालें।
5. निकाली गई `asposeslides` पैकेज डायरेक्टरी को खोजें। उसकी सामग्री, जिसमें `lib` डायरेक्टरी और JAR फ़ाइल शामिल हैं, को एक साथ रखें।
6. अगले सेक्शन की `example.py` फ़ाइल को `asposeslides` डायरेक्टरी के बगल में रखें ताकि Python पैकेज को इम्पोर्ट कर सके।

## **इंस्टॉलेशन की पुष्टि करें**

`example.py` के रूप में निम्नलिखित कोड सहेजें। यह एक टेक्स्ट बॉक्स के साथ प्रेज़ेंटेशन बनाता है और वर्तमान कार्य डायरेक्टरी में इसे `out.pptx` के रूप में सहेजता है।

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

वर्चुअल एन्वायरनमेंट सक्रिय होने पर, `example.py` वाली डायरेक्टरी से उदाहरण चलाएँ:

```sh
python example.py
```

`asposeslides` इम्पोर्ट JVM शुरू होने से पहले बंडल्ड Java लाइब्रेरी को रजिस्टर करता है। JVM शुरू करने के बाद `asposeslides.api` इम्पोर्ट करें, और JVM को बंद करने से पहले प्रेज़ेंटेशन संसाधनों को रिलीज़ करें।

{{% alert color="info" title="Note" %}}
बिना लाइसेंस के, आउटपुट में एक मूल्यांकन वॉटरमार्क शामिल होगा। मूल्यांकन सीमाओं और अस्थायी लाइसेंस जानकारी के लिए देखें [Evaluate Aspose.Slides](/slides/hi/python-java/evaluate-aspose-slides/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Python रिपोर्ट करता है कि JVM नहीं मिला या लोड नहीं हो रहा है, ऐसा क्यों?**

जांचें कि `JAVA_HOME` आपके Python और JPype इंस्टालेशन के साथ अनुकूलित JDK की ओर इशारा करता है, जैसा कि [System Requirements](/slides/hi/python-java/system-requirements/) में बताया गया है। अतिरिक्त जाँच के लिए देखें [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html)।

**Python रिपोर्ट करता है कि `asposeslides` नहीं मिला इंस्टालेशन के बाद, ऐसा क्यों?**

संभव है कि पैकेज किसी अलग Python इंटरप्रेटर के लिए स्थापित किया गया हो। इंस्टालेशन के दौरान प्रयुक्त वर्चुअल एन्वायरनमेंट को सक्रिय करें और `python -m pip show aspose-slides-java` चलाएँ। ZIP इंस्टालेशन के लिए, सुनिश्चित करें कि `asposeslides` डायरेक्टरी आपके स्क्रिप्ट के बगल में या Python के मॉड्यूल खोज पाथ में उपलब्ध है।

**क्या मैं उदाहरण को नोटबुक में बार-बार चला सकता हूँ?**

उदाहरण एक स्टैंडअलोन Python प्रोसेस के लिए बनाया गया है। इसे नोटबुक में बार-बार चलाने के लिए अनुकूलित करने से पहले, JVM जीवनचक्र और नोटबुक मार्गदर्शन के लिए देखें [Limitations and API Differences](/slides/hi/python-java/limitations-and-api-differences/#import-the-library)।

**pip `CERTIFICATE_VERIFY_FAILED` के साथ विफल क्यों होता है?**

यदि आपका नेटवर्क HTTPS निरीक्षण प्रॉक्सी का उपयोग करता है, तो pip को उसके प्रमाणपत्र प्राधिकरण पर भरोसा करना होगा। pip के `--cert` विकल्प या `PIP_CERT` पर्यावरण वेरिएबल का उपयोग करके विश्वसनीय CA बंडल कॉन्फ़िगर करें, जैसा कि [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/) में बताया गया है। आवश्यक कॉन्फ़िगरेशन आपके नेटवर्क और pip संस्करण पर निर्भर करता है।