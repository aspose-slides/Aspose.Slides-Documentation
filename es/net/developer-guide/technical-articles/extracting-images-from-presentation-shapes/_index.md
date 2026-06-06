---
title: Extraer imágenes de formas de presentación en .NET
linktitle: Imagen de forma
type: docs
weight: 90
url: /es/net/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para .NET: solución rápida y fácil de usar en código."
---
## **Resumen**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imagen ordinarios, como rellenos de imagen aplicados a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom o como imágenes incrustadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de [ImageCollection](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection/) y [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) objetos.

Si solo necesitas exportar cada recurso de imagen incrustado en una presentación, recorre `presentation.Images`. Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se utilizan imágenes en las diapositivas, de modo que los archivos guardados puedan conservar contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa de medios, vista previa OLE o imagen de zoom).

{{% alert title="Tip" color="primary" %}}
Utiliza [IPPImage.BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) para conservar los datos de imagen codificados originales y el tipo de archivo. Utiliza [IPPImage.Image](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) con [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) cuando quieras normalizar la salida a un formato específico como PNG.
{{% /alert %}}

## **Métodos Auxiliares Compartidos**

Los métodos auxiliares a continuación mantienen los ejemplos breves. `SaveOriginalImage` escribe los bytes incrustados originales, elige una extensión segura a partir del tipo MIME y omite binarios de imagen duplicados mediante hash SHA‑256.

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

## **Extraer Imágenes de Marcos de Imagen**

Utiliza este enfoque para imágenes insertadas como objetos independientes. Un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) almacena su imagen en `PictureFormat.Picture.Image`, que devuelve un objeto [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).

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

## **Extraer Imágenes de Formas con Relleno de Imagen**

