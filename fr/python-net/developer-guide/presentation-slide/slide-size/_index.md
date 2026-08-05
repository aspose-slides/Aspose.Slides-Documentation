---
title: Modifier la taille des diapositives dans les présentations avec Python
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/python-net/slide-size/
keywords:
- taille de diapositive
- ratio d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de diapositive
- modifier la taille de diapositive
- taille de diapositive personnalisée
- taille de diapositive spéciale
- taille de diapositive unique
- diapositive pleine taille
- type d'écran
- ne pas mettre à l'échelle
- assurer l'ajustement
- maximiser
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Python et Aspose.Slides, optimisez les présentations pour tout écran sans perte de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le ratio d'aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l'impression que pour l'affichage à l'écran. 

Tailles de diapositives et ratios populaires :

- **Standard (ratio d'aspect 4:3)** : Idéal pour les écrans et appareils plus anciens.
- **Écran large (ratio d'aspect 16:9)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, car une seule taille de diapositive et un seul ratio d'aspect s'appliquent à toutes les diapositives. Pour des résultats optimaux, définissez les dimensions de vos diapositives dès le début du processus de création de la présentation afin d'éviter les complications.

{{% alert color="primary" %}} 
Par défaut, les présentations créées avec Aspose.Slides utilisent le ratio d'aspect standard 4:3.
{{% /alert %}}

## **Change the Slide Size in a Presentation**

Ce code d'exemple montre comment modifier la taille de la diapositive dans une présentation en Python avec Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specify Custom Slide Sizes**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives en taille réelle à partir de votre présentation sur une mise en page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, il est probable que vous bénéficiiez de l'utilisation d'un paramètre de taille personnalisée pour votre présentation. 

Ce code d'exemple montre comment utiliser Aspose.Slides pour Python via .NET afin de spécifier une taille de diapositive personnalisée pour une présentation en Python :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # format de papier A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Handle Slide Content After Resizing**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- `DO_NOT_SCALE`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `ENSURE_FIT`

  Si vous souhaitez réduire la taille de la diapositive et que vous avez besoin qu’Aspose.Slides ajuste les objets des diapositives pour qu’ils tiennent tous sur la diapositive (et ainsi éviter la perte de contenu), utilisez ce paramètre. 

- `MAXIMIZE`

  Si vous souhaitez augmenter la taille de la diapositive et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce paramètre. 

Ce code d'exemple montre comment utiliser le paramètre `MAXIMIZE` lors du changement de la taille de la diapositive d’une présentation :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l'utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/python-net/merge-presentation/) lorsqu'elles ont des tailles de diapositives différentes — commencez par redimensionner l'une des présentations pour correspondre à l'autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant la mise en forme.

**Puis-je générer des vignettes pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront‑elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des vignettes pour [entire slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/) ainsi que pour [selected shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_image/). Les images résultantes reflètent la taille et le ratio d'aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.