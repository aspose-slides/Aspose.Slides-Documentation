---
title: Convertir les diapositives de présentation en images en .NET
linktitle: Diapositive en image
type: docs
weight: 41
url: /fr/net/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive vers image
- enregistrer diapositive en tant qu'image
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
description: "Convertissez les diapositives PPT, PPTX et ODP en images en C# avec Aspose.Slides for .NET—rendu rapide et de haute qualité avec des exemples de code clairs."
---
## **Introduction**

Aspose.Slides for .NET vous permet de convertir facilement les diapositives PowerPoint et OpenDocument en divers formats d’image, notamment BMP, PNG, JPG (JPEG), GIF et d’autres.

Pour convertir une diapositive en image, suivez ces étapes :

1. Définissez les paramètres de conversion souhaités et sélectionnez les diapositives à exporter en utilisant :
    - L’interface [ITiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/itiffoptions/), ou
    - L’interface [IRenderingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/irenderingoptions/).
2. Générez l’image de la diapositive en appelant la méthode [GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/).

Dans .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) est un objet qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans un large éventail de formats (BMP, JPG, PNG, etc.).

## **Convertir des diapositives en Bitmap et enregistrer les images en PNG**

Vous pouvez convertir une diapositive en un objet bitmap et l’utiliser directement dans votre application. Vous pouvez également convertir une diapositive en bitmap puis enregistrer l’image en JPEG ou dans tout autre format de votre choix.

Ce code C# montre comment convertir la première diapositive d’une présentation en objet bitmap puis enregistrer l’image au format PNG :

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Convertir la première diapositive de la présentation en bitmap.
    using (IImage image = presentation.Slides[0].GetImage())
    {
        // Enregistrer l'image au format PNG.
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Il peut être nécessaire d’obtenir une image d’une taille précise. En utilisant une surcharge de la méthode [GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/islide/getimage/), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (largeur et hauteur).

Ce code d’exemple montre comment procéder :

```cs
Size imageSize = new Size(1820, 1040);

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Convertir la première diapositive de la présentation en bitmap avec la taille spécifiée.
    using (IImage image = presentation.Slides[0].GetImage(imageSize))
    {
        // Enregistrer l'image au format JPEG.
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Convertir des diapositives avec notes et commentaires en images**

Certaines diapositives peuvent contenir des notes et des commentaires.

Aspose.Slides propose deux interfaces — [ITiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/itiffoptions/) et [IRenderingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/irenderingoptions/) — qui vous permettent de contrôler le rendu des diapositives en images. Les deux interfaces incluent la propriété `SlidesLayoutOptions`, qui vous permet de configurer le rendu des notes et des commentaires lors de la conversion en image.

Avec la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/notescommentslayoutingoptions/), vous pouvez spécifier la position souhaitée pour les notes et les commentaires dans l’image résultante.

Ce code C# montre comment convertir une diapositive avec notes et commentaires :

```cs
float scaleX = 2;
float scaleY = scaleX;

// Charger un fichier de présentation.
using (Presentation presentation = new Presentation("Presentation_with_notes_and_comments.pptx"))
{
    // Créer les options de rendu.
    RenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,  // Définir la position des notes.
            CommentsPosition = CommentsPositions.Right,      // Définir la position des commentaires.
            CommentsAreaWidth = 500,                         // Définir la largeur de la zone des commentaires.
            CommentsAreaColor = Color.AntiqueWhite           // Définir la couleur de la zone des commentaires.
        }
    };

    // Convertir la première diapositive de la présentation en image.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        // Enregistrer l'image au format GIF.
        image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 
Dans tout processus de conversion diapositive‑vers‑image, la propriété [NotesPosition](https://reference.aspose.com/slides/fr/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) ne peut pas être définie sur `BottomFull` (pour spécifier la position des notes) car le texte d’une note peut être trop volumineux et ne pas tenir dans la taille d’image spécifiée.
{{% /alert %}} 

## **Convertir des diapositives en images en utilisant les options TIFF**

L’interface [ITiffOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/itiffoptions/) offre un contrôle plus poussé sur l’image TIFF résultante en vous permettant de spécifier des paramètres tels que la taille, la résolution, la palette de couleurs, etc.

Ce code C# montre un processus de conversion où les options TIFF sont utilisées pour produire une image en noir et blanc avec une résolution de 300 dpi et une taille de 2160 × 2800 :

```cs
// Charger un fichier de présentation.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Obtenir la première diapositive de la présentation.
    ISlide slide = presentation.Slides[0];

    // Configurer les paramètres de l'image TIFF de sortie.
    TiffOptions tiffOptions = new TiffOptions
    {
        ImageSize = new Size(2160, 2880),                  // Définir la taille de l'image.
        PixelFormat = ImagePixelFormat.Format1bppIndexed,  // Définir le format de pixel (noir et blanc).
        DpiX = 300,                                        // Définir la résolution horizontale.
        DpiY = 300                                         // Définir la résolution verticale.
    };

    // Convertir la diapositive en image avec les options spécifiées.
    using (IImage image = slide.GetImage(tiffOptions))
    {
        // Enregistrer l'image au format TIFF.
        image.Save("output.tiff", ImageFormat.Tiff);
    }
}
```

## **Convertir toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d’une présentation en images, transformant ainsi l’ensemble de la présentation en une série d’images.

Ce code d’exemple montre comment convertir toutes les diapositives d’une présentation en images avec C# :

```cs
float scaleX = 2;
float scaleY = scaleX;

using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    // Rendre la présentation en images diapositive par diapositive.
    for (int i = 0; i < presentation.Slides.Count; i++)
    {
        // Contrôler les diapositives masquées (ne pas rendre les diapositives masquées).
        if (presentation.Slides[i].Hidden)
            continue;

        // Convertir la diapositive en image.
        using (IImage image = presentation.Slides[i].GetImage(scaleX, scaleY))
        {
            // Enregistrer l'image au format JPEG.
            image.Save($"Slide_{i}.jpg", ImageFormat.Jpeg);
        }
    }
}
```

## **Rendu des emojis en couleur**

{{% alert title="Note" color="warning" %}} 
Pour rendre correctement les emojis en couleur lors de la conversion des diapositives en images, les polices d’emoji utilisées dans la présentation doivent être installées et disponibles sur le système qui effectue la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images générées.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge le rendu des diapositives avec animations ?**

Non, la méthode `GetImage` enregistre uniquement une image statique de la diapositive, sans animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui, les diapositives masquées peuvent être traitées comme les diapositives normales. Assurez‑vous simplement qu’elles soient incluses dans la boucle de traitement.

**Les images peuvent‑elles être enregistrées avec des ombres et des effets ?**

Oui, Aspose.Slides prend en charge le rendu des ombres, de la transparence et d’autres effets graphiques lors de l’enregistrement des diapositives en images.