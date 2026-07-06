---
title: Gérer les cadres d'image dans les présentations en .NET
linktitle: Cadre d'image
type: docs
weight: 10
url: /fr/net/picture-frame/
keywords:
- cadre d'image
- ajouter un cadre d'image
- créer un cadre d'image
- ajouter une image
- créer une image
- extraire une image
- image raster
- image vectorielle
- rogner une image
- zone rognée
- propriété StretchOff
- mise en forme du cadre d'image
- propriétés du cadre d'image
- échelle relative
- effet d'image
- ratio d'aspect
- transparence d'image
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajoutez des cadres d'image aux présentations PowerPoint et OpenDocument avec Aspose.Slides pour .NET. Simplifiez votre flux de travail et améliorez la conception des diapositives."
---
## **Introduction**

Un cadre d'image est une forme qui contient une image — c'est comme une image dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre d'image. Ainsi, vous pouvez mettre en forme l'image en formatant le cadre d'image.

{{% alert  title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG to PowerPoint](https://products.aspose.app/slides/fr/import/jpg-to-ppt) et [PNG to PowerPoint](https://products.aspose.app/slides/fr/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

## **Créer un cadre d'image**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation). 
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet forme associé à la diapositive référencée.
6. Ajoutez un cadre d'image (contenant l'image) à la diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre comment créer un cadre d'image :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{
    // Obtient la première diapositive
    ISlide slide = pres.Slides[0];

    // Charge une image et l'ajoute à la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre d'image avec la même hauteur et largeur
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applique un certain formatage au cadre d'image
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Enregistre la présentation dans un fichier PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Les cadres d'image vous permettent de créer rapidement des diapositives de présentation à partir d'images. En combinant le cadre d'image avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir les images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image to JPG](https://products.aspose.com/slides/fr/net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/fr/net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/fr/net/conversion/jpg-to-png/), convertir [PNG to JPG](https://products.aspose.com/slides/fr/net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/fr/net/conversion/png-to-svg/), convertir [SVG to PNG](https://products.aspose.com/slides/fr/net/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un cadre d'image avec échelle relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre d'image plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation). 
2. Obtenez la référence d'une diapositive via son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre d'image.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre comment créer un cadre d'image avec échelle relative :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Charge une image et l'ajoute à la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre d'image à la diapositive
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Définit la largeur et la hauteur d'échelle relative
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Enregistre la présentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extraire les images raster des cadres d'image**

Vous pouvez extraire des images raster des objets [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe) et les enregistrer au format PNG, JPG et autres. L'exemple de code ci-dessous montre comment extraire une image du document "sample.pptx" et l'enregistrer au format PNG.

```c#
using (var presentation = new Presentation("sample.pptx"))
{
    var firstSlide = presentation.Slides[0];
    var firstShape = firstSlide.Shapes[0];

    if (firstShape is IPictureFrame pictureFrame)
    {
        var image = pictureFrame.PictureFormat.Picture.Image.SystemImage;
        image.Save("slide_1_shape_1.png", ImageFormat.Png);
    }
}
```

## **Extraire les images SVG des cadres d'image**

Lorsqu'une présentation contient des graphiques SVG placés à l'intérieur de formes [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/), Aspose.Slides pour .NET vous permet de récupérer les images vectorielles originales avec une fidélité totale. En parcourant la collection de formes de la diapositive, vous pouvez identifier chaque [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/), vérifier si le [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) sous-jacent contient du contenu SVG, puis enregistrer cette image sur le disque ou dans un flux dans son format SVG natif.

L'exemple de code suivant montre comment extraire une image SVG d'un cadre d'image :

```cs
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

if (shape is IPictureFrame pictureFrame)
{
    var svgImage = pictureFrame.PictureFormat.Picture.Image.SvgImage;
    if (svgImage != null)
    {
        File.WriteAllText("output.svg", svgImage.SvgContent);
    }
}
```

## **Obtenir la transparence d'une image**

Aspose.Slides vous permet d'obtenir l'effet de transparence appliqué à une image. Ce code C# démontre l'opération :

```c#
using (var presentation = new Presentation("Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Picture transparency: " + transparencyValue);
        }
    }
}
```

## **Obtenir la luminosité et le contraste d'une image**

Aspose.Slides vous permet d'obtenir l'effet de luminosité et de contraste appliqué à une image. L'interface [ILuminance](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iluminance/) représente cet effet de transformation d'image.

Ce code C# montre comment obtenir les réglages de luminosité et de contraste d'un cadre d'image :

```csharp
using (var presentation = new Presentation("sample.pptx"))
{
    var slide = presentation.Slides[0];
    var shape = slide.Shapes[0];
    var pictureFrame = (IPictureFrame)shape;

    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is ILuminance luminanceEffect)
        {
            var luminance = luminanceEffect.GetEffective();
            var brightness = luminance.Brightness;
            var contrast = luminance.Contrast;

            Console.WriteLine("Brightness: " + brightness);
            Console.WriteLine("Contrast: " + contrast);
        }
    }
}
```

{{% alert color="primary" %}} 
Tous les effets appliqués aux images sont répertoriés dans [Aspose.Slides.Effects](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/).
{{% /alert %}}

## **Mise en forme du cadre d'image**

Aspose.Slides propose de nombreuses options de mise en forme pouvant être appliquées à un cadre d'image. En utilisant ces options, vous pouvez modifier un cadre d'image pour qu'il réponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/fr/aspose.slides/) .
2. Obtenez la référence d'une diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage) en ajoutant une image à la [IImagescollection](https://reference.aspose.com/slides/fr/net/aspose.slides/iimagecollection) associée à l'objet présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](http://www.aspose.com/api/net/slides/fr/aspose.slides/ishapecollection/methods/addpictureframe) exposée par l'objet [IShapes](http://www.aspose.com/api/net/slides/fr/aspose.slides/ishapecollection) associé à la diapositive référencée.
6. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
7. Définissez la couleur de la bordure du cadre d'image.
8. Définissez la largeur de la bordure du cadre d'image.
9. Faites pivoter le cadre d'image en lui attribuant une valeur positive ou négative.
   * Une valeur positive fait pivoter l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait pivoter l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre d'image (contenant l'image) à la diapositive.
11. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre le processus de mise en forme du cadre d'image :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Obtient la première diapositive
    ISlide slide = presentation.Slides[0];

    // Charge une image et l'ajoute à la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre d'image avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applique un certain formatage au cadre d'image
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Enregistre la présentation dans un fichier PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose a récemment développé un [Collage Maker gratuit](https://products.aspose.app/slides/fr/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG, ou de [créer des grilles à partir de photos](https://products.aspose.app/slides/fr/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une image sous forme de lien**

Pour éviter que les présentations deviennent volumineuses, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'intégrer les fichiers directement dans les présentations. Ce code C# montre comment ajouter une image et une vidéo dans un espace réservé :

```c#
using (var presentation = new Presentation("input.pptx"))
{
    var shapesToRemove = new List<IShape>();
    int shapesCount = presentation.Slides[0].Shapes.Count;

    for (var i = 0; i < shapesCount; i++)
    {
        var autoShape = presentation.Slides[0].Shapes[i];

        if (autoShape.Placeholder == null)
        {
            continue;
        }

        switch (autoShape.Placeholder.Type)
        {
            case PlaceholderType.Picture:
                var pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle,
                        autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, null);

                pictureFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                shapesToRemove.Add(autoShape);
                break;

            case PlaceholderType.Media:
                var videoFrame = presentation.Slides[0].Shapes.AddVideoFrame(
                    autoShape.X, autoShape.Y, autoShape.Width, autoShape.Height, "");

                videoFrame.PictureFormat.Picture.LinkPathLong =
                    "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg";

                videoFrame.LinkPathLong = "https://youtu.be/t_1LYZ102RA";

                shapesToRemove.Add(autoShape);
                break;
        }
    }

    foreach (var shape in shapesToRemove)
    {
        presentation.Slides[0].Shapes.Remove(shape);
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Rogner des images**

Ce code C# montre comment rogner une image existante sur une diapositive :

```c#
using (Presentation presentation = new Presentation())
{
    // Crée un nouvel objet image
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute un PictureFrame à une diapositive
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Recadre l'image (valeurs en pourcentage)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Enregistre le résultat
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## **Supprimer les zones rognées d'un cadre d'image**

Si vous souhaitez supprimer les zones rognées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) . Cette méthode renvoie l'image rognée ou l'image d'origine si le rognage n'est pas nécessaire.

Ce code C# montre l'opération :

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtient le PictureFrame de la première diapositive
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Supprime les zones rognées de l'image du PictureFrame et renvoie l'image rognée
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Enregistre le résultat
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

La méthode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ajoute l'image rognée à la collection d'images de la présentation. Si l'image n'est utilisée que dans le [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les fichiers métas WMF/EMF en images PNG raster lors de l'opération de rognage. 

{{% /alert %}}

## **Compresser des images**

Vous pouvez compresser une image dans une présentation à l'aide de la méthode [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat/compressimage/) . Cette méthode compresse une image en réduisant sa taille en fonction de la taille de la forme et de la résolution spécifiée, avec la possibilité de supprimer les zones rognées. 

Elle ajuste la taille et la résolution de l'image de façon similaire à la fonctionnalité **Picture Format → Compress Pictures → Resolution** de PowerPoint.

Les exemples C# suivants montrent comment compresser une image dans une présentation en spécifiant une résolution cible et en supprimant éventuellement les zones rognées :

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Compresse l'image avec une résolution cible de 150 DPI (résolution Web) et supprime les zones rognées.
    bool result = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);

    // Vérifie le résultat de la compression.
    if (result)
    {
        Console.WriteLine("Image successfully compressed.");
    }
    else
    {
        Console.WriteLine("Image compression failed or no changes were necessary.");
    }

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

Ou en utilisant directement une valeur DPI personnalisée :

```csharp
using (Presentation presentation = new Presentation("demo.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IPictureFrame pictureFrame = slide.Shapes[0] as IPictureFrame;

    // Compresse l'image à 150 DPI (résolution Web), en supprimant les zones rognées.
    pictureFrame.PictureFormat.CompressImage(true, 150f);

    presentation.Save("CompressedImage.pptx", SaveFormat.Pptx);
}
```

{{% alert title="NOTE" color="warning" %}} 

La méthode convertit l'image à une résolution inférieure en fonction de la taille de la forme et du DPI fourni. Les régions rognées peuvent également être supprimées pour optimiser la taille du fichier. Si l'image est un métafichier (WMF/EMF) ou un SVG, la compression ne sera pas appliquée. De plus, la qualité JPEG est préservée ou légèrement réduite selon la résolution, de façon similaire à la gestion des JPEG haute résolution par PowerPoint.

{{% /alert %}}

## **Verrouiller le ratio d'aspect**

Si vous souhaitez qu'une forme contenant une image conserve son ratio d'aspect même après modification des dimensions de l'image, vous pouvez utiliser la propriété [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframelock/aspectratiolocked/) pour définir le paramètre *Lock Aspect Ratio*. 

Ce code C# montre comment verrouiller le ratio d'aspect d'une forme :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Définit la forme pour conserver le ratio d'aspect lors du redimensionnement
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="NOTE" color="warning" %}} 

