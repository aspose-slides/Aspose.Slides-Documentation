---
title: Aspose.Slides for .NET 15.4.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'teki genel API güncellemeleri ve geriye uyumsuz değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for .NET 15.4.0 API'siyle getirilen eklenen [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) veya kaldırılan [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **Enum OrganizationChartLayoutType Eklendi**
Aspose.Slides.SmartArt.OrganizationChartLayoutType enum'u, bir organizasyon şemasındaki alt düğümlerin biçimlendirme türünü temsil eder.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts Eklendi**
Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts yöntemi, maddeler etkin olduğunda (PowerPoint'in paragraf maddelerini/numaralandırmasını etkinleştirdiğinde yaptığı gibi) etkili paragraf Indent ve MarginLeft için varsayılan sıfır olmayan kaymaları ayarlar. Maddeler devre dışı bırakıldığında ise sadece paragraf Indent ve MarginLeft sıfırlanır (PowerPoint'in paragraf maddelerini/numaralandırmasını devre dışı bıraktığında yaptığı gibi).

Örnekleri [burada](/slides/tr/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx) inceleyin:
#### **Method IConnector.Reroute Eklendi**
Aspose.Slides.IConnector.Reroute yöntemi, bağlayıcıyı bağladığı şekiller arasındaki olası en kısa yolu alacak şekilde yeniden yönlendirir. Bunu yapmak için Reroute() yöntemi StartShapeConnectionSiteIndex ve EndShapeConnectionSiteIndex değerlerini değiştirebilir.

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
#### **Method IPresentation.GetSlideById Eklendi**
Aspose.Slides.IPresentation.GetSlideById(System.UInt32) yöntemi, slide Id'sine göre bir Slide, MasterSlide veya LayoutSlide döndürür.

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
#### **Property IShape.ConnectionSiteCount Eklendi**
Aspose.Slides.IShape.ConnectionSiteCount özelliği, şeklin üzerindeki bağlantı noktalarının sayısını döndürür.

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
#### **Property ISmartArt.IsReversed Eklendi**
Aspose.Slides.SmartArt.ISmartArt.IsReversed özelliği, diyagram terslemeyi destekliyorsa, SmartArt diyagramının (soldan sağa) LTR veya (sağdan sola) RTL durumunu alıp ayarlamaya izin verir.

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
#### **Property ISmartArt.Nodes Eklendi**
Aspose.Slides.SmartArt.ISmartArt.Nodes özelliği, SmartArt nesnesindeki kök düğümlerin koleksiyonunu döndürür.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // ikinci kök düğümü seç

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.IsHidden Eklendi**
Aspose.Slides.SmartArt.ISmartArtNode.IsHidden özelliği, bu düğüm veri modelinde gizli bir düğüm ise true döndürür.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true döndürür

  if(hidden)

  {

    //bazı eylemler veya bildirimler

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Property ISmartArtNode.OrganizationChartLayout Eklendi**
Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout özelliği, mevcut düğümle ilişkili organizasyon şeması tipini alıp ayarlamaya izin verir.

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
#### **Property ISmartArt.Layout için Set Metodu Eklendi**
Aspose.Slides.SmartArt.ISmartArt.Layout özelliği için set metodu eklendi. Mevcut bir diyagramın düzen tipini değiştirmeye olanak tanır.

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
#### **Küçük API Değişiklikleri**
**Bu, Küçük API Değişikliklerinin Listesidir:**

|Enum Aspose.Slides.BevelColorMode |silindi, kullanılmayan enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |silindi, kullanılmayan property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |eklendi |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |silindi |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |eski olduğu için silindi |