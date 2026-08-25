---
title: Управление рамками изображения в презентациях на .NET
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

Рамка картинки – это объект формы типа слайд, который отображает изображение. В Aspose.Slides ресурс изображения и форма, её отображающая, являются отдельными объектами: объект [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/) владеет встроенными ресурсами изображений через свою коллекцию [Images](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/images/), а объект [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) управляет положением изображения, его размером, форматированием линии, поворотом, обрезкой, эффектами изображения и другими параметрами уровня рамки.

Это разделение полезно, когда одно и то же изображение показывается более одного раза. Добавьте изображение в презентацию один раз, удерживая возвращённый объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/), и используйте этот ресурс изображения при создании рамок картинок.

Рамки картинок могут содержать растровые изображения, такие как PNG или JPEG, а также векторные изображения SVG. Они также могут ссылаться на связанные изображения вместо хранения байтов изображения в презентации. Выбор влияет на переносимость, размер файла, извлечение и поведение экспорта, поэтому полезно решить, как изображение должно храниться, до применения форматирования или оптимизации.

## **Добавление и форматирование встроенного изображения**

Для встроенного изображения добавьте данные изображения в презентацию и создайте рамку картинки с помощью [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection/addpictureframe/). Изображение станет частью пакета презентации, поэтому она останется автономной при переносе на другой компьютер.

Ниже приведён пример, который добавляет JPEG‑изображение, создаёт рамку с оригинальными размерами изображения и применяет форматирование линии и поворот:

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

Рамка картинки контролирует отображаемую геометрию; изменение размера рамки не меняет оригинальные пиксельные размеры, хранящиеся во встроенном ресурсе изображения. Это различие становится важным при последующей обрезке или сжатии изображения.

## **Использование относительного масштаба**

[IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) предоставляет относительное масштабирование ширины и высоты рамки. Значение `1.0` соответствует 100 % оригинального размера картинки. Относительный масштаб полезен, когда нужно сохранять отношение к размеру исходного изображения вместо ручного расчёта конечных размеров.

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

Относительный масштаб изменяет настройки масштаба рамки; он не пересэмплирует и не сжимает встроенное изображение.

## **Встроенные и связанные изображения**

Встроенная картинка хранит данные изображения внутри презентации и поэтому является самым надёжным вариантом с точки зрения переносимости и предсказуемого рендеринга. Связанная картинка хранит внешний путь через ссылку [ISlidesPicture](https://reference.aspose.com/slides/ru/net/aspose.slides/islidespicture/) вместо встраивания данных изображения тем же способом.

Связанные изображения могут уменьшить объём данных изображения, хранящихся в PPTX, но они вводят внешнюю зависимость. Связанный файл должен оставаться доступным для приложения, открывающего или рендерящего презентацию. Если путь изменится, файл будет перемещён или ресурс недоступен, связанная картинка может не отображаться как ожидается. Для презентаций, которые необходимо отправлять по электронной почте, архивировать или рендерить в изолированных средах, встроенные изображения обычно более надёжны.

### **Добавление связанного изображения**

В следующем примере создаётся рамка картинки и указывается путь к локальному файлу изображения. Пример охватывает только связывание изображений; связывание видео – отдельный медиа‑рабочий процесс и намеренно не включено в данный пример.

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

Используйте ссылки, когда намеренно управляем внешними файлами. Не используйте их лишь как замену сжатию: небольшой PPTX с повреждёнными зависимостями изображений обычно менее полезен, чем крупная автономная презентация.

## **Извлечение изображений из рамок картинок**

Прежде чем извлекать изображение из существующей презентации, проверьте, что форма действительно является [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) и что она содержит встроенное изображение. Связанные рамки картинок могут не содержать байтов изображения, которые можно было бы извлечь таким же способом.

### **Извлечение растрового изображения**

Современный API изображений использует [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) напрямую и не требует старого системного обёртывания. Ниже пример, который находит первое встроенное растровое изображение на слайде и сохраняет его как PNG:

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

Сохранение через [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) преобразует извлечённое изображение в запрашиваемый формат вывода. Если вам нужны закодированные байты, хранящиеся в презентации, а не конвертированный растр, используйте бинарные данные ресурса изображения.

### **Извлечение SVG‑изображения**

Для SVG‑картинки объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) раскрывает объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/). Это позволяет получить данные SVG напрямую без предварительной растеризации картинки.

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

Сохранение SVG‑содержимого как SVG сохраняет векторный источник внутри презентации. Растровый экспорт, такой как PNG или JPEG, обязательно преобразует вектор в пиксели. Экспорт слайдов в PDF или SVG также является операцией рендеринга, поэтому экспортированная графика не должна рассматриваться как побайтная копия оригинального встроенного SVG; используйте встроенные данные [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/), когда требуется оригинальный векторный ресурс.

## **Обрезка изображения**

Обрезка изменяет ту часть изображения, которую видно внутри рамки. Значения обрезки в [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) задаются в процентах от размеров исходного изображения. Обрезка изначально не удаляет скрытые пиксели из встроенного изображения; она лишь меняет видимую область.

Ниже пример, который надёжно находит рамку картинки и применяет значения обрезки:

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

## **Удаление данных обрезанных изображений**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) удаляет данные изображения за пределами текущего прямоугольника обрезки и возвращает полученный ресурс изображения. Это может уменьшить размер файла, но является разрушительной оптимизацией: после сохранения презентации удалённые пиксели более недоступны для последующей операции «отобрезки».

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

Метод может добавить новый ресурс изображения в презентацию. Если оригинальное изображение также используется другими рамками, эти рамки всё равно нуждаются в своём ресурсе, поэтому удаление обрезанных областей не обязательно уменьшает общее количество изображений. Обрезка содержимого WMF или EMF этим методом растрирует результат в PNG.

