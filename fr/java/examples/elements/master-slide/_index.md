---
title: Diapositive maître
type: docs
weight: 30
url: /fr/java/examples/elements/master-slide/
keywords:
- exemple de code
- diapositive maître
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez les exemples de diapositives maîtres Aspose.Slides pour Java : créez, modifiez et stylisez les maîtres, les espaces réservés et les thèmes dans PPT, PPTX et ODP avec du code Java clair."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit les éléments de conception communs tels que les arrière-plans, les logos et le formatage du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides pour Java.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut. Il ajoute ensuite une bannière avec le nom de l'entreprise à toutes les diapositives grâce à l'héritage de la mise en page.

```java
static void addMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Clone la diapositive maître par défaut.
        IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
        IMasterSlide newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        // Ajoutez une bannière avec le nom de l'entreprise en haut de la diapositive maître.
        IAutoShape textBox = newMasterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        textBox.getFillFormat().setFillType(FillType.NoFill);

        // Assignez la nouvelle diapositive maître à une diapositive de mise en page.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Assignez la diapositive de mise en page à la première diapositive de la présentation.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle cohérente ou des éléments de conception partagés sur toutes les diapositives. Toute modification apportée à la diapositive maître se reflétera automatiquement sur les diapositives de mise en page et normales dépendantes.  
> 💡 **Note 2:** Toutes les formes ou le formatage ajoutés à une diapositive maître sont hérités par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page.  
> L'image ci-dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de diapositive maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres à l'aide de la collection maître de la présentation. Voici comment les récupérer et travailler avec elles :

```java
static void accessMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);

        // Modifier le type d'arrière-plan.
        firstMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par indice, soit par référence.

```java
static void removeMasterSlide() {
    Presentation presentation = new Presentation("sample.pptx");
    try {
        // Supprimer une diapositive maître par indice.
        presentation.getMasters().removeAt(0);

        // Supprimer une diapositive maître par référence.
        IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```java
static void removeUnusedMasterSlide() {
    Presentation presentation = new Presentation();
    try {
        // Supprimer toutes les diapositives maîtres inutilisées (même celles marquées comme Préserver).
        presentation.getMasters().removeUnused(true);
    } finally {
        presentation.dispose();
    }
}
```