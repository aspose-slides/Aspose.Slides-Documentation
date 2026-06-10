---
title: Tartalék betűkészlet-gyűjtemények konfigurálása Java-ban
linktitle: Tartalék betűkészlet-gyűjtemény
type: docs
weight: 20
url: /hu/java/create-fallback-fonts-collection/
keywords:
- tartalék betűkészlet
- tartalék szabály
- betűkészlet-gyűjtemény
- betűkészlet konfigurálása
- betűkészlet beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Állítson be egy tartalék betűkészlet-gyűjteményt az Aspose.Slides for Java-ban, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz tartalék betűkészlet-szabályok gyűjteményét konfigurálja. Minden tartalék szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hez, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelheti a prezentáció `FontsManager`-ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` kezeli a betűkészleteket a prezentációban, és minden `Presentation` példány saját `FontsManager`-rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűkészlet-gyűjteménnyel, a megadott tartalék betűkészletek a prezentáció renderelése során kerülnek alkalmazásra.

## **Tartalék szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztály példányai szervezhetők a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) gyűjteménybe, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFontFallBackRulesCollection) interfészt. A szabályok hozzáadása vagy eltávolítása a gyűjteményből lehetséges.

Ezután ez a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) metódushoz a [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) osztályban. A FontsManager kezeli a betűkészleteket a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--) metódussal, amelynek saját [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) példánya van.

Az alábbi példa bemutatja, hogyan hozhat létre tartalék betűkészlet-szabályok gyűjteményét, és hogyan rendelheti hozzá egy adott prezentáció [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--) osztályához:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Miután a FontsManager inicializálva van a tartalék betűkészlet-gyűjteménnyel, a tartalék betűkészletek a prezentáció renderelése során kerülnek alkalmazásra.

{{% alert color="primary" %}} 
Olvassa el, hogyan [Prezentáció renderelése tartalék betűkészlettel](/slides/hu/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beágyazódnak-e a tartalék szabályaim a PPTX fájlba, és láthatók lesznek a PowerPointban mentés után?**

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem kerülnek sorosításra a PPTX-be, így nem jelennek meg a PowerPoint felületén.

**Alkalmazódik-e a tartalék betűkészlet a SmartArt, WordArt, diagramok és táblázatok szövegére?**

Igen. Ugyanaz a glyph-helyettesítési mechanizmus használatos bármely ilyen objektumban lévő szöveghez.

**Közöl-e az Aspose bármilyen betűkészletet a könyvtárral?**

Nem. A betűkészleteket saját oldalán adja hozzá és használja, saját felelősségére.

**Használható-e együtt a hiányzó betűkészletek helyettesítése vagy felcserélése a hiányzó glyphok tartalék megoldásával?**

Igen. Ezek a betűkészlet-felbontás ugyanazon csővezetékének független szakaszai: először a motor feloldja a betűkészlet elérhetőségét ([replacement](/slides/hu/java/font-replacement/)/[substitution](/slides/hu/java/font-substitution/)), majd a tartalék betűkészlet pótolja a hiányzó glyphokat az elérhető betűkészletekben.