---
title: Convertir diapositive
type: docs
weight: 41
url: /net/convert-slide/
keywords: 
- convertir diapositive en image
- exporter diapositive en tant qu'image
- enregistrer diapositive en tant qu'image
- diapositive en image
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- C#
- Csharp
- .NET
- Aspose.Slides pour .NET
description: "Convertir des diapositives PowerPoint en images (bitmap, PNG ou JPG) en C# ou .NET"
---

Aspose.Slides pour .NET vous permet de convertir des diapositives (dans des présentations) en images. Voici les formats d'image pris en charge : BMP, PNG, JPG (JPEG), GIF, et d'autres. 

Pour convertir une diapositive en image, procédez comme suit : 

1. Tout d'abord, définissez les paramètres de conversion et les objets diapositive à convertir en utilisant :
   * l'interface [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) ou
   * l'interface [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions). 

2. Deuxièmement, convertissez la diapositive en image en utilisant la méthode [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

## **À propos du Bitmap et d'autres formats d'image**

Dans .NET, un [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0) est un objet qui vous permet de travailler avec des images définies par des données de pixels. Vous pouvez utiliser une instance de cette classe pour enregistrer des images dans un large éventail de formats (BMP, JPG, PNG, etc.).

{{% alert title="Info" color="info" %}}

Aspose a récemment développé un convertisseur en ligne [Texte en GIF](https://products.aspose.app/slides/text-to-gif). 

{{% /alert %}}

## **Conversion des diapositives en bitmap et sauvegarde des images en PNG**

Ce code C# vous montre comment convertir la première diapositive d'une présentation en un objet bitmap, puis comment enregistrer l'image au format PNG :

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convertit la première diapositive de la présentation en un objet Bitmap
    using (IImage image = pres.Slides[0].GetImage())
    {
        // Enregistre l'image au format PNG
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert title="Astuce" color="primary" %}} 

Vous pouvez convertir une diapositive en un objet bitmap, puis utiliser l'objet directement quelque part. Ou vous pouvez convertir une diapositive en bitmap, puis enregistrer l'image en JPEG ou tout autre format de votre choix. 

{{% /alert %}}  

## **Conversion des diapositives en images avec des tailles personnalisées**

Vous pourriez avoir besoin d'obtenir une image d'une certaine taille. En utilisant une surcharge de la méthode [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/), vous pouvez convertir une diapositive en image avec des dimensions spécifiques (longueur et largeur). 

Ce code d'exemple démontre la conversion proposée en utilisant la méthode [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) en C# :

``` csharp 
using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Convertit la première diapositive de la présentation en un Bitmap avec la taille spécifiée
    using (IImage image = pres.Slides[0].GetImage(new Size(1820, 1040)))
    {
        // Enregistre l'image au format JPEG
        image.Save("Slide_0.jpg", ImageFormat.Jpeg);
    }
}
```

## **Conversion des diapositives avec notes et commentaires en images**

Certaines diapositives contiennent des notes et des commentaires. 

Aspose.Slides fournit deux interfaces—[ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) et [IRenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/irenderingoptions)—qui vous permettent de contrôler le rendu des diapositives de présentation en images. Les deux interfaces contiennent l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) qui vous permet d'ajouter des notes et des commentaires sur une diapositive lorsque vous convertissez cette diapositive en image.

{{% alert title="Info" color="info" %}} 

Avec l'interface [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions), vous pouvez spécifier votre position préférée pour les notes et les commentaires dans l'image résultante. 

{{% /alert %}} 

Ce code C# démontre le processus de conversion pour une diapositive avec des notes et des commentaires :

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Crée les options de rendu
    IRenderingOptions options = new RenderingOptions();

    // Définit la position des notes sur la page
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Définit la position des commentaires sur la page 
    options.NotesCommentsLayouting.CommentsPosition = CommentsPositions.Right;

    // Définit la largeur de la zone de sortie des commentaires
    options.NotesCommentsLayouting.CommentsAreaWidth = 500;

    // Définit la couleur de la zone des commentaires
    options.NotesCommentsLayouting.CommentsAreaColor = Color.AntiqueWhite;

    // Convertit la première diapositive de la présentation en un objet Bitmap
    using (IImage image = pres.Slides[0].GetImage(options, 2f, 2f))
    {
        // Enregistre l'image au format GIF
        image.Save("Slide_Notes_Comments_0.gif", ImageFormat.Gif);
    }
}
```

{{% alert title="Note" color="warning" %}} 

Dans tout processus de conversion d'une diapositive en image, la propriété [NotesPositions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions/properties/notesposition) ne peut pas être définie sur BottomFull (pour spécifier la position pour les notes) car le texte d'une note peut être long, ce qui signifie qu'il pourrait ne pas tenir dans la taille d'image spécifiée. 

{{% /alert %}} 

## **Conversion des diapositives en images en utilisant ITiffOptions**

L'interface [ITiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/itiffoptions) vous donne plus de contrôle (en termes de paramètres) sur l'image résultante. En utilisant cette interface, vous pouvez spécifier la taille, la résolution, la palette de couleurs, et d'autres paramètres pour l'image résultante. 

Ce code C# démontre un processus de conversion où ITiffOptions est utilisé pour produire une image en noir et blanc avec une résolution de 300dpi et une taille de 2160 × 2800 :

``` csharp 
using (Presentation pres = new Presentation("PresentationNotesComments.pptx"))
{
    // Obtient une diapositive par son index
    ISlide slide = pres.Slides[0];

    // Crée un objet TiffOptions
    TiffOptions options = new TiffOptions() { ImageSize = new Size(2160, 2880) };

    // Définit la police utilisée au cas où la police source ne serait pas trouvée
    options.DefaultRegularFont = "Arial Black";

    // Définit la position des notes sur la page 
    options.NotesCommentsLayouting.NotesPosition = NotesPositions.BottomTruncated;

    // Définit le format des pixels (noir et blanc)
    options.PixelFormat = ImagePixelFormat.Format1bppIndexed;

    // Définit la résolution
    options.DpiX = 300;
    options.DpiY = 300;

    // Convertit la diapositive en un objet Bitmap
    using (IImage image = slide.GetImage(options))
    {
        // Enregistre l'image au format BMP
        image.Save("PresentationNotesComments.tiff", ImageFormat.Tiff);
    }
}  
```

## **Conversion de toutes les diapositives en images**

Aspose.Slides vous permet de convertir toutes les diapositives d'une seule présentation en images. Essentiellement, vous pouvez convertir la présentation (dans son intégralité) en images. 

Ce code d'exemple vous montre comment convertir toutes les diapositives d'une présentation en images en C# :

```csharp
// Spécifie le chemin vers le répertoire de sortie
string outputDir = @"D:\PresentationImages";

using (Presentation pres = new Presentation("Presentation.pptx"))
{
    // Rendu de la présentation en tableau d'images diapositive par diapositive
    for (int i = 0; i < pres.Slides.Count; i++)
    {
        // Spécifie le réglage pour les diapositives cachées (ne pas rendre les diapositives cachées)
        if (pres.Slides[i].Hidden)
            continue;

        // Convertit la diapositive en un objet Bitmap
        using (IImage image = pres.Slides[i].GetImage(2f, 2f))
        {
            // Crée un nom de fichier pour une image
            string outputFilePath = Path.Combine(outputDir, "Slide_" + i + ".jpg");

            // Enregistre l'image au format JPEG
            image.Save(outputFilePath, ImageFormat.Jpeg);
        }
    }
}
```