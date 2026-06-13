---
title: .NET में प्रस्तुतियों में चित्र फ्रेम प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/net/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएं
- छवि जोड़ें
- छवि बनाएं
- छवि निकालें
- रास्टर छवि
- वेक्टर छवि
- छवि क्रॉप करें
- क्रॉप किया गया क्षेत्र
- StretchOff प्रॉपर्टी
- चित्र फ्रेम फॉर्मेटिंग
- चित्र फ्रेम गुण
- सापेक्ष स्केल
- छवि प्रभाव
- अस्पेक्ट अनुपात
- छवि पारदर्शिता
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में चित्र फ्रेम जोड़ें। अपने कार्यप्रवाह को सुव्यवस्थित करें और स्लाइड डिज़ाइन को बेहतर बनाएं।"
---
## **परिचय**

चित्र फ्रेम एक आकार है जो एक छवि को समाहित करता है—यह फ्रेम में चित्र की तरह है।

आप एक स्लाइड में चित्र फ्रेम के माध्यम से छवि जोड़ सकते हैं। इस तरह, आप चित्र फ्रेम को फ़ॉर्मेट करके छवि को फ़ॉर्मेट कर सकते हैं।

{{% alert  title="टिप" color="primary" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG से PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG से PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो लोगों को छवियों से जल्दी प्रस्तुतियाँ बनाने में मदद करता है।

{{% /alert %}} 

## **चित्र फ्रेम बनाएं**

1. `[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)` वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage)` ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े `[IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection)` में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. आकार ऑब्जेक्ट द्वारा प्रदान किए गए `AddPictureFrame` मेथड का उपयोग करके छवि की चौड़ाई और ऊँचाई के आधार पर एक `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe)` बनाएं।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दिखाता है कि कैसे एक चित्र फ्रेम बनाएं:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = pres.Slides[0];

    // छवि लोड करता है और उसे प्रस्तुति छवि संग्रह में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // समान ऊँचाई और चौड़ाई के साथ एक चित्र फ्रेम जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // चित्र फ्रेम पर कुछ फ़ॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रस्तुति को PPTX फ़ाइल में लिखता है
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

चित्र फ्रेम आपको छवियों के आधार पर शीघ्रता से प्रस्तुति स्लाइड बनाने की सुविधा देता है। जब आप चित्र फ्रेम को Aspose.Slides की सहेजने विकल्पों के साथ मिलाते हैं, तो आप इनपुट/आउटपुट संचालन को नियंत्रित कर एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को परिवर्तित कर सकते हैं। आप इन पृष्ठों को देखना चाह सकते हैं: छवि को [JPG में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/image-to-jpg/); [JPG को छवि में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/jpg-to-image/); [JPG को PNG में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/jpg-to-png/), [PNG को JPG में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/png-to-jpg/); [PNG को SVG में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/png-to-svg/), [SVG को PNG में कनवर्ट करें](https://products.aspose.com/slides/hi/net/conversion/svg-to-png/).  

{{% /alert %}}

## **सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं**

छवि की सापेक्ष स्केल को बदलकर आप अधिक जटिल चित्र फ्रेम बना सकते हैं।

1. `[Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)` वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. प्रस्तुति की छवि संग्रह में एक छवि जोड़ें।  
4. `[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage)` ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े `[IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection)` में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
5. चित्र फ्रेम में छवि की सापेक्ष चौड़ाई और ऊँचाई निर्दिष्ट करें।  
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दिखाता है कि कैसे सापेक्ष स्केल के साथ चित्र फ्रेम बनाएं:

```c#
// PPTX फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // छवि लोड करता है और उसे प्रस्तुति छवि संग्रह में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक चित्र फ्रेम जोड़ता है
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // सापेक्ष स्केल की ऊँचाई और चौड़ाई सेट करता है
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // प्रस्तुति को सहेजता है
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **चित्र फ्रेम से रास्टर छवियों को निकालें**

आप `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe)` ऑब्जेक्ट से रास्टर छवियों को निकाल सकते हैं और उन्हें PNG, JPG आदि फ़ॉर्मेट में सहेज सकते हैं। नीचे दिया गया कोड उदाहरण दस्तावेज़ “sample.pptx” से एक छवि निकालता है और उसे PNG फ़ॉर्मेट में सहेजता है।

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

## **चित्र फ्रेम से SVG छवियों को निकालें**

