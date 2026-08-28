---
title: Convertir les diapositives de présentation en images dans .NET
linktitle: Diapositive en image
type: docs
weight: 41
url: /fr/net/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer la diapositive comme image
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Convertir les diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et autres formats d'image en C# avec Aspose.Slides pour .NET."
---
## **Introduction**

Aspose.Slides for .NET peut rendre des diapositives individuelles provenant de présentations PowerPoint et OpenDocument au format PNG, JPEG, GIF, TIFF et d’autres formats d’image.

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/).
4. Appelez la méthode [GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/). Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/).
5. Appelez la méthode [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/save/) et spécifiez le format de sortie avec une valeur [ImageFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L’objet [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) résultant peut être traité en mémoire ou enregistré dans un fichier.

L’exemple C# suivant rend la première diapositive et l’enregistre au format PNG :

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge [GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/) qui accepte une valeur [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) pour rendre une diapositive avec des dimensions exactes en pixels.

L’exemple suivant crée une image JPEG de 1820 × 1040 :

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **Convertir des diapositives avec notes et commentaires en images**

Par défaut, les images de diapositives n’incluent pas les notes ni les commentaires. Assignez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/) à la propriété [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) pour contrôler où les notes et les commentaires apparaissent.

L’exemple suivant place les notes tronquées sous la diapositive et les commentaires à sa droite :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion de diapositive en image, ne définissez pas la propriété [NotesPosition](https://reference.aspose.com/slides/fr/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) sur [BottomFull](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notespositions/). Les notes peuvent contenir plus de texte que la taille d’image fixe ne peut accueillir. Utilisez plutôt [BottomTruncated](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/tiffoptions/) vous permet de contrôler la taille, la résolution et d’autres propriétés de l’image TIFF rendue.

L’exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 à 300 DPI :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **Convertir toutes les diapositives en images**

Itérez la collection de diapositives pour convertir l’ensemble de la présentation en une série d’images. Les diapositives masquées sont incluses sauf si vous les ignorez explicitement.

L’exemple suivant rend chaque diapositive en une image JPEG avec des facteurs d’échelle horizontaux et verticaux de 2 :

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **Créer une sortie Enhanced Metafile**

Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d’autres applications Windows qui prennent en charge les métadonnées Windows. Contrairement à une image bitmap, un EMF peut conserver les opérations de dessin vectoriel qui se redimensionnent sans perdre de netteté. Cependant, EMF est principalement un format de compatibilité pour les applications supportant les métadonnées Windows, pas un format d’échange universel. De plus, le contenu complexe d’une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d’éléments rasterisés à l’intérieur du conteneur de métadonnées vectorielles.

### **Exporter une diapositive en EMF**

La méthode [ISlide.WriteAsEmf](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/writeasemf/) écrit un [ISlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/) dans un flux cible au format EMF. L’exemple suivant charge une présentation, sélectionne la première diapositive et l’écrit dans un flux de fichier EMF :

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

L’appelant possède le flux passé à [ISlide.WriteAsEmf](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/writeasemf/) et doit le fermer ou le libérer. Aspose.Slides écrit à la position actuelle du flux et le laisse ouvert.

### **Convertir une image SVG en EMF et l’ajouter à une présentation**

Utilisez [ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/writeasemf/) pour convertir du contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [IImageCollection.AddImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection/addimage/) et placés sur une diapositive avec [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addpictureframe/).

L’exemple suivant crée une [SvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/svgimage/) à partir du balisage SVG, la convertit en EMF en mémoire, insère le métafichier sur la première diapositive et enregistre la présentation :

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/writeasemf/) ne prend pas la possession du flux de destination. Après l’écriture, la position du flux se trouve à la fin des données générées. Réinitialisez `Position` au début avant de passer le même flux consultable à un lecteur, comme montré ci‑dessus. Gardez le flux ouvert jusqu’à ce que le consommateur ait fini de le lire, puis libérez‑le. Alternativement, appelez `ToArray` et transmettez le tableau d’octets retourné à [IImageCollection.AddImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection/addimage/); `ToArray` renvoie le tampon complet quelle que soit la position actuelle du flux.

La génération d’EMF est disponible sur les systèmes d’exploitation pris en charge par la version d’Aspose.Slides for .NET sélectionnée, mais le rendu peut varier selon les plateformes lorsque les polices ou les dépendances graphiques natives sont indisponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [exigences de la plateforme](/slides/fr/net/system-requirements/) pour votre package Aspose.Slides, et validez le résultat dans l’application cible qui consomme les EMF. Les applications Linux et macOS ont souvent un support limité ou incohérent pour l’affichage et l’édition des métadonnées Windows.

## **Rendu des Emoji en couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis en couleur lors de la conversion de diapositives de présentation en images, les polices d’emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu de diapositives avec animations ?**

Non. La méthode [GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/) rend une image statique de la diapositive et n’exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme les diapositives normales. Incluez‑les dans la boucle de traitement, comme le montre l’exemple ci‑dessus.

**Les ombres et autres effets sont‑ils conservés dans les images de diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et d’autres effets graphiques pris en charge dans les images de diapositives.