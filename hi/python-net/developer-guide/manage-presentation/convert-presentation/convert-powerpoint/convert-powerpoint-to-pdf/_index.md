---
title: Python में PPT और PPTX को PDF में बदलें | उन्नत विकल्प
linktitle: PowerPoint को PDF में बदलें
type: docs
weight: 40
url: /hi/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - PowerPoint बदलें
  - प्रस्तुति
  - PowerPoint को PDF में बदलें
  - PPT को PDF में बदलें
  - PPTX को PDF में बदलें
  - PowerPoint को PDF के रूप में सहेजें
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - Aspose.Slides for Python
description: "Python में Aspose.Slides के साथ PPT, PPTX और ODP को उच्च‑गुणवत्ता, WCAG‑अनुपालन PDF में बदलने का चरण‑दर‑चरण मार्गदर्शक — पासवर्ड संरक्षण, स्लाइड चयन, और छवि‑गुणवत्ता नियंत्रण सहित।"
showReadingTime: true
---
## **अवलोकन**

Python में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP) को PDF स्वरूप में बदलने के कई लाभ हैं, जैसे विभिन्न उपकरणों पर संगतता सुनिश्चित करना और आपकी प्रस्तुति की लेआउट तथा फ़ॉर्मेट को संरक्षित रखना। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता को नियंत्रित करने के लिये विभिन्न विकल्पों का उपयोग करें, छुपी हुई स्लाइड्स शामिल करें, PDF दस्तावेज़ों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, रूपांतरण के लिये विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप इन स्वरूपों की प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

