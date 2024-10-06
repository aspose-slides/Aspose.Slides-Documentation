---
title: API Moderne
type: docs
weight: 237
url: /net/modern-api/
keywords: "CrossPlatform API Moderne System.Drawing"
description: "API Moderne"
---

## Introduction

Historiquement, Aspose Slides dépend de System.Drawing et possède dans l'API publique les classes suivantes à partir de là :
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Étant donné que le support de System.Drawing dans les versions .NET6 et supérieures est supprimé pour les versions non-Windows ([changement majeur](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides a mis en œuvre une approche de version à deux bibliothèques :
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) - support pour .NET6+ pour Windows, .NETStandard pour Windows/Linux/MacOS, .NETFramework 2+ (Windows).
  - dépend de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) - version Windows/Linux/MacOS sans dépendances.

L'inconvénient de [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) est qu'il implémente sa propre version de System.Drawing dans le même espace de noms (pour supporter la compatibilité ascendante avec l'API publique). Ainsi, lorsque Aspose.Slides.NET6.CrossPlatform et System.Drawing de .NETFramework ou le package System.Drawing.Common sont utilisés en même temps, un conflit de noms se produit à moins qu'un alias soit utilisé.

Afin de se débarrasser des dépendances à System.Drawing dans le package principal Aspose.Slides.NET, nous avons ajouté le soi-disant "API Moderne" - c'est-à-dire l'API qui doit être utilisée à la place de l'ancienne API obsolète, dont les signatures contiennent des dépendances sur les types suivants de System.Drawing : Image et Bitmap. PrinterSettings et Graphics sont déclarés obsolètes et leur support est retiré de l'API publique de Slides.

La suppression de l'API publique obsolète avec des dépendances sur System.Drawing sera dans la version 24.8.

## API Moderne

Les classes et énumérations suivantes ont été ajoutées à l'API publique :

- Aspose.Slides.IImage - représente l'image raster ou vectorielle.
- Aspose.Slides.ImageFormat - représente le format de fichier de l'image.
- Aspose.Slides.Images - méthodes pour instancier et travailler avec l'interface IImage.

Veuillez noter que IImage est jetable (il implémente l'interface IDisposable et son utilisation doit être encapsulée dans un using ou être libérée d'une autre manière pratique).

Un scénario typique d'utilisation de la nouvelle API peut ressembler à ceci :

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instancier une instance jetable d'IImage à partir du fichier sur le disque.  
    using (IImage image = Images.FromFile("image.png"))
    {
        // créer une image PowerPoint en ajoutant une instance d'IImage aux images de la présentation.
        ppImage = pres.Images.AddImage(image);
    }

    // ajouter une forme d'image sur la diapositive #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtenir une instance de l'IImage représentant la diapositive #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // sauvegarder l'image sur le disque.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```

## Remplacer l'ancien code par l'API Moderne

Pour faciliter la transition, l'interface de la nouvelle IImage répète les signatures séparées des classes Image et Bitmap. En général, vous aurez juste besoin de remplacer l'appel à l'ancienne méthode utilisant System.Drawing par la nouvelle.

### Obtenir une miniature de diapositive

Code utilisant une API obsolète :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Moderne :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### Obtenir une miniature de forme

Code utilisant une API obsolète :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Moderne :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### Obtenir une miniature de présentation

Code utilisant une API obsolète :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var bitmaps = pres.GetThumbnails(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < bitmaps.Length; index++)
        {
            Bitmap thumbnail = bitmaps[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (Bitmap bitmap in bitmaps)
        {
            bitmap.Dispose();
        }
    }
}
```

API Moderne :

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    var images = pres.GetImages(new RenderingOptions(), new Size(1980, 1028));
    try
    {
        for (var index = 0; index < images.Length; index++)
        {
            IImage thumbnail = images[index];
            thumbnail.Save($"slide{index}.png", ImageFormat.Png);
        }
    }
    finally
    {
        foreach (IImage image in images)
        {
            image.Dispose();
        }
    }
}
```

### Ajouter une image à une présentation

Code utilisant une API obsolète :

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (Image image = Image.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```

API Moderne :

``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    using (IImage image = Aspose.Slides.Images.FromFile("image.png"))
    {
        ppImage = pres.Images.AddImage(image);
    }

    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);
}
```
## Méthodes/propriétés à supprimer et leur remplacement dans l'API Moderne

### Présentation
| Signature de la méthode                               | Signature de la méthode de remplacement                             |
|-----------------------------------------------|---------------------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages)                   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1)   |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Sera complètement supprimé |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Sera complètement supprimé |
| public void Print()                           | Sera complètement supprimé                               |
| public void Print(PrinterSettings printerSettings) | Sera complètement supprimé                            |
| public void Print(string printerName)         | Sera complètement supprimé                               |
| public void Print(PrinterSettings printerSettings, string presName) | Sera complètement supprimé                          |

### Forme
| Signature de la méthode                                                      | Signature de la méthode de remplacement                                       |
|----------------------------------------------------------------------|-------------------------------------------------------------------|
| public Bitmap GetThumbnail()                                          | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage)                                                           |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### Diapositive
| Signature de la méthode                                                      | Signature de la méthode de remplacement                                           |
|----------------------------------------------------------------------|-----------------------------------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY)                | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5)                                 |
| public Bitmap GetThumbnail()                                         | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage)                                                              |
| public Bitmap GetThumbnail(IRenderingOptions options)                | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1)                                  |
| public Bitmap GetThumbnail(Size imageSize)                           | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6)                                             |
| public Bitmap GetThumbnail(ITiffOptions options)                    | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4)                                      |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3)               |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Sera complètement supprimé                                       |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Sera complètement supprimé                             |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Sera complètement supprimé                                    |

#### Sortie
| Signature de la méthode                                                | Signature de la méthode de remplacement                                |
|-----------------------------------------------------------------|-------------------------------------------------------------|
| public IOutputFile Add(string path, Image image)               | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1)                               |

### ImageCollection
| Signature de la méthode                          | Signature de la méthode de remplacement               |
|-------------------------------------------|--------------------------------------------|
| IPPImage AddImage(Image image)           | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage)                      |

### ImageWrapperFactory
| Signature de la méthode                                         | Signature de la méthode de remplacement                            |
|----------------------------------------------------------|---------------------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image)           | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper)                        |

### PPImage
| Signature de la méthode/propriété                     | Signature de la méthode de remplacement   |
|--------------------------------------|-----------------------------------------|
| void ReplaceImage(Image newImage)   | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage)            |
| Image SystemImage { get; }          | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image)                    |

### PatternFormat
| Signature de la méthode                                          | Signature de la méthode de remplacement                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1)         |
| Bitmap GetTileImage(Color styleColor)                     | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile)                           |

### IPatternFormatEffectiveData
| Signature de la méthode                                          | Signature de la méthode de remplacement                        |
|-----------------------------------------------------------|-----------------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground)   | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage)                    |

## Le support pour Aspose.Slides.NET6.CrossPlatform sera interrompu

Suite à la sortie de [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) version 24.8, le support pour [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) sera interrompu.

## Le support API pour Graphics et PrinterSettings sera interrompu

La classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) n'est pas supportée pour les versions multiplateformes de .NET6 et supérieures. Dans Aspose Slides, la partie de l'API qui l'utilise sera supprimée :
[Diapositive](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

De plus, la partie de l'API liée à l'impression sera supprimée :

[Présentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)