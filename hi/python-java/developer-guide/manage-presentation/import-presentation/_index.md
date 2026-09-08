---
title: Python के माध्यम से Java में PDF या HTML से प्रस्तुतियों का आयात
linktitle: प्रस्तुति आयात
type: docs
weight: 60
url: /hi/python-java/import-presentation/
keywords:
- प्रस्तुति आयात
- स्लाइड आयात
- PDF आयात
- HTML आयात
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
description: "Aspose.Slides के साथ Python के माध्यम से Java में PDF और HTML सामग्री को PowerPoint प्रस्तुतियों में आयात करना सीखें और परिणाम को PPTX फ़ाइलों के रूप में सहेजें।"
---
## **परिचय**

Aspose.Slides for Python via Java Microsoft PowerPoint के बिना PDF पृष्ठों या HTML सामग्री को PowerPoint स्लाइड्स में परिवर्तित कर सकता है। [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) क्लास [addFromPdf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromPdf) और [addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromHtml) प्रदान करता है ताकि आयातित सामग्री को प्रस्तुति में जोड़ सकें।  
HTML प्लेसमेंट पर अधिक नियंत्रण के लिए, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertFromHtml) उत्पन्न स्लाइड्स को संग्रह सूचकांक पर डाल सकता है या मौजूदा स्लाइड पर उपलब्ध स्थान को भरना शुरू कर सकता है। लंबी HTML को स्वचालित रूप से अतिरिक्त स्लाइड्स में पृष्ठांकित किया जाता है, स्रोत को स्ट्रिंग या स्ट्रीम के रूप में प्रदान किया जा सकता है, और बाहरी संसाधनों को [ExternalResourceResolver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/externalresourceresolver/) के माध्यम से एक बेस URI के साथ लोड किया जा सकता है। लौटाया गया [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) एरे प्रभावित और नए निर्मित स्लाइड्स की पहचान करता है।

## **PDF से आयात**

