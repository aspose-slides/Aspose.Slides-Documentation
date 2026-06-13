---
title: VSTO और Aspose.Slides for .NET का उपयोग करके एनिमेशन के साथ चित्र फ्रेम जोड़ना
linktitle: एनिमेशन के साथ चित्र फ्रेम
type: docs
weight: 60
url: /hi/net/adding-picture-frame-with-animation/
keywords:
- चित्र फ्रेम
- छवि जोड़ें
- चित्र जोड़ें
- एनिमेशन वाली छवि
- एनिमेशन वाला चित्र
- स्थानांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुतिकरण
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET पर माइग्रेट करें और PowerPoint (PPT, PPTX) स्लाइड्स में साफ़ C# कोड के साथ चित्र फ्रेम को एनीमेट करें।"
---
{{% alert color="primary" %}} 

Picture frames are applied to shapes or images in Microsoft PowerPoint to frame images in a presentation. This article shows how to create a picture frame and apply animation on it programmatically using first [VSTO 2008](/slides/hi/net/adding-picture-frame-with-animation/) and then [Aspose.Slides for .NET](/slides/hi/net/adding-picture-frame-with-animation/). First, we show you how to apply a frame and animation using VSTO 2008. We then show you how to perform the same steps using Aspose.Slides for .NET.

{{% /alert %}} 
## **एनिमेशन के साथ चित्र फ्रेम जोड़ना**
नीचे दिया गया कोड नमूना एक प्रस्तुति बनाता है जिसमें एक स्लाइड होती है, एक चित्र फ्रेम के साथ छवि जोड़ता है और उस पर एनिमेशन लागू करता है।
### **VSTO 2008 उदाहरण**
VSTO 2008 का उपयोग करके, निम्न चरणों का पालन करें:

1. एक प्रस्तुति बनाएं।
1. एक खाली स्लाइड जोड़ें।
1. स्लाइड में एक चित्र आकार जोड़ें।
1. चित्र पर एनिमेशन लागू करें।
1. प्रस्तुति को डिस्क पर लिखें।

**VSTO के साथ बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//खाली प्रस्तुति बनाना
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//एक खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//चित्र फ्रेम जोड़ें
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//चित्र फ्रेम पर एनीमेशन लागू करना
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//प्रस्तुति सहेजना
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET उदाहरण**
Aspose.Slides for .NET का उपयोग करके, निम्न चरणों को पूरा करें:

1. एक प्रस्तुति बनाएं।
1. पहले स्लाइड तक पहुंचें।
1. एक चित्र को चित्र संग्रह में जोड़ें।
1. स्लाइड में एक चित्र आकार जोड़ें।
1. चित्र पर एनिमेशन लागू करें।
1. प्रस्तुति को डिस्क पर लिखें।

**Aspose.Slides के साथ बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// एक खाली प्रस्तुति बनाएं
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड तक पहुंचें
    ISlide slide = pres.Slides[0];

    // प्रस्तुति की छवि संग्रह में एक छवि जोड़ें
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // एक चित्र फ्रेम जोड़ें जिसकी ऊँचाई और चौड़ाई छवि की ऊँचाई और चौड़ाई के समान हो
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // स्लाइड की मुख्य एनीमेशन अनुक्रम प्राप्त करें
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // चित्र फ्रेम पर लेफ्ट से फ़्लाई एनीमेशन इफ़ेक्ट जोड़ें
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // प्रस्तुति सहेजें
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```