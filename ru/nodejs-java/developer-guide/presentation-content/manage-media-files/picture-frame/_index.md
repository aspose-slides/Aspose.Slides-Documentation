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
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java. Упростите рабочий процесс и улучшите дизайн слайдов."
---
## **Введение**

Рамка изображения — это фигура, содержащая изображение, похожая на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект `PPImage`, добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которая будет использована для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFrame) на основе ширины и высоты изображения через метод `addPictureFrame`, предоставляемый объектом shape, связанным с указанным слайдом.
6. Добавьте рамку изображения (содержащую картину) на слайд.
7. Запишите изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать рамку изображения:

```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создает экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавляет рамку изображения с эквивалентной высотой и шириной изображения
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. Комбинируя рамку изображения с параметрами сохранения Aspose.Slides, вы можете управлять вводом/выводом для конвертации изображений из одного формата в другой.

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, можно создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которая будет использована для заполнения фигуры.
5. Укажите относительную ширину и высоту изображения в рамке изображения.
6. Запишите изменённую презентацию в файл PPTX.

Этот JavaScript‑код показывает, как создать рамку изображения с относительным масштабом:

```javascript
// Создает экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создает экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавляет рамку изображения с высотой и шириной, эквивалентными изображению
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Устанавливает относительный масштаб ширины и высоты
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Извлечение растровых изображений из рамок изображения**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFrame) и сохранять их в формате PNG, JPG и других. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Извлечение SVG‑изображений из рамок изображения**

Когда презентация содержит SVG‑графику, помещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java позволяет получить оригинальные векторные изображения с полной точностью. Путём обхода коллекции фигур слайда можно определить каждый [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/), проверить, содержит ли связанный [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его изначальном формате SVG.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки изображения:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот JavaScript‑код демонстрирует операцию:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Получение яркости и контрастности изображения**

Aspose.Slides позволяет получить эффекты яркости и контрастности, применённые к изображению. Класс [Luminance](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/luminance/) представляет этот трансформационный эффект изображения.

Этот JavaScript‑код демонстрирует, как получить настройки яркости и контрастности из рамки изображения:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С помощью этих параметров вы можете изменить рамку изображения так, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которая будет использована для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) объекта [Shapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ShapeCollection), связанного с указанным слайдом.
6. Добавьте рамку изображения (содержащую картину) на слайд.
7. Установите цвет линии рамки изображения.
8. Установите толщину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержащую картину) на слайд.
11. Запишите изменённую презентацию в файл PPTX.

Этот JavaScript‑код демонстрирует процесс форматирования рамки изображения:

```javascript
// Создает экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создает экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавляет рамку изображения с высотой и шириной, эквивалентными изображению
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Применяет некоторое форматирование к PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Записывает файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose недавно разработала [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетки из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения как ссылки**

Чтобы избежать большого размера презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот JavaScript‑код показывает, как добавить изображение и видео в заполнитель:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Обрезка изображения**

Этот JavaScript‑код показывает, как обрезать существующее изображение на слайде:

```javascript
var pres = new aspose.slides.Presentation();
// Создает новый объект изображения
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет рамку изображения на слайд
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Обрезает изображение (значения в процентах)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Сохраняет результат
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Удаление обрезанных областей изображения**

Если нужно удалить обрезанные области изображения, содержащегося в рамке, вы можете воспользоваться методом [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Этот метод возвращает обрезанное изображение либо оригинальное изображение, если обрезка не требуется.

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Получает рамку изображения с первого слайда
    var picFrame = slide.getShapes().get_Item(0);
    // Удаляет обрезанные области изображения рамки и возвращает обрезанное изображение
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Сохраняет результат
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение в процессе обрезки. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации с помощью метода [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-). Этот метод сжимает изображение, уменьшая его размер в зависимости от размеров фигуры и заданного разрешения, с опцией удаления обрезанных областей.

Он корректирует размер и разрешение изображения аналогично функции PowerPoint **Picture Format → Compress Pictures → Resolution**.

Следующие примеры JavaScript демонстрируют, как сжать изображение в презентации, указав целевое разрешение и при желании удалив обрезанные области:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Сжимает изображение с целевым разрешением 150 DPI (веб-разрешение) и удаляет обрезанные области.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Проверяет результат сжатия.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Или используя другое предустановленное значение DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Сжимает изображение до 96 DPI (разрешение для email), удаляя обрезанные области.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод конвертирует изображение в более низкое разрешение, исходя из размеров фигуры и указанного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не будет применено. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично тому, как PowerPoint обрабатывает JPEG‑изображения высокого разрешения.

{{% /alert %}}

## **Блокировка пропорций**

Если необходимо, чтобы фигура, содержащая изображение, сохраняла свои пропорции даже после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Lock Aspect Ratio*.

Этот JavaScript‑код показывает, как заблокировать пропорции фигуры:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // установить фигуру так, чтобы сохранялось соотношение сторон при изменении размеров
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Параметр *Lock Aspect Ratio* сохраняет только пропорции самой фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Использование свойства StretchOff**

С помощью методов [setStretchOffsetLeft](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) и [setStretchOffsetBottom](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) класса [PictureFillFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/PictureFillFormat) вы можете задать прямоугольник заполнения.

При указании растягивания для изображения исходный прямоугольник масштабируется до указанных размеров заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника фигуры. Положительный процент задаёт внутренняя отступ, отрицательный — наружный отступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заливки фигуры.
6. Установите режим заливки изображения.
7. Добавьте изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующей грани ограничивающего прямоугольника фигуры.
9. Запишите изменённую презентацию в файл PPTX.

Этот JavaScript‑код демонстрирует процесс использования свойства StretchOff:

```javascript
// Создает экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Создает экземпляр класса ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет AutoShape с типом Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Устанавливает тип заливки фигуры
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Устанавливает режим заливки изображения фигуры
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Устанавливает изображение для заполнения фигуры
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Указывает смещения изображения от соответствующей грани ограничивающего прямоугольника фигуры
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Записывает файл PPTX на диск
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные изображения (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями движка конвертации слайдов и изображений.

**Как добавление десятков крупных изображений скажется на размере и производительности PPTX?**

Встраивание больших изображений увеличивает размер файла и потребление памяти; использование ссылок на изображения помогает сократить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для уменьшения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [блокировки фигур](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) в виде оригинального вектора. При [экспорте в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) или в [растровые форматы](/slides/ru/nodejs-java/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.