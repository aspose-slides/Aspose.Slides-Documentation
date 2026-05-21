---
title: Gérer SmartArt dans les présentations PowerPoint avec JavaScript
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/nodejs-java/manage-smartart/
keywords:
- SmartArt
- texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme illustré
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Node.js grâce à des exemples de code JavaScript clairs qui accélèrent la conception et l'automatisation des diapositives."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d’une disposition. Avec Aspose.Slides pour Node.js via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions des organigrammes et créer des organigrammes illustrés.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte visible, parcourez [SmartArt.getAllNodes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/#getAllNodes--), puis lisez le [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) retourné par [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Modifier le type de disposition d'un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartlayouttype/), la change en valeur `BasicProcess` et enregistre la présentation.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartlayouttype/) et vérifie l'état masqué du nœud.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir ou définir la disposition de l'organigramme**

Pour les diagrammes SmartArt qui utilisent une disposition d'organigramme, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) et [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) définissent comment les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire suspendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/organizationchartlayouttype/) sélectionné.

L'exemple suivant crée un organigramme et définit la disposition du premier nœud sur la valeur `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/organizationchartlayouttype/).

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un organigramme illustré**

Un organigramme illustré est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'image. Utilisez la valeur `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartartlayouttype/) lors de l'ajout de l'objet SmartArt à une diapositive.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt prend-il en charge le miroir ou l'inversion pour les langues RTL ?**

Oui. La méthode [SmartArt.setReversed](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/setreversed/) inverse la direction du diagramme de gauche à droite en droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l'inversion.

**Comment copier un SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/nodejs-java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/nodejs-java/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre un SmartArt en image raster pour l'aperçu ou l'exportation Web ?**

[Rendre la diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) ou la présentation entière en PNG ou JPEG. Le SmartArt est rendu comme partie intégrante de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Attribuez une valeur distinctive à [Shape.setAlternativeText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/setalternativetext/) ou [Shape.setName](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/setname/) sur la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/smartart/).