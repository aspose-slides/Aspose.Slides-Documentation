---
title: Cloner les diapositives d'une présentation en JavaScript
linktitle: Cloner des diapositives
type: docs
weight: 35
url: /fr/nodejs-java/clone-slides/
keywords:
- cloner diapositive
- copier diapositive
- enregistrer diapositive
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Dupliquez rapidement des diapositives PowerPoint avec Aspose.Slides pour Node.js. Suivez nos exemples de code pour automatiser la création de PPT en quelques secondes et éliminer le travail manuel."
---
## **Introduction**

Le clonage est le processus de création d'une copie exacte ou d'un replica de quelque chose. Aspose.Slides for Node.js via Java permet également de créer une copie ou un clone de n'importe quelle diapositive, puis d'insérer cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositives crée une nouvelle diapositive qui peut être modifiée par les développeurs sans changer la diapositive originale. Il existe plusieurs façons de cloner une diapositive :

- Cloner à la fin d'une présentation.
- Cloner à une autre position au sein d'une présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for Node.js via Java, (une collection d'objets [Slide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Slide)) exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) fournit les méthodes [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) pour réaliser les types de clonage de diapositives ci‑dessus.

## **Cloner à la fin d'une présentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
3. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
4. Enregistrez le fichier de présentation modifié.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives de la même présentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Enregistrer la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner à une autre position dans la même présentation**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
2. Instanciez la classe en faisant référence à la collection [**Slides**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation).
3. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) et passez la diapositive à cloner ainsi que l'indice de la nouvelle position en paramètre de la méthode [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
4. Enregistrez la présentation modifiée au format PPTX.

Dans l'exemple ci‑dessous, nous avons cloné une diapositive (située à l'indice 1 – position 2 – de la présentation) à l'indice 2 – position 3 – de la présentation.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Cloner la diapositive souhaitée à la fin de la collection de diapositives de la même présentation
    var slds = pres.getSlides();
    // Cloner la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Enregistrer la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Cloner à la fin dans une autre présentation**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation de destination dans laquelle la diapositive sera ajoutée.
3. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection) en faisant référence à la collection [**Slides**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) exposée par l'objet Presentation de la présentation de destination.
4. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
5. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive (à partir du premier indice de la présentation source) à la fin de la présentation de destination.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Enregistrer la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à une autre position dans une autre présentation**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation source depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation dans laquelle la diapositive sera ajoutée.
3. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l'objet Presentation de la présentation de destination.
4. Appelez la méthode [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source ainsi que la position souhaitée en paramètre de la méthode [insertClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
5. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive (à partir de l'indice zéro de la présentation source) à l'indice 1 (position 2) de la présentation de destination.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancier la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Cloner la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // Enregistrer la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec une diapositive maître d'une présentation et l'utiliser dans une autre présentation, vous devez d'abord cloner la diapositive maître souhaitée de la présentation source vers la présentation de destination. Ensuite, vous devez utiliser cette diapositive maître pour cloner la diapositive avec maître. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) attend une diapositive maître provenant de la présentation de destination plutôt que de la présentation source. Pour cloner la diapositive avec un maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation source depuis laquelle la diapositive sera clonée.
2. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
3. Accédez à la diapositive à cloner ainsi qu'à la diapositive maître.
4. Instanciez la classe [MasterSlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MasterSlideCollection) en faisant référence à la collection Masters exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) de la présentation de destination.
5. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l'objet [MasterSlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/MasterSlideCollection) et passez le maître du PPTX source à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
6. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) en définissant la référence à la collection Slides exposée par l'objet [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation) de la présentation de destination.
7. Appelez la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getSlides--) et passez la diapositive de la présentation source à cloner ainsi que la diapositive maître en paramètre de la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
8. Enregistrez le fichier de présentation de destination modifié.

Dans l'exemple ci‑dessus, nous avons cloné une diapositive avec un maître (située à l'indice zéro de la présentation source) à la fin de la présentation de destination en utilisant un maître de la diapositive source.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instancier la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancier la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instancier ISlide à partir de la collection de diapositives de la présentation source avec
        // Diapositive maître
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Cloner la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans le
        // présentation de destination
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // Cloner la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // collection de diapositives de la présentation de destination
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // Enregistrer la présentation de destination sur le disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **Cloner à la fin dans une section spécifiée**
Si vous souhaitez cloner une diapositive puis l'utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) exposée par la classe [**SlideCollection**](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java permet de cloner une diapositive de la première section puis d'insérer cette diapositive clonée dans la seconde section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Enregistrer la présentation de destination sur le disque
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Assurer une taille de diapositive correspondante**

Lors du clonage de diapositives dans une autre présentation, assurez‑vous que la présentation de destination possède la même taille de diapositive que la source. Si les tailles de diapositives diffèrent, Aspose.Slides ne redimensionne pas automatiquement les formes clonées : leurs coordonnées et dimensions d'origine sont conservées, ce qui peut entraîner un désalignement du contenu ou son dépassement des limites de la diapositive.

Vous pouvez définir la taille des diapositives de la présentation de destination pour qu'elle corresponde à celle de la source avant de cloner le maître et la diapositive :

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

Effectuez cette opération avant de cloner le maître et la diapositive.

## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont-ils clonés ?**

Oui. La page de notes et les commentaires de révision sont inclus dans le clone. Si vous ne les souhaitez pas, [supprimez‑les](/slides/fr/nodejs-java/presentation-notes/) après l'insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L'objet graphique, son formatage et les données incorporées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé en tant qu'[objet OLE](/slides/fr/nodejs-java/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/nodejs-java/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dans celle‑ci.