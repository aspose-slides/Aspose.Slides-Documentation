---
title: Convertir PowerPoint en PNG
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-png/
keywords: PowerPoint en PNG, PPT en PNG, PPTX en PNG, Python, Aspose.Slides pour Python via .NET
description: Convertir une présentation PowerPoint en PNG
---

## **À propos de la conversion PowerPoint en PNG**

Le format PNG (Portable Network Graphics) n'est pas aussi populaire que le JPEG (Joint Photographic Experts Group), mais il reste très populaire.

**Cas d'utilisation :** Lorsque vous avez une image complexe et que la taille n'est pas un problème, le PNG est un meilleur format d'image que le JPEG.

{{% alert title="Conseil" color="primary" %}} Vous voudrez peut-être consulter les **Convertisseurs PowerPoint en PNG** gratuits d'Aspose : [PPTX en PNG](https://products.aspose.app/slides/conversion/pptx-to-png) et [PPT en PNG](https://products.aspose.app/slides/conversion/ppt-to-png). Ce sont une mise en œuvre en direct du processus décrit sur cette page. {{% /alert %}}

## **Convertir PowerPoint en PNG**

Suivez ces étapes :

1. Instanciez la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Récupérez l'objet slide de la collection [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) sous l'interface [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/).
3. Utilisez la méthode [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) pour obtenir la miniature de chaque diapositive.
4. Utilisez la méthode [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) pour enregistrer la miniature de la diapositive au format PNG.

Ce code Python vous montre comment convertir une présentation PowerPoint en PNG :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **Convertir PowerPoint en PNG avec des dimensions personnalisées**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine échelle, vous pouvez définir les valeurs pour `desiredX` et `desiredY`, qui déterminent les dimensions de la miniature résultante.

Ce code en Python démontre l'opération décrite :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **Convertir PowerPoint en PNG avec une taille personnalisée**

Si vous souhaitez obtenir des fichiers PNG autour d'une certaine taille, vous pouvez passer vos arguments préférés `width` et `height` pour `ImageSize`.

Ce code vous montre comment convertir un PowerPoint en PNG tout en spécifiant la taille pour les images :

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```