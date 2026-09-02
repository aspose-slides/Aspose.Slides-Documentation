---
title: .NET में प्रस्तुतियों में Picture Frames प्रबंधित करें
linktitle: चित्र फ्रेम
type: docs
weight: 10
url: /hi/net/picture-frame/
keywords:
- चित्र फ्रेम
- चित्र फ्रेम जोड़ें
- चित्र फ्रेम बनाएँ
- एम्बेडेड इमेज
- लिंक्ड इमेज
- इमेज निकालें
- रेस्टर इमेज
- SVG इमेज
- इमेज क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएँ
- इमेज संपीड़ित करें
- StretchOffset
- चित्र फ्रेम फ़ॉर्मेटिंग
- सापेक्ष स्केल
- इमेज इफ़ेक्ट
- अस्पेक्ट रेशियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides के साथ प्रस्तुतियों में चित्र फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और संपीड़ित करें।"
---
## **परिचय**

एक picture frame एक slide shape है जो एक image दिखाता है। Aspose.Slides में, image resource और उसे दिखाने वाला shape अलग-अलग objects हैं: एक [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) अपनी [Images](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/images/) collection के माध्यम से एम्बेडेड image resources का स्वामित्व रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) image की position, size, line formatting, rotation, cropping, picture effects, और अन्य frame‑level settings को नियंत्रित करता है।

यह विभाजन तब उपयोगी होता है जब एक ही image को एक से अधिक बार दिखाया जाता है। image को प्रस्तुति में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को रखें, और picture frames बनाते समय उसी image resource का उपयोग करें।

Picture frames PNG या JPEG जैसे raster images और SVG जैसे vector images को रख सकते हैं। वे presentation में image bytes को संग्रहीत करने के बजाय linked images का भी संदर्भ ले सकते हैं। यह चयन portability, file size, extraction, और export behavior को प्रभावित करता है, इसलिए formatting या optimization लागू करने से पहले यह तय करना उपयोगी है कि image को कैसे संग्रहीत किया जाए।

## **एक एम्बेडेड छवि जोड़ें और स्वरूपित करें**

एक एम्बेडेड image के लिए, image डेटा को प्रस्तुति में जोड़ें और [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) के साथ एक picture frame बनाएं। image प्रस्तुति पैकेज का हिस्सा बन जाता है, इसलिए प्रस्तुति को दूसरी कंप्यूटर पर ले जाने पर भी वह self‑contained रहता है।

निम्न उदाहरण JPEG image जोड़ता है, image के मूल dimensions पर एक फ्रेम बनाता है, और line formatting तथा rotation लागू करता है:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

picture frame प्रदर्शित geometry को नियंत्रित करता है; फ्रेम आकार बदलने से एम्बेडेड image resource में संग्रहीत मूल pixel dimensions नहीं बदलते। यह अंतर बाद में image को crop या compress करने पर महत्वपूर्ण हो जाता है।

## **सापेक्ष स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) फ्रेम के लिए relative width और height scaling प्रदान करता है। `1.0` का मान मूल picture size के 100 % के बराबर है। Relative scale तब उपयोगी होता है जब workflow को source image size के साथ अनुपात बनाए रखना पड़ता है, न कि अंतिम dimensions को मैन्युअली गणना करना।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Relative scale फ्रेम की scale settings बदलता है; यह एम्बेडेड image को resample या compress नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज**

एक एम्बेडेड picture image डेटा को प्रस्तुति के अंदर संग्रहीत करता है और इस कारण portability और predictable rendering के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड picture [ISlidesPicture](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/) लिंक पथ के माध्यम से बाहरी स्थान को संदर्भित करता है, न कि image डेटा को उसी तरह embed करता है।

लिंक्ड इमेजेज PPTX में संग्रहीत image डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस application के लिए उपलब्ध रहना चाहिए जो प्रस्तुति को खोलता या render करता है। यदि path बदलता है, फ़ाइल मूव हो जाती है, या resource अनुपलब्ध हो जाता है, तो लिंक्ड picture अपेक्षित रूप से नहीं दिखेगा। उन प्रस्तुतियों के लिए जिन्हें ईमेल, आर्काइव, या isolated environments में render करना है, एम्बेडेड इमेजेज आमतौर पर अधिक भरोसेमंद होते हैं।

### **एक लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक picture frame बनाता है और उसे एक स्थानीय image फ़ाइल की ओर पॉइंट करता है। यह केवल image linking को ही दर्शाता है; video linking एक अलग media workflow है और जानबूझकर इस उदाहरण में सम्मिलित नहीं किया गया है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

बाहरी फ़ाइल प्रबंधन इरादतन होने पर लिंक का उपयोग करें। उन्हें केवल compression के विकल्प के रूप में प्रयोग न करें: एक छोटा PPTX जिसमें टूटे हुए image dependencies हों, आमतौर पर एक बड़े self‑contained प्रस्तुति से कम उपयोगी होता है।

## **Picture Frames से इमेजेज निकालें**

