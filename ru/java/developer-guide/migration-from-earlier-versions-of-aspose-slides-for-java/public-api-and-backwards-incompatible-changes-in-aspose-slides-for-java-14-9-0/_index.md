---
title: Публичный API и несовместимые изменения в Aspose.Slides для Java 14.9.0
type: docs
weight: 80
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

Эта страница содержит список всех [добавленных](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) классов, методов, свойств и так далее, а также новых ограничений и других [изменений](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), введенных с API Aspose.Slides для Java 14.9.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавленные методы для замены изображения на PPImage, IPPImage**
Добавлены новые методы:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Первый способ

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Второй способ

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Добавленные методы для сохранения слайдов с сохранением номеров страниц**
Добавлены следующие методы:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Эти методы позволяют сохранять указанные слайды презентации в форматах PDF, XPS, TIFF, HTML. Массив 'slides' позволяет указывать номера страниц, начиная с 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Массив позиций слайдов

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Добавлено значение перечисления SmartArtLayoutType.Custom**
Этот тип компоновки SmartArt представляет диаграмму с пользовательским шаблоном. Пользовательские диаграммы могут загружаться только из файла презентации и не могут быть созданы с помощью метода ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Добавлен класс SmartArtShape и интерфейс ISmartArtShape**
Класс Aspose.Slides.SmartArt.SmartArtShape (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShape) обеспечивают доступ к отдельным фигурам внутри диаграммы SmartArt. SmartArtShape можно использовать для изменения FillFormat, LineFormat, добавления гиперссылок и т.д.

{{% alert color="primary" %}} 

SmartArtShape не поддерживает свойства IShape RawFrame, Frame, Rotation, X, Y, Width, Height и вызывает System.NotSupportedException при попытке доступа к ним.

{{% /alert %}} 

Пример использования:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Добавлен класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и метод ISmartArtNode.getShapes()**
Класс Aspose.Slides.SmartArt.SmartArtShapeCollection (и его интерфейс Aspose.Slides.SmartArt.ISmartArtShapeCollection) обеспечивают доступ к отдельным фигурам внутри диаграммы SmartArt. Коллекция содержит фигуры, связанные с SmartArtNode. Свойство SmartArtNode.Shapes возвращает коллекции всех фигур, связанных с узлом.

{{% alert color="primary" %}} 

В зависимости от SmartArtLayoutType одна SmartArtShape может использоваться несколькими узлами.

{{% /alert %}} 

﻿

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```