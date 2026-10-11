---
title: Python के माध्यम से Java में नोट्स पेज आकार और अभिविन्यास बदलें
linktitle: नोट्स पेज आकार
type: docs
weight: 10
url: /hi/python-java/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिविन्यास
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रेजेंटेशन
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java में नोट्स पेज आयाम पढ़ें और बदलें, अभिविन्यास बदलें, सहेजे गए आकारों की पुष्टि करें, और नोट्स या हैंडआउट को PDF और छवियों में निर्यात करें।"
---
## **अवलोकन**

Use [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getNotesSize) to access the presentation's notes page settings. It returns a [NotesSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notessize/) object whose [setSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notessize/#setSize) method sets the page dimensions. Although the settings object itself cannot be replaced, you can assign new dimensions through this method.

चौड़ाई और ऊँचाई **पॉइंट्स** में निर्दिष्ट की जाती है, जहाँ 1 इंच में 72 पॉइंट्स होते हैं। उदाहरण के लिए, 900 × 600 पॉइंट्स 12.5 × 8⅓ इंच होते हैं। ये सेटिंग्स पूरी प्रेजेंटेशन पर लागू होती हैं, न कि व्यक्तिगत स्लाइड के नोट्स पर।

| Setting | Purpose |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getNotesSize) | नोट्स पेज के आयाम तथा हैंडआउट निर्यात के लिए उपयोग किए जाने वाले पेज आयामों को नियंत्रित करता है। |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideSize) | सामान्य प्रेजेंटेशन स्लाइड के आयामों को [SlideSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/) के माध्यम से नियंत्रित करता है। |

इनमें से किसी एक सेटिंग को बदलने से स्वचालित रूप से दूसरी नहीं बदलती। नोट्स पेज की ओरिएंटेशन बदलने से नियमित स्लाइड्स घुमती नहीं हैं। नियमित स्लाइड्स को पुन: आकार देने के लिए [स्लाइड आकार](/slides/hi/python-java/slide-size/) देखें।

निम्नलिखित उदाहरण मौजूदा `sample.pptx` का उपयोग करते हैं। निर्यात उदाहरणों के लिए, कम से कम एक स्लाइड जिसमें स्पीकर नोट्स हों, वाली प्रेजेंटेशन का उपयोग करें। प्रत्येक उदाहरण स्वतंत्र रूप से चलाया जा सकता है।

## **नोट्स पेज आकार और अभिविन्यास पढ़ें**

चौड़ाई और ऊँचाई पढ़ें और उनकी तुलना करके अभिविन्यास निर्धारित करें: चौड़ा पेज लैंडस्केप होता है, ऊँचा पेज पोर्ट्रेट, और समान आयाम वर्गाकार पेज को दर्शाते हैं। यह उदाहरण वास्तविक आयाम पॉइंट्स में प्रिंट करता है, बिना मानक कागज़ आकार मानते हुए।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **पेपर आकार बदले बिना लैंडस्केप में बदलें**

केवल अभिविन्यास बदलने के लिए, मौजूदा चौड़ाई और ऊँचाई को अदला‑बदली करें। इससे दोनों पक्षों की लंबाई सुरक्षित रहती है, जिसमें कस्टम पेपर आकार की लंबाई भी शामिल है। नीचे दिया गया शर्त पहले से लैंडस्केप पेज को फिर से पोर्ट्रेट में बदलने से रोकता है तथा वर्गाकार पेज को जैसा है वैसा ही छोड़ देता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpule.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पोर्ट्रेट अभिविन्यास के लिए, वही असाइनमेंट तब उपयोग करें जब `size.getWidth() > size.getHeight()` हो। जब तक आप पेपर आकार भी बदलना नहीं चाहते, तब तक A4 या लेटर आयामों को प्रतिस्थापित न करें।

## **कस्टम नोट्स पेज आकार सेट और सत्यापित करें**

