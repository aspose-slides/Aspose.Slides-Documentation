---
title: Aspose.Slides for .NET 15.4.0 में सार्वजनिक API और पिछड़े असंगत परिवर्तन
linktitle: Aspose.Slides .NET 15.4.0 के लिए
type: docs
weight: 150
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- माइग्रेशन
- पुराना कोड
- आधुनिक कोड
- पुरानी पद्धति
- आधुनिक पद्धति
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अपडेट और ब्रेकिंग परिवर्तन की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रेजेंटेशन समाधान को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="primary" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) वर्गों, विधियों, गुणों आदि की सूची देता है, और Aspose.Slides for .NET 15.4.0 API के साथ प्रस्तुत किए गए अन्य परिवर्तन भी।

{{% /alert %}} 
## **Public API Changes**
#### **Enum OrganizationChartLayoutType Has Been Added**
Aspose.Slides.SmartArt.OrganizationChartLayoutType enum एक संगठन चार्ट में बच्चों के नोड्स के फ़ॉर्मेटिंग प्रकार को दर्शाता है।
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts Has Been Added**
Method Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts बुलेट सक्षम होने पर (जैसा PowerPoint में पैराग्राफ बुलेट/नंबरिंग सक्षम करने पर होता है) प्रभावी पैराग्राफ इंडेंट और MarginLeft के लिए डिफ़ॉल्ट गैर‑शून्य शिफ्ट सेट करता है। यदि बुलेट अक्षम है तो केवल पैराग्राफ इंडेंट और MarginLeft को रीसेट करता है (जैसा PowerPoint में बुलेट/नंबरिंग अक्षम करने पर होता है)।

उदाहरण देखें [यहाँ](/slides/hi/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute Has Been Added**
Method Aspose.Slides.IConnector.Reroute कनेक्टर को इस प्रकार पुनः मार्गित करता है कि वह आकारों के बीच सबसे छोटा संभावित पथ ले। ऐसा करने के लिए, Reroute() मेथड StartShapeConnectionSiteIndex और EndShapeConnectionSiteIndex को बदल सकता है।

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Method IPresentation.GetSlideById Has Been Added**
Method Aspose.Slides.IPresentation.GetSlideById(System.UInt32) स्लाइड Id द्वारा Slide, MasterSlide या LayoutSlide लौटाता है।

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount Has Been Added**
Property Aspose.Slides.IShape.ConnectionSiteCount आकार पर कनेक्शन साइटों की संख्या लौटाता है।

``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.IsReversed Has Been Added**
Property Aspose.Slides.SmartArt.ISmartArt.IsReversed बताता है या सेट करता है कि SmartArt आरेख (बाएँ‑से‑दाएँ) LTR या (दाएँ‑से‑बाएँ) RTL की दिशा में उल्टा है या नहीं, यदि आरेख उलट समर्थन करता है।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes Has Been Added**
Property Aspose.Slides.SmartArt.ISmartArt.Nodes SmartArt वस्तु में मूल नोड्स का संग्रह लौटाता है।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // दूसरा मूल नोड चुनें

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden Has Been Added**
Property Aspose.Slides.SmartArt.ISmartArtNode.IsHidden लौटाता है कि यह नोड डेटा मॉडल में छिपा हुआ नोड है या नहीं।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true लौटाता है

  if(hidden)

  {

    //कुछ कार्य या सूचनाएँ करें

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout Has Been Added**
Property Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout वर्तमान नोड से जुड़े संगठन चार्ट प्रकार को प्राप्त या सेट करने की अनुमति देता है।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout Has Been Added**
Property Aspose.Slides.SmartArt.ISmartArt.Layout के लिए सेट मेथड जोड़ा गया है। यह मौजूदा आरेख के लेआउट प्रकार को बदलने की अनुमति देता है।

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Minor API Changes**
**यह Minor API परिवर्तनों की सूची है:**

|Enum Aspose.Slides.BevelColorMode |हटाया गया, अप्रयुक्त enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |हटाया गया, अप्रयुक्त property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |जोड़ा गया |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |हटाया गया |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |हटाया गया क्योंकि अवकाशित |