---
title: ".NET में प्रस्तुतियों में पिक्चर फ्रेम प्रबंधित करें"
linktitle: "पिक्चर फ्रेम"
type: docs
weight: 10
url: /hi/net/picture-frame/
keywords:
- "पिक्चर फ्रेम"
- "पिक्चर फ्रेम जोड़ें"
- "पिक्चर फ्रेम बनाएं"
- "छवि जोड़ें"
- "छवि बनाएं"
- "छवि निकालें"
- "रास्टर छवि"
- "वेक्टर छवि"
- "छवि को क्रॉप करें"
- "क्रॉप किया गया क्षेत्र"
- "StretchOff प्रॉपर्टी"
- "पिक्चर फ्रेम फॉर्मेटिंग"
- "पिक्चर फ्रेम प्रॉपर्टीज़"
- "सापेक्ष स्केल"
- "छवि प्रभाव"
- "आस्पेक्ट अनुपात"
- "छवि पारदर्शिता"
- "PowerPoint"
- "OpenDocument"
- "प्रेजेंटेशन"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में पिक्चर फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइनों को बेहतर बनाएं।"
---
## **परिचय**

एक पिक्चर फ्रेम वह आकार है जो एक छवि शामिल करता है— यह फ्रेम में तस्वीर जैसा है।

आप एक पिक्चर फ्रेम के माध्यम से स्लाइड में छवि जोड़ सकते हैं। इस प्रकार, आप पिक्चर फ्रेम को फॉर्मेट करके छवि को फॉर्मेट कर सकते हैं।

{{% alert  title="Tip" color="primary" %}} 
Aspose मुफ्त कन्वर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रेजेंटेशन बनाने की सुविधा देता है। 
{{% /alert %}} 

## **पिक्चर फ्रेम बनाएं**

1. एक [Presentation ](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंज़ प्राप्त करें। 
3. एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा। 
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें। 
5. एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe) बनाएं, छवि की चौड़ाई और ऊँचाई के आधार पर, `AddPictureFrame` मेथड के द्वारा जो रेफ़रेंस्ड स्लाइड से जुड़े shape ऑब्जेक्ट द्वारा उजागर किया गया है। 
6. स्लाइड में एक पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें। 
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C# कोड दिखाता है कि पिक्चर फ्रेम कैसे बनाएं:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.Slides[0];

    // एक छवि लोड करता है और उसे प्रस्तुति की इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // उसी ऊँचाई और चौड़ाई के साथ एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // पिक्चर फ्रेम पर कुछ फॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रेजेंटेशन को PPTX फ़ाइल में लिखता है
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 
पिक्चर फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रेजेंटेशन स्लाइड बनाने की अनुमति देते हैं। जब आप पिक्चर फ्रेम को Aspose.Slides की सेव ऑप्शन के साथ मिलाते हैं, तो आप इनपुट/आउटपुट ऑपरेशन को नियंत्रित कर एक फॉर्मेट से दूसरे फॉर्मेट में छवियों को परिवर्तित कर सकते हैं। आप इन पृष्ठों को देखना चाह सकते हैं: convert [image to JPG](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/). 
{{% /alert %}}

## **सापेक्ष स्केल के साथ पिक्चर फ्रेम बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंज़ प्राप्त करें। 
3. प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ें। 
4. एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा। 
5. पिक्चर फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें। 
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C# कोड दिखाता है कि सापेक्ष स्केल के साथ पिक्चर फ्रेम कैसे बनाएं:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // एक छवि लोड करता है और उसे प्रस्तुति की इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // सापेक्ष स्केल की चौड़ाई और ऊँचाई सेट करता है
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // प्रेजेंटेशन को सहेजता है
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **पिक्चर फ्रेम से रास्टर छवियों को निकालें**

