---
title: Créer des Vignettes de Forme
type: docs
weight: 70
url: /fr/python-net/create-shape-thumbnails/
keywords: "Vignette de forme. Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Vignette de forme dans une présentation PowerPoint en Python"
---

Aspose.Slides pour Python via .NET est utilisé pour créer des fichiers de présentation où chaque page est une diapositive. Ces diapositives peuvent être visualisées en ouvrant les fichiers de présentation à l'aide de Microsoft PowerPoint. Mais parfois, les développeurs peuvent avoir besoin de visualiser les images des formes séparément dans un visualiseur d'images. Dans de tels cas, Aspose.Slides pour Python via .NET vous aide à générer des images miniatures des formes de diapositive. Comment utiliser cette fonctionnalité est décrit dans cet article.  
Cet article explique comment générer des vignettes de diapositives de différentes manières :

- Générer une vignette de forme à l'intérieur d'une diapositive.
- Générer une vignette de forme pour une forme de diapositive avec des dimensions définies par l'utilisateur.
- Générer une vignette de forme dans les limites de l'apparence d'une forme.
- Générer une vignette d'un nœud enfant SmartArt.

## **Générer une Vignette de Forme à partir d'une Diapositive**
Pour générer une vignette de forme à partir de n'importe quelle diapositive à l'aide d'Aspose.Slides pour Python via .NET :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la forme de la diapositive référencée à l'échelle par défaut.
1. Enregistrer l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous génère une vignette de forme.

```py
import aspose.slides as slides

# Instancier une classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Créer une image à pleine échelle
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # Enregistrer l'image sur le disque au format PNG
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Générer une Vignette avec un Facteur d'Échelle Défini par l'Utilisateur**
Pour générer la vignette de forme de n'importe quelle forme de diapositive à l'aide d'Aspose.Slides pour Python via .NET :

1. Créer une instance de la classe `Presentation`.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de la forme.
1. Enregistrer l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous génère une vignette avec un facteur d'échelle défini par l'utilisateur.

```py
import aspose.slides as slides

# Instancier une classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # Créer une image à pleine échelle
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # Enregistrer l'image sur le disque au format PNG
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```


## **Créer une Vignette de l'Apparence de la Forme dans les Limites**
Cette méthode de création de vignettes de formes permet aux développeurs de générer une vignette dans les limites de l'apparence de la forme. Elle prend en compte tous les effets de la forme. La vignette de forme générée est limitée par les limites de la diapositive. Pour générer une vignette de n'importe quelle forme de diapositive dans les limites de son apparence, utilisez le code d'exemple suivant :

1. Créer une instance de la classe `Presentation`.
1. Obtenir la référence de n'importe quelle diapositive en utilisant son ID ou son index.
1. Obtenir l'image miniature de la diapositive référencée avec les limites de la forme comme apparence.
1. Enregistrer l'image miniature dans n'importe quel format d'image souhaité.

L'exemple ci-dessous crée une vignette avec un facteur d'échelle défini par l'utilisateur.

```py
import aspose.slides as slides

# Instancier une classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # Créer une image de forme avec des limites d'apparence
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # Enregistrer l'image sur le disque au format PNG
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```