---
title: Convertir les présentations PowerPoint en GIF animés en Python
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animé
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en GIF
- présentation en GIF
- diapositive en GIF
- PPT en GIF
- PPTX en GIF
- enregistrer PPT en GIF
- enregistrer PPTX en GIF
- exporter PPT en GIF
- exporter PPTX en GIF
- paramètres par défaut
- paramètres personnalisés
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertissez facilement les présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides for Python via Java. Résultats rapides et de haute qualité."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de convertir des présentations PowerPoint en fichiers GIF animés en quelques lignes de code seulement. Cela est utile pour partager le contenu des diapositives sur des pages web, des messageries ou de la documentation. Cet article explique comment exporter une présentation en utilisant les paramètres par défaut et comment personnaliser la taille du cadre, le délai des diapositives et le taux de rafraîchissement des transitions via [GifOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gifoptions/).

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

L'exemple Python suivant charge `pres.pptx` et le sauvegarde en GIF animé en utilisant les paramètres standard :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Astuce" %}}
Pour personnaliser la sortie GIF, transmettez un objet [GifOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gifoptions/) lors de l'enregistrement, comme indiqué ci-dessous.
{{% /alert %}}

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Utilisez [setFrameSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gifoptions/#setFrameSize) pour spécifier les dimensions de sortie en pixels, [setDefaultDelay](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gifoptions/#setDefaultDelay) pour définir le délai de diapositive par défaut en millisecondes, et [setTransitionFps](https://reference.aspose.com/slides/fr/python-java/aspose.slides/gifoptions/#setTransitionFps) pour contrôler le taux de rafraîchissement des transitions.

L'exemple suivant exporte un GIF de 960 × 720 avec un délai de diapositive par défaut de deux secondes et 35 images par seconde pour les transitions. Le délai par défaut s'applique lorsque le temps d'avance après de la diapositive n'est pas défini.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Vous pouvez également essayer le convertisseur gratuit [Text to GIF](https://products.aspose.app/slides/fr/text-to-gif) d'Aspose.
{{% /alert %}}

## **FAQ**

**Et si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configurez les polices de secours](/slides/fr/python-java/powerpoint-fonts/). La substitution de polices peut modifier l'apparence du GIF exporté. Il est essentiel de rendre les polices originales disponibles afin de respecter le design de la présentation.

**Puis-je superposer un filigrane sur les cadres GIF ?**

Oui. [Ajoutez un objet ou un logo semi-transparent](/slides/fr/python-java/watermark/) aux diapositives maîtres concernées ou aux diapositives individuelles avant l'exportation. Le filigrane devient partie intégrante du contenu rendu de la diapositive.