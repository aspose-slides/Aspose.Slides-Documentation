---
title: Convertir les diapositives PowerPoint en PNG avec Python
linktitle: Diapositive en PNG
type: docs
weight: 30
url: /fr/python-net/convert-powerpoint-to-png/
keywords:
- convertir PowerPoint en PNG
- convertir présentation en PNG
- convertir diapositive en PNG
- convertir PPT en PNG
- convertir PPTX en PNG
- convertir ODP en PNG
- PowerPoint en PNG
- présentation en PNG
- diapositive en PNG
- PPT en PNG
- PPTX en PNG
- ODP en PNG
- Python
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en images PNG de haute qualité rapidement avec Aspose.Slides pour Python via .NET, garantissant des résultats précis et automatisés."
---

## **Vue d'ensemble**

Aspose.Slides for Python via .NET simplifie la conversion des présentations PowerPoint en PNG. Vous chargez une présentation, parcourez ses diapositives, rasterisez chacune en image et enregistrez le résultat sous forme de fichiers PNG. Cela convient pour générer des aperçus de diapositives, intégrer des diapositives dans des pages web ou produire des actifs statiques pour un traitement ultérieur.

## **Convertir les diapositives en PNG**

Cette section montre l'exemple le plus simple de conversion d'une présentation PowerPoint en images PNG à l'aide d'Aspose.Slides for Python via .NET.

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Récupérez une diapositive de la collection `Presentation.slides` (voir la classe [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)).
1. Utilisez la méthode `Slide.get_image` pour générer une vignette de la diapositive.
1. Utilisez la méthode `Presentation.save` pour enregistrer la vignette de la diapositive au format PNG.

Ce code Python montre comment convertir une présentation PowerPoint en PNG :
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Convertir les diapositives en PNG avec des dimensions personnalisées**

Pour exporter les diapositives en PNG à une échelle personnalisée, appelez `Slide.get_image` avec des facteurs d'échelle horizontaux et verticaux. Ces multiplicateurs redimensionnent la sortie par rapport aux dimensions originales de la diapositive—par exemple, `2.0` double à la fois la largeur et la hauteur. Utilisez des valeurs identiques pour `scale_x` et `scale_y` afin de conserver le rapport d'aspect.

Ce code Python démontre l'opération décrite :
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **Convertir les diapositives en PNG avec une taille personnalisée**

Si vous souhaitez générer des fichiers PNG d'une taille précise, transmettez les valeurs souhaitées de `width` et `height`. Le code ci‑dessus montre comment convertir un PowerPoint en PNG tout en spécifiant la taille de l'image :
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Astuce" color="primary" %}}

Vous pouvez essayer les convertisseurs gratuits **PowerPoint‑to‑PNG** d'Aspose—[PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ils offrent une implémentation en direct du processus décrit sur cette page.

{{% /alert %}}

## **FAQ**

**Comment exporter uniquement une forme spécifique (par ex. un graphique ou une image) plutôt que la diapositive entière ?**

Aspose.Slides prend en charge [la génération de vignettes pour des formes individuelles](/slides/fr/python-net/create-shape-thumbnails/) ; vous pouvez rendre une forme en image PNG.

**La conversion parallèle est‑elle prise en charge sur un serveur ?**

Oui, mais [ne partagez pas](/slides/fr/python-net/multithreading/) une même instance de présentation entre plusieurs threads. Utilisez une instance distincte par thread ou processus.

**Quelles sont les limitations de la version d'évaluation lors de l'exportation en PNG ?**

Le mode d'évaluation ajoute un filigrane aux images de sortie et applique [d'autres restrictions](/slides/fr/python-net/licensing/) jusqu'à ce qu'une licence soit installée.