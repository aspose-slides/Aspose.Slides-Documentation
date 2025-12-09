---
title: Créer ou gérer un nœud de forme SmartArt PowerPoint en JavaScript
linktitle: Gérer le nœud de forme SmartArt
type: docs
weight: 30
url: /fr/nodejs-java/manage-smartart-shape-node/
keywords: smartart powerpoint, nœuds smartart, position smartart, supprimer smartart, ajouter nœuds smartart, présentation powerpoint, powerpoint java, api javascript powerpoint
description: Gérer le nœud smartart et le nœud enfant dans les présentations PowerPoint en JavaScript
---

## **Ajouter un nœud SmartArt à une présentation PowerPoint en JavaScript**

Aspose.Slides for Node.js via Java a fourni l'API la plus simple pour gérer les formes SmartArt de la manière la plus facile. Le code d'exemple suivant aidera à ajouter un nœud et un nœud enfant dans une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. [Ajouter un nouveau nœud](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) dans la forme SmartArt [**NodeCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) et définir le texte dans le TextFrame.
1. Ensuite, [Ajouter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) un [**nœud enfant**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) dans le nœud SmartArt récemment ajouté et définir le texte dans le TextFrame.
1. Enregistrer la présentation.
```javascript
// Charger la présentation souhaitée
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est du type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            // Ajouter un nouveau nœud SmartArt
            var TemNode = smart.getAllNodes().addNode();
            // Ajouter du texte
            TemNode.getTextFrame().setText("Test");
            // Ajouter un nouveau nœud enfant au nœud parent. Il sera ajouté à la fin de la collection
            var newNode = TemNode.getChildNodes().addNode();
            // Ajouter du texte
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Enregistrer la présentation
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajouter un nœud SmartArt à une position spécifique**

Dans le code d'exemple suivant, nous expliquons comment ajouter les nœuds enfants appartenant aux nœuds respectifs d'une forme SmartArt à une position particulière.

1. Créer une instance de la classe Presentation.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) de type [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) dans la diapositive sélectionnée.
1. Accéder au premier nœud de la forme SmartArt ajoutée.
1. Ensuite, ajouter le [**nœud enfant**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) pour le [**nœud**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode) sélectionné à la position 2 et définir son texte.
1. Enregistrer la présentation.
```javascript
// Créer une instance de présentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une forme SmartArt IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Accéder au nœud SmartArt à l'index 0
    var node = smart.getAllNodes().get_Item(0);
    // Ajouter un nouveau nœud enfant à la position 2 dans le nœud parent
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Ajouter du texte
    chNode.getTextFrame().setText("Sample Text Added");
    // Enregistrer la présentation
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder aux nœuds SmartArt dans une présentation PowerPoint en JavaScript**

Le code d'exemple suivant aidera à accéder aux nœuds d’une forme SmartArt. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne peut être défini que lors de l’ajout de la forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. Parcourir tous les [**nœuds**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) de la forme SmartArt.
1. Accéder et afficher des informations telles que la position du nœud SmartArt, son niveau et son texte.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Parcourir chaque forme de la première diapositive
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            // Parcourir tous les nœuds du SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Accéder au nœud SmartArt à l'index i
                var node = smart.getAllNodes().get_Item(j);
                // Afficher les paramètres du nœud SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder au nœud enfant SmartArt**

Le code d'exemple suivant aidera à accéder aux nœuds enfants appartenant aux nœuds respectifs d’une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. Parcourir tous les [**nœuds**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#getAllNodes--) de la forme SmartArt.
1. Pour chaque [**nœud**] de forme SmartArt sélectionné, parcourir tous les [**nœuds enfants**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) à l'intérieur du nœud particulier.
1. Accéder et afficher des informations telles que la position du [**nœud enfant**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) , son niveau et son texte.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Parcourir chaque forme de la première diapositive
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            // Parcourir tous les nœuds du SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Accéder au nœud SmartArt à l'index i
                var node0 = smart.getAllNodes().get_Item(i);
                // Parcourir les nœuds enfants du nœud SmartArt à l'index i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Accéder au nœud enfant du nœud SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // Afficher les paramètres du nœud enfant SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder au nœud enfant SmartArt à une position spécifique**

