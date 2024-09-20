---
title: Рамка для изображения
type: docs
weight: 10
url: /net/picture-frame/
keywords: "Добавить рамку для изображения, создать рамку для изображения, добавить изображение, создать изображение, извлечь изображение, свойство StretchOff, форматирование рамки для изображения, свойства рамки для изображения, презентация PowerPoint, C#, Csharp, Aspose.Slides для .NET"
description: "Добавить рамку для изображения в презентацию PowerPoint на C# или .NET"
---

Рамка для изображения — это фигура, которая содержит изображение, она как картина в рамке.

Вы можете добавить изображение на слайд через рамку для изображения. Таким образом, вы можете отформатировать изображение, отформатировав рамку для изображения.

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt), которые позволяют людям быстро создавать презентации из изображений.

{{% /alert %}}

## **Создание рамки для изображения**

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, который будет использован для заливки фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) на основе ширины и высоты изображения через метод `AddPictureFrame`, предоставленный объектом фигуры, связанным с указным слайдом.
6. Добавьте рамку для изображения (содержит картинку) на слайд.
7. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как создать рамку для изображения:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Создает экземпляр класса ImageEx
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Добавляет рамку для изображения с эквивалентной высотой и шириной изображения
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Применяет некоторое форматирование к PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    // Записывает PPTX файл на диск
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}}

