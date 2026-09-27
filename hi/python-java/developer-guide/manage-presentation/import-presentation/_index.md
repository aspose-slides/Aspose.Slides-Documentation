---
title: Python के माध्यम से Java में PDF या HTML से प्रस्तुति आयात करें
linktitle: प्रस्तुति आयात करें
type: docs
weight: 60
url: /hi/python-java/import-presentation/
keywords:
- प्रस्तुति आयात करें
- स्लाइड आयात करें
- PDF आयात करें
- HTML आयात करें
- PDF से प्रस्तुति
- PDF से PPT
- PDF से PPTX
- PDF से ODP
- HTML से प्रस्तुति
- HTML से PPT
- HTML से PPTX
- HTML से ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में PDF और HTML सामग्री को PowerPoint प्रस्तुतियों में आयात करना सीखें और परिणामों को PPTX फ़ाइलों के रूप में सहेजें।"
---
## **परिचय**

Aspose.Slides for Python via Java PDF पृष्ठों या HTML सामग्री को Microsoft PowerPoint के बिना PowerPoint स्लाइड्स में बदल सकता है। The [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) class provides [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) और [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) imported सामग्री को प्रस्तुति में जोड़ने के लिए।

HTML प्लेसमेंट पर अधिक नियंत्रण के लिए, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) निर्दिष्ट संग्रह सूचकांक पर जनरेटेड स्लाइड्स डाल सकता है या मौजूदा स्लाइड पर उपलब्ध स्थान भरना शुरू कर सकता है। लंबी HTML स्वचालित रूप से अतिरिक्त स्लाइड्स में विभाजित होती है, स्रोत को स्ट्रिंग या स्ट्रीम के रूप में प्रदान किया जा सकता है, और बाहरी संसाधन [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) के साथ बेस URI के माध्यम से लोड किए जा सकते हैं। लौटाई गई [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) एरे प्रभावित और नए निर्मित स्लाइड्स को पहचानती है।

## **PDF से आयात**

