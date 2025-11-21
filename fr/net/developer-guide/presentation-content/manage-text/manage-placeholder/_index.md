---
title: Gérer les espaces réservés de présentation dans .NET
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/net/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- texte d'invite
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez facilement les espaces réservés dans Aspose.Slides pour .NET : remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Modifier le texte dans un espace réservé**
En utilisant [Aspose.Slides for .NET](/slides/fr/net/), vous pouvez trouver et modifier les espaces réservés sur les diapositives d’une présentation. Aspose.Slides vous permet d’apporter des modifications au texte d’un espace réservé.

**Prérequis** : Vous avez besoin d’une présentation contenant un espace réservé. Vous pouvez créer une telle présentation dans l’application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l’espace réservé de cette présentation :

1. Instancier la classe [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) et transmettre la présentation en argument.
2. Obtenir une référence de diapositive via son indice.
3. Parcourir les formes pour trouver l’espace réservé.
4. Convertir la forme d’espace réservé en un [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) et modifier le texte à l’aide du [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) associé au [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/). 
5. Enregistrer la présentation modifiée.

Ce code C# montre comment modifier le texte dans un espace réservé :
```c#
// Instancie une classe Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Parcourt les formes pour trouver l'espace réservé
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Modifie le texte de chaque espace réservé
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Enregistre la présentation sur le disque
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Définir le texte d’invite dans l’espace réservé**
Les mises en page standard et pré‑construites contiennent des textes d’invite d’espace réservé tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous‑titre***. En utilisant Aspose.Slides, vous pouvez insérer vos propres textes d’invite dans les mises en page d’espaces réservés.

Ce code C# vous montre comment définir le texte d’invite dans un espace réservé :
```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Parcourt la diapositive
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint affiche "Cliquez pour ajouter un titre"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Ajoute le sous-titre
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```


## **Définir la transparence de l’image d’espace réservé**
Aspose.Slides vous permet de définir la transparence de l’image d’arrière‑plan dans un espace réservé de texte. En ajustant la transparence de l’image dans ce cadre, vous pouvez faire ressortir le texte ou l’image (selon les couleurs du texte et de l’image).

Ce code C# montre comment définir la transparence d’une image d’arrière‑plan (à l’intérieur d’une forme) :
```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```


## **FAQ**

**Qu’est‑ce qu’un espace réservé de base, et en quoi diffère‑t‑il d’une forme locale sur une diapositive ?**

Un espace réservé de base est la forme originale sur une mise en page ou un masque dont hérite la forme de la diapositive — le type, la position et une partie du formatage proviennent de celle‑ci. Une forme locale est indépendante ; s’il n’existe pas d’espace réservé de base, l’héritage ne s’applique pas.

**Comment mettre à jour tous les titres ou légendes d’une présentation sans parcourir chaque diapositive ?**

Modifiez l’espace réservé correspondant sur la mise en page ou le masque. Les diapositives basées sur ces mises en page/ce masque hériteront automatiquement de la modification.

**Comment contrôler les espaces réservés d’en‑tête/pied de page standard — date & heure, numéro de diapositive et texte de pied de page ?**

Utilisez les gestionnaires HeaderFooter dans la portée appropriée (diapositives normales, mises en page, masque, notes/handouts) pour activer ou désactiver ces espaces réservés et définir leur contenu.