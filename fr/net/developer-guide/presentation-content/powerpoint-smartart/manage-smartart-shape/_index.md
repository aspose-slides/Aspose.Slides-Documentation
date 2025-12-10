---
title: Gérer les graphiques SmartArt dans les présentations en .NET
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/net/manage-smartart-shape/
keywords:
- Objet SmartArt
- Graphique SmartArt
- Style SmartArt
- Couleur SmartArt
- créer SmartArt
- ajouter SmartArt
- modifier SmartArt
- changer SmartArt
- accéder SmartArt
- type de mise en page SmartArt
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint en .NET avec Aspose.Slides, incluant des exemples de code concis et des conseils axés sur la performance."
---

## **Créer une forme SmartArt**
Aspose.Slides pour .NET permet désormais d'ajouter des formes SmartArt personnalisées dans leurs diapositives à partir de zéro. Aspose.Slides pour .NET a fourni l'API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenir la référence d'une diapositive en utilisant son index.
- Ajouter une forme SmartArt en définissant son LayoutType.
- Enregistrer la présentation modifiée sous forme de fichier PPTX.
```c#
// Instancier la présentation
using (Presentation pres = new Presentation())
{

    // Accéder à la diapositive de la présentation
    ISlide slide = pres.Slides[0];

    // Ajouter une forme SmartArt
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Enregistrer la présentation
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Accéder à une forme SmartArt sur une diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans le code d'exemple, nous parcourrons chaque forme à l'intérieur de la diapositive et vérifierons s'il s'agit d'une forme SmartArt. Si la forme est de type SmartArt, nous la convertirons en instance SmartArt.
```c#
// Charger la présentation souhaitée
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Parcourir toutes les formes de la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Accéder à une forme SmartArt avec un type de Layout particulier**
Le code d'exemple suivant vous aidera à accéder à la forme SmartArt avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt, car il est en lecture seule et n'est défini que lors de l'ajout de la forme SmartArt.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Vérifier la forme SmartArt avec le LayoutType particulier et effectuer les actions requises par la suite.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir toutes les formes de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Vérifier la mise en page SmartArt
            if (smart.Layout == SmartArtLayoutType.BasicBlockList)
            {
                Console.WriteLine("Do some thing here....");
            }
        }
    }
}
```


## **Modifier le style d'une forme SmartArt**
Le code d'exemple suivant vous aidera à accéder à la forme SmartArt avec un LayoutType particulier.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Trouver la forme SmartArt avec un style particulier.
- Définir le nouveau style pour la forme SmartArt.
- Enregistrer la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir toutes les formes de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le style SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Modifier le style SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Enregistrer la présentation
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier le style de couleur d'une forme SmartArt**
Dans cet exemple, nous apprendrons à changer le style de couleur d'une forme SmartArt. Le code d'exemple suivant accédera à la forme SmartArt avec un style de couleur particulier et modifiera son style.

- Créer une instance de la classe `Presentation` et charger la présentation contenant une forme SmartArt.
- Obtenir la référence de la première diapositive en utilisant son index.
- Parcourir chaque forme à l'intérieur de la première diapositive.
- Vérifier si la forme est de type SmartArt et convertir la forme sélectionnée en SmartArt si c'est le cas.
- Trouver la forme SmartArt avec un style de couleur particulier.
- Définir le nouveau style de couleur pour la forme SmartArt.
- Enregistrer la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir toutes les formes de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Caster la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le type de couleur SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Modifier le type de couleur SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Enregistrer la présentation
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis‑je animer SmartArt comme un seul objet ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/net/powerpoint-animation/) via l'API d'animations (entrée, sortie, mise en emphase, chemins de mouvement) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur — c'est la méthode recommandée pour localiser la forme cible.

**Puis‑je grouper SmartArt avec d'autres formes ?**

Oui. Vous pouvez grouper SmartArt avec d'autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/net/group/).

**Comment obtenir une image d'un SmartArt spécifique (par ex., pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/net/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L'apparence du SmartArt sera‑t‑elle conservée lors de la conversion de l'ensemble de la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l'[export PDF](/slides/fr/net/convert-powerpoint-to-pdf/), avec un éventail d'options de qualité et de compatibilité.