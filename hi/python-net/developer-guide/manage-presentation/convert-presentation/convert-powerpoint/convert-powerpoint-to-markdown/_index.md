---
title: Python में PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint को Markdown में परिवर्तित करें
- OpenDocument को Markdown में परिवर्तित करें
- प्रस्तुति को Markdown में परिवर्तित करें
- स्लाइड को Markdown में परिवर्तित करें
- PPT को Markdown में परिवर्तित करें
- PPTX को Markdown में परिवर्तित करें
- ODP को Markdown में परिवर्तित करें
- PowerPoint को MD में परिवर्तित करें
- OpenDocument को MD में परिवर्तित करें
- प्रस्तुति को MD में परिवर्तित करें
- स्लाइड को MD में परिवर्तित करें
- PPT को MD में परिवर्तित करें
- PPTX को MD में परिवर्तित करें
- ODP को MD में परिवर्तित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Markdown
- Python
- Aspose.Slides
description: Aspose.Slides for Python via .NET के साथ PowerPoint और OpenDocument स्लाइड—PPT, PPTX, ODP—को साफ़ Markdown में परिवर्तित करें, दस्तावेज़ीकरण को स्वचालित करें और स्वरूपण बनाए रखें।
---
## **परिचय**

Aspose.Slides आपको PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करने की अनुमति देता है, जो दस्तावेज़ीकरण कार्यप्रवाह, स्थैतिक साइट निर्माण, सामग्री माइग्रेशन और संस्करण‑नियंत्रित पाठ प्रकाशित करने के लिए उपयोगी हो सकता है। API PPT और PPTX प्रस्तुतियों से सीधे MD फ़ाइलों में निर्यात का समर्थन करती है और परिणामी Markdown दस्तावेज़ में स्लाइड सामग्री के प्रतिनिधित्व को नियंत्रित करने के लिए अतिरिक्त विकल्प प्रदान करती है।

आप प्रस्तुतियों को साधारण Markdown के रूप में निर्यात कर सकते हैं, CommonMark और GitHub Flavored Markdown जैसे कई Markdown फ़्लेवर में से चुन सकते हैं, और निर्यात के दौरान छवियों को कैसे संभाला जाए इसे कॉन्फ़िगर कर सकते हैं। दृश्य सामग्री वाली प्रस्तुतियों के लिए, Aspose.Slides आपको छवियों को एक अलग फ़ोल्डर में सहेजने और उत्पन्न Markdown फ़ाइल से उनका संदर्भ देने की सुविधा भी देती है।

{{% alert color="warning" %}}
PowerPoint‑to‑Markdown निर्यात डिफ़ॉल्ट रूप से **छवियों के बिना** होता है। यदि आप छवियों वाली PowerPoint दस्तावेज़ को निर्यात करना चाहते हैं, तो आपको `export_type = MarkdownExportType.VISUAL` सेट करना होगा और `base_path` निर्दिष्ट करना होगा, जहाँ Markdown दस्तावेज़ में संदर्भित छवियों को सहेजा जाएगा।
{{% /alert %}}

## **प्रस्तुतियों को Markdown में परिवर्तित करें**

नीचे दिया गया उदाहरण Aspose.Slides for Python via .NET का उपयोग करके डिफ़ॉल्ट सेटिंग्स के साथ PowerPoint प्रस्तुति को Markdown में परिवर्तित करने का सबसे सरल तरीका दर्शाता है।

1. प्रस्तुति को लोड करने के लिए एक [प्रस्तुति]({{guid}}) बनाएँ।  
1. `save` को कॉल करके इसे एक Markdown फ़ाइल के रूप में निर्यात करें।

नीचे दिया गया Python स्निपेट उपयोग करके परिवर्तन करें:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:  
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **प्रस्तुतियों को Markdown फ़्लेवर में परिवर्तित करें**

Aspose.Slides आपको प्रस्तुतियों को विभिन्न Markdown स्वरूपों में परिवर्तित करने की अनुमति देती है, जिसमें बुनियादी Markdown, CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab और 17 अन्य Markdown फ़्लेवर शामिल हैं।

