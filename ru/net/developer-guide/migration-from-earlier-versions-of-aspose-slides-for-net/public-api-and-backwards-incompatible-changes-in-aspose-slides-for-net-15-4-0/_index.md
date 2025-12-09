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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides для .NET 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Перечисление OrganizationChartLayoutType было добавлено**
Перечисление Aspose.Slides.SmartArt.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в организационной диаграмме.
#### **Метод IBulletFormat.ApplyDefaultParagraphIndentsShifts был добавлен**
Метод Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию ненулевых смещений для эффективного абзаца Indent и MarginLeft, когда маркеры включены (как делает PowerPoint при включении абзацев с маркерами/нумерацией). Если маркеры отключены, то просто сбрасывает Indent и MarginLeft абзаца (как делает PowerPoint при отключении маркеров/нумерации).

Смотрите примеры [здесь](/slides/ru/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Метод IConnector.Reroute был добавлен**
Метод Aspose.Slides.IConnector.Reroute перенаправляет соединитель так, чтобы он занял самый короткий возможный путь между соединяемыми фигурами. Для этого метод Reroute() может изменить свойства StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
#### **Метод IPresentation.GetSlideById был добавлен**
Метод Aspose.Slides.IPresentation.GetSlideById(System.UInt32) возвращает Slide, MasterSlide или LayoutSlide по идентификатору слайда.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Свойство IShape.ConnectionSiteCount было добавлено**
Свойство Aspose.Slides.IShape.ConnectionSiteCount возвращает количество точек подключения на фигуре.

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
#### **Свойство ISmartArt.IsReversed было добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArt.IsReversed позволяет получить или установить состояние диаграммы SmartArt относительно (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает обратный порядок.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Свойство ISmartArt.Nodes было добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArt.Nodes возвращает коллекцию корневых узлов в объекте SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // select second root node

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Свойство ISmartArtNode.IsHidden было добавлено**
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
#### **Свойство ISmartArtNode.OrganizationChartLayout было добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout позволяет получить или установить тип организационной диаграммы, связанный с текущим узлом.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Метод set для свойства ISmartArt.Layout был добавлен**
Метод set для свойства Aspose.Slides.SmartArt.ISmartArt.Layout был добавлен. Он позволяет изменить тип макета существующей диаграммы.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API changes**
**Это список небольших изменений API:**

|Enum Aspose.Slides.BevelColorMode |удалено, неиспользуемое перечисление |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |удалено, неиспользуемое свойство |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |добавлено |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |удалено |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |удалено как устаревшее |