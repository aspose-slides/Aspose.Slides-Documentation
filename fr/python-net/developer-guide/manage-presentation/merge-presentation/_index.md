---
title: Fusionner efficacement des présentations avec Python
linktitle: Fusionner des présentations
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
description: "Fusionnez sans effort les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) avec Aspose.Slides pour Python via .NET, en simplifiant votre flux de travail."
---

## **Optimisez la fusion de vos présentations**

Avec [Aspose.Slides pour Python](https://products.aspose.com/slides/python-net/), vous pouvez fusionner sans effort les présentations PowerPoint tout en préservant les styles, les mises en page et tous les éléments. Contrairement à d’autres outils, Aspose.Slides fusionne les présentations sans compromettre la qualité ni perdre de données. Fusionnez des présentations entières, des diapositives spécifiques ou même différents formats de fichiers (par ex., PPT en PPTX).

### **Fonctionnalités de fusion**

- **Fusion de présentation complète :** Assemblez toutes les diapositives dans un seul fichier.  
- **Fusion de diapositives spécifiques :** Sélectionnez et combinez les diapositives choisies.  
- **Fusion interformat :** Intégrez des présentations de différents formats tout en maintenant l’intégrité.  

## **Fusion de présentations**

Lorsque vous fusionnez une présentation dans une autre, vous combinez effectivement leurs diapositives en une seule présentation pour obtenir un fichier unique. La plupart des programmes de présentation — comme PowerPoint ou OpenOffice — ne proposent pas de fonctions permettant de fusionner les présentations de cette manière.

Cependant, [Aspose.Slides pour Python](https://products.aspose.com/slides/python-net/) vous permet de fusionner les présentations de plusieurs manières. Vous pouvez fusionner les présentations avec toutes leurs formes, styles, texte, mise en forme, commentaires et animations, sans aucune perte de qualité ou de données.

**Voir aussi**

[Cloner des diapositives PowerPoint en Python](/slides/fr/python-net/clone-slides/)

### **Ce qui peut être fusionné**

Avec Aspose.Slides, vous pouvez fusionner :

- Présentations entières : toutes les diapositives des jeux de source sont combinées en une seule présentation.  
- Diapositives spécifiques : seules les diapositives sélectionnées sont combinées en une seule présentation.  
- Présentations du même format (par ex., PPT→PPT, PPTX→PPTX) ou de formats différents (par ex., PPT→PPTX, PPTX→ODP).  

### **Options de fusion**

Vous pouvez contrôler si :

- chaque diapositive de la présentation de sortie conserve son style original, ou  
- un style unique est appliqué à toutes les diapositives de la présentation de sortie.

Pour fusionner des présentations, Aspose.Slides propose les méthodes [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) sur la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) . Ces surcharges de méthode définissent la manière dont la fusion est effectuée. Chaque objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) expose une collection [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) , ainsi vous appelez `add_clone` sur la collection de diapositives de la présentation de destination.

La méthode `add_clone` renvoie un `Slide` — un clone de la diapositive source. Les diapositives de la présentation de sortie sont des copies des originales, vous pouvez ainsi modifier les diapositives résultantes (par exemple, appliquer des styles, de la mise en forme ou des mises en page) sans affecter les présentations sources.

## **Fusionner des présentations** 

Aspose.Slides fournit la méthode [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide) qui permet de combiner les diapositives tout en préservant leurs mises en page et styles (en utilisant les paramètres par défaut).

L'exemple Python suivant montre comment fusionner des présentations :
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide)
        presentation1.save("combined.pptx", slides.export.SaveFormat.PPTX)
```


## **Fusionner des présentations avec un maître de diapositive**

Aspose.Slides fournit la méthode [add_clone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesimasterslide-bool) qui permet de fusionner les diapositives tout en appliquant un maître de diapositive provenant d’un modèle. Ainsi, si besoin, vous pouvez re‑styler les diapositives de la présentation de sortie.

L'exemple Python suivant illustre cette opération :
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.masters[0], True)
        presentation1.save("combined_with_master.pptx", slides.export.SaveFormat.PPTX) 
```


