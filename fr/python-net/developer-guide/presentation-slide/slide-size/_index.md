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
- grand écran
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
- Aspose.Slides
description: "Apprenez à redimensionner rapidement les diapositives dans les fichiers PPT, PPTX et ODP avec Python et Aspose.Slides, optimisez les présentations pour n'importe quel écran sans perdre en qualité."
---
## **Introduction**

Aspose.Slides fournit des outils complets pour ajuster la taille des diapositives et le ratio d'aspect dans les présentations PowerPoint, essentiel à la fois pour l'impression et l'affichage à l'ecran.

Tailles de diapositives populaires et ratios :

- **Standard (ratio d'aspect 4:3)**: Idéal pour les ecrans et appareils plus anciens.
- **Grand ecran (ratio d'aspect 16:9)**: Recommande pour les projecteurs et ecrans modernes.

Assurez la coherence de votre presentation, car une seule taille de diapositive et un seul ratio d'aspect s'appliquent a toutes les diapositives. Pour des resultats optimaux, definissez les dimensions de vos diapositives au debut du processus de creation de la presentation afin d'eviter les complications.

{{% alert color="info" title="Note" %}}
Par defaut, les presentations creees avec Aspose.Slides utilisent le ratio d'aspect standard 4:3.
{{% /alert %}}

Les pages de notes et de documents de distribution ont des dimensions separees des diapositives normales. Voir [Taille de la page de notes](/slides/fr/python-net/notes-size/) pour modifier leur taille et leur orientation.

## **Modifier la taille de la diapositive dans une presentation**

Ce code d'exemple montre comment modifier la taille de la diapositive d'une presentation en Python a l'aide d'Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **Specifier des tailles de diapositive personnalisees**

Si les tailles de diapositives courantes (4:3 et 16:9) ne conviennent pas a votre travail, vous pouvez decidir d'utiliser une taille de diapositive specifique ou unique. Par exemple, si vous prevoyez d'imprimer des diapositives pleine taille de votre presentation sur une mise en page de page personnalisee ou si vous avez l'intention d'afficher votre presentation sur certains types d'ecrans, il est probable que vous beneficiez de l'utilisation d'un reglage de taille personnalisee pour votre presentation.

Ce code d'exemple montre comment utiliser Aspose.Slides pour Python via .NET afin de specifier une taille de diapositive personnalisee pour une presentation en Python:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # Taille du papier A4
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **Gerer le contenu des diapositives apres redimensionnement**

Apres avoir modifie la taille des diapositives d'une presentation, le contenu des diapositives (images ou objets, par exemple) peut etre deforme. Par defaut, les objets sont automatiquement redimensionnes pour s'adapter a la nouvelle taille de diapositive. Cependant, lors du changement de la taille des diapositives d'une presentation, vous pouvez specifier un parametre qui determine la facon dont Aspose.Slides gere le contenu des diapositives.

Selon ce que vous souhaitez faire ou atteindre, vous pouvez utiliser l'un de ces parametres:

- `DO_NOT_SCALE`

  Si vous NE voulez PAS que les objets sur les diapositives soient redimensionnes, utilisez ce parametre.

- `ENSURE_FIT`

  Si vous souhaitez reduire a une taille de diapositive plus petite et que vous avez besoin qu'Aspose.Slides reduise les objets des diapositives pour qu'ils tiennent tous sur les diapositives (ainsi, vous evitez de perdre du contenu), utilisez ce parametre.

- `MAXIMIZE`

  Si vous souhaitez agrandir a une taille de diapositive plus grande et que vous avez besoin qu'Aspose.Slides agrandisse les objets des diapositives pour les rendre proportionnels a la nouvelle taille de diapositive, utilisez ce parametre.

Ce code d'exemple montre comment utiliser le parametre `MAXIMIZE` lors du changement de la taille des diapositives d'une presentation:

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**Puis-je definir une taille de diapositive personnalisee en utilisant des unites autres que les pouces (par exemple, des points ou des millimetres) ?**

Oui. Aspose.Slides utilise les points en interne, ou 1 point egal a 1/72 de pouce. Vous pouvez convertir n'importe quelle unite (telle que les millimetres ou les centimetres) en points et utiliser les valeurs converties pour definir la largeur et la hauteur de la diapositive.

**Une taille de diapositive personnalisee tres grande affectera-t-elle les performances et la consommation de memoire lors du rendu ?**

Oui. Des dimensions de diapositive plus grandes (en points) combinees a une echelle de rendu plus elevee entrainent une consommation de memoire accrue et des temps de traitement plus longs. Visez une taille de diapositive pratique et ajustez l'echelle de rendu uniquement si necessaire pour obtenir la qualite de sortie souhaitee.

**Puis-je definir une taille de diapositive non standard puis fusionner des diapositives de presentations ayant des tailles différentes ?**

Vous ne pouvez pas [fusionner des presentations](/slides/fr/python-net/merge-presentation/) lorsqu'elles ont des tailles de diapositive differentes — commencez par redimensionner une presentation pour correspondre a l'autre. Lors du changement de la taille des diapositives, vous pouvez choisir comment le contenu existant est gere via l'option [SlideSizeScaleType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesizescaletype/). Apres avoir aligne les tailles, vous pouvez fusionner les diapositives tout en preservant le formatage.

**Puis-je generer des miniatures pour des formes indivduelles ou des regions specifique d'une diapositive, et respecteront-elles la nouvelle taille de diapositive ?**

Oui. Aspose.Slides peut rendre des miniatures pour [toutes les diapositives](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/) ainsi que pour [les formes selectionnees](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/get_image/). Les images resultantes reflètent la taille et le ratio d'aspect actuels de la diapositive, garantissant un cadrage et une geometrie coherents.