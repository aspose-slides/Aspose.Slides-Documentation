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
- добавить изображение
- создать изображение
- извлечь изображение
- растровое изображение
- векторное изображение
- обрезать изображение
- обрезанная область
- свойство StretchOff
- форматирование рамки изображения
- свойства рамки изображения
- относительный масштаб
- эффект изображения
- соотношение сторон
- прозрачность изображения
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Добавляйте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Оптимизируйте рабочий процесс и улучшайте дизайн слайдов."
---
## **Введение**

Рамка изображения — это форма, содержащая изображение; она похожа на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку.

{{% alert  title="Tip" color="info" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использоваться для заполнения формы. 
4. Укажите ширину и высоту изображения. 
5. Создайте [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, доступного у объекта формы, связанного с указанным слайдом. 
6. Добавьте рамку изображения (содержащую картинку) на слайд. 
7. Сохраните изменённую презентацию в файл PPTX. 

Этот C#‑код показывает, как создать рамку изображения:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide slide = pres.Slides[0];

    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения с одинаковой высотой и шириной
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Применяет некоторое форматирование к рамке изображения
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Сохраняет презентацию в файл PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. При сочетании рамки изображения с параметрами сохранения Aspose.Slides можно управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вас заинтересуют следующие страницы: конвертировать [image to JPG](https://products.aspose.com/slides/ru/net/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/ru/net/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/ru/net/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/ru/net/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/ru/net/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/ru/net/conversion/svg-to-png/). 

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, можно создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации. 
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использоваться для заполнения формы. 
5. Укажите относительную ширину и высоту изображения в рамке изображения. 
6. Сохраните изменённую презентацию в файл PPTX. 

Этот C#‑код показывает, как создать рамку изображения с относительным масштабом:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения на слайд
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Устанавливает относительные масштаб ширины и высоты
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Сохраняет презентацию
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Извлечение растровых изображений из рамок изображения**

Можно извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe) и сохранить их в PNG, JPG и других форматах. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.

```c#
using Aspose.Slides;

using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var ppImage = pictureFrame.PictureFormat.Picture.Image;
        ppImage.Image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Извлечение SVG‑изображений из рамок изображения**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/), Aspose.Slides for .NET позволяет получить оригинальные векторные изображения с полной точностью. Проходя по коллекции фигур слайда, можно определить каждую [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/), проверить, содержит ли соответствующий [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) SVG‑содержимое, и затем сохранить это изображение на диск или в поток в его родном SVG‑формате.

Ниже приведён пример кода, демонстрирующего извлечение SVG‑изображения из рамки изображения:

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот C#‑код демонстрирует операцию:

```c#
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Получение яркости и контрастности изображения**

Aspose.Slides позволяет получить эффекты яркости и контрастности, применённые к изображению. Интерфейс [ILuminance](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/iluminance/) представляет этот трансформирующий эффект изображения.

Этот C#‑код демонстрирует, как получить настройки яркости и контрастности из рамки изображения:

```csharp
using Aspose.Slides;
using Aspose.Slides.Effects;

using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="info" %}} 
Все эффекты, применяемые к изображениям, можно найти в [Aspose.Slides.Effects](https://reference.aspose.com/slides/ru/net/aspose.slides.effects/). 
{{% /alert %}}

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. Используя эти параметры, вы можете изменить рамку изображения в соответствии с конкретными требованиями.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/ru/aspose.slides/) . 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/ru/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использоваться для заполнения формы. 
4. Укажите ширину и высоту изображения. 
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](http://www.aspose.com/api/net/slides/ru/aspose.slides/ishapecollection/methods/addpictureframe), доступный у объекта [IShapes](http://www.aspose.com/api/net/slides/ru/aspose.slides/ishapecollection), связанного с указанным слайдом. 
6. Добавьте рамку изображения (содержащую картинку) на слайд. 
7. Установите цвет линии рамки изображения. 
8. Установите толщину линии рамки изображения. 
9. Поверните рамку изображения, задав положительное или отрицательное значение. 
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки. 
10. Добавьте рамку изображения (содержащую картинку) на слайд. 
11. Сохраните изменённую презентацию в файл PPTX. 

Этот C#‑код демонстрирует процесс форматирования рамки изображения:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения с высотой и шириной, соответствующей изображению
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Применяет некоторое форматирование к рамке изображения
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Сохраняет презентацию в файл PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}

Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/ru/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/ru/collage/jpg) или PNG‑изображения, [создать сетки из фотографий](https://products.aspose.app/slides/ru/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения в виде ссылки**

Чтобы избежать больших размеров презентаций, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентацию. Этот C#‑код показывает, как добавить изображение и видео в заполнитель:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Обрезка изображений**

Этот C#‑код показывает, как обрезать существующее изображение на слайде:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    // Создаёт новый объект изображения
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения на слайд
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Обрезает изображение (значения в процентах)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Сохраняет результат
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Удаление обрезанных областей изображения в рамке**

Если необходимо удалить обрезанные области изображения, находящегося в рамке, можно использовать метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Метод возвращает обрезанное изображение или исходное изображение, если обрезка не требуется.

Этот C#‑код демонстрирует операцию:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получает рамку изображения с первого слайда
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Удаляет обрезанные области изображения рамки изображения и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Сохраняет результат
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Метод конвертирует метафайлы WMF/EMF в растровое PNG‑изображение в процессе обрезки. 

{{% /alert %}}

## **Сжатие изображений**

Вы можете сжать изображение в презентации, используя метод [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat/compressimage/). Метод сжимает изображение, уменьшая его размер в зависимости от размеров формы и заданного разрешения, с возможностью удаления обрезанных областей. 

Он регулирует размер и разрешение изображения аналогично функции PowerPoint **Picture Format → Compress Pictures → Resolution**.

Ниже приведены примеры на C#, показывающие, как сжать изображение в презентации, указав целевое разрешение и при желании удалив обрезанные области:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение с целевым разрешением 150 DPI (веб-разрешение) и удалить обрезанные области.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Проверьте результат сжатия.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Или используя пользовательское значение DPI напрямую:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение до 150 DPI (веб разрешение), удаляя обрезанные области.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

Метод преобразует изображение к более низкому разрешению на основе размеров формы и указанного DPI. Обрезанные регионы также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не применяется. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично поведению PowerPoint при работе с JPEG‑изображениями высокого разрешения. 

{{% /alert %}}

## **Блокировка соотношения сторон**

Если необходимо, чтобы форма, содержащая изображение, сохраняла соотношение сторон даже после изменения размеров изображения, можно использовать свойство [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframelock/aspectratiolocked/) для установки параметра *Lock Aspect Ratio*. 

Этот C#‑код показывает, как заблокировать соотношение сторон формы:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Устанавливает сохранение соотношения сторон формы при изменении размеров
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Настройка *Lock Aspect Ratio* сохраняет только соотношение сторон формы, а не изображения, которое она содержит. 

{{% /alert %}}

## **Использование свойства StretchOff**

С помощью свойств [StretchOffsetLeft](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/properties/stretchoffsetright) и [StretchOffsetBottom](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ipicturefillformat) и класса [PictureFillFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/picturefillformat) можно задать прямоугольник заполнения. 

При указании растягивания для изображения исходный прямоугольник масштабируется так, чтобы вписаться в заданный прямоугольник заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего блока формы. Положительный процент задаёт отступ, отрицательный — выступ. 

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/ru/aspose.slides/) . 
2. Получите ссылку на слайд по его индексу. 
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение. 
5. Установите тип заполнения формы. 
6. Установите режим заполнения формы изображением. 
7. Добавьте изображение для заполнения формы. 
8. Укажите смещения изображения от соответствующей грани ограничивающего блока формы. 
9. Сохраните изменённую презентацию в файл PPTX. 

Этот C#‑код демонстрирует процесс использования свойства StretchOff:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Устанавливает растягивание изображения со всех сторон в теле формы
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Как узнать, какие форматы изображений поддерживаются для PictureFrame?

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями движка конвертации слайдов и изображений.

### Как добавить десятки больших изображений скажется на размере и производительности PPTX?

Встраивание больших изображений увеличивает размер файла и расход памяти; привязка изображений через ссылки помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для снижения размера файла.

### Как заблокировать объект изображения от случайного перемещения/изменения размера?

Используйте [блокировки формы](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/pictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки описан для форм в отдельной [статье о защите](/slides/ru/net/applying-protection-to-presentation/) и поддерживается для различных типов форм, включая [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/).

### Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/net/convert-powerpoint-to-png/) результат может быть растровым в зависимости от параметров экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.