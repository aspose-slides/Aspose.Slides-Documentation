---
title: Substitution de police
type: docs
weight: 70
url: /fr/python-net/font-substitution/
keywords: "Police, police de substitution, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Substituer une police dans PowerPoint en Python"
---

Aspose.Slides vous permet de définir des règles pour les polices qui déterminent ce qui doit être fait dans certaines conditions (par exemple, lorsqu'une police ne peut pas être accédée) de cette manière :

1. Charger la présentation pertinente.
2. Charger la police qui sera remplacée.
3. Charger la nouvelle police.
4. Ajouter une règle pour le remplacement.
5. Ajouter la règle à la collection de règles de remplacement de police de la présentation.
6. Générer l'image de la diapositive pour observer l'effet.

Ce code Python démontre le processus de substitution de police :

```python
import aspose.slides as slides

# Charge une présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source qui sera remplacée
    sourceFont = slides.FontData("SomeRareFont")

    # Charge la nouvelle police
    destFont = slides.FontData("Arial")

    # Ajoute une règle de police pour le remplacement de police
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Ajoute la règle à la collection de règles de substitution de police
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Ajoute la collection de règles de police à la liste des règles
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # La police Arial sera utilisée à la place de SomeRareFont lorsque cette dernière est inaccessible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Enregistre l'image sur le disque au format JPEG
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{% alert title="NOTE" color="warning" %}} 

Vous voudrez peut-être voir [**Remplacement de police**](/slides/fr/python-net/font-replacement/). 

{{% /alert %}}