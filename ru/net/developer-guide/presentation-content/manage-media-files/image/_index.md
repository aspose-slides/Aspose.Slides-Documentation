---
title: Изображение
type: docs
weight: 10
url: /net/image/
keywords: "Добавить изображение, Добавить картинку, Презентация PowerPoint, EMF, SVG, C#, Csharp, Aspose.Slides для .NET"
description: "Добавьте изображение на слайд или в презентацию PowerPoint на C# или .NET"
---

## **Изображения на слайдах в презентациях**

Изображения делают презентации более привлекательными и интересными. В Microsoft PowerPoint вы можете вставлять изображения из файла, интернета или других мест на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами.

{{% alert title="Совет" color="primary" %}}

Aspose предоставляет бесплатные конвертеры — [JPEG в PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG в PowerPoint](https://products.aspose.app/slides/import/png-to-ppt), которые позволяют пользователям быстро создавать презентации из изображений.

{{% /alert %}}

{{% alert title="Информация" color="info" %}}

Если вы хотите добавить изображение в качестве объектной рамки — особенно если вы собираетесь использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.д. — смотрите [Рамка изображения](https://docs.aspose.com/slides/net/picture-frame/).

{{% /alert %}}

{{% alert title="Примечание" color="warning" %}}

Вы можете управлять операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, чтобы конвертировать изображение из одного формата в другой. Смотрите эти страницы: конвертировать [изображение в JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); конвертировать [JPG в изображение](https://products.aspose.com/slides/net/conversion/jpg-to-image/); конвертировать [JPG в PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), конвертировать [PNG в JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); конвертировать [PNG в SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), конвертировать [SVG в PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает операции с изображениями в этих популярных форматах: JPEG, PNG, BMP, GIF и других.

## **Добавление изображений, хранящихся локально, на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Этот пример кода на C# показывает, как добавить изображение на слайд:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Добавление изображений из Интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить изображение напрямую из Интернета.

Этот пример кода показывает, как добавить изображение из Интернета на слайд на C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[ЗАМЕНИТЕ URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Добавление изображений в мастер-слайды**

Мастер-слайд — это верхний слайд, который хранит и управляет информацией (темой, макетом и т.д.) о всех слайдах под ним. Таким образом, когда вы добавляете изображение в мастер-слайд, это изображение появляется на каждом слайде под этим мастер-слайдом.

Этот пример кода на C# показывает, как добавить изображение в мастер-слайд:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Добавление изображений в качестве фона слайда**

Вы можете решить использовать изображение в качестве фона для конкретного слайда или нескольких слайдов. В этом случае вам нужно ознакомиться с *[Установкой изображений в качестве фонов для слайдов](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавлять или вставлять любое изображение в презентацию, используя метод [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

Чтобы создать объект изображения на основе SVG-изображения, вы можете сделать это следующим образом:

1. Создайте объект SvgImage, чтобы вставить его в ImageShapeCollection
2. Создайте объект PPImage из ISvgImage
3. Создайте объект PictureFrame с использованием интерфейса IPPImage

Этот пример кода показывает, как реализовать вышеописанные шаги, чтобы добавить изображение SVG в презентацию:
```csharp 
// Путь к каталогу документов
string dataDir = @"D:\Documents\";

// Имя исходного SVG файла
string svgFileName = dataDir + "sample.svg";

// Имя выходного файла презентации
string outPptxPath = dataDir + "presentation.pptx";

// Создание новой презентации
using (var p = new Presentation())
{
    // Чтение содержимого SVG файла
    string svgContent = File.ReadAllText(svgFileName);

    // Создание объекта SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Создание объекта PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Создание нового PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Сохранение презентации в формате PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Конвертация SVG в набор форм**
Конвертация SVG в набор форм в Aspose.Slides аналогична функциональности PowerPoint, используемой для работы с SVG-изображениями:


![Всплывающее меню PowerPoint](img_01_01.png)

Эта функциональность предоставляется одним из перегрузок метода [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для конвертации SVG файла в набор форм:

```csharp 
// Путь к каталогу документов
string dataDir = @"D:\Documents\";

// Имя исходного SVG файла
string svgFileName = dataDir + "sample.svg";

// Имя выходного файла презентации
string outPptxPath = dataDir + "presentation.pptx";

// Создание новой презентации
using (IPresentation presentation = new Presentation())
{
    // Чтение содержимого SVG файла
    string svgContent = File.ReadAllText(svgFileName);

    // Создание объекта SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получение размера слайда
    SizeF slideSize = presentation.SlideSize.Size;

    // Конвертация SVG изображения в группу форм с масштабированием до размера слайда
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Сохранение презентации в формате PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Добавление изображений как EMF на слайды**
Aspose.Slides для .NET позволяет вам создавать EMF изображения из листов Excel и добавлять изображения как EMF на слайды с помощью Aspose.Cells.

Этот пример кода показывает, как выполнить описанную задачу:

```csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // Сохранение рабочей книги в поток
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

{{% alert title="Информация" color="info" %}}

Используя бесплатный конвертер Aspose [Текст в GIF](https://products.aspose.app/slides/text-to-gif), вы можете легко анимировать текст, создавать GIF из текстов и т.д.

{{% /alert %}}