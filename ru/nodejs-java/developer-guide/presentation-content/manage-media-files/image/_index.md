---
title: Оптимизация управления изображениями в презентациях с использованием JavaScript
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/nodejs-java/image/
keywords:
- добавить изображение
- добавить картинку
- заменить изображение
- коллекция изображений
- рамка изображения
- связанное изображение
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- SVG в фигуры
- внешние ресурсы SVG
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять, повторно использовать, связывать, заменять и управлять растровыми и SVG-изображениями в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js via Java."
---
## **Введение**

Aspose.Slides for Node.js via Java предоставляет несколько способов работы с изображениями, и каждый из них служит разной цели. Вы можете хранить изображение в презентации, отображать его в рамке изображения, использовать его как фон слайда, ссылаться на внешнее изображение, заменить общий ресурс изображения или преобразовать содержимое SVG в редактируемые фигуры.

В этой статье рассматриваются ресурсы изображений и их использование в презентации. Для обрезки, прозрачности, эффектов, растягивания и другого форматирования, применяемого к отдельной рамке изображения, см. [Рамка изображения](/slides/ru/nodejs-java/picture-frame/).

## **Понимание модели изображений**

Следующие концепции API тесно связаны, но не взаимозаменяемы:

- [Коллекция изображений презентации](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/) хранит ресурсы изображений, используемые в презентации. Используйте [ImageCollection.addImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/) для добавления данных изображения и получения ресурса [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).
- [Рамка изображения](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) — это фигура, отображающая изображение на слайде, макете или мастере. Используйте [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/) для размещения ресурса изображения на слайде.
- Фон слайда использует изображение как часть заливки слайда, а не как фигуру. Поэтому он не ведет себя как рамка изображения.
- [PPImage.replaceImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) заменяет ресурс изображения. Если несколько элементов презентации используют этот ресурс, они все используют замену.
- Преобразование SVG в фигуры создаёт редактируемые фигуры слайда. После преобразования содержимое больше не управляется как один ресурс изображения.

Типичный рабочий процесс выглядит так: добавить данные изображения в коллекцию изображений, получить [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/), а затем использовать этот ресурс в одной или нескольких рамках изображений или заливках.

## **Добавление встроенного изображения**

Чтобы вставить локальное изображение, загрузите файл, добавьте его в коллекцию изображений и создайте рамку изображения, использующую возвращённый ресурс [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Изображение, добавленное таким способом, встраивается в презентацию, поэтому полученный файл не зависит от наличия исходного файла изображения.

### **Добавление изображения из интернета**

Когда изображение доступно через HTTP или HTTPS, загрузите его байты, добавьте их в коллекцию изображений презентации и используйте возвращённый ресурс изображения тем же способом, что и локальное изображение.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

В длительно работающих приложениях повторно используйте HTTP‑клиент или стратегию управления соединениями, соответствующую приложению, вместо многократного создания ненужной сетевой инфраструктуры. Также проверяйте удалённые URL, размеры ответов и типы содержимого, когда источник ненадежен.

## **Повторное использование изображений на разных слайдах**

Если одно и то же изображение требуется более одного раза, добавьте его в презентацию один раз и повторно используйте полученный [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) при создании дополнительных рамок изображений. Это избавляет от повторной загрузки одних и тех же исходных данных и делает связь между общим ресурсом изображения и его использованием явной.

Для графики, которая должна автоматически появляться на многих слайдах, например логотип компании, рассмотрите возможность размещения рамки изображения на [мастер‑слайде](/slides/ru/nodejs-java/slide-master/) или макете вместо добавления эквивалентной фигуры на каждый слайд.

## **Использование изображения в качестве фона слайда**

Фоновое изображение назначается заливке слайда; оно не добавляется как фигура рамки изображения. Это полезно, когда изображение должно покрывать фон слайда и не должно манипулироваться как обычный объект слайда.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Для дополнительных параметров фона, включающих фон мастера и макета, см. [Фон презентации](/slides/ru/nodejs-java/presentation-background/).

## **Встроенные и связанные изображения**

Встроенные и связанные изображения имеют разные компромиссы по переносимости и размеру файла:

- **Встроенное изображение:** данные изображения хранятся внутри презентации. Презентация автономна, но размер файла включает данные изображения.
- **Связанное изображение:** презентация сохраняет путь или URL к внешнему изображению. Это может уменьшить размер презентации, но внешний ресурс должен оставаться доступным при открытии или рендеринге презентации.

Связанную картинку можно создать, задав внешний путь или URL через [Picture.setLinkPathLong](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picture/) вместо встраивания данных изображения.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте связанные изображения только тогда, когда среда развертывания может надёжно обращаться к внешнему ресурсу. Для презентаций, которые должны работать офлайн или перемещаться между системами, встроенные изображения обычно безопаснее.

## **Работа с SVG‑изображениями**

SVG — векторный формат, поэтому он может быть полезен для значков, схем и другой графики, которую нужно масштабировать без потери детализации, характерной для растровых изображений. Aspose.Slides поддерживает SVG как ресурс изображения и как источник для редактируемых фигур слайда.

### **Добавление SVG в качестве изображения**

Создайте [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/), добавьте его в коллекцию изображений и разместите полученный ресурс изображения в рамке изображения.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **SVG‑файлы со внешними ресурсами**

SVG может ссылаться на внешние изображения, таблицы стилей или шрифты. Для этих случаев [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) предоставляет конструкторы, принимающие [ExternalResourceResolver](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/externalresourceresolver/) и базовый URI. Разрешитель может сопоставлять относительный URI с разрешённым абсолютным URI и возвращать поток запрошенного ресурса.

Разрешитель делает внешние ресурсы доступными, пока Aspose.Slides обрабатывает SVG, но не переписывает SVG в автономный документ. Если SVG должен оставаться переносимым, внедрите требуемые ресурсы непосредственно в SVG, например, используя URI `data:` для связанных изображений.

Когда SVG‑файлы поступают из ненадёжных источников, ограничьте схемы, расположения файлов и хосты, к которым разрешён доступ разрешителя. Сетевые разрешители также должны применять тайм‑ауты, ограничения по размеру ответа и проверку содержимого.

### **Преобразование SVG в редактируемые фигуры**

Aspose.Slides может преобразовать SVG в группу редактируемых фигур слайда, аналогично соответствующей команде PowerPoint.

![Всплывающее меню PowerPoint](img_01_01.png)

Для выполнения преобразования используйте перегрузку [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/), принимающую SVG‑изображение.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Применяйте преобразование SVG‑в‑фигуры, когда отдельные векторные элементы необходимо редактировать как фигуры PowerPoint. Если SVG требуется только для отображения, проще оставить его как изображение и избежать создания множества отдельных фигур.

## **Замена существующего ресурса изображения**

Используйте [PPImage.replaceImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) для замены существующего ресурса изображения. Это особенно полезно для общих графических элементов, таких как логотипы.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Если несколько рамок изображений, фонов, мастеров или макетов используют один и тот же ресурс изображения, замена этого ресурса обновит все его применения. Если нужно изменить только одну рамку изображения, назначьте другой ресурс этой рамке вместо замены общего ресурса.

[PPImage.replaceImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) также предоставляет перегрузки, принимающие массив байтов или другой [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).

## **Практические рекомендации по управлению изображениями**

### **Контроль размера презентации**

Большие растровые изображения могут необязательно увеличивать размер презентации. Используйте исходные изображения с размерами, соответствующими их предполагаемому отображению, повторно используйте общие ресурсы изображений, где это возможно, и избегайте встраивания повторяющихся копий одной и той же графики в полном разрешении.

Для растровых картинок, уже помещённых в рамки изображений, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/picturefillformat/) может уменьшить данные изображения в соответствии с выбранным разрешением и параметрами обрезки. Это обработка рамки изображения, а не управление коллекцией изображений, поэтому см. [Рамка изображения](/slides/ru/nodejs-java/picture-frame/) для связанных операций форматирования.

