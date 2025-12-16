---
title: Gérer les arrière-plans de présentation sur Android
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/androidjava/presentation-background/
keywords:
- arrière‑plan de présentation
- arrière‑plan de diapositive
- couleur unie
- couleur dégradé
- image d’arrière‑plan
- transparence d’arrière‑plan
- propriétés d’arrière‑plan
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à définir des arrière‑plans dynamiques dans les fichiers PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour Android via Java, avec des conseils de code pour améliorer vos présentations."
---

## **Aperçu**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plans de diapositives. Vous pouvez définir l'arrière‑plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive maître** (s'applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan pour une diapositive spécifique d'une présentation—même si la présentation utilise une diapositive maître. La modification ne s'applique qu'à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de l'arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) sur [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) pour spécifier la couleur d'arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L'exemple Java suivant montre comment définir une couleur unie bleue comme arrière‑plan d'une diapositive normale :
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


## **Définir un arrière‑plan de couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan pour la diapositive maître d'une présentation. La diapositive maître agit comme un modèle qui contrôle le formatage de toutes les diapositives, de sorte que lorsqu'une couleur unie est choisie pour l'arrière‑plan de la diapositive maître, elle s'applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) de la diapositive maître (via `getMasters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de l'arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) pour spécifier la couleur d'arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L'exemple Java suivant montre comment définir une couleur unie (verte) comme arrière‑plan d'une diapositive maître :
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


## **Définir un arrière‑plan en dégradé pour une diapositive**

Un gradient est un effet graphique créé par une variation progressive de couleur. Lorsqu'il est utilisé comme arrière‑plan de diapositive, les dégradés peuvent rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière‑plan pour les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de l'arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) sur [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L'exemple Java suivant montre comment définir une couleur de dégradé comme arrière‑plan d'une diapositive :
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

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d'utiliser des images comme arrière‑plans de diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) de l'arrière‑plan de la diapositive sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière‑plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) sur [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) pour assigner l'image comme arrière‑plan.
7. Enregistrez la présentation modifiée.

L'exemple Java suivant montre comment définir une image comme arrière‑plan d'une diapositive :
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


L'exemple de code suivant montre comment définir le type de remplissage d'arrière‑plan sur une image en mosaïque et modifier les propriétés de mosaïquage :
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

    // Définissez l'image utilisée pour le remplissage de l'arrière-plan.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Définissez le mode de remplissage d'image à Tuiles et ajustez les propriétés de la mosaïque.
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
En savoir plus : [**Image en tuiles comme texture**](/slides/fr/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l'image d'arrière‑plan**

Vous pouvez vouloir ajuster la transparence de l'image d'arrière‑plan d'une diapositive afin que le contenu de la diapositive ressorte davantage. Le code Java suivant montre comment changer la transparence d'une image d'arrière‑plan de diapositive :
```java
int transparencyValue = 30; // Par exemple.

// Récupérez la collection des opérations de transformation d'image.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```


## **Obtenir la valeur d'arrière‑plan de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs d'arrière‑plan effectives d'une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) et le [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) effectifs.

En utilisant la méthode `getBackground` de la classe [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/), vous pouvez obtenir l'arrière‑plan effectif d'une diapositive.

L'exemple Java suivant montre comment obtenir la valeur d'arrière‑plan effective d'une diapositive :
```java
// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Récupérez l'arrière-plan effectif en tenant compte du maître, de la mise en page et du thème.
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

**Puis-je réinitialiser un arrière‑plan personnalisé et restaurer l'arrière‑plan du thème/de la mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l'arrière‑plan sera de nouveau hérité de la [mise en page](/slides/fr/androidjava/slide-layout/)/[maître](/slides/fr/androidjava/slide-master/) correspondante (c’est‑à‑dire le [arrière‑plan du thème](/slides/fr/androidjava/presentation-theme/)).

**Que se passe-t-il à l'arrière‑plan si je modifie le thème de la présentation plus tard ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l'arrière‑plan est hérité de la [mise en page](/slides/fr/androidjava/slide-layout/)/[maître](/slides/fr/androidjava/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/androidjava/presentation-theme/).