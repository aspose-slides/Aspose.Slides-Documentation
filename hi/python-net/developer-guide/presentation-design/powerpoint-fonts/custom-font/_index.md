---
title: "Python में PowerPoint फ़ॉन्ट को कस्टमाइज़ करें"
linktitle: "कस्टम फ़ॉन्ट"
type: docs
weight: 20
url: /hi/python-net/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET के साथ PowerPoint स्लाइड्स में कस्टम फ़ॉन्ट एम्बेड करें ताकि आपकी प्रस्तुतियां किसी भी डिवाइस पर स्पष्ट और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides for Python आपको रनटाइम पर कस्टम फ़ॉन्ट प्रदान करने की अनुमति देता है ताकि प्रस्तुतियों को सही ढंग से रेंडर किया जा सके, भले ही आवश्यक फ़ॉन्ट होस्ट सिस्टम पर इंस्टॉल न किए गए हों। PDF या इमेज में निर्यात करते समय, आप फ़ॉन्ट फ़ोल्डरों या मेमोरी में मौजूद फ़ॉन्ट डेटा को प्रदान करके टेक्स्ट लेआउट, ग्लिफ़ मेट्रिक्स और टाइपोग्राफी को संरक्षित रख सकते हैं। यह विभिन्न वातावरणों में सर्वर-साइड रेंडरिंग को पूर्वानुमानित बनाता है, OS-स्तर की फ़ॉन्ट निर्भरताओं को हटाता है, और अनचाहे फ़ॉलबैक या रीफ़्लो को रोकता है। लेख दिखाता है कि फ़ॉन्ट स्रोतों को कैसे रजिस्टर्ड किया जाए।

Aspose.Slides आपको निम्नलिखित फ़ॉन्ट लोड करने की अनुमति देता है, `load_external_font` और `load_external_fonts` मेथड्स का उपयोग करके [FontsLoader](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/) क्लास का।

- TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType).
- OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **कस्टम फ़ॉन्ट लोड करें**

Aspose.Slides आपको प्रस्तुतिकरण में उपयोग किए गए फ़ॉन्ट को सिस्टम पर इंस्टॉल किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, इमेज और अन्य समर्थित फ़ॉर्मेट—को प्रभावित करता है, जिससे परिणामी दस्तावेज़ विभिन्न वातावरणों में सुसंगत दिखते हैं। फ़ॉन्ट कस्टम डायरेक्टरीज़ से लोड किए जाते हैं।

1. ऐसे एक या अधिक फ़ोल्डर निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हों।
2. स्टेटिक [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/load_external_fonts/) मेथड को कॉल करके उन फ़ोल्डरों से फ़ॉन्ट लोड करें।
3. प्रस्तुतीकरण को लोड और रेंडर/निर्यात करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिये [FontsLoader.clear_cache](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/clear_cache/) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोड करने की प्रक्रिया को दर्शाता है:

```py
import aspose.slides as slides

# कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डरों को परिभाषित करें।
font_folders = [ external_font_folder1, external_font_folder2 ]

# निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/निर्यात करें (जैसे PDF, इमेज या अन्य फ़ॉर्मेट)।
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# कार्य समाप्त होने पर फ़ॉन्ट कैश को साफ़ करें।
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="नोट" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/load_external_fonts/) फ़ॉन्ट सर्च पाथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट इनिशियलाइज़ेशन क्रम को नहीं बदलता है।  
फ़ॉन्ट इस क्रम में इनिशियलाइज़ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पाथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पाथ।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें**

Aspose.Slides `get_font_folders` मेथड प्रदान करता है जिससे फ़ॉन्ट फ़ोल्डर प्राप्त किए जा सकते हैं। यह `load_external_fonts` द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर दोनों को रिटर्न करता है।

यह Python कोड दिखाता है कि `get_font_folders` का उपयोग कैसे किया जाता है:

```python
import aspose.slides as slides

# यह कॉल फ़ॉन्ट फ़ाइलों के लिए जांचे गए फ़ोल्डरों को लौटाता है।
# इसमें load_external_fonts मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर शामिल हैं।
font_folders = slides.FontsLoader.get_font_folders()
```

## **प्रस्तुति के लिए कस्टम फ़ॉन्ट निर्दिष्ट करें**

Aspose.Slides `document_level_font_sources` प्रॉपर्टी प्रदान करता है, जिससे आप प्रस्तुति के साथ उपयोग करने के लिये बाहरी फ़ॉन्ट निर्दिष्ट कर सकते हैं।

निम्नलिखित Python उदाहरण दिखाता है कि `document_level_font_sources` का उपयोग कैसे किया जाता है:

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
    # प्रस्तुति के साथ काम करें।
    # CustomFont1, CustomFont2, और assets\\fonts तथा global\\fonts फ़ोल्डरों (और उनके सबफ़ोल्डरों) के फ़ॉन्ट प्रस्तुति के लिए उपलब्ध हैं।
    # ...
    print(len(presentation.slides))
```

## **बाइनरी डेटा से बाहरी फ़ॉन्ट लोड करें**

Aspose.Slides `load_external_font` मेथड प्रदान करता है जिससे बाइनरी डेटा से बाहरी फ़ॉन्ट लोड किए जा सकते हैं।

निम्नलिखित Python उदाहरण बाइट एरे से फ़ॉन्ट लोड करने को दर्शाता है:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# बाइट ऐरे से बाहरी फ़ॉन्ट लोड करें।
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # बाहरी फ़ॉन्ट इस प्रस्तुति इंस्टेंस के जीवनकाल तक उपलब्ध हैं।
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मेट्स (PDF, PNG, SVG, HTML) में निर्यात को प्रभावित करते हैं?**

हां। जुड़े हुए फ़ॉन्ट रेंडरर द्वारा सभी निर्यात फ़ॉर्मेट्स में उपयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट स्वचालित रूप से परिणामी PPTX में एम्बेड हो जाते हैं?**

नहीं। रेंडरिंग के लिये फ़ॉन्ट को रजिस्टर्ड करना और इसे PPTX में एम्बेड करना समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/python-net/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्रिफ़ न होने पर फ़ॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**

हां। आप [font substitution](/slides/hi/python-net/font-substitution/), [replacement rules](/slides/hi/python-net/font-replacement/) और [fallback sets](/slides/hi/python-net/fallback-font/) को कॉन्फ़िगर करके यह निर्धारित कर सकते हैं कि अनुरोधित ग्रिफ़ अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए।

**क्या मैं Linux/Docker कंटेनर में फ़ॉन्ट का उपयोग कर सकता हूँ बिना उन्हें सिस्टम-वाइड इंस्टॉल किए?**

हां। आप अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर इशारा कर सकते हैं या बाइट एरे से फ़ॉन्ट लोड कर सकते हैं। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरीज़ पर निर्भरता समाप्त हो जाती है।

**लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**

फ़ॉन्ट लाइसेंसिंग अनुपालन की ज़िम्मेदारी आपका अपना कार्य है। शर्तें भिन्न होती हैं; कुछ लाइसेंस एम्बेडिंग या वाणिज्यिक उपयोग को प्रतिबंधित करते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA की समीक्षा करें।