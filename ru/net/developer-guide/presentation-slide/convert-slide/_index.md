---
title: Конвертировать слайд
type: docs
weight: 41
url: /net/convert-slide/
keywords: "Конвертировать слайд в изображение, экспортировать слайд как изображение, сохранить слайд как изображение, слайд в изображение, слайд в PNG, слайд в JPEG, слайд в Bitmap, C#, Csharp, .NET, Aspose.Slides"
description: "Конвертировать слайд PowerPoint в изображение (Bitmap, PNG или JPG) на C# или .NET"
---

Aspose.Slides для .NET позволяет вам конвертировать слайды (в презентациях) в изображения. Поддерживаемые форматы изображений: BMP, PNG, JPG (JPEG), GIF и другие.

Чтобы конвертировать слайд в изображение, выполните следующие действия:

1. Сначала,
   * конвертируйте слайд в Bitmap с помощью метода [GetThumbnail](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) или
   * отрисуйте слайд на объекте Graphics с помощью метода [RenderToGraphics](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index) из интерфейса [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).

2. Во-вторых, установите дополнительные параметры для конверсии и конвертируемых объектов слайдов через
   * интерфейс [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) или
   * интерфейс [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions).

## **О Bitmap и других форматах изображений**

В .NET объект [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) позволяет работать с изображениями, определенными с помощью данных пикселей. Вы можете использовать экземпляр этого класса, чтобы сохранять изображения в широком диапазоне форматов (BMP, JPG, PNG и др.).

{{% alert title="Информация" color="info" %}}

