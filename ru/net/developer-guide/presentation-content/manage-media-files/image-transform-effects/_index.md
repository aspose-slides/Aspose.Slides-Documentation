---
title: Управление эффектами преобразования изображения в презентациях с .NET
linktitle: Эффекты преобразования изображения
type: docs
weight: 11
url: /ru/net/image-transform-effects/
keywords:
- преобразование изображения
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
- альфа‑эффект
- цепочка эффектов
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Применяйте, комбинируйте, проверяйте, удаляйте и подтверждайте эффекты преобразования изображения для рамок картинок с помощью Aspose.Slides для .NET."
---
## **Обзор**

Aspose.Slides представляет настройки изображения как упорядоченную коллекцию операций преобразования изображения. Для рамки изображения начните с [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) и получите доступ к [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/). Возвращаемый [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) позволяет добавлять, перечислять, просматривать, удалять и очищать эффекты без перезаписи исходных байтов изображения.

В этой статье демонстрируется полный рабочий процесс для яркости и контраста, цветовых преобразований, размытия, прозрачности, упорядоченных цепочек эффектов, эффективных значений, удаления и проверки обратного прохода PPTX.

## **Понимание владения эффектом и повторного использования изображения**

Ресурс изображения и изображение, которое его отображает, являются разными объектами:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) хранит или ссылается на исходные данные изображения, принадлежащие презентации.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) принадлежит заполнению изображения и ссылается на ресурс изображения, при этом хранит коллекцию преобразований изображения.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) является формой слайда, владеющей соответствующим заполнением изображения, геометрией, настройками обрезки и другими параметрами формата уровня кадра.

Следовательно, операции преобразования изображения не изменяют байты в [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/). Когда один и тот же `IPPImage` передаётся в [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) более одного раза, каждый новый кадр изображения получает собственный `ISlidesPicture` и собственную коллекцию преобразований. Применение градации серого к одному кадру не делает остальные кадры серыми, несмотря на то, что все они используют один и тот же внедрённый ресурс изображения.

Та же модель `ISlidesPicture.ImageTransform` используется и другими заполнениями изображений, например формой или фоном слайда. Приведённые ниже примеры сосредоточены на кадрах изображений.

## **Использование допустимых диапазонов параметров и единиц**

Продемонстрированные методы используют следующие смысловые диапазоны и единицы. Сохраняйте значения в этих диапазонах, даже если конкретная версия библиотеки не отклоняет каждый выходящий за пределы параметр сразу; целевой формат презентации может нормализовать, опустить или отклонить недопустимые данные при сохранении или при открытии файла в PowerPoint.

| Операция | Параметры | Допустимый диапазон и единица |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` до `100`, процентов; `0` оставляет компонент без изменений. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | None | Нет числовых параметров. Альфа остаётся без изменений. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Два цвета для тёмных и светлых пикселей. Каналы RGB и альфа в `System.Drawing.Color` используют значения от `0` до `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Оттенок (`hue`) — от `0` включительно до `360` исключая, в градусах; количество (`amount`) — от `-100` до `100` процентов. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Оттенок (`hue`) — от `0` включительно до `360` исключая, в градусах; насыщенность (`saturation`) и яркость (`luminance`) — от `-100` до `100` процентов. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | Цвет замены использует значения каналов от `0` до `255`. Существующие значения альфа остаются без изменений. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Радиус (`radius`) неотрицательный и измеряется в пунктах; `grow` — булево значение, контролирующее, может ли размазанное содержимое выходить за пределы оригинального кадра. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Неотрицательный процент. Используйте значения от `0` до `100` для обычного масштабирования непрозрачности: `0` — полностью прозрачно, `100` сохраняет существующее значение альфа. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` по `100`, процентов непрозрачности. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` до `100`, процентов порога альфа. Значения ниже порога становятся прозрачными; значения, равные или выше порога, — непрозрачными. |

Для фиксированной модуляции альфа прозрачность и непрозрачность являются взаимодополняющими. Например, 35 % прозрачности соответствует значению модуляции альфа 65 %.

## **Применение яркости и контраста**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) возвращает операцию [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/). Её скалярные настройки задаются при создании операции. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) возвращает вычисленные только для чтения значения, которые можно просмотреть или записать в журнал.

Следующий пример увеличивает яркость на 15 % и контраст на 20 %, затем рендерит предварительный просмотр без изменения внедрённого изображения:

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

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) является расширением эффекта изображения Office 2010 и менее переносим, чем стандартный эффект яркости DrawingML. Когда яркость и контраст должны оставаться редактируемыми после обратного прохода PPTX, используйте [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) и проверьте результат после повторного открытия файла. Раздел ограничений формата объясняет это различие подробнее.

## **Применение цветовых преобразований**

