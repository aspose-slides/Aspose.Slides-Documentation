---
title: Python में प्रस्तुति जानकारी को पुनः प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/python-net/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX का परीक्षण
- PPT का परीक्षण
- ODP का परीक्षण
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा का अन्वेषण Python का उपयोग कर तेज़ अंतर्दृष्टि और स्मार्ट सामग्री ऑडिट के लिए करें।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति के स्वरूप की पहचान कर सकता है और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडाटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक सूची बनानी हो, या गुणों की जाँच करनी हो इससे पहले कि आप यह तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्के निरीक्षण को [PresentationFactory](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) के माध्यम से, साथ ही [DocumentProperties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/) के माध्यम से लक्षित अपडेट्स को दर्शाता है।

## **प्रस्तुति स्वरूप की जाँच**

फ़ाइल की जाँच करने के लिए बिना [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें। [PresentationInfo.load_format](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/load_format/) प्रॉपर्टी पता लगाए गए स्वरूप को रिपोर्ट करती है, जैसे PPTX, PPT, या ODP।

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **हल्का प्रस्तुति सूची बनाना**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो आपको वैधता, इंडेक्सिंग या दस्तावेज़ प्रबंधन प्रणाली के लिए एक संक्षिप्त सूची की आवश्यकता हो सकती है। इस स्थिति में, एक [PresentationInfo](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करने के लिए [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) का उपयोग करें, और फिर दस्तावेज़ मेटाडाटा को पढ़ने के लिए [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) को कॉल करें। यह दृष्टिकोण एक [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस नहीं बनाता है और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार करने की आवश्यकता नहीं पड़ती।

[DocumentProperties] द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित सूची मान प्रदान करते हैं:

| गुण | सूची मान |
| --- | --- |
| [slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/slides/hi/) | स्लाइड्स की कुल संख्या। |
| [hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/hidden_slides/) | छिपी स्लाइड्स की संख्या। |
| [notes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/notes/) | नोट्स वाली स्लाइड्स की संख्या। |
| [paragraphs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/paragraphs/) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [words](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/words/) | शब्दों की कुल संख्या। |
| [multimedia_clips](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/multimedia_clips/) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना किसी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त सूची प्रिंट करता है। यह फ़ॉन्ट, थीम और स्लाइड शीर्षकों जैसे सामग्री समूहों को प्रदर्शित करने के लिए [heading_pairs](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/heading_pairs/) को [titles_of_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/titles_of_parts/) के साथ भी संयोजित करता है।

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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/python-net/aspose.slides/headingpair/) एक समूह नाम और उस समूह में वस्तुओं की संख्या प्रदान करता है। [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/titles_of_parts/) एक फ्लैट, क्रमबद्ध संग्रह है, इसलिए प्रत्येक heading pair द्वारा निर्दिष्ट क्रमागत शीर्षकों की संख्या का उपयोग करें।

### **संग्रहीत मेटाडाटा और स्वरूप सीमाएँ**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) द्वारा लौटाए गए सूची गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडाटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और पार नहीं करता। अनुपलब्ध गुण डिफॉल्ट मानों द्वारा दर्शाए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाला अनुप्रयोग अपने दस्तावेज़ गुणों को अपडेट नहीं करता।

- **PPTX:** स्वरूप स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गिनती के लिए विस्तारित दस्तावेज़ गुण, साथ ही heading pairs और part titles प्रदान करता है। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन से गुण लिखे हैं।
- **PPT:** बाइनरी स्वरूप संबंधित दस्तावेज़‑सारांश गुणों को संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा ताज़ा नहीं किया गया है, तो Aspose.Slides इसे स्लाइड्स से गणना करने के बजाय संग्रहीत या डिफॉल्ट मान लौटाता है।
- **ODP:** OpenDocument मेटाडाटा सामान्य दस्तावेज़ सांख्यिकी जैसे पेज, पैराग्राफ और शब्द गिनती प्रदान करता है, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित गुण से मैप नहीं होते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, heading‑pair और part‑title मेटाडाटा उपलब्ध नहीं हो सकते, और सूची गुण डिफॉल्ट मान लौट सकते हैं। शून्य मान या खाली संग्रह को यह सिद्ध करने के लिए उपयोग न करें कि संबंधित सामग्री अनुपस्थित है।

सूचियों और प्रारंभिक जाँचों के लिए हल्के मेटाडाटा दृष्टिकोण का उपयोग करें। जब परिणाम को मेमोरी में हुए परिवर्तनों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करने की आवश्यकता हो, तो प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रस्तुति गुण अपडेट करें**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) द्वारा लौटाए गए गुणों को भी बिना किसी [Presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) इंस्टेंस बनाए बदला जा सकता है। बदलावों को [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/update_document_properties/) से लागू करें, और फिर बाइंडेड प्रस्तुति को [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/write_binded_presentation/) से लिखें।

निम्न छवि मूल दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑संरक्षित समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

निम्न छवि अद्यतन दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के बदलें हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँचों और संरक्षण सेटिंग्स के लिए, निम्न लेख देखें:

- [पासवर्ड‑सुरक्षित प्रस्तुतियाँ](/slides/hi/python-net/password-protected-presentation/)
- [लेखन‑सुरक्षित प्रस्तुतियाँ](/slides/hi/python-net/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौनसे हैं?**

प्रस्तुति को लोड करें और [Presentation.fonts_manager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/fonts_manager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट प्राप्त करने के लिए [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट प्राप्त करने के लिए [FontsManager.get_fonts](https://reference.aspose.com/slides/hi/python-net/aspose.slides/fontsmanager/get_fonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट को खोजें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता करूँ कि फ़ाइल में छिपी स्लाइड्स हैं या नहीं और उनकी संख्या कितनी है?**

जब संग्रहीत दस्तावेज़ मेटाडाटा पर्याप्त हो, तो [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationfactory/get_presentation_info/) और [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentationinfo/read_document_properties/) के माध्यम से [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/documentproperties/hidden_slides/) पढ़ें। यह हल्की सूची के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडाटा गायब या पुराना हो सकता है, या आपको लाइव मानों की जाँच करनी हो, तो [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) के माध्यम से इटररेट करें और प्रत्येक स्लाइड की [Slide.hidden](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slide/hidden/) प्रॉपर्टी को देखें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफॉल्ट से अलग हैं?**

हां। प्रस्तुति को लोड करें और [Presentation.slide_size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slide_size/) पढ़ें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [SlideSize.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/size/) और [SlideSize.orientation](https://reference.aspose.com/slides/hi/python-net/aspose.slides/slidesize/orientation/) की जांच करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ देते हैं, यह जल्दी से देखना संभव है?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chart/) को खोजें और [ChartData.data_source_type](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/data_source_type/) की जाँच करें। बाहरी वर्कबुक के लिए, [ChartData.external_workbook_path](https://reference.aspose.com/slides/hi/python-net/aspose.slides.charts/chartdata/external_workbook_path/) पढ़ें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ को पहचानते हैं, लेकिन लक्ष्य उपलब्धता की जाँच के लिए एक अलग संसाधन जाँच आवश्यक है।

**मैं 'भारी' स्लाइड्स का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.slides](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/slides/hi/) और प्रत्येक स्लाइड की [BaseSlide.shapes](https://reference.aspose.com/slides/hi/python-net/aspose.slides/baseslide/shapes/) संग्रह को पार करें। आकार की गिनती और बड़े चित्र, प्रभाव, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और एक स्लाइड को पुष्टि किए गए प्रदर्शन बाधा के रूप में मानने से पहले प्रतिनिधि रेंडर या निर्यात को मापें।