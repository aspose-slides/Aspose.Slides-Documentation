---
title: Redimensionner les formes sur les diapositives de présentation sous Android
type: docs
weight: 130
url: /fr/androidjava/resizing-shapes-on-slide/
aliases:
  - /androidjava/re-sizing-shapes-on-slide/
keywords:
- redimensionner forme
- modifier la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Android
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java—automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Vue d'ensemble**

Lorsque vous modifiez la taille des diapositives d'une présentation, il peut également être nécessaire de redimensionner et de repositionner ses formes pour qu'elles s'adaptent aux nouvelles dimensions. Cet article explique comment mettre à l'échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les mises en page.

## **Redimensionner les formes**

Pour conserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur d'origine. Appliquez le rapport de hauteur correspondant à ses coordonnées verticales et à sa hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, modifie la taille de la diapositive en A4 et enregistre le résultat. Il utilise [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) avec [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) afin que la boucle suivante contrôle la mise à l'échelle. Les rapports sont sans unité; les positions et dimensions des formes sont mesurées en points. Des rapports de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d'une forme n'entraîne pas la mise à l'échelle des tailles de police.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Les tableaux nécessitent une gestion séparée: redimensionnez leurs largeurs de colonne et hauteurs de ligne au lieu d'attribuer la largeur et la hauteur globales du tableau. Les hauteurs de ligne peuvent rester supérieures à la valeur demandée si le contenu des cellules nécessite plus d'espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les mises en page ainsi que sur les diapositives individuelles avant d'enregistrer la présentation redimensionnée. Son assistant gère chaque [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) en redimensionnant les largeurs de colonne avec [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) et les hauteurs minimales de ligne avec [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Il redimensionne ensuite la position du tableau sans redimensionner séparément ses dimensions globales.

```java
import com.aspose.slides.*;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Les dimensions du tableau sont déterminées par les largeurs des colonnes et les hauteurs des lignes.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Pourquoi les formes sont-elles déformées ou coupées après le redimensionnement d'une diapositive ?**  
Si vous modifiez la taille de la diapositive sans mettre à l'échelle les formes, elles conservent leurs positions et dimensions d'origine et peuvent dépasser de la diapositive. Mettre à l'échelle la largeur et la hauteur avec des rapports différents peut également déformer les formes.

**Le code fourni fonctionne-t-il pour tous les types de formes ?**  
Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tableaux. Le deuxième exemple gère les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne mettent pas à l'échelle les tailles de police et le contenu des tableaux peut contraindre les hauteurs de ligne.

**Comment redimensionner les tableaux lors du redimensionnement d'une diapositive ?**  
Redimensionnez les largeurs de colonne selon le rapport de largeur et les hauteurs minimales de ligne selon le rapport de hauteur, puis redimensionnez la position du tableau, comme illustré dans le deuxième exemple.

**Ce redimensionnement fonctionne-t-il pour les diapositives maîtres et les diapositives de mise en page ?**  
Oui. Le deuxième exemple parcourt [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) et les [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) de chaque maître, puis applique la même logique de redimensionnement à leurs formes.

**Puis-je changer l'orientation d'une diapositive (portrait/paysage) lors du redimensionnement ?**  
Oui. Appelez [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d'échelle reflètent l'orientation finale.

**Existe-t-il une limite à la taille de diapositive que je peux définir ?**  
Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). Les dimensions prises en charge dépendent également du format de la présentation et de l'application utilisée pour ouvrir le fichier.

**Comment empêcher les formes avec un rapport d'aspect fixe de se déformer ?**  
Utilisez le même facteur d'échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des rapports de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d'un bord.