Las formas pueden usar una imagen como su relleno. Comprueba primero el tipo de relleno de la forma: si no es [FillType.Picture](https://reference.aspose.com/slides/es/net/aspose.slides/filltype/), no hay imagen que extraer de ese relleno. El ejemplo a continuación maneja objetos [IAutoShape](https://reference.aspose.com/slides/es/net/aspose.slides/iautoshape/) y guarda cada imagen como PNG a través de [IPPImage.Image](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).

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

## **Extraer Imágenes de Vista Previa de Marcos de Objetos OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe/) puede tener una imagen sustituta que PowerPoint usa como vista previa del objeto en una diapositiva. Esta imagen está disponible mediante `SubstitutePictureFormat.Picture.Image`. Extraer esta imagen te brinda la vista previa, no el contenido del paquete OLE incrustado.

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

## **Extraer Imágenes de Vista Previa de Marcos de Vídeo**

Un [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) también puede almacenar una imagen de vista previa en `PictureFormat.Picture.Image`. Esta es la portada o miniatura mostrada en la diapositiva, no un fotograma decodificado del flujo de vídeo.

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

## **Extraer Imágenes de Vista Previa de Marcos de Audio**

Un [IAudioFrame](https://reference.aspose.com/slides/es/net/aspose.slides/iaudioframe/) puede almacenar una miniatura en `PictureFormat.Picture.Image`. Esta es la imagen mostrada para el objeto de audio en la diapositiva.

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

## **Extraer Imágenes de Objetos de Zoom**

Los objetos [IZoomFrame](https://reference.aspose.com/slides/es/net/aspose.slides/izoomframe/) y [ISectionZoomFrame](https://reference.aspose.com/slides/es/net/aspose.slides/isectionzoomframe/) pueden usar imágenes personalizadas. Lee `ZoomImage` del marco de zoom.

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

## **Extraer Imágenes de Marcos de Zoom de Resumen**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/es/net/aspose.slides/isummaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través de la propiedad `ZoomImage` de cada sección de zoom de resumen.

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

## **Extraer Imágenes de Formas de Tabla**

Una [ITable](https://reference.aspose.com/slides/es/net/aspose.slides/itable/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en las celdas de la tabla.

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

## **Extraer Imágenes de Formas de Gráfico**

Un [IChart](https://reference.aspose.com/slides/es/net/aspose.slides.charts/ichart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

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

## **Extraer Imágenes de Formas SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartart/) es una forma. Dependiendo del diseño de SmartArt, las imágenes pueden estar almacenadas en los rellenos de viñetas de los nodos o en los formatos de relleno de las formas de los nodos.

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

## **Incluir Imágenes Dentro de Formas Agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El auxiliar compartido `EnumerateShapes` tiene una opción `includeGroupedShapes`. Establécela en `true` cuando quieras inspeccionar las formas dentro de objetos [IGroupShape](https://reference.aspose.com/slides/es/net/aspose.slides/igroupshape/). El ejemplo a continuación extrae imágenes de marcos de imagen, formas con relleno de imagen, vistas previas de objetos OLE, miniaturas de fotogramas de vídeo y miniaturas de fotogramas de audio. Para incluir también imágenes de tabla, gráfico, SmartArt y zoom de resumen, reutiliza la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

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

## **Casos Extremos y Notas Prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Calcula un hash de [IPPImage.BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) antes de escribir los archivos si deseas un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar [IPPImage.BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) conserva los datos JPEG, PNG, GIF, SVG, EMF o WMF incrustados. Guardar [IPPImage.Image](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) mediante [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) resulta útil cuando quieres un formato de salida consistente.
- **Tipos de relleno no compatibles:** Las formas de relleno sólido, degradado, patrón o sin relleno no contienen un relleno de imagen. Verifica [FillType](https://reference.aspose.com/slides/es/net/aspose.slides/filltype/) antes de leer `PictureFillFormat`.
- **Formas agrupadas:** La colección de formas de nivel superior de la diapositiva no aplana los grupos. Inspecciona recursivamente [IGroupShape.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides/igroupshape/) cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [IOleObjectFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe/) puede exponer una imagen de vista previa mediante `SubstitutePictureFormat`, pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de fotogramas de vídeo:** Un [IVideoFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) puede exponer una imagen de vista previa mediante `PictureFormat`, pero esa imagen es solo la portada mostrada en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de fotogramas de audio:** Un [IAudioFrame](https://reference.aspose.com/slides/es/net/aspose.slides/iaudioframe/) puede exponer un icono o miniatura mediante `PictureFormat`; no es el dato de audio incrustado.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, zoom de sección y zoom de resumen pueden usar objetos [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) personalizados a través de `ZoomImage`.
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [IShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishape/), pero sus imágenes suelen almacenarse en objetos de formato anidados de celdas de tabla, elementos de gráfico o nodos de SmartArt.
- **Imágenes recortadas o transformadas:** Acceder a [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) te proporciona el recurso de imagen almacenado. No renderiza recortes, transparencias, recoloreado, rotación u otros efectos visuales aplicados por la forma.

## **Preguntas Frecuentes**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Accede al objeto [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) y escribe [IPPImage.BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) en disco. Esto conserva la imagen codificada original almacenada en la presentación, no la forma en que se renderiza en la diapositiva.

**¿Puedo exportar todas las imágenes extraídas como PNG?**

Sí. Utiliza [IPPImage.Image](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) para obtener un objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) y luego llama a [IImage.Save](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) con [ImageFormat.Png](https://reference.aspose.com/slides/es/net/aspose.slides/imageformat/). Esto convierte la salida y puede no preservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Utiliza un hash de [IPPImage.BinaryData](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) y guarda los hashes en un conjunto. Si una nueva imagen tiene un hash que ya existe, omítela o registra otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imagen, las formas con relleno de imagen, los marcos de objetos OLE, los marcos de medios, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden referenciar imágenes. Algunos tipos de forma exponen imágenes a través de objetos de formato anidados, por lo que una simple comprobación de `PictureFormat` o `FillFormat` de la forma no siempre es suficiente.

**¿Puedo extraer la miniatura mostrada para un fotograma de vídeo?**

Sí. Utiliza [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ivideoframe/) y lee `PictureFormat.Picture.Image`. Esto extrae la imagen de portada almacenada con el fotograma de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no guarda enlaces inversos de [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) a las formas. Construye un mapa durante el recorrido: cada vez que encuentres una referencia a una imagen, registra el número de diapositiva, la ruta de la forma y el hash o el elemento de la colección de la imagen.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puedes extraer la vista previa del objeto OLE desde [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ioleobjectframe/). Sin embargo, esa vista previa no es el documento incrustado en sí. Para extraer imágenes dentro del archivo incrustado, extrae los datos OLE y examínalos con herramientas apropiadas para ese tipo de archivo.