## **Сжатие растровых изображений**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/compressimage/) уменьшает разрешение растрового изображения относительно размера, в котором картинка отображается. Он также может удалить обрезанные области в той же операции. Метод возвращает `true`, когда изображение было изменено размером или обрезано, и `false`, когда изменений не потребовалось.

Используйте предопределённое значение [PicturesCompression](https://reference.aspose.com/slides/ru/net/aspose.slides.export/picturescompression/), когда достаточно стандартного целевого разрешения:

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

Вместо перечисления можно передать пользовательское положительное значение DPI, если требуется конкретная цель.

Сжатие предназначено для растровых изображений. SVG‑ и метафайлы не уменьшаются этим радиальным процессом. Также помните, что более низкое разрешение и удалённые обрезанные области невозможно восстановить из оптимизированной презентации. Выбирайте целевое разрешение, исходя из максимального размера, с которым изображение будет фактически просмотрено или экспортировано, а не устанавливайте самое низкое DPI глобально.

## **Управление эффектами трансформации изображения**

Для полного рабочего процесса, охватывающего яркость, контраст, цветовые трансформации, размытие, альфа‑эффекты, упорядоченные цепочки, инспекцию, удаление и проверку обратного пути, см. раздел [Image Transform Effects](/slides/ru/net/image-transform-effects/).

## **Блокировка геометрии рамки картинки**

Настройки [IPictureFrameLock](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframelock/) определяют, какие операции редактирования отключены для рамки картинки. Например, блокировка соотношения сторон сохраняет пропорции формы при её изменении размеров.

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

Блокировка применяется к форме рамки картинки. Она не принуждает исходное изображение к пересэмпливанию или постоянному изменению соотношения сторон.

## **Настройка значений StretchOffset**

Когда режим заливки картинки установлен в «stretch», значения stretch‑offset в [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/) определяют прямоугольник заливки относительно ограничивающего блока рамки картинки. Положительные проценты создают отступ от края, отрицательные — выступ.

Это отличается от обрезки. Параметры обрезки выбирают, какая часть исходного изображения видна; stretch‑offset меняет прямоугольник, в который растягивается видимая заливка.

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

Используйте stretch‑offset для размещения заливки. Применяйте свойства обрезки, когда нужно скрыть части исходного изображения.

## **Хранение, размер файла и соображения при экспорте**

Главные компромиссы легче управляются, когда хранение изображений и форматирование рамки картинки рассматриваются отдельно:

- **Встроенные изображения** делают презентацию автономной и являются самым надёжным вариантом для совместного использования и серверного рендеринга, но крупные растровые изображения увеличивают размер PPTX и потребление памяти.
- **Связанные изображения** могут уменьшить размер пакета, однако презентация зависит от доступности внешних файлов по сохранённым путям или локациям.
- **Обрезка** изначально не разрушительна. Скрытые пиксели остаются встроенными до тех пор, пока обрезанные области явно не удалятся или не будут удалены при сжатии.
- **Сжатие** может значительно уменьшить размер файла для слишком больших растровых изображений, но ухудшает исходное разрешение. Его следует применять после того, как известен конечный размер изображения на слайде.
- **SVG‑изображения** следует оставлять в виде SVG, когда важна векторная точность. Извлекайте встроенный SVG напрямую, когда нужен сам векторный ресурс. Растровый экспорт слайдов всегда преобразует отрисованный слайд в пиксели.
- **Повторяющиеся изображения** следует переиспользовать существующий ресурс [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/), когда это возможно, вместо многократной загрузки одного и того же файла в рабочий процесс презентации.

Для больших презентаций оптимизация изображений обычно наиболее эффективна при избирательном применении: оставляйте логотипы и схемы в векторном виде, сжимайте фотографии согласно их реальному размеру отображения, удаляйте обрезанные пиксели только тогда, когда дальнейшее редактирование не требуется, и избегайте внешних ссылок, если только управление зависимостями не является частью дизайна развертывания.

## **FAQ**

**В чём разница между рамкой картинки и ресурсом изображения?**

[IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) представляет ресурс изображения, связанный с презентацией. [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) — это форма на слайде, отображающая изображение и хранящая параметры геометрии и форматирования уровня рамки, такие как размер, поворот, значения обрезки, эффекты и блокировки.

**Стоит ли встраивать или связывать изображения?**

Встраивайте изображения, когда презентация должна быть переносимой, архивируемой или рендериться без доступа к внешним ресурсам. Связывайте изображения только тогда, когда намеренно храните файлы изображений вне PPTX и внешние места могут быть надёжно поддержаны.

**Уменьшает ли обрезка размер файла PPTX?**

Само по себе нет. Обычные настройки обрезки скрывают части исходного изображения, но сохраняют пиксели. Используйте [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) или сжатие изображения с удалением обрезанных областей, когда эти пиксели можно удалить окончательно.

**Можно ли восстановить качество изображения после сжатия?**

Нет. Сжатие может уменьшить сохранённое растровое разрешение, а удаление обрезанных областей уничтожает данные изображения. Сохраняйте оригинальное исходное изображение вне презентации, если позже может потребоваться редактирование в высоком разрешении.

**Как следует работать с SVG‑изображениями?**

Сохраняйте SVG‑контент как SVG, когда важна векторная точность. Встроенный [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/) можно извлечь напрямую. Рендеринг слайда в растр, такой как PNG или JPEG, растеризует SVG как часть изображения слайда.

**Как избежать небезопасных привидений при чтении существующих слайдов?**

Проверяйте тип формы перед использованием членов, специфичных для рамки картинки. Сопоставление по типу с помощью [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) или фильтрация коллекции форм по этому интерфейсу избегает недопустимых привидений и позволяет коду корректно обрабатывать слайды без рамок картинки.