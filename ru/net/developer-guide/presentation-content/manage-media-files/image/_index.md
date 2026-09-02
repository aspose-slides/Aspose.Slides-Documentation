---
title: Оптимизация управления изображениями в презентациях на .NET
linktitle: Управление изображениями
type: docs
weight: 10
url: /ru/net/image/
keywords:
- добавить изображение
- добавить картинку
- добавить bitmap
- заменить изображение
- заменить картинку
- из интернета
- фон
- добавить PNG
- добавить JPG
- добавить SVG
- внешние ресурсы SVG
- резолвер SVG
- связанные SVG‑изображения
- шрифты SVG
- добавить EMF
- добавить WMF
- добавить TIFF
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Упростите управление изображениями в PowerPoint и OpenDocument с помощью Aspose.Slides для .NET, улучшая производительность и автоматизируя ваш рабочий процесс."
---
## **Введение**

Изображения делают презентации более увлекательными и визуально привлекательными. В Microsoft PowerPoint вы можете вставлять картинки на слайды из файлов, интернета или других источников. Аналогично, Aspose.Slides позволяет добавлять изображения в слайды презентации несколькими способами.

{{% alert  title="Tip" color="primary" %}} 
Aspose предоставляет бесплатные конвертеры — [JPEG to PowerPoint](https://products.aspose.app/slides/ru/import/jpg-to-ppt) и [PNG to PowerPoint](https://products.aspose.app/slides/ru/import/png-to-ppt) — которые позволяют быстро создавать презентации из изображений. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Если вы хотите добавить изображение как рамку картинки — особенно если планируете изменять его размер, применять эффекты или использовать другие стандартные параметры форматирования — см. [Picture Frame](/slides/ru/net/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Вы можете конвертировать изображения из одного формата в другой. Смотрите следующие страницы: конвертировать [image to JPG](https://products.aspose.com/slides/ru/net/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/ru/net/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/ru/net/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ru/net/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/ru/net/conversion/png-to-svg/), и [SVG to PNG](https://products.aspose.com/slides/ru/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides поддерживает изображения в популярных форматах, таких как JPEG, PNG, BMP, GIF и другие. 

## **Добавление локально хранящихся изображений на слайды**

Вы можете добавить одно или несколько изображений, хранящихся на вашем компьютере, на слайд презентации. Ниже приведён пример кода C#, показывающий, как добавить изображение на слайд:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Добавление изображений из Интернета на слайды**

Если изображение, которое вы хотите добавить на слайд, не хранится на вашем компьютере, вы можете добавить его напрямую из Интернета. 

Ниже приведён пример кода C#, показывающий, как добавить изображение из Интернета на слайд:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Мастер слайда хранит и контролирует информацию, такую как тема и макет для слайдов, которые его используют. Когда вы добавляете изображение в мастер слайда, изображение появляется на каждом слайде, основанном на этом мастере. 

Ниже приведён пример кода C#, показывающий, как добавить изображение в мастер слайда:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Вы можете использовать изображение в качестве фона одного или нескольких слайдов. Подробности см. в *[Setting Images as Backgrounds for Slides](/slides/ru/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Добавление SVG в презентации**

Содержимое SVG можно добавить в презентацию с помощью класса [SvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/svgimage/). Полученный объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/) затем можно добавить в коллекцию изображений презентации и использовать для создания рамки картинки. 

Ниже приведён пример C#, импортирующий автономную строку SVG. Все изображения, стили и другие ресурсы, использованные в этом SVG, внедрены непосредственно в содержимое SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Импорт SVG‑контента с внешними ресурсами**

SVG‑файлы, экспортированные из дизайнерских инструментов, редакторов диаграмм, систем иконок и веб‑конвейеров, могут ссылаться на ресурсы, хранящиеся вне документа SVG. Например, SVG может содержать ссылку на изображение вида `images/photo.png`, значение CSS `url(...)` или URL шрифта. 

