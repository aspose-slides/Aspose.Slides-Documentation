---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /hi/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint ऑटोमेशन Python
- Python PPT लाइब्रेरी
- Python में PowerPoint को PDF निर्यात
- Python में PowerPoint को SVG निर्यात
- Python में PowerPoint संपादित करें
- Microsoft Office के बिना Python PowerPoint
- Python के साथ PPTX प्रबंधित करें
- Python में स्लाइड पूर्वावलोकन
- Python में स्लाइड्स में ऑडियो जोड़ें
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET व्यापक सुविधाओं का सेट प्रदान करता है, जिसमें पाठ, आकार, तालिकाएँ और एनिमेशन का प्रबंधन, स्लाइड्स में ऑडियो और वीडियो जोड़ना, स्लाइड्स का पूर्वावलोकन, तथा SVG, PDF और अन्य फ़ॉर्मैट में निर्यात शामिल है।"
---
{{% alert color="info" %}}

**Aspose.Slides for Python via .NET में आपका स्वागत है**

![Aspose.Slides for Python via .NET उत्पाद लोगो](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET एक मजबूत क्लास लाइब्रेरी है जो आपके अनुप्रयोगों को Microsoft PowerPoint® की आवश्यकता के बिना PowerPoint® प्रस्तुतियों को पढ़ने और लिखने की अनुमति देती है।

यह पहला और अकेला कॉम्पोनेन्ट है जो Python डेवलपर्स के लिए पूर्ण‑विशेषताएं वाला PowerPoint® दस्तावेज़ प्रबंधन प्रदान करता है।

Aspose.Slides for Python via .NET में पाठ, आकार, तालिका और एनिमेशन के साथ काम करना; ऑडियो और वीडियो जोड़ना; स्लाइड का पूर्वावलोकन; और SVG, PDF आदि जैसे फ़ॉर्मेट में स्लाइड निर्यात करना जैसी व्यापक सुविधाएँ शामिल हैं।

{{% /alert %}}

## Aspose.Slides for Python via .NET स्थापित करें

```bash
pip install aspose.slides
```

पैकेज में आवश्यक .NET रनटाइम शामिल है, इसलिए स्थापित करने के लिए कुछ नहीं बचता और Microsoft PowerPoint की आवश्यकता नहीं है। Windows, Linux या macOS पर Python 3.7 या बाद का संस्करण।

## Python में PowerPoint प्रस्तुति बनाएँ

यह उदाहरण एक प्रस्तुति बनाता है, पहले स्लाइड में पाठ वाला एक आकार जोड़ता है, और परिणाम को PPTX और PDF दोनों रूप में सहेजता है।

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

चलाने पर यह `presentation.pptx` (लगभग 34 KB) और `presentation.pdf` (लगभग 36 KB) को कार्य निर्देशिका में लिखता है।

बिना लाइसेंस के लाइब्रेरी मूल्यांकन मोड में चलती है, जो वॉटरमार्क जोड़ती है और स्लाइडों की संख्या सीमित करती है। लागू करने के लिए देखें [लाइसेंसिंग](/slides/hi/python-net/licensing/)।

## Aspose.Slides for Python via .NET संसाधन

इन उपयोगी संसाधनों का अन्वेषण करें::

- [Aspose.Slides for Python via .NET ऑनलाइन प्रलेखन](/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET सुविधाएँ](/slides/hi/python-net/features-overview/)
- [Aspose.Slides for Python via .NET रिलीज़ नोट्स](https://releases.aspose.com/slides/hi/python-net/release-notes/)
- [Aspose.Slides for Python via .NET उत्पाद पृष्ठ](https://products.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET डाउनलोड करें](https://releases.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET PyPi पैकेज स्थापित करें](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API संदर्भ गाइड](https://reference.aspose.com/slides/hi/python-net/)
- [Aspose.Slides for Python via .NET मुफ्त समर्थन फ़ोरम](https://forum.aspose.com/c/slides/hi/11)
- [Aspose.Slides for Python via .NET सशुल्क समर्थन हेल्पडेस्क](https://helpdesk.aspose.com/)

## अक्सर पूछे जाने वाले प्रश्न

### Aspose.Slides for Python via .NET क्या है?

Aspose.Slides for Python via .NET एक शक्तिशाली Python लाइब्रेरी है जो Microsoft PowerPoint स्थापित किए बिना प्रोग्रामेटिक रूप से PowerPoint प्रस्तुतियों (PPT, PPTX, ODP) बनाने, संपादित करने और रूपांतरित करने की अनुमति देती है।

### Aspose.Slides कौन-सी प्रस्तुति सुविधाएँ समर्थन करता है?

यह लाइब्रेरी पाठ, आकार, तालिका, चार्ट, एनिमेशन, मास्टर स्लाइड, ऑडियो, वीडियो आदि का प्रबंधन समर्थन करती है। यह स्लाइड पूर्वावलोकन, रेंडरिंग, और PDF, SVG, HTML, तथा छवियों जैसे फ़ॉर्मेट में निर्यात को भी सक्षम बनाती है।

### क्या मैं Aspose.Slides का उपयोग करके प्रस्तुतियों को अन्य फ़ॉर्मेट में रूपांतरित कर सकता हूँ?

हाँ। Aspose.Slides PowerPoint फ़ाइलों को उच्च सटीकता और प्रदर्शन के साथ PDF, SVG, HTML, JPG, PNG, TIFF और अन्य फ़ॉर्मेट में रूपांतरित करने की सुविधा देता है।

### क्या Aspose.Slides के उपयोग के लिए Microsoft PowerPoint आवश्यक है?

नहीं। Aspose.Slides एक स्वतंत्र API है और इसे Microsoft Office या किसी तृतीय‑पक्ष सॉफ़्टवेयर की आवश्यकता नहीं होती।

### Aspose.Slides for Python via .NET किन प्लेटफ़ॉर्मों को समर्थन देता है?

यह क्रॉस‑प्लेटफ़ॉर्म है और Windows, Linux, तथा macOS परिवेशों पर काम करता है।

### मैं Aspose.Slides for Python के साथ कैसे शुरू करूँ?

आप इसे PyPi के माध्यम से स्थापित कर सकते हैं और शुरू करने के लिए [डिवेलपर गाइड](/slides/hi/python-net/developer-guide/) का अन्वेषण कर सकते हैं, जिसमें उदाहरण, API संदर्भ और ट्यूटोरियल शामिल हैं।