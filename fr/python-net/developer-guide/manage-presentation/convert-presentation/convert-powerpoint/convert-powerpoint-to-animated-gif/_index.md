---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /fr/python-net/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint, PPT, PPTX, GIF animé, PPT en GIF animé, PPTX en GIF animé, Python, paramètres par défaut, paramètres personnalisés "
description: "Convertir une présentation PowerPoint en GIF animé : PPT en GIF, PPTX en GIF en Python"
---

## Conversion de présentations en GIF animé en utilisant les paramètres par défaut ##

Ce code exemple en Python montre comment convertir une présentation en GIF animé en utilisant des paramètres standard :

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

Le GIF animé sera créé avec des paramètres par défaut. 

{{%  alert  title="CONSEIL"  color="primary"  %}} 

Si vous préférez personnaliser les paramètres pour le GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/). Voir le code exemple ci-dessous. 

{{% /alert %}} 

## Conversion de présentations en GIF animé en utilisant des paramètres personnalisés ##
Ce code exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en Python :

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # la taille du GIF résultant  
options.default_delay = 2000 # la durée d'affichage de chaque diapositive avant de passer à la suivante
options.transition_fps = 35  # augmenter les FPS pour une meilleure qualité d'animation de transition

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

Vous voudrez peut-être jeter un œil à un convertisseur GRATUIT [Texte en GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 

{{% /alert %}}