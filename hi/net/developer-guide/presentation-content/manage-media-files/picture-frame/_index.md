---
title: ".NET में प्रस्तुतियों में चित्र फ़्रेम प्रबंधित करें"
linktitle: "चित्र फ़्रेम"
type: docs
weight: 10
url: /hi/net/picture-frame/
keywords:
- चित्र फ़्रेम
- चित्र फ़्रेम जोड़ें
- चित्र फ़्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया हुआ क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ़्रेम फ़ॉर्मेटिंग
- चित्र फ़्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: " .NET के लिए Aspose.Slides के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ़्रेम जोड़ें। अपने कार्यप्रवाह को सरल बनाएं और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

Picture frame एक आकार है जो एक छवि को समाहित करता है—यह फ़्रेम में एक तस्वीर की तरह है।  

आप एक स्लाइड में चित्र फ़्रेम के माध्यम से छवि जोड़ सकते हैं। इस तरह, आप चित्र फ़्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="info" %}} 

Aspose मुफ्त कनवर्टर्स प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रेजेंटेशन बनाने की अनुमति देते हैं। 

{{% /alert %}} 

## **Picture Frame बनाएं**

1. एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेज़ेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. `AddPictureFrame` मेथड के माध्यम से, जो संदर्भित स्लाइड से जुड़े शेप ऑब्जेक्ट द्वारा उजागर किया गया है, छवि की चौड़ाई और ऊँचाई पर आधारित एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe) बनाएं।  
6. स्लाइड में एक चित्र फ़्रेम (जिसमें तस्वीर है) जोड़ें।  
7. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड आपको दिखाता है कि कैसे एक चित्र फ़्रेम बनाएं:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.Slides[0];

    // एक छवि लोड करता है और उसे प्रेजेंटेशन इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // उसी ऊँचाई और चौड़ाई के साथ एक picture frame जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // picture frame पर कुछ फ़ॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रेज़ेंटेशन को PPTX फ़ाइल में सहेजता है
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Picture frames आपको छवियों के आधार पर शीघ्रता से प्रेजेंटेशन स्लाइड बनाने की सुविधा देते हैं। जब आप चित्र फ़्रेम को Aspose.Slides के सहेजने विकल्पों के साथ संयोजित करते हैं, तो आप इनपुट/आउटपुट ऑपरेशन्स को नियंत्रित करके छवियों को एक फ़ॉर्मेट से दूसरे में बदल सकते हैं। आप इन पृष्ठों को देखना चाह सकते हैं: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/).  

{{% /alert %}}

## **रिलेटिव स्केल के साथ Picture Frame बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेज़ेंटेशन इमेज कलेक्शन में एक छवि जोड़ें।  
4. प्रेज़ेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
5. चित्र फ़्रेम में छवि की रिलेटिव चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड आपको दिखाता है कि कैसे रिलेटिव स्केल के साथ एक picture frame बनाएं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation presentation = new Presentation())
{
    // एक छवि लोड करता है और उसे प्रेज़ेंटेशन इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक picture frame जोड़ता है
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // रिलेटिव स्केल की चौड़ाई और ऊँचाई सेट करता है
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // प्रेज़ेंटेशन को सहेजता है
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Picture Frames से रास्टर इमेज निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe) ऑब्जेक्ट्स से रास्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG और अन्य फॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दिखाता है कि कैसे "sample.pptx" दस्तावेज़ से एक छवि निकालें और PNG फॉर्मेट में सहेजें।

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Picture Frames से SVG इमेज निकालें**

जब एक प्रेज़ेंटेशन में SVG ग्राफ़िक्स [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) आकारों के अंदर स्थित होते हैं, तो Aspose.Slides for .NET आपको मूल वेक्टर छवियों को पूरी शुद्धता के साथ पुनः प्राप्त करने देता है। स्लाइड की शेप कलेक्शन को पार करते हुए, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि संबंधित [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) में SVG सामग्री है या नहीं, और फिर उस छवि को उसके मूल SVG फॉर्मेट में डिस्क या स्ट्रीम में सहेज सकते हैं।

निम्न कोड उदाहरण दिखाता है कि कैसे एक picture frame से SVG छवि निकाली जाए:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **छवि की ट्रांसपैरेंसी प्राप्त करें**

