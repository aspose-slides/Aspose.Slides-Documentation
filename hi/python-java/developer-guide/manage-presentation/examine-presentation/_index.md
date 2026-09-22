---
title: Python के माध्यम से Java में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/python-java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
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
description: "Python के माध्यम से Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक स्मार्ट सामग्री ऑडिट के लिए।"
---
## **समीक्षा**

Aspose.Slides एक प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करने, इन्वेंटरी बनाने, या गुणों का निरीक्षण करने की आवश्यकता होती है, इससे पहले कि आप प्रस्तुति की सामग्री को लोड और प्रोसेस करने का निर्णय लें।

उदाहरणों के लिए Aspose.Slides for Python via Java और एक संगत Java रनटाइम की आवश्यकता होती है। प्रत्येक उदाहरण JVM को शुरू करता है यदि वह पहले से चल नहीं रहा है। उदाहरणों में उपयोग किए गए पाथ पर मौजूदा प्रस्तुति फ़ाइलों को प्रदान करें।

यह लेख हल्के निरीक्षण को [PresentationFactory](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) के माध्यम से, साथ ही लक्षित अपडेट को [DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) के माध्यम से दर्शाता है।

## **प्रेजेंटेशन फ़ॉर्मेट जांचें**

यदि आपके पास पहले से लोडेड प्रस्तुति है, तो लोडिंग के बाद पहचान के लिए और लेगेसी PPT, PPS, और POT स्ट्रीम की सीमाओं के लिए देखें [मूल प्रस्तुति फ़ॉर्मेट निर्धारित करें](/slides/hi/python-java/detect-presentation-source-format/)।

फ़ाइल को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए निरीक्षण करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करें। [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#getLoadFormat) मेथड पता लगाए गए फ़ॉर्मेट की रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **एक हल्का प्रस्तुती इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंटरी की आवश्यकता हो सकती है। इस परिदृश्य में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह तरीका एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं होती।

[DocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/) द्वारा प्रदान किए गए विस्तारित गुण निम्नलिखित इन्वेंटरी मान देते हैं:

| विधि | इन्वेंटरी मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getSlides) | स्लाइड की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) | छुपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getParagraphs) | उपलब्ध होने पर पैराग्राफ की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getWords) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त इन्वेंटरी प्रिंट करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHeadingPairs) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ मिलाकर फ़ॉन्ट, थीम और स्लाइड शीर्षकों जैसी सामग्री समूहों को दिखाता है।

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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/python-java/aspose.slides/headingpair/) एक समूह नाम और उस समूह में वस्तुओं की संख्या प्रदान करता है। [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getTitlesOfParts) एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पेय द्वारा निर्दिष्ट लगातार शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए इन्वेंटरी गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनर्गणना हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपस्थित गुण डिफ़ॉल्ट मानों द्वारा दर्शाए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाले एप्लिकेशन ने अपने दस्तावेज़ गुण अपडेट नहीं किए थे।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छुपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गिनती के विस्तारित दस्तावेज़ गुण, साथ ही हेडिंग‑पेय और भाग‑शीर्षक प्रदान करता है। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने किन गुणों को लिखा है।
- **PPT:** बाइनरी फ़ॉर्मेट समान दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा रिफ़्रेश नहीं किया गया है, तो Aspose.Slides उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइडों से गणना करके।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पेज, पैराग्राफ और शब्द गिनती देता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छुपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेय और भाग‑शीर्षक मेटाडेटा उपलब्ध नहीं हो सकते, और इन्वेंटरी गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या खाली एरे को यह प्रमाण मानने से बचें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंटरी और प्रारंभिक जाँच के लिए हल्के मेटाडेटा दृष्टिकोण का उपयोग करें। जब परिणाम को मेमोरी‑में परिवर्तन प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करना हो, तो प्रस्तुति लोड करें और उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रेजेंटेशन गुण अपडेट करें**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) द्वारा लौटाए गए गुणों को भी बिना [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) इंस्टेंस बनाए बदला जा सकता है। बदलावों को [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) के साथ लागू करें, और फिर बंधित प्रस्तुति को [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) से लिखें।

नीचे मूल दस्तावेज़ गुणों की छवि दिखाई गई है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ गुण](input_properties.png)

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

नीचे अपडेट किए गए दस्तावेज़ गुणों की छवि दिखाई गई है।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और सुरक्षा सेटिंग्स के लिए निम्न लेख देखें:

- [प्रेजेंटेशन पर पासवर्ड सुरक्षा](/slides/hi/python-java/password-protected-presentation/)
- [प्रेजेंटेशन पर लिखने से संरक्षण](/slides/hi/python-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन‑से हैं?**

प्रेजेंटेशन लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getFontsManager) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) को कॉल करें और प्रेजेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsmanager/#getFonts) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को खोजें जिनकी रेंडरिंग के लिए आवश्यकता है लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे जानूं कि फ़ाइल में छुपी स्लाइडें हैं और कितनी?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/documentproperties/#getHiddenSlides) को [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationfactory/#getPresentationInfo) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentationinfo/#readDocumentProperties) के माध्यम से पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा गायब या पुराना हो सकता है, या लाइव मानों को सत्यापित करने की आवश्यकता हो, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) के माध्यम से इटरिटेट करें और प्रत्येक स्लाइड के [Slide.getHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getHidden) मेथड का निरीक्षण करें।

**क्या मैं कस्टम स्लाइड आकार और अभिविन्यास का पता लगा सकता हूँ, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। प्रेजेंटेशन लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlideSize) को कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [SlideSize.getType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getSize) और [SlideSize.getOrientation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidesize/#getOrientation) का उपयोग करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों की जाँच करने का तेज़ तरीका है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chart/) को खोजें और [ChartData.getDataSourceType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getDataSourceType) को कॉल करें। बाहरी वर्कबुक के लिए, [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) को कॉल करें। डेटा स्रोत प्रकार और पाथ बाहरी संदर्भ को पहचानते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिए अलग संसाधन जाँच आवश्यक है।

**मैं किस प्रकार 'भारी' स्लाइड्स का मूल्यांकन कर सकता हूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getSlides) और प्रत्येक स्लाइड के [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) संग्रह को ट्रैवर्स करें। आकार गणना, बड़े चित्र, इफ़ेक्ट, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और बड़ी स्लाइड को अंतिम प्रदर्शन बाधा मानने से पहले प्रतिनिधि रेंडर या निर्यात मापें।