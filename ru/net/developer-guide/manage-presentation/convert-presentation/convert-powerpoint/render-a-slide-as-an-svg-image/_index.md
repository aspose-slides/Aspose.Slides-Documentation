---
title: Экспорт слайдов презентаций в виде изображений SVG в .NET
linktitle: Слайд в SVG
type: docs
weight: 50
url: /ru/net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint в SVG
- презентация в SVG
- слайд в SVG
- PPT в SVG
- PPTX в SVG
- опции экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint в виде SVG‑изображений в .NET и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — это масштабируемый формат изображений на основе XML, который хорошо подходит для веб‑публикации, просмотра слайдов, рабочих процессов доступности и автоматической пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) когда экспортированный SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспортировать слайд в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), выберите слайд и запишите его в поток. В следующем примере каждый слайд презентации экспортируется в отдельный файл SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Имя файла использует [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) вместо индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/), когда просмотрщику слайдов или веб‑странице нужна только эта фигура.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) контролирует визуализацию SVG. Для текстовых рамок [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) включает рамку текста в область рендеринга, а [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) в `true`, когда текст должен рендериться без лигатур.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Управление обрезкой линии у наконечников стрелок**

В SVG 1.1 нет настройки смещения маркера, позволяющей указать, где линия должна остановиться под наконечником стрелки. По умолчанию Aspose.Slides укорачивает экспортируемую линию, чтобы её штрих не выступал за пределы маркера. Установите [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) в `true`, чтобы рисовать штрих до исходной конечной точки линии. Эта настройка влияет только на вывод SVG. Позиция и длина линии на слайде остаются без изменений.

В примере рисуются треугольные и ромбовидные наконечники на линиях толщиной 2 и 10 пунктов. Один и тот же слайд экспортируется дважды, меняется только параметр обрезки.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Сравнение показывает треугольный наконечник на 10‑пунктовой линии. При включённой обрезке наконечник острый. При отключённой обрезке штрих выступает за наклонные стороны маркера, оставляя плоский конец.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

В остальных линиях примера выступающий штрих менее заметен на 2‑пунктовом треугольнике. Заполненный ромб покрывает конец штриха при обеих толщинах.

## **Управление текстом и шрифтами**

При экспорте слайдов в SVG вы можете контролировать, останется ли текст текстовым или будет преобразован в векторную графику, а также как включаются или ссылки на внешние шрифты. Следующие параметры помогают сбалансировать визуальную согласованность, возможность выделения текста и зависимости от шрифтов в экспортированном SVG.

### **Векторизовать весь текст**

Установите [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) в `true`, чтобы записать весь текст слайда как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным между браузерами, но текст больше нельзя будет выделять или искать как SVG‑текст.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Выбор способа обработки внешних шрифтов**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed`, чтобы включить данные шрифта в SVG, или `Vectorize`, чтобы рендерить только текст, использующий внешние шрифты, как графику. Проверьте лицензирование шрифтов перед их встраиванием.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Уменьшить размер встроенных изображений**

Используйте [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) для снижения разрешения встроенных изображений, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) для исключения обрезанных областей исходных изображений и [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) для управления качеством кодирования JPEG. Эти настройки уменьшают размер файла ценой качества изображения или количества сохраняемых данных изображения.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Управление разрешением растеризации метафайлов**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) задаёт нижний предел разрешения при растеризации метафайлов во время экспорта SVG. Используйте его, чтобы сбалансировать детализацию и размер файла, когда растеризуется изображение EMF или WMF. Он не определяет глобальное DPI для SVG и не заставляет каждый объект на слайде становиться растровым изображением.

Скачайте [metafile-rasterization.pptx](metafile-rasterization.pptx), в котором содержится изображение EMF с плотно расположенными диагональными линиями. В следующем примере первая страница презентации экспортируется при трёх разрешениях растеризации через [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Все остальные параметры экспорта остаются одинаковыми, чтобы было возможно сравнение результатов.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

В результате EMF превратился в один встроенный PNG в каждом SVG. Ниже приведены измерения для предоставленной презентации; они не представляют общую формулу преобразования DPI в пиксельные размеры.

| DPI растеризации метафайла | Размеры встроенного PNG | Размер SVG файла (байт) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Сравнение ниже показывает одну и ту же область встроенного растрового изображения при одинаковом увеличенном размере отображения. Диагональные линии видимо пикселизованы при 72 DPI и имеют более гладкие края при более высоких разрешениях, при этом размер SVG растёт. Увеличение значения не обязательно улучшает каждую деталь или меняет каждое экспортируемое изображение.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) управляет снижением разрешения изображения и может скрывать эффект изменения разрешения растеризации метафайла. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) контролирует качество кодирования JPEG, а не разрешение растеризации метафайла.

## **Назначить стабильные идентификаторы фигурам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) для установки [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) каждой SVG‑фигуры. Чтобы также задать значения [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) у элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Присвойте любой из контроллеров через [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Следующий контроллер использует [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), который стабилен в течение жизненного цикла фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для пост‑обработки неизменённой презентации.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Добавить обработчики событий SVG**

В [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) вызовите [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) с параметром [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/), чтобы добавить JavaScript‑обработчик события к экспортируемой фигуре. Присвойте контроллер через [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) и определите JavaScript‑функцию на странице или в SVG‑документе, где размещён результат.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Страничный хост может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий открывает возможности для просмотрщиков слайдов, улучшения доступности и других интерактивных SVG‑рабочих процессов.

## **FAQ**

**Когда следует использовать [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), когда только текст, использующий внешние шрифты, следует преобразовать в графику.

**Какой лучший способ уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Тестируйте результат, так как снижение разрешения изображения, снижение качества JPEG и векторизация текста каждый по‑своему влияют на качество и размер.

**Можно ли изменять экспортированные элементы SVG после экспорта?**

Да. Присвойте идентификаторы через контроллер форматирования, а затем выберите соответствующие SVG‑элементы в вашем инструменте пост‑обработки или скрипте браузера.