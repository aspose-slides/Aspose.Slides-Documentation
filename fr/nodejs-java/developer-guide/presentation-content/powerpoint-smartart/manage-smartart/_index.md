---
title: Gérer SmartArt dans les présentations PowerPoint à l'aide de JavaScript
linktitle: Gérer SmartArt
type: docs
weight: 10
url: /fr/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Texte SmartArt
- type de disposition
- propriété masquée
- organigramme
- organigramme avec image
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Node.js en utilisant des exemples de code JavaScript clairs qui accélèrent la conception et l'automatisation des diapositives."
---
## **Vue d'ensemble**

SmartArt est un diagramme PowerPoint composé de nœuds, de formes de nœuds et d'une disposition. Avec Aspose.Slides pour Node.js via Java, vous pouvez créer des SmartArt, lire le texte de leurs nœuds, modifier leur disposition, inspecter les nœuds masqués, configurer les dispositions de diagrammes d'organisation et créer des diagrammes d'organisation avec image.

## **Obtenir le texte d'un objet SmartArt**

Un nœud SmartArt peut contenir une ou plusieurs formes. Pour lire le texte des formes du nœud, parcourez [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), puis lisez le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) renvoyé par [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

L'exemple nécessite une présentation contenant au moins une diapositive et un objet SmartArt en tant que première forme sur cette diapositive. Il affiche chaque cadre de texte disponible dans la console.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Modifier le type de disposition d'un objet SmartArt**

La disposition SmartArt contrôle la façon dont les nœuds sont disposés et connectés. L'exemple suivant crée un objet SmartArt avec la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, la change en `BasicProcess` et enregistre la présentation. La position et la taille passées à [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) sont mesurées en points. Utilisez [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) pour modifier la disposition.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vérifier si un nœud SmartArt est masqué**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) indique si le nœud est masqué dans le modèle de données SmartArt. Les nœuds masqués peuvent exister dans la structure même lorsque la disposition sélectionnée ne les affiche pas comme éléments visibles du diagramme.

L'exemple suivant ajoute un nœud à un objet SmartArt qui utilise la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` et vérifie l'état masqué du nœud ajouté. Il affiche un message si le nœud est masqué et enregistre le diagramme.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obtenir ou définir la disposition du graphique d'organisation**

Pour les diagrammes SmartArt qui utilisent une disposition de graphique d'organisation, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) et [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) définissent la manière dont les nœuds enfants sont disposés sous un nœud parent. Par exemple, vous pouvez faire suspendre les nœuds enfants à gauche, à droite ou des deux côtés, selon le [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/), sélectionné.

L'exemple suivant crée un graphique d'organisation et définit la disposition du premier nœud sur la valeur [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. L'index de base zéro `0` sélectionne le premier nœud de niveau supérieur ; ses nœuds enfants utilisent l'arrangement sélectionné. La présentation modifiée est ensuite enregistrée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Créer un graphique d'organisation avec image**

Un graphique d'organisation avec image est une disposition SmartArt conçue pour les diagrammes hiérarchiques incluant des espaces réservés d'image. Utilisez la valeur [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` lors de l'ajout de l'objet SmartArt à une diapositive. Cet exemple enregistre un diagramme avec des espaces réservés d'image ; il ne remplit pas ces espaces avec des images.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Convertir les diagrammes hérités en groupes de formes**

Lors de la modernisation d'une présentation existante, il peut être nécessaire de mettre à jour un graphique d'organisation créé à l'origine dans PowerPoint 97–2003. Aspose.Slides représente ces diagrammes hérités comme des objets [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Utilisez [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) pour convertir un diagramme en un groupe de formes afin de pouvoir modifier les éléments visuels individuels. Consultez la [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) pour plus de détails.

La conversion ajoute un nouveau groupe à la collection de formes sans supprimer le diagramme original. Après une conversion réussie, supprimez l'original avec [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) pour éviter le contenu dupliqué. Rassemblez les diagrammes hérités dans une liste avant de les convertir afin que l'ajout et la suppression de formes ne perturbent pas l'itération.

L'exemple suivant ouvre une présentation, parcourt chaque diapositive, convertit les diagrammes en groupes de formes et enregistre la présentation mise à jour au format PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La présentation enregistrée contient des groupes de formes modifiables à la place des diagrammes hérités convertis, aucun diagramme original n'étant laissé à côté. Ouvrez le PPTX dans PowerPoint pour modifier les éléments individuels au sein de chaque groupe, comme leur texte, remplissage ou position.

## **FAQ**

**Le SmartArt prend-il en charge le miroir ou l'inversion pour les langues RTL ?**

Oui. La méthode [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) bascule la direction du diagramme de gauche à droite vers droite à gauche, ou inversement, lorsque la disposition SmartArt sélectionnée prend en charge l'inversion.

**Comment copier le SmartArt sur la même diapositive ou dans une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/nodejs-java/shape-manipulations/) avec [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) ou [cloner la diapositive entière](/slides/fr/nodejs-java/clone-slides/) contenant le SmartArt. Les deux approches conservent la taille, la position et le formatage.

**Comment rendre le SmartArt en image bitmap pour un aperçu ou une exportation web ?**

[Rendre la diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) ou la présentation entière en PNG ou JPEG. Le SmartArt est rendu comme partie de la diapositive.

**Comment trouver un objet SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Utilisez [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) ou [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) pour attribuer un texte alternatif ou un nom distinctif à la forme SmartArt, recherchez cette valeur dans [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), puis vérifiez que la forme correspondante est un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).