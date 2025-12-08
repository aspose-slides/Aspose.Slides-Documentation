---
title: Gérer la forme SmartArt
type: docs
weight: 20
url: /fr/nodejs-java/manage-smartart-shape/
---

## **Créer une forme SmartArt**
Aspose.Slides for Node.js via Java a fourni une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. Obtenez la référence d’une diapositive en utilisant son index.
3. [Add a SmartArt shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) en définissant son [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtLayoutType).
4. Enregistrez la présentation modifiée au format PPTX.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une forme SmartArt
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // Enregistrement de la présentation
    pres.save("SimpleSmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : Forme SmartArt ajoutée à la diapositive**|

## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans le code d’exemple, nous parcourrons chaque forme à l’intérieur de la diapositive et vérifierons s’il s’agit d’une forme [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Si la forme est de type SmartArt, nous la convertirons en instance de [**SmartArt**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).
```javascript
// Charger la présentation souhaitée
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArtEx
            var smart = shape;
            console.log("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Accéder à la forme SmartArt avec un LayoutType particulier**
Le code d’exemple suivant permet d’accéder à la forme [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne peut être défini que lors de l’ajout de la forme [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son index.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt] et convertissez la forme sélectionnée en SmartArt si c’est le cas.
5. Vérifiez la forme SmartArt avec le LayoutType particulier et effectuez les actions requises par la suite.
```javascript
var pres = new aspose.slides.Presentation("AccessSmartArtShape.pptx");
try {
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArtEx
            var smart = shape;
            // Vérifier la mise en page SmartArt
            if (smart.getLayout() == aspose.slides.SmartArtLayoutType.BasicBlockList) {
                console.log("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modifier le style de la forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style rapide d’une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son index.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt] et convertissez la forme sélectionnée en SmartArt si c’est le cas.
5. Trouvez la forme SmartArt avec un style particulier.
6. Définissez le nouveau style pour la forme SmartArt.
7. Enregistrez la présentation.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArtEx
            var smart = shape;
            // Vérifier le style SmartArt
            if (smart.getQuickStyle() == aspose.slides.SmartArtQuickStyleType.SimpleFill) {
                // Modifier le style SmartArt
                smart.setQuickStyle(aspose.slides.SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Enregistrer la présentation
    pres.save("ChangeSmartArtStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : Forme SmartArt avec style modifié**|

## **Modifier le style de couleur de la forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur d’une forme SmartArt. Le code d’exemple suivant accédera à la forme SmartArt avec un style de couleur particulier et en modifiera le style.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) et chargez la présentation contenant la forme SmartArt.
2. Obtenez la référence de la première diapositive en utilisant son index.
3. Parcourez chaque forme à l’intérieur de la première diapositive.
4. Vérifiez si la forme est de type [SmartArt] et convertissez la forme sélectionnée en SmartArt si c’est le cas.
5. Trouvez la forme SmartArt avec un style de couleur particulier.
6. Définissez le nouveau style de couleur pour la forme SmartArt.
7. Enregistrez la présentation.
```javascript
// Instancier la classe Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Obtenir la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Parcourir chaque forme à l'intérieur de la première diapositive
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Vérifier si la forme est de type SmartArt
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Convertir la forme en SmartArtEx
            var smart = shape;
            // Vérifier le type de couleur SmartArt
            if (smart.getColorStyle() == aspose.slides.SmartArtColorType.ColoredFillAccent1) {
                // Modifier le type de couleur SmartArt
                smart.setColorStyle(aspose.slides.SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Enregistrer la présentation
    pres.save("ChangeSmartArtColorStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure : Forme SmartArt avec style de couleur modifié**|

## **FAQ**

**Puis-je animer SmartArt comme un seul objet ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [standard animations](/slides/fr/nodejs-java/powerpoint-animation/) via l’API d’animations (entrée, sortie, mise en évidence, chemins de mouvement) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme à l’aide de cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis‑je regrouper SmartArt avec d’autres formes ?**

Oui. Vous pouvez regrouper SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/nodejs-java/group/).

**Comment obtenir une image d’un SmartArt spécifique (par exemple, pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [render individual shapes](/slides/fr/nodejs-java/create-shape-thumbnails/) en fichiers raster (PNG/JPG/TIFF).

**L’apparence de SmartArt sera‑t‑elle conservée lors de la conversion de l’ensemble de la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[PDF export](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/), avec un éventail d’options de qualité et de compatibilité.