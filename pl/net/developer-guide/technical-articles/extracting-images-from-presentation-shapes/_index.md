---
title: Wyodrębnianie obrazów z kształtów prezentacji w .NET
linktitle: Obraz z kształtu
type: docs
weight: 90
url: /pl/net/extracting-images-from-presentation-shapes/
keywords:
- wyodrębnić obraz
- pobrać obraz
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wyodrębnij obrazy z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET - szybkie, przyjazne kodowi rozwiązanie."
---
## **Przegląd**

Obrazy w prezentacji mogą występować w kilku typach kształtów: jako zwykłe ramki obrazu, jako wypełnienia obrazu zastosowane do kształtów, jako podglądowe obrazy obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększenia lub jako obrazy zagnieżdżone wewnątrz kształtów tabel, wykresów i SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej przez [ImageCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/imagecollection/) i [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) obiekty.

Jeśli potrzebujesz jedynie wyeksportować każdy zasób obrazu osadzony w prezentacji, iteruj przez `presentation.Images`. Ten artykuł koncentruje się na innym zadaniu: przeszukiwaniu kształtów w celu znalezienia, gdzie obrazy są używane na slajdach, aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (ramka obrazu, wypełnienie obrazu, podgląd mediów, podgląd OLE lub obraz powiększenia).

{{% alert title="Tip" color="primary" %}}
Użyj [IPPImage.BinaryData](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) aby zachować oryginalne zakodowane dane obrazu i typ pliku. Użyj [IPPImage.Image](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) wraz z [IImage.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) gdy chcesz znormalizować wyjście do określonego formatu, takiego jak PNG.
{{% /alert %}}

## **Wspólne Metody Pomocnicze**

Metody pomocnicze poniżej skracają przykłady. `SaveOriginalImage` zapisuje oryginalne osadzone bajty, wybiera bezpieczne rozszerzenie z typu MIME i pomija zduplikowane binaria obrazu przy użyciu skrótu SHA-256.

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

## **Eksportowanie Obrazów z Ramki Obrazu**

Użyj tego podejścia dla obrazów wstawionych jako samodzielne obiekty. [IPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe/) przechowuje swój obraz w `PictureFormat.Picture.Image`, co zwraca obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).

```c#
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

## **Eksportowanie Obrazów z Kształtów Wypełnionych Obrazem**

Kształty mogą używać obrazu jako swojego wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/), nie ma obrazu do wyodrębnienia z tego wypełnienia. Przykład poniżej obsługuje obiekty [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i zapisuje każdy obraz jako PNG przy użyciu [IPPImage.Image](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).

```c#
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

## **Eksportowanie Obrazów Podglądu z Ramki Obiektu OLE**

[IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe/) może mieć zamienny obraz, którego PowerPoint używa jako podgląd obiektu na slajdzie. Ten obraz jest dostępny poprzez `SubstitutePictureFormat.Picture.Image`. Wyodrębnienie tego obrazu daje podgląd, a nie osadzone treści pakietu OLE.

```c#
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

## **Eksportowanie Obrazów Podglądu z Ramki Wideo**

[IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) może również przechowywać obraz podglądu w `PictureFormat.Picture.Image`. Jest to plakat lub miniatura wyświetlana na slajdzie, a nie klatka zdekodowana ze strumienia wideo.

```c#
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

## **Eksportowanie Obrazów Podglądu z Ramki Audio**

[IAudioFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudioframe/) może przechowywać miniaturę w `PictureFormat.Picture.Image`. Jest to obraz wyświetlany dla obiektu audio na slajdzie.

```c#
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

## **Eksportowanie Obrazów z Obiektów Zoom**

[IZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/izoomframe/) i [ISectionZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/isectionzoomframe/) mogą używać własnych obrazów. Odczytaj `ZoomImage` z ramki zoom.

```c#
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

## **Eksportowanie Obrazów z Ramki Zoom Podsumowania**

[ISummaryZoomFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/isummaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnianych przez właściwość `ZoomImage` każdego elementu sekcji podsumowania.

```c#
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

## **Eksportowanie Obrazów z Kształtów Tabeli**

[ITable](https://reference.aspose.com/slides/pl/net/aspose.slides/itable/) jest kształtem. Obrazy w tabeli są zazwyczaj przechowywane jako wypełnienia obrazu w komórkach tabeli.

```c#
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

## **Eksportowanie Obrazów z Kształtów Wykresu**

[IChart](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/ichart/) jest kształtem. Przykład poniżej wyodrębnia obraz z wypełnienia obrazu obszaru wykresu.

```c#
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

## **Eksportowanie Obrazów z Kształtów SmartArt**

[ISmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/ismartart/) jest kształtem. W zależności od układu SmartArt, obrazy mogą być przechowywane w wypełnieniach punktów węzła lub w formatach wypełnienia kształtów węzłów.

```c#
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

## **Dołączanie Obrazów w Kształtach Grupowanych**

Kształty grupowane zawierają własne kolekcje kształtów. Wspólna metoda pomocnicza `EnumerateShapes` ma opcję `includeGroupedShapes`. Ustaw ją na `true`, gdy chcesz analizować kształty wewnątrz obiektów [IGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides/igroupshape/). Przykład poniżej wyodrębnia obrazy z ramek obrazu, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur klatek wideo i miniatur klatek audio. Aby dołączyć obrazy tabel, wykresów, SmartArt i podsumowania zoom, ponownie użyj specjalizowanej logiki wyodrębniania z poprzednich sekcji, zachowując tę samą rekurencyjną traversję kształtów.

```c#
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

## **Edge Cases i Praktyczne Uwagi**

- **Zduplikowane obrazy:** Wiele kształtów może odwoływać się do tego samego obrazu lub do osobnych obrazów o identycznych bajtach. Haszuj [IPPImage.BinaryData](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) przed zapisem plików, jeśli chcesz mieć jeden plik wyjściowy dla unikalnego obrazu.
- **Oryginalne dane vs. przetworzone wyjście:** Zapisywanie [IPPImage.BinaryData](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) zachowuje osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapisywanie [IPPImage.Image](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) przez [IImage.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) jest przydatne, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnień:** Kształty o wypełnieniu stałym, gradientowym, wzorowym i bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/) przed odczytem `PictureFillFormat`.
- **Kształty grupowane:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekurencyjnie analizuj [IGroupShape.Shapes](https://reference.aspose.com/slides/pl/net/aspose.slides/igroupshape/), gdy zależy ci na zawartości grup.
- **Podglądy obiektów OLE:** [IOleObjectFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe/) może udostępniać obraz podglądu poprzez `SubstitutePictureFormat`, ale jest to tylko podgląd slajdu, a nie osadzony plik w obiekcie OLE.
- **Miniatury klatek wideo:** [IVideoFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) może udostępniać obraz podglądu poprzez `PictureFormat`, ale jest to jedynie plakat wyświetlany na slajdzie, a nie klatka wyodrębniona z strumienia wideo.
- **Miniatury klatek audio:** [IAudioFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudioframe/) może udostępniać ikonę lub miniaturę poprzez `PictureFormat`; nie jest to osadzony dźwięk.
- **Obrazy zoom:** Kształty zoom slajdu, sekcji i podsumowania mogą używać własnych obiektów [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) poprzez `ZoomImage`.
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), ale ich obrazy są często przechowywane w zagnieżdżonych obiektach formatowania komórek, elementów wykresu lub węzłów SmartArt.
- **Obrazy przycięte lub przekształcone:** Dostęp do [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) daje zasób obrazu przechowywany w prezentacji. Nie renderuje on przycięć, przezroczystości, recoloringu, rotacji ani innych efektów wizualnych nakładanych przez kształt.

## **FAQ**

**Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów lub transformacji kształtu?**

Tak. Uzyskaj obiekt [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) i zapisz [IPPImage.BinaryData](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) na dysk. To zachowuje oryginalny zakodowany obraz przechowywany w prezentacji, a nie sposób, w jaki obraz jest renderowany na slajdzie.

**Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?**

Tak. Użyj [IPPImage.Image](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) aby uzyskać obiekt [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/), a następnie wywołaj [IImage.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) z [ImageFormat.Png](https://reference.aspose.com/slides/pl/net/aspose.slides/imageformat/). To konwertuje wyjście i może nie zachować oryginalnego typu pliku ani danych wektorowych.

**Jak uniknąć zapisywania tego samego obrazu więcej niż raz?**

Użyj skrótu [IPPImage.BinaryData](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) i przechowuj skróty w zbiorze. Jeśli nowy obraz ma skrót, który już istnieje, pomiń go lub zarejestruj kolejne odniesienie do istniejącego pliku wyjściowego.

**Dlaczego niektóre kształty nie generują obrazu?**

Ramki obrazu, kształty wypełnione obrazem, ramki obiektów OLE, ramki mediów, ramki zoom, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy poprzez zagnieżdżone obiekty formatowania, więc proste sprawdzenie `PictureFormat` lub `FillFormat` nie zawsze wystarcza.

**Czy mogę wyodrębnić miniaturę wyświetlaną dla klatki wideo?**

Tak. Użyj [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ivideoframe/) i odczytaj `PictureFormat.Picture.Image`. To wyodrębnia plakat przechowywany z klatką wideo, a nie klatkę wygenerowaną z pliku wideo.

**Jak mogę określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?**

Aspose.Slides nie przechowuje odwróconych linków od [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) do kształtów. Zbuduj mapowanie podczas traversji: za każdym razem, gdy znajdziesz odwołanie do obrazu, zapisz numer slajdu, ścieżkę kształtu oraz skrót obrazu lub element kolekcji.

**Czy mogę wyodrębnić obrazy osadzone w obiektach OLE, takie jak załączone dokumenty?**

Możesz wyodrębnić podgląd slajdu obiektu OLE z [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ioleobjectframe/). Jednak ten podgląd nie jest osadzonym dokumentem. Aby wyodrębnić obrazy z wnętrza pliku osadzonego, wyodrębnij dane OLE i zbadaj je przy użyciu narzędzi odpowiednich dla tego typu pliku.