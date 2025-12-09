---
title: Cloner des diapositives
type: docs
weight: 35
url: /fr/nodejs-java/clone-slides/
---

## **Cloner des diapositives dans une présentation**
Le clonage est le processus consistant à créer une copie exacte ou une réplique de quelque chose. Aspose.Slides for Node.js via Java rend également possible la création d’une copie ou d’un clone de n’importe quelle diapositive, puis l’insertion de cette diapositive clonée dans la présentation actuelle ou toute autre présentation ouverte. Le processus de clonage de diapositive crée une nouvelle diapositive qui peut être modifiée par les développeurs sans modifier la diapositive originale. Il existe plusieurs manières possibles de cloner une diapositive :

- Cloner à la fin dans une présentation.
- Cloner à une autre position dans une présentation.
- Cloner à la fin dans une autre présentation.
- Cloner à une autre position dans une autre présentation.
- Cloner à une position spécifique dans une autre présentation.

Dans Aspose.Slides for Node.js via Java, (une collection d’[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) objects) exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) fournit les méthodes [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) et [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) pour réaliser les types de clonage de diapositive mentionnés ci‑dessus

## **Cloner à la fin dans une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation à la fin des diapositives existantes, utilisez la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) selon les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation modifié.

Dans l’exemple ci‑dessous, nous avons cloné une diapositive (située à la première position – indice zéro – de la présentation) à la fin de la présentation.
```javascript
// Instancie la classe Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // Clone la diapositive souhaitée à la fin de la collection de diapositives de la même présentation
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // Enregistre la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Cloner à une autre position dans une présentation**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais à une position différente, utilisez la méthode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Instanciez la classe en faisant référence à la collection [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) et transmettez la diapositive à cloner ainsi que l’indice de la nouvelle position en paramètres de la méthode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (située à l’indice zéro – position 1 – de la présentation) à l’indice 1 – position 2 – de la présentation.
```javascript
// Instancie la classe Presentation qui représente un fichier de présentation
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // Clone la diapositive souhaitée à la fin de la collection de diapositives de la même présentation
    var slds = pres.getSlides();
    // Clone la diapositive souhaitée à l'index spécifié dans la même présentation
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // Enregistre la présentation modifiée sur le disque
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Cloner à la fin dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à la fin des diapositives existantes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation source de la diapositive à cloner.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation de destination dans laquelle la diapositive sera ajoutée.
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) en faisant référence à la collection [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source en paramètre de la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (du premier indice de la présentation source) à la fin de la présentation de destination.
```javascript
// Instancie la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancie la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // Enregistre la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Cloner à une autre position dans une autre présentation**
Si vous devez cloner une diapositive d’une présentation et l’utiliser dans une autre présentation, à une position spécifique :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation de destination à laquelle la diapositive sera ajoutée.
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) en faisant référence à la collection Slides exposée par l’objet Presentation de la présentation de destination.
1. Appelez la méthode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) et transmettez la diapositive de la présentation source ainsi que la position souhaitée en paramètres de la méthode [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive (du zéro indice de la présentation source) à l’indice 1 (position 2) de la présentation de destination.
```javascript
// Instancie la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // Instancie la classe Presentation pour le PPTX de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Clone la diapositive souhaitée de la présentation source à la fin de la collection de diapositives de la présentation de destination
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // Enregistre la présentation de destination sur le disque
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Cloner à une position spécifique dans une autre présentation**
Si vous devez cloner une diapositive avec une diapositive maîtresse d’une présentation et l’utiliser dans une autre présentation, vous devez d’abord cloner la diapositive maîtresse souhaitée de la présentation source vers la présentation de destination. Ensuite, utilisez cette diapositive maîtresse pour cloner la diapositive avec maître. La méthode [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) attend une diapositive maîtresse provenant de la présentation de destination plutôt que de la source. Pour cloner la diapositive avec maître, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation source dont la diapositive sera clonée.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) contenant la présentation de destination vers laquelle la diapositive sera clonée.
1. Accédez à la diapositive à cloner ainsi qu’à sa diapositive maîtresse.
1. Instanciez la classe [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) en faisant référence à la collection Masters exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l’objet [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) et transmettez le maître du PPTX source à cloner en paramètre de la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Instanciez la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) en définissant la référence à la collection Slides exposée par l’objet [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) de la présentation de destination.
1. Appelez la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) exposée par l’objet [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) et transmettez la diapositive source à cloner ainsi que la diapositive maîtresse en paramètres de la méthode [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. Enregistrez le fichier de présentation de destination modifié.

Dans l’exemple ci‑dessus, nous avons cloné une diapositive avec maître (située à l’indice zéro de la présentation source) à la fin de la présentation de destination en utilisant le maître de la diapositive source.
```javascript
// Instancie la classe Presentation pour charger le fichier de présentation source
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // Instancie la classe Presentation pour la présentation de destination (où la diapositive doit être clonée)
    var destPres = new aspose.slides.Presentation();
    try {
        // Instancie ISlide à partir de la collection de diapositives de la présentation source ainsi que
        // la diapositive maître
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
        // présentation de destination
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // Clone la diapositive maître souhaitée de la présentation source vers la collection de maîtres dans la
        // présentation de destination
        var iSlide = masters.addClone(SourceMaster);
        // Clone la diapositive souhaitée de la présentation source avec le maître souhaité à la fin de la
        // collection de diapositives dans la présentation de destination
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // Enregistre la présentation de destination sur le disque
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **Cloner à la fin dans une section spécifiée**
Si vous souhaitez cloner une diapositive puis l’utiliser dans le même fichier de présentation mais dans une section différente, utilisez la méthode [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) exposée par la classe [**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java permet de cloner une diapositive de la première section puis d’insérer cette diapositive clonée dans la deuxième section de la même présentation.

Le fragment de code suivant montre comment cloner une diapositive et insérer la diapositive clonée dans une section spécifiée.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // Enregistre la présentation de destination sur le disque
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**Les notes du présentateur et les commentaires des réviseurs sont‑ils clonés ?**

Oui. La page des notes et les commentaires de révision sont inclus dans le clone. Si vous ne les voulez pas, [supprimez‑les](/slides/fr/nodejs-java/presentation-notes/) après l’insertion.

**Comment les graphiques et leurs sources de données sont‑ils gérés ?**

L’objet graphique, son formatage et les données intégrées sont copiés. Si le graphique était lié à une source externe (par ex., un classeur OLE intégré), ce lien est conservé comme un [objet OLE](/slides/fr/nodejs-java/manage-ole/). Après le déplacement entre fichiers, vérifiez la disponibilité des données et le comportement de rafraîchissement.

**Puis‑je contrôler la position d’insertion et les sections du clone ?**

Oui. Vous pouvez insérer le clone à un indice de diapositive spécifique et le placer dans une [section](/slides/fr/nodejs-java/slide-section/) choisie. Si la section cible n’existe pas, créez‑la d’abord puis déplacez la diapositive dedans.