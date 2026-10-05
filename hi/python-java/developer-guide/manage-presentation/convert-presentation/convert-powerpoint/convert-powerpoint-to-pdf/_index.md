---
title: "Python via Java में PPT और PPTX को PDF में परिवर्तित करें [उन्नत सुविधाएँ शामिल]"
linktitle: "PowerPoint को PDF में"
type: docs
weight: 40
url: /hi/python-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint को बदलें"
- "प्रेजेंटेशन को बदलें"
- "PowerPoint को PDF में"
- "प्रेजेंटेशन को PDF में"
- "PPT को PDF में"
- "PPT को PDF में बदलें"
- "PPTX को PDF में"
- "PPTX को PDF में बदलें"
- "PowerPoint को PDF के रूप में सहेजें"
- "PPT को PDF के रूप में सहेजें"
- "PPTX को PDF के रूप में सहेजें"
- "PPT को PDF में निर्यात करें"
- "PPTX को PDF में निर्यात करें"
- "संलग्नक"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके Python via Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोजयोग्य PDFs में परिवर्तित करें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **सारांश**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP, आदि) को Python via Java में PDF फ़ॉर्मेट में बदलने के कई फ़ायदे हैं, जैसे विभिन्न डिवाइसों में संगतता और आपके प्रेजेंटेशन की लेआउट व फ़ॉर्मेटिंग को संरक्षित रखना। यह मार्गदर्शिका दर्शाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, इमेज क्वालिटी को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, विशिष्ट स्लाइड्स का चयन करके बदलें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint को PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित स्वरूपों में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास में एक आर्ग्यूमेंट के रूप में पास करें और फिर [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) क्लास [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) मेथड को उजागर करता है जो आम तौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java आउटपुट दस्तावेज़ों में अपने API सूचना और संस्करण संख्या डालता है। उदाहरण के लिए, जब प्रस्तुति को PDF में बदला जाता है, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" के रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको रूपांतरित करने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में एक्सपोर्ट करता है, जिससे परिणामी PDFs मूल प्रस्तुतियों के बहुत करीब होते हैं। रूपांतरण में तत्व और विशेषताएँ सटीक रूप से रेंडर होती हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाईपरलिंक
* हेडर और फ़ूटर
* बुलेट
* टेबल

## **PowerPoint को PDF में परिवर्तित करें**

मानक रूपांतरण डिफ़ॉल्ट PDF एक्सपोर्ट सेटिंग्स का उपयोग करता है। जब आपको इमेज क्वालिटी, पेज कंटेंट या PDF अनुपालन को नियंत्रित करने की आवश्यकता हो तो कस्टम विकल्पों का उपयोग करें।

Install [Aspose.Slides for Python via Java](/slides/hi/python-java/installation/) and a compatible Java runtime before running the examples. Each example reads `presentation.pptx` from the current working directory; replace it with your PPT, PPTX, or ODP file. Start the JVM once per Python process.

The following example loads a presentation and saves all visible slides to PDF using the default export settings.

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

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF परिवर्तक**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑से‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ इस परिवर्तक के साथ परीक्षण करके यहां वर्णित प्रक्रिया को लाइव लागू कर सकते हैं।
{{% /alert %}}

## **PowerPoint को PDF में विकल्पों के साथ परिवर्तित करें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास के तहत प्रॉपर्टीज़—प्रदान करता है जो आपको परिणामी PDF को कस्टमाइज़ करने, पासवर्ड के साथ PDF को लॉक करने, या यह निर्दिष्ट करने की अनुमति देते हैं कि रूपांतरण प्रक्रिया कैसे आगे बढ़े।

### **PowerPoint को PDF में कस्टम विकल्पों के साथ परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर इमेजेज़ की पसंदीदा क्वालिटी सेटिंग, मेटा‑फ़ाइल्स को कैसे संभालना है, टेक्स्ट के लिए कम्प्रेशन लेवल, इमेजेज़ के लिए DPI आदि परिभाषित कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Embedded OLE फ़ाइलों को PDF एटैचमेंट के रूप में सुरक्षित रखें**

यदि प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाह सकते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा देख सकें साथ ही स्लाइड्स भी। `True` के साथ [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) को कॉल करके उत्पन्न PDF में एम्बेडेड OLE फ़ाइलों को एटैचमेंट के रूप में सुरक्षित रखें।

डिफ़ॉल्ट मान `False` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, पर उसकी एम्बेडेड फ़ाइल एटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `True` करने से फ़ाइल डेटा भी शामिल हो जाता है। प्रीव्यू केवल एक विज़ुअल प्रतिनिधित्व है; एटैचमेंट प्राप्तकर्ताओं को एम्बेडेड फ़ाइल को अलग से खोलने या सेव करने की सुविधा देता है। OLE ऑब्जेक्ट PDF पेज पर इंटरैक्टिव Excel शीट नहीं बनता।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

