---
title: Diapositive maître
type: docs
weight: 30
url: /fr/nodejs-java/examples/elements/master-slide/
keywords:
- exemple de code
- diapositive maître
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Explorez les exemples de diapositives maîtres d'Aspose.Slides pour Node.js : créez, modifiez et stylisez les maîtres, les espaces réservés et les thèmes dans PPT, PPTX et ODP avec un code clair."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit des éléments de conception communs tels que les arrière-plans, les logos et le formatage du texte. Les **diapositives de mise en page** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de mise en page.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides pour Node.js via Java.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut. Il ajoute ensuite une bannière du nom de l'entreprise à toutes les diapositives grâce à l'héritage de mise en page.

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Cloner la diapositive maître par défaut.
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // Ajouter une bannière avec le nom de l'entreprise en haut de la diapositive maître.
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // Attribuer la nouvelle diapositive maître à une diapositive de mise en page.
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // Attribuer la diapositive de mise en page à la première diapositive de la présentation.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Note 1:** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle cohérente ou des éléments de conception partagés à toutes les diapositives. Toute modification apportée à la diapositive maître sera automatiquement reflétée sur les diapositives de mise en page et normales dépendantes.  
> 💡 **Note 2:** Toutes les formes ou tout le formatage ajoutés à une diapositive maître sont hérités par les diapositives de mise en page et, à leur tour, par toutes les diapositives normales utilisant ces mises en page.  
> L'image ci-dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres en utilisant la collection maîtres de la présentation. Voici comment les récupérer et travailler avec elles :

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // Modifier le type d'arrière-plan.
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par indice, soit par référence.

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Supprimer une diapositive maître par indice.
        presentation.getMasters().removeAt(0);

        // Supprimer une diapositive maître par référence.
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // Supprimer toutes les diapositives maîtres inutilisées (même celles marquées comme Préserver).
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```