Ce réglage *Lock Aspect Ratio* préserve uniquement le ratio d'aspect de la forme et non celui de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/properties/stretchoffsetright) et [StretchOffsetBottom](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ipicturefillformat) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/picturefillformat), vous pouvez spécifier un rectangle de remplissage. 

Lorsque l'étirement est spécifié pour une image, un rectangle source est redimensionné pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage en pourcentage par rapport au bord correspondant de la boîte englobante de la forme. Un pourcentage positif indique un retrait, tandis qu'un pourcentage négatif indique un dépassement.

1. Créez une instance de la [Presentation](http://www.aspose.com/api/net/slides/fr/aspose.slides/) classe.
2. Obtenez la référence d'une diapositive via son index.
3. Ajoutez un rectangle `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image définie pour remplir la forme.
8. Spécifiez les décalages de l'image depuis le bord correspondant de la boîte englobante de la forme
9. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre un processus dans lequel une propriété StretchOff est utilisée :

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Définit l'image étirée depuis chaque côté dans le corps de la forme
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Comment savoir quels formats d'image sont pris en charge pour PictureFrame ?**

Aspose.Slides prend en charge à la fois les images raster (PNG, JPEG, BMP, GIF, etc.) et les images vectorielles (par exemple, SVG) via l'objet image assigné à un [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/). La liste des formats pris en charge chevauche généralement les capacités du moteur de conversion de diapositives et d'images.

**Comment l'ajout de dizaines d'images volumineuses affecte-t-il la taille et les performances du PPTX ?**

L'intégration d'images volumineuses augmente la taille du fichier et l'utilisation de la mémoire ; le lien vers des images contribue à réduire la taille de la présentation mais nécessite que les fichiers externes restent accessibles. Aspose.Slides offre la possibilité d'ajouter des images par lien pour diminuer la taille du fichier.

**Comment puis‑je verrouiller un objet image pour éviter un déplacement/redimensionnement accidentel ?**

Utilisez les [verrous de forme](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/pictureframelock/) pour un [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/) (par exemple, désactiver le déplacement ou le redimensionnement). Le mécanisme de verrouillage est décrit pour les formes dans un [article de protection](/slides/fr/net/applying-protection-to-presentation/) séparé et est pris en charge pour divers types de formes, y compris [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/).

**La fidélité vectorielle SVG est‑elle préservée lors de l'exportation d'une présentation vers PDF/images ?**

Aspose.Slides permet d'extraire un SVG d'un [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/) en tant que vecteur original. Lors de l'[exportation vers PDF](/slides/fr/net/convert-powerpoint-to-pdf/) ou vers des [formats raster](/slides/fr/net/convert-powerpoint-to-png/), le résultat peut être rasterisé selon les paramètres d'exportation ; le fait que le SVG original soit stocké en tant que vecteur est confirmé par le comportement d'extraction.