---
title: Aspose.Slides for .NET 15.4.0 में सार्वजनिक API और पीछे की ओर असंगत परिवर्तन
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- माइग्रेशन
- लेगसी कोड
- आधुनिक कोड
- लेगसी दृष्टिकोण
- आधुनिक दृष्टिकोण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में सार्वजनिक API अद्यतन और ब्रेकिंग बदलावों की समीक्षा करें ताकि आप अपने PowerPoint PPT, PPTX और ODP प्रस्तुति समाधानों को सहजता से माइग्रेट कर सकें।"
---
{{% alert color="info" %}} 

यह पृष्ठ सभी [जोड़े गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) या [हटाए गए](/slides/hi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) क्लासेज़, मेथड्स, प्रॉपर्टीज़ आदि, तथा Aspose.Slides for .NET 15.4.0 API के साथ प्रस्तुत किए गए अन्य बदलावों की सूची देता है।

{{% /alert %}} 
## **सार्वजनिक API परिवर्तन**
#### **Enum OrganizationChartLayoutType जोड़ा गया है**
Aspose.Slides.SmartArt.OrganizationChartLayoutType एन्‍उम एक संगठन चार्ट में चाइल्ड नोड्स के फ़ॉर्मेटिंग प्रकार को दर्शाता है।

#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts जोड़ा गया है**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts मेथड बुलेट्स सक्षम होने पर (जैसा PowerPoint पैराग्राफ बुलेट्स/नंबरिंग सक्षम करता है) प्रभावी पैराग्राफ इंडेंट और MarginLeft के लिए शून्य‑से‑भिन्न डिफ़ॉल्ट शिफ्ट सेट करता है। यदि बुलेट्स अक्षम हो, तो पैराग्राफ इंडेंट और MarginLeft को रीसेट करता है (जैसा PowerPoint अक्षम करने पर करता है)।

उदाहरण देखें [यहाँ](/slides/hi/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):

#### **Method IConnector.Reroute जोड़ा गया है**
Aspose.Slides.IConnector.Reroute मेथड कनेक्टर को इस प्रकार पुनःरूट करता है कि वह उन शैलियों के बीच सबसे छोटा संभव मार्ग ले। ऐसा करने के लिये, Reroute() मेथड StartShapeConnectionSiteIndex और EndShapeConnectionSiteIndex को बदल सकता है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
#### **Method IPresentation.GetSlideById जोड़ा गया है**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) मेथड स्लाइड Id द्वारा Slide, MasterSlide या LayoutSlide लौटाता है।

``` csharp
using System.Diagnostics;
using Aspose.Slides;


 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}
``` 
#### **Property IShape.ConnectionSiteCount जोड़ा गया है**
Aspose.Slides.IShape.ConnectionSiteCount प्रॉपर्टी आकृति पर मौजूद कनेक्शन साइटों की संख्या लौटाती है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


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
#### **Property ISmartArt.IsReversed जोड़ा गया है**
Aspose.Slides.SmartArt.ISmartArt.IsReversed प्रॉपर्टी SmartArt डायग्राम की दिशा (बाएँ‑से‑दाएँ LTR या दाएँ‑से‑बाएँ RTL) को प्राप्त करने या सेट करने की अनुमति देती है, यदि डायग्राम रिवर्सल को समर्थन देता है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArt.Nodes जोड़ा गया है**
Aspose.Slides.SmartArt.ISmartArt.Nodes प्रॉपर्टी SmartArt ऑब्जेक्ट में रूट नोड्स का संग्रह लौटाती है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // दूसरा मूल नोड चुनें

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden जोड़ा गया है**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden प्रॉपर्टी true लौटाती है यदि यह नोड डेटा मॉडल में एक छिपा नोड है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true लौटाता है

  if(hidden)

  {

    //कुछ क्रियाएँ या सूचनाएँ करें

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout जोड़ा गया है**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout प्रॉपर्टी वर्तमान नोड से संबंधित संगठन चार्ट प्रकार को प्राप्त करने या सेट करने की अनुमति देती है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Set Method for Property ISmartArt.Layout जोड़ा गया है**
Aspose.Slides.SmartArt.ISmartArt.Layout प्रॉपर्टी के लिए सेट मेथड जोड़ा गया है। यह मौजूदा डायग्राम के लेआउट प्रकार को बदलने की अनुमति देता है।

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Minor API Changes**
**यह Minor API Changes की सूची है:**

|Enum Aspose.Slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |deleted, unused property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |added |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |deleted as obsolete |

|Enum Aspose.Slides.BevelColorMode |हटाया गया, अप्रयुक्त एन्‍उम |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |हटाया गया, अप्रयुक्त प्रॉपर्टी |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |जोड़ा गया |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |हटाया गया |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |हटाया गया क्योंकि पुराना |