---
title: Modifier la taille et l'orientation de la page des notes en JavaScript
linktitle: Taille de la page des notes
type: docs
weight: 10
url: /fr/nodejs-java/notes-size/
keywords:
- taille de la page des notes
- orientation des notes
- notes en mode paysage
- notes en mode portrait
- taille du support
- PowerPoint
- présentation
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Lire et modifier les dimensions de la page des notes dans Aspose.Slides pour Node.js via Java, changer l'orientation, vérifier les tailles enregistrées, et exporter les notes ou les supports en PDF et images."
---
## **Aperçu**

Utilisez [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getnotessize/) pour accéder aux paramètres de la page de notes de la présentation. Elle renvoie un objet [NotesSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notessize/) dont la méthode [setSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notessize/setsize/) définit les dimensions de la page. Bien que l'objet de paramètres lui‑même ne puisse pas être remplacé, vous pouvez affecter de nouvelles dimensions via cette méthode.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s’appliquent à la présentation, et non à la note d’une diapositive individuelle.

| Paramètre | Objectif |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getnotessize/) | Contrôle les dimensions de la page de notes ainsi que les dimensions de page utilisées pour l’exportation des supports. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getslidesize/) | Contrôle les dimensions des diapositives normales de la présentation via [SlideSize](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidesize/). |

Modifier l’un ou l’autre paramètre ne modifie pas automatiquement l’autre. Modifier l’orientation de la page de notes ne fait pas non plus pivoter les diapositives normales. Consultez [Slide Size](/slides/fr/nodejs-java/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessus utilisent un fichier `sample.pptx` existant. Pour les exemples d’exportation, utilisez une présentation contenant au moins une diapositive avec des notes de présentateur. Chaque exemple peut être exécuté de manière indépendante.

## **Lire la taille et l’orientation de la page de notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l’orientation : une page plus large est en mode paysage, une page plus haute est en mode portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer une taille de papier standard.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Passer en paysage sans modifier la taille du papier**

Pour ne modifier que l’orientation, échangez la largeur et la hauteur existantes. Cela conserve les longueurs des deux côtés, y compris celles d’une taille de papier personnalisée. La condition ci‑dessous empêche une page déjà en paysage d’être reconvertie en portrait et laisse une page carrée inchangée.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour une orientation portrait, utilisez la même affectation lorsque `size.getWidth() > size.getHeight()`. Ne remplacez pas les dimensions A4 ou Letter à moins de vouloir également modifier la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Affectez les deux dimensions simultanément, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/save/) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX, puis rouvre le fichier enregistré pour vérifier les valeurs conservées. La comparaison autorise une tolérance de 0,01 point pour les valeurs à virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Le résultat attendu est `900 x 600 points` et `Size preserved: true`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que les seuls paramètres en mémoire.

## **Exporter les notes et les supports**

Les dimensions de la page définissent la zone disponible pour les notes ou les mises en page des supports. Elles n’activent pas ces mises en page seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Affectez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notescommentslayoutingoptions/) à [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes au format PNG en utilisant [Slide.getImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getImage) et [RenderingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notespositions/) conserve les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. Avec l’échelle d’image de 1 × 1 utilisée ci‑dessous, le PNG mesure 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Pour l’exportation PDF avec de longues notes, [BottomFull](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/notespositions/) permet d’ajouter des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après le redimensionnement, examinez la sortie pour détecter des notes tronquées et le positionnement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Consultez [Convert PowerPoint to PDF with Notes](/slides/fr/nodejs-java/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les supports en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une même page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Modifier la taille de la page modifie la zone disponible pour la grille du support sans changer les dimensions des diapositives sources. Pour les images de support, utilisez [Presentation.getImages](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/getimages/) avec la mise en page du support, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu des supports au niveau de la présentation utilise les dimensions de la page de notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page de support. Consultez [Handout Mode](/slides/fr/nodejs-java/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Conservez distinctes la taille de la présentation stockée, la taille de page exportée et la taille de papier imprimée :

- **Visionneuses de présentation :** Un visionneur peut afficher ou imprimer les notes en appliquant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation :** Les exemples de PDF de notes et de supports ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions de pixels entiers et une échelle de rendu, de sorte que les valeurs fractionnaires de points peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de page des notes.
- **Pilotes d’imprimante :** La sélection du papier, la rotation automatique et les paramètres d’ajustement à la page peuvent modifier le rendu physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier spécifique, adaptez les paramètres de l’imprimante et vérifiez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir des notes différentes, mais cette propriété ne fournit pas de taille de page distincte pour chaque diapositive.

**Pourquoi la modification de l’orientation des notes n’a‑t‑elle pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑mêmes.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Rouvrez d’abord la présentation enregistrée et comparez ses dimensions de notes. Si celles‑ci ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle d’image, les paramètres du visionneur et la sélection du papier d’imprimante.