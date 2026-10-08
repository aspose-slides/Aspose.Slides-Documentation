---
title: Java में PPT और PPTX को PDF में परिवर्तित करें [उन्नत सुविधाएँ सम्मिलित]
linktitle: PowerPoint से PDF
type: docs
weight: 40
url: /hi/java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- PowerPoint से PDF
- प्रेजेंटेशन से PDF
- PPT से PDF
- PPT को PDF में परिवर्तित करें
- PPTX से PDF
- PPTX को PDF में परिवर्तित करें
- PowerPoint को PDF के रूप में सहेजें
- PPT को PDF के रूप में सहेजें
- PPTX को PDF के रूप में सहेजें
- PPT को PDF में निर्यात करें
- PPTX को PDF में निर्यात करें
- संलग्नक
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके Java में PowerPoint PPT/PPTX को उच्च‑गुणवत्ता, खोज योग्य PDFs में परिवर्तित करें, तेज़ कोड उदाहरणों और उन्नत रूपांतरण विकल्पों के साथ."
---
## **अवलोकन**

PowerPoint प्रस्तुतियों (PPT, PPTX, ODP आदि) को Java में PDF स्वरूप में परिवर्तित करने के कई लाभ होते हैं, जिसमें विभिन्न उपकरणों के बीच संगतता और आपकी प्रस्तुति की लेआउट और फ़ॉर्मेटिंग को बनाए रखना शामिल है। यह मार्गदर्शिका दर्शाती है कि प्रस्तुतियों को PDF दस्तावेज़ों में कैसे परिवर्तित किया जाए, छवि गुणवत्ता को नियंत्रित करने के लिए विभिन्न विकल्पों का उपयोग करें, छिपी स्लाइड्स शामिल करें, PDF फ़ाइलों को पासवर्ड‑से‑सुरक्षित करें, फ़ॉन्ट प्रतिस्थापन का पता लगाएं, रूपांतरण के लिए विशिष्ट स्लाइड्स चुनें, और आउटपुट दस्तावेज़ों पर अनुपालन मानकों को लागू करें।

## **PowerPoint से PDF रूपांतरण**

Aspose.Slides का उपयोग करके, आप निम्नलिखित स्वरूपों में प्रस्तुतियों को PDF में परिवर्तित कर सकते हैं:

* **PPT**
* **PPTX**
* **ODP**

