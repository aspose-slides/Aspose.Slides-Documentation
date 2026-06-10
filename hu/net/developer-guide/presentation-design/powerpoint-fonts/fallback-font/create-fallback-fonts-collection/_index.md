---
title: Fallback betűtípusgyűjtemények konfigurálása .NET-ben
linktitle: Fallback betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/net/create-fallback-fonts-collection/
keywords:
- fallback betűtípus
- fallback szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Állítson be egy fallback betűtípus-gyűjteményt az Aspose.Slides .NET verziójában, hogy a szöveg konzisztens és tiszta maradjon a PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy tartalék betűtípus szabályok gyűjteményét konfigurálja egy bemutatóhoz. Minden tartalék szabályt a `FontFallBackRule` osztály képvisel, és a `FontFallBackRulesCollection`‑be adható hozzá, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelhető a bemutató `FontsManager`‑ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` kezeli a betűtípusokat a teljes bemutatóban, és minden `Presentation` példány saját `FontsManager`‑rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűtípusok gyűjteményével, a megadott tartalék betűtípusok a bemutató renderelése során kerülnek alkalmazásra.

## **Tartalék szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztály példányai szervezhetők a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection) gyűjteménybe, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontfallbackrulescollection) interfészt. A szabályok hozzáadhatók vagy eltávolíthatók a gyűjteményből.

Ezután a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection ](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) tulajdonsághoz a [FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager) osztályban. A FontsManager kezeli a betűtípusokat a bemutatóban.

Minden [Presentation ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) rendelkezik egy [FontsManager ](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/fontsmanager) tulajdonsággal, amely saját FontsManager példányt tartalmaz.

Az alábbi példa bemutatja, hogyan hozhat létre tartalék betűtípus szabályok gyűjteményét, és hogyan rendeli hozzá egy adott bemutató FontsManager‑éhez:

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Miután a FontsManager inicializálva van a tartalék betűtípusok gyűjteményével, a tartalék betűtípusok a bemutató renderelése során kerülnek alkalmazásra.

{{% alert color="primary" %}} 
Olvassa el, hogyan [Render Presentation with Fallback Font](/slides/hu/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beágyazódnak a tartalék szabályok a PPTX fájlba, és láthatóak lesznek a PowerPointban a mentés után?**

Nem. A tartalék szabályok futás‑időbeni renderelési beállítások; nem sorosítódnak a PPTX‑be, ezért nem jelennek meg a PowerPoint felhasználói felületén.

**A tartalék szabályok vonatkoznak a SmartArt, WordArt, diagramok és táblázatok szövegére is?**

Igen. Ugyanazt a glif‑helyettesítési mechanizmust használják minden ilyen objektum szövegére.

**Az Aspose terjeszt-e betűtípusokat a könyvtárral?**

Nem. A betűtípusok hozzád és a te felelősségedre kerülnek.

**Használhatók együtt a hiányzó betűtípusok helyettesítése/substitúciója és a hiányzó glifek tartalékként történő kezelése?**

Igen. Önmagukban független lépések ugyanabban a betűtípus‑feloldási folyamatban: először a motor feloldja a betűtípus elérhetőségét ([replacement](/slides/hu/net/font-replacement/)/[substitution](/slides/hu/net/font-substitution/)), majd a tartalék kitölti a hiányzó glifekhez szükséges hézagokat az elérhető betűtípusokban.