---
title: Police intégrée
type: docs
weight: 40
url: /fr/python-net/embedded-font/
keywords: "Polices, polices intégrées, ajouter des polices, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Utiliser des polices intégrées dans une présentation PowerPoint en Python"
---

**Les polices intégrées dans PowerPoint** sont utiles lorsque vous souhaitez que votre présentation apparaisse correctement lorsqu'elle est ouverte sur n'importe quel système ou appareil. Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d'intégrer votre police. Sinon (sans polices intégrées), les textes ou les nombres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus.

La classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), la classe [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) et leurs interfaces contiennent la plupart des propriétés et des méthodes dont vous avez besoin pour travailler avec des polices intégrées dans les présentations PowerPoint.

## **Obtenir ou supprimer des polices intégrées de la présentation**

Aspose.Slides fournit la méthode `get_embedded_fonts()` (exposée par la classe [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/)) pour vous permettre d'obtenir (ou de découvrir) les polices intégrées dans une présentation. Pour supprimer des polices, la méthode `remove_embedded_font(font_data)` (exposée par la même classe) est utilisée.

Ce code Python vous montre comment obtenir et supprimer des polices intégrées d'une présentation :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation(path + "EmbeddedFonts.pptx") as presentation:
    # Rendra une diapositive contenant un cadre de texte qui utilise "FunSized" intégré
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture1_out.png", slides.ImageFormat.PNG)

    fontsManager = presentation.fonts_manager

    # Obtient toutes les polices intégrées
    embeddedFonts = fontsManager.get_embedded_fonts()

    # Trouve la police "Calibri"
    
    funSizedEmbeddedFont = list(filter(lambda data : data.font_name == "Calibri", embeddedFonts))[0]

    # Supprime la police "Calibri"
    fontsManager.remove_embedded_font(funSizedEmbeddedFont)

    # Rendra la présentation ; la police "Calibri" est remplacée par une existante
    with presentation.slides[0].get_image(draw.Size(960, 720)) as img:
        img.save("picture2_out.png", slides.ImageFormat.PNG)

    # Enregistre la présentation sans la police "Calibri" intégrée sur le disque
    presentation.save("WithoutManageEmbeddedFonts_out.ppt", slides.export.SaveFormat.PPT)
```

## **Ajouter des polices intégrées à la présentation**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) et deux surcharges de la méthode `add_embedded_font(font_data, embed_font_rule)`, vous pouvez sélectionner votre règle (d'intégration) préférée pour intégrer les polices dans une présentation. Ce code Python vous montre comment intégrer et ajouter des polices à une présentation :

```python
import aspose.slides as slides

# Charge la présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source à remplacer
    sourceFont = slides.FontData("Arial")

    allFonts = presentation.fonts_manager.get_fonts()
    embeddedFonts = presentation.fonts_manager.get_embedded_fonts()
    for font in allFonts:
        if font not in embeddedFonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Enregistre la présentation sur le disque
    presentation.save("AddEmbeddedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Compresser les polices intégrées**

Pour vous permettre de compresser les polices intégrées dans une présentation et de réduire sa taille de fichier, Aspose.Slides fournit la méthode `compress_embedded_fonts` (exposée par la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)).

Ce code Python vous montre comment compresser les polices intégrées de PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:

    slides.lowcode.Compress.compress_embedded_fonts(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```