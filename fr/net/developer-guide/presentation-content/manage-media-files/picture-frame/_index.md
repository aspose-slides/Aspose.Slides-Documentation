---
title: Gérer les cadres d'image dans les présentations en .NET
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/net/picture-frame/
keywords:
- cadre d'image
- ajouter cadre d'image
- créer cadre d'image
- image incorporée
- image liée
- extraire image
- image matricielle
- image SVG
- recadrer image
- supprimer zones recadrées
- compresser image
- StretchOffset
- formatage du cadre d'image
- échelle relative
- effet d'image
- rapport d'aspect
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Créer, formater, lier, recadrer, extraire et compresser les cadres d'image dans les présentations avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Un cadre d'image est une forme de diapositive qui affiche une image. Dans Aspose.Slides, la ressource d'image et la forme qui l'affiche sont des objets séparés : une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) possède des ressources d'images incorporées via sa collection [Images](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/images/), tandis qu'un [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) contrôle la position, la taille, le format de ligne, la rotation, le recadrage, les effets d'image et les autres paramètres au niveau du cadre.

Cette séparation est utile lorsque la même image est affichée plusieurs fois. Ajoutez l'image à la présentation une seule fois, conservez le [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) retourné, et utilisez cette ressource d'image lors de la création de cadres d'image.

Les cadres d'image peuvent contenir des images matricielles telles que PNG ou JPEG ainsi que des images vectorielles SVG. Ils peuvent également faire référence à des images liées au lieu de stocker les octets de l'image dans la présentation. Le choix affecte la portabilité, la taille du fichier, l'extraction et le comportement d'exportation, il est donc utile de décider comment l'image doit être stockée avant d'appliquer le formatage ou l'optimisation.

## **Ajouter et formater une image incorporée**

Pour une image incorporée, ajoutez les données d'image à la présentation et créez un cadre d'image avec [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addpictureframe/). L'image devient alors partie du package de présentation, de sorte que la présentation reste autonome lorsqu'elle est déplacée vers un autre ordinateur.

L'exemple suivant ajoute une image JPEG, crée un cadre aux dimensions natives de l'image et applique le format de ligne ainsi que la rotation :

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

Le cadre d'image contrôle la géométrie affichée ; modifier la taille du cadre ne change pas les dimensions en pixels d'origine stockées dans la ressource d'image incorporée. Cette distinction devient importante lors du recadrage ou de la compression d'une image ultérieurement.

## **Utiliser l'échelle relative**

[IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) expose le redimensionnement relatif en largeur et en hauteur du cadre. Une valeur de `1.0` correspond à 100 % de la taille d'origine de l'image. L'échelle relative est utile lorsqu'un flux de travail doit conserver une relation avec la taille source de l'image au lieu de calculer manuellement les dimensions finales.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

L'échelle relative modifie les paramètres d'échelle du cadre ; elle ne rééchantillonne ni ne compresse l'image incorporée.

## **Images incorporées et liées**

Une image incorporée stocke les données d'image à l'intérieur de la présentation et constitue donc le choix le plus sûr pour la portabilité et un rendu prévisible. Une image liée stocke un chemin d'accès externe via le lien [ISlidesPicture](https://reference.aspose.com/slides/fr/net/aspose.slides/islidespicture/) au lieu d'incorporer les données d'image de la même manière.

Les images liées peuvent réduire la quantité de données d'image stockées dans le PPTX, mais elles introduisent une dépendance externe. Le fichier lié doit rester accessible à l'application qui ouvre ou rend la présentation. Si le chemin change, le fichier est déplacé ou la ressource n'est pas disponible, l'image liée peut ne pas s'afficher comme prévu. Pour les présentations qui doivent être envoyées par e‑mail, archivées ou rendues dans des environnements isolés, les images incorporées sont généralement plus fiables.

### **Ajouter une image liée**

L'exemple suivant crée un cadre d'image et le pointe vers un fichier image local. Il ne traite que le lien d'image ; le lien vidéo est un flux média distinct et n'est pas mélangé dans cet exemple.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilisez les liens lorsque la gestion de fichiers externes est intentionnelle. Ne les utilisez pas simplement comme substitut à la compression : un petit PPTX avec des dépendances d'image cassées est généralement moins utile qu'une présentation plus grande et autonome.

## **Extraire des images des cadres d'image**

Avant d'extraire une image d'une présentation existante, vérifiez qu'une forme est réellement un [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) et qu'elle contient une image incorporée. Les cadres d'image liés peuvent ne pas contenir d'octets d'image qui peuvent être extraits de la même façon.

### **Extraire une image matricielle**

