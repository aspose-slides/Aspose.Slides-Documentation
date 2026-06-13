---
title: प्रस्तुति में चित्र फ्रेम जोड़ें
type: docs
weight: 50
url: /hi/net/add-picture-frame-to-presentation/
---
## **VSTO**
VSTO प्रस्तुति में चित्र जोड़ने के लिए नीचे कोड दिया गया है:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
अपने स्लाइड में एक सरल चित्र फ्रेम जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. Presentation क्लास का एक इंस्टेंस बनाएं।
1. इंडेक्स का उपयोग करके स्लाइड का रेफ़रेंस प्राप्त करें।
1. Presentation ऑब्जेक्ट से जुड़ी Images कलेक्शन में एक इमेज जोड़कर Image ऑब्जेक्ट बनाएं, जिसे Shape को भरने के लिए उपयोग किया जाएगा।
1. इमेज की चौड़ाई और ऊँचाई की गणना करें।
1. संदर्भित स्लाइड से जुड़े Shapes ऑब्जेक्ट की AddPictureFrame मेथड का उपयोग करके इमेज की चौड़ाई और ऊँचाई के अनुसार एक PictureFrame बनाएं।
1. स्लाइड में एक चित्र फ्रेम (जिसमें चित्र हो) जोड़ें।
1. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपर्युक्त चरण नीचे दिए गए उदाहरण में लागू किए गए हैं।

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //PPTX का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
  Presentation pres = new Presentation();

  //पहली स्लाइड प्राप्त करें
  ISlide sld = pres.Slides[0];

  //ImageEx क्लास का उदाहरण बनाएं
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //चित्र के समान ऊँचाई और चौड़ाई के साथ Picture Frame जोड़ें
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)