आप [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe) ऑब्जेक्ट से रास्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG और अन्य फॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दर्शाता है कि दस्तावेज़ “sample.pptx” से एक छवि को निकालकर PNG फॉर्मेट में कैसे सहेजा जाए।

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **पिक्चर फ्रेम से SVG छवियों को निकालें**

जब किसी प्रस्तुति में [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) आकार के भीतर SVG ग्राफ़िक्स रखे होते हैं, तो Aspose.Slides for .NET आपको मूल वेक्टर छवियों को पूरी शुद्धता के साथ पुनः प्राप्त करने देता है। स्लाइड की shape कलेक्शन को पार करते हुए, आप प्रत्येक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) में SVG कंटेंट है या नहीं, और फिर उस छवि को उसके मूल SVG फॉर्मेट में डिस्क या स्ट्रीम में सहेज सकते हैं।

नीचे दिया गया कोड उदाहरण दर्शाता है कि पिक्चर फ्रेम से SVG छवि को कैसे निकालें:

```cs
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

## **छवि की पारदर्शिता प्राप्त करें**

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने देता है। यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
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

## **छवि की चमक और कंट्रास्ट प्राप्त करें**

Aspose.Slides आपको छवि पर लागू चमक और कंट्रास्ट प्रभाव को प्राप्त करने देता है। [ILuminance](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iluminance/) इंटरफ़ेस इस छवि ट्रांसफ़ॉर्म प्रभाव का प्रतिनिधित्व करता है।

यह C# कोड दिखाता है कि पिक्चर फ्रेम से चमक और कंट्रास्ट सेटिंग्स कैसे प्राप्त करें:

```csharp
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

{{% alert color="primary" %}} 
छवियों पर लागू सभी प्रभाव [Aspose.Slides.Effects](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/) में पाए जा सकते हैं। 
{{% /alert %}}

## **पिक्चर फ्रेम फॉर्मेटिंग**

