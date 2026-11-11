---
title: Экспорт слайдов презентации в SVG‑изображения на Android
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
description: "Экспортируйте слайды PowerPoint в SVG‑изображения на Android и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикаций, просмотрщиков слайдов, процессов обеспечения доступности и автоматической постобработки. Aspose.Slides for Android via Java экспортирует каждый слайд в отдельный файл SVG и позволяет контролировать, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/), когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), выберите слайд и запишите его в поток с помощью [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). В следующем примере каждый слайд презентации экспортируется в отдельный файл SVG.

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

Для имени файла используется [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) вместо индекса цикла. Вы также можете экспортировать отдельную форму с помощью [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), когда просмотрщику слайдов или веб‑странице нужен только этот объект.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) включает рамку в область рендеринга, а [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) определяет, применять ли вращение рамки. Установите [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) в значение `true`, когда текст должен рендериться без лигатур.

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

## **Управление обрезкой конца линии у стрелок**

В SVG 1.1 нет настройки `marker-inset`, позволяющей указать, где линия должна обрезаться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортируемую линию, чтобы её штрих не выступал за маркер. Вызовите [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableLineEndCropping-boolean-) со значением `true`, чтобы рисовать штрих до оригинального конца линии. Эта настройка влияет только на вывод SVG. Позиция и длина линии на слайде остаются прежними.

В примере показываются треугольные и ромбовидные наконечники на линиях толщиной 2 и 10 пунктов. Один и тот же слайд экспортируется дважды, меняется только параметр обрезки.

```java
import com.aspose.slides.*;
import android.graphics.Color;
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
            format.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
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

Сравнение демонстрирует треугольный наконечник на 10‑пунктовой линии. При включённой обрезке кончик остаётся острым. При отключённой обрезке штрих выступает за наклонные стороны маркера, образуя плоский конец.

![Увеличенный треугольник 10 пунктов с острым наконечником при включенной обрезке и плоским концом при отключенной обрезке](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен на 2‑пунктовом треугольнике. Заполненный ромб покрывает конец штриха в обоих случаях.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст текстом или будет преобразован в векторную графику, а также как будут включаться или ссылаться внешние шрифты. Ниже перечислены параметры, помогающие сбалансировать визуальную согласованность, возможность выбора текста и зависимости от шрифтов в экспортируемом SVG.

### **Векторизация всего текста**

Установите [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) в значение `true`, чтобы записать весь текст слайда как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст уже нельзя будет выделять или искать как SVG‑текст.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) принимает значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы ссылаться на отдельные файлы шрифтов, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы включать данные шрифта в SVG, или [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), чтобы рендерить только текст, использующий внешние шрифты, как графику. Перед включением шрифтов проверьте их лицензионные ограничения.

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

Используйте [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-), чтобы уменьшить разрешение встроенных картинок, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), чтобы исключать обрезанные области исходных изображений, и [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-), чтобы управлять качеством JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт потери качества изображения или удалённых данных изображения.

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

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы найти баланс между детализацией и размером файла, когда растеризуется изображение EMF или WMF. Этот параметр не задаёт глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором содержится изображение EMF с плотно расположенными диагональными линиями. В следующем примере первая страница экспортируется с тремя различными разрешениями растеризации через [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Все остальные параметры экспорта остаются одинаковыми, чтобы результаты было удобно сравнивать.

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

В результате EMF преобразуется в один встроенный PNG в каждом SVG. Ниже приведены измерения для представленной презентации; они не являются общей формулой преобразования DPI в пиксельные размеры.

| Разрешение растеризации метафайла DPI | Размеры встроенного PNG | Размер файла SVG (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже демонстрирует один и тот же участок растрового изображения при одинаковом увеличенном размере отображения. Диагональные линии показывают заметную пикселизацию при 72 DPI и более гладкие края при более высокой детализации, при этом размер SVG‑файла растёт. Увеличение значения не обязательно улучшает каждый элемент детали или меняет каждое экспортируемое изображение.

![Увеличенная детализация диагональной линии при 72, 150 и 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) управляет уменьшением разрешения изображений и может скрывать влияние изменения разрешения растеризации метафайла. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) управляет качеством JPEG‑кодирования, а не разрешением растеризации метафайла.

## **Назначение стабильных идентификаторов формам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), чтобы задать [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) для каждой SVG‑формы. Чтобы также задать значения [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) для элементов `tspan` текста, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Присвойте любой из контроллеров через [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Ниже показан контроллер, использующий [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), который стабилен в течение жизни формы, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для постобработки неизменённой презентации.

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

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) вызовите [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) с значением [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/), чтобы добавить JavaScript‑обработчик события к экспортируемой форме. Присвойте контроллер через [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) и определите JavaScript‑функцию на странице или в SVG‑документе, где будет использоваться результат.

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

Страницу‑хост может определить JavaScript‑функцию, на которую ссылается обработчик. Назначение идентификаторов и обработчиков событий позволяет создавать просмотрщики слайдов, улучшать доступность и реализовывать другие интерактивные сценарии работы с SVG.

## **FAQ**

**Когда следует использовать [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Используйте [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, должен быть преобразован в графику.

**Как лучше всего сделать SVG меньше?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылки на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, потому что снижение разрешения изображения, снижение JPEG‑качества и векторизация текста по‑разному влияют на качество и размер файла.

**Можно ли изменять экспортированные элементы SVG после экспорта?**

Да. Назначьте идентификаторы через контроллер форматирования, затем выберите соответствующие SVG‑элементы в вашем инструменте постобработки или скрипте браузера.