---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 15.4.0
linktitle: Aspose.Slides dla .NET 15.4.0
type: docs
weight: 150
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przegląd aktualizacji publicznego API i zmian łamiących w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [added](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) lub [removed](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) klasy, metody, właściwości i tak dalej, oraz inne zmiany wprowadzone w API Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Zmiany publicznego API**
#### **Enum OrganizationChartLayoutType został dodany**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType reprezentuje typ formatowania węzłów podrzędnych w diagramie organizacyjnym.
#### **Metoda IBulletFormat.ApplyDefaultParagraphIndentsShifts została dodana**
Metoda Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ustawia domyślne niezerowe przesunięcia dla wcięcia akapitu (Indent) i lewego marginesu (MarginLeft), gdy włączone są wypunktowania (tak jak PowerPoint robi, jeśli włączone są wypunktowania/numeracja w akapicie). Jeśli wypunktowania są wyłączone, metoda resetuje wcięcie akapitu i lewy margines (tak jak PowerPoint robi, jeśli wyłączone są wypunktowania/numeracja w akapicie).

Zobacz przykłady [here](/slides/pl/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Metoda IConnector.Reroute została dodana**
Metoda Aspose.Slides.IConnector.Reroute przekierowuje łącznik tak, aby przyjął najkrótszą możliwą ścieżkę pomiędzy połączonymi kształtami. W tym celu metoda Reroute() może zmienić właściwości StartShapeConnectionSiteIndex i EndShapeConnectionSiteIndex.

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
#### **Metoda IPresentation.GetSlideById została dodana**
Metoda Aspose.Slides.IPresentation.GetSlideById(System.UInt32) zwraca obiekt Slide, MasterSlide lub LayoutSlide na podstawie identyfikatora slajdu.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Właściwość IShape.ConnectionSiteCount została dodana**
Właściwość Aspose.Slides.IShape.ConnectionSiteCount zwraca liczbę miejsc połączeń na kształcie.

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
#### **Właściwość ISmartArt.IsReversed została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArt.IsReversed umożliwia pobranie lub ustawienie stanu diagramu SmartArt względem (od lewej do prawej) LTR lub (od prawej do lewej) RTL, jeśli diagram obsługuje odwrócenie.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Właściwość ISmartArt.Nodes została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArt.Nodes zwraca kolekcję węzłów głównych w obiekcie SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // wybierz drugi węzeł główny

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Właściwość ISmartArtNode.IsHidden została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.IsHidden zwraca true, jeśli ten węzeł jest ukryty w modelu danych.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //zwraca true

  if(hidden)

  {

    //wykonaj akcje lub powiadomienia

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Właściwość ISmartArtNode.OrganizationChartLayout została dodana**
Właściwość Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout umożliwia pobranie lub ustawienie typu wykresu organizacyjnego powiązanego z bieżącym węzłem.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Metoda set dla właściwości ISmartArt.Layout została dodana**
Metoda set dla właściwości Aspose.Slides.SmartArt.ISmartArt.Layout została dodana. Umożliwia zmianę typu układu istniejącego diagramu.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Mniejsze zmiany API**
**To jest lista mniejszych zmian API:**

|Enum Aspose.Slides.BevelColorMode |usunięty, nieużywany enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |usunięta, nieużywana właściwość |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |dodane |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |usunięte |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |usunięte jako przestarzałe |