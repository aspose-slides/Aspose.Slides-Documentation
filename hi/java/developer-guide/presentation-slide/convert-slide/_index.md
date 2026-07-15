---
title: "जावा में प्रस्तुति स्लाइड्स को छवियों में परिवर्तित करें"
linktitle: "स्लाइड से छवि"
type: docs
weight: 35
url: /hi/java/convert-slide/
keywords:
- "स्लाइड परिवर्तित करें"
- "स्लाइड निर्यात करें"
- "स्लाइड से छवि"
- "स्लाइड को छवि के रूप में सहेजें"
- "स्लाइड से PNG"
- "स्लाइड से JPEG"
- "स्लाइड से बिटमैप"
- "स्लाइड से TIFF"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides का उपयोग करके जावा में PPT, PPTX और ODP स्लाइड्स को छवियों में परिवर्तित करें—तेज़, उच्च‑गुणवत्ता वाला रेंडरिंग तथा स्पष्ट कोड उदाहरण।"
---
## **परिचय**

Aspose.Slides for Java आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न छवि प्रारूपों में परिवर्तित करने में सक्षम बनाता है, जिसमें BMP, PNG, JPG (JPEG), GIF और अन्य शामिल हैं।

एक स्लाइड को छवि में परिवर्तित करने के लिए, निम्न चरणों का पालन करें:

1. अपनी वांछित परिवर्तन सेटिंग्स को परिभाषित करें और उन स्लाइड्स का चयन करें जिन्हें आप निर्यात करना चाहते हैं, उपयोग करके:
    - The [ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) interface, or
    - The [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/) interface.
2. स्लाइड छवि को उत्पन्न करने के लिए [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) method को कॉल करें।

In Aspose.Slides for Java, an [IImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iimage/) is an interface that allows you to work with images defined by pixel data. You can use this interface to save images in a wide range of formats (BMP, JPG, PNG, etc.).

## **स्लाइड्स को बिटमैप में परिवर्तित करें और PNG में छवियों को सहेजें**

आप एक स्लाइड को बिटमैप ऑब्जेक्ट में परिवर्तित करके सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में परिवर्तित करके फिर उसे JPEG या किसी अन्य पसंदीदा प्रारूप में सहेज सकते हैं।

यह कोड प्रदर्शित करता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे परिवर्तित किया जाए और फिर छवि को PNG प्रारूप में कैसे सहेजा जाए:

```java 
Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को बिटमैप में परिवर्तित करें।
    IImage image = presentation.getSlides().get_Item(0).getImage();
	try {
        // छवि को PNG स्वरूप में सहेजें।
        image.save("Slide_0.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **स्लाइड्स को कस्टम आकार के साथ छवियों में परिवर्तित करें**

आपको किसी निश्चित आकार की छवि चाहिए हो सकती है। [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ छवि में परिवर्तित कर सकते हैं।

यह नमूना कोड दर्शाता है कि इसे कैसे किया जाए:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // निर्दिष्ट आकार के साथ प्रस्तुति में पहली स्लाइड को बिटमैप में परिवर्तित करें।
    IImage image = presentation.getSlides().get_Item(0).getImage(imageSize);

    try {
        // छवि को JPEG स्वरूप में सहेजें।
        image.save("Slide_0.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स वाले स्लाइड्स को छवियों में परिवर्तित करें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/irenderingoptions/)—प्रदान करता है जो आपको प्रस्तुति स्लाइड्स को छवियों में रेंडर करने को नियंत्रित करने की अनुमति देता है। दोनों इंटरफ़ेस में `setSlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को छवि में परिवर्तित करते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने में सक्षम बनाता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामी छवि में नोट्स और कमेंट्स के लिए अपनी पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि नोट्स और कमेंट्स वाले स्लाइड को कैसे परिवर्तित किया जाए:

```java 
float scaleX = 2;
float scaleY = scaleX;

// एक प्रस्तुति फ़ाइल लोड करें।
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // नोट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // कमेंट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsAreaWidth(500);                         // कमेंट्स क्षेत्र की चौड़ाई सेट करें।
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // कमेंट्स क्षेत्र के लिए रंग सेट करें.

    // रेन्डरिंग विकल्प बनाएं।
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // प्रस्तुति की पहली स्लाइड को छवि में परिवर्तित करें।
    IImage image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);

    try {
        // छवि को GIF स्वरूप में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

किसी भी slide-to-image परिवर्तन प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/inotescommentslayoutingoptions/#setNotesPosition-int-) मेथड `BottomFull` को लागू नहीं कर सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट छवि आकार में फिट नहीं हो पाता।

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में परिवर्तित करें**

[ITiffOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/itiffoptions/) इंटरफ़ेस आपको आकार, रेज़ोल्यूशन, कलर पैलेट और अधिक जैसे पैरामीटर निर्दिष्ट करके उत्पन्न TIFF छवि पर अधिक नियंत्रण प्रदान करता है।

यह कोड एक परिवर्तन प्रक्रिया को दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रेज़ोल्यूशन और 2160 × 2800 आकार की ब्लैक‑एंड‑व्हाइट छवि आउटपुट की जाती है:

```java 
// एक प्रस्तुति फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF छवि की सेटिंग्स कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // छवि का आकार सेट करें।
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (काली और सफ़ेद)।
    tiffOptions.setDpiX(300);                                        // क्षैतिज रिज़ॉल्यूशन सेट करें।
    tiffOptions.setDpiY(300);                                        // ऊर्ध्वाधर रिज़ॉल्यूशन सेट करें।

    // निर्दिष्ट विकल्पों के साथ स्लाइड को छवि में परिवर्तित करें।
    IImage image = slide.getImage(tiffOptions);

    try {
        // छवि को TIFF स्वरूप में सहेजें।
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

TIFF समर्थन JDK 9 से पहले के संस्करणों में गारंटीकृत नहीं है।

{{% /alert %}} 

## **सभी स्लाइड्स को छवियों में परिवर्तित करें**

Aspose.Slides आपको एक प्रस्तुति में सभी स्लाइड्स को छवियों में परिवर्तित करने की अनुमति देता है, जिससे पूरी प्रस्तुति को छवियों की श्रृंखला में प्रभावी रूप से बदला जा सकता है।

यह नमूना कोड दिखाता है कि Java में प्रस्तुति की सभी स्लाइड्स को छवियों में कैसे परिवर्तित किया जाए:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति को स्लाइड दर स्लाइड छवियों में रेंडर करें।
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी हुई स्लाइड्स को रेंडर न करें)।
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // स्लाइड को छवि में परिवर्तित करें।
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

## **रंगीन इमोजी रेंडरिंग**

{{% alert title="Note" color="warning" %}} 
रंगीन इमोजी को सही ढंग से रेंडर करने के लिए, प्रस्तुति में उपयोग किए गए इमोजी फ़ॉन्ट को उस सिस्टम पर स्थापित होना चाहिए जहाँ परिवर्तन किया जा रहा है। उदाहरण के लिए, यदि प्रस्तुति **Segoe UI Emoji** का उपयोग करती है और यह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट छवियों में इमोजी एकरंग (monochrome) दिखाई दे सकते हैं।
{{% /alert %}}

## **FAQ**

**क्या Aspose.Slides स्लाइड्स को एनीमेशन के साथ रेंडर करने का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर छवि सहेजता है, एनीमेशन के बिना।

**क्या छिपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हैं।

**क्या छवियों को शेडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को छवियों के रूप में सहेजते समय शेडो, ट्रांस्पेरेन्सी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।