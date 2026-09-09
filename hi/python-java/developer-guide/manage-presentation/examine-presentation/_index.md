---
title: Python के माध्यम से Java में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/python-java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति प्रॉपर्टीज़
- दस्तावेज़ प्रॉपर्टीज़
- प्रॉपर्टीज़ प्राप्त करें
- प्रॉपर्टीज़ पढ़ें
- प्रॉपर्टीज़ बदलें
- प्रॉपर्टीज़ संशोधित करें
- प्रॉपर्टीज़ अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के माध्यम से Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडाटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और बेहतर कंटेंट ऑडिट के लिए।"
---
## **परिचय**

Aspose.Slides प्रस्तुति का फ़ॉर्मेट पहचान सकता है और उसके दस्तावेज़ मेटाडाटा को पूरी प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक इन्वेंट्री बनानी हो, या प्रॉपर्टीज़ का निरीक्षण करना हो इससे पहले कि आप प्रस्तुति की सामग्री को लोड और प्रोसेस करने का निर्णय लें।

उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। प्रत्येक उदाहरण JVM को शुरू करता है यदि वह पहले से चल नहीं रहा है। उदाहरणों में प्रयुक्त पथों पर मौजूदा प्रस्तुति फ़ाइलें प्रदान करें।

यह लेख हल्के निरीक्षण को [PresentationFactory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) के माध्यम से तथा लक्षित अपडेट को [DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) के माध्यम से प्रदर्शित करता है।

## **प्रस्तुति फ़ॉर्मेट जांचें**

फ़ाइल का निरीक्षण बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करें। [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#getLoadFormat) मेथड पता लगाए गए फ़ॉर्मेट की रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **हल्की वजन की प्रस्तुति इन्वेंट्री बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो आपको वैधता, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंट्री की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल करके दस्तावेज़ मेटाडाटा पढ़ें। यह दृष्टिकोण [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार नहीं करता।

[DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) द्वारा प्रकट किए गए विस्तारित प्रॉपर्टीज़ निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getSlides) | स्लाइड्स की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) | छिपी हुई स्लाइड्स की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाले स्लाइड्स की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getParagraphs) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getWords) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त इन्वेंट्री प्रिंट करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHeadingPairs) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ मिलाकर फ़ॉन्ट्स, थीम्स और स्लाइड शीर्षकों जैसे कंटेंट समूह दिखाता है।

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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/python-java/aspose.slides/headingpair/) एक समूह का नाम और उस समूह में आइटम्स की संख्या प्रदान करता है। [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) एक फ्लैट, क्रमबद्ध ऐरे लौटाता है, इसलिए प्रत्येक heading pair द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडाटा और फ़ॉर्मेट सीमाएँ**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए इन्वेंट्री प्रॉपर्टीज़ स्रोत दस्तावेज़ में उपलब्ध मेटाडाटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और पार नहीं करता। अनुपलब्ध प्रॉपर्टीज़ को डिफ़ॉल्ट मानों से दर्शाया जाता है, और संग्रहीत मान पुराने हो सकते हैं यदि फ़ाइल को अंतिम बार सहेजने वाले अनुप्रयोग ने अपने दस्तावेज़ प्रॉपर्टीज़ को अपडेट नहीं किया था।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी हुई स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गिनती के लिए विस्तारित दस्तावेज़ प्रॉपर्टीज़ प्रदान करता है, साथ ही heading pairs और part titles भी। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से प्रॉपर्टीज़ लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट समान document‑summary प्रॉपर्टीज़ संग्रहीत कर सकता है। यदि कोई प्रॉपर्टी अनुपस्थित है या निर्माता ने उसे अपडेट नहीं किया है, तो Aspose.Slides उसके संग्रहीत या डिफ़ॉल्ट मान को लौटाता है, न कि स्लाइड्स से पुनः गणना करके।
- **ODP:** OpenDocument मेटाडाटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ और शब्द गिनती, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित प्रॉपर्टी से मेल नहीं खाते। छिपी हुई स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, heading‑pair और part‑title मेटाडाटा उपलब्ध नहीं हो सकता, और इन्वेंट्री प्रॉपर्टीज़ डिफ़ॉल्ट मान लौट सकती हैं। शून्य मान या खाली ऐरे को इस बात का अधिकारिक प्रमाण न मानें कि संबंधित कंटेंट अनुपस्थित है।

इन्वेंट्री और प्रारंभिक जाँचों के लिए हल्का मेटाडाटा दृष्टिकोण उपयोग करें। जब परिणाम को इन‑मे़मोरी बदलावों को दर्शाना हो या आपको वास्तविक प्रस्तुति कंटेंट को सत्यापित करने की आवश्यकता हो तो प्रस्तुति को लोड करें और उसकी लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रस्तुति प्रॉपर्टीज़ अपडेट करें**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए प्रॉपर्टीज़ को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए बदला जा सकता है। परिवर्तन को [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) के साथ लागू करें, और फिर [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) से बंधी हुई प्रस्तुति लिखें।

निम्न छवि मूल दस्तावेज़ प्रॉपर्टीज़ को दिखाती है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ प्रॉपर्टीज़](input_properties.png)

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

निम्न छवि अपडेटेड दस्तावेज़ प्रॉपर्टीज़ को दिखाती है।

![PowerPoint प्रस्तुति की बदली हुई दस्तावेज़ प्रॉपर्टीज़](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँचों और सुरक्षा सेटिंग्स के लिए निम्न लेख देखें:

- [Password-Protect Presentations](/slides/hi/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/python-java/write-protected-presentation/)

## **FAQ**

**मैं कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से हैं?**

प्रेजेंटेशन लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFonts) कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**फ़ाइल में छिपी हुई स्लाइड्स हैं या नहीं और उनकी संख्या कैसे जल्दी पता करूँ?**

जब संग्रहीत दस्तावेज़ मेटाडाटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) के माध्यम से [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) पढ़ें। यह हल्की इन्वेंट्री के लिये उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडाटा गायब या पुराना हो सकता है, या आपको लाइव मानों की जाँच करनी हो, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) के माध्यम से इटरिटेट करें और प्रत्येक स्लाइड के [Slide.getHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getHidden) मेथड को देखें।

**क्या मैं यह पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में है, और क्या वह डिफ़ॉल्ट से अलग है?**

हां। प्रस्तुति लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideSize) कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रिसेट और आयामों से करने के लिए [SlideSize.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getSize) और [SlideSize.getOrientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getOrientation) का उपयोग करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों को संदर्भित करने का कोई त्वरित तरीका है?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) खोजें और [ChartData.getDataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) को कॉल करें। बाहरी वर्कबुक के लिए, [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) कॉल करें। डेटा स्रोत प्रकार और पथ बाहरी संदर्भ को पहचानते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिये अलग संसाधन जाँच आवश्यक है।

**मैं 'भारी' स्लाइड्स को कैसे आकलन करूं जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

एक एकल जटिलता प्रॉपर्टी नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) और प्रत्येक स्लाइड के [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) संग्रह को पार करें। आकृति गिनती और बड़े चित्रों, इफ़ेक्ट्स, एनिमेशन्स या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और एक प्रतिनिधि रेंडर या निर्यात मापें इससे पहले कि आप स्लाइड को निश्चित प्रदर्शन बाधा मानें।