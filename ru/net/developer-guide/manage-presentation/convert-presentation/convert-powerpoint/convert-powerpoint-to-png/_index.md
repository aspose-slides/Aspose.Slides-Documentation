---
title: Преобразование слайдов PowerPoint в PNG в .NET
linktitle: PowerPoint в PNG
type: docs
weight: 30
url: /ru/net/convert-powerpoint-to-png/
keywords:
- преобразовать PowerPoint
- преобразовать презентацию
- преобразовать слайд
- преобразовать PPT
- преобразовать PPTX
- PowerPoint в PNG
- презентацию в PNG
- слайд в PNG
- PPT в PNG
- PPTX в PNG
- сохранить PPT как PNG
- сохранить PPTX как PNG
- экспортировать PPT в PNG
- экспортировать PPTX в PNG
- .NET
- C#
- Aspose.Slides
description: "Быстро преобразуйте презентации PowerPoint в качественные изображения PNG с помощью Aspose.Slides для .NET, обеспечивая точные, автоматизированные результаты."
---
## **Обзор**

В этой статье объясняется, как преобразовать слайды презентаций в изображения PNG с помощью Aspose.Slides для .NET. Вы можете загружать презентации в форматах PPT, PPTX и ODP, отрисовывать каждый слайд и сохранять его как отдельное изображение PNG.

Приведённые ниже примеры демонстрируют создание миниатюр, установку коэффициентов масштабирования, указание размеров вывода в пикселях и выбор стиля рендеринга градиентов.

## **Преобразовать PowerPoint в PNG**

Загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) и получите доступ к её слайдам через коллекцию [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). В примере каждый слайд отрисовывается с помощью [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) без параметров для создания миниатюры. Затем вызывается [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) с [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) для сохранения каждого отрисованного слайда в виде изображения PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
Перегрузка [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) без параметров отрисовывается с масштабом 0.2. Например, слайд размером 720 × 540 пунктов даёт миниатюру 144 × 108 пикселей. Чтобы контролировать размеры вывода, используйте перегрузки с коэффициентами масштабирования или явным указанием размера изображения, как показано ниже.
{{% /alert %}}

## **Преобразовать PowerPoint в PNG с пользовательскими размерами**

Передайте горизонтальные и вертикальные коэффициенты масштабирования в [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) для контроля размеров отрисовки. В этом примере оба коэффициента равны 2, поэтому слайд размером 720 × 540 пунктов даёт изображение 1440 × 1080 пикселей. Одинаковые коэффициенты сохраняют соотношение сторон слайда. Каждое изображение сохраняется в формате PNG с помощью [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Преобразовать PowerPoint в PNG с пользовательским размером**

Для указания размеров вывода в пикселях передайте размер в [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) вместо коэффициентов масштабирования. Этот пример отрисовывает каждый слайд размером 960 × 720 пикселей и сохраняет результат с помощью [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Выбирайте размеры, соответствующие соотношению сторон слайда, чтобы избежать растягивания изображения.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Выбрать стиль рендеринга градиентов**

Предположим, что слайд содержит градиентные заливки, но переходы в экспортированном PNG выглядят светлее или иначе, чем в PowerPoint. Вы можете использовать свойство [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) класса [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) для выбора способа рендеринга градиентов.

Скачайте файл [gradient-styles.pptx](gradient-styles.pptx) и поместите его в рабочий каталог приложения. Первый слайд содержит два линейных градиента: от цианового к оранжевому вверху и от синего к жёлтому внизу. Каждый градиент имеет две остановки — на 0 % и 100 %.

Следующий пример загружает эту презентацию и отрисовывает первый слайд в обоих режимах с помощью [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

Ниже показаны изображения вывода одного и того же слайда, где каждый градиент присутствует на каждом изображении:

| Default | PowerPointUI |
| --- | --- |
| ![Градиенты от цианового к оранжевому и от синего к жёлтому, отрисованные с Default](gradient-Default.png) | ![Те же градиенты, отрисованные с PowerPointUI](gradient-PowerPointUI.png) |

В этом примере `Default` генерирует более светлые промежуточные цвета, тогда как `PowerPointUI` — более тёмные. Разница зависит от цветов и остановок в градиенте.

Выбирайте `Default`, когда стандартный вывод Aspose.Slides отвечает вашим требованиям. Пробуйте `PowerPointUI`, если приоритет — соответствие внешнему виду в PowerPoint. Сравните оба вывода с желаемым результатом; ни один из режимов не является универсально лучшим.

## **Часто задаваемые вопросы**

**Как экспортировать конкретную форму, например диаграмму или изображение, вместо всего слайда?**

Aspose.Slides поддерживает [создание миниатюр для отдельных фигур](/slides/ru/net/create-shape-thumbnails/), позволяя отрисовать форму в виде изображения PNG.

**Поддерживается ли параллельное преобразование на сервере?**

Да. Используйте отдельный экземпляр презентации для каждого потока или процесса; [не делите один экземпляр между потоками](/slides/ru/net/multithreading/).

**Каковы ограничения оценочной версии при экспорте в PNG?**

Режим оценки добавляет водяной знак к выходным изображениям и применяет [другие ограничения](/slides/ru/net/licensing/), пока лицензия не будет активирована.