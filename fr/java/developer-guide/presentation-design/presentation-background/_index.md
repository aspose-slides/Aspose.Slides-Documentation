---
title: Gérer les arrière-plan de présentation en Java
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/java/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- dégradé de couleur
- arrière-plan d'image
- transparence de l'arrière-plan
- propriétés de l'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à définir des arrière-plan dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Java, avec des conseils de code pour améliorer vos présentations."
---
## **Introduction**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plan de diapositive. Vous pouvez définir l'arrière‑plan pour une **diapositive normale** (une seule diapositive) ou une **diapositive maître** (s’applique à plusieurs diapositives à la fois).

![Arrière‑plan PowerPoint](powerpoint-background.png)

## **Définir un arrière‑plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive spécifique d’une présentation — même si la présentation utilise une diapositive maître. La modification ne s’applique qu’à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/#getSolidFillColor--) de [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur bleue unie comme arrière‑plan d’une diapositive normale :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Définit la couleur d'arrière-plan de la diapositive en bleu.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Enregistre la présentation sur le disque.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir un arrière‑plan de couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître sert de modèle qui contrôle le formatage de toutes les diapositives, ainsi choisir une couleur unie pour l’arrière‑plan de la diapositive maître l’appliquera à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/backgroundtype/) de la diapositive maître (via `getMasters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/#getSolidFillColor--) pour spécifier la couleur d’arrière‑plan unie.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur unie (verte) comme arrière‑plan d’une diapositive maître :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Définit la couleur d'arrière-plan de la diapositive maître en vert.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Enregistre la présentation sur le disque.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir un arrière‑plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une variation progressive des couleurs. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/#getGradientFormat--) de [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une couleur de dégradé comme arrière‑plan d’une diapositive :

```java
import com.aspose.slides.*;
import java.awt.Color;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Appliquez un effet de dégradé à l'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Ajoutez les couleurs du dégradé. Sans arrêts de dégradé, l'arrière-plan revient à un dégradé noir‑blanc par défaut.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Enregistrez la présentation sur le disque.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Picture`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de la diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/#getPictureFillFormat--) de [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/fillformat/) pour affecter l’image comme arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple Java suivant montre comment définir une image comme arrière‑plan d’une diapositive :

```java
import com.aspose.slides.*;

// Créez une instance de la classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Définir les propriétés de l'image d'arrière-plan.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Charger l'image.
    IImage image = Images.fromFile("Tulips.jpg");
    // Ajouter l'image à la collection d'images de la présentation.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Enregistrez la présentation sur le disque.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le fragment de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image en mosaïque et modifier les propriétés de la mosaïque :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Définir l'image utilisée pour le remplissage d'arrière-plan.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Définir le mode de remplissage de l'image sur Tile et ajuster les propriétés de la mosaïque.
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

{{% alert color="info" %}}
En savoir plus : [**Tile Picture As Texture**](/slides/fr/java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Il se peut que vous souhaitiez ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin de faire ressortir le contenu de celle‑ci. Le code Java suivant vous montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Par exemple.

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtenir la collection des opérations de transformation d'image.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Trouver un effet de transparence fixe en pourcentage existant.
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

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir la valeur d’arrière‑plan de la diapositive**

Aspose.Slides fournit l’interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs effectives d’arrière‑plan d’une diapositive. Cette interface expose les [FillFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) et [EffectFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) effectifs.

En utilisant la méthode `getBackground` de la classe [BaseSlide](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

L’exemple Java suivant montre comment obtenir la valeur d’arrière‑plan effectif d’une diapositive :

```java
import com.aspose.slides.*;

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

### Pouvez‑vous réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème/mise en page ?

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la diapositive [layout](/slides/fr/java/slide-layout/)/[master](/slides/fr/java/slide-master/) correspondante (c’est‑à‑dire l’[arrière‑plan du thème](/slides/fr/java/presentation-theme/)).

### Que se passe‑t‑il pour l’arrière‑plan si je change le thème de la présentation plus tard ?

Si une diapositive possède son propre remplissage, celui‑ci restera inchangé. Si l’arrière‑plan est hérité de la [layout](/slides/fr/java/slide-layout/)/[master](/slides/fr/java/slide-master/), il sera mis à jour pour correspondre au [new theme](/slides/fr/java/presentation-theme/).