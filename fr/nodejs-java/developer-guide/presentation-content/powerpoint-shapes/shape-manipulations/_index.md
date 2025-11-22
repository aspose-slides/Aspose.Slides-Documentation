---
title: Manipulations de formes
type: docs
weight: 40
url: /fr/nodejs-java/shape-manipulations/
---

## **Trouver une forme dans la diapositive**
Cet article décrit une technique simple pour faciliter la recherche d’une forme spécifique sur une diapositive sans utiliser son Id interne. Il est important de savoir que les fichiers de présentation PowerPoint ne disposent d’aucun moyen d’identifier les formes sur une diapositive autre qu’un Id unique interne. Il semble difficile pour les développeurs de trouver une forme en utilisant son Id unique interne. Toutes les formes ajoutées aux diapositives possèdent un texte alternatif. Nous suggérons aux développeurs d’utiliser le texte alternatif pour rechercher une forme spécifique. Vous pouvez utiliser MS PowerPoint pour définir le texte alternatif des objets que vous prévoyez de modifier ultérieurement.

Après avoir défini le texte alternatif de la forme souhaitée, vous pouvez ouvrir cette présentation avec Aspose.Slides for Node.js via Java et parcourir toutes les formes ajoutées à une diapositive. À chaque itération, vous pouvez vérifier le texte alternatif de la forme et la forme dont le texte alternatif correspond sera celle dont vous avez besoin. Pour illustrer cette technique de manière plus claire, nous avons créé une méthode, [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) qui permet de trouver une forme spécifique dans une diapositive et renvoie simplement cette forme.
```javascript
// Instancier une classe Presentation qui représente le fichier de présentation
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Texte alternatif de la forme à rechercher
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **Cloner une forme**
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtenir la référence d’une diapositive en utilisant son indice.
1. Accéder à la collection de formes de la diapositive source.
1. Ajouter une nouvelle diapositive à la présentation.
1. Cloner les formes de la collection de formes de la diapositive source vers la nouvelle diapositive.
1. Enregistrer la présentation modifiée au format PPTX.

L’exemple ci‑dessous ajoute une forme groupe à une diapositive.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Enregistrer le fichier PPTX sur le disque
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Supprimer une forme**
Aspose.Slides for Node.js via Java permet aux développeurs de supprimer n’importe quelle forme. Pour supprimer la forme d’une diapositive, veuillez suivre les étapes ci‑dessous :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Rechercher la forme avec un AlternativeText spécifique.
1. Supprimer la forme.
1. Enregistrer le fichier sur le disque.
```javascript
// Créer l'objet Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une forme auto de type rectangle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Enregistrer la présentation sur le disque
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Masquer une forme**
Aspose.Slides for Node.js via Java permet aux développeurs de masquer n’importe quelle forme. Pour masquer la forme d’une diapositive, veuillez suivre les étapes ci‑dessus :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Rechercher la forme avec un AlternativeText spécifique.
1. Masquer la forme.
1. Enregistrer le fichier sur le disque.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une forme auto de type rectangle
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Enregistrer la présentation sur le disque
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier l’ordre des formes**
Aspose.Slides for Node.js via Java permet aux développeurs de réorganiser les formes. Réorganiser les formes définit quelle forme est au premier plan ou à l’arrière-plan. Pour réorganiser les formes d’une diapositive, veuillez suivre les étapes ci‑dessous :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter une forme.
1. Ajouter du texte dans le cadre de texte de la forme.
1. Ajouter une autre forme aux mêmes coordonnées.
1. Réorganiser les formes.
1. Enregistrer le fichier sur le disque.
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtenir l’ID de forme Interop**
Aspose.Slides for Node.js via Java permet aux développeurs d’obtenir un identifiant unique de forme au niveau de la diapositive, contrairement à la méthode [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) qui permet d’obtenir un identifiant unique au niveau de la présentation. La méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) a été ajoutée aux classes [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) et [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). La valeur renvoyée par la méthode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) correspond à la valeur de l’Id de l’objet Microsoft.Office.Interop.PowerPoint.Shape. Vous trouverez ci‑dessous un exemple de code.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtention de l'identifiant de forme unique dans la portée de la diapositive
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Définir le texte alternatif pour une forme**
Aspose.Slides for Node.js via Java permet aux développeurs de définir l’AlternateText de n’importe quelle forme. Les formes d’une présentation peuvent être distinguées à l’aide de la méthode [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) ou du [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Les méthodes [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) et [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) peuvent être lues ou définies avec Aspose.Slides ainsi qu’avec Microsoft PowerPoint. En utilisant cette méthode, vous pouvez marquer une forme et effectuer différentes opérations telles que la suppression d’une forme, son masquage ou son réordonnancement sur une diapositive. Pour définir l’AlternateText d’une forme, veuillez suivre les étapes ci‑dessous :
1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Accéder à la première diapositive.
1. Ajouter n’importe quelle forme à la diapositive.
1. Effectuer des opérations avec la forme nouvellement ajoutée.
1. Parcourir les formes pour en trouver une.
1. Définir l’AlternativeText.
1. Enregistrer le fichier sur le disque.
```javascript
// Instancier la classe Presentation qui représente le PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une forme auto de type rectangle
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Enregistrer la présentation sur le disque
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder aux formats de mise en page d’une forme**
Aspose.Slides for Node.js via Java fournit une API simple pour accéder aux formats de mise en page d’une forme. Cet article montre comment accéder à ces formats.

Vous trouverez ci‑dessous un exemple de code.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Rendu d’une forme au format SVG**
À présent, Aspose.Slides for Node.js via Java prend en charge le rendu d’une forme au format SVG. La méthode [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (et ses surcharges) a été ajoutée aux classes [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) et [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). Cette méthode permet d’enregistrer le contenu de la forme sous forme de fichier SVG. L’extrait de code ci‑dessous montre comment exporter la forme d’une diapositive vers un fichier SVG.
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Alignement des formes**
Aspose.Slides permet d’aligner les formes soit par rapport aux marges de la diapositive, soit les unes par rapport aux autres. À cette fin, la méthode surchargée [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-) a été ajoutée. L’enumération [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) définit les options d’alignement possibles.

**Exemple 1**

Le code source ci‑dessous aligne les formes avec les indices 1, 2 et 4 le long du bord supérieur de la diapositive.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Exemple 2**

L’exemple ci‑dessous montre comment aligner l’ensemble de la collection de formes par rapport à la forme la plus basse de la collection.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Propriétés de retournement**
Dans Aspose.Slides, la classe [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) offre un contrôle du miroir horizontal et vertical des formes via ses propriétés `flipH` et `flipV`. Ces deux propriétés sont de type `byte`, autorisant les valeurs `1` pour indiquer un retournement, `0` pour aucun retournement, ou `-1` pour le comportement par défaut. Ces valeurs sont accessibles depuis le [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) d’une forme.

Pour modifier les réglages de retournement, une nouvelle instance de [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) est créée avec la position et la taille actuelles de la forme, les valeurs souhaitées pour `flipH` et `flipV`, ainsi que l’angle de rotation. L’attribution de cette instance au [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) de la forme et l’enregistrement de la présentation appliquent les transformations de miroir et les enregistrent dans le fichier de sortie.

Supposons que nous ayons un fichier sample.pptx dont la première diapositive contient une seule forme avec les réglages de retournement par défaut, comme indiqué ci‑dessus.

![The shape to be flipped](shape_to_be_flipped.png)

L’exemple de code suivant récupère les propriétés de retournement actuelles de la forme et la retourne à la fois horizontalement et verticalement.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Récupérer la propriété de retournement horizontal de la forme.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Récupérer la propriété de retournement vertical de la forme.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Retourner horizontalement.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Retourner verticalement.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


Le résultat :

![The flipped shape](flipped_shape.png)

## **FAQ**

**Puis‑je combiner des formes (union/intersection/soustraction) sur une diapositive comme dans un éditeur de bureau ?**

Il n’existe pas d’API d’opérations booléennes intégrée. Vous pouvez l’approximer en construisant vous‑même le contour désiré — par exemple, calculer la géométrie résultante (via [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)) et créer une nouvelle forme avec ce contour, en supprimant éventuellement les originales.

**Comment contrôler l’ordre d’empilement (z‑order) pour qu’une forme reste toujours « au premier plan » ?**

Modifiez l’ordre d’insertion ou de déplacement dans la collection [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) de la diapositive. Pour des résultats prévisibles, finalisez le z‑order après toutes les autres modifications de la diapositive.

**Puis‑je « verrouiller » une forme pour empêcher les utilisateurs de la modifier dans PowerPoint ?**

Oui. Définissez les [drapeaux de protection au niveau de la forme](/slides/fr/nodejs-java/applying-protection-to-presentation/) (par exemple, verrouiller la sélection, le déplacement, le redimensionnement, les modifications de texte). Si nécessaire, appliquez des restrictions similaires sur la diapositive maître ou le masque. Notez qu’il s’agit d’une protection au niveau de l’interface utilisateur, pas d’une fonctionnalité de sécurité ; pour une protection plus forte, combinez‑la avec des restrictions au niveau du fichier comme les [recommandations en lecture seule ou les mots de passe](/slides/fr/nodejs-java/password-protected-presentation/).