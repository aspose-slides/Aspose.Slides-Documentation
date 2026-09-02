---
title: Управление рамками изображений в презентациях на .NET
linktitle: Рамка изображения
type: docs
weight: 10
url: /ru/net/picture-frame/
keywords:
- рамка изображения
- добавить рамку изображения
- создать рамку изображения
- встроенное изображение
- связанное изображение
- извлечь изображение
- растровое изображение
- SVG-изображение
- обрезать изображение
- удалить обрезанные области
- сжать изображение
- StretchOffset
- форматирование рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте, форматируйте, связывайте, обрезайте, извлекайте и сжимайте рамки изображений в презентациях с помощью Aspose.Slides для .NET."
---
## **Обзор**

Рамка изображения — это фигура слайда, отображающая изображение. В Aspose.Slides ресурс изображения и фигура, отображающая его, являются отдельными объектами: [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою коллекцию [Images](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/images/), в то время как [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) управляет позицией изображения, размером, форматированием линии, вращением, обрезкой, эффектами изображения и другими настройками уровня рамки.

Это разделение полезно, когда одно и то же изображение отображается более одного раза. Добавьте изображение в презентацию один раз, сохраните возвращённый [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок.

Рамки могут содержать растровые изображения, такие как PNG или JPEG, и векторные SVG‑изображения. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и экспорт, поэтому полезно решить, как изображение будет храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку изображения с помощью [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/). Изображение становится частью пакета презентации, поэтому презентация остаётся автономной при перемещении на другой компьютер.

Следующий пример добавляет JPEG‑изображение, создаёт рамку с исходными размерами изображения и применяет форматирование линии и вращение:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Рамка изображения контролирует отображаемую геометрию; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты для рамки. Значение `1.0` соответствует 100 % исходного размера картинки. Относительный масштаб полезен, когда рабочий процесс должен сохранять отношение к размеру исходного изображения вместо ручного вычисления конечных размеров.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

Относительный масштаб меняет настройки масштаба рамки; он не переобразует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная рамка хранит данные изображения внутри презентации и поэтому является самым безопасным выбором для переносимости и предсказуемого рендеринга. Связанная рамка хранит внешний путь через свойство ссылки [ISlidesPicture](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным приложению, которое открывает или рендерит презентацию. Если путь изменится, файл будет перемещён или ресурс станет недоступен, связанная рамка может не отобразиться ожидаемым образом. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

Следующий пример создаёт рамку изображения и указывает её на локальный файл изображения. Он рассматривает только привязку изображений; привязка видео — отдельный медиа‑рабочий процесс и намеренно не смешана в этом примере.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Используйте ссылки, когда внешнее управление файлами является намеренным. Не используйте их просто как замену сжатию: небольшая PPTX с нарушенными зависимостями изображений обычно менее полезна, чем более крупная автономная презентация.

## **Извлечение изображений из рамок**

Прежде чем извлекать изображение из существующей презентации, проверьте, что фигура действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) и что она содержит встроенное изображение. Связанные рамки могут не содержать байтов изображения, которые можно извлечь тем же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) напрямую и не требует старого системного обёртывания. Следующий пример находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Сохранение через [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) преобразует извлечённое изображение в требуемый выходной формат. Если вам нужны закодированные байты, хранящиеся в презентации, а не преобразованный растровый файл, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) раскрывает объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/). Это позволяет получать данные SVG напрямую, без предварительного растеризования изображения.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Сохранение SVG‑содержимого как SVG сохраняет векторный исходник внутри презентации. Растровый экспорт, такой как PNG или JPEG, неизбежно преобразует векторное содержимое в пиксели. Экспорт слайда в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтовая копия оригинального встроенного SVG; используйте данные встроенного [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/), когда требуется сам векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет часть изображения, видимую внутри рамки. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Следующий пример безопасно находит рамку изображения и применяет значения обрезки:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Поскольку скрытые данные изображения всё ещё присутствуют, обрезку можно изменить позже без потери оригинальных пикселей. Если размер файла важнее обратимости, обрезанные области можно физически удалить, как описано в следующем разделе.