PDF दस्तावेज़ को PowerPoint प्रस्तुति में परिवर्तित करने के लिए, उसकी सामग्री को स्लाइड संग्रह में आयात करें और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाएं।
2. [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) को PDF फ़ाइल के पथ के साथ कॉल करें।
3. [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें ताकि प्रस्तुति को PPTX फ़ाइल में लिखा जा सके।

निम्नलिखित Python उदाहरण PDF दस्तावेज़ को आयात करता है और जनरेटेड स्लाइड्स को PowerPoint प्रस्तुति के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

डिफ़ॉल्ट खाली स्लाइड प्रस्तुति में बनी रहती है क्योंकि आयात स्लाइड्स को जोड़ता है। केवल आयातित पृष्ठों को रखने के लिए, आयात करने से पहले [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) के साथ स्लाइड संग्रह को साफ़ करें।

The [addFromPdf] मेथड उन स्लाइड्स को रिटर्न करता है जो यह जोड़ता है, जो तभी उपयोगी है जब आपको केवल आयातित स्लाइड्स को प्रोसेस करना हो।

{{% alert title="Tip" color="success" %}}
इस रूपांतरण कार्यप्रवाह को क्रिया में देखिणे के लिए मुफ्त [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) वेब ऐप आज़माएँ।
{{% /alert %}}

## **HTML से आयात**

Aspose.Slides भी HTML दस्तावेज़ से स्लाइड्स बना सकता है। स्रोत को HTML टेक्स्ट या स्ट्रीम के रूप में प्रदान किया जा सकता है। निम्न चरण फ़ाइल स्ट्रीम का उपयोग करते हैं:

1. एक नया [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाएं।
2. HTML फ़ाइल को पढ़ने के लिए खोलें और स्ट्रीम को [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) को पास करें।
3. [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करें ताकि परिणाम को PPTX फ़ाइल में लिखा जा सके।

निम्नलिखित Python उदाहरण HTML दस्तावेज़ को आयात करता है और जनरेटेड स्लाइड्स को PowerPoint प्रस्तुति के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **HTML सामग्री डालें**

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) का उपयोग तब करें जब HTML-जनित स्लाइड्स को संलग्न करने के बजाय विशिष्ट स्थान पर रखना हो। सूचकांक शून्य-आधारित है और वह स्थान पहचानता है जहाँ आयात शुरू होता है।

`useSlideWithIndexAsStart` तर्क नियंत्रित करता है कि आयातकर्ता उस स्थिति का कैसे उपयोग करता है:

- जब यह `False` हो, आयातकर्ता निर्दिष्ट सूचकांक पर नई स्लाइड्स बनाता है और उसके बाद की स्लाइड्स को स्थानांतरित करता है।
- जब यह `True` हो, आयातकर्ता उस सूचकांक पर मौजूदा स्लाइड की उपलब्ध जगह में सामग्री रखना शुरू करता है। यदि HTML फिट नहीं होती, तो Aspose.Slides इसे स्वचालित रूप से पेजिनेट करता है और प्रारंभिक स्लाइड के तुरंत बाद अतिरिक्त स्लाइड्स डालता है।

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) ऑब्जेक्ट्स की एक एरे रिटर्न करता है। जब सम्मिलन नई स्लाइड्स पर शुरू होता है, तो प्रत्येक रिटर्नेड आइटम नया बनाया गया होता है। जब मौजूदा स्लाइड को प्रारंभिक बिंदु के रूप में उपयोग किया जाता है, तो एरे में वह प्रभावित स्लाइड और उसके बाद की नई ओवरफ़्लो स्लाइड्स शामिल होती हैं। आप इस एरे को निरीक्षण कर सकते हैं बजाय इसके कि प्रस्तुति की स्लाइड गिनती से प्रभावित रेंज की गणना करें।

### **नई स्लाइड्स के रूप में HTML डालें**

निम्न उदाहरण HTML को स्ट्रिंग के रूप में प्रदान करता है और जनरेटेड स्लाइड्स को संग्रह सूचकांक `1` पर डालता है। `False` पास करने से मौजूदा स्लाइड्स अपरिवर्तित रहती हैं, केवल जगह बनाने के लिए शिफ्ट की जाती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **मौजूदा स्लाइड पर शुरू करें**

अगला उदाहरण HTML को स्ट्रीम के माध्यम से प्रदान करता है। यह मौजूदा टेम्पलेट स्लाइड पर हेडर शेप को बनाए रखता है, प्रयुक्त क्षेत्र के नीचे आयात शुरू करता है, और लंबा बॉडी नई स्लाइड्स पर जारी रहने देता है।

HTML में एक सापेक्षित इमेज URL भी होता है। एक [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) संसाधन प्राप्त करता है, जबकि बेस URI आयातकर्ता को बताता है कि `images/logo.png` को कैसे समाधान किया जाए। इस उदाहरण में, वह फ़ाइल `html-assets/images/logo.png` पर अपेक्षित है।

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
एक अनियंत्रित बाहरी संसाधन रेज़ॉल्वर HTML द्वारा संदर्भित स्थानीय या नेटवर्क संसाधनों को पढ़ सकता है। असुरक्षित इनपुट के लिए, HTML आयात करने से पहले अनुमति प्राप्त स्कीम, डायरेक्ट्रीज़ और होस्ट्स की व्हाइटलिस्ट के विरुद्ध संसाधन URLs को सत्यापित और साफ़ करें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides PDF आयात करते समय तालिकाओं का पता लगा सकता है?**

हाँ। एक [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/) ऑब्जेक्ट बनाएं, [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) को `True` के साथ कॉल करें, और विकल्पों को [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) को पास करें। तालिका पहचान की गुणवत्ता स्रोत PDF की संरचना और जटिलता पर निर्भर करती है।

{{% alert title="Note" color="info" %}}
HTML आयात करने के बाद, आप स्लाइड्स को [images](/slides/hi/python-java/convert-powerpoint-to-png/), [TIFF](/slides/hi/python-java/convert-powerpoint-to-tiff/), या [SVG](/slides/hi/python-java/render-a-slide-as-an-svg-image/) में भी निर्यात कर सकते हैं।
{{% /alert %}}