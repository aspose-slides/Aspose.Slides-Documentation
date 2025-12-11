---
title: "Fusionner efficacement les présentations sur Android"
linktitle: "Fusionner des présentations"
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
  - "fusionner PowerPoint"
  - "fusionner présentations"
  - "fusionner diapositives"
  - "fusionner PPT"
  - "fusionner PPTX"
  - "fusionner ODP"
  - "combiner PowerPoint"
  - "combiner présentations"
  - "combiner diapositives"
  - "combiner PPT"
  - "combiner PPTX"
  - "combiner ODP"
  - Android
  - Java
  - Aspose.Slides
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Android via Java, simplifiant votre flux de travail."
---

{{% alert  title="Tip" color="primary" %}} 

Vous pourriez vouloir consulter l'application **Aspose gratuit en ligne** [Merger app](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT en PPT, PPTX en PPTX, etc.) et de fusionner des présentations dans différents formats (PPT en PPTX, PPTX en ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation afin d’obtenir un fichier. 

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), cependant, vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, formatage, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données.

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT en PPT, PPTX en PPTX, etc.) et dans différents formats (PPT en PPTX, PPTX en ODP, etc.) entre elles. 

{{% alert title="Note" color="warning" %}} 

Outre les présentations, Aspose.Slides vous permet de fusionner d’autres fichiers :

* [Images](https://products.aspose.com/slides/androidjava/merger/image-to-image/), telles que [JPG en JPG](https://products.aspose.com/slides/androidjava/merger/jpg-to-jpg/) ou [PNG en PNG](https://products.aspose.com/slides/androidjava/merger/png-to-png/)
* Documents, tels que [PDF en PDF](https://products.aspose.com/slides/androidjava/merger/pdf-to-pdf/) ou [HTML en HTML](https://products.aspose.com/slides/androidjava/merger/html-to-html/)
* Et deux fichiers différents tels que [image en PDF](https://products.aspose.com/slides/androidjava/merger/image-to-pdf/), ou [JPG en PDF](https://products.aspose.com/slides/androidjava/merger/jpg-to-pdf/) ou [TIFF en PDF](https://products.aspose.com/slides/androidjava/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation résultante conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation résultante. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de l’interface [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--), vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner des diapositives.

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives d’une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple appliquer des styles, des options de formatage ou des dispositions) sans craindre que les présentations sources soient affectées. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui permet de combiner des diapositives tout en conservant leurs dispositions et styles (paramètres par défaut).

Ce code Java vous montre comment fusionner des présentations :
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Fusionner des présentations avec un masque de diapositives**

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui permet de combiner des diapositives tout en appliquant un modèle de masque de diapositives. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives de la présentation de sortie.

Ce code en Java illustre l'opération décrite :
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

La disposition de diapositive pour le masque est déterminée automatiquement. Lorsqu’une disposition appropriée ne peut être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est réglé sur true, la disposition de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une disposition différente, utilisez plutôt la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lors de la fusion.

## **Fusionner des diapositives spécifiques à partir de présentations**

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des ensembles de diapositives personnalisés. Aspose.Slides for Android via Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la disposition et le design des diapositives originales.

Le code Java suivant crée une nouvelle présentation, ajoute les diapositives de titre de deux autres présentations, et enregistre le résultat dans un fichier :
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```


## **Fusionner des présentations avec une mise en page de diapositive**

Ce code Java vous montre comment combiner des diapositives provenant de présentations tout en appliquant votre mise en page de diapositive préférée afin d’obtenir une seule présentation de sortie :
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Note" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner deux présentations dont les tailles de diapositive diffèrent, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation. 

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


## **Fusionner des diapositives dans une section de présentation**

Ce code Java vous montre comment fusionner une diapositive spécifique dans une section d’une présentation :
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```


La diapositive est ajoutée à la fin de la section. 

{{% alert title="Tip" color="primary" %}}

Aspose propose une [FREE Collage web app](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

**Existe-t-il des limitations sur le nombre de diapositives lors de la fusion de présentations ?**

Aucune limitation stricte. Aspose.Slides peut gérer de gros fichiers, mais les performances dépendent de la taille et des ressources système. Pour des présentations très volumineuses, il est recommandé d’utiliser une JVM 64 bits et d’allouer suffisamment de mémoire heap.

**Puis-je fusionner des présentations contenant des vidéos ou audios intégrés ?**

Oui, Aspose.Slides préserve le contenu multimédia intégré aux diapositives, bien que la présentation finale puisse devenir nettement plus volumineuse.

**Les polices seront-elles conservées lors de la fusion des présentations ?**

Oui. Les polices utilisées dans les présentations sources sont conservées dans le fichier de sortie, à condition qu’elles soient installées sur le système ou [embedded](/slides/fr/androidjava/embedded-font/).