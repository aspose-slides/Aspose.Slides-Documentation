---
title: जावास्क्रिप्ट में प्रस्तुति जानकारी पुनः प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/nodejs-java/examine-presentation/
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
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट का उपयोग करके पावरपॉइंट और ओपनडॉक्यूमेंट प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, ताकि तेज़ अंतर्दृष्टि और smarter सामग्री ऑडिट प्राप्त हो।"
---
## **अवलोकन**

Aspose.Slides एक प्रस्तुति के स्वरूप की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह उन परिस्थितियों में उपयोगी है जब आपको फ़ाइलों को वर्गीकृत करना, इन्वेंटरी बनाना, या प्रेजेंटेशन सामग्री को लोड और प्रोसेस करने का निर्णय लेने से पहले गुणों का निरीक्षण करना हो।

यह लेख [PresentationFactory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) के माध्यम से हल्का निरीक्षण तथा [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) के माध्यम से लक्षित अपडेट्स को दर्शाता है।

## **प्रस्तुति स्वरूप की जाँच करें**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके आप फ़ाइल का निरीक्षण कर सकते हैं बिना एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाए। [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/getloadformat/) मेथड पता किए गए स्वरूप को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो वैधता, अनुक्रमण या दस्तावेज‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके एक [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह दृष्टिकोण एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार करने की आवश्यकता नहीं रखता।

[DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) द्वारा प्रदान की गई विस्तारित प्रॉपर्टीज़ निम्नलिखित इन्वेंटरी मानों को दर्शाती हैं:

| विधि | इन्वेंटरी मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getSlides) | स्लाइडों की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | छिपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getWords) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को बिना एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त इन्वेंटरी प्रिंट करता है। यह साथ ही [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) को [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ जोड़ता है जिससे फ़ॉन्ट, थीम और स्लाइड शीर्षक जैसी सामग्री समूह दिखाए जा सकें।

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/) एक समूह का नाम [HeadingPair.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/#getName) द्वारा प्रदान करता है और उस समूह में आइटम की संख्या [HeadingPair.getCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/#getCount) द्वारा। [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) एक एकल, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संचित मेटाडेटा और स्वरूप सीमाएँ**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) द्वारा लौटाए गए इन्वेंटरी प्रॉपर्टीज़ स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करती हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और पार नहीं करता। अनुपलब्ध प्रॉपर्टीज़ डिफ़ॉल्ट मानों से दर्शाई जाती हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल को सहेजने वाले अनुप्रयोग ने उनके दस्तावेज़ प्रॉपर्टीज़ को अपडेट नहीं किया हो।

- **PPTX:** स्वरूप स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गिनती के लिए विस्तारित दस्तावेज़ प्रॉपर्टीज़ प्रदान करता है, साथ ही हेडिंग‑पेयर और पार्ट‑टाइटल्स। उपलब्धता इस बात पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑सी प्रॉपर्टीज़ लिखी हैं।
- **PPT:** बाइनरी स्वरूप संबंधित दस्तावेज़‑सारांश प्रॉपर्टीज़ संग्रहीत कर सकता है। यदि कोई प्रॉपर्टी अनुपस्थित है या निर्माता ने उसे ताज़ा नहीं किया है, तो Aspose.Slides उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है, स्लाइड्स से गणना नहीं करता।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पृष्ठ, पैराग्राफ और शब्द गिनती प्रदान करता है, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित प्रॉपर्टी से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और पार्ट‑टाइटल मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंटरी प्रॉपर्टीज़ डिफ़ॉल्ट मान लौट सकती हैं। शून्य मान या खाली एरे को यह प्रमाण न मानें कि संबंधित सामग्री अनुपलब्ध है।

इन्वेंटरी और प्रारंभिक जाँचों के लिए हल्का मेटाडेटा तरीका उपयोग करें। जब परिणाम को मेमोरी‑में बदलाव को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करने की आवश्यकता हो, तब प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल का निरीक्षण करें।

## **प्रस्तुति गुण अपडेट करें**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) द्वारा लौटाए गए प्रॉपर्टीज़ को बिना एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाए बदला जा सकता है। बदलावों को [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) से लागू करें, और फिर बाइंडेड प्रस्तुति को [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) से लिखें।

निम्न छवि मूल दस्तावेज़ प्रॉपर्टीज़ को दर्शाती है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम‑सहेजने का समय बदलता है और परिणाम को एक नई फ़ाइल में लिखता है:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

निम्न छवि अपडेटेड दस्तावेज़ प्रॉपर्टीज़ को दर्शाती है।

![PowerPoint प्रस्तुति के बदले हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँच और सुरक्षा सेटिंग्स के लिए निम्न लेख देखें:

- [Password-Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/nodejs-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से एम्बेडेड हैं, यह कैसे जाँचूँ?**

प्रेजेंटेशन को लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getfontsmanager/) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**फ़ाइल में छिपी स्लाइड्स हैं या नहीं और उनकी संख्या कितनी है, यह जल्दी कैसे पता करूँ?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) के माध्यम से [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) पढ़ें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है; ऐसी स्थिति में लाइव मानों की पुष्टि के लिए [Presentation.getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) को इटररेट करें और प्रत्येक स्लाइड के [Slide.getHidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/gethidden/) मेथड का निरीक्षण करें।

**क्या मैं कस्टम स्लाइड आकार और अभिविन्यास का पता लगा सकता हूँ, और क्या वे डिफ़ॉल्ट से भिन्न हैं?**

हां। प्रस्तुति को लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslidesize/) को कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [SlideSize.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/getsize/), और [SlideSize.getOrientation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/getorientation/) का उपयोग करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित करते हैं, यह देखने का तेज़ तरीका है?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) को खोजें और [ChartData.getDataSourceType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) को कॉल करें। यदि स्रोत एक बाहरी वर्कबुक है, तो [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) को कॉल करें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ को दर्शाते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिए अलग संसाधन जाँच आवश्यक है।

**'हेवी' स्लाइड्स जिन्हें रेंडरिंग या PDF निर्यात को धीमा कर सकता है, का मूल्यांकन कैसे करूँ?**

कोई एकल जटिलता प्रॉपर्टी नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) और प्रत्येक स्लाइड के [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getShapes) संग्रह को पार करें। आकार‑गिनती, बड़ी छवियों, इफ़ेक्ट्स, एनिमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और स्लाइड को पुष्टि करने से पहले प्रतिनिधि रेंडर या निर्यात को मापें।