एक प्रस्तुति को PDF में परिवर्तित करने के लिए, फ़ाइल नाम को एक तर्क के रूप में [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास में पास करें और फिर [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड का उपयोग करके प्रस्तुति को PDF के रूप में सहेजें। [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड को उजागर करता है जो आमतौर पर प्रस्तुति को PDF में परिवर्तित करने के लिए उपयोग किया जाता है।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Java आउटपुट दस्तावेज़ों में अपनी API जानकारी और संस्करण संख्या डालता है। उदाहरण के लिए, जब किसी प्रस्तुति को PDF में बदलते हैं, तो Aspose.Slides Application फ़ील्ड को "*Aspose.Slides*" और PDF Producer फ़ील्ड को "*Aspose.Slides v XX.XX*" रूप में भरता है। **Note** कि आप Aspose.Slides को इस जानकारी को बदलने या हटाने के लिए निर्देश नहीं दे सकते।
{{% /alert %}}

Aspose.Slides आपको परिवर्तित करने की अनुमति देता है:

* संपूर्ण प्रस्तुतियों को PDF में
* किसी प्रस्तुति की विशिष्ट स्लाइड्स को PDF में

Aspose.Slides प्रस्तुतियों को PDF में निर्यात करता है, यह सुनिश्चित करते हुए कि परिणामी PDFs मूल प्रस्तुतियों से निकटता से मेल खाते हैं। तत्व और गुण रूपांतरण में सटीक रूप से रेंडर किए जाते हैं, जिसमें शामिल हैं:

* छवियों
* टेक्स्ट बॉक्स और आकार
* टेक्स्ट फ़ॉर्मेटिंग
* पैराग्राफ फ़ॉर्मेटिंग
* हाइपरलिंक्स
* हेडर और फुटर
* बुलेट्स
* टेबल्स

## **PowerPoint को PDF में परिवर्तित करें**

मानक PowerPoint‑to‑PDF रूपांतरण प्रक्रिया डिफ़ॉल्ट विकल्पों का उपयोग करती है। इस मामले में, Aspose.Slides अधिकतम गुणवत्ता स्तर पर इष्टतम सेटिंग्स के साथ प्रदान की गई प्रस्तुति को PDF में परिवर्तित करने का प्रयास करता है।

निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है और सभी दृश्य स्लाइड्स को डिफ़ॉल्ट निर्यात सेटिंग्स का उपयोग करके PDF में सहेजता है।

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
Aspose एक मुफ्त ऑनलाइन [**PowerPoint to PDF परिवर्तक**](https://products.aspose.app/slides/conversion/ppt-to-pdf) प्रदान करता है जो प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया को प्रदर्शित करता है। आप यहाँ वर्णित प्रक्रिया का लाइव कार्यान्वयन देखने के लिए इस परिवर्तक के साथ एक परीक्षण चला सकते हैं।
{{% /alert %}}

## **विकल्पों के साथ PowerPoint को PDF में परिवर्तित करें**

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास के तहत कस्टम विकल्प — गुण प्रदान करता है जो आपको परिणामी PDF को अनुकूलित करने, PDF को पासवर्ड से लॉक करने, या रूपांतरण प्रक्रिया को कैसे आगे बढ़ना चाहिए, यह निर्दिष्ट करने की अनुमति देते हैं।

### **विकल्पों के साथ PowerPoint को PDF में कस्टम रूप से परिवर्तित करें**

कस्टम रूपांतरण विकल्पों का उपयोग करके, आप रास्टर छवियों के लिए वांछित गुणवत्ता सेटिंग, मेटाफाइलों को कैसे संभालना है, टेक्स्ट के लिए संपीड़न स्तर, छवियों के DPI, आदि को परिभाषित कर सकते हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF 1.5 में निर्यात करता है जिसमें JPEG गुणवत्ता 90, छवि रिज़ॉल्यूशन 300 DPI, मेटाफाइल PNG के रूप में सहेजे गए, और Flate टेक्स्ट संपीड़न है।

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

### **PDF एटैचमेंट्स के रूप में एम्बेडेड OLE फ़ाइलों को संरक्षित रखें**

यदि किसी प्रस्तुति में एक एम्बेडेड Excel वर्कबुक है, तो आप चाहते हैं कि PDF प्राप्तकर्ता वर्कबुक का डेटा भी देख सके। परिणामी PDF में एम्बेडेड OLE फ़ाइलों को एटैचमेंट के रूप में संरक्षित रखने के लिए `true` के साथ [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) को कॉल करें।

डिफ़ॉल्ट मान `false` है: OLE ऑब्जेक्ट की प्रीव्यू छवि या आइकन PDF पेज पर रेंडर होता है, लेकिन उसकी एम्बेडेड फ़ाइल एटैचमेंट के रूप में शामिल नहीं होती। विकल्प को `true` पर सेट करने से फ़ाइल डेटा अतिरिक्त रूप से शामिल हो जाता है। प्रीव्यू केवल एक दृश्य प्रतिनिधित्व रहता है; एटैचमेंट प्राप्तकर्ताओं को एम्बेडेड फ़ाइल को अलग से खोलने या सहेजने की अनुमति देता है। OLE ऑब्जेक्ट PDF पेज पर इंटरैक्टिव Excel वर्कशीट नहीं बनता।

निम्नलिखित उदाहरण एक प्रस्तुति को लोड करता है जिसमें पहले से ही एम्बेडेड Excel वर्कबुक है और वर्कबुक को एटैचमेंट के साथ PDF में निर्यात करता है।

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

1. किसी ऐसा व्यूअर में निर्यातित PDF खोलें जो फ़ाइल एटैचमेंट्स का समर्थन करता हो, जैसे Adobe Acrobat Reader.
2. व्यूअर के **Attachments** पैनल को खोलें और एम्बेडेड वर्कबुक को खोजें.
3. एटैचमेंट को सहेजें और डेटा की जाँच के लिए Excel में खोलें, या यदि व्यूअर अनुमति देता है तो सीधे खोलें। PDF पेज पर प्रीव्यू एटैचमेंट से अलग होता है।

{{% alert color="info" title="Note" %}}
PDF/A मानक एटैचमेंट्स पर प्रतिबंध लगाते हैं: PDF/A-1 एम्बेडेड फ़ाइलों को प्रतिबंधित करता है, PDF/A-2 केवल PDF/A एटैचमेंट्स की अनुमति देता है, और PDF/A-3 अन्य फ़ाइल प्रकारों, जिसमें Excel वर्कबुक शामिल हैं, की अनुमति देता है। ये मानकों की आवश्यकताएँ हैं, Aspose.Slides‑specific प्रतिबंध नहीं। यह उदाहरण डिफ़ॉल्ट PDF अनुपालन सेटिंग का उपयोग करता है और PDF/A निर्यात को नहीं दर्शाता।
{{% /alert %}}

### **छिपी स्लाइड्स के साथ PowerPoint को PDF में परिवर्तित करें**

यदि किसी प्रस्तुति में छिपी स्लाइड्स हैं, तो आप [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास से [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) मेथड को `true` के साथ कॉल करके छिपी स्लाइड्स को परिणामी PDF में पृष्ठों के रूप में शामिल कर सकते हैं।

निम्नलिखित उदाहरण छिपी स्लाइड्स सहित एक प्रस्तुति को PDF में निर्यात करता है।

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

### **पासवर्ड‑सुरक्षित PDF के साथ PowerPoint को परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति को ऐसे PDF में निर्यात करता है जो खोलने के लिए पासवर्ड `password` की आवश्यकता रखता है। अभिगम अधिकार प्रिंटिंग की अनुमति देते हैं, जिसमें उच्च‑गुणवत्ता प्रिंटिंग भी शामिल है।

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

Aspose.Slides [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास के तहत [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) मेथड प्रदान करता है, जो आपको प्रस्तुति‑to‑PDF रूपांतरण प्रक्रिया के दौरान फ़ॉन्ट प्रतिस्थापन का पता लगाने की सुविधा देता है।

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है और कंसोल में फ़ॉन्ट प्रतिस्थापन चेतावनियों को प्रिंट करता है। निर्यात के दौरान केवल तब चेतावनी प्रिंट होती है जब कोई उपलब्ध नहीं फ़ॉन्ट प्रतिस्थापित किया जाता है।

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
फ़ॉन्ट प्रतिस्थापन के बारे में अधिक जानकारी के लिए, देखें [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/) लेख।
{{% /alert %}} 

### **बिना समर्पित बोल्ड टाइपफ़ेस वाले फ़ॉन्ट्स को संभालें**

एक प्रस्तुति वह फ़ॉन्ट उपयोग कर सकती है जिसमें कोई समर्पित बोल्ड टाइपफ़ेस नहीं होता, फिर भी वह टेक्स्ट बोल्ड फ़ॉर्मेटिंग लागू कर सकती है। यह टेक्स्ट सिंथेटिक बोल्डिंग के माध्यम से दिखाई दे सकता है, जो नियमित ग्लिफ़ को कृत्रिम रूप से मोटा कर देता है। जब वह टेक्स्ट PDF में बहुत भारी या इच्छित रूप से अलग दिखे, तो आप [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) को `true` के साथ कॉल करने का प्रयास कर सकते हैं। यह विकल्प PDF निर्यात के दौरान प्रभावित टेक्स्ट को बिटमैप के रूप में रेंडर करता है और कुछ फ़ॉन्ट्स के लिए उसकी उपस्थिति में सुधार कर सकता है। इसका डिफ़ॉल्ट मान `false` है।

निम्नलिखित उदाहरण दो टेक्स्ट बॉक्स वाली प्रस्तुति को लोड करता है: एक सामान्य टेक्स्ट वाला और एक वही फ़ॉन्ट पर बोल्ड फ़ॉर्मेटिंग वाला, जिसका कोई समर्पित बोल्ड टाइपफ़ेस नहीं है। यह उदाहरण विकल्प को सक्षम करता है और PDF में निर्यात करता है:

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

निम्नलिखित पूर्वावलोकन निष्क्रिय आउटपुट और सक्रिय आउटपुट को दर्शाते हैं। इस उदाहरण में, विकल्प निष्क्रिय होने पर बोल्ड टेक्स्ट के स्ट्रोक मोटे होते हैं। विकल्प सक्रिय होने पर स्ट्रोक हल्के होते हैं; सामान्य टेक्स्ट अपरिवर्तित रहता है। अपने प्रस्तुतिकरण के लिए सेटिंग चुनने से पहले परिणामों की तुलना करें।

| विकल्प निष्क्रिय (`false`, डिफ़ॉल्ट) | विकल्प सक्रिय (`true`) |
|---|---|
| ![असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन निष्क्रिय वाला PDF](unsupported-bold-disabled.png) | ![असमर्थित फ़ॉन्ट शैली रास्टराइज़ेशन सक्रिय वाला PDF](unsupported-bold-enabled.png) |

इस उदाहरण में, विकल्प को सक्षम करने से केवल बोल्ड टेक्स्ट बिटमैप में बदल जाता है: इसे OCR के बिना चयन, कॉपी या खोजा नहीं जा सकता, और 800% जूम पर किनारे मुलायम दिखते हैं। सामान्य टेक्स्ट खोज योग्य बना रहता है। विकल्प निष्क्रिय होने पर दोनों स्ट्रिंग्स टेक्स्ट बनी रहती हैं।

यह विकल्प उन फ़ॉन्ट्स के लिए जो बोल्ड टाइपफ़ेस नहीं रखते, बोल्ड रूप में फ़ॉर्मेटेड टेक्स्ट को बिटमैप में बदल देता है। [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/) के बजाय जब मूल फ़ॉन्ट उपलब्ध नहीं होता तो कोई अन्य फ़ॉन्ट चुनता है।

## **PowerPoint से चयनित स्लाइड्स को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति से स्लाइड 1 और 3 को PDF में निर्यात करता है। इस ऐरे में स्लाइड नंबर एक‑आधारित हैं, और इनपुट प्रस्तुति में कम से कम तीन स्लाइड्स होनी चाहिए।

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

## **कस्टम स्लाइड आकार के साथ PowerPoint को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण पहली स्लाइड को 612 × 792 पॉइंट (8.5 × 11 इंच) के स्लाइड आकार वाले नए प्रस्तुति में कॉपी करता है। यह स्लाइड सामग्री को फिट करने के लिए स्केल करता है और एकल स्लाइड को PDF में निर्यात करता है।

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

    // नए प्रस्तुति के साथ बनाई गई खाली स्लाइड को हटाएँ।
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **नोट्स स्लाइड व्यू में PowerPoint को PDF में परिवर्तित करें**

निम्नलिखित उदाहरण एक प्रस्तुति को PDF में निर्यात करता है, प्रत्येक स्लाइड के नीचे स्पीकर नोट्स रखता है। परिणाम देखने के लिए स्पीकर नोट्स वाली प्रस्तुति का उपयोग करें।

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

## **PDF के लिए एक्सेसेबिलिटी और अनुपालन मानक**

Aspose.Slides आपको एक रूपांतरण प्रक्रिया का उपयोग करने की अनुमति देता है जो [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) के अनुरूप है। आप इन अनुपालन मानकों में से किसी का उपयोग करके PowerPoint दस्तावेज़ को PDF में निर्यात कर सकते हैं: **PDF/A1a**, **PDF/A1b**, और **PDF/UA**।

यह कोड विभिन्न अनुपालन मानकों के आधार पर कई PDFs उत्पन्न करने वाली PowerPoint‑to‑PDF रूपांतरण प्रक्रिया को दर्शाता है:

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
Aspose.Slides PDF रूपांतरण संचालन का समर्थन करता है, जिससे आप PDF फ़ाइलों को लोकप्रिय फ़ाइल स्वरूपों में बदल सकते हैं। आप [PDF से HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF से image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF से JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), और [PDF से PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) रूपांतरण कर सकते हैं। अन्य PDF रूपांतरण संचालन विशेष स्वरूपों—[PDF से SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF से TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), और [PDF से XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—के लिए भी समर्थित हैं।
{{% /alert %}}

> **Note:** जब PDF/UA में निर्यात किया जाता है, Aspose.Slides जटिल ग्राफ़िक्स जैसे SmartArt, चार्ट और फॉर्मूले को एकल फ़िगर के रूप में व्यवहार करता है। व्यक्तिगत पाथ तत्व अलग-अलग सामग्री के रूप में संरक्षित नहीं रहते और उन्हें आर्टिफैक्ट्स के रूप में चिह्नित किया जा सकता है; वैकल्पिक टेक्स्ट केवल संपूर्ण फ़िगर के लिए प्रदान किया जाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कई PowerPoint फ़ाइलों को एक साथ PDF में बदल सकता हूँ?**

हाँ, Aspose.Slides कई PPT या PPTX फ़ाइलों को PDF में बैच रूप में परिवर्तित करने का समर्थन करता है। आप अपने फ़ाइलों पर क्रमशः लूप चलाकर प्रोग्रामेटिक रूप से रूपांतरण प्रक्रिया लागू कर सकते हैं।

**क्या परिवर्तित PDF को पासवर्ड‑से‑सुरक्षित करना संभव है?**

हाँ। परिवर्तन प्रक्रिया के दौरान पासवर्ड सेट करने और अभिगम अधिकार परिभाषित करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास का उपयोग कर सकते हैं।

**मैं PDF में छिपी स्लाइड्स को कैसे शामिल करूँ?**

छिपी स्लाइड्स को परिणामी PDF में शामिल करने के लिए आप [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास में [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) को `true` के साथ कॉल करें।

**क्या Aspose.Slides PDF में उच्च छवि गुणवत्ता बनाए रख सकता है?**

हाँ, आप [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) क्लास में [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) और [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) जैसी विधियों का उपयोग करके अपने PDF में उच्च‑गुणवत्ता वाली छवियों को सुनिश्चित कर सकते हैं।

**क्या Aspose.Slides PDF/A अनुपालन मानकों का समर्थन करता है?**

हाँ, Aspose.Slides आपको उन PDF को निर्यात करने की अनुमति देता है जो विभिन्न मानकों ([various standards](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/)) के अनुरूप होते हैं, जिसमें PDF/A1a, PDF/A1b, और PDF/UA शामिल हैं, जिससे आपके दस्तावेज़ एक्सेसेबिलिटी और अभिलेखीय आवश्यकताओं को पूरा करते हैं।

## **अतिरिक्त संसाधन**

- [Aspose.Slides for Java दस्तावेज़ीकरण](/slides/hi/java/)
- [Aspose.Slides for Java API संदर्भ](https://reference.aspose.com/slides/java/)
- [Aspose मुफ्त ऑनलाइन कनवर्टर](https://products.aspose.app/slides/conversion)