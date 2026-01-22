---
title: Gérer les SmartArt dans les présentations PowerPoint en JavaScript
linktitle: Gérer les SmartArt
type: docs
weight: 10
url: /fr/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt texte
- type de disposition
- propriété masquée
- organigramme
- organigramme d'image
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à créer et modifier des SmartArt PowerPoint avec Aspose.Slides pour Node.js en utilisant des exemples de code JavaScript clairs qui accélèrent la conception et l'automatisation des diapositives."
---

## **Obtenir le texte de SmartArt**
La méthode TextFrame a maintenant été ajoutée à la classe [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) et à la classe [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) respectivement. Cette propriété vous permet d'obtenir tout le texte de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) s'il ne contient pas uniquement le texte des nœuds. Le code d'exemple suivant vous aidera à récupérer le texte d'un nœud SmartArt.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier le type de disposition de SmartArt**
Pour modifier le type de disposition de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Suivez les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Obtenez la référence d'une diapositive en utilisant son index.
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Modifiez le [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) en BasicProcess.
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajouter SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Modifier LayoutType en BasicProcess
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // Enregistrement de la présentation
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Vérifier la propriété de visibilité de SmartArt**
Veuillez noter : la méthode [SmartArtNode.isHidden()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) renvoie true si ce nœud est masqué dans le modèle de données. Pour vérifier la propriété masquée de n'importe quel nœud de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Suivez les étapes ci‑dessus :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Ajoutez un nœud au SmartArt.
- Vérifiez la propriété de [visibility](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/).
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajouter SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // Ajouter un nœud sur SmartArt
    var node = smart.getAllNodes().addNode();
    // Vérifier la propriété isHidden
    var hidden = node.isHidden();// Retourne true
    if (hidden) {
        // Effectuer des actions ou des notifications
    }
    // Enregistrement de la présentation
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir ou définir le type de diagramme d'organisation**
Les méthodes [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) et [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) permettent d'obtenir ou de définir le type de diagramme d'organisation associé au nœud actuel. Pour obtenir ou définir le type de diagramme d'organisation, suivez les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Ajoutez un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
- Obtenez ou [définissez le type de diagramme d'organisation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Enregistrez la présentation au format PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un connecteur entre deux formes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ajouter SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Obtenir ou définir le type de diagramme d'organisation
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // Enregistrement de la présentation
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Créer un diagramme d'organisation d'image**
Aspose.Slides for Node.js via Java propose une API simple pour créer des graphiques PictureOrganization facilement. Pour créer un graphique sur une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d'une diapositive par son index.
3. Ajoutez un graphique avec les données par défaut ainsi que le type souhaité (ChartType.PictureOrganizationChart).
4. Enregistrez la présentation modifiée au format PPTX.

Le code suivant est utilisé pour créer un graphique.
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir ou définir l'état de SmartArt**
Pour modifier le type de disposition de [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Ajoutez un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) sur la diapositive.
3. [Obtenez](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) ou [définissez](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) l'état du diagramme SmartArt.
4. Enregistrez la présentation au format PPTX.

Le code suivant est utilisé pour créer un graphique.
```javascript
// Instancier la classe Presentation qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ajouter SmartArt BasicProcess
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // Obtenir ou définir l'état du diagramme SmartArt
    smart.setReversed(true);
    var flag = smart.isReversed();
    // Enregistrement de la présentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**SmartArt prend‑t‑il en charge le mirroring/la réversion pour les langues RTL ?**

Oui. La méthode [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) bascule la direction du diagramme (LTR/RTL) si le type SmartArt sélectionné prend en charge la réversion.

**Comment copier SmartArt sur la même diapositive ou vers une autre présentation tout en conservant le formatage ?**

Vous pouvez [cloner la forme SmartArt](/slides/fr/nodejs-java/shape-manipulations/) via la collection de formes ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) ou [cloner la diapositive entière](/slides/fr/nodejs-java/clone-slides/) contenant cette forme. Les deux approches conservent la taille, la position et le style.

**Comment rendre SmartArt en image raster pour l'aperçu ou l'export Web ?**

Vous pouvez [rendre la diapositive](/slides/fr/nodejs-java/convert-powerpoint-to-png/) (ou l'ensemble de la présentation) en PNG/JPEG via l'API qui convertit les diapositives/présentations en images — SmartArt sera dessiné comme partie de la diapositive.

**Comment sélectionner de manière programmatique un SmartArt spécifique sur une diapositive s'il y en a plusieurs ?**

Une pratique courante consiste à utiliser le [texte alternatif](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) ou [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) et à rechercher la forme par cet attribut à l'aide de [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), puis à vérifier le type pour confirmer qu'il s'agit d'un [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). La documentation décrit les techniques typiques pour trouver et travailler avec les formes.