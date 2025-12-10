---
title: Convertir PPT et PPTX en JPG dans .NET
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
description: "Convertir les diapositives PowerPoint (PPT, PPTX) en images JPG de haute qualité en C# avec Aspose.Slides pour .NET en utilisant des exemples de code rapides et fiables."
---

## **Vue d'ensemble**

Convertir des présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration du contenu dans des sites Web ou des applications. Aspose.Slides for .NET vous permet de transformer des fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Grâce à ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations et de créer une vignette pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides vous permet de convertir la présentation entière ou une diapositive spécifique en formats d’image.

## **Convertir les diapositives d’une présentation en images JPG**

Voici les étapes pour convertir un fichier PPT, PPTX ou ODP en JPG :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Récupérez l’objet diapositive de type [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) depuis la collection [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides).
1. Créez une image de la diapositive en utilisant la méthode [ISlide.GetImage(float,float)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_5).
1. Appelez la méthode [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3) sur l’objet image. Passez le nom du fichier de sortie et le format d’image en arguments.

{{% alert color="primary" %}} 

**Remarque :** La conversion PPT, PPTX ou ODP vers JPG diffère de la conversion vers d’autres formats dans l’API Aspose.Slides .NET. Pour les autres formats, vous utilisez généralement la méthode [IPresentation.Save(String,SaveFormat,ISaveOptions)](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/save/#save_5). toutefois, pour la conversion JPG, vous devez utiliser la méthode [IImage.Save(string,ImageFormat)](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/#save_3).

{{% /alert %}} 
```c#
int scaleX = 1;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("PowerPoint_Presentation.ppt"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Crée une image de diapositive avec l'échelle spécifiée.
        using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
        {
            // Enregistre l'image sur le disque au format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG résultantes, vous pouvez définir la taille de l’image en la transmettant à la méthode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/#getimage_6). Cela vous permet de créer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que la sortie répond à vos exigences de résolution et de rapport d’aspect. Cette flexibilité est particulièrement utile lors de la génération d’images pour des applications Web, des rapports ou de la documentation, où des dimensions d’image précises sont requises.
```c#
Size imageSize = new Size(1200, 800);

using (Presentation presentation = new Presentation("PowerPoint_Presentation.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Créer une image de diapositive avec la taille spécifiée.
        using (IImage thumbnail = slide.GetImage(imageSize))
        {
            // Enregistrer l'image sur le disque au format JPEG.
            string imageFileName = $"Slide_{slide.SlideNumber}.jpg";
            thumbnail.Save(imageFileName, ImageFormat.Jpeg);
        }
    }
}
```


## **Rendu des commentaires lors de l’enregistrement des diapositives en images**

Aspose.Slides for .NET propose une fonction qui vous permet de rendre les commentaires sur les diapositives d’une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour conserver les annotations, les remarques ou les discussions ajoutées par les collaborateurs dans les présentations PowerPoint. En activant cette option, vous assurez que les commentaires sont visibles dans les images générées, facilitant ainsi la révision et le partage des retours sans avoir à ouvrir le fichier de présentation original.

Supposons que nous ayons un fichier de présentation, **"sample.pptx"**, contenant une diapositive avec des commentaires :

![La diapositive avec commentaires](slide_with_comments.png)

Le code C# suivant convertit la diapositive en image JPG tout en conservant les commentaires :
```c#
int scaleX = 2;
int scaleY = scaleX;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    IRenderingOptions options = new RenderingOptions
    {
        // Définir les options pour les commentaires des diapositives.
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

![L’image JPG avec commentaires](image_with_comments.png)

## **Voir aussi**

Voir les autres options de conversion de PPT, PPTX ou ODP en images, telles que :

- [Convert PowerPoint to GIF](/slides/fr/net/convert-powerpoint-to-animated-gif/)
- [Convert PowerPoint to PNG](/slides/fr/net/convert-powerpoint-to-png/)
- [Convert PowerPoint to TIFF](/slides/fr/net/convert-powerpoint-to-tiff/)
- [Convert PowerPoint to SVG](/slides/fr/net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![Convertisseur PPTX vers JPG en ligne gratuit](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose propose une application web [GRATUITE de collage](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des images [JPG vers JPG](https://products.aspose.app/slides/collage/jpg) ou PNG vers PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/net/conversion/image-to-jpg/); convertir [JPG en image](https://products.aspose.com/slides/net/conversion/jpg-to-image/); convertir [JPG en PNG](https://products.aspose.com/slides/net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/net/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/net/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lots ?**

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, graphiques, tableaux, formes, etc. Cependant, la précision du rendu peut légèrement varier par rapport à PowerPoint, notamment avec des polices personnalisées ou manquantes.

**Existe‑t‑il des limites sur le nombre de diapositives pouvant être traitées ?**

Aspose.Slides n’impose pas de limites strictes au nombre de diapositives que vous pouvez traiter. Toutefois, vous pouvez rencontrer une erreur de mémoire insuffisante lors du travail avec de très grandes présentations ou des images haute résolution.