Python में प्रस्तुति को PDF में बदलने के लिये, आपको केवल फ़ाइल नाम को [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास में एक तर्क के रूप में पास करना है और फिर प्रस्तुति को [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड का उपयोग करके PDF के रूप में सहेजना है। [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास वह [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड उजागर करती है जो आमतौर पर प्रस्तुति को PDF में बदलने के लिये उपयोग की जाती है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python आउटपुट दस्तावेज़ों में सीधे API जानकारी और संस्करण संख्या लिखती है। उदाहरण के लिये, जब यह प्रस्तुति को PDF में बदलती है, तो Aspose.Slides for Python *Application* फ़ील्ड को '*Aspose.Slides*' मान से और *PDF Producer* फ़ील्ड को '*Aspose.Slides v XX.XX*' रूप में भरती है। **ध्यान दें** कि आप Aspose.Slides for Python को इस जानकारी को बदलने या हटाने के लिये निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित को बदलने की सुविधा देती है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति की विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करती है, जिससे उत्पन्न PDF की सामग्री मूल प्रस्तुति के निकट मेल करती है। रूपांतरण के दौरान तत्वों और गुणों को सटीक रूप से रेंडर किया जाता है, जिसमें शामिल हैं:

* छवियाँ
* पाठ बॉक्स और आकार
* पाठ फ़ॉर्मेटिंग
* अनुच्छेद फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट्स
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट विकल्पों के साथ मानक PowerPoint PDF रूपांतरण ऑपरेशन निष्पादित किया जाता है। इस स्थिति में, Aspose.Slides अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में बदलने का प्रयास करती है। यह Python कोड दिखाता है कि PowerPoint को PDF में कैसे बदलें:

_चरण: Python में PowerPoint से PDF रूपांतरण_

निम्नलिखित नमूना कोड Python के माध्यम से .NET में इन रूपांतरणों को समझाता है
- <a name="python-net-powerpoint-to-pdf"><strong>चरण: Python के माध्यम से .NET में PowerPoint को PDF में बदलें</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPT को PDF में बदलें</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPTX को PDF में बदलें</a></strong>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET में ODP को PDF में बदलें</a></strong>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPS को PDF में बदलें</a></strong>

_कोड चरण:_

- [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं और उसे PowerPoint फ़ाइल प्रदान करें।
  * _.ppt_ एक्सटेंशन का उपयोग करके **PPT** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.pptx_ एक्सटेंशन का उपयोग करके **PPTX** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.odp_ एक्सटेंशन का उपयोग करके **ODP** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.pps_ एक्सटेंशन का उपयोग करके **PPS** फ़ाइल को _Presentation_ क्लास में लोड करें।
- _Presentation_ को **PDF** स्वरूप में सहेजें, **Save** मेथड को कॉल करके और **SaveFormat.PDF** एनेुमरेशन का उपयोग करके।

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = slides.Presentation("PowerPoint.ppt")

# प्रस्तुति को PDF के रूप में सुरक्षित करता है
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति को PDF में बदलने की प्रक्रिया को दर्शाता है। यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देखने के लिये आप कन्वर्टर के साथ परीक्षण कर सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास के तहत गुण—प्रदान करती है, जिससे आप PDF (रूपांतरण प्रक्रिया के परिणाम) को अनुकूलित कर सकते हैं, PDF को पासवर्ड से सुरक्षित कर सकते हैं, या रूपांतरण प्रक्रिया के संचालन को निर्दिष्ट कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर छवियों के लिये वांछित गुणवत्ता सेटिंग, मेटाफाइल कैसे संभाली जाए, टेक्स्ट का संपीड़न स्तर, छवियों के लिये DPI आदि निर्धारित कर सकते हैं।

निम्नलिखित कोड उदाहरण दर्शाता है कि कैसे एक PowerPoint प्रस्तुति को कई कस्टम विकल्पों के साथ PDF में बदला जाता है:

```python
import aspose.slides as slides

# PdfOptions क्लास का उदाहरण बनाता है
pdf_options = slides.export.PdfOptions()

# JPG छवियों की गुणवत्ता सेट करता है
pdf_options.jpeg_quality = 90

# छवियों के लिये DPI सेट करता है
pdf_options.sufficient_resolution = 300

# मेटाफाइल्स के व्यवहार को सेट करता है
pdf_options.save_metafiles_as_png = True

# पाठ सामग्री के लिये टेक्स्ट संपीड़न स्तर सेट करता है
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF अनुपालन मोड को परिभाषित करता है
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Presentation क्लास का उदाहरण बनाता है जो PowerPoint दस्तावेज़ का प्रतिनिधित्व करता है
with slides.Presentation("PowerPoint.pptx") as presentation:
    # प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजता है
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **छुपी हुई स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छुपी हुई स्लाइड्स हैं, तो आप एक कस्टम विकल्प—`show_hidden_slides` प्रॉपर्टी जो [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास में है—का उपयोग करके Aspose.Slides को निर्देश दे सकते हैं कि छुपी हुई स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल किया जाए।

यह Python कोड दिखाता है कि छुपी हुई स्लाइड्स सहित PowerPoint प्रस्तुति को PDF में कैसे बदला जाए:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions क्लास का उदाहरण बनाता है
pdfOptions = slides.export.PdfOptions()

# छुपी हुई स्लाइड्स जोड़ता है
pdfOptions.show_hidden_slides = True

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

यह Python कोड दिखाता है कि [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint को पासवर्ड‑सुरक्षित PDF में कैसे बदला जाए:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट का उदाहरण बनाता है
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions क्लास का उदाहरण बनाता है
pdfOptions = slides.export.PdfOptions()

# PDF पासवर्ड और एक्सेस अनुमतियों को सेट करता है
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint में चयनित स्लाइड्स को PDF में बदलें**

यह Python कोड दिखाता है कि PowerPoint प्रस्तुति की विशिष्ट स्लाइड्स को PDF में कैसे बदला जाए:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट का उदाहरण बनाता है
presentation = slides.Presentation("PowerPoint.pptx")

# स्लाइड स्थितियों की एक एरे सेट करता है
slides_array = [ 1, 3 ]

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह Python कोड दिखाता है कि जब स्लाइड आकार निर्दिष्ट हो, तो PowerPoint को PDF में कैसे बदला जाए:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है।
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाता है।
    with slides.Presentation() as resized_presentation:

        # कस्टम स्लाइड आकार सेट करता है।
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # मूल प्रस्तुति से पहली स्लाइड को क्लोन करता है।
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # रिसाइज़्ड प्रस्तुति को नोट्स सहित PDF में सहेजता है।
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह Python कोड दिखाता है कि PowerPoint को PDF नोट्स में कैसे बदला जाए:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# प्रस्तुति को PDF नोट्स में सहेजता है
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF के लिये अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देती है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिये इन अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह Python कोड कई विभिन्न अनुपालन मानकों के आधार पर कई PDF उत्पन्न करने वाले PowerPoint से PDF रूपांतरण ऑपरेशन को प्रदर्शित करता है:

```python
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

options = slides.export.PdfOptions()

options.compliance = slides.export.PdfCompliance.PDF_A1A
pres.save("pres-a1a-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_A1B
pres.save("pres-a1b-compliance.pdf", slides.export.SaveFormat.PDF, options)

options.compliance = slides.export.PdfCompliance.PDF_UA
pres.save("pres-ua-compliance.pdf", slides.export.SaveFormat.PDF, options)
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides PDF रूपांतरण ऑपरेशन्स के समर्थन को इस प्रकार विस्तारित करती है कि आप PDF को सबसे लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष स्वरूपों में PDF रूपांतरण ऑपरेशन्स—[PDF to SVG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **ध्यान दें:** जब PDF/UA को निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और सूत्रों को एक ही आकृति के रूप में मानती है। व्यक्तिगत पाथ तत्व अलग‑अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें कलाकृतियों के रूप में चिन्हित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिये प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides for Python PDF से एप्लिकेशन जानकारी हटा सकता है?**

नहीं, Aspose.Slides for Python स्वचालित रूप से आउटपुट PDF में API जानकारी और संस्करण संख्या शामिल करती है। इस जानकारी को संशोधित या हटाया नहीं जा सकता।

**मैं केवल विशिष्ट स्लाइड्स को PDF रूपांतरण में कैसे शामिल करूँ?**

आप `save` मेथड को एक स्लाइड पोज़ीशन एरे पास करके वह स्लाइड इंडेक्स निर्दिष्ट कर सकते हैं जिन्हें आप बदलना चाहते हैं।

**क्या रूपांतरण के दौरान PDF को पासवर्ड‑सुरक्षित बनाना संभव है?**

हाँ, आप PDF को सहेजने से पहले `PdfOptions` क्लास का उपयोग करके पासवर्ड सेट कर सकते हैं और एक्सेस अनुमतियों को परिभाषित कर सकते हैं।

**क्या Aspose.Slides PDF को अन्य स्वरूपों में बदलने का समर्थन करती है?**

हाँ, Aspose.Slides PDF को HTML, इमेज स्वरूप (JPG, PNG), SVG, TIFF, और XML जैसे स्वरूपों में बदलने का समर्थन करती है।

**मैं कैसे सुनिश्चित करूँ कि मेरा PDF अभिगम्यता मानकों के अनुरूप हो?**

`PdfOptions` में `compliance` प्रॉपर्टी को `PDF_A1A`, `PDF_A1B`, या `PDF_UA` जैसे मान सेट करें ताकि अभिगम्यता दिशानिर्देशों के अनुरूपता सुनिश्चित हो सके।

**क्या मैं छुपी हुई स्लाइड्स को PDF आउटपुट में शामिल कर सकता हूँ?**

हाँ, `PdfOptions` में `show_hidden_slides` प्रॉपर्टी को `True` सेट करने पर छुपी हुई स्लाइड्स PDF में शामिल हो जाएँगी।

**रूपांतरण के दौरान मैं छवि गुणवत्ता और रिज़ॉल्यूशन को कैसे समायोजित करूँ?**

रूपांतरण के परिणामस्वरूप PDF में छवि गुणवत्ता और रिज़ॉल्यूशन को नियंत्रित करने के लिये `jpeg_quality` और `sufficient_resolution` प्रॉपर्टी `PdfOptions` में उपयोग करें।

**क्या Aspose.Slides फ़ॉन्ट प्रतिस्थापन को स्वचालित रूप से संभालती है?**

Aspose.Slides रूपांतरण के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाती है, और आप इसे `SaveOptions` में `warning_callback` प्रॉपर्टी (वर्तमान में सीमित) के माध्यम से संभाल सकते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/hi/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/hi/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)