PDF दस्तावेज़ को PowerPoint प्रस्तुति में बदलने के लिए, उसकी सामग्री को स्लाइड संग्रह में आयात करें और परिणाम को PPTX फ़ाइल के रूप में सहेजें।

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वस्तु बनाएं।  
2. PDF फ़ाइल के पथ के साथ [addFromPdf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromPdf) को कॉल करें।  
3. [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करके प्रस्तुति को PPTX फ़ाइल में लिखें।

निम्नलिखित Python उदाहरण PDF दस्तावेज़ को आयात करता है और उत्पन्न स्लाइड्स को PowerPoint प्रस्तुति के रूप में सहेजता है:

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

डिफ़ॉल्ट खाली स्लाइड प्रस्तुति में बना रहता है क्योंकि आयात स्लाइड्स को जोड़ता है। केवल आयातित पृष्ठ रखना हो तो आयात करने से पहले [SlideCollection.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#clear) द्वारा स्लाइड संग्रह को साफ़ करें।  
[addFromPdf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromPdf) मेथड वह स्लाइड्स लौटाता है जो वह जोड़ता है, जो केवल आयातित स्लाइड्स को प्रोसेस करने की आवश्यकता होने पर उपयोगी है।

{{% alert title="सलाह" color="success" %}}
इस परिवर्तन कार्यप्रवाह को क्रियान्वित होते देखना है तो निःशुल्क [PDF to PowerPoint](https://products.aspose.app/slides/hi/import/pdf-to-powerpoint) वेब ऐप आज़माएँ।
{{% /alert %}}

## **HTML से आयात**

Aspose.Slides HTML दस्तावेज़ से भी स्लाइड्स बना सकता है। स्रोत को HTML पाठ या स्ट्रीम के रूप में प्रदान किया जा सकता है। निम्नलिखित चरण फाइल स्ट्रीम का उपयोग करते हैं:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वस्तु बनाएं।  
2. HTML फ़ाइल को पढ़ने के लिये खोलें और स्ट्रीम को [addFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromHtml) को पास करें।  
3. [save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) को [SaveFormat.Pptx](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/#Pptx) के साथ कॉल करके परिणाम को PPTX फ़ाइल में लिखें।

निम्नलिखित Python उदाहरण HTML दस्तावेज़ को आयात करता है और उत्पन्न स्लाइड्स को PowerPoint प्रस्तुति के रूप में सहेजता है:

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

## **HTML सामग्री सम्मिलित करें**

जब HTML-जनित स्लाइड्स को जोड़ने के बजाय किसी विशेष स्थान पर रखना हो, तो [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertFromHtml) का उपयोग करें। सूचकांक शून्य-आधारित है और उस स्थान को दर्शाता है जहाँ आयात शुरू होता है।  

`useSlideWithIndexAsStart` तर्क नियंत्रित करता है कि आयातक उस स्थिति का उपयोग कैसे करता है:

- जब यह `False` हो, आयातक निर्दिष्ट सूचकांक पर नई स्लाइड्स बनाता है और उसके बाद की स्लाइड्स को शिफ्ट कर देता है।  
- जब यह `True` हो, आयातक उस सूचकांक पर मौजूदा स्लाइड के उपलब्ध स्थान में सामग्री रखना शुरू करता है। यदि HTML फिट नहीं होता, तो Aspose.Slides इसे स्वतः पृष्ठांकित करता है और प्रारंभिक स्लाइड के तुरंत बाद अतिरिक्त स्लाइड्स सम्मिलित करता है।

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#insertFromHtml) [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) वस्तुओं की एक एरे लौटाता है। जब सम्मिलन नई स्लाइड्स पर शुरू होता है, तो प्रत्येक लौटाया गया आइटम नया बनाया गया होता है। जब मौजूदा स्लाइड को प्रारंभिक के रूप में उपयोग किया जाता है, तो एरे में वह प्रभावित स्लाइड और उसके बाद के किसी भी नए ओवरफ़्लो स्लाइड्स शामिल होते हैं। आप इस एरे को देख सकते हैं बजाय प्रस्तुति की स्लाइड गिनती से प्रभावित सीमा की गणना करने के।

### **HTML को नई स्लाइड्स के रूप में सम्मिलित करें**

निम्नलिखित उदाहरण HTML को स्ट्रिंग के रूप में प्रदान करता है और उत्पन्न स्लाइड्स को संग्रह सूचकांक `1` पर सम्मिलित करता है। `False` पास करने से मौजूदा स्लाइड्स अपरिवर्तित रहती हैं सिवाय उन्हें स्थान बनाने के लिए शिफ्ट करने के।

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

अगला उदाहरण HTML को स्ट्रीम के माध्यम से प्रदान करता है। यह मौजूदा टेम्पलेट स्लाइड पर हेडर आकार को रखता है, कब्ज़ा किए हुए क्षेत्र के नीचे आयात शुरू करता है, और लंबा बॉडी नई स्लाइड्स पर जारी रहने देता है।  
HTML में एक सापेक्ष इमेज URL भी शामिल है। एक [ExternalResourceResolver](https://reference.aspose.com/slides/hi/python-java/aspose.slides/externalresourceresolver/) संसाधन प्राप्त करता है, जबकि बेस URI आयातक को बताता है कि `images/logo.png` को कैसे हल किया जाए। इस उदाहरण में, उस फ़ाइल की अपेक्षा `html-assets/images/logo.png` पर है।

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

{{% alert title="चेतावनी" color="warning" %}}
एक अनिश्चित बाहरी संसाधन समाधानकर्ता HTML द्वारा संदर्भित स्थानीय या नेटवर्क संसाधनों को पढ़ सकता है। अविश्वसनीय इनपुट के लिए, आयात करने से पहले अनुमत स्कीम, निर्देशिकाओं और होस्टों की अनुमति सूची के विरुद्ध संसाधन URL को सत्यापित और स्वच्छ करें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides PDF आयात करते समय तालिकाओं का पता लगा सकता है?**

हाँ। एक [PdfImportOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfimportoptions/) ऑब्जेक्ट बनाएं, `True` के साथ [setDetectTables](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pdfimportoptions/#setDetectTables) को कॉल करें, और विकल्पों को [addFromPdf](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addFromPdf) को पास करें। तालिका पहचान की गुणवत्ता स्रोत PDF की संरचना और जटिलता पर निर्भर करती है।

{{% alert title="ध्यान" color="info" %}}
HTML आयात करने के बाद, आप स्लाइड्स को [images](/slides/hi/python-java/convert-powerpoint-to-png/), [TIFF](/slides/hi/python-java/convert-powerpoint-to-tiff/), या [SVG](/slides/hi/python-java/render-slide-as-svg/) में भी निर्यात कर सकते हैं।
{{% /alert %}}