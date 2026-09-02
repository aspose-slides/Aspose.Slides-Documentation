---
title: Управление эффектами трансформации изображений в презентациях с .NET
linktitle: Эффекты трансформации изображений
type: docs
weight: 11
url: /ru/net/image-transform-effects/
keywords:
- трансформация изображений
- эффект изображения
- яркость
- контраст
- градация серого
- дуотон
- оттенок
- HSL
- замена цвета
- размытие
- прозрачность
- альфа-эффект
- цепочка эффектов
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Применяйте, комбинируйте, просматривайте, удаляйте и проверяйте эффекты трансформации изображений для рамок рисунков с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides представляет коррекцию изображений как упорядоченную коллекцию операций трансформации изображений. Для рамки изображения начните с её [ISlidesPicture](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/imagetransform/). Возвращаемая [IImageTransformOperationCollection](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без переписывания оригинальных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного прохождения PPTX.

## **Поймите владение эффектами и повторное использование изображений**

Ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/) относится к заполнению изображения и указывает на ресурс изображения, при этом хранит коллекцию трансформаций изображения.
- [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) — это форма слайда, которая владеет соответствующим заполнением изображения, геометрией, настройками обрезки и другим форматированием уровня рамки.

Поэтому операции трансформации изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/) более одного раза, каждый новый кадр получает собственный `ISlidesPicture` и собственную коллекцию трансформаций. Применение градации серого к одному кадру не делает остальные кадры градацией серого, несмотря на то что все они используют один и тот же встроенный ресурс изображения.

Та же модель `ISlidesPicture.ImageTransform` используется и другими заполнениями изображений, например фигурой или фоном слайда. Примеры ниже сосредоточены на кадрах изображений.

## **Используйте допустимые диапазоны параметров и единицы измерения**

Продемонстрированные методы используют следующие семантические диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждое значение сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или открытии файла PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица измерения |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` до `100`, процентов; `0` оставляет компонент без изменений. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Нет | Нет числовых параметров. Альфа остаётся без изменений. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `System.Drawing.Color` используют значения от `0` до `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Тон — от `0` включительно до `360` исключительно, в градусах; количество — от `-100` до `100`, процентов. |
| [AddHSLEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Тон — от `0` включительно до `360` исключительно, в градусах; насыщенность и яркость — от `-100` до `100`, процентов. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Цвет замены использует значения каналов от `0` до `255`. Существующие альфа‑значения остаются без изменений. |
| [AddBlurEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус — неотрицательный, измеряется в пунктах; `grow` — логическое, определяющее, может ли размытие выходить за пределы исходных границ. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательный процент. Для обычного масштабирования непрозрачности используйте `0`–`100`: `0` — полностью прозрачно, `100` — сохраняет исходную альфу. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0`–`100`, процентов непрозрачности. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0`–`100`, процентов порога альфа. Значения ниже порога становятся прозрачными; значения на уровне и выше — непрозрачными. |

Для фиксированной модуляции альфа‑прозрачности прозрачность и непрозрачность являются дополнениями. Например, 35 % прозрачности соответствует значению модуляции альфа = 65 %.

## **Применение яркости и контраста**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ibrightnesscontrast/). Ее скалярные настройки задаются при создании операции. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/brightnesscontrast/geteffective/) возвращает вычисленные только для чтения значения, которые можно просмотреть или залогировать.

Следующий пример увеличивает яркость на 15 % и контраст на 20 %, затем отображает предварительный просмотр без изменения встроенного изображения:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/brightnesscontrast/) — расширение эффекта изображения Office 2010 и менее переносимо, чем стандартный эффект luminance DrawingML. Когда яркость и контраст должны оставаться редактируемыми после обратного прохождения PPTX, используйте [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) и проверяйте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие более подробно.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным кадрам, использующим один ресурс изображения. Следующий пример создает пять кадров и применяет градацию серого, дуотон, оттенок, регулировку HSL и замену цвета.

[IDuotone](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iduotone/) содержит два независимо редактируемых цветовых параметра: `Color1` сопоставляет тёмные пиксели, а `Color2` — светлые. Это делает его полезным примером эффекта с более сложными настройками, чем один скаляр.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) заменяет каждый пиксель фиксированным цветом, сохраняя альфа‑канал. Это отличается от [AddColorChangeEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), который сопоставляет один исходный цвет другому и раскрывает форматы обоих цветов.

## **Добавьте размытие, прозрачность и альфа‑эффекты**

[AddBlurEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) затрагивает все цветовые каналы, включая альфа. Установите `grow` в `true`, если размытие может выходить за пределы исходных границ изображения.

