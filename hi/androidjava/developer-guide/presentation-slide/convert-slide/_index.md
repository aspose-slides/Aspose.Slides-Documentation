---
title: "एंड्रॉइड पर प्रस्तुति स्लाइड्स को इमेज में बदलें"
linktitle: "स्लाइड से इमेज"
type: docs
weight: 35
url: /hi/androidjava/convert-slide/
keywords:
- "स्लाइड बदलें"
- "स्लाइड निर्यात"
- "स्लाइड से इमेज"
- "स्लाइड को इमेज के रूप में सहेजें"
- "स्लाइड से PNG"
- "स्लाइड से JPEG"
- "स्लाइड से बिटमैप"
- "स्लाइड से TIFF"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android का उपयोग करके PPT, PPTX और ODP स्लाइड्स को इमेज में बदलें—तेज़, उच्च गुणवत्ता वाला रेंडरिंग, स्पष्ट Java कोड उदाहरणों के साथ."
---
## **परिचय**

Aspose.Slides for Android via Java आपको PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स में आसानी से बदलने देता है, जिसमें BMP, PNG, JPG (JPEG), GIF आदि शामिल हैं।

स्लाइड को इमेज में बदलने के लिए, इन चरणों का पालन करें:

1. इच्छित रूपांतरण सेटिंग्स को परिभाषित करें और इस प्रकार स्लाइड्स चुनें जिन्हें आप निर्यात करना चाहते हैं:
    - [ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेस, या
    - [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/) इंटरफ़ेस।
2. [getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage--) मेथड को कॉल करके स्लाइड इमेज उत्पन्न करें।

Aspose.Slides for Android via Java में, एक [IImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/) इंटरफ़ेस वह है जो पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की संभावना देता है। आप इस इंटरफ़ेस का उपयोग BMP, JPG, PNG आदि सहित विस्तृत फ़ॉर्मेट्स में इमेज को सहेजने के लिए कर सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे अपने एप्लिकेशन में सीधे उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर इमेज को JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में सहेज सकते हैं।

यह कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर इसे PNG फ़ॉर्मेट में सहेजें:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति की पहली स्लाइड को बिटमैप में बदलें.
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // इमेज को PNG फ़ॉर्मेट में सहेजें.
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकारों के साथ स्लाइड्स को इमेज में बदलें**

आपको निश्चित आकार की इमेज की आवश्यकता हो सकती है। [getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) वाली इमेज में बदल सकते हैं।

यह नमूना कोड दर्शाता है कि इसे कैसे किया जाए:

```java 
Size imageSize = new Size(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें.
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें.
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स के साथ स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/irenderingoptions/)—प्रदान करता है जो प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करने का विकल्प देते हैं। दोनों इंटरफ़ेस में `setSlidesLayoutOptions` मेथड शामिल है, जो इमेज में बदलते समय स्लाइड पर नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की अनुमति देता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी इमेज में नोट्स और कमेंट्स की वांछित स्थिति निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे बदलें:

```java 
float scaleX = 2;
float scaleY = scaleX;

// प्रस्तुति फ़ाइल लोड करें.
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // नोट्स की स्थिति सेट करें.
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // टिप्पणियों की स्थिति सेट करें.
    notesCommentsOptions.setCommentsAreaWidth(500);                         // टिप्पणी क्षेत्र की चौड़ाई सेट करें.
    notesCommentsOptions.setCommentsAreaColor(Color.LTGRAY);   // टिप्पणी क्षेत्र का रंग सेट करें.

    // रेंडरिंग विकल्प बनाएं.
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // प्रस्तुति की पहली स्लाइड को इमेज में बदलें.
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // इमेज को GIF फ़ॉर्मेट में सहेजें.
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-टू-इमेज रूपांतरण प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) मेथड `BottomFull` को लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itiffoptions/) इंटरफ़ेस आपको आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके उत्पन्न TIFF इमेज पर अधिक नियंत्रण देता है।

यह कोड एक रूपांतरण प्रक्रिया को दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की काली-श्वेत इमेज उत्पन्न की जाती है:

```java 
// एक प्रस्तुति फ़ाइल लोड करें.
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Size(2160, 2880));                  // इमेज का आकार सेट करें.
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (काली और सफ़ेद).
    tiffOptions.setDpiX(300);                                        // क्षैतिज रिज़ॉल्यूशन सेट करें.
    tiffOptions.setDpiY(300);                                        // वर्टिकल रिज़ॉल्यूशन सेट करें.

    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें.
    IImage image = slide.getImage(tiffOptions);

    try {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें.
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में बदल दिया जाता है।

यह जावा में सभी स्लाइड्स को इमेज में बदलने का नमूना कोड दिखाता है:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति को प्रत्येक स्लाइड के रूप में इमेज में रेंडर करें.
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी हुई स्लाइड्स को रेंडर न करें).
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // स्लाइड को इमेज में बदलें.
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें.
            image.save("Slide_" + i + ".jpg", ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर इमेज को सहेजता है, एनीमेशन शामिल नहीं होते।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हाँ, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेज को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हाँ, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय शैडो, ट्रांस्पैरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।