---
title: "Python में PPT & PPTX को PDF में बदलें | उन्नत विकल्प"
linktitle: "PowerPoint को PDF में"
type: docs
weight: 40
url: /hi/python-net/convert-powerpoint-to-pdf/
aliases:
  - /python-net/convert-to-pdf/
keywords:
  - "PowerPoint बदलें"
  - "प्रस्तुति"
  - "PowerPoint को PDF में"
  - "PPT को PDF में"
  - "PPTX को PDF में"
  - "PowerPoint को PDF के रूप में सहेजें"
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - Python
  - "Aspose.Slides for Python"
description: "Python में Aspose.Slides के साथ PPT, PPTX और ODP को उच्च‑गुणवत्ता, WCAG‑अनुपालित PDFs में बदलने के लिए चरण‑दर‑चरण गाइड— इसमें पासवर्ड सुरक्षा, स्लाइड चयन, और इमेज‑गुणवत्ता नियंत्रण शामिल है।"
showReadingTime: true
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP) को Python में PDF प्रारूप में बदलने से कई लाभ मिलते हैं, जिसमें विभिन्न डिवाइसों पर संगतता सुनिश्चित करना और आपकी प्रस्तुति के लेआउट व फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह गाइड दर्शाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, इमेज क्वालिटी को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF दस्तावेज़ों को पासवर्ड से सुरक्षित रखें, फ़ॉन्ट सब्स्टिट्यूशन का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **स्थापना**

```bash
pip install aspose.slides
```

यह पैकेज आवश्यक रनटाइम को बंडल करता है, इसलिए Microsoft PowerPoint को उस मशीन पर इंस्टॉल करने की आवश्यकता नहीं है जहाँ रूपांतरण किया जा रहा है।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप इन फ़ॉर्मेट्स में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

