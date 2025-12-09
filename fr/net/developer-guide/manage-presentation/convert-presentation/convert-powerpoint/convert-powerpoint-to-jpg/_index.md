---
title: Convertir PPT et PPTX en JPG avec .NET
linktitle: PowerPoint en JPG
type: docs
weight: 60
url: /fr/net/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en JPG
- présentation en JPG
- diapositive en JPG
- PPT en JPG
- PPTX en JPG
- enregistrer PowerPoint en JPG
- enregistrer présentation en JPG
- enregistrer diapositive en JPG
- enregistrer PPT en JPG
- enregistrer PPTX en JPG
- exporter PPT en JPG
- exporter PPTX en JPG
- .NET
- C#
- Aspose.Slides
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en C# avec Aspose.Slides pour .NET à l'aide d'exemples de code rapides et fiables."
---

## **Vue d'ensemble**

La conversion des présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration du contenu dans des sites Web ou des applications. Aspose.Slides for .NET vous permet de transformer les fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visionneuse de présentations et de créer une vignette pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides permet de convertir l’ensemble de la présentation ou une diapositive spécifique en formats d’image.

## **Convertir les diapositives de présentation en images JPG**

Voici les étapes pour convertir un fichier PPT, PPTX ou ODP en JPG :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Récupérez l’objet diapositive de type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) depuis la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
3. Créez une image de la diapositive en utilisant la méthode [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
4. Appelez la méthode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) sur l’objet image. Passez le nom du fichier de sortie et le format d’image en arguments.

{{% alert color="primary" %}} 
**Note :** La conversion PPT, PPTX ou ODP en JPG diffère de la conversion vers d’autres formats dans l’API Aspose.Slides .NET. Pour d’autres formats, vous utilisez généralement la méthode [IPresentation.Save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). Cependant, pour la conversion en JPG, vous devez utiliser la méthode [IImage.Save(string, ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).
{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Créez une image de diapositive à l'échelle spécifiée.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Enregistrez l'image sur le disque au format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG générées, vous pouvez définir la taille de l’image en la transmettant à la méthode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). Cela vous permet de créer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que la sortie répond à vos exigences de résolution et de ratio d’aspect. Cette flexibilité est particulièrement utile lors de la génération d’images pour des applications Web, des rapports ou de la documentation, où des dimensions d’image précises sont requises.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Créer une image de diapositive de la taille spécifiée.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Enregistrer l'image sur le disque au format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Rendre les commentaires lors de l’enregistrement des diapositives en images**

Aspose.Slides for .NET propose une fonctionnalité qui vous permet de rendre les commentaires sur les diapositives d’une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour préserver les annotations, les retours ou les discussions ajoutées par les collaborateurs dans les présentations PowerPoint. En activant cette option, vous vous assurez que les commentaires sont visibles dans les images générées, facilitant ainsi la révision et le partage des retours sans avoir à ouvrir le fichier de présentation original.

Supposons que nous disposions d’un fichier de présentation, **sample.pptx**, avec une diapositive contenant des commentaires :

![La diapositive avec des commentaires](slide_with_comments.png)

Le code C# suivant convertit la diapositive en image JPG tout en conservant les commentaires :
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Définir les options pour les commentaires de la diapositive.
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            CommentsPosition = CommentsPositions.Right,
            CommentsAreaWidth = 200,
            CommentsAreaColor = Color.DarkOrange                  
        }
    };

    // Convertir la première diapositive en image.
    using (IImage image = presentation.Slides[0].GetImage(options, scaleX, scaleY))
    {
        image.Save("Slide_1.jpg", ImageFormat.Jpeg);
    }
}
```


Le résultat :

![L’image JPG avec des commentaires](image_with_comments.png)

## **Voir aussi**

Voir d’autres options pour convertir PPT, PPTX ou ODP en images, telles que :

- [Convertir PowerPoint en GIF](/slides/fr/net/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint en PNG](/slides/fr/net/convert-powerpoint-to-png/)
- [Convertir PowerPoint en TIFF](/slides/fr/net/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint en SVG](/slides/fr/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![Convertisseur PPTX en JPG en ligne gratuit](ppt-to-jpg.png)

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web GRATUITE de collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG to JPG](https://products.aspose.app/slides/collage/jpg) ou PNG to PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image to JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG to image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG to PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/); convertir [PNG to JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG to SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/); convertir [SVG to PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lots ?**

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, graphiques, tableaux, formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsqu’il s’agit de polices personnalisées ou manquantes.

**Existe‑t‑il des limites quant au nombre de diapositives pouvant être traitées ?**

Aspose.Slides n’impose aucune limite stricte au nombre de diapositives que vous pouvez traiter. Toutefois, vous pouvez rencontrer des erreurs de mémoire insuffisante lors du traitement de présentations très volumineuses ou d’images haute résolution.