---
title: Prezentációk renderelése helyettesítő betűtípusokkal Pythonban
linktitle: Prezentációk renderelése
type: docs
weight: 30
url: /hu/python-net/render-presentation-with-fallback-font/
keywords:
- helyettesítő betűtípus
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Renderelje a prezentációkat helyettesítő betűtípusokkal az Aspose.Slides Python számára .NET-en keresztül – tartsa a szöveget konzisztensnek PPT, PPTX és ODP formátumok között lépésről lépésre kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy helyettesítő betűtípus szabályok használatával jelenítsen meg prezentációkat. Ez a cikk bemutatja, hogyan hozhat létre egy helyettesítő betűtípus szabályok gyűjteményt, hogyan módosíthatja annak szabályait helyettesítő betűtípusok eltávolításával vagy hozzáadásával, valamint hogyan rendelheti a gyűjteményt a `FontsManager.font_fall_back_rules_collection` tulajdonsághoz.

Miután a helyettesítő betűtípus szabályok gyűjteménye hozzárendelésre kerül a prezentáció `fonts_manager` tulajdonságához, a szabályok alkalmazásra kerülnek a mentés, a renderelés és a prezentáció konvertálása során. A példa bemutatja, hogyan lehet használni a konfigurált szabályokat diakép bélyegkép renderelésekor, és azt PNG-képként menteni.

## **Dia renderelése helyettesítő betűtípus szabályokkal**

A következő példa ezeket a lépéseket tartalmazza:

1. Létrehozzuk a [helyettesítő betűtípus szabályok gyűjteményét](/slides/hu/python-net/create-fallback-fonts-collection/).
1. [Eltávolítás](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrule/remove/) egy helyettesítő betűtípus szabályt, és [add_fall_back_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) egy másik szabályhoz.
1. Állítsuk be a szabályok gyűjteményét a [FontsManager.font_fall_back_rules_collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) tulajdonságra.
1. A [Presentation.save()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) metódussal menthetjük a prezentációt ugyanabban a formátumban, vagy egy másikban. Miután a helyettesítő betűtípus szabályok gyűjteménye be van állítva a FontsManager-re, ezek a szabályok alkalmazásra kerülnek a prezentáción végzett bármely művelet során: mentés, renderelés, konvertálás stb.

```py
import aspose.slides as slides

# Új szabálykészlet példány létrehozása
rulesList = slides.FontFallBackRulesCollection()

# Hozzon létre néhány szabályt
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Megpróbálja eltávolítani a "Tahoma" helyettesítő betűtípust a betöltött szabályokból
	fallBackRule.remove("Tahoma")

	#És a megadott tartományra vonatkozó szabályok frissítése
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#Továbbá eltávolíthatunk bármely meglévő szabályt a listáról
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Kész szabálykészlet hozzárendelése a használathoz
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendering of thumbnail with using of initialized rules collection and saving to PNG
	# Bélyegkép renderelése az inicializált szabálykészlet használatával és PNG-be mentés
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert color="primary" %}} 
Olvasson többet arról, hogyan [PowerPoint diák PNG formátumba konvertálása Pythonban](/slides/hu/python-net/convert-powerpoint-to-png/).
{{% /alert %}}