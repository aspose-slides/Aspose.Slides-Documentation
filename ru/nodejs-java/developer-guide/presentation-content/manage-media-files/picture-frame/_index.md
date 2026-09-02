---
title: Управление рамками изображений в презентациях с использованием JavaScript
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/nodejs-java/picture-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Рамка изображения — это объект формы слайда, который отображает изображение. В Aspose.Slides ресурс изображения и форма, отображающая его, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) хранит встроенные ресурсы изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/), в то время как [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) управляет положением изображения, его размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Такое разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании рамок изображения.

Рамки изображения могут содержать растровые изображения, такие как PNG или JPEG, а также векторные изображения SVG. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение при экспорте, поэтому полезно решить, как изображение будет храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся самостоятельной при перемещении на другой компьютер.

Следующий пример добавляет PNG‑изображение, создаёт рамку с исходными размерами изображения и применяет форматирование линий и вращение:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Рамка изображения управляет отображаемой геометрией; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) предоставляет возможность относительного масштабирования ширины и высоты рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % исходного размера изображения. Относительный масштаб полезен, когда рабочий процесс требует сохранения отношения к размеру исходного изображения вместо ручного расчёта конечных размеров.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Относительный масштаб изменяет настройки масштаба рамки; он не переобразует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым надёжным выбором для переносимости и предсказуемого отображения. Связанное изображение хранит внешний путь через метод [Picture.setLinkPathLong](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, которое открывает или отображает презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступным, связанное изображение может не отобразиться как ожидается. Для презентаций, которые должны отправляться по электронной почте, архивироваться или отображаться в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Он охватывает только привязку изображения; привязка видео — отдельный медиа‑рабочий процесс и намеренно не смешана в этом примере.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте ссылки, когда внешнее управление файлами целенаправленно. Не используйте их просто как замену сжатию: небольшой PPTX с разрушенными зависимостями изображений обычно менее полезен, чем более крупная самостоятельная презентация.

## **Извлечение изображений из рамок**

Перед извлечением изображения из существующей презентации проверьте, является ли форма действительно [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) и содержит ли она встроенное изображение. Связанные рамки изображения могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) напрямую. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/#save) преобразует извлечённое изображение в запрошенный формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑рисунка объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/). Это позволяет получить данные SVG напрямую, без растрирования изображения.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Сохранение SVG‑содержимого как SVG сохраняет векторный источник внутри презентации. Растровые экспорты, такие как PNG или JPEG, обязательно преобразуют векторное содержимое в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как точная копия оригинального встроенного SVG; используйте данные [SvgImage.getSvgData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/#getSvgData--) когда требуется сам оригинальный векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри рамки. Значения обрезки в [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Следующий пример безопасно находит рамку изображения и применяет значения обрезки:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если важен размер файла больше, чем возможность обратимого восстановления, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление данных обрезанного изображения**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может снизить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «отмены обрезки».

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём существующем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF содержимого с помощью этого метода растрирует результат в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором оно отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено по размеру или обрезано, и `false`, когда изменений не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturescompression/), когда достаточен стандартный целевой уровень разрешения:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Вместо предопределённого значения можно передать пользовательское положительное значение DPI, когда требуется конкретный целевой параметр.

Сжатие предназначено для растровых изображений. SVG‑ и метафайл‑содержимое не уменьшается этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, основываясь на наибольшем размере, при котором изображение действительно будет просматриваться или экспортироваться, а не применяя минимальный DPI глобально.

## **Управление эффектами преобразования изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые преобразования, размытие, альфа‑эффекты, упорядоченные цепочки, инспекцию, удаление и проверку обратного пути, см. [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Блокировка геометрии рамки изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при изменении её размеров.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Блокировка применяется к форме рамки изображения. Она не принуждает исходное изображение к переобразованию или постоянному изменению до того же соотношения сторон.

## **Регулировка значений StretchOffset**

Когда режим заливки изображения установлен в «растянуть», значения stretch‑offset в [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) определяют прямоугольник заливки относительно ограничивающего блока рамки изображения. Положительные проценты создают отступ от края, а отрицательные — выступ.

Это отличается от обрезки. Параметры обрезки выбирают, какая часть исходного изображения видна; stretch‑offset изменяет прямоугольник, в который растягивается видимая заливка.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте stretch‑offset для размещения заливки. Используйте параметры обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Основные компромиссы легче управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию самостоятельной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** изначально некрупна. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удалены или не удалены в процессе сжатия.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но ухудшает исходное разрешение. Его следует применять после того, как известен фактический размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна сохранность вектора. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Экспорты слайдов в растровый формат всегда преобразуют отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизацию изображений обычно эффективнее выполнять выборочно: храните логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) — это форма на слайде, отображающая изображение и хранящая геометрию и форматирование уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно храните файлы изображений вне PPTX и внешние расположения могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют скрытые пиксели. Используйте [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) или сжатие изображений с удалением обрезанных областей, когда эти пиксели можно удалить окончательно.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Сохраняйте оригинальное исходное изображение вне презентации, если в дальнейшем может потребоваться редактирование с высоким разрешением.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑содержание как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверяйте тип формы перед использованием членов, специфичных для рамки изображения. Проверка `java.instanceOf` против [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) предотвращает неверные приведения и позволяет коду обрабатывать слайды, не содержащие рамок изображения.