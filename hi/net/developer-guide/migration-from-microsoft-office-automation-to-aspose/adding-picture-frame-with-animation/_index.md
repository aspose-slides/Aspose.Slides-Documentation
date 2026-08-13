---
title: VSTO और Aspose.Slides for .NET का उपयोग करके एनीमेशन के साथ चित्र फ्रेम जोड़ना
linktitle: एनीमेशन के साथ चित्र फ्रेम
type: docs
weight: 60
url: /hi/net/adding-picture-frame-with-animation/
keywords:
- चित्र फ्रेम
- छवि जोड़ें
- चित्र जोड़ें
- एनीमेशन वाली छवि
- एनीमेशन वाला चित्र
- स्थानांतरण
- VSTO
- ऑफिस ऑटोमेशन
- PowerPoint
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Microsoft Office ऑटोमेशन से Aspose.Slides for .NET में स्थानांतरण करें और PowerPoint (PPT, PPTX) स्लाइड में साफ़ C# कोड के साथ चित्र फ्रेम को एनीमेट करें।"
---
{{% alert color="info" %}} 

PowerPoint में चित्र फ्रेमों को आकारों या छवियों पर लागू किया जाता है ताकि प्रस्तुति में छवियों को फ्रेम किया जा सके। यह लेख दिखाता है कि कैसे प्रोग्रामेटिक रूप से पहले [VSTO 2008](/slides/hi/net/adding-picture-frame-with-animation/) और फिर [Aspose.Slides for .NET](/slides/hi/net/adding-picture-frame-with-animation/) का उपयोग करके चित्र फ्रेम बनाया जाए और उस पर एनीमेशन लागू किया जाए। पहले, हम आपको दिखाते हैं कि VSTO 2008 का उपयोग करके फ्रेम और एनीमेशन कैसे लागू करें। फिर हम आपको दिखाते हैं कि Aspose.Slides for .NET का उपयोग करके वही चरण कैसे करने हैं।

{{% /alert %}} 
## **एनीमेशन के साथ चित्र फ्रेम जोड़ना**
नीचे दिए गए कोड नमूने एक प्रस्तुति एक स्लाइड के साथ बनाते हैं, एक छवि को चित्र फ्रेम के साथ जोड़ते हैं और उस पर एनीमेशन लागू करते हैं।
### **VSTO 2008 उदाहरण**
VSTO 2008 का उपयोग करके, निम्नलिखित चरणों का पालन करें:

1. एक प्रस्तुति बनाएं।
1. एक खाली स्लाइड जोड़ें।
1. स्लाइड में एक चित्र आकार जोड़ें।
1. चित्र पर एनीमेशन लागू करें।
1. प्रस्तुति को डिस्क पर लिखें।

**VSTO द्वारा बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//खाली प्रस्तुति बना रहा है
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//एक खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//चित्र फ्रेम जोड़ें
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//चित्र फ्रेम पर एनीमेशन लागू कर रहे हैं
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//प्रस्तुति सहेज रहे हैं
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Aspose.Slides for .NET उदाहरण**
Aspose.Slides for .NET का उपयोग करके, निम्नलिखित चरणों को पूरा करें:

1. एक प्रस्तुति बनाएं।
1. पहली स्लाइड तक पहुंचें।
1. एक छवि को चित्र संग्रह में जोड़ें।
1. स्लाइड में एक चित्र आकार जोड़ें।
1. चित्र पर एनीमेशन लागू करें।
1. प्रस्तुति को डिस्क पर लिखें।

**Aspose.Slides द्वारा बनाई गई आउटपुट प्रस्तुति** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// एक खाली प्रस्तुति बनाएं
using (Presentation pres = new Presentation())
{
    // पहली स्लाइड तक पहुंचें
    ISlide slide = pres.Slides[0];

    // प्रस्तुति की इमेज कलेक्शन में एक छवि जोड़ें
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // एक चित्र फ्रेम जोड़ें जिसकी ऊँचाई और चौड़ाई छवि की ऊँचाई और चौड़ाई से मेल खाती है
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // स्लाइड की मुख्य एनीमेशन अनुक्रम प्राप्त करें
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // चित्र फ्रेम पर बाएँ से उड़ने वाला एनीमेशन इफ़ेक्ट जोड़ें
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // प्रस्तुतिकरण सहेजें
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```