जब एक प्रस्तुति में SVG ग्राफ़िक्स `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/)` आकार के भीतर रखे होते हैं, तो Aspose.Slides for .NET मूल वेक्टर छवियों को पूर्ण विश्वसनीयता के साथ पुनः प्राप्त करने की अनुमति देता है। स्लाइड के आकार संग्रह को पार करते हुए, आप प्रत्येक `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/)` की पहचान कर सकते हैं, जांच सकते हैं कि अंतर्निहित `[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/)` में SVG सामग्री है या नहीं, और फिर उस छवि को उसके मूल SVG फ़ॉर्मेट में डिस्क या स्ट्रीम में सहेज सकते हैं।

निम्न कोड उदाहरण दिखाता है कि कैसे एक चित्र फ्रेम से SVG छवि निकाली जाए:

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

Aspose.Slides आपको छवि पर लागू पारदर्शिता प्रभाव को प्राप्त करने की अनुमति देता है। यह C# कोड इस ऑपरेशन को प्रदर्शित करता है:

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

{{% alert color="primary" %}} 
छवियों पर लागू सभी प्रभाव [Aspose.Slides.Effects](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/) में पाए जा सकते हैं।  
{{% /alert %}}

## **चित्र फ्रेम फ़ॉर्मेटिंग**

Aspose.Slides कई फ़ॉर्मेटिंग विकल्प प्रदान करता है जिन्हें चित्र फ्रेम पर लागू किया जा सकता है। इन विकल्पों का उपयोग करके आप चित्र फ्रेम को विशिष्ट आवश्यकताओं के अनुरूप बना सकते हैं।

