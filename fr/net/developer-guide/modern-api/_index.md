---
title: Améliorer le traitement d'images avec l'API Moderne
linktitle: API Moderne
type: docs
weight: 237
url: /fr/net/modern-api/
keywords:
- System.Drawing
- API moderne
- dessin
- vignette de diapositive
- diapositive en image
- vignette de forme
- forme en image
- vignette de présentation
- présentation en images
- ajouter image
- ajouter image
- .NET
- C#
- Aspose.Slides
description: "Modernisez le traitement d'images des diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne .NET pour une automatisation fluide de PowerPoint et OpenDocument."
---

## **Introduction**

Historiquement, Aspose Slides dépend de System.Drawing et expose dans son API publique les classes suivantes provenant de cet espace de noms :
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

À partir de la version 24.4, cette API publique est marquée comme obsolète.

Comme la prise en charge de System.Drawing dans les versions .NET 6 et supérieures a été supprimée pour les plateformes non Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides a adopté une approche à deux bibliothèques :
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – prise en charge de .NET 6+ pour Windows, .NETStandard pour Windows/Linux/macOS, .NETFramework 2+ (Windows).  
  - dépend de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – version Windows/Linux/macOS sans dépendances.

L’inconvénient de [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) est qu’il implémente sa propre version de System.Drawing dans le même espace de noms (pour maintenir la compatibilité ascendante de l’API publique). Ainsi, lorsque Aspose.Slides.NET6.CrossPlatform et System.Drawing provenant de .NETFramework ou du paquet System.Drawing.Common sont utilisés simultanément, un conflit de noms apparaît à moins d’utiliser un alias.

Afin de se débarrasser des dépendances à System.Drawing dans le principal package Aspose.Slides.NET, nous avons ajouté ce que l’on appelle « l’API Moderne » – c’est‑à‑dire l’API à utiliser à la place de celle marquée comme obsolète, dont les signatures contiennent des dépendances aux types System.Drawing suivants : Image et Bitmap. PrinterSettings et Graphics sont déclarés obsolètes et leur prise en charge est retirée de l’API publique de Slides.

La suppression de l’API publique obsolète dépendante de System.Drawing sera effectuée dans la version 24.8.

## **API Moderne**

Ajout des classes et énumérations suivantes à l’API publique :

- Aspose.Slides.IImage – représente une image raster ou vectorielle.  
- Aspose.Slides.ImageFormat – représente le format de fichier de l’image.  
- Aspose.Slides.Images – méthodes pour instancier et travailler avec l’interface IImage.

Veuillez noter que IImage est jetable (il implémente l’interface IDisposable et son utilisation doit être encapsulée dans un `using` ou être libérée d’une autre manière appropriée).

Un scénario typique d’utilisation de la nouvelle API peut ressembler à ce qui suit :
``` csharp
using (Presentation pres = new Presentation())
{
    IPPImage ppImage;
    // instancier une instance jetable de IImage à partir du fichier sur le disque.
    using (IImage image = Images.FromFile("image.png"))
    {
        // créer une image PowerPoint en ajoutant une instance de IImage aux images de la présentation.
        ppImage = pres.Images.AddImage(image);
    }

    // ajouter une forme image sur la diapositive #1
    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, ppImage);

    // obtenir une instance de IImage représentant la diapositive #1.
    using (var slideImage = pres.Slides[0].GetImage(new Size(1920, 1080)))
    {
        // enregistrer l'image sur le disque.
        slideImage.Save("slide1.jpeg", ImageFormat.Jpeg);
    }
}
```


## **Remplacement du code ancien par l'API Moderne**

Pour faciliter la transition, l’interface du nouveau IImage reprend les signatures séparées des classes Image et Bitmap. En pratique, il suffit de remplacer l’appel à l’ancienne méthode utilisant System.Drawing par le nouvel appel.

### **Obtention d’une vignette de diapositive**

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


### **Obtention d’une vignette de forme**

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


### **Obtention d’une vignette de présentation**

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


### **Ajout d’une image à une présentation**

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


## **Méthodes/propriétés à supprimer et leur remplacement dans l'API Moderne**

### **Presentation**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)]() |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | Sera supprimé complètement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | Sera supprimé complètement |
| public void Print() | Sera supprimé complètement |
| public void Print(PrinterSettings printerSettings) | Sera supprimé complètement |
| public void Print(string printerName) | Sera supprimé complètement |
| public void Print(PrinterSettings printerSettings, string presName) | Sera supprimé complètement |

### **Shape**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | Sera supprimé complètement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | Sera supprimé complètement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | Sera supprimé complètement |

### **Output**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Signature de la Méthode/Propriété | Signature de la Méthode de Remplacement |
|-----------------------------------|------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Signature de la Méthode | Signature de la Méthode de Remplacement |
|--------------------------|------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **La prise en charge des Graphics et PrinterSettings sera interrompue**

La classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) n’est pas supportée pour les versions multiplateformes de .NET 6 et supérieures. Dans Aspose Slides, la partie de l’API qui l’utilise sera retirée :
[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

De même, la partie de l’API relative à l’impression sera supprimée :

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

# **FAQ**

**Pourquoi la classe System.Drawing.Graphics a‑t‑elle été supprimée ?**

La prise en charge de `Graphics` est retirée de l’API publique afin d’unifier le rendu et la manipulation d’images, d’éliminer les dépendances spécifiques à la plateforme et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Toutes les méthodes de rendu vers `Graphics` seront supprimées.

**Quel est l’avantage pratique d’IImage par rapport à Image/Bitmap ?**

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) unifie le travail avec les images raster et vectorielles, simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), réduit la dépendance à `System.Drawing` et rend le code plus portable entre les environnements.

**L’API Moderne impactera‑t‑elle les performances de génération des vignettes ?**

Le passage de `GetThumbnail` à `GetImage` n’entraîne pas de dégradation des scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifiques dépendent du scénario, mais fonctionnellement les remplacements sont équivalents.