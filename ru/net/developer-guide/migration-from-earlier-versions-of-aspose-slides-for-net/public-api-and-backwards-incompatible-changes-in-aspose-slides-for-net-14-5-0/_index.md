---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для .NET 14.5.0
type: docs
weight: 70
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) классы, методы, свойства и так далее, любые новые [ограничения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) и другие [изменения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) введенные с API Aspose.Slides для .NET 14.5.0.

{{% /alert %}} 
## **Публичный API и изменения, несовместимые с предыдущими версиями**
### **Добавленные интерфейсы, классы, свойства и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и класс PresentationInfo**
Представляет информацию о презентации.

- Булево свойство IsEncrypted принимает значение True, если презентация зашифрована, в противном случае - False.
- Свойство LoadFormat получает тип презентации.
#### **Добавлено свойство Aspose.Slides.IShape.IsGrouped**
Свойство Aspose.Slides.IShape.IsGrouped определяет, является ли фигура группой.
#### **Добавлено свойство Aspose.Slides.IShape.ParentGroup**
Свойство Aspose.Slides.IShape.ParentGroup возвращает родительский объект GroupShape, если фигура находится в группе. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.AddGroupShape()**
Метод Aspose.Slides.IShapeCollection.AddGroupShape() создает новую GroupShape и добавляет ее в конец коллекции.
Размер и положение рамки GroupShape будут подогнаны под содержимое при добавлении новой фигуры.
#### **Добавлен метод Aspose.Slides.IShapeCollection.Clear()**
Метод Aspose.Slides.IShapeCollection.Clear() удаляет все фигуры из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.InsertGroupShape(int) создает новую GroupShape и вставляет ее в коллекцию по указанному индексу.
Размер и положение рамки GroupShape будут подогнаны под содержимое при добавлении новой фигуры.
#### **Добавлены методы IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Эти методы позволяют получить информацию о файле или потоке презентации без полной загрузки презентации.
#### **Добавлено свойство IPresentationFactory PresentationFactory.Instance**
Это свойство позволяет разработчикам использовать функциональность фабрики без инстанцирования.
### **Ограничения**
#### **Ограничения для IShape.Frame**
Добавлены ограничения на использование неопределенных значений для IShape.Frame. Код, который пытается назначить неопределенную рамку для IShape.Frame, не имеет смысла в большинстве случаев (особенно когда родительский GroupShape содержит несколько вложенных других {{GroupShape}}). Например:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);

``` 

или

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Такой код может привести к неясным ситуациям. Поэтому добавлены ограничения для использования неопределенных значений для IShape.Frame. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (и не установлены в float.NaN или NullableBool.NotDefined). Пример кода выше теперь вызывает исключение ArgumentException.
Это применимо к следующим случаям использования:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Не может быть неопределенной

IShapeCollection shapes = ...;

// параметры x, y, width, height не могут быть float.NaN:

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

Но свойства рамки IShape.RawFrame могут быть неопределенными. Это имеет смысл, когда фигура связана с заполнительом. Тогда неопределенные значения рамки фигуры заменяются значениями родительской фигуры-заполнителя. Если родительской фигуры-заполнителя нет, то эта фигура использует значения по умолчанию при оценке эффективной рамки на основе своего IShape.RawFrame. Значения по умолчанию равны 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

``` csharp

 IShape shape = ...; // фигура связана с заполнителем

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// теперь фигура унаследует значения x, y, height, flipH, flipV от заполнителя и переопределит width=100 и rotationAngle=0.

``` 
### **Измененные свойства**
#### **Изменено название и тип свойства Aspose.Slides.IShapeCollection.Parent**
- Тип свойства Aspose.Slides.IShapeCollection.Parent был изменен с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape является потомком ISlideComponent, поэтому существующий код не требует адаптации.
- Название свойства Aspose.Slides.IShapeCollection.Parent было изменено с Parent на ParentGroup.
#### **Изменены типы свойств Aspose.Slides.IShapeFrame.FlipH, .FlipV**
- Тип свойства Aspose.Slides.IShapeFrame.FlipH был изменен с bool на NullableBool.
- Свойство IShape.Frame возвращает эффективный экземпляр IShapeFrame (все его свойства имеют определенные эффективные значения).
- Свойство IShape.RawFrame возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределенное значение (особенно FlipH или FlipV могут иметь значение NullableBool.NotDefined).