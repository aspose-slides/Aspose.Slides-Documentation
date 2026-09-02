---
title: Оптимизация управления изображениями в презентациях с использованием JavaScript
linktitle: Управление изображениями
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
- внешние ресурсы SVG
- резолвер SVG
- связанные SVG‑изображения
- шрифты SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Упростите управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java, оптимизируя производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и визуально привлекательными. В Microsoft PowerPoint вы можете вставлять изображения на слайды из файлов, интернета или других источников. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды презентаций разными способами.

{{% alert  title="Подсказка" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

{{% alert title="Информация" color="info" %}}
Если вы хотите добавить изображение в виде рамки — особенно если планируете менять размер, применять эффекты или использовать другие стандартные параметры форматирования — смотрите [Рамка изображения](/slides/ru/nodejs-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}}
Вы можете конвертировать изображения из одного формата в другой. Смотрите следующие страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/ru/nodejs-java/conversion/image-to-jpg/), [JPG в изображение](https://products.aspose.com/slides/ru/nodejs-java/conversion/jpg-to-image/), [JPG в PNG](https://products.aspose.com/slides/ru/nodejs-java/conversion/jpg-to-png/), [PNG в JPG](https://products.aspose.com/slides/ru/nodejs-java/conversion/png-to-jpg/), [PNG в SVG](https://products.aspose.com/slides/ru/nodejs-java/conversion/png-to-svg/), и [SVG в PNG](https://products.aspose.com/slides/ru/nodejs-java/conversion/svg-to-png/). 
{{% /alert %}}

Aspose.Slides поддерживает изображения в популярных форматах, таких как JPEG, PNG, BMP, GIF и другие. 

## **Добавление локальных изображений на слайды**

Вы можете добавить одно или несколько изображений, хранящихся на вашем компьютере, на слайд презентации. Ниже приведён пример кода JavaScript, показывающий, как добавить изображение на слайд:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Добавление изображений из веба на слайды**

Если изображение, которое вы хотите добавить на слайд, не хранится на вашем компьютере, его можно добавить напрямую из интернета. 

Ниже приведён пример кода JavaScript, показывающий, как добавить изображение из веба на слайд:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Добавление изображений в мастер‑слайды**

Мастер‑слайд хранит и управляет информацией, такой как тема и макет, для слайдов, использующих его. Когда вы добавляете изображение в мастер‑слайд, оно появляется на каждом слайде, основанном на этом мастере. 

Ниже приведён пример кода JavaScript, показывающий, как добавить изображение в мастер‑слайд:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Добавление изображений в качестве фона слайдов**

Вы можете использовать изображение как фон для одного или нескольких слайдов. Подробности см. в *[Установка изображений в качестве фона слайдов](/slides/ru/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Контент SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) . Полученный объект изображения SVG затем может быть добавлен в коллекцию изображений презентации и использован для создания рамки изображения. 

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Импорт SVG с внешними ресурсами**

SVG‑файлы, экспортированные из дизайнерских инструментов, редакторов диаграмм, систем иконок и веб‑конвейеров, могут ссылаться на ресурсы, хранящиеся вне документа SVG. Например, в SVG может быть ссылка на изображение `images/photo.png`, значение CSS `url(...)` или URL шрифта. 

Чтобы импортировать такой SVG‑контент, предоставьте внешний резолвер ресурсов и передайте его вместе с базовым URI в соответствующий конструктор [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) . Базовый URI указывает место расположения SVG‑документа и используется для разрешения относительных ссылок. 

Класс `SvgImage` предоставляет доступ к информации об импортированном SVG:

- `getSvgContent()` возвращает разметку SVG в виде строки.  
- `getSvgData()` возвращает содержимое SVG в виде массива байтов.  
- `getBaseUri()` возвращает базовый URI, используемый для относительных ссылок.  
- `getExternalResourceResolver()` возвращает резолвер, назначенный объекту SVG изображения.  

### **Реализация внешнего резолвера ресурсов**

У резолвера есть два метода:

- `resolveUri` объединяет базовый URI и относительную ссылку ресурса и возвращает абсолютный URI. Возвращайте `null`, когда ссылку нельзя разрешить или она не допускается.  
- `getEntity` возвращает читаемый Java‑поток для абсолютного URI ресурса. Возвращайте `null`, когда ресурс отсутствует, заблокирован или недоступен. При необходимости можно вернуть запасной поток.  

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Этот резолвер намеренно разрешает только локальные файлы.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Использовать запасной вариант только для ресурсов изображений. Возврат потока изображения
                // для отсутствующего шрифта или таблицы стилей недопустим.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Разрешение связанных ресурсов при импорте SVG**

Предположим, что `assets/diagram.svg` содержит относительную ссылку, например:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ниже приведён пример кода JavaScript, который передаёт URI SVG‑файла в качестве базового URI и использует пользовательский резолвер. Резолвер преобразует относительную ссылку на изображение в абсолютный URI и возвращает поток, содержащий связанный ресурс, пока Aspose.Slides обрабатывает SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Базовый URI представляет расположение SVG‑документа.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage exposes the source content, binary data, base URI, and resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Класс `SvgImage` также предоставляет перегрузки, принимающие SVG‑данные в виде массива байтов, а также фабричные методы на основе потоков, вместе с внешним резолвером ресурсов и базовым URI. 

{{% alert title="Важно" color="warning" %}}
Резолвер ресурсов делает внешние ресурсы доступными во время обработки и рендеринга SVG в Aspose.Slides. Он не изменяет оригинальную разметку SVG и не встраивает автоматически разрешённые ресурсы в неё. 

Когда SVG‑изображение добавляется в коллекцию изображений презентации, файл PPTX может содержать как оригинальное представление SVG, так и растровый запасной образ. Связанный ресурс может появиться в сгенерированном запасном изображении, тогда как относительная ссылка вроде `images/photo.png` остаётся неизменной в сохранённом SVG. Приложение, которое рендерит нативное представление SVG, может опустить связанный контент, если оригинальный внешний ресурс недоступен. 
{{% /alert %}}

### **Создание автономного SVG‑изображения**

Чтобы создать SVG‑картинку, не зависящую от внешних файлов, сделайте SVG самодостаточным перед созданием `SvgImage`. Например, замените связанные URL‑адреса изображений на URI `data:`, содержащие данные изображения:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

После того как все необходимые ресурсы внедрены в содержимое SVG, создайте `SvgImage`, добавьте его в коллекцию изображений презентации и вставьте в рамку изображения, как показано в предыдущем примере. 

### **Обработка отсутствующих или заблокированных ресурсов**

Возвращайте `null` из `resolveUri`, когда URI ресурса недействителен, запрещён или не может быть разрешён. Возвращайте `null` из `getEntity`, когда ресурс нельзя прочитать. Aspose.Slides продолжит обработку SVG без этого ресурса, если это возможно. 

Запасной поток может быть возвращён для отсутствующего ресурса, но его содержимое должно соответствовать требуемому типу ресурса. Например, возвращайте поток изображения только для отсутствующего изображения, а не для шрифта или таблицы стилей. 

{{% alert title="Безопасность" color="warning" %}}
Не разрешайте произвольные пути к файлам или неограниченные сетевые URL‑адреса из ненадёжных SVG‑файлов. Ограничьте разрешённые схемы, каталоги и хосты. Для сетевых ресурсов также применяйте ограничения по времени подключения, размеру ответа и проверку содержимого. 
{{% /alert %}}

## **Преобразование SVG в набор фигур**

Aspose.Slides может преобразовать SVG в набор фигур, аналогично соответствующей функциональности в PowerPoint:

![Меню PowerPoint](img_01_01.png)

Эта возможность реализована перегрузкой метода [addGroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) класса [ShapeCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ShapeCollection), который принимает объект SVG‑изображения в качестве первого аргумента. 

Ниже приведён пример кода JavaScript, показывающий, как использовать этот метод для преобразования SVG‑файла в набор фигур:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Исходное имя файла SVG.
const svgFileName = "sample.svg";

// Выходное имя файла презентации.
const outPptxPath = "presentation.pptx";

// Создать новую презентацию.
const presentation = new aspose.slides.Presentation();
try {
    // Прочитать содержимое SVG‑файла.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Создать объект SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Получить размер слайда.
    const slideSize = presentation.getSlideSize().getSize();

    // Преобразовать SVG‑изображение в группу фигур и масштабировать её до размера слайда.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Сохранить презентацию в формате PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавление изображений в формате EMF на слайды**

Aspose.Slides for Node.js via Java позволяет генерировать EMF‑изображения из листов Excel с помощью Aspose.Cells и добавлять их в слайды презентации. 

Ниже приведён пример кода JavaScript, демонстрирующий, как это сделать:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Сохранить книгу в поток.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Добавить файл как есть, чтобы изображение оставалось векторным EMF, а не растрировано.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая изображения, используемые формами слайдов. В этом разделе описываются несколько способов обновления изображений в коллекции. Вы можете заменить изображение, используя сырые байтовые данные, экземпляр [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) или другое изображение, уже находящееся в коллекции. 

Выполните следующие шаги:

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) .  
2. Загрузите новое изображение из файла в массив байтов.  
3. Замените целевое изображение новым, используя массив байтов.  
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) и замените целевое изображение этим объектом.  
5. В третьем подходе замените целевое изображение изображением, которое уже присутствует в коллекции изображений презентации.  
6. Запишите изменённую презентацию в файл PPTX.  

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Создать экземпляр класса Presentation, представляющего файл презентации.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Первый способ.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Второй способ.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

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
С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) вы легко анимируете текст и создаёте GIF‑изображения из текста. 
{{% /alert %}}

## **Часто задаваемые вопросы**

**Сохраняется ли исходное разрешение изображения после вставки?**  
Да. Исходные пиксели сохраняются, но конечный вид зависит от того, как [рамка изображения](/slides/ru/nodejs-java/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.  

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**  
Разместите логотип на мастер‑слайде или макете и замените его в коллекции изображений презентации — изменения будут применены ко всем элементам, использующим этот ресурс.  

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**  
Да. SVG можно преобразовать в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.  

**Как установить изображение в качестве фона сразу для нескольких слайдов?**  
[Назначьте изображение как фон](/slides/ru/nodejs-java/presentation-background/) на мастер‑слайде или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.  

**Как предотвратить увеличение размера презентации из‑за большого количества изображений?**  
Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и, где уместно, размещайте повторяющуюся графику на мастере.