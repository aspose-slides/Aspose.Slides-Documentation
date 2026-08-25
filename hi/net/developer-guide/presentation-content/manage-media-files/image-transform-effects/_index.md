---
title: ".NET के साथ प्रस्तुतियों में इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को प्रबंधित करें"
linktitle: "इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स"
type: docs
weight: 11
url: /hi/net/image-transform-effects/
keywords:
- इमेज ट्रांसफ़ॉर्म
- पिक्चर इफ़ेक्ट
- ब्राइटनेस
- कंट्रास्ट
- ग्रेस्केल
- ड्यूोटोन
- टिंट
- HSL
- रंग प्रतिस्थापन
- ब्लर
- ट्रांसपैरेंसी
- अल्फा इफ़ेक्ट
- इफ़ेक्ट चेन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ पिक्चर फ्रेम्स के लिए इमेज ट्रांसफ़ॉर्म इफ़ेक्ट्स को लागू करें, चेन बनाएं, निरीक्षण करें, हटाएं और सत्यापित करें।"
---
## **सारांश**

Aspose.Slides चित्र समायोजन को इमेज ट्रांसफ़ॉर्म ऑपरेशनों के क्रमबद्ध संग्रह के रूप में दर्शाता है। एक चित्र फ्रेम के लिए, फ्रेम की [ISlidesPicture](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/) से शुरू करें और [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/imagetransform/) तक पहुँचें। लौटाया गया [IImageTransformOperationCollection](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/) आपको प्रभावों को जोड़ने, गिनने, जांचने, हटाने और साफ़ करने की अनुमति देता है बिना मूल इमेज बाइट्स को पुनर्लिखे।

यह लेख ब्राइटनेस और कंट्रास्ट, रंग रूपांतरण, ब्लर, ट्रांसपैरेंसी, क्रमबद्ध इफ़ेक्ट चेन, प्रभावी मान, हटाना, और PPTX राउंड‑ट्रिप सत्यापन के लिए पूर्ण कार्यप्रवाह प्रदर्शित करता है।

## **प्रभाव स्वामित्व और इमेज पुन: उपयोग को समझें**

एक इमेज रिसोर्स और उसे प्रदर्शित करने वाला चित्र दो विभिन्न वस्तुएँ हैं:

