---
title: Betűtípus kiválasztási sorozat az Aspose.Slides .NET-ben
linktitle: Betűtípus kiválasztás
type: docs
weight: 80
url: /hu/net/font-selection-sequence/
keywords:
- betűtípus kiválasztás
- betűtípus helyettesítés
- betűtípus csere
- helyettesítési szabály
- elérhető betűtípus
- hiányzó betűtípus
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan választja ki az Aspose.Slides .NET a betűtípusokat, biztosítva a PPT, PPTX és ODP fájlok éles és következetes megjelenítését – javítsa most diáinak minőségét."
---
## **Áttekintés**

Amikor egy prezentáció betöltődik, megjelenik vagy más formátumba konvertálódik, az Aspose.Slides figyelembe veszi a beágyazott betűtípusokat és az alkalmazás számára elérhető betűtípusokat. Ha egy szükséges betűtípus nem áll rendelkezésre, az Aspose.Slides egy helyettesítő betűtípust választ, amely a lehető legközelebb áll ahhoz, amit a PowerPoint használna.

Elérhető betűtípusok lehetnek rendszerbetűtípusok, az alkalmazás által betöltött betűtípusok és a prezentációba beágyazott betűtípusok. A megfelelő beágyazott és regisztrált betűtípus esetén az alább leírt .NET 26.11 beállítás szabályozza, melyik kap prioritást. A [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) által definiált betűtípus helyettesítési szabályok külön mechanizmus.

Betűtípusokat is hozzáadhat az alkalmazás futási idejében, használhat beágyazott betűtípusokat egy prezentációból, vagy betölthet külső betűtípusokat a kimeneti dokumentumokhoz, például PDF fájlokhoz.

## **Betűtípus kiválasztása**

