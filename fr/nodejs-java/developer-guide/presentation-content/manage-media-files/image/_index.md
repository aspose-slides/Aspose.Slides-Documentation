---
title: Image
type: docs
weight: 10
url: /fr/nodejs-java/image/
keywords:
- ajouter image
- ajouter image
- ajouter bitmap
- remplacer image
- remplacer image
- depuis le web
- arrière-plan
- ajouter PNG
- ajouter JPG
- ajouter SVG
- ajouter EMF
- ajouter WMF
- ajouter TIFF
- PowerPoint
- OpenDocument
- présentation
- EMF
- SVG
- Node.js
- Aspose.Slides
description: "Simplifiez la gestion des images dans PowerPoint et OpenDocument avec Aspose.Slides pour Node.js, en optimisant les performances et en automatisant votre flux de travail."
---

## **Images dans les diapositives des présentations**

Les images rendent les présentations plus attrayantes et intéressantes. Dans Microsoft PowerPoint, vous pouvez insérer des images depuis un fichier, Internet ou d’autres emplacements sur les diapositives. De même, Aspose.Slides vous permet d’ajouter des images aux diapositives de vos présentations grâce à différentes procédures.

{{% alert title="Astuce" color="primary" %}} 

Aspose propose des convertisseurs gratuits — [JPEG vers PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) et [PNG vers PowerPoint](https://products.aspose.app/slides/import/png-to-ppt) — qui permettent de créer rapidement des présentations à partir d’images. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Si vous souhaitez ajouter une image en tant qu’objet cadre—en particulier si vous prévoyez d’utiliser les options de formatage standard pour modifier sa taille, ajouter des effets, etc.—voir [Cadre d’image](https://docs.aspose.com/slides/nodejs-java/picture-frame/).

{{% /alert %}} 

{{% alert title="Remarque" color="warning" %}}

Vous pouvez manipuler les opérations d’entrée/sortie impliquant des images et des présentations PowerPoint pour convertir une image d’un format à un autre. Consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/nodejs-java/conversion/image-to-jpg/ ); convertir [JPG en image](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-image/ ); convertir [JPG en PNG](https://products.aspose.com/slides/nodejs-java/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-jpg/); convertir [PNG en SVG](https://products.aspose.com/slides/nodejs-java/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides prend en charge les opérations avec des images dans ces formats populaires : JPEG, PNG, GIF et d’autres.

## **Ajout d’images stockées localement aux diapositives**

Vous pouvez ajouter une ou plusieurs images présentes sur votre ordinateur à une diapositive d’une présentation. Ce code d’exemple en JavaScript vous montre comment ajouter une image à une diapositive :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajout d’images depuis un flux aux diapositives**

Si l’image que vous souhaitez ajouter à une diapositive n’est pas disponible sur votre ordinateur, vous pouvez l’ajouter directement depuis le Web.

Ce code d’exemple vous montre comment ajouter une image depuis le Web à une diapositive en JavaScript :
```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Charge un fichier Excel en flux
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Crée un objet de données pour l'intégration
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Ajoute une forme de cadre d'objet Ole
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Écrit le fichier PPTX sur le disque
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajout d’images aux maîtres de diapositives**

Un maître de diapositive est la diapositive supérieure qui stocke et contrôle les informations (thème, mise en page, etc.) de toutes les diapositives qui en découlent. Ainsi, lorsque vous ajoutez une image à un maître de diapositive, cette image apparaît sur chaque diapositive utilisant ce maître.

Ce code d’exemple en JavaScript vous montre comment ajouter une image à un maître de diapositive :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ajout d’images comme arrière-plan de diapositive**

Vous pouvez décider d’utiliser une image comme arrière‑plan d’une diapositive spécifique ou de plusieurs diapositives. Dans ce cas, vous devez consulter *[Définir des images comme arrière‑plans pour les diapositives](https://docs.aspose.com/slides/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Ajout de SVG aux présentations**
Vous pouvez ajouter ou insérer n’importe quelle image dans une présentation en utilisant la méthode [addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) appartenant à la classe [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection).

Pour créer un objet image basé sur une image SVG, procédez ainsi :

1. Créez un objet SvgImage à insérer dans ImageShapeCollection  
2. Créez un objet PPImage à partir de ISvgImage  
3. Créez un objet PictureFrame en utilisant la classe PPImage  

Ce code d’exemple vous montre comment mettre en œuvre les étapes ci‑dessus pour ajouter une image SVG à une présentation :
```javascript
// Instancier la classe Presentation qui représente le fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Conversion du SVG en ensemble de formes**
La conversion du SVG en un ensemble de formes par Aspose.Slides est similaire à la fonctionnalité PowerPoint utilisée pour travailler avec les images SVG :

![PowerPoint Popup Menu](img_01_01.png)

Cette fonctionnalité est fournie par l’une des surcharge de la méthode [addGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) de la classe [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection) qui accepte un objet [SvgImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SvgImage) en premier argument.

Ce code d’exemple vous montre comment utiliser la méthode décrite pour convertir un fichier SVG en un ensemble de formes :
```javascript
// Créer une nouvelle présentation
var presentation = new aspose.slides.Presentation();
try {
    // Lire le contenu du fichier SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Créer un objet SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Obtenir la taille de la diapositive
    var slideSize = presentation.getSlideSize().getSize();
    // Convertir l'image SVG en groupe de formes en l'ajustant à la taille de la diapositive
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Enregistrer la présentation au format PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Ajout d’images en tant qu’EMF dans les diapositives**
Aspose.Slides for Node.js via Java vous permet de générer des images EMF à partir de feuilles Excel et d’ajouter ces images en tant qu’EMF dans les diapositives avec Aspose.Cells. 

Ce code d’exemple vous montre comment réaliser la tâche décrite :
```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Remplacement d’images dans la collection d’images**

Aspose.Slides vous permet de remplacer les images stockées dans la collection d’images d’une présentation (y compris celles utilisées par les formes de diapositives). Cette section montre plusieurs approches pour mettre à jour les images de la collection. L’API fournit des méthodes simples pour remplacer une image à l’aide de données brutes, d’une instance [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) ou d’une autre image déjà présente dans la collection.

Suivez les étapes ci‑dessous :

1. Chargez le fichier de présentation contenant les images à l’aide de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).  
2. Chargez une nouvelle image depuis un fichier dans un tableau d’octets.  
3. Remplacez l’image cible par la nouvelle image en utilisant le tableau d’octets.  
4. Dans la deuxième approche, chargez l’image dans un objet [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) et remplacez l’image cible par cet objet.  
5. Dans la troisième approche, remplacez l’image cible par une image déjà présente dans la collection d’images de la présentation.  
6. Enregistrez la présentation modifiée au format PPTX.  

