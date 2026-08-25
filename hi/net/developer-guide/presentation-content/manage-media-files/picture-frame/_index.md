---
title: प्रेजेंटेशन में .NET के साथ पिक्चर फ्रेम का प्रबंधन
linktitle: पिक्चर फ्रेम
type: docs
weight: 10
url: /hi/net/picture-frame/
keywords:
- पिक्चर फ्रेम
- पिक्चर फ्रेम जोड़ें
- पिक्चर फ्रेम बनाएं
- एम्बेडेड इमेज
- लिंक्ड इमेज
- इमेज निकालें
- रास्टर इमेज
- SVG इमेज
- इमेज क्रॉप करें
- क्रॉप्ड क्षेत्रों को हटाएँ
- इमेज कॉम्प्रेस करें
- StretchOffset
- पिक्चर फ्रेम फ़ॉर्मेटिंग
- रिलेटिव स्केल
- इमेज इफ़ेक्ट
- एस्पेक्ट रैशियो
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रेजेंटेशन में पिक्चर फ्रेम बनाएं, फ़ॉर्मेट करें, लिंक करें, क्रॉप करें, निकालें और कॉम्प्रेस करें।"
---
## **परिचय**

Picture frame एक स्लाइड शेप है जो इमेज दिखाता है। Aspose.Slides में, इमेज रिसोर्स और उसे दिखाने वाला शेप अलग-अलग ऑब्जेक्ट हैं: एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) अपने [Images](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/images/) कलेक्शन के माध्यम से एम्बेडेड इमेज रिसोर्सेज़ को रखता है, जबकि एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) इमेज की पोज़िशन, साइज, लाइन फ़ॉर्मेटिंग, रोटेशन, क्रॉपिंग, पिक्चर इफ़ेक्ट्स और अन्य फ्रेम‑लेवल सेटिंग्स को नियंत्रित करता है।

यह अलगाव तब उपयोगी होता है जब एक ही इमेज को एक से अधिक बार दिखाया जाता है। इमेज को प्रेजेंटेशन में एक बार जोड़ें, लौटाए गए [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) को रखें, और पिक्चर फ्रेम बनाते समय उसी इमेज रिसोर्स का उपयोग करें।

Picture frames में PNG या JPEG जैसे रास्टर इमेज और SVG जैसे वेक्टर इमेज दोनों हो सकते हैं। वे इमेज डेटा को प्रेजेंटेशन में स्टोर करने के बजाय लिंक्ड इमेज को भी संदर्भित कर सकते हैं। यह चयन पोर्टेबिलिटी, फ़ाइल आकार, एक्सट्रैक्शन और एक्सपोर्ट व्यवहार को प्रभावित करता है, इसलिए फ़ॉर्मेटिंग या ऑप्टिमाइज़ेशन लागू करने से पहले यह तय करना उपयोगी है कि इमेज कैसे संग्रहीत होनी चाहिए।

## **एम्बेडेड इमेज जोड़ें और फ़ॉर्मेट करें**

एंबेडेड इमेज के लिए, इमेज डेटा को प्रेजेंटेशन में जोड़ें और [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) के साथ एक पिक्चर फ्रेम बनाएं। इमेज प्रेजेंटेशन पैकेज का हिस्सा बन जाता है, इसलिए प्रेजेंटेशन को दूसरी कंप्यूटर पर ले जाने पर भी वह स्वयं‑समावेशी रहता है।

निम्न उदाहरण एक JPEG इमेज जोड़ता है, इमेज के मूल आकार पर एक फ्रेम बनाता है, और लाइन फ़ॉर्मेटिंग और रोटेशन लागू करता है:

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

पिक्चर फ्रेम प्रदर्शित जियोमेट्री को नियंत्रित करता है; फ्रेम का आकार बदलने से एम्बेडेड इमेज रिसोर्स में संग्रहीत मूल पिक्सेल आयाम नहीं बदलते। यह अंतर बाद में इमेज को क्रॉप या कॉम्प्रेस करते समय महत्वपूर्ण हो जाता है।

## **रिलेटिव स्केल का उपयोग करें**

[IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) फ्रेम के लिए रिलेटिव चौड़ाई और ऊँचाई स्केलिंग को उजागर करता है। `1.0` का मान मूल चित्र आकार के 100 % के अनुरूप है। रिलेटिव स्केल तब उपयोगी होता है जब वर्कफ़्लो को स्रोत इमेज आकार के साथ एक संबंध बनाए रखना हो, न कि मैन्युअल रूप से अंतिम आयाम की गणना करना।

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

