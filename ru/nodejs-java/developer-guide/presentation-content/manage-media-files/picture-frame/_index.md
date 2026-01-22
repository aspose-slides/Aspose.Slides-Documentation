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
description: "Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides for Node.js via Java. Оптимизируйте рабочий процесс и улучшите дизайн слайдов."
---

Рамка изображения — это форма, содержащая изображение, почти как картина в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Подсказка" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

## **Создать рамку изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект `PPImage`, добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) на основе ширины и высоты изображения через метод `addPictureFrame`, предоставляемый объектом формы, связанным с указанным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать рамку изображения:
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
    // Сохраняет файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. Комбинируя рамку изображения с параметрами сохранения Aspose.Slides, вы можете управлять операциями ввода/вывода для преобразования изображений из одного формата в другой.

## **Создать рамку изображения с относительным масштабом**

Изменяя относительный масштаб изображения, можно создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
5. Укажите относительную ширину и высоту изображения в рамке.
6. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript показывает, как создать рамку изображения с относительным масштабом:
```javascript
// Создать класс Presentation, представляющий PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получить первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создать экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавить рамку изображения с высотой и шириной, эквивалентными изображению
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Установка относительного масштаба ширины и высоты
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Сохранить файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Извлечь растровые изображения из рамок**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) и сохранять их в форматах PNG, JPG и других. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.
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


## **Извлечь SVG‑изображения из рамок**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java позволяет получить оригинальные векторные изображения с полной точностью. Перебирая коллекцию фигур слайда, вы можете определить каждый [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), проверить, содержит ли нижележащий [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его нативном SVG‑формате.

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки:
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


## **Получить прозрачность изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот код JavaScript демонстрирует операцию:
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


## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью вы можете изменить рамку, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанный с объектом презентации, который будет использоваться для заполнения формы.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) объекта [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection), связанного с указанным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Установите цвет линии рамки изображения.
8. Установите ширину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение.
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержащую картинку) на слайд.
11. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript демонстрирует процесс форматирования рамки изображения:
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создаёт экземпляр класса Image
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


{{% alert title="Подсказка" color="primary" %}}
Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этим сервисом. 
{{% /alert %}}

## **Добавить изображение как ссылку**

Чтобы избежать большого размера презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот код JavaScript показывает, как добавить изображение и видео в заполнитель:
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


## **Обрезать изображение**

Этот код JavaScript показывает, как обрезать существующее изображение на слайде:
```javascript
var pres = new aspose.slides.Presentation();
// Создаёт новый объект изображения
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
    // Добавляет PictureFrame на слайд
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


## **Удалить обрезанные области рисунка**

Если необходимо удалить обрезанные области изображения, содержащегося в рамке, используйте метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот код JavaScript демонстрирует операцию:
```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Получает PictureFrame с первого слайда
    var picFrame = slide.getShapes().get_Item(0);
    // Удаляет обрезанные области изображения PictureFrame и возвращает обрезанное изображение
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Сохраняет результат
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 
Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение во время операции обрезки. 
{{% /alert %}}

## **Блокировать соотношение сторон**

Если необходимо, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) для установки параметра *Lock Aspect Ratio*.

Этот код JavaScript показывает, как заблокировать соотношение сторон формы:
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
    // установить форму для сохранения соотношения сторон при изменении размера
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}} 
Данный параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не изображения, которое она содержит. 
{{% /alert %}}

## **Использовать свойство StretchOff**

С помощью методов [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) и [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) класса [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat) вы можете задать прямоугольник заполнения.

При указании растягивания для изображения исходный прямоугольник масштабируется до размеров заданного прямоугольника заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего прямоугольника формы. Положительный процент задаёт внутренний отступ, отрицательный — наружный отступ.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Получите ссылку на слайд по его индексу.
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение.
5. Установите тип заполнения формы.
6. Установите режим заполнения формы изображением.
7. Добавьте изображение для заполнения формы.
8. Задайте смещения изображения от соответствующей грани ограничивающего прямоугольника формы.
9. Запишите изменённую презентацию в файл PPTX.

Этот код JavaScript демонстрирует процесс использования свойства StretchOff:
```javascript
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var slide = pres.getSlides().get_Item(0);
    // Создаёт экземпляр класса ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Добавляет AutoShape типа Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Устанавливает тип заполнения фигуры
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Устанавливает режим заполнения фигурой изображением
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
Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/). Список поддерживаемых форматов обычно перекрывается возможностями движка конвертации слайдов и изображений.

**Как добавление десятков больших изображений повлияет на размер PPTX и производительность?**  
Встраивание больших изображений увеличивает размер файла и потребление памяти; использование ссылок на изображения помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размеров?**  
Используйте [блокировки формы](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размеров). Механизм блокировки поддерживается для различных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**  
Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/nodejs-java/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт хранения оригинального SVG как вектора подтверждается поведением извлечения.