---
title: Rendre des présentations avec des polices de secours en Python via Java
linktitle: Rendre les présentations
type: docs
weight: 30
url: /fr/python-java/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendu PowerPoint
- rendu de présentation
- rendu de diapositive
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Rendre des présentations avec des polices de secours dans Aspose.Slides pour Python via Java – maintenir la cohérence du texte entre PPT, PPTX et ODP avec des exemples de code Python étape par étape."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de rendre des présentations en utilisant des règles de polices de secours. Cet article montre comment créer une collection de règles de polices de secours, modifier ses règles en supprimant ou en ajoutant des polices de secours, et affecter la collection à l'aide de la méthode [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection).

Une fois la collection de règles de polices de secours affectée au [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/) de la présentation, les règles sont appliquées lors d'opérations telles que l'enregistrement, le rendu et la conversion de la présentation. L'exemple montre comment utiliser les règles configurées lors du rendu d'une vignette de diapositive et de son enregistrement au format image JPEG.

## **Rendre une diapositive en utilisant des règles de polices de secours**

L'exemple suivant comprend les étapes suivantes :

1. [Créer une collection de règles de polices de secours](/slides/fr/python-java/create-fallback-fonts-collection/).
2. [Supprimer](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/#remove) une police de secours d'une règle et [ajouter des polices de secours](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) à une autre règle.
3. Affecter la collection de règles en utilisant [setFontFallBackRulesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) sur le gestionnaire de polices renvoyé par [getFontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getFontsManager).
4. Utiliser la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour enregistrer la présentation au même format ou à un autre format. Après que la collection de règles de polices de secours a été affectée à [FontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/), ces règles sont appliquées lors d'opérations sur la présentation : enregistrement, rendu, conversion, etc.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Créer une nouvelle collection de règles.
fallback_rules = FontFallBackRulesCollection()

# Créer plusieurs règles.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Essayer de supprimer la police de secours "Tahoma" des règles.
    fallback_rule.remove("Tahoma")

    # Mettre à jour les règles pour la plage spécifiée.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Supprimer une règle existante, en conservant au moins une règle pour le rendu.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Attribuer la collection de règles préparée.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Rendre une vignette en utilisant la collection de règles configurée.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Enregistrer l'image sur le disque au format JPEG.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
En savoir plus sur la façon de [convertir PPT et PPTX en JPG en Python via Java](/slides/fr/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}