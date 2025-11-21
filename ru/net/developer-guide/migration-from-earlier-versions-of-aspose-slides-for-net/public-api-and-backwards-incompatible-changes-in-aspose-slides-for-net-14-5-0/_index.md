---
title: Публичный API и обратные несовместимые изменения в Aspose.Slides для .NET 14.5.0
linktitle: Aspose.Slides для .NET 14.5.0
type: docs
weight: 70
url: /ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides для .NET, чтобы плавно мигрировать ваши решения для презентаций PowerPoint PPT, PPTX и ODP."
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) классы, методы, свойства и т.д., любые новые [ограничения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) и другие [изменения](/slides/ru/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) введённые в API Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
Представляет информацию о презентации.

- Свойство Boolean IsEncrypted возвращает **True**, если презентация зашифрована, иначе **False**.
- Свойство LoadFormat LoadFormat возвращает тип презентации.
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
Свойство Aspose.Slides.IShape.IsGrouped определяет, находится ли объект в группе.
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
Свойство Aspose.Slides.IShape.ParentGroup возвращает объект родительского GroupShape, если объект находится в группе. В противном случае возвращает **null**.
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
Метод Aspose.Slides.IShapeCollection.AddGroupShape() создаёт новый GroupShape и добавляет его в конец коллекции. Размер и положение кадра GroupShape будут подстроены под содержимое при добавлении новой фигуры.
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
Метод Aspose.Slides.IShapeCollection.Clear() удаляет все фигуры из коллекции.
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
Метод Aspose.Slides.IShapeCollection.InsertGroupShape(int) создаёт новый GroupShape и вставляет его в коллекцию в указанную позицию. Размер и положение кадра GroupShape будут подстроены под содержимое при добавлении новой фигуры.
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
Эти методы позволяют получить информацию о файле презентации или потоке без полной загрузки презентации.
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
Это свойство позволяет разработчикам использовать функции фабрики без создания экземпляра.
### **Restrictions**
#### **Restrictions to IShape.Frame**
Для свойства IShape.Frame добавлены ограничения на использование неопределённых значений. Код, который пытается присвоить неопределённый кадр IShape.Frame, обычно не имеет смысла (особенно когда родительский GroupShape вложен в другие {{GroupShape}}). Пример:

```csharp
 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

или

```csharp
 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Такой код может привести к неопределённым ситуациям. Поэтому добавлены ограничения на использование неопределённых значений для IShape.Frame. Параметры x, y, width, height, flipH, flipV и rotationAngle должны быть определены (и не должны быть равны float.NaN или NullableBool.NotDefined). Приведённый выше пример теперь бросает исключение **ArgumentException**. Это относится к следующим сценариям:

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

Но свойства кадра IShape.RawFrame могут быть неопределёнными. Это имеет смысл, когда фигура связана с заполнителем. Тогда неопределённые значения кадра наследуются от родительского заполнителя. Если родительского заполнителя нет, фигура использует значения по умолчанию при вычислении эффективного кадра на основе IShape.RawFrame. Значения по умолчанию: 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Пример:

```csharp
 IShape shape = ...; // фигура связана с заполнителем
shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);
// теперь фигура наследует x, y, height, flipH, flipV из заполнителя и переопределяет width=100 и rotationAngle=0.
``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- Тип свойства Aspose.Slides.IShapeCollection.Parent изменён с **ISlideComponent** на новый интерфейс **IGroupShape**. Интерфейс IGroupShape является наследником ISlideComponent, поэтому существующий код не требует адаптаций.
- Имя свойства Aspose.Slides.IShapeCollection.Parent изменено с **Parent** на **ParentGroup**.
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- Тип свойства Aspose.Slides.IShapeFrame.FlipH изменён с **bool** на **NullableBool**.
- Свойство IShape.Frame возвращает эффективный экземпляр IShapeFrame (все его свойства имеют определённые эффективные значения).
- Свойство IShape.RawFrame возвращает экземпляр IShapeFrame, где каждое свойство может быть неопределённым (особенно FlipH или FlipV могут иметь значение **NullableBool.NotDefined**).