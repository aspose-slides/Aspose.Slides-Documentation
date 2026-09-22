---
title: जावा में प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/java/examine-presentation/
keywords:
- प्रस्तुति स्वरूप
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अपडेट करें
- PPTX जांचें
- PPT जांचें
- ODP जांचें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: जावा का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडाटा का अन्वेषण करें ताकि तेज़ अंतर्दृष्टि और अधिक बुद्धिमान सामग्री ऑडिट मिल सकें।
---
## **समीक्षा**

Aspose.Slides प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूरी प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडाटा को पढ़ सकता है। यह तब उपयोगी है जब आपको फ़ाइलों को वर्गीकृत करना हो, एक इन्वेंटरी बनानी हो, या गुणों की जांच करनी हो इससे पहले कि आप यह तय करें कि प्रस्तुति सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्की जांच को [PresentationFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) के माध्यम से प्रदर्शित करता है, साथ ही लक्षित अपडेट को [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) के माध्यम से दिखाता है।

## **प्रस्तुति फ़ॉर्मेट की जाँच**

यदि आपके पास पहले से लोड की गई प्रस्तुति है, तो लोड करने के बाद जाँच और लेगेसी PPT, PPS, और POT स्ट्रिम की सीमाओं के लिए [Determine the Original Presentation Format](/slides/hi/java/detect-presentation-source-format/) देखें।

फ़ाइल को जांचने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें बिना एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस बनाए। [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) मेथड पता लगाए गए फ़ॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **हल्की प्रस्तुति इन्वेंटरी बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो आपको सत्यापन, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंटरी की आवश्यकता हो सकती है। इस स्थिति में, एक [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें, और फिर दस्तावेज़ मेटाडाटा पढ़ने के लिए [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करें। यह तरीका एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस नहीं बनाता और पूरी प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं होती।

IDocumentProperties द्वारा प्रदर्शित विस्तारित गुण निम्नलिखित इन्वेंटरी मान प्रदान करते हैं:

| विधि | इन्वेंटरी मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSlides--) | स्लाइडों की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | छुपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getNotes--) | नोट्स वाली स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | कुल पैराग्राफ़ों की संख्या, जब उपलब्ध हो। |
| [getWords](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getWords--) | कुल शब्दों की संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्नलिखित उदाहरण इन मानों को एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक संक्षिप्त इन्वेंटरी प्रदर्शित करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) के साथ मिलाकर फ़ॉन्ट, थीम, और स्लाइड शीर्षक जैसे कंटेंट समूह दिखाता है।

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iheadingpair/) एक समूह का नाम और उस समूह में वस्तुओं की संख्या प्रदान करता है। [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) एक सपाट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट लगातार शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडाटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए इन्वेंटरी गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड और ट्रैवर्स नहीं करता। लापता गुणों को डिफ़ॉल्ट मानों से दर्शाया जाता है, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम फ़ाइल सहेजने वाले एप्लिकेशन ने दस्तावेज़ गुणों को अपडेट नहीं किया।

- **PPTX:** यह फ़ॉर्मेट स्लाइड, नोट, छुपी‑स्लाइड, पैराग्राफ़, शब्द, और मल्टीमीडिया गणना के लिए विस्तारित दस्तावेज़ गुण, साथ ही हेडिंग पेयर और भाग शीर्षक प्रदान करता है। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से गुण लिखे।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा रीफ़्रेश नहीं किया गया है, तो Aspose.Slides स्लाइडों से गणना करने के बजाय उसकी संग्रहीत या डिफ़ॉल्ट मूल्य लौटाता है।
- **ODP:** OpenDocument मेटाडाटा सामान्य दस्तावेज़ आँकड़े प्रदान करता है, जैसे पृष्ठ, पैराग्राफ़ और शब्द गणना, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छुपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडाटा उपलब्ध नहीं हो सकते, और इन्वेंटरी गुण डिफ़ॉल्ट मान लौटा सकते हैं। शून्य मान या खाली एरे को यह प्रमाण न मानें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंटरी और प्रारम्भिक जाँचों के लिए हल्के मेटाडाटा दृष्टिकोण का उपयोग करें। जब परिणाम को स्मृति‑में बदलाव को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करना हो, तो प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल की जाँच करें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए गुणों को एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस बनाए बिना भी बदला जा सकता है। परिवर्तनों को [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) से लागू करें, और फिर बाउंड प्रस्तुति को [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) के साथ लिखें।

निम्नलिखित चित्र मूल दस्तावेज़ गुण दिखाता है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्नलिखित उदाहरण शीर्षक और अंतिम‑सेव समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

निम्नलिखित चित्र अपडेट किए गए दस्तावेज़ गुण दिखाता है।

![PowerPoint प्रस्तुति के बदलें हुए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जांच और संरक्षण सेटिंग्स के लिए, निम्नलिखित लेख देखें:

- [प्रस्तुति को पासवर्ड से सुरक्षित करें](/slides/hi/java/password-protected-presentation/)
- [प्रस्तुति को लिखने से सुरक्षित करें](/slides/hi/java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं यह कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं या नहीं और कौन‑से हैं?**

प्रस्तुति को लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getFontsManager--) का उपयोग करें। एम्बेडेड फ़ॉन्ट प्राप्त करने के लिए [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) को कॉल करें और प्रस्तुति में उपयोग किए गए फ़ॉन्ट प्राप्त करने के लिए [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट को खोजें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**फ़ाइल में छुपी हुई स्लाइडें हैं और उनकी संख्या कितनी है, इसे मैं जल्दी से कैसे पता करूँ?**

जब संग्रहीत दस्तावेज़ मेटाडाटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) के माध्यम से [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) को पढ़ें और [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) का उपयोग करें। यह हल्की इन्वेंटरी के लिए उपयुक्त है। यदि प्रस्तुति को स्मृति में संशोधित किया गया है, तो संग्रहीत मेटाडाटा अनुपलब्ध या पुराना हो सकता है, या आपको लाइव मानों की पुष्टि करनी हो, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) के माध्यम से इटररेट करें और प्रत्येक स्लाइड के [ISlide.getHidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getHidden--) मेथड को जांचें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। प्रस्तुति को लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlideSize--) को कॉल करें। वर्तमान सेटिंग्स की अपेक्षित प्रीसेट और आयामों से तुलना करने के लिए [ISlideSize.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getSize--), और [ISlideSize.getOrientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getOrientation--) का उपयोग करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों को संदर्भित कर रहे हैं, यह जल्दी से देखने का कोई तरीका है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/) को खोजें और [IChartData.getDataSourceType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getDataSourceType--) को कॉल करें। बाहरी वर्कबुक के लिए, [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कॉल करें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ को पहचानते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि करने के लिए एक अलग रिसोर्स जांच आवश्यक है।

**मैं उन 'भारी' स्लाइडों का मूल्यांकन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) और प्रत्येक स्लाइड के [IBaseSlide.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getShapes--) संग्रह को ट्रैवर्स करें। आकार गणना और बड़े चित्र, प्रभाव, एनीमेशन, या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेतों के रूप में उपयोग करें, और स्लाइड को पुष्टि किए गए प्रदर्शन बाधा मानने से पहले एक प्रतिनिधिक रेंडर या निर्यात को मापें।