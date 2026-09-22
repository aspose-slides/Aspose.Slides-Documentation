---
title: Python में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुति सहेजें
type: docs
weight: 80
url: /hi/python-net/save-presentation/
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
- थंबनेल रीफ़्रेश
- सहेजने की प्रगति
- Python
- Aspose.Slides
description: "Aspose.Slides के साथ Python में PowerPoint और OpenDocument प्रस्तुतियों को फ़ाइलों या स्ट्रीम में सहेजें, और PPTX आउटपुट विकल्पों को कॉन्फ़िगर करें।"
---
## **सारांश**

जब आप एक प्रस्तुति बनाते हैं या मौजूदा प्रस्तुति खोलते हैं, तो परिणाम लिखने के लिए Presentation.save मेथड का उपयोग करें। Aspose.Slides for Python via .NET प्रस्तुति को PowerPoint, OpenDocument, PDF और अन्य फ़ॉर्मैट में फ़ाइल या स्ट्रीम में सहेज सकता है। निम्नलिखित अनुभाग मानक सहेजने के ऑपरेशनों और PPTX आउटपुट के लिए उपलब्ध विकल्पों को कवर करते हैं।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को फ़ाइल में सहेजने के लिए, आउटपुट पाथ और एक SaveFormat मान को Presentation.save मेथड में पास करें। फ़ॉर्मेट मान निर्धारित करता है कि Aspose.Slides कौन‑सी फ़ाइल प्रकार बनाएगा।

निम्नलिखित उदाहरण एक प्रस्तुति बनाता है और उसे PPTX फ़ाइल के रूप में सहेजता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # प्रस्तुति सामग्री यहाँ जोड़ें या संशोधित करें।

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **अपनी मूल फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

फ़ाइल और स्ट्रीम डिटेक्शन उदाहरणों, नई बनाई गई प्रस्तुतियों के व्यवहार, और स्रोत व आउटपुट फ़ॉर्मेट के अंतर के लिए देखें [मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें](/slides/hi/python-net/detect-presentation-source-format/)।

बैच‑प्रोसेसिंग एप्लिकेशन में इनपुट फ़ॉर्मेट पहले से ज्ञात नहीं हो सकता। फ़ाइल लोड करने के बाद, उसके मूल फ़ॉर्मेट को Presentation.source_format प्रॉपर्टी से पढ़ें। प्राप्त SourceFormat मान को SlideUtil.to_save_format को पास करें ताकि संबंधित SaveFormat मान प्राप्त हो, और फिर Presentation.save का उपयोग करके संशोधित प्रस्तुति लिखें।

निम्नलिखित संपूर्ण उदाहरण इनपुट निर्देशिका की प्रत्येक फ़ाइल को प्रोसेस करता है, उसका शीर्षक अपडेट करता है, और उसी फ़ॉर्मेट में आउटपुट निर्देशिका में सहेजता है जिससे वह लोड हुई थी:

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](/slides/hi/python-net/aspose.slides.util/slideutil/to_save_format/) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP और PowerPoint XML को उनके संबंधित प्रस्तुति सहेजने फ़ॉर्मेट में मैप करता है। यह केवल प्रस्तुति स्रोत फ़ॉर्मेट को मैप करता है; PDF, HTML, TIFF या छवियों जैसे एक्सपोर्ट फ़ॉर्मेट चुनने के लिए नहीं है। असमर्थित या अमान्य SourceFormat मान पास करने पर अपवाद उत्पन्न होता है।

Legacy PPT, PPS और POT फ़ाइलें समान बाइनरी कंटेनर का उपयोग करती हैं। जब ऐसी प्रस्तुति को बिना फ़ाइल एक्सटेंशन के स्ट्रीम से लोड किया जाता है, तो PPS या POT फ़ाइल को PPT के रूप में पहचाना जा सकता है। यदि इन पुरानी उपप्रकारों को संरक्षित रखना आवश्यक है, तो मूल फ़ाइलनाम या फ़ॉर्मेट मेटाडेटा को अलग से रखते हुए आउटपुट फ़ाइलनाम और फ़ॉर्मेट चुनते समय उपयोग करें।

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

एक प्रस्तुति को अंतिम फ़ाइल पाथ पर निर्भर किए बिना लिखने के लिए, एक लिखने योग्य BinaryIO स्ट्रीम और एक SaveFormat मान को Presentation.save मेथड में पास करें। यह विधि तब उपयोगी होती है जब आउटपुट को वेब सेवा से वापस करना हो, डेटाबेस में संग्रहीत करना हो या मेमोरी में प्रोसेस करना हो।

निम्नलिखित उदाहरण नए प्रस्तुति को फ़ाइल स्ट्रीम में सहेजता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **पूर्वनिर्धारित व्यू टाइप के साथ प्रस्तुतियों को सहेजें**

आप सहेजी गई प्रस्तुति को PowerPoint प्रारंभिक रूप से किस व्यू में खोलता है, यह निर्धारित कर सकते हैं। सहेजने से पहले ViewProperties.last_view प्रॉपर्टी को एक ViewType मान पर सेट करें।

