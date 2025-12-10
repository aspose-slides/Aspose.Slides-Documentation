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
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Java — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---

## **Vue d'ensemble**

L'une des questions les plus fréquentes des clients d'Aspose.Slides pour Java porte sur la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas coupées. Cet article technique bref montre comment procéder.

## **Redimensionner les formes**

Pour éviter que les formes ne se désalignent lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu'elles correspondent à la nouvelle mise en page de la diapositive.
```java
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


{{% alert color="primary" %}} 

Si une diapositive contient un tableau, le code ci‑au-dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.

{{% /alert %}} 

Utilisez le code suivant de votre côté pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, la définition de la largeur ou de la hauteur constitue un cas particulier : vous devez ajuster les hauteurs des lignes et les largeurs des colonnes individuellement afin de modifier la taille globale du tableau.
```java
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```


## **FAQ**

**Pourquoi les formes sont‑elles déformées ou coupées après le redimensionnement d’une diapositive ?**

Lorsque vous redimensionnez une diapositive, les formes conservent leur position et leur taille d’origine, sauf si l’échelle est modifiée explicitement. Cela peut entraîner le recadrage du contenu ou le désalignement des formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

L’exemple de base fonctionne pour la plupart des types de formes (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer séparément les lignes et les colonnes, car la hauteur et la largeur d’un tableau sont déterminées par les dimensions des cellules individuelles.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Vous devez parcourir toutes les lignes et toutes les colonnes du tableau et redimensionner leur hauteur et largeur proportionnellement, comme illustré dans le second exemple de code.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) et les [Layout slides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getLayoutSlides--) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence de la présentation.

**Puis‑je modifier l’orientation d’une diapositive (portrait/paysage) lors du redimensionnement ?**

Oui. Vous pouvez utiliser [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/islidesize/#setOrientation-int-) pour changer l’orientation. Veillez à ajuster la logique de mise à l’échelle en conséquence afin de préserver la mise en page.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

**Comment empêcher les formes à ratio d’aspect fixe de se déformer ?**

Vous pouvez vérifier la méthode `getAspectRatioLocked` de la forme avant de la mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle séparément.