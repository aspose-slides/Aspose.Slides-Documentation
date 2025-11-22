---
title: Gérer les arrière-plans de présentation en JavaScript
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/nodejs-java/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur dégradée
- arrière-plan image
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument en utilisant Aspose.Slides pour Node.js, avec des astuces de code pour améliorer vos présentations."
---

## **Aperçu**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plans de diapositives. Vous pouvez définir l’arrière‑plan d’une **diapositive normale** (une diapositive unique) ou d’une **diapositive maître** (s’applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive spécifique dans une présentation — même si la présentation utilise une diapositive maître. La modification s’applique uniquement à la diapositive sélectionnée.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) sur [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple JavaScript suivant montre comment définir une couleur bleue unie comme arrière‑plan d’une diapositive normale :
```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive en bleu.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Enregistrez la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir un arrière‑plan couleur unie pour la diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme un modèle qui contrôle le formatage de toutes les diapositives, de sorte que le choix d’une couleur unie pour l’arrière‑plan de la diapositive maître s’applique à chaque diapositive.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositive maître (via `getMasters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple JavaScript suivant montre comment définir une couleur verte unie comme arrière‑plan d’une diapositive maître :
```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive maître en vert forêt.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Enregistrez la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir un arrière‑plan en dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une transition progressive de couleur. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur en dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) sur [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L’exemple JavaScript suivant montre comment définir une couleur en dégradé comme arrière‑plan d’une diapositive :
```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Appliquez un effet de dégradé à l'arrière-plan.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d’utiliser des images comme arrière‑plans de diapositives.

1. Créez une instance de la classe [Présentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Picture`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) sur [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) pour affecter l’image à l’arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple JavaScript suivant montre comment définir une image comme arrière‑plan d’une diapositive :
```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Définissez les propriétés de l'image d'arrière-plan.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Chargez l'image.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Ajoutez l'image à la collection d'images de la présentation.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Enregistrez la présentation sur le disque.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


L’exemple de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image en mosaïque et modifier les propriétés de tuilage :
```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Définir l'image utilisée pour le remplissage de l'arrière-plan.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Définir le mode de remplissage de l'image sur Tile et ajuster les propriétés de la tuile.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}

En savoir plus : [**Tile Picture As Texture**](/slides/fr/nodejs-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin que le contenu de la diapositive ressorte davantage. Le code JavaScript suivant montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :
```js
var transparencyValue = 30; // Par exemple.

// Get the collection of picture transform operations.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Obtenir la valeur d’arrière‑plan de la diapositive**

Aspose.Slides fournit la classe `BackgroundEffectiveData` pour récupérer les valeurs d’arrière‑plan effectives d’une diapositive. Cette classe expose le [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) effectifs.

En utilisant la méthode `getBackground` de la classe [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

L’exemple JavaScript suivant montre comment obtenir la valeur d’arrière‑plan effective d’une diapositive :
```js
// Créez une instance de la classe Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Récupérez l'arrière-plan effectif, en tenant compte du maître, de la disposition et du thème.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème/disposition ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la [disposition](/slides/fr/nodejs-java/slide-layout/)/[maître](/slides/fr/nodejs-java/slide-master/) correspondante (c’est‑à‑dire du [fond du thème](/slides/fr/nodejs-java/presentation-theme/)).

**Que se passe‑t‑il avec l’arrière‑plan si je change le thème de la présentation plus tard ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l’arrière‑plan est hérité de la [disposition](/slides/fr/nodejs-java/slide-layout/)/[maître](/slides/fr/nodejs-java/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/nodejs-java/presentation-theme/).