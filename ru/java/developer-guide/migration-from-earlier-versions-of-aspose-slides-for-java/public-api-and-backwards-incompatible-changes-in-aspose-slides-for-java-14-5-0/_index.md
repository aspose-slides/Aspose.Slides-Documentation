---
title: Публичный API и изменения, несовместимые с предыдущими версиями, в Aspose.Slides для Java 14.5.0
type: docs
weight: 40
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) классов, методов, свойств и т.д., новых [ограничений](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) и других [изменений](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), введенных в API Aspose.Slides для Java 14.5.0.

{{% /alert %}} 
## **Публичный API и изменения, несовместимые с предыдущими версиями**
### **Добавленные классы и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и класс PresentationInfo**
Представляет информацию о презентации.

Метод Boolean isEncrypted() возвращает True, если презентация зашифрована, иначе возвращает False.

Метод LoadFormat getLoadFormat() возвращает тип презентации.
#### **Добавлен метод Aspose.Slides.IShape.isGrouped()**
Метод Aspose.Slides.IShape.isGrouped() определяет, сгруппирована ли форма.
#### **Добавлен метод Aspose.Slides.IShape.getParentGroup()**
Метод Aspose.Slides.IShape.getParentGroup() возвращает объект GroupShape родителя, если форма сгруппирована. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.addGroupShape()**
Метод Aspose.Slides.IShapeCollection.addGroupShape() создает новый GroupShape и добавляет его в конец коллекции.

Размер и положение рамки GroupShape будут подогнаны под содержимое, когда новая форма будет добавлена в GroupShape.
#### **Добавлен метод Aspose.Slides.IShapeCollection.clear()**
Метод Aspose.Slides.IShapeCollection.clear() удаляет все формы из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.insertGroupShape(int) создает новый GroupShape и вставляет его в коллекцию по указанному индексу.
Размер и положение рамки GroupShape будут подогнаны под содержимое, когда новая форма будет добавлена в GroupShape.
#### **Добавлены методы IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Эти методы позволяют разработчикам получать информацию о файле/потоке презентации без полного загрузки презентации.
#### **Добавлен метод IPresentationFactory PresentationFactory.getInstance()**
Позволяет использовать функциональность фабрики без инстанцирования.
### **Ограничения**
#### **Добавлены ограничения на использование неопределенных значений для IShape.getFrame()**
Код, который пытается присвоить неопределенную рамку IShape.setFrame(IShapeFrame), не имеет смысла в общем случае (особенно когда родительский GroupShape несколько раз вложен в другие {{GroupShape}}s). Например:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

или

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Такой код может привести к неясным ситуациям. Поэтому были добавлены ограничения на использование неопределенных значений для IShape.Frame. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (не Float.NaN или NullableBool.NotDefined). Примерный код выше теперь вызывает исключение ArgumentException.
Это относится к следующим случаям использования:

``` java

 IShape shape = ...;

shape.setFrame(...); // не может быть неопределенным

IShapeCollection shapes = ...;

// параметры x, y, width, height не могут быть Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Но рамка IShape.getRawFrame() может быть неопределенной. Это имеет смысл, когда форма связана с заполнителем. Тогда неопределенные значения рамки формы перекрываются значениями родительской формы-заполнителя. Если у этой формы нет родительской формы-заполнителя, то используются значения по умолчанию при оценке эффективной рамки на основе ее IShape.getRawFrame(). Значения по умолчанию: 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

``` java

 IShape shape = ...; // форма связана с заполнителем

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// теперь форма наследует значения x, y, height, flipH, flipV от заполнителя и переопределяет width=100 и rotationAngle=0.

```
### **Измененные свойства**
#### **Изменены тип и имя метода Aspose.Slides.IShapeCollection.getParent()**
Тип свойства Aspose.Slides.IShapeCollection.Parent изменен с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape является потомком ISlideComponent, поэтому существующий код не требует адаптации.

Имя метода Aspose.Slides.IShapeCollection.getParent() изменено с getParent на getParentGroup().
#### **Изменен тип методов Aspose.Slides.IShapeFrame.getFlipH() и .getFlipV()**
Тип метода Aspose.Slides.IShapeFrame.getFlipH() изменен с bool на NullableBool.

Метод IShape.getFrame() возвращает эффективный экземпляр IShapeFrame (все свойства которого имеют определенные эффективные значения).

Метод IShape.getRawFrame() возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределенное значение (в частности, FlipH или FlipV могут иметь значение NullableBool.NotDefined).