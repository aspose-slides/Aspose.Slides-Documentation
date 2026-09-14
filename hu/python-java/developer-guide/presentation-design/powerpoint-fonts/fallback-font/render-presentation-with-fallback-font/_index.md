---
title: Bemutatók renderelése fallback betűkészletekkel Pythonon keresztül Java segítségével
linktitle: Bemutatók renderelése
type: docs
weight: 30
url: /hu/python-java/render-presentation-with-fallback-font/
keywords:
- fallback betűkészlet
- PowerPoint renderelése
- prezentáció renderelése
- dia renderelése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Renderelje a bemutatókat fallback betűkészletekkel az Aspose.Slides Python változatban Java segítségével – tartsa a szöveget konzisztensnek a PPT, PPTX és ODP formátumok között lépésről‑lépésre Python kódmintákkal."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy a prezentációkat fallback betűkészlet szabályokkal renderelje. Ez a cikk bemutatja, hogyan hozhat létre egy fallback betűkészlet szabályok gyűjteményét, hogyan módosíthatja annak szabályait egy fallback betűkészlet eltávolításával vagy hozzáadásával, valamint hogyan rendeli hozzá a gyűjteményt a [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) metódussal.

Miután a fallback betűkészlet szabályok gyűjteményét hozzárendelték a bemutató [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) objektumához, a szabályok a mentés, renderelés és a prezentáció átalakítása során kerülnek alkalmazásra. A példa bemutatja, hogyan használhatók a konfigurált szabályok egy dia bélyegképének renderelésekor és JPEG képként való mentésekor.

## **Dia renderelése fallback betűkészlet szabályokkal**

Az alábbi példa a következő lépéseket tartalmazza:

1. [Hozzon létre egy fallback betűkészlet szabályok gyűjteményét](/slides/hu/python-java/create-fallback-fonts-collection/).
1. [Távolítson el](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/#remove) egy fallback betűkészletet egy szabályból, és [adjon hozzá fallback betűkészleteket](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) egy másik szabályhoz.
1. Rendelje hozzá a szabályok gyűjteményét a [setFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) metódussal a [getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) által visszaadott betűkészlet-kezelőhöz.
1. Használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a prezentáció mentéséhez ugyanabban vagy más formátumban. Miután a fallback betűkészlet szabályok gyűjteményét hozzárendelték a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) objektumhoz, ezek a szabályok a prezentáción végzett műveletek során alkalmazásra kerülnek: mentés, renderelés, átalakítás stb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Hozzon létre egy új szabálygyűjteményt.
fallback_rules = FontFallBackRulesCollection()

# Hozzon létre több szabályt.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Próbálja meg eltávolítani a "Tahoma" fallback betűkészletet a szabályokból.
    fallback_rule.remove("Tahoma")

    # Frissítse a szabályokat a megadott tartományra.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Távolítson el egy meglévő szabályt, úgy hogy legalább egy szabály megmaradjon a rendereléshez.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Rendelje hozzá az előkészített szabálygyűjteményt.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Készítsen bélyegképet a konfigurált szabálygyűjtemény használatával.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Mentse a képet lemezre JPEG formátumban.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Megjegyzés" %}}
Olvassa el, hogyan [konvertálhatja a PPT és PPTX fájlokat JPG formátumba Pythonon keresztül Java használatával](/slides/hu/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}