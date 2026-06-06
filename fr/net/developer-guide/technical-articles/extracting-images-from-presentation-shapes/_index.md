---
title: Extraire des images des formes de présentation en .NET
linktitle: Image depuis la forme
type: docs
weight: 90
url: /fr/net/extracting-images-from-presentation-shapes/
keywords:
- extraire image
- récupérer image
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Extraire des images des formes dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET - solution rapide et conviviale pour le code."
---
## **Vue d'ensemble**

Les images d’une présentation peuvent apparaître sous plusieurs types de forme : cadres d’image ordinaires, remplissages d’image appliqués aux formes, images d’aperçu d’objets OLE, miniatures de cadres vidéo ou audio, images de zoom, ou images imbriquées dans les formes tableau, graphique et SmartArt. Aspose.Slides stocke ces images dans la collection d’images de la présentation, exposée via les objets [ImageCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/imagecollection/) et [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).

Si vous avez seulement besoin d’exporter chaque ressource image intégrée dans une présentation, parcourez `presentation.Images`. Cet article se concentre sur une tâche différente : parcourir les formes pour trouver où les images sont utilisées sur les diapositives, afin que les fichiers enregistrés conservent un contexte utile comme le numéro de diapositive, la position de la forme et le type de source (cadre d’image, image de remplissage, aperçu multimédia, aperçu OLE ou image de zoom).

{{% alert title="Astuce" color="primary" %}}
Utilisez [IPPImage.BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) pour préserver les données d’image encodées d’origine et le type de fichier. Utilisez [IPPImage.Image](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) avec [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) lorsque vous souhaitez normaliser la sortie vers un format spécifique tel que PNG.
{{% /alert %}}

## **Méthodes d’assistance partagées**

Les méthodes d’assistance ci‑dessous raccourcissent les exemples. `SaveOriginalImage` écrit les octets intégrés d’origine, choisit une extension sûre à partir du type MIME et ignore les binaires d’image en double grâce au hachage SHA‑256.

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

## **Extraire les images des cadres d’image**

Utilisez cette approche pour les images insérées comme objets autonomes. Un [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) stocke son image dans `PictureFormat.Picture.Image`, qui renvoie un objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).

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

## **Extraire les images des formes remplies d’image**

Les formes peuvent utiliser une image comme remplissage. Vérifiez d’abord le type de remplissage de la forme : s’il n’est pas [FillType.Picture](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/), il n’y a aucune image à extraire de ce remplissage. L’exemple ci‑dessous traite les objets [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) et enregistre chaque image au format PNG via [IPPImage.Image](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).

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

## **Extraire les images d’aperçu des cadres d’objet OLE**

Un [IOleObjectFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ioleobjectframe/) peut posséder une image de substitution que PowerPoint utilise comme aperçu de l’objet sur une diapositive. Cette image est accessible via `SubstitutePictureFormat.Picture.Image`. Extraire cette image vous donne l’aperçu, pas le contenu du package OLE intégré.

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

## **Extraire les images d’aperçu des cadres vidéo**

Un [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) peut aussi stocker une image d’aperçu dans `PictureFormat.Picture.Image`. Il s’agit de l’afficheur ou de la miniature affichée sur la diapositive, pas d’une image décodée à partir du flux vidéo.

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

## **Extraire les images d’aperçu des cadres audio**

Un [IAudioFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudioframe/) peut stocker une vignette dans `PictureFormat.Picture.Image`. C’est l’image affichée pour l’objet audio sur la diapositive.

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

## **Extraire les images des objets Zoom**

Les formes [IZoomFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/izoomframe/) et [ISectionZoomFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/isectionzoomframe/) peuvent utiliser des images personnalisées. Lisez la propriété `ZoomImage` du cadre zoom.

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

## **Extraire les images des cadres de zoom de résumé**

Un [ISummaryZoomFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/isummaryzoomframe/) est également une forme. Ses éléments de section peuvent utiliser des images personnalisées, exposées via la propriété `ZoomImage` de chaque section de zoom de résumé.

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

## **Extraire les images des formes de tableau**

