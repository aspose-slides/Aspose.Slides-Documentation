---
title: Публичный API и несовместимые изменения в Aspose.Slides for .NET 15.4.0
linktitle: Aspose.Slides для .NET 15.4.0
type: docs
weight: 150
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for .NET для плавной миграции ваших решений для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) или [удалённые](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) классы, методы, свойства и т.п., а также другие изменения, введённые в API Aspose.Slides for .NET 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Enum OrganizationChartLayoutType добавлен**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в диаграмме организационной структуры.
#### **Метод IBulletFormat.ApplyDefaultParagraphIndentsShifts добавлен**
Метод Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts задаёт значения смещений абзаца Indent и MarginLeft по умолчанию, когда маркеры включены (как делает PowerPoint при включении маркеров/нумерации). Если маркеры отключены, просто сбрасываются значения Indent и MarginLeft (как делает PowerPoint при отключении маркеров/нумерации).

См. примеры [здесь](/slides/ru/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Метод IConnector.Reroute добавлен**
Метод Aspose.Slides.IConnector.Reroute перенаправляет соединитель так, чтобы он проходил кратчайшим возможным маршрутом между соединяемыми фигурами. Для этого метод Reroute() может изменить свойства StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
#### **Метод IPresentation.GetSlideById добавлен**
Метод Aspose.Slides.IPresentation.GetSlideById(System.UInt32) возвращает Slide, MasterSlide или LayoutSlide по идентификатору слайда.

``` csharp
using (Presentation presentation = new Presentation())
{
    uint id = presentation.Slides[0].SlideId;
    IBaseSlide slide = presentation.GetSlideById(id);
    Debug.Assert(presentation.Slides[0] == slide);
}
``` 
#### **Свойство IShape.ConnectionSiteCount добавлено**
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
#### **Свойство ISmartArt.IsReversed добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArt.IsReversed позволяет получить или задать направление диаграммы SmartArt (слева направо LTR или справа налево RTL), если диаграмма поддерживает инверсию.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
  smart.IsReversed = true;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Свойство ISmartArt.Nodes добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArt.Nodes возвращает коллекцию корневых узлов объекта SmartArt.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);
  ISmartArtNode node = smart.Nodes[1]; // выбрать второй корневой узел
  node.TextFrame.Text = "Second root node";
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Свойство ISmartArtNode.IsHidden добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.IsHidden возвращает true, если данный узел скрыт в модели данных.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
  ISmartArtNode node = smart.AllNodes.AddNode();
  bool hidden = node.IsHidden; // возвращает true
  if(hidden)
  {
    // выполнить какие‑то действия или уведомления
  }
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Свойство ISmartArtNode.OrganizationChartLayout добавлено**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout позволяет получить или задать тип организационной схемы, связанный с текущим узлом.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Метод set для свойства ISmartArt.Layout добавлен**
Метод set для свойства Aspose.Slides.SmartArt.ISmartArt.Layout добавлен. Он позволяет изменить тип макета существующей диаграммы.

``` csharp
using (Presentation pres = new Presentation())
{
  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
  smart.Layout = SmartArtLayoutType.BasicProcess;
  pres.Save("out.pptx", Export.SaveFormat.Pptx);
}
``` 
#### **Мелкие изменения API**
**Это список мелких изменений API:**

|Enum Aspose.Slides.BevelColorMode |deleted, unused enum |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |deleted, unused property |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |added |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |deleted |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |deleted as obsolete |