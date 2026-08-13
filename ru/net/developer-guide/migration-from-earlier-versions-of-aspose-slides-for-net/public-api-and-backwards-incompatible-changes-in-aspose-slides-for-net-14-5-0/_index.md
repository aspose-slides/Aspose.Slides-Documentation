---
title: Публичный API и изменения, несовместимые с обратной совместимостью в Aspose.Slides for .NET 14.5.0
linktitle: Aspose.Slides for .NET 14.5.0
type: docs
weight: 70
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Обзор обновлений публичного API и критических изменений в Aspose.Slides for .NET для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) классы, методы, свойства и т. д., любые новые [ограничения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) и прочие [изменения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) , введённые в Aspose.Slides for .NET 14.5.0 API.

{{% /alert %}} 
## **Публичный API и изменения, несовместимые с обратной совместимостью**
### **Добавленные интерфейсы, классы, свойства и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и класс PresentationInfo**
Представляет информацию о презентации.

- Свойство Boolean IsEncrypted возвращает True, если презентация зашифрована, иначе возвращает False.
- Свойство LoadFormat возвращает тип презентации.
#### **Добавлено свойство Aspose.Slides.IShape.IsGrouped**
Свойство Aspose.Slides.IShape.IsGrouped определяет, сгруппирована ли фигура.
#### **Добавлено свойство Aspose.Slides.IShape.ParentGroup**
Свойство Aspose.Slides.IShape.ParentGroup возвращает родительский объект GroupShape, если фигура находится в группе. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.AddGroupShape()**
Метод Aspose.Slides.IShapeCollection.AddGroupShape() создает новый объект GroupShape и добавляет его в конец коллекции.
Размер и положение кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры.
#### **Добавлен метод Aspose.Slides.IShapeCollection.Clear()**
Метод Aspose.Slides.IShapeCollection.Clear() удаляет все фигуры из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.InsertGroupShape(int) создает новый объект GroupShape и вставляет его в коллекцию в указанную позицию индекса.
Размер и положение кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры.
#### **Добавлены методы IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Эти методы позволяют получать информацию о файле презентации или потоке без полного загрузки презентации.
#### **Добавлено свойство IPresentationFactory PresentationFactory.Instance**
Это свойство позволяет разработчикам использовать функциональность фабрики без создания экземпляра.
### **Ограничения**
#### **Ограничения для IShape.Frame**
Для использования неопределённых значений в IShape.Frame добавлены ограничения. Код, который пытается присвоить неопределённый кадр свойству IShape.Frame, в большинстве случаев не имеет смысла (особенно когда родительский GroupShape вложен в несколько других {{GroupShape}}). Например:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Выбрасывает ArgumentException: значения кадра должны быть определены.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

или

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Выбрасывает ArgumentException: x, y, width и height должны быть определены.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Такой код может привести к неоднозначным ситуациям. Поэтому для использования неопределённых значений в IShape.Frame добавлены ограничения. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (и не могут быть установлены в float.NaN или NullableBool.NotDefined). Приведённый выше пример кода теперь бросает исключение ArgumentException.
Это относится к следующим случаям использования:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Параметры x, y, width и height не могут быть float.NaN, а flipH, flipV
// не могут быть NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// Такое же ограничение применяется ко всем методам, создающим фигуру:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Однако свойства кадра IShape.RawFrame могут быть неопределёнными. Это имеет смысл, когда фигура связана с placeholder'ом. Тогда неопределённые значения кадра фигуры переопределяются из родительской placeholder фигуры. Если родительского placeholder нет, фигура использует значения по умолчанию при вычислении эффективного кадра на основе IShape.RawFrame. Значения по умолчанию — 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Фигура связана с placeholder'ом
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // теперь фигура наследует значения x, y, height, flipH, flipV из placeholder и переопределяет width=100 и rotationAngle=0.
}
``` 
### **Изменённые свойства**
#### **Изменено имя и тип свойства Aspose.Slides.IShapeCollection.Parent**
- Тип свойства Aspose.Slides.IShapeCollection.Parent был изменён с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape наследуется от ISlideComponent, поэтому существующий код не требует адаптаций.
- Имя свойства Aspose.Slides.IShapeCollection.Parent изменено с Parent на ParentGroup.
#### **Изменён тип свойств Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Тип свойства Aspose.Slides.IShapeFrame.FlipH изменён с bool на NullableBool.
- Свойство IShape.Frame возвращает эффективный экземпляр IShapeFrame (все его свойства имеют определённые эффективные значения).
- Свойство IShape.RawFrame возвращает экземпляр IShapeFrame, у которого каждое свойство может быть неопределённым (особенно FlipH или FlipV могут иметь значение NullableBool.NotDefined).