किसी मौजूदा प्रस्तुति से image निकालने से पहले, यह जांचें कि shape वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) है और उसमें एम्बेडेड image मौजूद है। लिंक्ड picture frames में वह image bytes नहीं हो सकते जिन्हें उसी तरह निकाल सकें।

### **एक Raster Image निकालें**

आधुनिक image API सीधे [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) का उपयोग करता है और पुराने system‑image wrapper की आवश्यकता नहीं होती। निम्न उदाहरण पहले एम्बेडेड raster picture को slide पर खोजता है और उसे PNG के रूप में सहेजता है:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

[IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के माध्यम से सहेजना extracted image को अनुरोधित output format में बदल देता है। यदि आपको presentation में संग्रहीत encoded bytes चाहिए, न कि रूपांतरित raster फ़ाइल, तो image resource के binary डेटा का उपयोग करें।

### **एक SVG Image निकालें**

एक SVG picture के लिए, [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) object उजागर करता है। यह आपको SVG डेटा को सीधे प्राप्त करने देता है, बिना पहले picture को rasterize किए।

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

SVG को SVG के रूप में रखना presentation के भीतर vector source को संरक्षित करता है। PNG या JPEG जैसे raster export को वह vector content को pixels में render करना पड़ता है। PDF या SVG slide export भी एक rendering प्रक्रिया है, इसलिए एक्सपोर्ट किए गए graphics को मूल एम्बेडेड SVG की बाइट‑फॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल vector resource की आवश्यकता हो तो एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) डेटा का उपयोग करें।

## **एक Image को Crop करें**

Cropping फ्रेम के अंदर image के कौन से भाग दिखेंगे, इसे बदलता है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) पर crop values source image dimensions के प्रतिशत होते हैं। Cropping प्रारम्भ में एम्बेडेड image से छिपे हुए pixels को हटाता नहीं है; यह केवल दृश्य क्षेत्र को बदलता है।

निम्न उदाहरण एक picture frame को सुरक्षित रूप से ढूँढता है और crop values लागू करता है:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

क्योंकि छिपा हुआ image डेटा अभी भी मौजूद है, crop को बाद में मूल pixels खोए बिना बदला जा सकता है। यदि फाइल आकार अधिक महत्वपूर्ण है और reversibility की आवश्यकता नहीं है, तो अगले खंड में वर्णित अनुसार cropped regions को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप्ड Image डेटा हटाएँ**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) वर्तमान crop rectangle के बाहर की image डेटा को हटाता है और resultant image resource लौटाता है। यह फाइल आकार को कम कर सकता है, लेकिन यह एक destructive optimization है: प्रस्तुति सेव होने के बाद हटाए गए pixels बाद में uncrop ऑपरेशन के लिए उपलब्ध नहीं रहते।

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

इस method से प्रस्तुति में एक नया image resource जुड़ सकता है। यदि मूल image को अन्य picture frames भी उपयोग कर रहे हैं, तो उन frames को अभी भी अपने मौजूदा resource की आवश्यकता होगी, इसलिए cropped areas को हटाना जरूरी नहीं कि कुल image संख्या को घटाए। WMF या EMF content को इस method से crop करने पर परिणाम PNG में rasterize हो जाता है।

## **Raster Image को Compress करें**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/) raster image resolution को उस size के सापेक्ष घटाता है जिस पर picture प्रदर्शित होती है। यह उसी ऑपरेशन में cropped regions को भी हटा सकता है। यह method तब `true` लौटाता है जब image को resized या cropped किया गया हो और `false` जब कोई बदलाव आवश्यक न हो।

एक मानक target resolution पर्याप्त होने पर पूर्वपरिभाषित [PicturesCompression](https://reference.aspose.com/slides/hi/net/aspose.slides.export/picturescompression/) मान का उपयोग करें:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

यदि कोई विशिष्ट target चाहिए तो enum मान के बजाय एक कस्टम सकारात्मक DPI मान पास किया जा सकता है।

Compression raster image के लिए अभिप्रेत है। SVG और metafile सामग्री इस raster compression workflow द्वारा नहीं घटती। यह भी याद रखें कि कम resolution और हटाए गए cropped regions को अनुकूलित प्रस्तुति से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य resolution को उस अधिकतम size के आधार पर चुनें जिस पर image वास्तव में देखी या एक्सपोर्ट की जाएगी, न कि वैश्विक रूप से सबसे कम DPI लागू करके।

## **Image Effects की निरीक्षण करें**

Picture effects frame द्वारा उपयोग किए गए picture पर संग्रहीत होते हैं। image transform collection में transparency के लिए fixed alpha modulation और brightness‑contrast के लिए luminance जैसे प्रभाव हो सकते हैं। नीचे दिया गया उदाहरण पहले picture frame से दोनों प्रकार के प्रभावों को सुरक्षित रूप से पढ़ता है:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

ये प्रभाव frame में image के render होने के तरीके को बदलते हैं; वे मूल एम्बेडेड image bytes को पुनः लिखते नहीं हैं।

## **Picture Frame Geometry को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि picture frame के कौन से editing operations अक्षम हों। उदाहरण के लिये, aspect‑ratio lock आकार बदलते समय shape के अनुपात को बरकरार रखता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

लॉक picture frame shape पर लागू होता है। यह source image को resample या स्थायी रूप से समान aspect ratio में बदलता नहीं है।

## **StretchOffset मानों को समायोजित करें**

जब picture fill mode stretch हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) पर stretch‑offset मान picture frame की bounding box के सापेक्ष fill rectangle को परिभाषित करते हैं। सकारात्मक प्रतिशत किनारे से एक inset बनाते हैं, जबकि नकारात्मक प्रतिशत एक outset बनाते हैं।

