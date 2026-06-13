---
title: .NET में प्रस्तुति स्लाइड्स को इमेज में बदलें
linktitle: स्लाइड से इमेज
type: docs
weight: 41
url: /hi/net/convert-slide/
keywords:
- स्लाइड परिवर्तित करें
- स्लाइड निर्यात करें
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
description: "PPT, PPTX और ODP से स्लाइड को C# में Aspose.Slides for .NET का उपयोग करके इमेज में बदलें—तेज़, उच्च-गुणवत्ता वाला रेंडरिंग स्पष्ट कोड उदाहरणों के साथ."
---
## **परिचय**

Aspose.Slides for .NET आपको PowerPoint और OpenDocument प्रस्तुति स्लाइड्स को विभिन्न इमेज फ़ॉर्मेट्स जैसे BMP, PNG, JPG (JPEG), GIF आदि में आसानी से परिवर्तित करने की सुविधा देता है।

स्लाइड को इमेज में बदलने के लिए निम्न चरणों का पालन करें:

1. आवश्यक रूपांतरण सेटिंग्स निर्धारित करें और उन स्लाइड्स का चयन करें जिन्हें आप निर्यात करना चाहते हैं:
    - [ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) इंटरफ़ेस का उपयोग करके, या
    - [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/) इंटरफ़ेस का उपयोग करके.
2. [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) मेथड को कॉल करके स्लाइड इमेज उत्पन्न करें।

.NET में, एक [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) वह ऑब्जेक्ट है जो पिक्सेल डेटा द्वारा परिभाषित इमेजेस के साथ काम करने की सुविधा देता है। आप इस क्लास की एक इंस्टेंस का उपयोग करके BMP, JPG, PNG आदि विभिन्न फ़ॉर्मेट्स में इमेज को सहेज सकते हैं।

## **स्लाइड्स को बिटमैप में बदलें और PNG में इमेज सहेजें**

आप स्लाइड को एक बिटमैप ऑब्जेक्ट में बदल सकते हैं और इसे सीधे अपने एप्लिकेशन में उपयोग कर सकते हैं। वैकल्पिक रूप से, आप स्लाइड को बिटमैप में बदलकर इमेज को JPEG या किसी अन्य पसंदीदा फ़ॉर्मेट में सहेज सकते हैं।

यह C# कोड दिखाता है कि प्रस्तुति की पहली स्लाइड को बिटमैप ऑब्जेक्ट में कैसे बदलें और फिर इमेज को PNG फ़ॉर्मेट में सहेजें:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // प्रस्तुति में पहली स्लाइड को बिटमैप में बदलें।
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // इमेज को PNG फ़ॉर्मेट में सहेजें।
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **कस्टम आकारों के साथ स्लाइड्स को इमेज में बदलें**

कभी-कभी आपको निश्चित आकार की इमेज चाहिए होती है। [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) के एक ओवरलोड का उपयोग करके, आप स्लाइड को विशिष्ट आयामों (चौड़ाई और ऊँचाई) वाली इमेज में बदल सकते हैं।

यह नमूना कोड इस प्रक्रिया को दर्शाता है:

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // प्रस्तुति में पहली स्लाइड को निर्दिष्ट आकार के साथ बिटमैप में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // इमेज को JPEG फ़ॉर्मेट में सहेजें।
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **नोट्स और टिप्पणियों के साथ स्लाइड्स को इमेज में बदलें**

कुछ स्लाइड्स में नोट्स और टिप्पणियाँ हो सकती हैं।

Aspose.Slides दो इंटरफ़ेस—[ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) और [IRenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/irenderingoptions/)—प्रदान करता है जो प्रस्तुति स्लाइड्स को इमेज में रेंडर करने को नियंत्रित करने की अनुमति देते हैं। दोनों इंटरफ़ेस में `SlidesLayoutOptions` प्रॉपर्टी शामिल है, जो स्लाइड को इमेज में बदलते समय नोट्स और टिप्पणियों के रेंडरिंग को कॉन्फ़िगर करने में मदद करती है।

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) क्लास के साथ, आप परिणामस्वरूप इमेज में नोट्स और टिप्पणियों की इच्छित स्थिति निर्धारित कर सकते हैं।

यह C# कोड दिखाता है कि नोट्स और टिप्पणियों के साथ स्लाइड को कैसे बदलें:

