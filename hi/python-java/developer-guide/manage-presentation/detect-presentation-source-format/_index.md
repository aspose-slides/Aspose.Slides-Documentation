---
title: "Python के माध्यम से Java में मूल प्रस्तुति स्वरूप निर्धारित करें"
linktitle: "स्रोत स्वरूप"
type: docs
weight: 35
url: /hi/python-java/detect-presentation-source-format/
keywords:
- स्रोत स्वरूप
- प्रस्तुति स्वरूप का पता लगाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ Python में लोड की गई प्रस्तुति का मूल स्वरूप पढ़ें, पहचान API की तुलना करें, और फ़ाइलों, स्ट्रीम और लेगेसी स्वरूपों को संभालें।"
---
## **अवलोकन**

एक प्रस्तुति लोड करने के बाद, उसके मूल स्वरूप को निर्धारित करने के लिए [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) मेथड को कॉल करें। इसे तब उपयोग करें जब बाद की प्रक्रिया इस बात पर निर्भर करती है कि वर्तमान इंस्टेंस किस स्वरूप में लोड किया गया था।

स्रोत स्वरूप आउटपुट फ़ाइल के लिए चुने गए [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) से अलग होता है। किसी अन्य स्वरूप में सहेजने से मौजूदा इंस्टेंस का स्रोत स्वरूप नहीं बदलता है।

उदाहरणों को Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। प्रत्येक उदाहरण JVM को शुरू करता है यदि वह पहले से चल नहीं रहा है।

## **फ़ाइल का स्रोत स्वरूप पढ़ें**

यह उदाहरण एक मौजूद `sample.pptx` फ़ाइल की आवश्यकता रखता है। यह फ़ाइल को लोड करता है और फ़ाइलनाम के बजाय [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) का उपयोग करके एप्लिकेशन प्रोसेसिंग नीति का चयन करता है। अन्य स्वरूपों को आज़माने के लिए इनपुट पथ बदलें। उदाहरण चयनित नीति को प्रिंट करता है; संदेशों को अपने एप्लिकेशन लॉजिक से बदलें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **समर्थित मानों को पहचानें**

[SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) क्लास पूर्णांक स्थिरांक परिभाषित करती है जो निम्नलिखित प्रस्तुति स्वरूपों को अलग करती हैं। नीचे दी गई एक्सटेंशन सामान्य एक्सटेंशन हैं, न कि मूल फ़ाइलनाम की पुनः निर्मिति।

| SourceFormat मान | एक्सटेंशन | स्वरूप |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint 97–2003 प्रस्तुति |
| `Pptx` | `.pptx` | Office Open XML प्रस्तुति |
| `Pptm` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रस्तुति |
| `Pps` | `.pps` | PowerPoint 97–2003 स्लाइड शो |
| `Ppsx` | `.ppsx` | Office Open XML स्लाइड शो |
| `Ppsm` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइड शो |
| `Pot` | `.pot` | PowerPoint 97–2003 टेम्पलेट |
| `Potx` | `.potx` | Office Open XML टेम्पलेट |
| `Potm` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्पलेट |
| `Odp` | `.odp` | OpenDocument प्रस्तुति |
| `Otp` | `.otp` | OpenDocument प्रस्तुति टेम्पलेट |
| `Fodp` | `.fodp` | Flat XML ODF प्रस्तुति |
| `Xml` | `.xml` | PowerPoint XML प्रस्तुति |

## **स्ट्रीम का स्रोत स्वरूप पढ़ें**

यह उदाहरण एक मौजूद `sample.pps` फ़ाइल की आवश्यकता रखता है। उसके बाइट्स को मेमोरी स्ट्रीम में पढ़ना उन इनपुट को मॉडल करता है जो फ़ाइलनाम के बिना प्राप्त होते हैं, जैसे डेटाबेस मान या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) कंस्ट्रक्टर केवल स्ट्रीम प्राप्त करता है। Python फ़ाइल बाइट्स पढ़ता है, और JPype उन्हें Java बाइट एरे में बदलता है जिससे Java मेमोरी स्ट्रीम बनता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS, और POT एक ही बाइनरी स्वरूप साझा करते हैं। फ़ाइल पथ द्वारा लोड करने पर एक्सटेंशन स्लाइड शो या टेम्पलेट को पहचानने में मदद कर सकता है। फ़ाइलनाम के बिना, लेगेसी PPS और POT सामग्री को `SourceFormat.Ppt` के रूप में रिपोर्ट किया जा सकता है; ऊपर का PPS उदाहरण `SourceFormat.Ppt` का पूर्णांक मान प्रिंट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या उपप्रकार मेटाडाटा को अलग से रखें। इन लेगेसी उपप्रकारों के लिए एक्सटेंशन एक उपयोगी संकेत है, लेकिन इसे एकमात्र पहचान आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

जब आपको फ़ाइल को पूरी प्रस्तुति ऑब्जेक्ट मॉडल लोड करने से पहले निरीक्षण करना हो तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#getLoadFormat) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो तो [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और क्रमशः `LoadFormat.Pptx` और `SourceFormat.Pptx` के पूर्णांक मान प्रिंट करता है। उत्पादन में, अपनी प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोड की गई प्रस्तुति को केवल स्रोत स्वरूप प्राप्त करने के लिए दूसरे निरीक्षण की आवश्यकता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

