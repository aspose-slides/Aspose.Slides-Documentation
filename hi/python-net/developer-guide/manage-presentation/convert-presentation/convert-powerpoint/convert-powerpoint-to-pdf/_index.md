---
title: Python में PPT और PPTX को PDF में बदलें | उन्नत विकल्प
linktitle: PowerPoint को PDF में
type: docs
weight: 40
url: /hi/python-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रस्तुति
- PowerPoint को PDF में
- PPT को PDF में
- PPTX को PDF में
- PowerPoint को PDF के रूप में सहेजें
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Aspose.Slides for Python
description: "Python में Aspose.Slides के साथ PPT, PPTX और ODP को उच्च गुणवत्ता, WCAG‑अनुपालन PDF में बदलने के लिए चरण-दर-चरण मार्गदर्शिका—जिसमें पासवर्ड सुरक्षा, स्लाइड चयन और छवि‑गुणवत्ता नियंत्रण शामिल है।"
showReadingTime: true
---
## **अवलोकन**

Python में PowerPoint प्रस्तुतियों (PPT, PPTX, ODP) को PDF स्वरूप में बदलने के कई लाभ हैं, जिसमें विभिन्न उपकरणों पर संगतता सुनिश्चित करना और आपकी प्रस्तुति की लेआउट और स्वरूपण को संरक्षित रखना शामिल है। यह मार्गदर्शिका दिखाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता को नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स को शामिल करें, PDF दस्तावेज़ों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, परिवर्तन के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

* **PPT**
* **PPTX**
* **ODP**

