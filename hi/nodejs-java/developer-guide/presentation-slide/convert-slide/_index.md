---
title: जावास्क्रिप्ट में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 35
url: /hi/nodejs-java/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात
- स्लाइड से इमेज
- स्लाइड को इमेज के रूप में सहेजें
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके जावास्क्रिप्ट में PPT, PPTX और ODP स्लाइड्स को इमेज में बदलें — तेज़, उच्च-गुणवत्ता वाला रेंडरिंग स्पष्ट कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides for Node.js via Java आपको आसानी से PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स में बदलने की सुविधा देता है, जैसे BMP, PNG, JPG (JPEG), GIF, और अन्य।

स्लाइड को इमेज में बदलने के लिए, निम्न चरणों का पालन करें:

1. अपनी इच्छित रूपांतरण सेटिंग्स निर्धारित करें और उन स्लाइड्स को चुनें जिन्हें आप निर्यात करना चाहते हैं, इनका उपयोग करके:
    - [TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास, या
    - [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/) क्लास।
2. स्लाइड इमेज उत्पन्न करने के लिए [getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) मेथड को कॉल करें।

Aspose.Slides for Node.js via Java में, [IImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/) एक क्लास है जो आपको पिक्सेल डेटा द्वारा परिभाषित इमेज के साथ काम करने की अनुमति देती है। आप इस क्लास का उपयोग विभिन्न फ़ॉर्मेट्स (BMP, JPG, PNG, आदि) में इमेज को सहेजने के लिये कर सकते हैं।

## **स्लाइड को बिटमैप में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लीकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर इमेज को JPEG या किसी अन्य वांछित फ़ॉर्मेट में सहेज सकते हैं।

यह JavaScript कोड दर्शाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर इमेज को PNG फ़ॉर्मेट में कैसे सहेजें:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को बिटमैप में बदलें।
    let image = presentation.getSlides().get_Item(0).getImage();
    try {
        // इमेज को PNG फ़ॉर्मेट में सहेजें।
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकार के साथ स्लाइड को इमेज में बदलें**

आपको किसी विशेष आकार की इमेज चाहिए हो सकती है। [getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage) के ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ इमेज में बदल सकते हैं। 

यह नमूना कोड दिखाता है कि यह कैसे किया जाता है:

```js
let imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    let image = presentation.getSlides().get_Item(0).getImage(imageSize);
    try {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें।
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **नोट्स और कमेंट्स के साथ स्लाइड को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो क्लासेस प्रदान करता है—[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) और [RenderingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/)—जो आपको प्रस्तुति स्लाइड्स को इमेज में बदलने की प्रक्रिया को नियंत्रित करने की अनुमति देती हैं। दोनों क्लासेस में `setSlidesLayoutOptions` मेथड शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने में मदद करता है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामस्वरूप इमेज में नोट्स और कमेंट्स की इच्छित स्थिति निर्धारित कर सकते हैं।

यह JavaScript कोड दर्शाता है कि नोट्स और कमेंट्स वाली स्लाइड को कैसे इमेज में बदला जाए:

```js
const scaleX = 2;
const scaleY = scaleX;

// एक प्रस्तुति फ़ाइल लोड करें।
let presentation = new aspose.slides.Presentation("Presentation_with_notes_and_comments.pptx");
try {
    let notesCommentsOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesCommentsOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);                  // नोट्स की स्थिति सेट करें।
    notesCommentsOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);                      // टिप्पणियों की स्थिति सेट करें।
    notesCommentsOptions.setCommentsAreaWidth(500);                                                       // टिप्पणियों क्षेत्र की चौड़ाई सेट करें।
    notesCommentsOptions.setCommentsAreaColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));  // टिप्पणियों क्षेत्र का रंग सेट करें.

    // रेंडरिंग विकल्प बनाएं।
    let options = new aspose.slides.RenderingOptions();
    options.setSlidesLayoutOptions(notesCommentsOptions);
 
    // प्रस्तुति की पहली स्लाइड को इमेज में बदलें।
    let image = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        // इमेज को GIF फ़ॉर्मेट में सहेजें।
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

किसी भी स्लाइड-से-इमेज रूपांतरण प्रक्रिया में, [setNotesPosition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) मेथड `BottomFull` (नोट्स की स्थिति निर्दिष्ट करने के लिये) लागू नहीं कर सकता क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता। 

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड को इमेज में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/) क्लास आपको आकार, रिज़ॉल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके परिणामस्वरूप TIFF इमेज पर अधिक नियंत्रण देती है।

यह JavaScript कोड एक रूपांतरण प्रक्रिया दर्शाता है जिसमें TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की ब्लैक-एंड-व्हाइट इमेज उत्पन्न की जाती है:

```js
// एक प्रस्तुति फ़ाइल लोड करें।
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // प्रस्तुति से पहली स्लाइड प्राप्त करें।
    let slide = presentation.getSlides().get_Item(0);

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setImageSize(java.newInstanceSync("java.awt.Dimension", 2160, 2880));  // इमेज का आकार सेट करें.
    tiffOptions.setPixelFormat(aspose.slides.ImagePixelFormat.Format1bppIndexed);      // पिक्सेल फ़ॉर्मेट सेट करें (ब्लैक एंड व्हाइट).
    tiffOptions.setDpiX(300);                                                          // क्षैतिज रिज़ॉल्यूशन सेट करें.
    tiffOptions.setDpiY(300);                                                          // ऊर्ध्वाधर रिज़ॉल्यूशन सेट करें.

    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
    let image = slide.getImage(tiffOptions);
    try {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें.
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

JDK 9 से पहले के संस्करणों में TIFF समर्थन की गारंटी नहीं है। 

{{% /alert %}} 

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में बदला जा सकता है।

यह नमूना कोड दर्शाता है कि JavaScript में प्रस्तुति की सभी स्लाइड्स को इमेज में कैसे बदला जाए:

```js
const scaleX = 2;
const scaleY = scaleX;

let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    // प्रस्तुति को स्लाइड दर स्लाइड इमेज में रेंडर करें।
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
        if (presentation.getSlides().get_Item(i).getHidden()) {
            continue;
        }

        // स्लाइड को इमेज में बदलें।
        let image = presentation.getSlides().get_Item(i).getImage(scaleX, scaleY);
        try {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें।
            image.save("Slide_" + i + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **कलर इमोजी रेंडरिंग**

{{% alert title="Note" color="warning" %}} 
प्रस्तुति स्लाइड्स को इमेज में बदलते समय कलर इमोजी सही तरीके से रेंडर करने के लिए, प्रस्तुति में प्रयुक्त इमोजी फ़ॉन्ट्स को उस सिस्टम पर इंस्टॉल और उपलब्ध होना चाहिए जो रूपांतरण कर रहा है। उदाहरण के लिए, यदि प्रस्तुति में **Segoe UI Emoji** फ़ॉन्ट उपयोग किया गया है और वह अनुपलब्ध है, तो आउटपुट इमेज में इमोजी मोनोक्रोम दिख सकते हैं। 
{{% /alert %}} 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन्स वाली स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `getImage` मेथड केवल स्लाइड की स्थिर इमेज सहेजता है, बिना एनीमेशन के।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हाँ, छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेजेस को शैडो और इफ़ेक्ट्स के साथ सहेजा जा सकता है?**

हाँ, Aspose.Slides इमेज के रूप में स्लाइड्स सहेजते समय शैडो, ट्रांसपैरेंसी और अन्य ग्राफ़िक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।