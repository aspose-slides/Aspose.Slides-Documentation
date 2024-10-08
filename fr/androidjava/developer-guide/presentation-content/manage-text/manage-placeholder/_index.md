---
title: Gérer le Placeholder
type: docs
weight: 10
url: /fr/androidjava/manage-placeholder/
description: Modifier le texte dans un placeholder dans des diapositives PowerPoint en utilisant Java. Définir le texte d'invite dans un placeholder dans des diapositives PowerPoint en utilisant Java.
---

## **Modifier le texte dans le Placeholder**
Utilisez [Aspose.Slides pour Android via Java](/slides/fr/androidjava/), vous pouvez trouver et modifier des placeholders sur des diapositives dans des présentations. Aspose.Slides vous permet de modifier le texte dans un placeholder.

**Prérequis** : Vous avez besoin d'une présentation contenant un placeholder. Vous pouvez créer une telle présentation dans l'application standard Microsoft PowerPoint.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans le placeholder de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) et passez la présentation en argument.
2. Obtenez une référence de diapositive via son index.
3. Parcourez les formes pour trouver le placeholder.
4. Convertissez le shape de placeholder en [`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape) et modifiez le texte en utilisant le [`TextFrame`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) associé à l'[`AutoShape`](https://reference.aspose.com/slides/androidjava/com.aspose.slides/AutoShape).
5. Enregistrez la présentation modifiée.

Ce code Java montre comment changer le texte dans un placeholder :

```java
// Instancie une classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Parcourt les formes pour trouver le placeholder
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Change le texte dans chaque placeholder
            ((IAutoShape) shp).getTextFrame().setText("Ceci est un Placeholder");
        }
    }

    // Enregistre la présentation sur le disque
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le texte d'invite dans le Placeholder**
Les mises en page standard et préconçues contiennent des textes d'invite de placeholder tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. En utilisant Aspose.Slides, vous pouvez insérer vos textes d'invite préférés dans les mises en page de placeholder.

Ce code Java vous montre comment définir le texte d'invite dans un placeholder :

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Parcourt la diapositive
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint affiche "Cliquez pour ajouter un titre" 
            {
                text = "Ajouter un titre";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Ajoute un sous-titre
            {
                text = "Ajouter un sous-titre";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder avec texte : " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir la transparence de l'image du Placeholder**

Aspose.Slides vous permet de définir la transparence de l'image de fond dans un placeholder de texte. En ajustant la transparence de l'image dans un tel cadre, vous pouvez faire ressortir le texte ou l'image (en fonction des couleurs du texte et de l'image).

Ce code Java montre comment définir la transparence pour une image de fond (dans une forme) :

```java
Presentation presentation = new Presentation("example.pptx");

IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

IImageTransformOperationCollection operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (int i = 0; i < operationCollection.size(); i++)
{
    if(operationCollection.get_Item(i) instanceof AlphaModulateFixed)
    {
        AlphaModulateFixed alphaModulate = (AlphaModulateFixed)operationCollection.get_Item(i);
        float currentValue = 100 - alphaModulate.getAmount();
        System.out.println("Valeur actuelle de transparence : " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```