---
title: Tartalék betűtípus-gyűjtemények konfigurálása Pythonban Java segítségével
linktitle: Tartalék betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/python-java/create-fallback-fonts-collection/
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
- Java
- Aspose.Slides
description: "Állíts be egy tartalék betűtípus-gyűjteményt az Aspose.Slides számára Pythonban Java-n keresztül, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy gyűjteményt konfiguráljon a tartalék betűtípus szabályokhoz egy prezentációhoz. Minden tartalék szabályt a [FontFallBackRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/) osztály képviseli, és hozzáadható egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrulescollection/) gyűjteményhez.

A gyűjtemény létrehozása után a prezentáció [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztályának [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) metódusával rendelheted hozzá. A [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) kezeli a betűtípusokat a teljes prezentációban, és minden [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példánynak saját [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) példánya van.

Miután a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) inicializálva van a tartalék betűtípus-gyűjteménnyel, a megadott tartalék betűtípusok alkalmazásra kerülnek a prezentáció renderelése során.

## **Tartalék Szabályok Alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/) osztály példányai egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrulescollection/) gyűjteménybe szervezhetők. A szabályokat hozzáadhatod vagy eltávolíthatod a gyűjteményből.

Ez a gyűjtemény ezután a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztály [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) metódusával rendelhető hozzá, amely a prezentációban a betűtípusokat kezeli.

Minden [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) metódussal, amely visszaadja a saját [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) példányát.

Az alábbi példa bemutatja, hogyan hozhatsz létre egy tartalék betűtípus szabályok gyűjteményét, és rendeld hozzá egy prezentáció [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztályához:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

Miután a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) inicializálva van a tartalék betűtípus-gyűjteménnyel, a tartalék betűtípusok alkalmazásra kerülnek a prezentáció renderelése során.

{{% alert color="info" title="Note" %}}
További információ arról, hogyan [prezentáció renderelése tartalék betűtípussal](/slides/hu/python-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beázzák-e a tartalék szabályaim a PPTX fájlba, és láthatóak lesznek-e a PowerPointban mentés után?**

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem kerülnek sorosításra a PPTX-be, és nem fognak megjelenni a PowerPoint felhasználói felületén.

**Alkalmazódik-e a tartalék betűtípus a SmartArt, WordArt, diagramok és táblázatok szövegére?**

Igen. Ugyanaz a karakterhelyettesítési mechanizmus használatos minden szöveghez ezekben az objektumokban.

**Terjeszt-e az Aspose bármilyen betűtípust a könyvtárral?**

Nem. A betűtípusokat saját magad adod hozzá és használod, saját felelősségedre.

**Használható-e együtt a hiányzó betűtípusok helyettesítése/substitúciója és a hiányzó karakterek tartaléka?**

Igen. Ezek a betűtípus-felbontási csővezeték független szakaszai: először a motor megoldja a betűtípus elérhetőségét ([replacement](/slides/hu/python-java/font-replacement/)/[substitution](/slides/hu/python-java/font-substitution/)), majd a tartalék kitölti a hiányzó karaktereket az elérhető betűtípusokban.