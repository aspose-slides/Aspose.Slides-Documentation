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
description: Добавьте рамки изображений в презентации PowerPoint и OpenDocument с помощью Aspose.Slides для .NET. Оптимизируйте ваш рабочий процесс и улучшите дизайн слайдов.
---

Рамка изображения — это форма, содержащая изображение; она похожа на картину в рамке.  

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.  

{{% alert title="Tip" color="primary" %}}  
Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений.  
{{% /alert %}}  

## **Создать рамку изображения**

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Получить ссылку на слайд по его индексу.  
3. Создать объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использовано для заполнения формы.  
4. Указать ширину и высоту изображения.  
5. Создать [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) на основе ширины и высоты изображения через метод `AddPictureFrame`, предоставляемый объектом формы, связанным с указанным слайдом.  
6. Добавить рамку изображения (содержащую картинку) на слайд.  
7. Сохранить изменённую презентацию в файл PPTX.  

Этот C#‑код показывает, как создать рамку изображения:  
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{
    // Получает первый слайд
    ISlide slide = pres.Slides[0];

    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения с той же высотой и шириной
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Применяет некоторую форматировку к рамке изображения
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Сохраняет презентацию в файл PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```
  

{{% alert color="warning" %}}  
Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. При сочетании рамки изображения с параметрами сохранения Aspose.Slides вы можете управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Смотрите также страницы: конвертировать [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).  
{{% /alert %}}  

## **Создать рамку изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, можно создать более сложную рамку изображения.  

1. Создать экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).  
2. Получить ссылку на слайд по его индексу.  
3. Добавить изображение в коллекцию изображений презентации.  
4. Создать объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использовано для заполнения формы.  
5. Указать относительную ширину и высоту изображения в рамке изображения.  
6. Сохранить изменённую презентацию в файл PPTX.  

Этот C#‑код показывает, как создать рамку изображения с относительным масштабом:  
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения на слайд
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Устанавливает относительный масштаб ширины и высоты
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Сохраняет презентацию
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```
  

## **Извлечь растровые изображения из рамок изображений**

Вы можете извлекать растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) и сохранять их в формате PNG, JPG и других. Пример кода ниже демонстрирует, как извлечь изображение из документа «sample.pptx» и сохранить его в формате PNG.  
```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```
  

## **Извлечь SVG‑изображения из рамок изображений**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), Aspose.Slides for .NET позволяет получить оригинальные векторные изображения с полной точностью. Проходя по коллекции фигур слайда, можно определить каждый [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), проверить, содержит ли связанный [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его родном SVG‑формате.  

Следующий пример кода демонстрирует, как извлечь SVG‑изображение из рамки изображения:  
```cs
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
  

## **Получить прозрачность изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот C#‑код демонстрирует операцию:  
```c#
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
  

{{% alert color="primary" %}}  
Все эффекты, применяемые к изображениям, можно найти в [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/).  
{{% /alert %}}  

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применить к рамке изображения. С их помощью можно изменить рамку изображения так, чтобы она соответствовала конкретным требованиям.  