Для равномерной прозрачности используйте [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) вместо этого назначает одно значение альфа всем пикселям. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) преобразует альфа в два уровня по заданному порогу.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Другие альфа‑операции без параметров включают [AddAlphaCeilingEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), который делает каждый ненулевой альфа полностью непрозрачным; [AddAlphaFloorEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [AddAlphaInverseEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), который меняет альфа на `100% - alpha`.

## **Постройте упорядоченную цепочку эффектов**

Каждый метод `Add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в другом порядке могут дать разный результат.

Например, градация серого, а затем оттенок сначала удаляют цветовую информацию, а затем перекрашивают полученную яркость. Оттенок, а затем градация серого удаляют оттенок обратно. Аналогично, замена альфа может переопределить значения, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример строит цепочку из четырёх операций, сохраняет её как PPTX, открывает презентацию вновь, проверяет типы и порядок операций и отображает повторно открытый результат:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

Коллекция не накладывает матрицу совместимости, которая ограничивала бы цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но не все комбинации полезны. Фиксированная замена цвета убирает вариацию RGB, созданную предыдущими цветовыми эффектами; градация серого после дуотона удаляет два выбранных цвета; а операции альфа‑ceiling, floor, replacement или bi‑level могут отбросить детали альфа, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не как набор несортированных флагов форматирования.

## **Просмотрите редактируемые и эффективные значения**

Редактируемая операция — это объект, хранящийся в `ISlidesPicture.ImageTransform`. В зависимости от эффекта она может напрямую раскрывать изменяемые члены. Например, [IBlur](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iblur/) раскрывает записываемые `Radius` и `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ialphamodulatefixed/) — `Amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ialphabilevel/) — `Threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/itint/) и [IAlphaReplace](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ialphareplace/), не раскрывают свои скалярные параметры как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в нужной позиции.

Эффективные данные, возвращаемые `GetEffective()`, вычисляются и доступны только для чтения. Они полезны для разрешения зависящих от темы цветов и чтения нормализованных значений, используемых рендерером, но не представляют собой отдельный слой редактирования. Следующий пример перебирает цепочку и просматривает эффективные значения, где соответствующий API их предоставляет:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Эффекты без параметров, такие как градация серого, альфа‑ceiling и альфа‑inverse, всё равно имеют объект эффективных данных, но нет скалярных настроек для вывода. Их наличие и позиция в коллекции являются важной информацией.

## **Удалите или очистите трансформации изображения**

Используйте [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перебора. Метод `Clear()` удаляет всю цепочку.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Удаление или очистка трансформаций меняет только форматирование изображения. Это не удаляет, не пере‑сжимает и не изменяет используемый повторно [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) ресурс.

## **Учтите форматы презентаций и целевые экспортные типы**

Трансформации изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже с PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как luminance, grayscale, duotone, tint, HSL, blur и общие альфа‑операции, имеют наилучшие шансы выжить при обратном прохождении PPTX. Всегда открывайте сгенерированный файл вновь и проверяйте коллекцию, когда требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/brightnesscontrast/) — расширение Office 2010, а не стандартная операция luminance DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что после сохранения и повторного открытия PPTX он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/ibrightnesscontrast/). Предпочтительно использовать [AddLuminanceEffect](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) для постоянных настроек яркости и контраста.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опустить неподдерживаемые операции, сократить цепочку до поддерживаемого подмножества или приблизительно отобразить внешний вид. Не используйте PPT как формат проверки сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к отображаемому результату. Эти выводы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы плоско сохраняют результат в пикселях, а экспорт документов/векторов хранит своё собственное представление рендеринга.
- Эффекты не делают связанное изображение автономным. Рендеринг связанного изображения всё равно требует доступности связанного ресурса при загрузке презентации.

Разные потребители презентаций могут по‑разному обрабатывать граничные случаи, особенно когда объединяются несколько альфа‑ или цветоквантовых операций. Для критических результатов тестируйте как редактируемый обратный проход, так и финальный экспортный формат с той же версией Aspose.Slides, что используется в продакшине.

## **FAQ**

**Изменяют ли эффекты трансформации изображения встроенные данные изображения?**

Нет. Операции принадлежат `ISlidesPicture`, используемому в заполнении изображения. Базовые байты `IPPImage` остаются без изменений.

**Будут ли два кадра, использующие один и тот же ресурс изображения, делить свои эффекты?**

Нет. Повторное использование `IPPImage` избегает дублирования данных изображения, но каждый кадр обычно имеет отдельный `ISlidesPicture` и свою коллекцию трансформаций.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учтите, как каждая операция влияет на вывод предыдущей, поскольку операции замены и порога могут отбрасывать ранее созданные детали цвета или альфа.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции трансформаций, где существуют записываемые члены; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат использовать для сохранения цепочки трансформаций?**

Используйте PPTX и проверяйте файл, открывая его вновь. Устаревший PPT не может представить полную модель эффектов DrawingML, а экспортные форматы сохраняют лишь внешний вид, а не редактируемые операции трансформации.