---
title: Управление рамками изображений в презентациях с использованием Java
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/java/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG-изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование рамки изображения
- относительное масштабирование
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для Java."
---
## **Обзор**

Рамка изображения — это объект формы в слайде, который отображает картинку. В Aspose.Slides ресурс изображения и объект, который его отображает, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) владеет встроенными ресурсами изображений через свой [IImageCollection](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimagecollection/), а [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) управляет позицией изображения, его размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими параметрами уровня рамки.

Это разделение удобно, когда одно и то же изображение используется более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок изображений.

Рамки изображений могут содержать растровые изображения, такие как PNG или JPEG, а также векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, прежде чем применять форматирование или оптимизацию.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся самодостаточной при перемещении на другой компьютер.

В следующем примере добавляется JPEG‑изображение, создаётся рамка с оригинальными размерами изображения и применяются форматирование линий и вращение:

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

Рамка изображения контролирует отображаемую геометрию; изменение её размера не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштабирования**

[IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты для рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительное масштабирование удобно, когда рабочий процесс требует сохранять связь с размером исходного изображения вместо расчёта конечных размеров вручную.

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

Относительное масштабирование меняет параметры масштаба рамки; оно не пересэмплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым безопасным вариантом с точки зрения переносимости и предсказуемого рендеринга. Связанное изображение хранит внешний путь через метод [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанное изображение может не отобразиться ожидаемым образом. Для презентаций, которые должны быть отправлены по электронной почте, архивированы или рендерятся в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавление связанного изображения**

В следующем примере создаётся рамка изображения и указывается локальный файл картинки. Пример работает только с привязкой изображений; привязка видео — отдельный медиапоток и намеренно не смешан с этим примером.

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

Используйте ссылки, когда управление внешними файлами является намеренным. Не используйте их лишь как замену сжатию: небольшой PPTX с нарушенными зависимостями изображений обычно менее полезен, чем более крупная самодостаточная презентация.

## **Извлечение изображений из рамок**

Перед извлечением изображения из существующей презентации проверьте, является ли объект формой [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) и содержит ли он встроенное изображение. Связанные рамки могут не содержать байты изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображения использует [IImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/) напрямую и не требует старого Java‑обёртки изображения. В следующем примере находится первое встроенное растровое изображение на слайде и сохраняется как PNG:

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

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/java/com.aspose.slides/iimage/#save-java.lang.String-int-) преобразует извлечённое изображение в требуемый конечный формат. Если нужны закодированные байты, хранящиеся в презентации, а не преобразованный растр, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) раскрывает объект [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/). Это позволяет напрямую получить SVG‑данные без предварительного растрирования картинки.

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

Сохранение SVG‑контента в виде SVG сохраняет векторный источник внутри презентации. Экспорт в растр, такой как PNG или JPEG, обязательно преобразует вектор в пиксели. Экспорт слайда в PDF или SVG — тоже операция рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтная копия оригинального встроенного SVG; используйте данные [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/#getSvgData--) при необходимости самого векторного ресурса.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри рамки. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) указаны в процентах от размеров исходного изображения. Обрезка первоначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

В следующем примере безопасно находится рамка изображения и применяются значения обрезки:

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области могут быть физически удалены, как описано в следующем разделе.

## **Удаление данных обрезанных изображений**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели больше недоступны для последующей операции «отобрезки».

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF‑контента этим методом растрирует результат в PNG.

## **Сжатие растровых изображений**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором картинка отображается. Он также может удалять обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено в размере или обрезано, и `false`, когда изменение не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/java/com.aspose.slides/picturescompression/) при достаточном стандартном целевом разрешении:

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

При необходимости конкретного целевого разрешения можно передать пользовательское положительное значение DPI вместо предопределённого.

Сжатие предназначено для растровых изображений. SVG‑ и метафайловый контент этим raster‑сжатием не уменьшается. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, при котором изображение действительно будет просматриваться или экспортаироваться, а не применяйте минимальный DPI глобально.

## **Управление эффектами трансформации изображений**

Для полного рабочего процесса, включающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, инспекцию, удаление и проверку обратного пути, см. [Image Transform Effects](/java/image-transform-effects/).

## **Блокировка геометрии рамки изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframelock/) управляют тем, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при её изменении размеров.

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

Блокировка применяется к форме рамки изображения. Она не заставляет исходное изображение пересэмплироваться или постоянно изменяться до тех же пропорций.

## **Регулировка значений StretchOffset**

Когда режим заливки изображения — растяжка, значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/) определяют прямоугольник заливки относительно ограничивающего бокса рамки изображения. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видима; stretch‑offset изменяют прямоугольник, в который растягивается видимая заливка изображения.

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

Используйте stretch‑offset для размещения заливки. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранилище, размер файла и соображения экспорта**

Основные компромиссы проще учитывать, когда хранение изображений и форматирование рамок обрабатываются отдельно:

- **Встроенные изображения** делают презентацию самодостаточной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или локациям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются при сжатии.
- **Сжатие** может существенно уменьшить размер файла для oversized‑растровых изображений, но теряется исходное разрешение. Его следует применять после определения окончательного размера на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрендеренный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/), а не многократно загружать один и тот же файл в рабочий процесс презентации.

Для больших презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: хранить логотипы и схемы как векторный контент, сжимать фотографии в соответствии с их реальными размерами отображения, удалять обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегать внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) — это форма на слайде, отображающая изображение и хранящая параметры уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда хранение файлов изображений вне PPTX является намеренным и внешние местоположения могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть окончательно удалены.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальное исходное изображение вне презентации, если в дальнейшем может потребоваться высокое разрешение для редактирования.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

** Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для рамки изображения. Проверка `instanceof` относительно [IPictureFrame](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ipictureframe/) предотвращает недопустимые привидения и позволяет коду корректно обрабатывать слайды, не содержащие рамок изображений.