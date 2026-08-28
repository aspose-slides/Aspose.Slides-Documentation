---
title: Android पर प्रस्तुति स्लाइड्स को इमेज में परिवर्तित करें
linktitle: स्लाइड को इमेज
type: docs
weight: 35
url: /hi/androidjava/convert-slide/
keywords:
- स्लाइड परिवर्तित करें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides के साथ Android पर PPT, PPTX और ODP प्रस्तुतियों की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य इमेज फ़ॉर्मैट्स में परिवर्तित करें।"
---
## **परिचय**

Aspose.Slides for Android via Java व्यक्तिगत स्लाइड्स को PowerPoint और OpenDocument प्रस्तुतियों से PNG, JPEG, GIF, TIFF और अन्य छवि फ़ॉर्मैट्स में प्रस्तुत कर सकता है।

स्लाइड को इमेज में बदलने के लिए निम्न चरणों का पालन करें:

1. प्रेज़ेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास के माध्यम से लोड करें।
2. उस स्लाइड का चयन करें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास के साथ कॉन्फ़िगर करें।
4. [ISlide.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage--) मेथड को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड को कॉल करें और आउटपुट फ़ॉर्मेट को एक [ImageFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/) मान के साथ निर्दिष्ट करें।

## **एक स्लाइड को PNG छवि में परिवर्तित करें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामी [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सहेजा जा सकता है।

निम्न Java उदाहरण पहले स्लाइड को रेंडर करता है और उसे PNG इमेज के रूप में सहेजता है:

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

## **कस्टम आकारों के साथ स्लाइड्स को छवियों में परिवर्तित करें**

[ISlide.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) ओवरलोड का उपयोग करें जो एक [Size](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides.android/size/) वैल्यू को स्वीकार करता है, ताकि स्लाइड को सटीक पिक्सेल आयामों के साथ रेंडर किया जा सके।

निम्न उदाहरण 1820 × 1040 JPEG इमेज बनाता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1820, 1040);

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

## **नोट्स और कमेंट्स के साथ स्लाइड्स को छवियों में परिवर्तित करें**

डिफ़ॉल्ट रूप से स्लाइड इमेज में नोट्स या कमेंट्स शामिल नहीं होते। नोट्स और कमेंट्स की स्थिति को नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/renderingoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) मेथड में पास करें।

निम्न उदाहरण स्लाइड के नीचे ट्रंकेटेड नोट्स और दाएँ तरफ कमेंट्स रखता है:

```java
import android.graphics.Color;
import com.aspose.slides.CommentsPositions;
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.NotesCommentsLayoutingOptions;
import com.aspose.slides.NotesPositions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;

float scaleX = 2f;
float scaleY = scaleX;

int commentsAreaColor = Color.rgb(250, 235, 215);

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
स्लाइड‑टू‑इमेज रूपांतरण के लिए, [BottomFull](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notespositions/) को [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/#setNotesPosition-int-) मेथड में पास न करें। नोट्स में ऐसी मात्रा में टेक्स्ट हो सकता है जो तय इमेज आकार में फिट नहीं हो पाएगा। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/tiffoptions/) क्लास आपको रेंडर की गई TIFF इमेज के आकार, रिज़ॉल्यूशन और अन्य गुणों को नियंत्रित करने की सुविधा देती है।

निम्न उदाहरण पहला स्लाइड 2160 × 2880 TIFF इमेज के रूप में 300 DPI पर रेंडर करता है:

```java
import com.aspose.slides.IImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;
import com.aspose.slides.TiffOptions;
import com.aspose.slides.android.Size;

Size imageSize = new Size(2160, 2880);

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

## **सभी स्लाइड्स को छवियों में परिवर्तित करें**

स्लाइड कलेक्शन पर इटरेट करके पूरी प्रेज़ेंटेशन को छवियों की श्रृंखला में बदलें। छिपी हुई स्लाइड्स भी शामिल की जाती हैं जब तक आप उन्हें स्पष्ट रूप से स्किप न करें।

निम्न उदाहरण प्रत्येक स्लाइड को 2 के क्षैतिज और लंबवत स्केल फैक्टर के साथ JPEG इमेज के रूप में रेंडर करता है:

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

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर‑आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows एप्लिकेशनों के साथ आदान‑प्रदान करना हो जो Windows Metafiles का समर्थन करते हैं। पिक्सेल‑आधारित इमेज के विपरीत, EMF वेक्टर ड्राइंग ऑपरेशन्स को बनाए रखता है जिससे स्केल करने पर स्पष्टता नहीं घटती। हालाँकि, EMF मुख्यतः Windows Metafile समर्थन वाले एप्लिकेशनों के लिए एक संगतता फ़ॉर्मेट है, सार्वभौमिक इंटरचेंज फ़ॉर्मेट नहीं। अतिरिक्त रूप से, स्लाइड की जटिल सामग्री जैसे बिटमैप इमेज और कुछ इफ़ेक्ट्स वेक्टर Metafile कंटेनर में रास्टराइज़्ड एलिमेंट्स के रूप में संग्रहीत हो सकती हैं।

