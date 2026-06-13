---
title: PyInstaller और cx_Freeze के साथ संगतता
linktitle: PyInstaller के साथ संगतता
type: docs
weight: 122
url: /hi/python-net/compatibility-with-pyinstaller/
keywords:
- संगतता
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET को PyInstaller के साथ पैकेज करें। इस गाइड का पालन करके अपने ऐप को बंडल, कॉन्फ़िगर और ट्रब्लशूट करके एक स्टैंडअलोन निष्पादन योग्य फ़ाइल बनाएं।"
---
## **परिचय**

Aspose.Slides for Python via .NET extensions मानक Python C एक्सटेंशन हैं, इसलिए इन्हें PyInstaller और cx_Freeze (या समान) जैसे टूल्स के साथ प्रोग्राम निर्भरताओं के रूप में फ्रीज़ किया जा सकता है। यह आपको अपने Python स्क्रिप्ट्स से निष्पादन योग्य फ़ाइलें बनाने की अनुमति देता है। ऐसे टूल्स को “फ्रीज़र” कहा जाता है क्योंकि वे आपके कोड और उसकी निर्भरताओं को एक ही वितरित करने योग्य फ़ाइल में बंडल कर देते हैं जो अन्य मशीनों पर बिना Python इंस्टॉलेशन या अतिरिक्त लाइब्रेरीज़ के चल सकती है। यह दृष्टिकोण आपके Python एप्लिकेशन्स को वितरित करना सरल बनाता है।

Aspose.Slides for Python via .NET एक्सटेंशन को निर्भरताओं के रूप में फ्रीज़ करना नीचे एक साधारण प्रोग्राम के साथ दर्शाया गया है जो Aspose.Slides का उपयोग करता है।

## **PyInstaller**

आमतौर पर, जब आप Aspose.Slides for Python via .NET एक्सटेंशन पर निर्भर एक प्रोग्राम को पैकेज कर रहे हों तो कोई विशेष शर्त नहीं होती। जब प्रोग्राम एक्सटेंशन को ऐसे इम्पोर्ट करता है जो PyInstaller द्वारा देखा जा सके, तो एक्सटेंशन प्रोग्राम के साथ बंडल हो जाएगा। क्योंकि Aspose.Slides for Python via .NET में PyInstaller हुक शामिल होते हैं, उसकी निर्भरताएँ स्वतः पता चल जाती हैं और बंडल में कॉपी हो जाती हैं।

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

हालांकि, PyInstaller कभी‑कभी छिपे हुए इम्पोर्ट्स को मिस कर सकता है—ऐसे मॉड्यूल जो आपके कोड द्वारा डायनैमिक या अप्रत्यक्ष रूप से इम्पोर्ट किए जाते हैं। छिपा इम्पोर्ट शामिल करने के लिए, PyInstaller के विकल्पों का उपयोग करें। एक्सटेंशन की निर्भरताएँ PyInstaller हुक में निर्दिष्ट होती हैं जो Aspose.Slides for Python via .NET के साथ आती हैं।

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

cx_Freeze के साथ एक प्रोग्राम को फ्रीज़ करने के लिए, इसे उस Aspose.Slides for Python via .NET एक्सटेंशन के मूल पैकेज को शामिल करने के लिए कॉन्फ़िगर करें जिसका आप उपयोग कर रहे हैं। इससे यह सुनिश्चित होता है कि एक्सटेंशन और सभी निर्भरताएँ मॉड्यूल आपके एप्लिकेशन के साथ बिल्ड में कॉपी हो जाएँ।

### **Using the cxfreeze Script**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Using the Setup Script**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**क्या मुझे उपयोगकर्ता की मशीन पर Microsoft PowerPoint या .NET इंस्टॉल करने की आवश्यकता है?**

नहीं, PowerPoint की आवश्यकता नहीं है। Aspose.Slides एक स्वनिर्भर इंजन है; Python पैकेज सभी आवश्यक घटकों को CPython के लिए एक्सटेंशन के रूप में शामिल करता है। उपयोगकर्ता को .NET अलग से इंस्टॉल करने की आवश्यकता नहीं है।

**मैं फ़्रीज़्ड एप्लिकेशन के साथ लाइसेंस को सही तरीके से कैसे संलग्न करूँ?**

आप लाइसेंस XML को निष्पादन योग्य फ़ाइल के पास रख सकते हैं या इसे रिसोर्स के रूप में एम्बेड कर सकते हैं और पहले API कॉल से पहले किसी उपलब्ध पथ से लोड कर सकते हैं। महत्वपूर्ण: XML सामग्री को संशोधित न करें (भले ही लाइन्स में बदलाव न करें)।

**यदि बिल्ड के बाद फ़ॉन्ट्स विकास के मुकाबले अलग दिखें तो मुझे क्या करना चाहिए?**

सुनिश्चित करें कि आप जिन फ़ॉन्ट्स का उपयोग कर रहे हैं वे लक्ष्य वातावरण में उपलब्ध हों (बंडल किए गए या सिस्टम‑इंस्टॉल्ड) और उनके पथ रन‑टाइम पर सही ढंग से हल हों; फ़ॉन्ट व्यवहार विशेष रूप से Linux पर संवेदनशील होता है।