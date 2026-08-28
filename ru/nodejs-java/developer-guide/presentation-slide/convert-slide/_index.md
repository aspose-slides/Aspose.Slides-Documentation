---
title: Преобразование слайдов презентации в изображения на JavaScript
linktitle: Слайд в изображение
type: docs
weight: 35
url: /ru/nodejs-java/convert-slide/
keywords:
- преобразовать слайд
- экспортировать слайд
- слайд в изображение
- сохранить слайд как изображение
- слайд в EMF
- слайд в PNG
- слайд в JPEG
- слайд в bitmap
- слайд в TIFF
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Преобразуйте слайды из презентаций PPT, PPTX и ODP в PNG, JPEG, GIF, TIFF, EMF и другие форматы изображений на JavaScript с помощью Aspose.Slides."
---
## **Введение**

Aspose.Slides for Node.js via Java может визуализировать отдельные слайды из презентаций PowerPoint и OpenDocument в форматах PNG, JPEG, GIF, TIFF и других графических форматах.

Чтобы преобразовать слайд в изображение, выполните следующие шаги:

1. Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/).
2. Выберите слайд, который необходимо отрисовать.
3. При необходимости настройте визуализацию с помощью класса [RenderingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/) или [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/).
4. Вызовите метод [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage). Он возвращает объект [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/).
5. Вызовите метод [IImage.save](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/#save) и укажите формат вывода с помощью значения [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/).

## **Преобразование слайда в PNG‑изображение**

Самое простое преобразование использует параметры визуализации по умолчанию. Полученный объект [IImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/iimage/) можно обработать в памяти или сохранить в файл.

Следующий пример JavaScript визуализирует первый слайд и сохраняет его как PNG‑изображение:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage();
    try {
        image.save("Slide_0.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Преобразование слайдов в изображения с пользовательскими размерами**

Используйте перегруженный метод [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage), принимающий значение `java.awt.Dimension`, чтобы отрисовать слайд с точными пиксельными размерами.

Следующий пример создает изображение JPEG размером 1820 × 1040 пикселей:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 1820, 1040);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(imageSize);
    try {
        image.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Преобразование слайдов с заметками и комментариями в изображения**

По умолчанию изображения слайдов не включают заметки и комментарии. Передайте объект [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayoutingoptions/) в метод [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions), чтобы задать расположение заметок и комментариев.

Следующий пример размещает обрезанные заметки под слайдом и комментарии справа от него:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = scaleX;

const commentsAreaColor = java.newInstanceSync("java.awt.Color", 250, 235, 215);

const layoutOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
layoutOptions.setCommentsPosition(aspose.slides.CommentsPositions.Right);
layoutOptions.setCommentsAreaWidth(500);
layoutOptions.setCommentsAreaColor(commentsAreaColor);

const renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutOptions);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(renderingOptions, scaleX, scaleY);
    try {
        image.save("Image_with_notes_and_comments_0.gif", aspose.slides.ImageFormat.Gif);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}

Для преобразования слайдов в изображения НЕ передавайте [BottomFull](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notespositions/) в метод [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition). Заметки могут содержать больше текста, чем позволяет фиксированный размер изображения. Используйте [BottomTruncated](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/notespositions/) вместо этого.

{{% /alert %}}

## **Преобразование слайдов в изображения с использованием параметров TIFF**

Класс [TiffOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/tiffoptions/) позволяет управлять размером, разрешением и другими свойствами визуализируемого TIFF‑изображения.

Следующий пример визуализирует первый слайд как TIFF‑изображение 2160 × 2880 пикселей с разрешением 300 DPI:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const imageSize = java.newInstanceSync("java.awt.Dimension", 2160, 2880);

const tiffOptions = new aspose.slides.TiffOptions();
tiffOptions.setImageSize(imageSize);
tiffOptions.setDpiX(300);
tiffOptions.setDpiY(300);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const image = slide.getImage(tiffOptions);
    try {
        image.save("output.tiff", aspose.slides.ImageFormat.Tiff);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert title="Warning" color="warning" %}}

Поддержка TIFF не гарантируется в версиях Java ранее JDK 9.

{{% /alert %}}

## **Преобразование всех слайдов в изображения**

Пройдитесь по коллекции слайдов, чтобы преобразовать всю презентацию в последовательность изображений. Скрытые слайды включаются, если их явно не пропустить.

Следующий пример визуализирует каждый слайд как изображение JPEG с горизонтальным и вертикальным коэффициентами масштабирования, равными 2:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const scaleX = 2;
const scaleY = scaleX;

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.getSlides().get_Item(index);
        const image = slide.getImage(scaleX, scaleY);
        try {
            image.save("Slide_" + index + ".jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Создание вывода в формате Enhanced Metafile**

Enhanced Metafile (EMF) полезен, когда векторная графика должна быть обменяна с Microsoft Office или другими приложениями Windows, поддерживающими Windows‑метафайлы. В отличие от растрового изображения, EMF сохраняет векторные операции рисования, которые масштабируются без потери резкости. Однако EMF служит в первую очередь форматом совместимости для приложений с поддержкой Windows‑метафайлов, а не универсальным форматом обмена. Кроме того, сложное содержание слайда, такое как растровые изображения и некоторые эффекты, может быть сохранено как растрированные элементы внутри векторного контейнера метафайла.

### **Экспорт слайда в EMF**

Метод [Slide.writeAsEmf](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#writeAsEmf) записывает слайд в целевой поток в формате EMF. Ниже приведён пример, который загружает презентацию, выбирает первый слайд и записывает его в поток файла EMF:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.FileOutputStream", "Slide_0.emf");
    try {
        slide.writeAsEmf(emfStream);
    } finally {
        emfStream.close();
    }
} finally {
    presentation.dispose();
}
```

Вызывающая сторона владеет потоком, переданным в [Slide.writeAsEmf](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#writeAsEmf), и отвечает за его закрытие, как показано выше.

### **Преобразование SVG‑изображения в EMF и добавление его в презентацию**

Используйте [SvgImage.writeAsEmf](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/#writeAsEmf) для преобразования SVG‑контента в EMF. Полученные байты можно добавить в презентацию через [ImageCollection.addImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/#addImage) и разместить на слайде с помощью [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#addPictureFrame).

Следующий пример создает объект [SvgImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/) из разметки SVG, преобразует его в EMF в памяти, вставляет метафайл на первый слайд и сохраняет презентацию:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
const svgImage = new aspose.slides.SvgImage(svgContent);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const emfStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        svgImage.writeAsEmf(emfStream);

        const emfData = java.newArray("byte", Array.from(emfStream.toByteArray()));
        const image = presentation.getImages().addImage(emfData);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100, image);
    } finally {
        emfStream.close();
    }

    presentation.save("Presentation_with_emf.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[SvgImage.writeAsEmf](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgimage/#writeAsEmf) не захватывает владение целевым потоком. `java.io.ByteArrayOutputStream` хранит все сгенерированные данные в памяти, поэтому перед вызовом `toByteArray` не требуется сбрасывать позицию. Возвращённый массив байтов остаётся действительным после закрытия потока.

Генерация EMF доступна на операционных системах, поддерживаемых выбранной конфигурацией Aspose.Slides for Node.js via Java и JDK, однако рендеринг может различаться между платформами при отсутствии шрифтов или графических зависимостей. Установите шрифты, используемые в исходном контенте, или настройте подходящие замены, следуйте [требованиям платформы](/slides/ru/nodejs-java/system-requirements/) для Aspose.Slides for Node.js via Java и проверьте результат в целевом приложении, потребляющем EMF. Приложения Linux и macOS часто имеют ограниченную или непоследовательную поддержку отображения и редактирования Windows‑метафайлов.

## **Отображение цветных эмодзи**

{{% alert title="Note" color="info" %}}
Чтобы правильно отобразить цветные эмодзи при преобразовании слайдов презентации в изображения, шрифты эмодзи, используемые в презентации, должны быть установлены и доступны в системе, выполняющей преобразование. Например, если презентация использует **Segoe UI Emoji** и этот шрифт отсутствует, эмодзи могут отображаться монохромно в результирующих изображениях.
{{% /alert %}}

## **FAQ**

**Поддерживает ли Aspose.Slides визуализацию слайдов с анимацией?**

Нет. Метод [Slide.getImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/#getImage) создает статическое изображение слайда и не экспортирует анимацию.

**Можно ли экспортировать скрытые слайды как изображения?**

Да. Скрытые слайды можно визуализировать так же, как обычные. Включите их в цикл обработки, как показано в примере выше.

**Сохраняются ли тени и другие эффекты в изображениях слайдов?**

Да. Aspose.Slides рендерит тени, прозрачность и другие поддерживаемые графические эффекты в изображениях слайдов.