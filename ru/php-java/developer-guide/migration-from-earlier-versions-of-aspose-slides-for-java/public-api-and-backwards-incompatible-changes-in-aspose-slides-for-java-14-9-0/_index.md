---
title: Публичный API и несовместимые изменения в Aspose.Slides для PHP через Java 14.9.0
type: docs
weight: 80
url: /ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Эта страница содержит все [добавленные](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) классы, методы, свойства и так далее, любые новые ограничения и другие [изменения](/slides/ru/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), введенные с API Aspose.Slides для PHP через Java 14.9.0.

{{% /alert %}} 
## **Изменения в публичном API**
### **Добавлены методы для замены изображения в PPImage, IPPImage**
Добавлены новые методы:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # Первый способ
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # Второй способ
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **Добавлены методы для сохранения слайдов с сохранением номеров страниц**
Добавлены следующие методы:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Эти методы позволяют сохранять указанные слайды презентации в формате PDF, XPS, TIFF, HTML. Массив 'slides' позволяет указывать номера страниц, начиная с 1.

```php
  save($string, $slides, SaveFormat);

```

```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// Массив позиций слайдов

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **Добавлено значение перечисления SmartArtLayoutType::Custom**
Этот тип макета SmartArt представляет диаграмму с пользовательским шаблоном. Пользовательские диаграммы могут загружаться только из файла презентации и не могут создаваться с помощью метода ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom)
### **Добавлен класс SmartArtShape и интерфейс ISmartArtShape**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) предоставляют доступ к отдельным фигурам внутри диаграммы SmartArt. SmartArtShape может использоваться для изменения FillFormat, LineFormat, добавления гиперссылок и т.д.

{{% alert color="primary" %}} 

SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и выбрасывает System.NotSupportedException при попытке к ним обратиться.

{{% /alert %}} 

Пример использования:

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **Добавлены класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и метод ISmartArtNode.getShapes()**
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) предоставляет доступ к отдельным фигурам внутри диаграммы SmartArt. Коллекция содержит фигуры, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекции всех фигур, связанных с узлом.

{{% alert color="primary" %}} 

В зависимости от SmartArtLayoutType одна SmartArtShape может быть общей для нескольких узлов.

{{% /alert %}} 

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```