1. Создать экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .  
2. Получить ссылку на слайд по его индексу.  
3. Создать объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в коллекцию [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, которое будет использовано для заполнения формы.  
4. Указать ширину и высоту изображения.  
5. Создать `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe), предоставляемый объектом [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection), связанным с указанным слайдом.  
6. Добавить рамку изображения (содержащую картинку) на слайд.  
7. Задать цвет линии рамки изображения.  
8. Задать ширину линии рамки изображения.  
9. Повернуть рамку изображения, указав положительное или отрицательное значение.  
   * Положительное значение вращает изображение по часовой стрелке.  
   * Отрицательное значение вращает изображение против часовой стрелки.  
10. Добавить рамку изображения (содержащую картинку) на слайд.  
11. Сохранить изменённую презентацию в файл PPTX.  

Этот C#‑код демонстрирует процесс форматирования рамки изображения:  
```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
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

    // Применяет некоторую форматировку к рамке изображения
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Сохраняет презентацию в файл PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```
  

{{% alert color="primary" %}}  
Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетку из фотографий](https://products.aspose.app/slides/collage/photo-grid), можете воспользоваться этим сервисом.  
{{% /alert %}}  

## **Добавить изображение как ссылку**

Чтобы избежать большого размера презентации, вы можете добавлять изображения (или видео) через ссылки вместо встраивания файлов напрямую в презентацию. Этот C#‑код показывает, как добавить изображение и видео в заполнитель:  
```c#
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
  

## **Обрезать изображения**

Этот C#‑код показывает, как обрезать существующее изображение на слайде:  
```c#
using (Presentation presentation = new Presentation())
{
    // Создает новый объект изображения
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет PictureFrame на слайд
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
  

## **Удалить обрезанные области рамки изображения**

Если нужно удалить обрезанные области изображения, находящегося в рамке, можно использовать метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Метод возвращает обрезанное изображение или исходное, если обрезка не требуется.  

Этот C#‑код демонстрирует операцию:  
```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получает PictureFrame с первого слайда
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Удаляет обрезанные области изображения PictureFrame и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Сохраняет результат
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```
  

{{% alert title="NOTE" color="warning" %}}  

Метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанном [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в получившейся презентации увеличится.  

Метод преобразует WMF/EMF‑метафайлы в растровое PNG‑изображение в процессе обрезки.  
{{% /alert %}}  

## **Сжать изображения**

Вы можете сжать изображение в презентации, используя метод [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/).  
Метод уменьшает размер изображения, учитывая размер формы и указанное разрешение, с возможностью удаления обрезанных областей.  

Он регулирует размер и разрешение картинки аналогично функции PowerPoint **Picture Format → Compress Pictures → Resolution**.  

Ниже приведены примеры C#‑кода, показывающие, как сжать изображение в презентации, задав целевое разрешение и, при желании, удалив обрезанные области:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить PictureFrame со слайда
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение с целевым разрешением 150 DPI (веб-разрешение) и удалить обрезанные области
    bool result = picFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Проверить результат сжатия
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }
}
```
  

Или с указанием пользовательского DPI напрямую:  
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение до 150 DPI (веб разрешение), удаляя обрезанные области
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```
  

{{% alert title="NOTE" color="warning" %}}  

Метод преобразует изображение к более низкому разрешению в зависимости от размера формы и указанного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение — метафайл (WMF/EMF) или SVG, сжатие не применяется. При этом качество JPEG сохраняется или слегка снижается в зависимости от разрешения, аналогично обработке в PowerPoint.  
{{% /alert %}}  

## **Блокировать соотношение сторон**

Если необходимо, чтобы форма, содержащая изображение, сохраняла своё соотношение сторон после изменения размеров изображения, можно воспользоваться свойством [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) для установки параметра *Lock Aspect Ratio*.  

Этот C#‑код показывает, как заблокировать соотношение сторон формы:  
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Устанавливает форму для сохранения соотношения сторон при изменении размера
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```
  

{{% alert title="NOTE" color="warning" %}}  

Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон формы, но не самого изображения, которое она содержит.  
{{% /alert %}}  

## **Использовать свойства StretchOffset**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) и [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) можно задать прямоугольник заполнения.  

При указании растягивания изображения исходный прямоугольник масштабируется так, чтобы вместиться в заданный прямоугольник заполнения. Каждая сторона прямоугольника заполнения определяется процентным смещением от соответствующей стороны ограничивающего бокса формы. Положительный процент задаёт отступ, отрицательный — выступ.  

1. Создать экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) .  
2. Получить ссылку на слайд по его индексу.  
3. Добавить прямоугольник `AutoShape`.  
4. Создать изображение.  
5. Задать тип заполнения формы.  
6. Задать режим заполнения формы картинкой.  
7. Добавить изображение для заполнения формы.  
8. Указать смещения изображения от соответствующей стороны ограничивающего бокса формы.  
9. Сохранить изменённую презентацию в файл PPTX.  

Этот C#‑код демонстрирует процесс, в котором используется свойство StretchOffset:  
```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

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

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**  

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и т.д.), так и векторные (например, SVG) через объект изображения, присваиваемый [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). Список поддерживаемых форматов в целом совпадает с возможностями движка конвертации слайдов и изображений.  

**Как добавление десятков больших изображений влияет на размер и производительность PPTX?**  

Встраивание больших изображений увеличивает размер файла и потребление памяти; ссылки на изображения позволяют снизить размер презентации, но требуют постоянного доступа к внешним файлам. Aspose.Slides предоставляет возможность добавлять изображения по ссылке для уменьшения размера файла.  

**Как заблокировать объект изображения от случайного перемещения/изменения размеров?**  

Используйте [shape locks](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (например, отключите перемещение или изменение размеров). Механизм блокировки описан в статье о защите фигур [/slides/net/applying-protection-to-presentation/] и поддерживается различными типами фигур, включая [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).  

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**  

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) как оригинальный вектор. При [экспорте в PDF](/slides/ru/net/convert-powerpoint-to-pdf/) или [растровые форматы](/slides/ru/net/convert-powerpoint-to-png/) результат может быть растровым в зависимости от настроек экспорта; факт хранения оригинального SVG как вектора подтверждается поведением извлечения.  