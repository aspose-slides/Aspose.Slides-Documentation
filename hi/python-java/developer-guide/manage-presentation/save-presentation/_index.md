---
title: Python के माध्यम से Java में प्रेज़ेंटेशन सहेजें
linktitle: प्रेज़ेंटेशन सहेजें
type: docs
weight: 80
url: /hi/python-java/save-presentation/
keywords:
  - PowerPoint सहेजें
  - OpenDocument सहेजें
  - प्रस्तुति सहेजें
  - स्लाइड सहेजें
  - PPT सहेजें
  - PPTX सहेजें
  - ODP सहेजें
  - फ़ाइल में प्रस्तुति
  - स्ट्रीम में प्रस्तुति
  - पूर्वनिर्धारित व्यू टाइप
  - स्ट्रिक्ट Office Open XML फ़ॉर्मेट
  - Zip64 मोड
  - थंबनेल रीफ़्रेश करना
  - सहेजने की प्रगति
  - Python
  - Java
  - Aspose.Slides
description: "Aspose.Slides के साथ Python के माध्यम से Java में PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट तथा प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **समीक्षा**

प्रेज़ेंटेशन बनाने के बाद या [एक मौजूदा प्रस्तुति खोलें](/slides/hi/python-java/open-presentation/), परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। Aspose.Slides for Python via Java प्रेज़ेंटेशन को PowerPoint, OpenDocument, PDF और अन्य फ़ॉर्मेट में फ़ाइल या स्ट्रीम में सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने की क्रियाओं और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रेज़ेंटेशन सहेजें**

फ़ाइल में प्रेज़ेंटेशन सहेजने के लिए, आउटपुट पाथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides किस प्रकार की फ़ाइल बनाता है।

निम्न उदाहरण एक प्रेज़ेंटेशन बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # यहाँ प्रस्तुति सामग्री जोड़ें या संशोधित करें।

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रेज़ेंटेशन को उनके मूल फ़ॉर्मेट में सहेजें**

बैच‑प्रॉसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसके मूल फ़ॉर्मेट को [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) मेथड से पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) मान को [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#toSaveFormat) को पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) प्राप्त करें, और फिर [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करके संशोधित प्रेज़ेंटेशन लिखें।

निम्न पूर्ण उदाहरण इनपुट डायरेक्टरी में प्रत्येक फ़ाइल को प्रोसेस करता है, उसके शीर्षक को अपडेट करता है, और उसे उसी फ़ॉर्मेट में आउटपुट डायरेक्टरी में सहेजता है जिससे वह लोड हुई थी:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रेज़ेंटेशन सहेजने के फ़ॉर्मेट में मैप करता है। यह केवल प्रेज़ेंटेशन स्रोत फ़ॉर्मेट को मैप करता है; यह PDF, HTML, TIFF या इमेज जैसे निर्यात फ़ॉर्मेट चुनने के लिए नहीं है। असमर्थित या अमान्य [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) मान पास करने पर एक [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) उत्पन्न होता है।

पुराने PPT, PPS और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रेज़ेंटेशन को स्ट्रीम से फ़ाइल एक्सटेंशन के बिना लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन पुराने सबटाइप्स को संदर्भित रखना आवश्यक हो, तो मूल फ़ाइलनाम या फ़ॉर्मेट मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम व फ़ॉर्मेट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रेज़ेंटेशन सहेजें**

फ़ाइल पाथ पर निर्भर हुए बिना प्रेज़ेंटेशन लिखने के लिए, एक लिखने योग्य स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड में पास करें। यह तरीका तब उपयोगी होता है जब आउटपुट को वेब सर्विस से लौटाना हो, डेटाबेस में संग्रहीत करना हो, या मेमोरी में प्रोसेस करना हो।

निम्न उदाहरण एक नई प्रेज़ेंटेशन को फ़ाइल स्ट्रीम में सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रेज़ेंटेशन सहेजें**

आप सहेजे गए प्रेज़ेंटेशन को PowerPoint में प्रारंभिक रूप से किस व्यू में खोलना चाहते हैं, यह निर्दिष्ट कर सकते हैं। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewtype/) मान के साथ [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setLastView) मेथड का उपयोग करें।

निम्न उदाहरण Slide Master व्यू को प्रारंभिक व्यू के रूप में कॉन्फ़िगर करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **स्ट्रिक्ट Office Open XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें**

Office Open XML की स्ट्रिक्ट प्रोफ़ाइल के अनुरूप PPTX फ़ाइल बनाने के लिए, एक [PptxOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/) इंस्टेंस बनाएं और उसके [setConformance](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setConformance) मेथड को [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) मान के साथ कॉल करें। फिर विकल्पों को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड में पास करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Office Open XML फ़ॉर्मेट में Zip64 मोड के साथ प्रेज़ेंटेशन सहेजें**

