---
title: Cadre Photo
type: docs
weight: 10
url: /net/picture-frame/
keywords: 
- ajouter un cadre photo
- créer un cadre photo
- ajouter une image
- créer une image
- extraire une image
- propriété StretchOff
- formatage du cadre photo
- propriétés du cadre photo
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Ajouter un cadre photo à une présentation PowerPoint en C# ou .NET"
---

Un cadre photo est une forme qui contient une image—c'est comme une photo dans un cadre. 

Vous pouvez ajouter une image à une diapositive via un cadre photo. De cette manière, vous pouvez formater l'image en formatant le cadre photo.

{{% alert  title="Conseil" color="primary" %}} 

Aspose fournit des convertisseurs gratuits—[JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)—qui permettent aux utilisateurs de créer rapidement des présentations à partir d'images. 

{{% /alert %}} 

## **Créer un Cadre Photo**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Obtenez une référence à la diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associée à l'objet de la présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) basé sur la largeur et la hauteur de l'image via la méthode `AddPictureFrame` exposée par l'objet de forme associé à la diapositive référencée.
6. Ajoutez un cadre photo (contenant l'image) à la diapositive.
7. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# montre comment créer un cadre photo :

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

    // Ajoute un cadre photo avec la même hauteur et largeur
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applique un certain formatage au cadre photo
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Écrit la présentation dans un fichier PPTX
    pres.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="warning" %}} 