### **EMF में स्लाइड निर्यात करें**

[ISlide.writeAsEmf](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#writeAsEmf-java.io.OutputStream-) मेथड एक [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) को लक्ष्य स्ट्रीम में EMF फ़ॉर्मेट में लिखता है। निम्न उदाहरण एक प्रेज़ेंटेशन लोड करता है, पहला स्लाइड चुनता है, और उसे EMF फ़ाइल स्ट्रीम में लिखता है:

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

[caller] को पास की गई स्ट्रीम का मालिकाना अधिकार और उसे बंद करने की ज़िम्मेदारी स्वयं रखनी होती है, जैसा कि ऊपर दिखाया गया है।

### **SVG इमेज को EMF में बदलें और प्रेज़ेंटेशन में जोड़ें**

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) का उपयोग करके SVG कंटेंट को EMF में बदलें। परिणामी बाइट्स को [IImageCollection.addImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimagecollection/#addImage-byte:A-) के माध्यम से प्रेज़ेंटेशन में जोड़ सकते हैं और [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) से स्लाइड पर रख सकते हैं।

निम्न उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/svgimage/) बनाता है, उसे मेमोरी में EMF में बदलता है, पहले स्लाइड पर Metafile डालता है, और प्रेज़ेंटेशन को सहेजता है:

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

[ISvgImage.writeAsEmf](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isvgimage/#writeAsEmf-java.io.OutputStream-) गंतव्य स्ट्रीम की मालिकी नहीं लेता। एक [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) सभी उत्पन्न डेटा को मेमोरी में रखता है, इसलिए `toByteArray` कॉल करने से पहले किसी पोजीशन रीसेट की आवश्यकता नहीं होती। लौटाया गया बाइट एरे स्ट्रीम बंद होने के बाद भी वैध रहता है।

EMF जेनरेशन समर्थित Android संस्करणों और डिवाइस कॉन्फ़िगरेशन पर उपलब्ध है, लेकिन फॉन्ट या ग्राफ़िक्स डिपेंडेंसी उपलब्ध न होने पर रेंडरिंग में अंतर आ सकता है। स्रोत कंटेंट द्वारा उपयोग किए गए फ़ॉन्ट इंस्टॉल करें या उपयुक्त प्रतिस्थापन कॉन्फ़िगर करें, Aspose.Slides for Android via Java के लिए [इंस्टॉलेशन गाइड](/slides/hi/androidjava/install-aspose-slides-for-android-via-java/) का अनुसरण करें, और लक्ष्य EMF‑उपभोक्ता एप्लिकेशन में परिणाम को वैधेट करें। गैर‑Windows प्लेटफ़ॉर्म पर एप्लिकेशन अक्सर Windows Metafiles को दिखाने और संपादित करने में सीमित या असंगत समर्थन रखते हैं।

## **रंगीन इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेज़ेंटेशन स्लाइड्स को इमेज में बदलते समय रंगीन इमोजी सही ढंग से रेंडर करने के लिए, प्रेज़ेंटेशन में प्रयुक्त इमोजी फ़ॉन्ट सिस्टम में स्थापित और उपलब्ध होना चाहिए। उदाहरण के लिए, यदि प्रेज़ेंटेशन में **Segoe UI Emoji** फ़ॉन्ट प्रयोग किया गया है और वह उपलब्ध नहीं है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides स्लाइड्स को एनीमेशन के साथ रेंडर करने का समर्थन करता है?**

नहीं। [ISlide.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage--) मेथड स्लाइड की स्थिर इमेज रेंडर करता है और एनीमेशन निर्यात नहीं करता।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हां। छिपी हुई स्लाइड्स को नियमित स्लाइड्स की तरह रेंडर किया जा सकता है। उन्हें प्रोसेसिंग लूप में शामिल करें, जैसा कि ऊपर के उदाहरण में दिखाया गया है।

**क्या स्लाइड इमेज में शैडो और अन्य इफ़ेक्ट्स संरक्षित रहते हैं?**

हां। Aspose.Slides स्लाइड इमेज में शैडो, ट्रांसपैरेंसी और अन्य समर्थित ग्राफ़िकल इफ़ेक्ट्स को रेंडर करता है।