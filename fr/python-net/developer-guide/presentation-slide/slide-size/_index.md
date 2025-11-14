---
title: Modifier la taille des diapositives dans les présentations avec Python
linktitle: Taille de diapositive
type: docs
weight: 70
url: /fr/python-net/slide-size/
keywords:
- taille de diapositive
- rapport d'image
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
descriptions: "Découvrez comment redimensionner rapidement les diapositives des fichiers PPT, PPTX et ODP avec Python et Aspose.Slides, et optimiser les présentations pour tout écran sans perte de qualité."
---

## Tailles de diapositives dans les présentations PowerPoint

Aspose.Slides pour Python via .NET vous permet de changer la taille de la diapositive ou le rapport d'aspect dans les présentations PowerPoint. Si vous prévoyez d'imprimer votre présentation ou d'afficher ses diapositives sur un écran, vous devez prêter attention à sa taille de diapositive ou à son rapport d'aspect.

Voici les tailles de diapositives et les rapports d'aspect les plus courants :

- **Standard (rapport d'aspect 4:3)**

  Si votre présentation doit être affichée ou vue sur des appareils ou écrans relativement anciens, vous pourriez vouloir utiliser ce paramètre.

- **Widescreen (rapport d'aspect 16:9)**

  Si votre présentation doit être vue sur des projecteurs ou affichages modernes, vous pourriez vouloir utiliser ce paramètre.

Vous ne pouvez pas utiliser plusieurs paramètres de taille de diapositive dans une seule présentation. Lorsque vous sélectionnez une taille de diapositive pour une présentation, ce paramètre de taille de diapositive s'applique à toutes les diapositives de la présentation.

Si vous préférez utiliser une taille de diapositive spéciale pour vos présentations, nous vous recommandons fortement de le faire dès le début. Idéalement, vous devriez spécifier votre taille de diapositive préférée au début, c'est-à-dire lorsque vous êtes en train de configurer la présentation—avant d'ajouter du contenu à la présentation. De cette façon, vous évitez les complications résultant des modifications (futures) apportées à la taille des diapositives.

{{% alert color="primary" %}}

 Lorsque vous utilisez Aspose.Slides pour créer une présentation, toutes les diapositives de la présentation obtiennent automatiquement la taille standard ou le rapport d'aspect 4:3.

{{% /alert %}}

## Changer la taille des diapositives dans les présentations

Cet échantillon de code vous montre comment changer la taille de la diapositive dans une présentation en Python en utilisant Aspose.Slides :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## Spécifier des tailles de diapositives personnalisées dans les présentations

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d'utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous prévoyez d'imprimer des diapositives en taille réelle de votre présentation sur une mise en page de page personnalisée ou si vous comptez afficher votre présentation sur certains types d'écrans, vous êtes susceptible de bénéficier de l'utilisation d'un paramètre de taille personnalisée pour votre présentation.

Cet échantillon de code vous montre comment utiliser Aspose.Slides pour Python via .NET pour spécifier une taille de diapositive personnalisée pour une présentation en Python :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Taille de papier A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## Gérer les problèmes lors du changement de la taille des diapositives dans les présentations

Après avoir changé la taille de la diapositive pour une présentation, le contenu des diapositives (images ou objets, par exemple) peut devenir déformé. Par défaut, les objets sont automatiquement redimensionnés pour s'adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille de la diapositive d'une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides gère le contenu sur les diapositives.

Selon ce que vous comptez faire ou atteindre, vous pouvez utiliser l'un de ces paramètres :

- `DO_NOT_SCALE`

  Si vous ne souhaitez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- `ENSURE_FIT`

  Si vous souhaitez réduire la taille de la diapositive et que vous avez besoin qu'Aspose.Slides réduise les objets de la diapositive pour s'assurer qu'ils tiennent tous sur les diapositives (de cette façon, vous évitez de perdre du contenu), utilisez ce paramètre.

- `MAXIMIZE`

  Si vous souhaitez agrandir la taille de la diapositive et que vous avez besoin qu'Aspose.Slides agrandisse les objets de la diapositive pour les rendre proportionnels à la nouvelle taille de diapositive, utilisez ce paramètre.

Cet échantillon de code vous montre comment utiliser le paramètre `MAXIMIZE` lors du changement de la taille de la diapositive d'une présentation :

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```