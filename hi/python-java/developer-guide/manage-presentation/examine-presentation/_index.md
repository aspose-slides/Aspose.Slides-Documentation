---
title: "Java के माध्यम से Python में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें"
linktitle: "प्रस्तुति जानकारी"
type: docs
weight: 30
url: /hi/python-java/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX का परीक्षण करें
- PPT का परीक्षण करें
- ODP का परीक्षण करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा को Python के माध्यम से Java का उपयोग करके खोजें, तेज़ अंतर्दृष्टि और अधिक स्मार्ट कंटेंट ऑडिट के लिए।"
---
## **समीक्षा**

Aspose.Slides प्रस्तुति का फॉर्मेट पहचान सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करने, इन्वेंट्री बनाने, या गुणों का निरीक्षण करने की आवश्यकता होती है, इससे पहले कि आप तय करें कि प्रस्तुति सामग्री को लोड और प्रोसेस करें या नहीं।

इन उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। प्रत्येक उदाहरण JVM को शुरू करता है यदि वह पहले से चल रहा नहीं है। उदाहरणों में उपयोग किए गए पथों पर मौजूदा प्रस्तुति फ़ाइलें उपलब्ध कराएँ।

यह लेख हल्के निरीक्षण को दर्शाता है जो [PresentationFactory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) के माध्यम से किया जाता है, तथा लक्षित अपडेट्स को [DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) के माध्यम से।

## **प्रस्तुति फॉर्मेट की जाँच करें**

फ़ाइल को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए निरीक्षण करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करें। [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#getLoadFormat) मेथड पता लगाए गए फॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **हल्की प्रस्तुति इन्वेंट्री बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस कर रहे हों, तो आपको सत्यापन, इंडेक्सिंग, या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंट्री की आवश्यकता हो सकती है। इस परिदृश्य में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह दृष्टिकोण एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार करने की आवश्यकता नहीं होती।

[DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getSlides) | स्लाइड्स की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) | छिपी हुई स्लाइड्स की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाली स्लाइड्स की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getParagraphs) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getWords) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक कॉम्पैक्ट इन्वेंट्री प्रिंट करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHeadingPairs) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ मिलाकर फ़ॉन्ट, थीम, और स्लाइड शीर्षक जैसे कंटेंट समूह भी दिखाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/python-java/aspose.slides/headingpair/) एक समूह नाम और उस समूह में आइटमों की संख्या प्रदान करता है। [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) एक फ़्लैट, क्रमबद्ध ऐरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमागत शीर्षकों की संख्या को उपभोग करें।

### **संग्रहित मेटाडेटा और फॉर्मेट सीमाएँ**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मूल्यों की पुनर्गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड या पार नहीं करता। अनुपस्थित गुण डिफ़ॉल्ट मानों द्वारा प्रतिनिधित्व किए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि फ़ाइल को अंतिम बार सहेजने वाले एप्लिकेशन ने दस्तावेज़ गुण अपडेट नहीं किए हों।

- **PPTX:** फॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द, और मल्टीमीडिया गननाओं के लिए विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग पेयर्स और पार्ट टाइटल्स भी। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन से गुण लिखे हैं।
- **PPT:** बाइनरी फॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा रीफ़्रेश नहीं हुआ है, तो Aspose.Slides उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइड्स से गणना किया गया मान।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ, और शब्द गिनती, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर, और पार्ट‑टाइटल मेटाडेटा अनुपलब्ध हो सकता है, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौट सकते हैं। शून्य मान या खाली ऐरे को यह सिद्ध करने के लिए अधिकारिक प्रमाण न मानें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंट्री और प्रारंभिक जाँचों के लिए हल्का मेटाडेटा दृष्टिकोण उपयोग करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तब पूर्ण प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल को निरीक्षण करें।

## **प्रस्तुति गुणों को अपडेट करें**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए गुणों को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए बदला भी जा सकता है। बदलावों को लागू करने के लिए [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) का प्रयोग करें, और फिर बंधित प्रस्तुति को [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) के साथ लिखें।

निम्न छवि मूल दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजे समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

निम्न छवि अपडेट किए गए दस्तावेज़ गुणों को दर्शाती है।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँचों और संरक्षण सेटिंग्स के लिए निम्न लेख देखें:

- [Password-Protect Presentations](/slides/hi/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/python-java/write-protected-presentation/)

## **पूछे जाने वाले प्रश्न**

**मैं कैसे जाँचूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन‑से हैं?**

प्रस्तुति लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFonts) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता करूँ कि फ़ाइल में छिपी स्लाइड्स हैं और उनकी संख्या कितनी है?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) के माध्यम से [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) पढ़ें। यह एक हल्की इन्वेंट्री के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा गायब या पुराना हो सकता है, या आपको वास्तविक मानों की पुष्टि करनी है, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) पर इटररेट करें और प्रत्येक स्लाइड के [Slide.getHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getHidden) मेथड को निरीक्षण करें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग किया गया है, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। प्रस्तुति लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideSize) को कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [SlideSize.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getSize), और [SlideSize.getOrientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getOrientation) का उपयोग करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों को देखने का कोई तेज़ तरीका है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) को लोकेट करें और [ChartData.getDataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) को कॉल करें। बाहरी वर्कबुक के लिए, [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को कॉल करें। डेटा स्रोत प्रकार और पथ एक बाहरी रेफ़रेंस की पहचान करता है, लेकिन यह सत्यापित करने के लिए कि लक्ष्य उपलब्ध है या नहीं, अलग से संसाधन जाँच आवश्यक है।

**मैं कैसे मूल्यांकन करूँ कि 'भारी' स्लाइड्स हैं जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) और प्रत्येक स्लाइड की [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) कलेक्शन को पार करें। आकार गणना, बड़े इमेज, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और किसी स्लाइड को निश्चित प्रदर्शन बाधा के रूप में लेबल करने से पहले प्रतिनिधि रेंडर या एक्सपोर्ट मापें।