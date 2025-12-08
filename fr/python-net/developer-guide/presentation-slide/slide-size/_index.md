---
title: Modifier la taille des diapositives dans les présentations avec Python
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/python-net/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de diapositive
- changer la taille de diapositive
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
descriptions: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Python et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perdre de qualité."
---

## Tailles de diapositive dans les présentations PowerPoint

Aspose.Slides for Python via .NET vous permet de modifier la taille ou le rapport d’aspect des diapositives dans les présentations PowerPoint. Si vous prévoyez d’imprimer votre présentation ou d’afficher ses diapositives sur un écran, vous devez faire attention à la taille ou au rapport d’aspect des diapositives. 

Voici les tailles de diapositives et rapports d’aspect les plus courants :

- **Standard (rapport d’aspect 4:3)**

  Si votre présentation doit être affichée ou visualisée sur des appareils ou écrans relativement anciens, vous voudrez peut-être utiliser ce réglage. 

- **Écran large (rapport d’aspect 16:9)** 

  Si votre présentation doit être affichée sur des projecteurs ou écrans modernes, vous voudrez peut-être utiliser ce réglage. 

Vous ne pouvez pas utiliser plusieurs réglages de taille de diapositive dans une même présentation. Lorsque vous choisissez une taille de diapositive pour une présentation, ce réglage s’applique à toutes les diapositives de la présentation. 

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire tôt. Idéalement, vous devriez spécifier votre taille de diapositive préférée dès le départ, c’est‑à‑dire lors de la configuration initiale de la présentation—avant d’ajouter tout contenu. Ainsi, vous éviterez les complications résultant des modifications (à venir) de la taille des diapositives. 

{{% alert color="primary" %}} 
Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d’aspect 4:3.
{{% /alert %}} 

## Modifier la taille des diapositives dans les présentations 

Ce code d’exemple montre comment modifier la taille d’une diapositive dans une présentation en Python à l’aide d’Aspose.Slides:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```


## Spécifier des tailles de diapositive personnalisées dans les présentations

Si vous jugez que les tailles de diapositive courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez choisir d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d’imprimer des diapositives en plein format de votre présentation sur une mise en page de page personnalisée ou si vous avez l’intention d’afficher votre présentation sur certains types d’écrans, il est probable que vous bénéficiiez d’un réglage de taille personnalisée pour votre présentation. 

Ce code d’exemple montre comment utiliser Aspose.Slides pour Python via .NET afin de spécifier une taille de diapositive personnalisée pour une présentation en Python:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```


## Gérer les problèmes lors du changement de la taille des diapositives dans les présentations

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’ajuster à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un réglage qui détermine la façon dont Aspose.Slides gère le contenu des diapositives. 

En fonction de ce que vous souhaitez faire ou atteindre, vous pouvez utiliser l’un de ces réglages :

- `DO_NOT_SCALE`

  Si vous NE voulez PAS que les objets des diapositives soient redimensionnés, utilisez ce réglage.

- `ENSURE_FIT`

  Si vous désirez réduire à une taille de diapositive plus petite et que vous avez besoin qu’Aspose.Slides rétrécisse les objets des diapositives pour garantir qu’ils tiennent tous sur les diapositives (ainsi, vous évitez la perte de contenu), utilisez ce réglage. 

- `MAXIMIZE`

  Si vous désirez agrandir à une taille de diapositive plus grande et que vous avez besoin qu’Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels à la nouvelle taille, utilisez ce réglage. 

Ce code d’exemple montre comment utiliser le réglage `MAXIMIZE` lors du changement de la taille d’une diapositive de présentation:
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```


## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, les points ou les millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point équivaut à 1/72 pouce. Vous pouvez convertir n’importe quelle unité (comme les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une très grande taille de diapositive personnalisée affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus importantes (en points) combinées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des présentations](/slides/fr/python-net/merge-presentation/) tant qu’elles ont des tailles de diapositive différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en conservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) ainsi que pour [les formes sélectionnées](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/). Les images résultantes reflètent la taille et le rapport d’aspect actuels de la diapositive, garantissant un cadrage et une géométrie cohérents.