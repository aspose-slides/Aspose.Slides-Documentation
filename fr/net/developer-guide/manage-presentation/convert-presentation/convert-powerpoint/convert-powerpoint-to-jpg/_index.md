---
title: Convertir PowerPoint en JPG en C#
linktitle: Convertir PowerPoint PPT en JPG
type: docs
weight: 60
url: /net/convert-powerpoint-to-jpg/
keywords: 
- Convertir une présentation PowerPoint
- JPG
- JPEG
- PowerPoint en JPG
- PowerPoint en JPEG
- PPT en JPG
- PPTX en JPG
- PPT en JPEG
- PPTX en JPEG
- C#
- Csharp
- .NET
- Aspose.Slides
description: "Convertir PowerPoint en JPG en C# ou .NET. Enregistrer une diapositive comme image JPG"
---

## **Aperçu**

Cet article explique comment convertir une présentation PowerPoint au format JPG en utilisant C#. Il couvre les sujets suivants :

- [C# Convertir PowerPoint en JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir PPT en JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir PPTX en JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir ODP en JPG](#convert-powerpoint-pptpptx-to-jpg)
- [C# Convertir une diapositive PowerPoint en image](#convert-powerpoint-pptpptx-to-jpg)

## **C# PowerPoint en JPG**

Pour le code d'exemple en C# pour convertir PowerPoint en JPG, veuillez consulter la section ci-dessous, c'est-à-dire [Convertir PowerPoint en JPG](#convert-powerpoint-pptpptx-to-jpg). Le code peut charger plusieurs formats comme PPT, PPTX et ODP dans un objet Présentation, puis enregistrer sa miniature de diapositive au format JPG. Les autres conversions PowerPoint en image qui sont assez similaires telles que PNG, BMP, TIFF et SVG sont abordées dans ces articles.

- [C# PowerPoint en PNG](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)
- [C# PowerPoint en BMP](#convert-powerpoint-pptpptx-to-jpg)
- [C# PowerPoint en TIFF](https://docs.aspose.com/slides/net/convert-powerpoint-to-tiff/)
- [C# PowerPoint en SVG](https://docs.aspose.com/slides/net/render-a-slide-as-an-svg-image/)

## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides .NET API**](https://products.aspose.com/slides/net/), vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG. Il est également possible de convertir PPT/PPTX en BMP, PNG ou SVG. Grâce à cette fonctionnalité, il est facile de mettre en œuvre votre propre visualiseur de présentation, de créer la miniature pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de présentation contre le copyright, ou démontrer la présentation en mode lecture seule. Aspose.Slides permet de convertir l'ensemble de la présentation ou une certaine diapositive en formats d'image.

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Obtenez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) à partir de la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. Créez la miniature de chaque diapositive, puis convertissez-la en JPG. La méthode [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) est utilisée pour obtenir une miniature d'une diapositive, elle retourne un objet [Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=netframework-4.8) en résultat. La méthode [GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) doit être appelée depuis la diapositive nécessaire de type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide), les échelles de la miniature résultante sont passées dans la méthode.
4. Après avoir obtenu la miniature de la diapositive, appelez la méthode [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) depuis l'objet miniature. Passez le nom de fichier résultant et le format d'image en paramètre. 

{{% alert color="primary" %}} 
**Remarque** : La conversion PPT/PPTX en JPG diffère de la conversion vers d'autres types dans l'API Aspose.Slides .NET. Pour d'autres types, vous utilisez généralement la méthode [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)** ](https://reference.aspose.com/slides/net/aspose.slides.ipresentation/save/methods/5), mais ici vous devez utiliser la méthode [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```c#
const int imageScale = 1;

using (Presentation pres = new Presentation("PowerPoint-Presentation.ppt"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // Crée une image à échelle complète
        using (IImage thumbnail = slide.GetImage(imageScale, imageScale))
        {
            // Enregistre l'image sur le disque au format JPEG
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```

## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**
Pour changer la dimension de la miniature résultante et de l'image JPG, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant dans la méthode [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5) :

```c#
using (Presentation pres = new Presentation("PowerPoint-Presentation.pptx"))
{
    // Définit les dimensions
    int desiredX = 1200;
    int desiredY = 800;

    // Obtient les valeurs mises à l'échelle de X et Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    foreach (ISlide slide in pres.Slides)
    {
        // Crée une image à échelle complète
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Enregistre l'image sur le disque au format JPEG
			string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Rendre les commentaires lors de la sauvegarde de la présentation en image**
Aspose.Slides pour .NET fournit une fonctionnalité qui vous permet de rendre les commentaires dans les diapositives d'une présentation lorsque vous convertissez ces diapositives en images. Ce code C# démontre l'opération :

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomTruncated,
            CommentsAreaColor = Color.Red,
            CommentsAreaWidth = 200,
            CommentsPosition = CommentsPositions.Right
        }
    };

    using (IImage image = presentation.Slides[0].GetImage(options))
    {
        image.Save("OutPresBitmap.png", ImageFormat.Png);
    }

    System.Diagnostics.Process.Start("OutPresBitmap.png");
}
```

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG en PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d'autres options pour convertir PPT/PPTX en image telles que :

- [Conversion PPT/PPTX en SVG](/slides/net/render-a-slide-as-an-svg-image/).