---
title: Estrai immagini da forme della presentazione in .NET
linktitle: Immagine da Forma
type: docs
weight: 90
url: /it/net/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Estrai immagini da forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per .NET - soluzione rapida e orientata al codice."
---
## **Panoramica**

Le immagini in una presentazione possono apparire in diversi tipi di forma: come normali riquadri immagine, come riempimenti immagine applicati alle forme, come immagini di anteprima di oggetti OLE, come miniature di fotogrammi video o audio, come immagini di zoom, o come immagini annidate all'interno di tabelle, grafici e forme SmartArt. Aspose.Slides memorizza queste immagini nella raccolta di immagini della presentazione, esposta tramite gli oggetti [ImageCollection](https://reference.aspose.com/slides/it/net/aspose.slides/imagecollection/) e [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).

Se hai bisogno solo di esportare ogni risorsa immagine incorporata in una presentazione, itera su `presentation.Images`. Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini vengono utilizzate nelle diapositive, in modo che i file salvati possano conservare contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (riquadro immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Tip" color="primary" %}}
Usa [IPPImage.BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) per conservare i dati immagine codificati originali e il tipo di file. Usa [IPPImage.Image](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) con [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) quando desideri normalizzare l'output in un formato specifico, ad esempio PNG.
{{% /alert %}}

## **Metodi di supporto condivisi**

I metodi di supporto di seguito mantengono gli esempi brevi. `SaveOriginalImage` scrive i byte originali incorporati, sceglie un’estensione sicura dal tipo MIME e salta i binari immagine duplicati tramite hash SHA-256.

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

## **Estrai immagini da riquadri immagine**

Usa questo approccio per le immagini inserite come oggetti autonomi. Un [IPictureFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ipictureframe/) memorizza la sua immagine in `PictureFormat.Picture.Image`, che restituisce un oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).

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

## **Estrai immagini da forme riempite con immagine**

