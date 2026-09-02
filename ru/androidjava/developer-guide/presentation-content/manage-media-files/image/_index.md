---
title: Оптимизация управления изображениями в презентациях на Android
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/androidjava/image/
keywords:
- добавить изображение
- добавить рисунок
- заменить изображение
- коллекция изображений
- рамка рисунка
- связанное изображение
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- SVG в фигуры
- внешние ресурсы SVG
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, переиспользовать, связывать, заменять и управлять растровыми и SVG‑изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides for Android via Java."
---
## **Введение**

Aspose.Slides for Android via Java предоставляет несколько способов работы с изображениями, каждый из которых служит разной цели. Вы можете хранить изображение в презентации, отображать его в рамке рисунка, использовать его в качестве фона слайда, связывать с внешним изображением, заменять общий ресурс изображения или конвертировать содержимое SVG в редактируемые фигуры.

В этой статье рассматриваются ресурсы изображений и их использование в презентации. Для обрезки, прозрачности, эффектов, растягивания и другого форматирования, применяемого к отдельной рамке рисунка, см. [Рамка рисунка](/slides/ru/androidjava/picture-frame/).

## **Понимание модели изображения**

Следующие концепции API тесно связаны, но не взаимозаменяемы:

- [Коллекция изображений презентации](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/) хранит ресурсы изображений, используемые в презентации. Используйте [ImageCollection.addImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imagecollection/) для добавления данных изображения и получения ресурса [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).
- [Рамка рисунка](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) — это фигура, которая отображает изображение на слайде, шаблоне или мастере. Используйте [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/) для размещения ресурса изображения на слайде.
- Фон слайда использует изображение как часть заливки слайда, а не как фигуру. Поэтому он не ведет себя как рамка рисунка.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Конвертирование SVG в фигуры создаёт редактируемые фигуры слайда. После конвертации содержимое больше не управляется как один ресурс рисунка.

Типичный рабочий процесс выглядит так: добавить данные изображения в коллекцию изображений, получить [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), а затем использовать этот ресурс в одной или нескольких рамках рисунка или заливках.

## **Добавление встроенного изображения**

Чтобы вставить локальное изображение, загрузите файл, добавьте его в коллекцию изображений и создайте рамку рисунка, использующую полученный `IPPImage`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Изображение, добавленное таким способом, внедряется в презентацию, поэтому результирующий файл не зависит от наличия исходного файла изображения.

### **Добавление изображения из веба**

Когда изображение доступно через HTTP или HTTPS, скачайте его байты, добавьте их в коллекцию изображений презентации и используйте полученный ресурс изображения так же, как локальное изображение.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

В длительно работающих приложениях повторно используйте HTTP‑клиент или стратегию управления соединениями, подходящие для вашего приложения, вместо многократного создания лишней сетевой инфраструктуры. Кроме того, проверяйте удалённые URL, размеры ответов и типы содержимого, когда источник недоверенный.

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение требуется более одного раза, добавьте его в презентацию один раз и повторно используйте полученный [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) при создании дополнительных рамок рисунка. Это избавляет от многократной загрузки одинаковых исходных данных и делает связь между общим ресурсом изображения и его использованием явной.

Для графики, которая должна автоматически появляться на многих слайдах, например логотипа компании, рассмотрите размещение рамки рисунка на [мастере слайдов](/slides/ru/androidjava/slide-master/) или шаблоне, вместо добавления эквивалентной фигуры на каждый слайд.

## **Использование изображения в качестве фона слайда**

