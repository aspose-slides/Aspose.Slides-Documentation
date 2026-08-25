---
title: Управление каркасами изображений в презентациях с использованием Java
linktitle: Каркас изображения
type: docs
weight: 10
url: /ru/java/picture-frame/
keywords:
- каркас изображения
- добавить каркас изображения
- создать каркас изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG‑изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование каркаса изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте каркасы изображений в презентациях с помощью Aspose.Slides для Java."
---
## **Обзор**

Каркас изображения — это объект формы слайда, который отображает изображение. В Aspose.Slides ресурс изображения и форма, отображающая его, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) владеет встроенными ресурсами изображений через его [IImageCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimagecollection/), в то время как [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) управляет положением изображения, размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня кадра.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращенный [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/), и используйте этот ресурс изображения при создании каркасов.

Каркасы изображений могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо сохранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавить и отформатировать встроенное изображение**

Для встроенного изображения добавьте данные изображения в презентацию и создайте каркас изображения с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создает кадр с нативными размерами изображения и применяет форматирование линий и вращение:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Каркас изображения контролирует отображаемую геометрию; изменение размера кадра не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использовать относительное масштабирование**

[IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты кадра через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительное масштабирование удобно, когда процесс должен сохранять отношение к исходному размеру изображения вместо расчёта конечных размеров вручную.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Относительное масштабирование изменяет параметры масштаба кадра; оно не пере‑сэмплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого рендеринга. Связанное изображение хранит внешний путь через метод [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, открывающему или рендерящему презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанное изображение может не отобразиться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавить связанное изображение**

Следующий пример создаёт каркас изображения и указывает его на локальный файл изображения. Он рассматривает только связывание изображений; связывание видеоматериалов — отдельный медиа‑процесс и намеренно не смешивается в этом примере.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте ссылки, когда внешнее управление файлами задумано. Не используйте их лишь как замену сжатию: небольшой PPTX с повреждёнными зависимостями изображений обычно менее полезен, чем большая автономная презентация.

## **Извлекать изображения из каркасов**

Перед извлечением изображения из существующей презентации проверьте, что форма действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) и что она содержит встроенное изображение. Связанные каркасы изображений могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечь растровое изображение**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) напрямую и не требует устаревшего Java‑обёртки. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/#save-java.lang.String-int-) преобразует извлечённое изображение в запрошенный формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечь SVG‑изображение**

Для SVG‑изображения [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/). Это позволяет получить SVG‑данные напрямую, без предварительной растризации изображения.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Сохранение SVG‑содержимого как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязателен преобразует векторное содержимое в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как точная копия оригинального встроенного SVG; используйте данные [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/#getSvgData--) при необходимости самого векторного ресурса.

## **Обрезать изображение**

Обрезка меняет ту часть изображения, которая видна внутри кадра. Значения обрезки на [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) выражаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Следующий пример надёжно находит каркас изображения и применяет значения обрезки:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если важен размер файла больше, чем возможность обратного изменения, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удалить данные обрезанных изображений**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующего отката.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими каркасами, эти кадры всё равно нуждаются в своем существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF этим методом растрирует результат в PNG.

## **Сжать растровые изображения**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, при котором оно отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено в размере или обрезано, и `false`, когда изменений не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/java/com.aspose.slides/picturescompression/), когда достаточно стандартного целевого разрешения:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

При необходимости конкретного целевого разрешения вместо предопределённого значения можно передать пользовательское положительное DPI.

Сжатие предназначено для растровых изображений. SVG и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, при котором изображение будет реально просматриваться или экспортироваться, а не применяйте самое низкое DPI глобально.

## **Управление эффектами трансформации изображения**

Для полного процесса, охватывающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и двойную проверку, см. [Image Transform Effects](/slides/ru/java/image-transform-effects/).

## **Блокировать геометрию каркаса изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframelock/) контролируют, какие операции редактирования отключены для каркаса изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при её изменении размера.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Блокировка применяется к форме каркаса изображения. Она не принуждает исходное изображение к пере‑сэмплированию или постоянному изменению пропорций.

## **Настроить значения StretchOffset**

Когда режим заливки изображения установлен в stretch, значения stretch‑offset на [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) определяют прямоугольник заливки относительно ограничивающего бокса каркаса. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видна; stretch‑offset изменяют прямоугольник, в который растягивается видимая заливка изображения.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте stretch‑offset для позиционирования заливки. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения экспорта**

Основные компромиссы легче управлять, когда хранение изображений и форматирование каркасов рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для обмена и серверного рендеринга, но большие растровые изображения увеличивают размер PPTX и расход памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по сохранённым путям или локациям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными до тех пор, пока обрезанные области явно не будут удалены или удалены во время сжатия.
- **Сжатие** может значительно уменьшить размер файла для слишком крупных растровых изображений, но теряется исходное разрешение. Применяйте его после того, как известен окончательный размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна сохранность вектора. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage], когда это возможно, вместо многократной загрузки одного и того же файла в процесс создания презентации.

Для больших презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: храните логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальными размерами отображения, удаляйте обрезанные пиксели только когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не входит в дизайн развертывания.

## **FAQ**

**В чём разница между каркасом изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) — это форма на слайде, отображающая изображение и хранящая геометрию и форматирование уровня кадра, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Нужно ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние локации можно надёжно поддерживать.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить хранение растрового разрешения, а удаление обрезанных областей отбрасывает данные изображения. Сохраните оригинальное исходное изображение вне презентации, если позже потребуется редактирование в высоком разрешении.

**Как обращаться с SVG‑изображениями?**

Сохраняйте SVG‑содержание как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для каркаса изображения. Проверка `instanceof` относительно [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) предотвращает недопустимые приведения и позволяет коду обрабатывать слайды без каркасов изображения.