Рамки для изображений позволяют быстро создавать слайды презентаций на основе изображений. Когда вы комбинируете рамку для изображения с параметрами сохранения Aspose.Slides, вы можете манипулировать вводом/выводом, чтобы преобразовывать изображения из одного формата в другой. Вы можете ознакомиться с этими страницами: конвертировать [изображение в JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Создание рамки для изображения с относительным масштабом**

Изменив относительное масштабирование изображения, вы можете создать более сложную рамку для изображения.

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Получите ссылку на слайд по индексу.
3. Добавьте изображение в коллекцию изображений презентации.
4. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, который будет использован для заливки фигуры.
5. Укажите относительную ширину и высоту изображения в рамке для изображения.
6. Запишите измененную презентацию в файл PPTX.

Этот код на C# показывает, как создать рамку для изображения с относительным масштабом:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation presentation = new Presentation())
{

    // Загружает изображение, которое будет добавлено в коллекцию изображений презентации
    Image img = new Bitmap("aspose-logo.jpg");
    IPPImage image = presentation.Images.AddImage(img);

    // Добавляет рамку для изображения на слайд
    IPictureFrame pf = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);

    // Устанавливает относительное значение ширины и высоты
    pf.RelativeScaleHeight = 0.8f;
    pf.RelativeScaleWidth = 1.35f;

    // Сохраняет презентацию
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Извлечение изображения из рамки для изображения**

Вы можете извлекать изображения из объектов [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) и сохранять их в форматах PNG, JPG и других. Пример кода ниже демонстрирует, как извлечь изображение из документа "sample.pptx" и сохранить его в формате PNG.

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

## **Получение прозрачности изображения**

Aspose.Slides позволяет вам получить прозрачность изображения. Этот код на C# демонстрирует эту операцию:

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Прозрачность изображения: " + transparencyValue);
        }
    }
}
```

## **Форматирование рамки для изображения**

Aspose.Slides предоставляет множество параметров форматирования, которые можно применять к рамке для изображения. Используя эти параметры, вы можете изменить рамку для изображения так, чтобы она соответствовала определенным требованиям.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд по индексу.
3. Создайте объект [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage), добавив изображение в [IImagescollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection), связанную с объектом презентации, который будет использован для заливки фигуры.
4. Укажите ширину и высоту изображения.
5. Создайте `PictureFrame` на основе ширины и высоты изображения через метод [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe), предоставленный объектом [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection), связанным с указным слайдом.
6. Добавьте рамку для изображения (содержит картинку) на слайд.
7. Установите цвет линии рамки для изображения.
8. Установите ширину линии рамки для изображения.
9. Поверните рамку для изображения, задав ей положительное или отрицательное значение.
   * Положительное значение поворачивает изображение по часовой стрелке.
   * Отрицательное значение поворачивает изображение против часовой стрелки.
10. Добавьте рамку для изображения (содержит картинку) на слайд.
11. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует процесс форматирования рамки для изображения:

```c#
// Создает экземпляр класса Presentation, представляющего файл PPTX
using (Presentation pres = new Presentation())
{

    // Получает первый слайд
    ISlide sld = pres.Slides[0];

    // Создает экземпляр класса ImageEx
    System.Drawing.Image img = (System.Drawing.Image)new Bitmap("aspose-logo.jpg");
    IPPImage imgx = pres.Images.AddImage(img);

    // Добавляет рамку для изображения с эквивалентной высотой и шириной изображения
    IPictureFrame pf = sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

    // Применяет некоторое форматирование к PictureFrameEx
    pf.LineFormat.FillFormat.FillType = FillType.Solid;
    pf.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pf.LineFormat.Width = 20;
    pf.Rotation = 45;

    // Записывает PPTX файл на диск
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose недавно разработал [бесплатный Конструктор Коллажей](https://products.aspose.app/slides/collage). Если вам когда-либо нужно будет [объединить изображения JPG/JPEG](https://products.aspose.app/slides/collage/jpg) или PNG, [создать сетки из фотографий](https://products.aspose.app/slides/collage/photo-grid), вы можете использовать этот сервис.

{{% /alert %}}

## **Добавить изображение как ссылку**

Чтобы избежать больших размеров презентации, вы можете добавить изображения (или видео) через ссылки вместо встраивания файлов непосредственно в презентации. Этот код на C# показывает, как добавить изображение и видео в заполнитель:

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

Этот код на C# показывает, как обрезать существующее изображение на слайде:

```c#
using (Presentation presentation = new Presentation())
{
    // Создает новый объект изображения
    IPPImage newImage = presentation.Images.AddImage(Image.FromFile(imagePath));

    // Добавляет рамку для изображения на слайд
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

## Удалить обрезанные области изображения

Если вы хотите удалить обрезанные области изображения, содержащегося в рамке, вы можете использовать метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Этот метод возвращает обрезанное изображение или исходное изображение, если обрезка не необходима.

Этот код на C# демонстрирует операцию:

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Получает PictureFrame с первого слайда
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Удаляет обрезанные области изображения рамки и возвращает обрезанное изображение
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Сохраняет результат
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Метод [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) добавляет обрезанное изображение в коллекцию изображений презентации. Если изображение используется только в обработанной [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/), эта настройка может уменьшить размер презентации. В противном случае количество изображений в результирующей презентации увеличится.

Этот метод преобразует метафайлы WMF/EMF в растровое изображение PNG в процессе обрезки.

{{% /alert %}}

## **Закрепить соотношение сторон**

Если вы хотите, чтобы фигура, содержащая изображение, сохраняла свое соотношение сторон даже после изменения размеров изображения, вы можете использовать свойство [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) для установки параметра *Закрепить соотношение сторон*.

Этот код на C# показывает, как зафиксировать соотношение сторон фигуры:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);
    using Image image = Image.FromFile(Path.Combine("image.png"));
    IPPImage presImage = pres.Images.AddImage(image);

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Устанавливает форму для сохранения соотношения сторон при изменении размера
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="ПРИМЕЧАНИЕ" color="warning" %}}

Этот параметр *Закрепить соотношение сторон* сохраняет только соотношение сторон фигуры, а не изображения, которое она содержит.

{{% /alert %}}

## **Используйте свойство StretchOff**

Используя свойства [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) и [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) интерфейса [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) и класса [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat), вы можете задать заполнение прямоугольника.

Когда для изображения установлено масштабирование, исходный прямоугольник масштабируется, чтобы соответствовать указанному прямоугольнику заполнения. Каждый край прямоугольника заполнения определяется процентным смещением от соответствующего края ограничивающей рамки фигуры. Положительный процент указывает на внутреннее смещение, а отрицательный процент — на внешнее смещение.

1. Создайте экземпляр класса [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Получите ссылку на слайд по индексу.
3. Добавьте прямоугольник `AutoShape`.
4. Создайте изображение.
5. Установите тип заливки фигуры.
6. Установите режим заливки изображения фигуры.
7. Добавьте установленное изображение для заполнения фигуры.
8. Укажите смещения изображения от соответствующего края ограничивающей рамки фигуры.
9. Запишите измененную презентацию в файл PPTX.

Этот код на C# демонстрирует процесс, в котором используется свойство StretchOff:

```c#
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image bitmap = new Bitmap("image.png"))
    {
        ppImage = pres.Images.AddImage(bitmap);
    }

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);
    
    // Устанавливает изображение, растянутое с каждой стороны в теле фигуры
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;
    
    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```