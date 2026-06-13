---
title: जावा में प्रेज़ेंटेशन स्लाइड्स को छवियों में बदलें
linktitle: स्लाइड से छवि
type: docs
weight: 35
url: /hi/java/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से छवि
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides का उपयोग करके जावा में PPT, PPTX और ODP स्लाइड्स को छवियों में बदलें—तेज़, उच्च गुणवत्ता वाला रेंडरिंग, स्पष्ट कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides for Java आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न छवि स्वरूपों में बदलने की सुविधा देता है, जिसमें BMP, PNG, JPG (JPEG), GIF, और अन्य शामिल हैं।

स्लाइड को छवि में बदलने के लिए, निम्नलिखित चरणों का पालन करें:

1. इच्छित रूपांतरण सेटिंग्स को परिभाषित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इसके लिए उपयोग करें:
    - The [ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/) interface.
2. स्लाइड छवि उत्पन्न करने के लिए [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) method को कॉल करें।

Aspose.Slides for Java में, एक [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) एक इंटरफ़ेस है जो आपको पिक्सेल डेटा द्वारा परिभाषित छवियों के साथ काम करने की अनुमति देता है। आप इस इंटरफ़ेस का उपयोग करके विभिन्न स्वरूपों (BMP, JPG, PNG, आदि) में छवियों को सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में छवियों को सहेजें**

आप एक स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप एक स्लाइड को बिटमैप में बदल सकते हैं और फिर छवि को JPEG या किसी अन्य पसंदीदा स्वरूप में सहेज सकते हैं।

यह कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदला जाए और फिर PNG स्वरूप में छवि को कैसे सहेजा जाए:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति की पहली स्लाइड को बिटमैप में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage();
    try {
        // छवि को PNG प्रारूप में सहेजें।
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकार के साथ स्लाइड्स को छवियों में बदलें**

आपको एक निश्चित आकार की छवि चाहिए हो सकती है। [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) के एक ओवरलोड का उपयोग करके आप स्लाइड को विशेष आयामों (चौड़ाई और ऊँचाई) वाली छवि में बदल सकते हैं।

यह नमूना कोड दर्शाता है कि इसे कैसे किया जाए:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रेज़ेंटेशन की पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // छवि को JPEG प्रारूप में सहेजें।
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स वाली स्लाइड्स को छवियों में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस प्रदान करता है—[ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/)—जो प्रस्तुति स्लाइड्स को छवियों में रेंडर करने को नियंत्रित करने की अनुमति देते हैं। दोनों इंटरफ़ेस में `setSlidesLayoutOptions` मेथड शामिल है, जो आपको स्लाइड को छवि में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की सुविधा देता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी छवि में नोट्स और कमेंट्स की वांछित स्थिति निर्दिष्ट कर सकते हैं।

```java 
float scaleX = 2;
float scaleY = scaleX;

// प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // नोट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // कमेंट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsAreaWidth(500);                         // कमेंट्स क्षेत्र की चौड़ाई सेट करें।
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // कमेंट्स क्षेत्र का रंग सेट करें।

    // रेंडरिंग विकल्प बनाएं।
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // प्रेज़ेंटेशन की पहली स्लाइड को छवि में बदलें।
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // छवि को GIF प्रारूप में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
किसी भी स्लाइड-से-छवि रूपांतरण प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) मेथड `BottomFull` को लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का पाठ बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट छवि आकार में फिट नहीं हो पाता।
{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) इंटरफ़ेस आपको आकार, रिज़ॉल्यूशन, रंग पैलेट और अधिक जैसे पैरामीटर निर्दिष्ट करने की अनुमति देकर परिणामस्वरूप TIFF छवि पर अधिक नियंत्रण देता है।

यह कोड एक रूपांतरण प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की ब्लैक‑एंड‑व्हाइट छवि आउटपुट की जाती है:

```java 
// प्रेजेंटेशन फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रेजेंटेशन से पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF छवि की सेटिंग्स कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // छवि का आकार सेट करें।
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // पिक्सेल फॉर्मेट सेट करें (भूरा और सफेद)।
    tiffOptions.setDpiX(300);                                        // क्षैतिज रेज़ोल्यूशन सेट करें।
    tiffOptions.setDpiY(300);                                        // लंबवत रेज़ोल्यूशन सेट करें।

    // स्लाइड को निर्दिष्ट विकल्पों के साथ छवि में बदलें।
    IImage image = slide.getImage(tiffOptions);

    try {
        // छवि को TIFF प्रारूप में सहेजें।
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
TIFF समर्थन JDK 9 से पहले के संस्करणों में गारंटी नहीं है।
{{% /alert %}} 

## **सभी स्लाइड्स को छवियों में बदलें**

Aspose.Slides आपको प्रस्तुति में सभी स्लाइड्स को छवियों में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को छवियों की श्रृंखला में प्रभावी रूप से बदल दिया जाता है।

यह नमूना कोड दर्शाता है कि जावा में प्रस्तुति की सभी स्लाइड्स को छवियों में कैसे बदला जाए:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रेजेंटेशन को स्लाइड दर स्लाइड छवियों में रेंडर करें।
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी हुई स्लाइड्स को रेंडर न करें)।
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // स्लाइड को छवि में बदलें।
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // छवि को JPEG प्रारूप में सहेजें।
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

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर छवि को सहेजता है, जिसमें एनीमेशन नहीं होते।

**क्या छुपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हाँ, छुपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या छवियों को छायाओं और प्रभावों के साथ सहेजा जा सकता है?**

हाँ, Aspose.Slides स्लाइड्स को छवियों के रूप में सहेजते समय छायाएँ, पारदर्शिता और अन्य ग्राफ़िक प्रभावों को रेंडर करने का समर्थन करता है।