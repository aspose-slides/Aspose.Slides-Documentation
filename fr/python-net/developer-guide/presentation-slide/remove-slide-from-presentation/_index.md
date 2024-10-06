---
title: Supprimer une diapositive de la présentation
type: docs
weight: 30
url: /python-net/remove-slide-from-presentation/
keywords: "Supprimer diapositive, Effacer diapositive, PowerPoint, Présentation, Python, Aspose.Slides"
description: "Supprimer une diapositive de PowerPoint par référence ou index en Python"

---

Si une diapositive (ou son contenu) devient redondante, vous pouvez la supprimer. Aspose.Slides fournit la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui encapsule [ISlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/islidecollection/), qui est un référentiel pour toutes les diapositives d'une présentation. En utilisant des pointeurs (référence ou index) pour un objet [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), vous pouvez spécifier la diapositive que vous souhaitez supprimer.

## **Supprimer une diapositive par référence**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence de la diapositive que vous souhaitez supprimer par son ID ou Index.
1. Supprimez la diapositive référencée de la présentation.
1. Sauvegardez la présentation modifiée.

Ce code Python vous montre comment supprimer une diapositive par sa référence :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "RemoveSlideUsingReference.pptx") as pres:
    # Accède à une diapositive par son index dans la collection de diapositives
    slide = pres.slides[0]

    # Supprime une diapositive par sa référence
    pres.slides.remove(slide)

    # Sauvegarde la présentation modifiée
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer une diapositive par index**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Supprimez la diapositive de la présentation par sa position d'index.
1. Sauvegardez la présentation modifiée.

Ce code Python vous montre comment supprimer une diapositive par son index :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "RemoveSlideUsingIndex.pptx") as pres:
    # Supprime une diapositive par son index de diapositive
    pres.slides.remove_at(0)

    # Sauvegarde la présentation modifiée
    pres.save("modified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer une diapositive de mise en page inutilisée**

Aspose.Slides fournit la méthode `remove_unused_layout_slides(pres)` (de la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives de mise en page indésirables et inutilisées. Ce code Python vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer une diapositive maître inutilisée**

Aspose.Slides fournit la méthode `remove_unused_master_slides(pres)` (de la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)) pour vous permettre de supprimer des diapositives maîtres indésirables et inutilisées. Ce code Python vous montre comment supprimer une diapositive maître d'une présentation PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```