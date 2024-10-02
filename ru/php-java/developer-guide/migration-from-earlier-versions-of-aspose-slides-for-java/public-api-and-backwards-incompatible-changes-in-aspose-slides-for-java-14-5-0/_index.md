---
title: Публичный API и изменения, несовместимые с предыдущими версиями в Aspose.Slides для PHP через Java 14.5.0
type: docs
weight: 40
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
---

{{% alert color="primary" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) классы, методы, свойства и так далее, любые новые [ограничения](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) и другие [изменения](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), введенные в API Aspose.Slides для PHP через Java 14.5.0.

{{% /alert %}} 
## **Публичный API и изменения, несовместимые с предыдущими версиями**
### **Добавленные классы и методы**
#### **Добавлен интерфейс Aspose.Slides.IPresentationInfo и классы PresentationInfo**
Представляет информацию о презентации.

Метод Boolean isEncrypted() возвращает True, если презентация зашифрована, иначе возвращает False.

Метод LoadFormat getLoadFormat() возвращает тип презентации.
#### **Добавлен метод Aspose.Slides.IShape.isGrouped()**
Метод Aspose.Slides.IShape.isGrouped() определяет, сгруппирован ли объект.
#### **Добавлен метод Aspose.Slides.IShape.getParentGroup()**
Метод Aspose.Slides.IShape.getParentGroup() возвращает объект GroupShape родителя, если объект сгруппирован. В противном случае возвращает null.
#### **Добавлен метод Aspose.Slides.IShapeCollection.addGroupShape()**
Метод Aspose.Slides.IShapeCollection.addGroupShape() создает новый GroupShape и добавляет его в конец коллекции.

Размер и позиция рамки GroupShape будут подогнаны под содержимое, когда в GroupShape будет добавлен новый объект.
#### **Добавлен метод Aspose.Slides.IShapeCollection.clear()**
Метод Aspose.Slides.IShapeCollection.clear() удаляет все объекты из коллекции.
#### **Добавлен метод Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Метод Aspose.Slides.IShapeCollection.insertGroupShape(int) создает новый GroupShape и вставляет его в коллекцию по указанному индексу.
Размер и позиция рамки GroupShape будут подогнаны под содержимое, когда в GroupShape будет добавлен новый объект.
#### **Добавлены методы IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Эти методы позволяют разработчикам получать информацию о файле/потоке презентации без полной загрузки презентации.
#### **Добавлен метод IPresentationFactory PresentationFactory.getInstance()**
Позволяет использовать функциональность фабрики без создания экземпляра.
### **Ограничения**
#### **Добавлены ограничения на использование неопределенных значений для IShape.getFrame()**
Код, который пытается присвоить неопределенную рамку методу IShape.setFrame(IShapeFrame), не имеет смысла в общих случаях (особенно если родительский GroupShape несколько раз вложен в другие {{GroupShape}}). Например:

```php
  $shape = $$missing$;
  $shape->setFrame(new ShapeFrame(Float::NaN, Float::NaN, Float::NaN, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, Float::NaN));

```

или

```php
  slide.Shapes->AddAutoShape(ShapeType::RoundCornerRectangle, Float::NaN, Float::NaN, Float::NaN, Float::NaN);

```

Такой код может привести к неясным ситуациям. Поэтому были добавлены ограничения на использование неопределенных значений для IShape.Frame. Значения x, y, width, height, flipH, flipV и rotationAngle должны быть определены (не Float.NaN или NullableBool.NotDefined). Пример кода выше теперь вызывает исключение ArgumentException.
Это относится к этим случаям использования:

```php
  $shape = $$missing$;
  $shape->setFrame();// не может быть неопределенным

  $shapes = $$missing$;
  # параметры x, y, width, height не могут быть Float.NaN:
  {
    $shapes->addAudioFrameCD();
    $shapes->addAudioFrameEmbedded();
    $shapes->addAudioFrameLinked();
    $shapes->addAutoShape();
    $shapes->addChart();
    $shapes->addConnector();
    $shapes->addOleObjectFrame();
    $shapes->addPictureFrame();
    $shapes->addSmartArt();
    $shapes->addTable();
    $shapes->addVideoFrame();
    $shapes->insertAudioFrameEmbedded();
    $shapes->insertAudioFrameLinked();
    $shapes->insertAutoShape();
    $shapes->insertChart();
    $shapes->insertConnector();
    $shapes->insertOleObjectFrame();
    $shapes->insertPictureFrame();
    $shapes->insertTable();
    $shapes->insertVideoFrame();
  }
```

Но рамка IShape.getRawFrame() может быть неопределенной. Это имеет смысл, когда объект связан с заполнителем. Тогда неопределенные значения рамки объекта переопределяются значениями родительского заполнителя. Если для этого объекта нет родительского заполнителя, то используются значения по умолчанию при оценке эффективной рамки на основе его IShape.getRawFrame(). Значения по умолчанию составляют 0 и NullableBool.False для x, y, width, height, flipH, flipV и rotationAngle. Например:

```php
  $shape = $$missing$;// объект связан с заполнителем

  $shape->setRawFrame(new ShapeFrame(Float::NaN, Float::NaN, 100, Float::NaN, NullableBool::NotDefined, NullableBool::NotDefined, 0));
  # теперь объект наследует значения x, y, height, flipH, flipV от заполнителя и переопределяет width=100 и rotationAngle=0.

```
### **Измененные свойства**
#### **Изменен тип и имя метода Aspose.Slides.IShapeCollection.getParent()**
Тип свойства Aspose.Slides.IShapeCollection.Parent изменен с ISlideComponent на новый интерфейс IGroupShape. Интерфейс IGroupShape является потомком ISlideComponent, поэтому существующему коду не требуется адаптация.

Имя метода Aspose.Slides.IShapeCollection.getParent() изменено с getParent на getParentGroup().
#### **Изменен тип методов Aspose.Slides.IShapeFrame.getFlipH() и .getFlipV()**
Тип метода Aspose.Slides.IShapeFrame.getFlipH() изменен с bool на NullableBool.

Метод IShape.getFrame() возвращает эффективный экземпляр IShapeFrame (все свойства которого имеют определенные эффективные значения).

Метод IShape.getRawFrame() возвращает экземпляр IShapeFrame, у которого каждое свойство может иметь неопределенное значение (в частности, FlipH или FlipV могут иметь значение NullableBool.NotDefined).