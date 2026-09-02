---
title: Java में प्रस्तुति स्लाइड्स को छवियों में परिवर्तित करें
linktitle: स्लाइड से छवि
type: docs
weight: 35
url: /hi/java/convert-slide/
keywords:
- स्लाइड परिवर्तित करें
- स्लाइड निर्यात करें
- स्लाइड से छवि
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Java में PPT, PPTX और ODP प्रस्तुतियों की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य छवि स्वरूपों में परिवर्तित करें।"
---
## **परिचय**

Aspose.Slides for Java व्यक्तिगत स्लाइडों को PowerPoint और OpenDocument प्रस्तुतियों से PNG, JPEG, GIF, TIFF और अन्य छवि प्रारूपों में रेंडर कर सकता है।

एक स्लाइड को छवि में परिवर्तित करने के लिए, निम्न चरणों का पालन करें:

1. प्रस्तुति को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास के साथ लोड करें।
2. उन स्लाइड को चुनें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो [RenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास के साथ रेंडरिंग कॉन्फ़िगर करें।
4. [ISlide.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage--) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage.save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड को कॉल करें और [ImageFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/) मान के साथ आउटपुट फ़ॉर्मेट निर्दिष्ट करें।

## **एक स्लाइड को PNG छवि में परिवर्तित करें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामस्वरूप [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सहेजा जा सकता है।

निम्नलिखित Java उदाहरण पहली स्लाइड को रेंडर करता है और इसे PNG छवि के रूप में सहेजता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage();
    try {
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकार के साथ स्लाइडों को छवियों में परिवर्तित करें**

[ISlide.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) ओवरलोड का उपयोग करें जो एक [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) मान स्वीकार करता है ताकि स्लाइड को सटीक पिक्सेल आयामों के साथ रेंडर किया जा सके।

निम्न उदाहरण 1820 × 1040 JPEG छवि बनाता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import java.awt.Dimension;

Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स के साथ स्लाइडों को छवियों में परिवर्तित करें**

डिफ़ॉल्ट रूप से, स्लाइड छवियों में नोट्स या कमेंट्स शामिल नहीं होते। नोट्स और कमेंट्स की स्थिति को नियंत्रित करने के लिए [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड में पास करें।

निम्न उदाहरण ट्रंकेटेड नोट्स को स्लाइड के नीचे और कमेंट्स को दाईं ओर रखता है:

```java
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import java.awt.Color;

float scaleX = 2f;
float scaleY = scaleX;

Color commentsAreaColor = new Color(250, 235, 215);

NotesCommentsLayoutingOptions layoutOptions = new NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-से-छवि रूपांतरण के लिए, [BottomFull](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notespositions/) को [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) मेथड में पास न करें। नोट्स में जितना टेक्स्ट हो सकता है, वह स्थिर छवि आकार से अधिक हो सकता है। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइडों को छवियों में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/tiffoptions/) क्लास आपको रेंडर की गई TIFF छवि के आकार, रेज़ोल्यूशन और अन्य गुणों को नियंत्रित करने की अनुमति देती है।

निम्न उदाहरण पहली स्लाइड को 2160 × 2880 TIFF छवि के रूप में 300 DPI पर रेंडर करता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import java.awt.Dimension;

Dimension imageSize = new Dimension(2160, 2880);

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}
TIFF समर्थन JDK 9 से पहले के Java संस्करणों में गारंटीकृत नहीं है।
{{% /alert %}}

## **सभी स्लाइडों को छवियों में परिवर्तित करें**

पूरी प्रस्तुति को छवियों की श्रृंखला में बदलने के लिए स्लाइड संग्रह पर इटररेट करें। जब तक आप स्पष्ट रूप से उन्हें स्किप न करें, छुपी हुई स्लाइडें भी शामिल रहती हैं।

निम्न उदाहरण प्रत्येक स्लाइड को 2 के क्षैतिज और लंबवत स्केल फैक्टर के साथ JPEG छवि के रूप में रेंडर करता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

float scaleX = 2f;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Enhanced Metafile आउटपुट बनाएं**

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर-आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows अनुप्रयोगों के साथ साझा करना हो जो Windows मेटाफाइल का समर्थन करते हैं। पिक्सेल-आधारित छवि के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बनाए रख सकता है जो स्केल करने पर समान शार्पनेस खोते नहीं हैं। हालांकि, EMF मुख्यतः Windows मेटाफाइल समर्थन वाले अनुप्रयोगों के लिए एक संगतता फ़ॉर्मेट है, सार्वभौमिक अंतर‑आदान के लिए नहीं। अतिरिक्त रूप से, जटिल स्लाइड सामग्री जैसे बिटमैप छवियां और कुछ प्रभाव वेक्टर मेटाफाइल कंटेनर के भीतर रास्टराइज़्ड तत्वों के रूप में संग्रहित हो सकते हैं।

### **एक स्लाइड को EMF में निर्यात करें**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) मेथड एक [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) को लक्ष्य स्ट्रीम में EMF फ़ॉर्मेट में लिखता है। निम्न उदाहरण एक प्रस्तुति लोड करता है, पहली स्लाइड चुनता है, और उसे EMF फ़ाइल स्ट्रीम में लिखता है:

```java
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    FileOutputStream emfStream = new FileOutputStream("Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

कॉलर वह स्ट्रीम का मालिक होता है जो [ISlide.writeAsEmf](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) को पास किया गया है और ऊपर दिखाए अनुसार उसे बंद करने की जिम्मेदारी उसके पास होती है।

### **SVG छवि को EMF में परिवर्तित करें और प्रस्तुति में जोड़ें**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) का उपयोग करके SVG सामग्री को EMF में बदलें। परिणामी बाइट्स को [IImageCollection.addImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimagecollection/#addImage-byte:A-) के माध्यम से प्रस्तुति में जोड़ा जा सकता है और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) से स्लाइड पर रखा जा सकता है।

निम्न उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/svgimage/) बनाता है, इसे इन‑मे़मोरी EMF में परिवर्तित करता है, पहले स्लाइड पर मेटाफाइल डालता है, और प्रस्तुति को सहेजता है:

```java
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ISvgImage;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;
import com.aspose.slides.SvgImage;
import java.io.ByteArrayOutputStream;

String svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
ISvgImage svgImage = new SvgImage(svgContent);

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ByteArrayOutputStream emfStream = new ByteArrayOutputStream();
    try {
        svgImage.writeAsEmf(emfStream);

        byte[] emfData = emfStream.toByteArray();
        IPPImage image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) गंतव्य स्ट्रीम का स्वामित्व नहीं लेता। एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) सभी उत्पन्न डेटा को मेमोरी में रखता है, इसलिए `toByteArray` को कॉल करने से पहले पोज़िशन रीसेट करने की आवश्यकता नहीं होती। स्ट्रीम बंद करने के बाद भी लौटाई गई बाइट ऐरे वैध रहती है।

EMF जनरेशन चयनित Aspose.Slides for Java और JDK कॉन्फ़िगरेशन द्वारा समर्थित ऑपरेटिंग सिस्टम पर उपलब्ध है, लेकिन फ़ॉन्ट या ग्राफ़िक निर्भरताएँ अनुपलब्ध होने पर प्लेटफ़ॉर्म के बीच रेंडरिंग अलग हो सकती है। स्रोत सामग्री द्वारा उपयोग किए गए फ़ॉन्ट इंस्टॉल करें या उपयुक्त विकल्प कॉन्फ़िगर करें, Aspose.Slides for Java के [platform requirements](/slides/hi/java/system-requirements/) का पालन करें, और लक्ष्य EMF‑उपयोगकर्ता अनुप्रयोग में परिणाम की पुष्टि करें। Linux और macOS अनुप्रयोगों में अक्सर Windows मेटाफाइल को दिखाने और संपादित करने के लिए सीमित या असंगत समर्थन होता है।

## **रंग इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
जब प्रस्तुति स्लाइडों को छवियों में बदलते हैं, तो रंग इमोजी को सही ढंग से रेंडर करने के लिए प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट को सिस्टम पर इंस्टॉल और उपलब्ध होना चाहिए। उदाहरण के तौर पर, यदि प्रस्तुति **Segoe UI Emoji** फ़ॉन्ट का उपयोग करती है और यह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट छवियों में इमोजी मोनोक्रोमा दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड रेंडरिंग का समर्थन करता है?**

नहीं। [ISlide.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage--) मेथड स्लाइड की एक स्थिर छवि रेंडर करता है और एनीमेशन को निर्यात नहीं करता।

**क्या छिपी हुई स्लाइडों को छवियों के रूप में निर्यात किया जा सकता है?**

हां। छिपी हुई स्लाइडों को सामान्य स्लाइडों की तरह रेंडर किया जा सकता है। ऊपर दिखाए उदाहरण की तरह प्रोसेसिंग लूप में उन्हें शामिल करें।

**क्या स्लाइड छवियों में छायाएँ और अन्य प्रभाव संरक्षित रहते हैं?**

हां। Aspose.Slides स्लाइड छवियों में छायाएँ, पारदर्शिता और अन्य समर्थित ग्राफ़िकल प्रभावों को रेंडर करता है।