{{% alert title="Note" color="warning" %}}
La mise en page appropriée sous le maître de diapositive spécifié est déterminée automatiquement. Si aucune mise en page appropriée n’est trouvée et que le paramètre booléen `allow_clone_missing_layout` de la méthode `add_clone` est défini sur `True`, la mise en page de la diapositive source est utilisée à la place. Sinon, une [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/) est levée.
{{% /alert %}}

Pour appliquer une mise en page différente aux diapositives de la présentation de sortie, utilisez la méthode [add_clone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/#asposeslidesislide-asposeslidesilayoutslide) lors de la fusion.

## **Fusionner des diapositives spécifiques à partir de présentations**

La fusion de diapositives spécifiques provenant de plusieurs présentations est utile lors de la création de jeux de diapositives personnalisés. Aspose.Slides vous permet de sélectionner et d’importer uniquement les diapositives dont vous avez besoin, tout en préservant le formatage, la mise en page et le design d’origine.

L'exemple Python suivant crée une nouvelle présentation, ajoute des diapositives titre à partir de deux autres présentations, et enregistre le résultat dans un fichier :
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

L'exemple Python suivant montre comment fusionner des diapositives provenant de plusieurs présentations tout en appliquant une mise en page de diapositive spécifique pour produire une seule présentation de sortie :
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.layout_slides[0])
        presentation1.save("combined_with_layout.pptx", slides.export.SaveFormat.PPTX) 
```


## **Fusionner des présentations avec des tailles de diapositive différentes**

{{% alert title="Note" color="warning" %}}
Vous ne pouvez pas fusionner directement des présentations dont les tailles de diapositive sont différentes.
{{% /alert %}}

Pour fusionner deux présentations avec des tailles de diapositive différentes, redimensionnez d’abord une présentation afin que sa taille de diapositive corresponde à celle de l’autre.

Le code d'exemple suivant illustre ce processus :
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

L'exemple Python suivant montre comment fusionner une diapositive spécifique dans une section d’une présentation :
```py
import aspose.slides as slides

with slides.Presentation("presentation1.pptx") as presentation1:
    with slides.Presentation("presentation2.pptx") as presentation2:
        for slide in presentation2.slides:
            presentation1.slides.add_clone(slide, presentation1.sections[0])
        presentation1.save("combined_sections.pptx", slides.export.SaveFormat.PPTX) 
```


La diapositive est ajoutée à la fin de la section. 

{{% alert title="Tip" color="primary" %}}
Vous cherchez un outil en ligne **gratuit** et rapide pour **fusionner des présentations PowerPoint** ? Essayez le [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/merger).

- **Fusionnez facilement des fichiers PowerPoint** : combinez plusieurs présentations **PPT, PPTX, ODP** en un seul fichier.  
- **Prend en charge différents formats** : fusionnez **PPT en PPTX**, **PPTX en ODP**, et plus encore.  
- **Aucune installation requise** : fonctionne directement dans votre navigateur, rapide et sécurisé.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/merger)  

Commencez dès aujourd’hui à fusionner vos fichiers PowerPoint avec **l'outil en ligne gratuit d'Aspose** !
{{% /alert %}}

{{% alert title="Tip" color="primary" %}}
Aspose propose une [application Web COLLAGE GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc.
{{% /alert %}}

## **FAQ**

**Les notes du présentateur sont-elles conservées lors de la fusion ?**  
Oui. Lors du clonage des diapositives, Aspose.Slides transfère tous les éléments de la diapositive, y compris les notes, le formatage et les animations.

**Les commentaires et leurs auteurs sont-ils transférés ?**  
Les commentaires, faisant partie du contenu de la diapositive, sont copiés avec la diapositive. Les étiquettes d’auteur des commentaires sont conservées sous forme d’objets de commentaire dans la présentation résultante.

**Que se passe-t-il si la présentation source est protégée par mot de passe ?**  
Elle doit être [ouverte avec le mot de passe](/slides/fr/python-net/password-protected-presentation/) via [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/). Après le chargement, ces diapositives peuvent être clonées en toute sécurité dans un fichier cible non protégé (ou également protégé).

**Quelle est la sécurité de la fusion vis-à-vis du multithreading ?**  
Ne pas utiliser la même instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) depuis [plusieurs threads](/slides/fr/python-net/multithreading/). La règle recommandée est « un document — un fil » ; différents fichiers peuvent être traités en parallèle dans des threads séparés.