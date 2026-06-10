---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.4.0 verzióban
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migráció
- örökölt kód
- modern kód
- örökölt megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át az Aspose.Slides for .NET nyilvános API frissítéseit és a töréspont változásokat, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="primary" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) osztályt, metódust, tulajdonságot stb., valamint az Aspose.Slides for .NET 15.4.0 API-val bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API változások**
#### **Enum OrganizationChartLayoutType hozzá lett adva**
Az Aspose.Slides.SmartArt.OrganizationChartLayoutType enum a szervezeti diagram gyerekcsomópontjainak formázási típusát képviseli.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts hozzá lett adva**
Az Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts metódus alapértelmezett, nem nulla eltolásokat állít be a bekezdés behúzása (Indent) és bal margója (MarginLeft) számára, amikor a felsorolás be van kapcsolva (úgy, ahogy a PowerPoint is teszi, ha engedélyezi a bekezdés felsorolásait/ számozását). Ha a felsorolás ki van kapcsolva, akkor csak visszaállítja a bekezdés behúzását és bal margóját (úgy, ahogy a PowerPoint is teszi, ha letiltja a bekezdés felsorolásait/ számozását). Lásd a példákat [itt](/slides/hu/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute hozzá lett adva**
Az Aspose.Slides.IConnector.Reroute metódus átirányítja a kapcsolót, hogy a csatlakoztatott alakzatok között a lehető legrövidebb útvonalat vegye fel. Ennek érdekében a Reroute() metódus megváltoztathatja a StartShapeConnectionSiteIndex és EndShapeConnectionSiteIndex értékeket.
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
#### **Method IPresentation.GetSlideById hozzá lett adva**
Az Aspose.Slides.IPresentation.GetSlideById(System.UInt32) metódus slide‑azonosító alapján visszaad egy Slide, MasterSlide vagy LayoutSlide objektumot.
``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount hozzá lett adva**
Az Aspose.Slides.IShape.ConnectionSiteCount tulajdonság visszaadja az alakzaton lévő csatlakozási pontok számát.
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
#### **Property ISmartArt.IsReversed hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.IsReversed tulajdonság lehetővé teszi a SmartArt diagram állapotának lekérdezését vagy beállítását a (balról jobbra) LTR vagy (jobbról balra) RTL tekintetében, ha a diagram támogatja a megfordítást.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.Nodes tulajdonság visszaadja a SmartArt objektum gyökércsomópontjainak gyűjteményét.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // válassza ki a második gyökércsomópontot

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArtNode.IsHidden tulajdonság true értéket ad, ha ez a csomópont rejtett a adattárolóban.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true-t ad vissza

  if(hidden)

  {

    //végezzen néhány műveletet vagy értesítést

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout tulajdonság lehetővé teszi a jelenlegi csomóponthoz társított szervezeti diagram típus lekérdezését vagy beállítását.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.Layout tulajdonság beállító metódusa hozzá lett adva. Lehetővé teszi egy meglévő diagram elrendezéstípusának módosítását.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API Changes**
**Ez a kisebb API változások listája:**

|Enum Aspose.Slides.BevelColorMode |törölve, nem használt enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |törölve, nem használt property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |hozzáadva |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |törölve |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |törölve, mert elavult |