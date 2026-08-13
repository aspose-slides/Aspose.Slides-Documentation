---
title: Общий API и несовместимые изменения в Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides для Java 14.5.0
type: docs
weight: 40
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- миграция
- унаследованный код
- современный код
- унаследованный подход
- современный подход
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Обзор обновлений публичного API и разрушающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) классы, методы, свойства и т.д., любые новые [ограничения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) и прочие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) введённые в API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **Публичный API и несовместимые изменения**
### **Добавленные классы и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и классы PresentationInfo**
Представляет информацию о презентации.

Метод Boolean isEncrypted() возвращает True, если презентация зашифрована, иначе возвращает False.

Метод LoadFormat getLoadFormat() возвращает тип презентации.
#### **Добавлен метод Aspose.Slides.IShape.isGrouped()**
Метод Aspose.Slides.IShape.isGrouped() определяет, сгруппирована ли фигура.
#### **Добавлен метод Aspose.Slides.IShape.getParentGroup()**
Метод Aspose.Slides.IShape.getParentGroup() возвращает объект родительского GroupShape, если фигура сгруппирована. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.addGroupShape()**
Метод Aspose.Slides.IShapeCollection.addGroupShape() создаёт новый GroupShape и добавляет его в конец коллекции.

Размер и позиция кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры в GroupShape.
#### **Добавлен метод Aspose.Slides.IShapeCollection.clear()**
Метод Aspose.Slides.IShapeCollection.clear() удаляет все фигуры из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.insertGroupShape(int) создаёт новый GroupShape и вставляет его в коллекцию по заданному индексу.

Размер и позиция кадра GroupShape будут подогнаны под содержимое при добавлении новой фигуры в GroupShape.
#### **Добавлены методы IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Эти методы позволяют разработчикам получать информацию о файле/потоке презентации без полной загрузки презентации.
#### **Добавлен метод IPresentationFactory PresentationFactory.getInstance()**
Позволяет использовать функциональность фабрики без создания экземпляра.
### **Ограничения**
#### **Для использования неопределённых значений в IShape.getFrame() добавлены ограничения**
Код, который пытается присвоить неопределённый кадр IShape.setFrame(IShapeFrame), обычно не имеет смысла (особенно когда родительский GroupShape многократно вложен в другие {{GroupShape}}). Например:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Вызывает ArgumentException: значения кадра должны быть определены.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

или

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Вызывает ArgumentException: значения x, y, ширины и высоты должны быть определены.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Такой код может привести к неопределённым ситуациям. Поэтому для использования неопределённых значений в IShape.Frame добавлены ограничения. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (не Float.NaN и не NullableBool.NotDefined). Приведённый выше пример кода теперь генерирует исключение ArgumentException.

Это относится к следующим сценариям использования:

``` java
// Кадр, передаваемый в IShape.setFrame(IShapeFrame), не может содержать неопределённые значения.

// Параметры x, y, ширина и высота следующих методов IShapeCollection
// также не могут быть Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Однако кадр, возвращаемый IShape.getRawFrame(), может быть неопределённым. Это имеет смысл, когда фигура связана с заполнительным элементом. Тогда неопределённые значения кадра фигуры переопределяются значениями родительского заполняющего элемента. Если для этой фигуры нет родительского заполняющего элемента, используются значения по умолчанию при вычислении эффективного кадра на основе IShape.getRawFrame(). Значения по умолчанию: 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Фигура связана с заполнительным элементом.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Теперь фигура наследует значения x, y, высоты, flipH и flipV от заполнительного элемента
    // и переопределяет ширину = 100 и угол вращения = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Изменённые свойства**
#### **Изменён тип и имя метода Aspose.Slides.IShapeCollection.getParent()**
Тип свойства Aspose.Slides.IShapeCollection.Parent изменён с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape наследуется от ISlideComponent, поэтому существующий код не требует адаптации.

Имя метода Aspose.Slides.IShapeCollection.getParent() изменено с getParent на getParentGroup().
#### **Изменён тип методов Aspose.Slides.IShapeFrame.getFlipH() и .getFlipV()**
Тип метода Aspose.Slides.IShapeFrame.getFlipH() изменён с bool на NullableBool.

Метод IShape.getFrame() возвращает эффективный экземпляр IShapeFrame (все его свойства имеют определённые эффективные значения).

Метод IShape.getRawFrame() возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределённое значение (особенно FlipH или FlipV могут иметь значение NullableBool.NotDefined).