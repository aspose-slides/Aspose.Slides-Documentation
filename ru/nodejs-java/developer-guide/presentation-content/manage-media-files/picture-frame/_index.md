---
title: Рамка изображения
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
- обрезать изображение
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- эффект изображения
- соотношение сторон
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides for Node.js via Java
description: "Добавить рамку изображения в презентацию PowerPoint с помощью JavaScript"
---

Picture Frame — это фигура, содержащая изображение, подобно картине в рамке.  

Вы можете добавить изображение на слайд через Picture Frame. Таким способом вы форматируете изображение, форматируя саму рамку.  

{{% alert title="Совет" color="primary" %}}  
Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — позволяющие быстро создавать презентации из изображений.  
{{% /alert %}}  

## **Создание Picture Frame**  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект `PPImage`, добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которое будет использоваться для заполнения фигуры.  
4. Укажите ширину и высоту изображения.  
5. Создайте [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) на основе ширины и высоты изображения с помощью метода `addPictureFrame`, доступного у объекта формы, связанного с выбранным слайдом.  
6. Добавьте рамку (с изображением) на слайд.  
7. Запишите изменённую презентацию в файл PPTX.  

Этот JavaScript‑код показывает, как создать Picture Frame:  
```javascript
    // Создает экземпляр класса Presentation, представляющего файл PPTX
    var pres = new aspose.slides.Presentation();
    try {
        // Получает первый слайд
        var sld = pres.getSlides().get_Item(0);
        // Создает экземпляр класса Image
        var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
        // Добавляет рамку изображения с эквивалентными высотой и шириной картинки
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
  

{{% alert color="warning" %}}  
Picture Frames позволяют быстро создавать слайды на основе изображений. Комбинируя Picture Frame с параметрами сохранения Aspose.Slides, вы можете управлять операциями ввода/вывода для конвертации изображений между форматами. Полезные страницы: конвертация [изображения в JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); конвертация [JPG в изображение](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); конвертация [JPG в PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), конвертация [PNG в JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); конвертация [PNG в SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), конвертация [SVG в PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).  
{{% /alert %}}  

## **Создание Picture Frame с относительным масштабом**  

Изменяя относительное масштабирование изображения, можно создать более сложный Picture Frame.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте изображение в коллекцию изображений презентации.  
4. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которое будет использоваться для заполнения фигуры.  
5. Укажите относительные ширину и высоту изображения в рамке.  
6. Запишите изменённую презентацию в файл PPTX.  

Этот JavaScript‑код показывает, как создать Picture Frame с относительным масштабом:  
```javascript
// Создает экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создает экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавляет рамку изображения с высотой и шириной, равными картинке
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Устанавливает относительные масштаб ширины и высоты
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Сохраняет файл PPTX на диск
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
  

## **Извлечение растровых изображений из Picture Frames**  

Можно извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFrame) и сохранять их в PNG, JPG и другие форматы. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.  
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
  

## **Извлечение SVG‑изображений из Picture Frames**  

Когда презентация содержит векторную графику SVG, помещённую в формы [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java позволяет получить оригинальные векторные изображения с полной точностью. Проходя по коллекции фигур слайда, можно определить каждый [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), проверить, содержит ли связанный [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) SVG‑контент, и затем сохранить изображение в нативном формате SVG.  

Следующий пример кода демонстрирует извлечение SVG‑изображения из рамки:  
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
  

## **Форматирование Picture Frame**  

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к Picture Frame. С их помощью вы можете изменить рамку так, чтобы она отвечала конкретным требованиям.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).  
2. Получите ссылку на слайд по его индексу.  
3. Создайте объект [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PPImage), добавив изображение в [ImagesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection), связанную с объектом презентации, которое будет использоваться для заполнения формы.  
4. Укажите ширину и высоту изображения.  
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) объекта [Shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection), связанного с выбранным слайдом.  
6. Добавьте Picture Frame (с изображением) на слайд.  
7. Установите цвет линии рамки.  
8. Установите ширину линии рамки.  
9. Поверните рамку, задав положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавьте Picture Frame (с изображением) на слайд.  
11. Запишите изменённую презентацию в файл PPTX.  