रिलेटिव स्केल फ्रेम की स्केल सेटिंग्स को बदलता है; यह एम्बेडेड इमेज को री‑सैंपल या कॉम्प्रेस नहीं करता।

## **एम्बेडेड और लिंक्ड इमेजेज**

एक एम्बेडेड पिक्चर इमेज डेटा को प्रेजेंटेशन के अंदर स्टोर करता है और इसलिए पोर्टेबिलिटी और पूर्वानुमेय रेंडरिंग के लिए सबसे सुरक्षित विकल्प है। एक लिंक्ड पिक्चर [ISlidesPicture](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/) लिंक पाथ के माध्यम से बाहरी लोकेशन को स्टोर करता है, न कि इमेज डेटा को उसी तरह एम्बेड करता है।

लिंक्ड इमेज PPTX में संग्रहीत इमेज डेटा की मात्रा को कम कर सकते हैं, लेकिन वे एक बाहरी निर्भरता पेश करते हैं। लिंक्ड फ़ाइल को उस एप्लिकेशन के लिए सुलभ रहना चाहिए जो प्रेजेंटेशन को खोलता या रेंडर करता है। यदि पाथ बदलता है, फ़ाइल स्थानांतरित होती है, या रिसोर्स उपलब्ध नहीं रहता, तो लिंक्ड पिक्चर अपेक्षित रूप से प्रदर्शित नहीं हो सकता। उन प्रेजेंटेशनों के लिए जो ई‑मेल, आर्काइव या अलग‑थलग वातावरण में रेंडर किए जाने चाहिए, एम्बेडेड इमेज आमतौर पर अधिक विश्वसनीय होते हैं।

### **लिंक्ड इमेज जोड़ें**

निम्न उदाहरण एक पिक्चर फ्रेम बनाता है और उसे स्थानीय इमेज फ़ाइल की ओर इंगित करता है। यह केवल इमेज लिंकिंग को संभालता है; वीडियो लिंकिंग एक अलग मीडिया वर्कफ़्लो है और इरादतन इस उदाहरण में मिश्रित नहीं है।

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

जब बाहरी फ़ाइल प्रबंधन इरादतन हो तो लिंक का उपयोग करें। उन्हें केवल कॉम्प्रेशन के विकल्प के रूप में उपयोग न करें: टूटे हुए इमेज डिपेंडेंसी वाले छोटे PPTX अक्सर बड़े स्वयं‑समावेशी प्रेजेंटेशन की तुलना में कम उपयोगी होते हैं।

## **पिक्चर फ्रेम से इमेज एक्सट्रैक्ट करें**

किसी मौजूदा प्रेजेंटेशन से इमेज एक्सट्रैक्ट करने से पहले, यह जांचें कि आकार वास्तव में एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) है और उसमें एम्बेडेड इमेज है। लिंक्ड पिक्चर फ्रेम में संभवतः इमेज बाइट्स नहीं होते जो समान तरीके से एक्सट्रैक्ट किए जा सकें।

### **रास्टर इमेज एक्सट्रैक्ट करें**

आधुनिक इमेज API सीधे [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) का उपयोग करती है और पुराने सिस्टम‑इमेज रैपर की आवश्यकता नहीं होती। निम्न उदाहरण पहले स्लाइड पर पहली एम्बेडेड रास्टर पिक्चर खोजता है और उसे PNG के रूप में सेव करता है:

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

[IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) के माध्यम से सेव करने से एक्सट्रैक्टेड इमेज को अनुरोधित आउटपुट फ़ॉर्मेट में बदल दिया जाता है। यदि आपको प्रेजेंटेशन में संग्रहीत एन्कोडेड बाइट्स चाहिए बनाम एक परिवर्तित रास्टर फ़ाइल, तो इमेज रिसोर्स का बाइनरी डेटा उपयोग करें।

### **SVG इमेज एक्सट्रैक्ट करें**

SVG पिक्चर के लिए, [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) एक [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) ऑब्जेक्ट उजागर करता है। इससे आप SVG डेटा को सीधे प्राप्त कर सकते हैं, बिना पहले पिक्चर को रास्टराइज़ किए।

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