Le forme possono usare un’immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType.Picture](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/), non c’è alcuna immagine da estrarre da quel riempimento. L’esempio seguente gestisce gli oggetti [IAutoShape](https://reference.aspose.com/slides/it/net/aspose.slides/iautoshape/) e salva ogni immagine come PNG tramite [IPPImage.Image](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/).

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

## **Estrai immagini di anteprima da riquadri oggetto OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe/) può avere un’immagine sostitutiva che PowerPoint usa come anteprima dell’oggetto su una diapositiva. Questa immagine è disponibile tramite `SubstitutePictureFormat.Picture.Image`. Estrarre questa immagine fornisce l’anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai immagini di anteprima da fotogrammi video**

Un [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) può anche memorizzare un’immagine di anteprima in `PictureFormat.Picture.Image`. Questa è il poster o la miniatura mostrata sulla diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai immagini di anteprima da fotogrammi audio**

Un [IAudioFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iaudioframe/) può memorizzare una miniatura in `PictureFormat.Picture.Image`. Questa è l’immagine mostrata per l’oggetto audio sulla diapositiva.

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

## **Estrai immagini da oggetti Zoom**

[IZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/izoomframe/) e [ISectionZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/isectionzoomframe/) possono usare immagini personalizzate. Leggi `ZoomImage` dal riquadro zoom.

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

## **Estrai immagini da riquadri riepilogo Zoom**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/it/net/aspose.slides/isummaryzoomframe/) è anch'esso una forma. I suoi elementi di sezione possono usare immagini personalizzate, esposte tramite la proprietà `ZoomImage` di ciascuna sezione riepilogo zoom.

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

## **Estrai immagini da forme tabella**

Un [ITable](https://reference.aspose.com/slides/it/net/aspose.slides/itable/) è una forma. Le immagini in una tabella sono solitamente memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai immagini da forme grafico**

Un [IChart](https://reference.aspose.com/slides/it/net/aspose.slides.charts/ichart/) è una forma. L’esempio seguente estrae un’immagine dal riempimento immagine dell’area del grafico.

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

## **Estrai immagini da forme SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/it/net/aspose.slides.smartart/ismartart/) è una forma. A seconda del layout SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi immagini all'interno di forme raggruppate**

Le forme raggruppate contengono le proprie collezioni di forme. Il metodo di supporto condiviso `EnumerateShapes` ha un’opzione `includeGroupedShapes`. Impostala su `true` quando vuoi ispezionare le forme all’interno di oggetti [IGroupShape](https://reference.aspose.com/slides/it/net/aspose.slides/igroupshape/). L’esempio seguente estrae immagini da riquadri immagine, forme riempite con immagine, anteprime di oggetti OLE, miniature di fotogrammi video e miniature di fotogrammi audio. Per includere anche le immagini di tabelle, grafici, SmartArt e zoom riepilogativo, riutilizza la logica di estrazione specializzata delle sezioni precedenti mantenendo lo stesso attraversamento ricorsivo delle forme.

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

## **Casi limite e note pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Esegui un hash di [IPPImage.BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs. output convertito:** salvare [IPPImage.BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) conserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare [IPPImage.Image](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) tramite [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** le forme a riempimento solido, gradiente, motivo o senza riempimento non contengono un’immagine di riempimento. Controlla [FillType](https://reference.aspose.com/slides/it/net/aspose.slides/filltype/) prima di leggere `PictureFillFormat`.
- **Forme raggruppate:** la collezione di forme della diapositiva di livello superiore non appiattisce i gruppi. Ispeziona ricorsivamente [IGroupShape.Shapes](https://reference.aspose.com/slides/it/net/aspose.slides/igroupshape/) quando il contenuto raggruppato è importante.
- **Anteprime oggetti OLE:** un [IOleObjectFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe/) può esporre un’immagine di anteprima tramite `SubstitutePictureFormat`, ma quell’immagine è solo l’anteprima della diapositiva. Non è il file incorporato all’interno dell’oggetto OLE.
- **Miniature fotogrammi video:** un [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) può esporre un’immagine di anteprima tramite `PictureFormat`, ma quell’immagine è solo il poster mostrato sulla diapositiva. Non è estratta dal flusso video.
- **Miniature fotogrammi audio:** un [IAudioFrame](https://reference.aspose.com/slides/it/net/aspose.slides/iaudioframe/) può esporre un’icona o miniatura tramite `PictureFormat`; non è il dato audio incorporato.
- **Immagini Zoom:** le forme zoom di diapositiva, sezione e riepilogo possono usare oggetti [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) personalizzati tramite `ZoomImage`.
- **Modelli di forma annidati:** gli oggetti tabella, grafico e SmartArt implementano [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape/), ma le loro immagini sono spesso memorizzate in oggetti di formattazione annidati di celle, elementi del grafico o nodi SmartArt.
- **Immagini ritagliate o trasformate:** accedere a [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) ti restituisce la risorsa immagine memorizzata. Non rende i ritagli, la trasparenza, il recolor, la rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l’immagine originale senza ritagli, effetti o trasformazioni della forma?**  
Sì. Accedi all’oggetto [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) e scrivi [IPPImage.BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) su disco. Questo conserva l’immagine originale codificata memorizzata nella presentazione, non il modo in cui l’immagine viene renderizzata sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**  
Sì. Usa [IPPImage.Image](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) per ottenere un oggetto [IImage](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) e poi chiama [IImage.Save](https://reference.aspose.com/slides/it/net/aspose.slides/iimage/) con [ImageFormat.Png](https://reference.aspose.com/slides/it/net/aspose.slides/imageformat/). Questo converte l’output e potrebbe non conservare il tipo di file originale o i dati vettoriali.

**Come evito di salvare la stessa immagine più di una volta?**  
Usa un hash di [IPPImage.BinaryData](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) e tieni gli hash in un set. Se una nuova immagine ha un hash già presente, salta il salvataggio o registra un altro riferimento al file di output esistente.

**Perché alcune forme non producono un’immagine?**  
I riquadri immagine, le forme riempite con immagine, i riquadri oggetto OLE, i riquadri multimediali, le forme zoom, le tabelle, i grafici e gli oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono le immagini tramite oggetti di formattazione annidati, quindi un semplice controllo su `PictureFormat` o su `FillFormat` della forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per un fotogramma video?**  
Sì. Usa [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) e leggi `PictureFormat.Picture.Image`. Questo estrae l’immagine poster memorizzata con il fotogramma video, non un fotogramma generato dal file video.

**Come posso determinare quali forme usano una specifica immagine dalla raccolta di immagini della presentazione?**  
Aspose.Slides non memorizza collegamenti inversi da [IPPImage](https://reference.aspose.com/slides/it/net/aspose.slides/ippimage/) a forme. Costruisci una mappatura durante l’attraversamento: ogni volta che trovi un riferimento a un’immagine, registra il numero della diapositiva, il percorso della forma e l’hash o l’elemento della raccolta.

**Posso estrarre immagini incorporate all’interno di oggetti OLE, come documenti allegati?**  
Puoi estrarre l’anteprima della diapositiva dell’oggetto OLE da [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/it/net/aspose.slides/ioleobjectframe/). Tuttavia, quell’anteprima non è il documento incorporato stesso. Per estrarre immagini dall’interno del file incorporato, devi estrarre i dati OLE e ispezionarli con gli strumenti appropriati per quel tipo di file.