Python में एक प्रस्तुति को PDF में बदलने के लिए, आपको केवल फ़ाइल नाम को [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास में तर्क के रूप में पास करना है और फिर [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजना है। [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास वह [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड प्रस्तुत करता है जो सामान्यतः प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python सीधे आउटपुट दस्तावेज़ों में API जानकारी और संस्करण संख्या लिखता है। उदाहरण के लिए, जब यह एक प्रस्तुति को PDF में बदलता है, तो Aspose.Slides for Python ‘Application’ फ़ील्ड को '*Aspose.Slides*' मान से और PDF Producer फ़ील्ड को '*Aspose.Slides v XX.XX*' रूप में भरता है। **ध्यान देें** कि आप Aspose.Slides for Python को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूप में बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति की विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में एक्सपोर्ट करता है, जिससे उत्पन्न PDFs की सामग्री मूल प्रस्तुतियों के बहुत करीब रहती है। रूपांतरण में तत्व और एट्रिब्यूट सटीक रूप से रेंडर होते हैं, जिनमें शामिल हैं:

* इमेजेज
* टेक्स्ट बॉक्स और शेप्स
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक्स
* हेडर और फ़ूटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में बदलें**

मानक PowerPoint PDF रूपांतरण ऑपरेशन डिफ़ॉल्ट विकल्पों का उपयोग करके चलाया जाता है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स के साथ PDF में बदलने का प्रयास करता है। यह Python कोड दिखाता है कि PowerPoint को PDF में कैसे बदलें:

_चरण: Python में PowerPoint से PDF रूपांतरण_

निम्नलिखित नमूना कोड .NET के माध्यम से Python का उपयोग करके इन रूपांतरणों को समझाता है
- <a name="python-net-powerpoint-to-pdf"><strong>चरण: Python के माध्यम से .NET में PowerPoint को PDF में बदलें</strong></a>
- <a name="python-net-ppt-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPT को PDF में बदलें</strong></a>
- <a name="python-net-pptx-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPTX को PDF में बदलें</strong></a>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET में ODP को PDF में बदलें</strong></a>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET में PPS को PDF में बदलें</strong></a>

_कोड चरण:_

- Create instance of [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) class and provide it the PowerPoint file.
  * _.ppt_ एक्सटेंशन का उपयोग करके **PPT** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.pptx_ एक्सटेंशन का उपयोग करके **PPTX** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.odp_ एक्सटेंशन का उपयोग करके **ODP** फ़ाइल को _Presentation_ क्लास में लोड करें।
  * _.pps_ एक्सटेंशन का उपयोग करके **PPS** फ़ाइल को _Presentation_ क्लास में लोड करें।
- Save the _Presentation_ to **PDF** format by calling **Save** method and using **SaveFormat.PDF** enumeration.

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
presentation = slides.Presentation("PowerPoint.ppt")

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF परिवर्तक**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति से PDF रूपांतरण प्रक्रिया को दर्शाता है। यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन करने के लिए, आप परिवर्तक के साथ एक परीक्षण कर सकते हैं।

{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है, जिससे आप PDF (रूपांतरण प्रक्रिया के परिणाम) को कस्टमाइज़ कर सकते हैं, PDF को पासवर्ड से सुरक्षित कर सकते हैं, या रूपांतरण प्रक्रिया के व्यवहार को निर्धारित कर सकते हैं।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर इमेजेज के लिए अपनी पसंदीदा क्वालिटी सेटिंग सेट कर सकते हैं, मेटा‑फ़ाइल्स को कैसे हैंडल किया जाए निर्दिष्ट कर सकते हैं, टेक्स्ट के लिए कम्प्रेशन लेवल सेट कर सकते हैं, इमेजेज के DPI को सेट कर सकते हैं, आदि।

निम्न कोड उदाहरण दिखाता है कि एक PowerPoint प्रस्तुति को कई कस्टम विकल्पों के साथ PDF में कैसे बदला जाता है:

```python
import aspose.slides as slides

# PdfOptions क्लास को इंस्टैंसिएट करता है
pdf_options = slides.export.PdfOptions()

# JPG इमेजेज की क्वालिटी सेट करता है
pdf_options.jpeg_quality = 90

# इमेजेज के लिए DPI सेट करता है
pdf_options.sufficient_resolution = 300

# मेटा‑फ़ाइल्स के व्यवहार को सेट करता है
pdf_options.save_metafiles_as_png = True

# पाठ्य सामग्री के लिए टेक्स्ट कम्प्रेशन लेवल सेट करता है
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF अनुपालन मोड को परिभाषित करता है
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# PowerPoint दस्तावेज़ का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
with slides.Presentation("PowerPoint.pptx") as presentation:
    # प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजता है
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint को PDF में छिपी स्लाइड्स के साथ बदलें**

यदि किसी प्रस्तुति में छिपी स्लाइड्स हैं, तो आप एक कस्टम विकल्प—`show_hidden_slides` प्रॉपर्टी [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास से—का उपयोग करके Aspose.Slides को परिणामस्वरूप PDF में छिपी स्लाइड्स को पेज के रूप में शामिल करने का निर्देश दे सकते हैं।

यह Python कोड दिखाता है कि छिपी स्लाइड्स शामिल करके PowerPoint प्रस्तुति को PDF में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions क्लास को इंस्टैंसिएट करता है
pdfOptions = slides.export.PdfOptions()

# छिपी स्लाइड्स जोड़ता है
pdfOptions.show_hidden_slides = True

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint को पासवर्ड‑प्रोटेक्टेड PDF में बदलें**

यह Python कोड दिखाता है कि [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास की प्रोटेक्शन पैरामीटर्स का उपयोग करके PowerPoint को पासवर्ड‑प्रोटेक्टेड PDF में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions क्लास को इंस्टैंसिएट करता है
pdfOptions = slides.export.PdfOptions()

# PDF पासवर्ड और एक्सेस अनुमतियों को सेट करता है
pdfOptions.password = "password"
pdfOptions.access_permissions = slides.export.PdfAccessPermissions.PRINT_DOCUMENT | slides.export.PdfAccessPermissions.HIGH_QUALITY_PRINT

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPTX-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PowerPoint में चयनित स्लाइड्स को PDF में बदलें**

यह Python कोड दिखाता है कि PowerPoint प्रस्तुति में विशिष्ट स्लाइड्स को PDF में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation ऑब्जेक्ट को इंस्टैंसिएट करता है
presentation = slides.Presentation("PowerPoint.pptx")

# स्लाइड पोजीशन की एक एरे सेट करता है
slides_array = [ 1, 3 ]

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह Python कोड दिखाता है कि जब स्लाइड आकार निर्दिष्ट हो तो PowerPoint को PDF में कैसे बदलें:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाएं।
    with slides.Presentation() as resized_presentation:

        # कस्टम स्लाइड आकार सेट करें।
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # मूल प्रस्तुति से पहली स्लाइड को क्लोन करें और डिफ़ॉल्ट खाली स्लाइड को हटाएं।
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)
        resized_presentation.slides.remove_at(1)

        # रिसाइज़्ड प्रस्तुति को PDF में सहेजें।
        resized_presentation.save("PDF_with_custom_slide_size.pdf", slides.export.SaveFormat.PDF)
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह Python कोड दिखाता है कि PowerPoint को PDF नोट्स में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
presentation = slides.Presentation("NotesFile.pptx")

# नोट लेआउट के साथ PDF विकल्प कॉन्फ़िगर करता है
pdfOptions = slides.export.PdfOptions()
pdfOptions.slides_layout_options = slides.export.NotesCommentsLayoutingOptions()
pdfOptions.slides_layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# प्रस्तुति को नोट्स के साथ PDF में सहेजता है
presentation.save("Pdf_Notes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक ऐसी रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसिबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप PowerPoint दस्तावेज़ को PDF में निर्यात करने के लिए इन अनुपालन मानकों में से कोई भी उपयोग कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह Python कोड कई अनुपालन मानकों के आधार पर विभिन्न PDFs प्राप्त करने वाली PowerPoint से PDF रूपांतरण ऑपरेशन को प्रदर्शित करता है:

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

Aspose.Slides की PDF रूपांतरण क्षमताएँ PDF को सबसे लोकप्रिय फ़ाइल फ़ॉर्मेट्स में बदलने तक विस्तारित हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेष फ़ॉर्मेट्स—[PDF to SVG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-xml/)—भी समर्थित हैं।

{{% /alert %}}

> **नोट:** PDF/UA में एक्सपोर्ट करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूले को एकल फ़िगर के रूप में मानता है। व्यक्तिगत पाथ एलिमेंट्स को अलग कंटेंट के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी फ़िगर के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या Aspose.Slides for Python PDF से एप्लिकेशन जानकारी हटा सकता है?

नहीं, Aspose.Slides for Python स्वतः API जानकारी और संस्करण संख्या को आउटपुट PDF में शामिल करता है। इस जानकारी को संशोधित या हटाया नहीं जा सकता।

### PDF रूपांतरण में केवल विशिष्ट स्लाइड्स को कैसे शामिल करें?

आप `save` मेथड को स्लाइड पोजीशन की एक एरे पास करके उन स्लाइड इंडेक्स को निर्दिष्ट कर सकते हैं जिन्हें आप बदलना चाहते हैं।

### क्या रूपांतरण के दौरान PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?

हाँ, आप PDF को सहेजने से पहले `PdfOptions` क्लास का उपयोग करके पासवर्ड सेट कर सकते हैं और एक्सेस परमिशन्स परिभाषित कर सकते हैं।

### क्या Aspose.Slides PDF को अन्य फ़ॉर्मेट्स में बदलने का समर्थन करता है?

हाँ, Aspose.Slides PDFs को HTML, इमेज फ़ॉर्मेट्स (JPG, PNG), SVG, TIFF, और XML जैसे फ़ॉर्मेट्स में बदलने का समर्थन करता है।

### मैं सुनिश्चित कैसे करूँ कि मेरा PDF एक्सेसिबिलिटी मानकों का पालन करता है?

`PdfOptions` में `compliance` प्रॉपर्टी को `PDF_A1A`, `PDF_A1B`, या `PDF_UA` जैसे मानों पर सेट करें ताकि एक्सेसिबिलिटी गाइडलाइन्स के अनुरूप हो।

### क्या मैं PDF आउटपुट में छिपी स्लाइड्स शामिल कर सकता हूँ?

हाँ, `PdfOptions` में `show_hidden_slides` प्रॉपर्टी को `True` सेट करने पर छिपी स्लाइड्स PDF में शामिल हो जाएँगी।

### रूपांतरण के दौरान इमेज क्वालिटी और रेज़ॉल्यूशन कैसे समायोजित करें?

`PdfOptions` में `jpeg_quality` और `sufficient_resolution` प्रॉपर्टीज़ का उपयोग करके उत्पन्न PDF में इमेज क्वालिटी और रेज़ॉल्यूशन को नियंत्रित कर सकते हैं।

### क्या Aspose.Slides फ़ॉन्ट सब्स्टिट्यूशन को स्वतः संभालता है?

Aspose.Slides रूपांतरण के दौरान फ़ॉन्ट सब्स्टिट्यूशन का पता लगाता है, और आप इसे `SaveOptions` में `warning_callback` प्रॉपर्टी (वर्तमान में सीमित) का उपयोग करके संभाल सकते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET Documentation](https://docs.aspose.com/slides/hi/python-net/)
- [Aspose.Slides API Reference](https://reference.aspose.com/slides/hi/python-net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)