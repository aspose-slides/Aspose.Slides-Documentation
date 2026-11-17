---
title: .NET के साथ प्रस्तुतियों में छवि रूपांतरण प्रभाव प्रबंधित करें
linktitle: छवि रूपांतरण प्रभाव
type: docs
weight: 11
url: /hi/net/image-transform-effects/
keywords:
- छवि रूपांतरण
- चित्र प्रभाव
- चमक
- कॉन्ट्रास्ट
- ग्रेस्केल
- डुओटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- पारदर्शिता
- अल्फा प्रभाव
- प्रभाव श्रृंखला
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ चित्र फ्रेम के लिए छवि रूपांतरण प्रभाव लागू करें, श्रृंखलाबद्ध करें, निरीक्षण करें, हटाएँ, और सत्यापित करें।"
---
## **अवलोकन**

Aspose.Slides चित्र समायोजनों को छवि रूपांतरण संचालन के क्रमबद्ध संग्रह के रूप में प्रस्तुत करता है। एक चित्र फ्रेम के लिए, फ्रेम के [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) आपको मूल छवि बाइट्स को दोबारा लिखे बिना प्रभावों को जोड़ने, गिनने, निरीक्षण करने, हटाने और साफ़ करने की अनुमति देता है।

यह लेख चमक और कंट्रास्ट, रंग रूपांतरण, ब्लर, पारदर्शिता, क्रमबद्ध प्रभाव श्रृंखला, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह प्रदर्शित करता है।

## **इफ़ेक्ट स्वामित्व और छवि पुन: उपयोग को समझें**

एक छवि संसाधन और वह चित्र जो इसे प्रदर्शित करता है अलग‑अलग वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व वाली मूल छवि डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) एक चित्र फ़िल भरता है और एक छवि संसाधन को संदर्भित करता है जबकि छवि रूपांतरण संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) वह स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स और अन्य फ्रेम‑स्तरीय फ़ॉर्मेटिंग को धारण करता है।

इसलिए, छवि रूपांतरण संचालन [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) में बाइट्स को संशोधित नहीं करते। जब वही `IPPImage` को [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) को एक से अधिक बार पास किया जाता है, तो प्रत्येक नया चित्र फ्रेम अपना स्वयं का `ISlidesPicture` और अपनी स्वयं की रूपांतरण संग्रह प्राप्त करता है। एक फ्रेम पर ग्रेस्केल लागू करना अन्य फ्रेमों को ग्रेस्केल नहीं बनाता, भले ही सभी समान एम्बेडेड छवि संसाधन का पुनः उपयोग करें।

एक ही `ISlidesPicture.ImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण चित्र फ्रेम पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयाँ उपयोग करें**

प्रदर्शित विधियों में निम्नलिखित अर्थपूर्ण रेंज और इकाइयाँ उपयोग होती हैं। इन रेंजों में मान रखें भले ही किसी विशेष लाइब्रेरी संस्करण द्वारा आउट‑ऑफ़‑रेंज मान तुरंत अस्वीकार न किए जाएँ; लक्ष्य प्रस्तुति स्वरूप सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, छोड़ या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित छोड़ता है। |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | कोई नहीं | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | गहरे और हल्के पिक्सेल के लिए दो रंग। `System.Drawing.Color` में RGB और अल्फा चैनल `0` से `255` तक होते हैं। |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue `0` (समावेशी) से `360` (बहिष्करण) तक, डिग्री में; amount `-100` से `100` तक, प्रतिशत। |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue `0` से `360` तक, डिग्री में; saturation और luminance `-100` से `100` तक, प्रतिशत। |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | प्रतिस्थापन रंग चैनल मान `0` से `255` तक। मौजूदा अल्फा मान अपरिवर्तित रहते हैं। |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius गैर‑नकारात्मक और पॉइंट में मापी जाती है; `grow` एक Boolean है जो निर्धारित करता है कि धुंधला कंटेंट मूल सीमा से बाहर जा सकता है या नहीं। |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | गैर‑नकारात्मक प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` उपयोग करें: `0` पूरी तरह पारदर्शी और `100` मौजूदा अल्फा को बरकरार रखता है। |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100` तक, प्रतिशत अपारदर्शिता। |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100` तक, प्रतिशत अल्फा थ्रेशहोल्ड। इससे नीचे के मान पारदर्शी हो जाते हैं; थ्रेशहोल्ड के बराबर या ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉड्यूलेशन के लिए, पारदर्शिता और अपारदर्शिता परस्परपूरक होते हैं। उदाहरण के लिए, 35 % पारदर्शिता का अर्थ है अल्फा मॉड्यूलेशन मात्रा 65 % के बराबर।

