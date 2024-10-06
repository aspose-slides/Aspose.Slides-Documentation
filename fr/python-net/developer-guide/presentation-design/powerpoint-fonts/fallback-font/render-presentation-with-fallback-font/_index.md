---
title: Rendre la présentation avec une police de secours
type: docs
weight: 30
url: /python-net/render-presentation-with-fallback-font/
keywords: "Police de secours, rendre PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Rendre PowerPoint avec une police de secours en Python"
---

L'exemple suivant comprend ces étapes :

1. Nous [créons une collection de règles de police de secours](/slides/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) une règle de police de secours et [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) à une autre règle.
1. Définir la collection de règles sur la propriété [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/).
1. Avec la méthode [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), nous pouvons enregistrer la présentation dans le même format, ou l'enregistrer dans un autre. Après que la collection de règles de police de secours soit définie sur FontsManager, ces règles sont appliquées lors de toute opération sur la présentation : enregistrer, rendre, convertir, etc.

```py
import aspose.slides as slides

# Créer une nouvelle instance d'une collection de règles
rulesList = slides.FontFallBackRulesCollection()

# créer un certain nombre de règles
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Essayer de supprimer la police de secours "Tahoma" des règles chargées
	fallBackRule.remove("Tahoma")

	#Et mettre à jour les règles pour la plage spécifiée
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#Nous pouvons également supprimer toute règle existante de la liste
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Assignation d'une liste de règles préparée à utiliser
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendu de la vignette en utilisant la collection de règles initialisée et enregistrement au format PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
En savoir plus sur [Enregistrement et conversion dans la présentation](/slides/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}