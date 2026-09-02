---
title: .NET-ben a szkript-specifikus téma betűkészletek kezelése
linktitle: Szkript-specifikus téma betűkészletek
type: docs
weight: 15
url: /hu/net/script-specific-font-mappings/
keywords:
- szkript-specifikus betűkészlet
- téma betűkészlet leképezés
- többnyelvű prezentáció
- írásrendszer
- Cirill betűkészlet
- Arab betűkészlet
- Japán betűkészlet
- Grúz betűkészlet
- Thaana betűkészlet
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Vizsgálja, adjon hozzá, cseréljen ki és távolítson el szkript-specifikus betűkészlet-leképezéseket a PowerPoint témákban az Aspose.Slides .NET verziójával."
---
## **Áttekintés**

A prezentáció témája különböző betűcsaládokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűkészleteit használja, egy koordinált betűtípus‑sémát kövessen, miközben megfelelő betűkészleteket használ a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez.

A téma [IFontScheme](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/ifontscheme/) egy fő betűkészlet‑gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, és egy mellék betűkészlet‑gyűjteményt, amelyet általában a törzsszöveghez használnak. A latin és kelet‑ázsiai betűkészlet‑tulajdonságaik mellett mindkét gyűjtemény térképeket (mapping) tesz elérhetővé az írásrendszer‑címkék és a betűcsalád‑nevek között a [IFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/ifonts/) felületen keresztül.

Ez a cikk bemutatja, hogyan lehet megvizsgálni és módosítani ezeket a leképezéseket a prezentáció master‑témájában, valamint ellenőrizni, hogy a változások megmaradnak‑e egy mentés‑ és újratöltés‑ciklus után.

## **A szkriptcímkék megértése**

A szkriptbetűkészlet‑módszerek négybetűs BCP 47 szkript‑alalcímkéket használnak az írásrendszerek azonosítására. A gyakori értékek a következők:

| Szkriptcímke | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűkészlet‑sémához tartoznak, nem az egyes szövegrészekhez. Egy prezentáció meghatározhat különböző leképezéseket a fő és a mellék gyűjteményekhez, és bizonyos szkriptekhez kihagyhatja a leképezést.

## **A szkriptbetűk leképezéseinek elérése és vizsgálata**

