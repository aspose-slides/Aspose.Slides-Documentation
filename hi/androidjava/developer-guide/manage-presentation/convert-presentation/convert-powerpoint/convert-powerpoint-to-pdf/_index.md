---
title: Android पर PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint को बदलें
- प्रस्तुति को बदलें
- PowerPoint से PDF
- प्रस्तुति से PDF
- PPT से PDF
- PPT को PDF में बदलें
- PPTX से PDF
- PPTX को PDF में बदलें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों सहित।"
---
## **अवलोकन**

Android पर PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF फ़ॉर्मेट में बदलना कई लाभ प्रदान करता है, जिसमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति के लेआउट और फ़ॉर्मेटिंग को संरक्षित करना शामिल है। यह गाइड दिखाता है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे बदलें, छवि गुणवत्ता को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपे स्लाइड शामिल करें, PDF फ़ाइलों को पासवर्ड से सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएँ, रूपांतरण के लिए विशिष्ट स्लाइड चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्न फ़ॉर्मेट में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में बदलने के लिए, फ़ाइल नाम को [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड को उजागर करता है जो आमतौर पर प्रस्तुति को PDF में बदलने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के लिए, जब एक प्रस्तुति को PDF में बदलते हैं, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको बदलने की अनुमति देता है:

* पूरे प्रस्तुतियों को PDF में
* एक प्रस्तुति से विशिष्ट स्लाइड को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, सुनिश्चित करता है कि उत्पन्न PDF मूल प्रस्तुतियों से बहुत करीब मेल खाएँ। तत्वों और गुणों को रूपांतरण में सटीक रूप से रेंडर किया जाता है, जिसमें:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* टेबल

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है।

निम्न उदाहरण एक प्रस्तुति लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दृश्यमान स्लाइड को PDF में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑से‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ वर्णित प्रक्रिया के वास्तविक कार्यान्वयन के लिए इस कनवर्टर के साथ एक परीक्षण चला सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास के अंतर्गत गुण—प्रदान करता है, जिससे आप उत्पन्न PDF को कस्टमाइज़ कर सकते हैं, पासवर्ड के साथ PDF को लॉक कर सकते हैं, या रूपांतरण प्रक्रिया को कैसे आगे बढ़ना है यह निर्दिष्ट कर सकते हैं।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी पसंदीदा गुणवत्ता सेटिंग परिभाषित कर सकते हैं, यह निर्दिष्ट कर सकते हैं कि मेटाफाइल्स को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, और बहुत कुछ।

निम्न उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है जिसमें JPEG गुणवत्ता 90 पर सेट है, छवि रिज़ॉल्यूशन 300 DPI पर सेट है, मेटाफाइल्स PNG के रूप में सहेजे गए हैं, और Flate टेक्स्ट संपीड़न है।

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **स्वचालित रूप से इमेज संपीड़न चुनें**

जब किसी प्रस्तुति में कई फ़ोटोग्राफ़ या स्क्रीनशॉट होते हैं, तो निर्यात किए गए PDF का आकार कम करने से ईमेल या डाउनलोड करना आसान हो जाता है। PDF निर्यात के दौरान प्रत्येक छवि के लिए सबसे उपयुक्त संपीड़न एल्गोरिद्म को स्वचालित रूप से चुनने के लिए [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) को `true` के साथ कॉल करें।

निम्न उदाहरण एक मौजूदा प्रस्तुति लोड करता है, स्वचालित इमेज संपीड़न चयन को सक्षम करता है, और इसे PDF दस्तावेज़ के रूप में सहेजता है। अन्य सभी PDF निर्यात सेटिंग्स अपने डिफ़ॉल्ट मान रखती हैं।

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

यह विकल्प प्रत्येक छवि के लिए एक संपीड़न एल्गोरिद्म चुनता है। [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) को पास किया गया मान घटाने से JPEG छवि गुणवत्ता कम हो जाती है, जबकि [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) को पास किया गया मान घटाने से छवियों को कम रिज़ॉल्यूशन पर डाउनसैंपल किया जा सकता है, जिससे विवरण कम हो सकता है। स्वचालित संपीड़न चयन को सक्षम करने से इन सेटिंग्स में से कोई भी स्वयं नहीं घटता।

इमेज संपीड़न एल्गोरिद्म चुनने के लिए अतिरिक्त प्रोसेसिंग समय और मेमोरी की आवश्यकता होती है। आकार में कमी प्रस्तुति की छवियों और निर्यात सेटिंग्स पर निर्भर करती है; प्रत्येक प्रस्तुति के लिए निश्चित कमी की गारंटी नहीं है।

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट के रूप में संरक्षित रखें**

यदि कोई प्रस्तुति एम्बेडेड Excel वर्कबुक रखती है, तो आप चाह सकते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी देख सकें और स्लाइड देख सकें। परिणामस्वरूप PDF में एम्बेडेड OLE फ़ाइलों को अटैचमेंट के रूप में संरक्षित रखने के लिए [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) को `true` के साथ कॉल करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू इमेज या आइकन PDF पेज पर रेंडर होती है, लेकिन उसकी एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` पर सेट करने से फ़ाइल डेटा अतिरिक्त रूप से शामिल हो जाता है। प्रीव्यू एक दृश्य प्रतिनिधित्व बना रहता है; अटैचमेंट प्राप्तकर्ताओं को एंबेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पेज पर एक इंटरैक्टिव Excel वर्कशीट नहीं बनता।

निम्न उदाहरण एक ऐसी प्रस्तुति लोड करता है जिसमें पहले से एम्बेडेड Excel वर्कबुक मौजूद है और इसे वर्कबुक अटैचमेंट के साथ PDF में निर्यात करता है।

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

परिणाम की जांच करने के लिए:

1. Adobe Acrobat Reader जैसे फ़ाइल अटैचमेंट को सपोर्ट करने वाले व्यूअर में निर्यातित PDF खोलें।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें।
3. अटैचमेंट को सहेजें और डेटा जांचने के लिए इसे Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू अटैचमेंट से अलग है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को निषिद्ध करता है, PDF/A-2 केवल PDF/A अटैचमेंट की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जैसे Excel वर्कबुक, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides के विशेष प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात को नहीं दर्शाता।
{{% /alert %}}

### **छिपी स्लाइडों के साथ PowerPoint को PDF में बदलें**

यदि किसी प्रस्तुति में छिपी स्लाइडें हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) मेथड का उपयोग करके छिपी स्लाइडों को परिणामस्वरूप PDF में पेज के रूप में शामिल कर सकते हैं।

निम्न उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जिसमें सभी छिपी स्लाइडें भी शामिल हैं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Password‑Protected PDF के साथ PowerPoint को बदलें**

निम्न उदाहरण एक प्रस्तुति को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` आवश्यक है। एक्सेस अनुमतियाँ प्रिंटिंग की अनुमति देती हैं, जिसमें उच्च‑गुणवत्ता प्रिंटिंग भी शामिल है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **फ़ॉन्ट प्रतिस्थापन पता करें**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) मेथड प्रदान करता है, जिससे आप प्रस्तुति‑से‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगा सकते हैं।

