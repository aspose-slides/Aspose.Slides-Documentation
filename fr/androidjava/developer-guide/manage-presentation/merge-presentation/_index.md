---
title: Fusion efficace des présentations sur Android
linktitle: Fusionner les présentations
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner présentations
- fusionner diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner présentations
- combiner diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Android
- Java
- Aspose.Slides
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Android via Java, simplifiant votre flux de travail."
---

{{% alert title="Astuce" color="primary" %}}

Vous pourriez vouloir découvrir l'**Aspose gratuit en ligne** [Merger app](https://products.aspose.app/slides/merger). Il permet de fusionner des présentations PowerPoint dans le même format (PPT en PPT, PPTX en PPTX, etc.) et de fusionner des présentations dans des formats différents (PPT en PPTX, PPTX en ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}}

## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation afin d’obtenir un fichier unique.

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) ne disposent pas de fonctions permettant aux utilisateurs de combiner des présentations de cette manière.

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/), cependant, vous permet de fusionner des présentations de différentes façons. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, formatages, commentaires, animations, etc., sans craindre de perdre de la qualité ou des données.

**Voir aussi**

[Clone Slides](https://docs.aspose.com/slides/androidjava/clone-slides/).

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner  

* des présentations complètes. Toutes les diapositives des présentations se retrouvent dans une seule présentation  
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation  
* des présentations dans un même format (PPT en PPT, PPTX en PPTX, etc.) et dans des formats différents (PPT en PPTX, PPTX en ODP, etc.) les unes avec les autres.  

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si  

* chaque diapositive de la présentation de sortie conserve un style unique  
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie.  

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (à partir de l’interface [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection)). Plusieurs implémentations des méthodes `AddClone` définissent les paramètres du processus de fusion. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ; vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez ajouter des diapositives.

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives d’origine. Vous pouvez donc modifier les diapositives résultantes (par exemple, appliquer des styles, des options de formatage ou des mises en page) sans que les présentations sources ne soient affectées.  

## **Fusionner des présentations**

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et leurs styles (paramètres par défaut).

Ce code Java montre comment fusionner des présentations :
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


## **Fusionner des présentations avec un masque de diapositive**

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation maître. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation de sortie.

Ce code Java illustre l’opération décrite :
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

La mise en page du maître de diapositive est déterminée automatiquement. Lorsqu’une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est réglé sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/PptxEditException) sera levée.

{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie utilisent une mise en page différente, utilisez la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lors de la fusion.

## **Fusionner des diapositives spécifiques provenant de présentations**

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des jeux de diapositives personnalisés. Aspose.Slides for Android via Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la mise en page et le design des diapositives d’origine.

Le code Java suivant crée une nouvelle présentation, ajoute des diapositives titre provenant de deux autres présentations et enregistre le résultat dans un fichier :
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

Ce code Java montre comment combiner des diapositives provenant de présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie unique :
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

{{% alert title="Remarque" color="warning" %}}

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes.

{{% /alert %}}

Pour fusionner deux présentations dont les tailles de diapositive diffèrent, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre.

Ce code d’exemple illustre l’opération décrite :
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

Ce code Java montre comment fusionner une diapositive spécifique dans une section d’une présentation :
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

Aspose propose une application web [GRATUITE Collage](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.

{{% /alert %}}

## **FAQ**

**Existe-t-il des limitations quant au nombre de diapositives lors de la fusion de présentations ?**

Aucune limitation stricte. Aspose.Slides peut gérer de gros fichiers, mais les performances dépendent de la taille du fichier et des ressources système. Pour des présentations très volumineuses, il est recommandé d’utiliser une JVM 64 bits et d’allouer suffisamment de mémoire heap.

**Puis-je fusionner des présentations contenant des vidéos ou des audios intégrés ?**

Oui, Aspose.Slides préserve le contenu multimédia intégré aux diapositives, mais la présentation finale peut devenir sensiblement plus grande.

**Les polices seront-elles conservées lors de la fusion de présentations ?**

Oui. Les polices utilisées dans les présentations sources sont conservées dans le fichier de sortie, à condition qu’elles soient installées sur le système ou [embedded](/slides/fr/androidjava/embedded-font/).