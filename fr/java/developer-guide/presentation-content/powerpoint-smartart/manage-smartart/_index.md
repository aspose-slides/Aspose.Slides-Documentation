---
title: Gérer SmartArt dans les présentations PowerPoint en Java
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/java/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme d'images
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides for Java en utilisant des exemples de code clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint constitué de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides for Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes d’images.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), puis lisez le [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) renvoyé par [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

L’exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt comme première forme sur cette diapositive. Il affiche chaque trame de texte disponible dans la console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Modifier le type de disposition d'un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont organisés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/), la change en valeur `BasicProcess` et enregistre la présentation. La position et la taille passées à [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) sont mesurées en points. Utilisez [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) pour modifier la disposition.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) et vérifie l’état de masquage du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir ou définir la disposition de l’organigramme**

Pour les diagrammes SmartArt utilisant une disposition d’organigramme, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) et [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) définissent comment les nœuds enfants sont arrangés sous un nœud parent. Par exemple, vous pouvez faire pendre les nœuds enfants du côté gauche, droit ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/). L’indice zéro‑based `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent l’arrangement choisi. La présentation modifiée est ensuite enregistrée.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un organigramme d’images**

Un organigramme d’images est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) lors de l’ajout de l’objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d’image ; il ne remplit pas ces espaces avec des images.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convertir les diagrammes anciens en groupes de formes**

Lors de la modernisation d’une présentation existante, il peut être nécessaire de mettre à jour un organigramme créé initialement dans PowerPoint 97‑2003. Aspose.Slides représente ces diagrammes anciens sous forme d’objets [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/). Utilisez [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) pour convertir un diagramme en groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) pour éviter le contenu dupliqué. Rassemblez les diagrammes anciens dans une liste avant de les convertir afin que l’ajout et la suppression de formes n’interrompent pas l’itération.

L’exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes anciens convertis, sans aucun diagramme original restant à côté. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels au sein de chaque groupe, tels que le texte, le remplissage ou la position.

## **FAQ**

**SmartArt prend‑il en charge le mirroring ou l’inversion pour les langues RTL ?**

Oui. La méthode [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) inverse la direction du diagramme de de gauche à droite à de droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [clone the SmartArt shape](/slides/fr/java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [clone the whole slide](/slides/fr/java/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre le SmartArt en image raster pour l’aperçu ou l’export web ?**

[Render the slide](/slides/fr/java/convert-powerpoint-to-png/) ou la présentation complète au format PNG ou JPEG. SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Utilisez [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) ou [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) pour attribuer un texte alternatif ou un nom distinctif à la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).