Чтобы импортировать такой SVG‑контент, создайте реализацию [IExternalResourceResolver](https://reference.aspose.com/slides/ru/net/aspose.slides.import/iexternalresourceresolver/) и передайте её вместе с базовым URI в соответствующий конструктор `SvgImage`. Базовый URI указывает расположение документа SVG и используется для разрешения относительных ссылок. 

Интерфейс [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage/) предоставляет доступ к информации об импортированном SVG: 

- `SvgContent` возвращает разметку SVG в виде строки. 
- `SvgData` возвращает содержимое SVG в виде массива байтов. 
- `BaseUri` возвращает базовый URI, используемый для относительных ссылок. 
- `ExternalResourceResolver` возвращает резолвер, назначенный изображению SVG. 

### **Реализация внешнего резолвера ресурсов**

У резолвера есть два метода: 

- [ResolveUri](https://reference.aspose.com/slides/ru/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) комбинирует базовый URI и относительную ссылку на ресурс и возвращает абсолютный URI. Возвратите `null`, когда ссылку нельзя разрешить или она не допускается. 
- [GetEntity](https://reference.aspose.com/slides/ru/net/aspose.slides.import/iexternalresourceresolver/getentity/) возвращает поток для чтения абсолютного URI ресурса. Возвратите `null`, когда ресурс отсутствует, заблокирован или недоступен. При необходимости можно также вернуть резервный поток. 

Следующий резолвер загружает связанные ресурсы только из разрешённого локального каталога. Сетевые ресурсы и пути за пределами разрешённого каталога блокируются. Для нерешённых ссылок на изображения возвращается необязательное резервное изображение. 

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Этот резолвер намеренно разрешает только локальные файлы.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Использовать резервный вариант только для графических ресурсов. Возврат потока изображения
        // для отсутствующего шрифта или таблицы стилей будет недопустимым.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Разрешение связанных ресурсов при импорте SVG**

Предположим, что `assets/diagram.svg` содержит относительную ссылку, например: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Ниже приведён пример C#, который передаёт URI SVG‑файла в качестве базового URI и использует пользовательский резолвер. Резолвер преобразует относительную ссылку на изображение в абсолютный URI и возвращает поток, содержащий связанный ресурс, пока Aspose.Slides обрабатывает SVG. 

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// Базовый URI представляет расположение SVG‑документа.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage предоставляет исходное содержимое, бинарные данные, базовый URI и резолвер.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

Класс `SvgImage` также предоставляет перегрузки, принимающие данные SVG в виде массива байтов или потока, вместе с внешним резолвером ресурсов и базовым URI. 

{{% alert title="Important" color="warning" %}}

Ресурсный резолвер делает внешние ресурсы доступными во время обработки и рендеринга SVG в Aspose.Slides. Он не изменяет оригинальную разметку SVG и не внедряет автоматически разрешённые ресурсы в неё. 

Когда объект `ISvgImage` добавляется в коллекцию изображений презентации, файл PPTX может содержать как оригинальное SVG‑представление, так и растровое резервное изображение. Связанный ресурс может появиться в сгенерированном резервном изображении, тогда как относительная ссылка типа `images/photo.png` остаётся неизменной в сохранённом SVG. Приложение, которое рендерит нативное SVG‑представление, может поэтому опустить связанный контент, если оригинальный внешний ресурс недоступен. 
{{% /alert %}}

### **Создание переносного SVG‑изображения**

Чтобы создать SVG‑изображение, не зависящее от внешних файлов, сделайте SVG автономным перед созданием `SvgImage`. Например, замените связанные URL‑адреса изображений на URI вида `data:`, содержащие данные изображения: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

После того как все необходимые ресурсы будут внедрены в содержимое SVG, создайте `SvgImage`, добавьте его в коллекцию изображений презентации и вставьте в рамку картинки, как показано в предыдущем примере. 

### **Обработка отсутствующих или заблокированных ресурсов**

Возвратите `null` из `ResolveUri`, когда URI ресурса недействителен, запрещён или не может быть разрешён. Возвратите `null` из `GetEntity`, когда ресурс нельзя прочитать. Aspose.Slides продолжает обработку SVG без этого ресурса, когда это возможно. 

Для отсутствующего ресурса можно вернуть резервный поток, но его содержимое должно соответствовать требуемому типу ресурса. Например, возвращайте поток изображения только для отсутствующего изображения, а не для шрифта или таблицы стилей. 

{{% alert title="Security" color="warning" %}}

Не разрешайте произвольные пути файлов или неограниченные сетевые URL‑адреса из ненадёжных SVG‑файлов. Ограничьте допустимые схемы, каталоги и хосты. Для сетевых ресурсов также применяйте тайм‑ауты соединения, ограничения по размеру ответа и проверку содержимого. 
{{% /alert %}}

## **Конвертирование SVG в набор фигур**
Aspose.Slides может конвертировать SVG в набор фигур, аналогично соответствующей функции в PowerPoint: 

![PowerPoint Popup Menu](img_01_01.png)

Эта возможность предоставляется перегрузкой метода [AddGroupShape](https://reference.aspose.com/slides/ru/net/aspose.slides.ishapecollection/addgroupshape/methods/1) интерфейса [IShapeCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/ishapecollection), который принимает объект [ISvgImage](https://reference.aspose.com/slides/ru/net/aspose.slides/isvgimage) в качестве первого аргумента. 

Ниже приведён пример кода C#, показывающий, как использовать этот метод для конвертации SVG‑файла в набор фигур: 

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Исходное имя SVG файла
string svgFileName = "sample.svg";

// Имя результирующего файла презентации
string outPptxPath = "presentation.pptx";

// Создать новую презентацию
using (IPresentation presentation = new Presentation())
{
    // Читать содержимое SVG файла
    string svgContent = File.ReadAllText(svgFileName);

    // Создать объект SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Получить размер слайда
    SizeF slideSize = presentation.SlideSize.Size;

    // Преобразовать SVG‑изображение в группу фигур и масштабировать до размеров слайда
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Сохранить презентацию в формате PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Добавление изображений в формате EMF на слайды**
Aspose.Slides for .NET позволяет генерировать изображения EMF из листов Excel с помощью Aspose.Cells и добавлять их на слайды презентации. 

Ниже приведён пример кода C#, показывающий, как это сделать: 

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Сохранить книгу в поток
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Замена изображений в коллекции изображений**

Aspose.Slides позволяет заменять изображения, хранящиеся в коллекции изображений презентации, включая изображения, используемые фигурами слайдов. В этом разделе описываются несколько способов обновления изображений в коллекции. Вы можете заменить изображение, используя необработанные байтовые данные, экземпляр [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) или другое изображение, уже существующее в коллекции. 

Выполните следующие шаги: 

1. Загрузите файл презентации, содержащий изображения, с помощью класса [Presentation](https://reference.aspose.com/slides/ru/net/aspose.slides/presentation/). 
2. Загрузите новое изображение из файла в массив байтов. 
3. Замените целевое изображение новым, используя массив байтов. 
4. Во втором подходе загрузите изображение в объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) и замените целевое изображение этим объектом. 
5. В третьем подходе замените целевое изображение изображением, которое уже существует в коллекции изображений презентации. 
6. Запишите изменённую презентацию в файл PPTX. 

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
С помощью бесплатного конвертера Aspose [Text to GIF](https://products.aspose.app/slides/ru/text-to-gif) вы можете легко анимировать текст и создавать GIF‑изображения из текста. 
{{% /alert %}}

## **FAQ**

**Сохраняется ли оригинальное разрешение изображения после вставки?**  
Да. Исходные пиксели сохраняются, но окончательный вид зависит от того, как [picture](/slides/ru/net/picture-frame/) масштабируется на слайде и от любой компрессии, применяемой при сохранении.  

**Как лучше всего заменить один и тот же логотип на десятках слайдов одновременно?**  
Разместите логотип на мастере слайда или в макете и замените его в коллекции изображений презентации — изменения будут распространены на все элементы, использующие этот ресурс.  

**Можно ли преобразовать вставленный SVG в редактируемые фигуры?**  
Да. Вы можете конвертировать SVG в группу фигур, после чего отдельные части становятся редактируемыми с помощью стандартных свойств фигур.  

**Как установить изображение в качестве фона сразу для нескольких слайдов?**  
[Назначьте изображение как фон](/slides/ru/net/presentation-background/) на мастере слайда или соответствующем макете — все слайды, использующие этот мастер/макет, унаследуют фон.  

**Как избежать избыточного разрастания файла презентации из‑за большого количества изображений?**  
Повторно используйте один ресурс изображения вместо дублирования, выбирайте разумные разрешения, применяйте компрессию при сохранении и размещайте повторяющиеся графические элементы в мастере, где это уместно.