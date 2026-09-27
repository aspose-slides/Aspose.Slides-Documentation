---
title: इंस्टॉलेशन
type: docs
weight: 70
url: /hi/python-java/installation/
keywords:
- Aspose.Slides डाउनलोड
- Aspose.Slides स्थापित करें
- Aspose.Slides स्थापना
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Windows, Linux, या macOS पर Java के माध्यम से Python के लिए Aspose.Slides स्थापित करें, Java और JPype को कॉन्फ़िगर करें, और एक कार्यशील उदाहरण के साथ सेटअप की पुष्टि करें।"
---
Aspose.Slides for Python via Java Windows, Linux और macOS पर चलता है। यह JPype का उपयोग करके Python से Java लाइब्रेरी तक पहुँचता है। Microsoft PowerPoint आवश्यक नहीं है।

## **पूर्वापेक्षाएँ**

Python पैकेज स्थापित करने से पहले, Python और एक JDK स्थापित करें जो [System Requirements](/slides/hi/python-java/system-requirements/) को पूरा करता हो। उस पृष्ठ पर संगत संस्करण, आर्किटेक्चर आवश्यकताएँ, और JPype को स्रोत से बनाते समय आवश्यक किसी भी निर्भरताओं की सूची दी गई है।

`JAVA_HOME` को JDK इंस्टॉलेशन डायरेक्टरी पर सेट करें, न कि उसके `bin` उपडायरेक्टरी पर, और JDK की `bin` डायरेक्टरी को `PATH` में जोड़ें। पर्यावरण वेरिएबल्स बदलने के बाद एक नया टर्मिनल खोलें।

## **PyPI से स्थापित करें**

निम्नलिखित कमांड टर्मिनल में चलाएँ, Python इंटरैक्टिव प्रॉम्प्ट में नहीं। पैकेजों को अन्य प्रोजेक्ट्स से अलग रखने के लिए एक प्रोजेक्ट डायरेक्टरी और एक वर्चुअल एनवायरनमेंट बनाएं।

### **Windows**

यदि आपका चयनित Python इंटरप्रेटर `PATH` में `python` के रूप में उपलब्ध है, तो Command Prompt में निम्नलिखित कमांड चलाएँ:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux और macOS**

यदि आपका चयनित Python संस्करण `python3` के रूप में उपलब्ध है, तो Bash या zsh में निम्नलिखित कमांड चलाएँ:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Debian या Ubuntu पर, यदि `ensurepip` उपलब्ध नहीं होने के कारण एनवायरनमेंट बनाना विफल हो जाता है, तो `sudo apt-get install python3-venv` के साथ `python3-venv` पैकेज स्थापित करें, फिर एनवायरनमेंट निर्माण कमांड दोहराएँ। अलग से स्थापित Python संस्करण को उसके मिलते-जुलते संस्करण-विशिष्ट `venv` पैकेज की आवश्यकता हो सकती है।

### **पैकेज स्थापित करें**

वर्चुअल एनवायरनमेंट सक्रिय होने पर, JPype और Aspose.Slides स्थापित करें:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

`python -m pip` का उपयोग यह सुनिश्चित करता है कि पैकेज आपके एप्लिकेशन को चलाने वाले इंटरप्रेटर के लिए स्थापित हों।

मौजूदा Aspose.Slides स्थापना को अपडेट करने के लिए, समान एनवायरनमेंट में `python -m pip install --upgrade aspose-slides-java` चलाएँ।

## **ZIP आर्काइव से स्थापित करें**

