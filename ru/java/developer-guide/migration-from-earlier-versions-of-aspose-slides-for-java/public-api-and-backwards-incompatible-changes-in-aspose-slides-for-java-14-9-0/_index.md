---
title: "Публичный API и обратно несовместимые изменения в Aspose.Slides for Java 14.9.0"
linktitle: "Aspose.Slides for Java 14.9.0"
type: docs
weight: 80
url: /ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
  - миграция
  - унаследованный код
  - современный код
  - старый подход
  - современный подход
  - PowerPoint
  - OpenDocument
  - презентация
  - Java
  - Aspose.Slides
description: "Обзор обновлений публичного API и ломающих изменений в Aspose.Slides for Java для плавной миграции ваших решений по работе с презентациями PowerPoint PPT, PPTX и ODP."
---
{{% alert color="info" %}} 

Эта страница перечисляет все [добавленные](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) классы, методы, свойства и т.п., любые новые ограничения и другие [изменения](/slides/ru/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) введённые в API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Изменения публичного API**
### **Добавлены методы замены изображения на PPImage, IPPImage**
Добавлены новые методы:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Первый способ
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Второй способ
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Добавлены методы сохранения слайдов с сохранением номеров страниц**
Были добавлены следующие методы:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Эти методы позволяют сохранить указанные слайды презентации в форматы PDF, XPS, TIFF, HTML. Массив `slides` позволяет указать номера страниц, начиная с 1.

``` java
// Перегрузки, добавленные в IPresentation (значения SaveFormat являются целочисленными константами в Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Массив позиций слайдов

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Добавлено значение перечисления SmartArtLayoutType.Custom**
Этот тип макета SmartArt представляет диаграмму с пользовательским шаблоном. Пользовательские диаграммы могут быть загружены только из файла презентации и не могут быть созданы с помощью метода `ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)`.

### **Добавлены класс SmartArtShape и интерфейс ISmartArtShape**
Класс `Aspose.Slides.SmartArt.SmartArtShape` (и его интерфейс `Aspose.Slides.SmartArt.ISmartArtShape`) предоставляет доступ к отдельным формам внутри диаграммы SmartArt. `SmartArtShape` может использоваться для изменения `FillFormat`, `LineFormat`, добавления гиперссылок и т.д.

{{% alert color="info" %}} 

SmartArtShape не поддерживает свойства IShape `RawFrame`, `Frame`, `Rotation`, `X`, `Y`, `Width`, `Height` и генерирует `System.NotSupportedException` при попытке доступа к ним.

{{% /alert %}} 

Example of usage:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **Добавлены класс SmartArtShapeCollection, интерфейс ISmartArtShapeCollection и метод ISmartArtNode.getShapes()**
Класс `Aspose.Slides.SmartArt.SmartArtShapeCollection` (и его интерфейс `Aspose.Slides.SmartArt.ISmartArtShapeCollection`) предоставляет доступ к отдельным формам внутри диаграммы SmartArt. Коллекция содержит формы, связанные с `SmartArtNode`. Свойство `SmartArtNode.Shapes` возвращает коллекцию всех форм, связанных с узлом.

{{% alert color="info" %}} 

В зависимости от `SmartArtLayoutType` один `SmartArtShape` может быть общим для нескольких узлов.

{{% /alert %}} 

 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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