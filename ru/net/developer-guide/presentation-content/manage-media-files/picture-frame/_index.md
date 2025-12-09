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

Рамка изображения — это фигура, содержащая изображение, она похожа на картину в рамке. 

Вы можете добавить изображение на слайд через рамку изображения. Таким образом, вы форматируете изображение, форматируя рамку изображения.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры —[JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) —которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

## **Создание рамки изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанный с объектом презентации, который будет использован для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) на основе ширины и высоты изображения с помощью метода `AddPictureFrame`, предоставленного объектом формы, связанным с указанным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Запишите изменённую презентацию в файл PPTX.

Этот код C# показывает, как создать рамку изображения:
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

Рамки изображения позволяют быстро создавать слайды презентаций на основе изображений. Комбинируя рамку изображения с параметрами сохранения Aspose.Slides, можно управлять операциями ввода/вывода для конвертации изображений из одного формата в другой. Возможно, вас заинтересуют эти страницы: конвертировать [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); конвертировать [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); конвертировать [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), конвертировать [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); конвертировать [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), конвертировать [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамки изображения с относительным масштабом**

Изменяя относительное масштабирование изображения, вы можете создать более сложную рамку изображения. 

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Получите ссылку на слайд по его индексу. 
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанный с объектом презентации, который будет использован для заполнения фигуры.
5. Укажите относительные ширину и высоту изображения в рамке изображения.
6. Запишите изменённую презентацию в файл PPTX.

Этот код C# показывает, как создать рамку изображения с относительным масштабом:
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


## **Извлечение растровых изображений из рамок изображения**

Вы можете извлечь растровые изображения из объектов [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) и сохранить их в PNG, JPG и другие форматы. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.
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


## **Извлечение SVG‑изображений из рамок изображения**

Когда презентация содержит SVG‑графику, размещённую внутри фигур [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), Aspose.Slides для .NET позволяет извлечь оригинальные векторные изображения с полной точностью. Проходя по коллекции фигур слайда, можно определить каждую [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), проверить, содержит ли соответствующий [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) SVG‑контент, и затем сохранить это изображение на диск или в поток в его родном SVG‑формате.

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


## **Получение прозрачности изображения**

Aspose.Slides позволяет получить эффект прозрачности, применённый к изображению. Этот код C# демонстрирует операцию:
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
Все эффекты, применённые к изображениям, можно найти в [Aspose.Slides.Effects](https://reference.aspose.com/slides/net/aspose.slides.effects/).
{{% /alert %}}

## **Форматирование рамки изображения**

Aspose.Slides предоставляет множество вариантов форматирования, которые можно применить к рамке изображения. Используя эти варианты, можно изменить рамку изображения так, чтобы она соответствовала конкретным требованиям.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) . 
2. Получите ссылку на слайд по его индексу. 
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанный с объектом презентации, который будет использован для заполнения фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения с помощью метода [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe), предоставленного объектом [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection), связанным с указанным слайдом.
6. Добавьте рамку изображения (содержащую картинку) на слайд.
7. Установите цвет линии рамки изображения.
8. Установите ширину линии рамки изображения.
9. Поверните рамку изображения, задав ей положительное или отрицательное значение. 
   * Положительное значение вращает изображение по часовой стрелке. 
   * Отрицательное значение вращает изображение против часовой стрелки.
10. Добавьте рамку изображения (содержащую картинку) на слайд.
11. Запишите изменённую презентацию в файл PPTX.

Этот код C# демонстрирует процесс форматирования рамки изображения:
```c#
// Создаёт экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{
    // Получает первый слайд
    ISlide slide = presentation.Slides[0];

    // Загружает изображение и добавляет его в коллекцию изображений презентации
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Добавляет рамку изображения с высотой и шириной, равными размеру картинки
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


{{% alert color="primary" %}}

Aspose недавно разработал [бесплатный Collage Maker](https://products.aspose.app/slides/collage). Если вам нужно [объединить JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG‑изображения, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете воспользоваться этим сервисом. 

{{% /alert %}}

## **Добавление изображения как ссылки**

Чтобы избежать больших размеров презентаций, можно добавлять изображения (или видео) через ссылки вместо внедрения файлов непосредственно в презентацию. Этот код C# показывает, как добавить изображение и видео в заполнитель:
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


## **Обрезка изображения**

Этот код C# показывает, как обрезать существующее изображение на слайде:
```c#
using (Presentation presentation = new Presentation())
{
    // Создаёт новый объект изображения
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


## **Удаление обрезанных областей изображения**

Если необходимо удалить обрезанные области изображения, содержащегося в рамке, используйте метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Этот метод возвращает обрезанное изображение или оригинальное, если обрезка не требуется.

Этот код C# демонстрирует операцию:
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

Метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), такая настройка может уменьшить размер презентации. В противном случае количество изображений в полученной презентации увеличится.

Метод преобразует метафайлы WMF/EMF в растровое PNG‑изображение в процессе обрезки. 

{{% /alert %}}

## **Сжатие изображения**

Вы можете сжать картинку в презентации, используя метод [`IPictureFillFormat.CompressImage`](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/compressimage/). 
Метод уменьшает размер изображения, учитывая размер фигуры и заданное разрешение, с возможностью удаления обрезанных областей. 

Он регулирует размер и разрешение изображения аналогично функции PowerPoint **Формат рисунка → Сжать рисунки → Разрешение**.

Следующие примеры C# демонстрируют, как сжать изображение в презентации, задав целевое разрешение и при необходимости удалив обрезанные области:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получить PictureFrame из слайда
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение до целевого разрешения 150 DPI (веб‑разрешение) и удалить обрезанные области
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


Или напрямую, задав пользовательское значение DPI:
```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];

    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Сжать изображение до 150 DPI (веб-разрешение), удаляя обрезанные области
    bool result = picFrame.PictureFormat.CompressImage(true, 150f);
}
```


{{% alert title="NOTE" color="warning" %}} 

Метод преобразует изображение в более низкое разрешение, исходя из размеров фигуры и указанного DPI. Обрезанные области также могут быть удалены для оптимизации размера файла.  
Если изображение является метафайлом (WMF/EMF) или SVG, сжатие не будет применено. Кроме того, качество JPEG сохраняется или слегка снижается в зависимости от разрешения, подобно тому, как PowerPoint обрабатывает JPEG с высоким разрешением.

{{% /alert %}}

## **Блокировка соотношения сторон**

Если требуется, чтобы фигура с изображением сохраняла своё соотношение сторон после изменения размеров изображения, можно использовать свойство [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) для включения параметра *Lock Aspect Ratio*. 

Этот код C# показывает, как заблокировать соотношение сторон фигуры:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Устанавливает сохранение соотношения сторон формы при изменении размера
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```


{{% alert title="NOTE" color="warning" %}} 

Параметр *Lock Aspect Ratio* сохраняет только соотношение сторон самой фигуры, но не изображения, которое она содержит.

{{% /alert %}}

## **Использование свойства StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) и [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) из интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat) можно задать прямоугольник заполнения. 

При указании растягивания для изображения исходный прямоугольник масштабируется, чтобы соответствовать заданному прямоугольнику заполнения. Каждая грань прямоугольника заполнения определяется процентным смещением от соответствующей грани ограничивающего бокса фигуры. Положительный процент указывает на врезку, отрицательный — на выступ.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/) . 
2. Получите ссылку на слайд по его индексу. 
3. Добавьте прямоугольник `AutoShape`. 
4. Создайте изображение. 
5. Установите тип заполнения фигуры. 
6. Установите режим заполнения рисунком. 
7. Добавьте изображение для заполнения фигуры. 
8. Укажите смещения изображения от соответствующей грани ограничивающего бокса фигуры. 
9. Запишите изменённую презентацию в файл PPTX.

Этот код C# демонстрирует процесс использования свойства StretchOff:
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


## **Часто задаваемые вопросы**

**Как узнать, какие форматы изображений поддерживаются для PictureFrame?**

Aspose.Slides поддерживает как растровые изображения (PNG, JPEG, BMP, GIF и др.), так и векторные (например, SVG) через объект изображения, назначенный [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/). Список поддерживаемых форматов, как правило, совпадает с возможностями движка конвертации слайдов и изображений.

**Как добавление множества больших изображений влияет на размер PPTX и производительность?**

Встраивание больших изображений увеличивает размер файла и потребление памяти; использование ссылок на изображения помогает уменьшить размер презентации, но требует доступности внешних файлов. Aspose.Slides предоставляет возможность добавления изображений по ссылке для уменьшения размера файла.

**Как заблокировать объект изображения от случайного перемещения/изменения размера?**

Используйте [блокировки фигур](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/pictureframelock/) для [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) (например, отключить перемещение или изменение размера). Механизм блокировки описан в отдельной статье о защите [здесь](/slides/ru/net/applying-protection-to-presentation/) и поддерживается для разных типов фигур, включая [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/).

**Сохраняется ли векторная точность SVG при экспорте презентации в PDF/изображения?**

Aspose.Slides позволяет извлечь SVG из [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) как оригинальный вектор. При экспорте в PDF [/slides/net/convert-powerpoint-to-pdf/] или в растровые форматы [/slides/net/convert-powerpoint-to-png/] результат может быть растеризован в зависимости от настроек экспорта; факт сохранения оригинального SVG как вектора подтверждается поведением извлечения.