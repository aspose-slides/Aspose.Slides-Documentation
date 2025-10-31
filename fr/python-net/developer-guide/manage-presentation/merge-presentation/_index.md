---
title: "Fusionner efficacement les présentations avec Python"
linktitle: "Fusionner des présentations"
type: docs
weight: 40
url: /fr/python-net/merge-presentation/
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
- Python
- Aspose.Slides
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Python via .NET, simplifiant votre flux de travail."
---

## **Optimisez la fusion de vos présentations**

Avec [Aspose.Slides pour Python](https://products.aspose.com/slides/python-net/), vous pouvez combiner facilement des présentations PowerPoint tout en conservant les styles, mises en page et tous les éléments. Contrairement à d’autres outils, Aspose.Slides fusionne les présentations sans compromettre la qualité ni perdre de données. Fusionnez des présentations entières, des diapositives spécifiques, ou même des formats de fichiers différents (par ex. PPT vers PPTX).

### **Fonctionnalités de fusion**

- **Fusion complète de présentation :** Assemblez toutes les diapositives en un seul fichier.  
- **Fusion de diapositives spécifiques :** Sélectionnez et combinez les diapositives choisies.  
- **Fusion inter‑format :** Intégrez des présentations de formats différents tout en conservant leur intégrité.

## **Fusion de présentations**

Lorsque vous fusionnez une présentation avec une autre, vous combinez effectivement leurs diapositives dans une seule présentation afin de produire un unique fichier. La plupart des logiciels de présentation—tels que PowerPoint ou OpenOffice—ne proposent pas de fonctionnalités permettant cette fusion.

Cependant, [Aspose.Slides pour Python](https://products.aspose.com/slides/python-net/) vous permet de fusionner les présentations de plusieurs manières. Vous pouvez fusionner des présentations avec toutes leurs formes, styles, textes, formats, commentaires et animations, sans aucune perte de qualité ou de données.

**Voir aussi**

[Cloner des diapositives PowerPoint en Python](/slides/fr/python-net/clone-slides/)

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner :

- Des présentations entières : toutes les diapositives des présentations sources sont combinées en une seule.  
- Des diapositives spécifiques : seules les diapositives sélectionnées sont combinées en une seule présentation.  
- Des présentations du même format (par ex. PPT→PPT, PPTX→PPTX) ou de formats différents (par ex. PPT→PPTX, PPTX→ODP).

{{% alert title="Note" color="info" %}}

En plus des présentations, Aspose.Slides permet également de fusionner d’autres fichiers :

- [Images](https://products.aspose.com/slides/python-net/merger/image-to-image/), comme [JPG vers JPG](https://products.aspose.com/slides/python-net/merger/jpg-to-jpg/) ou [PNG vers PNG](https://products.aspose.com/slides/python-net/merger/png-to-png/).  
- Documents, comme [PDF vers PDF](https://products.aspose.com/slides/python-net/merger/pdf-to-pdf/) ou [HTML vers HTML](https://products.aspose.com/slides/python-net/merger/html-to-html/).  
- Deux types de fichiers différents, comme [image vers PDF](https://products.aspose.com/slides/python-net/merger/image-to-pdf/), [JPG vers PDF](https://products.aspose.com/slides/python-net/merger/jpg-to-pdf/), ou [TIFF vers PDF](https://products.aspose.com/slides/python-net/merger/tiff-to-pdf/).

{{% /alert %}}

### **Options de fusion**

Vous pouvez choisir :

- Que chaque diapositive de la présentation de sortie conserve son style original, ou  
- Qu’un style unique soit appliqué à toutes les diapositives de la présentation de sortie.

Pour fusionner des présentations, Aspose.Slides propose les méthodes [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) de la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/). Ces surcharges de méthode définissent comment la fusion est réalisée. Chaque objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expose une collection [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/), ainsi vous appelez `add_clone` sur la collection de diapositives de la présentation destination.

La méthode `add_clone` renvoie un `Slide` — un clone de la diapositive source. Les diapositives de la présentation de sortie sont des copies des originales, vous pouvez donc modifier les diapositives résultantes (par ex. appliquer des styles, du formatage ou des mises en page) sans affecter les présentations sources.

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) qui permet de combiner des diapositives tout en conservant leurs mises en page et styles (avec les paramètres par défaut).

L’exemple Python suivant montre comment fusionner des présentations :

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Fusionner des présentations avec un maître de diapositive**

Aspose.Slides fournit la méthode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) qui permet de fusionner des diapositives tout en appliquant un maître de diapositive depuis un modèle. Ainsi, si besoin, vous pouvez redéfinir le style des diapositives de la présentation de sortie.

L’exemple Python suivant illustre cette opération :

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```

{{% alert title="Avertissement" color="warning" %}}

La mise en page appropriée sous le maître de diapositive spécifié est déterminée automatiquement. Si aucune mise en page adaptée n’est trouvée et que le paramètre booléen `allow_clone_missing_layout` de la méthode `add_clone` est fixé à `True`, la mise en page de la diapositive source est alors utilisée. Sinon, une [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) est levée.

{{% /alert %}}

Pour appliquer une mise en page de diapositive différente aux diapositives de la présentation de sortie, utilisez la méthode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) lors de la fusion.

## **Fusionner des diapositives spécifiques depuis des présentations**

Fusionner des diapositives spécifiques provenant de plusieurs présentations est utile lors de la création de jeux de diapositives personnalisés. Aspose.Slides vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin, tout en conservant le formatage, la mise en page et le design des diapositives d’origine.

L’exemple Python suivant crée une nouvelle présentation, ajoute les diapositives titre de deux autres présentations, puis enregistre le résultat dans un fichier :

```py
def get_title_slide(pres):
    for slide in pres.slides:
        if slide.layout_slide.layout_type == slides.SlideLayoutType.TITLE:
            return slide
    return None


with slides.Presentation() as presentation, \
        slides.Presentation("presentation1.pptx") as presentation1, \
        slides.Presentation("presentation2.pptx") as presentation2:
    presentation.slides.remove_at(0)

    slide1 = get_title_slide(presentation1)
    if slide1 is not None:
        presentation.slides.add_clone(slide1)

    slide2 = get_title_slide(presentation2)
    if slide2 is not None:
        presentation.slides.add_clone(slide2)

    presentation.save("combined.pptx", slides.export.SaveFormat.PPTX)
```

## **Fusionner des présentations avec une mise en page de diapositive**

L’exemple Python suivant montre comment fusionner des diapositives provenant de plusieurs présentations tout en appliquant une mise en page de diapositive spécifique afin de produire une seule présentation de sortie :

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Avertissement" color="warning" %}}

Vous ne pouvez pas fusionner directement des présentations dont les tailles de diapositive sont différentes.

{{% /alert %}}

Pour fusionner deux présentations avec des tailles de diapositive différentes, redimensionnez d’abord une présentation afin que sa taille de diapositive corresponde à celle de l’autre.

Le code d’exemple suivant illustre ce processus :

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    slide_size = presentation1.slide_size.size
    with slides.Presentation("presentation2.pptx") as presentation2:
        presentation2.slide_size.set_size(slide_size.width, slide_size.height, slides.SlideSizeScaleType.ENSURE_FIT)
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined_size.pptx", slides.export.SaveFormat.PPTX) 
```

## **Fusionner des diapositives dans une section de présentation**

L’exemple Python suivant montre comment fusionner une diapositive spécifique dans une section d’une présentation :

```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```

La diapositive est ajoutée à la fin de la section. 

{{% alert title="Astuce" color="primary" %}}

Vous cherchez un outil **gratuit en ligne** pour **fusionner des présentations PowerPoint** ? Essayez le [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **Fusionnez facilement des fichiers PowerPoint** : combinez plusieurs présentations **PPT, PPTX, ODP** en un seul fichier.  
- **Prise en charge de différents formats** : fusionnez **PPT vers PPTX**, **PPTX vers ODP**, et plus encore.  
- **Aucune installation requise** : fonctionne directement dans votre navigateur, rapide et sécurisé.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Commencez à fusionner vos fichiers PowerPoint avec l’outil **gratuit en ligne d’Aspose** dès aujourd’hui !  

{{% /alert %}}

{{% alert title="Astuce" color="primary" %}}

Aspose propose une application web **GRATUITE** de collage : [Collage](https://products.aspose.app/slides/collage). Avec ce service en ligne, vous pouvez fusionner des [JPG vers JPG](https://products.aspose.app/slides/collage/jpg) ou PNG vers PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

{{% /alert %}}

## **FAQ**

**Les notes du présentateur sont‑elles conservées lors de la fusion ?**

Oui. Lors du clonage des diapositives, Aspose.Slides transfère tous les éléments de la diapositive, y compris les notes, le formatage et les animations.

**Les commentaires et leurs auteurs sont‑ils transférés ?**

Les commentaires, faisant partie du contenu de la diapositive, sont copiés avec la diapositive. Les libellés des auteurs de commentaires sont conservés en tant qu’objets commentaire dans la présentation résultante.

**Que se passe‑t‑il si la présentation source est protégée par un mot de passe ?**

Elle doit être [ouverte avec le mot de passe](/slides/fr/python-net/password-protected-presentation/) via [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/); après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

**Quelle est la sûreté du processus de fusion en environnement multithread ?**

N’utilisez pas la même instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-net/multithreading/). La règle recommandée est « un document — un thread » ; différents fichiers peuvent être traités en parallèle dans des threads séparés.