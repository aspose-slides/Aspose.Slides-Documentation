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

Рамка изображения — это элемент слайда, который отображает изображение. В Aspose.Slides ресурс изображения и элемент, который его отображает, являются отдельными объектами: [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) владеет встроенными ресурсами изображения через свою [IImageCollection](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimagecollection/), тогда как [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) управляет положением изображения, размером, оформлением линии, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение удобно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок изображения.

Рамки изображения могут содержать растровые изображения, такие как PNG или JPEG, а также векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на портативность, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, прежде чем применять форматирование или оптимизацию.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт рамку с оригинальными размерами изображения и применяет оформление линии и вращение:

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

Рамка изображения управляет отображаемой геометрией; изменение размеров рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие важно при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительный масштаб полезен, когда рабочий процесс должен сохранять соотношение с исходным размером изображения вместо ручного расчёта конечных размеров.

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

Относительный масштаб меняет параметры масштаба рамки; он не выполняет перерасчёт или сжатие встроенного изображения.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым надёжным выбором с точки зрения портативности и предсказуемого рендеринга. Связанное изображение сохраняет внешний путь через метод [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они создают внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанное изображение может не отобразиться как ожидается. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. В примере рассматривается только связывание изображений; связывание видео — отдельный медиа‑рабочий процесс и намеренно не смешано с этим примером.

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

Используйте ссылки, когда управление внешними файлами является намеренным. Не используйте их просто как замену сжатию: небольшой PPTX с повреждёнными зависимостями изображений обычно менее полезен, чем более крупная автономная презентация.

## **Извлечение изображений из рамок изображения**

Прежде чем извлекать изображение из существующей презентации, проверьте, что форма действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) и что в ней содержится встроенное изображение. Связанные рамки изображения могут не содержать байты изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/) напрямую и не требует устаревшего Java‑обёртки. Следующий пример ищет первое встроенное растровое изображение на слайде и сохраняет его как PNG:

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

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) конвертирует извлечённое изображение в запрошенный формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не конвертированный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) предоставляет объект [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/). Это позволяет получить данные SVG напрямую, без предварительной растеризации изображения.

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

Сохранение содержимого SVG в виде SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязательно преобразует векторный контент в пиксели. Экспорт слайда в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как точная копия оригинального встроенного SVG; используйте данные [ISvgImage.getSvgData](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/#getSvgData--) когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка меняет видимую часть изображения внутри рамки. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Следующий пример безопасно находит рамку изображения и применяет значения обрезки:

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже, не теряя оригинальные пиксели. Если важен размер файла больше, чем обратимость, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление данных обрезанных изображений**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «разобрезки».

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, этим рамкам всё равно нужен их существующий ресурс, поэтому удаление обрезанных областей не обязательно уменьшит общее количество изображений. Обрезка WMF или EMF с помощью этого метода растеризует результат в PNG.

## **Сжатие растровых изображений**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено размером или обрезано, и `false`, когда изменений не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/picturescompression/), когда достаточно стандартного целевого разрешения:

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

Сжатие предназначено для растровых изображений. SVG‑ и метафайл‑контент не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, при котором изображение будет действительно просматриваться или экспортироваться, а не применяя наименьшее DPI глобально.

## **Управление трансформационными эффектами изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые преобразования, размытие, альфа‑эффекты, упорядоченные цепочки, проверку, удаление и двойную проверку, см. [Image Transform Effects](/androidjava/image-transform-effects/).

## **Блокировка геометрии рамки изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при изменении её размеров.

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

Блокировка применяется к форме рамки изображения. Она не заставляет исходное изображение быть перерасчётным или постоянно изменённым до тех же пропорций.

## **Настройка значений StretchOffset**

Когда режим заливки изображения установлен в «растянуть», значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/) определяют прямоугольник заливки относительно ограничивающего прямоугольника рамки изображения. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видна; stretch‑offset изменяют прямоугольник, в который видимая заливка изображения растягивается.

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

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, но презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются во время сжатия.
- **Сжатие** может значительно уменьшить размер файла для слишком больших растровых изображений, но снижает исходное разрешение. Его следует применять после того, как известен предполагаемый размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна сохранность вектора. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрендеренный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для крупных презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: храните логотипы и схемы как векторный контент, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) — это элемент на слайде, который отображает изображение и хранит параметры геометрии и форматирования рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Следует ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть портативной, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда хранение файлов изображений вне PPTX является намеренным и внешние расположения могут надёжно поддерживаться.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные параметры обрезки скрывают части исходного изображения, но сохраняют нижележащие пиксели. Используйте [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть удалены навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей удаляет данные изображения. Храните оригинальное исходное изображение вне презентации, если впоследствии может потребоваться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте содержимое SVG как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверьте тип формы перед использованием членов, специфичных для рамки изображения. Проверка `instanceof` против [IPictureFrame](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ipictureframe/) предотвращает неверные приведения и позволяет коду корректно обрабатывать слайды, не содержащие рамок изображения.