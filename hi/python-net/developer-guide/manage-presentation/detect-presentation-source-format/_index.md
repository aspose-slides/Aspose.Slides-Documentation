---
title: "Python में मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें"
linktitle: "स्रोत फ़ॉर्मेट"
type: docs
weight: 35
url: /hi/python-net/detect-presentation-source-format/
keywords:
- "स्रोत फ़ॉर्मेट"
- "प्रेजेंटेशन फ़ॉर्मेट का पता लगाएँ"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- "PPT"
- "PPTX"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET के साथ Python में लोड किए गए प्रेजेंटेशन का मूल फ़ॉर्मेट पढ़ें, पहचान API की तुलना करें, और फ़ाइलों, स्ट्रीम और लेगेसी फ़ॉर्मेट को संभालें।"
---
## **सारांश**

प्रेजेंटेशन को लोड करने के बाद, उसकी मूल फ़ॉर्मेट निर्धारित करने के लिए केवल‑पढ़ने योग्य [Presentation.source_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/source_format/) प्रॉपर्टी को पढ़ें। जब बाद के प्रोसेसिंग को इस फ़ॉर्मेट पर निर्भर होना हो जो वर्तमान इंस्टेंस लोड किया गया था, तब इसका उपयोग करें।

स्रोत फ़ॉर्मेट आउटपुट फ़ाइल के लिए चुने गए [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) से अलग होता है। किसी अन्य फ़ॉर्मेट में सेव करने से मौजूदा इंस्टेंस का स्रोत फ़ॉर्मेट नहीं बदलता।

## **फ़ाइल का स्रोत फ़ॉर्मेट पढ़ें**

इस उदाहरण के लिए एक मौजूदा `sample.pptx` फ़ाइल की आवश्यकता होती है। यह फ़ाइल को लोड करता है और फ़ाइलनाम के बजाय [Presentation.source_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/source_format/) का उपयोग करके एक एप्लिकेशन प्रोसेसिंग नीति चुनता है। अन्य फ़ॉर्मेट आज़माने के लिए इनपुट पाथ बदलें। उदाहरण चुनी हुई नीति को प्रिंट करता है; संदेशों को अपनी एप्लिकेशन लॉजिक से बदलें।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **समर्थित मानों को पहचानें**

[SourceFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sourceformat/) एनेमरेशन निम्नलिखित प्रेजेंटेशन फ़ॉर्मेट को अलग करता है। नीचे दिए गए एक्सटेंशन सामान्य एक्सटेंशन हैं, मूल फ़ाइलनाम का पुनर्निर्माण नहीं हैं।

| SourceFormat मान | एक्सटेंशन | फ़ॉर्मेट |
| --- | --- | --- |
| `PPT` | `.ppt` | PowerPoint 97–2003 प्रेजेंटेशन |
| `PPTX` | `.pptx` | Office Open XML प्रेजेंटेशन |
| `PPTM` | `.pptm` | मैक्रो‑सक्षम Office Open XML प्रेजेंटेशन |
| `PPS` | `.pps` | PowerPoint 97–2003 स्लाइडशो |
| `PPSX` | `.ppsx` | Office Open XML स्लाइडशो |
| `PPSM` | `.ppsm` | मैक्रो‑सक्षम Office Open XML स्लाइडशो |
| `POT` | `.pot` | PowerPoint 97–2003 टेम्पलेट |
| `POTX` | `.potx` | Office Open XML टेम्पलेट |
| `POTM` | `.potm` | मैक्रो‑सक्षम Office Open XML टेम्पलेट |
| `ODP` | `.odp` | OpenDocument प्रेजेंटेशन |
| `OTP` | `.otp` | OpenDocument प्रेजेंटेशन टेम्पलेट |
| `FODP` | `.fodp` | Flat XML ODF प्रेजेंटेशन |
| `XML` | `.xml` | PowerPoint XML प्रेजेंटेशन |