परिणाम की जांच करने के लिए:

1. फ़ाइल एटैचमेंट को सपोर्ट करने वाले व्यूअर (जैसे Adobe Acrobat Reader) में एक्सपोर्ट किए गए PDF को खोलें।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को ढूंढें।
3. एटैचमेंट को सेव करें और Excel में खोल कर डेटा देखें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू एटैचमेंट से अलग रहता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक एटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एंबेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A एटैचमेंट की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, सहित Excel वर्कबुक, को अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides की विशिष्ट सीमाएँ नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A एक्सपोर्ट को प्रदर्शित नहीं करता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में परिवर्तित करें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) मेथड को उपयोग करके छिपी स्लाइड्स को परिणामस्वरूप PDF में पेजेस के रूप में शामिल कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को परिवर्तित करें**

निम्न उदाहरण एक PDF को एक्सपोर्ट करता है जिसे खोलने के लिए पासवर्ड `password` की आवश्यकता होती है। एक्सेस परमिशन प्रिंटिंग, जिसमें हाई‑क्वालिटी प्रिंटिंग शामिल है, की अनुमति देते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) मेथड प्रदान करता है, जिससे आप प्रस्तुति‑से‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्न उदाहरण एक प्रस्तुति को PDF में एक्सपोर्ट करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। केवल तब चेतावनी प्रिंट होती है जब एक्सपोर्ट के दौरान कोई अनुपलब्ध फ़ॉन्ट प्रतिस्थापित किया जाता है। Java API से चेतावनी कॉलबैक प्राप्त करने के लिए JPype प्रॉक्सी का उपयोग करें। जावा विवरण स्ट्रिंग को Python स्ट्रिंग में बदलें और उसके प्रीफ़िक्स की जाँच करें:

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


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/python-java/font-substitution/) लेख।
{{% /alert %}}

## **PowerPoint से चयनित स्लाइड्स को PDF में परिवर्तित करें**

[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) को पास किए गए स्लाइड नंबर 1‑आधारित होते हैं। यह उदाहरण दोनों मौजूद होने पर स्लाइड 1 और 3 को एक्सपोर्ट करता है।

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में परिवर्तित करें**

यह उदाहरण पहले स्लाइड को 612 बाय 792 पॉइंट (US Letter) के पेज पर एक्सपोर्ट करता है। यह स्लाइड को निर्दिष्ट आकार के साथ नई प्रस्तुति में क्लोन करता है और स्लाइड कंटेंट को फिट करने के लिए स्केल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # नए प्रस्तुतीकरण के साथ बनाई गई खाली स्लाइड को हटाएँ।
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में परिवर्तित करें**

निम्न उदाहरण एक प्रस्तुति को PDF में एक्सपोर्ट करता है, जिसमें प्रत्येक स्लाइड के स्पीकर नोट्स स्लाइड के नीचे रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

सुलभ PDFs तैयार करने के लिए, देखें [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html)। आउटपुट मानक चुनने के लिए [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) का उपयोग करें: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने की प्रक्रिया दर्शाता है:

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

> **नोट:** जब PDF/UA में एक्सपोर्ट किया जाता है, तो Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फ़ॉर्मूले को एकल फ़िगर के रूप में मानता है। व्यक्तिगत पाथ एलिमेंट्स को अलग कंटेंट के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल सम्पूर्ण फ़िगर के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को बैच में PDF में बदल सकता हूँ?**  
हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपनी फ़ाइलों पर इटररेट करके प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित किया जा सकता है?**  
हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस परमिशन परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स कैसे शामिल करूँ?**  
[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) को `True` के साथ कॉल करके आप परिणामस्वरूप PDF में छिपी स्लाइड्स को शामिल कर सकते हैं।

**क्या Aspose.Slides PDF में उच्च इमेज क्वालिटी बनाए रख सकता है?**  
हाँ, आप [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) और [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) जैसी मेथड्स का उपयोग करके [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) क्लास में उच्च‑गुणवत्ता वाली इमेजेस सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**  
हाँ, Aspose.Slides आपको विभिन्न मानकों ([various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/)) के साथ अनुकूल PDF निर्यात करने की अनुमति देता है, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, ताकि एक्सेसिबिलिटी या आर्काइविंग आवश्यकताओं को पूरा किया जा सके। उपयुक्त मानक चुनें और अपने आवश्यकताओं के अनुसार आउटपुट की समीक्षा करें।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Python via Java Documentation](/slides/hi/python-java/)
- [Aspose.Slides for Python via Java API Reference](https://reference.aspose.com/slides/python-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)