```js
// Instancier la classe Presentation qui représente un fichier de présentation.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // La première façon.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // La deuxième façon.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // La troisième façon.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


{{% alert title="Info" color="info" %}}

En utilisant le convertisseur GRATUIT Aspose [Texte vers GIF](https://products.aspose.app/slides/text-to-gif), vous pouvez facilement animer du texte, créer des GIF à partir de texte, etc. 

{{% /alert %}}

## **FAQ**

**La résolution de l’image originale reste‑t‑elle intacte après l’insertion ?**

Oui. Les pixels source sont conservés, mais l’apparence finale dépend de la manière dont le [cadre d’image](/slides/fr/nodejs-java/picture-frame/) est mis à l’échelle sur la diapositive et de toute compression appliquée lors de l’enregistrement.

**Quelle est la meilleure façon de remplacer le même logo sur des dizaines de diapositives en une fois ?**

Placez le logo sur le maître de diapositive ou sur une mise en page et remplacez‑le dans la collection d’images de la présentation ; les mises à jour se propageront à tous les éléments qui utilisent cette ressource.

**Un SVG inséré peut‑il être converti en formes modifiables ?**

Oui. Vous pouvez convertir un SVG en un groupe de formes, après quoi chaque partie devient modifiable avec les propriétés de forme classiques.

**Comment définir une image comme arrière‑plan pour plusieurs diapositives en même temps ?**

[Attribuez l’image comme arrière‑plan](/slides/fr/nodejs-java/presentation-background/) sur le maître de diapositive ou la mise en page concernée ; toutes les diapositives utilisant ce maître/mise en page hériteront de l’arrière‑plan.

**Comment empêcher la présentation de « gonfler » en taille à cause de nombreuses images ?**

Réutilisez une même ressource d’image au lieu de duplicata, choisissez des résolutions raisonnables, appliquez une compression lors de l’enregistrement et conservez les graphiques répétés sur le maître lorsque cela est approprié.