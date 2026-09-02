---
title: Рендеринг слайдов презентаций как SVG‑изображения в JavaScript
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
- параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Экспортировать слайды PowerPoint как SVG‑изображения в JavaScript и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикации, просмотров слайдов, рабочих процессов доступности и автоматической пост‑обработки. Aspose.Slides for Node.js via Java экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [Slide.writeAsSvg](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/writeassvg/). Приведённый ниже пример экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла формируется с помощью [Slide.getSlideNumber](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slide/getslidenumber/), а не индекса цикла. Вы также можете экспортировать отдельную форму с помощью [Shape.writeAsSvg](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/writeassvg/), если просмотрщик слайдов или веб‑страница требуется только эта форма.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setuseframesize/) включает рамку текста в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) в `true`, когда текст должен рендериться без лигатур.

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

## **Управление текстом и шрифтами**

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) в `true`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст больше нельзя будет выделять или искать как SVG‑текст.

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

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы отрисовывать только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

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

## **Сокращение размера внедрённых изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setpicturescompression/), чтобы уменьшить разрешение внедрённых изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/), чтобы исключить обрезанные области исходных изображений, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setjpegquality/), чтобы управлять качеством кодирования JPEG. Эти параметры уменьшают размер файла за счёт точности изображения или сохранённых данных изображения.

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

## **Назначение стабильных идентификаторов формам и тексту**

Передайте контроллер форматирования в [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), чтобы задать [SvgShape.setId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgshape/setid/) для каждой формы SVG. Контроллер, который также обрабатывает текстовые спаны, может задавать значения [SvgTSpan.setId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgtspan/setid/) у элементов текста `tspan`.

Следующий контроллер использует [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), который стабилен в течение срока жизни формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

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

В контроллере форматирования вызовите [SvgShape.setEventHandler](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgshape/seteventhandler/) с параметром [SvgEvent](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgevent/), чтобы добавить обработчик JavaScript к экспортируемой форме. Назначьте контроллер с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) и определите JavaScript‑функцию на странице или в документе SVG, где будет размещён результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет реализовать просмотрщики слайдов, улучшения доступности и другие интерактивные рабочие процессы SVG.

## **Часто задаваемые вопросы**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText], когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize], когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, так как уменьшение разрешения изображения, снижение качества JPEG и векторизация текста имеют разные компромиссы между качеством и размером.

**Можно ли изменить экспортированные элементы SVG после экспорта?**

Да. Присвойте идентификаторы через контроллер форматирования, а затем выберите соответствующие SVG‑элементы в вашем инструменте пост‑обработки или скрипте браузера.