Aspose недавно разработала онлайн-конвертер [Текст в GIF](https://products.aspose.app/slides/text-to-gif).

{{% /alert %}}

## **Конвертация слайдов в Bitmap и сохранение изображений в PNG**

Этот код на C# показывает, как конвертировать первый слайд презентации в объект bitmap, а затем как сохранить изображение в формате PNG:

```csharp
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Конвертирует первый слайд в презентации в объект Bitmap
    using (Bitmap bmp = pres.Slides[0].GetThumbnail())
    {
        // Сохраняет изображение в формате PNG
        bmp.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

Этот образец кода показывает, как конвертировать первый слайд презентации в объект bitmap, используя метод [RenderToGraphics](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index):

```csharp
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Получает размер слайда презентации
    Size slideSize = pres.SlideSize.Size.ToSize();

    // Создает Bitmap с размерами слайда
    using (Bitmap slideImage = new Bitmap(slideSize.Width, slideSize.Height))
    {
        // Отрисовывает первый слайд на объекте Graphics
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            pres.Slides[0].RenderToGraphics(new RenderingOptions(), graphics);
        }

        slideImage.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Совет" color="primary" %}} 

Вы можете конвертировать слайд в объект bitmap, а затем использовать объект напрямую в другом месте. Или вы можете конвертировать слайд в bitmap и затем сохранить изображение в формате JPEG или любом другом предпочитаемом вами формате.

{{% /alert %}}  

## **Конвертация слайдов в изображения с пользовательскими размерами**

Вам может понадобиться получить изображение определенного размера. Используя перегрузку метода [GetThumbnail](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) или [RenderToGraphics](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index), вы можете конвертировать слайд в изображение с конкретными размерами (длина и ширина).

Этот образец кода демонстрирует предложенную конверсию с использованием метода [GetThumbnail](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/getthumbnail/index) на C#:

```csharp
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Конвертирует первый слайд в презентации в Bitmap с указанным размером
    using (Bitmap bmp = pres.Slides[0].GetThumbnail(new Size(1820, 1040)))
    {
        // Сохраняет изображение в формате JPEG
        bmp.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

Этот код на C# демонстрирует, как конвертировать первый слайд в обрамленное изображение с использованием метода [RenderToGraphics](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index):

```csharp
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    Size slideSize = new Size(1820, 1040);

    // Создает Bitmap с указанным размером (размер слайда + поля)
    using (Bitmap slideImage = new Bitmap(slideSize.Width + 50, slideSize.Height + 50))
    {
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            // Заполняет и перемещает Graphics, чтобы создать рамку вокруг слайда
            graphics.Clear(Color.Red);
            graphics.TranslateTransform(25f, 25f);

            // Отрисовывает первый слайд на Graphics
            pres.Slides[0].RenderToGraphics(new RenderingOptions(), graphics, slideSize);
        }

        // Сохраняет изображение в формате JPEG
        slideImage.Save("FramedSlide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Конвертация слайдов с заметками и комментариями в изображения**

Некоторые слайды содержат заметки и комментарии.

Aspose.Slides предоставляет два интерфейса — [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) и [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions) — которые позволяют контролировать отрисовку слайдов презентации в изображения. Оба интерфейса содержат интерфейс [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions), который позволяет добавлять заметки и комментарии на слайд при конвертации этого слайда в изображение.

{{% alert title="Информация" color="info" %}} 

С помощью интерфейса [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) вы можете указать желаемое положение для заметок и комментариев на итоговом изображении.

{{% /alert %}} 

Этот код на C# демонстрирует процесс конверсии слайда с заметками и комментариями:

```csharp
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Создает параметры отрисовки
    IRenderingOptions options = new RenderingOptions();
                
    // Устанавливает положение заметок на странице
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;
                
    // Устанавливает положение комментариев на странице 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Устанавливает ширину области вывода комментариев
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;
                
    // Устанавливает цвет области комментариев
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;
                
    // Конвертирует первый слайд презентации в объект Bitmap
    Bitmap bmp = pres.Slides[0].GetThumbnail(options, 2f, 2f);

    // Сохраняет изображение в формате GIF
    bmp.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
}
```

Этот код на C# демонстрирует процесс конверсии слайда с заметками с использованием метода [RenderToGraphics](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/rendertographics/index):

```csharp
using (Presentation pres = new Presentation("PresentationNotes.pptx"))
{
    // Получает размер заметок презентации
    Size notesSize = pres.NotesSize.Size.ToSize();

    // Создает параметры отрисовки
    IRenderingOptions options = new RenderingOptions();

    // Устанавливает положение заметок
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Создает Bitmap с размерами заметок
    using (Bitmap slideImage = new Bitmap(notesSize.Width, notesSize.Height))
    {
        // Отрисовывает первый слайд на Graphics
        using (Graphics graphics = Graphics.FromImage(slideImage))
        {
            pres.Slides[0].RenderToGraphics(options, graphics, notesSize);
        }

        // Сохраняет изображение в формате PNG
        slideImage.Save("Slide_Notes_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Примечание" color="warning" %}} 

В любом процессе конверсии слайдов в изображения свойство [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) не может быть установлено в BottomFull (для указания положения заметок), потому что текст заметки может быть большим, что означает, что он может не поместиться в указанном размере изображения.

{{% /alert %}} 

## **Конвертация слайдов в изображения с использованием ITiffOptions**

Интерфейс [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) дает вам больше контроля (в терминах параметров) над итоговым изображением. С помощью этого интерфейса вы можете указать размер, разрешение, цветовую палитру и другие параметры для итогового изображения.

Этот код на C# демонстрирует процесс конверсии, где ITiffOptions используется для вывода черно-белого изображения с разрешением 300dpi и размером 2160 × 2800:

```csharp
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Получает слайд по его индексу
    ISlide slide = pres.Slides[0];

    // Создает объект TiffOptions
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // Устанавливает шрифт, используемый в случае, если исходный шрифт не найден
    options.DefaultRegularFont = "Arial Black";

    // Устанавливает положение заметок на странице 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Устанавливает формат пикселей (черно-белый)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Устанавливает разрешение
    options.DpiX = 300;
    options.DpiY = 300;

    // Конвертирует слайд в объект Bitmap
    using (Bitmap bmp = slide.GetThumbnail(options))
    {
        // Сохраняет изображение в формате BMP
        bmp.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **Конвертация всех слайдов в изображения**

Aspose.Slides позволяет вам конвертировать все слайды в одной презентации в изображения. По сути, вы можете конвертировать презентацию (в ее целостности) в изображения.

Этот образец кода показывает, как конвертировать все слайды в презентации в изображения на C#:

```csharp
// Указывает путь к выходному каталогу
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Рендерит презентацию в массив изображений по слайдам
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // Указывает настройку для скрытых слайдов (не рендерить скрытые слайды)
        if (pres.Slides[i].Hidden)
            continue;

        // Конвертирует слайд в объект Bitmap
        using (Bitmap bmp = pres.Slides[i].GetThumbnail(2f, 2f))
        {
            // Создает имя файла для изображения
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Сохраняет изображение в формате JPEG
            bmp.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
} 
```