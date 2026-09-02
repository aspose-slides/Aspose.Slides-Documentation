---
title: Экспортировать слайды презентаций в виде SVG‑изображений на Android
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: "Экспортировать слайды PowerPoint в виде SVG‑изображений на Android и управлять шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый формат изображений на основе XML, который хорошо подходит для веб‑публикаций, просмотрщиков слайдов, сценариев доступности и автоматической пост‑обработки. Aspose.Slides for Android через Java экспортирует каждый слайд в отдельный файл SVG и позволяет контролировать, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым в разных браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд как SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ниже приведён пример, который экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла использует [ISlide.getSlideNumber](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islide/#getSlideNumber--) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [IShape.writeAsSvg](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), когда просмотрщику слайдов или веб‑странице требуется только эта форма.

## **Настроить вывод SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) определяет, применяется ли поворот рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) в `true`, когда текст необходимо отрисовывать без лигатур.

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

### **Векторизовать весь текст**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) в `true`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным в разных браузерах, но текст уже нельзя будет выделять или искать как SVG‑текст.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы ссылаться на отдельные файлы шрифтов, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы включить данные шрифта в SVG, или [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы отрисовывать только текст, использующий внешние шрифты, как графику. Проверьте лицензионные ограничения шрифтов перед их встраиванием.

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

## **Уменьшить размер встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) , чтобы уменьшить разрешение встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) , чтобы исключить обрезанные области источника, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) , чтобы контролировать качество JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт качества изображения или количества сохраняемых данных.

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

## **Назначить стабильные идентификаторы формам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), чтобы установить [ISvgShape.setId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) для каждой формы SVG. Чтобы также задать значения [ISvgTSpan.setId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) у элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Примените любой из контроллеров с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Следующий контроллер использует [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), который остаётся стабильным в течение жизни формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

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

## **Добавить обработчики событий SVG**

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) вызовите [ISvgShape.setEventHandler](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) с параметром [SvgEvent](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgevent/), чтобы добавить JavaScript‑обработчик события к экспортированной форме. Примените контроллер с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) и определите JavaScript‑функцию на странице или в документе SVG, который содержит результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Назначение идентификаторов и обработчиков событий позволяет использовать просмотрщики слайдов, улучшать доступность и реализовывать другие интерактивные сценарии SVG.

## **FAQ**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Какой лучший способ уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, поскольку уменьшение разрешения изображений, снижение качества JPEG и векторизация текста имеют разные компромиссы между качеством и размером.

**Могу ли я изменять экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через контроллер форматирования, а затем выберите соответствующие элементы SVG в вашем инструменте пост‑обработки или скрипте браузера.