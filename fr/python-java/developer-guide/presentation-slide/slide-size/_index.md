---
title: Modifier la taille des diapositives de la présentation en Python via Java
linktitle: Taille de la diapositive
type: docs
weight: 70
url: /fr/python-java/slide-size/
keywords:
- taille de diapositive
- rapport d'aspect
- standard
- écran large
- 4:3
- 16:9
- définir la taille de la diapositive
- modifier la taille de la diapositive
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
- Java
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Python via Java et Aspose.Slides, et à optimiser les présentations pour n'importe quel écran sans perdre de qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le rapport d’aspect dans les présentations PowerPoint, ce qui est essentiel tant pour l’impression que pour l’affichage à l’écran.

Tailles de diapositives populaires et rapports :

- **Standard (4:3 Aspect Ratio)** : Idéal pour les écrans et appareils plus anciens.
- **Widescreen (16:9 Aspect Ratio)** : Recommandé pour les projecteurs et affichages modernes.

Assurez la cohérence de votre présentation, car une même taille de diapositive et un même rapport d’aspect s’appliquent à toutes les diapositives. Pour de meilleurs résultats, définissez les dimensions de vos diapositives au début du processus de création de la présentation afin d’éviter les complications.

{{% alert color="info" title="Remarque" %}}
Par défaut, les présentations créées avec Aspose.Slides utilisent le rapport d’aspect standard 4:3.
{{% /alert %}}

Les pages de notes et de documents ont des dimensions distinctes des diapositives classiques. Consultez [Taille de la page de notes](/slides/fr/python-java/notes-size/) pour modifier leur taille et orientation.

## **Modifier la taille des diapositives dans les présentations**

Ce code d’exemple montre comment modifier la taille des diapositives d’une présentation en Python via Java à l’aide d’Aspose.Slides :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Spécifier des tailles de diapositives personnalisées dans les présentations**

Si vous trouvez que les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas à votre travail, vous pouvez décider d’utiliser une taille de diapositive spécifique ou unique. Par exemple, si vous envisagez d’imprimer des diapositives en pleine taille à partir de votre présentation sur une mise en page personnalisée ou si vous prévoyez d’afficher votre présentation sur certains types d’écrans, vous bénéficierez probablement d’un réglage de taille personnalisée pour votre présentation.

Ce code d’exemple montre comment utiliser Aspose.Slides pour Python via Java afin de spécifier une taille de diapositive personnalisée pour une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Gérer le contenu des diapositives après le redimensionnement**

Après avoir modifié la taille des diapositives d’une présentation, le contenu des diapositives (images ou objets, par exemple) peut être déformé. Par défaut, les objets sont automatiquement redimensionnés pour s’adapter à la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d’une présentation, vous pouvez spécifier un paramètre qui détermine comment Aspose.Slides traite le contenu des diapositives.

En fonction de ce que vous souhaitez faire ou obtenir, vous pouvez utiliser l’un de ces paramètres :

- [DoNotScale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  Si vous NE souhaitez PAS que les objets sur les diapositives soient redimensionnés, utilisez ce paramètre.

- [EnsureFit](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  Si vous voulez réduire à une taille de diapositive plus petite et que vous avez besoin qu’Aspose.Slides réduise les objets des diapositives pour qu’ils tiennent tous sur les diapositives (ainsi vous évitez de perdre du contenu), utilisez ce paramètre.

- [Maximize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/#Maximize)

  Si vous voulez agrandir à une taille de diapositive plus grande et que vous avez besoin qu’Aspose.Slides augmente les objets des diapositives pour qu’ils soient proportionnels à la nouvelle taille de diapositive, utilisez ce paramètre.

Ce code d’exemple montre comment utiliser le paramètre [Maximize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/#Maximize) lors du changement de la taille des diapositives d’une présentation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je définir une taille de diapositive personnalisée en utilisant des unités autres que les pouces (par exemple, points ou millimètres) ?**

Oui. Aspose.Slides utilise les points en interne, où 1 point vaut 1/72 de pouce. Vous pouvez convertir n’importe quelle unité (telles que les millimètres ou les centimètres) en points et utiliser les valeurs converties pour définir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisée très grande affectera-t-elle les performances et l’utilisation de la mémoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) associées à une échelle de rendu plus élevée entraînent une consommation de mémoire accrue et des temps de traitement plus longs. Visez une taille de diapositive réaliste et ajustez l’échelle de rendu uniquement si nécessaire pour obtenir la qualité de sortie souhaitée.

**Puis-je définir une taille de diapositive non standard puis fusionner des diapositives provenant de présentations ayant des tailles différentes ?**

Vous ne pouvez pas [merge presentations](/slides/fr/python-java/merge-presentation/) tant qu’elles ont des tailles de diapositives différentes — commencez par redimensionner une présentation pour qu’elle corresponde à l’autre. Lors du changement de la taille des diapositives, vous pouvez choisir la façon dont le contenu existant est géré via l’option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesizescaletype/). Après avoir aligné les tailles, vous pouvez fusionner les diapositives tout en préservant le formatage.

**Puis-je générer des miniatures pour des formes individuelles ou des régions spécifiques d’une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) ainsi que pour [formes sélectionnées](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getImage). Les images générées reflètent la taille de diapositive et le rapport d’aspect actuels, garantissant un cadrage et une géométrie cohérents.