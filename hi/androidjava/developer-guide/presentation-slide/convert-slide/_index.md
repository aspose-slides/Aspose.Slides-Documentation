---
title: Android पर प्रेजेंटेशन स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/androidjava/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "PPT, PPTX और ODP से स्लाइड्स को इमेज में बदलें Aspose.Slides for Android का उपयोग करके—तेज़, उच्च-गुणवत्ता वाली रेंडरिंग स्पष्ट Java कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides for Android via Java आपको आसानी से PowerPoint और OpenDocument प्रेजेंटेशन स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स, जिसमें BMP, PNG, JPG (JPEG), GIF और अन्य शामिल हैं, में परिवर्तित करने में सक्षम बनाता है।

स्लाइड को इमेज में बदलने के लिए, इन चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स निर्धारित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इसके लिए उपयोग करें:
    - The [ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/) interface.
2. [getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage--) मेथड को कॉल करके स्लाइड इमेज उत्पन्न करें।

Aspose.Slides for Android via Java में, एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) एक इंटरफ़ेस है जो पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की सुविधा देता है। आप इस इंटरफ़ेस का उपयोग करके इमेज को विभिन्न फ़ॉर्मेट्स (BMP, JPG, PNG आदि) में सेव कर सकते हैं।

## **स्लाइड्स को बिटमैप में परिवर्तित करें और PNG में इमेज सहेजें**

आप स्लाइड को एक बिटमैप ऑब्जेक्ट में बदलकर सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर इसे JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में सहेज सकते हैं।

यह कोड एक प्रेजेंटेशन की पहली स्लाइड को बिटमैप ऑब्जेक्ट में परिवर्तित करने और फिर इमेज को PNG फ़ॉर्मेट में सहेजने का तरीका दर्शाता है:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रेजेंटेशन की पहली स्लाइड को बिटमैप में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // इमेज को PNG फ़ॉर्मेट में सहेजें।
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **विशेष आकार के साथ स्लाइड्स को इमेज में परिवर्तित करें**

आपको एक निश्चित आकार की इमेज चाहिए हो सकती है। [getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशेष आयामों (चौड़ाई और ऊँचाई) वाली इमेज में बदल सकते हैं।

यह नमूना कोड इस प्रक्रिया को दर्शाता है:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रेजेंटेशन की पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें।
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स वाली स्लाइड्स को इमेज में बदलें**

कभी‑कभी स्लाइड्स में नोट्स और कमेंट्स होते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/)—प्रदान करता है जो प्रेजेंटेशन स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करने की सुविधा देते हैं। दोनों इंटरफ़ेस में `setSlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास की मदद से आप परिणामी इमेज में नोट्स और कमेंट्स की पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह कोड नोट्स और कमेंट्स वाली स्लाइड को परिवर्तित करने का तरीका दर्शाता है:

```java 
float scaleX = 2;
float scaleY = scaleX;

// प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // नोट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // टिप्पणी की स्थिति सेट करें।
    notesCommentsOptions.setCommentsAreaWidth(500);                         // टिप्पणी क्षेत्र की चौड़ाई सेट करें।
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // टिप्पणी क्षेत्र का रंग सेट करें.

    // रेंडरिंग विकल्प बनाएं।
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // प्रेजेंटेशन की पहली स्लाइड को इमेज में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // इमेज को GIF फ़ॉर्मेट में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="नोट" color="warning" %}} 

किसी भी स्लाइड‑से‑इमेज रूपांतरण प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) मेथड `BottomFull` लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में परिवर्तित करें**

[ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेस आपको आकार, रेज़ोल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके परिणामी TIFF इमेज पर अधिक नियंत्रण देता है।

यह कोड एक रूपांतरण प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रेज़ोल्यूशन और 2160 × 2800 आकार की ब्लैक‑एंड‑व्हाइट इमेज उत्पन्न की जाती है:

```java 
// एक प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रेजेंटेशन से पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // इमेज का आकार सेट करें।
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (ब्लैक एंड व्हाइट)।
    tiffOptions.setDpiX(300);                                        // क्षैतिज रेज़ोल्यूशन सेट करें।
    tiffOptions.setDpiY(300);                                        // ऊर्ध्वाधर रेज़ोल्यूशन सेट करें।

    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
    IImage image = slide.getImage(tiffOptions);

    try {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें।
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **सभी स्लाइड्स को इमेज में परिवर्तित करें**

Aspose.Slides आपको प्रेजेंटेशन में सभी स्लाइड्स को इमेज में बदलने की सुविधा देता है, जिससे पूरी प्रेजेंटेशन को इमेजों की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड जावा में प्रेजेंटेशन की सभी स्लाइड्स को इमेज में बदलने का तरीका दिखाता है:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रेजेंटेशन को स्लाइड दर स्लाइड इमेज में रेंडर करें।
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // छुपी हुई स्लाइड्स को नियंत्रित करें (छुपी स्लाइड्स को रेंडर न करें)।
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // स्लाइड को इमेज में बदलें।
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें।
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **रंगीन इमोजी रेंडरिंग**

{{% alert title="नोट" color="warning" %}} 
रंगीन इमोजी को सही ढंग से रेंडर करने के लिए, प्रेजेंटेशन में उपयोग किए गए इमोजी फ़ॉन्ट्स को उस सिस्टम पर स्थापित होना आवश्यक है जो रूपांतरण कर रहा है। उदाहरण के लिए, यदि प्रेजेंटेशन में **Segoe UI Emoji** फ़ॉन्ट का उपयोग किया गया है और वह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides एनीमेशन वाली स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थैतिक इमेज को सेव करता है, जिसमें एनीमेशन नहीं होते।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेज को शैडो और प्रभावों के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय शैडो, ट्रांसपेरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।