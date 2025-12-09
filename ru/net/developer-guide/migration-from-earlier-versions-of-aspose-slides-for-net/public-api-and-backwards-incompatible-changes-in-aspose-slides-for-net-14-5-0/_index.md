---
title: Публичный API и несовместимые изменения в Aspose.Slides для .NET 14.5.0
linktitle: Aspose.Slides для .NET 14.5.0
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
description: "Обзор обновлений публичного API и несовместимых изменений в Aspose.Slides для .NET, позволяющих без проблем мигрировать решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [added](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) классы, методы, свойства и т.д., любые новые [restrictions](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) и другие [changes](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) , введённые в API Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **Публичный API и несовместимые изменения**
### **Добавленные интерфейсы, классы, свойства и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и класс PresentationInfo**
Представляет информацию о презентации.

- Булево свойство IsEncrypted возвращает True, если презентация зашифрована, иначе возвращает False.
- Свойство LoadFormat LoadFormat возвращает тип презентации.
#### **Добавлено свойство Aspose.Slides.IShape.IsGrouped**
Свойство Aspose.Slides.IShape.IsGrouped определяет, сгруппирована ли фигура.
#### **Добавлено свойство Aspose.Slides.IShape.ParentGroup**
Свойство Aspose.Slides.IShape.ParentGroup возвращает объект родительской GroupShape, если фигура сгруппирована. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.AddGroupShape()**
Метод Aspose.Slides.IShapeCollection.AddGroupShape() создаёт новую GroupShape и добавляет её в конец коллекции.
Размер и позиция рамки GroupShape будут подогнаны к содержимому при добавлении новой фигуры.
#### **Добавлен метод Aspose.Slides.IShapeCollection.Clear()**
Метод Aspose.Slides.IShapeCollection.Clear() удаляет все фигуры из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.InsertGroupShape(int) создаёт новую GroupShape и вставляет её в коллекцию в указанную позицию индекса.
Размер и позиция рамки GroupShape будут подогнаны к содержимому при добавлении новой фигуры.
#### **Добавлены методы IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Эти методы позволяют получать информацию о файле презентации или потоке без полной загрузки презентации.
#### **Добавлено свойство IPresentationFactory PresentationFactory.Instance**
Это свойство позволяет разработчикам использовать функциональность фабрики без её инстанцирования.
### **Ограничения**
#### **Ограничения для IShape.Frame**
Для использования неопределённых значений в IShape.Frame добавлены ограничения. Код, который пытается присвоить неопределённую рамку IShape.Frame, обычно не имеет смысла (особенно когда родительская GroupShape вложена в несколько других {{GroupShape}}). Например:

```csharp
IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

или

```csharp
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Такой код может привести к неясным ситуациям. Поэтому добавлены ограничения для использования неопределённых значений в IShape.Frame. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (и не должны быть float.NaN или NullableBool.NotDefined). Приведённый выше пример кода теперь бросает исключение ArgumentException.
Это относится к следующим сценариям:

```csharp
IShape shape = ...;

shape.Frame = ...; // Не может быть неопределённым

IShapeCollection shapes = ...;

// Параметры x, y, width, height не могут быть float.NaN:

{
    shapes.AddAudioFrameCD(...);
    shapes.AddAudioFrameEmbedded(...);
    shapes.AddAudioFrameLinked(...);
    shapes.AddAutoShape(...);
    shapes.AddChart(...);
    shapes.AddConnector(...);
    shapes.AddOleObjectFrame(...);
    shapes.AddPictureFrame(...);
    shapes.AddSmartArt(...);
    shapes.AddTable(...);
    shapes.AddVideoFrame(...);
    shapes.InsertAudioFrameEmbedded(...);
    shapes.InsertAudioFrameLinked(...);
    shapes.InsertAutoShape(...);
    shapes.InsertChart(...);
    shapes.InsertConnector(...);
    shapes.InsertOleObjectFrame(...);
    shapes.InsertPictureFrame(...);
    shapes.InsertTable(...);
    shapes.InsertVideoFrame(...);
}
``` 

Но свойства IShape.RawFrame могут быть неопределёнными. Это имеет смысл, когда фигура связана с заполнительем. Тогда неопределённые значения рамки фигуры переопределяются из родительской фигуры‑заполнителя. Если родительского заполнителя нет, фигура использует значения по умолчанию при вычислении эффективной рамки на основе IShape.RawFrame. Значения по умолчанию: 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

```csharp
IShape shape = ...; // фигура связана с заполнительем
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// теперь фигура наследует x, y, height, flipH, flipV из заполнятеля и переопределяет width=100 и rotationAngle=0.
``` 
### **Изменённые свойства**
#### **Изменено имя и тип свойства Aspose.Slides.IShapeCollection.Parent**
- Тип свойства Aspose.Slides.IShapeCollection.Parent изменён с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape наследует ISlideComponent, поэтому существующему коду адаптации не требуются.
- Имя свойства Aspose.Slides.IShapeCollection.Parent изменено с Parent на ParentGroup.
#### **Изменён тип свойств Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Тип свойства Aspose.Slides.IShapeFrame.FlipH изменён с bool на NullableBool.
- Свойство IShape.Frame возвращает эффективный экземпляр IShapeFrame (у всех его свойств определены эффективные значения).
- Свойство IShape.RawFrame возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределённое значение (особенно FlipH или FlipV могут иметь значение NullableBool.NotDefined).