निम्नलिखित Python उदाहरण दिखाता है कि PowerPoint प्रस्तुति को CommonMark में कैसे परिवर्तित किया जाए:

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, save_options)
```

23 समर्थित Markdown फ़्लेवर को [Flavor]({{guid}}) enumeration और [MarkdownSaveOptions]({{guid}}) क्लास में सूचीबद्ध किया गया है।

## **छवियों वाली प्रस्तुतियों को Markdown में परिवर्तित करें**

[MarkdownSaveOptions]({{guid}}) क्लास ऐसी प्रॉपर्टीज़ और एन्यूमरेशन्स प्रदान करती है जो उत्पन्न Markdown फ़ाइल को कॉन्फ़िगर करने की अनुमति देती हैं। उदाहरण के लिए, [MarkdownExportType]({{guid}}) enum यह नियंत्रित करता है कि छवियों को कैसे संभाला जाए: `SEQUENTIAL`, `TEXT_ONLY` या `VISUAL`।

### **छवियों को क्रमिक रूप से परिवर्तित करें**

यदि आप चाहते हैं कि छवियाँ एक-एक करके—एक के बाद एक—उत्पन्न Markdown में दिखाई दें, तो `SEQUENTIAL` विकल्प चुनें। नीचे दिया गया Python उदाहरण दर्शाता है कि छवियों वाली प्रस्तुति को Markdown में कैसे परिवर्तित किया जाए।

```python
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.show_hidden_slides = True
save_options.show_slide_number = True
save_options.flavor = slides.export.Flavor.GITHUB
save_options.export_type = slides.export.MarkdownExportType.SEQUENTIAL
save_options.new_line_type = slides.export.NewLineType.WINDOWS

slide_indices = [1, 3, 5]

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slide_indices, slides.export.SaveFormat.MD, save_options)
```

### **छवियों को दृश्य रूप में परिवर्तित करें**

यदि आप चाहते हैं कि छवियाँ परिणामस्वरूप Markdown में एक साथ दिखाई दें, तो `VISUAL` विकल्प चुनें। इस मोड में, छवियाँ एप्लिकेशन की वर्तमान निर्देशिका में सहेजी जाती हैं (और Markdown दस्तावेज़ सापेक्ष पाथ का उपयोग करता है), या आप एक कस्टम आउटपुट पाथ और फ़ोल्डर नाम निर्दिष्ट कर सकते हैं।

नीचे दिया गया Python उदाहरण इस ऑपरेशन को दर्शाता है:

```python
import os
import aspose.slides as slides

save_options = slides.export.MarkdownSaveOptions()
save_options.export_type = slides.export.MarkdownExportType.VISUAL
save_options.images_save_folder_name = "md-images"
save_options.base_path = "c:\\documents"

with slides.Presentation("presentation.pptx") as presentation:
    file_path = os.path.join(save_options.base_path, "presentation.md")
    presentation.save(file_path, slides.export.SaveFormat.MD, save_options)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक निर्यात के बाद Markdown में बनी रहती हैं?**  
हाँ। टेक्स्ट [हाइपरलिंक](/slides/hi/python-net/manage-hyperlinks/) को मानक Markdown लिंक्स के रूप में संरक्षित किया जाता है। स्लाइड [ट्रांज़िशन](/slides/hi/python-net/slide-transition/) और [ऐनिमेशन](/slides/hi/python-net/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या मैं कई थ्रेड्स में चलाकर रूपांतरण को तेज़ कर सकता हूँ?**  
आप फ़ाइलों के बीच समानांतर कर सकते हैं, लेकिन [उसी](/slides/hi/python-net/multithreading/) [प्रस्तुति]({{guid}}) इंस्टेंस को थ्रेड्स के बीच साझा न करें। कंटेंशन से बचने के लिए प्रत्येक फ़ाइल के लिए अलग‑अलग इंस्टेंस/प्रोसेस उपयोग करें।

**छवियों के साथ क्या होता है—वे कहाँ सहेजी जाती हैं, और पाथ सापेक्ष हैं क्या?**  
[छवियाँ](/slides/hi/python-net/image/) एक समर्पित फ़ोल्डर में निर्यात की जाती हैं, और Markdown फ़ाइल डिफ़ॉल्ट रूप से उन्हें सापेक्ष पाथ से संदर्भित करती है। आप बेस आउटपुट पाथ और एसेट फ़ोल्डर नाम को कॉन्फ़िगर करके पूर्वानुमेय रिपॉज़िटरी संरचना बनाए रख सकते हैं।