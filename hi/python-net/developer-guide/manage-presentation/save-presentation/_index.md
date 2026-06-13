---
title: Python में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुतियों को सहेजें
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
- पूर्वनिर्धारित दृश्य प्रकार
- स्ट्रिक्ट Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में प्रस्तुतियों को कैसे सहेजें—PowerPoint या OpenDocument में निर्यात करते समय लेआउट, फ़ॉन्ट और इफ़ेक्ट्स को बनाए रखें।"
---
## **अवलोकन**

[Python में प्रस्तुति खोलें](/slides/hi/python-net/open-presentation/) ने बताया कि कैसे [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति खोली जा सकती है। यह लेख बताता है कि कैसे प्रस्तुतियों को बनाया और सहेजा जाए। [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री रहती है। चाहे आप शुरू से प्रस्तुति बना रहे हों या मौजूदा को संशोधित कर रहे हों, समाप्ति पर उसे सहेजना आवश्यक है। Aspose.Slides for Python के साथ आप **file** या **stream** में सहेज सकते हैं। यह लेख प्रस्तुतियों को सहेजने के विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

`save` मेथड को कॉल करके प्रस्तुति को फ़ाइल में सहेजें। मेथड में फ़ाइल का नाम और सहेजने का फ़ॉर्मेट पास करें। नीचे दिया गया उदाहरण Aspose.Slides for Python के साथ प्रस्तुति को सहेजने का तरीका दर्शाता है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    
    # यहाँ कुछ कार्य करें...

    # प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास के `save` मेथड में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे दिए उदाहरण में हम नई प्रस्तुति बनाते हैं, एक आकार में पाठ जोड़ते हैं, और उसे स्ट्रीम में सहेजते हैं।

```py
import aspose.slides as slides

# प्रस्तुतिक फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides for Python आपको वह प्रारंभिक दृश्य सेट करने देता है जो PowerPoint द्वारा उत्पन्न प्रस्तुति के खुले समय उपयोग किया जाता है, यह कार्य [ViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) क्लास के माध्यम से किया जाता है। `last_view` प्रॉपर्टी को [ViewType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewtype/) एन्ह्यूमरेशन के किसी मान पर सेट करें।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **स्ट्रिक्ट Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजने की सुविधा देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/) क्लास का उपयोग करके उसकी `conformance` प्रॉपर्टी सेट करें। यदि आप `Conformance.ISO_29500_2008_STRICT` सेट करते हैं, तो आउटपुट फ़ाइल स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजी जाएगी।

नीचे दिया गया उदाहरण एक प्रस्तुति बनाता है और उसे स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजता है।

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
with slides.Presentation() as presentation:
    # प्रस्तुति को स्ट्रिक्ट Office Open XML फ़ॉर्मेट में सहेजें।
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **ZIP64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Office Open XML फ़ाइल एक ZIP आर्काइव होती है जिसमें अनकम्प्रेस्ड फ़ाइल आकार, कम्प्रेस्ड फ़ाइल आकार और कुल आर्काइव आकार पर 4 GB (2^32 बाइट) की सीमा होती है तथा अधिकतम 65 535 (2^16‑1) फ़ाइलें रखी जा सकती हैं। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ा देता है।

[​PptxOptions.zip_64_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) प्रॉपर्टी आपको Office Open XML फ़ाइल को सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन कब उपयोग करना है, चुनने देती है।

यह प्रॉपर्टी निम्नलिखित मोड प्रदान करती है:

- `IF_NECESSARY` केवल तभी ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं को पार कर जाए। यह डिफ़ॉल्ट मोड है।
- `NEVER` ZIP64 फ़ॉर्मेट एक्सटेंशन कभी उपयोग नहीं करता।
- `ALWAYS` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन उपयोग करता है।

नीचे दिया गया कोड दिखाता है कि कैसे ZIP64 फ़ॉर्मेट एक्सटेंशन सक्रिय कर PPTX के रूप में प्रस्तुति सहेजी जाए:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
जब आप `Zip64Mode.NEVER` के साथ सहेजते हैं, तो यदि प्रस्तुति ZIP32 फ़ॉर्मेट में सहेजी नहीं जा सकती है, तो एक [PptxException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxexception/) उत्पन्न होता है।
{{% /alert %}}

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[​PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) प्रॉपर्टी PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करती है:

- यदि इसे `True` पर सेट किया जाता है, तो सहेजने के दौरान थंबनेल रीफ़्रेश होता है। यह डिफ़ॉल्ट है।
- यदि इसे `False` पर सेट किया जाता है, तो मौजूदा थंबनेल बरकरार रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई नया नहीं बनाया जाता।

नीचे दिए कोड में प्रस्तुति को PPTX में थंबनेल रीफ़्रेश किए बिना सहेजा गया है।

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
यह विकल्प PPTX फ़ॉर्मेट में प्रस्तुति सहेजने के समय लगने वाले समय को कम करने में मदद करता है।
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter ऐप](/products/aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइड्स को नई PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **FAQ**

**क्या "फास्ट सेव" (इन्क्रिमेंटल सेव) समर्थित है ताकि केवल परिवर्तन ही लिखे जाएँ?**

नहीं। सहेजने पर हर बार पूर्ण लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "फास्ट सेव" समर्थित नहीं है।

**क्या कई थ्रेड्स से एक ही Presentation इंस्टेंस को सहेजना थ्रेड‑सेफ़ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ़ नहीं है](/slides/hi/python-net/multithreading/); इसे केवल एक थ्रेड से सहेजें।

**सहेजने पर हाइपरलिंक और बाहरी रूप से जुड़े फ़ाइलों का क्या होता है?**

[हाइपरलिंक्स](/slides/hi/python-net/manage-hyperlinks/) बरकरार रहते हैं। बाहरी रूप से जुड़े फ़ाइलें (जैसे सापेक्ष पथ वाले वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पथ उपलब्ध रहें।

**क्या मैं डॉक्यूमेंट मेटा‑डेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हाँ। मानक [डॉक्यूमेंट प्रॉपर्टीज़](/slides/hi/python-net/presentation-properties/) समर्थित हैं और सहेजते समय फ़ाइल में लिखी जाती हैं।