एक मानक ZIP आर्काइव प्रत्येक एंट्री के संपीडित और असंपीडित आकार, कुल आर्काइव आकार और एंट्री की संख्या को सीमित करता है। चूँकि PPTX फ़ाइल एक ZIP आर्काइव है, बहुत बड़ी प्रेज़ेंटेशन इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन आकार और एंट्री‑काउंट सीमाओं को बढ़ाते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setZip64Mode) मेथड का उपयोग करके नियंत्रित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- [IfNecessary](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 का उपयोग करता है जब प्रेज़ेंटेशन मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को निष्क्रिय करता है।
- [Always](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्न उदाहरण आउटपुट प्रेज़ेंटेशन के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="चेतावनी" %}}
यदि [Zip64Mode.Never](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Never) उपयोग किया जाता है और प्रेज़ेंटेशन मानक ZIP सीमाओं में नहीं फिट हो पाता, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **संपीड़न स्तर के साथ Office Open XML फ़ॉर्मेट में प्रेज़ेंटेशन सहेजें**

PPTX आउटपुट के लिए, आप [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setCompressionLevel) मेथड का उपयोग करके सहेजने की गति को फ़ाइल आकार के विरुद्ध संतुलित कर सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/) क्लास इन मानों को प्रदान करती है:

- [None](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#None) डेटा को बिना संपीड़न के संग्रहीत करता है।
- [Level1](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level1) सबसे तेज़ संपीड़न और सबसे बड़ा संपीड़ित आउटपुट देता है।
- [Level2](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level5) तक क्रमशः छोटे आउटपुट को सहेजने की गति के ऊपर प्राथमिकता देते हैं।
- [Level6](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level6) सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट स्तर है।
- [Level7](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level8) छोटे आउटपुट के पक्ष में और अधिक प्राथमिकता देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level9) सबसे मजबूत संपीड़न प्रदान करता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्न उदाहरण बिना संपीड़न के प्रेज़ेंटेशन सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

निम्न उदाहरण अधिकतम संपीड़न स्तर का उपयोग करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **थंबनेल को रीफ़्रेश किए बिना प्रेज़ेंटेशन सहेजें**

जब प्रेज़ेंटेशन को PPTX के रूप में सहेजा जाता है, तो [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड उसके डॉक्यूमेंट थंबनेल को नियंत्रित करता है:

- `True` सहेजने के दौरान थंबनेल को पुनः जेनरेट करता है। यह डिफ़ॉल्ट मान है।
- `False` मौजूदा थंबनेल को संरक्षित रखता है। यदि प्रेज़ेंटेशन में थंबनेल नहीं है, तो Aspose.Slides एक नहीं बनाता।

निम्न उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रेज़ेंटेशन सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ध्यान दें" %}}
थंबनेल रीफ़्रेश को डिसेबल करने से PPTX फ़ाइल को सहेजने में लगने वाला समय घट सकता है।
{{% /alert %}}

## **प्रगति अपडेट प्रतिशत में दिखाएँ**

सहेजने की प्रक्रिया की निगरानी करने के लिए, `jpype.JProxy` के माध्यम से एक Python प्रगति हैंडलर रजिस्टर करें और उसे [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setProgressCallback) मेथड में पास करें। Aspose.Slides तब निर्यात के दौरान हैंडलर के `reporting` मेथड को प्रोग्रेस वैल्यू के साथ कॉल करता है।

निम्न उदाहरण PDF निर्यात की प्रगति को कंसोल पर रिपोर्ट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="ध्यान दें" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जो Aspose.Slides API के साथ बनाया गया है। यह प्रेज़ेंटेशन से चयनित स्लाइड को अलग‑अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इंक्रीमेंटल या “फ़ास्ट सहेजना” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन पूरी आउटपुट फ़ाइल लिखता है, न कि केवल बदले हुए हिस्सों को अपडेट करता है।

**क्या कई थ्रेड एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/python-java/multithreading/)। प्रत्येक इंस्टेंस को केवल एक थ्रेड से ही एक्सेस और सहेजा जाना चाहिए।

**जब मैं प्रेज़ेंटेशन सहेजता हूँ तो हाइपरलिंक्स और बाहरी रूप से लिंक की गई फ़ाइलें क्या होती हैं?**

[हाइपरलिंक्स](/slides/hi/python-java/manage-hyperlinks/) प्रेज़ेंटेशन में बना रहता है। Aspose.Slides बाहरी रूप से लिंक की गई फ़ाइलों को कॉपी नहीं करता, इसलिए सहेजा गया प्रेज़ेंटेशन फिर भी उनकी लोकेशन तक पहुंच सकना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसी डॉक्यूमेंट मेटाडाटा सहेज सकता हूँ?**

हां। सहेजने से पहले उचित [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/python-java/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिखता है।