Python में प्रस्तुतियों को PDF में बदलने के लिए, आपको केवल फ़ाइल नाम को [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास में एक तर्क के रूप में पास करना है और फिर एक [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजना है। [Presentation](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/) क्लास वह [Save](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides/presentation/#methods) मेथड उजागर करती है जो आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Python आउटपुट दस्तावेज़ों में सीधे API जानकारी और संस्करण संख्या लिखता है। उदाहरण के लिए, जब यह एक प्रस्तुति को PDF में बदलता है, Aspose.Slides for Python Application फ़ील्ड को '*Aspose.Slides*' मान से भरता है और PDF Producer फ़ील्ड को '*Aspose.Slides v XX.XX*' रूप में मान से। **Note** कि आप Aspose.Slides for Python को आउटपुट दस्तावेज़ों से इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।

{{% /alert %}}

Aspose.Slides आपको बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति की विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, जिससे परिणामी PDFs की सामग्री मूल प्रस्तुतियों के बहुत करीब रहती है। परिवर्तन के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट स्वरूपण
* पैराग्राफ स्वरूपण
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलें**

स्टैंडर्ड PowerPoint PDF रूपांतरण ऑपरेशन डिफ़ॉल्ट विकल्पों का उपयोग करके निष्पादित किया जाता है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है। यह Python कोड आपको दिखाता है कि PowerPoint को PDF में कैसे बदलें:

_चरण: Python में PowerPoint से PDF रूपांतरण_

निम्न नमूना कोड .NET के माध्यम से Python का उपयोग करके इन रूपांतरणों को समझाता है
- <a name="python-net-powerpoint-to-pdf"><strong>चरण: Python के माध्यम से .NET का उपयोग करके PowerPoint को PDF में बदलें</a></strong>
- <a name="python-net-ppt-to-pdf"><strong>चरण: Python के माध्यम से .NET का उपयोग करके PPT को PDF में बदलें</a></strong>
- <a name="python-net-pptx-to-pdf"><strong>चरण: Python के माध्यम से .NET का उपयोग करके PPTX को PDF में बदलें</a></strong>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET का उपयोग करके ODP को PDF में बदलें</a></strong>
- <a name="python-net-odp-to-pdf"><strong>चरण: Python के माध्यम से .NET का उपयोग करके PPS को PDF में बदलें</a></strong>

_कोड चरण:_

- PowerPoint फ़ाइल प्रदान करने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
  * _.ppt_ एक्सटेंशन का उपयोग करके _Presentation_ क्लास के अंदर **PPT** फ़ाइल लोड करें।
  * _.pptx_ एक्सटेंशन का उपयोग करके _Presentation_ क्लास के अंदर **PPTX** फ़ाइल लोड करें।
  * _.odp_ एक्सटेंशन का उपयोग करके _Presentation_ क्लास के अंदर **ODP** फ़ाइल लोड करें।
  * _.pps_ एक्सटेंशन का उपयोग करके _Presentation_ क्लास के अंदर **PPS** फ़ाइल लोड करें।
- _Presentation_ को **PDF** स्वरूप में सहेजने के लिए **Save** मेथड को कॉल करें और **SaveFormat.PDF** एन्यूमरेशन का उपयोग करें।

```python
import aspose.slides as slides

# एक Presentation क्लास का उदाहरण बनाता है जो एक PowerPoint फ़ाइल का प्रतिनिधित्व करता है
presentation = slides.Presentation("PowerPoint.ppt")

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPT-to-PDF.pdf", slides.export.SaveFormat.PDF)
```

{{%  alert  color="primary"  %}} 

Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति को PDF में बदलने की प्रक्रिया को दर्शाता है। यहाँ वर्णित प्रक्रिया के लाइव कार्यान्वयन के लिए, आप कनवर्टर के साथ परीक्षण कर सकते हैं।

{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ बदलें**

Aspose.Slides एक कस्टम विकल्प—[PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास के अंतर्गत प्रॉपर्टीज़—प्रदान करता है जो आपको रूपांतरण प्रक्रिया से प्राप्त PDF को अनुकूलित करने, PDF को पासवर्ड से सुरक्षित करने, या यहाँ तक कि रूपांतरण प्रक्रिया के संचालन को निर्धारित करने की अनुमति देता है।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग, मेटा फ़ाइलों के हैंडलिंग का तरीका, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI आदि निर्धारित कर सकते हैं।

निम्न कोड उदाहरण एक ऐसे ऑपरेशन को दर्शाता है जिसमें PowerPoint प्रस्तुति को कई कस्टम विकल्पों के साथ PDF में बदल दिया जाता है:

```python
import aspose.slides as slides

# PdfOptions क्लास का उदाहरण बनाता है
pdf_options = slides.export.PdfOptions()

# JPG छवियों की गुणवत्ता सेट करता है
pdf_options.jpeg_quality = 90

# छवियों के लिए DPI सेट करता है
pdf_options.sufficient_resolution = 300

# मेटा फ़ाइलों के लिए व्यवहार सेट करता है
pdf_options.save_metafiles_as_png = True

# पाठ सामग्री के लिए टेक्स्ट संपीड़न स्तर सेट करता है
pdf_options.text_compression = slides.export.PdfTextCompression.FLATE

# PDF अनुपालन मोड को परिभाषित करता है
pdf_options.compliance = slides.export.PdfCompliance.PDF15

# Presentation क्लास का उदाहरण बनाता है जो PowerPoint दस्तावेज़ का प्रतिनिधित्व करता है
with slides.Presentation("PowerPoint.pptx") as presentation:
    # प्रस्तुति को PDF दस्तावेज़ के रूप में सहेजता है
    presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **PowerPoint को PDF में छिपी स्लाइड्स के साथ बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप कस्टम विकल्प—`show_hidden_slides` प्रॉपर्टी को [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास से—का उपयोग करके Aspose.Slides को निर्देश दे सकते हैं कि छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल किया जाए।

यह Python कोड आपको दिखाता है कि छिपी स्लाइड्स शामिल करके PowerPoint प्रस्तुति को PDF में कैसे बदलें:

```python
import aspose.slides as slides

# एक Presentation क्लास का उदाहरण बनाता है जो PowerPoint फ़ाइल का प्रतिनिधित्व करता है
presentation = slides.Presentation("PowerPoint.pptx")

# PdfOptions क्लास का उदाहरण बनाता है
pdfOptions = slides.export.PdfOptions()

# छिपी स्लाइड्स जोड़ता है
pdfOptions.show_hidden_slides = True

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PowerPoint-to-PDF.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

### **PowerPoint को पासवर्ड‑सुरक्षित PDF में बदलें**

यह Python कोड आपको दिखाता है कि [PdfOptions](https://docs.aspose.com/slides/hi/python-net/api-reference/aspose.slides.export/pdfoptions/) क्लास के सुरक्षा पैरामीटर का उपयोग करके PowerPoint को पासवर्ड‑सुरक्षित PDF में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाता है
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

यह Python कोड आपको दिखाता है कि PowerPoint प्रस्तुति में विशिष्ट स्लाइड्स को PDF में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाता है
presentation = slides.Presentation("PowerPoint.pptx")

# स्लाइड स्थितियों का एक एरे सेट करता है
slides_array = [ 1, 3 ]

# प्रस्तुति को PDF के रूप में सहेजता है
presentation.save("PPTX-to-PDF.pdf", slides_array, slides.export.SaveFormat.PDF)
```

## **PowerPoint को कस्टम स्लाइड आकार के साथ PDF में बदलें**

यह Python कोड आपको दिखाता है कि जब स्लाइड आकार निर्दिष्ट हो तो PowerPoint को PDF में कैसे बदलें:

```python
import aspose.slides as slides

slide_width = 612
slide_height = 792

# PowerPoint या OpenDocument फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास का उदाहरण बनाता है।
with slides.Presentation("SelectedSlides.pptx") as presentation:

    # समायोजित स्लाइड आकार के साथ नई प्रस्तुति बनाता है।
    with slides.Presentation() as resized_presentation:

        # कस्टम स्लाइड आकार सेट करता है।
        resized_presentation.slide_size.set_size(slide_width, slide_height, slides.SlideSizeScaleType.ENSURE_FIT)

        # मूल प्रस्तुति से पहली स्लाइड को क्लोन करता है।
        slide = presentation.slides[0]
        resized_presentation.slides.insert_clone(0, slide)

        # नोट्स के साथ PDF में पुनःआकारित प्रस्तुति को सहेजता है।
        resized_presentation.save("PDF_with_notes.pdf", slides.export.SaveFormat.PDF)
```

## **PowerPoint को नोट्स स्लाइड दृश्य में PDF में बदलें**

यह Python कोड आपको दिखाता है कि PowerPoint को PDF नोट्स में कैसे बदलें:

```python
import aspose.slides as slides

# PowerPoint फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाता है
presentation = slides.Presentation("NotesFile.pptx")

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

# प्रस्तुति को PDF नोट्स में सहेजता है
presentation.Save("Pdf_Notes_out.tiff", slides.export.SaveFormat.PDF, pdfOptions)
```

## **PDF के लिये अभिगम्यता और अनुपालन मानक**

Aspose.Slides आपको एक ऐसा रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसेबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप हो। आप इन अनुपालन मानकों में से किसी भी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह Python कोड एक PowerPoint से PDF रूपांतरण ऑपरेशन को दर्शाता है जिसमें विभिन्न अनुपालन मानकों पर आधारित कई PDFs प्राप्त होते हैं:

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

Aspose.Slides की PDF रूपांतरण ऑपरेशन्स की समर्थन सीमा इस बात तक विस्तारित है कि आप PDF को सबसे लोकप्रिय फ़ाइल स्वरूपों में भी बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशेषीकृत स्वरूपों—[PDF to SVG](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/hi/python-net/conversion/pdf-to-xml/)—के लिए भी समर्थन उपलब्ध है।

{{% /alert %}}

> **Note:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूला को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरे आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides for Python PDF से एप्लिकेशन जानकारी हटा सकता है?**  
नहीं, Aspose.Slides for Python आउटपुट PDF में स्वचालित रूप से API जानकारी और संस्करण संख्या शामिल करता है। इस जानकारी को संशोधित या हटाया नहीं जा सकता।

**PDF रूपांतरण में केवल विशिष्ट स्लाइड्स को कैसे शामिल करूँ?**  
आप `save` मेथड को स्लाइड पोजीशन की एक एरे पास करके वह स्लाइड इंडेक्स निर्दिष्ट कर सकते हैं जिन्हें आप बदलना चाहते हैं।

**क्या रूपांतरण के दौरान PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**  
हाँ, आप PDF को सहेजने से पहले `PdfOptions` क्लास का उपयोग करके पासवर्ड सेट कर सकते हैं और एक्सेस अनुमतियों को परिभाषित कर सकते हैं।

**क्या Aspose.Slides PDF को अन्य स्वरूपों में बदलने का समर्थन करता है?**  
हाँ, Aspose.Slides PDF को HTML, इमेज स्वरूप (JPG, PNG), SVG, TIFF, और XML जैसे स्वरूपों में बदलने का समर्थन करता है।

**मैं अपने PDF को अभिगम्यता मानकों के अनुरूप कैसे सुनिश्चित करूँ?**  
`PdfOptions` में `compliance` प्रॉपर्टी को `PDF_A1A`, `PDF_A1B`, या `PDF_UA` जैसे मान पर सेट करें ताकि अभिगम्यता दिशानिर्देशों के अनुरूप हो।

**क्या मैं PDF आउटपुट में छिपी स्लाइड्स शामिल कर सकता हूँ?**  
हाँ, `PdfOptions` में `show_hidden_slides` प्रॉपर्टी को `True` पर सेट करने से छिपी स्लाइड्स PDF में शामिल हो जाएँगी।

**रूपांतरण के दौरान छवि गुणवत्ता और रेज़ोल्यूशन कैसे समायोजित करूँ?**  
`PdfOptions` में `jpeg_quality` और `sufficient_resolution` प्रॉपर्टी का उपयोग करके उत्पन्न PDF में छवि गुणवत्ता और रेज़ोल्यूशन को नियंत्रित कर सकते हैं।

**क्या Aspose.Slides फ़ॉन्ट प्रतिस्थापन को स्वचालित रूप से संभालता है?**  
Aspose.Slides रूपांतरण के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाता है, और आप `SaveOptions` में `warning_callback` प्रॉपर्टी का उपयोग करके इसे संभाल सकते हैं (वर्तमान में सीमित)।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for .NET दस्तावेज़](https://docs.aspose.com/slides/hi/python-net/)
- [Aspose.Slides API रेफ़रेंस](https://reference.aspose.com/slides/hi/python-net/)
- [Aspose मुफ्त ऑनलाइन कन्वर्टर](https://products.aspose.app/slides/hi/conversion)