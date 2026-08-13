---
title: Nyilvános API és visszafelé nem kompatibilis változások az Aspose.Slides for .NET 15.4.0 verzióban
linktitle: Aspose.Slides for .NET 15.4.0
type: docs
weight: 150
url: /hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migráció
- régi kód
- modern kód
- régi megközelítés
- modern megközelítés
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tekintse át a nyilvános API frissítéseket és a visszafelé nem kompatibilis változásokat az Aspose.Slides for .NET-ben, hogy zökkenőmentesen migrálhassa PowerPoint PPT, PPTX és ODP prezentációs megoldásait."
---
{{% alert color="info" %}} 
Ez az oldal felsorolja az összes [hozzáadott](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) vagy [eltávolított](/slides/hu/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) osztályt, metódust, tulajdonságot stb., valamint a Aspose.Slides for .NET 15.4.0 API-vel bevezetett egyéb változásokat.
{{% /alert %}} 
## **Nyilvános API változások**
#### **Az Enum OrganizationChartLayoutType hozzá lett adva**
Az Aspose.Slides.SmartArt.OrganizationChartLayoutType felsoroló (enum) a szervezeti diagram gyermekcsomópontjainak formázási típusát képviseli.
#### **Az IBulletFormat.ApplyDefaultParagraphIndentsShifts metódus hozzá lett adva**
Az Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts metódus alapértelmezett nem nulla eltolásokat állít be a hatékony bekezdésbehúzás (Indent) és bal margó (MarginLeft) számára, ha a felsorolás engedélyezve van (úgy, ahogy a PowerPoint is teszi, ha engedélyezi a bekezdés felsorolásait/számozását). Ha a felsorolás le van tiltva, akkor csak visszaállítja a bekezdésbehúzást és a bal margót (úgy, ahogy a PowerPoint is teszi, ha letiltja a bekezdés felsorolásait/számozását).
Lásd a példákat [itt](/slides/hu/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Az IConnector.Reroute metódus hozzá lett adva**
Az Aspose.Slides.IConnector.Reroute metódus átirányítja a csatlót, hogy a két alakzat között a lehető legrövidebb útvonalat vegye. Ennek érdekében a Reroute() metódus megváltoztathatja a StartShapeConnectionSiteIndex és EndShapeConnectionSiteIndex értékeket.
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
#### **Az IPresentation.GetSlideById metódus hozzá lett adva**
Az Aspose.Slides.IPresentation.GetSlideById(System.UInt32) metódus egy Slide, MasterSlide vagy LayoutSlide objektumot ad vissza a diavetítés azonosítója alapján.
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
#### **Az IShape.ConnectionSiteCount tulajdonság hozzá lett adva**
Az Aspose.Slides.IShape.ConnectionSiteCount tulajdonság visszaadja a forma csatlakozási pontjainak számát.
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
#### **Az ISmartArt.IsReversed tulajdonság hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.IsReversed tulajdonság lehetővé teszi a SmartArt diagram (balról jobbra) LTR vagy (jobbról balra) RTL állapotának lekérdezését vagy beállítását, amennyiben a diagram támogatja a fordítást.
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
#### **Az ISmartArt.Nodes tulajdonság hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.Nodes tulajdonság visszaadja a SmartArt objektum gyökércsomópontjainak gyűjteményét.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // válassza ki a második gyökércsomópontot

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Az ISmartArtNode.IsHidden tulajdonság hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArtNode.IsHidden tulajdonság true értéket ad vissza, ha ez a csomópont rejtett a adatmodellben.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //true értéket ad vissza

  if(hidden)

  {

    //végezzen néhány műveletet vagy értesítést

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Az ISmartArtNode.OrganizationChartLayout tulajdonság hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout tulajdonság lehetővé teszi a jelenlegi csomóponthoz kapcsolódó szervezeti diagram típusának lekérdezését vagy beállítását.
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
#### **Az ISmartArt.Layout tulajdonság beállító metódusa hozzá lett adva**
Az Aspose.Slides.SmartArt.ISmartArt.Layout tulajdonság beállító metódusa hozzá lett adva. Lehetővé teszi egy meglévő diagram elrendezéstípusának módosítását.
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
#### **Kisebb API változások**
**Ez a kisebb API változások listája:**

|Enum Aspose.Slides.BevelColorMode |törölve, nem használt enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |törölve, nem használt tulajdonság |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |hozzáadva |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |törölve |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |törölve, elavultként |