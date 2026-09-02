---
title: जावा में प्रस्तुति स्लाइड्स को छवियों में बदलें
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
description: "Aspose.Slides का उपयोग करके जावा में PPT, PPTX और ODP की स्लाइड्स को छवियों में बदलें—तेज़, उच्च-गुणवत्ता वाला रेंडरिंग और स्पष्ट कोड उदाहरण।"
---
## **परिचय**

Aspose.Slides for Java आपको PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न छवि स्वरूपों, जैसे BMP, PNG, JPG (JPEG), GIF, और अन्य में आसानी से परिवर्तित करने की सुविधा देता है।

एक स्लाइड को छवि में परिवर्तित करने के लिए, निम्नलिखित चरणों का पालन करें:

1. वांछित रूपांतरण सेटिंग्स को परिभाषित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इस प्रकार:
    - [ITiffOptions] इंटरफ़ेस, या
    - [IRenderingOptions] इंटरफ़ेस।
2. स्लाइड छवि को उत्पन्न करने के लिए [getImage] मेथड को कॉल करें।

Aspose.Slides for Java में, एक [IImage] एक इंटरफ़ेस है जो आपको पिक्सेल डेटा द्वारा परिभाषित छवियों के साथ काम करने की अनुमति देता है। आप इस इंटरफ़ेस का उपयोग करके विभिन्न स्वरूपों (BMP, JPG, PNG, आदि) में छवियों को सहेज सकते हैं।

## **स्लाइड को बिटमैप में बदलें और PNG में छवियाँ सहेजें**

आप स्लाइड को एक बिटमैप ऑब्जेक्ट में बदल सकते हैं और उसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर फिर JPEG या किसी अन्य पसंदीदा स्वरूप में छवि सहेज सकते हैं।

यह कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर PNG स्वरूप में छवि को कैसे सहेजें:

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

## **कस्टम आकार के साथ स्लाइड को छवि में बदलें**

आपको एक विशिष्ट आकार की छवि चाहिए हो सकती है। [getImage] के एक ओवरलोड का उपयोग करके, आप स्लाइड को निर्दिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ छवि में बदल सकते हैं।

यह नमूना कोड दिखाता है कि यह कैसे किया जाता है:

```java 
Dimension imageSize = new Dimension(1820, 1040);

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // निर्दिष्ट आकार के साथ प्रस्तुति की पहली स्लाइड को बिटमैप में बदलें।
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

## **नोट्स और कमेंट्स वाली स्लाइड को छवि में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions] और [IRenderingOptions]—प्रदान करता है जो आपको प्रस्तुति स्लाइड्स को छवियों में रेंडर करने पर नियंत्रण करने की अनुमति देते हैं। दोनों इंटरफ़ेस में `setSlidesLayoutOptions` मेथड शामिल है, जो आपको स्लाइड को छवि में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने देता है।

[NotesCommentsLayoutingOptions] क्लास के साथ, आप परिणामस्वरूप छवि में नोट्स और कमेंट्स के लिए अपनी पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह कोड दर्शाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे बदलें:

```java 
float scaleX = 2;
float scaleY = scaleX;

// एक प्रस्तुति फ़ाइल लोड करें।
Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(NotesPositions.BottomTruncated);  // नोट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsPosition(CommentsPositions.Right);      // टिप्पणियों की स्थिति सेट करें।
    notesCommentsOptions.setCommentsAreaWidth(500);                         // टिप्पणियों क्षेत्र की चौड़ाई सेट करें।
    notesCommentsOptions.setCommentsAreaColor(Color.LIGHT_GRAY);            // टिप्पणियों क्षेत्र के लिए रंग सेट करें।

    // रेंडरिंग विकल्प बनाएं।
    RenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);

    // प्रस्तुति की पहली स्लाइड को छवि में बदलें।
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

किसी भी स्लाइड-से-छवि परिवर्तन प्रक्रिया में, [setNotesPosition] मेथड `BottomFull` को लागू नहीं कर सकता (नोट्स की स्थिति निर्धारित करने के लिए) क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट छवि आकार में फिट नहीं हो पाता।

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड को छवि में बदलें**

[ITiffOptions] इंटरफ़ेस आपको परिणामी TIFF छवि पर अधिक नियंत्रण देता है, जिससे आप आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट कर सकते हैं।

यह कोड दिखाता है कि TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की काली‑सफ़ेद छवि कैसे आउटपुट की जाती है:

```java 
// एक प्रस्तुति फ़ाइल लोड करें।
Presentation presentation = new Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें।
    ISlide slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF छवि की सेटिंग्स कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setImageSize(new Dimension(2160, 2880));             // छवि का आकार सेट करें।
    tiffOptions.setPixelFormat(ImagePixelFormat.Format1bppIndexed);  // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफ़ेद)।
    tiffOptions.setDpiX(300);                                        // क्षैतिज रेजोल्यूशन सेट करें।
    tiffOptions.setDpiY(300);                                        // लंबवत रेजोल्यूशन सेट करें।

    // निर्दिष्ट विकल्पों के साथ स्लाइड को छवि में बदलें।
    IImage image = slide.getImage(tiffOptions);

    try {
        // छवि को TIFF फ़ॉर्मेट में सहेजें।
        image.save("output.tiff", ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

JDK 9 से पहले के संस्करणों में Tiff समर्थन की गारंटी नहीं है।

{{% /alert %}} 

## **सभी स्लाइड को छवियों में बदलें**

Aspose.Slides आपको एक प्रस्तुति की सभी स्लाइड्स को छवियों में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को छवियों की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड दर्शाता है कि Java में प्रस्तुति की सभी स्लाइड्स को छवियों में कैसे बदलें:

```java 
float scaleX = 2;
float scaleY = scaleX;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    // प्रस्तुति को स्लाइड दर स्लाइड छवियों में रेंडर करें।
    for (int i = 0 ; i < presentation.getSlides().size(); i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
        if (presentation.getSlides().get_Item(i).getHidden())
            continue;

        // स्लाइड को एक छवि में बदलें।
        IImage image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);

        try {
            // छवि को JPEG फ़ॉर्मेट में सहेजें।
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
जब प्रस्तुति स्लाइड्स को छवियों में बदलते समय रंगीन इमोजी को सही ढंग से रेंडर करना हो, तो प्रस्तुति में प्रयुक्त इमोजी फ़ॉन्ट्स को उस सिस्टम पर स्थापित और उपलब्ध होना चाहिए जहाँ परिवर्तन हो रहा है। उदाहरण के लिए, यदि प्रस्तुति **Segoe UI Emoji** फ़ॉन्ट का उपयोग करती है और वह फ़ॉन्ट अनुपलब्ध है, तो इमोजी आउटपुट छवियों में मोनोक्रोम दिखाई दे सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड रेंडरिंग का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर छवि को सहेजता है, बिना एनीमेशन के।

**क्या छिपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हां, छिपी हुई स्लाइड्स को भी सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या छवियों को छाया और प्रभावों के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को छवियों के रूप में सहेजते समय छाया, पारदर्शिता और अन्य ग्राफ़िक प्रभावों को रेंडर करने का समर्थन करता है।