---
title: स्थापना
type: docs
weight: 70
url: /hi/python-net/installation/
keywords:
- Aspose.Slides डाउनलोड
- Aspose.Slides स्थापित करें
- Aspose.Slides उपयोग करें
- Aspose.Slides स्थापना
- Windows
- macOS
- Python
description: "Aspose.Slides for Python via .NET को जल्दी स्थापित करने का तरीका जानें। चरण-बद्ध मार्गदर्शिका, सिस्टम आवश्यकताएँ, और कोड नमूने — आज ही PowerPoint प्रस्तुतियों पर काम शुरू करें!"
---
## **अवलोकन**

Aspose.Slides for Python via .NET पैकेज सभी आवश्यक .NET लाइब्रेरीज़ को बंडल करके प्रदान करता है, जिसका अर्थ है कि आपको अलग से .NET स्थापित करने की आवश्यकता नहीं है। यह सेटअप प्रक्रिया को सरल बनाता है और डेवलपर्स को तुरंत प्रेजेंटेशन के साथ काम शुरू करने देता है। हालांकि, यह ध्यान देना महत्वपूर्ण है कि आपके ऑपरेटिंग सिस्टम या पर्यावरण के आधार पर आपको .NET द्वारा आवश्यक कुछ प्लेटफ़ॉर्म‑विशिष्ट निर्भरताएँ अभी भी स्थापित करनी पड़ सकती हैं। अतिरिक्त रूप से, पैकेज की पूर्ण संगतता और सही कार्यशीलता सुनिश्चित करने के लिए कुछ सिस्टम आवश्यकताओं को पूरा करना आवश्यक है।

## **विंडोज**

**सिस्टम आवश्यकताएँ**

अपनी मशीन की विशिष्टताओं की जाँच करें और पुष्टि करें कि वे [सिस्टम आवश्यकताएँ](/slides/hi/python-net/system-requirements/) को पूरा या उससे अधिक हैं।

### **Aspose.Slides स्थापित करें**

`pip` .NET पर Windows में [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) को डाउनलोड और स्थापित करने का सबसे आसान तरीका है।

Aspose.Slides स्थापित करने के लिए, निम्न कमांड चलाएँ:

```sh
pip install aspose-slides
```

**Aspose.Slides का उपयोग करें**

अपने Aspose.Slides स्थापना का परीक्षण करने के लिए निम्न कोड चलाएँ जो एक PowerPoint प्रस्तुति बनाता है:

```python
# Aspose.Slides for Python via .NET मॉड्यूल आयात करें।
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**सिस्टम आवश्यकताएँ**

अपनी मशीन की विशिष्टताओं की जाँच करें और पुष्टि करें कि वे [सिस्टम आवश्यकताएँ](/slides/hi/python-net/system-requirements/) को पूरा या उससे अधिक हैं।

### **पूर्व शर्तें**

**साझा लाइब्रेरीज़ वाला Python**

macOS पर Python स्थापित करने के कई तरीके हैं, लेकिन हम अत्यधिक सलाह देते हैं कि आप [pyenv tool](https://github.com/pyenv/pyenv#homebrew-in-macos) का उपयोग करें।

**pyenv** स्थापित और कॉन्फ़िगर करने के बाद, टर्मिनल ऐप में निम्न कमांड चलाकर साझा लाइब्रेरीज़ के साथ Python स्थापित करें:

1. Python स्थापित करें:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. इसे वैश्विक Python संस्करण के रूप में सेट करें:

```sh
pyenv global 3.9.13
```

3. इसे शेल‑विशिष्ट Python संस्करण के रूप में सेट करें:

```sh
pyenv shell 3.9.13
```

4. सिस्टम लाइब्रेरी डायरेक्टरी में libpython लाइब्रेरी के लिए एक सिम्बोलिक लिंक बनाएं:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

नोट: Python 3.5 या उससे ऊपर आवश्यक है। यहां केवल उदाहरण के रूप में संस्करण 3.9.13 उपयोग किया गया है।

**libgdiplus लाइब्रेरी स्थापित करें**

**libgdiplus** लाइब्रेरी macOS और Linux के लिए Windows GDI+ कार्यान्वयन है, जिस पर .NET उन प्लेटफ़ॉर्म पर ग्राफ़िकल कार्यक्षमता के लिए निर्भर करता है।

macOS पर इस लाइब्रेरी को स्थापित करने के लिए, निम्न कमांड चलाएँ:

```sh
brew install mono-libgdiplus
```

### **Aspose.Slides स्थापित करें**

`pip` macOS पर [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) को डाउनलोड और स्थापित करने का सबसे आसान तरीका है।

Aspose.Slides स्थापित करने के लिए, निम्न कमांड चलाएँ:

```sh
pip install aspose-slides
```

**Aspose.Slides का उपयोग करें**

अपने Aspose.Slides स्थापना का परीक्षण करने के लिए निम्न कोड चलाएँ जो एक PowerPoint प्रस्तुति बनाता है:

```python
# Aspose.Slides for Python via .NET मॉड्यूल आयात करें।
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं Aspose.Slides को एक वर्चुअल वातावरण में स्थापित कर सकता हूँ?**

हाँ, आप `pip` का उपयोग करके इसे किसी भी Python वर्चुअल वातावरण में स्थापित कर सकते हैं। सुनिश्चित करें कि आपका वातावरण आपके OS के अनुसार आवश्यक नेटिव निर्भरताओं तक पहुँच रखता है।

**क्या मैं Docker कंटेनरों में Aspose.Slides का उपयोग कर सकता हूँ?**

हाँ, लेकिन आपको यह सुनिश्चित करना होगा कि आपका Docker इमेज आवश्यक नेटिव लाइब्रेरीज़ (**libgdiplus**, फ़ॉन्ट पैकेज, आदि) तथा सही Python संस्करण शामिल करे।

**क्या कोई मुफ्त संस्करण या ट्रायल सीमा है?**

हाँ, डिफ़ॉल्ट रूप से, Aspose.Slides मूल्यांकन मोड में चलता है, जो वॉटरमार्क लगाता है और अन्य प्रतिबंध हो सकते हैं। प्रतिबंध हटाने के लिए, आपको एक वैध [लाइसेंस](/slides/hi/python-net/licensing/) लागू करना होगा।