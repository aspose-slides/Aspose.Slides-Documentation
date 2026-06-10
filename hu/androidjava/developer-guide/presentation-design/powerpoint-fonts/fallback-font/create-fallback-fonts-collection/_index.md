---
title: Androidon a tartalék betűtípus-gyűjtemények konfigurálása
linktitle: Tartalék betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/androidjava/create-fallback-fonts-collection/
keywords:
- tartalék betűtípus
- tartalék szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Állítsa be a tartalék betűtípus-gyűjteményt az Aspose.Slides for Androidban Java segítségével, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy konfiguráljon egy tartalék betűtípus szabályok gyűjteményét egy prezentációhoz. Minden tartalék szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hez, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelheti a prezentáció `FontsManager`-ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példánynak a saját `FontsManager`-e van.

Miután a `FontsManager` a tartalék betűtípus-gyűjteménnyel inicializálódik, a megadott tartalék betűtípusok a prezentáció renderelése során kerülnek alkalmazásra.

## **Tartalék szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRule) osztály példányait úgy lehet rendezni, hogy egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection)-ba kerüljenek, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFontFallBackRulesCollection) interfészt. Lehetséges szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután ez a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontFallBackRulesCollection) metódushoz a [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) osztályban. A FontsManager kezeli a betűtípusokat a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--) metódussal, amelynek saját [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FontsManager) példánya van.

Itt egy példa arra, hogyan hozhat létre tartalék betűtípus szabályok gyűjteményét, és hogyan adja hozzá a bizonyos prezentáció [FontsManager](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getFontsManager--) osztályához:  

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

Miután a FontsManager a tartalék betűtípus-gyűjteménnyel inicializálódik, a tartalék betűtípusok a prezentáció renderelése során kerülnek alkalmazásra.

{{% alert color="primary" %}} 
Olvassa el, hogyan [Render Presentation with Fallback Font](/slides/hu/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beágyazódnak a tartalék szabályaim a PPTX fájlba, és láthatóak lesznek a PowerPointban a mentés után?**

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem sorosítódnak be a PPTX‑be, és nem jelennek meg a PowerPoint felhasználói felületén.

**Alkalmazódik a tartalék a SmartArt, WordArt, diagramok és táblázatok szövegére?**

Igen. Ugyanazt a glif‑helyettesítési mechanizmust használják ezekben az objektumokban a szöveghez.

**Terjeszti‑e az Aspose a betűtípusokat a könyvtárral?**

Nem. A betűtípusokat saját magának kell hozzáadni és használni, saját felelősségére.

**Használhatók együtt a hiányzó betűtípusok cseréje/helyettesítése és a hiányzó glifek tartalékja?**

Igen. Ezek a betűtípus‑felbontási folyamat független szakaszai: először a motor feloldja a betűtípusok elérhetőségét ([replacement](/slides/hu/androidjava/font-replacement/)/[substitution](/slides/hu/androidjava/font-substitution/)), majd a tartalék kitölti a hiányzó glifekből adódó hiányosságokat az elérhető betűtípusokban.