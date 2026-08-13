---
title: .NET में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint को JPG में
type: docs
weight: 60
url: /hi/net/convert-powerpoint-to-jpg/
keywords:
- PowerPoint बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint को JPG में
- प्रेज़ेंटेशन को JPG में
- स्लाइड को JPG में
- PPT को JPG में
- PPTX को JPG में
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
description: "Aspose.Slides for .NET का उपयोग करके C# में PowerPoint (PPT, PPTX) स्लाइड्स को तेज़, विश्वसनीय कोड उदाहरणों के साथ उच्च-गुणवत्ता वाले JPG छवियों में बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रेज़ेंटेशन को JPG छवियों में बदलना स्लाइड्स को साझा करने, प्रदर्शन को अनुकूलित करने और वेबसाइट या एप्लिकेशन में सामग्री एम्बेड करने में मदद करता है। Aspose.Slides for .NET आपको PPTX, PPT और ODP फ़ाइलों को उच्च गुणवत्ता वाली JPEG छवियों में ट्रांसफ़ॉर्म करने की अनुमति देता है। यह गाइड रूपांतरण के विभिन्न तरीकों को समझाता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रेज़ेंटेशन व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान है। यह उपयोगी हो सकता है यदि आप प्रेज़ेंटेशन स्लाइड्स को कॉपी करने से बचाना चाहते हैं या केवल-पढ़ने मोड में प्रेज़ेंटेशन प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रेज़ेंटेशन या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मेट में बदलने की सुविधा देता है।

## **प्रेज़ेंटेशन स्लाइड्स को JPG छवियों में बदलें**

PPT, PPTX, या ODP फ़ाइल को JPG में बदलने के चरण इस प्रकार हैं:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) class.
2. Get the slide object of the [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide) type from the [Presentation.Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/properties/slides) collection.
3. Create an image of the slide using the [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/#getimage_5) method.
4. Call the [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/#save_3) method on the image object. Pass the output file name and image format as arguments.

{{% alert color="info" %}} 

**Note:** PPT, PPTX, या ODP से JPG रूपांतरण Aspose.Slides .NET API में अन्य फ़ॉर्मेट्स के रूपांतरण से अलग होता है। अन्य फ़ॉर्मेट्स के लिए, आप आमतौर पर [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/save/#save_5) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए आपको [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/#save_3) मेथड का उपयोग करना आवश्यक है।

{{% /alert %}} 

```c#
using Aspose.Slides;

int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // निर्दिष्ट स्केल की स्लाइड छवि बनाएं।
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **कस्टम आयामों के साथ स्लाइड्स को JPG में बदलें**

परिणामी JPG छवियों के आयाम बदलने के लिए, आप [ISlide.GetImage(Size)](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/#getimage_6) मेथड में आकार पास करके इमेज साइज सेट कर सकते हैं। यह आपको विशिष्ट चौड़ाई और ऊँचाई मानों के साथ छवियां उत्पन्न करने की अनुमति देता है, जिससे आउटपुट आपकी रिज़ॉल्यूशन और पहलू अनुपात की आवश्यकताओं को पूरा करता है। यह लचीलापन विशेष रूप से वेब एप्लिकेशन, रिपोर्ट या दस्तावेज़ों के लिए छवियां जनरेट करने में उपयोगी है, जहाँ सटीक इमेज डायमेंशन आवश्यक होते हैं।

```c#
using System.Drawing;
using Aspose.Slides;

Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // निर्दिष्ट आकार की स्लाइड छवि बनाएं।
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // छवि को JPEG फ़ॉर्मेट में डिस्क पर सहेजें।
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **छवियों के रूप में स्लाइड्स को सहेजते समय टिप्पणियों को रेंडर करें**

Aspose.Slides for .NET एक सुविधा प्रदान करता है जो आपको प्रेज़ेंटेशन की स्लाइड्स को JPG छवियों में बदलते समय टिप्पणियों को रेंडर करने देती है। यह कार्यक्षमता विशेष रूप से PowerPoint प्रेज़ेंटेशन में सहयोगियों द्वारा जोड़े गए एनोटेशन, फीडबैक या चर्चाओं को संरक्षित रखने के लिए उपयोगी है। इस विकल्प को सक्षम करके, आप सुनिश्चित करते हैं कि टिप्पणियां बनाई गई छवियों में दिखाई दें, जिससे मूल प्रेज़ेंटेशन फ़ाइल को खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास एक प्रेज़ेंटेशन फ़ाइल "sample.pptx" है, जिसमें एक स्लाइड पर टिप्पणियां हैं:

![टिप्पणियों के साथ स्लाइड](slide_with_comments.png)

निम्नलिखित C# कोड स्लाइड को JPG छवि में बदलता है और टिप्पणियों को संरक्षित रखता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // स्लाइड टिप्पणियों के लिए विकल्प सेट करें।
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // पहली स्लाइड को छवि में बदलें।
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```

परिणाम:

![टिप्पणियों के साथ JPG छवि](image_with_comments.png)

## **और देखें**

PPT, PPTX, या ODP को छवियों में बदलने के अन्य विकल्प देखें, जैसे:

- [PowerPoint को GIF में कनवर्ट करें](/slides/hi/net/convert-powerpoint-to-animated-gif/)
- [PowerPoint को PNG में कनवर्ट करें](/slides/hi/net/convert-powerpoint-to-png/)
- [PowerPoint को TIFF में कनवर्ट करें](/slides/hi/net/convert-powerpoint-to-tiff/)
- [PowerPoint को SVG में कनवर्ट करें](/slides/hi/net/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aspose.Slides कैसे PowerPoint को JPG छवियों में बदलता है, यह देखने के लिए इन नि:शुल्क ऑनलाइन कनवर्टर्स को आज़माएं: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)। 

{{% /alert %}} 

![नि:शुल्क ऑनलाइन PPTX से JPG कनवर्टर](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG इमेजेज़ को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके, आप इमेजेज़ को एक फ़ॉर्मेट से दूसरे में बदल सकते हैं। अधिक जानकारी के लिए इन पृष्ठों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या यह विधि बैच रूपांतरण का समर्थन करती है?

हां, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देती है।

### क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स का समर्थन करता है?

हां, Aspose.Slides सभी सामग्री को रेंडर करती है, जिसमें SmartArt, चार्ट, टेबल, शेप आदि शामिल हैं। हालांकि, रेंडरिंग सटीकता PowerPoint की तुलना में थोड़ा अलग हो सकती है, विशेष रूप से कस्टम या गायब फ़ॉन्ट्स का उपयोग करने पर।

### प्रक्रिया की जा सकने वाली स्लाइड्स की संख्या पर कोई सीमा है क्या?

Aspose.Slides स्वयं प्रोसेस की जा सकने वाली स्लाइड्स की संख्या पर कोई कड़ी सीमा नहीं लगाता। हालांकि, बड़े प्रेज़ेंटेशन या उच्च-रिज़ॉल्यूशन इमेजेज़ के साथ काम करते समय आपको मेमोरी समाप्ति त्रुटि का सामना करना पड़ सकता है।