## **चमक और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) एक [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) संचालन लौटाता है। इसके स्केलर सेटिंग्स संचालन बनते समय आपूर्ति की जाती हैं। [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) गणना किए गए केवल‑पढ़ने‑योग्य मान लौटाता है जिसे निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण 15 % चमक और 20 % कंट्रास्ट बढ़ाता है, फिर एम्बेडेड छवि को बदले बिना एक प्रीव्यू रेंडर करता है:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) Office 2010 चित्र‑इफ़ेक्ट विस्तार है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट से कम पोर्टेबल है। जब चमक और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रहना हो, तो [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) का उपयोग करें और फ़ाइल पुनः खोलने के बाद परिणाम सत्यापित करें। स्वरूप सीमाएँ इस अंतर को अधिक विस्तार से समझाती हैं।

## **रंग रूपांतरण लागू करें**

रंग प्रभावों को अलग‑अलग चित्र फ्रेम पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही छवि संसाधन का पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, डुओटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `Color1` गहरे पिक्सेल को मैप करता है, जबकि `Color2` हल्के पिक्सेल को। यह एक उपयोगी उदाहरण है जहाँ सेटिंग्स एकल स्केलर मान से अधिक जटिल होती हैं।

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) हर पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को संरक्षित रखता है। यह [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और स्रोत एवं लक्ष्य दोनों रंग स्वरूपों को उजागर करता है।

### **ल्यूमिनेंस थ्रेशहोल्ड लागू करें**

ल्यूमिनेंस थ्रेशहोल्ड स्कैन की गई पृष्ठ पर धुंधले निशानों को पृष्ठभूमि से अधिक स्पष्ट बनाने में मदद करता है। [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) मध्यवर्ती ग्रे शेड्स को बनाए रखता है। [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) ल्यूमिनेंस को काले या सफ़ेद में मैप करता है, जबकि [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) अपारदर्शिता पर थ्रेशहोल्ड लगाता है।

ल्यूमिनेंस थ्रेशहोल्ड 0 % से 100 % (समावेशी) तक रहता है। थ्रेशहोल्ड से कम पिक्सेल काले हो जाते हैं। थ्रेशहोल्ड के बराबर या ऊपर के पिक्सेल सफ़ेद हो जाते हैं। थ्रेशहोल्ड बढ़ाने से अधिक शेड्स काले हो जाते हैं क्योंकि अधिक पिक्सेल कट‑ऑफ़ से नीचे गिरते हैं।

[grayscale-swatches.png](grayscale-swatches.png) को कार्यशील निर्देशिका में डाउनलोड करें। प्रत्येक लेबल मूल ग्रे स्तर को 0‑255 स्केल पर दर्शाता है। उदाहरण मूल को दो प्रतियों के बगल में रखता है और प्रत्येक प्रतिलिपि का थ्रेशहोल्ड प्रस्तुति में सहेजता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और तीन फ्रेम की तुलना करें। लेबल 96 वाला स्वॉच लगभग 38 % ल्यूमिनेंस (96/255) दर्शाता है। यह 20 % थ्रेशहोल्ड पर सफ़ेद और 60 % थ्रेशहोल्ड पर काला हो जाता है।

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **ब्लर, पारदर्शिता, और अल्फा प्रभाव जोड़ें**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) सभी रंग चैनलों को प्रभावित करता है, जिसमें अल्फा भी शामिल है। जब ब्लर्ड किनारा मूल चित्र सीमा से बाहर जा सकता है, तो `grow` को `true` सेट करें।