निम्नलिखित उदाहरण स्लाइड मास्टर व्यू को प्रारंभिक व्यू के रूप में कॉन्फ़िगर करता है:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **स्ट्रिक्ट Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Strict प्रोफ़ाइल के अनुरूप PPTX फ़ाइल बनाने के लिए, एक PptxOptions इंस्टेंस बनाकर उसकी conformance प्रॉपर्टी को `Conformance.ISO_29500_2008_STRICT` पर सेट करें। फिर विकल्पों को Presentation.save मेथड में पास करें।

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक मानक ZIP अभिलेख प्रत्येक प्रविष्टि, कुल अभिलेख और प्रविष्टियों की संख्या पर आकार सीमा लगाता है। चूँकि PPTX फ़ाइल एक ZIP अभिलेख है, बहुत बड़ी प्रस्तुति इन सीमाओं को पार कर सकती है। ZIP64 एक्सटेंशन इन सीमाओं को बढ़ाते हैं।

PptxOptions.zip_64_mode प्रॉपर्टी का उपयोग करके तय करें कि Aspose.Slides ZIP64 एक्सटेंशन लिखे या नहीं:

- `IF_NECESSARY` केवल तब ZIP64 उपयोग करता है जब प्रस्तुति मानक ZIP सीमाओं से अधिक हो। यह डिफ़ॉल्ट मोड है।
- `NEVER` ZIP64 एक्सटेंशन को निष्क्रिय करता है।
- `ALWAYS` हमेशा ZIP64 एक्सटेंशन लिखता है।

निम्नलिखित उदाहरण आउटपुट प्रस्तुति के लिए हमेशा ZIP64 एक्सटेंशन सक्षम करता है:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
यदि `Zip64Mode.NEVER` का उपयोग किया जाता है और प्रस्तुति मानक ZIP सीमाओं में नहीं फिट होती, तो सहेजने का काम एक PptxException उत्पन्न करता है।
{{% /alert %}}

## **संपीड़न स्तरों के साथ Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

PPTX आउटपुट के लिए, आप सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाने के लिए PptxOptions.compression_level प्रॉपर्टी सेट कर सकते हैं। CompressionLevel एन्यूमरेशन निम्नलिखित मान प्रदान करता है:

- `NONE` बिना संपीड़न के डेटा संग्रहित करता है।
- `LEVEL1` सबसे तेज़ संपीड़न और सबसे बड़ा संपीड़ित आउटपुट देता है।
- `LEVEL2` से `LEVEL5` क्रमशः छोटे आउटपुट के पक्ष में अधिक संपीड़न प्रदान करते हैं।
- `LEVEL6` सहेजने की गति और फ़ाइल आकार के बीच संतुलन बनाता है। यह डिफ़ॉल्ट स्तर है।
- `LEVEL7` और `LEVEL8` छोटे आउटपुट के पक्ष में तेज़ सहेजने की गति पर बल देते हैं।
- `LEVEL9` सबसे मजबूत संपीड़न देता है और सबसे अधिक प्रोसेसिंग समय लेता है।

निम्नलिखित उदाहरण संपीड़न के बिना प्रस्तुति सहेजता है:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

निम्नलिखित उदाहरण अधिकतम संपीड़न स्तर का उपयोग करता है:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **थंबनेल रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

जब प्रस्तुति को PPTX के रूप में सहेजा जाता है, तो PptxOptions.refresh_thumbnail प्रॉपर्टी दस्तावेज़ थंबनेल को नियंत्रित करती है:

- `True` सहेजने के दौरान थंबनेल को पुनः उत्पन्न करता है। यह डिफ़ॉल्ट मान है।
- `False` मौजूदा थंबनेल को बरकरार रखता है। यदि प्रस्तुति में थंबनेल नहीं है, तो Aspose.Slides कोई नया थंबनेल नहीं बनाता।

निम्नलिखित उदाहरण थंबनेल को रीफ़्रेश किए बिना प्रस्तुति सहेजता है:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
थंबनेल रीफ़्रेश को अक्षम करने से PPTX फ़ाइल को सहेजने में लगने वाले समय को घटाया जा सकता है।
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त PowerPoint Splitter प्रदान करता है जो Aspose.Slides API द्वारा निर्मित है। यह प्रस्तुति से चयनित स्लाइड्स को अलग‑अलग PPT या PPTX फ़ाइलों में सहेजता है।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides इन्क्रिमेंटल या “फ़ास्ट सेव” का समर्थन करता है?**

नहीं। प्रत्येक सहेजने का ऑपरेशन पूरी आउटपुट फ़ाइल लिखता है, न कि केवल बदलें हुए भागों को अद्यतन करता है।

**क्या कई थ्रेड एक ही Presentation इंस्टेंस को सहेज सकते हैं?**

नहीं। एक Presentation इंस्टेंस थ्रेड‑सेफ़ नहीं है। प्रत्येक इंस्टेंस को केवल एक थ्रेड से ही एक्सेस और सहेजा जाए।

**जब मैं प्रस्तुति सहेजता हूँ तो हाइपरलिंक और बाहरी लिंक वाली फ़ाइलें क्या होती हैं?**

[हाइपरलिंक](/slides/hi/python-net/manage-hyperlinks/) प्रस्तुति में बने रहते हैं। Aspose.Slides बाहरी लिंक वाली फ़ाइलों की प्रतिलिपि नहीं बनाता, इसलिए सहेजी गई प्रस्तुति को अभी भी उनके स्थान तक पहुँचने में सक्षम होना चाहिए।

**क्या मैं लेखक, शीर्षक, कंपनी और निर्माण तिथि जैसे दस्तावेज़ मेटाडेटा सहेज सकता हूँ?**

हाँ। सहेजने से पहले उपयुक्त दस्तावेज़ प्रॉपर्टीज़ सेट करें, और Aspose.Slides उन्हें आउटपुट फ़ाइल में लिख देगा।