---
title: Python के माध्यम से Java में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint परिवर्तित करें
- प्रेज़ेंटेशन परिवर्तित करें
- PowerPoint से PDF
- प्रेज़ेंटेशन से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python के माध्यम से Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोजनीय PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **अवलोकन**

Python के माध्यम से Java में PowerPoint प्रस्तुतीकरण (PPT, PPTX, ODP, आदि) को PDF प्रारूप में परिवर्तित करने के कई लाभ हैं, जैसे विभिन्न उपकरणों में兼容ता और आपकी प्रस्तुति के लेआउट और फ़ॉर्मेटिंग को बनाए रखना। यह मार्गदर्शिका दर्शाती है कि कैसे प्रस्तुतीकरण को PDF दस्तावेज़ में बदलें, इमेज क्वालिटी को नियंत्रित करने के विभिन्न विकल्पों का उपयोग करें, छिपी हुई स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड‑प्रोटेक्ट करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, परिवर्तन के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके आप निम्नलिखित स्वरूपों में प्रस्तुतीकरण को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुतीकरण को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास में आर्ग्यूमेंट के रूप में पास करें और फिर [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करके प्रस्तुतीकरण को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास वह [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड उजागर करता है जो आमतौर पर प्रस्तुतीकरण को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="ध्यान दें" %}}

Aspose.Slides for Python via Java अपने API जानकारी और संस्करण संख्या को आउटपुट दस्तावेज़ों में सम्मिलित करता है। उदाहरण के तौर पर, जब एक प्रस्तुतीकरण को PDF में बदलते हैं, तो Aspose.Slides एप्लिकेशन फ़ील्ड को "*Aspose.Slides*" से भरता है और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में सेट करता है। **ध्यान रखें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए नहीं कह सकते।

{{% /alert %}}

Aspose.Slides आपको निम्नलिखित रूपांतरण करने की अनुमति देता है:

* संपूर्ण प्रस्तुतीकरण को PDF में बदलना
* प्रस्तुतीकरण की विशिष्ट स्लाइड्स को PDF में बदलना

Aspose.Slides प्रस्तुतीकरण को PDF में निर्यात करता है, जिससे परिणामस्वरूप PDFs मूल प्रस्तुतीकरण के अत्यधिक निकट होते हैं। रूपांतरण के दौरान तत्व और गुण सटीक रूप से रेंडर होते हैं, जिनमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फ़ूटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट PDF निर्यात सेटिंग्स के साथ मानक रूपांतरण किया जाता है। जब आपको इमेज क्वालिटी, पेज कंटेंट या PDF अनुपालन को नियंत्रित करने की आवश्यकता हो तो कस्टम विकल्पों का उपयोग करें।

[Aspose.Slides for Python via Java](/slides/hi/python-java/installation/) और संगत Java रनटाइम को स्थापित करके उदाहरण चलाएँ। प्रत्येक उदाहरण वर्तमान कार्यशील निर्देशिका से `presentation.pptx` पढ़ता है; इसे अपने PPT, PPTX, या ODP फ़ाइल से बदलें। Python प्रक्रिया के प्रति JVM को केवल एक बार प्रारंभ करें।

यह कोड एक प्रस्तुतीकरण को PDF में बदलता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ध्यान दें" %}}

Aspose एक मुफ्त ऑनलाइन **PowerPoint to PDF converter**(https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुतीकरण‑से‑PDF रूपांतरण प्रक्रिया को प्रदर्शित करता है। आप इस कनवर्टर के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देख सकते हैं।

{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प प्रदान करता है—[PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के तहत गुण—जो आपको उत्पन्न PDF को अनुकूलित करने, पासवर्ड के साथ PDF को लॉक करने, या रूपांतरण प्रक्रिया के प्रवाह को निर्दिष्ट करने में मदद करते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके आप रास्टर इमेज की वांछित क्वालिटी सेट कर सकते हैं, मेटाफाइल्स को कैसे सँभालना है निर्दिष्ट कर सकते हैं, टेक्स्ट के लिए कंप्रेशन लेवल सेट कर सकते हैं, इमेज के DPI को कॉन्फ़िगर कर सकते हैं, आदि।

नीचे दिया गया कोड उदाहरण दर्शाता है कि कैसे कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुतीकरण को PDF में बदला जाए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **छिपी हुई स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुतीकरण में छिपी हुई स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के [setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग करके छिपी हुई स्लाइड्स को परिणामस्वरूप PDF में पेज के रूप में शामिल कर सकते हैं।

यह कोड दर्शाता है कि कैसे छिपी हुई स्लाइड्स सहित PowerPoint प्रस्तुतीकरण को PDF में बदला जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

यह कोड दर्शाता है कि कैसे [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के प्रोटेक्शन पैरामीटर का उपयोग करके PowerPoint प्रस्तुतीकरण को पासवर्ड‑प्रोटेक्टेड PDF में बदला जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जिससे आप प्रस्तुतीकरण‑से‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

जावा API से चेतावनी कॉलबैक प्राप्त करने के लिए JPype प्रॉक्सी का उपयोग करें। जावा विवरण स्ट्रिंग को Python स्ट्रिंग में बदलें और उसके प्रिफिक्स की जांच करें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ध्यान दें" %}}

फ़ॉन्ट प्रतिस्थापन के दौरान रेंडरिंग प्रक्रिया में कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए देखें [Getting Warning Callbacks for Fonts Substitution](/slides/hi/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए देखें लेख [Font Substitution](/slides/hi/python-java/font-substitution/)।

{{% /alert %}}

## **PowerPoint में चयनित स्लाइड्स को PDF में बदलें**

[Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को पास किए गए स्लाइड नंबर 1‑आधारित होते हैं। यह उदाहरण तभी स्लाइड 1 और 3 निर्यात करता है जब दोनों मौजूद हों:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

यह उदाहरण पहला स्लाइड 612 × 792 पॉइंट (US Letter) आकार के पेज पर निर्यात करता है। यह निर्दिष्ट आकार के साथ नई प्रस्तुतीकरण में स्लाइड को क्लोन करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

यह कोड दर्शाता है कि कैसे नोट्स सहित PowerPoint प्रस्तुतीकरण को PDF में बदला जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF के लिए अभिगम्यता और अनुपालन मानक**

सुलभ PDFs तैयार करते समय [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) देखें। आउटपुट मानक चुनने के लिए [PdfOptions.setCompliance](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setCompliance) का उपयोग करें: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **ध्यान दें:** जब PDF/UA में निर्यात किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और समीकरणों को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्व अलग-अलग सामग्री के रूप में संरक्षित नहीं होते और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को बल्क में PDF में बदल सकता हूँ?**

हां, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटररेट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या रूपांतरित PDF को पासवर्ड‑प्रोटेक्ट किया जा सकता है?**

हां। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और पहुंच अधिकार निर्धारित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी हुई स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी हुई स्लाइड्स को शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?**

हां, आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setJpegQuality) और [setSufficientResolution](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSufficientResolution) जैसी विधियों का उपयोग करके अपने PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**

हां, Aspose.Slides आपको विभिन्न मानकों ([various standards](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfcompliance/)) के साथ अनुपालन करने वाले PDFs निर्यात करने की अनुमति देता है, जिनमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिन्हें आप अभिगम्यता या अभिलेखीय उद्देश्य के लिए उपयोग कर सकते हैं। उचित मानक चुनें और आउटपुट को अपनी आवश्यकताओं के विरुद्ध जांचें।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Python via Java Documentation](/slides/hi/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/hi/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hi/conversion)