समान पारदर्शिता के लिए, [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) का उपयोग करें। यह प्रत्येक मौजूदा अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से पारदर्शी पिक्सेल अनुपातिक रूप से अलग रहते हैं। [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान देता है। [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में परिवर्तित करता है।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

अन्य पैरामीटर‑रहित अल्फा संचालन में शामिल हैं [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), जो प्रत्येक शून्य‑नॉन‑शून्य अल्फा को पूरी तरह अपारदर्शी बनाता है; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), जो 100 % से कम सभी अल्फा को पूरी तरह पारदर्शी बनाता है; और [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध प्रभाव श्रृंखला बनाएं**

प्रत्येक `Add...Effect` विधि संग्रह के अंत में एक नया संचालन जोड़ती है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: संचालन 0 का आउटपुट संचालन 1 का इनपुट बनता है, आदि। परिणामस्वरूप, समान संचालन का अलग क्रम अलग‑अलग छवि उत्पन्न कर सकता है।

उदाहरण के लिए, ग्रेस्केल के बाद टिंट पहले रंगात्मक जानकारी हटाता है और फिर ल्यूमिनेंस परिणाम को पुनः रंगित करता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी तरह, अल्फा प्रतिस्थापन पहले के संचालन द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मॉड्यूलेशन उनके सापेक्ष अंतर को बनाए रखता है।

निम्न उदाहरण चार‑ऑपरेशन श्रृंखला बनाता है, उसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, संचालन प्रकार और क्रम दोनों की जाँच करता है, और पुनः खुले परिणाम को रेंडर करता है:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

संग्रह कोई संगतता मैट्रिक्स लागू नहीं करता जो रंग, अल्फा, और ब्लर संचालन को अलग‑अलग श्रृंखलाओं में सीमित करे। इन्हें संयोजित किया जा सकता है, पर संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग प्रभावों द्वारा उत्पन्न RGB विविधता को हटा देता है; डुओटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, प्रतिस्थापन, या बाइलवल संचालन पहले निर्मित अल्फा विवरण को नष्ट कर सकते हैं। इच्छित पिक्सेल‑प्रोसेसिंग क्रम के अनुसार श्रृंखला बनाएँ, न कि इसे असॉर्टेड फ़ॉर्मेटिंग फ्लैग मानें।


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **संपादनीय और प्रभावी मानों का निरीक्षण करें**

एक संपादनीय संचालन वह वस्तु है जो `ISlidesPicture.ImageTransform` में संग्रहीत होती है। प्रभाव के अनुसार, यह सीधे लिखने योग्य सदस्यों को उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) लिखने योग्य `Radius` और `Grow` को उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) लिखने योग्य `Amount` को उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) लिखने योग्य `Threshold` को उजागर करता है। [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) जैसे रंग प्रभाव [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) वस्तुओं को बदलने योग्य रूप में उजागर करते हैं।

कुछ संचालन इंटरफ़ेस, जैसे [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), अपने निर्माण स्केलर को लिखने योग्य गुण के रूप में उजागर नहीं करते। इन सेटिंग्स को बदलने के लिए, संचालन को हटाएँ और आवश्यक स्थिति में एक प्रतिस्थापन जोड़ें।

`GetEffective()` द्वारा लौटाए गए प्रभावी डेटा गणना किए गए और केवल‑पढ़ने‑योग्य होते हैं। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी होता है, लेकिन यह कोई अतिरिक्त संपादन सतह नहीं है। नीचे का उदाहरण श्रृंखला को गिनता है और जहाँ संबंधित API प्रदान करती है वहाँ प्रभावी मानों का निरीक्षण करता है:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

पैरामीटर‑रहित प्रभाव जैसे ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स के भी एक प्रभावी‑डेटा वस्तु होती है, लेकिन प्रिंट करने के लिए कोई स्केलर सेटिंग नहीं होती। उनका अस्तित्व और संग्रह में स्थिति ही महत्वपूर्ण जानकारी होती है।

## **छवि रूपांतरण हटाएँ या साफ़ करें**

एक संचालन को उसके इंडेक्स द्वारा हटाने के लिए [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) का उपयोग करें। क्योंकि हटाने के बाद इंडेक्स शिफ़्ट होते हैं, पहले लक्ष्य को खोजें और गिनती के बाद उसे हटाएँ। पूरी श्रृंखला को हटाने के लिए `Clear()` उपयोग करें।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

रूपांतरण हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) संसाधन को नहीं हटाता, पुनः संपीड़ित करता या अन्यथा बदलता।

## **प्रेजेंटेशन स्वरूप और एक्सपोर्ट लक्ष्य पर विचार करें**

छवि रूपांतरण DrawingML में उत्पन्न होते हैं, इसलिए PPTX प्रभाव श्रृंखलाओं के लिए पसंदीदा संपादन योग्य स्वरूप है। PPTX के साथ भी, हर संचालन की पोर्टेबिलिटी समान नहीं है:

