---
title: Fusionner efficacement des présentations sur Android
linktitle: Fusionner des présentations
type: docs
weight: 40
url: /fr/androidjava/merge-presentation/
keywords:
- fusionner PowerPoint
- fusionner des présentations
- fusionner des diapositives
- fusionner PPT
- fusionner PPTX
- fusionner ODP
- combiner PowerPoint
- combiner des présentations
- combiner des diapositives
- combiner PPT
- combiner PPTX
- combiner ODP
- Android
- Java
- Aspose.Slides
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Android via Java, simplifiant votre flux de travail."
---
## **Vue d'ensemble**

Fusionner des présentations PowerPoint et OpenDocument est une tâche courante dans de nombreuses applications Android, notamment lors de la génération de rapports, de la compilation de diapositives provenant de sources différentes ou de l'automatisation des flux de travail de présentation. Aspose.Slides fournit une API puissante et facile à utiliser pour combiner plusieurs fichiers PPT, PPTX ou ODP en une seule présentation sans installer Microsoft PowerPoint, LibreOffice ou OpenOffice.

Dans ce guide, vous apprendrez comment fusionner des présentations PowerPoint et OpenDocument en quelques lignes de code seulement. Nous fournirons des exemples prêts à l’emploi et montrerons comment préserver le format des diapositives, les mises en page et les autres éléments de la présentation pendant le processus de fusion.

Que vous construisiez une application d’entreprise ou un simple outil d’automatisation, Aspose.Slides rend la fusion de présentations rapide, fiable et évolutive. Aspose.Slides permet de fusionner des présentations de différentes manières. Vous pouvez combiner des présentations avec toutes leurs formes, styles, textes, formats, commentaires, animations, etc., sans vous soucier de la perte de qualité ou de données.

{{% alert color="info" %}}
Voir aussi : [Cloner les diapositives](https://docs.aspose.com/slides/fr/androidjava/clone-slides/)
{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* toutes les présentations. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT vers PPT, PPTX vers PPTX, etc.) et dans des formats différents (PPT vers PPTX, PPTX vers ODP, etc.) les unes avec les autres. 

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive de la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives de la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit les méthodes [AddClone](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (de l’interface [ISlideCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection)). Il existe plusieurs implémentations des méthodes `AddClone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Presentation possède une collection [Slides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/Presentation#getSlides--) ; vous pouvez donc appeler une méthode `AddClone` depuis la présentation dans laquelle vous souhaitez fusionner les diapositives.

La méthode `AddClone` renvoie un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives d’une présentation de sortie sont simplement une copie des diapositives de la source. Ainsi, vous pouvez modifier les diapositives résultantes (par exemple appliquer des styles, des options de formatage ou des mises en page) sans craindre d’affecter les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone(ISlide)**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) qui permet de combiner des diapositives tout en conservant leurs mises en page et leurs styles (paramètres par défaut).

Ce code Java vous montre comment fusionner des présentations :

```java
import com.aspose.slides.*;

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

Aspose.Slides fournit la méthode [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) qui permet de combiner des diapositives tout en appliquant un modèle de masque de diapositive. Ainsi, si nécessaire, vous pouvez modifier le style des diapositives dans la présentation de sortie.

Ce code Java illustre l’opération décrite :

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
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
La mise en page de la diapositive du masque est déterminée automatiquement. Lorsqu’une mise en page appropriée ne peut pas être déterminée, si le paramètre booléen `allowCloneMissingLayout` de la méthode `AddClone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, l’exception [PptxEditException](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/PptxEditException) sera levée.
{{% /alert %}}

Si vous souhaitez que les diapositives de la présentation de sortie aient une mise en page différente, utilisez la méthode [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) lors de la fusion.

## **Fusionner des diapositives spécifiques à partir de présentations** 

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile pour créer des ensembles de diapositives personnalisés. Aspose.Slides pour Android via Java vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin. L’API préserve le formatage, la mise en page et le design des diapositives d’origine.

Le code Java suivant crée une nouvelle présentation, ajoute des diapositives de titre provenant de deux autres présentations et enregistre le résultat dans un fichier :

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

Ce code Java vous montre comment combiner des diapositives de plusieurs présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie unique :

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
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
Il n’est pas possible de fusionner des présentations avec des tailles de diapositive différentes. 
{{% /alert %}}

Pour fusionner 2 présentations dont les tailles de diapositive diffèrent, vous devez redimensionner l’une des présentations afin que sa taille corresponde à celle de l’autre présentation. 

Ce code d’exemple illustre l’opération décrite :

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/fr/collage). Grâce à ce service en ligne, vous pouvez fusionner des [JPG en JPG](https://products.aspose.app/slides/fr/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/fr/collage/photo-grid), etc. 
{{% /alert %}}

## **FAQ**

### Existe-t-il des limitations quant au nombre de diapositives lors de la fusion de présentations ?

Pas de limitations strictes. Aspose.Slides peut gérer de gros fichiers, mais les performances dépendent de la taille du fichier et des ressources système. Pour des présentations très volumineuses, il est recommandé d’utiliser une JVM 64 bits et d’allouer suffisamment de mémoire heap.

### Puis‑je fusionner des présentations contenant des vidéos ou des audios intégrés ?

Oui, Aspose.Slides préserve le contenu multimédia intégré aux diapositives, mais la présentation finale peut devenir sensiblement plus lourde.

### Les polices seront‑elles conservées lors de la fusion de présentations ?

Oui. Les polices utilisées dans les présentations sources sont conservées dans le fichier de sortie, à condition qu’elles soient installées sur le système ou [embedded](/slides/fr/androidjava/embedded-font/).