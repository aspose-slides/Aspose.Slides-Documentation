---
title: Python के माध्यम से Java में PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- PowerPoint से PDF
- प्रस्तुति से PDF
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
description: "Aspose.Slides का उपयोग करके Python के माध्यम से Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोजयोग्य PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP, आदि) को Python के माध्यम से Java में PDF फ़ॉर्मेट में परिवर्तित करने के कई लाभ हैं, जिसमें विभिन्न डिवाइसों के बीच अनुकूलता और आपकी प्रस्तुति के लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह गाइड दर्शाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित किया जाए, छवि गुणवत्ता को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग किया जाए, छुपी स्लाइड्स को शामिल किया जाए, PDF फ़ाइलों को पासवर्ड से सुरक्षित किया जाए, फ़ॉन्ट प्रतिस्थापन का पता लगाया जाए, विशिष्ट स्लाइड्स को चयनित करके परिवर्तित किया जाए, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू किया जाए।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित फॉर्मेट में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास के आर्ग्युमेंट के रूप में पास करें और फिर [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को उजागर करता है, जो आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="नोट" %}}
Aspose.Slides for Python via Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के तौर पर, जब कोई प्रस्तुति PDF में परिवर्तित होती है, तो Aspose.Slides एप्लिकेशन फ़ील्ड को "*Aspose.Slides*" और PDF प्रोड्यूसर फ़ील्ड को "*Aspose.Slides v XX.XX*" के रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को आउटपुट दस्तावेज़ों से बदलने या हटाने का निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको परिवर्तित करने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि परिणामी PDFs मूल प्रस्तुतियों के करीब हों। तत्वों और गुणों को रूपांतरण में सटीक रूप से रेंडर किया जाता है, जिसमें शामिल हैं:

* छवियां
* पाठ बॉक्स और आकार
* पाठ फॉर्मेटिंग
* पैरा फॉर्मेटिंग
* हाइपरलिंक्स
* हेडर और फुटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में बदलें**

डिफ़ॉल्ट PDF निर्यात सेटिंग्स का उपयोग मानक रूपांतरण करता है। जब आपको छवि गुणवत्ता, पेज सामग्री, या PDF अनुपालन को नियंत्रित करने की आवश्यकता हो, तो अनुकूलित विकल्पों का उपयोग करें।

उदाहरण चलाने से पहले [Aspose.Slides for Python via Java](/slides/hi/python-java/installation/) और एक संगत Java रनटाइम स्थापित करें। प्रत्येक उदाहरण वर्तमान कार्य निर्देशिका से `presentation.pptx` पढ़ता है; इसे अपनी PPT, PPTX, या ODP फ़ाइल से बदलें। प्रत्येक Python प्रक्रिया के लिए JVM को एक बार प्रारंभ करें।

यह कोड एक प्रस्तुति को PDF में परिवर्तित करता है:

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