निम्न उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। चेतावनी केवल तभी प्रिंट होती है जब निर्यात के दौरान अनुपलब्ध फ़ॉन्ट का प्रतिस्थापन किया जाता है।

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [Font Substitution](/slides/hi/androidjava/font-substitution/) लेख।
{{% /alert %}}

### **समर्पित बोल्ड फ़ॉन्ट शैली के बिना फ़ॉन्ट को संभालें**

एक प्रस्तुति टेक्स्ट पर बोल्ड फ़ॉर्मेट लागू कर सकती है भले ही उसके फ़ॉन्ट में समर्पित बोल्ड टाइपफ़ेस न हो। टेक्स्ट सिंथेटिक बोल्डिंग द्वारा अभी भी बोल्ड दिख सकता है, जो नियमित glyphs को कृत्रिम रूप से मोटा करता है। जब वह टेक्स्ट बहुत भारी दिखता है या PDF में वांछित रूप से अलग दिखता है, तो [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) को `true` के साथ कॉल करने का प्रयास करें। यह विकल्प निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रेंडर करता है और कुछ फ़ॉन्ट्स के लिए इसकी दिखावट सुधार सकता है। इसका डिफ़ॉल्ट मान `false` है।

नमूना प्रस्तुति दो टेक्स्ट बॉक्स रखती है: एक नियमित टेक्स्ट के साथ और एक समान फ़ॉन्ट पर बोल्ड फ़ॉर्मेट लागू किए साथ, जिसमें समर्पित बोल्ड टाइपफ़ेस नहीं है। निम्न उदाहरण प्रस्तुति को लोड करता है, असमर्थित फ़ॉन्ट शैलियों के रास्टराइज़ेशन को सक्षम करता है, और इसे PDF में निर्यात करता है:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