1. `[Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/)` वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage)` ऑब्जेक्ट बनाएं, प्रस्तुति ऑब्जेक्ट से जुड़े `[IImagescollection](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection)` में एक छवि जोड़कर, जिसका उपयोग आकार को भरने के लिए किया जाएगा।  
4. छवि की चौड़ाई और ऊँचाई निर्दिष्ट करें।  
5. `[AddPictureFrame](http://www.aspose.com/api/net/slides/hi/aspose.slides/ishapecollection/methods/addpictureframe)` मेथड का उपयोग करके छवि की चौड़ाई और ऊँचाई के आधार पर एक `PictureFrame` बनाएं, जो संदर्भित स्लाइड से जुड़े `[IShapes](http://www.aspose.com/api/net/slides/hi/aspose.slides/ishapecollection)` ऑब्जेक्ट द्वारा प्रदर्शित है।  
6. स्लाइड में चित्र फ्रेम (जिसमें चित्र है) जोड़ें।  
7. चित्र फ्रेम की लाइन रंग सेट करें।  
8. चित्र फ्रेम की लाइन चौड़ाई सेट करें।  
9. चित्र फ्रेम को सकारात्मक या नकारात्मक मान देकर घुमाएँ।  
   * सकारात्मक मान छवि को घड़ी की दिशा में घुमाता है।  
   * नकारात्मक मान छवि को घड़ी के विपरीत दिशा में घुमाता है।  
10. चित्र फ्रेम (जिसमें चित्र है) को स्लाइड में फिर से जोड़ें।  
11. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड चित्र फ्रेम फ़ॉर्मेटिंग प्रक्रिया को दर्शाता है:

```c#
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
using (Presentation presentation = new Presentation())
{
    // पहली स्लाइड प्राप्त करता है
    ISlide slide = presentation.Slides[0];

    // छवि लोड करता है और उसे प्रस्तुति छवि संग्रह में जोड़ता है
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // चित्र की समान ऊँचाई और चौड़ाई के साथ एक चित्र फ्रेम जोड़ता है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // चित्र फ्रेम पर कुछ फ़ॉर्मेटिंग लागू करता है
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // प्रस्तुति को PPTX फ़ाइल में लिखता है
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose ने हाल ही में एक [नि:शुल्क कोलाज मेकर](https://products.aspose.app/slides/hi/collage) विकसित किया है। यदि आपको कभी [JPG/JPEG](https://products.aspose.app/slides/hi/collage/jpg) या PNG छवियों को मिलाना हो, या [फ़ोटो ग्रिड से ग्रिड बनाना हो](https://products.aspose.app/slides/hi/collage/photo-grid), तो आप इस सेवा का उपयोग कर सकते हैं।  

{{% /alert %}}

## **एक छवि को लिंक के रूप में जोड़ें**

प्रस्तुति का आकार घटाने के लिए आप फ़ाइलों को सीधे प्रस्तुतियों में एम्बेड करने के बजाय लिंक के माध्यम से छवियां (या वीडियो) जोड़ सकते हैं। यह C# कोड दिखाता है कि कैसे एक प्लेसहोल्डर में छवि और वीडियो जोड़ा जाए:

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

यह C# कोड दिखाता है कि स्लाइड पर मौजूद छवि को कैसे क्रॉप किया जाए:

```c#
using (Presentation presentation = new Presentation())
{
    // एक नया इमैज ऑब्जेक्ट बनाता है
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // स्लाइड में एक PictureFrame जोड़ता है
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

## **चित्र फ्रेम के क्रॉप किए गए क्षेत्रों को हटाएं**

यदि आप फ्रेम में मौजूद छवि के क्रॉप किए गए क्षेत्रों को हटाना चाहते हैं, तो आप `[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)` मेथड का उपयोग कर सकते हैं। यह मेथड क्रॉप की गई छवि या मूल छवि लौटाता है यदि क्रॉपिंग आवश्यक नहीं है।

यह C# कोड ऑपरेशन को दर्शाता है:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    //  पहली स्लाइड से PictureFrame प्राप्त करता है
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    //  PictureFrame छवि के क्रॉप किए गए क्षेत्रों को हटाता है और क्रॉप की गई छवि लौटाता है
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    //  परिणाम को सहेजता है
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

`[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/)` मेथड क्रॉप की गई छवि को प्रस्तुति की छवि संग्रह में जोड़ता है। यदि छवि केवल प्रोसेस किए गए `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/)` में उपयोग हुई है, तो यह सेटअप प्रस्तुति का आकार घटा सकता है। अन्यथा, परिणामी प्रस्तुति में छवियों की संख्या बढ़ेगी।

यह मेथड क्रॉपिंग संचालन में WMF/EMF मेटाफाइल को रास्टर PNG छवि में बदल देता है।  

{{% /alert %}}

## **छवियों को संपीड़ित करें**

आप `[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/)` मेथड का उपयोग करके प्रस्तुति में चित्र को संपीड़ित कर सकते हैं। यह मेथड आकार और निर्दिष्ट रिज़ॉल्यूशन के आधार पर छवि को छोटा करता है, और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को भी हटाता है।

यह PowerPoint के **Picture Format → Compress Pictures → Resolution** विकल्प के समान ही आकार और रिज़ॉल्यूशन को समायोजित करता है।

निम्न C# उदाहरण दिखाते हैं कि कैसे लक्षित रिज़ॉल्यूशन निर्धारित करके और वैकल्पिक रूप से क्रॉप किए गए क्षेत्रों को हटाकर प्रस्तुति में छवि को संपीड़ित किया जा सकता है:

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // इमेज को 150 DPI (वेब रिज़ॉल्यूशन) के लक्ष्य रिज़ॉल्यूशन के साथ संपीड़ित करता है और क्रॉप किए गए क्षेत्रों को हटाता है।
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
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // छवि को 150 DPI (वेब रिज़ॉल्यूशन) तक संपीड़ित करता है, क्रॉप किए गए क्षेत्रों को हटाते हुए।
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह मेथड आकार और प्रदान किए गए DPI के आधार पर छवि को कम रिज़ॉल्यूशन में बदलता है। क्रॉप किए गए क्षेत्रों को हटाकर फ़ाइल आकार को अनुकूलित भी किया जा सकता है। यदि छवि एक मेटाफाइल (WMF/EMF) या SVG है, तो संपीड़न लागू नहीं किया जाएगा। JPEG की गुणवत्ता रिज़ॉल्यूशन के अनुसार समान रूप से बनी रहती है या थोड़ा घटती है, जैसा कि PowerPoint उच्च‑रिज़ॉल्यूशन JPEG को संभालता है।  

{{% /alert %}}

## **आस्पेक्ट रेशियो को लॉक करें**

यदि आप चाहते हैं कि छवि रखने वाला आकार छवि के आयाम बदलने के बाद भी अपना अस्पेक्ट रेशियो बना रहे, तो आप `[IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/aspectratiolocked/)` गुण का उपयोग करके *Lock Aspect Ratio* सेटिंग निर्धारित कर सकते हैं।

यह C# कोड दिखाता है कि कैसे आकार के अस्पेक्ट रेशियो को लॉक किया जाए:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // आकार को रिसाइज़ करने पर अस्पेक्ट अनुपात बनाए रखने के लिए सेट करता है
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ध्यान दें" color="warning" %}} 

यह *Lock Aspect Ratio* सेटिंग केवल आकार के अस्पेक्ट रेशियो को संरक्षित करती है, न कि उसकी अंतर्निहित छवि को।  

{{% /alert %}}

## **StretchOff प्रॉपर्टी का उपयोग करें**

`[StretchOffsetLeft](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetleft)`, `[StretchOffsetTop](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsettop)`, `[StretchOffsetRight](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetright)`, और `[StretchOffsetBottom](https://reference.aspose.com/slides/hi/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom)` प्रॉपर्टी का उपयोग करके, आप एक भराव आयत निर्दिष्ट कर सकते हैं।

जब छवि के लिए स्ट्रेचिंग निर्धारित की जाती है, तो स्रोत आयत निर्दिष्ट भराव आयत में फिट होने के लिए स्केल की जाती है। भराव आयत का प्रत्येक किनारा आकार के बाउंडिंग बॉक्स के संबंधित किनारे से प्रतिशत ऑफ़सेट द्वारा परिभाषित होता है। सकारात्मक प्रतिशत एक इन्सेट दर्शाता है जबकि नकारात्मक प्रतिशत एक आउटसेट दर्शाता है।

1. `[Presentation](http://www.aspose.com/api/net/slides/hi/aspose.slides/)` वर्ग का एक उदाहरण बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक आयत `AutoShape` जोड़ें।  
4. एक छवि बनाएं।  
5. आकार का फ़िल टाइप सेट करें।  
6. आकार का चित्र फ़िल मोड सेट करें।  
7. आकार को भरने के लिए एक सेट छवि जोड़ें।  
8. आकार के बाउंडिंग बॉक्स के संबंधित किनारे से छवि ऑफ़सेट निर्दिष्ट करें।  
9. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।  

यह C# कोड दिखाता है कि कैसे StretchOff प्रॉपर्टी का उपयोग किया जाता है:

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // आकार बॉडी में छवि को प्रत्येक तरफ से स्ट्रेच करने के लिए सेट करता है
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता लगा सकता हूं कि PictureFrame के लिए कौन‑से छवि फ़ॉर्मेट समर्थित हैं?**

Aspose.Slides रास्टर छवियों (PNG, JPEG, BMP, GIF आदि) और वेक्टर छवियों (जैसे SVG) दोनों का समर्थन करता है, जो एक `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/)` को सौंपे गए छवि ऑब्जेक्ट के माध्यम से प्रदान की जाती हैं। समर्थित फ़ॉर्मेट की सूची आम तौर पर स्लाइड और छवि रूपांतरण इंजन की क्षमताओं के साथ ओवरलैप करती है।

**सैकड़ों बड़ी छवियों को जोड़ने से PPTX आकार और प्रदर्शन पर क्या प्रभाव पड़ेगा?**

बड़ी छवियों को एम्बेड करने से फ़ाइल आकार और मेमोरी उपयोग बढ़ता है; छवियों को लिंक करने से प्रस्तुति का आकार कम रहता है, लेकिन बाहरी फ़ाइलों को सुलभ रखना आवश्यक है। Aspose.Slides लिंक के माध्यम से छवियों को जोड़ने की सुविधा प्रदान करता है जिससे फ़ाइल आकार घटाया जा सके।

**मैं एक छवि ऑब्जेक्ट को आकस्मिक गति/आकार बदलने से कैसे रोक सकता हूँ?**

`[shape locks](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/pictureframelock/)` का उपयोग करके एक `[PictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/pictureframe/)` को लॉक किया जा सकता है (उदाहरण के लिए, गति या आकार बदलना अक्षम किया जाए)। लॉकिंग तंत्र को आकारों के लिए अलग-अलग [protection article](/slides/hi/net/applying-protection-to-presentation/) में बताया गया है और यह विभिन्न आकार प्रकारों, जिसमें `[PictureFrame]` शामिल है, के लिए समर्थित है।

**क्या SVG वेक्टर फ़िडेलिटी PDFs/छवियों में निर्यात करते समय संरक्षित रहती है?**

Aspose.Slides आपको एक `[PictureFrame]` से मूल वेक्टर के रूप में SVG निकालने की अनुमति देता है। जब आप प्रस्तुति को PDF (/slides/hi/net/convert-powerpoint-to-pdf/) या रास्टर फ़ॉर्मेट (/slides/hi/net/convert-powerpoint-to-png/) में निर्यात करते हैं, तो परिणाम निर्यात सेटिंग्स के आधार पर रास्टराइज्ड हो सकता है; मूल SVG को वेक्टर के रूप में संरक्षित रखने की पुष्टि निकलते समय व्यवहार से होती है।