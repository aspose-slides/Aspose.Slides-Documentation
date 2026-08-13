---
title: Извлечение изображений из фигур презентации в .NET
linktitle: Изображение из фигуры
type: docs
weight: 90
url: /ru/net/extracting-images-from-presentation-shapes/
keywords:
- извлекать изображение
- получать изображение
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Извлекайте изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для .NET — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: как обычные рамки рисунков, как заливка рисунками, применяемая к фигурам, как изображения‑предпросмотры OLE‑объектов, как миниатюры видеокадров или аудиокадров, как изображения масштабирования или как изображения, вложенные в таблицы, диаграммы и фигуры SmartArt. Aspose.Slides хранит эти изображения в коллекции изображений презентации, доступной через объекты [ImageCollection](https://reference.aspose.com/slides/ru/net/aspose.slides/imagecollection/) и [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).

Если вам нужно только экспортировать каждый ресурс изображения, встроенный в презентацию, пройдите по `presentation.Images`. Эта статья сосредоточена на другой задаче: обходе фигур для поиска мест использования изображений на слайдах, чтобы сохранённые файлы могли сохранять полезный контекст, такой как номер слайда, положение фигуры и тип источника (рамка рисунка, изображение‑заливка, медиа‑предпросмотр, OLE‑предпросмотр или изображение масштабирования).

{{% alert title="Tip" color="info" %}}
Используйте [IPPImage.BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) для сохранения оригинальных закодированных данных изображения и типа файла. Используйте [IPPImage.Image](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) совместно с [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) когда требуется нормализовать вывод в конкретный формат, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже приведённые вспомогательные методы делают примеры короче. `SaveOriginalImage` записывает оригинальные встроенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные данные изображений по хэшу SHA‑256.

```c#
using Aspose.Slides;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

private static bool SaveOriginalImage(
    IPPImage image,
    string outputDirectory,
    string fileNameBase,
    ISet<string> savedImageHashes)
{
    byte[] imageData = image.BinaryData;
    string imageHash = GetSha256Hash(imageData);
    if (!savedImageHashes.Add(imageHash))
    {
        return false;
    }

    string extension = GetExtensionFromContentType(image.ContentType);
    string fileName = $"{fileNameBase}.{extension}";
    string outputPath = Path.Combine(outputDirectory, fileName);
    File.WriteAllBytes(outputPath, imageData);
    return true;
}

private static void SaveImageAsPng(IPPImage image, string outputDirectory, string fileNameBase)
{
    string fileName = $"{fileNameBase}.png";
    string outputPath = Path.Combine(outputDirectory, fileName);

    using (IImage outputImage = image.Image)
    {
        outputImage.Save(outputPath, ImageFormat.Png);
    }
}

private static IPPImage GetPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.FillType != FillType.Picture)
    {
        return null;
    }

    return fillFormat.PictureFillFormat.Picture.Image;
}

private static IEnumerable<(IShape Shape, string NamePart)> EnumerateShapes(
    IShapeCollection shapes,
    string prefix,
    bool includeGroupedShapes)
{
    int shapeCount = shapes.Count;
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes[shapeIndex];
        int displayIndex = shapeIndex + 1;
        string shapeNamePart = $"{prefix}_shape_{displayIndex}";
        yield return (shape, shapeNamePart);

        if (includeGroupedShapes && shape is IGroupShape groupShape)
        {
            foreach ((IShape Shape, string NamePart) childShape in EnumerateShapes(
                groupShape.Shapes,
                shapeNamePart,
                includeGroupedShapes))
            {
                yield return childShape;
            }
        }
    }
}

private static string GetSha256Hash(byte[] data)
{
    using (SHA256 sha256 = SHA256.Create())
    {
        byte[] hash = sha256.ComputeHash(data);
        return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
    }
}

private static string GetExtensionFromContentType(string contentType)
{
    if (string.IsNullOrWhiteSpace(contentType))
    {
        return "bin";
    }

    string mediaType = contentType.Split(';')[0].Trim().ToLowerInvariant();
    switch (mediaType)
    {
        case "image/jpeg":
            return "jpg";
        case "image/png":
            return "png";
        case "image/gif":
            return "gif";
        case "image/bmp":
            return "bmp";
        case "image/tiff":
            return "tiff";
        case "image/x-emf":
        case "image/emf":
            return "emf";
        case "image/x-wmf":
        case "image/wmf":
            return "wmf";
        case "image/svg+xml":
            return "svg";
        default:
            if (mediaType.StartsWith("image/"))
            {
                string extension = mediaType.Substring("image/".Length);
                return MakeSafeFileNamePart(extension);
            }

            return "bin";
    }
}

private static string MakeSafeFileNamePart(string value)
{
    foreach (char invalidCharacter in Path.GetInvalidFileNameChars())
    {
        value = value.Replace(invalidCharacter, '_');
    }

    return value;
}
```

## **Извлечение изображений из рамок рисунков**

Используйте этот подход для изображений, вставленных как отдельные объекты. Объект [IPictureFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ipictureframe/) хранит своё изображение в `PictureFormat.Picture.Image`, который возвращает объект [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "extracted-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
            }
        }
    }
}
```

## **Извлечение изображений из фигур, залитых изображениями**

Фигуры могут использовать рисунок в качестве заливки. Сначала проверьте тип заливки фигуры: если это не [FillType.Picture](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/), изображение извлекать нечего. Пример ниже работает с объектами [IAutoShape](https://reference.aspose.com/slides/ru/net/aspose.slides/iautoshape/) и сохраняет каждое изображение как PNG через [IPPImage.Image](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/).

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "shape-fill-images");
Directory.CreateDirectory(outputDirectory);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveImageAsPng(image, outputDirectory, item.NamePart);
                }
            }
        }
    }
}
```