## **स्ट्रीम का स्रोत फ़ॉर्मेट पढ़ें**

इस उदाहरण के लिए एक मौजूदा `sample.pps` फ़ाइल की आवश्यकता होती है। उसकी बाइट्स को मेमोरी स्ट्रीम में पढ़ना उस इनपुट को मॉडल करता है जो फ़ाइलनाम के बिना प्राप्त होता है, जैसे डेटाबेस वैल्यू या अपलोड किया गया बाइट एरे। [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) कन्स्ट्रक्टर केवल स्ट्रीम प्राप्त करता है।

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS, और POT एक ही बाइनरी फ़ॉर्मेट साझा करते हैं। जब फ़ाइल पाथ से लोड किया जाता है, तो एक्सटेंशन स्लाइडशो या टेम्पलेट को अलग करने में मदद कर सकता है। फ़ाइलनाम के बिना, लेगेसी PPS और POT सामग्री को `SourceFormat.PPT` के रूप में रिपोर्ट किया जा सकता है; ऊपर का PPS उदाहरण `PPT` रिपोर्ट करता है।

यदि आपके एप्लिकेशन को यह अंतर बनाए रखना आवश्यक है, तो मूल फ़ाइलनाम या उप‑प्रकार मेटाडेटा को अलग से रखें। इन लेगेसी उप‑प्रकारों के लिए एक्सटेंशन एक उपयोगी संकेत है, लेकिन इसे एकमात्र आधार नहीं बनाना चाहिए।

## **लोड करने से पहले और बाद में पहचान की तुलना करें**

फ़ाइल को पूरी प्रेजेंटेशन ऑब्जेक्ट मॉडल में लोड करने से पहले निरीक्षण करने के लिए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) और [PresentationInfo.load_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/load_format/) का उपयोग करें। जब इंस्टेंस पहले से मौजूद हो तो [Presentation.source_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/source_format/) का उपयोग करें।

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और दोनों जाँचों के लिए `PPTX` प्रिंट करता है। प्रोडक्शन में अपने प्रोसेसिंग चरण के अनुसार उपयुक्त API चुनें; पहले से लोड किया गया प्रेजेंटेशन केवल स्रोत फ़ॉर्मेट प्राप्त करने के लिए दूसरी जाँच की आवश्यकता नहीं रखता।

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

परिणाम अलग‑अलग एनेमरेशन टाइप्स होते हैं: [LoadFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/loadformat/) और [SourceFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sourceformat/)। उन्हें उनके न्यूमेरिक मानों को कास्ट करके तुलना न करें या यह न मानें कि हर फ़ॉर्मेट के detection परिणाम समान होंगे। नीचे वर्णित save‑and‑reopen जाँच में PowerPoint XML को लोड करने से पहले `LoadFormat.UNKNOWN` और लोड करने के बाद `SourceFormat.XML` रिपोर्ट किया गया।

## **स्रोत और आउटपुट फ़ॉर्मेट अलग रखें**

यह उदाहरण `sample.pptx` की आवश्यकता रखता है और `converted.odp` लिखता है। यह मूल इंस्टेंस को सेव करने से पहले और बाद दोनों बार `PPTX` प्रिंट करता है। केवल ODP आउटपुट से लोड किया गया नया इंस्टेंस `ODP` रिपोर्ट करता है।

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

`slides.Presentation()` से शून्य से बनाया गया प्रेजेंटेशन `SourceFormat.PPTX` रिपोर्ट करता है। इसका कोई इनपुट फ़ाइल नहीं है: यह नई बनाई गई इंस्टेंस का डिफ़ॉल्ट मान है, यह प्रमाण नहीं कि PPTX फ़ाइल लोड हुई थी। यदि आपके लिए यह अंतर महत्वपूर्ण है तो यह अलग‑अलग ट्रैक करें कि आपका एप्लिकेशन इंस्टेंस को बनाया या लोड किया।

## **स्रोत फ़ॉर्मेट को एक्सटेंशन में मैप करें**

