---
title: Python में PowerPoint फ़ॉन्ट को कस्टमाइज़ करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/python-net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधन करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "Aspose.Slides for Python को .NET के माध्यम से उपयोग करके PowerPoint स्लाइड्स में कस्टम फ़ॉन्ट एम्बेड करें ताकि आपके प्रेजेंटेशन किसी भी डिवाइस पर तेज़ और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides for Python आपको रनटाइम पर कस्टम फ़ॉन्ट प्रदान करने की अनुमति देता है ताकि प्रस्तुतियों को सही ढंग से रेंडर किया जा सके, भले ही आवश्यक फ़ॉन्ट होस्ट सिस्टम पर स्थापित न हों। PDF या इमेज में निर्यात के दौरान, आप फ़ॉन्ट फ़ोल्डर या इन‑मेमोरी फ़ॉन्ट डेटा प्रदान कर सकते हैं जिससे टेक्स्ट लेआउट, ग्लाइफ़ मीट्रिक्स और टाइपोग्राफी संरक्षित रहती है। यह सर्वर‑साइड रेंडरिंग को विभिन्न वातावरणों में पूर्वानुमानित बनाता है, OS‑स्तर की फ़ॉन्ट निर्भरताओं को हटाता है, और अनचाहे फ़ॉलबैक या रीफ़्लो को रोकता है। यह लेख फ़ॉन्ट स्रोतों को पंजीकृत करने का तरीका दिखाता है।

एक प्रस्तुति थीम विभिन्न लेखन प्रणाली के लिए अलग‑अलग फ़ॉन्ट परिवारों को संदर्भित कर सकती है। ये मैपिंग्स फ़ॉन्ट नाम संग्रहीत करती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/python-net/script-specific-font-mappings/), और नीचे दिए गए लोडिंग विकल्पों का उपयोग करके संदर्भित फ़ॉन्ट को सुसंगत रेंडरिंग के लिए उपलब्ध कराएँ।

Aspose.Slides आपको निम्नलिखित फ़ॉन्ट्स लोड करने की अनुमति देता है, जिसका उपयोग आप `load_external_font` और `load_external_fonts` मेथड्स के माध्यम से [FontsLoader](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/) क्लास में कर सकते हैं:

- TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।
- OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।

## **कस्टम फ़ॉन्ट लोड करना**

Aspose.Slides आपको प्रस्तुतियों में प्रयुक्त फ़ॉन्ट को सिस्टम पर स्थापित किए बिना लोड करने की सुविधा देता है। यह निर्यात आउटपुट—जैसे PDF, इमेज और अन्य समर्थित फ़ॉर्मेट्स—को प्रभावित करता है, जिससे विभिन्न वातावरणों में उत्पन्न दस्तावेज़ समान दिखते हैं। फ़ॉन्ट कस्टम डायरेक्टरी से लोड किए जाते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. उन फ़ोल्डरों से फ़ॉन्ट लोड करने के लिये स्थिर [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/load_external_fonts/) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिये [FontsLoader.clear_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/clear_cache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```py
import aspose.slides as slides

# कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर परिभाषित करें।
font_folders = ["fonts", "external_fonts"]

# निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # लोड किए गए फ़ॉन्ट का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (उदा., PDF, इमेज या अन्य फ़ॉर्मेट में)।
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# काम समाप्त होने के बाद फ़ॉन्ट कैश साफ़ करें।
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/load_external_fonts/) अतिरिक्त फ़ोल्डरों को फ़ॉन्ट खोज पथ में जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता।
फ़ॉन्ट इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।
2. [FontsLoader](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/) द्वारा लोड किए गए पथ।

{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करना**

Aspose.Slides `get_font_folders` मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर प्राप्त कर सकते हैं। यह `load_external_fonts` के माध्यम से जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर दोनों को वापस करता है।

यह Python कोड दिखाता है कि `get_font_folders` का उपयोग कैसे करें:

```python
import aspose.slides as slides

# यह कॉल फ़ॉन्ट फ़ाइलों के लिए जांचे गए फ़ोल्डर लौटाती है।
# इनमें load_external_fonts मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर शामिल हैं।
font_folders = slides.FontsLoader.get_font_folders()
```

## **प्रस्तुति के लिए कस्टम फ़ॉन्ट निर्दिष्ट करना**

Aspose.Slides `document_level_font_sources` प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति के साथ उपयोग हेतु बाहरी फ़ॉन्ट निर्दिष्ट कर सकते हैं।

निम्नलिखित Python उदाहरण `document_level_font_sources` के उपयोग को दर्शाता है:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # प्रस्तुति के साथ कार्य करें।
    # CustomFont1, CustomFont2, और assets\fonts तथा global\fonts फ़ोल्डरों (और उनकी सबफ़ोल्डरों) के फ़ॉन्ट प्रस्तुति के लिए उपलब्ध हैं।
    # ...
    print(len(presentation.slides))
```

## **बायनरी डेटा से बाहरी फ़ॉन्ट लोड करना**

Aspose.Slides `load_external_font` मेथड प्रदान करता है जिससे आप बायनरी डेटा से बाहरी फ़ॉन्ट लोड कर सकते हैं।

निम्नलिखित Python उदाहरण बाइट एरे से फ़ॉन्ट लोड करने को दर्शाता है:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# बाइट एरे से बाहरी फ़ॉन्ट लोड करें।
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # बाहरी फ़ॉन्ट इस प्रस्तुति इंस्टेंस के जीवनकाल के लिए उपलब्ध हैं।
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मेट (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?

हाँ। जुड़े फ़ॉन्ट रेंडरर द्वारा सभी निर्यात फ़ॉर्मेट में उपयोग किए जाते हैं।

### क्या कस्टम फ़ॉन्ट स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?

नहीं। रेंडरिंग के लिये फ़ॉन्ट पंजीकृत करना इसका अर्थ नहीं है कि वह PPTX में एम्बेड हो गया है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के अंदर ले जाना है, तो स्पष्ट [embedding features](/slides/hi/python-net/embedded-font/) का उपयोग करें।

### यदि कस्टम फ़ॉन्ट में कुछ ग्लाइफ़ नहीं हैं तो फ़ॉलबैक व्यवहार को कैसे नियंत्रित किया जा सकता है?

हाँ। [font substitution](/slides/hi/python-net/font-substitution/), [replacement rules](/slides/hi/python-net/font-replacement/), और [fallback sets](/slides/hi/python-net/fallback-font/) को कॉन्फ़िगर करके आप ठीक‑ठीक निर्धारित कर सकते हैं कि जब अनुरोधित ग्लाइफ़ अनुपलब्ध हो तो कौन सा फ़ॉन्ट उपयोग किया जाएगा।

### क्या मैं Linux/Docker कंटेनर में फ़ॉन्ट स्थापित किए बिना उनका उपयोग कर सकता हूँ?

हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर संकेत करें या बाइट एरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर निर्भरता समाप्त हो जाती है।

### लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंधों के एम्बेड कर सकता हूँ?

आप फ़ॉन्ट लाइसेंस अनुपालन के लिए जिम्मेदार हैं। शर्तें विभिन्न हो सकती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर प्रतिबंध लगा सकते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट की EULA की समीक्षा करें।