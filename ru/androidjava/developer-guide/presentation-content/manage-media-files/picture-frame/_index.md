---
title: У管理ление рамками изображений в презентациях на Android
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

Рамка изображения — это фигура слайда, отображающая изображение. В Aspose.Slides ресурс изображения и фигура, отображающая его, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) владеет встроенными ресурсами изображений через его [IImageCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/), в то время как [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) управляет положением изображения, его размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение удобно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок изображений.

Рамки изображений могут содержать растровые изображения, такие как PNG или JPEG, и векторные изображения SVG. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, прежде чем применять форматирование или оптимизацию.

## **Добавить и отформатировать встроенное изображение**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

В следующем примере добавляется JPEG‑изображение, создаётся рамка с размером изображения в его исходных размерах и применяются форматирование линий и вращение:

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

Рамка изображения управляет отображаемой геометрией; изменение размера рамки не меняет оригинальные pixel‑размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использовать относительный масштаб**

[IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты рамки через методы [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % от оригинального размера изображения. Относительный масштаб полезен, когда рабочий процесс требует сохранять связь с размером исходного изображения вместо ручного вычисления конечных размеров.

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

Относительный масштаб меняет настройки масштабирования рамки; он не пере‑семплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная картинка хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого рендеринга. Связанная картинка хранит внешний путь через метод [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же образом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанная картинка может не отобразиться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно надёжнее.

### **Добавить связанное изображение**

В следующем примере создаётся рамка изображения и указывается локальный файл изображения. Пример рассматривает только связывание изображений; связывание видео — отдельный медиа‑рабочий процесс и намеренно не смешано в этом примере.

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

Используйте ссылки, когда внешнее управление файлами является намеренным. Не используйте их просто как замену сжатию: небольшая PPTX с повреждёнными зависимостями изображений обычно менее полезна, чем более крупная автономная презентация.

## **Извлекать изображения из рамок изображений**

Прежде чем извлекать изображение из существующей презентации, проверьте, что фигура действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) и что она содержит встроенное изображение. Связанные рамки изображений могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечь растровое изображение**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) напрямую и не требует старого Java‑обёртки изображения. В следующем примере находится первое встроенное растровое изображение на слайде и сохраняется как PNG:

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

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) конвертирует извлечённое изображение в требуемый формат вывода. Если нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечь SVG‑изображение**

Для SVG‑картинки [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/). Это позволяет получить SVG‑данные напрямую, не растрируя картинку сначала.

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

Хранение SVG‑контента как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно рендерит векторный контент в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтовая копия оригинального встроенного SVG; используйте данные [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/#getSvgData--) при необходимости самого векторного ресурса.

## **Обрезать изображение**

Обрезка меняет, какая часть изображения видна внутри рамки. Значения обрезки на [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) указаны в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она только изменяет видимую область.

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удалить обрезанные данные изображения**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели больше недоступны для последующей операции «откобрать».

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, этим рамкам всё равно нужен существующий ресурс, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF с помощью этого метода растрирует полученный результат в PNG.

## **Сжать растровые изображения**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалять обрезанные области в той же операции. Метод возвращает `true`, если изображение было изменено размером или обрезано, и `false`, если изменение не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/picturescompression/) тогда, когда достаточно стандартного целевого разрешения:

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

При необходимости конкретного целевого разрешения вместо предопределённого значения можно передать пользовательское положительное значение DPI.

Сжатие предназначено для растровых изображений. SVG‑и метафайл‑контент не уменьшается этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, в котором изображение будет фактически просматриваться или экспортироваться, а не применяйте самое низкое DPI глобально.

## **Управление эффектами трансформации изображений**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и проверку обратного хода, см. [Image Transform Effects](/slides/ru/androidjava/image-transform-effects/).

## **Блокировать геометрию рамки изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции фигуры при изменении её размера.

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

Блокировка применяется к фигуре рамки изображения. Она не заставляет исходное изображение быть пере‑семплированным или постоянно изменённым до тех же пропорций.

## **Настроить значения StretchOffset**

Когда режим заполнения изображения — растяжка, значения stretch‑offset на [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса рамки изображения. Положительные проценты создают отступ от края, отрицательные — выступ.

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

Используйте stretch‑offset для размещения заливки. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения экспорта**

Основные компромиссы легче управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но большие растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от внешних файлов, остающихся доступными по сохранённым путям или локациям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными до тех пор, пока обрезанные области явно не удаляются или не удаляются во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для превышающих размер растровых изображений, но жертвуя исходным разрешением. Его следует применять после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна сохранность вектора. Извлекайте встроенный SVG напрямую, если нужен сам векторный ресурс. Экспорт слайдов в растр всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: хранить логотипы и схемы как векторный контент, сжимать фотографии согласно их реальному отображаемому размеру, удалять обрезанные пиксели только тогда, когда дальнейшее редактирование не требуется, и избегать внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) — это фигура на слайде, отображающая изображение и хранящая настройки уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Нужно ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда хранение файлов изображений вне PPTX является намеренным и внешние пути могут надёжно поддерживаться.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют базовые пиксели. Используйте [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть окончательно удалены.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Храните оригинальное исходное изображение вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверяйте тип фигуры перед использованием членов, специфичных для рамки изображения. Проверка `instanceof` против [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) предотвращает неправильные привидения и позволяет коду обрабатывать слайды, не содержащие рамки изображения.