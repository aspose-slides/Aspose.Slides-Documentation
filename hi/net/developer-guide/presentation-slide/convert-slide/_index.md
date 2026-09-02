---
title: प्रेजेंटेशन स्लाइड्स को .NET में इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/net/convert-slide/
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
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX और ODP से स्लाइड्स को C# में Aspose.Slides for .NET का उपयोग करके इमेज में बदलें—तेज़, उच्च‑गुणवत्ता वाला रेंडरिंग, स्पष्ट कोड उदाहरणों के साथ।"
---
## **परिचय**

Aspose.Slides for .NET आपको PowerPoint और OpenDocument प्रेजेंटेशन स्लाइड्स को विभिन्न इमेज फॉर्मैट्स, जैसे BMP, PNG, JPG (JPEG), GIF और अन्य में आसानी से परिवर्तित करने की सुविधा देता है।

एक स्लाइड को इमेज में बदलने के लिए, इन चरणों का पालन करें:

1. इच्छित कन्वर्ज़न सेटिंग्स को परिभाषित करें और उन स्लाइड्स का चयन करें जिन्हें आप एक्सपोर्ट करना चाहते हैं, इसके लिए उपयोग करें:
    - [ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) इंटरफ़ेस, या
    - [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/) इंटरफ़ेस।
2. [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) मेथड को कॉल करके स्लाइड इमेज उत्पन्न करें।

.NET में, एक [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) एक ऑब्जेक्ट है जो आपको पिक्सेल डेटा द्वारा परिभाषित इमेजेज के साथ काम करने की अनुमति देता है। आप इस क्लास की एक इंस्टेंस का उपयोग करके विभिन्न फ़ॉर्मैट्स (BMP, JPG, PNG, आदि) में इमेज को सेव कर सकते हैं।

## **स्लाइड्स को बिटमैप में परिवर्तित करें और PNG में इमेज सहेजें**

आप स्लाइड को एक बिटमैप ऑब्जेक्ट में बदल सकते हैं और सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदल कर फिर JPEG या किसी भी अन्य पसंदीदा फ़ॉर्मेट में इमेज सहेज सकते हैं।

निम्नलिखित C# कोड यह दर्शाता है कि कैसे एक प्रेजेंटेशन की पहली स्लाइड को बिटमैप ऑब्जेक्ट में बदलें और फिर PNG फ़ॉर्मेट में इमेज सहेजें:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // प्रेजेंटेशन की पहली स्लाइड को बिटमैप में बदलें।
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // इमेज को PNG फ़ॉर्मेट में सहेजें।
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **कस्टम आकार के साथ स्लाइड्स को इमेज में परिवर्तित करें**

आपको किसी विशेष आकार की इमेज चाहिए हो सकती है। [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) के ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) के साथ इमेज में बदल सकते हैं।

यह नमूना कोड इस प्रक्रिया को दर्शाता है:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // निर्दिष्ट आकार के साथ प्रेजेंटेशन की पहली स्लाइड को बिटमैप में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें।
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **नोट्स और कमेंट्स वाले स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और कमेंट्स हो सकते हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/)—प्रदान करता है जो प्रेजेंटेशन स्लाइड्स को इमेज में रेंडर करने पर नियंत्रण की अनुमति देते हैं। दोनों इंटरफ़ेस में `SlidesLayoutOptions` प्रॉपर्टी शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और कमेंट्स के रेंडरिंग को कॉन्फ़िगर करने की सुविधा देती है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामस्वरूप इमेज में नोट्स और कमेंट्स की अपनी पसंदीदा स्थिति निर्दिष्ट कर सकते हैं।

यह C# कोड दर्शाता है कि कैसे नोट्स और कमेंट्स वाले स्लाइड को बदलें:

```cs
float scaleX = 2;
float scaleY = scaleX;

// एक प्रेजेंटेशन फ़ाइल लोड करें.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // रेंडरिंग विकल्प बनाएं.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // नोट्स की स्थिति सेट करें।
            CommentsPosition = CommentsPositions.Right,      // टिप्पणियों की स्थिति सेट करें।
            CommentsAreaWidth = 500,                         // टिप्पणी क्षेत्र की चौड़ाई सेट करें।
            CommentsAreaColor = Color.AntiqueWhite           // टिप्पणी क्षेत्र का रंग सेट करें।
        }
    };

    // प्रेजेंटेशन की पहली स्लाइड को इमेज में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // इमेज को GIF फ़ॉर्मेट में सहेजें।
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="नोट" color="warning" %}} 

किसी भी स्लाइड-से-इमेज कन्वर्ज़न प्रक्रिया में, [NotesPosition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) प्रॉपर्टी को `BottomFull` (नोट्स की स्थिति निर्दिष्ट करने के लिए) पर सेट नहीं किया जा सकता क्योंकि नोट का टेक्स्ट बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) इंटरफ़ेस आपको आकार, रेज़ोल्यूशन, कलर पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके अंतिम TIFF इमेज पर अधिक नियंत्रण प्रदान करता है।

यह C# कोड एक ऐसा कन्वर्ज़न प्रक्रिया दर्शाता है जहाँ TIFF विकल्पों का उपयोग करके 300 DPI रेज़ोल्यूशन और 2160 × 2800 आकार की ब्लैक‑एंड‑व्हाइट इमेज उत्पन्न की जाती है:

```cs
// एक प्रेजेंटेशन फ़ाइल लोड करें.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // प्रेजेंटेशन से पहली स्लाइड प्राप्त करें.
    ISlide slide = presentation.Slides[0];

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // इमेज का आकार सेट करें.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफ़ेद).
        DpiX = 300,                                        // क्षैतिज रिज़ॉल्यूशन सेट करें.
        DpiY = 300                                         // ऊर्ध्वाधर रिज़ॉल्यूशन सेट करें.
    };

    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रेजेंटेशन की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रेजेंटेशन को इमेज की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड C# में दर्शाता है कि कैसे प्रेजेंटेशन की सभी स्लाइड्स को इमेज में बदलें:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // प्रेजेंटेशन को स्लाइड दर स्लाइड इमेज में रेंडर करें.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी हुई स्लाइड्स को रेंडर न करें).
        if (presentation.Slides[i].Hidden)
            continue;

        // स्लाइड को इमेज में बदलें.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **कलर इमोजी रेंडरिंग**

{{% alert title="नोट" color="warning" %}} 
जब प्रेजेंटेशन स्लाइड्स को इमेज में बदलते हैं तो कलर इमोजी को सही ढंग से रेंडर करने के लिए प्रेजेंटेशन में उपयोग किए गए इमोजी फ़ॉन्ट्स सिस्टम पर स्थापित और उपलब्ध होने चाहिए। उदाहरण के लिए, यदि प्रेजेंटेशन **Segoe UI Emoji** फ़ॉन्ट का उपयोग करता है और यह फ़ॉन्ट अनुपलब्ध है, तो इमेज आउटपुट में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनिमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `GetImage` मेथड केवल स्लाइड की स्थिर इमेज सेव करता है, बिना एनिमेशन के।

**क्या छिपी हुई स्लाइड्स को इमेज के रूप में एक्सपोर्ट किया जा सकता है?**

हाँ, छिपी हुई स्लाइड्स को भी सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। बस यह सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हों।

**क्या इमेज को शैडो और इफ़ेक्ट्स के साथ सेव किया जा सकता है?**

हाँ, Aspose.Slides स्लाइड्स को इमेज के रूप में सेव करते समय शैडो, ट्रांसपैरेंसी और अन्य ग्राफिक इफ़ेक्ट्स को रेंडर करने का समर्थन करता है।