Használja a [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) elemet a prezentáció szintű téma eléréséhez. A [FontScheme.Major](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.Minor](https://reference.aspose.com/slides/hu/net/aspose.slides.theme/fontscheme/minor/) tulajdonságok adják vissza a két [IFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/ifonts/) gyűjteményt.

Hívja meg a [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/getscriptfontmap/) metódust, hogy lekérje az összes leképezést egy gyűjteményből. Egy írásrendszer kereséséhez hívja meg a [IFonts.GetScriptFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/getscriptfont/) metódust a szkriptcímkével. A `GetScriptFont` `null` értéket ad vissza, ha az adott gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja a [IFonts.SetScriptFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/setscriptfont/) metódust egy leképezés létrehozásához vagy a jelenlegi betűcsalád helyettesítéséhez. A [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/removescriptfont/) segítségével eltávolíthat egy leképezést.

Az alábbi végponttól‑végpontig terjedő példa beolvassa az összes meglévő fő és mellék leképezést, lekéri a japán fő betűtípust, módosítja a cirill fő betűtípust, eltávolítja a thaana mellék leképezést, menti a prezentációt, és újranyitja azt a változások ellenőrzéséhez. Az eltávolítási lépés függetlené tételéhez a kiinduló témától, a példa csak akkor hoz létre thaana leképezést, ha az még nincs definiálva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Az ellenőrzés ugyanazt a `null` viselkedést használja, mint egy szokásos lekérdezés: a törlés mentése után a `GetScriptFont("Thaa")` `null` értéket ad vissza a mellék gyűjteményre.

## **A téma leképezéseinek megkülönböztetése más betűkészlet‑beállításoktól**

A szkript‑specifikus téma leképezések részt vesznek a betűkészlet‑kiválasztásban, de más problémát oldanak meg, mint a közvetlen szövegformázás, helyettesítés és visszatérő (fallback) megoldás:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Szkript‑specifikus téma betűkészlet‑leképezés | Kiválaszt egy fő vagy mellék téma‑betűkészletet egy írásrendszerhez. | A szöveg, amely továbbra is a megfelelő téma‑betűkészletet használja, az új leképezett családra vonatkozhat. |
| Közvetlenül a szövegrészhez hozzárendelt betűkészlet | Az adott részre rögzíti a kért betűcsaládot a téma helyett. | A rész változatlan maradhat, mivel a közvetlen formázás felülírja a téma választását. |
| Betűkészlet‑helyettesítés | Lecseréli a kért betűkészletet, ha az nem elérhető, vagy ha egy helyettesítési szabály érvényesül. | A kérést követően működik; nem definiálja újra a téma szkript‑leképezését. |
| Betűkészlet‑visszatérés | Olyan glyph-eket biztosít, amelyeket a kiválasztott betűkészlet nem tartalmaz, gyakran bizonyos Unicode‑tartományokhoz. | Kitölti a hiányzó glyph‑lefedettséget; nem módosítja a tárolt téma leképezést. |

További információért az utolsó két mechanizmusról lásd a [Betűkészlet‑helyettesítés](/slides/hu/net/font-substitution/) és a [Visszatérő betűkészletek](/slides/hu/net/fallback-font/) részeket.

A [Presentation.MasterTheme](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/mastertheme/) leképezésének módosítása csak azokra a tartalmakra van hatással, amelyek hatékony formázása még mindig attól a témától függ. A szöveg helyette örökölhet téma‑felülírást egy master‑től, elrendezéstől vagy diától, vagy használhat közvetlenül hozzárendelt betűkészletet. Vizsgálja meg ezeket a szinteket, ha a látható eredmény nem követi a prezentáció‑szintű leképezést.

## **A leképezett betűkészletek elérhetővé tétele és az eredmény ellenőrzése**

A szkript leképezés csak a betűcsalád nevét tárolja; nem telepíti vagy tölti be a megfelelő betűkészlet‑fájlt. Az egységes megjelenítéshez és exportáláshoz minden leképezett betűkészletet telepíteni kell a környezetben, vagy átadni az Aspose.Slides‑nek egy egyedi forráson keresztül, például a [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/hu/net/aspose.slides/fontsloader/loadexternalfonts/) vagy a [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/documentlevelfontsources/) segítségével. A rendelkezésre álló betöltési lehetőségekért lásd a [Egyedi betűkészletek](/slides/hu/net/custom-font/) oldalt.

A mentett leképezés ellenőrzése csak azt erősíti meg, hogy a téma definíciója megmaradt. Nem bizonyítja, hogy a betűkészlet elérhető, tartalmazza az összes szükséges glyph‑et, vagy a kívánt elrendezést hozza létre. Generáljon reprezentatív szöveget minden szükséges írásrendszerhez egy képre vagy PDF‑re, és vizsgálja meg a kimenetet. Így felderíthetőek a hiányzó betűkészletek, a nem teljes glyph‑lefedettség, a visszatérési viselkedés és az elrendezés‑változások, mielőtt a prezentációt terjesztenék. A renderelési és exportálási példákért lásd a [PowerPoint‑prezentációk konvertálása](/slides/hu/net/convert-powerpoint/) oldalt.

## **GYIK**

**Mi a `GetScriptFont` visszatérési értéke, ha egy szkript nincs leképezve?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/getscriptfont/) `null` értéket ad vissza, ha a kért szkript leképezés nincs definiálva az adott fő vagy mellék betűkészlet‑gyűjteményben.

**A `SetScriptFont` hozzáad egy második leképezést, ha a szkript már létezik?**

Nem. A [IFonts.SetScriptFont](https://reference.aspose.com/slides/hu/net/aspose.slides/fonts/setscriptfont/) akkor hoz létre leképezést, ha hiányzik, és a már meglévő szkriptcímke esetén felülírja a leképezett betűcsaládot.

**Miért nem változott meg egyes szövegek a téma leképezés módosítása után?**

A szöveg lehet, hogy közvetlenül hozzárendelt betűkészlettel rendelkezik, egy felülíráson keresztül másik témát örököl, vagy a renderelés során helyettesítés vagy visszatérés befolyásolja. Egy prezentáció‑szintű szkript leképezés csak azokra a szövegekre van hatással, amelyek hatékony formázása még mindig az adott téma betűkészlet‑gyűjteményre hivatkozik.

**Elég a mentés és újranyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újranyitás csak a téma adatainak megmaradását ellenőrzi. Emellett generáljon reprezentatív szöveget minden szükséges írásrendszerből, hogy megerősítse, hogy a leképezett betűkészletek elérhetők és tartalmazzák a szükséges glyph‑eket.