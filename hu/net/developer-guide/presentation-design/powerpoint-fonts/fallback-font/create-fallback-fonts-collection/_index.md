---
title: Visszaeső betűkészlet-gyűjtemények konfigurálása .NET-ben
linktitle: Visszaeső betűkészlet-gyűjtemény
type: docs
weight: 20
url: /hu/net/create-fallback-fonts-collection/
keywords:
- visszaeső betűtípus
- visszaeső szabály
- betűkészlet-gyűjtemény
- betűkészlet konfigurálása
- betűkészlet beállítása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Állítson be egy visszaeső betűkészlet-gyűjteményt az Aspose.Slides .NET-ben, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy visszaeső betűkészlet szabályok gyűjteményét konfigurálja egy prezentációhoz. Minden visszaeső szabályt a `FontFallBackRule` osztály képvisel, és hozzáadható egy `FontFallBackRulesCollection`-hez, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelheti a prezentáció `FontsManager`-ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példány saját `FontsManager`-rel rendelkezik.

Miután a `FontsManager` inicializálva van a visszaeső betűkészlet-gyűjteménnyel, a megadott visszaeső betűkészletek a prezentáció renderelése során érvényesülnek.

## **Alkalmazza a visszaeső szabályokat**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/net/aspose.slides/FontFallBackRule) osztály példányai rendezhetők egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontfallbackrulescollection) gyűjteménybe, amely megvalósítja az [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ifontfallbackrulescollection) interfészt. Lehet szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután ez a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) tulajdonságához a [FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsmanager) osztályban. A FontsManager kezeli a betűtípusokat a teljes prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) rendelkezik egy [FontsManager](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/properties/fontsmanager) tulajdonsággal, amely saját FontsManager példányt tartalmaz.

Az alábbi példák bemutatják, hogyan hozhat létre visszaeső betűkészlet szabályok gyűjteményét, és hogyan rendelheti hozzá egy adott prezentáció FontsManager-éhez:  

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

Miután a FontsManager inicializálva van a visszaeső betűkészlet-gyűjteménnyel, a visszaeső betűkészletek a prezentáció renderelése során alkalmazásra kerülnek.

{{% alert color="info" %}} 
További információ: [Prezentáció renderelése visszaeső betűtípussal](/slides/hu/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Gyakran Ismételt Kérdések**

### Be lesznek ágyazva a visszaeső szabályaim a PPTX fájlba, és láthatóak lesznek a PowerPointban mentés után?

Nem. A visszaeső szabályok futásidejű renderelési beállítások; nem sorosítódnak a PPTX-be, és nem jelennek meg a PowerPoint felhasználói felületén.

### Alkalmazható a visszaesés a SmartArt, WordArt, diagramok és táblázatok szövegére?

Igen. Az ugyanaz a glifcsere-működés használatos bármely szöveghez ezekben az objektumokban.

### Közöl-e az Aspose bármilyen betűkészletet a könyvtárral?

Nem. Önnek kell betűkészleteket hozzáadnia és használnia, saját felelősségére.

### Használható együtt a hiányzó betűkészletek helyettesítése/cseréje és a hiányzó glifek visszaeső betűtípusa?

Igen. Ezek a betűkészlet-felbontási csővezeték független lépései: először a motor feloldja a betűkészlet elérhetőségét ([replacement](/slides/hu/net/font-replacement/)/[substitution](/slides/hu/net/font-substitution/)), majd a visszaeső betűtípus kitölti a hiányzó glifek részeit az elérhető betűkészletekben.