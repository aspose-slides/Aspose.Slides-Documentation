---
title: जावास्क्रिप्ट में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/nodejs-java/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जाँचें
- PPT जाँचें
- ODP जाँचें
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट का उपयोग करके पावरपॉइंट और ओपनडॉक्यूमेंट प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक स्मार्ट सामग्री ऑडिट के लिए।"
---
## **परिचय**

Aspose.Slides प्रस्तुति के फॉर्मेट की पहचान कर सकता है और उसके दस्तावेज़ मेटाडेटा को पूरी प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, इन्वेंट्री बनानी हो, या गुणों की जाँच करनी हो इससे पहले कि आप तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्के निरीक्षण को [PresentationFactory](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/) और [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) के माध्यम से, साथ ही [DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) के लक्ष्यित अपडेट्स के माध्यम से दर्शाता है।

## **प्रस्तुति फ़ॉर्मेट की जाँच**

यदि आपके पास पहले से लोड की हुई प्रस्तुति है, तो लोड करने के बाद जाँच के लिए [Determine the Original Presentation Format](/slides/hi/nodejs-java/detect-presentation-source-format/) देखें और लेगेसी PPT, PPS, और POT स्ट्रीम्स की सीमाओं के बारे में पढ़ें।

Use [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) to inspect a file without creating a [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) instance. The [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/getloadformat/) method reports the detected format, such as PPTX, PPT, or ODP.

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

## **हल्का प्रस्तुति इन्वेंट्री बनाना**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो वैधता, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंट्री की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) का उपयोग करके [PresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह तरीका [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूरी प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं होती।

[DocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/) द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getSlides) | कुल स्लाइडों की संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | छिपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getNotes) | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | जब उपलब्ध हो तो कुल पैराग्राफों की संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getWords) | कुल शब्दों की संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक कॉम्पैक्ट इन्वेंट्री प्रिंट करता है। यह [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) को [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) के साथ मिलाकर फ़ॉन्ट, थीम और स्लाइड शीर्षकों जैसी सामग्री समूहों को प्रदर्शित करता है।

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

प्रत्येक [HeadingPair](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/) समूह नाम को [HeadingPair.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/#getName) के माध्यम से और उस समूह में आइटमों की संख्या को [HeadingPair.getCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/headingpair/#getCount) के माध्यम से प्राप्त करता है। [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग‑पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संचित मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। अनुपलब्ध गुण डिफ़ॉल्ट मूल्यों द्वारा प्रतिनिधित्व किए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाले एप्लिकेशन ने दस्तावेज़ गुणों को अपडेट नहीं किया हो।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया काउंट सहित विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग‑पेयर और भाग‑शीर्षक। उपलब्धता इस बात पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा नहीं अपडेट किया गया है, तो Aspose.Slides उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है न कि स्लाइडों से गणना किए हुए मान।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ और शब्द गिनती, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडेटा उपलब्ध न हो सकते हैं, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या खाली एरे को इस बात का प्रमाण न मानें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंट्री और प्रारंभिक जाँच के लिए हल्का मेटाडेटा दृष्टिकोण उपयोग करें। जब परिणाम को मेमोरी‑में परिवर्तन को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करना हो, तब प्रस्तुति लोड करें और उसका लाइव ऑब्जेक्ट मॉडल निरीक्षण करें।

## **प्रस्तुति गुण अपडेट करें**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) द्वारा लौटाए गए गुणों को [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस बनाए बिना भी बदला जा सकता है। परिवर्तन करें [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) के साथ, और फिर बाइंडेड प्रस्तुति को [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) के साथ लिखें।

नीचे मूल दस्तावेज़ गुणों की छवि है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ गुण](input_properties.png)

नीचे उदाहरण शीर्षक और अंतिम‑सहेजे समय को बदलता है तथा परिणाम को नई फ़ाइल में लिखता है:

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

नीचे अपडेट किए गए दस्तावेज़ गुणों की छवि है।

![PowerPoint प्रस्तुति के बदलें हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँच और सुरक्षा सेटिंग्स के लिए नीचे दिए गए लेख देखें:

- [Password‑Protect Presentations](/slides/hi/nodejs-java/password-protected-presentation/)
- [Write‑Protect Presentations](/slides/hi/nodejs-java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जांचूँ कि फ़ॉन्ट एंबेडेड हैं और कौन‑से हैं?**

प्रेजेंटेशन लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getfontsmanager/) का उपयोग करें। एंबेडेड फ़ॉन्ट प्राप्त करने के लिए [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट प्राप्त करने के लिए [FontsManager.getFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/getfonts/) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स की पहचान करें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एंबेडेड नहीं हैं।

**मैं जल्दी कैसे बता सकता हूँ कि फ़ाइल में छिपी स्लाइडें हैं और कितनी हैं?**

जब संग्रहित दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) को [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) और [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) के माध्यम से पढ़ें। यह हल्के इन्वेंट्री के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है, या लाइव मानों को सत्यापित करने हेतु [Presentation.getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) के माध्यम से iterate करके प्रत्येक स्लाइड के [Slide.getHidden](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/gethidden/) को जांचें।

**क्या मैं कस्टम स्लाइड आकार और अभिविन्यास का पता लगा सकता हूँ, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हां। प्रस्तुति लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslidesize/) को कॉल करें। वर्तमान सेटिंग्स की अपेक्षित प्रीसेट और आयामों से तुलना करने के लिए [SlideSize.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/getsize/), और [SlideSize.getOrientation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/getorientation/) का उपयोग करें।

**क्या कोई तेज़ तरीका है जिससे पता चले कि चार्ट्स बाहरी डेटा स्रोतों का संदर्भ देते हैं?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) को ढूंढ़ें और [ChartData.getDataSourceType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) को कॉल करें। बाहरी वर्कबुक के लिए, [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) को कॉल करें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ पहचानते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि के लिए अलग संसाधन जाँच आवश्यक है।

**मैं कैसे 'भारी' स्लाइड्स की पहचान करूँ जो रेंडरिंग या PDF एक्सपोर्ट को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getslides/) और प्रत्येक स्लाइड के [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getShapes) संग्रह को ट्रैवर्स करें। आकार, बड़ी छवियों, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और प्रतिनिधि रेंडर या एक्सपोर्ट मापें इससे पहले कि स्लाइड को निश्चित प्रदर्शन बाधा माना जाए।