SVG सामग्री को SVG के रूप में रखने से वेक्टर स्रोत प्रेजेंटेशन के भीतर बना रहता है। PNG या JPEG जैसे रास्टर एग्ज़ोर्ट आवश्यक रूप से उस वेक्टर सामग्री को पिक्सेल में रेंडर करते हैं। PDF या SVG स्लाइड एक्सपोर्ट भी एक रेंडरिंग ऑपरेशन है, इसलिए एक्सपोर्टेड ग्राफ़िक्स को मूल एम्बेडेड SVG की बाइट‑फ़ॉर‑बाइट कॉपी नहीं माना जाना चाहिए; जब मूल वेक्टर रिसोर्स स्वयं आवश्यक हो तो एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) डेटा का उपयोग करें।

## **इमेज को क्रॉप करें**

क्रॉपिंग फ्रेम के भीतर इमेज के कौन से हिस्से दिखेंगे, इसे बदलता है। [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) पर क्रॉप वैल्यूज़ स्रोत इमेज आयामों का प्रतिशत होते हैं। क्रॉपिंग प्रारंभ में एम्बेडेड इमेज से छिपे पिक्सेल को हटाती नहीं है; यह केवल दृश्यमान क्षेत्र को बदलती है।

निम्न उदाहरण सुरक्षित रूप से एक पिक्चर फ्रेम खोजता है और क्रॉप वैल्यूज़ लागू करता है:

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

क्योंकि छिपा हुआ इमेज डेटा अभी भी मौजूद है, क्रॉप को बाद में मूल पिक्सेल खोए बिना बदला जा सकता है। यदि फ़ाइल आकार अधिक महत्वपूर्ण है और पुनर्प्राप्ति की आवश्यकता नहीं है, तो अगले सेक्शन में वर्णित अनुसार क्रॉप्ड क्षेत्रों को शारीरिक रूप से हटाया जा सकता है।

## **क्रॉप्ड इमेज डेटा हटाएं**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) वर्तमान क्रॉप रेक्टैंगल के बाहर के इमेज डेटा को हटाता है और परिणामी इमेज रिसोर्स लौटाता है। यह फ़ाइल आकार कम कर सकता है, लेकिन यह एक विनाशकारी ऑप्टिमाइज़ेशन है: प्रेजेंटेशन सेव होने के बाद हटाए गए पिक्सेल बाद में अनक्रॉप ऑपरेशन के लिए उपलब्ध नहीं रहते।

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

यह मेथड प्रेजेंटेशन में एक नया इमेज रिसोर्स जोड़ सकता है। यदि मूल इमेज अन्य पिक्चर फ्रेम द्वारा भी उपयोग की जा रही है, तो उन फ्रेम को अभी भी अपना मौजूदा रिसोर्स चाहिए रहता है, इसलिए क्रॉप्ड क्षेत्रों को हटाने से कुल इमेज की संख्या अनिवार्य रूप से नहीं घटती। इस मेथड से WMF या EMF सामग्री को क्रॉप करने पर परिणाम PNG में रास्टराइज़ हो जाता है।

## **रास्टर इमेज कॉम्प्रेस करें**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/compressimage/) रास्टर इमेज रिज़ॉल्यूशन को उस आकार के सापेक्ष कम करता है जिस पर चित्र दर्शाया जाता है। यह उसी ऑपरेशन में क्रॉप्ड क्षेत्रों को भी हटा सकता है। मेथड `true` लौटाता है जब इमेज को रीसाइज़ या क्रॉप किया गया हो और `false` जब कोई बदलाव आवश्यक न हो।

