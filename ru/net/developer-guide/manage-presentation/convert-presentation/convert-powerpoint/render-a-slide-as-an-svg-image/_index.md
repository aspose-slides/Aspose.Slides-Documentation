---
title: Рендеринг слайдов презентаций в виде SVG‑изображений в .NET
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
- Параметры экспорта SVG
- интерактивный SVG
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Экспортируйте слайды PowerPoint в виде SVG‑изображений в .NET и управляйте шрифтами, текстом, изображениями, идентификаторами и событиями с помощью Aspose.Slides."
---
## **Обзор**

SVG — масштабируемый основанный на XML формат изображений, который хорошо подходит для веб‑публикации, просмотра слайдов, процессов доступности и автоматической пост‑обработки. Aspose.Slides экспортирует каждый слайд в отдельный файл SVG и позволяет управлять тем, как записываются текст, шрифты, изображения и элементы SVG.

Используйте [SVGOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/) когда экспортируемый SVG должен быть компактным, предсказуемым во всех браузерах или готовым к интерактивному использованию.

## **Экспорт слайда в SVG**

Создайте [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/), выберите слайд и запишите его в поток. Следующий пример экспортирует каждый слайд презентации в отдельный файл SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Имя файла использует [ISlide.SlideNumber](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/slidenumber/) вместо индекса цикла. Вы также можете экспортировать отдельную фигуру с помощью [IShape.WriteAsSvg](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/writeassvg/), когда просмотрщику слайдов или веб‑странице нужна только эта фигура.

## **Настройка вывода SVG**

[SVGOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/) управляет рендерингом SVG. Для текстовых рамок [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/useframesize/) включает рамку текста в область рендеринга, а [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/useframerotation/) определяет, применяется ли вращение рамки. Установите [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/disablefontligatures/) в `true`, когда текст должен выводиться без лигатур.

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

## **Управление текстом и шрифтами**

### **Векторизация всего текста**

Установите [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/vectorizetext/) в `true`, чтобы записать весь текст слайда как векторную графику. Это устраняет зависимости от шрифтов и делает визуальный результат более согласованным во всех браузерах, но текст перестаёт быть выделяемым и поисковым как SVG‑текст.

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

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/externalfontshandling/) использует значение [SvgExternalFontsHandling](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgexternalfontshandling/) для шрифтов, загружаемых извне. Выберите `AddLinksToFontFiles`, чтобы ссылаться на отдельные файлы шрифтов, `Embed` — чтобы включить данные шрифта в SVG, или `Vectorize` — чтобы рендерить только текст, использующий внешние шрифты, как графику. Убедитесь в наличии лицензии на шрифт перед его встраиванием.

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

## **Сокращение размера встроенных изображений**

Используйте [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/picturescompression/) для уменьшения разрешения встроенных изображений, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/) чтобы опустить обрезанные области исходных изображений, и [SVGOptions.JpegQuality](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/jpegquality/) для контроля качества JPEG‑кодирования. Эти параметры уменьшают размер файла за счёт качества изображения или сохранённых данных изображения.

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

## **Назначение стабильных идентификаторов фигурам и тексту**

Используйте [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgshapeformattingcontroller/) для установки [ISvgShape.Id](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgshape/id/) каждой фигуре SVG. Чтобы также задавать значения [ISvgTSpan.Id](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgtspan/id/) у элементов текста `tspan`, реализуйте [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Назначьте любой контроллер с помощью [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Следующий контроллер использует [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/officeinteropshapeid/), который стабилен в течение срока жизни фигуры, и повторяемый счётчик для её текстовых спанов. Это делает сгенерированные идентификаторы пригодными для постобработки неизменённой презентации.

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

## **Добавление обработчиков событий SVG**

Внутри [ISvgShapeFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgshapeformattingcontroller/) вызовите [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/ru/net/aspose.slides.export/isvgshape/seteventhandler/) с значением [SvgEvent](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgevent/) для добавления обработчика JavaScript к экспортируемой фигуре. Назначьте контроллер с помощью [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) и определите JavaScript‑функцию на странице или в SVG‑документе, содержащем результат.

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

Хост‑страница может определить JavaScript‑функцию, на которую ссылается обработчик. Присвоение идентификаторов и обработчиков событий позволяет использовать просмотрщики слайдов, улучшать доступность и реализовывать другие интерактивные сценарии SVG.

## **FAQ**

**Когда следует использовать [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/vectorizetext/) вместо [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgexternalfontshandling/)?**

Используйте [SVGOptions.VectorizeText](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/vectorizetext/) когда весь текст должен быть независим от шрифтов. Используйте [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgexternalfontshandling/) когда следует преобразовать в графику только тот текст, который использует внешние шрифты.

**Как лучше уменьшить размер SVG?**

Начните с сжатия встроенных изображений, удаления обрезанных областей изображений и выбора ссылок на файлы шрифтов, если целевая среда может их обслуживать. Проверьте результат, так как уменьшение разрешения изображения, снижение качества JPEG и векторизация текста имеют различные компромиссы между качеством и размером.

**Можно ли изменять экспортированные элементы SVG после экспорта?**

Да. Присвойте идентификаторы через контроллер форматирования, а затем выберите соответствующие элементы SVG в вашем инструменте пост‑обработки или скрипте браузера.