## **Извлечение предварительных изображений из рамок OLE‑объектов**

Объект [IOleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe/) может иметь заменяющее изображение, которое PowerPoint использует как предварительный просмотр объекта на слайде. Это изображение доступно через `SubstitutePictureFormat.Picture.Image`. Извлекая эту картинку, вы получаете предварительный просмотр, а не содержимое встроенного OLE‑пакета.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "ole-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Извлечение предварительных изображений из видеокадров**

Объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) также может хранить предварительное изображение в `PictureFormat.Picture.Image`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "video-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Извлечение предварительных изображений из аудиокадров**

Объект [IAudioFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudioframe/) может хранить миниатюру в `PictureFormat.Picture.Image`. Это изображение, показываемое для аудиобъекта на слайде.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "audio-preview-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Извлечение изображений из объектов Zoom**

Фигуры [IZoomFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/izoomframe/) и [ISectionZoomFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/isectionzoomframe/) могут использовать пользовательские изображения. Читайте `ZoomImage` из рамки масштабирования.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is IZoomFrame zoomFrame && zoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_zoom";
                SaveOriginalImage(zoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

            if (item.Shape is ISectionZoomFrame sectionZoomFrame && sectionZoomFrame.ZoomImage != null)
            {
                string fileNameBase = $"{item.NamePart}_section_zoom";
                SaveOriginalImage(sectionZoomFrame.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                continue;
            }

        }
    }
}
```

## **Извлечение изображений из рамок Summary Zoom**

Объект [ISummaryZoomFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/isummaryzoomframe/) также является фигурой. Его элементы разделов могут использовать пользовательские изображения, доступные через свойство `ZoomImage` каждого раздела summary zoom.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "summary-zoom-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: false))
        {
            if (item.Shape is ISummaryZoomFrame summaryZoomFrame)
            {
                int sectionCount = summaryZoomFrame.SummaryZoomCollection.Count;
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.SummaryZoomCollection[sectionIndex];
                    if (section.ZoomImage != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        string fileNameBase = $"{item.NamePart}_summary_zoom_{displayIndex}";
                        SaveOriginalImage(section.ZoomImage, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
```

## **Извлечение изображений из фигур таблиц**

