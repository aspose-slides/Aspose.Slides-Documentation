---
title: Pythonban a tartalék betűtípus-gyűjtemények konfigurálása
linktitle: Tartalék betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/python-net/create-fallback-fonts-collection/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Állítson be egy tartalék betűtípus-gyűjteményt az Aspose.Slides for Python via .NET segítségével, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz konfiguráljon egy tartalék betűtípus szabályok gyűjteményét. Minden tartalék szabályt a `FontFallBackRule` osztály képvisel, és hozzáadható egy `FontFallBackRulesCollection`-hez.

A gyűjtemény létrehozása után hozzárendelheti a prezentáció `fonts_manager`-ének `font_fall_back_rules_collection` tulajdonságához. A `fonts_manager` kezeli a betűtípusokat az egész prezentációban, és minden `Presentation` példány saját `FontsManager`-rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűtípus gyűjteménnyel, a megadott tartalék betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

## **Tartalék Szabályok Alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/python-net/aspose.slides/FontFallBackRule/) osztály példányai szervezhetők egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontfallbackrulescollection/) gyűjteménybe. Lehetőség van szabályok hozzáadására vagy eltávolítására a gyűjteményből.

Ezután ez a gyűjtemény hozzárendelhető a [font_fall_back_rules_collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) tulajdonsághoz a [FontsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/) osztályban. A FontsManager kezeli a betűtípusokat a teljes prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) rendelkezik egy [fonts_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) tulajdonsággal, amely a FontsManager osztály saját példányát tartalmazza.

Itt egy példa arra, hogyan hozhat létre tartalék betűtípus szabályok gyűjteményét, és hogyan rendeli hozzá egy adott prezentáció FontsManager-éhez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

Miután a FontsManager inicializálva van a tartalék betűtípusok gyűjteményével, a tartalék betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

{{% alert color="primary" %}} 
További információ a [Prezentáció renderelése tartalék betűtípussal](/slides/hu/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beágyazódnak a tartalék szabályaim a PPTX fájlba, és láthatók lesznek a PowerPointban mentés után?**

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem sorosítódnak be a PPTX-be, és nem fognak megjelenni a PowerPoint felhasználói felületén.

**Alkalmazható a tartalék betűtípus a SmartArt, WordArt, diagramok és táblázatok szövegeire?**

Igen. Ugyanazt a glif‑helyettesítési mechanizmust használják minden ilyen objektumban lévő szöveghez.

**Terjeszti-e az Aspose a betűtípusokat a könyvtárral együtt?**

Nem. A betűtípusokat saját maga adja hozzá és használja, saját felelősségére.

**Használható együtt a hiányzó betűtípusok helyettesítése/substitúciója és a hiányzó glifek tartaléka?**

Igen. Független szakaszok a betűtípus‑feloldási folyamatban: először a motor feloldja a betűtípus elérhetőségét ([replacement](/slides/hu/python-net/font-replacement/)/[substitution](/slides/hu/python-net/font-substitution/)), majd a tartalék betöltése pótolja a hiányzó glifeket az elérhető betűtípusokban.