## **Удаление обрезанных данных изображения**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели больше недоступны для последующего отката обрезки.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём текущем ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка WMF или EMF содержимого этим методом растеризует результат в PNG.

## **Сжатие растровых изображений**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/compressimage/) уменьшает разрешение растрового изображения относительно размера, в котором картинка отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено по размеру или обрезано, и `false`, когда изменения не требовались.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/net/aspose.slides.export/picturescompression/), когда достаточен стандартный целевой уровень разрешения:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Вместо значения перечисления можно передать пользовательское положительное значение DPI, когда нужен конкретный целевой параметр.

Сжатие предназначено для растровых изображений. SVG‑и метафайлы не уменьшаются этим растровым процессом сжатия. Также помните, что более низкое разрешение и удалённые обрезанные области нельзя восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из наибольшего размера, при котором изображение действительно будет просматриваться или экспортироваться, а не применяйте минимальный DPI глобально.

## **Проверка эффектов изображения**

Эффекты картинки хранятся в изображении, используемом рамкой. Коллекция трансформаций изображения может содержать такие эффекты, как фиксированная альфа‑модуляция для прозрачности и яркость/контраст для изменения светлоты. Пример ниже безопасно читает оба типа эффектов из первой рамки изображения на слайде:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Эти эффекты изменяют способ рендеринга изображения в рамке; они не переписывают оригинальные байты встроенного изображения.

## **Блокировка геометрии рамки изображения**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframelock/) контролируют, какие операции редактирования отключены для рамки изображения. Например, блокировка соотношения сторон сохраняет пропорции фигуры при её изменении размеров.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Блокировка применяется к фигуре рамки изображения. Она не принуждает исходное изображение к переобразованию или постоянному изменению соотношения сторон.

## **Регулировка значений StretchOffset**

Когда режим заполнения картинки установлен в «растянуть», значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) определяют прямоугольник заполнения относительно ограничивающего бокса рамки. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Значения обрезки выбирают, какая часть исходного изображения видима; stretch‑offset изменяют прямоугольник, в который растягивается видимая часть заполнения.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Используйте stretch‑offset для размещения заполнения. Используйте свойства обрезки, когда цель — скрыть края исходного изображения.

## **Соображения по хранению, размеру файла и экспорту**

Основные компромиссы легче управлять, когда хранение изображений и форматирование рамок рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются наиболее надёжными для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** позволяют уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или расположениям.
- **Обрезка** изначально некрушительная. Скрытые пиксели остаются встроенными, пока обрезанные области явно не удаляются или не удаляются во время сжатия.
- **Сжатие** может существенно уменьшить размер файла для слишком больших растровых изображений, но уменьшает исходное разрешение. Его следует применять после того, как известен конечный размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Экспорт слайдов в растровый формат всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать, используя уже существующий ресурс [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/), вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизацию изображений обычно эффективнее проводить выборочно: храните логотипы и схемы как векторный контент, сжимайте фотографии в соответствии с их реальным размером отображения, удаляйте обрезанные пиксели только когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью стратегии развертывания.

## **ЧаВо**

**В чём разница между рамкой изображения и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) — это фигура на слайде, отображающая изображение и хранящая параметры геометрии и форматирования рамки, такие как размер, вращение, значения обрезки, эффекты и блокировки.

**Надо ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно храните файлы изображений вне PPTX и внешние расположения могут быть поддержаны надёжно.

**Уменьшает ли обрезка размер файла PPTX?**

Не сама по себе. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют пиксели. Используйте [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить навсегда.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей отбрасывает данные изображения. Сохраните оригинальный исходный файл вне презентации, если позже может потребоваться работа с высоким разрешением.

**Как следует обращаться с SVG‑изображениями?**

Сохраняйте SVG‑содержимое как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/) можно извлекать напрямую. Рендеринг слайда в растровый формат, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных приведения типов при чтении существующих слайдов?**

Проверяйте тип фигуры перед использованием членов, специфичных для рамки изображения. Сопоставление с [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) или фильтрация коллекции фигур по этому интерфейсу предотвращает недопустимые приведения и позволяет коду корректно обрабатывать слайды без рамок изображения.