---
title: Android पर प्रस्तुति जानकारी प्राप्त करें और अपडेट करें
linktitle: प्रस्तुति जानकारी
type: docs
weight: 30
url: /hi/androidjava/examine-presentation/
keywords:
- प्रस्तुति फ़ॉर्मेट
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
- Android
- Java
- Aspose.Slides
description: "Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में स्लाइड, संरचना और मेटाडेटा का अन्वेषण करें, तेज़ अंतर्दृष्टि और अधिक समझदार सामग्री ऑडिट के लिए।"
---
## **सारांश**

Aspose.Slides प्रस्तुति के फ़ॉर्मेट की पहचान कर सकता है और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल बनाए बिना दस्तावेज़ मेटाडेटा पढ़ सकता है। यह तब उपयोगी होता है जब आपको फ़ाइलों को वर्गीकृत करना हो, इन्वेंट्री बनाना हो, या सामग्री को लोड और प्रोसेस करने का निर्णय लेने से पहले गुणों की जाँच करनी हो।

यह लेख हल्की जाँच को [PresentationFactory](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/) और [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) के माध्यम से, तथा लक्षित अपडेट को [IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/) के माध्यम से दर्शाता है।

## **प्रस्तुति फ़ॉर्मेट जांचें**

फ़ाइल को बिना [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए निरीक्षण करने के लिए [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करें। [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) मेथड पता लगाए गए फ़ॉर्मेट को रिपोर्ट करता है, जैसे PPTX, PPT, या ODP।

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

## **हल्की प्रस्तुति इन्वेंट्री बनाएं**

जब आप कई प्रस्तुति फ़ाइलों को प्रोसेस करते हैं, तो सत्यापन, अनुक्रमण, या दस्तावेज़ प्रबंधन प्रणाली के लिए एक कॉम्पैक्ट इन्वेंट्री आवश्यक हो सकती है। इस स्थिति में, [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) का उपयोग करके एक [IPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/) ऑब्जेक्ट प्राप्त करें, और फिर [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) को कॉल करके दस्तावेज़ मेटाडेटा पढ़ें। यह विधि एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस नहीं बनाती और पूर्ण प्रस्तुति ऑब्जेक्ट मॉडल को पार करने की आवश्यकता नहीं होती।

[IDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/) द्वारा उजागर किए गए विस्तारित गुण निम्नलिखित इन्वेंट्री मान प्रदान करते हैं:

| विधि | इन्वेंट्री मान |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | स्लाइडों की कुल संख्या। |
| [getHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | छिपी हुई स्लाइडों की संख्या। |
| [getNotes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | नोट्स वाले स्लाइडों की संख्या। |
| [getParagraphs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | उपलब्ध होने पर पैराग्राफों की कुल संख्या। |
| [getWords](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | शब्दों की कुल संख्या। |
| [getMultimediaClips](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | ऑडियो और वीडियो क्लिप्स की कुल संख्या। |

निम्नलिखित उदाहरण इन मानों को बिना [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) ऑब्जेक्ट बनाए पढ़ता है और एक कॉम्पैक्ट इन्वेंट्री प्रिंट करता है। यह [getHeadingPairs](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) को [getTitlesOfParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) के साथ संयोजित करके फ़ॉन्ट, थीम, और स्लाइड शीर्षक जैसी सामग्री समूहों को दिखाता है।

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

प्रत्येक [IHeadingPair](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iheadingpair/) एक समूह नाम और उस समूह में वस्तुओं की संख्या प्रदान करता है। [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) एक सपाट, क्रमबद्ध एरे लौटाता है, इसलिए प्रत्येक हेडिंग पेयर द्वारा निर्दिष्ट क्रमिक शीर्षकों की संख्या को उपभोग करें।

### **संग्रहीत मेटाडेटा और फ़ॉर्मेट सीमाएँ**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए इन्वेंट्री गुण स्रोत दस्तावेज़ में उपलब्ध मेटाडेटा को प्रतिबिंबित करते हैं। Aspose.Slides इस कॉल के लिए इन मूल्यों की पुनः गणना करने हेतु प्रस्तुति ऑब्जेक्ट मॉडल को लोड या पार नहीं करता। अनुपलब्ध गुण डिफ़ॉल्ट मानों द्वारा दर्शाए जाते हैं, और संग्रहीत मान पुराने हो सकते हैं यदि फ़ाइल को अंतिम बार सहेजने वाले अनुप्रयोग ने अपने दस्तावेज़ गुण अपडेट नहीं किए हों।

- **PPTX:** फ़ॉर्मेट स्लाइड, नोट, छिपी‑स्लाइड, पैराग्राफ, शब्द, और मल्टीमीडिया गणनाओं के लिए विस्तारित दस्तावेज़ गुण प्रदान करता है, साथ ही हेडिंग पेयर और भाग शीर्षक। उपलब्धता उस पर निर्भर करती है कि दस्तावेज़ निर्माता ने कौन‑से गुण लिखे हैं।
- **PPT:** बाइनरी फ़ॉर्मेट समान दस्तावेज़‑सारांश गुणों को संग्रहीत कर सकता है। यदि कोई गुण अनुपस्थित है या निर्माता द्वारा रीफ़्रेश नहीं किया गया है, तो Aspose.Slides उसके संग्रहीत या डिफ़ॉल्ट मान को लौटाता है, न कि स्लाइडों से गणना किया हुआ मूल्य।
- **ODP:** OpenDocument मेटाडेटा सामान्य दस्तावेज़ आँकड़े जैसे पृष्ठ, पैराग्राफ, और शब्द गणना प्रदान करता है, लेकिन ये मान प्रत्येक PowerPoint‑विशिष्ट विस्तारित गुण से मेल नहीं खाते। छिपी‑स्लाइड, नोट‑स्लाइड, मल्टीमीडिया, हेडिंग‑पेयर, और भाग‑शीर्षक मेटाडेटा उपलब्ध नहीं हो सकता, और इन्वेंट्री गुण डिफ़ॉल्ट मान लौट सकते हैं। शून्य मान या खाली एरे को यह प्रमाण न मानें कि सम्बंधित सामग्री अनुपस्थित है।

हल्की मेटाडेटा दृष्टिकोण का उपयोग इन्वेंट्री और प्रारंभिक जांच के लिए करें। जब परिणाम को मेमोरी में हुए बदलावों को प्रतिबिंबित करना हो या वास्तविक प्रस्तुति सामग्री की पुष्टि करनी हो, तो प्रस्तुति को लोड करके उसकी लाइव ऑब्जेक्ट मॉडल की जाँच करें।

## **प्रस्तुति गुण अपडेट करें**

[IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) द्वारा लौटाए गए गुणों को बिना [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस बनाए बदला भी जा सकता है। बदलावों को [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) के साथ लागू करें, और फिर बंधित प्रस्तुति को [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-) से लिखें।

निम्नलिखित छवि मूल दस्तावेज़ गुणों को दर्शाती है।

![Original document properties of the PowerPoint presentation](input_properties.png)

निम्नलिखित उदाहरण शीर्षक और अंतिम‑सहेजे गए समय को बदलता है और परिणाम को नई फ़ाइल में लिखता है:

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

निम्नलिखित छवि अपडेटेड दस्तावेज़ गुणों को दर्शाती है।

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **प्रयोगी लिंक**

संबंधित सुरक्षा जांच और संरक्षण सेटिंग्स के लिए निम्नलिखित लेख देखें:

- [Password-Protect Presentations](/slides/hi/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hi/androidjava/write-protected-presentation/)

## **FAQ**

**मैं कैसे जांच सकता हूँ कि फ़ॉन्ट एम्बेडेड हैं और कौन‑से हैं?**

प्रस्तुति लोड करें और [Presentation.getFontsManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getFontsManager--) का उपयोग करें। एम्बेडेड फ़ॉन्ट्स प्राप्त करने के लिए [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) को कॉल करें और प्रस्तुति द्वारा उपयोग किए गए फ़ॉन्ट्स के लिए [IFontsManager.getFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) को कॉल करें। दोनों परिणामों की तुलना करके उन फ़ॉन्ट्स को पहचानें जो रेंडरिंग के लिए आवश्यक हैं लेकिन एम्बेडेड नहीं हैं।

**मैं जल्दी से कैसे पता करूँ कि फ़ाइल में छिपी स्लाइडें हैं और उनकी संख्या क्या है?**

जब संग्रहीत दस्तावेज़ मेटाडेटा पर्याप्त हो, तो [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) और [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) के माध्यम से [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) पढ़ें। यह हल्की इन्वेंट्री के लिए उपयुक्त है। यदि प्रस्तुति मेमोरी में संशोधित हुई है, तो संग्रहीत मेटाडेटा अनुपलब्ध या पुराना हो सकता है; ऐसे में लाइव मानों को सत्यापित करने के लिए [Presentation.getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) के माध्यम से प्रत्येक स्लाइड के [ISlide.getHidden](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getHidden--) मेथड को जाँचें।

**क्या मैं पता कर सकता हूँ कि कस्टम स्लाइड आकार और अभिविन्यास उपयोग में हैं, और क्या वे डिफ़ॉल्ट से अलग हैं?**

हाँ। प्रस्तुति लोड करें और [Presentation.getSlideSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlideSize--) को कॉल करें। वर्तमान सेटिंग्स की तुलना अपेक्षित प्रीसेट और आयामों से करने के लिए [ISlideSize.getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getSize--) और [ISlideSize.getOrientation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidesize/#getOrientation--) का प्रयोग करें।

**क्या चार्ट्स के बाहरी डेटा स्रोतों को देखना आसान है?**

हाँ। प्रत्येक [Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/) को खोजें और [IChartData.getDataSourceType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) को कॉल करें। बाहरी वर्कबुक के लिए [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) को कॉल करें। डेटा स्रोत प्रकार और पथ बाहरी रेफ़रेंस को पहचानते हैं, लेकिन लक्ष्य की उपलब्धता की पुष्टि अलग संसाधन जाँच की मांग करती है।

**मैं 'भारी' स्लाइड्स का आकलन कैसे करूँ जो रेंडरिंग या PDF निर्यात को धीमा कर सकती हैं?**

कोई एकल जटिलता गुण नहीं है। [Presentation.getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) और प्रत्येक स्लाइड के [IBaseSlide.getShapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getShapes--) संग्रह को पार करें। आकार गणना, बड़े चित्र, इफ़ेक्ट, एनिमेशन या मल्टीमीडिया की उपस्थिति को संकेतक के रूप में उपयोग करें, तथा प्रतिनिधि रेंडर या निर्यात मापें, इससे पहले कि स्लाइड को पुष्टि किए गए प्रदर्शन बाधा के रूप में लेबल किया जाए।