निम्न प्रीव्यू निष्क्रिय आउटपुट और सक्रिय आउटपुट को दर्शाते हैं। इस उदाहरण में, विकल्प निष्क्रिय होने पर बोल्ड टेक्स्ट के स्ट्रोक मोटे होते हैं। विकल्प सक्रिय होने पर, उसके स्ट्रोक हल्के होते हैं; नियमित टेक्स्ट अपरिवर्तित रहता है। अपने प्रस्तुति के लिए सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प निष्क्रिय (`false`, डिफ़ॉल्ट) | विकल्प सक्रिय (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प सक्रिय करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: इसे OCR के बिना चयन, कॉपी या टेक्स्ट के रूप में खोजा नहीं जा सकता, और 800% ज़ूम पर किनारे अधिक नरम दिखते हैं। नियमित टेक्स्ट अभी भी खोज योग्य रहता है। विकल्प निष्क्रिय होने पर, दोनों स्ट्रिंग्स टेक्स्ट ही रहती हैं।

यह विकल्प तब टेक्स्ट को रास्टराइज़ करता है जब उसका फ़ॉन्ट समर्पित बोल्ड टाइपफ़ेस नहीं रखता। [Font substitution](/slides/hi/androidjava/font-substitution/) मूल फ़ॉन्ट उपलब्ध न होने पर दूसरे फ़ॉन्ट को चुनता है।

## **PowerPoint से चयनित स्लाइड को PDF में बदलें**

निम्न उदाहरण एक प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड संख्या एक‑आधारित है, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड होना आवश्यक है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में बदलें**

निम्न उदाहरण एक प्रस्तुति से पहली स्लाइड को 612 × 792 पॉइंट्स (8.5 × 11 इंच) स्लाइड आकार वाली नई प्रस्तुति में कॉपी करता है। यह स्लाइड कंटेंट को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // नई प्रस्तुति के साथ बनाई गई खाली स्लाइड को हटाएँ।
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

निम्न उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, प्रत्येक स्लाइड के स्पीकर नोट्स को स्लाइड के नीचे रखता है। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF के लिए एक्सेसिबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड एक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया दर्शाता है जो विभिन्न अनुपालन मानकों के आधार पर कई PDFs बनाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides PDF रूपांतरण संचालन को सपोर्ट करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल फ़ॉर्मेट में बदल सकते हैं। आप [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), और [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण संचालन विशेष फ़ॉर्मेट में—[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), और [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **ध्यान दें:** PDF/UA में निर्यात करते समय, Aspose.Slides SmartArt, चार्ट और फॉर्मूले जैसी जटिल ग्राफिक्स को एक ही आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में नहीं संरक्षित किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूपांतरण का समर्थन करता है। आप अपनी फ़ाइलों पर इटरट कर सकते हैं और प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या बदले गए PDF को पासवर्ड से सुरक्षित करना संभव है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और एक्सेस अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइडें कैसे शामिल करूँ?**

छिपी स्लाइडों को परिणामस्वरूप PDF में शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) को `true` के साथ कॉल करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) और [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) जैसे मेथड का उपयोग करके छवि गुणवत्ता को नियंत्रित कर सकते हैं ताकि आपके PDF में उच्च‑गुणवत्ता वाली छवियां सुनिश्चित हों।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको ऐसे PDFs निर्यात करने की अनुमति देता है जो [विभिन्न मानकों](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) के अनुरूप हों, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ एक्सेसिबिलिटी और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Android via Java दस्तावेज़ीकरण](/slides/hi/androidjava/)
- [Aspose.Slides for Android via Java API संदर्भ](https://reference.aspose.com/slides/androidjava/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)