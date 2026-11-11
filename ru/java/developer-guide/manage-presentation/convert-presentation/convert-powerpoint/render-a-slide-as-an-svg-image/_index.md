---
title: Рендеринг слайдов презентации в SVG-изображения на Java
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
description: "Экспортируйте слайды PowerPoint в виде SVG-изображений на Java и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотрщиков слайдов, процессов обеспечения доступности и автоматической пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) , когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Следующий пример экспортирует каждый слайд презентации в отдельный файл SVG.

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

Имя файла использует [ISlide.getSlideNumber](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getSlideNumber--) вместо индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [IShape.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) , когда просмотрщику слайдов или веб‑странице нужна только эта фигура.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/) управляет визуализацией SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) включает рамку текста в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) определяет, применяется ли поворот рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) в `true`, когда текст должен отображаться без лигатур.

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

## **Управление обрезкой линии у наконечников стрелок**

В SVG 1.1 нет параметра смещения маркера, позволяющего указать, где линия должна завершаться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортированную линию, чтобы её штрих не выступал за маркер. Вызовите [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) с `true`, чтобы рисовать штрих до исходной конечной точки линии. Этот параметр влияет только на вывод SVG. Линия сохраняет своё положение и длину на слайде.

В примере рисуются треугольные и ромбовидные наконечники на линиях шириной 2 и 10 пунктов. Он экспортирует один и тот же слайд дважды, изменяя только параметр обрезки.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    int y = 40;
    
    for (byte style : new byte[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond }) {
        for (int width : new int[] { 2, 10 }) {
            IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0);
            ILineFormat format = line.getLineFormat();
            format.getFillFormat().setFillType(FillType.Solid);
            format.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
            format.setWidth(width);
            format.setEndArrowheadStyle(style);
            y += 50;
        }
    }

    SVGOptions options = new SVGOptions();
    options.setDisableLineEndCropping(false);
    try (FileOutputStream cropped = new FileOutputStream("cropped.svg")) {
        slide.writeAsSvg(cropped, options);
    }

    options.setDisableLineEndCropping(true);
    try (FileOutputStream uncropped = new FileOutputStream("uncropped.svg")) {
        slide.writeAsSvg(uncropped, options);
    }
} finally {
    presentation.dispose();
}
```

Сравнение показывает треугольный наконечник на 10‑пунктовой линии. При включённой обрезке кончик остаётся острым. При отключённой обрезке штрих выступает за наклонные стороны маркера, образуя плоский конец.

![Увеличенный треугольник шириной 10 пунктов с острым наконечником при включённой обрезке и плоским концом при отключённой обрезке](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен на треугольнике шириной 2 пункта. Заполненный ромб покрывает конец штриха в обоих случаях ширины.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете управлять тем, останется ли текст в виде текста или будет преобразован в векторную графику, а также тем, как включаются или ссылаются внешние шрифты. Следующие параметры помогают сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) в `true`, чтобы записать весь текст слайда как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным между браузерами, однако текст больше нельзя выделять или искать как SVG‑текст.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы преобразовать в графику только текст, использующий внешние шрифты. Проверьте лицензирование шрифтов перед их встраиванием.

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

## **Уменьшение размера встроенных изображений**

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) для снижения разрешения встроенных изображений, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) — чтобы исключать обрезанные участки источника, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) — для управления качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счет потери качества изображения или сохранённых данных изображения.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы сбалансировать детализацию и размер файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором находится изображение EMF с плотно расположенными диагональными линиями. Следующий пример экспортирует первый слайд с тремя разрешениями растеризации с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Все остальные параметры экспорта остаются одинаковыми, чтобы можно было сравнить результаты.

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

В результате EMF превратилось в один встроенный PNG в каждом SVG. Ниже приведённые измерения относятся к прилагаемой презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер SVG‑файла (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растра при одинаковом увеличенном размере отображения. Диагональные линии демонстрируют заметную пикселизацию при 72 DPI и более плавные края при более высоких разрешениях, при этом размер SVG‑файла увеличивается. Увеличение значения не обязательно улучшает каждую деталь или изменяет каждое экспортированное изображение.

![Увеличенные детали диагональных линий при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setPicturesCompression-int-) управляет снижением разрешения изображений и может скрывать эффект изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setJpegQuality-int-) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначение стабильных идентификаторов фигурам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) для установки [ISvgShape.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setId-java.lang.String-) для каждой фигуры SVG. Чтобы также задать значения [ISvgTSpan.setId](https://reference.aspose.com/slides/java/com.aspose.slides/isvgtspan/#setId-java.lang.String-) для элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeandtextformattingcontroller/). Примените любой из контроллеров с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Следующий контроллер использует [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--), который стабилен в течение срока жизни фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

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

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshapeformattingcontroller/) вызовите [ISvgShape.setEventHandler](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) с значением [SvgEvent](https://reference.aspose.com/slides/java/com.aspose.slides/svgevent/), чтобы добавить обработчик JavaScript к экспортированной фигуре. Примените контроллер с помощью [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) и определите JavaScript‑функцию на странице или в SVG‑документе, где размещён результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет реализовать просмотрщики слайдов, улучшения доступности и другие интерактивные сценарии работы с SVG.

## **FAQ**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/)?**  
Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/java/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/java/com.aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего уменьшить размер SVG?**  
Начните с сжатия встроенных изображений, удаления обрезанных участков изображений и выбора связных файлов шрифтов, если целевая среда может их обслуживать. Проверьте результат, поскольку более низкое разрешение изображений, более низкое качество JPEG и векторизованный текст имеют разные компромиссы между качеством и размером.

**Можно ли изменять экспортированные элементы SVG после экспорта?**  
Да. Назначьте идентификаторы через контроллер форматирования, затем выберите соответствующие элементы SVG в вашем инструменте пост‑обработки или скрипте браузера.