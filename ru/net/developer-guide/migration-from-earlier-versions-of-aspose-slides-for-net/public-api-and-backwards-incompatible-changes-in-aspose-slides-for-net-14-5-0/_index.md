---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 14.5.0
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
description: "Обзор обновлений публичного API и разрывных изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) классы, методы, свойства и т.д., любые новые [ограничения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) и другие [изменения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) , введённые в API Aspose.Slides для .NET 14.5.0.

{{% /alert %}} 
## **Публичный API и обратные несовместимые изменения**
### **Добавлены интерфейсы, классы, свойства и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и класс PresentationInfo**
Представляет информацию о презентации.

- Булево свойство IsEncrypted возвращает True, если презентация зашифрована, иначе возвращает False.  
- Свойство LoadFormat получает тип презентации.  
#### **Добавлено свойство Aspose.Slides.IShape.IsGrouped**
Свойство Aspose.Slides.IShape.IsGrouped определяет, находится ли объект в группе.  
#### **Добавлено свойство Aspose.Slides.IShape.ParentGroup**
Свойство Aspose.Slides.IShape.ParentGroup возвращает объект родительской GroupShape, если объект находится в группе. В противном случае возвращает null.  
#### **Добавлен метод Aspose.Slides.IShapeCollection.AddGroupShape()**
Метод Aspose.Slides.IShapeCollection.AddGroupShape() создаёт новый GroupShape и добавляет его в конец коллекции.  
Размер и позиция кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры.  
#### **Добавлен метод Aspose.Slides.IShapeCollection.Clear()**
Метод Aspose.Slides.IShapeCollection.Clear() удаляет все фигуры из коллекции.  
#### **Добавлен метод Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.InsertGroupShape(int) создаёт новый GroupShape и вставляет его в коллекцию в указанную позицию индекса.  
Размер и позиция кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры.  
#### **Добавлены методы IPresentationFactory.GetPresentationInfo(string file) и IPresentationFactory.GetPresentationInfo(Stream stream)**
Эти методы позволяют получить информацию о файле презентации или потоке без полной загрузки презентации.  
#### **Добавлено свойство IPresentationFactory PresentationFactory.Instance**
Это свойство позволяет разработчикам использовать функциональность фабрики без её создания.  
### **Ограничения**
#### **Ограничения для IShape.Frame**
Для использования неопределённых значений в IShape.Frame были добавлены ограничения. Код, пытающийся присвоить неопределённый кадр свойству IShape.Frame, в большинстве случаев не имеет смысла (особенно когда родительский GroupShape вложен в другие {{GroupShape}}). Пример:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

или

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Такой код может приводить к неоднозначным ситуациям. Поэтому добавлены ограничения на использование неопределённых значений в IShape.Frame. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (и не задаваться как float.NaN или NullableBool.NotDefined). Приведённый выше пример теперь бросает исключение ArgumentException.  
Это относится к следующим сценариям использования:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Не может быть неопределённым

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

Однако свойства кадра IShape.RawFrame могут быть неопределёнными. Это имеет смысл, когда фигура привязана к заполняющему элементу. Тогда неопределённые значения кадра берутся у родительского заполняющего элемента. Если родительского заполняющего элемента нет, фигура использует значения по умолчанию при вычислении эффективного кадра на основе IShape.RawFrame. Значения по умолчанию — 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Пример:

``` csharp

 IShape shape = ...; // фигура привязана к заполняющему элементу

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// теперь фигура наследует x, y, height, flipH, flipV из заполняющего элемента и переопределяет width=100 и rotationAngle=0.

``` 
### **Изменённые свойства**
#### **Изменено имя и тип свойства Parent в Aspose.Slides.IShapeCollection**
- Тип свойства Aspose.Slides.IShapeCollection.Parent изменён с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape является наследником ISlideComponent, поэтому существующий код адаптаций не требует.  
- Имя свойства Aspose.Slides.IShapeCollection.Parent изменено с Parent на ParentGroup.  
#### **Изменён тип свойств Aspose.Slides.IShapeFrame.FlipH и .FlipV**
- Тип свойства Aspose.Slides.IShapeFrame.FlipH изменён с bool на NullableBool.  
- Свойство IShape.Frame возвращает эффективный экземпляр IShapeFrame (у всех его свойств определённые эффективные значения).  
- Свойство IShape.RawFrame возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределённое значение (особенно FlipH или FlipV могут иметь значение NullableBool.NotDefined).