```cs
float scaleX = 2;
float scaleY = scaleX;

// प्रस्तुति फ़ाइल लोड करें।
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // रेंडरिंग विकल्प बनाएं।
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // नोट्स की स्थिति सेट करें।
            CommentsPosition = CommentsPositions.Right,      // टिप्पणियों की स्थिति सेट करें।
            CommentsAreaWidth = 500,                         // टिप्पणियों के क्षेत्र की चौड़ाई सेट करें।
            CommentsAreaColor = Color.AntiqueWhite           // टिप्पणियों के क्षेत्र के लिए रंग सेट करें।
        }
    };

    // प्रस्तुति की पहली स्लाइड को इमेज में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // इमेज को GIF फ़ॉर्मेट में सहेजें।
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

किसी भी स्लाइड-से-इमेज रूपांतरण प्रक्रिया में, [NotesPosition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) प्रॉपर्टी को `BottomFull` पर सेट नहीं किया जा सकता (नोट्स की स्थिति निर्दिष्ट करने के लिए), क्योंकि नोट के टेक्स्ट का आकार बहुत बड़ा हो सकता है, जिससे वह निर्दिष्ट इमेज आकार में फिट नहीं हो पाता।

{{% /alert %}} 

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को इमेज में बदलें**

[ITiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/itiffoptions/) इंटरफ़ेस आपको आकार, रिज़ॉल्यूशन, रंग पैलेट आदि जैसे पैरामीटर निर्दिष्ट करके परिणामी TIFF इमेज पर अधिक नियंत्रण देता है।

यह C# कोड दिखाता है कि कैसे TIFF विकल्पों का उपयोग करके 300 DPI रिज़ॉल्यूशन और 2160 × 2800 आकार की काली-सफ़ेद इमेज उत्पन्न की जाए:

```cs
// प्रस्तुति फ़ाइल लोड करें।
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // प्रस्तुति से पहला स्लाइड प्राप्त करें।
    ISlide slide = presentation.Slides[0];

    // आउटपुट TIFF इमेज की सेटिंग्स कॉन्फ़िगर करें।
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // इमेज का आकार सेट करें।
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // पिक्सेल फ़ॉर्मेट सेट करें (काला और सफ़ेद)।
        DpiX = 300,                                        // क्षैतिज रेज़ॉल्यूशन सेट करें।
        DpiY = 300                                         // लंबवत रेज़ॉल्यूशन सेट करें।
    };

    // निर्दिष्ट विकल्पों के साथ स्लाइड को इमेज में बदलें।
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // इमेज को TIFF फ़ॉर्मेट में सहेजें।
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **सभी स्लाइड्स को इमेज में बदलें**

Aspose.Slides आपको प्रस्तुति की सभी स्लाइड्स को इमेज में बदलने की अनुमति देता है, जिससे पूरी प्रस्तुति को इमेजों की श्रृंखला में परिवर्तित किया जा सकता है।

यह नमूना कोड C# में दिखाता है कि कैसे सभी स्लाइड्स को इमेज में बदला जाए:

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // प्रस्तुति को प्रत्येक स्लाइड के लिए इमेज में रेंडर करें।
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // छिपी हुई स्लाइड्स को नियंत्रित करें (छिपी स्लाइड्स को रेंडर न करें)।
        if (presentation.Slides[i].Hidden)
            continue;

        // स्लाइड को इमेज में बदलें।
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // इमेज को JPEG फ़ॉर्मेट में सहेजें।
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **FAQ**

**1. क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं, `GetImage` मेथड केवल स्लाइड की स्थैतिक इमेज सहेजता है, बिना एनीमेशन के।

**2. क्या छुपी हुई स्लाइड्स को इमेज के रूप में निर्यात किया जा सकता है?**

हां, छुपी हुई स्लाइड्स को भी सामान्य स्लाइड्स की तरह प्रोसेस किया जा सकता है। सुनिश्चित करें कि वे प्रोसेसिंग लूप में शामिल हैं।

**3. क्या इमेजेज़ को छाया और प्रभावों के साथ सहेजा जा सकता है?**

हां, Aspose.Slides स्लाइड्स को इमेज के रूप में सहेजते समय छाया, पारदर्शिता और अन्य ग्राफ़िक प्रभावों को रेंडर करने का समर्थन करता है।