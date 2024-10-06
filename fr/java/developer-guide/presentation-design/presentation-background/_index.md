---
title: Arrière-plan de Présentation
type: docs
weight: 20
url: /java/presentation-background/
keywords: "arrière-plan PowerPoint, définir un arrière-plan en Java"
description: "Définir un arrière-plan dans une présentation PowerPoint en Java"
---

Les couleurs unies, les dégradés de couleurs et les images sont souvent utilisés comme arrière-plans pour les diapositives. Vous pouvez définir l'arrière-plan pour une **diapositive normale** (diapositive unique) ou une **diapositive maître** (plusieurs diapositives à la fois)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour une diapositive spécifique dans une présentation (même si cette présentation contient une diapositive maître). Le changement d'arrière-plan n'affecte que la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) pour l'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) exposée par [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code Java vous montre comment définir une couleur unie (bleue) comme arrière-plan pour une diapositive normale :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Définit la couleur d'arrière-plan pour la première ISlide sur Bleu
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Écrit la présentation sur le disque
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour la diapositive maître dans une présentation. La diapositive maître agit comme un modèle qui contient et contrôle les paramètres de mise en forme pour toutes les diapositives. Par conséquent, lorsque vous sélectionnez une couleur unie comme arrière-plan pour la diapositive maître, ce nouvel arrière-plan sera utilisé pour toutes les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) pour la diapositive maître (`Masters`) sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) pour l'arrière-plan de la diapositive maître sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getSolidFillColor--) exposée par [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code Java vous montre comment définir une couleur unie (vert forêt) comme arrière-plan pour une diapositive maître dans une présentation :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Définit la couleur d'arrière-plan pour la Master ISlide sur Vert Forêt
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Écrit la présentation sur le disque
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir une Couleur Dégradée comme Arrière-plan pour une Diapositive**

Un dégradé est un effet graphique basé sur un changement progressif de couleur. Les couleurs dégradées, lorsqu'elles sont utilisées comme arrière-plans pour les diapositives, donnent aux présentations un aspect artistique et professionnel. Aspose.Slides vous permet de définir une couleur dégradée comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) pour l'arrière-plan de la diapositive maître sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getGradientFormat--) exposée par [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour spécifier votre paramètre de dégradé préféré.
5. Enregistrez la présentation modifiée.

Ce code Java vous montre comment définir une couleur dégradée comme arrière-plan pour une diapositive :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Applique l'effet de dégradé à l'arrière-plan
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Écrit la présentation sur le disque
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir une Image comme Arrière-plan pour une Diapositive**

En plus des couleurs unies et dégradées, Aspose.Slides vous permet également de définir des images comme arrière-plan pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/java/com.aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) pour l'arrière-plan de la diapositive maître sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/#getPictureFillFormat--) exposée par [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) pour définir l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

Ce code Java vous montre comment définir une image comme arrière-plan pour une diapositive : 

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation();
try {
    // Définit les conditions pour l'image d'arrière-plan
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Charge l'image
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Ajoute l'image à la collection d'images de la présentation
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Écrit la présentation sur le disque
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Changer la Transparence de l'Image de Fond**

Vous souhaiterez peut-être ajuster la transparence de l'image d'arrière-plan d'une diapositive pour faire ressortir le contenu de la diapositive. Ce code Java vous montre comment changer la transparence d'une image d'arrière-plan de diapositive :

```java
int transparencyValue = 30; // par exemple

// Obtient une collection d'opérations de transformation d'image
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Trouve un effet de transparence avec un pourcentage fixe.
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// Définit la nouvelle valeur de transparence.
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Obtenir la Valeur de l'Arrière-plan de la Diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/) pour vous permettre d'obtenir les valeurs effectives des arrière-plans des diapositives. Cette interface contient des informations sur le [FillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) effectif et le [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

En utilisant la propriété [Background](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getBackground--) de la classe [BaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/), vous pouvez obtenir la valeur effective pour l'arrière-plan d'une diapositive.

Ce code Java vous montre comment obtenir la valeur d'arrière-plan effective d'une diapositive :

```java
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Couleur de remplissage : " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Type de remplissage : " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```