Aspose.Slides आपको एक छवि पर लागू ट्रांसपैरेंसी इफ़ेक्ट को प्राप्त करने की अनुमति देता है। यह C# कोड इस ऑपरेशन को प्रदर्शित करता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **छवि की ब्राइटनेस और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको एक छवि पर लागू ब्राइटनेस और कंट्रास्ट इफ़ेक्ट को प्राप्त करने की अनुमति देता है। [ILuminance](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iluminance/) इंटरफ़ेस इस छवि ट्रांसफ़ॉर्म इफ़ेक्ट का प्रतिनिधित्व करता है।

यह C# कोड दिखाता है कि कैसे एक picture frame से ब्राइटनेस और कंट्रास्ट सेटिंग्स प्राप्त करें:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
छवियों पर लागू सभी इफ़ेक्ट्स आप [Aspose.Slides.Effects](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/) में पा सकते हैं।  
{{% /alert %}}

## **Picture Frame फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें एक picture frame पर लागू किया जा सकता है। उन विकल्पों का उपयोग करके, आप picture frame को बदल सकते हैं ताकि वह विशिष्ट आवश्यकताओं को पूरा करे।

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रेज़ेंटेशन ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में छवि जोड़कर एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, जिसे आकार को भरने के लिए उपयोग किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. `AddPictureFrame` मेथड के माध्यम से, जो [IShapes](http://www.aspose.com/api/net/slides/hi/aspose.slides/ishapecollection) ऑब्जेक्ट से जुड़े संदर्भित स्लाइड में उजागर किया गया है, छवि की चौड़ाई और ऊँचाई पर आधारित एक `PictureFrame` बनाएं।  
6. स्लाइड में picture frame (जिसमें तस्वीर है) जोड़ें।  
7. picture frame की लाइन कलर सेट करें।  
8. picture frame की लाइन चौड़ाई सेट करें।  
9. picture frame को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को घड़ी के विपरीत दिशा में घुमाता है।  
10. picture frame (जिसमें तस्वीर है) को स्लाइड में जोड़ें।  
11. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड picture frame फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = presentation.Slides[0];

    // एक छवि लोड करता है और उसे प्रेज़ेंटेशन इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // चित्र की समान ऊँचाई और चौड़ाई के साथ एक picture frame जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // picture frame पर कुछ फ़ॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रेज़ेंटेशन को PPTX फ़ाइल में सहेजता है
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मर्ज करने की आवश्यकता हो, या [फ़ोटो ग्रिड से ग्रिड बनाना](https://products.aspose.app/slides/hi/collage/photo-grid) हो, तो आप इस सेवा का उपयोग कर सकते हैं।  

{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

प्रेज़ेंटेशन आकार को कम रखने के लिए, आप फ़ाइलों को सीधे एम्बेड करने के बजाय लिंक के माध्यम से छवियों (या वीडियो) को जोड़ सकते हैं। यह C# कोड आपको दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो जोड़ें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **छवियों को क्रॉप करें**

यह C# कोड आपको दिखाता है कि स्लाइड में मौजूदा छवि को कैसे क्रॉप करें:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // नया इमेज ऑब्जेक्ट बनाता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक PictureFrame जोड़ता है
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // इमेज को क्रॉप करता है (प्रतिशत मान)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // परिणाम को सहेजता है
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **चित्र के क्रॉप किए गए क्षेत्रों को हटाएं**

यदि आप फ्रेम में शामिल छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि को लौटाता है, यदि क्रॉपिंग आवश्यक नहीं है।

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहली स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // PictureFrame छवि के क्रॉप किए हुए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // परिणाम को सहेजता है
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड क्रॉप की गई छवि को प्रेज़ेंटेशन इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) में उपयोग होती है, तो यह सेटअप प्रेज़ेंटेशन आकार को घटा सकता है। अन्यथा, परिणामी प्रेज़ेंटेशन में छवियों की संख्या बढ़ेगी।

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मेटा फ़ाइलों को रास्टर PNG छवि में परिवर्तित करता है।  

{{% /alert %}}

## **छवियों को संपीड़ित करें**

आप [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/) मेथड का उपयोग करके प्रेज़ेंटेशन में एक चित्र को संपीड़ित कर सकते हैं। यह मेथड आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर छवि का आकार घटाकर संपीड़ित करता है, और विकल्प के रूप में क्रॉप किए गए क्षेत्रों को हटाने की सुविधा देता है।  

यह पावरपॉइंट के **Picture Format → Compress Pictures → Resolution** फीचर के समान है।  

निम्न C# उदाहरण दिखाते हैं कि कैसे लक्ष्य रेज़ोल्यूशन निर्धारित करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रेज़ेंटेशन में छवि को संपीड़ित किया जा सकता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ छवि को संपीड़ित करें और क्रॉप किए हुए क्षेत्रों को हटाएँ।
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // संपीड़न के परिणाम की जाँच करें।
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

या सीधे एक कस्टम DPI मान का उपयोग करके:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) पर संपीड़ित करें, क्रॉप किए हुए क्षेत्रों को हटाते हुए।
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

यह मेथड आकार के आधार पर छवि को कम रेज़ोल्यूशन में बदलता है और आवश्यक होने पर क्रॉपेड क्षेत्रों को हटाकर फ़ाइल आकार को अनुकूलित करता है। यदि छवि एक मेटा फ़ाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं होगा। JPEG की गुणवत्ता रेज़ोल्यूशन के अनुसार संरक्षित या हल्की घटेगी, जैसा कि पावरपॉइंट उच्च-रेज़ोल्यूशन JPEG को संभालता है।  

{{% /alert %}}

## **अस्पेक्ट रेशो को लॉक करें**

यदि आप चाहते हैं कि छवि वाला आकार छवि के आयाम बदलने के बाद भी अपना एस्पेक्ट रेशो बनाए रखे, तो आप [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/aspectratiolocked/) प्रॉपर्टी का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं। 

यह C# कोड दिखाता है कि कैसे एक आकार के एस्पेक्ट रेशो को लॉक करें:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // आकार को रिसाइज़ करने पर अनुपात बनाए रखने के लिए सेट करता है
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल आकार के एस्पेक्ट रेशो को संरक्षित करती है, न कि उसमें शामिल छवि को।  

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat) क्लास के [StretchOffsetLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetright) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) प्रॉपर्टी का उपयोग करके, आप एक फ़िल भराव आयत निर्दिष्ट कर सकते हैं।  

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट किया जाता है, तो स्रोत आयत को निर्दिष्ट फ़िल आयत में फिट करने के लिए स्केल किया जाता है। फ़िल आयत का प्रत्येक किनारा आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत इन्सेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को।  

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास की इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. आकार की फ़िल टाइप सेट करें।  
6. आकार की पिक्चर फ़िल मोड सेट करें।  
7. आकार को फ़िल करने के लिए सेट इमेज जोड़ें।  
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारे से छवि के ऑफ़सेट निर्दिष्ट करें।  
9. परिवर्तित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दिखाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाए:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // आकार बॉडी में प्रत्येक किनारे से छवि को स्ट्रेच करने के लिए सेट करता है
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### मैं कैसे पता कर सकता हूँ कि PictureFrame के लिए कौन से इमेज फ़ॉर्मेट सपोर्टेड हैं?

