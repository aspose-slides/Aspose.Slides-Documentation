---
title: Incorporer des polices dans les présentations avec Python
linktitle: Incorporation de police
type: docs
weight: 40
url: /fr/python-net/embedded-font/
keywords:
- ajouter une police
- incorporer une police
- incorporation de police
- obtenir une police incorporée
- ajouter une police incorporée
- supprimer une police incorporée
- compresser une police incorporée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Incorporez des polices TrueType dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET, garantissant un rendu précis sur toutes les plates‑formes."
---

## **Vue d'ensemble**

**L'incorporation des polices dans PowerPoint** garantit que votre présentation conserve son apparence prévue sur différents systèmes. Que vous utilisiez des polices uniques pour la créativité ou des polices standard, incorporer les polices empêche les perturbations du texte et de la mise en page.

Si vous avez utilisé une police tierce ou non standard parce que vous avez fait preuve de créativité dans votre travail, vous avez encore plus de raisons d'incorporer votre police. Sinon (sans polices incorporées), le texte ou les nombres sur vos diapositives, la mise en page, le style, etc. peuvent changer ou se transformer en rectangles confus. 

Utilisez les classes [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/), et [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) pour gérer les polices incorporées.

## **Obtenir et supprimer des polices incorporées**

Récupérez ou supprimez les polices incorporées d'une présentation facilement avec les méthodes [get_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) et [remove_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Ce code Python vous montre comment obtenir et supprimer des polices incorporées d'une présentation :

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Rendre la diapositive contenant un cadre de texte qui utilise la police incorporée 'FunSized'.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Obtenir toutes les polices incorporées.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Trouver la police 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Supprimer la police 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Rendre la diapositive ; la police 'Calibri' sera remplacée par une police existante.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Enregistrer la présentation sans la police incorporée 'Calibri' sur le disque.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Ajouter des polices incorporées**

En utilisant l'énumération [EmbedFontCharacters](https://reference.aspose.com/slides/python-net/aspose.slides.export/embedfontcharacters/) et deux surcharges de la méthode [add_embedded_font](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/add_embedded_font/), vous pouvez sélectionner la règle d'incorporation souhaitée pour intégrer les polices dans une présentation. Ce code Python vous montre comment incorporer et ajouter des polices à une présentation :

```python
import aspose.slides as slides

# Charger une présentation.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Enregistrer la présentation sur le disque.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Compresser les polices incorporées**

Optimisez la taille du fichier en compressant les polices incorporées à l'aide de [compress_embedded_fonts](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Exemple de code pour la compression :

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Comment savoir qu’une police spécifique dans la présentation sera encore substituée lors du rendu malgré son incorporation ?**

Vérifiez les [informations de substitution](/slides/fr/python-net/font-substitution/) dans le gestionnaire de polices et les [règles de secours/substitution](/slides/fr/python-net/fallback-font/) : si la police est indisponible ou restreinte, une police de secours sera utilisée.

**Cela vaut-il la peine d’incorporer les polices « système » comme Arial/Calibri ?**

Généralement non — elles sont presque toujours disponibles. Mais pour une portabilité totale dans des environnements « légers » (Docker, un serveur Linux sans polices préinstallées), incorporer les polices système peut éliminer le risque de substitutions inattendues.