Объект [ITable](https://reference.aspose.com/slides/ru/net/aspose.slides/itable/) является фигурой. Изображения в таблице обычно хранятся как заливки рисунками в ячейках таблицы.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "table-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is ITable table)
            {
                int rowCount = table.Rows.Count;
                int columnCount = table.Columns.Count;
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table[columnIndex, rowIndex];
                        IPPImage image = GetPictureFillImage(cell.CellFormat.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_cell_{rowIndex + 1}_{columnIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Извлечение изображений из фигур диаграмм**

Объект [IChart](https://reference.aspose.com/slides/ru/net/aspose.slides.charts/ichart/) является фигурой. Пример ниже извлекает изображение из заливки рисунком области диаграммы.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "chart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.Charts.IChart chart)
            {
                IFillFormat fillFormat = chart.FillFormat;
                IPPImage image = GetPictureFillImage(fillFormat);
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_chart_area";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Извлечение изображений из фигур SmartArt**

Объект [ISmartArt](https://reference.aspose.com/slides/ru/net/aspose.slides.smartart/ismartart/) является фигурой. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "smartart-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
            {
                int nodeCount = smartArt.AllNodes.Count;
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndex];
                    IPPImage bulletImage = GetPictureFillImage(node.BulletFillFormat);
                    if (bulletImage != null)
                    {
                        string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_bullet";
                        SaveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.Shapes.Count;
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        var nodeShape = node.Shapes[nodeShapeIndex];
                        IPPImage image = GetPictureFillImage(nodeShape.FillFormat);
                        if (image != null)
                        {
                            string fileNameBase = $"{item.NamePart}_smartart_node_{nodeIndex + 1}_shape_{nodeShapeIndex + 1}";
                            SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
```

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `EnumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, когда нужно проверять фигуры внутри объектов [IGroupShape](https://reference.aspose.com/slides/ru/net/aspose.slides/igroupshape/). Пример ниже извлекает изображения из рамок рисунков, фигур, залитых рисунками, предварительных просмотров OLE‑объектов, миниатюр видеокадров и аудиокадров. Чтобы включить также изображения таблиц, диаграмм, SmartArt и summary zoom, переиспользуйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

```c#
using Aspose.Slides;

string inputPath = "sample.pptx";
string outputDirectory = Path.Combine(Environment.CurrentDirectory, "all-shape-images");
Directory.CreateDirectory(outputDirectory);

var savedImageHashes = new HashSet<string>(StringComparer.Ordinal);

using (Presentation presentation = new Presentation(inputPath))
{
    foreach (ISlide slide in presentation.Slides)
    {
        string slidePrefix = $"slide_{slide.SlideNumber}";
        foreach ((IShape Shape, string NamePart) item in EnumerateShapes(
            slide.Shapes,
            slidePrefix,
            includeGroupedShapes: true))
        {
            if (item.Shape is IPictureFrame pictureFrame)
            {
                IPPImage image = pictureFrame.PictureFormat.Picture.Image;
                SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                continue;
            }

            if (item.Shape is IAutoShape autoShape)
            {
                IPPImage image = GetPictureFillImage(autoShape.FillFormat);
                if (image != null)
                {
                    SaveOriginalImage(image, outputDirectory, item.NamePart, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IOleObjectFrame oleObjectFrame)
            {
                IPPImage image = oleObjectFrame.SubstitutePictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_ole_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IVideoFrame videoFrame)
            {
                IPPImage image = videoFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_video_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (item.Shape is IAudioFrame audioFrame)
            {
                IPPImage image = audioFrame.PictureFormat.Picture.Image;
                if (image != null)
                {
                    string fileNameBase = $"{item.NamePart}_audio_preview";
                    SaveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
```

## **Особые случаи и практические замечания**

- **Дублирующие изображения:** Несколько фигур могут ссылаться на одно и то же изображение или на отдельные изображения с идентичными байтами. Хешируйте [IPPImage.BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) перед записью файлов, если хотите один файл вывода на каждое уникальное изображение.
- **Оригинальные данные vs. преобразованный вывод:** Сохранение [IPPImage.BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) сохраняет встроенные JPEG, PNG, GIF, SVG, EMF или WMF данные. Сохранение [IPPImage.Image](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) через [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) удобно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заливки:** Сплошные, градиентные, узорные и беззаливные фигуры не содержат рисунка‑заливки. Проверьте [FillType](https://reference.aspose.com/slides/ru/net/aspose.slides/filltype/) перед чтением `PictureFillFormat`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не разворачивает группы. Рекурсивно проверяйте [IGroupShape.Shapes](https://reference.aspose.com/slides/ru/net/aspose.slides/igroupshape/), когда важен содержимое групп.
- **Предпросмотр OLE‑объектов:** Объект [IOleObjectFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe/) может предоставлять изображение‑предпросмотр через `SubstitutePictureFormat`, но это лишь предварительный просмотр слайда, а не встроенный файл внутри OLE‑объекта.
- **Миниатюры видеокадров:** Объект [IVideoFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) может предоставлять изображение‑предпросмотр через `PictureFormat`, но это лишь постер, отображаемый на слайде, а не кадр, извлечённый из видеопотока.
- **Миниатюры аудиокадров:** Объект [IAudioFrame](https://reference.aspose.com/slides/ru/net/aspose.slides/iaudioframe/) может предоставлять значок или миниатюру через `PictureFormat`; это не встроенные аудиоданные.
- **Изображения Zoom:** Фигуры slide zoom, section zoom и summary zoom могут использовать пользовательские объекты [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) через `ZoomImage`.
- **Вложенные модели фигур:** Объекты таблиц, диаграмм и SmartArt реализуют [IShape](https://reference.aspose.com/slides/ru/net/aspose.slides/ishape/), но их изображения часто хранятся в вложенных объектах форматирования ячеек таблицы, элементов диаграммы или узлов SmartArt.
- **Обрезанные или трансформированные картинки:** Доступ к [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) даёт хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перекраску, поворот или другие визуальные эффекты, применённые фигурой.

## **FAQ**

### Можно ли извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?

Да. Обратитесь к объекту [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) и запишите [IPPImage.BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не то, как оно отображается на слайде.

### Можно ли экспортировать каждое извлечённое изображение как PNG?

Да. Используйте [IPPImage.Image](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) чтобы получить объект [IImage](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/), а затем вызовите [IImage.Save](https://reference.aspose.com/slides/ru/net/aspose.slides/iimage/) с параметром [ImageFormat.Png](https://reference.aspose.com/slides/ru/net/aspose.slides/imageformat/). Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

### Как избежать многократного сохранения одного и того же изображения?

Используйте хеш от [IPPImage.BinaryData](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) и храните хеши в наборе. Если новое изображение имеет уже существующий хеш, пропустите его или запишите другую ссылку на существующий файл вывода.

### Почему некоторые фигуры не дают изображения?

Рамки рисунков, фигуры, залитые рисунками, рамки OLE‑объектов, медиа‑рамки, рамки zoom, таблицы, диаграммы и объекты SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простой проверка `PictureFormat` или `FillFormat` может быть недостаточной.

### Можно ли извлечь миниатюру, показываемую для видеокадра?

Да. Используйте [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ivideoframe/) и прочитайте `PictureFormat.Picture.Image`. Это извлекает постер‑изображение, хранящееся вместе с видеокадром, а не кадр, полученный из видеофайла.

### Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?

Aspose.Slides не хранит обратные ссылки от [IPPImage](https://reference.aspose.com/slides/ru/net/aspose.slides/ippimage/) к фигурам. Постройте сопоставление во время обхода: каждый раз, когда находите ссылку на изображение, фиксируйте номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

### Можно ли извлечь изображения, встроенные в OLE‑объекты, например прикреплённые документы?

Вы можете извлечь предварительный просмотр OLE‑объекта из [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/ru/net/aspose.slides/ioleobjectframe/). Однако этот предварительный просмотр не является самим вложенным документом. Чтобы извлечь изображения изнутри вложенного файла, извлеките OLE‑данные и проанализируйте их специализированными инструментами для соответствующего типа файла.