Изображение фона назначается заливке слайда; оно не добавляется как фигура рамки рисунка. Это удобно, когда рисунок должен покрывать фон слайда и не должен обрабатываться как обычный объект слайда.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для дополнительных вариантов фона, включая фон мастера и шаблона, см. [Фон презентации](/slides/ru/androidjava/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы по переносимости и размеру файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация автономна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация хранит путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен оставаться доступным при открытии или рендеринге презентации.

Связанное изображение можно создать, задав внешний путь или URL через [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/) вместо внедрения данных изображения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте связанные изображения только тогда, когда среда развертывания может надёжно получить внешний ресурс. Для презентаций, которые должны работать офлайн или переноситься между системами, встроенные изображения обычно безопаснее.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он полезен для значков, диаграмм и другой графики, которую нужно масштабировать без потери детализации, характерной для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения и как источник для редактируемых фигур слайда.

### **Добавление SVG в качестве изображения**

Создайте [SvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgimage/), добавьте его в коллекцию изображений и разместите полученный ресурс изображения в рамке рисунка.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑файлы с внешними ресурсами**

SVG может ссылаться на внешние изображения, таблицы стилей или шрифты. Для таких случаев [SvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgimage/) предоставляет конструкторы, принимающие [IExternalResourceResolver](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iexternalresourceresolver/) и базовый URI. Резольвер может сопоставлять относительный URI с разрешённым абсолютным URI и возвращать поток для требуемого ресурса.

Резольвер делает внешние ресурсы доступными во время обработки SVG Aspose.Slides, но не переписывает SVG в автономный документ. Если SVG должен оставаться переносимым, внедрите его необходимые ресурсы непосредственно в SVG, например, используя URI `data:` для связанных изображений.

Когда SVG‑файлы поступают из недоверенных источников, ограничьте схемы, расположения файлов и хосты, к которым резольвер может получить доступ. Сетевые резольверы также должны применять тайм‑ауты, ограничения размера ответов и проверку содержимого.

### **Конвертирование SVG в редактируемые фигуры**

Aspose.Slides может конвертировать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![Всплывающее меню PowerPoint](img_01_01.png)

Используйте перегрузку [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/) , принимающую [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/), для выполнения конвертации.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Применяйте конвертацию SVG‑в‑фигуры, когда отдельные векторные элементы необходимо редактировать как фигуры PowerPoint. Если SVG требуется только отобразить, проще оставить его как изображение, избегая создания множества отдельных фигур.

## **Замена существующего ресурса изображения**

Используйте [IPPImage.replaceImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) когда нужно заменить существующий ресурс изображения. Это особенно полезно для общих графических элементов, таких как логотипы.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если несколько рамок рисунка, фонов, мастеров или шаблонов используют один и тот же ресурс изображения, замена этого ресурса обновит все такие использования. Если нужно изменить только одну рамку рисунка, назначьте ей другое изображение вместо замены общего ресурса.

`replaceImage` также предоставляет перегрузки, принимающие массив байтов или другой [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/).

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут необоснованно увеличивать размер презентации. Используйте исходные изображения с размерами, соответствующими их предполагаемому размеру отображения, повторно используйте общие ресурсы изображений там, где это возможно, и избегайте внедрения повторяющихся копий одного и того же графического файла высокой чёткости.

Для растровых картинок, уже размещённых в рамках рисунка, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) может уменьшить данные изображения в соответствии с выбранным разрешением и настройками обрезки. Это обработка рамки рисунка, а не управление коллекцией изображений, поэтому см. [Рамка рисунка](/slides/ru/androidjava/picture-frame/) для связанных операций форматирования.

### **Выбор между встроенным и связанным содержимым**

Внедрение делает презентацию переносимой, поскольку все необходимые данные изображений находятся в файле. Связывание может уменьшить размер файла, но вводит внешнюю зависимость. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование общего брендинга**

Для повторяющихся логотипов, водяных знаков или декоративных графических элементов используйте один ресурс изображения и переиспользуйте его. Если графика относится к дизайну презентации, а не к содержимому слайда, разместите её на мастере или шаблоне, чтобы она наследовалась соответствующими слайдами.

### **Соблюдение переносимости SVG‑ресурсов**

Самодостаточный SVG проще перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности внедрите требуемые ресурсы перед импортом SVG. Конвертируйте SVG в фигуры только тогда, когда отдельные векторные элементы нужно редактировать.

### **Использование современного кроссплатформенного API изображений**

Для нового кода Android via Java используйте API Aspose.Slides [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) и [Images](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/images/) вместо устаревшего публичного API, основанного на `android.graphics.Bitmap`. См. [Современный API](/slides/ru/androidjava/modern-api/) для рекомендаций по миграции.

WMF и EMF требуют особого внимания. Когда эти форматы передаются через [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imagecollection/) конвертирует метафайл в растровое представление PNG перед вставкой. Если важно сохранить данные метафайла, используйте перегрузку потокового [ImageCollection.addImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imagecollection/). Генерация EMF‑контента из электронных таблиц или других продуктов — отдельный процесс интеграции и выходит за рамки этой статьи.

## **FAQ**

**В чём разница между коллекцией изображений и рамкой рисунка?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка рисунка — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое для рисунка форматирование, такое как обрезка и эффекты.

**Как лучше всего заменить один и тот же логотип повсюду?**

Если логотип уже общим ресурсом изображения, замените его с помощью [IPPImage.replaceImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/). Для брендинга во всей презентации можно также разместить логотип на мастере или шаблоне, уменьшая дублирование содержимого слайдов.

**Почему связанное изображение исчезает на другом компьютере?**

Связанное изображение зависит от внешнего файла или URL. Если с другого компьютера этот ресурс недоступен, связанное изображение будет недоступно. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли отредактировать вставленный SVG как фигуры PowerPoint?**

Да. Конвертируйте SVG с помощью [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/); полученная группа будет содержать редактируемые фигуры слайда вместо одного SVG‑рисунка.

**Как сохранить презентации с большим количеством изображений небольшими по размеру?**

Повторно используйте общие ресурсы изображений, избегайте избыточно больших растровых источников, при необходимости сжимайте подходящие растровые картинки, размещайте повторяющийся брендинг на мастерах или шаблонах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.