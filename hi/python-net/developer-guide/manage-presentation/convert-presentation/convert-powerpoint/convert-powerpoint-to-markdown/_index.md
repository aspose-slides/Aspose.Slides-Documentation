---
title: Python में PowerPoint प्रस्तुतियों को Markdown में परिवर्तित करें
linktitle: PowerPoint से Markdown
type: docs
weight: 140
url: /hi/python-net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint रूपांतरित करें
- प्रेजेंटेशन रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से MD
- प्रेजेंटेशन से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को Markdown के रूप में सहेजें
- प्रेजेंटेशन को Markdown के रूप में सहेजें
- स्लाइड को Markdown के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- Markdown छवि निर्यात
- CDN छवि लिंक
- PowerPoint
- प्रेजेंटेशन
- Markdown
- Python
- Python via .NET
- Aspose.Slides
description: "Python में PPT और PPTX प्रस्तुतियों को Markdown में परिवर्तित करें और निर्यातित छवियों को कहाँ सहेजा जाए तथा उत्पन्न Markdown उन छवियों को कैसे संदर्भित करता है, इसे नियंत्रित करें।"
---
## **अवलोकन**

Aspose.Slides for Python via .NET PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थैतिक‑साइट, सामग्री‑स्थलांतरण, और संस्करण‑नियंत्रण कार्य‑प्रवाहों के लिए Markdown में बदल सकता है। आप एक Markdown फ़्लेवर चुन सकते हैं, स्लाइड सामग्री कैसे प्रस्तुत की जाती है इसे नियंत्रित कर सकते हैं, और तय कर सकते हैं कि निर्यातित छवियाँ कहाँ सहेजी जाएँ और उत्पन्न Markdown उन्हें कैसे संदर्भित करता है।

डिफ़ॉल्ट रूप से, Markdown निर्यात केवल‑पाठ आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, [MarkdownSaveOptions.export_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/export_type/) प्रॉपर्टी को [MarkdownExportType](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownexporttype/) एन्न्यूमरेशन के `SEQUENTIAL` या `VISUAL` मान पर सेट करें। `SEQUENTIAL` स्लाइड आइटमों को अलग‑अलग और क्रम में रेंडर करता है, जबकि `VISUAL` समूहित आइटमों को साथ रखता है ताकि उनका दृश्य संबंध बनाए रखा जा सके। `TEXT_ONLY` मान छवि संसाधनों को उत्पन्न नहीं करता।

## **प्रेजेंटेशन को Markdown में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ipresentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) एन्न्यूमरेशन के `MD` मान के साथ कॉल करें।

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD)
```

## **Markdown फ़्लेवर चुनें**

[MarkdownSaveOptions.flavor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/flavor/) प्रॉपर्टी आउटपुट के लिए उपयोग की जाने वाली Markdown विशिष्टता को नियंत्रित करती है। [Flavor](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/flavor/) एन्न्यूमरेशन में CommonMark, GitHub Flavored Markdown, और अन्य समर्थित वैरिएंट शामिल हैं।

निम्न उदाहरण एक प्रस्तुतिकरण को CommonMark के रूप में निर्यात करता है:

```python
import aspose.slides as slides

options = slides.export.MarkdownSaveOptions()
options.flavor = slides.export.Flavor.COMMON_MARK

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.md", slides.export.SaveFormat.MD, options)
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने वाले व्यवहार का उपयोग करके चित्र निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों के लिए दो प्रॉपर्टी प्रदान करती है:

- [base_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) Markdown दस्तावेज़ और उसकी संसाधनों के लिए आधार निर्देशिका निर्दिष्ट करता है।
- [images_save_folder_name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) छवि उपनिर्देशिका को निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्न उदाहरण दृश्य सामग्री रेंडर करता है, छवियों को `output/assets` में लिखता है, और Markdown दस्तावेज़ में सापेक्ष छवि संदर्भ बनाता है:

