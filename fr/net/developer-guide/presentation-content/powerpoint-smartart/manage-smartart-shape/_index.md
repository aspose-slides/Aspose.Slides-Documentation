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
Aspose.Slides for .NET permet désormais d'ajouter des formes SmartArt personnalisées à leurs diapositives dès le départ. Aspose.Slides for .NET propose l'API la plus simple pour créer des formes SmartArt de la manière la plus facile. Pour créer une forme SmartArt dans une diapositive, suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez une forme SmartArt en définissant son LayoutType.
- Enregistrez la présentation modifiée sous forme de fichier PPTX.
```c#
// Instancier la présentation
using (Presentation pres = new Presentation())
{

    // Accéder à la diapositive de la présentation
    ISlide slide = pres.Slides[0];

    // Ajouter une forme SmartArt
    ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

    // Enregistrement de la présentation
    pres.Save("SimpleSmartArt_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans l'exemple, nous parcourrons chaque forme de la diapositive et vérifierons si elle est de type SmartArt. Si la forme est de type SmartArt, nous la convertirons en instance SmartArt.
```c#
// Charger la présentation souhaitée
using (Presentation pres = new Presentation("AccessSmartArtShape.pptx"))
{

    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.Console.WriteLine("Shape Name:" + smart.Name);

        }
    }
}
```


## **Accéder à la forme SmartArt avec un Layout Type particulier**
Le code d'exemple suivant permet d'accéder à la forme SmartArt avec un LayoutType spécifique. Notez que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et n'est défini que lors de l'ajout de la forme SmartArt.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c’est le cas.
- Recherchez la forme SmartArt avec le LayoutType souhaité et effectuez les opérations requises.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
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


## **Modifier le style de la forme SmartArt**
Le code d'exemple suivant permet d'accéder à la forme SmartArt avec un LayoutType particulier.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c’est le cas.
- Recherchez la forme SmartArt avec le style souhaité.
- Attribuez le nouveau style à la forme SmartArt.
- Enregistrez la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le style SmartArt
            if (smart.QuickStyle == SmartArtQuickStyleType.SimpleFill)
            {
                // Modifier le style SmartArt
                smart.QuickStyle = SmartArtQuickStyleType.Cartoon;
            }
        }
    }

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtStyle_out.pptx", SaveFormat.Pptx);
}
```


## **Modifier le style de couleur de la forme SmartArt**
Dans cet exemple, nous allons apprendre à modifier le style de couleur d’une forme SmartArt. Le code suivant accède à la forme SmartArt avec un style de couleur particulier et change ce style.

- Créez une instance de la classe `Presentation` et chargez la présentation contenant la forme SmartArt.
- Obtenez la référence de la première diapositive en utilisant son index.
- Parcourez chaque forme de la première diapositive.
- Vérifiez si la forme est de type SmartArt et convertissez la forme sélectionnée en SmartArt si c’est le cas.
- Recherchez la forme SmartArt avec le style de couleur souhaité.
- Attribuez le nouveau style de couleur à la forme SmartArt.
- Enregistrez la présentation.
```c#
using (Presentation presentation = new Presentation("AccessSmartArtShape.pptx"))
{
    // Parcourir chaque forme à l'intérieur de la première diapositive
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Vérifier si la forme est de type SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forme en SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            // Vérifier le type de couleur SmartArt
            if (smart.ColorStyle == SmartArtColorType.ColoredFillAccent1)
            {
                // Modifier le type de couleur SmartArt
                smart.ColorStyle = SmartArtColorType.ColorfulAccentColors;
            }
        }
    }

    // Enregistrement de la présentation
    presentation.Save("ChangeSmartArtColorStyle_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Puis-je animer le SmartArt comme un seul objet ?**

Oui. Le SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/net/powerpoint-animation/) via l’API d’animation (entrée, sortie, mise en emphase, trajectoires) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le Texte alternatif (AltText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis-je grouper le SmartArt avec d’autres formes ?**

Oui. Vous pouvez grouper le SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/net/group/).

**Comment obtenir une image d’un SmartArt spécifique (par exemple, pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/net/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de toute la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[export PDF](/slides/fr/net/convert-powerpoint-to-pdf/), avec diverses options de qualité et de compatibilité.