{{% alert color="info" title="नोट" %}}
Aspose एक मुफ़्त ऑनलाइन **PowerPoint से PDF रूपांतरणकर्ता**(https://products.aspose.app/slides/hi/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति-से-PDF रूपांतरण प्रक्रिया दर्शाता है। आप इस रूपांतरणकर्ता के साथ परीक्षण चलाकर यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन कर सकते हैं।
{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ परिवर्तित करें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के गुण— प्रदान करता है, जिससे आप परिणामी PDF को कस्टमाइज़ कर सकते हैं, PDF को पासवर्ड से लॉक कर सकते हैं, या यह निर्दिष्ट कर सकते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग निर्धारित कर सकते हैं, मेटा फाइलों को कैसे संभालना है निर्दिष्ट कर सकते हैं, पाठ के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के DPI को कॉन्फ़िगर कर सकते हैं, और अधिक।

नीचे दिया गया कोड उदाहरण दर्शाता है कि कई कस्टम विकल्पों के साथ PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए।

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

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में परिवर्तित करें**

यदि प्रस्तुति में छिपी स्लाइड्स हों, तो आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

यह कोड दर्शाता है कि छिपी स्लाइड्स को शामिल करके PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए:

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

### **PowerPoint को पासवर्ड-सुरक्षित PDF में परिवर्तित करें**

यह कोड दर्शाता है कि [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के सुरक्षा पैरामीटरों का उपयोग करके PowerPoint प्रस्तुति को पासवर्ड-सुरक्षित PDF में कैसे परिवर्तित किया जाए:

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

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास के अंतर्गत [setWarningCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जो आपको प्रस्तुति-से-PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाने में सक्षम बनाता है।

जावास्क्रिप्ट API से वार्निंग कॉलबैक प्राप्त करने के लिए JPype प्रॉक्सी का उपयोग करें। जावा वर्णन स्ट्रिंग को पायथन स्ट्रिंग में बदलें इससे पहले कि आप उसके उपसर्ग की जांच करें:

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

{{% alert color="info" title="नोट" %}}
रेंडरिंग प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापनों के लिए कॉलबैक प्राप्त करने के बारे में अधिक जानकारी के लिए, देखें [Getting Warning Callbacks for Font Substitution](/slides/hi/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)।

फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/python-java/font-substitution/) लेख।
{{% /alert %}}

## **PowerPoint में चयनित स्लाइड्स को PDF में परिवर्तित करें**

[Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को पास किए गए स्लाइड नंबर 1-आधारित होते हैं। यह उदाहरण तब स्लाइड 1 और 3 को निर्यात करता है जब दोनों मौजूद हों:

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

## **PowerPoint को कस्टम स्लाइड आकार के साथ PDF में परिवर्तित करें**

यह उदाहरण पहले स्लाइड को 612 बाय 792 पॉइंट (US Letter) आकार के पृष्ठ पर निर्यात करता है। यह स्लाइड को निर्दिष्ट आकार के साथ एक नई प्रस्तुति में क्लोन करता है:

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

## **PowerPoint को नोट्स स्लाइड दृश्य में PDF में बदलें**

यह कोड दर्शाता है कि नोट्स सहित PowerPoint प्रस्तुति को PDF में कैसे परिवर्तित किया जाए:

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

## **PDF के लिए सुलभता और अनुपालन मानक**

सुलभ PDFs तैयार करते समय, [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) देखें। आउटपुट मानक चुनने के लिए [PdfOptions.setCompliance](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setCompliance) का उपयोग करें: **PDF/A1a**, **PDF/A1b**, तथा **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाले PowerPoint-से-PDF रूपांतरण प्रक्रिया को दर्शाता है:

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

> **ध्यान दें:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफिक्स जैसे SmartArt, चार्ट और फ़ॉर्मूले को एक ही आकृति के रूप में मानेता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में नहीं सुरक्षित किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक पाठ केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को बैच में PDF में परिवर्तित कर सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपने फ़ाइलों पर इटरैट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड से सुरक्षित करना संभव है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमति निर्धारित करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड का उपयोग करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setJpegQuality) और [setSufficientResolution](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSufficientResolution) जैसी विधियों का उपयोग करके PDF में उच्च-गुणवत्ता वाली छवियां सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**

हाँ, Aspose.Slides आपको उन PDF को निर्यात करने की अनुमति देता है जो [various standards](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfcompliance/) जैसे PDF/A1a, PDF/A1b, और PDF/UA के साथ अनुपालन रखते हैं, सुलभता या अभिलेखन के लिए। उपयुक्त मानक चुनें और आउटपुट को अपनी आवश्यकताओं के विरुद्ध समीक्षा करें।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Python via Java दस्तावेज़ीकरण](/slides/hi/python-java/)
- [Aspose.Slides for Python via Java API संदर्भ](https://reference.aspose.com/slides/hi/python-java/)
- [Aspose मुफ्त ऑनलाइन रूपांतरणकर्ता](https://products.aspose.app/slides/hi/conversion)