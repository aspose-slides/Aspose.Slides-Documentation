---
title: A szkript-specifikus téma betűtípusok kezelése C++-ban
linktitle: Szkript-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/cpp/script-specific-font-mappings/
keywords:
- szkript-specifikus betűtípus
- téma betűtípus leképezés
- többnyelvű prezentáció
- írásrendszer
- cirill betűtípus
- arab betűtípus
- japán betűtípus
- grúz betűtípus
- thaana betűtípus
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ellenőrizze, adja hozzá, cserélje ki és távolítsa el a szkript-specifikus betűtípus leképezéseket a PowerPoint témákban az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

A prezentációs téma különböző betűtípus‑családokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűtípusait használja, egységes betűtípus‑sémát kövessen, miközben a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez megfelelő betűtípusokat alkalmaz.

A téma [IFontScheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/ifontscheme/) egy fő (major) betűtípus‑gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, illetve egy mellék (minor) betűtípus‑gyűjteményt a törzsszöveghez. A latin és kelet‑ázsiai betűtípus‑tulajdonságokon kívül mindkét gyűjtemény a [IFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifonts/) felületen keresztül a írásrendszer címkéket betűtípus‑családnevekre térképezi.

Ez a cikk bemutatja, hogyan ellenőrizhetők és módosíthatók ezek a leképezések a prezentáció mester‑témájában, valamint hogyan ellenőrizhető, hogy a változtatások megmaradnak‑e a mentés‑újratöltés ciklus során.

## **A szkript címkék megértése**

A szkript betűtípus‑metódusok négybetűs BCP 47 szkript alalcímkéket használnak az írásrendszerek azonosítására. Gyakori értékek:

| Szkript címke | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűtípus‑sémához tartoznak, nem az egyes szövegrészekhez. Egy prezentáció meghatározhat különböző leképezéseket a fő és a mellék gyűjteményekhez, illetve elhagyhat leképezéseket bizonyos szkriptekhez.

## **A szkript betűtípus leképezések elérése és vizsgálata**

Használja a [Presentation::get_MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/) metódust a prezentáció‑szintű téma eléréséhez. A [FontScheme::get_Major](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_major/) és a [FontScheme::get_Minor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.theme/fontscheme/get_minor/) metódusok visszaadják a két [IFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifonts/) gyűjteményt.

Hívja a [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/getscriptfontmap/) metódust a gyűjtemény összes leképezésének lekéréséhez. Egy adott írásrendszer felkereséséhez hívja a [Fonts::GetScriptFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/getscriptfont/)‑t a szkript címkével. A `GetScriptFont` null‑stringet ad vissza, ha az adott gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja a [Fonts::SetScriptFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/setscriptfont/)‑t egy leképezés létrehozásához vagy a jelenlegi betűtípus‑család felülírásához. A [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/removescriptfont/)‑t a leképezés eltávolításához.

Az alábbi vég‑eredményes példaprogram beolvassa a meglévő fő és mellék leképezéseket, megkeresi a japán fő betűtípust, megváltoztatja a cirill fő betűtípust, eltávolítja a thaana mellék leképezést, menti a prezentációt, majd újból megnyitja a változások ellenőrzéséhez. Az eltávolítási lépés függetlené tétele érdekében a példa csak akkor hoz létre thaana leképezést, ha az még nincs definiálva.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Az ellenőrzés ugyanazt a null‑string viselkedést használja, mint egy szokásos lekérdezés: a eltávolítás mentése után a `GetScriptFont(u"Thaa")` null‑stringet ad a mellék gyűjteményhez.

## **A téma leképezések megkülönböztetése a többi betűtípus beállítástól**

