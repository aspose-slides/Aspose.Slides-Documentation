---
title: Redimensionner les formes sur les diapositives de présentation
type: docs
weight: 110
url: /fr/java/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides for Java—automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Aperçu**

L’une des questions les plus fréquentes des clients d’Aspose.Slides for Java porte sur la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas tronquées. Cet article technique court montre comment le faire.

## **Redimensionner les formes**

Pour éviter que les formes ne soient désalignées lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu’elles correspondent à la nouvelle mise en page de la diapositive.

```java
import com.aspose.slides.*;

// Charger le fichier de présentation.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Obtenir la taille originale de la diapositive.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Obtenir la nouvelle taille de la diapositive.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Redimensionner et repositionner les formes sur chaque diapositive.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Les tables ne nécessitent aucun traitement spécial : définir la largeur et la hauteur d’une table redimensionne proportionnellement ses colonnes et ses lignes, de sorte que redimensionner à nouveau les hauteurs de ligne et les largeurs de colonne appliquerait le ratio deux fois.
{{% /alert %}} 

Le code ci-dessous ne modifie que les formes sur les diapositives. Les diapositives maîtres et les diapositives de mise en page conservent leurs propres formes, il faut donc les redimensionner également lorsque vous souhaitez que toute la présentation suive la nouvelle taille de diapositive :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Obtenir la taille originale de la diapositive.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Obtenir la nouvelle taille de la diapositive.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Mettre à l'échelle la taille de la forme.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Mettre à l'échelle la position de la forme.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Mettre à l'échelle la taille de la forme.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Mettre à l'échelle la position de la forme.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

### Pourquoi les formes sont‑elles déformées ou tronquées après le redimensionnement d’une diapositive ?

Lors du redimensionnement d’une diapositive, les formes conservent leur position et leur taille d’origine sauf si l’échelle est explicitement modifiée. Cela peut entraîner le recadrage du contenu ou le désalignement des formes.

### Le code fourni fonctionne‑t‑il pour tous les types de formes ?

Oui. Définir la hauteur et la largeur fonctionne aussi bien pour les zones de texte, les images, les graphiques que les tables.

### Comment redimensionner les tables lors du redimensionnement d’une diapositive ?

Redimensionnez la forme de la table elle‑même, exactement comme toute autre forme. Ses lignes et colonnes s’ajustent proportionnellement, il ne faut donc pas les redimensionner à nouveau par la suite.

### Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getMasters--) et les [Layout slides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getLayoutSlides--) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence dans toute la présentation.

### Puis‑je modifier l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?

Oui. Vous pouvez utiliser [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidesize/#setOrientation-int-) pour modifier l’orientation. Assurez-vous de définir la logique de mise à l’échelle en conséquence afin de préserver la mise en page.

### Existe‑t‑il une limite à la taille de diapositive que je peux définir ?

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

### Comment empêcher les formes à rapport d’aspect fixe de se déformer ?

Vous pouvez vérifier la méthode `getAspectRatioLocked` de la forme avant de la mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle séparément.