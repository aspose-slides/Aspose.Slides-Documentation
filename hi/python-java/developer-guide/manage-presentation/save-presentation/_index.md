---
title: Python के द्वारा Java में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
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
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट Office Open XML प्रारूप
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Python के द्वारा Java में PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट तथा प्रगति रिपोर्टिंग को कॉन्फ़िगर करें।"
---
## **अवलोकन**

जब आप एक प्रस्तुति बनाते हैं या [मौजूदा प्रस्तुति खोलें](/slides/hi/python-java/open-presentation/), तो परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड का उपयोग करें। Aspose.Slides for Python via Java एक प्रस्तुति को PowerPoint, OpenDocument, PDF और अन्य फ़ॉर्मैट में फ़ाइल या स्ट्रीम में सहेज सकता है। नीचे दिए गए अनुभाग मानक सहेजने के ऑपरेशन्स और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को फ़ाइल में सहेजने के लिए, आउटपुट पाथ और एक [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को पास करें। फ़ॉर्मैट मान निर्धारित करता है कि Aspose.Slides कौन सी फ़ाइल प्रकार बनाता है।

निम्न उदाहरण एक प्रस्तुति बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

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

## **मूल स्वरूप में प्रस्तुतियों को सहेजें**

एक बैच‑प्रोसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मैट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसके मूल स्वरूप को [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) मेथड से पढ़ें। प्राप्त [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) मान को [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#toSaveFormat) को पास करके संबंधित [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान प्राप्त करें, और फिर संशोधित प्रस्तुति को लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) का उपयोग करें।

निम्न पूर्ण उदाहरण इनपुट डायरेक्ट्री में प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और उसी स्वरूप में आउटपुट डायरेक्ट्री में सहेजता है जिससे वह लोड हुई थी:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने वाले फ़ॉर्मैट से मैप करता है। यह केवल प्रस्तुति स्रोत फ़ॉर्मैट को मैप करता है; यह PDF, HTML, TIFF या इमेज जैसे निर्यात फ़ॉर्मैट चुनने के लिए नहीं है। असमर्थित या अवैध [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) मान पास करने पर एक [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) उत्पन्न होता है।

Legacy PPT, PPS, और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को बिना फ़ाइल एक्सटेंशन के स्ट्रीम से लोड किया जाता है, तो एक PPS या POT फ़ाइल को PPT के रूप में पहचान लिया जा सकता है। यदि इन लेगेसी उपश्रेणियों को संरक्षित रखना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मैट मेटाडेटा को अलग से रखें और आउटपुट फ़ाइलनाम व फ़ॉर्मैट चुनते समय उसका उपयोग करें।

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

एक फ़ाइल पाथ पर निर्भर हुए बिना प्रस्तुति को लिखने के लिए, एक लिखने योग्य स्ट्रीम और एक [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) मान को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को पास करें। यह तरीका उपयोगी है जब आउटपुट को वेब सर्विस से वापस करना हो, डेटाबेस में संग्रहित करना हो, या मेमोरी में प्रोसेस करना हो।

निम्न उदाहरण एक नई प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

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

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

आप PowerPoint को सहेजी गई प्रस्तुति खोलते समय प्रारंभिक दृश्य निर्धारित कर सकते हैं। सहेजने से पहले एक [ViewType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewtype/) मान के साथ [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setLastView) मेथड का उपयोग करें।

निम्न उदाहरण Slide Master दृश्य को प्रारंभिक दृश्य के रूप में कॉन्फ़िगर करता है:

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

## **स्ट्रिक्ट Office Open XML स्वरूप में प्रस्तुतियों को सहेजें**

एक PPTX फ़ाइल बनाने के लिए जो Office Open XML के स्ट्रिक्ट प्रोफ़ाइल का पालन करती हो, एक [PptxOptions](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/) इंस्टेंस बनाएं और उसके [setConformance](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setConformance) मेथड को [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hi/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) के साथ उपयोग करें। फिर विकल्पों को [Presentation.save](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#save) मेथड को पास करें।

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

## **Office Open XML स्वरूप में Zip64 मोड के साथ प्रस्तुतियों को सहेजें**

एक मानक ZIP आर्काइव प्रत्येक प्रविष्टि के संकुचित और अनसंकुचित आकार, कुल आर्काइव आकार और प्रविष्टियों की संख्या को सीमित करता है। क्योंकि PPTX फ़ाइल एक ZIP आर्काइव है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन लागू आकार और प्रविष्टि‑गणना सीमाओं को बढ़ाते हैं।

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setZip64Mode) मेथड का उपयोग करके नियंत्रित करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- [IfNecessary](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#IfNecessary) केवल तब ZIP64 का उपयोग करता है जब प्रस्तुति मानक ZIP सीमाओं को पार करती है। यह डिफ़ॉल्ट मोड है।
- [Never](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Never) ZIP64 एक्सटेंशन को अक्षम करता है।
- [Always](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Always) हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्न उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

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

{{% alert color="warning" title="Warning" %}}
यदि [Zip64Mode.Never](https://reference.aspose.com/slides/hi/python-java/aspose.slides/zip64mode/#Never) का उपयोग किया जाता है और प्रस्तुति मानक ZIP सीमाओं में नहीं फिट होती, तो सहेजने का ऑपरेशन एक [PptxException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxexception/) फेंकेगा।
{{% /alert %}}

## **Office Open XML स्वरूप में संपीड़न स्तरों के साथ प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए आप [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setCompressionLevel) मेथड का उपयोग करके सहेजने की गति और फ़ाइल आकार के बीच संतुलन बना सकते हैं। [CompressionLevel](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/) क्लास नीचे दिए गए मान प्रदान करती है:

- [None](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#None) डेटा को बिना संकुचन के संग्रहीत करता है।
- [Level1](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level1) सबसे तेज़ संकुचन और सबसे बड़ा संकुचित आउटपुट देता है।
- [Level2](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level2) से [Level5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level5) तक धीरे‑धीरे सहेजने की गति की तुलना में छोटे आउटपुट को प्राथमिकता देते हैं।
- [Level6](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level6) सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट स्तर है।
- [Level7](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level7) और [Level8](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level8) छोटे आउटपुट को और अधिक प्राथमिकता देते हैं।
- [Level9](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compressionlevel/#Level9) सबसे मजबूत संकुचन प्रदान करता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्न उदाहरण बिना संकुचन के प्रस्तुति सहेजता है:

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

निम्न उदाहरण अधिकतम संकुचन स्तर का उपयोग करता है:

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

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

जब प्रस्तुति को PPTX के रूप में सहेजा जाता है, तो [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) मेथड उसके दस्तावेज़ थंबनेल को नियंत्रित करता है:

- `True` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `False` मौजूदा थंबनेल को संरक्षित रखता है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides नया थंबनेल नहीं बनाता।

निम्न उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रस्तुति सहेजता है:

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

{{% alert color="info" title="Note" %}}
थंबनेल रीफ़्रेश को अक्षम करने से PPTX फ़ाइल को सहेजने में लगने वाले समय को घटाया जा सकता है।
{{% /alert %}}

## **सहेजने की प्रगति को प्रतिशत में रिपोर्ट करें**

सहेजने के ऑपरेशन की निगरानी के लिए, `jpype.JProxy` के माध्यम से एक Python प्रोग्रेस हैंडलर रजिस्टर करें और उसे [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveoptions/#setProgressCallback) मेथड में पास करें। Aspose.Slides तब निर्यात के दौरान प्रोग्रेस मानों के साथ हैंडलर की `reporting` मेथड को कॉल करता है।

निम्न उदाहरण PDF निर्यात की प्रगति को कंसोल में रिपोर्ट करता है:

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

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त [PowerPoint Splitter](https://products.aspose.app/slides/hi/splitter) प्रदान करता है जिसे Aspose.Slides API के साथ बनाया गया है। यह चयनित स्लाइड्स को अलग‑अलग PPT या PPTX फ़ाइलों के रूप में सहेजता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides इनक्रिमेंटल या “फास्ट सेव” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन एक संपूर्ण आउटपुट फ़ाइल लिखता है न कि केवल बदले हुए भागों को अपडेट करता है।

**क्या कई थ्रेड्स एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ नहीं है](/slides/hi/python-java/multithreading/)। प्रत्येक इंस्टेंस को केवल एक थ्रेड से ही एक्सेस और सहेजें।

**जब मैं प्रस्तुति सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक वाली फ़ाइलों के साथ क्या होता है?**

[Hyperlinks](/slides/hi/python-java/manage-hyperlinks/) प्रस्तुति में बनी रहती हैं। Aspose.Slides बाहरी लिंक वाली फ़ाइलों की कॉपी नहीं बनाता, इसलिए सहेजी गई प्रस्तुति को अभी भी उनके स्थानों तक पहुंचना होगा।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसी दस्तावेज़ मेटा‑डेटा सहेज सकता हूँ?**

हाँ। सहेजने से पहले उचित [document properties](/slides/hi/python-java/presentation-properties/) सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिख देगा।