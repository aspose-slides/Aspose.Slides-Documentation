---
title: Оптимизация управления изображениями в презентациях в .NET
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/net/image/
keywords:
- добавить изображение
- добавить картинку
- добавить битмап
- заменить изображение
- заменить картинку
- из веба
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Упрощение управления изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, оптимизация производительности и автоматизация вашего рабочего процесса."
---

## **Изображения в слайдах презентаций**

Изображения делают презентации более захватывающими и интересными. В Microsoft PowerPoint вы можете вставлять картинки из файла, интернета или других источников на слайды. Аналогично, Aspose.Slides позволяет добавлять изображения на слайды в ваших презентациях различными способами.

{{% alert  title="Tip" color="primary" %}} 

Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Если вы хотите добавить изображение как объект кадра — особенно если планируете использовать стандартные параметры форматирования для изменения его размера, добавления эффектов и т.д. — см. [Picture Frame](https://docs.aspose.com/slides/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Вы можете управлять операциями ввода/вывода, связанными с изображениями и презентациями PowerPoint, для преобразования изображения из одного формата в другой. См. эти страницы: преобразовать [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); преобразовать [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); преобразовать [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), преобразовать [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); преобразовать [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), преобразовать [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides поддерживает работу с изображениями в следующих популярных форматах: JPEG, PNG, BMP, GIF и другие. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений с вашего компьютера на слайд в презентации. Пример кода на C# показывает, как добавить изображение на слайд:
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

Если изображение, которое вы хотите добавить на слайд, недоступно на вашем компьютере, вы можете добавить его напрямую из Интернета. 

Этот пример кода показывает, как добавить изображение из Интернета на слайд на C#:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Добавление изображений в шаблоны слайдов**

Шаблон слайда (slide master) — это верхний слайд, который хранит и контролирует информацию (тема, макет и т.д.) о всех слайдах, расположенных под ним. Поэтому, когда вы добавляете изображение в шаблон слайда, это изображение появляется на каждом слайде, использующем данный шаблон. 

Пример кода на C# показывает, как добавить изображение в шаблон слайда:
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


## **Добавление изображений в качестве фона слайдов**

Вы можете решить использовать картинку в качестве фона для конкретного слайда или нескольких слайдов. В этом случае следует посмотреть *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**
Вы можете добавить или вставить любое изображение в презентацию, используя метод [AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addpictureframe), который принадлежит интерфейсу [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection).

Чтобы создать объект изображения на основе SVG, можно сделать это следующим образом:

1. Создать объект SvgImage для вставки в ImageShapeCollection
2. Создать объект PPImage из ISvgImage
3. Создать объект PictureFrame, используя интерфейс IPPImage

Этот пример кода показывает, как реализовать перечисленные шаги для добавления SVG‑изображения в презентацию:
```csharp
// Путь к директории документов
string dataDir = @"D:\Documents\";

// Исходное имя файла SVG
string svgFileName = dataDir + "sample.svg";

// Имя выходного файла презентации
string outPptxPath = dataDir + "presentation.pptx";

// Создать новую презентацию
using (var p = new Presentation())
{
    // Прочитать содержимое SVG‑файла
    string svgContent = File.ReadAllText(svgFileName);

    // Создать объект SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Создать объект PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Создает новый PictureFrame 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Сохранить презентацию в формате PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Преобразование SVG в набор фигур**
Преобразование SVG в набор фигур в Aspose.Slides схоже с функцией PowerPoint, используемой для работы с SVG‑изображениями:

![PowerPoint Popup Menu](img_01_01.png)

Эта функциональность предоставляется одной из перегрузок метода [AddGroupShape](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/addgroupshape/methods/1) интерфейса [IShapeCollection](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/net/aspose.slides/isvgimage) в качестве первого аргумента.

Этот пример кода показывает, как использовать описанный метод для преобразования SVG‑файла в набор фигур:
``` csharp 
// Путь к директории документов
string dataDir = @"D:\Documents\";

// Исходное имя файла SVG
string svgFileName = dataDir + "sample.svg";

// Имя выходного файла презентации
string outPptxPath = dataDir + "presentation.pptx";

// Создать новую презентацию
using (IPresentation presentation = new Presentation())
{
    // Прочитать содержимое SVG-файла
    string svgContent = File.ReadAllText(svgFileName);

    // Создать объект SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получить размер слайда
    SizeF slideSize = presentation.SlideSize.Size;

    // Преобразовать SVG‑изображение в группу фигур, масштабируя его до размеров слайда
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Сохранить презентацию в формате PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```


## **Добавление изображений в формате EMF на слайды**
Aspose.Slides для .NET позволяет генерировать EMF‑изображения из листов Excel и добавлять их в качестве EMF на слайды с помощью Aspose.Cells. 

Этот пример кода показывает, как выполнить описанную задачу:
``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    //Сохранить рабочую книгу в поток
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


## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации (включая те, которые используются фигурами слайда). В этом разделе показаны несколько подходов к обновлению изображений в коллекции. API предоставляет простые методы замены изображения с помощью необработанных байтовых данных, экземпляра [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) или другого изображения, уже присутствующего в коллекции.

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Загрузите новое изображение из файла в массив байтов.
3. Замените целевое изображение новым, используя массив байтов.
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) и замените целевое изображение этим объектом.
5. В третьем подходе замените целевое изображение изображением, уже существующим в коллекции изображений презентации.
6. Запишите изменённую презентацию в файл PPTX.
```cs
// Создать экземпляр класса Presentation, представляющего файл презентации.
using Presentation presentation = new Presentation("sample.pptx");

// Первый способ.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Второй способ.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Третий способ.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Сохранить презентацию в файл.
presentation.Save("output.pptx", SaveFormat.Pptx);
```


{{% alert title="Info" color="info" %}}

С помощью бесплатного конвертера Aspose FREE [Text to GIF](https://products.aspose.app/slides/text-to-gif) вы можете легко анимировать текст, создавать GIF‑изображения из текста и т.д. 

{{% /alert %}}

## **FAQ**

**Сохраняется ли исходное разрешение изображения после вставки?**

Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [картинка](/slides/ru/net/picture-frame/) масштабируется на слайде и от любой компрессии при сохранении.

**Как лучше всего заменить один и тот же логотип сразу на десятках слайдов?**

Разместите логотип на мастер‑слайде или в макете и замените его в коллекции изображений презентации — обновления распространятся на все элементы, использующие этот ресурс.

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**

Да. Вы можете преобразовать SVG в группу фигур, после чего отдельные части станут редактируемыми с помощью стандартных свойств фигур.

**Как установить изображение фоном сразу для нескольких слайдов?**

[Назначьте изображение в качестве фона](/slides/ru/net/presentation-background/) на мастер‑слайде или соответствующем макете — любые слайды, использующие этот мастер/макет, унаследуют фон.

**Как не допустить «раздувания» размера презентации из‑за большого количества изображений?**

Повторно используйте один ресурс изображения вместо дубликатов, выбирайте разумные разрешения, применяйте компрессию при сохранении и держите повторяющиеся графические элементы на мастер‑слайде, где это уместно.