```python
import os
import aspose.slides as slides

output_directory = "output"
os.makedirs(output_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = output_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(output_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

Aspose.Slides निर्यात के दौरान छवि संसाधन उत्पन्न होने पर छवि उपनिर्देशिका बनाता है, लेकिन एप्लिकेशन को Markdown फ़ाइल सहेजने से पहले `base_path` बनाना आवश्यक है।

## **प्रकाशन के लिए Markdown और छवियाँ तैयार करें**

Aspose.Slides for Python via .NET निर्यात के दौरान प्रत्येक उत्पन्न छवि लिंक को बदलने के लिए .NET इमेज‑सहेजने वाले कॉलबैक को उजागर नहीं करता। इसके बजाय, Markdown दस्तावेज़ और उसकी छवि फ़ोल्डर को प्रकाशित करने वाले निर्देशिका में निर्यात करें, और फिर उस निर्देशिका को उसकी सापेक्ष संरचना बदले बिना प्रकाशित करें।

निम्न उदाहरण `cdn-origin/presentations/quarterly-report` को माउंटेड या सिंक्रनाइज़्ड प्रकाशन निर्देशिका के रूप में तैयार करता है। नमूना स्वयं कोई नेटवर्क अपलोड नहीं करता: निर्देशिका को इच्छित साइट या CDN स्थान पर प्रकाशित करने के बाद उत्पन्न लिंक वैध हो जाते हैं।

```python
import os
import aspose.slides as slides

publication_directory = os.path.join(
    "cdn-origin",
    "presentations",
    "quarterly-report")
os.makedirs(publication_directory, exist_ok=True)

options = slides.export.MarkdownSaveOptions()
options.export_type = slides.export.MarkdownExportType.VISUAL
options.base_path = publication_directory
options.images_save_folder_name = "assets"

markdown_path = os.path.join(publication_directory, "presentation.md")

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save(markdown_path, slides.export.SaveFormat.MD, options)
```

`presentation.md` को `assets` निर्देशिका के साथ प्रकाशित करें। Markdown दस्तावेज़ सापेक्ष छवि संदर्भों का उपयोग करता है, इसलिए दोनों आइटमों को गंतव्य पर समान संबंध रखना चाहिए। यदि कोई प्रकाशन प्रणाली पूर्ण बाहरी URL की आवश्यकता रखती है, तो सभी छवि फ़ाइलों के प्रकाशित होने के बाद उत्पन्न लिंक को एक अलग पोस्ट‑प्रोसेसिंग चरण के रूप में पुनः लिखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Python कॉलबैक Markdown निर्यात के दौरान व्यक्तिगत छवि फ़ाइलों और लिंक को अनुकूलित कर सकते हैं?**

नहीं। Aspose.Slides for Python via .NET .NET के `ImageSaving` और `SvgImageSaving` कॉलबैक को उजागर नहीं करता। स्थानीय आउटपुट को [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) और [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) के साथ कॉन्फ़िगर करें, फिर उत्पन्न संसाधनों को प्रकाशित या पोस्ट‑प्रोसेस करें।

**निर्यातित छवियाँ कहाँ सहेजी जाती हैं?**

छवि स्थान को [MarkdownSaveOptions.base_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/base_path/) और [MarkdownSaveOptions.images_save_folder_name](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/markdownsaveoptions/images_save_folder_name/) द्वारा नियंत्रित किया जाता है। Markdown दस्तावेज़ उन छवियों को सापेक्ष पाथ्स के साथ संदर्भित करता है।

**छवि लिंक किन पथ विभाजकों का उपयोग करना चाहिए?**

Markdown लिंक और URL में फॉरवर्ड स्लैश (`/`) का उपयोग करें। फ़ाइल‑सिस्टम पाथ के लिए केवल `os.path.join` उपयोग करें, और पोस्ट‑प्रोसेसिंग के दौरान निर्मित किसी भी लिंक को अलग से सामान्यीकृत करें।

**क्या Markdown निर्यात के दौरान हाइपरलिंक संरक्षित रहते हैं?**

हाँ। टेक्स्ट [hyperlinks](/slides/hi/python-net/manage-hyperlinks/) को मानक Markdown लिंक के रूप में संरक्षित किया जाता है। स्लाइड [transitions](/slides/hi/python-net/slide-transition/) और [animations](/slides/hi/python-net/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रस्तुतियों को समानांतर रूप से Markdown में परिवर्तित किया जा सकता है?**

आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन थ्रेड्स के बीच एक ही [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस साझा न करें। [multithreading guidelines](/slides/hi/python-net/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए अलग इंस्टेंस उपयोग करें।