दोनों आयाम एक साथ असाइन करें, फिर प्रेजेंटेशन लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करें। यह उदाहरण 900 × 600‑पॉइंट्स का लैंडस्केप पेज सेट करता है, इसे PPTX के रूप में सहेजता है, और सहेजी गई फ़ाइल को फिर से खोलकर स्थायी मानों की जाँच करता है। तुलना फ़्लोटिंग‑पॉइंट मानों के लिए 0.01‑पॉइंट सहनशीलता की अनुमति देती है; यह प्रत्येक फ़ाइल फ़ॉर्मेट के लिए सटीकता की गारंटी नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

अपेक्षित परिणाम `900.0 x 600.0 points` और `Size preserved: True` है। नई खोली गई प्रेजेंटेशन की जाँच सहेजी गई फ़ाइल को सत्यापित करती है, न कि केवल इन‑मेमोरी सेटिंग्स को।

## **नोट्स और हैंडआउट निर्यात**

पेज आयाम नोट्स या हैंडआउट लेआउट के लिए उपलब्ध क्षेत्र को निर्धारित करते हैं। ये लेआउट स्वयं सक्षम नहीं होते: निर्यात विकल्पों को भी कॉन्फ़िगर करें। नियमित स्लाइड निर्यात स्लाइड आयामों का उपयोग जारी रखता है।

### **नोट्स को PDF और PNG में निर्यात करें**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notescommentslayoutingoptions/) को [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) में असाइन करें ताकि PDF में नोट्स शामिल हों। यह उदाहरण नोट्स के साथ पहली स्लाइड को PNG में रेंडर करता है, इसके लिए [Slide.getImage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getImage) और [RenderingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/renderingoptions/) का उपयोग किया गया है।

[BottomTruncated](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/) मोड नोट्स को एक पेज पर रखता है; जो नोट्स फिट नहीं होते उन्हें ट्रंकेट किया जा सकता है। PDF 900 × 600‑पॉइंट्स पेजों का उपयोग करता है। नीचे उपयोग किए गए 1 × 1 इमेज स्केल पर PNG 900 × 600 पिक्सेल होता है। पॉइंट्स पेज जियोमेट्री को दर्शाते हैं; पिक्सेल रास्टर आउटपुट को, जिसकी डाइमेंशन भी रेंडरिंग स्केल पर निर्भर करती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

लंबे नोट्स वाले PDF निर्यात के लिए, [BottomFull](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notespositions/) आवश्यकतानुसार अतिरिक्त पृष्ठों की अनुमति देता है। उपर्युक्त सिंगल‑स्लाइड इमेज कॉल के साथ इस मोड का उपयोग न करें, क्योंकि वह इसे समर्थन नहीं देता। आकार बदलने के बाद, क्लिप किए गए नोट्स और मौजूदा notes‑master ऑब्जेक्ट्स की स्थिति की जाँच करें; केवल पेज आयाम बदलना यह गारंटी नहीं देता कि सभी कंटेंट फिट हो जाएगा। नोट्स निर्यात के बारे में अधिक जानकारी के लिए [Convert PowerPoint to PDF with Notes](/slides/hi/python-java/convert-powerpoint-to-pdf-with-notes/) देखें।

### **हैंडआउट को PDF में निर्यात करें**

एक पेज पर कई स्लाइड थंबनेल के लिए [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handoutlayoutingoptions/) का उपयोग करें। निम्न उदाहरण 900 × 600‑पॉइंट्स पेज सेट करता है और [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hi/python-java/aspose.slides/handouttype/) का उपयोग करके प्रति पेज अधिकतम चार स्लाइड व्यवस्थित करता है। हॉरिज़ॉन्टल प्रीसेट स्लाइड क्रम को नियंत्रित करता है; पेज अभिविन्यास उसकी चौड़ाई और ऊँचाई से निर्धारित होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

