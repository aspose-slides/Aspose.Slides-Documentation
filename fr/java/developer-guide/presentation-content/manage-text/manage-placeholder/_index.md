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
description: "Gérez facilement les espaces réservés dans Aspose.Slides pour Java : remplacez le texte, personnalisez les invites et définissez la transparence des images dans PowerPoint et OpenDocument."
---

## **Modifier le texte dans un espace reserve**
En utilisant [Aspose.Slides for Java](/slides/fr/java/), vous pouvez rechercher et modifier les espaces reserves sur les diapositives d'une presentation. Aspose.Slides vous permet d'apporter des modifications au texte d'un espace reserve.

**Prerequis**: Vous avez besoin d'une presentation contenant un espace reserve. Vous pouvez creer une telle presentation dans l'application Microsoft PowerPoint standard.

Voici comment utiliser Aspose.Slides pour remplacer le texte dans l'espace reserve de cette presentation :

1. Instanciez la classe [`Presentation`](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et transmettez la presentation en argument.
2. Obtenez une reference a une diapositive via son indice.
3. Parcourez les formes pour trouver l'espace reserve.
4. Convertissez la forme d'espace reserve en un [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape) et modifiez le texte a l'aide du [`TextFrame`](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) associe au [`AutoShape`](https://reference.aspose.com/slides/java/com.aspose.slides/AutoShape).
5. Enregistrez la presentation modifiee.

Ce code Java montre comment modifier le texte dans un espace reserve :
```java
// Instancie une classe Presentation
Presentation pres = new Presentation("ReplacingText.pptx");
try {

    // Accède à la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);

    // Parcourt les formes pour trouver l'espace réservé
    for (IShape shp : sld.getShapes()) 
    {
        if (shp.getPlaceholder() != null) {
            // Modifie le texte dans chaque espace réservé
            ((IAutoShape) shp).getTextFrame().setText("This is Placeholder");
        }
    }

    // Enregistre la présentation sur le disque
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Definir le texte d'invite dans un espace reserve**
Les dispositions standard et pre-concues contiennent des textes d'invite d'espace reserve tels que ***Cliquez pour ajouter un titre*** ou ***Cliquez pour ajouter un sous-titre***. Avec Aspose.Slides, vous pouvez inserer vos propres textes d'invite dans les dispositions d'espace reserve.

Ce code Java vous montre comment definir le texte d'invite dans un espace reserve :
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


## **Definir la transparence de l'image d'un espace reserve**

Aspose.Slides vous permet de definir la transparence de l'image d'arriere-plan dans un espace reserve de texte. En ajustant la transparence de l'image dans ce cadre, vous pouvez faire ressortir le texte ou l'image (selon les couleurs du texte et de l'image).

Ce code Java vous montre comment definir la transparence d'un arriere-plan d'image (dans une forme) :
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

**Qu'est-ce qu'un espace reserve de base et en quoi differe-t-il d'une forme locale sur une diapositive?**

Un espace reserve de base est la forme originale sur une disposition ou un masque dont la forme de la diapositive herite -- le type, la position et certains formats en proviennent. Une forme locale est indépendante; s'il n'existe pas d'espace reserve de base, l'heritage ne s'applique pas.

**Comment mettre a jour tous les titres ou legendes d'une presentation sans parcourir chaque diapositive?**

Modifiez l'espace reserve correspondant sur la disposition ou le masque. Les diapositives basees sur ces dispositions/ce masque herediteront automatiquement du changement.

**Comment contrôler les espaces reserves d'en-tete/pied de page standard -- date & heure, numero de diapositive et texte du pied de page?**

Utilisez les gestionnaires HeaderFooter au niveau approprie (diapositives normales, dispositions, masque, notes/feuillets) pour activer ou desactiver ces espaces reserves et definir leur contenu.