L'API d'image moderne utilise directement [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) et ne nécessite plus l'ancien wrapper système-image. L'exemple suivant trouve la première image matricielle incorporée sur une diapositive et l'enregistre au format PNG :

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Enregistrement via [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/) convertit l'image extraite vers le format de sortie demandé. Si vous avez besoin des octets encodés stockés dans la présentation plutôt qu'un fichier matriciel converti, utilisez les données binaires de la ressource d'image.

### **Extraire une image SVG**

Pour une image SVG, le [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) expose un objet [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/). Cela vous permet de récupérer les données SVG directement au lieu de rasteriser d'abord l'image.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Conserver le contenu SVG en tant que SVG préserve la source vectorielle à l'intérieur de la présentation. Les exportations matricielles telles que PNG ou JPEG rendent nécessairement ce contenu vectoriel en pixels. L'exportation de diapositives en PDF ou en SVG est également une opération de rendu, de sorte que les graphiques exportés ne doivent pas être considérés comme une copie octet à octet de l'SVG incorporé d'origine ; utilisez les données [ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) incorporées lorsque la ressource vectorielle d'origine elle‑même est requise.

## **Recadrer une image**

Le recadrage modifie la partie de l'image visible à l'intérieur du cadre. Les valeurs de recadrage sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/) sont des pourcentages des dimensions de l'image source. Le recadrage ne supprime pas initialement les pixels masqués de l'image incorporée ; il ne change que la région visible.

L'exemple suivant trouve un cadre d'image de façon sécurisée et applique les valeurs de recadrage :

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Comme les données d'image masquées sont toujours présentes, le recadrage peut être modifié ultérieurement sans perdre les pixels d'origine. Si la taille du fichier est plus importante que la réversibilité, les régions recadrées peuvent être supprimées physiquement comme décrit dans la section suivante.

## **Supprimer les données d'image recadrées**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) supprime les données d'image en dehors du rectangle de recadrage actuel et renvoie la ressource d'image résultante. Cela peut réduire la taille du fichier, mais il s'agit d'une optimisation destructive : après l'enregistrement de la présentation, les pixels supprimés ne sont plus disponibles pour une opération de décrop ultérieure.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

La méthode peut ajouter une nouvelle ressource d'image à la présentation. Si l'image d'origine est également utilisée par d'autres cadres d'image, ces cadres ont toujours besoin de leur ressource existante, de sorte que la suppression des zones recadrées ne réduit pas nécessairement le nombre total d'images. Recadrer du contenu WMF ou EMF avec cette méthode rasterise le résultat recadré en PNG.

## **Compresser les images matricielles**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/compressimage/) réduit la résolution de l'image matricielle par rapport à la taille à laquelle l'image est affichée. Il peut également supprimer les régions recadrées dans la même opération. La méthode renvoie `true` lorsque l'image a été redimensionnée ou recadrée et `false` lorsqu'aucun changement n'était nécessaire.