यह cropping से अलग है। Crop values यह चुनते हैं कि source image का कौन सा भाग दिखे; stretch offsets वह rectangle बदलते हैं जिसमें दृश्य picture fill को stretch किया जाता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

fill placement के लिए stretch offsets का उपयोग करें। जब लक्ष्य source‑image किनारों को छिपाना हो तो crop properties का उपयोग करें।

## **स्टोरेज, फाइल साइज, और एक्सपोर्ट विचार**

जब image स्टोरेज और picture‑frame formatting को अलग‑अलग माना जाता है तो मुख्य trade‑offs को प्रबंधित करना सरल हो जाता है:

- **Embedded images** प्रस्तुति को self‑contained बनाते हैं और शेयरिंग तथा server‑side rendering के लिये सबसे भरोसेमंद होते हैं, लेकिन बड़े raster images PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रस्तुति को बाहरी फ़ाइलों की उपलब्धता पर निर्भर बनाते हैं।
- **Cropping** प्रारम्भ में non‑destructive होता है। छिपे हुए pixels तब तक एम्बेडेड रहते हैं जब तक cropped areas को स्पष्ट रूप से delete या compression के दौरान हटाया न जाए।
- **Compression** अत्यधिक बड़े raster images के फाइल आकार को काफी घटा सकता है, लेकिन यह source resolution की कीमत पर होता है। इसे स्लाइड पर वास्तविक आकार ज्ञात होने के बाद लागू करना चाहिए।
- **SVG images** को तब तक SVG के रूप में रखें जब तक vector preservation महत्वपूर्ण न हो। जब आपको स्वयं vector resource चाहिए तो एम्बेडेड SVG को सीधे निकालें। Raster slide exports हमेशा rendered slide को pixels में बदलते हैं।
- **Repeated images** को संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) resource को पुनः उपयोग करें, बजाय प्रत्येक बार वही फ़ाइल प्रस्तुति workflow में लोड करने के।

बड़े presentations के लिये, image optimization सामान्यतया तब सबसे प्रभावी होती है जब चयनित रूप से किया जाए: logos और diagrams को vector सामग्री के रूप में रखें, photographs को उनके वास्तविक display size के अनुसार compress करें, cropped pixels को केवल तब हटाएँ जब बाद में editing आवश्यक न हो, और बाहरी लिंक को तब तक न अपनाएँ जब तक dependency management deployment design का हिस्सा न हो।

## **FAQ**

**एक picture frame और एक image resource में क्या अंतर है?**

एक [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) प्रस्तुति से जुड़ा image resource दर्शाता है। एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) slide पर वह shape है जो image दिखाता है और फ्रेम‑level geometry तथा formatting जैसे size, rotation, crop values, effects, और locks को संग्रहीत करता है।

**मुझे image को embed करना चाहिए या link करना चाहिए?**

जब प्रस्तुति को portable, archived, या बाहरी resources के बिना render करना आवश्यक हो तो image को embed करें। बाहरी फ़ाइलों को बाहर रखने का इरादा हो और वह स्थान विश्वसनीय रूप से बनाए रखे जा सकें तभी image को link करें।

**क्या cropping PPTX फाइल साइज को कम करता है?**

स्वयं नहीं। सामान्य crop सेटिंग्स source image के भाग को छुपाती हैं लेकिन अंतर्निहित pixels को रखती हैं। जब उन pixels को स्थायी रूप से हटाया जा सकता हो तो [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) या crop‑area removal के साथ image compression का उपयोग करें।

**क्या मैं compression के बाद image की गुणवत्ता पुनः प्राप्त कर सकता हूँ?**

नहीं। Compression संग्रहीत raster resolution को घटा देता है, और cropped regions को हटाने से image डेटा हट जाता है। यदि बाद में उच्च‑resolution editing की सम्भावना हो तो मूल source image को प्रस्तुति के बाहर रखें।

**SVG images को कैसे संभालना चाहिए?**

जब vector fidelity मायने रखती है तो SVG सामग्री को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) को सीधे निकाल सकते हैं। स्लाइड को PNG या JPEG जैसे raster format में render करने से SVG को pixels में बदल दिया जाता है।

**मैं existing slides पढ़ते समय unsafe casts से कैसे बचूँ?**

shape type को उपयोग करने से पहले जांचें। [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) के साथ pattern matching या shape collection को उस interface द्वारा फ़िल्टर करने से invalid casts से बचा जा सकता है और कोड उन slides को संभाल सकता है जिनमें picture frames नहीं होते।