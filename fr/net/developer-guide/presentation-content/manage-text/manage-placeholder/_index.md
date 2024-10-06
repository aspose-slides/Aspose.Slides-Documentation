---
title: Gérer les Espaces réservés
type: docs
weight: 10
url: /net/manage-placeholder/
keywords: "Espace réservé, Texte d'espace réservé, Texte d'invite, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Modifier le texte de l'espace réservé et le texte d'invite dans des présentations PowerPoint en C# ou .NET"
---

## **Modifier le Texte dans l'Espace Réservé**
En utilisant [Aspose.Slides pour .NET](/slides/net/), vous pouvez trouver et modifier les espaces réservés sur des diapositives dans des présentations. Aspose.Slides vous permet de modifier le texte dans un espace réservé.

**Prérequis**: Vous avez besoin d'une présentation qui contient un espace réservé. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation) et passez la présentation comme argument.
2. Obtenez une référence à une diapositive par son index.
3. Parcourez les formes pour trouver l'espace réservé.
4. Typecast la forme de l'espace réservé en une [`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) et modifiez le texte à l'aide de [`TextFrame`](https://reference.aspose.com/slides/net/aspose.slides/textframe/) associé à l[`AutoShape`](https://reference.aspose.com/slides/net/aspose.slides/autoshape/).
5. Enregistrez la présentation modifiée.

Ce code C# montre comment modifier le texte dans un espace réservé :

```c#
// Instancie une classe Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Accède à la première diapositive
    ISlide sld = pres.Slides[0];

    // Itère à travers les formes pour trouver l'espace réservé
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Modifie le texte dans chaque espace réservé
            ((IAutoShape)shp).TextFrame.Text = "Ceci est un Espace Réservé";
        }

    // Sauvegarde la présentation sur le disque
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Définir le Texte d'Invite dans l'Espace Réservé**
Les mises en page standard et prédéfinies contiennent des textes d'invite pour les espaces réservés tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page d'espaces réservés.

Ce code C# vous montre comment définir le texte d'invite dans un espace réservé :

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Itère à travers la diapositive
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint affiche "Cliquez pour ajouter un titre"
            {
                text = "Ajouter un Titre";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Ajoute un sous-titre
            {
                text = "Ajouter un Sous-titre";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Espace réservé avec texte : {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Définir la Transparence de l'Image de l'Espace Réservé**

Aspose.Slides vous permet de définir la transparence de l'image de fond dans un espace réservé de texte. En ajustant la transparence de l'image dans un tel cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code C# vous montre comment définir la transparence pour un arrière-plan d'image (dans une forme) :

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