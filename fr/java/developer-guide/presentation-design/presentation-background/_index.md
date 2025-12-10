---
title: Gérer les arrière-plans de présentation en Java
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/java/presentation-background/
keywords:
- arrière‑plan de présentation
- arrière‑plan de diapositive
- couleur unie
- couleur dégradée
- arrière‑plan image
- transparence d'arrière‑plan
- propriétés d'arrière‑plan
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à définir des arrière‑plans dynamiques dans les fichiers PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d’ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plan de diapositive. Vous pouvez définir l’arrière‑plan d’une **diapositive normale** (une seule diapositive) ou d’une **diapositive maître** (qui s’applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive précise d’une présentation, même si la présentation utilise une diapositive maître. La modification ne s’applique qu’à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) sur [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur bleue unie comme arrière‑plan d’une diapositive normale :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive en bleu.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Enregistrez la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir un arrière‑plan couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme modèle qui contrôle le formatage de toutes les diapositives ; ainsi, lorsque vous choisissez une couleur unie pour l’arrière‑plan de la diapositive maître, elle s’applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) de la diapositive maître (via `getMasters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur unie (verte) comme arrière‑plan d’une diapositive maître :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive maître sur Vert forêt.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Enregistrez la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir un arrière‑plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une transition progressive de couleur. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) sur [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur de dégradé comme arrière‑plan d’une diapositive :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Appliquez un effet de dégradé à l'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Picture`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) sur [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour attribuer l’image comme arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une image comme arrière‑plan d’une diapositive :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Définissez les propriétés de l'image d'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Chargez l'image.
    IImage image = Images.fromFile("Tulips.jpg");
    // Ajoutez l'image à la collection d'images de la présentation.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Enregistrez la présentation sur le disque.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


L’extrait de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image en mosaïque et modifier les propriétés de mosaïquage :
```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Définir l'image utilisée pour le remplissage de l'arrière-plan.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Définir le mode de remplissage de l'image sur Tile et ajuster les propriétés de la tuile.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert color="primary" %}}
En savoir plus : [**Tile Picture As Texture**](/slides/fr/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive pour faire ressortir le contenu de la diapositive. Le code Java suivant montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :
```java
int transparencyValue = 30; // Par exemple.

// Obtenir la collection des opérations de transformation d'image.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Trouver un effet de transparence à pourcentage fixe existant.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Définir la nouvelle valeur de transparence.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Obtenir la valeur d’arrière‑plan de la diapositive**

Aspose.Slides fournit l’interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs d’arrière‑plan effectives d’une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) et le [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) effectifs.

En utilisant la méthode `getBackground` de la classe [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

L’exemple Java suivant montre comment obtenir la valeur d’arrière‑plan effective d’une diapositive :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Récupérez l'arrière-plan effectif en tenant compte du maître, de la disposition et du thème.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Puis‑je réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème/de la disposition ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la diapositive [layout](/slides/fr/java/slide-layout/)/[master](/slides/fr/java/slide-master/) correspondante (c’est‑à‑dire du [theme background](/slides/fr/java/presentation-theme/)).

**Que se passe‑t‑il avec l’arrière‑plan si je change plus tard le thème de la présentation ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l’arrière‑plan est hérité de la [layout](/slides/fr/java/slide-layout/)/[master](/slides/fr/java/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/java/presentation-theme/).