Aspose.Slides रास्टर इमेजेज (PNG, JPEG, BMP, GIF आदि) और वेक्टर इमेजेज (जैसे SVG) को सपोर्ट करता है, जो एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) को सौंपा गया इमेज ऑब्जेक्ट द्वारा उपयोग किए जाते हैं। समर्थित फ़ॉर्मेट की सूची आम तौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है।

### बड़े छवियों की दर्जनों जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रेज़ेंटेशन आकार छोटा रहता है, लेकिन बाहरी फ़ाइलों को उपलब्ध रखना आवश्यक होता है। Aspose.Slides लिंक द्वारा छवियों को जोड़ने की क्षमता प्रदान करता है ताकि फ़ाइल आकार घटाया जा सके।

### मैं आकस्मिक मूव/रीसाइज़ से इमेज ऑब्जेक्ट को कैसे लॉक कर सकता हूँ?

[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) (जैसे मूविंग या रिसाइज़िंग को डिसेबल करना) के लिए आप [shape locks](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/pictureframelock/) का उपयोग कर सकते हैं। लॉकिंग मैकेनिज़्म को अलग [protection article](/slides/hi/net/applying-protection-to-presentation/) में आकारों के लिए बताया गया है और यह विभिन्न आकार प्रकारों, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) भी शामिल है, के लिए समर्थित है।

### क्या SVG वेक्टर फ़िडेलिटी PDF/इमेज में एक्सपोर्ट करने पर बनी रहती है?

Aspose.Slides एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) से SVG को मूल वेक्टर के रूप में निकालने की अनुमति देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/net/convert-powerpoint-to-pdf/) या [रास्टर फ़ॉर्मेट में](/slides/hi/net/convert-powerpoint-to-png/) करते हैं, तो एक्सपोर्ट सेटिंग्स के आधार पर परिणाम रास्टर हो सकता है; मूल SVG को वेक्टर के रूप में संग्रहीत रहने की पुष्टि निकासी व्यवहार द्वारा होती है।