जब एक मानक लक्ष्य रिज़ॉल्यूशन पर्याप्त हो तो पूर्वपरिभाषित [PicturesCompression](https://reference.aspose.com/slides/hi/net/aspose.slides.export/picturescompression/) वैल्यू का उपयोग करें:

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

यदि विशिष्ट लक्ष्य आवश्यक हो तो एनीम वैल्यू के बजाय कस्टम पॉज़िटिव DPI मान पास किया जा सकता है।

कॉम्प्रेशन रास्टर इमेज के लिए अभिप्रेत है। SVG और मेटाफाइल सामग्री इस रास्टर कॉम्प्रेशन वर्कफ़्लो से नहीं घटती। यह भी याद रखें कि कम रिज़ॉल्यूशन और हटाए गए क्रॉप्ड क्षेत्रों को ऑप्टिमाइज़्ड प्रेजेंटेशन से पुनः प्राप्त नहीं किया जा सकता। लक्ष्य रिज़ॉल्यूशन को उस अधिकतम आकार के आधार पर चुनें जिस पर इमेज वास्तव में देखी या एक्सपोर्ट की जाएगी, न कि ग्लोबली सबसे कम DPI लागू करके।

## **इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स प्रबंधित करें**

ब्राइटनेस, कॉन्ट्रास्ट, कलर ट्रांसफ़ॉर्मेशन, ब्लर, अल्फा इफ़ेक्ट्स, ऑर्डर्ड चेन, इंस्पेक्शन, रिमूवल और राउंड‑ट्रिप वेरिफिकेशन को कवर करने वाले पूर्ण वर्कफ़्लो के लिए देखें [Image Transform Effects](/slides/hi/net/image-transform-effects/)।

## **पिक्चर फ्रेम जियोमेट्री को लॉक करें**

[IPictureFrameLock](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframelock/) सेटिंग्स यह नियंत्रित करती हैं कि पिक्चर फ्रेम के लिए कौन‑से एडिटिंग ऑपरेशन निष्क्रिय हैं। उदाहरण के लिए, एस्पेक्ट‑रैशियो लॉक आकार बदलते समय शेप के अनुपात को बनाए रखता है।

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

लॉक पिक्चर फ्रेम शेप पर लागू होता है। यह स्रोत इमेज को री‑सैंपल या स्थायी रूप से उसी एस्पेक्ट रैशियो में बदलने के लिए बाध्य नहीं करता।

## **StretchOffset वैल्यू समायोजित करें**

जब पिक्चर फ़िल मोड स्ट्रेच हो, तो [IPictureFillFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/) पर स्ट्रेच‑ऑफ़सेट वैल्यूज़ पिक्चर फ्रेम के बाउंडिंग बॉक्स के सापेक्ष फ़िल रेक्टैंगल को परिभाषित करती हैं। पॉज़िटिव प्रतिशत किनारे से इनसेट बनाते हैं, जबकि नेगेटिव प्रतिशत आउटसेट बनाते हैं।

यह क्रॉपिंग से अलग है। क्रॉप वैल्यूज़ स्रोत इमेज के कौन से भाग दिखेंगे, इसे चुनती हैं; स्ट्रेच ऑफ़सेट दृश्य पिक्चर फ़िल को फैलाने वाले रेक्टैंगल को बदलते हैं।

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

फ़िल प्लेसमेंट के लिए स्ट्रेच ऑफ़सेट का उपयोग करें। जब लक्ष्य स्रोत‑इमेज किनारों को छिपाना हो तो क्रॉप प्रॉपर्टीज़ का उपयोग करें।

## **स्टोरेज, फ़ाइल आकार, और एक्सपोर्ट विचार**

मुख्य ट्रेड‑ऑफ़ तब आसान होते हैं जब इमेज स्टोरेज और पिक्चर‑फ़्रेम फ़ॉर्मेटिंग को अलग‑अलग संभाला जाए:

- **Embedded images** प्रेजेंटेशन को स्वयं‑समावेशी बनाते हैं और शेयरिंग तथा सर्वर‑साइड रेंडरिंग के लिए सबसे विश्वसनीय होते हैं, लेकिन बड़े रास्टर इमेज PPTX आकार और मेमोरी उपयोग को बढ़ाते हैं।
- **Linked images** पैकेज को छोटा रख सकते हैं, लेकिन प्रेजेंटेशन को बाहरी फ़ाइलों के उपलब्ध रहने पर निर्भर होना पड़ता है।
- **Cropping** प्रारम्भ में नॉन‑डिस्ट्रक्टिव है। छिपे पिक्सेल एम्बेडेड रहते हैं जब तक कि क्रॉप्ड एरिया स्पष्ट रूप से डिलीट या कॉम्प्रेशन के दौरान हटाया न जाए।
- **Compression** ओवरसाइज़्ड रास्टर इमेज के फ़ाइल आकार को काफी घटा सकता है, लेकिन यह स्रोत रिज़ॉल्यूशन का त्याग है। इसे स्लाइड पर इच्छित आकार ज्ञात होने के बाद लागू किया जाना चाहिए।
- **SVG images** को वेक्टर संरक्षण आवश्यक होने पर SVG के रूप में ही रखना चाहिए। जब आपको स्वयं वेक्टर रिसोर्स चाहिए तो एम्बेडेड SVG को सीधे एक्सट्रैक्ट करें। रास्टर स्लाइड एक्सपोर्ट हमेशा रेंडर की गई स्लाइड को पिक्सेल में बदल देता है।
- **Repeated images** को संभव हो तो मौजूदा [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) रिसोर्स को पुन: उपयोग करना चाहिए, न कि एक ही फ़ाइल को बार‑बार प्रेजेंटेशन वर्कफ़्लो में लोड करना।

बड़े प्रेजेंटेशन के लिए इमेज ऑप्टिमाइज़ेशन आमतौर पर चयनात्मक रूप से सबसे प्रभावी होता है: लोगो और डायग्राम को वेक्टर कंटेंट के रूप में रखें, फोटोज़ को उनके वास्तविक डिस्प्ले आकार के अनुसार कॉम्प्रेस करें, क्रॉप्ड पिक्सेल केवल तब हटाएँ जब बाद में एडिटिंग आवश्यक न हो, और बाहरी लिंक तभी रखें जब डिपेंडेंसी मैनेजमेंट डिप्लॉयमेंट डिज़ाइन का हिस्सा हो।

## **FAQ**

**पिक्चर फ्रेम और इमेज रिसोर्स में क्या अंतर है?**

[IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) प्रेजेंटेशन से जुड़ा इमेज रिसोर्स दर्शाता है। [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) एक स्लाइड पर वह शेप है जो इमेज दिखाता है और फ़्रेम‑लेवल जियोमेट्री एवं फ़ॉर्मेटिंग जैसे साइज, रोटेशन, क्रॉप वैल्यूज़, इफ़ेक्ट्स और लॉक संग्रहीत करता है।

**मुझे इमेज एम्बेड करनी चाहिए या लिंक?**

जब प्रेजेंटेशन को पोर्टेबल, आर्काइव या बाहरी रिसोर्स के बिना रेंडर करने की आवश्यकता हो तो इमेज एम्बेड करें। लिंक केवल तभी उपयोग करें जब इमेज फ़ाइलों को PPTX के बाहर रखने का इरादा हो और बाहरी लोकेशन को विश्वसनीय रूप से बनाए रखा जा सके।

**क्या क्रॉपिंग से PPTX फ़ाइल आकार घटता है?**

स्वयं नहीं। सामान्य क्रॉप सेटिंग्स स्रोत इमेज के हिस्सों को छुपाती हैं लेकिन अंतर्निहित पिक्सेल को रखती हैं। फ़ाइल आकार घटाने के लिए [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/hi/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) या क्रॉप्ड‑एरिया हटाने के साथ इमेज कॉम्प्रेशन का उपयोग करें।

**क्या मैं कॉम्प्रेशन के बाद इमेज क्वालिटी को पुनः प्राप्त कर सकता हूँ?**

नहीं। कॉम्प्रेशन संग्रहीत रास्टर रिज़ॉल्यूशन को घटा सकता है, और क्रॉप्ड क्षेत्रों को हटाने से इमेज डेटा स्थायी रूप से ख़तम हो जाता है। यदि बाद में हाई‑रिज़ॉल्यूशन एडिटिंग की संभावना हो तो मूल स्रोत इमेज को प्रेजेंटेशन के बाहर रखें।

**SVG इमेज को कैसे हैंडल करना चाहिए?**

जब वेक्टर फ़िडेलिटी महत्वपूर्ण हो तो SVG को SVG के रूप में रखें। एम्बेडेड [ISvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/) को सीधे एक्सट्रैक्ट किया जा सकता है। स्लाइड को PNG या JPEG जैसे रास्टर फ़ॉर्मेट में एक्सपोर्ट करने से SVG को पिक्सेल में रेंडर किया जाता है।

**मौजूदा स्लाइड पढ़ते समय अनसेफ़ कास्ट से कैसे बचें?**

शेप टाइप को उपयोग करने से पहले जांचें कि वह एक [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) है या नहीं। पैटर्न मैचिंग या इंटरफ़ेस द्वारा shape कलेक्शन को फ़िल्टर करने से इनवैलिड कास्ट से बचा जा सकता है और कोड उन स्लाइडों को भी संभाल सकता है जिनमें पिक्चर फ्रेम नहीं हैं।