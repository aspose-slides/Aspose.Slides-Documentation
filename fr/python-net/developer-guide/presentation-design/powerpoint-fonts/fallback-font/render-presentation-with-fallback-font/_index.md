---
title: Rendre des présentations avec des polices de secours en Python
linktitle: Rendre les présentations
type: docs
weight: 30
url: /fr/python-net/render-presentation-with-fallback-font/
keywords:
- police de secours
- rendre PowerPoint
- rendre présentation
- rendre diapositive
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Rendre les présentations avec des polices de secours dans Aspose.Slides pour Python via .NET – garder le texte cohérent entre PPT, PPTX et ODP avec des exemples de code étape par étape."
---

L'exemple suivant comprend ces étapes:
1. Nous [créons une collection de règles de police de secours](/slides/fr/python-net/create-fallback-fonts-collection/).
1. Nous [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) à une autre règle.
1. Définissez la collection de règles sur la propriété [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. Avec la méthode [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) nous pouvons enregistrer la présentation au même format, ou l'enregistrer dans un autre. Après que la collection de règles de police de secours est définie sur FontsManager, ces règles sont appliquées lors de toute opération sur la présentation: enregistrement, rendu, conversion, etc.
```py
import aspose.slides as slides

# Créer une nouvelle instance d'une collection de règles
rulesList = slides.FontFallBackRulesCollection()

# créer un certain nombre de règles
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	# Essayer de supprimer la police de secours "Tahoma" des règles chargées
	fallBackRule.remove("Tahoma")

	# Et mettre à jour les règles pour la plage spécifiée
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

# Nous pouvons également supprimer toutes les règles existantes de la liste
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	# Assigner la liste de règles préparée pour l'utilisation
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendu de la miniature en utilisant la collection de règles initialisée et enregistrement au format PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
En savoir plus sur la façon de [Convertir des diapositives PowerPoint en PNG avec Python](/slides/fr/python-net/convert-powerpoint-to-png/).
{{% /alert %}}