A szöveg hivatkozhat egy témabetűtípusra, például `+mn-lt`, az explicit családnév helyett. Lásd a [Témabetűtípus‑hivatkozások feloldása](/slides/hu/net/presentation-theme/#resolve-theme-font-references) oldalt a vonatkozó téma által meghatározott család lekéréséhez. Ennek a hivatkozásnak a feloldása különálló a betűtípus elérhetőségének ellenőrzésétől és a renderelés közbeni helyettesítés vagy jel helyettesítés alkalmazásától; nem határozza meg a szöveg megjelenítéséhez végül használt betűtípusfájlt.

Dia renderelésekor vagy egy prezentáció konvertálásakor ellenőrizze, hogy a kért betűtípusok be vannak-e ágyazva vagy elérhetők a regisztrált forrásokból. Hiányzó betűtípusok cserét vagy helyettesítést igényelhetnek; lásd a [**Betűtípus helyettesítés**](/slides/hu/net/font-replacement/) és a [**Betűtípus helyettesítés**](/slides/hu/net/font-substitution/) oldalakat.

Betűtípus kiválasztásának vizsgálatakor:

1. Oldja fel a kért családot és stílust, beleértve a témahivatkozást is.
2. Ellenőrizze a beágyazott betűtípusokat és a regisztrált forrásokat, beleértve a rendszerbetűtípusokat és az alkalmazás által betöltött betűtípusokat. Használja az alábbi beállítást, ha a beágyazott és regisztrált verziók versengenek.
3. Tekintse át a [betűtípus helyettesítési szabályok](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) és a jel helyettesítést, ha a kért betűtípus vagy karakterek nem állnak rendelkezésre.

Az Aspose.Slides lehetővé teszi, hogy betűtípusokat adjon hozzá az alkalmazás futási idejében, és ezután használja azokat. Lásd a [**Egyéni betűtípusok**](/slides/hu/net/custom-font/) oldalt.

Ha további betűtípusok kerülnek egy prezentációba, azokat [**Beágyazott betűtípusok**](/slides/hu/net/embedded-font/) néven hívják.

Az Aspose.Slides lehetővé teszi, hogy olyan betűtípusokat adjon hozzá, amelyek csak a kimeneti dokumentumokra vonatkoznak. Például, ha egy PDF‑re konvertálni kívánt prezentáció betűtípusokkal rendelkezik, amelyek hiányoznak a rendszerről és a beágyazott betűtípusok közül, akkor a szükséges betűtípusokat **külső betűtípusok**‑ként adhatja hozzá vagy töltheti be.

{{% alert title="Note" color="info" %}} 
Nem terjesztünk semmilyen betűtípust, sem fizetett, sem ingyenes. Az API‑nk lehetővé teszi külső betűtípusok betöltését és azok dokumentumokba ágyazását, de ezt saját belátására és felelősségére teszi.
{{% /alert %}}

## **Regisztrált betűtípusok előnyben részesítése a beágyazott betűtípusok felett**

A .NET 26.11‑től kezdve a [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) lehetővé teszi, hogy a megfelelő regisztrált betűtípus előnyt élvezzen a beágyazott betűtípus felett az export során. Az alapértelmezett érték `false`. A egyezés a betűtípus nevére és stílusára épül; egy eltérő családnév nem minősül helyettesítő egyezésnek. A regisztrált betűtípusok származhatnak a rendszerből vagy [kifejezetten betöltött betűtípus források](/slides/hu/net/custom-font/).

Az alábbi példa a **Aspose.Slides.NET6.CrossPlatform 26.11** csomagot használja .NET 8-on. Kövesse a [telepítési útmutató](/slides/hu/net/installation/) a környezetéhez. Adja meg az `embedded-fonts.pptx` fájlt beágyazott betűtípussal, valamint a `preferred.ttf` fájlt ugyanazzal a családnévvel és stílussal. A két betűtípus‑fájlnak láthatóan eltérnie kell, ha az eredményt össze szeretné hasonlítani.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Ez a beállítás módosítja a betűtípus precedenciát az export során; nem nevez át a szöveg betűtípusát, nem távolítja el a beágyazott betűtípus adatokat, és nem ágyazza be újra a regisztrált fájlt. Ez egy futási időbeli beállítás: nyissa meg újra a prezentációt, majd állítsa be újra. Ha nincs megfelelő regisztrált betűtípus, a beállítás engedélyezése nem biztosít ilyet; ellenőrizze a végső betűtípust és elrendezést a célkörnyezetben.

A fenti konfigurációra a kifejezetten betöltött normál betűtípusokkal készült PNG és PDF kimenetek ellenőrzésre kerültek. Ellenőrizze saját betűtípusfájljait, stílusait, SDK buildjét és a kimeneti formátumokat, mielőtt azonos eredményeket várna. A betűtípus‑metrikák megváltoztathatják a sortöréseket és a pozicionálást. Használja a [betűtípus helyettesítés](/slides/hu/net/font-replacement/) vagy a [helyettesítés](/slides/hu/net/font-substitution/) oldalt, ha más családra van szüksége, és a [beágyazott betűtípus műveletek](/slides/hu/net/embedded-font/) oldalt, ha a prezentációban tárolt betűtípusokat szeretné módosítani.

## **GYIK**

**Hogyan határozhatom meg, hogy egy prezentációban a konverzió előtt mely betűtípusok vannak ténylegesen használatban?**

Az Aspose.Slides lehetővé teszi, hogy a [betűtípus menedzser](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) segítségével megvizsgálja a használt betűtípusokat, így eldöntheti, hogy [beágyazás](/slides/hu/net/embedded-font/), [helyettesítés](/slides/hu/net/font-replacement/) vagy [külső források](/slides/hu/net/custom-font/) hozzáadja-e. Ez segít elkerülni a nem kívánt helyettesítéseket a renderelés és az export során.

**Hozzáadhatok extra betűtípus könyvtárakat anélkül, hogy telepíteném őket az operációs rendszerben?**

Igen. Regisztrálhat [külső betűtípus források](/slides/hu/net/custom-font/) olyan módon, mint mappák vagy memória‑folyamok a rendereléshez és exporthoz. Ez eltávolítja a függőséget a gazda rendszer betűtípusaitól és előre jelezhető elrendezést biztosít.

**Hogyan akadályozhatom meg a csendes visszalépést egy nem megfelelő betűtípusra, ha egy jel hiányzik?**

Határozzon meg explicit [betűtípus helyettesítés](/slides/hu/net/font-replacement/) és betűtípus [visszalépési szabályok](/slides/hu/net/fallback-font/) előre. A használt betűtípusok elemzésével és a helyettesítők kontrollált prioritásának beállításával biztosíthatja a konzisztens tipográfiát és elkerülheti a váratlan eredményeket.