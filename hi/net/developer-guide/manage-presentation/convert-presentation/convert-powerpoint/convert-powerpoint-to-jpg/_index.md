---
title: PPT और PPTX को .NET में JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से JPG
- प्रेज़ेंटेशन से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- PowerPoint को JPG के रूप में सहेजें
- प्रेज़ेंटेशन को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके C# में PowerPoint (PPT, PPTX) स्लाइड्स को उच्च‑गुणवत्ता वाले JPG चित्रों में तेज़ और विश्वसनीय कोड उदाहरणों के साथ बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में बदलने से स्लाइड्स को साझा करना, प्रदर्शन को अनुकूलित करना और सामग्री को वेबसाइटों या एप्लिकेशन में एम्बेड करना आसान हो जाता है। Aspose.Slides for .NET आपको PPTX, PPT और ODP फाइलों को उच्च‑गुणवत्ता वाले JPEG छवियों में बदलने की सुविधा देता है। यह मार्गदर्शिका विभिन्न रूपांतरण विधियों को समझाती है।

इन सुविधाओं के साथ, आप अपना स्वयं का प्रेज़ेंटेशन व्यूर बना सकते हैं और प्रत्येक स्लाइड का थंबनेल तैयार कर सकते हैं। यह उपयोगी हो सकता है यदि आप स्लाइड्स को कॉपी करने से बचाना चाहते हैं या केवल‑पढ़ने की स्थिति में प्रस्तुति दिखाना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मेट में बदलने की अनुमति देता है।

## **प्रेज़ेंटेशन स्लाइड्स को JPG छवियों में बदलें**

PPT, PPTX या ODP फ़ाइल को JPG में बदलने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
1. [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/properties/slides) कलेक्शन से [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
1. [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/#getimage_5) मेथड का उपयोग करके स्लाइड की इमेज बनाएँ।
1. इमेज ऑब्जेक्ट पर [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/#save_3) मेथड कॉल करें। आउटपुट फ़ाइल नाम और इमेज फ़ॉर्मेट को आर्ग्युमेंट्स के रूप में पास करें।

{{% alert color="primary" %}} 

**ध्यान दें:** PPT, PPTX या ODP से JPG रूपांतरण Aspose.Slides .NET API में अन्य फ़ॉर्मेट्स के रूपांतरण से अलग है। अन्य फ़ॉर्मेट्स के लिए आप आमतौर पर [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/#save_5) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए आपको [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/#save_3) मेथड का प्रयोग करना होगा।

{{% /alert %}} 

```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // निर्दिष्ट स्केल के अनुसार स्लाइड इमेज बनाएं।
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **कस्टमाइज्ड डायमेंशन के साथ स्लाइड्स को JPG में बदलें**

नतीजित JPG छवियों के आयाम बदलने के लिए, आप [ISlide.GetImage(Size)](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/#getimage_6) मेथड में आकार पास करके इमेज साइज निर्धारित कर सकते हैं। इससे आप विशेष चौड़ाई और ऊँचाई वाले इमेज बना सकते हैं, जिससे आउटपुट रिज़ॉल्यूशन और एस्पेक्ट रेशो आपकी आवश्यकताओं के अनुसार हो। यह लचीलापन वेब एप्लिकेशन, रिपोर्ट या दस्तावेज़ों में सटीक इमेज डायमेंशन की आवश्यकता होने पर बहुत उपयोगी है।

```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // निर्दिष्ट आकार की स्लाइड इमेज बनाएं।
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // इमेज को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **स्लाइड्स को इमेज के रूप में सेव करते समय टिप्पणी (Comments) को रेंडर करना**

Aspose.Slides for .NET एक ऐसी सुविधा प्रदान करता है जिससे आप प्रेज़ेंटेशन की स्लाइड्स को JPG छवियों में बदलते समय टिप्पणी (Comments) को भी रेंडर कर सकते हैं। यह फ़ीचर PowerPoint प्रस्तुतियों में सहयोगियों द्वारा जोड़ी गई एनोटेशन, फीडबैक या चर्चाओं को संरक्षित करने में विशेष रूप से उपयोगी है। इस विकल्प को सक्षम करके आप सुनिश्चित करते हैं कि टिप्पणी उत्पन्न छवियों में दिखाई दे, जिससे मूल फ़ाइल को खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास "sample.pptx" नामक प्रेज़ेंटेशन फाइल है, जिसमें एक स्लाइड पर टिप्पणियां हैं:

![The slide with comments](slide_with_comments.png)

निम्नलिखित C# कोड स्लाइड को टिप्पणी के साथ JPG इमेज में बदलता है:

```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // स्लाइड टिप्पणी के लिए विकल्प सेट करें।
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // पहली स्लाइड को इमेज में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

परिणाम:

![The JPG image with comments](image_with_comments.png)

## **संबंधित लेख**

PPT, PPTX या ODP को इमेज में बदलने के अन्य विकल्प देखें, जैसे:

- [Convert PowerPoint to GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/hi/net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/hi/net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/hi/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides द्वारा PowerPoint को JPG छवियों में बदलने का तरीका देखने के लिए इन मुफ्त ऑनलाइन कन्वर्टर्स को आज़माएँ: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)। 

{{% /alert %}} 

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG इमेज को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में बताए गए समान सिद्धांतों का उपयोग करके आप इमेज को एक फ़ॉर्मेट से दूसरे में बदल सकते हैं। अधिक जानकारी के लिए इन पेजों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण का समर्थन करती है?**

हाँ, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूप से बदलने की सुविधा देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स को सपोर्ट करता है?**

हाँ, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, टेबल, शेप्स आदि शामिल हैं। हालांकि, रेंडरिंग सटीकता PowerPoint की तुलना में थोड़ा अलग हो सकती है, विशेषकर कस्टम या अनुपलब्ध फ़ॉन्ट्स के उपयोग पर।

**क्या प्रक्रिया किए जाने वाले स्लाइड्स की संख्या पर कोई सीमा है?**

Aspose.Slides स्वयं स्लाइड्स की संख्या पर कोई कठोर सीमा नहीं लगाता। लेकिन बड़े प्रेज़ेंटेशन या उच्च‑रिज़ॉल्यूशन इमेज के साथ काम करते समय मेमोरी की कमी (out‑of‑memory) की त्रुटि आ सकती है।