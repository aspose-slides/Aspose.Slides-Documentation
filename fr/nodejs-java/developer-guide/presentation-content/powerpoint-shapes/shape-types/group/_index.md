---
title: Groupe
type: docs
weight: 40
url: /fr/nodejs-java/group/
---

## **Ajouter une forme de groupe**
Aspose.Slides prend en charge le travail avec les formes de groupe sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides pour Node.js via Java prend en charge l'ajout ou l'accès aux formes de groupe. Il est possible d'ajouter des formes à une forme de groupe ajoutée pour la remplir ou accéder à n'importe quelle propriété de la forme de groupe. Pour ajouter une forme de groupe à une diapositive en utilisant Aspose.Slides pour Node.js via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Ajoutez une forme de groupe à la diapositive.
1. Ajoutez les formes à la forme de groupe ajoutée.
1. Enregistrez la présentation modifiée au format PPTX.

L'exemple ci-dessous ajoute une forme de groupe à une diapositive.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Accéder à la collection de formes des diapositives
    var slideShapes = sld.getShapes();
    // Ajouter une forme de groupe à la diapositive
    var groupShape = slideShapes.addGroupShape();
    // Ajouter des formes à l'intérieur de la forme de groupe ajoutée
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Ajouter le cadre de la forme de groupe
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Écrire le fichier PPTX sur le disque
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder à la propriété AltText**
Ce sujet montre des étapes simples, accompagnées d'exemples de code, pour ajouter une forme de groupe et accéder à la propriété AltText des formes de groupe sur les diapositives. Pour accéder à l'AltText d'une forme de groupe dans une diapositive en utilisant Aspose.Slides pour Node.js via Java :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) qui représente le fichier PPTX.
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. Accédez à la collection de formes des diapositives.
1. Accédez à la forme de groupe.
1. Appelez la propriété [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--).

L'exemple ci-dessous accède au texte alternatif de la forme de groupe.
```javascript
// Instancier la classe Presentation qui représente le fichier PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Accéder à la collection de formes des diapositives
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Accéder à la forme de groupe.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Accéder à la propriété AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Le regroupement imbriqué (une forme de groupe à l'intérieur d'une autre) est-il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) possède une méthode [getParentGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getparentgroup/) qui indique directement la prise en charge de la hiérarchie (une forme de groupe peut être l'enfant d'un autre groupe).

**Comment contrôler l'ordre Z du groupe par rapport aux autres objets sur la diapositive ?**

Utilisez la méthode [getZOrderPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getzorderposition/) de GroupShape pour inspecter sa position dans la pile d'affichage.

**Puis-je empêcher le déplacement/l'édition/le dégroupage ?**

Oui. La section de verrouillage du groupe est exposée via [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), ce qui vous permet de restreindre les opérations sur l'objet.