A szkript‑specifikus téma leképezések részt vesznek a betűtípus‑kiválasztásban, de más problémát oldanak meg, mint a közvetlen szövegformázás, helyettesítés és fallback:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Szkript‑specifikus téma betűtípus leképezés | Kiválasztja a fő vagy mellék téma betűtípust egy írásrendszerhez. | A megfelelő téma betűtípust használó szöveg az új családra térképezhető. |
| Betűtípus kifejezetten hozzárendelve egy szövegrészhez | A kért betűtípus‑családot rögzíti azon a részen, a témától függetlenül. | A rész változatlan maradhat, mert a közvetlen formázás felülírja a téma választását. |
| Betűtípus‑helyettesítés | Kicseréli a kért betűtípust, ha az nem érhető el vagy helyettesítési szabály lép érvénybe. | A betűtípus‑kérés után működik; nem változtatja meg a téma szkript leképezését. |
| Betűtípus‑fallback | Hiányzó glyfjeket biztosít a kiválasztott betűtípustól, gyakran adott Unicode‑tartományokra. | Hiányzó glyfeket pótol, de nem változtatja a tárolt téma leképezést. |

További információért a két utóbbi mechanizmusról lásd a [Font Substitution](/slides/hu/cpp/font-substitution/) és a [Fallback Fonts](/slides/hu/cpp/fallback-font/) oldalakat.

A [Presentation::get_MasterTheme](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_mastertheme/)‑ben történő leképezés‑módosítás csak azokra a tartalmakra van hatással, amelyek hatékony formázása továbbra is erre a témára támaszkodik. A szöveg megörökíthet egy mester‑, elrendezés‑ vagy dia‑témát, vagy kifejezetten hozzárendelt betűtípust használhat. Vizsgálja ezeket a szinteket, ha a látható eredmény nem követi a prezentáció‑szintű leképezést.

## **A leképezett betűtípusok elérhetővé tétele és az eredmény ellenőrzése**

Egy szkript leképezés csak a betűtípus‑család nevét tárolja; nem telepíti vagy tölti be a megfelelő betűtípus‑fájlt. A következetes megjelenítés és export érdekében minden leképezett betűtípust telepíteni kell a környezetben, vagy az Aspose.Slides‑nek egy egyedi forráson keresztül kell biztosítani, például a [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsloader/loadexternalfonts/) vagy a [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) használatával. Lásd a [Custom Fonts](/slides/hu/cpp/custom-font/) oldalt a elérhető betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma definíciója megmaradt. Nem bizonyítja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez kép‑ vagy PDF‑formátumban, és ellenőrizze a kimenetet. Ez felderíti a hiányzó betűtípusokat, a nem teljes glif‑lefedettséget, a fallback viselkedést és az elrendezés‑változásokat, mielőtt a prezentációt terjesztenék. Lásd a [Convert PowerPoint Presentations](/slides/hu/cpp/convert-powerpoint/) oldalt a renderelés‑ és export‑példákért.

## **GYIK**

**Mi a `GetScriptFont` visszatérési értéke, ha egy szkript nincs leképezve?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/getscriptfont/) null‑stringet ad, ha a kért szkript leképezése nincs definiálva az adott fő vagy mellék betűtípus‑gyűjteményben.

**A `SetScriptFont` második leképezést hoz létre, ha a szkript már létezik?**

Nem. [Fonts::SetScriptFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fonts/setscriptfont/) létrehozza a leképezést, ha hiányzik, és felülírja a már meglévő betűtípus‑családot, ha a szkript címke már jelen van.

**Miért nem változott meg egyes szövegrészek betűtípusa a téma leképezés módosítása után?**

A szöveg lehet, hogy kifejezetten hozzárendelt betűtípussal rendelkezik, másik témát örököl felülíráson keresztül, vagy a renderelés során helyettesítés vagy fallback befolyásolja. A prezentáció‑szintű szkript leképezés csak azokra a szövegekre hat, amelyek hatékony formázása még mindig arra a téma betűtípus‑gyűjteményre hivatkozik.

**Elég a mentés és újbóli megnyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újbóli megnyitás csak a téma adatainak megmaradását ellenőrzi. Emellett minden szükséges írásrendszerből rendereljen representatív szöveget, hogy megbizonyosodjon a leképezett betűtípusok elérhetőségéről és a szükséges glifek meglétéről.