---
title: Python में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/python-net/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- प्रॉपर्टीज़ प्राप्त करें
- प्रॉपर्टीज़ पढ़ें
- प्रॉपर्टीज़ बदलें
- प्रॉपर्टीज़ संशोधित करें
- प्रॉपर्टीज़ अपडेट करें
- PPTX जाँचें
- PPT जाँचें
- ODP जाँचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, त्वरित अंतर्दृष्टि और अधिक समझदारी वाली सामग्री ऑडिट के लिए।"
---
## **परिचय**

Aspose.Slides किसी प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके डॉक्यूमेंट मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, इन्वेंटरी बनानी हो, या सामग्री को लोड और प्रोसेस करने से पहले प्रॉपर्टीज़ की जाँच करनी हो।

यह लेख हल्की जांच को [PresentationFactory](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) के माध्यम से, तथा लक्षित अपडेट को [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) के माध्यम से प्रदर्शित करता है।

## **प्रस्तुति फ़ॉर्मेट जाँचें**

यदि आपके पास पहले से लोडेड प्रस्तुति है, तो लोडिंग के बाद पहचान के लिए [Determine the Original Presentation Format](/slides/hi/python-net/detect-presentation-source-format/) देखें और लेगेसी PPT, PPS, और POT स्ट्रीम की सीमाओं को समझें।

फ़ाइल को बिना [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए जाँचने के लिए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें। [PresentationInfo.load_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/load_format/) प्रॉपर्टी पता लगाए गए फ़ॉर्मेट (जैसे PPTX, PPT, या ODP) को रिपोर्ट करती है।

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, इंडेक्सिंग, या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंटरी की आवश्यकता हो सकती है। इस परिदृश्य में, इन्वेंटरी प्राप्त करने के लिए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) को कॉल करके डॉक्यूमेंट मेटाडेटा पढ़ें। इस दृष्टिकोण से न तो [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनता है और न ही पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करना आवश्यक होता है।

[DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) द्वारा उजागर विस्तारित प्रॉपर्टीज़ निम्नलिखित इन्वेंटरी मान प्रदान करती हैं:

| प्रॉपर्टी | इन्वेंटरी मान |
| --- | --- |
| [स्लाइड्स](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/slides/hi/) | कुल स्लाइड्स की संख्या। |
| [hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/hidden_slides/) | छिपी हुई स्लाइड्स की संख्या। |
| [notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/notes/) | नोट्स वाली स्लाइड्स की संख्या। |
| [paragraphs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/paragraphs/) | उपलब्ध होने पर कुल पैराग्राफ़ की संख्या। |
| [words](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/words/) | कुल शब्दों की संख्या। |
| [multimedia_clips](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/multimedia_clips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक कॉम्पैक्ट इन्वेंटरी प्रिंट करता है। यह [heading_pairs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/heading_pairs/) को [titles_of_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/titles_of_parts/) के साथ मिलाकर फ़ॉन्ट्स, थीम्स और स्लाइड शीर्षकों जैसे कंटेंट समूह प्रदर्शित करता है।

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/python-net/aspose.slides/headingpair/) समूह का नाम और उस समूह में आइटम्स की संख्या प्रदान करता है। [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/titles_of_parts/) एक फ्लैट, क्रमबद्ध संग्रह है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडाटा और फ़ॉर्मेट सीमाएँ**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) द्वारा लौटाए गए इन्वेंटरी प्रॉपर्टीज़ स्रोत दस्तावेज़ में उपलब्ध मेटाडाटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनर्गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। लापता प्रॉपर्टीज़ डिफ़ॉल्ट मानों द्वारा दर्शाई जाती हैं, और संग्रहीत मान पुराने हो सकते हैं यदि फ़ाइल को अंतिम बार सहेजने वाले एप्लिकेशन ने अपने डॉक्यूमेंट प्रॉपर्टीज़ को अपडेट नहीं किया हो।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टिमीडिया की गिनती के लिए विस्तारित डॉक्यूमेंट प्रॉपर्टीज़ के साथ हेडिंग पेयर्स और पार्ट टाइटल्स प्रदान करता है। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑सी प्रॉपर्टीज़ लिखी हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित डॉक्यूमेंट‑समरी प्रॉपर्टीज़ को संग्रहीत कर सकता है। यदि कोई प्रॉपर्टी अनुपस्थित है या निर्माता ने उसे रीफ़्रेश नहीं किया, तो Aspose.Slides उसकी संग्रहीत या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइड्स से गणना करके।
- **ODP:** OpenDocument मेटाडाटा सामान्य दस्तावेज़ आँकड़े (जैसे पेज, पैराग्राफ, शब्द गिनती) देता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित प्रॉपर्टी के साथ मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टिमीडिया, हेडिंग‑पेयर, और पार्ट‑टाइटल मेटाडाटा अनुपलब्ध हो सकते हैं, और इन्वेंटरी प्रॉपर्टीज़ डिफ़ॉल्ट मान लौटाएंगी। शून्य मान या खाली संग्रह को यह मानने के लिए प्रयोग न करें कि संबंधित कंटेंट मौजूद नहीं है।