Этот JavaScript‑код демонстрирует процесс форматирования Picture Frame:  
```javascript
// Создаёт экземпляр класса Presentation, представляющего PPTX
var pres = new aspose.slides.Presentation();
try {
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Создаёт экземпляр класса Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Добавляет рамку изображения с высотой и шириной, равными изображению
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
  

{{% alert title="Совет" color="primary" %}}  
Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фото](https://products.aspose.app/slides/collage/photo-grid), используйте этот сервис.  
{{% /alert %}}  

## **Добавление изображения в виде ссылки**  

Чтобы уменьшить размер презентации, вместо внедрения файлов можно добавлять изображения (или видео) через ссылки. Этот JavaScript‑код показывает, как добавить изображение и видео в заполнитель:  
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
  

## **Удаление обрезанных областей из рамки**  

Если нужно удалить обрезанные области изображения, содержащегося в рамке, используйте метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Метод возвращает обрезанное изображение или оригинал, если обрезка не требуется.  

Этот JavaScript‑код демонстрирует операцию:  
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
Метод [deletePictureCroppedAreas()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), это может сократить размер презентации. В противном случае количество изображений в полученной презентации увеличится.  

Метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение во время операции обрезки.  
{{% /alert %}}  

## **Блокировка соотношения сторон**  

Чтобы форма, содержащая изображение, сохраняла соотношение сторон при изменении размеров изображения, используйте метод [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-), задающий параметр *Lock Aspect Ratio*.  

Этот JavaScript‑код показывает, как заблокировать соотношение сторон формы:  
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
    // установить форму, чтобы сохранять соотношение сторон при изменении размеров
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
  

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}  
Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, но не изображения, которое она содержит.  
{{% /alert %}}  

## **Использование свойства StretchOff**  

С помощью методов [setStretchOffsetLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) и [setStretchOffsetBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) класса [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PictureFillFormat) можно задать прямоугольник заполнения.  

При указании растягивания для изображения исходный прямоугольник масштабируется, чтобы вписаться в заданный прямоугольник заполнения. Каждая грань прямоугольника заполнения задаётся процентным смещением от соответствующей грани ограничивающего прямоугольника формы. Положительный процент задаёт врезку, отрицательный — выступ.  

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentatio).  
2. Получите ссылку на слайд по его индексу.  
3. Добавьте прямоугольник `AutoShape`.  
4. Создайте изображение.  
5. Задайте тип заполнения формы.  
6. Установите режим заполнения формы изображением.  
7. Добавьте изображение для заполнения формы.  
8. Укажите смещения изображения от соответствующей грани ограничивающего прямоугольника формы.  
9. Запишите изменённую презентацию в файл PPTX.  

Этот JavaScript‑код демонстрирует процесс применения свойства StretchOff:  
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
    // Устанавливает тип заливки формы
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Устанавливает режим заливки формы изображением
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Устанавливает изображение для заливки формы
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Указывает смещения изображения от соответствующей грани ограничивающего прямоугольника формы
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

**Как узнать, какие форматы изображений поддерживаются для Picture Frame?**  

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и др.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка конвертации слайдов и изображений.  

**Как добавление десятков крупных изображений влияет на размер и производительность PPTX?**  

Встраивание больших изображений увеличивает размер файла и потребление памяти; привязка изображений через ссылки помогает уменьшить размер презентации, но требует постоянной доступности внешних файлов. Aspose.Slides позволяет добавлять изображения по ссылке, чтобы сократить размер файла.  

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**  

Используйте [блокировки форм](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки описан в отдельной статье о [защите](/slides/ru/nodejs-java/applying-protection-to-presentation/) и поддерживается для различных типов форм, включая [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).  

**Сохраняется ли точность векторного SVG при экспорте презентации в PDF/изображения?**  

Aspose.Slides позволяет извлекать SVG из [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/nodejs-java/convert-powerpoint-to-pdf/) или в [растровые форматы](/slides/ru/nodejs-java/convert-powerpoint-to-png/) результат может быть растеризован в зависимости от настроек экспорта; факт того, что оригинальный SVG хранится как вектор, подтверждается поведением извлечения.  