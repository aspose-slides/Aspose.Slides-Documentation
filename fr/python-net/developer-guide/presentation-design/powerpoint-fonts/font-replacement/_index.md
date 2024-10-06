---
title: Remplacement de police
type: docs
weight: 60
url: /python-net/font-replacement/
keywords: "Police, remplacer police, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Remplacer des polices explicitement dans PowerPoint en Python"
---

Si vous changez d'avis sur l'utilisation d'une police, vous pouvez remplacer cette police par une autre police. Toutes les instances de l'ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation pertinente.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Remplacez la police.
5. Écrivez la présentation modifiée en tant que fichier PPTX.

Ce code Python démontre le remplacement de police :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Charge une présentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Charge la police source qui sera remplacée
    sourceFont = slides.FontData("Arial")

    # Charge la nouvelle police
    destFont = slides.FontData("Times New Roman")

    # Remplace les polices
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Enregistre la présentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Remarque" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (si une police ne peut pas être accessible, par exemple), voir [**Substitution de police**](/slides/python-net/font-substitution/). 

{{% /alert %}}