हल्की मेटाडाटा पद्धति को इन्वेंटरी और प्रारंभिक जाँच के लिए उपयोग करें। जब परिणाम को मेमोरी में हुए परिवर्तनों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति कंटेंट को सत्यापित करना हो, तो प्रस्तुति को लोड कर उसके लाइव ऑब्जेक्ट मॉडल की जाँच करें।

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) द्वारा लौटाई गई प्रॉपर्टीज़ को [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए बिना भी बदला जा सकता है। बदलावों को लागू करने के लिए [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/update_document_properties/) का उपयोग करें, और फिर बंधित प्रस्तुति को [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/write_binded_presentation/) से लिखें।

निम्न छवि मूल दस्तावेज़ प्रॉपर्टीज़ को दर्शाती है।

![Original document properties of the PowerPoint presentation](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सेव समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

निम्न छवि अपडेट किए गए दस्तावेज़ प्रॉपर्टीज़ को दर्शाती है।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँच और सुरक्षा सेटिंग्स के लिए नीचे दिए गए लेख देखें:

- [Password-Protect Presentations](/slides/hi/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/python-net/write-protected-presentation/)

## **FAQ**

**फ़ॉन्ट्स एम्बेडेड हैं या नहीं और कौन‑से एम्बेडेड हैं, कैसे जाँचें?**

प्रस्तुति को लोड करें और [Presentation.fonts_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/fonts_manager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [FontsManager.get_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**फ़ाइल में छिपी स्लाइड्स हैं या नहीं और उनकी संख्या कैसे जल्दी पता करें?**

जब संग्रहीत डॉक्यूमेंट मेटाडाटा पर्याप्त हो, तो [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/hidden_slides/) को [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) और फिर [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) के माध्यम से पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडाटा गायब या पुराना हो सकता है; ऐसे में [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) को इटररेट करके प्रत्येक स्लाइड के [Slide.hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) प्रॉपर्टी की जाँच करें।

**कस्टम स्लाइड आकार और अभिविन्यास का उपयोग हो रहा है या नहीं, और क्या वे डिफ़ॉल्ट से अलग हैं, कैसे पता करें?**

हाँ। प्रस्तुति को लोड करें और [Presentation.slide_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slide_size/) पढ़ें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसैट और आयामों से करने के लिए [SlideSize.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/size/) और [SlideSize.orientation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/orientation/) का निरीक्षण करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों को रेफ़र कर रहे हैं, इसे जल्दी से देखना संभव है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) को लोकेट करें और [ChartData.data_source_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) की जाँच करें। बाहरी वर्कबुक के लिए [ChartData.external_workbook_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) पढ़ें। डेटा स्रोत प्रकार और पाथ बाहरी रेफ़रेंस की पहचान करते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिए अलग रिसोर्स चेक आवश्यक है।

**'हैवी' स्लाइड्स जिन्हें रेंडरिंग या PDF एक्सपोर्ट धीमा कर सकती हैं, कैसे आकलन करें?**

कोई एकल जटिलता प्रॉपर्टी नहीं है। [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) और प्रत्येक स्लाइड के [BaseSlide.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/shapes/) संग्रह को ट्रैवर्स करें। आकार बड़ी इमेजेज, इफ़ेक्ट्स, एनीमेशन या मल्टिमीडिया की उपस्थिति, और शैप काउंट को स्क्रीनिंग संकेतों के रूप में उपयोग करें, तथा प्रतिनिधिक रेंडर या एक्सपोर्ट मापें इससे पहले कि स्लाइड को performance bottleneck के रूप में मानें।