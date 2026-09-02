---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /hi/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python के लिए PowerPoint स्वचालन
- Python PPT लाइब्रेरी
- Python के साथ PowerPoint को PDF में निर्यात करें
- Python के साथ PowerPoint को SVG में निर्यात करें
- Python में PowerPoint संपादित करें
- Microsoft Office के बिना Python PowerPoint
- Python के साथ PPTX प्रबंधित करें
- Python में स्लाइड पूर्वावलोकन
- Python से स्लाइड में ऑडियो जोड़ें
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET एक व्यापक फीचर सेट प्रदान करता है, जिसमें टेक्स्ट, शैलियां, तालिकाओं और एनीमेशन का प्रबंधन, स्लाइड में ऑडियो और वीडियो जोड़ना, स्लाइड का पूर्वावलोकन, तथा SVG, PDF और अन्य फ़ॉर्मैट में निर्यात शामिल है।"
---
{{% alert color="primary" %}}

**Aspose.Slides for Python via .NET में आपका स्वागत है**

![Aspose.Slides for Python via .NET उत्पाद लोगो](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET एक मजबूत क्लास लाइब्रेरी है जो आपके अनुप्रयोगों को Microsoft PowerPoint® की आवश्यकता के बिना PowerPoint® प्रस्तुतियों को पढ़ने और लिखने की सुविधा देती है।

यह पहला और एकमात्र घटक है जो Python डेवलपर्स के लिए पूर्ण‑फ़ीचर PowerPoint® दस्तावेज़ प्रबंधन प्रदान करता है।

Aspose.Slides for Python via .NET में टेक्स्ट, शैलियों, तालिकाओं और एनीमेशन के साथ काम करना; ऑडियो और वीडियो जोड़ना; स्लाइड का पूर्वावलोकन; और SVG, PDF आदि जैसे फॉर्मेट में स्लाइड निर्यात करना जैसे कई फीचर उपलब्ध हैं।

{{% /alert %}}

## Install Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

यह पैकेज आवश्यक .NET रनटाइम को शामिल करता है, इसलिए स्थापित करने के लिए कुछ और नहीं है और Microsoft PowerPoint की आवश्यकता नहीं है। Windows, Linux या macOS पर Python 3.7 या बाद का संस्करण समर्थित है।

## Create a PowerPoint Presentation in Python

यह उदाहरण एक प्रस्तुति बनाता है, पहले स्लाइड में टेक्स्ट के साथ एक आकार जोड़ता है, और परिणाम को PPTX और PDF दोनों के रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

इसे चलाने पर `presentation.pptx` (लगभग 34 KB) और `presentation.pdf` (लगभग 36 KB) कार्य निर्देशिका में लिखे जाते हैं।

लाइसेंस के बिना लाइब्रेरी मूल्यांकन मोड में चलती है, जिसमें वॉटरमार्क जोड़ता है और स्लाइड की संख्या सीमित करता है। लागू करने के लिए [Licensing](/slides/hi/python-net/licensing/) देखें।

## Aspose.Slides for Python via .NET Resources

इन उपयोगी संसाधनों का अन्वेषण करें:

- [Aspose.Slides for Python via .NET ऑनलाइन दस्तावेज़ीकरण](/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET सुविधाएँ](/slides/hi/python-net/features-overview/)
- [Aspose.Slides for Python via .NET रिलीज़ नोट्स](https://releases.aspose.com/slides/hi/python-net/release-notes/)
- [Aspose.Slides for Python via .NET उत्पाद पृष्ठ](https://products.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET डाउनलोड करें](https://releases.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET PyPi पैकेज स्थापित करें](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API रेफरेंस गाइड](https://reference.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET फ्री सपोर्ट फोरम](https://forum.aspose.com/c/slides/hi/11)
- [Aspose.Slides for Python via .NET पेड सपोर्ट हेल्पडेस्क](https://helpdesk.aspose.com/)

## FAQ

### Aspose.Slides for Python via .NET क्या है?

Aspose.Slides for Python via .NET एक शक्तिशाली Python लाइब्रेरी है जो Microsoft PowerPoint स्थापित किए बिना प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों (PPT, PPTX, ODP) को बनाना, संपादित करना और रूपांतरित करना संभव बनाती है।

### Aspose.Slides कौन-कौन से प्रस्तुति फीचर सपोर्ट करता है?

यह लाइब्रेरी टेक्स्ट, शैलियां, तालिकाएं, चार्ट, एनीमेशन, मास्टर स्लाइड, ऑडियो, वीडियो आदि का प्रबंधन समर्थन करती है। यह स्लाइड पूर्वावलोकन, रेंडरिंग, प्रिंटिंग और PDF, SVG, HTML, और इमेज जैसी फॉर्मैट में निर्यात भी प्रदान करती है।

### क्या मैं Aspose.Slides का उपयोग करके प्रस्तुतियों को अन्य फॉर्मैट में बदल सकता हूँ?

हाँ। Aspose.Slides PowerPoint फ़ाइलों को PDF, SVG, HTML, JPG, PNG, TIFF और अन्य फॉर्मैट में उच्च सटीकता और प्रदर्शन के साथ रूपांतरित करने की सुविधा देता है।

### Aspose.Slides उपयोग करने के लिए Microsoft PowerPoint आवश्यक है क्या?

नहीं। Aspose.Slides एक स्वतंत्र API है और इसे Microsoft Office या किसी तृतीय‑पक्ष सॉफ़्टवेयर की आवश्यकता नहीं होती।

### Aspose.Slides for Python via .NET कौन‑से प्लेटफ़ॉर्म को सपोर्ट करता है?

यह क्रास‑प्लेटफ़ॉर्म है और Windows, Linux और macOS वातावरण में काम करता है।

### मैं Aspose.Slides for Python के साथ कैसे प्रारंभ करूँ?

आप इसे PyPi से स्थापित कर सकते हैं और शुरुआत करने के लिए [Developer Guide](/slides/hi/python-net/developer-guide/) देखें, जिसमें उदाहरण, API रेफ़रेंस और ट्यूटोरियल शामिल हैं।