Dans cet exemple, nous apprendrons à accéder aux nœuds enfants à une position particulière appartenant aux nœuds respectifs d’une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Ajouter une forme SmartArt de type [**StackedList**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Accéder à la forme SmartArt ajoutée.
1. Accéder au nœud à l'index 0 de la forme SmartArt sélectionnée.
1. Ensuite, accéder au [**nœud enfant**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) à la position 1 du nœud SmartArt sélectionné en utilisant la méthode **get_Item()**.
1. Accéder et afficher des informations comme la position, le niveau et le texte du [**nœud enfant**].
```javascript
    // Instancier la présentation
    var pres = new aspose.slides.Presentation();
    try {
        // Accéder à la première diapositive
        var slide = pres.getSlides().get_Item(0);
        // Ajouter la forme SmartArt dans la première diapositive
        var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
        // Accéder au nœud SmartArt à l'index 0
        var node = smart.getAllNodes().get_Item(0);
        // Accéder au nœud enfant à la position 1 dans le nœud parent
        var position = 1;
        var chNode = node.getChildNodes().get_Item(position);
        // Afficher les paramètres du nœud enfant SmartArt
        console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Supprimer un nœud SmartArt dans une présentation PowerPoint en JavaScript**

Dans cet exemple, nous apprendrons à supprimer les nœuds d’une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. Vérifier si le [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) contient plus de 0 nœuds.
1. Sélectionner le nœud SmartArt à supprimer.
1. Ensuite, supprimer le nœud sélectionné en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Enregistrer la présentation.
```javascript
// Charger la présentation souhaitée
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accéder au nœud SmartArt à l'index 0
                var node = smart.getAllNodes().get_Item(0);
                // Supprimer le nœud sélectionné
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Enregistrer la présentation
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Supprimer un nœud SmartArt à une position spécifique**

Dans cet exemple, nous apprendrons à supprimer les nœuds d’une forme SmartArt à une position particulière.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la première diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. Sélectionner le nœud de forme SmartArt à l'index 0.
1. Ensuite, vérifier si le nœud SmartArt sélectionné possède plus de 2 nœuds enfants.
1. Ensuite, supprimer le nœud à la **position 1** en utilisant la méthode [**RemoveNode**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Enregistrer la présentation.
```javascript
// Charger la présentation souhaitée
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Accéder au nœud SmartArt à l'index 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Supprimer le nœud enfant à la position 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Enregistrer la présentation
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir une position personnalisée pour le nœud enfant dans SmartArt**

Aspose.Slides for Node.js via Java prend désormais en charge la définition des propriétés [X](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setX-float-) et [Y](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setY-float-) du [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape). L'extrait de code ci-dessous montre comment définir la position, la taille et la rotation personnalisées d'un SmartArtShape ; notez également que l'ajout de nouveaux nœuds déclenche un recalcul des positions et tailles de tous les nœuds. Avec des paramètres de position personnalisés, l'utilisateur peut positionner les nœuds selon ses besoins.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Déplacer la forme SmartArt à une nouvelle position
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Modifier les largeurs de la forme SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Modifier la hauteur de la forme SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Modifier la rotation de la forme SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Check Assistant Node**
{{% alert color="primary" %}} 

Dans cet article, nous examinerons plus en détail les fonctionnalités des formes SmartArt ajoutées aux diapositives de présentation de façon programmatique à l'aide d'Aspose.Slides for Node.js via Java.

{{% /alert %}} 

Nous utiliserons la forme SmartArt source suivante pour notre investigation dans les différentes sections de cet article.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure : Forme SmartArt source dans la diapositive**|

Dans le code d'exemple suivant, nous étudierons comment identifier les **nœuds assistant** dans la collection de nœuds SmartArt et les modifier.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et charger la présentation avec la forme SmartArt.
1. Obtenir la référence de la deuxième diapositive en utilisant son index.
1. Parcourir chaque forme de la première diapositive.
1. Vérifier si la forme est du type [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) et convertir la forme sélectionnée en [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) si c'est une SmartArt.
1. Parcourir tous les nœuds de la forme SmartArt et vérifier s'ils sont des [**nœuds assistant**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isAssistant--).
1. Modifier le statut du nœud assistant en nœud normal.
1. Enregistrer la présentation.
```javascript
// Créer une instance de présentation
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Parcourir chaque forme dans la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArt
            var smart = shape;
            // Parcourir tous les nœuds de la forme SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Vérifier si le nœud est un nœud Assistant
                if (node.isAssistant()) {
                    // Définir le nœud Assistant sur false et le transformer en nœud normal
                    node.isAssistant();
                }
            }
        }
    }
    // Enregistrer la présentation
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure : Nœuds assistant modifiés dans la forme SmartArt de la diapositive**|

