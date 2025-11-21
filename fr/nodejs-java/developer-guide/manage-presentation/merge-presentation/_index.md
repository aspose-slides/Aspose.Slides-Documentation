---
title: Fusion de présentation
type: docs
weight: 40
url: /fr/nodejs-java/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, Java"
description: "Fusionner ou combiner une présentation PowerPoint en JavaScript"
---

## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier unique. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides pour Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), cependant, vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mise en forme, commentaires, animations, etc. sans vous soucier de perte de qualité ou de données.

**Voir aussi**

[Cloner les diapositives](https://docs.aspose.com/slides/nodejs-java/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* toutes les présentations. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* présentations dans un même format (PPT vers PPT, PPTX vers PPTX, etc.) et dans des formats différents (PPT vers PPTX, PPTX vers ODP, etc.) les unes vers les autres. 

{{% alert title="Note" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/nodejs-java/merger/image-to-image/), telles que [JPG vers JPG](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-jpg/) ou [PNG vers PNG](https://products.aspose.com/slides/nodejs-java/merger/png-to-png/)
* Documents, tels que [PDF vers PDF](https://products.aspose.com/slides/nodejs-java/merger/pdf-to-pdf/) ou [HTML vers HTML](https://products.aspose.com/slides/nodejs-java/merger/html-to-html/)
* Et deux fichiers différents tels que [image vers PDF](https://products.aspose.com/slides/nodejs-java/merger/image-to-pdf/) ou [JPG vers PDF](https://products.aspose.com/slides/nodejs-java/merger/jpg-to-pdf/) ou [TIFF vers PDF](https://products.aspose.com/slides/nodejs-java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (de la classe [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection)). Il existe plusieurs implémentations des méthodes `addClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--), vous pouvez donc appeler une méthode `addClone` depuis la présentation dans laquelle vous souhaitez fusionner les diapositives.

La méthode `addClone` renvoie un objet `Slide`, qui est un clone de la diapositive source. Les diapositives d’une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple, appliquer des styles, des options de mise en forme ou des dispositions) sans vous soucier d’affecter les présentations sources.

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) qui vous permet de combiner des diapositives tout en conservant leurs dispositions et styles (paramètres par défaut).

Ce code JavaScript vous montre comment fusionner des présentations :
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionner des présentations avec le masque des diapositives**

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation maître. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation de sortie.

Ce code JavaScript démontre l’opération décrite :
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


{{% alert title="Note" color="warning" %}} 

La disposition de la diapositive pour le masque des diapositives est déterminée automatiquement. Lorsqu’une disposition appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `addClone` est défini sur true, la disposition de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une disposition différente, utilisez la méthode [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) à la place lors de la fusion.

## **Fusionner des diapositives spécifiques à partir de présentations**

Fusionner des diapositives spécifiques à partir de plusieurs présentations est utile pour créer des ensembles de diapositives personnalisés. Aspose.Slides pour Node.js via Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve la mise en forme, la disposition et le design des diapositives originales.

Le code JavaScript suivant crée une nouvelle présentation, ajoute des diapositives titre provenant de deux autres présentations, et enregistre le résultat dans un fichier :
```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```

```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```


## **Fusionner des présentations avec la disposition des diapositives**

Ce code JavaScript vous montre comment combiner des diapositives de présentations tout en appliquant votre disposition de diapositive préférée afin d’obtenir une seule présentation de sortie :
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionner des présentations avec des tailles de diapositives différentes**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositives différentes. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositives différentes, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation. 

Ce code d’exemple démontre l’opération décrite :
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


## **Fusionner des diapositives dans une section de présentation**

Ce code JavaScript vous montre comment fusionner une diapositive spécifique dans une section d’une présentation :
```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```


La diapositive est ajoutée à la fin de la section. 

## **FAQ**

**Les notes du présentateur sont-elles conservées lors de la fusion ?**

Oui. Lors de la duplication des diapositives, Aspose.Slides transfère tous les éléments de la diapositive, y compris les notes, la mise en forme et les animations.

**Les commentaires et leurs auteurs sont-ils transférés ?**

Les commentaires, en tant que partie du contenu de la diapositive, sont copiés avec la diapositive. Les étiquettes d’auteur des commentaires sont conservées en tant qu’objets commentaire dans la présentation résultante.

**Que se passe-t-il si la présentation source est protégée par un mot de passe ?**

Elle doit être [ouverte avec le mot de passe](/slides/fr/nodejs-java/password-protected-presentation/) via [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setpassword/); après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

**Quelle est la sécurité des threads de l’opération de fusion ?**

N’utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/nodejs-java/multithreading/). La règle recommandée est « un document — un fil » ; différents fichiers peuvent être traités en parallèle dans des fils séparés.

## **Voir aussi**

Aspose propose un [Créateur de collages EN LIGNE GRATUIT](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG vers JPG](https://products.aspose.app/slides/collage/jpg) ou PNG vers PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), et plus encore.

Découvrez le [Merger EN LIGNE GRATUIT Aspose](https://products.aspose.app/slides/merger). Il vous permet de fusionner des présentations PowerPoint dans le même format (par ex., PPT vers PPT, PPTX vers PPTX) ou entre différents formats (par ex., PPT vers PPTX, PPTX vers ODP).

[![Aspose MERGEUR EN LIGNE GRATUIT](slides-merger.png)](https://products.aspose.app/slides/merger)