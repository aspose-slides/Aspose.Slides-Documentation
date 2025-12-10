---
title: Fusionner efficacement les présentations en Java
linktitle: Fusionner les présentations
type: docs
weight: 40
url: /fr/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Fusionnez facilement les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Java, simplifiant votre flux de travail."
---

## **Vue d'ensemble**

Fusionner des présentations PowerPoint et OpenDocument est une tâche courante dans de nombreuses applications Java, notamment lors de la génération de rapports, de la compilation de diapositives provenant de sources diverses ou de l’automatisation de flux de travail de présentation. Aspose.Slides pour Java fournit une API puissante et facile d’utilisation pour combiner plusieurs fichiers PPT, PPTX ou ODP en une seule présentation sans installer Microsoft PowerPoint, LibreOffice ou OpenOffice.

Dans ce guide, vous apprendrez à fusionner des présentations PowerPoint et OpenDocument en quelques lignes de code Java. Nous fournirons des exemples prêts à l’emploi et montrerons comment conserver le formatage des diapositives, les mises en page et les autres éléments de la présentation pendant le processus de fusion.

Que vous développiez une application d’entreprise ou un simple outil d’automatisation, Aspose.Slides rend la fusion de présentations en Java rapide, fiable et évolutive. Aspose.Slides pour Java vous permet de fusionner des présentations de différentes manières. Vous pouvez combiner des présentations avec toutes leurs formes, styles, texte, formatage, commentaires, animations, etc., sans vous soucier d’une perte de qualité ou de données.

{{% alert color="primary" %}}
Voir également : [Clone Slides](https://docs.aspose.com/slides/java/clone-slides/)
{{% /alert %}}

### **Qu’est‑ce qui peut être fusionné ?**

Avec Aspose.Slides, vous pouvez fusionner :

**Des présentations entières** – toutes les diapositives de plusieurs présentations sont combinées en une seule.

**Des diapositives spécifiques** – seules les diapositives sélectionnées sont fusionnées dans une présentation unique.

**Des présentations au même format** (par ex. PPT vers PPT, PPTX vers PPTX) et **dans des formats différents** (par ex. PPT vers PPTX, PPTX vers ODP).

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si :

- chaque diapositive de la présentation de sortie conserve son style d’origine
- un style spécifique est appliqué à toutes les diapositives de la présentation de sortie

Pour fusionner des présentations, Aspose.Slides fournit les méthodes `AddClone` de l’interface [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/). Il existe plusieurs surcharges de la méthode `AddClone` qui définissent le comportement du processus de fusion. Chaque objet [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) possède une collection Slides. Vous pouvez donc appeler une méthode `AddClone` sur la présentation cible dans laquelle vous souhaitez fusionner des diapositives.

La méthode `AddClone` renvoie un objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) qui est un clone de la diapositive source. Les diapositives résultantes dans la présentation de sortie sont simplement des copies des diapositives originales. Cela signifie que vous pouvez modifier en toute sécurité les diapositives clonées — par exemple en appliquant des styles, des options de formatage ou des mises en page—sans affecter la présentation source.

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [AddClone(ISlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) qui permet de combiner des diapositives tout en conservant leurs mises en page et styles d’origine (comportement par défaut).

Le code Java suivant montre comment fusionner des présentations :
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **Fusionner des présentations avec un maître de diapositive** 

Aspose.Slides fournit la méthode [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui permet de combiner des diapositives tout en appliquant un maître de diapositive provenant d’un modèle de présentation. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation de sortie.

Le code Java suivant illustre cette opération :
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


{{% alert title="Note" color="warning" %}}
La mise en page de la diapositive est déterminée automatiquement. Lorsqu’une mise en page appropriée ne peut être trouvée et que le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est à `true`, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

## **Fusionner des diapositives spécifiques provenant de présentations** 

Fusionner des diapositives spécifiques de plusieurs présentations est utile pour créer des jeux de diapositives personnalisés. Aspose.Slides pour Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la mise en page et le design des diapositives originales.

Le code Java suivant crée une nouvelle présentation, ajoute des diapositives titre provenant de deux autres présentations, puis enregistre le résultat dans un fichier :
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

Pour appliquer une mise en page de diapositive différente aux diapositives de sortie pendant la fusion, utilisez la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) à la place.

Le code Java suivant montre comment combiner des diapositives de plusieurs présentations tout en appliquant la mise en page de diapositive souhaitée, aboutissant à une seule présentation de sortie :
```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **Fusionner des présentations avec des tailles de diapositive différentes** 

Pour fusionner deux présentations ayant des tailles de diapositive différentes, vous devez redimensionner l’une d’elles afin qu’elle corresponde à la taille de diapositive de l’autre présentation.

Le code Java suivant illustre cette opération :
```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


## **Fusionner des diapositives dans une section de présentation** 

Fusionner des diapositives dans une section spécifique d’une présentation aide à organiser le contenu et à améliorer la navigation. Aspose.Slides permet de fusionner des diapositives dans des sections existantes. Cela assure une structure claire tout en préservant le formatage original de chaque diapositive.

Le code Java suivant montre comment fusionner une diapositive spécifique dans une section d’une présentation :
```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```


La diapositive est ajoutée à la fin de la section.

## **Voir aussi** 

Aspose propose un [outil gratuit en ligne de création de collages](https://products.aspose.app/slides/collage). Grâce à ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid) et plus encore.

Découvrez le [fusionneur gratuit en ligne d’Aspose](https://products.aspose.app/slides/merger). Il vous permet de fusionner des présentations PowerPoint dans le même format (par ex. PPT vers PPT, PPTX vers PPTX) ou entre différents formats (par ex. PPT vers PPTX, PPTX vers ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/merger)

Outre les présentations, Aspose.Slides vous permet de fusionner d’autres types de fichiers :

- [**Images**](https://products.aspose.com/slides/java/merger/image-to-image/), comme [JPG en JPG](https://products.aspose.com/slides/java/merger/jpg-to-jpg/) ou [PNG en PNG](https://products.aspose.com/slides/java/merger/png-to-png/)
- **Documents**, comme [PDF en PDF](https://products.aspose.com/slides/java/merger/pdf-to-pdf/) ou [HTML en HTML](https://products.aspose.com/slides/java/merger/html-to-html/)
- **Types de fichiers mixtes**, comme [image en PDF](https://products.aspose.com/slides/java/merger/image-to-pdf/), [JPG en PDF](https://products.aspose.com/slides/java/merger/jpg-to-pdf/) ou [TIFF en PDF](https://products.aspose.com/slides/java/merger/tiff-to-pdf/)

## **FAQ**

**Existe‑t‑il des limites quant au nombre de diapositives lors de la fusion de présentations ?**  
Aucune limite stricte. Aspose.Slides peut gérer de gros fichiers, mais les performances dépendent de la taille du fichier et des ressources système. Pour des présentations très volumineuses, il est recommandé d’utiliser une JVM 64 bits et d’allouer suffisamment de mémoire heap.

**Puis‑je fusionner des présentations contenant des vidéos ou des audios intégrés ?**  
Oui, Aspose.Slides préserve le contenu multimédia intégré aux diapositives, mais la présentation finale peut devenir sensiblement plus lourde.

**Les polices seront‑elles conservées lors de la fusion des présentations ?**  
Oui. Les polices utilisées dans les présentations sources sont conservées dans le fichier de sortie, à condition qu’elles soient installées sur le système ou [intégrées](/slides/fr/java/embedded-font/).