Цветовые эффекты могут применяться независимо к разным кадрам изображений, которые используют один ресурс изображения. Следующий пример создаёт пять кадров и применяет градацию серого, дуотон, оттенок, настройку HSL и замену цвета.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) содержит два независимо редактируемых цветовых параметра: `Color1` назначает тёмные пиксели, а `Color2` — светлые пиксели. Это делает его полезным примером эффекта, настройки которого более сложны, чем один скалярный параметр.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) заменяет цвет каждого пикселя на один фиксированный цвет, сохраняя альфа-канал. Это отличается от [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), который сопоставляет один исходный цвет другому и раскрывает форматы как исходного, так и целевого цвета.

### **Применение порога яркости**

Порог яркости может облегчить различие слабых отметок на отсканированной странице от фона. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) сохраняет промежуточные оттенки серого. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) сопоставляет яркость черному или белому, тогда как [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) применяет порог к непрозрачности.

Порог яркости варьируется от 0 % до 100 %, включительно. Пиксели ниже порога становятся чёрными. Пиксели, равные или выше порога, становятся белыми. Увеличение порога делает больше оттенков чёрными, поскольку больше их попадает ниже установленного предела.

Скачайте [grayscale-swatches.png](grayscale-swatches.png) в рабочий каталог. Каждая метка указывает исходный уровень серого по шкале от 0 до 255. В примере оригинал размещён рядом с двумя копиями, и порог каждой копии сохраняется в презентации.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Откройте полученную презентацию в PowerPoint, чтобы сравнить три кадра. Образец с меткой 96 имеет около 38 % яркости (96 из 255). Он становится белым при пороге 20 % и чёрным при пороге 60 %.

![Исходные образцы градаций серого рядом с чёрно‑белыми результатами при порогах яркости 20 % и 60 %](luminance-threshold.png)

## **Добавление размытия, прозрачности и альфа‑эффектов**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) воздействует на все цветовые каналы, включая альфа. Установите `grow` в `true`, когда размытие может выходить за пределы оригинального кадра изображения.

Для одинаковой прозрачности используйте [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Он умножает каждое существующее значение альфа, поэтому частично прозрачные пиксели сохраняют пропорциональные различия. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) вместо этого назначает одно значение альфа всем пикселям. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) преобразует альфа в два уровня на основе порога.

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

Другие альфа‑операции без параметров включают [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), который делает каждый ненулевой альфа полностью непрозрачным; [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), который делает каждый альфа ниже 100 % полностью прозрачным; и [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), который меняет альфа на `100% - alpha`.

## **Создание упорядоченной цепочки эффектов**

Каждый метод `Add...Effect` добавляет новую операцию в конец коллекции. Рендерер использует коллекцию как упорядоченный конвейер: вывод операции 0 становится вводом операции 1 и так далее. Следовательно, одинаковые операции в другом порядке могут дать другое изображение.

Например, градация серого, а затем оттенок сначала удаляют хроматическую информацию, а затем перекрашивают результат яркости. Оттенок, а затем градация серого убирает оттенок снова. Аналогично, замена альфа может переопределить значения альфа, вычисленные более ранними операциями, тогда как модуляция альфа сохраняет их относительные различия.

Следующий пример создаёт цепочку из четырёх операций, сохраняет её как PPTX, повторно открывает презентацию, проверяет типы операций и их порядок, и рендерит результат после повторного открытия:

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

Коллекция не накладывает матрицу совместимости, ограничивая цветовые, альфа‑ и размытие операции отдельными цепочками. Их можно комбинировать, но комбинации не всегда полезны. Фиксированная замена цвета удаляет вариацию RGB, созданную более ранними цветовыми эффектами; градация серого после дуотона удаляет два выбранных цвета; а операции альфа‑потолок, пол, замена или двухуровневой альфа могут удалить альфа‑детали, созданные ранее. Формируйте цепочку согласно желаемой последовательности обработки пикселей, а не рассматривайте её элементы как неупорядоченные флаги форматирования.