निम्नलिखित उदाहरण `sample.pptx` की आवश्यकता रखता है। यह प्रत्येक वर्तमान में समर्थित [SourceFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides/sourceformat/) मान को एक सामान्य एक्सटेंशन में मैप करता है, बिना इनपुट फ़ाइलनाम को पार्स किए। फॉलबैक अनपहचाने मान को चुपचाप एक्सटेंशन असाइन करने से बचता है।

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

यह मैपिंग फ़ाइल को परिवर्तित नहीं करती या स्ट्रीम लोडिंग के दौरान खोए लेगेसी PPS/POT उप‑प्रकार को पुनर्स्थापित नहीं करती। वास्तविक सेविंग के लिए, स्पष्ट रूप से एक [SaveFormat](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/saveformat/) चुनें, या [Save Presentations in Their Original Format](/slides/hi/python-net/save-presentation/#save-presentations-in-their-original-format) में दिखाए गए रूपांतरण का उपयोग करें।

## **सेव करके और पुनः खोलकर फ़ॉर्मेट की पुष्टि करें**

यह स्व-विषयक उदाहरण एक प्रेजेंटेशन बनाता है और कार्य निर्देशिका में तीन फ़ाइलें लिखता है, समान नाम वाली फ़ाइलों को ओवरराइट करता है। यह प्रत्येक आउटपुट को पाथ और मेमोरी स्ट्रीम दोनों से फिर से खोलता है। PPTX और ODP के लिए, दोनों मार्ग सेव किए गए फ़ॉर्मेट को रिपोर्ट करते हैं। PPS के लिए, पाथ से लोड करने पर `PPS` रिपोर्ट होता है, जबकि वही बाइट्स बिना फ़ाइलनाम के लोड करने पर `PPT` रिपोर्ट होता है।

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

उपरोक्त सभी फ़ॉर्मेट्स के साथ किया गया समान चेक उत्पन्न प्रेजेंटेशन में मेल खाने वाले एक्सटेंशन के साथ निम्नलिखित परिणाम देता है:

| सेव किया गया फ़ॉर्मेट | फ़ाइल पथ से SourceFormat | नामहीन स्ट्रीम से SourceFormat |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` क्रमशः | फ़ाइल पथ जैसा ही |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` क्रमशः | फ़ाइल पथ जैसा ही |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` क्रमशः | फ़ाइल पथ जैसा ही |
| ODP, OTP | `ODP`, `OTP` क्रमशः | फ़ाइल पथ जैसा ही |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

इन जाँचों में, नामहीन स्ट्रीम के लिए केवल स्रोत‑फ़ॉर्मेट नॉर्मलाइज़ेशन PPS/POT को `PPT` में बदलना था। तालिका फ़ॉर्मेट पहचान का वर्णन करती है, न कि परिवर्तन के दौरान हर प्रेजेंटेशन फीचर को संरक्षित करने का।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या PPTX से लोड किए गए प्रेजेंटेशन को ODP में सेव करने से स्रोत फ़ॉर्मेट बदल जाता है?**

नहीं। मौजूदा इंस्टेंस अभी भी `PPTX` रिपोर्ट करता है। सेव किए गए ODP फ़ाइल से लोड किया गया इंस्टेंस `ODP` रिपोर्ट करता है।

**क्या एक स्ट्रीम हमेशा लेगेसी प्रेजेंटेशन, स्लाइडशो और टेम्पलेट को अलग पहचान सकती है?**

नहीं। PPT, PPS, और POT बाइनरी फ़ॉर्मेट साझा करते हैं। जब यह अंतर आवश्यक हो तो फ़ाइलनाम या उप‑प्रकार मेटाडेटा को अलग से रखें।

**यदि प्रेजेंटेशन पहले से लोड किया गया है तो कौन सा API उपयोग करना चाहिए?**

[Presentation.source_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/source_format/) पढ़ें। लोड करने से पहले निरीक्षण के लिए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें।