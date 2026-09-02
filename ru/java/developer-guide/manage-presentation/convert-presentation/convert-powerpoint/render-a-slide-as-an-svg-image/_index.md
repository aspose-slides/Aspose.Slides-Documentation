---
title: Рендеринг слайдов презентации в SVG-изображения в Java
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- Параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint в виде SVG-изображений на Java и контролируйте шрифты, текст, изображения, идентификаторы и события с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый формат изображений на основе XML, который хорошо подходит для веб-публикаций, просмотров слайдов, рабочих процессов доступности и автоматической постобработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет контролировать, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/) когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Следующий пример экспортирует каждый слайд презентации в отдельный файл SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Имя файла формируется с помощью [ISlide.getSlideNumber](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islide/#getSlideNumber--) , а не индекса цикла. Вы также можете экспортировать отдельную форму с помощью [IShape.writeAsSvg](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) , если просмотрщик слайдов или веб-страница нуждается только в этой форме.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) определяет, применяется ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) в `true`, когда текст должен рендериться без лигатур.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Управление текстом и шрифтами**

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) в `true`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст больше нельзя выделять или искать как SVG‑текст.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Сокращение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) , чтобы уменьшить разрешение встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) , чтобы исключить обрезанные области исходных изображений, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) , чтобы контролировать качество кодирования JPEG. Эти параметры уменьшают размер файла за счёт точности изображения или сохранённых данных изображения.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Назначение стабильных идентификаторов фигурам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgshapeformattingcontroller/) , чтобы установить [ISvgShape.setId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) для каждой фигуры SVG. Чтобы также задать значения [ISvgTSpan.setId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) для элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Назначьте любой из контроллеров с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Следующий контроллер использует [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) , который стабилен на протяжении жизни фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для постобработки неизменённой презентации.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Добавление обработчиков событий SVG**

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgshapeformattingcontroller/) вызовите [ISvgShape.setEventHandler](https://reference.aspose.com/slides/ru/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) с значением [SvgEvent](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgevent/) , чтобы добавить обработчик JavaScript к экспортируемой фигуре. Назначьте контроллер с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) и определите функцию JavaScript на странице или в документе SVG, который содержит результат.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Хост‑страница может определить функцию JavaScript, на которую ссылается обработчик. Назначение идентификаторов и обработчиков событий позволяет реализовать просмотры слайдов, улучшения доступности и другие интерактивные рабочие процессы SVG.

## **Часто задаваемые вопросы**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) , когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/java/com.aspose.slides/svgexternalfontshandling/) , когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора связанных файлов шрифтов, если целевая среда может их обслуживать. Проверьте результат, поскольку снижение разрешения изображения, снижение качества JPEG и векторизация текста каждый по‑своему влияют на качество и размер.

**Можно ли изменить экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы с помощью контроллера форматирования, затем выберите соответствующие элементы SVG в вашем инструменте постобработки или скрипте браузера.