---
title: Optimiser la gestion des images dans les présentations en .NET
linktitle: Gestion des images
type: docs
weight: 10
url: /fr/net/image/
keywords:
- ajouter une image
- ajouter une image
- ajouter bitmap
- remplacer image
- remplacer image
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ressources SVG externes
- résolveur SVG
- images SVG liées
- polices SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour .NET, en optimisant les performances et en automatisant votre flux de travail."
---
## **Introduction**

Les images rendent les présentations plus attrayantes et visuellement plaisantes. Dans Microsoft PowerPoint, vous pouvez insérer des images dans les diapositives à partir de fichiers, d'Internet ou d'autres sources. De même, Aspose.Slides vous permet d'ajouter des images aux diapositives de présentation de plusieurs manières.

{{% alert  title="Tip" color="info" %}} 

Aspose propose des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt)—qui vous permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant que cadre d'image—en particulier si vous prévoyez de la redimensionner, d'appliquer des effets ou d'utiliser d'autres options de formatage standard—voir [Picture Frame](/slides/fr/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Vous pouvez convertir des images d'un format à un autre. Consultez les pages suivantes : convertissez [image en JPG](https://products.aspose.com/slides/fr/net/conversion/image-to-jpg/), [JPG en image](https://products.aspose.com/slides/fr/net/conversion/jpg-to-image/), [JPG en PNG](https://products.aspose.com/slides/fr/net/conversion/jpg-to-png/), [PNG en JPG](https://products.aspose.com/slides/fr/net/conversion/png-to-jpg/), [PNG en SVG](https://products.aspose.com/slides/fr/net/conversion/png-to-svg/), et [SVG en PNG](https://products.aspose.com/slides/fr/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les images dans les formats populaires tels que JPEG, PNG, BMP, GIF et d'autres.

## **Ajouter des images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images stockées sur votre ordinateur à une diapositive de présentation. Le code d'exemple C# suivant montre comment ajouter une image à une diapositive :

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

## **Ajouter des images du Web aux diapositives**

Si l'image que vous souhaitez ajouter à une diapositive n'est pas stockée sur votre ordinateur, vous pouvez l'ajouter directement depuis le Web.

Le code d'exemple C# suivant montre comment ajouter une image depuis le Web à une diapositive :

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

## **Ajouter des images aux maîtres de diapositives**

Un maître de diapositive stocke et contrôle des informations telles que le thème et la disposition des diapositives qui l'utilisent. Lorsque vous ajoutez une image à un maître de diapositive, l'image apparaît sur chaque diapositive basée sur ce maître.

Le code d'exemple C# suivant montre comment ajouter une image à un maître de diapositive :

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

## **Ajouter des images comme arrière-plan de diapositives**

Vous pouvez utiliser une image comme arrière-plan d'une ou plusieurs diapositives. Pour plus de détails, voir *[Setting Images as Backgrounds for Slides](/slides/fr/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajouter du SVG aux présentations**

Le contenu SVG peut être ajouté à une présentation à l'aide de la classe [SvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/svgimage/). L'objet [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) résultant peut ensuite être ajouté à la collection d'images de la présentation et utilisé pour créer un cadre d'image.

L'exemple C# suivant importe une chaîne SVG autonome. Toutes les images, styles et autres ressources utilisés par ce SVG sont intégrés directement dans le contenu SVG.

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

## **Importer du contenu SVG avec des ressources externes**

Les fichiers SVG exportés depuis des outils de conception, éditeurs de diagrammes, systèmes d'icônes et pipelines Web peuvent référencer des ressources stockées à l'extérieur du document SVG. Par exemple, un SVG peut contenir un lien d'image tel que `images/photo.png`, une valeur CSS `url(...)`, ou une URL de police.

Pour importer ce type de contenu SVG, créez une implémentation de [IExternalResourceResolver](https://reference.aspose.com/slides/fr/net/aspose.slides.import/iexternalresourceresolver/) et transmettez‑la, avec une URI de base, à un constructeur approprié de `SvgImage`. L'URI de base identifie l'emplacement du document SVG et est utilisée pour résoudre les liens relatifs.

L'interface [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) fournit l'accès aux informations concernant le SVG importé :

- `SvgContent` renvoie le balisage SVG sous forme de chaîne.
- `SvgData` renvoie le contenu SVG sous forme de tableau d'octets.
- `BaseUri` renvoie l'URI de base utilisée pour les liens relatifs.
- `ExternalResourceResolver` renvoie le résolveur assigné à l'image SVG.

### **Implémenter un résolveur de ressources externes**

Le résolveur possède deux méthodes :

- [ResolveUri](https://reference.aspose.com/slides/fr/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combine l'URI de base et un lien de ressource relatif et renvoie une URI absolue. Retournez `null` lorsque le lien ne peut pas être résolu ou n'est pas autorisé.
- [GetEntity](https://reference.aspose.com/slides/fr/net/aspose.slides.import/iexternalresourceresolver/getentity/) renvoie un flux lisible pour une URI de ressource absolue. Retournez `null` si la ressource est manquante, bloquée ou indisponible. Un flux de secours peut également être renvoyé le cas échéant.

Le résolveur suivant charge les ressources liées uniquement depuis un répertoire local autorisé. Les ressources réseau et les chemins en dehors du répertoire autorisé sont bloqués. Une image de secours facultative est renvoyée pour les liens d'image non résolus.

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

        // Ce résolveur autorise intentionnellement uniquement les fichiers locaux.
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

        // Utilisez un secours uniquement pour les ressources image. Retourner un flux d'image
        // pour une police ou une feuille de style manquante ne serait pas valide.
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

### **Résoudre les ressources liées lors de l'importation SVG**

Supposons que `assets/diagram.svg` contienne une référence relative telle que :

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

L'exemple C# suivant transmet l'URI du fichier SVG comme URI de base et fournit un résolveur personnalisé. Le résolveur convertit le lien d'image relatif en une URI absolue et renvoie un flux contenant la ressource liée pendant qu'Aspose.Slides traite le SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// L'URI de base représente l'emplacement du document SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage expose le contenu source, les données binaires, l'URI de base et le résolveur.
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

La classe `SvgImage` propose également des surcharges qui acceptent les données SVG sous forme de tableau d'octets ou de flux, ainsi qu'un résolveur de ressources externes et une URI de base.

{{% alert title="Important" color="warning" %}}

Le résolveur de ressources rend les ressources externes disponibles pendant qu'Aspose.Slides traite et rend le SVG. Il ne modifie pas le balisage SVG original ni n'intègre automatiquement les ressources résolues.

Lorsque un `ISvgImage` est ajouté à la collection d'images de la présentation, le fichier PPTX peut contenir à la fois la représentation SVG originale et une image raster de secours. Une ressource liée peut apparaître dans l'image de secours générée tandis qu'un lien relatif tel que `images/photo.png` reste inchangé dans le SVG stocké. Une application qui rend la représentation SVG native peut donc omettre le contenu lié lorsque la ressource externe originale n'est pas disponible.

{{% /alert %}}

### **Créer une image SVG portable**

Pour créer une image SVG qui ne dépend pas de fichiers externes, rendez le SVG autonome avant de créer le `SvgImage`. Par exemple, remplacez les URL d'images liées par des URI `data:` contenant les données de l'image :

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Une fois toutes les ressources requises intégrées au contenu SVG, créez le `SvgImage`, ajoutez-le à la collection d'images de la présentation et insérez-le dans un cadre d'image comme illustré dans l'exemple précédent.

### **Gérer les ressources manquantes ou bloquées**

Retournez `null` depuis `ResolveUri` lorsqu'une URI de ressource est invalide, interdite ou ne peut pas être résolue. Retournez `null` depuis `GetEntity` lorsque la ressource ne peut pas être lue. Aspose.Slides poursuit le traitement du SVG sans cette ressource lorsque cela est possible.

Un flux de secours peut être renvoyé pour une ressource manquante, mais son contenu doit être compatible avec le type de ressource demandé. Par exemple, renvoyez un flux d'image uniquement pour une image manquante, pas pour une police ou une feuille de style.

{{% alert title="Security" color="warning" %}}

Ne résolvez pas des chemins de fichiers arbitraires ni des URL réseau non restreintes provenant de fichiers SVG non fiables. Restreignez les schémas, répertoires et hôtes autorisés. Pour les ressources réseau, appliquez également des délais d'attente de connexion, des limites de taille de réponse et une validation du contenu.

{{% /alert %}}

## **Convertir le SVG en ensemble de formes**

Aspose.Slides peut convertir un SVG en un ensemble de formes, similaire à la fonctionnalité correspondante dans PowerPoint :

![Menu contextuel PowerPoint](img_01_01.png)

Cette fonctionnalité est fournie par une surcharge de la méthode [AddGroupShape](https://reference.aspose.com/slides/fr/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de l'interface [IShapeCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection) qui prend un objet [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage) comme premier argument.

Le code d'exemple C# suivant montre comment utiliser cette méthode pour convertir un fichier SVG en un ensemble de formes :

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nom du fichier SVG source
string svgFileName = "sample.svg";

// Nom du fichier de sortie de la présentation
string outPptxPath = "presentation.pptx";

// Créer une nouvelle présentation
using (IPresentation presentation = new Presentation())
{
    // Lire le contenu du fichier SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Créer un objet SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtenir la taille de la diapositive
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir l'image SVG en groupe de formes et la redimensionner à la taille de la diapositive
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Enregistrer la présentation au format PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Ajouter des images au format EMF aux diapositives**

Aspose.Slides for .NET vous permet de générer des images EMF à partir de feuilles de calcul Excel avec Aspose.Cells et de les ajouter aux diapositives de présentation.

Le code d'exemple C# suivant montre comment faire :

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

    // Enregistrer le classeur dans un flux
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

## **Remplacer des images dans la collection d'images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d'images d'une présentation, y compris les images utilisées par les formes de diapositives. Cette section décrit plusieurs méthodes pour mettre à jour les images de la collection. Vous pouvez remplacer une image à l'aide de données brutes d'octets, d'une instance [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) ou d'une autre image déjà présente dans la collection.

Suivez les étapes suivantes :

1. Chargez le fichier de présentation contenant les images à l'aide de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Chargez une nouvelle image depuis un fichier dans un tableau d'octets.
3. Remplacez l'image cible par la nouvelle image en utilisant le tableau d'octets.
4. Dans la deuxième approche, chargez l'image dans un objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) et remplacez l'image cible par cet objet.
5. Dans la troisième approche, remplacez l'image cible par une image déjà existante dans la collection d'images de la présentation.
6. Enregistrez la présentation modifiée au format PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier de présentation.
using Presentation presentation = new Presentation("sample.pptx");

// Première méthode.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Deuxième méthode.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Troisième méthode.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Enregistrez la présentation dans un fichier.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Info" color="info" %}}

Avec le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d'Aspose, vous pouvez facilement animer du texte et créer des GIF à partir du texte. 

{{% /alert %}}

## **FAQ**

**La résolution de l'image originale reste-t-elle intacte après l'insertion ?**

Oui. Les pixels sources sont conservés, mais l'apparence finale dépend de la façon dont le [picture](/slides/fr/net/picture-frame/) est redimensionné sur la diapositive et de toute compression appliquée lors de l'enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une seule fois ?**

Placez le logo sur la diapositive maître ou sur une mise en page et remplacez‑le dans la collection d'images de la présentation — les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes éditables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi les parties individuelles deviennent éditables avec les propriétés de forme standard.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives en même temps ?**

[Attribuez l'image comme arrière‑plan](/slides/fr/net/presentation-background/) sur la diapositive maître ou la mise en page concernée — toutes les diapositives utilisant ce maître/mise en page hériteront de l'arrière‑plan.

**Comment empêcher une présentation de devenir trop volumineuse à cause de nombreuses images ?**

Réutilisez une seule ressource d'image au lieu de duplications, choisissez des résolutions raisonnables, appliquez une compression lors de l'enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.