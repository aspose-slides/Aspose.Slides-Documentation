---
title: Управление рамками изображений в презентациях с помощью JavaScript
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

Рамка изображения — это элемент слайда, отображающий изображение. В Aspose.Slides ресурс изображения и элемент, который его отображает, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою [ImageCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/), тогда как [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) управляет положением изображения, размером, форматированием линий, вращением, обрезкой, эффектами изображения и другими параметрами уровня рамки.

Это разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните полученный [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/), и используйте этот ресурс изображения при создании рамок изображения.

Рамки изображения могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо того, чтобы хранить байты изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, прежде чем применять форматирование или оптимизацию.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет PNG‑изображение, создаёт рамку с оригинальными размерами изображения и применяет форматирование линий и вращение:

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

[PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) предоставляет относительное масштабирование ширины и высоты для рамки через [setRelativeScaleWidth](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) и [setRelativeScaleHeight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Значение `1.0` соответствует 100 % оригинального размера изображения. Относительный масштаб полезен, когда рабочий процесс требует сохранения отношения к размеру исходного изображения вместо ручного расчёта окончательных размеров.

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

Относительный масштаб изменяет настройки масштаба рамки; он не пересамплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенное изображение хранит данные изображения внутри презентации и поэтому является самым надёжным вариантом с точки зрения переносимости и предсказуемого рендеринга. Связанное изображение хранит внешний путь через метод [Picture.setLinkPathLong](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) вместо внедрения данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, открывающего или рендерящего презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанное изображение может не отображаться как ожидалось. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Он работает только с привязкой изображений; привязка видео — отдельный медиаворкфлоу и намеренно не смешана в этом примере.

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

Используйте ссылки, когда управление внешними файлами намеренно. Не используйте их просто как замену сжатию: небольшой PPTX с нарушенными зависимостями изображений обычно менее полезен, чем более крупная автономная презентация.

## **Извлечение изображений из рамок изображения**

Прежде чем извлекать изображение из существующей презентации, проверьте, что элемент действительно является [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) и содержит встроенное изображение. Связанные рамки изображения могут не содержать байтов изображения, которые можно извлечь тем же способом.

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

Сохранение через [IImage.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/#save) преобразует извлечённое изображение в запрошенный формат вывода. Если вам нужны исходные закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑изображения объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) предоставляет объект [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/). Это позволяет получить данные SVG напрямую, не растрируя изображение сначала.

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

Сохранение содержимого SVG как SVG сохраняет векторный источник внутри презентации. Растровые экспорты, такие как PNG или JPEG, обязаны рендерить этот вектор в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтная копия оригинального встроенного SVG; используйте данные [SvgImage.getSvgData](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/#getSvgData--) встроенного SVG, когда требуется именно векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет, какая часть изображения видна внутри рамки. Значения обрезки на [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она только меняет видимую область.

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

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже, не теряя оригинальные пиксели. Если размер файла важнее обратимости, обрезанные регионы можно физически удалить, как описано в следующем разделе.

## **Удаление данных обрезанных изображений**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является деструктивной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «отвёртки» обрезки.

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём текущем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF этим методом растрирует результат обрезки в PNG.

## **Сжатие растровых изображений**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) уменьшает разрешение растрового изображения относительно размера, в котором изображение отображается. Он также может удалять обрезанные регионы в той же операции. Метод возвращает `true`, когда изображение было изменено по размеру или обрезано, и `false`, когда изменение не требовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturescompression/), когда стандартное целевое разрешение достаточно:

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

Можно передать пользовательское положительное значение DPI вместо предопределённого, когда требуется конкретная цель.

Сжатие предназначено для растровых изображений. SVG и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные регионы нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, при котором изображение будет действительно просматриваться или экспортироваться, а не применяйте минимальный DPI глобально.

## **Проверка эффектов изображения**

Эффекты изображения хранятся в изображении, используемом рамкой. Коллекция трансформов изображения может содержать эффекты, такие как фиксированная альфа‑модуляция для прозрачности и яркость/контраст для светимости. Пример ниже безопасно читает оба типа эффектов из первой рамки изображения на слайде:

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
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Эти эффекты меняют способ рендеринга изображения в рамке; они не переписывают оригинальные байты встроенного изображения.

## **Блокировка геометрии рамки изображения**

Настройки [PictureFrameLock](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframelock/) управляют тем, какие операции редактирования отключены для рамки изображения. Например, [setAspectRatioLocked](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) сохраняет пропорции формы при её изменении размеров.

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

Блокировка применяется к форме рамки изображения. Она не заставляет исходное изображение быть пересамплировано или навсегда изменено до тех же пропорций.

## **Настройка значений StretchOffset**

Когда режим заливки изображения установлен в «stretch», значения stretch‑offset на [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) определяют прямоугольник заливки относительно ограничивающего прямоугольника рамки изображения. Положительные проценты создают отступ от края, а отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видима; смещения stretch изменяют прямоугольник, в который видимая заливка изображения растягивается.

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

Используйте смещения stretch для размещения заливки. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Хранение, размер файла и соображения по экспорту**

Основные компромиссы легче управлять, когда хранение изображений и форматирование рамок изображения рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют сократить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или местоположениям.
- **Обрезка** изначально не является разрушительной. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удалены или не удалены во время сжатия.
- **Сжатие** может значительно уменьшить размер файла для слишком больших растровых изображений, но снижает исходное разрешение. Его следует применять после определения окончательного размера изображения на слайде.
- **SVG‑изображения** следует сохранять как SVG, когда важна векторная целостность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Экспорт слайдов в растровый формат всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [PPImage], когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для крупных презентаций оптимизацию изображений обычно наиболее эффективно выполнять выборочно: сохраняйте логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда последующее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **FAQ**

**В чём разница между рамкой изображения и ресурсом изображения?**

[PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) представляет ресурс изображения, связанный с презентацией. [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) — это элемент на слайде, который отображает изображение и хранит параметры уровня рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Стоит ли внедрять или связывать изображения?**

Внедряйте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно хранить файлы изображений вне PPTX и внешние расположения могут поддерживаться надёжно.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют подлежащие пиксели. Используйте [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) или сжатие изображения с удалением обрезанных областей, когда эти пиксели могут быть удалены безвозвратно.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей удаляет данные изображения. Держите оригинальное исходное изображение вне презентации, если позже может понадобиться редактирование в высоком разрешении.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте содержимое SVG как SVG, когда важна векторная точность. Встроенный [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) можно извлечь напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растрирует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверьте тип элемента перед использованием членов, специфичных для рамки изображения. Проверка `java.instanceOf` относительно [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) избегает недопустимых приводов и позволяет коду корректно обрабатывать слайды без рамок изображения.