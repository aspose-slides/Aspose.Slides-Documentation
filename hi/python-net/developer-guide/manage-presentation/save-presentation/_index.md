---
title: Python में प्रस्तुतियों को सहेजें
linktitle: प्रस्तुतियों को सहेजें
type: docs
weight: 80
url: /hi/python-net/save-presentation/
keywords:
- PowerPoint को सहेजें
- OpenDocument को सहेजें
- प्रस्तुति सहेजें
- स्लाइड सहेजें
- PPT सहेजें
- PPTX सहेजें
- ODP सहेजें
- फ़ाइल में प्रस्तुति
- स्ट्रीम में प्रस्तुति
- पूर्वनिर्धारित दृश्य प्रकार
- सख्त Office Open XML फ़ॉर्मेट
- Zip64 मोड
- थंबनेल रीफ़्रेश करना
- सहेजने की प्रगति
- Python
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Python में प्रस्तुतियों को कैसे सहेजें, यह जानें - PowerPoint या OpenDocument में निर्यात करते हुए लेआउट, फ़ॉन्ट और प्रभावों को बनाए रखें।"
---
## **अवलोकन**

[Python में एक प्रस्तुति खोलें](/slides/hi/python-net/open-presentation/) ने बताया कि कैसे [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति खोलें। यह लेख बताता है कि प्रस्तुति कैसे बनाएं और सहेजें। [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास में प्रस्तुति की सामग्री होती है। चाहे आप शुरुआत से प्रस्तुति बना रहे हों या मौजूदा को बदल रहे हों, समाप्ति पर उसे सहेजना आवश्यक है। Aspose.Slides for Python के साथ आप **फ़ाइल** या **स्ट्रीम** में सहेज सकते हैं। यह लेख विभिन्न तरीकों को समझाता है।

## **फ़ाइलों में प्रस्तुतियों को सहेजें**

फ़ाइल में प्रस्तुति सहेजने के लिए [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की `save` विधि को कॉल करें। विधि को फ़ाइल नाम और सहेजने के फ़ॉर्मेट पास करें। निम्न उदाहरण दर्शाता है कि Aspose.Slides for Python के साथ प्रस्तुति को कैसे सहेजें।

```py
import aspose.slides as slides

# एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:
    
    # यहाँ कुछ काम करें...

    # प्रस्तुति को फ़ाइल में सहेजें।
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **स्ट्रीम में प्रस्तुतियों को सहेजें**

आप आउटपुट स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) क्लास की `save` विधि में पास करके प्रस्तुति को स्ट्रीम में सहेज सकते हैं। एक प्रस्तुति को कई प्रकार की स्ट्रीम में लिखा जा सकता है। नीचे दिए गए उदाहरण में, हम नई प्रस्तुति बनाते हैं और उसे फ़ाइल स्ट्रीम में सहेजते हैं।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # प्रस्तुति को स्ट्रीम में सहेजें।
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **पूर्वनिर्धारित दृश्य प्रकार के साथ प्रस्तुतियों को सहेजें**

Aspose.Slides for Python आपको उत्पन्न प्रस्तुति के खुले समय PowerPoint द्वारा उपयोग किए जाने वाले प्रारंभिक दृश्य को [ViewProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewproperties/) क्लास के माध्यम से सेट करने देता है। `last_view` प्रॉपर्टी को [ViewType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/viewtype/) एन्यूमरेशन के एक मान पर सेट करें।

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **सख्त Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

Aspose.Slides आपको प्रस्तुति को सख्त Office Open XML फ़ॉर्मेट में सहेजने की अनुमति देता है। सहेजते समय [PptxOptions](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/) क्लास का उपयोग करें और उसकी conformance प्रॉपर्टी सेट करें। यदि आप `Conformance.ISO_29500_2008_STRICT` सेट करते हैं, तो आउटपुट फ़ाइल सख्त Office Open XML फ़ॉर्मेट में सहेजी जाती है।

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को बनाएं।
with slides.Presentation() as presentation:
    # प्रस्तुति को सख्त Office Open XML फ़ॉर्मेट में सहेजें।
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Zip64 मोड में Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

एक Office Open XML फ़ाइल ZIP अभिलेख है जो किसी भी फ़ाइल के अनकम्प्रेस्ड आकार, कम्प्रेस्ड आकार तथा कुल आकार पर 4 GB (2^32 बाइट) की सीमा लगाता है, और अभिलेख में फ़ाइलों की संख्या 65 535 (2^16‑1) तक सीमित करता है। ZIP64 फ़ॉर्मेट एक्सटेंशन इन सीमाओं को 2^64 तक बढ़ाते हैं।

[PptxOptions.zip_64_mode](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) प्रॉपर्टी आपको Office Open XML फ़ाइल सहेजते समय ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग कब करना है, चुनने देती है।

यह प्रॉपर्टी निम्न मोड प्रदान करती है:

- `IF_NECESSARY` केवल तब ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है जब प्रस्तुति ऊपर दी गई सीमाओं को पार कर जाए। यह डिफ़ॉल्ट मोड है।
- `NEVER` कभी भी ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग नहीं करता।
- `ALWAYS` हमेशा ZIP64 फ़ॉर्मेट एक्सटेंशन का उपयोग करता है।

निचे दिया गया कोड एक PPTX फ़ाइल को ZIP64 फ़ॉर्मेट एक्सटेंशन के साथ सहेजने का उदाहरण दिखाता है:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
जब आप `Zip64Mode.NEVER` के साथ सहेजते हैं, तो यदि प्रस्तुति को ZIP32 फ़ॉर्मेट में सहेजा नहीं जा सकता है, तो एक [PptxException](https://reference.aspose.com/slides/hi/python-net/aspose.slides/pptxexception/) उत्पन्न होता है।
{{% /alert %}}

## **कम्प्रेशन स्तरों के साथ Office Open XML फ़ॉर्मेट में प्रस्तुतियों को सहेजें**

बड़ी प्रस्तुतियों के साथ काम करते समय आप फ़ाइल आकार और प्रोसेसिंग समय के बीच संतुलन बनाने के लिए कम्प्रेशन स्तर समायोजित कर सकते हैं। आपकी आवश्यकताओं के आधार पर आप तेज़ प्रोसेसिंग या छोटे आउटपुट फ़ाइलों को प्राथमिकता दे सकते हैं।

Aspose.Slides [PptxOptions.compression_level](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/compression_level/) प्रॉपर्टी प्रदान करता है, जिससे आप Office Open XML फ़ॉर्मेट में प्रस्तुति सहेजते समय उपयोग होने वाले कम्प्रेशन स्तर को निर्धारित कर सकते हैं।

उपलब्ध कम्प्रेशन स्तर निम्नलिखित हैं:

- [**NONE**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): कोई कम्प्रेशन नहीं किया जाता। फ़ाइलें जैसी हैं वैसी संग्रहीत रहती हैं।
- [**LEVEL1**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): सबसे तेज़ कम्प्रेशन, सबसे कम कम्प्रेशन अनुपात के साथ।
- [**LEVEL2**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL1** से थोड़ा बेहतर कम्प्रेशन अनुपात के साथ तेज़ कम्प्रेशन।
- [**LEVEL3**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL2** से बेहतर कम्प्रेशन, प्रोसेसिंग समय पर मध्यम प्रभाव के साथ।
- [**LEVEL4**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL3** से बेहतर कम्प्रेशन।
- [**LEVEL5**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL4** से उन्नत कम्प्रेशन, अतिरिक्त प्रोसेसिंग समय के साथ।
- [**LEVEL6**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): मानक कम्प्रेशन जो प्रोसेसिंग गति और फ़ाइल आकार के बीच अच्छा संतुलन प्रदान करता है। यह *डिफ़ॉल्ट कम्प्रेशन स्तर* है।
- [**LEVEL7**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL6** से बेहतर कम्प्रेशन, लेकिन धीमी प्रोसेसिंग।
- [**LEVEL8**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): **LEVEL7** से बेहतर कम्प्रेशन।
- [**LEVEL9**](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/compressionlevel/): अधिकतम कम्प्रेशन। सबसे छोटा फ़ाइल आकार प्राप्त करता है लेकिन सबसे अधिक प्रोसेसिंग समय लेता है।

निचे दिया गया उदाहरण *बिना कम्प्रेशन* के एक PPTX फ़ाइल को सहेजने को दर्शाता है:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

यह उदाहरण *अधिकतम कम्प्रेशन* के साथ एक PPTX फ़ाइल को सहेजने को प्रदर्शित करता है:

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **थंबनेल को रीफ़्रेश किए बिना प्रस्तुतियों को सहेजें**

[PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/hi/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) प्रॉपर्टी PPTX में प्रस्तुति सहेजते समय थंबनेल जनरेशन को नियंत्रित करती है:

- यदि `True` सेट किया गया है, तो सहेजते समय थंबनेल रीफ़्रेश हो जाता है। यह डिफ़ॉल्ट है।
- यदि `False` सेट किया गया है, तो मौजूदा थंबनेल संरक्षित रहता है। यदि प्रस्तुति में थंबनेल नहीं है, तो कोई थंबनेल उत्पन्न नहीं होगा।

निचे दिए गए कोड में, प्रस्तुति को थंबनेल रीफ़्रेश किए बिना PPTX में सहेजा गया है।

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
Aspose ने अपना स्वयं का API उपयोग करके एक [नि:शुल्क PowerPoint Splitter ऐप](https://products.aspose.app/slides/hi/splitter) विकसित किया है। यह ऐप चयनित स्लाइड्स को नए PPTX या PPT फ़ाइलों के रूप में सहेजकर प्रस्तुति को कई फ़ाइलों में विभाजित करने की सुविधा देता है।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या "तेज़ सहेजें" (इन्क्रिमेंटल सहेजना) समर्थित है ताकि केवल परिवर्तन लिखे जाएँ?**

नहीं। सहेजने पर प्रत्येक बार पूरी लक्ष्य फ़ाइल बनाई जाती है; इन्क्रिमेंटल "तेज़ सहेजें" समर्थित नहीं है।

**क्या एक ही Presentation इंस्टेंस को कई थ्रेड्स से सहेजना थ्रेड‑सेफ है?**

नहीं। एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस [थ्रेड‑सेफ नहीं है](/slides/hi/python-net/multithreading/); इसे केवल एक ही थ्रेड से सहेजें।

**सहेजते समय हाइपरलिंक्स और बाहरी लिंक वाली फ़ाइलों के साथ क्या होता है?**

[हाइपरलिंक्स](/slides/hi/python-net/manage-hyperlinks/) संरक्षित रहते हैं। बाहरी लिंक वाली फ़ाइलें (जैसे सापेक्ष पथ के माध्यम से वीडियो) स्वतः कॉपी नहीं होतीं—सुनिश्चित करें कि संदर्भित पथ अभिगम्य रहें।

**क्या मैं दस्तावेज़ मेटाडेटा (लेखक, शीर्षक, कंपनी, तिथि) सेट/सहेज सकता हूँ?**

हां। मानक [दस्तावेज़ प्रॉपर्टी](/slides/hi/python-net/presentation-properties/) समर्थित हैं और सहेजते समय फ़ाइल में लिखी जाती हैं।