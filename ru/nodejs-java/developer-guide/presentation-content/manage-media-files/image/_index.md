---
title: Изображение
type: docs
weight: 10
url: /ru/nodejs-java/image/
keywords:
- добавить изображение
- добавить рисунок
- добавить bitmap
- заменить изображение
- заменить рисунок
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
- Aspose.Slides
description: "Оптимизируйте управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js, повышая производительность и автоматизируя ваш рабочий процесс."
---

## **Изображения на слайдах в презентациях**

Изображения делают презентации более увлекательными и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других мест на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами. 

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект кадра — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.п., см. [Picture Frame](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете управлять операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. См. эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в этих популярных форматах: JPEG, PNG, GIF и другие. 

## **Добавление изображений, хранящихся локально, на слайды**

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
    // Получает первый слайд
    var sld = pres.getSlides().get_Item(0);
    // Загружает файл Excel в поток
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Создает объект данных для встраивания
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


## **Добавление изображений в шаблоны слайдов**

Шаблон слайда (slide master) — это основной слайд, который хранит и управляет информацией (тема, макет и т.д.) обо всех слайдах, находящихся под ним. Поэтому, когда вы добавляете изображение в шаблон слайда, это изображение появляется на каждом слайде, использующем данный шаблон. 

Этот пример кода на JavaScript показывает, как добавить изображение в шаблон слайда:
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

Вы можете решить использовать картинку в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам следует посмотреть *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

Чтобы создать объект изображения на основе SVG, вы можете сделать это следующим образом:

1. Создать объект SvgImage для вставки его в ImageShapeCollection
2. Создать объект PPImage из ISvgImage
3. Создать объект PictureFrame, используя класс PPImage

Этот пример кода показывает, как реализовать указанные шаги для добавления SVG‑изображения в презентацию:
```javascript
// Создать экземпляр класса Presentation, представляющего файл PPTX
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

![Всплывающее меню PowerPoint](img_01_01.png)

Функциональность предоставляется одной из перегрузок метода [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) класса [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection), который принимает объект [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования файла SVG в набор фигур:
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
Aspose.Slides for Node.js via Java позволяет генерировать EMF‑изображения из листов Excel и добавлять их в слайды в виде EMF с помощью Aspose.Cells. 

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
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

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, что используются фигурами слайдов). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения, используя необработанные байтовые данные, экземпляр [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) или другое изображение, уже существующее в коллекции.

1. Загрузите файл презентации, содержащий изображения, используя класс [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Загрузите новое изображение из файла в массив байтов.
1. Замените целевое изображение новым, используя массив байтов.
1. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) и замените целевое изображение этим объектом.
1. В третьем подходе замените целевое изображение изображением, которое уже существует в коллекции изображений презентации.
1. Запишите изменённую презентацию в файл PPTX.
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


{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать тексты, создавать GIF‑изображения из текста и т.д. 

{{% /alert %}}

## **Часто задаваемые вопросы**

**Сохранится ли исходное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/nodejs-java/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Какой лучший способ заменить один и тот же логотип на десятках слайдов одновременно?**

Разместите логотип на слайде‑мастере или макете и замените его в коллекции изображений презентации — изменения распространятся на все элементы, использующие этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение в качестве фона для нескольких слайдов сразу?**

[Назначьте изображение как фон](/slides/ru/nodejs-java/presentation-background/) на слайде‑мастере или соответствующем макете — любой слайд, использующий этот мастер/макет, унаследует фон.

**Как предотвратить «раздувание» презентации из‑за большого количества картинок?**

Переиспользуйте один ресурс изображения вместо дублирования, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графики на мастере, где это уместно.