---
title: Gérer les espaces réservés de présentation en Java
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/java/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- texte d'invite
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Gérez facilement les espaces réservés dans Aspose.Slides pour Java: remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Modifier le texte dans un espace réservé**
En utilisant [Aspose.Slides for Java](/slides/fr/java/), vous pouvez rechercher et modifier les espaces réservés sur les diapositives des présentations. Aspose.Slides vous permet de modifier le texte d'un espace réservé.

**Prérequis** : vous avez besoin d'une présentation contenant un espace réservé. Vous pouvez créer une telle présentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace réservé de cette présentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et transmettez la présentation en argument.
2. Obtenez une référence de diapositive via son index.
3. Parcourez les formes pour trouver l'espace réservé.
4. Convertissez la forme de l'espace réservé en [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) et modifiez le texte à l'aide du [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) associé à la [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Enregistrez la présentation modifiée.

Ce code Java montre comment modifier le texte dans un espace réservé :
```java
// Instancie une classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Itère à travers les formes pour trouver l'espace réservé
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Modifie le texte de chaque espace réservé
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Enregistre la présentation sur le disque
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir le texte d'invite dans un espace réservé**
Les dispositions standard et préconstruites contiennent des textes d'invite d'espace réservé tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous‑titre***. Avec Aspose.Slides, vous pouvez insérer vos propres textes d'invite dans les dispositions d'espaces réservés.

Ce code Java vous montre comment définir le texte d'invite dans un espace réservé :
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    for (IShape shape : slide.getSlide().getShapes()) // Itère à travers la diapositive
    {
        if (shape.getPlaceholder() != null && shape instanceof AutoShape)
        {
            String text = "";
            if (shape.getPlaceholder().getType() == PlaceholderType.CenteredTitle) // PowerPoint affiche "Cliquez pour ajouter un titre"
            {
                text = "Add Title";
            }
            else if (shape.getPlaceholder().getType() == PlaceholderType.Subtitle) // Ajoute le sous-titre
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).getTextFrame().setText(text);
            System.out.println("Placeholder with text: " + text);
        }
    }

    pres.save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Définir la transparence de l'image d'un espace réservé**
Aspose.Slides vous permet de définir la transparence de l'image d'arrière‑plan dans un espace réservé de texte. En ajustant la transparence de l'image dans ce cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code Java montre comment définir la transparence d'une image d'arrière‑plan (à l'intérieur d'une forme) :
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
        System.out.println("Current transparency value: " + currentValue);

        int alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}

presentation.save("example_out.pptx", SaveFormat.Pptx);
```


## **FAQ**

**Qu'est‑ce qu'un espace réservé de base, et en quoi diffère‑t‑il d'une forme locale sur une diapositive ?**  
Un espace réservé de base est la forme originale sur une disposition ou un maître dont la forme de la diapositive hérite — le type, la position et certains formatages en proviennent. Une forme locale est indépendante ; s'il n'existe aucun espace réservé de base, l'héritage ne s'applique pas.

**Comment mettre à jour tous les titres ou légendes d'une présentation sans parcourir chaque diapositive ?**  
Modifiez l'espace réservé correspondant sur la disposition ou le maître. Les diapositives basées sur ces dispositions/ce maître hériteront automatiquement de la modification.

**Comment contrôler les espaces réservés d'en‑tête/pied de page standard — date et heure, numéro de diapositive et texte du pied de page ?**  
Utilisez les gestionnaires HeaderFooter au niveau approprié (diapositives normales, dispositions, maître, notes/feuillets) pour activer ou désactiver ces espaces réservés et définir leur contenu.