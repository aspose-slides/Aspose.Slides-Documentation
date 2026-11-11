---
title: Отображение слайдов презентации как SVG‑изображений в JavaScript
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- Опции экспорта SVG
- Интерактивный SVG
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint как SVG‑изображения в JavaScript и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый XML‑ориентированный формат изображений, который хорошо подходит для веб‑публикации, просмотрщиков слайдов, процессов доступности и автоматической пост‑обработки. Aspose.Slides for Node.js via Java экспортирует каждый слайд в отдельный SVG‑файл и позволяет контролировать, как записываются текст, шрифты, изображения и SVG‑элементы.

Используйте [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/), когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). В следующем примере каждый слайд презентации экспортируется в отдельный SVG‑файл.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Имя файла формируется с помощью [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/), а не индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/), если в просмотрщике слайдов или веб‑странице требуется только эта форма.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) определяет, применяется ли поворот рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `true`, когда текст должен рендериться без лигатур.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Управление обрезкой концов линий у стрелок**

В SVG 1.1 нет параметра смещения маркера, позволяющего указать, где линия должна прекращаться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортируемую линию, чтобы её штрих не выступал за пределы маркера. Вызовите [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) с `true`, чтобы рисовать штрих до оригинального конца линии. Эта настройка влияет только на вывод SVG. Положение и длина линии на слайде остаются без изменений.

В примере рисуются треугольные и ромбовидные наконечники у линий толщиной 2 и 10 пунктов. Один и тот же слайд экспортируется дважды, меняется только параметр обрезки.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

Сравнение показывает треугольный наконечник на линии толщиной 10 пунктов. При включенной обрезке кончик острый. При отключённой обрезке штрих выступает за наклонные стороны маркера и образует плоский конец.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен у треугольника толщиной 2 пункта. Заполненный ромб закрывает конец штриха при обеих ширинах.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст в виде текста или будет преобразован в векторную графику, а также как будут включаться или ссылаться внешние шрифты. Ниже перечислены параметры, помогающие сбалансировать визуальное соответствие, возможность выделения текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) в `true`, чтобы записывать весь текст слайдов как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст уже нельзя будет выбирать или искать как SVG‑текст.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Выбор обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Перед включением шрифтов проверьте их лицензирование.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Сокращение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) для снижения разрешения встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) — чтобы опускать обрезанные участки исходных изображений, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) — для управления качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт потери качества изображения или удаления части данных изображения.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Управление разрешением растеризации метафайлов**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его для балансировки детализации и размера файла, когда растеризуется изображение EMF или WMF. Этот параметр не задаёт глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором содержится изображение EMF с плотно расположенными диагональными линиями. В следующем примере первая страница экспортируется с тремя различными разрешениями растеризации через [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Все остальные параметры экспорта остаются одинаковыми, чтобы результаты было удобно сравнивать.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

В результате EMF превращается в один встроенный PNG в каждом SVG. Ниже приведены измерения для предоставленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| DPI растеризации метафайла | Размеры встроенного PNG | Размер SVG‑файла (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170 221 |
| 150 | 2492 × 1242 | 423 149 |
| 300 | 4983 × 2483 | 1 027 169 |

Сравнение ниже демонстрирует одну и ту же область встроенного растра при одинаковом увеличенном размере отображения. Диагональные линии проявляют пикселизацию при 72 DPI и более плавные края при более высоких разрешениях, при этом размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) управляет снижением разрешения изображения и может скрывать влияние изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначение стабильных идентификаторов формам и тексту**

Передайте контроллер форматирования в [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), чтобы установить [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) для каждой SVG‑формы. Контроллер, который также обрабатывает текстовые спаны, может задавать значения [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) для элементов `tspan` текста.

Ниже показан контроллер, использующий [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), который остаётся стабильным на протяжении жизни формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Добавление обработчиков событий SVG**

В контроллере форматирования вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) с значением [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/), чтобы добавить JavaScript‑обработчик события к экспортируемой форме. Назначьте контроллер через [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) и определите функцию JavaScript на странице или в SVG‑документе, в котором размещён результат.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Страница‑хост может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий открывает возможности для просмотрщиков слайдов, улучшений доступности и других интерактивных SVG‑процессов.

## **FAQ**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Какой лучший способ сделать SVG меньше?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, когда целевая среда может их обслуживать. Проверьте результат, поскольку снижение разрешения изображения, снижение качества JPEG и векторизация текста каждый по‑своему влияют на качество и размер.

**Можно ли изменить экспортированные SVG‑элементы после экспорта?**

Да. Назначьте идентификаторы через контроллер форматирования, а затем выбирайте соответствующие SVG‑элементы в вашем инструменте пост‑обработки или скрипте браузера.