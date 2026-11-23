---
title: Améliorer le traitement d'images avec l'API Moderne
linktitle: API Moderne
type: docs
weight: 234
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
- ajouter une image
- ajouter une image
- .NET
- C#
- Aspose.Slides
description: "Modernisez le traitement d'images des diapositives en remplaçant les API d'imagerie obsolètes par l'API Moderne .NET pour une automatisation fluide de PowerPoint et OpenDocument."
---
## **Introduction**

Historiquement, Aspose Slides dépend de System.Drawing et propose dans son API publique les classes suivantes provenant de celui‑ci :
- [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics)
- [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)
- [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap)
- [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings)

À partir de la version 24.4, cette API publique est déclarée obsolète.

Depuis que la prise en charge de System.Drawing dans les versions .NET6 et supérieures a été supprimée pour les versions non Windows ([breaking change](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only)), Slides a mis en œuvre une approche à deux packages :
- [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET) – prise en charge de .NET6+ pour Windows, .NETStandard pour Windows/Linux/macOS, .NETFramework 2+ (Windows).
  - dépend de [System.Drawing.Common](https://www.nuget.org/packages/System.Drawing.Common/).
- [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) – version Windows/Linux/macOS sans dépendances.

La contrainte de [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform) est qu’il implémente sa propre version de System.Drawing dans le même espace de noms (pour assurer la compatibilité descendante avec l’API publique). Ainsi, lorsque Aspose.Slides.NET6.CrossPlatform et System.Drawing provenant du .NET Framework ou du package System.Drawing.Common sont utilisés simultanément, un conflit de noms se produit à moins d’utiliser un alias.

Pour se débarrasser des dépendances à System.Drawing dans le package principal Aspose.Slides.NET, nous avons ajouté ce que l’on appelle l’« API moderne » – c’est‑à‑dire l’API qui doit être utilisée à la place de celle‑dépréciée, dont les signatures contiennent des dépendances aux types suivants de System.Drawing : [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) et [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) et [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) sont déclarés obsolètes et leur prise en charge a été retirée de l’API publique de Slides.

Dans les versions actuelles, considérez l’API publique dépendante de System.Drawing comme héritée/obsolète. Utilisez l’API Moderne pour le nouveau code et lors de la migration des flux de traitement d’images existants.

## **API Moderne**

Ajout des classes et énumérations suivantes à l’API publique :
- [Aspose.Slides.IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) – représente l’image raster ou vectorielle.
- [Aspose.Slides.ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) – représente le format de fichier de l’image.
- [Aspose.Slides.Images](https://reference.aspose.com/slides/net/aspose.slides/images/) – méthodes pour instancier et travailler avec l’interface [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).

Veuillez noter que [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) est jetable (elle implémente l’interface [IDisposable](https://learn.microsoft.com/en-us/dotnet/api/system.idisposable) et son utilisation doit être encapsulée dans un using ou libérée d’une autre façon appropriée).

Utilisez `GetImage` pour rendre une diapositive ou une forme unique. Utilisez `GetImages` pour rendre plusieurs diapositives d’une présentation. Utilisez les méthodes de [Images](https://reference.aspose.com/slides/net/aspose.slides/images/) pour charger des images, `AddImage` avec [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) pour les ajouter à une présentation, et `ReplaceImage` avec [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) pour mettre à jour une image existante d’une présentation.

Un scénario typique d’utilisation de la nouvelle API peut ressembler à :

``` csharp
using System.Drawing;
using Aspose.Slides;

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

## **Remplacement du code ancien par l’API Moderne**

Pour faciliter la transition, l’interface du nouveau [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) reproduit les signatures séparées des classes [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image) et [Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap). En général, il vous suffira de remplacer l’appel à l’ancienne méthode utilisant System.Drawing par la nouvelle.

### **Obtention d’une vignette de diapositive**

API héritée/obsolète :
``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetThumbnail().Save("slide1.png");
}
```

API Moderne :
``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].GetImage().Save("slide1.png");
}
```

### **Obtention d’une vignette de forme**

API héritée/obsolète :
``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetThumbnail().Save("shape.png");
}
```

API Moderne :
``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Slides[0].Shapes[0].GetImage().Save("shape.png");
}
```

### **Obtention d’une vignette de présentation**

API héritée/obsolète :
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

API héritée/obsolète :
``` csharp
using System.Drawing;
using Aspose.Slides;

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
using Aspose.Slides;

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

## **Méthodes/Propriétés obsolètes et leurs remplacements dans l’API Moderne**

### **Presentation**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| public Bitmap[] GetThumbnails(IRenderingOptions options) | [GetImages(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides) | [GetImages(IRenderingOptions options, int[] slides)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_1) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_4) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, float scaleX, float scaleY) | [GetImages(IRenderingOptions options, int[] slides, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_2) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, Size imageSize) | [GetImages(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages) |
| public Bitmap[] GetThumbnails(IRenderingOptions options, int[] slides, Size imageSize) | [GetImages(IRenderingOptions options, int[] slides, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages#getimages_3) |
| public void Save(string fname, SaveFormat format, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Save(string fname, SaveFormat format, ISaveOptions options, HttpResponse response, bool showInline) | No Modern API replacement |
| public void Print() | No Modern API replacement |
| public void Print(PrinterSettings printerSettings) | No Modern API replacement |
| public void Print(string printerName) | No Modern API replacement |
| public void Print(PrinterSettings printerSettings, string presName) | No Modern API replacement |

### **Shape**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage) |
| public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) | [GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage#getimage_1) |

### **Slide**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| public Bitmap GetThumbnail(float scaleX, float scaleY) | [GetImage(float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_5) |
| public Bitmap GetThumbnail() | [GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage) |
| public Bitmap GetThumbnail(IRenderingOptions options) | [GetImage(IRenderingOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_1) |
| public Bitmap GetThumbnail(Size imageSize) | [GetImage(Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_6) |
| public Bitmap GetThumbnail(ITiffOptions options) | [GetImage(ITiffOptions options)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_4) |
| public Bitmap GetThumbnail(IRenderingOptions options, float scaleX, float scaleY) | [GetImage(IRenderingOptions options, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_2) |
| public Bitmap GetThumbnail(IRenderingOptions options, Size imageSize) | [GetImage(IRenderingOptions options, Size imageSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage#getimage_3) |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY) | No Modern API replacement |
| public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize) | No Modern API replacement |

### **Output**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| public IOutputFile Add(string path, Image image) | [Add(string path, IImage image)](https://reference.aspose.com/slides/net/aspose.slides.export.web/output/add#add_1) |

### **ImageCollection**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| IPPImage AddImage(Image image) | [AddImage(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/addimage#addimage) |

### **ImageWrapperFactory**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| IImageWrapper CreateImageWrapper(Image image) | [CreateImageWrapper(IImage image)](https://reference.aspose.com/slides/net/aspose.slides/imagewrapperfactory/createimagewrapper#createimagewrapper) |

### **PPImage**
| Signature de la méthode/propriété | Signature de la méthode de remplacement |
|-----------------------------------|------------------------------------------|
| void ReplaceImage(Image newImage) | [ReplaceImage(IImage newImage)](https://reference.aspose.com/slides/net/aspose.slides/ppimage/replaceimage#replaceimage) |
| Image SystemImage { get; } | [IImage Image { get; }](https://reference.aspose.com/slides/net/aspose.slides/ppimage/image) |

### **PatternFormat**
| Signature de la méthode | Signature de la méthode de remplacement |
|-------------------------|------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTile(Color background, Color foreground)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile_1) |
| Bitmap GetTileImage(Color styleColor) | [GetTile(Color styleColor)](https://reference.aspose.com/slides/net/aspose.slides/patternformat/gettile#gettile) |

### **IPatternFormatEffectiveData**
| Signature de la méthode | Signature de la méthode de remplacement |
|--------------------------|------------------------------------------|
| Bitmap GetTileImage(Color background, Color foreground) | [GetTileIImage(SlidesImage image)](https://reference.aspose.com/slides/net/aspose.slides/ipatternformateffectivedata/gettileiimage) |

## **Prise en charge de Graphics et PrinterSettings par l’API**

La classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) n’est pas prise en charge pour les versions multiplateformes de .NET6 et supérieures. Dans Aspose Slides, utilisez les méthodes de rendu d’image de l’API Moderne au lieu de l’API qui rend vers [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) :
[ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, float scaleX, float scaleY)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_3)
- [public void RenderToGraphics(IRenderingOptions options, Graphics graphics, Size renderingSize)](https://reference.aspose.com/slides/net/aspose.slides/slide/rendertographics/#rendertographics_5)

De même, l’API liée à l’impression via [PrinterSettings](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.printing.printersettings) n’a pas de remplacement direct dans l’API Moderne :
[IPresentation](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/):
- [public void Presentation.Print](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print)
- [public void Print(PrinterSettings printerSettings)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_1)
- [public void Print(string printerName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_3)
- [public void Print(PrinterSettings printerSettings, string presName)](https://reference.aspose.com/slides/net/aspose.slides/presentation/print/#print_2)

## **FAQ**

### Pourquoi la classe [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) a‑t‑elle été supprimée ?

Le support de [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics) est obsolète dans l’API publique afin d’unifier le travail de rendu et d’images, d’éliminer les dépendances spécifiques à la plateforme, et de passer à une approche multiplateforme avec [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Utilisez `GetImage` ou `GetImages` au lieu de rendre vers [Graphics](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.graphics).

### Quel est l’avantage pratique de [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) par rapport à [Image](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.image)/[Bitmap](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.bitmap) ?

[IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/) unifie le travail avec les images raster et vectorielles, simplifie l’enregistrement dans divers formats via [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/), réduit la dépendance à `System.Drawing`, et rend le code plus portable entre les environnements.

### L’API Moderne affectera‑t‑elle les performances de génération de vignettes ?

La transition de `GetThumbnail` à `GetImage` n’entraîne pas de dégradation des scénarios : les nouvelles méthodes offrent les mêmes capacités de production d’images avec options et tailles, tout en conservant la prise en charge des options de rendu. Le gain ou la perte spécifiques dépendent du scénario, mais fonctionnellement les remplacements sont équivalents.