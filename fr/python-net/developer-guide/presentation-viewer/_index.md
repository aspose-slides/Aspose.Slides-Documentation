---
title: Créer un visualiseur de présentations en Python
linktitle: Visualiseur de présentations
type: docs
weight: 50
url: /fr/python-net/presentation-viewer/
keywords: 
- visualiser une présentation
- visualiseur de présentations
- créer un visualiseur de présentations
- visualiser PPT
- visualiser PPTX
- visualiser ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Apprenez à créer un visualiseur de présentations personnalisé en Python avec Aspose.Slides. Affichez facilement les fichiers PowerPoint (PPTX, PPT) et OpenDocument (ODP) sans Microsoft PowerPoint ni autre logiciel de bureautique."
---

## **Vue d’ensemble**

Aspose.Slides for Python est utilisé pour créer des fichiers de présentation contenant des diapositives. Ces diapositives peuvent être affichées en ouvrant les présentations dans Microsoft PowerPoint, par exemple. Cependant, les développeurs peuvent parfois devoir visualiser les diapositives sous forme d’images dans leur visionneur d’images préféré ou les utiliser dans un visualiseur de présentations personnalisé. Dans ces cas, Aspose.Slides vous permet d’exporter des diapositives individuelles en tant qu’images. Cet article explique comment procéder.

## **Générer une image SVG à partir d’une diapositive**

Pour générer une image SVG à partir d’une diapositive de présentation avec Aspose.Slides, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Ouvrez un flux de fichier.
1. Enregistrez la diapositive sous forme d’image SVG dans le flux de fichier.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Créer une image miniature d’une diapositive**

Aspose.Slides vous aide à générer des images miniatures des diapositives. Pour générer une miniature d’une diapositive à l’aide d’Aspose.Slides, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Créez une image miniature de la diapositive référencée à l’échelle souhaitée.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Créer une miniature de diapositive avec des dimensions définies par l’utilisateur**

Pour créer une image miniature de diapositive avec des dimensions définies par l’utilisateur, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Générez une image miniature de la diapositive référencée avec les dimensions spécifiées.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Créer une miniature de diapositive avec notes du présentateur**

Pour générer une miniature d’une diapositive contenant les notes du présentateur à l’aide d’Aspose.Slides, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
1. Utilisez la propriété `RenderingOptions.slides_layout_options` pour définir la position des notes du présentateur.
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Générez une image miniature de la diapositive référencée en utilisant les options de rendu.
1. Enregistrez l’image miniature dans le format d’image de votre choix.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Exemple en direct**

Essayez l’application gratuite [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) pour voir ce que vous pouvez implémenter avec l’API Aspose.Slides :

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **FAQ**

**Puis‑je intégrer un visualiseur de présentations dans une application web ASP.NET ?**

Oui. Vous pouvez utiliser Aspose.Slides côté serveur pour rendre les diapositives sous forme d’[images](/slides/fr/python-net/convert-powerpoint-to-png/) ou de [HTML](/slides/fr/python-net/convert-powerpoint-to-html/) et les afficher dans le navigateur. Les fonctions de navigation et de zoom peuvent être implémentées avec JavaScript pour offrir une expérience interactive.

**Quelle est la meilleure façon d’afficher des diapositives dans un visualiseur .NET personnalisé ?**

L’approche recommandée consiste à rendre chaque diapositive en tant qu’[image](/slides/fr/python-net/convert-powerpoint-to-png/) (par ex., PNG ou SVG) ou à la convertir en [HTML](/slides/fr/python-net/convert-powerpoint-to-html/) à l’aide d’Aspose.Slides, puis à afficher le résultat dans une zone d’image (pour les applications de bureau) ou un conteneur HTML (pour le web).

**Comment gérer de grandes présentations contenant de nombreuses diapositives ?**

Pour les présentations volumineuses, envisagez le chargement différé ou le rendu à la demande des diapositives. Cela signifie générer le contenu d’une diapositive uniquement lorsque l’utilisateur s’y rend, ce qui réduit la consommation de mémoire et le temps de chargement.