Utilisez une valeur prédéfinie [PicturesCompression](https://reference.aspose.com/slides/fr/net/aspose.slides.export/picturescompression/) lorsqu'une résolution cible standard suffit :

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Une valeur DPI positive personnalisée peut être passée à la place d'une valeur d'énumération lorsqu'une cible spécifique est requise.

La compression est destinée aux images matricielles. Le contenu SVG et le contenu de métafichier ne sont pas réduits par ce flux de travail de compression matricielle. Gardez également à l'esprit que la résolution inférieure et les régions recadrées supprimées ne peuvent pas être récupérées à partir de la présentation optimisée. Choisissez une résolution cible basée sur la plus grande taille à laquelle l'image sera réellement visualisée ou exportée plutôt que d'appliquer le DPI le plus bas globalement.

## **Inspecter les effets d'image**

Les effets d'image sont stockés sur l'image utilisée par le cadre. La collection de transformations d'image peut contenir des effets tels que la modulation alpha fixe pour la transparence et la luminance pour la luminosité et le contraste. L'exemple ci‑dessous lit en toute sécurité les deux types d'effets à partir du premier cadre d'image d'une diapositive :

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    foreach (var effect in pictureFrame.PictureFormat.Picture.ImageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparency = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparency: " + transparency);
        }

        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            Console.WriteLine("Brightness: " + luminance.Brightness);
            Console.WriteLine("Contrast: " + luminance.Contrast);
        }
    }
}
```

Ces effets modifient la façon dont l'image est rendue dans le cadre ; ils ne réécrivent pas les octets d'origine de l'image incorporée.

## **Verrouiller la géométrie du cadre d'image**

Les paramètres [IPictureFrameLock](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframelock/) contrôlent quelles opérations d'édition sont désactivées pour un cadre d'image. Par exemple, le verrouillage du rapport d'aspect préserve les proportions de la forme lorsqu'elle est redimensionnée.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

Le verrouillage s'applique à la forme du cadre d'image. Il ne force pas l'image source à être rééchantillonnée ou modifiée de façon permanente pour correspondre au même rapport d'aspect.

## **Ajuster les valeurs StretchOffset**

Lorsque le mode de remplissage d'image est étiré, les valeurs stretch‑offset sur [IPictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/) définissent le rectangle de remplissage relatif à la boîte englobante du cadre d'image. Des pourcentages positifs créent un retrait depuis un bord, tandis que des pourcentages négatifs créent un dépassement.

Ceci est différent du recadrage. Les valeurs de recadrage sélectionnent quelle partie de l'image source est visible ; les offsets d'étirement modifient le rectangle dans lequel le remplissage d'image visible est étiré.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Utilisez les offsets d'étirement pour le placement du remplissage. Utilisez les propriétés de recadrage lorsque le but est de masquer les bords de l'image source.

## **Stockage, taille du fichier et considérations d'exportation**

Les principaux compromis sont plus faciles à gérer lorsque le stockage des images et le formatage des cadres d'image sont traités séparément :

- **Images incorporées** rendent la présentation autonome et sont les plus fiables pour le partage et le rendu côté serveur, mais les grandes images matricielles augmentent la taille du PPTX et la consommation mémoire.
- **Images liées** peuvent maintenir le package plus petit, mais la présentation dépend de la disponibilité continue des fichiers externes aux emplacements stockés.
- **Recadrage** est initialement non destructif. Les pixels masqués restent incorporés jusqu'à ce que les zones recadrées soient explicitement supprimées ou retirées lors de la compression.
- **Compression** peut réduire considérablement la taille du fichier pour les images matricielles surdimensionnées, mais elle sacrifie la résolution source. Elle doit être appliquée après que la taille finale sur la diapositive soit connue.
- **Images SVG** doivent rester au format SVG lorsque la préservation vectorielle est importante. Extrayez le SVG incorporé directement lorsque vous avez besoin de la ressource vectorielle elle‑même. Les exportations de diapositive matricielles convertissent toujours la diapositive rendue en pixels.
- **Images répétées** doivent réutiliser une ressource [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) existante lorsque cela est possible plutôt que de charger à nouveau le même fichier dans le flux de travail de la présentation.

Pour les grandes présentations, l'optimisation des images est généralement la plus efficace lorsqu'elle est effectuée sélectivement : conservez les logos et diagrammes en tant que contenu vectoriel, compressez les photographies selon leur taille d'affichage réelle, supprimez les pixels recadrés uniquement lorsque l'édition ultérieure n'est pas requise, et évitez les liens externes sauf si la gestion des dépendances fait partie de la conception du déploiement.

## **FAQ**

**Quelle est la différence entre un cadre d'image et une ressource d'image ?**

Un [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) représente une ressource d'image associée à la présentation. Un [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) est une forme sur une diapositive qui affiche une image et stocke la géométrie et le formatage au niveau du cadre tels que la taille, la rotation, les valeurs de recadrage, les effets et les verrous.

**Dois‑je incorporer ou lier les images ?**

Incorporez les images lorsque la présentation doit être portable, archivées ou rendues sans accès à des ressources externes. Reliez les images uniquement lorsque le fait de conserver les fichiers image en dehors du PPTX est intentionnel et que les emplacements externes peuvent être maintenus de façon fiable.

**Le recadrage réduit‑il la taille du fichier PPTX ?**

Pas en soi. Les paramètres de recadrage standard masquent des parties de l'image source mais conservent les pixels sous‑jacents. Utilisez [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ou la compression d'image avec suppression des zones recadrées lorsque ces pixels peuvent être éliminés définitivement.

**Puis‑je restaurer la qualité de l'image après compression ?**

Non. La compression peut réduire la résolution matricielle stockée, et la suppression des régions recadrées élimine les données d'image. Conservez l'image source originale en dehors de la présentation si une édition à haute résolution peut être nécessaire ultérieurement.

**Comment les images SVG doivent‑elles être gérées ?**

Conservez le contenu SVG en tant que SVG lorsque la fidélité vectorielle est importante. L'[ISvgImage](https://reference.aspose.com/slides/fr/net/aspose.slides/isvgimage/) incorporé peut être extrait directement. Rendre une diapositive vers un format matriciel tel que PNG ou JPEG rasterise le SVG comme partie de l'image de la diapositive.

**Comment éviter les conversions non sécurisées lors de la lecture des diapositives existantes ?**

Vérifiez le type de forme avant d'utiliser des membres spécifiques au cadre d'image. Le filtrage de la collection de formes avec [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) ou le pattern matching évite les conversions invalides et permet au code de gérer les diapositives qui ne contiennent pas de cadres d'image.