- मानक DrawingML संचालन जैसे ल्यूमिनेंस, ग्रेस्केल, डुओटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा संचालन PPTX राउंड‑ट्रिप में जीवित रहने की सबसे अधिक संभावना रखते हैं। जब संरक्षण आवश्यक हो, तो उत्पन्न फ़ाइल को हमेशा पुनः खोलें और संग्रह का निरीक्षण करें।
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) Office 2010 का विस्तार है, न कि मानक DrawingML ल्यूमिनेंस संचालन। इसे इन‑मेमोरी रेंडरिंग के लिए उपयोग किया जा सकता है, लेकिन सहेजने और PPTX को पुनः खोलने के बाद यह संपादन योग्य [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) के रूप में बना रहना गारंटीकृत नहीं है। स्थायी चमक और कंट्रास्ट समायोजन के लिए [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) को प्राथमिकता दें।
- बाइनरी PPT स्वरूप पूर्ण DrawingML प्रभाव मॉडल से पहले आया है। PPT में सहेजने से असहाय संचालन छोड़ दिए जा सकते हैं, श्रृंखला को समर्थित उपसमूह में घटाया जा सकता है, या दिखावट का अनुमान लगाया जा सकता है। जटिल संपादन योग्य श्रृंखला के लिए सत्यापन स्वरूप के रूप में PPT का उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML या अन्य दृश्य आउटपुट पर रेंडरिंग समर्थित श्रृंखला को रेंडर की गई दिखावट पर लागू करती है। इन आउटपुट में संपादन योग्य `IImageTransformOperationCollection` नहीं होता; रास्टर स्वरूप परिणाम को पिक्सेल में फ्लैट कर देते हैं, और दस्तावेज़/वेक्टर एक्सपोर्ट अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- प्रभाव लिंक्ड छवि को स्वयं‑संचित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिए लिंक्ड संसाधन की उपलब्धता आवश्यक रहती है जब प्रस्तुति लोड की जाती है।

विभिन्न प्रस्तुति उपभोक्ता किनारे मामलों को अलग‑अलग रेंडर कर सकते हैं, विशेष रूप से जब कई अल्फा या रंग‑क्वांटाइज़िंग संचालन संयोजित होते हैं। महत्वपूर्ण आउटपुट के लिए, वही Aspose.Slides संस्करण उपयोग करते हुए संपादन योग्य राउंड‑ट्रिप और अंतिम एक्सपोर्ट स्वरूप दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या छवि रूपांतरण प्रभाव एम्बेडेड छवि डेटा को संशोधित करते हैं?**

नहीं। संचालन `ISlidesPicture` से संबंधित होते हैं जो चित्र फ़िल द्वारा उपयोग किया जाता है। अंतर्निहित `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम जो समान छवि का पुनः उपयोग करते हैं, प्रभाव साझा करते हैं?**

नहीं। `IPPImage` को पुनः उपयोग करने से डुप्लिकेट छवि डेटा बचता है, लेकिन प्रत्येक चित्र फ्रेम आमतौर पर अलग `ISlidesPicture` और अलग छवि रूपांतरण संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा प्रभावों को संयोजित किया जा सकता है?**

हां। संग्रह उन्हें एक क्रमबद्ध श्रृंखला में स्वीकार करता है। प्रत्येक संचालन के पिछले संचालन पर क्या प्रभाव पड़ता है, इसका विचार करें क्योंकि प्रतिस्थापन और थ्रेशहोल्ड संचालन पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल‑पढ़ने‑योग्य क्यों होते हैं?**

प्रभावी डेटा रेंडरिंग के लिए उपयोग किए गए गणना किए गए मानों का प्रतिनिधित्व करता है, जिसमें हल किए गए रंग शामिल होते हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, रूपांतरण संग्रह में संग्रहीत संचालन को संपादित करें; अन्यथा उसे हटाएँ और नई निर्माण पैरामीटर के साथ एक प्रतिस्थापन जोड़ें।

**कौन‑सा स्वरूप रूपांतरण श्रृंखला को संरक्षित करने के लिए उपयोग करना चाहिए?**

PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML प्रभाव मॉडल को प्रदर्शित नहीं कर सकता, और रेंडरेड एक्सपोर्ट स्वरूप केवल दिखावट को संरक्षित करते हैं, न कि संपादन योग्य रूपांतरण संचालन।