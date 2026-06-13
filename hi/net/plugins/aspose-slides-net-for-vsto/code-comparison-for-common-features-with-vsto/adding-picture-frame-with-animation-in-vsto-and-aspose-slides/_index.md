---
title: VSTO और Aspose.Slides में एनीमेशन के साथ चित्र फ्रेम जोड़ना
type: docs
weight: 20
url: /hi/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
नीचे दिए गए कोड नमूने एक प्रस्तुति बनाते हैं जिसमें एक स्लाइड, चित्र फ्रेम के साथ एक छवि जोड़ते हैं और उस पर एनीमेशन लागू करते हैं।

## **VSTO**
VSTO का उपयोग करके, निम्नलिखित चरण अपनाएँ:

1. एक प्रस्तुति बनाएं।  
1. एक खाली स्लाइड जोड़ें।  
1. स्लाइड में एक चित्र आकार (picture shape) जोड़ें।  
1. चित्र पर एनीमेशन लागू करें।  
1. प्रस्तुति को डिस्क पर लिखें।

``` csharp

 //खाली प्रस्तुति बना रहे हैं
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//एक खाली स्लाइड जोड़ें
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//चित्र फ्रेम जोड़ें
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//चित्र फ्रेम पर एनीमेशन लागू करना
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//प्रस्तुति सहेजना
pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
``` 
## **Aspose.Slides**
Aspose.Slides for .NET का उपयोग करके, निम्नलिखित चरणों को पूरा करें:

1. एक प्रस्तुति बनाएं।  
1. पहली स्लाइड तक पहुंचें।  
1. चित्र संग्रह (picture collection) में एक छवि जोड़ें।  
1. स्लाइड में एक चित्र आकार (picture shape) जोड़ें।  
1. चित्र पर एनीमेशन लागू करें।  
1. प्रस्तुति को डिस्क पर लिखें।

``` csharp

 //खाली प्रस्तुति बना रहे हैं

Presentation pres = new Presentation();

//पहली स्लाइड तक पहुंच रहे हैं

Slide slide = pres.GetSlideByPosition(1);

//प्रस्तुति की चित्र संग्रह में चित्र ऑब्जेक्ट जोड़ रहे हैं

Picture pic = new Picture(pres, "pic.jpeg");

//चित्र ऑब्जेक्ट जोड़ने के बाद, चित्र को एक अनूठा चित्र Id दिया जाता है

int picId = pres.Pictures.Add(pic);

//चित्र फ्रेम जोड़ रहे हैं

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//चित्र फ्रेम पर एनीमेशन लागू कर रहे हैं

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//प्रस्तुति सहेज रहे हैं

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)