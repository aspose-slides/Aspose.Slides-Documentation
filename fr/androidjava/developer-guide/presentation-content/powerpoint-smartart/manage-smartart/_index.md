---
title: Gérer SmartArt dans les présentations PowerPoint sur Android
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/androidjava/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Android en utilisant des exemples de code Java clairs qui accélèrent la conception et l'automatisation des diapositives."
---
## **Aperçu**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides for Android via Java, vous pouvez créer SmartArt, lire le texte de ses nœuds, modifier sa disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes d’images.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartart/#getAllNodes--) puis lisez le [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) renvoyé par [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Modifier le type de disposition d’un objet SmartArt**

La disposition SmartArt détermine comment les nœuds sont agencés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, la change en `BasicProcess` et enregistre la présentation.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` et vérifie l’état masqué du nœud.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir ou définir la disposition de l’organigramme**

Pour les diagrammes SmartArt utilisant une disposition d’organigramme, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/OrganizationChartLayoutType) sélectionné.

L’exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un organigramme d’image**

Un organigramme d’image est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` lors de l’ajout de l’objet SmartArt à une diapositive.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt prend‑il en charge le miroir ou l’inversion pour les langues RTL ?**

Oui. La méthode [ISmartArt.setReversed](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) bascule la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/androidjava/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [cloner toute la diapositive](/slides/fr/androidjava/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre SmartArt en image raster pour un aperçu ou une exportation web ?**

[Renderisez la diapositive](/slides/fr/androidjava/convert-powerpoint-to-png/) ou la présentation complète au format PNG ou JPEG. SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape.getAlternativeText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getAlternativeText--) ou à [Shape.getName](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#getName--) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/baseslide/#getShapes--), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ismartart/).