---
title: Публичный API и обратно несовместимые изменения в Aspose.Slides для .NET 15.4.0
linktitle: Aspose.Slides для .NET 15.4.0
type: docs
weight: 150
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- миграция
- унаследованный код
- современный код
- традиционный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавлено](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) или [удалено](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) классы, методы, свойства и т.д., а также другие изменения, введённые в API Aspose.Slides для .NET 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Enum OrganizationChartLayoutType был добавлен**
Перечисление Aspose.Slides.SmartArt.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в организационной диаграмме.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts был добавлен**
Метод Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию ненулевых сдвигов для эффективных отступов абзаца (Indent) и левого поля (MarginLeft), когда маркеры включены (как PowerPoint делает при включении маркеров/нумерации абзацев). Если маркеры отключены, то просто сбрасывает отступ абзаца и левое поле (как PowerPoint делает при отключении маркеров/нумерации).
Смотрите примеры [здесь](/slides/ru/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute был добавлен**
Метод Aspose.Slides.IConnector.Reroute перенаправляет соединитель так, чтобы он занял самый короткий возможный путь между соединяемыми фигурами. При этом метод Reroute() может изменить свойства StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
Метод Aspose.Slides.IPresentation.GetSlideById(System.UInt32) возвращает объект Slide, MasterSlide или LayoutSlide по идентификатору слайда.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount была добавлена**
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
#### **Property ISmartArt.IsReversed была добавлена**
Свойство Aspose.Slides.SmartArt.ISmartArt.IsReversed позволяет получить или задать состояние диаграммы SmartArt относительно (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает обратную ориентацию.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes была добавлена**
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
#### **Property ISmartArtNode.IsHidden была добавлена**
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
#### **Property ISmartArtNode.OrganizationChartLayout была добавлена**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout позволяет получить или задать тип организационной диаграммы, связанный с текущим узлом.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout был добавлен**
Метод‑сеттер свойства Aspose.Slides.SmartArt.ISmartArt.Layout был добавлен. Он позволяет изменить тип макета существующей диаграммы.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Minor API Changes**
**Это список незначительных изменений API:**

|Enum Aspose.Slides.BevelColorMode |удалён, неиспользуемый enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |удалено, неиспользуемое свойство |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |добавлено |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |удалено |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |удалено как устаревшее |