Les cadres photo vous permettent de créer rapidement des diapositives de présentation basées sur des images. Lorsque vous combinez un cadre photo avec les options d'enregistrement d'Aspose.Slides, vous pouvez manipuler les opérations d'entrée/sortie pour convertir des images d'un format à un autre. Vous voudrez peut-être consulter ces pages : convertir [image en JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Créer un Cadre Photo avec Échelle Relative**

En modifiant l'échelle relative d'une image, vous pouvez créer un cadre photo plus complexe. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez une référence à la diapositive via son index. 
3. Ajoutez une image à la collection d'images de la présentation.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associée à l'objet de la présentation qui sera utilisé pour remplir la forme.
5. Spécifiez la largeur et la hauteur relatives de l'image dans le cadre photo.
6. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# montre comment créer un cadre photo avec échelle relative :

```c#
// Instancie la classe Presentation qui représente un fichier PPTX
using (Presentation presentation = new Presentation())
{
    // Charge une image et l'ajoute à la collection d'images de la présentation
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute un cadre photo à la diapositive
    IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Définit la largeur et la hauteur d'échelle relative
    pictureFrame.RelativeScaleHeight = 0.8f;
    pictureFrame.RelativeScaleWidth = 1.35f;

    // Sauvegarde la présentation
    presentation.Save("Adding Picture Frame with Relative Scale_out.pptx", SaveFormat.Pptx);
}
```

## **Extraire une Image d'un Cadre Photo**

Vous pouvez extraire des images d'objets [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe) et les sauvegarder au format PNG, JPG, et autres. L'exemple de code ci-dessous démontre comment extraire une image du document "sample.pptx" et la sauvegarder au format PNG.

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

## **Obtenir la Transparence d'une Image**

Aspose.Slides vous permet d'obtenir la transparence d'une image. Ce code C# démontre l'opération :

```c#
using (var presentation = new Presentation(folderPath + "Test.pptx"))
{
    var pictureFrame = (IPictureFrame)presentation.Slides[0].Shapes[0];
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    foreach (var effect in imageTransform)
    {
        if (effect is IAlphaModulateFixed alphaModulateFixed)
        {
            var transparencyValue = 100 - alphaModulateFixed.Amount;
            Console.WriteLine("Transparence de l'image : " + transparencyValue);
        }
    }
}
```

## **Formatage du Cadre Photo**

Aspose.Slides fournit de nombreuses options de formatage qui peuvent être appliquées à un cadre photo. En utilisant ces options, vous pouvez modifier un cadre photo pour qu'il corresponde à des exigences spécifiques.

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez une référence à la diapositive via son index. 
3. Créez un objet [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) en ajoutant une image à la collection [IImages](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) associée à l'objet de la présentation qui sera utilisé pour remplir la forme.
4. Spécifiez la largeur et la hauteur de l'image.
5. Créez un `PictureFrame` basé sur la largeur et la hauteur de l'image via la méthode [AddPictureFrame](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection/methods/addpictureframe) exposée par l'objet [IShapes](http://www.aspose.com/api/net/slides/aspose.slides/ishapecollection) associé à la diapositive référencée.
6. Ajoutez le cadre photo (contenant l'image) à la diapositive.
7. Définissez la couleur de ligne du cadre photo.
8. Définissez la largeur de ligne du cadre photo.
9. Faites tourner le cadre photo en lui donnant une valeur positive ou négative.
   * Une valeur positive fait tourner l'image dans le sens des aiguilles d'une montre. 
   * Une valeur négative fait tourner l'image dans le sens inverse des aiguilles d'une montre.
10. Ajoutez le cadre photo (contenant l'image) à la diapositive.
11. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# démontre le processus de formatage du cadre photo :

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

    // Ajoute un cadre photo avec la hauteur et la largeur équivalentes de l'image
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Applique un certain formatage au cadre photo
    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    pictureFrame.LineFormat.Width = 20;
    pictureFrame.Rotation = 45;

    // Écrit la présentation dans un fichier PPTX
    presentation.Save("RectPicFrameFormat_out.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}

Aspose a récemment développé un [Créateur de Collages gratuit](https://products.aspose.app/slides/collage). Si vous avez besoin de [fusionner des images JPG/JPEG](https://products.aspose.app/slides/collage/jpg) ou PNG, [créer des grilles à partir de photos](https://products.aspose.app/slides/collage/photo-grid), vous pouvez utiliser ce service. 

{{% /alert %}}

## **Ajouter une Image comme Lien**

Pour éviter de gros fichiers de présentation, vous pouvez ajouter des images (ou des vidéos) via des liens au lieu d'incorporer les fichiers directement dans les présentations. Ce code C# montre comment ajouter une image et une vidéo dans un espace réservé :

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

## **Recadrer une Image**

Ce code C# montre comment recadrer une image existante sur une diapositive :

```c#
using (Presentation presentation = new Presentation())
{
    // Crée un nouvel objet image
    IImage image = Images.FromFile(imagePath);
    IPPImage newImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Ajoute un PictureFrame à une Diapositive
    IPictureFrame picFrame = presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 100, 100, 420, 250, newImage);

    // Recadre l'image (valeurs en pourcentage)
    picFrame.PictureFormat.CropLeft = 23.6f;
    picFrame.PictureFormat.CropRight = 21.5f;
    picFrame.PictureFormat.CropTop = 3;
    picFrame.PictureFormat.CropBottom = 31;

    // Sauvegarde le résultat
    presentation.Save("PictureFrameCrop.pptx", SaveFormat.Pptx);
}
```

## Supprimer les Zones Recadrées d'une Image

Si vous souhaitez supprimer les zones recadrées d'une image contenue dans un cadre, vous pouvez utiliser la méthode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/). Cette méthode renvoie l'image recadrée ou l'image d'origine si le recadrage n'est pas nécessaire.

Ce code C# démontre l'opération :

```c#
using (Presentation presentation = new Presentation("PictureFrameCrop.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtient le PictureFrame de la première diapositive
    IPictureFrame picFrame = slide.Shapes[0] as IPictureFrame;

    // Supprime les zones recadrées de l'image du PictureFrame et renvoie l'image recadrée
    IPPImage croppedImage = picFrame.PictureFormat.DeletePictureCroppedAreas();

    // Sauvegarde le résultat
    presentation.Save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
}
```

{{% alert title="REMARQUE" color="warning" %}} 

La méthode [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) ajoute l'image recadrée à la collection d'images de la présentation. Si l'image est uniquement utilisée dans le [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) traité, cette configuration peut réduire la taille de la présentation. Sinon, le nombre d'images dans la présentation résultante augmentera.

Cette méthode convertit les mét fichiers WMF/EMF en image raster PNG lors de l'opération de recadrage. 

{{% /alert %}}

## **Verrouiller le Rapport d'Aspect**

Si vous souhaitez qu'une forme contenant une image conserve son rapport d'aspect même après avoir changé les dimensions de l'image, vous pouvez utiliser la propriété [IPictureFrameLock.AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/aspectratiolocked/) pour définir le réglage *Verrouiller le Rapport d'Aspect*. 

Ce code C# montre comment verrouiller le rapport d'aspect d'une forme :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.Slides.AddEmptySlide(layout);

    IImage image = Images.FromFile("image.png");
    IPPImage presImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = emptySlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, presImage.Width, presImage.Height, presImage);

    // Définit la forme pour préserver le rapport d'aspect lors du redimensionnement
    pictureFrame.PictureFrameLock.AspectRatioLocked = true;
}
```

{{% alert title="REMARQUE" color="warning" %}} 

Ce réglage *Verrouiller le Rapport d'Aspect* préserve uniquement le rapport d'aspect de la forme et non de l'image qu'elle contient.

{{% /alert %}}

## **Utiliser la Propriété StretchOff**

En utilisant les propriétés [StretchOffsetLeft](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetleft), [StretchOffsetTop](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsettop), [StretchOffsetRight](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetright) et [StretchOffsetBottom](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/properties/stretchoffsetbottom) de l'interface [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat) et de la classe [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat), vous pouvez spécifier un rectangle de remplissage. 

Lorsque l'étirement est spécifié pour une image, un rectangle source est mis à l'échelle pour s'adapter au rectangle de remplissage spécifié. Chaque bord du rectangle de remplissage est défini par un décalage de pourcentage par rapport au bord correspondant de la boîte de délimitation de la forme. Un pourcentage positif spécifie un retrait tandis qu'un pourcentage négatif spécifie un avancement.

1. Créez une instance de la classe [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/).
2. Obtenez une référence à la diapositive via son index.
3. Ajoutez une forme rectangulaire `AutoShape`. 
4. Créez une image.
5. Définissez le type de remplissage de la forme.
6. Définissez le mode de remplissage d'image de la forme.
7. Ajoutez une image à remplir la forme.
8. Spécifiez les décalages de l'image par rapport au bord correspondant de la boîte de délimitation de la forme.
9. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code C# démontre un processus où une propriété StretchOff est utilisée :

```c#
using (Presentation pres = new Presentation())
{
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 400, ppImage);

    // Définit l'image étirée de chaque côté dans le corps de la forme
    pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
    pictureFrame.PictureFormat.StretchOffsetLeft = 24;
    pictureFrame.PictureFormat.StretchOffsetRight = 24;
    pictureFrame.PictureFormat.StretchOffsetTop = 24;
    pictureFrame.PictureFormat.StretchOffsetBottom = 24;

    pres.Save("imageStretch.pptx", SaveFormat.Pptx);
}
```