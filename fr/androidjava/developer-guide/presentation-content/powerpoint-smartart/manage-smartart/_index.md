---
title: Gérer SmartArt dans les présentations PowerPoint sur Android
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/androidjava/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de mise en page
- propriété masquée
- organigramme
- organigramme d'images
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Android en utilisant des exemples de code Java clairs qui accélèrent la conception de diapositives et l'automatisation."
---
## **Aperçu**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une mise en page. Avec Aspose.Slides pour Android via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur mise en page, examiner les nœuds masqués, configurer les mises en page des organigrammes et créer des organigrammes d’images.

## **Obtenir le texte d’un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), puis lisez le [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) renvoyé par [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

L’exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt en tant que première forme sur cette diapositive. Il affiche chaque cadre de texte disponible dans la console.

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

## **Modifier le type de mise en page d’un objet SmartArt**

La mise en page SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L’exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, la change en valeur `BasicProcess` et enregistre la présentation. La position et la taille passées à [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) sont exprimées en points. Utilisez [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) pour modifier la mise en page.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la mise en page sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L’exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` et vérifie l’état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

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

Pour les diagrammes SmartArt qui utilisent une mise en page d’organigramme, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) et [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) définissent la façon dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez placer les nœuds enfants en suspension à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) sélectionné.

L’exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. L’index basé sur zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent la disposition sélectionnée. La présentation modifiée est ensuite enregistrée.

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

Un organigramme d’images est une mise en page SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d’image. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` lors de l’ajout de l’objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d’image ; il ne remplit pas les espaces réservés avec des images.

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

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d’une présentation existante, il peut être nécessaire de mettre à jour un organigramme créé à l’origine dans PowerPoint 97–2003. Aspose.Slides représente ces diagrammes hérités sous forme d’objets [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/). Utilisez [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) pour convertir un diagramme en groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) pour les détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l’original avec [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) afin d’éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans une liste avant de les convertir afin que l’ajout et la suppression de formes n’interrompent pas l’itération.

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

La présentation enregistrée contient des groupes de formes éditables à la place des diagrammes hérités convertis, sans diagrammes originaux restant à leurs côtés. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels de chaque groupe, tels que leur texte, remplissage ou position.

## **FAQ**

**SmartArt prend-il en charge le mirroring ou l’inversion pour les langues RTL ?**

Oui. La méthode [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) inverse la direction du diagramme de gauche à droite en droite à gauche, ou inversement, lorsque la mise en page SmartArt sélectionnée prend en charge l’inversion.

**Comment copier un SmartArt sur la même diapositive ou dans une autre présentation tout en préservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/androidjava/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) ou [cloner la diapositive entière](/slides/fr/androidjava/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre le SmartArt en image raster pour un aperçu ou une exportation web ?**

[Render the slide](/slides/fr/androidjava/convert-powerpoint-to-png/) ou la présentation entière en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s’il y en a plusieurs ?**

Utilisez [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) ou [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) pour attribuer un texte alternatif ou un nom distinctif à la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), puis vérifiez que la forme correspondante est un [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).