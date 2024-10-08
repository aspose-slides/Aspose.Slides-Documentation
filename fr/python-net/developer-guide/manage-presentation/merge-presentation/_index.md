---
title: Fusionner une présentation
type: docs
weight: 40
url: /fr/python-net/merge-presentation/
keywords: "Fusionner PowerPoint, PPTX, PPT, combiner PowerPoint, fusionner présentation, combiner présentation, Python"
description: "Fusionner ou combiner des présentations PowerPoint en Python"
---

{{% alert  title="Conseil" color="primary" %}} 

Vous voudrez peut-être consulter l'application **Aspose gratuite en ligne** [Merger](https://products.aspose.app/slides/merger). Elle permet aux utilisateurs de fusionner des présentations PowerPoint dans le même format (PPT à PPT, PPTX à PPTX, etc.) et de fusionner des présentations dans différents formats (PPT à PPTX, PPTX à ODP, etc.).

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Fusionner des présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation pour obtenir un fichier.

{{% alert title="Info" color="info" %}}

La plupart des programmes de présentation (PowerPoint ou OpenOffice) manquent de fonctions permettant aux utilisateurs de combiner des présentations de cette manière. 

[**Aspose.Slides pour Python via .NET**](https://products.aspose.com/slides/python-net/), cependant, vous permet de fusionner des présentations de différentes manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, mises en forme, commentaires, animations, etc. sans vous soucier de la perte de qualité ou de données. 

**Voir aussi**

[Cloner des diapositives](https://docs.aspose.com/slides/python-net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner 

* des présentations entières. Toutes les diapositives des présentations se retrouvent dans une seule présentation
* des diapositives spécifiques. Les diapositives sélectionnées se retrouvent dans une seule présentation
* des présentations dans un même format (PPT à PPT, PPTX à PPTX, etc.) et dans des formats différents (PPT à PPTX, PPTX à ODP, etc.) entre elles. 

{{% alert title="Remarque" color="warning" %}} 

En plus des présentations, Aspose.Slides vous permet de fusionner d'autres fichiers :

* [Images](https://products.aspose.com/slides/python-net/merger/image-to-image/), telles que [JPG à JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) ou [PNG à PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/)
* Documents, tels que [PDF à PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) ou [HTML à HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/)
* Et deux fichiers différents tels que [image à PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/) ou [JPG à PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/) ou [TIFF à PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez appliquer des options qui déterminent si

* chaque diapositive dans la présentation de sortie conserve un style unique
* un style spécifique est utilisé pour toutes les diapositives dans la présentation de sortie. 

Pour fusionner des présentations, Aspose.Slides fournit des méthodes [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) (de l'interface [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/)). Il existe plusieurs implémentations des méthodes `add_clone` qui définissent les paramètres du processus de fusion des présentations. Chaque objet Présentation a une collection [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), vous pouvez donc appeler une méthode `add_clone` à partir de la présentation avec laquelle vous souhaitez fusionner des diapositives. 

La méthode `add_clone` retourne un objet `ISlide`, qui est un clone de la diapositive source. Les diapositives dans une présentation de sortie sont simplement une copie des diapositives de la source. Par conséquent, vous pouvez apporter des modifications aux diapositives résultantes (par exemple, appliquer des styles, des options de mise en forme ou des mises en page) sans vous soucier de l'impact sur les présentations sources. 

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [**AddClone (ISlide)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) qui vous permet de combiner des diapositives tout en conservant leurs mises en page et styles (paramètres par défaut). 

Ce code Python vous montre comment fusionner des présentations :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Fusionner des présentations avec modèle de diapositive**

Aspose.Slides fournit la méthode [**add_clone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) qui vous permet de combiner des diapositives tout en appliquant un modèle de présentation de diapositive maître. De cette manière, si nécessaire, vous pouvez changer le style des diapositives dans la présentation de sortie. 

Ce code en Python démontre l'opération décrite :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.masters[0], allow_clone_missing_layout = True)
        pres1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Remarque" color="warning" %}} 

La mise en page de la diapositive pour le modèle de diapositive maître est déterminée automatiquement. Lorsqu'une mise en page appropriée ne peut pas être déterminée, si le paramètre boolean `allowCloneMissingLayout` de la méthode `add_clone` est défini sur true, la mise en page de la diapositive source est utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) sera levée. 

{{% /alert %}}

Si vous souhaitez que les diapositives dans la présentation de sortie aient une mise en page de diapositive différente, utilisez la méthode [add_clone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/) à la place lors de la fusion. 

## **Fusionner des diapositives spécifiques à partir de présentations**

Ce code Python vous montre comment sélectionner et combiner des diapositives spécifiques à partir de différentes présentations pour obtenir une présentation de sortie :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionner des présentations avec mise en page de diapositive**

Ce code Python vous montre comment combiner des diapositives de présentations tout en appliquant votre mise en page de diapositive préférée pour obtenir une présentation de sortie :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.layout_slides[0])
        pres1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Remarque" color="warning" %}} 

Vous ne pouvez pas fusionner des présentations avec des tailles de diapositive différentes. 

{{% /alert %}}

Pour fusionner 2 présentations avec des tailles de diapositive différentes, vous devez redimensionner l'une des présentations pour que sa taille corresponde à celle de l'autre présentation. 

Ce code d'exemple illustre l'opération décrite :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        pres2.slide_size.set_size(pres1.slide_size.size.width, pres1.slide_size.size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in pres2.slides:
            pres1.slides.add_clone(slide)
        pres1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionner des diapositives dans une section de présentation**

Ce code Python vous montre comment fusionner une diapositive spécifique dans une section d'une présentation :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres1:
    with slides.Presentation("Presentation1.pptx") as pres2:
        for slide in pres2.slides:
            pres1.slides.add_clone(slide, pres1.sections[0])
        pres1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

La diapositive est ajoutée à la fin de la section. 

{{% alert title="Conseil" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG à JPG](https://products.aspose.app/slides/collage/jpg) ou PNG à PNG, créer des [grilles photo](https://products.aspose.app/slides/collage/photo-grid), et ainsi de suite. 

{{% /alert %}}