<!-- visual-explanation:image-transform-effects:start -->
[![То же изображение проходит через градацию серого, затем оттенок, и через оттенок, затем градацию серого. Два конечных изображения в градациях серого имеют разные тона.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*В этом иллюстративном рендере Aspose.Slides for .NET 26.11, оттенок 220° при 25 % оставляет изображение в градациях серого неизменным. Применение того же оттенка перед градацией серого дает разные тона.* 
<!-- visual-explanation:image-transform-effects:end -->

## **Проверка редактируемых и эффективных значений**

Редактируемая операция — это объект, хранящийся в `ISlidesPicture.ImageTransform`. В зависимости от эффекта он может напрямую раскрывать записываемые свойства. Например, [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) раскрывает записываемые `Radius` и `Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) раскрывает записываемое `Amount`, а [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) раскрывает записываемый `Threshold`. Цветовые эффекты, такие как [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/), раскрывают изменяемые объекты [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/).

Некоторые интерфейсы операций, включая [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/), и [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/), не раскрывают свои скалярные параметры создания как записываемые свойства. Чтобы изменить эти настройки, удалите операцию и добавьте замену в нужной позиции.

Эффективные данные, возвращаемые `GetEffective()`, вычисляются и доступны только для чтения. Они полезны для разрешения зависимых от темы цветов и чтения нормализованных значений, которые использует рендерер, но это не отдельная поверхность редактирования. Следующий пример перечисляет цепочку и проверяет эффективные значения там, где соответствующий API их предоставляет:

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

Эффекты без параметров, такие как градация серого, альфа‑потолок и альфа‑инверсия, всё равно имеют объект эффективных данных, но нет скалярных параметров для вывода. Их наличие и позиция в коллекции являются важной информацией.

## **Удаление или очистка преобразований изображения**

Используйте [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) для удаления одной операции по индексу. Поскольку индексы смещаются после удаления, сначала найдите нужный элемент, а затем удалите его после перечисления. Используйте `Clear()` чтобы удалить всю цепочку.

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

Удаление или очистка преобразований изменяют только форматирование изображения. Они не удаляют, не перекомпрессируют и не изменяют используемый повторно ресурс [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).

## **Учет форматов презентаций и целевых экспортов**

Преобразования изображений происходят в DrawingML, поэтому PPTX является предпочтительным редактируемым форматом для цепочек эффектов. Даже с PPTX не каждая операция обладает одинаковой переносимостью:

- Стандартные операции DrawingML, такие как яркость, градация серого, дуотон, оттенок, HSL, размытие и общие альфа‑операции, имеют наилучший шанс сохраниться после обратного прохода PPTX. Всегда повторно открывайте сгенерированный файл и проверяйте коллекцию, когда требуется сохранение.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) является расширением Office 2010, а не стандартной операцией яркости DrawingML. Его можно использовать для рендеринга в памяти, но нет гарантии, что он останется редактируемым [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) после сохранения и повторного открытия PPTX. Предпочтительно использовать [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) для постоянных настроек яркости и контраста.
- Бинарный формат PPT предшествует полной модели эффектов DrawingML. Сохранение в PPT может опускать неподдерживаемые операции, сокращать цепочку до поддерживаемого подмножества или приближать внешний вид. Не используйте PPT в качестве формата проверки для сложной редактируемой цепочки.
- Рендеринг в PNG, JPEG, TIFF, PDF, SVG, HTML или другие визуальные форматы применяет поддерживаемую цепочку к визуальному представлению. Эти форматы не содержат редактируемой `IImageTransformOperationCollection`; растровые форматы уплощают результат в пиксели, а экспорт документов/векторов хранит собственное представление рендеринга.
- Эффекты не делают связанную картинку автономной. Рендеринг связанного изображения по‑прежнему зависит от доступности связанного ресурса при загрузке презентации.

Различные программы просмотра презентаций могут по‑разному рендерить граничные случаи, особенно когда комбинируются несколько альфа‑ или цветоквантующих операций. Для критически важного вывода протестируйте как редактируемый обратный проход, так и конечный экспортный формат с той же версией Aspose.Slides, используемой в продакшене.

## **Часто задаваемые вопросы**

**Изменяют ли эффекты преобразования изображения внедрённые данные изображения?**

Нет. Операции принадлежат `ISlidesPicture`, используемому для заполнения изображения. Байты базового `IPPImage` остаются неизменными.

**Будут ли два кадра изображения, переиспользующие одно и то же изображение, делиться своими эффектами?**

Нет. Повторное использование `IPPImage` предотвращает дублирование данных изображения, но каждый кадр изображения обычно имеет отдельный `ISlidesPicture` и свою коллекцию преобразований изображения.

**Можно ли комбинировать цветовые, размытие и альфа‑эффекты?**

Да. Коллекция принимает их в одной упорядоченной цепочке. Учитывайте, что каждая операция делает с выводом предыдущей, так как операции замены и порога могут отбрасывать более ранние цветовые или альфа‑детали.

**Почему эффективные значения только для чтения?**

Эффективные данные представляют вычисленные значения, используемые для рендеринга, включая разрешённые цвета. Редактируйте операцию, хранящуюся в коллекции преобразований, где существуют записываемые свойства; иначе удалите её и добавьте замену с новыми параметрами создания.

**Какой формат следует использовать, чтобы сохранить цепочку преобразований?**

Используйте PPTX и проверьте файл, повторно открыв его. Устаревший PPT не может представить полную модель эффектов DrawingML, а экспортные форматы сохраняют лишь внешний вид, а не редактируемые операции преобразования.