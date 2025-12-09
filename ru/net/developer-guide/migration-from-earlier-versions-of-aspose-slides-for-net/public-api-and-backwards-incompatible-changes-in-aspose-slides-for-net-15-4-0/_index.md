---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.4.0
linktitle: Aspose.Slides для .NET 15.4.0
type: docs
weight: 150
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- миграция
- устаревший код
- современный код
- устаревший подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET для плавной миграции ваших решений презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Enum OrganizationChartLayoutType был добавлен**
Перечисление Aspose.Slides.SmartArt.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в организационной диаграмме.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts был добавлен**
Метод Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию ненулевых сдвигов для эффективных отступов абзаца и MarginLeft, когда включены маркеры (как это делает PowerPoint при включении маркеров/нумерации в абзаце). Если маркеры отключены, то просто сбрасываются отступ абзаца и MarginLeft (как PowerPoint делает при отключении маркеров/нумерации).

См. примеры [здесь](/slides/ru/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute был добавлен**
Метод Aspose.Slides.IConnector.Reroute перенаправляет соединитель так, чтобы он проходил кратчайшим возможным путём между соединяемыми фигурами. Для этого метод Reroute() может изменить свойства StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
#### **Method IPresentation.GetSlideById был добавлен**
Метод Aspose.Slides.IPresentation.GetSlideById(System.UInt32) возвращает Slide, MasterSlide или LayoutSlide по идентификатору слайда.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount был добавлен**
Свойство Aspose.Slides.IShape.ConnectionSiteCount возвращает количество точек соединения на фигуре.

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
#### **Property ISmartArt.IsReversed был добавлен**
Свойство Aspose.Slides.SmartArt.ISmartArt.IsReversed позволяет получить или задать состояние диаграммы SmartArt относительно (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает инверсию.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes был добавлен**
Свойство Aspose.Slides.SmartArt.ISmartArt.Nodes возвращает коллекцию корневых узлов в объекте SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // выбрать второй корневой узел

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden был добавлен**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.IsHidden возвращает true, если данный узел скрыт в модели данных.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //returns true

  if(hidden)

  {

    //do some actions or notifications

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout был добавлен**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout позволяет получить или задать тип организационной диаграммы, связанный с текущим узлом.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set method for property ISmartArt.Layout был добавлен**
Метод‑сеттер свойства Aspose.Slides.SmartArt.ISmartArt.Layout был добавлен. Он позволяет изменить тип макета существующей диаграммы.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API changes**
**Это список незначительных изменений API:**

|Enum Aspose.Slides.BevelColorMode|удален, неиспользуемый enum|
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode|удалено, неиспользуемое свойство|
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent|добавлено|
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent|удалено|
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle|удалено как устаревшее|