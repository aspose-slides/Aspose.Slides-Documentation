---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.4.0
linktitle: Aspose.Slides pro .NET 15.4.0
type: docs
weight: 150
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozbíjející změny v Aspose.Slides pro .NET, abyste hladce migrovali svá řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="info" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) nebo [odebráno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) třídy, metody, vlastnosti a podobně, a další změny zavedené v API Aspose.Slides pro .NET 15.4.0 API.

{{% /alert %}} 
## **Změny veřejného API**
#### **Enum OrganizationChartLayoutType byl přidán**
Výčtový typ Aspose.Slides.SmartArt.OrganizationChartLayoutType představuje typ formátování podřízených uzlů v organizačním diagramu.
#### **Metoda IBulletFormat.ApplyDefaultParagraphIndentsShifts byla přidána**
Metoda Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts nastavuje výchozí nenulové posuny pro efektivní odsazení odstavce a levý okraj, když jsou zapnuté odrážky (podobně jako PowerPoint, když je v prezentaci povoleno odrážkování/číslování odstavců). Pokud jsou odrážky vypnuté, metoda pouze resetuje odsazení odstavce a levý okraj (podobně jako PowerPoint, když je odrážkování/číslování odstavců vypnuto).

Viz příklady [zde](/slides/cs/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metoda IConnector.Reroute byla přidána**
Metoda Aspose.Slides.IConnector.Reroute přepočítá spojku tak, aby zvolila nejkratší možnou cestu mezi tvary, které spojuje. K tomu může metoda Reroute() změnit hodnoty StartShapeConnectionSiteIndex a EndShapeConnectionSiteIndex.

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
#### **Metoda IPresentation.GetSlideById byla přidána**
Metoda Aspose.Slides.IPresentation.GetSlideById(System.UInt32) vrací Slide, MasterSlide nebo LayoutSlide podle ID snímku.

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
#### **Vlastnost IShape.ConnectionSiteCount byla přidána**
Vlastnost Aspose.Slides.IShape.ConnectionSiteCount vrací počet připojovacích míst na tvaru.

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
#### **Vlastnost ISmartArt.IsReversed byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArt.IsReversed umožňuje získat nebo nastavit stav diagramu SmartArt s ohledem na (zleva doprava) LTR nebo (zprava doleva) RTL, pokud diagram podporuje převrácení.

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
#### **Vlastnost ISmartArt.Nodes byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArt.Nodes vrací kolekci kořenových uzlů v objektu SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // vyberte druhý kořenový uzel

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Vlastnost ISmartArtNode.IsHidden byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.IsHidden vrací true, pokud je tento uzel skrytý v datovém modelu.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //vrátí true

  if(hidden)

  {

    //proveďte nějaké akce nebo upozornění

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Vlastnost ISmartArtNode.OrganizationChartLayout byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout umožňuje získat nebo nastavit typ organizačního diagramu přiřazeného k aktuálnímu uzlu.

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
#### **Metoda set pro vlastnost ISmartArt.Layout byla přidána**
Metoda set pro vlastnost Aspose.Slides.SmartArt.ISmartArt.Layout byla přidána. Umožňuje změnit typ rozvržení existujícího diagramu.

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
#### **Menší změny API**
**Toto je seznam menších změn API:**

|Enum Aspose.Slides.BevelColorMode |odstraněn, nepoužívaný výčet |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |odstraněn, nepoužívaná vlastnost |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |přidáno |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |odstraněno |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |odstraněno jako zastaralé |