---
title: Fusionner une Présentation
type: docs
weight: 40
url: /java/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, Java"
description: "Fusionner ou combiner des présentations PowerPoint en Java"
---

{{% alert  title="Astuce" color="primary" %}} 

Vous voudrez peut-être jeter un œil à l'**application de fusion** [Aspose gratuite en ligne](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT à PPT, PPTX à PPTX, etc.) et de fusionner des présentations dans différents formats (PPT à PPTX, PPTX à ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusion des Présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives en une seule présentation pour obtenir un fichier.

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) manquent de fonctions permettant aux utilisateurs de combiner des présentations de cette manière.

[**Aspose.Slides pour Java**](https://products.aspose.com/slides/java/), cependant, vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mises en forme, commentaires, animations, etc. sans vous soucier de la perte de qualité ou de données.

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/java/clone-slides/). 

{{% /alert %}}

### **Ce Qui Peut Être Fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un format (PPT à PPT, PPTX à PPTX, etc.) et dans des formats différents (PPT à PPTX, PPTX à ODP, etc.) entre elles. 

{{% alert title="Remarque" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/java/merger/image-to-image/), telles que [JPG à JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) ou [PNG à PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
* Documents, tels que [PDF à PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) ou [HTML à HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
* Et deux fichiers différents comme [image à PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/) ou [JPG à PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) ou [TIFF à PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de Fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive dans la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives dans la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit des méthodes [AddClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de l'interface [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Présentation a une collection [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) afin que vous puissiez appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner les diapositives. 

La méthode `AddClone` retourne un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives de la présentation de sortie sont simplement une copie des diapositives de la source. Par conséquent, vous pouvez apporter des modifications aux diapositives résultantes (par exemple, appliquer des styles ou des options de mise en forme ou de disposition) sans vous soucier de l'impact sur les présentations sources. 

## **Fusionner des Présentations**

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut). 

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

## **Fusionner des Présentations avec le Maître de Diapositive**

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation de maître de diapositive. De cette façon, si nécessaire, vous pouvez changer le style des diapositives dans la présentation de sortie.

Ce code en Java démontre l'opération décrite :

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

{{% alert title="Remarque" color="warning" %}} 

La mise en page de la diapositive pour le maître de diapositive est déterminée automatiquement. Lorsqu'une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est réglé sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une mise en page différente, utilisez la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) à la place lors de la fusion. 

## **Fusionner des Diapositives Spécifiques de Présentations**

Ce code Java vous montre comment sélectionner et combiner des diapositives spécifiques à partir de différentes présentations pour obtenir une présentation de sortie :

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

## **Fusionner des Présentations Avec Mise en Page de Diapositive**

Ce code Java vous montre comment combiner des diapositives de présentations tout en appliquant votre mise en page préférée à celles-ci pour obtenir une seule présentation de sortie :

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

## **Fusionner des Présentations Avec Différentes Tailles de Diapositive**

{{% alert title="Remarque" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec différentes tailles de diapositive. 

{{% /alert %}}

Pour fusionner 2 présentations avec différentes tailles de diapositive, vous devez redimensionner l'une des présentations pour correspondre à la taille de l'autre présentation. 

Ce code d'exemple démontre l'opération décrite :

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

## **Fusionner des Diapositives à une Section de Présentation**

Ce code Java vous montre comment fusionner une diapositive spécifique à une section dans une présentation :

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

{{% alert title="Astuce" color="primary" %}}

Aspose fournit une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des [JPG à JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG à PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et plus encore.

{{% /alert %}}