## **Définir le format de remplissage du nœud**
Aspose.Slides for Node.js via Java permet d’ajouter des formes SmartArt personnalisées et de définir leur format de remplissage. Cet article explique comment créer et accéder aux formes SmartArt et définir leur format de remplissage à l’aide d’Aspose.Slides for Node.js via Java.

Veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenir la référence d’une diapositive en utilisant son index.
1. Ajouter une forme [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) en définissant son [**LayoutType**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Définir le [**FillFormat**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getFillFormat--) pour les nœuds de la forme SmartArt.
1. Enregistrer la présentation modifiée en tant que fichier PPTX.
```javascript
// Instancier la présentation
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter la forme SmartArt et les nœuds
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Définir la couleur de remplissage du nœud
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Enregistrer la présentation
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Générer une miniature du nœud enfant SmartArt**
Les développeurs peuvent générer une miniature du nœud enfant d’un SmartArt en suivant les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Ajouter un SmartArt.
1. Obtenir la référence d’un nœud en utilisant son index.
1. Obtenir l’image miniature.
1. Enregistrer l’image miniature dans le format d’image souhaité.
```javascript
// Instancier la classe Presentation qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ajouter SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Obtenir la référence d'un nœud en utilisant son index
    var node = smart.getNodes().get_Item(1);
    // Obtenir la miniature
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Enregistrer la miniature
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**L'animation SmartArt est-elle prise en charge ?**

Oui. SmartArt est traité comme une forme ordinaire, vous pouvez donc [appliquer des animations standard](/slides/fr/nodejs-java/shape-animation/) (entrée, sortie, mise en valeur, chemins de mouvement) et ajuster le timing. Vous pouvez également animer les formes à l'intérieur des nœuds SmartArt si nécessaire.

**Comment puis-je localiser de manière fiable un SmartArt spécifique sur une diapositive si son ID interne est inconnu ?**

Attribuez et recherchez par [texte alternatif](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getalternativetext/). Définir un AltText distinctif sur le SmartArt vous permet de le retrouver sans dépendre des identifiants internes.

**L'apparence du SmartArt sera-t-elle préservée lors de la conversion de la présentation en PDF ?**

Oui. Aspose.Slides rend le SmartArt avec une grande fidélité visuelle lors de l'[export PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), en conservant la disposition, les couleurs et les effets.

**Puis-je extraire une image de l’ensemble du SmartArt (pour des aperçus ou des rapports) ?**

Oui. Vous pouvez rendre une forme SmartArt en [formats raster](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) ou en [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) pour une sortie vectorielle évolutive, ce qui la rend adaptée aux miniatures, aux rapports ou à l’usage web.