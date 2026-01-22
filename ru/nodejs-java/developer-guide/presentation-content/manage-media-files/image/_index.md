---
title: Оптимизация управления изображениями в презентациях с использованием JavaScript
linktitle: Управлять изображениями
type: docs
weight: 10
url: /ru/nodejs-java/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью JavaScript и Aspose.Slides для Node.js, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения на слайдах в презентациях**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами. 

{{% alert  title="Подсказка" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры —[JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение как объект рамки — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.д. — см. [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides поддерживает работу с изображениями в следующих популярных форматах: JPEG, PNG, GIF и другие. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода на JavaScript показывает, как добавить изображение на слайд:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавление изображений из потока на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить его напрямую из интернета. 

Этот пример кода показывает, как добавить изображение из интернета на слайд в JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Доступ к первому слайду
    var sld = pres.getSlides().get_Item(0);
    // Загружает файл Excel в поток
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Создаёт объект данных для встраивания
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Добавляет форму Ole Object Frame
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Записывает файл PPTX на диск
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавление изображений в мастер-слайды**

Мастер-слайд — это главный слайд, который хранит и контролирует информацию (тема, макет и т.д.) о всех слайдах под ним. Поэтому, когда вы добавляете изображение в мастер-слайд, это изображение появляется на каждом слайде под этим мастером. 

Этот пример кода на JavaScript показывает, как добавить изображение в мастер-слайд:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать картинку в качестве фона для конкретного слайда или нескольких слайдов. В этом случае см. *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection). 

Чтобы создать объект изображения на основе SVG, можно сделать следующее:

1. Создать объект SvgImage для вставки в ImageShapeCollection
2. Создать объект PPImage из ISvgImage
3. Создать объект PictureFrame, используя класс PPImage

Этот пример кода показывает, как реализовать указанные шаги для добавления SVG‑изображения в презентацию:
```javascript
// Создать объект класса Presentation, представляющий файл PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Преобразование SVG в набор фигур**
Преобразование SVG в набор фигур в Aspose.Slides аналогично функции PowerPoint, используемой для работы с SVG‑изображениями:

![PowerPoint Popup Menu](img_01_01.png)

Эта функциональность предоставляется одной из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection), который принимает объект [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG‑файла в набор фигур:
```javascript
// Создать новую презентацию
var presentation = new aspose.slides.Presentation();
try {
    // Прочитать содержимое SVG файла
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Создать объект SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Получить размер слайда
    var slideSize = presentation.getSlideSize().getSize();
    // Преобразовать SVG‑изображение в группу фигур, масштабируя его до размера слайда
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Сохранить презентацию в формате PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Добавление изображений в формате EMF на слайды**
Aspose.Slides для Node.js через Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды в формате EMF с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Сохранить рабочую книгу в поток
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, которые используются в фигурах слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с использованием необработанных байтовых данных, экземпляра [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) или другого изображения, уже существующего в коллекции. 

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Загрузите новое изображение из файла в массив байтов.
3. Замените целевое изображение новым изображением, используя массив байтов.
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) и замените целевое изображение этим объектом.
5. В третьем подходе замените целевое изображение изображением, которое уже существует в коллекции изображений презентации.
6. Сохраните изменённую презентацию в формате PPTX.
```js
// Создать экземпляр класса Presentation, представляющего файл презентации.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Первый способ.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Второй способ.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Третий способ.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Сохранить презентацию в файл.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Информация" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать текст, создавать GIF‑файлы из текста и т.д. 

{{% /alert %}}

## **Часто задаваемые вопросы**

**Сохраняется ли оригинальное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но конечный вид зависит от того, как [изображение](/slides/ru/nodejs-java/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Какой лучший способ заменить один и тот же логотип сразу на десятках слайдов?**

Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие этот ресурс.

**Можно ли вставленный SVG преобразовать в редактируемые фигуры?**

Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.

**Как установить картинку в качестве фона сразу для нескольких слайдов?**

[Назначьте изображение в качестве фона](/slides/ru/nodejs-java/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.

**Как предотвратить «раздувание» презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющуюся графику на мастере, где это уместно.