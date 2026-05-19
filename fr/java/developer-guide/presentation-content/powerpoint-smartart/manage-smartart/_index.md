---
title: Gérer SmartArt dans les présentations PowerPoint avec Java
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Java à l’aide d’exemples de code clairs qui accélèrent la conception de diapositives et l’automatisation."
---
## **Aperçu**

SmartArt est un diagramme PowerPoint constitué de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides for Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds cachés, configurer les dispositions de graphiques d’organisation et créer des graphiques d’organisation illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ismartart/#getAllNodes--), puis lisez le [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) renvoyé par [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

La disposition SmartArt contrôle la manière dont les nœuds sont agencés et connectés. L’exemple suivant crée un objet SmartArt avec le type [SmartArtLayoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, le change en `BasicProcess` et enregistre la présentation.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ismartartnode/#isHidden--) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments de diagramme visibles.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise le type [SmartArtLayoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` et vérifie l’état masqué du nœud.

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

## **Obtenir ou définir la disposition du graphique d’organisation**

Pour les diagrammes SmartArt qui utilisent une disposition de graphique d’organisation, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) et [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez placer les nœuds enfants en suspension à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/OrganizationChartLayoutType) sélectionné.

L’exemple suivant crée un graphique d’organisation et définit la disposition du premier nœud sur le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **Créer un graphique d’organisation illustré**

Un graphique d’organisation illustré est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez le type [SmartArtLayoutType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` lors de l’ajout de l’objet SmartArt à une diapositive.

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

Oui. La méthode [ISmartArt.setReversed](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ismartart/#setReversed-boolean-) bascule la direction du diagramme de gauche à droite à droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou sur une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [cloner la diapositive entière](/slides/fr/java/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour un aperçu ou une exportation web ?**

[Rendez la diapositive](/slides/fr/java/convert-powerpoint-to-png/) ou la présentation entière en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape.getAlternativeText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getAlternativeText--) ou à [Shape.getName](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/#getName--) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseslide/#getShapes--), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ismartart/).