### **Выбор между встроенным и связанным содержимым**

Встраивание делает презентацию переносимой, потому что все необходимые данные изображений находятся в файле. Связывание может уменьшить размер файла, но приводит к внешней зависимости. Используйте ссылки только тогда, когда такая зависимость приемлема и стабильна.

### **Повторное использование фирменных элементов**

Для повторяющихся логотипов, водяных знаков или декоративных график используйте один ресурс изображения и повторно его применяйте. Если графика относится к дизайну презентации, а не к содержимому слайда, разместите её на мастере или макете, чтобы она наследовалась соответствующими слайдами.

### **Сохранение переносимости SVG‑ресурсов**

Самодостаточный SVG легче перемещать и рендерить последовательно, чем SVG, зависящий от внешних файлов или сетевых ресурсов. По возможности внедряйте требуемые ресурсы перед импортом SVG. Преобразовывайте SVG в фигуры только тогда, когда отдельные векторные элементы необходимо редактировать.

### **Использование современного кросс‑платформенного API изображений**

Для нового кода Node.js via Java используйте API Aspose.Slides [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) и [Images](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/images/) вместо устаревшего публичного API, основанного на `java.awt.image.BufferedImage`. См. [Современный API](/slides/ru/nodejs-java/modern-api/) для рекомендаций по миграции.

WMF и EMF требуют особого внимания. Когда эти форматы передаются через [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/) преобразует метафайл в растровое представление PNG перед вставкой. Если важно сохранить данные метафайла, используйте потоковую перегрузку [ImageCollection.addImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/). Генерация содержимого EMF из электронных таблиц или других продуктов — это отдельный процесс интеграции и выходит за рамки данной статьи.

## **FAQ**

**В чём разница между коллекцией изображений и рамкой изображения?**

Коллекция изображений хранит переиспользуемые ресурсы изображений. Рамка изображения — это фигура слайда, отображающая один из этих ресурсов и предоставляющая специфическое для картинок форматирование, такое как обрезка и эффекты.

**Как лучше всего заменить один и тот же логотип во всей презентации?**

Если логотип уже общим как один ресурс изображения, замените этот ресурс с помощью [PPImage.replaceImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/). Для брендирования на уровне всей презентации можно также разместить логотип на мастере или макете, что уменьшит дублирование содержимого слайдов.

**Почему связанное изображение исчезает на другом компьютере?**

Связанная картинка зависит от внешнего файла или URL. Если из другого компьютера этот ресурс недоступен, связанное изображение может быть недоступно. Встраивайте изображение, когда презентация должна быть автономной.

**Можно ли редактировать вставленный SVG как фигуры PowerPoint?**

Да. Преобразуйте SVG с помощью [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/); полученная группа будет содержать редактируемые фигуры слайда, а не одно SVG‑изображение.

**Как уменьшить размер презентаций с большим количеством изображений?**

Повторно используйте общие ресурсы изображений, избегайте излишне больших растровых источников, при необходимости сжимайте подходящие растровые картинки, размещайте повторяющийся фирменный контент на мастерах или макетах и используйте связанные изображения только тогда, когда внешняя зависимость приемлема.