Une [ITable](https://reference.aspose.com/slides/fr/net/aspose.slides/itable/) est une forme. Les images dans un tableau sont généralement stockées comme remplissages d’image dans les cellules du tableau.

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

## **Extraire les images des formes de graphique**

Un [IChart](https://reference.aspose.com/slides/fr/net/aspose.slides.charts/ichart/) est une forme. L’exemple ci‑dessous extrait une image du remplissage d’image de la zone du graphique.

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

## **Extraire les images des formes SmartArt**

Un [ISmartArt](https://reference.aspose.com/slides/fr/net/aspose.slides.smartart/ismartart/) est une forme. Selon la disposition du SmartArt, les images peuvent être stockées dans les remplissages de puces de nœud ou dans les formats de remplissage des formes de nœud.

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

## **Inclure les images à l’intérieur des formes groupées**

Les formes groupées contiennent leurs propres collections de formes. La méthode d’assistance partagée `EnumerateShapes` propose une option `includeGroupedShapes`. Réglez‑la sur `true` lorsque vous souhaitez inspecter les formes à l’intérieur des objets [IGroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides/igroupshape/). L’exemple ci‑dessous extrait les images des cadres d’image, des formes remplies d’image, des aperçus d’objets OLE, des miniatures de cadres vidéo et des miniatures de cadres audio. Pour inclure également les images de tableau, de graphique, de SmartArt et de zoom de résumé, réutilisez la logique d’extraction spécialisée des sections précédentes tout en conservant le même parcours récursif des formes.

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

## **Cas limites et notes pratiques**

- **Images en double :** plusieurs formes peuvent référencer la même image ou des images distinctes contenant des octets identiques. Hachez [IPPImage.BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) avant d’écrire les fichiers si vous souhaitez un fichier de sortie par image unique.
- **Données d’origine vs. sortie convertie :** enregistrer [IPPImage.BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) préserve les données JPEG, PNG, GIF, SVG, EMF ou WMF intégrées. Enregistrer [IPPImage.Image](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) via [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) est utile lorsqu’on veut un format de sortie uniforme.
- **Types de remplissage non pris en charge :** les formes à remplissage solide, dégradé, motif ou sans remplissage ne contiennent pas d’image de remplissage. Vérifiez [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) avant de lire `PictureFillFormat`.
- **Formes groupées :** la collection de formes de niveau supérieur d’une diapositive ne déplie pas les groupes. Inspectez récursivement [IGroupShape.Shapes](https://reference.aspose.com/slides/fr/net/aspose.slides/igroupshape/) lorsque le contenu groupé importe.
- **Aperçus d’objets OLE :** un [IOleObjectFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ioleobjectframe/) peut exposer une image d’aperçu via `SubstitutePictureFormat`, mais cette image n’est qu’un aperçu de la diapositive, pas le fichier intégré dans l’objet OLE.
- **Miniatures de cadres vidéo :** un [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) peut exposer une image d’aperçu via `PictureFormat`, mais cette image n’est que le poster affiché sur la diapositive. Elle n’est pas extraite du flux vidéo.
- **Miniatures de cadres audio :** un [IAudioFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iaudioframe/) peut exposer une icône ou une vignette via `PictureFormat` ; ce n’est pas le flux audio intégré.
- **Images de zoom :** les formes de zoom de diapositive, de section et de résumé peuvent utiliser des objets [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) personnalisés via `ZoomImage`.
- **Modèles de formes imbriquées :** les objets tableau, graphique et SmartArt implémentent [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/), mais leurs images sont souvent stockées dans des objets de formatage de cellule de tableau, d’élément de graphique ou de nœud SmartArt.
- **Images recadrées ou transformées :** accéder à [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) vous donne la ressource image stockée. Cela ne rend pas le recadrage, la transparence, le recolorisation, la rotation ou d’autres effets visuels appliqués par la forme.

## **FAQ**

**Puis‑je extraire l’image originale sans recadrage, effets ou transformations de forme ?**  
Oui. Accédez à l’objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) et écrivez [IPPImage.BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) sur le disque. Cela préserve l’image encodée d’origine stockée dans la présentation, et non la façon dont l’image est rendue sur la diapositive.

**Puis‑je exporter chaque image extraite au format PNG ?**  
Oui. Utilisez [IPPImage.Image](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) pour obtenir un objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/), puis appelez [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) avec [ImageFormat.Png](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/). Cette conversion peut ne pas préserver le type de fichier ou les données vectorielles d’origine.

**Comment éviter d’enregistrer la même image plusieurs fois ?**  
Utilisez un hachage de [IPPImage.BinaryData](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) et conservez les hachages dans un ensemble. Si une nouvelle image possède un hachage déjà présent, ignorez‑la ou enregistrez une référence supplémentaire vers le fichier de sortie existant.

**Pourquoi certaines formes ne produisent‑elles pas d’image ?**  
Les cadres d’image, les formes remplies d’image, les cadres d’objet OLE, les cadres multimédia, les cadres de zoom, les tableaux, les graphiques et les objets SmartArt peuvent référencer des images. Certains types de forme exposent les images via des objets de formatage imbriqués, de sorte qu’une simple vérification de `PictureFormat` ou `FillFormat` n’est pas toujours suffisante.

**Puis‑je extraire la miniature affichée pour un cadre vidéo ?**  
Oui. Utilisez [IVideoFrame.PictureFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) et lisez `PictureFormat.Picture.Image`. Cela extrait l’image du poster stockée avec le cadre vidéo, pas une image générée à partir du fichier vidéo.

**Comment déterminer quelles formes utilisent une image spécifique de la collection d’images de la présentation ?**  
Aspose.Slides ne conserve pas de liens inversés de [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) vers les formes. Construisez une cartographie pendant le parcours : chaque fois que vous trouvez une référence d’image, enregistrez le numéro de diapositive, le chemin de la forme et le hachage ou l’index de l’image dans la collection.

**Puis‑je extraire les images intégrées dans des objets OLE, comme des documents joints ?**  
Vous pouvez extraire l’aperçu de la diapositive de l’objet OLE via [IOleObjectFrame.SubstitutePictureFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ioleobjectframe/). Cependant, cet aperçu n’est pas le document intégré lui‑mmé. Pour extraire les images contenues dans le fichier intégré, il faut extraire les données OLE et les analyser avec les outils appropriés au type de fichier.