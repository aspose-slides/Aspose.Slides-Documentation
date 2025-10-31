---
title: Modifier la taille des diapositives dans les présentations avec Python
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/python-net/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- grand écran
- 4:3
- 16:9
- définir la taille de la diapositive
- changer la taille de la diapositive
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
descriptions: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Python et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perdre en qualité."
---

## Tailles de diapositives dans les présentations PowerPoint

Aspose.Slides for Python via .NET vous permet de modifier la taille de la diapositive ou le rapport d'aspect dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez faire attention à la taille ou au rapport d'aspect des diapositives.

Voici les tailles de diapositives et rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous pouvez choisir cette option.

- **Grand écran (rapport d'aspect 16:9)**

  Si votre présentation doit être vue sur des projecteurs ou écrans modernes, vous pouvez choisir cette option.

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une même présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce paramètre s'applique à toutes les diapositives de la présentation.

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier la taille de diapositive souhaitée dès le départ, c'est‑à‑dire lors de la création de la présentation—avant d'ajouter tout contenu. Ainsi, vous éviterez les complications dues aux modifications (future) de la taille des diapositives.

{{% alert color="primary" %}} 
Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d'aspect 4:3.
{{% /alert %}} 

## Modifier la taille de la diapositive dans les présentations 

Ce code d'exemple montre comment modifier la taille d'une diapositive dans une présentation en Python avec Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Spécifier des tailles de diapositive personnalisées dans les présentations

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives pleine taille de votre présentation sur une mise en page personnalisée ou si vous avez l'intention d'afficher votre présentation sur certains types d'écrans, il est probable que vous bénéficiiez d'un paramètre de taille personnalisée.

Ce code d'exemple montre comment utiliser Aspose.Slides for Python via .NET pour spécifier une taille de diapositive personnalisée pour une présentation en Python :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # taille du papier A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Gérer les problèmes lors du changement de taille des diapositives dans les présentations

Après avoir changé la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut se déformer. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille des diapositives. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine la façon dont Aspose.Slides gère le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l'un de ces paramètres :

- `DO_NOT_SCALE`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `ENSURE_FIT`

  Si vous voulez réduire la taille des diapositives et que vous avez besoin qu'Aspose.Slides réduise les objets des diapositives afin de garantir qu'ils tiennent tous sur les diapositives (ainsi, vous évitez de perdre du contenu), utilisez ce paramètre.

- `MAXIMIZE`

  Si vous voulez agrandir la taille des diapositives et que vous avez besoin qu'Aspose.Slides augmente les objets des diapositives pour qu'ils soient proportionnels à la nouvelle taille, utilisez ce paramètre.

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, des points ou des millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 de pouce. Vous pouvez convertir n'importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et la consommation de mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinées à une échelle de rendu plus élevée entraînent une augmentation de la consommation de mémoire et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/python-net/merge-presentation/) lorsqu'elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour correspondre à l'autre. En changeant la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant la mise en forme.

**Puis-je générer des miniatures pour des formes individuelles ou des zones spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut générer des miniatures pour [l’ensemble des diapositives](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ainsi que pour [des formes sélectionnées](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/). Les images résultantes reflètent la taille et le rapport d'aspect actuels de la diapositive, assurant un cadrage et une géométrie cohérents.