आप लाइब्रेरी को [Aspose.Slides डाउनलोड पेज](https://releases.aspose.com/slides/python-java/) से भी उपयोग कर सकते हैं:

1. जैसा कि [Prerequisites](#prerequisites) में बताया गया है, Python और Java स्थापित करें।
2. ऊपर दिए निर्देशों का उपयोग करके एक वर्चुअल एनवायरनमेंट बनाएं और सक्रिय करें।
3. `python -m pip install JPype1` के साथ JPype स्थापित करें।
4. Aspose.Slides for Python via Java ZIP आर्काइव डाउनलोड करके एक्सट्रैक्ट करें।
5. एक्सट्रैक्ट किए गए `asposeslides` पैकेज डायरेक्टरी को खोजें। इसकी सामग्री, जिसमें `lib` डायरेक्टरी और JAR फ़ाइल शामिल हैं, को एक साथ रखें।
6. `example.py` को अगले सेक्शन से `asposeslides` डायरेक्टरी के साथ रखें ताकि Python पैकेज को इम्पोर्ट कर सके। आर्काइव में पहले से ही `asposeslides` के बगल में अपना `example.py` मौजूद है; उसे नीचे दिया गया `example.py` से बदलें।

## **स्थापना की जाँच करें**

निम्नलिखित कोड को `example.py` के रूप में सहेजें। यह एक टेक्स्ट बॉक्स के साथ प्रेज़ेंटेशन बनाता है और वर्तमान कार्य निर्देशिका में इसे `out.pptx` के रूप में सहेजता है।

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

वर्चुअल एनवायरनमेंट सक्रिय होने पर, `example.py` वाली डायरेक्टरी से उदाहरण चलाएँ:

```sh
python example.py
```

`asposeslides` इम्पोर्ट जावाबंडल लाइब्रेरी को JVM शुरू होने से पहले रजिस्टर करता है। JVM शुरू करने के बाद `asposeslides.api` इम्पोर्ट करें, और JVM को बंद करने से पहले प्रेज़ेंटेशन संसाधनों को रिलीज़ करें।

{{% alert color="info" title="Note" %}}
बिना लाइसेंस के, आउटपुट में एक मूल्यांकन जलचािहा (watermark) शामिल होता है। मूल्यांकन सीमाएँ और अस्थायी लाइसेंस जानकारी के लिए देखें [Aspose.Slides का मूल्यांकन करें](/slides/hi/python-java/evaluate-aspose-slides/)।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**Python यह रिपोर्ट क्यों करता है कि JVM नहीं मिला या लोड नहीं हो सकता?**  
`JAVA_HOME` यह संकेत करता है कि वह आपका Python और JPype स्थापना के साथ संगत JDK की ओर इशारा कर रहा है, जैसा कि [System Requirements](/slides/hi/python-java/system-requirements/) में बताया गया है, इसे जांचें। अतिरिक्त जाँचों के लिए देखें [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html)।

**स्थापना के बाद Python यह रिपोर्ट क्यों करता है कि `asposeslides` गायब है?**  
पैकेज शायद किसी अलग Python इंटरप्रेटर के लिए स्थापित किया गया है। स्थापना में उपयोग किए गए वर्चुअल एनवायरनमेंट को सक्रिय करें और `python -m pip show aspose-slides-java` चलाएँ। ZIP स्थापना के लिए, सुनिश्चित करें कि `asposeslides` डायरेक्टरी आपके स्क्रिप्ट के साथ है या Python के मॉड्यूल खोज पथ पर उपलब्ध है।

**क्या मैं नोटबुक में उदाहरण को बार-बार चला सकता हूँ?**  
उदाहरण एक स्टैंडअलोन Python प्रक्रिया के लिए है। इसे बार-बार नोटबुक में चलाने के लिए अनुकूलित करने से पहले, JVM जीवनचक्र और नोटबुक मार्गदर्शन के लिए देखें [Limitations and API Differences](/slides/hi/python-java/limitations-and-api-differences/#import-the-library)।

**pip `CERTIFICATE_VERIFY_FAILED` के साथ क्यों विफल हो रहा है?**  
यदि आपका नेटवर्क HTTPS निरीक्षण प्रॉक्सी का उपयोग करता है, तो pip को उसके प्रमाणपत्र प्राधिकरण (CA) पर भरोसा होना चाहिए। भरोसेमंद CA बंडल को pip के `--cert` विकल्प या `PIP_CERT` पर्यावरण वेरिएबल का उपयोग करके कॉन्फ़िगर करें, जैसा कि [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/) में बताया गया है। आवश्यक कॉन्फ़िगरेशन आपके नेटवर्क और pip संस्करण पर निर्भर करता है।