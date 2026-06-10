---
title: Helyettesítő betűtípus gyűjtemények konfigurálása JavaScriptben
linktitle: Helyettesítő betűtípus gyűjtemény
type: docs
weight: 20
url: /hu/nodejs-java/create-fallback-fonts-collection/
keywords:
- helyettesítő betűtípus
- helyettesítő szabály
- betűtípus gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Állítson be egy helyettesítő betűtípus-gyűjteményt JavaScriptben az Aspose.Slides for Node.js segítségével, hogy a szöveg konzisztens és tiszta legyen a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz beállítson egy helyettesítő betűtípus szabályok gyűjteményét. Minden helyettesítő szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hez.

A gyűjtemény létrehozása után hozzárendelheti a prezentáció `FontsManager`-ének `setFontFallBackRulesCollection` metódusával. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példánynak saját `FontsManager`-e van.

Miután a `FontsManager` inicializálva van a helyettesítő betűtípus-gyűjteménnyel, a megadott helyettesítő betűtípusok a prezentáció renderelése során kerülnek alkalmazásra.

## **Helyettesítő szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRule) osztály példányai rendezhetők egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRulesCollection) gyűjteménybe, amely megvalósítja a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRulesCollection) osztályt. Lehet szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután ez a gyűjtemény a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager) osztály [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontFallBackRulesCollection) metódusához rendelhető. A FontsManager kezeli a betűtípusokat a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getFontsManager--) metódussal, amely saját példányt tartalmaz a [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/FontsManager) osztályból.

Az alábbi példák bemutatják, hogyan hozhat létre helyettesítő betűtípus szabályok gyűjteményét, és hogyan rendelheti hozzá egy adott prezentáció [FontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getFontsManager--) osztályához:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Miután a FontsManager inicializálva van a helyettesítő betűtípus-gyűjteménnyel, a helyettesítő betűtípusok a prezentáció renderelése során kerülnek alkalmazásra.

{{% alert color="primary" %}} 
További információk arról, hogyan [Render Presentation with Fallback Font](/slides/hu/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**A helyettesítő szabályaim be lesznek ágyazva a PPTX fájlba, és láthatóak lesznek a PowerPointban a mentés után?**

Nem. A helyettesítő szabályok futásidejű renderelési beállítások; nem kerülnek sorosítva a PPTX fájlba, és nem jelennek meg a PowerPoint felhasználói felületén.

**A helyettesítés érvényesül a SmartArt, WordArt, diagramok és táblázatok szövegeire is?**

Igen. Ugyanez a glifhelyettesítési mechanizmus használatos bármely szövegre ezekben az objektumokban.

**Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral?**

Nem. Önmaga adja hozzá és használja a betűtípusokat, saját felelősségére.

**Használható együtt a hiányzó betűtípusok helyettesítése/helyettesítése és a hiányzó glifek helyettesítése?**

Igen. Ezek a betűtípus-felbontási folyamat független szakaszai: először a motor megoldja a betűtípusok elérhetőségét ([replacement](/slides/hu/nodejs-java/font-replacement/)/[substitution](/slides/hu/nodejs-java/font-substitution/)), majd a helyettesítés kitölti a rendelkezésre álló betűtípusokban hiányzó glifek hiányát.