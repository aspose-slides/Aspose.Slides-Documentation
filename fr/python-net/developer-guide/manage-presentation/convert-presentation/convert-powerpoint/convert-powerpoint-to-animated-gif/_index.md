---
title: Convertir des présentations en GIF animés avec Python
linktitle: Présentation vers GIF
type: docs
weight: 65
url: /fr/python-net/convert-powerpoint-to-animated-gif/
keywords:
- GIF animé
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- convertir ODP
- PowerPoint vers GIF
- OpenDocument vers GIF
- présentation vers GIF
- diapositive vers GIF
- PPT vers GIF
- PPTX vers GIF
- ODP vers GIF
- paramètres par défaut
- paramètres personnalisés
- Python
- Aspose.Slides
description: "Convertissez facilement les présentations PowerPoint (PPT, PPTX) et les fichiers OpenDocument (ODP) en GIF animés avec Aspose.Slides pour Python. Rapide, résultats de haute qualité."
---

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple en Python montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

Le GIF animé sera créé avec les paramètres par défaut.

{{%  alert  title="ASTUCE"  color="primary"  %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/gifoptions/) . Voir le code d'exemple ci-dessous. 
{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**

Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés en Python :

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # la taille du GIF résultant  
options.default_delay = 2000 # durée d'affichage de chaque diapositive avant le passage à la suivante
options.transition_fps = 35  # augmenter le FPS pour améliorer la qualité de l'animation de transition

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
Vous voudrez peut-être consulter un convertisseur GRATUIT [Texte vers GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

**Que se passe-t-il si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configurez des polices de secours](/slides/fr/python-net/powerpoint-fonts/). Aspose.Slides les substituera, mais l'apparence peut différer. Pour l'image de marque, assurez-vous toujours que les polices requises sont explicitement disponibles.

**Puis-je superposer un filigrane sur les images du GIF ?**

Oui. [Ajoutez un objet/logo semi-transparent](/slides/fr/python-net/watermark/) à la diapositive maître ou aux diapositives individuelles avant l'exportation — le filigrane apparaîtra sur chaque image.