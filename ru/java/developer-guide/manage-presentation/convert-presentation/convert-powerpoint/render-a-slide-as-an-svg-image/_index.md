---
title: Рендеринг слайдов презентации в виде SVG‑изображений на Java
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
- параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint в виде SVG‑изображений на Java и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотрщиков слайдов, сценариев доступности и автоматизированной пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/), когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Ниже приведён пример, который экспортирует каждый слайд презентации в отдельный файл SVG.

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

Для имени файла использовано [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) вместо индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), когда просмотрщику слайдов или веб‑странице нужна только эта фигура.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) включает текстовую рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) определяет, применяется ли поворот рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) в `true`, когда текст должен рендериться без лигатур.

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

При экспорте слайдов в SVG вы можете контролировать, будет ли текст оставлен как текст или преобразован в векторную графику, а также как будут включаться или ссылаться внешние шрифты. Ниже перечислены параметры, помогающие сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) в `true`, чтобы записать весь текст слайда в виде векторной графики. Это устраняет зависимости от шрифтов и делает визуальный результат более единообразным во всех браузерах, но текст уже нельзя будет выделять или искать как SVG‑текст.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed` — чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Перед встраиванием шрифтов проверьте их лицензионные условия.

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

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-), чтобы уменьшить разрешение встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), чтобы исключить обрезанные области источника, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-), чтобы контролировать качество JPEG‑кодирования. Эти параметры снижают размер файла ценой качества изображения или сохранённых данных изображения.

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

## **Управление разрешением растеризации метафайлов**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы найти баланс между детализацией и размером файла, когда растеризуется изображение EMF или WMF. Этот параметр не задаёт глобальное DPI для SVG и не заставляет каждый объект на слайде превращаться в растровое изображение.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx) — файл, содержащий изображение EMF с плотно расположенными диагональными линиями. Ниже показан пример, экспортирующий первый слайд с тремя разрешениями растеризации через [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Все остальные параметры экспорта остаются идентичными, чтобы результаты можно было сравнить.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

В результате EMF превратилось в один встроенный PNG в каждом SVG. Ниже приведены измерения для предоставленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| DPI растеризации метафайла | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170 221 |
| 150 | 2492 × 1242 | 423 149 |
| 300 | 4983 × 2483 | 1 027 169 |

Сравнение ниже показывает одну и ту же область встроенного растра при одинаковом увеличенном отображении. Диагональные линии видны как пикселизированные при 72 DPI и более плавные при более высоких разрешениях, при этом размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортированное изображение.

![Увеличенные детали диагональной линии при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) управляет уменьшением разрешения изображения и может скрывать влияние изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) контролирует качество JPEG‑кодирования, а не разрешение растеризации метафайла.

## **Назначение стабильных идентификаторов фигур и текста**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/), чтобы задать [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) для каждой SVG‑фигуры. Чтобы также задавать значения [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) у элементов `tspan` текста, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Присвойте любой из контроллеров через [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Ниже показан контроллер, использующий [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), который остаётся неизменным в течение жизни фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

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

Внутри [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) вызовите [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) с значением [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/), чтобы добавить обработчик JavaScript к экспортируемой фигуре. Присвойте контроллер через [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) и определите JavaScript‑функцию на странице или в SVG‑документе, который содержит результат.

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

Страничный хост может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий открывает возможности для просмотрщиков слайдов, улучшений доступности и других интерактивных сценариев работы с SVG.

## **ЧаВо**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Как лучше всего уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылки на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, потому что снижение разрешения изображений, уменьшение качества JPEG и векторизация текста каждый по‑своему влияют на качество и размер.

**Можно ли изменять экспортированные SVG‑элементы после экспорта?**

Да. Присвойте идентификаторы через контроллер форматирования, а затем выбирайте соответствующие SVG‑элементы в вашем инструменте пост‑обработки или скрипте браузера.