- [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) प्रस्तुति द्वारा स्वामित्व वाले स्रोत इमेज डेटा को संग्रहीत या संदर्भित करता है।
- [ISlidesPicture](https://reference.aspose.com/slides/hi/net/aspose.slides/islidespicture/) एक चित्र फ़िल के अंतर्गत आता है और इमेज रिसोर्स को संदर्भित करता है जबकि इमेज ट्रांसफ़ॉर्म संग्रह को संग्रहीत करता है।
- [IPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ipictureframe/) स्लाइड आकार है जो संबंधित चित्र फ़िल, ज्यामिति, क्रॉप सेटिंग्स, और अन्य फ्रेम‑स्तर फ़ॉर्मेटिंग को स्वामित्व रखता है।

इसलिए, इमेज ट्रांसफ़ॉर्म ऑपरेशन्स [IPPImage] की बाइट्स को संशोधित नहीं करते। जब एक ही `IPPImage` को [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) से अधिक बार पास किया जाता है, तो प्रत्येक नई चित्र फ्रेम को अपना `ISlidesPicture` और अपनी ट्रांसफ़ॉर्म संग्रह मिलती है। एक फ्रेम पर ग्रेस्केल लागू करने से अन्य फ्रेम ग्रेस्केल नहीं होते, भले ही सभी एक ही एम्बेडेड इमेज रिसोर्स को पुन: उपयोग करें।

उसी `ISlidesPicture.ImageTransform` मॉडल का उपयोग अन्य चित्र फ़िल्स, जैसे आकार या स्लाइड पृष्ठभूमि, द्वारा भी किया जाता है। नीचे के उदाहरण केवल चित्र फ्रेम्स पर केंद्रित हैं।

## **वैध पैरामीटर रेंज और इकाइयों का उपयोग करें**

प्रदर्शित विधियों में निम्न सेमिक अर्थ वाली रेंज और इकाइयाँ उपयोग की जाती हैं। इन रेंजों में मान रखें भले ही कोई विशेष लाइब्रेरी संस्करण तुरंत सभी आउट‑ऑफ़‑रेंज मानों को अस्वीकार न करे; लक्ष्य प्रस्तुति फ़ॉर्मेट सहेजते समय या PowerPoint फ़ाइल खोलते समय अमान्य डेटा को सामान्यीकृत, छोड़ या अस्वीकार कर सकता है।

| ऑपरेशन | पैरामीटर | वैध रेंज और इकाई |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` से `100` तक, प्रतिशत; `0` घटक को अपरिवर्तित रखता है। |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | कोई संख्यात्मक पैरामीटर नहीं। अल्फा अपरिवर्तित रहता है। |
| [AddDuotoneEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | डार्क और लाइट पिक्सेल के लिए दो रंग। `System.Drawing.Color` में RGB और अल्फा चैनल `0` से `255` तक प्रयोग करते हैं। |
| [AddTintEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | ह्यू `0` (समावेशी) से `360` (अनन्य) डिग्री में; मात्रा `-100` से `100`, प्रतिशत। |
| [AddHSLEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | ह्यू `0` (समावेशी) से `360` (अनन्य) डिग्री में; सैचुरेशन और ल्यूमिनेंस `-100` से `100`, प्रतिशत। |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | बदलाव रंग के चैनल मान `0` से `255` तक होते हैं। मौजूदा अल्फा मान अपरिवर्तित रहता है। |
| [AddBlurEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | रेडियस नॉन‑नेगेटिव है और पॉइंट्स में मापा जाता है; `grow` एक बूलियन है जो निर्धारित करता है कि ब्लर किया गया कंटेंट मूल सीमा से बाहर विस्तारित हो सकता है या नहीं। |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | नॉन‑नेगेटिव प्रतिशत। सामान्य अपारदर्शिता स्केलिंग के लिए `0` से `100` प्रयोग करें: `0` पूर्णतः ट्रांसपेरेंट है और `100` मौजूद अल्फा को बरकरार रखता है। |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` से `100`, प्रतिशत अपारदर्शिता। |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` से `100`, प्रतिशत अल्फा थ्रेशहोल्ड। इसके नीचे मान ट्रांसपेरेंट हो जाते हैं; इस या उससे ऊपर के मान अपारदर्शी हो जाते हैं। |

स्थिर अल्फा मॉडुलेशन के लिए, ट्रांसपैरेंसी और अपारदर्शिता परस्परपूरक होते हैं। उदाहरण के लिए, 35% ट्रांसपैरेंसी का अर्थ 65% अल्फा मॉडुलेशन मात्रा है।

## **ब्राइटनेस और कंट्रास्ट लागू करें**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) एक [IBrightnessContrast](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ibrightnesscontrast/) ऑपरेशन लौटाता है। इसके स्केलर सेटिंग्स ऑपरेशन बनाते समय प्रदान की जाती हैं। [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/brightnesscontrast/geteffective/) गणना किए हुए केवल‑पढ़ने योग्य मान लौटाता है जिन्हें निरीक्षण या लॉग किया जा सकता है।

निम्न उदाहरण ब्राइटनेस को 15% और कंट्रास्ट को 20% बढ़ाता है, फिर एम्बेडेड इमेज को बदले बिना एक प्रीव्यू रेंडर करता है:

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

[BrightnessContrast](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/brightnesscontrast/) Office 2010 चित्र‑इफ़ेक्ट विस्तार है और मानक DrawingML ल्यूमिनेंस इफ़ेक्ट की तुलना में कम पोर्टेबल है। जब ब्राइटनेस और कंट्रास्ट को PPTX राउंड‑ट्रिप के बाद भी संपादन योग्य रखना हो, तो [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) का उपयोग करें और फ़ाइल को पुनः खोलने के बाद परिणाम सत्यापित करें। फ़ॉर्मेट सीमाएँ भाग इस अंतर को अधिक विस्तार से समझाता है।

## **रंग रूपांतरण लागू करें**

रंग इफ़ेक्ट्स को अलग‑अलग चित्र फ्रेम्स पर स्वतंत्र रूप से लागू किया जा सकता है जो एक ही इमेज रिसोर्स को पुनः उपयोग करते हैं। निम्न उदाहरण पाँच फ्रेम बनाता है और क्रमशः ग्रेस्केल, ड्यूोटोन, टिंट, HSL समायोजन, और रंग प्रतिस्थापन लागू करता है।

[IDuotone](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iduotone/) दो स्वतंत्र रूप से संपादन योग्य रंग पैरामीटर रखता है: `Color1` डार्क पिक्सेल को मैप करता है, जबकि `Color2` लाइट पिक्सेल को। यह एक उपयोगी उदाहरण है जहाँ सेटिंग्स एकल स्केलर मान से अधिक जटिल हैं।

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) प्रत्येक पिक्सेल के रंग को एक निश्चित रंग से बदलता है जबकि अल्फा को बरकरार रखता है। यह [AddColorChangeEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) से अलग है, जो एक स्रोत रंग को दूसरे में मैप करता है और स्रोत तथा लक्ष्य रंग फ़ॉर्मेट दोनों को उजागर करता है।

## **ब्लर, ट्रांसपैरेंसी और अल्फा इफ़ेक्ट जोड़ें**

[AddBlurEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) सभी रंग चैनलों, अल्फा सहित, को प्रभावित करता है। जब ब्लर किया गया किनारा मूल चित्र की सीमा से बाहर जा सकता है, तो `grow` को `true` सेट करें।

समान ट्रांसपैरेंसी के लिए, [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) उपयोग करें। यह प्रत्येक मौजूद अल्फा मान को गुणा करता है, इसलिए आंशिक रूप से ट्रांसपेरेंट पिक्सेल अनुपातिक रूप से अलग रहते हैं। [AddAlphaReplaceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) सभी पिक्सेल को एक ही अल्फा मान देता है। [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) थ्रेशहोल्ड के आधार पर अल्फा को दो स्तरों में परिवर्तित करता है।

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

अन्य पैरामीटर‑फ़्री अल्फा ऑपरेशन्स में [AddAlphaCeilingEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) शामिल है, जो हर गैर‑शून्य अल्फा को पूर्णतः अपारदर्शी बनाता है; [AddAlphaFloorEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) जो 100% से कम प्रत्येक अल्फा को पूर्णतः ट्रांसपेरेंट बनाता है; तथा [AddAlphaInverseEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) जो अल्फा को `100% - alpha` में बदलता है।

## **एक क्रमबद्ध इफ़ेक्ट चेन बनाएँ**

प्रत्येक `Add...Effect` मेथड नई ऑपरेशन को संग्रह के अंत में जोड़ता है। रेंडरर संग्रह को क्रमबद्ध पाइपलाइन के रूप में उपयोग करता है: ऑपरेशन 0 का आउटपुट ऑपरेशन 1 का इनपुट बन जाता है, आदि। परिणामस्वरूप, विभिन्न क्रम में समान ऑपरेशन्स अलग इमेज उत्पन्न कर सकते हैं।

उदाहरण के लिये, ग्रेस्केल के बाद टिंट पहले क्रोमैटिक जानकारी को हटा देता है और फिर ल्यूमिनेंस परिणाम को फिर से रंग देता है। टिंट के बाद ग्रेस्केल टिंट को फिर से हटा देता है। इसी तरह, अल्फा रिप्लेसमेंट पहले के ऑपरेशन्स द्वारा गणना किए गए अल्फा मानों को ओवरराइड कर सकता है, जबकि अल्फा मोड्यूलेशन उनके सापेक्ष अंतर को बनाय रखता है।

निम्न उदाहरण चार‑ऑपरेशन चेन बनाता है, इसे PPTX के रूप में सहेजता है, प्रस्तुति को पुनः खोलता है, ऑपरेशन प्रकार और उनका क्रम दोनों जाँचता है, और पुनः खोले गए परिणाम को रेंडर करता है:

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

संग्रह कोई संगतता मैट्रिक्स नहीं लागू करता जो रंग, अल्फा, और ब्लर ऑपरेशन्स को अलग‑अलग चेन में सीमित करे। उन्हें एक साथ जोड़ा जा सकता है, लेकिन संयोजन हमेशा उपयोगी नहीं होते। एक स्थिर रंग प्रतिस्थापन पहले के रंग इफ़ेक्ट्स द्वारा उत्पन्न RGB विविधता को हटा देता है; ड्यूोटोन के बाद ग्रेस्केल दो चयनित रंगों को हटा देता है; और अल्फा सीलिंग, फ़्लोर, रिप्लेसमेंट, या बाइ‑लेवल ऑपरेशन्स पहले निर्मित अल्फा विवरण को समाप्त कर सकते हैं। चेन को वांछित पिक्सेल‑प्रोसेसिंग क्रम के अनुसार बनाएं न कि इसके आइटम्स को अनऑर्डर्ड फ़ॉर्मेटिंग फ़्लैग मानें।

## **संपादन योग्य और प्रभावी मान निरीक्षण करें**

एक संपादन योग्य ऑपरेशन वह ऑब्जेक्ट है जो `ISlidesPicture.ImageTransform` में संग्रहीत होता है। प्रभाव के आधार पर, यह सीधे लिखने योग्य सदस्य उजागर कर सकता है। उदाहरण के लिए, [IBlur](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iblur/) लिखने योग्य `Radius` और `Grow` उजागर करता है, [IAlphaModulateFixed](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ialphamodulatefixed/) लिखने योग्य `Amount` उजागर करता है, और [IAlphaBiLevel](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ialphabilevel/) लिखने योग्य `Threshold` उजागर करता है। रंग इफ़ेक्ट्स जैसे [IDuotone](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iduotone/) परिवर्तनीय [IColorFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/icolorformat/) ऑब्जेक्ट्स उजागर करते हैं।

कुछ ऑपरेशन इंटरफ़ेसेस, जैसे [IBrightnessContrast](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/itint/), और [IAlphaReplace](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ialphareplace/), अपने निर्माण स्केलर को लिखने योग्य प्रॉपर्टी के रूप में उजागर नहीं करते। उन सेटिंग्स को बदलने के लिये, ऑपरेशन को हटाएँ और वांछित स्थान पर एक नया जोड़ें।

`GetEffective()` द्वारा लौटाया गया प्रभावी डेटा गणना किया गया और केवल‑पढ़ने योग्य होता है। यह थीम‑निर्भर रंगों को हल करने और रेंडरर द्वारा उपयोग किए गए सामान्यीकृत मानों को पढ़ने में उपयोगी है, परंतु यह अतिरिक्त संपादन सतह नहीं है। निम्न उदाहरण चेन को गिनता है और जहाँ संबंधित API उपलब्ध है, प्रभावी मानों का निरीक्षण करता है:

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

ग्रेस्केल, अल्फा सीलिंग, और अल्फा इनवर्स जैसे पैरामीटर‑फ़्री इफ़ेक्ट्स का भी प्रभावी‑डेटा ऑब्जेक्ट होता है, परंतु प्रिंट करने के लिये कोई स्केलर सेटिंग नहीं होती। संग्रह में उनकी उपस्थिति और स्थिति ही महत्वपूर्ण जानकारी है।

## **इमेज ट्रांसफ़ॉर्म हटाएँ या साफ़ करें**

[IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) का उपयोग करके इंडेक्स द्वारा एक ऑपरेशन हटाएँ। हटाने के बाद इंडेक्स बदलते हैं, इसलिए पहले लक्ष्य खोजें और enumeration के बाद हटाएँ। संपूर्ण चेन हटाने के लिये `Clear()` उपयोग करें।

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

ट्रांसफ़ॉर्म हटाने या साफ़ करने से केवल चित्र फ़ॉर्मेटिंग बदलती है। यह पुनः उपयोग किए गए [IPPImage](https://reference.aspose.com/slides/hi/net/aspose.slides/ippimage/) रिसोर्स को न तो हटाता है, न पुनः संपीड़ित करता है, और न ही अन्यथा बदलता है।

## **प्रेज़ेंटेशन फ़ॉर्मेट और एक्सपोर्ट लक्ष्य पर विचार करें**

इमेज ट्रांसफ़ॉर्म DrawingML से उत्पन्न होते हैं, इसलिए PPTX इफ़ेक्ट चेन के लिये वांछित संपादन योग्य फ़ॉर्मेट है। PPTX के साथ भी, प्रत्येक ऑपरेशन की पोर्टेबिलिटी समान नहीं होती:

- ल्यूमिनेंस, ग्रेस्केल, ड्यूोटोन, टिंट, HSL, ब्लर, और सामान्य अल्फा ऑपरेशन्स जैसे मानक DrawingML ऑपरेशन्स का PPTX राउंड‑ट्रिप में जीवित रहने का सर्वोत्तम मौका होता है। जब संरक्षण आवश्यक हो, हमेशा उत्पन्न फ़ाइल को पुनः खोलें और संग्रह की जाँच करें।
- [BrightnessContrast](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/brightnesscontrast/) Office 2010 विस्तार है, मानक DrawingML ल्यूमिनेंस ऑपरेशन नहीं। इसे मेमोरी में रेंडरिंग के लिये उपयोग किया जा सकता है, परंतु यह सेव करने और PPTX को पुनः खोलने के बाद एक संपादन योग्य [IBrightnessContrast](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/ibrightnesscontrast/) के रूप में बना रहे, इसकी गारंटी नहीं है। स्थायी ब्राइटनेस और कंट्रास्ट समायोजन के लिये [AddLuminanceEffect](https://reference.aspose.com/slides/hi/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) को प्राथमिकता दें।
- बाइनरी PPT फ़ॉर्मेट पूर्ण DrawingML इफ़ेक्ट मॉडल से पहले का है। PPT में सहेजने से असमर्थित ऑपरेशन्स को छोड़ दिया जा सकता है, चेन को समर्थित उपसमुच्चय में घटाया जा सकता है, या उपस्थिति का अनुमान लगाया जा सकता है। जटिल संपादन योग्य चेन के लिये PPT को सत्यापन फ़ॉर्मेट के रूप में उपयोग न करें।
- PNG, JPEG, TIFF, PDF, SVG, HTML, या अन्य विजुअल आउटपुट में रेंडर करने से समर्थित चेन रेंडर की गई उपस्थिति पर लागू होती है। इन आउटपुट में संपादन योग्य `IImageTransformOperationCollection` नहीं होती; रास्टर फ़ॉर्मेट परिणाम को पिक्सेल में फ़्लैटन कर देते हैं, और दस्तावेज़/वेक्टर एक्सपोर्ट अपना स्वयं का रेंडरिंग प्रतिनिधित्व संग्रहीत करते हैं।
- इफ़ेक्ट्स किसी लिंक्ड इमेज को स्व‑समाहित नहीं बनाते। लिंक्ड चित्र को रेंडर करने के लिये प्रस्तुति लोड होने पर लिंक्ड रिसोर्स उपलब्ध होना आवश्यक है।

विभिन्न प्रेज़ेंटेशन कंज्यूमर्स किनारे मामलों को अलग ढंग से रेंडर कर सकते हैं, विशेषकर जब कई अल्फा या रंग‑क्वांटाइज़िंग ऑपरेशन्स को मिलाया जाता है। महत्वपूर्ण आउटपुट के लिये, उत्पादन में उपयोग किए जाने वाले समान Aspose.Slides संस्करण के साथ संपादन योग्य राउंड‑ट्रिप और अंतिम एक्सपोर्ट फ़ॉर्मेट दोनों का परीक्षण करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या इमेज ट्रांसफ़ॉर्म इफ़ेक्ट एम्बेडेड इमेज डेटा को संशोधित करते हैं?**  
नहीं। ये ऑपरेशन्स चित्र फ़िल द्वारा उपयोग किए गए `ISlidesPicture` से संबंधित हैं। आधारभूत `IPPImage` बाइट्स अपरिवर्तित रहती हैं।

**क्या दो चित्र फ्रेम्स जो एक ही इमेज को पुनः उपयोग करते हैं, अपने इफ़ेक्ट साझा करेंगे?**  
नहीं। `IPPImage` को पुन: उपयोग करने से डुप्लिकेट इमेज डेटा बचता है, पर प्रत्येक चित्र फ्रेम आमतौर पर एक अलग `ISlidesPicture` और इमेज ट्रांसफ़ॉर्म संग्रह रखता है।

**क्या रंग, ब्लर, और अल्फा इफ़ेक्ट को मिलाया जा सकता है?**  
हां। संग्रह उन्हें एक क्रमबद्ध चेन में स्वीकार करता है। प्रत्येक ऑपरेशन पिछले के आउटपुट को कैसे बदलता है, इस पर विचार करें क्योंकि रिप्लेसमेंट और थ्रेशहोल्ड ऑपरेशन्स पहले के रंग या अल्फा विवरण को हटा सकते हैं।

**प्रभावी मान केवल पढ़ने योग्य क्यों होते हैं?**  
प्रभावी डेटा रेंडरिंग के लिये उपयोग किए गए गणना किए हुए मानों को दर्शाता है, जिसमें हल किए हुए रंग शामिल हैं। जहाँ लिखने योग्य सदस्य मौजूद हों, ट्रांसफ़ॉर्म संग्रह में संग्रहीत ऑपरेशन को संपादित करें; अन्यथा उसे हटाकर नई निर्माण पैरामीटर के साथ प्रतिस्थापन जोड़ें।

**एक ट्रांसफ़ॉर्म चेन को संरक्षित रखने के लिये मुझे कौन सा फ़ॉर्मेट उपयोग करना चाहिए?**  
PPTX का उपयोग करें और फ़ाइल को पुनः खोलकर सत्यापित करें। लेगेसी PPT पूर्ण DrawingML इफ़ेक्ट मॉडल को प्रदर्शित नहीं कर सकता, और रेंडर किए गए एक्सपोर्ट फ़ॉर्मेट केवल उपस्थिति को संरक्षित करते हैं, न कि संपादन योग्य ट्रांसफ़ॉर्म ऑपरेशन्स को।