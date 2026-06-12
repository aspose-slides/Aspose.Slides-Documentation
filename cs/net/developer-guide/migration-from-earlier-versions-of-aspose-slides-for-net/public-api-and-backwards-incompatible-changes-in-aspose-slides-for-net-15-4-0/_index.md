---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 15.4.0
linktitle: Aspose.Slides pro .NET 15.4.0
type: docs
weight: 150
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migrace
- starý kód
- moderní kód
- starý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prohlédněte si aktualizace veřejného API a rozdíly v Aspose.Slides pro .NET, abyste hladce migrovali své řešení prezentací PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidáno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) nebo [odstraněno](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) třídy, metody, vlastnosti a podobně a další změny zavedené v Aspose.Slides pro .NET 15.4.0 API.

{{% /alert %}} 
## **Změny veřejného API**
#### **Výčet OrganizationChartLayoutType byl přidán**
Výčet Aspose.Slides.SmartArt.OrganizationChartLayoutType představuje typ formátování podřízených uzlů v organizačním schématu.
#### **Metoda IBulletFormat.ApplyDefaultParagraphIndentsShifts byla přidána**
Metoda Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts nastaví výchozí nenulové posuny pro efektivní odsazení odstavce (Indent) a levý okraj (MarginLeft), když jsou odrážky povoleny (jako to dělá PowerPoint při zapnutí odrážek/číslování odstavců). Pokud jsou odrážky zakázány, metoda pouze resetuje odsazení odstavce a levý okraj (jako to dělá PowerPoint při vypnutí odrážek/číslování).
Viz příklady [zde](/slides/cs/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metoda IConnector.Reroute byla přidána**
Metoda Aspose.Slides.IConnector.Reroute přesměruje konektor tak, aby zvolila nejkratší možnou cestu mezi spojenými tvary. K tomu může metoda Reroute() změnit hodnoty StartShapeConnectionSiteIndex a EndShapeConnectionSiteIndex.

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
#### **Metoda IPresentation.GetSlideById byla přidána**
Metoda Aspose.Slides.IPresentation.GetSlideById(System.UInt32) vrací Slide, MasterSlide nebo LayoutSlide podle ID snímku.

``` csharp

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
Vlastnost Aspose.Slides.SmartArt.ISmartArt.IsReversed umožňuje získat nebo nastavit stav diagramu SmartArt vzhledem k (zleva doprava) LTR nebo (zprava doleva) RTL, pokud diagram podporuje obrácení.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Vlastnost ISmartArt.Nodes byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArt.Nodes vrací kolekci kořenových uzlů v objektu SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // vyberte druhý kořenový uzel

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Vlastnost ISmartArtNode.IsHidden byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.IsHidden vrací true, pokud je tento uzel skrytý v datovém modelu.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //vrací true

  if(hidden)

  {

    //proveďte nějaké akce nebo oznámení

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Vlastnost ISmartArtNode.OrganizationChartLayout byla přidána**
Vlastnost Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout umožňuje získat nebo nastavit typ organizačního diagramu přiřazený k aktuálnímu uzlu.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Metoda set pro vlastnost ISmartArt.Layout byla přidána**
Metoda set pro vlastnost Aspose.Slides.SmartArt.ISmartArt.Layout byla přidána. Umožňuje změnit typ rozvržení existujícího diagramu.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Menší změny API**
**Toto je seznam menších změn API:**

|Výčet Aspose.Slides.BevelColorMode |odstraněno, nepoužívaný výčet |
| :- | :- |
|Vlastnost ThreeDFormatEffectiveData.BevelColorMode |odstraněno, nepoužívaná vlastnost |
|Vlastnost Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Vlastnost Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |přidáno |
|Vlastnost Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Dědičnost IParagraphFormatEffectiveData z ISlideComponent <br>Vlastnost Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Dědičnost IThreeDFormat z ISlideComponent |odstraněno |
|Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Vlastnost Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |odstraněno jako zastaralé |