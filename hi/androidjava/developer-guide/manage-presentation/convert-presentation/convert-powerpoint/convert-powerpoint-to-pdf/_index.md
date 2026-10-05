---
title: Android पर PPT और PPTX को PDF में बदलें [उन्नत सुविधाएँ शामिल]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
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
description: "Aspose.Slides for Android का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च-गुणवत्ता, खोज योग्य PDFs में बदलें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ।"
---
## **परिचय**

Android पर PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को PDF स्वरूप में बदलने से कई लाभ मिलते हैं, जिसमें विभिन्न उपकरणों पर अनुकूलता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को सुरक्षित रखना शामिल है। यह गाइड प्रस्तुतियों को PDF दस्तावेज़ों में बदलना, छवि गुणवत्ता नियंत्रित करने के विभिन्न विकल्पों का उपयोग करना, छिपी स्लाइड्स को शामिल करना, PDF फ़ाइलों को पासवर्ड‑सुरक्षित बनाना, फ़ॉन्ट प्रतिस्थापन का पता लगाना, रूपांतरण के लिए विशिष्ट स्लाइड्स का चयन करना, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करना दर्शाता है।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्न स्वरूपों में प्रस्तुतियों को PDF में बदल सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

PDF में प्रस्तुति को बदलने के लिए, फ़ाइल नाम को [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास में तर्क के रूप में पास करें और फिर [सहेजें](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) विधि का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [प्रस्तुति](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास वह [सहेजें](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) विधि प्रदान करता है जिसका सामान्यतः उपयोग प्रस्तुति को PDF में बदलने के लिए किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या सम्मिलित करता है। उदाहरण के लिए, जब प्रस्तुति को PDF में बदलते हैं, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" से और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में मान से भरता है। **ध्यान दें** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने का निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको बदलने की अनुमति देता है:

* पूरी प्रस्तुतियों को PDF में
* प्रस्तुति से विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करता है कि परिणामी PDFs मूल प्रस्तुतियों के बहुत करीब हों। रूपांतरण में तत्व और गुण सटीक रूप से रेंडर होते हैं, जिसमें शामिल हैं:

* छवियाँ
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक
* हेडर और फुटर
* बुलेट
* तालिकाएँ

## **PowerPoint को PDF में बदलें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides प्रदान की गई प्रस्तुति को अधिकतम गुणवत्ता स्तरों पर इष्टतम सेटिंग्स का उपयोग करके PDF में बदलने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है और डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके सभी दृश्यमान स्लाइड्स को PDF में सहेजता है।

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
Aspose एक मुफ्त ऑनलाइन [**PowerPoint से PDF कनवर्टर**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है। आप यहाँ वर्णित प्रक्रिया के वास्तविक कार्यान्वयन के लिए इस कनवर्टर के साथ एक परीक्षण चला सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में बदलें**

Aspose.Slides कस्टम विकल्प—[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास के तहत— प्रदान करता है जो आपको परिणामी PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया के आगे बढ़ने के तरीके को निर्दिष्ट करने की अनुमति देता है।

### **कस्टम विकल्पों के साथ PowerPoint को PDF में बदलें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए अपनी वांछित गुणवत्ता सेटिंग निर्धारित कर सकते हैं, यह निर्दिष्ट कर सकते हैं कि मेटा‑फ़ाइलों को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर सेट कर सकते हैं, छवियों के लिए DPI कॉन्फ़िगर कर सकते हैं, और अधिक।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है जिसमें JPEG गुणवत्ता 90 पर सेट है, छवि रेज़ॉल्यूशन 300 DPI पर सेट है, मेटा‑फ़ाइलें PNG के रूप में सहेजी गई हैं, और Flate टेक्स्ट संपीड़न उपयोग किया गया है।

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

### **एम्बेडेड OLE फ़ाइलों को PDF अटैचमेंट के रूप में संरक्षित रखें**

यदि प्रस्तुति में एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी एक्सेस कर सके और स्लाइड्स देख सके। परिणामस्वरूप PDF में एम्बेडेड OLE फ़ाइलों को अटैचमेंट के रूप में संरक्षित रखने के लिए [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) को `true` के साथ कॉल करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू छवि या आइकन PDF पृष्ठ पर रेंडर होती है, लेकिन उसकी एम्बेडेड फ़ाइल अटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` सेट करने से फ़ाइल डेटा भी शामिल हो जाता है। प्रीव्यू एक दृश्य प्रतिनिधित्व बना रहता है; अटैचमेंट प्राप्तकर्ताओं को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पृष्ठ पर इंटरैक्टिव Excel वर्कशीट नहीं बनता।

निम्नलिखित उदाहरण एक ऐसी प्रस्तुति को लोड करता है जिसमें पहले से ही एम्बेडेड Excel वर्कबुक मौजूद है और इसे वर्कबुक अटैचमेंट के साथ PDF में निर्यात करता है।

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

परिणाम की जाँच करने के लिए:

1. Adobe Acrobat Reader जैसी फ़ाइल अटैचमेंट का समर्थन करने वाले व्यूअर में निर्यातित PDF खोलें।
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें।
3. अटैचमेंट को सहेजें और डेटा की जांच के लिए Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पृष्ठ पर प्रीव्यू अटैचमेंट से अलग होता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक अटैचमेंट पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A अटैचमेंट की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक शामिल हैं, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides के विशेष प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात नहीं दर्शाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में बदलें**

यदि प्रस्तुति में छिपी स्लाइड्स हैं, तो आप परिणामस्वरूप PDF में छिपी स्लाइड्स को पेजेस के रूप में शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास की [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) मेथड का उपयोग कर सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, जिसमें सभी छिपी स्लाइड्स शामिल हैं।

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

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति को ऐसे PDF में निर्यात करता है जिसे खोलने के लिए पासवर्ड `password` आवश्यक है। पहुँच अनुमतियों में प्रिंटिंग, जिसमें हाई‑क्वालिटी प्रिंटिंग भी शामिल है, की अनुमति है।

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

### **फ़ॉन्ट प्रतिस्थापन का पता लगाएँ**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) मेथड प्रदान करता है, जिससे आप प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापनों का पता लगा सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल पर फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। चेतावनी केवल तब प्रिंट होती है जब निर्यात के दौरान कोई अनुपलब्ध फ़ॉन्ट प्रतिस्थापित किया जाता है।

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
फ़ॉन्ट प्रतिस्थापन पर अधिक जानकारी के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) लेख।
{{% /alert %}}

## **PowerPoint से चयनित स्लाइड्स को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस एरे में स्लाइड नंबर एक‑आधारित हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

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

निम्नलिखित उदाहरण एक प्रस्तुति से पहली स्लाइड को नई प्रस्तुति में कॉपी करता है जिसका स्लाइड आकार 612 × 792 पॉइंट्स (8.5 × 11 इंच) है। यह स्लाइड सामग्री को फिट करने के लिये स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

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

    // नई प्रस्तुति बनाते समय बनाई गई खाली स्लाइड को हटाएँ।

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में बदलें**

निम्नलिखित उदाहरण एक प्रस्तुती को PDF में निर्यात करता है, जिसमें प्रत्येक स्लाइड के स्पीकर नोट्स स्लाइड के नीचे रखे जाते हैं। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

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

## **PDF के लिए सुलभता और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देता है जो [वेब कंटेंट एक्सेसेबिलिटी गाइडलाइन्स (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

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
Aspose.Slides PDF रूपांतरण कार्यों को समर्थन देता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF से छवि](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य विशिष्ट स्वरूपों में PDF रूपांतरण—[PDF से SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—भी समर्थित हैं।
{{% /alert %}}

> **ध्यान दें:** PDF/UA में निर्यात करते समय, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट, और फ़ॉर्मूले को एकल आकृति के रूप में मानता है। व्यक्तिगत पाथ तत्वों को अलग सामग्री के रूप में संरक्षित नहीं किया जाता और उन्हें आर्टिफैक्ट के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल पूरी आकृति के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों की बैच रूपांतरण को PDF में समर्थन करता है। आप अपने फ़ाइलों पर क्रमिक रूप से कार्य कर सकते हैं और प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑सुरक्षित बनाना संभव है?**

हाँ। रूपांतरण प्रक्रिया के दौरान पासवर्ड सेट करने और पहुँच अनुमतियों को परिभाषित करने के लिए [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास का उपयोग करें।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

परिणामी PDF में छिपी स्लाइड्स को शामिल करने के लिए [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) को `true` के साथ कॉल करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप छवि गुणवत्ता को नियंत्रित कर सकते हैं जैसे कि [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) और [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) मेथड्स को [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) क्लास में उपयोग करके, जिससे आपके PDF में उच्च‑गुणवत्ता वाली छवियाँ सुनिश्चित हों।

**क्या Aspose.Slides PDF/A अनुपालन मानकों को समर्थन देता है?**

हाँ, Aspose.Slides आपको ऐसे PDF निर्यात करने देता है जो [विभिन्न मानकों](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) के अनुरूप हों, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ सुलभता और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Android via Java दस्तावेज़ीकरण](/slides/hi/androidjava/)
- [Aspose.Slides for Android via Java API संदर्भ](https://reference.aspose.com/slides/androidjava/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)