Aspose.Slides पिक्चर फ्रेम पर लागू करने के लिए कई फॉर्मेटिंग विकल्प प्रदान करता है। इन विकल्पों का उपयोग करके, आप पिक्चर फ्रेम को विशिष्ट आवश्यकताओं के अनुरूप बदल सकते हैं।

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंज़ प्राप्त करें। 
3. एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage) ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े [IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection) में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा। 
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें। 
5. [AddPictureFrame](http://www.aspose.com/api/net/slides/hi/aspose.slides/ishapecollection/methods/addpictureframe) मेथड के द्वारा `PictureFrame` बनाएं, जो रेफ़रेंस्ड स्लाइड से जुड़े [IShapes](http://www.aspose.com/api/net/slides/hi/aspose.slides/ishapecollection) ऑब्जेक्ट द्वारा उजागर किया गया है। 
6. स्लाइड में पिक्चर फ्रेम (जिसमें चित्र है) जोड़ें। 
7. पिक्चर फ्रेम की लाइन रंग सेट करें। 
8. पिक्चर फ्रेम की लाइन चौड़ाई सेट करें। 
9. पिक्चर फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ। 
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है। 
   * नकारात्मक मान छवि को घड़ी के विपरीत दिशा में घुमाता है। 
10. पिक्चर फ्रेम (जिसमें चित्र है) को स्लाइड में जोड़ें। 
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

यह C# कोड पिक्चर फ्रेम फॉर्मेटिंग प्रक्रिया को दर्शाता है:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = presentation.Slides[0];

    // एक छवि लोड करता है और उसे प्रस्तुति की इमेज कलेक्शन में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // छवि की समान ऊँचाई और चौड़ाई के साथ एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // पिक्चर फ्रेम पर कुछ फॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रेजेंटेशन को PPTX फ़ाइल में लिखता है
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Aspose ने हाल ही में एक [free Collage Maker](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फ़ोटो ग्रिड](https://products.aspose.app/slides/hi/collage/photo-grid) बनाना हो, तो आप इस सेवा का उपयोग कर सकते हैं। 
{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

प्रस्तुति का आकार कम रखने के लिए, आप फ़ाइलों को सीधे एम्बेड करने की बजाय लिंक द्वारा छवियां (या वीडियो) जोड़ सकते हैं। यह C# कोड दर्शाता है कि प्लेसहोल्डर में छवि और वीडियो कैसे जोड़ें:

```c#
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

यह C# कोड दर्शाता है कि स्लाइड पर मौजूद छवि को कैसे क्रॉप किया जाए:

```c#
using (Presentation presentation = new Presentation())
{
    // एक नया इमेज ऑब्जेक्ट बनाता है
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक पिक्चर फ्रेम जोड़ता है
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // छवि को क्रॉप करता है (प्रतिशत मान)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // परिणाम को सहेजता है
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **पिक्चर फ्रेम के क्रॉप किए गए क्षेत्रों को हटाएं**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह C# कोड इस ऑपरेशन को दर्शाता है:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // पहली स्लाइड से पिक्चर फ्रेम प्राप्त करता है
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // पिक्चर फ्रेम इमेज के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई इमेज लौटाता है
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // परिणाम सहेजता है
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) मेथड क्रॉप की गई छवि को प्रस्तुति इमेज कलेक्शन में जोड़ता है। यदि छवि केवल प्रोसेस किए गए [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) में उपयोग की गई है, तो यह सेटअप प्रस्तुति का आकार कम कर सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ जाएगी। 

यह मेथड क्रॉपिंग ऑपरेशन में WMF/EMF मे टा फ़ाइलों को रास्टर PNG छवि में बदल देता है। 
{{% /alert %}}

## **छवियों को संकुचित करें**

आप प्रस्तुति में पिक्चर को [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/) मेथड का उपयोग करके संकुचित कर सकते हैं। यह मेथड आकार और निर्दिष्ट रेज़ोल्यूशन के आधार पर छवि के आकार को कम करके संकुचन करता है, और चयनित होने पर क्रॉप किए गए क्षेत्रों को हटाने का विकल्प भी देता है। 

यह PowerPoint के **Picture Format → Compress Pictures → Resolution** फीचर के समान है।

निम्न C# उदाहरण दिखाते हैं कि लक्ष्य रेज़ोल्यूशन निर्दिष्ट करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को कैसे संकुचित करें:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ छवि को संकुचित करें और क्रॉप किए गए क्षेत्रों को हटाएं।
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // संकुचन के परिणाम की जाँच करें।
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

या सीधे कस्टम DPI मान का उपयोग करके:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) पर संकुचित करें, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 
यह मेथड आकार और प्रदान किए गए DPI के आधार पर छवि को कम रेज़ोल्यूशन में बदल देता है। फ़ाइल आकार को अनुकूलित करने के लिए क्रॉप किए गए क्षेत्रों को भी हटाया जा सकता है। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संकुचन लागू नहीं होगा। साथ ही, JPEG की क्वालिटी रेज़ोल्यूशन के अनुसार बरकरार रहती है या थोड़ी घटती है, जैसा कि PowerPoint उच्च‑रेज़ोल्यूशन JPEG को संभालता है। 
{{% /alert %}}

## **लॉक एस्पेक्ट रेशियो**

यदि आप चाहते हैं कि छवि वाले आकार को बदलने के बाद भी उसका एस्पेक्ट रेशियो बना रहे, तो आप [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/aspectratiolocked/) प्रॉपर्टी का उपयोग करके *Lock Aspect Ratio* सेटिंग सेट कर सकते हैं। 

यह C# कोड दिखाता है कि आकार के एस्पेक्ट रेशियो को कैसे लॉक करें:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // रिसाइज़ करने पर आकार का आस्पेक्ट रेशियो बनाये रखने के लिए सेट करता है
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 
यह *Lock Aspect Ratio* सेटिंग केवल आकार के एस्पेक्ट रेशियो को संरक्षित करती है, न कि उसके भीतर मौजूद छवि को। 
{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

[StretchOffsetLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetright) और [StretchOffsetBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) प्रॉपर्टी को [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat) इंटरफ़ेस और [PictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat) क्लास से उपयोग करके आप एक फ़िल रेक्टेंगल निर्दिष्ट कर सकते हैं। 

जब किसी छवि के लिए स्ट्रेचिंग निर्दिष्ट की जाती है, तो स्रोत रेक्टेंगल को निर्दिष्ट फ़िल रेक्टेंगल में फिट होने के लिए स्केल किया जाता है। फ़िल रेक्टेंगल के प्रत्येक किनारे को आकार की बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित किया जाता है। सकारात्मक प्रतिशत इन्सेट को दर्शाता है जबकि नकारात्मक प्रतिशत आउटसेट को। 

1. एक [Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/) क्लास का इंस्टेंस बनाएं। 
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंज़ प्राप्त करें। 
3. एक रेक्टेंगल `AutoShape` जोड़ें। 
4. एक छवि बनाएं। 
5. आकार का फ़िल टाइप सेट करें। 
6. आकार का पिक्चर फ़िल मोड सेट करें। 
7. आकार को भरने के लिए सेट इमेज जोड़ें। 
8. आकार की बाउंडिंग बॉक्स के संबंधित किनारे से इमेज ऑफ़सेट निर्दिष्ट करें 
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें। 

यह C# कोड दर्शाता है कि StretchOff प्रॉपर्टी का उपयोग कैसे किया जाता है:

```c#
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

**मैं कैसे पता कर सकता हूँ कि पिक्चर फ्रेम के लिए कौन से इमेज फॉर्मेट सपोर्टेड हैं?**

Aspose.Slides रास्टर इमेज (PNG, JPEG, BMP, GIF, आदि) और वेक्टर इमेज (जैसे SVG) दोनों को सपोर्ट करता है, जो [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) को असाइन किए गए इमेज ऑब्जेक्ट के माध्यम से उपलब्ध होते हैं। समर्थित फॉर्मेट की सूची आमतौर पर स्लाइड और इमेज कन्वर्ज़न इंजन की क्षमताओं के साथ ओवरलैप करती है। 

**कई बड़ी छवियों को जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; लिंक की गई छवियां फ़ाइल आकार को कम रखती हैं लेकिन बाहरी फ़ाइलों की उपलब्धता आवश्यक बनाती हैं। Aspose.Slides लिंक द्वारा छवि जोड़ने की सुविधा देता है जिससे फ़ाइल आकार घटाया जा सके। 

**मैं कैसे किसी इमेज ऑब्जेक्ट को आकस्मिक मूव/रीसाइज़ से लॉक कर सकता हूँ?**

[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) (उदाहरण के लिए, मूव या रीसाइज़ को डिसेबल) के लिए आप [shape locks](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/pictureframelock/) का उपयोग कर सकते हैं। लॉकिंग मैकेनिज़्म को आकारों के लिए अलग [protection article](/slides/hi/net/applying-protection-to-presentation/) में वर्णित किया गया है और यह विभिन्न आकार प्रकारों, जिसमें [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) भी शामिल है, के लिए समर्थित है। 

**क्या SVG वेक्टर फ़िडेलिटी को PDF/इमेज में एक्सपोर्ट करने पर संरक्षित रखा जाता है?**

Aspose.Slides आपको एक [PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/) से मूल वेक्टर के रूप में SVG निकालने देता है। जब आप [PDF में एक्सपोर्ट](/slides/hi/net/convert-powerpoint-to-pdf/) या [रास्टर फॉर्मेट्स](/slides/hi/net/convert-powerpoint-to-png/) में निर्यात करते हैं, तो सेटिंग्स के अनुसार परिणाम रास्टराइज़ हो सकता है; मूल SVG के वेक्टर रूप में संग्रहित रहने की पुष्टि एक्सट्रैक्शन व्यवहार से होती है।