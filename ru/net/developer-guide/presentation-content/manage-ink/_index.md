---
title: Управление объектами чернил презентации в .NET
linktitle: Управление чернилами
type: docs
weight: 95
url: /ru/net/manage-ink/
keywords:
- чернила
- объект чернил
- трасса чернил
- управление чернилами
- рисование чернил
- рисование
- экспорт чернил
- рендеринг чернил
- скрыть чернила
- IInkOptions
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Управляйте объектами чернил PowerPoint, редактируйте трассы и свойства кисти, а также контролируйте внешний вид чернил при экспорте в PDF, HTML, SVG, TIFF и изображения с помощью Aspose.Slides для .NET."
---
## **Введение**

PowerPoint предоставляет функцию чернил, позволяющую рисовать свободные штрихи. Чернила можно использовать для выделения других объектов, отображения связей и процессов, а также привлечения внимания к определённым элементам на слайде.

Пространство имён [Aspose.Slides.Ink](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/) содержит классы и интерфейсы, необходимые для работы с объектами чернил. Например, интерфейс [IInk](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iink/) представляет объект чернил на слайде.

## **Различия между обычными объектами и объектами чернил**

Объекты на слайде PowerPoint обычно представлены объектами формы. В самой простой форме форма — это контейнер, определяющий область самого объекта (его рамку) вместе с такими свойствами, как размер контейнера, форма и фон. Для получения дополнительной информации смотрите [Shape Layout Format](https://docs.aspose.com/slides/ru/net/shape-manipulations/#access-layout-formats-for-shape).

Однако когда PowerPoint обрабатывает объект чернил, он игнорирует все свойства рамки объекта (контейнера), за исключением его размеров. Размер области контейнера определяется стандартными свойствами [IShape.Width](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/width/) и [IShape.Height](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Траекты чернил**

Траект — это базовый элемент, используемый для записи траектории пера, когда пользователь пишет цифровые чернила. Траект хранит последовательность соединённых точек.

Самая простая форма кодирования указывает координаты X и Y каждой точки‑образца. Когда все соединённые точки отрисовываются, они образуют изображение, подобное этому:

![ink_powerpoint2](ink_powerpoint2.png)

## **Свойства кисти для рисования**

Кисть используется для рисования линий, соединяющих точки траекта чернил. Кисть имеет собственный цвет и размер, представленные свойствами [IInkBrush.Color](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iinkbrush/color/) и [IInkBrush.Size](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iinkbrush/size/).

### **Установка цвета кисти чернил**

Этот код C# демонстрирует, как установить цвет кисти чернил:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Установка размера кисти чернил**

Этот код C# демонстрирует, как установить размер кисти чернил:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Как правило, ширина и высота кисти не совпадают, поэтому PowerPoint не отображает размер кисти (соответствующий раздел данных затемнён). Когда ширина и высота кисти совпадают, PowerPoint отображает её размер так:

![ink_powerpoint3](ink_powerpoint3.png)

Для наглядности увеличим высоту объекта чернил и рассмотрим важные размеры:

![ink_powerpoint4](ink_powerpoint4.png)

Контейнер (рамка) не учитывает размер кистей — он всегда предполагает, что толщина линии равна нулю (см. предыдущее изображение).

Следовательно, чтобы определить видимую область всего объекта чернил, необходимо учитывать размер кисти его траектов. Здесь целевой объект (трасса рукописного текста) масштабирован до размеров контейнера (рамки). При изменении размеров контейнера размер кисти остаётся постоянным и наоборот.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint использует аналогичное поведение для текстовых объектов:

![ink_powerpoint6](ink_powerpoint6.png)

## **Управление внешним видом чернил при экспорте и рендеринге**

Aspose.Slides предоставляет интерфейс [IInkOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/) для управления тем, как объекты чернил отображаются в экспортированных или отрендеренных результатах. С помощью его свойств можно полностью скрыть чернила или изменить способ интерпретации операций маски кисти чернил.

Параметры чернил доступны через параметры экспорта или рендеринга для нескольких типов вывода:

| Вывод | Свойство параметров чернил |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Изображение слайда | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/renderingoptions/inkoptions/) |

Через эти свойства доступны два одинаковых параметра:

- [`HideInk`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/hideink/) определяет, включать ли объекты чернил в вывод. Значение по умолчанию — `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) определяет, интерпретировать ли операцию маски как непрозрачность при рендеринге кисти чернил. Значение по умолчанию — `true`; установите `false`, чтобы использовать операцию ROP вместо неё.

### **Скрытие объектов чернил в выводе PDF**

По умолчанию объекты чернил остаются видимыми при экспорте. Установите [IInkOptions.HideInk](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/hideink/) в `true`, когда требуется чистый вывод без рукописных аннотаций или другого контента чернил.

Следующий пример C# экспортирует презентацию в PDF, скрывая все объекты чернил:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Скрытие объектов чернил при рендеринге слайда в изображение**

Чтобы скрыть объекты чернил при рендеринге слайдов в растровые изображения, настройте [RenderingOptions.InkOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/renderingoptions/inkoptions/) и передайте параметры рендеринга методу [ISlide.GetImage](https://reference.aspose.com/slides/ru/net/aspose.slides/islide/getimage/).

Следующий пример C# рендерит первый слайд в PNG‑изображение без объектов чернил:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Управление рендерингом маски чернил**

Свойство [IInkOptions.InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) управляет тем, как операции маски интерпретируются при рендеринге кистей чернил. Значение по умолчанию — `true`, что использует непрозрачность. Установите свойство в `false`, чтобы вместо этого использовать операцию ROP.

Следующий пример C# экспортирует слайд в SVG и использует рендеринг на основе ROP для операций маски чернил:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

То же самое можно применить через [TiffOptions.InkOptions](https://reference.aspose.com/slides/ru/net/aspose.slides.export/tiffoptions/inkoptions/) при экспорте презентации или рендеринге слайда в TIFF.

### **Выбор: скрывать или сохранять чернила**

Используйте [IInkOptions.HideInk](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/hideink/) со значением `true`, когда экспортируемый файл должен быть чистой версией аннотированной презентации, например, финальной копией, предназначенной для распространения без меток рецензирования.

Оставьте [IInkOptions.HideInk](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/hideink/) со значением по умолчанию `false`, когда аннотации чернилом являются частью предполагаемого содержания, например, комментарии рецензирования, рукописные заметки, выделения или рисунки, которые должны оставаться видимыми в экспортированном результате. Это позволяет приложениям генерировать отдельные версии для рецензирования и финального результата из одной и той же презентации без изменения исходных объектов чернил.

## **FAQ**

**Можно ли изменить цвет или размер существующего штриха чернил?**

Да. Получите траект из [IInk.Traces](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iink/traces/), затем измените его [IInkTrace.Brush](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iinktrace/brush/). Вы можете задать свойства [IInkBrush.Color](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iinkbrush/color/) и [IInkBrush.Size](https://reference.aspose.com/slides/ru/net/aspose.slides.ink/iinkbrush/size/).

**Меняется ли исходная презентация при скрытии чернил?**

Нет. [IInkOptions.HideInk](https://reference.aspose.com/slides/ru/net/aspose.slides.export/iinkoptions/hideink/) влияет только на отрендеренный или экспортированный результат; он не удаляет и не изменяет объекты чернил в исходной презентации.

**Для каких форматов экспорта поддерживаются параметры чернил?**

Вы можете настроить параметры чернил для PDF, HTML, SVG, TIFF и растровых изображений слайдов через соответствующие параметры экспорта или рендеринга, указанные выше.

**Дополнительные материалы**

* Чтобы узнать больше о формах в целом, см. раздел [PowerPoint Shapes](https://docs.aspose.com/slides/ru/net/powerpoint-shapes/).
* Для получения информации об эффективных значениях см. [Shape Effective Properties](https://docs.aspose.com/slides/ru/net/shape-effective-properties/#get-effective-font-height-value).
* Подробности экспорта в PDF — [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/ru/net/convert-powerpoint-to-pdf/).
* Подробности экспорта в HTML — [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/ru/net/convert-powerpoint-to-html/).
* Подробности экспорта в SVG — [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/ru/net/render-a-slide-as-an-svg-image/).
* Подробности экспорта в TIFF — [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/ru/net/convert-powerpoint-to-tiff/).
* Подробности рендеринга слайда в изображение — [Convert Presentation Slides to Images](https://docs.aspose.com/slides/ru/net/convert-slide/).