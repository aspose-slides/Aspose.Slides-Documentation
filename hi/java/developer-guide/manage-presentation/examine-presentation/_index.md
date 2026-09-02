---
title: Java में प्रस्तुति जानकारी प्राप्त करें और अद्यतन करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/java/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
- प्रस्तुति गुण
- दस्तावेज़ गुण
- गुण प्राप्त करें
- गुण पढ़ें
- गुण बदलें
- गुण संशोधित करें
- गुण अद्यतन करें
- PPTX का परीक्षण करें
- PPT का परीक्षण करें
- ODP का परीक्षण करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड्स, संरचना और मेटाडेटा का पता लगाएँ, तेज़ अंतर्दृष्टि और बुद्धिमान सामग्री ऑडिट्स के लिए।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना उसके दस्तावेज़ मेटाडेटा को पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करने, इन्वेंट्री बनाने, या गुणों की जांच करने की आवश्यकता होती है, इससे पहले कि आप तय करें कि प्रस्तुति की सामग्री को लोड और प्रोसेस किया जाए।

यह लेख हल्की जाँच को [PresentationFactory](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) के माध्यम से, तथा लक्षित अपडेट को [IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) के माध्यम से प्रदर्शित करता है।

## **प्रस्तुति फ़ॉर्मेट की जाँच**

फ़ाइल को बिना [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) उदाहरण बनाए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके निरीक्षण करें। [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) मेथड पता लगाए गए फ़ॉर्मेट की रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **हल्का प्रस्तुति इन्वेंट्री बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, अनुक्रमण या दस्तावेज़‑प्रबंधन प्रणाली के लिए एक संक्षिप्त इन्वेंट्री की आवश्यकता हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके एक [IPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह दृष्टिकोण [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट नहीं बनाता और संपूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार नहीं करता।

[IDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/) द्वारा उजागर विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getSlides--) | स्लाइड्स की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | छिपी हुई स्लाइड्स की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getNotes--) | नोट्स वाली स्लाइड्स की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | उपलब्ध होने पर पैराग्राफ़ की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getWords--) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्नलिखित उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक संक्षिप्त इन्वेंट्री प्रिंट करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) के साथ मिलाकर फ़ॉन्ट्स, थीम्स और स्लाइड शीर्षकों जैसे सामग्री समूह प्रदर्शित करता है।

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

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iheadingpair/) समूह का नाम और उस समूह में आइटम्स की संख्या प्रदान करता है। [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) एक सपाट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **सहेजे गए मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को दर्शाते हैं। Aspose.Slides इस कॉल के लिए इन मानों को पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड या पार नहीं करता। अनुपलब्ध गुणों को डिफ़ॉल्ट मानों से दर्शाया जाता है, और संग्रहीत मान पुराने हो सकते हैं यदि अंतिम बार फ़ाइल सहेजने वाले अनुप्रयोग ने अपने दस्तावेज़ गुणों को अपडेट नहीं किया था।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द और मल्टीमीडिया गिनती के लिये विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग पेयर्स और भाग शीर्षक। उपलब्धता इस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट संबंधित दस्तावेज़‑समरी गुण संग्रहीत कर सकता है। यदि कोई गुण अनुपलब्ध है या निर्माता ने उसे रीफ़्रेश नहीं किया, तो Aspose.Slides उसका संग्रहीत या डिफ़ॉल्ट मान लौटाता है, न कि स्लाइड्स से गणना किया हुआ मान।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पृष्ठ, पैराग्राफ और शब्द गिनती प्रदान करता है, लेकिन ये मान हर PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर और भाग‑शीर्षक मेटाडेटा अनुपलब्ध हो सकता है, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौटाएंगे। शून्य मान या ख़ाली एरे को यह प्रमाण न मानें कि संबंधित सामग्री अनुपस्थित है।

इन्वेंट्री और प्रारम्भिक जाँच के लिये हल्की मेटाडेटा पद्धति का उपयोग करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री को सत्यापित करना हो, तब प्रस्तुति को लोड करके उसके लाइव ऑब्जेक्ट मॉडल की जाँच करें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए गुणों को भी बिना [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) उदाहरण बनाए बदला जा सकता है। परिवर्तन को [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) के साथ लागू करें, और फिर बंधित प्रस्तुति को [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) से लिखें।

निम्नलिखित चित्र मूल दस्तावेज़ गुणों को दर्शाता है।

![PowerPoint प्रस्तुति की मूल दस्तावेज़ गुण](input_properties.png)

निम्नलिखित उदाहरण शीर्षक और अंतिम‑सहेजा समय बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

निम्नलिखित चित्र अपडेट किए गए दस्तावेज़ गुणों को दर्शाता है।

![PowerPoint प्रस्तुति के अपडेट किए गए दस्तावेज़ गुण](output_properties.png)

## **उपयोगी लिंक**

संबंधित सुरक्षा जाँच और सुरक्षा सेटिंग्स के लिये देखें:

- [प्रेज़ेंटेशन को पासवर्ड‑प्रोटेक्ट करें](/slides/hi/java/password-protected-presentation/)
- [प्रेज़ेंटेशन को लिखने‑से‑प्रोटेक्ट करें](/slides/hi/java/write-protected-presentation/)

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जाँचूं कि फोंट एम्बेडेड हैं और कौन से हैं?**

प्रेज़ेंटेशन लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getFontsManager--) का उपयोग करें। एम्बेडेड फोंट प्राप्त करने के लिये [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फोंट प्राप्त करने के लिये [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। दो परिणामों की तुलना करके उन फोंट्स को पहचानें जो रेंडरिंग के लिये आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता करूं कि फ़ाइल में छिपी हुई स्लाइड्स हैं और कितनी?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) और [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के माध्यम से [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) पढ़ें। यह हल्की इन्वेंट्री के लिये उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है, या लाइव मानों की जाँच की आवश्यकता हो, तो [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) को इटरेट करें और प्रत्येक स्लाइड के [ISlide.getHidden](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getHidden--) मेथड को देखें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में है, और क्या वह डिफ़ॉल्ट से अलग है?**

हां। प्रस्तुति लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlideSize--) को कॉल करें। वर्तमान सेटिंग्स को अपेक्षित प्रीसेट और आयामों से तुलना करने के लिये [ISlideSize.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getSize--), और [ISlideSize.getOrientation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidesize/#getOrientation--) का उपयोग करें।

**क्या चार्ट्स बाहरी डेटा स्रोतों का संदर्भ देते हैं, यह जल्दी से देखने का कोई तरीका है?**

हां। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/) को locate करें और [IChartData.getDataSourceType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getDataSourceType--) को कॉल करें। बाहरी वर्कबुक के लिये, [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कॉल करें। डेटा स्रोत प्रकार और पथ बाहरी संदर्भ को पहचानते हैं, लेकिन लक्ष्य की उपलब्धता सत्यापित करने के लिये अलग संसाधन जाँच आवश्यक है।

**मैं 'हेवी' स्लाइड्स का आकलन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) को पार करें और प्रत्येक स्लाइड के [IBaseSlide.getShapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getShapes--) संग्रह को देखें। आकार‑गणना, बड़े इमेजेज, इफ़ेक्ट्स, एनीमेशन या मल्टीमीडिया की उपस्थिति को स्क्रीनिंग संकेत के रूप में उपयोग करें, और किसी स्लाइड को पुष्टि करने से पहले प्रतिनिधि रेंडर या निर्यात मापें।