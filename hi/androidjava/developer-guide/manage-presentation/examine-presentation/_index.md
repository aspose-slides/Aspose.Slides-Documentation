---
title: एन्ड्रॉइड पर प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/androidjava/examine-presentation/
keywords:
- प्रस्तुति प्रारूप
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
- Android
- Java
- Aspose.Slides
description: "Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और समझदारीपूर्ण सामग्री ऑडिट के लिए।"
---
## **समीक्षा**

Aspose.Slides एक प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और उसके दस्तावेज़ मेटाडेटा को पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करने, इन्वेंट्री बनाने, या गुणों की जांच करने की आवश्यकता होती है, इससे पहले कि आप यह तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस करना है या नहीं।

यह लेख [PresentationFactory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) के माध्यम से लाइटवेट निरीक्षण तथा [IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/) के माध्यम से लक्षित अपडेट्स को दर्शाता है।

## **प्रस्तुति फ़ॉर्मेट की जाँच**

यदि आपके पास पहले से ही लोडेड प्रस्तुति है, तो लोड होने के बाद पहचान और लेगेसी PPT, PPS, और POT स्ट्रीम की सीमाओं के लिए [Determine the Original Presentation Format](/slides/hi/androidjava/detect-presentation-source-format/) देखें।

फ़ाइल की जाँच करने के लिए बिना [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें। [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) मेथड पता लगाए गए फ़ॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **हल्का प्रस्तुति इन्वेंट्री बनाएँ**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो वैधता, अनुक्रमण, या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंट्री की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके एक [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह विधि एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस नहीं बनाती और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को ट्रैवर्स करने की आवश्यकता नहीं होती।

[IDocumentProperties] द्वारा प्रदर्शित विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| Method | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | स्लाइड की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | छिपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | नोट्स वाले स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | यदि उपलब्ध हो तो पैराग्राफों की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्न उदाहरण इन मानों को एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) ऑब्जेक्ट बनाए बिना पढ़ता है और एक संक्षिप्त इन्वेंट्री प्रिंट करता है। यह फ़ॉन्ट, थीम, और स्लाइड शीर्षकों जैसे कंटेंट समूहों को दिखाने के लिए [getHeadingPairs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) के साथ भी संयोजित करता है।

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

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iheadingpair/) एक समूह का नाम और उस समूह में आइटमों की संख्या प्रदान करता है। [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) एक फ्लैट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमबद्ध शीर्षकों की संख्या को उपभोग करें।

### **संचित मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड या ट्रैवर्स नहीं करता। गायब गुण डिफ़ॉल्ट मानों द्वारा प्रदर्शित होते हैं, और यदि अंतिम बार फ़ाइल सहेजने वाले एप्लिकेशन ने अपने दस्तावेज़ गुण अपडेट नहीं किए तो संग्रहीत मान पुराने हो सकते हैं।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द, और मल्टीमीडिया गिनती के लिए विस्तारित दस्तावेज़ गुण, साथ ही हेडिंग पेयर और पार्ट टाइटल्स प्रदान करता है। उपलब्धता इस बात पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन से गुण लिखे थे।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑सारांश गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या दस्तावेज़ निर्माता द्वारा रिफ़्रेश नहीं हुआ है, तो Aspose.Slides इसे स्लाइड्स से गणना करने के बजाय संग्रहीत या डिफ़ॉल्ट मान लौटाता है।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पेज, पैराग्राफ, और शब्द गिनती प्रदान करता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर, और पार्ट‑टाइटल मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंट्री गुण डिफ़ॉल्ट मान वापस कर सकते हैं। शून्य मान या खाली एरे को यह मानकर न लेँ कि संबंधित सामग्री अनुपस्थित है।

इन्वेंट्री और प्रारम्भिक जांचों के लिए लाइटवेट मेटाडेटा दृष्टिकोण का प्रयोग करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तब प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल की जांच करें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए गुणों को भी एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए बिना बदला जा सकता है। परिवर्तन को [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) से लागू करें, और फिर बंधित प्रस्तुति को [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) से लिखें।

निम्न चित्र मूल दस्तावेज़ गुणों को दर्शाता है।

![PowerPoint प्रस्तुति के मूल दस्तावेज़ गुण](input_properties.png)

निम्न उदाहरण शीर्षक और अंतिम-सहेजे गए समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

![PowerPoint प्रस्तुति के बदलें गये दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँचों और संरक्षण सेटिंग्स के लिए, निम्न लेख देखें:

- [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन से हैं?**

प्रस्तुति को लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getFontsManager--) का प्रयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स को प्राप्त करने के लिए [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता लगा सकता हूँ कि फाइल में छिपी हुई स्लाइड्स हैं और उनकी संख्या क्या है?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) और [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के माध्यम से [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) पढ़ें। यह लाइटवेट इन्वेंट्री के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है, या आपको लाइव मानों की पुष्टि करनी हो, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) के द्वारा इटरेट करें और प्रत्येक स्लाइड के [ISlide.getHidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getHidden--) मेथड की जांच करें।

**क्या मैं पता लगा सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफ़ॉल्ट्स से भिन्न हैं?**

हां। प्रस्तुति को लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideSize--) को कॉल करें। वर्तमान सेटिंग्स की अपेक्षित प्रीसेट और आयामों से तुलना करने के लिए [ISlideSize.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getSize--), और [ISlideSize.getOrientation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getOrientation--) का उपयोग करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ देते हैं, यह जल्दी से देखना संभव है?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/) खोजें और [IChartData.getDataSourceType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) को कॉल करें। बाहरी वर्कबुक के लिए, [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कॉल करें। डेटा स्रोत प्रकार और पथ एक बाहरी संदर्भ दर्शाते हैं, लेकिन लक्ष्य उपलब्धता की पुष्टि के लिए अलग रिसोर्स जाँच आवश्यक है।

**मैं कैसे निर्धारित कर सकता हूं कि कौन सी 'भारी' स्लाइड्स हैं जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) और प्रत्येक स्लाइड के [IBaseSlide.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getShapes--) कलेक्शन को ट्रैवर्स करें। आकार की संख्या और बड़े इमेज, इफ़ेक्ट्स, एनिमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और स्लाइड को वास्तविक प्रदर्शन बाधा मानने से पहले एक प्रतिनिधि रेंडर या एक्सपोर्ट मापें।