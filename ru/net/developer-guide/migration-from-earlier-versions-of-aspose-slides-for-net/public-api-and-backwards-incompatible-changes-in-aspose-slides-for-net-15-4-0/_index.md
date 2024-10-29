---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 15.4.0
type: docs
weight: 150
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
---

{{% alert color="primary" %}} 

Эта страница lists все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) или [удаленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) классы, методы, свойства и так далее, а также другие изменения, введенные в API Aspose.Slides для .NET 15.4.0.

{{% /alert %}} 
## **Изменения публичного API**
#### **Добавлен Enum OrganizationChartLayoutType**
Enum Aspose.Slides.SmartArt.OrganizationChartLayoutType представляет тип форматирования дочерних узлов в организационной диаграмме.
#### **Добавлен метод IBulletFormat.ApplyDefaultParagraphIndentsShifts**
Метод Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts устанавливает значения по умолчанию для эффективного отступа абзаца и MarginLeft, когда включены маркеры (как это делает PowerPoint, если включены маркеры/нумерация абзаца). Если маркеры отключены, просто сбросить отступ абзаца и MarginLeft (как это делает PowerPoint, если отключены маркеры/нумерация абзаца).

Смотрите примеры [здесь](/slides/ru/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Добавлен метод IConnector.Reroute**
Метод Aspose.Slides.IConnector.Reroute перенаправляет соединитель, чтобы он принимал кратчайший возможный путь между фигурами, которые он соединяет. Для этого метод Reroute() может изменить StartShapeConnectionSiteIndex и EndShapeConnectionSiteIndex.

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
#### **Добавлен метод IPresentation.GetSlideById**
Метод Aspose.Slides.IPresentation.GetSlideById(System.UInt32) возвращает слайд, MasterSlide или LayoutSlide по идентификатору слайда.

``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Добавлено свойство IShape.ConnectionSiteCount**
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
#### **Добавлено свойство ISmartArt.IsReversed**
Свойство Aspose.Slides.SmartArt.ISmartArt.IsReversed позволяет получать или устанавливать состояние диаграммы SmartArt в отношении (слева направо) LTR или (справа налево) RTL, если диаграмма поддерживает реверс.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Добавлено свойство ISmartArt.Nodes**
Свойство Aspose.Slides.SmartArt.ISmartArt.Nodes возвращает коллекцию корневых узлов в объекте SmartArt.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // выбрать второй корневой узел

  node.TextFrame.Text = "Второй корневой узел";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Добавлено свойство ISmartArtNode.IsHidden**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.IsHidden возвращает true, если этот узел является скрытым в модели данных.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; //возвращает true

  if(hidden)

  {

    //выполнить некоторые действия или уведомления

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Добавлено свойство ISmartArtNode.OrganizationChartLayout**
Свойство Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout позволяет получать или устанавливать тип организационной диаграммы, связанный с текущим узлом.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Добавлен метод set для свойства ISmartArt.Layout**
Метод set для свойства Aspose.Slides.SmartArt.ISmartArt.Layout был добавлен. Он позволяет изменять тип макета существующей диаграммы.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Незначительные изменения API**
**Это список незначительных изменений API:**

|Enum Aspose.Slides.BevelColorMode |удален, неиспользуемый enum |
| :- | :- |
|Свойство ThreeDFormatEffectiveData.BevelColorMode |удалено, неиспользуемое свойство |
|Свойство Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Свойство Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |добавлено |
|Свойство Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Наследование IParagraphFormatEffectiveData от ISlideComponent <br>Свойство Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Наследование IThreeDFormat от ISlideComponent |удалено |
|Свойство Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Свойство Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Свойство Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Свойство Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Свойство Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Свойство Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |удалены как устаревшие |