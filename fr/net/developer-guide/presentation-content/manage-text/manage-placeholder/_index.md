---
title: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/net/manage-placeholder/
keywords: "Espace réservé, Texte d'espace réservé, Texte d'invite, Présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Modifier le texte et le texte d'invite des espaces réservés dans les présentations PowerPoint en C# ou .NET"
---

## **Modifier le texte dans un espace réservé**
En utilisant [Aspose.Slides for .NET](/slides/fr/net/), vous pouvez rechercher et modifier les espaces réservés sur les diapositives dans les présentations. Aspose.Slides vous permet d'apporter des modifications au texte d'un espace réservé.

**Prerequisite**: Vous avez besoin d'une présentation contenant un espace réservé. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) et passez la présentation en argument.
2. Obtenez une référence à une diapositive via son index.
3. Itérez à travers les formes pour trouver l'espace réservé.
4. Convertissez la forme de l'espace réservé en [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) et modifiez le texte en utilisant le [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) associé à l[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Enregistrez la présentation modifiée.

Ce code C# montre comment modifier le texte d'un espace réservé :
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


## **Définir le texte d'invite dans un espace réservé**
Les mises en page standard et préconfigurées contiennent des textes d'invite d'espace réservé tels que ***Click to add a title*** ou ***Click to add a subtitle***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page d'espaces réservés.

Ce code C# montre comment définir le texte d'invite dans un espace réservé :
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


## **Définir la transparence de l'image d'un espace réservé**
Aspose.Slides vous permet de définir la transparence de l'image d'arrière-plan dans un espace réservé de texte. En ajustant la transparence de l'image dans ce cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code C# montre comment définir la transparence d'une image d'arrière-plan (à l'intérieur d'une forme) :
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

**Quel est un espace réservé de base, et en quoi diffère-t-il d'une forme locale sur une diapositive ?**

Un espace réservé de base est la forme originale sur une mise en page ou un masque dont la forme de la diapositive hérite - le type, la position et certains formats en proviennent. Une forme locale est indépendante; s'il n'existe pas d'espace réservé de base, l'héritage ne s'applique pas.

**Comment puis-je mettre à jour tous les titres ou légendes d'une présentation sans parcourir chaque diapositive ?**

Modifiez l'espace réservé correspondant sur la mise en page ou le masque. Les diapositives basées sur ces mises en page ou ce masque hériteront automatiquement du changement.

**Comment contrôler les espaces réservés d'en-tête/pied de page standard - date et heure, numéro de diapositive et texte du pied de page ?**

Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, mises en page, masque, notes/versions imprimées) pour activer ou désactiver ces espaces réservés et définir leur contenu.