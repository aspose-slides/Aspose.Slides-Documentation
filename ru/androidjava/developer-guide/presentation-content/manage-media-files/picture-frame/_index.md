---
title: Управление рамками изображений в презентациях на Android
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/androidjava/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG‑изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для Android через Java."
---
## **Обзор**

Рамка изображения — это объект формы слайда, отображающий изображение. В Aspose.Slides ресурс изображения и форма, отображающая его, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) владеет встроенными ресурсами изображений через свой [IImageCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/), в то время как [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) управляет позицией изображения, размером, форматированием линии, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок.

Рамки изображения могут содержать растровые изображения, такие как PNG или JPEG, а также векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и экспорт, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся самодостаточной при перемещении на другой компьютер.

В следующем примере добавляется JPEG‑изображение, создаётся рамка с нативными размерами изображения и применяется форматирование линии и вращение:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Рамка изображения управляет отображаемой геометрией; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты рамки через методы [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % оригинального размера картинки. Относительный масштаб полезен, когда рабочий процесс должен сохранять соотношение с исходным размером изображения, а не вычислять конечные размеры вручную.

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

Относительный масштаб изменяет параметры масштабирования рамки; он не пере‑сэмплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная картинка хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого рендеринга. Связанная картинка хранит внешний путь через метод [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, которое открывает или выводит презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанная картинка может не отобразиться как ожидается. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или выводить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

В следующем примере создаётся рамка изображения и указывается ссылка на локальный файл изображения. Пример охватывает только связывание изображений; связывание видео — отдельный медиапроцесс и специально не смешивается в данном примере.

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

Используйте ссылки, когда управление внешними файлами задумано. Не используйте их просто как замену сжатию: небольшая PPTX с повреждёнными зависимостями изображений обычно менее полезна, чем большая самодостаточная презентация.

## **Извлечение изображений из рамок**

Перед извлечением изображения из существующей презентации проверьте, что объект действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) и что он содержит встроенное изображение. Связанные рамки могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) напрямую и не требует старого Java‑обёртки. В следующем примере находится первое встроенное растровое изображение на слайде и сохраняется как PNG:

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

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) преобразует извлечённое изображение в запрошенный формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки объект [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/). Это позволяет получить SVG‑данные напрямую, без растрирования картинки сначала.

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

Сохранение SVG‑контента в виде SVG сохраняет векторный источник внутри презентации. Экспорт в растровые форматы, такие как PNG или JPEG, обязательно рендерит векторный контент в пиксели. Экспорт слайда в PDF или SVG также является процессом рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтовая копия оригинального встроенного SVG; используйте данные [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/#getSvgData--) при необходимости самого векторного ресурса.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри рамки. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она только меняет видимую область.

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

Поскольку скрытые данные изображения по‑прежнему присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области могут быть физически удалены, как описано в следующем разделе.

## **Удаление обрезанных данных изображения**

Метод [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для обратной обрезки.

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своем существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF с помощью этого метода растрирует результат обрезки в PNG.

## **Сжатие растровых изображений**

Метод [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором картинка отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено в размере или обрезано, и `false`, когда изменений не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/picturescompression/) при достаточном стандартном целевом разрешении:

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

Можно передать пользовательское положительное значение DPI вместо предопределённого, если требуется конкретный целевой размер.

Сжатие предназначено для растровых изображений. SVG‑и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из наибольшего размера, при котором изображение действительно будет просматриваться или экспортироваться, а не применяйте самый низкий DPI глобально.

## **Просмотр эффектов изображения**

Эффекты изображения хранятся в картинке, используемой рамкой. Коллекция преобразований изображения может содержать эффекты, такие как фиксированная альфа‑модуляция для прозрачности и светлость для яркости и контраста. Пример ниже безопасно читает оба типа эффектов из первой рамки изображения на слайде:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Эти эффекты изменяют способ рендеринга изображения в рамке; они не переписывают оригинальные байты встроенного изображения.

## **Блокировка геометрии рамки изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при её изменении размеров.

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

Блокировка применяется к форме рамки изображения. Она не заставляет исходное изображение пере‑сэмплироваться или постоянно менять соотношение сторон.

## **Настройка значений StretchOffset**

Когда режим заполнения изображения установлен в растягивание, значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса рамки изображения. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видна; stretch‑offset меняет прямоугольник, в который растягивается видимая заливка изображения.

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

Используйте stretch‑offset для размещения заполнения. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения экспорта**

Основные компромиссы проще управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию самодостаточной и наиболее надёжной для обмена и серверного рендеринга, но большие растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, но презентация зависит от внешних файлов, оставшихся доступными по указанным путям или местоположениям.
- **Обрезка** изначально неразрушительна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для пере‑размерных растровых изображений, но оно уменьшает исходное разрешение. Применяйте его после того, как известен предполагаемый размер на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Экспорт слайдов в растровый формат всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage] вместо повторной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: оставляйте логотипы и схемы как векторный контент, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) — это форма на слайде, отображающая изображение и сохраняющая параметры уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда хранение файлов изображений вне PPTX задумано и внешние расположения могут поддерживаться надёжно.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть удалены окончательно.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальное исходное изображение вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для рамки изображения. Проверка `instanceof` против [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) избегает недопустимых привидений и позволяет коду корректно обрабатывать слайды, не содержащие рамок изображения.