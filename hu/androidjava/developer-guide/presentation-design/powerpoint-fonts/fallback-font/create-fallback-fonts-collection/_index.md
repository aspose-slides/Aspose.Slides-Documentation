---
title: Fallback betűtípus-gyűjtemények konfigurálása Androidon
linktitle: Fallback betűtípus gyűjtemény
type: docs
weight: 20
url: /hu/androidjava/create-fallback-fonts-collection/
keywords:
- fallback betűtípus
- fallback szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állíts be egy fallback betűtípus-gyűjteményt az Androidra szánt Aspose.Slides-ben Java segítségével, hogy a szöveg konzisztens és éles legyen a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy gyűjteményt konfiguráljon tartalék betűtípus szabályokról egy prezentációhoz. Minden tartalék szabályt a `FontFallBackRule` osztály képvisel, és hozzáadható egy `FontFallBackRulesCollection`-höz, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelhető a prezentáció `FontsManager`‑ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példány saját `FontsManager`‑rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűtípus-gyűjteménnyel, a megadott tartalék betűtípusok alkalmazásra kerülnek a prezentáció renderelése során.

## **Tartalék szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztály példányai rendezhetők egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection) gyűjteménybe, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFontFallBackRulesCollection) interfészt. A szabályok hozzáadása vagy eltávolítása a gyűjteményből lehetséges.

Ezután a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection) metódusához a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) osztályban. A FontsManager kezeli a betűtípusokat a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--) metódussal, amely saját példánnyal rendelkezik a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) osztályból.

Az alábbiakban egy példa látható arra, hogyan hozhat létre tartalék betűtípus szabályok gyűjteményét, és hogyan rendelheti hozzá egy adott prezentáció [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--)‑éhez:

```java
import com.aspose.slides.*;

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

Miután a FontsManager inicializálásra kerül a tartalék betűtípus-gyűjteménnyel, a tartalék betűtípusok alkalmazásra kerülnek a prezentáció renderelése során.

{{% alert color="info" %}} 
További információ: hogyan [Render Presentation with Fallback Font](/slides/hu/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

### A tartalék szabályok be lesznek ágyazva a PPTX fájlba, és láthatóak lesznek a PowerPointban a mentés után?

Nem. A tartalék szabályok futási időben történő renderelési beállítások; nem kerülnek sorosításra PPTX-be, és nem jelennek meg a PowerPoint felhasználói felületén.

### A tartalék betűtípusok érvényesek-e a SmartArt, WordArt, diagramok és táblázatok szövegére?

Igen. Ugyanazt a glif-helyettesítési mechanizmust használják ezekben az objektumokban lévő szövegekre is.

### Az Aspose terjeszt-e betűtípusokat a könyvtárral együtt?

Nem. A betűtípusokat saját maga adja hozzá és használja, saját felelősségére.

### Használható együtt a helyettesítés/helyettesítő betűtípusok és a hiányzó glifekhez tartozó tartalék betűtípus?

Igen. Ezek a betűtípus-felbontási folyamat független szakaszai: először a motor feloldja a betűtípus elérhetőségét ([replacement](/slides/hu/androidjava/font-replacement/)/[substitution](/slides/hu/androidjava/font-substitution/)), majd a tartalék betűtípus kitölti a hiányzó glifek lyukait az elérhető betűtípusokban.