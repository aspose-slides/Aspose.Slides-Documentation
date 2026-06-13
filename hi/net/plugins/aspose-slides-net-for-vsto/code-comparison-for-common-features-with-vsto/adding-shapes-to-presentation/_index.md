---
title: प्रस्तुति में आकार जोड़ना
type: docs
weight: 30
url: /hi/net/adding-shapes-to-presentation/
---
## **VSTO**
लाइन आकार जोड़ने के लिए नीचे कोड स्निपेट दिया गया है:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
प्रस्तुति की चयनित स्लाइड में एक साधारण सीधी रेखा जोड़ने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- Presentation क्लास का एक इंस्टेंस बनाएं
- स्लाइड का रेफ़रेंस उसके Index का उपयोग करके प्राप्त करें
- Shapes ऑब्जेक्ट द्वारा प्रदान किए गए AddAutoShape मेथड का उपयोग करके लाइन प्रकार की AutoShape जोड़ें
- परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें

नीचे दिए गए उदाहरण में, हमने प्रस्तुति की पहली स्लाइड में एक रेखा जोड़ी है।

``` csharp

   //PPTX का प्रतिनिधित्व करने वाली Prseetation क्लास को instantiate करें

  Presentation pres = new Presentation();

  //पहली स्लाइड प्राप्त करें

  ISlide slide = pres.Slides[0];

  //लाइन प्रकार की autoshape जोड़ें

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)