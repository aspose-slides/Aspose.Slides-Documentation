---
title: Bilder aus Präsentationsformen in .NET extrahieren
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/net/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET - schnelle, programmfreundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in verschiedenen Formtypen auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als Vorschau‑Bilder von OLE‑Objekten, als Miniatur‑Bilder von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen, Diagrammen und SmartArt‑Formen verschachtelte Bilder. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über die Objekte [ImageCollection](https://reference.aspose.com/slides/de/net/aspose.slides/imagecollection/) und [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) zur Verfügung gestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren müssen, iterieren Sie über `presentation.Images`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um zu ermitteln, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien Kontextinformationen wie Foliennummer, Position der Form und Quelltyp (Bildrahmen, Füllungsbild, Medienvorschau, OLE‑Vorschau oder Zoom‑Bild) behalten.

{{% alert title="Tip" color="primary" %}}
Verwenden Sie [IPPImage.BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/), um die ursprünglich codierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie [IPPImage.Image](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) mit [IImage.Save](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/), wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die Hilfsmethoden unten halten die Beispiele kurz. `SaveOriginalImage` schreibt die ursprünglich eingebetteten Bytes, wählt eine sichere Erweiterung basierend auf dem MIME‑Typ und überspringt doppelte Bild‑Binärdaten anhand eines SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [IPictureFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ipictureframe/) speichert sein Bild in `PictureFormat.Picture.Image`, das ein [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn es nicht [FillType.Picture](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das untenstehende Beispiel behandelt [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/)‑Objekte und speichert jedes Bild als PNG über [IPPImage.Image](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/).

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

## **Vorschau‑Bilder aus OLE‑Objekt‑Frames extrahieren**

[IOleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `SubstitutePictureFormat.Picture.Image` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschau‑Bild, nicht den eingebetteten OLE‑Paketinhalt.

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

## **Vorschau‑Bilder aus Video‑Frames extrahieren**

[IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/) kann ebenfalls ein Vorschau‑Bild in `PictureFormat.Picture.Image` speichern. Dies ist das Poster‑ oder Miniatur‑Bild, das auf der Folie angezeigt wird, nicht ein aus dem Videostrom decodiertes Bild.

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

## **Vorschau‑Bilder aus Audio‑Frames extrahieren**

[IAudioFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iaudioframe/) kann ein Miniaturbild in `PictureFormat.Picture.Image` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[IZoomFrame](https://reference.aspose.com/slides/de/net/aspose.slides/izoomframe/) und [ISectionZoomFrame](https://reference.aspose.com/slides/de/net/aspose.slides/isectionzoomframe/) können benutzerdefinierte Bilder verwenden. Lesen Sie `ZoomImage` aus dem Zoom‑Frame.

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

[ISummaryZoomFrame](https://reference.aspose.com/slides/de/net/aspose.slides/isummaryzoomframe/) ist ebenfalls eine Form. Die Abschnitte können benutzerdefinierte Bilder verwenden, die über die `ZoomImage`‑Eigenschaft jedes Summary‑Zoom‑Abschnitts zugänglich sind.

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

## **Bilder aus Tabellen‑Formen extrahieren**

[ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/) ist eine Form. Bilder in einer Tabelle werden meist als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagramm‑Formen extrahieren**

[IChart](https://reference.aspose.com/slides/de/net/aspose.slides.charts/ichart/) ist eine Form. Das untenstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

[ISmartArt](https://reference.aspose.com/slides/de/net/aspose.slides.smartart/ismartart/) ist ein Objekt und zugleich eine Form. Je nach SmartArt‑Layout können Bilder in Aufzählungs‑Füllungen von Knoten oder in den Füllungsformaten von Knotenkörpern gespeichert sein.

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

## **Bilder in gruppierten Formen einbeziehen**

Gruppierte Formen besitzen eigene Formsammlungen. Der gemeinsam genutzte Hilfs‑Parser `EnumerateShapes` verfügt über die Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [IGroupShape](https://reference.aspose.com/slides/de/net/aspose.slides/igroupshape/)‑Objekten untersuchen möchten. Das untenstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturbildern und Audio‑Frame‑Miniaturbildern. Um zusätzlich Bilder aus Tabellen, Diagrammen, SmartArt und Summary‑Zoom‑Formen zu berücksichtigen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten und behalten dabei die gleiche rekursive Form‑Durchquerung bei.

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

## **Randfälle und praktische Hinweise**

- **Duplizierte Bilder:** Mehrere Formen können dasselbe Bild oder verschiedene Bilder mit identischen Bytes referenzieren. Bilden Sie einen Hash von [IPPImage.BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) bevor Sie Dateien schreiben, wenn Sie pro eindeutigem Bild nur eine Ausgabedatei haben möchten.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [IPPImage.BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) bewahrt die eingebetteten JPEG-, PNG-, GIF-, SVG-, EMF- oder WMF-Daten. Das Speichern von [IPPImage.Image](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) über [IImage.Save](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) ist nützlich, wenn Sie ein einheitliches Ausgabeformat benötigen.
- **Nicht unterstützte Fülltypen:** Solide, Verlauf-, Muster‑ und Keine‑Füllung‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) bevor Sie `PictureFillFormat` lesen.
- **Gruppierte Formen:** Die oberste Formsammlung der Folie flacht Gruppen nicht ab. Untersuchen Sie rekursiv [IGroupShape.Shapes](https://reference.aspose.com/slides/de/net/aspose.slides/igroupshape/) wenn gruppierter Inhalt relevant ist.
- **OLE‑Objekt‑Vorschauen:** Ein [IOleObjectFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe/) kann ein Vorschau‑Bild über `SubstitutePictureFormat` bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die im OLE‑Objekt eingebettete Datei.
- **Video‑Frame‑Miniaturbilder:** Ein [IVideoFrame](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/) kann ein Vorschau‑Bild über `PictureFormat` bereitstellen, aber dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostrom extrahiert.
- **Audio‑Frame‑Miniaturbilder:** Ein [IAudioFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iaudioframe/) kann ein Symbol oder Miniaturbild über `PictureFormat` bereitstellen; es ist nicht das eingebettete Audiodaten.
- **Zoom‑Bilder:** Slide‑Zoom, Section‑Zoom und Summary‑Zoom‑Formen können benutzerdefinierte [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Objekte über `ZoomImage` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) liefert die gespeicherte Bildressource. Es wird das Zuschneiden, Transparenz, Umfärben, Drehen oder andere visuelle Effekte, die von der Form angewendet werden, nicht darstellen.

## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Greifen Sie auf das [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/)‑Objekt zu und schreiben Sie [IPPImage.BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) auf die Festplatte. Dadurch wird das ursprünglich codierte Bild in der Präsentation erhalten, nicht die Art und Weise, wie das Bild auf der Folie dargestellt wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie [IPPImage.Image](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/), um ein [IImage](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/)‑Objekt zu erhalten, und rufen Sie dann [IImage.Save](https://reference.aspose.com/slides/de/net/aspose.slides/iimage/) mit [ImageFormat.Png](https://reference.aspose.com/slides/de/net/aspose.slides/imageformat/) auf. Dies konvertiert die Ausgabe und bewahrt möglicherweise nicht den ursprünglichen Dateityp oder Vektordaten.

**Wie vermeide ich, dass dasselbe Bild mehrmals gespeichert wird?**

Verwenden Sie einen Hash von [IPPImage.BinaryData](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) und speichern Sie die Hashes in einer Menge. Hat ein neues Bild einen bereits vorhandenen Hash, überspringen Sie es oder vermerken Sie eine weitere Referenz zur bestehenden Ausgabedatei.

**Warum erzeugen einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Formtypen stellen Bilder über verschachtelte Formatierungsobjekte bereit, sodass ein einfacher `PictureFormat`‑ oder `FillFormat`‑Check nicht immer ausreicht.

**Kann ich das für einen Video‑Frame angezeigte Miniaturbild extrahieren?**

Ja. Verwenden Sie [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ivideoframe/) und lesen Sie `PictureFormat.Picture.Image`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, das aus der Videodatei generiert wurde.

**Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Bildsammlung der Präsentation verwenden?**

Aspose.Slides speichert keine Rückverweise von [IPPImage](https://reference.aspose.com/slides/de/net/aspose.slides/ippimage/) zu Formen. Erstellen Sie während der Durchquerung eine Zuordnung: Wann immer Sie eine Bildreferenz finden, notieren Sie die Foliennummer, den Form‑Pfad und den Bild‑Hash bzw. das Sammlungs‑Element.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Folien‑Vorschau des OLE‑Objekts über [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ioleobjectframe/) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten auslesen und mit geeigneten Tools für den jeweiligen Dateityp untersuchen.