पेज आकार बदलने से हैंडआउट ग्रिड के लिए उपलब्ध क्षेत्र बदलता है, जबकि स्रोत स्लाइड्स के आयाम नहीं बदलते। हैंडआउट इमेज के लिए, व्यक्तिगत स्लाइड की इमेज मेथड की बजाय हैंडआउट लेआउट के साथ [Presentation.getImages](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getImages) का उपयोग करें। Aspose.Slides में, प्रेजेंटेशन‑लेवल हैंडआउट रेंडरिंग नोट्स पेज आयामों का उपयोग करती है, जबकि व्यक्तिगत स्लाइड इमेज कॉल हैंडआउट पेज नहीं बनाता। लेआउट विकल्पों के लिए [Handout Mode](/slides/hi/python-java/convert-powerpoint-in-handout-mode/) देखें।

## **व्यूअर्स, निर्यात और प्रिंटिंग में पेज आकार**

भंडारित प्रेजेंटेशन आकार, निर्यातित पेज आकार, और प्रिंटेड पेपर आकार को अलग रखें:

- **प्रेजेंटेशन व्यूअर्स:** एक व्यूअर अपने लेआउट नियमों का उपयोग करके नोट्स प्रदर्शित या प्रिंट कर सकता है। यदि कोई अन्य एप्लिकेशन फ़ाइल को सहेजता है, तो उसे पुनः खोलें और आयामों की पुनः जाँच करें; उस एप्लिकेशन का फ़ॉर्मेट परिवर्तन उन्हें सामान्य कर सकता है।

- **निर्यात फ़ॉर्मेट्स:** उपर्युक्त नोट्स और हैंडआउट PDF उदाहरण कॉन्फ़िगर किए गए पेज आयामों का उपयोग करते हैं। रास्टर इमेज इंटीजर पिक्सेल आयाम और रेंडरिंग स्केल का उपयोग करती हैं, इसलिए फ्रैक्शनल पॉइंट मान इमेज आउटपुट में राउंड हो सकते हैं। नियमित स्लाइड्स का निर्यात नोट्स पेज आकार लागू नहीं करता।

- **प्रिंटर ड्राइवर्स:** पेपर चयन, ऑटोमैटिक रोटेशन, और फ़िट‑टू‑पेज सेटिंग्स भौतिक आउटपुट को बदल सकती हैं, जबकि प्रेजेंटेशन या PDF में संग्रहीत आयाम नहीं बदलते। किसी विशेष पेपर आकार के लिए, प्रिंटर सेटिंग्स से मिलाएँ और प्रिंट प्रीव्यू की जाँच करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल एक स्लाइड के लिए नोट्स आकार सेट कर सकता हूँ?**

नोट्स पेज आकार एक प्रेजेंटेशन‑स्तरीय सेटिंग है। व्यक्तिगत स्लाइड्स में अलग नोट्स सामग्री हो सकती है, लेकिन यह प्रॉपर्टी प्रत्येक स्लाइड के लिए अलग पेज आकार प्रदान नहीं करती।

**नोट्स अभिविन्यास बदलने से मेरे स्लाइड्स क्यों नहीं बदले?**

नोट्स पेज और सामान्य स्लाइड्स के आयाम स्वतंत्र होते हैं। यदि आप स्लाइड्स को पुनः आकार देना चाहते हैं तो नियमित स्लाइड आकार सेटिंग्स का उपयोग करें।

**मेरे सहेजे या प्रिंट किए परिणाम का आकार अलग क्यों है?**

पहले सहेजी गई प्रेजेंटेशन को पुनः खोलें और उसके नोट्स आयामों की तुलना करें। यदि वे बदल गए हैं, तो देखें कि किसी अन्य एप्लिकेशन में फ़ाइल को सहेजने या कनवर्ट करने से पेज सेटिंग्स बदलें या नहीं। यदि नहीं बदले, तो निर्यात लेआउट, इमेज स्केल, व्यूअर सेटिंग्स, और प्रिंटर पेपर चयन की जाँच करें।