परिणाम विभिन्न क्लासों के स्थिरांक उपयोग करते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/)। उनके संख्यात्मक मानों की तुलना न करें और न ही मानें कि हर स्वरूप के पहचान परिणाम समान होते हैं। PowerPoint XML को लोड करने से पहले `LoadFormat.Unknown` और लोड करने के बाद `SourceFormat.Xml` के रूप में रिपोर्ट किया जा सकता है।

## **स्रोत और आउटपुट स्वरूपों को अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सहेजने से पहले और बाद दोनों में `SourceFormat.Pptx` का पूर्णांक मान प्रिंट करता है। केवल ODP आउटपुट से लोड किया गया नया इंस्टेंस `Odp` रिपोर्ट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

`Presentation()` से शून्य से बनाई गई प्रस्तुति `SourceFormat.Pptx` रिपोर्ट करती है। इसका कोई इनपुट फ़ाइल नहीं है: यह नए बनाए गए इंस्टेंस का डिफ़ॉल्ट मान है, न कि यह संकेत कि कोई PPTX फ़ाइल लोड हुई थी। यदि यह अंतर आपके लिए महत्वपूर्ण है तो अपने एप्लिकेशन में यह ट्रैक रखें कि इंस्टेंस बनाया गया या लोड किया गया।

## **स्रोत स्वरूप को एक्सटेंशन से मैप करें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है। यह वर्तमान में समर्थित प्रत्येक [SourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/sourceformat/) मान को एक पारम्परिक एक्सटेंशन से मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। fallback अनपहचाने मान को चुपचाप एक्सटेंशन असाइन करने से बचाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

यह मैपिंग फ़ाइल को परिवर्तित नहीं करती और स्ट्रीम लोडिंग के दौरान खोए लेगेसी PPS/POT उपप्रकार को पुनः प्राप्त नहीं करती। वास्तविक सहेजने के लिए, किसी [SaveFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/saveformat/) को स्पष्ट रूप से चुनें, या [Save Presentations in Their Original Format](/slides/hi/python-java/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सहेजकर और पुनः खोलकर स्वरूपों की जाँच करें**

यह आत्मनिर्भर उदाहरण एक प्रस्तुति बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नामों वाली फ़ाइलों को अधिलेखित करता है। यह प्रत्येक आउटपुट को पथ द्वारा और मेमोरी स्ट्रीम के माध्यम से दोबारा खोलता है। PPTX और ODP के लिए, दोनों मार्ग सहेजे गए स्वरूप को रिपोर्ट करते हैं। PPS के लिए, पथ द्वारा लोड करने पर `Pps` रिपोर्ट होता है, जबकि बिना फ़ाइलनाम के वही बाइट्स लोड करने पर `Ppt` रिपोर्ट होता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

निम्न तालिका मिलते-जुलते एक्सटेंशन वाले प्रस्तुतियों के लिए स्रोत‑स्वरूप पहचान का सार प्रस्तुत करती है। नाम स्थिरांक दर्शाते हैं; Python उदाहरण उनके पूर्णांक मान प्रिंट करते हैं:

| सहेजा गया स्वरूप | फ़ाइल पथ से SourceFormat | नामरहित स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | क्रमशः `Pptx`, `Pptm` | फ़ाइल पथ जैसा ही |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | क्रमशः `Ppsx`, `Ppsm` | फ़ाइल पथ जैसा ही |
| POT | `Pot` | `Ppt` |
| POTX, POTM | क्रमशः `Potx`, `Potm` | फ़ाइल पथ जैसा ही |
| ODP, OTP | क्रमशः `Odp`, `Otp` | फ़ाइल पथ जैसा ही |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT सामग्री नामरहित स्ट्रीम के लिए `Ppt` के रूप में पहचानती है। तालिका स्वरूप पहचान को दर्शाती है, न कि रूपांतरण के दौरान हर प्रस्तुति विशेषता का संधारण।

## **प्रायः पूछे जाने वाले प्रश्न**

**क्या PPTX से लोड की गई प्रस्तुति को ODP में सहेजना स्रोत स्वरूप बदलता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `Pptx` रिपोर्ट करता है। सहेजी गई ODP फ़ाइल से लोड किया गया इंस्टेंस `Odp` रिपोर्ट करता है।

**क्या स्ट्रीम हमेशा एक लेगेसी प्रस्तुति, स्लाइड शो और टेम्पलेट को अलग कर सकती है?**

नहीं। PPT, PPS, और POT बाइनरी स्वरूप साझा करते हैं। जब उस अंतर की आवश्यकता हो तो फ़ाइलनाम या उपप्रकार मेटाडाटा को अलग रखिए।

**यदि प्रस्तुति पहले ही लोड हो चुकी है तो मुझे कौन सा API उपयोग करना चाहिए?**

प्रस्तुति के स्रोत स्वरूप के लिए [Presentation.getSourceFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSourceFormat) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) उपयोग करें।