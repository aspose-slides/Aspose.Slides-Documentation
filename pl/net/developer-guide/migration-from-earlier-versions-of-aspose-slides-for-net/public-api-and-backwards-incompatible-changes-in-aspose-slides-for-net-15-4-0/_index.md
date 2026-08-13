---
title: Publiczne API i niezgodne zmiany wsteczne w Aspose.Slides dla .NET 15.4.0
linktitle: Aspose.Slides dla .NET 15.4.0
type: docs
weight: 150
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- podejście nowoczesne
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany łamiące w Aspose.Slides dla .NET, aby płynnie migrować swoje rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="info" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) lub [usunięte](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Enum OrganizationChartLayoutType został dodany**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType reprezentuje typ formatowania węzłów podrzędnych w diagramie organizacyjnym.
#### **Metoda IBulletFormat.ApplyDefaultParagraphIndentsShifts została dodana**
Metoda Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ustawia domyślne, niezerowe przesunięcia dla efektywnego wcięcia akapitu i lewego marginesu, gdy włączone są wypunktowania (tak jak PowerPoint robi to po włączeniu wypunktowań/numeracji akapitu). Jeśli wypunktowania są wyłączone, metoda resetuje wcięcie akapitu i lewy margines (tak jak PowerPoint robi to po wyłączeniu wypunktowań/numeracji).

Zobacz przykłady [tutaj](/slides/pl/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metoda IConnector.Reroute została dodana**
Metoda Aspose.Slides.IConnector.Reroute przekierowuje łącze tak, aby przyjmowało najkrótszą możliwą ścieżkę między kształtami, które łączy. W tym celu metoda Reroute() może zmienić wartości StartShapeConnectionSiteIndex i EndShapeConnectionSiteIndex.

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
#### **Metoda IPresentation.GetSlideById została dodana**
Metoda Aspose.Slides.IPresentation.GetSlideById(System.UInt32) zwraca obiekt Slide, MasterSlide lub LayoutSlide na podstawie identyfikatora slajdu.

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
#### **Właściwość IShape.ConnectionSiteCount została dodana**
Właściwość Aspose.Slides.IShape.ConnectionSiteCount zwraca liczbę punktów połączeń na kształcie.

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
#### **Właściwość ISmartArt.IsReversed została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArt.IsReversed umożliwia odczyt i ustawienie stanu diagramu SmartArt względem (od lewej do prawej) LTR lub (od prawej do lewej) RTL, jeśli diagram obsługuje odwrócenie.

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
#### **Właściwość ISmartArt.Nodes została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArt.Nodes zwraca kolekcję węzłów głównych w obiekcie SmartArt.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // wybierz drugi węzeł główny

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", SaveFormat.Pptx);

}

``` 
#### **Właściwość ISmartArtNode.IsHidden została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.IsHidden zwraca true, jeśli ten węzeł jest ukryty w modelu danych.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;


 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //zwraca true

  if(hidden)

  {

    //wykonaj niektóre akcje lub powiadomienia

  }

  pres.Save("out.pptx", SaveFormat.Pptx);

}
``` 
#### **Właściwość ISmartArtNode.OrganizationChartLayout została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout umożliwia odczyt i ustawienie typu wykresu organizacyjnego powiązanego z bieżącym węzłem.

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
#### **Metoda set dla właściwości ISmartArt.Layout została dodana**
Metoda set dla właściwości Aspose.Slides.SmartArt.ISmartArt.Layout została dodana. Umożliwia zmianę typu układu istniejącego diagramu.

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
#### **Mniejsze zmiany API**
**To jest lista mniejszych zmian API:**

|Enum Aspose.Slides.BevelColorMode |usunięty, nieużywany enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |usunięta, nieużywana właściwość |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |dodano |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |usunięto |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |usunięto jako przestarzałe |