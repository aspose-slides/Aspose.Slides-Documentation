---
title: Script-specifikus téma betűk kezelése JavaScriptben
linktitle: Script-specifikus téma betűk
type: docs
weight: 15
url: /hu/nodejs-java/script-specific-font-mappings/
keywords:
- script-specifikus betű
- téma betűleképezés
- többnyelvű prezentáció
- írásrendszer
- Cirill betű
- Arab betű
- Japán betű
- Grúz betű
- Thaana betű
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Vizsgálja, adja hozzá, cserélje ki és távolítsa el a script-specifikus betűleképezéseket a PowerPoint témákban az Aspose.Slides for Node.js segítségével."
---
## **Áttekintés**

A prezentáció témája képes különböző betűcsaládokat kiválasztani különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűkészleteit használja, egy koordinált betűsémát kövessen, miközben a megfelelő betűket alkalmazza a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez.

A téma [FontScheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) egy fő betűkészlet-gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, valamint egy másodlagos betűkészlet-gyűjteményt, amelyet általában a törzsszöveghez használnak. Az őket érintő latin és kelet-ázsiai betűk beállításain túl mindkét gyűjtemény a [Fonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) osztályon keresztül térképezi fel az írásrendszer címkéit a betűcsaládnevekre.

Ez a cikk bemutatja, hogyan lehet ellenőrizni és módosítani ezeket a leképezéseket a prezentáció fő témájában, valamint hogyan ellenőrizhető, hogy a módosítások megmaradnak egy mentés‑újratöltés ciklus során.

## **A szkriptcímkék megértése**

A szkript betűkészlet metódusok négybetűs BCP 47 szkript alalcímkéket használnak az írásrendszerek azonosításához. Gyakori értékek a következők:

| Szkriptcímke | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűsémájához tartoznak, nem egyedi szövegrészekhez. Egy prezentáció különböző leképezéseket definiálhat a fő és a másodlagos gyűjteményekhez, és elhagyhat leképezéseket bizonyos szkriptekhez.

## **A szkript betűk leképezéseinek elérése és ellenőrzése**

Használja a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) metódust a prezentáció szintű téma eléréséhez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontscheme/) metódusok visszaadják a két [Fonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) gyűjteményt.

Hívja a [Fonts.getScriptFontMap](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) metódust a gyűjtemény összes leképezésének lekéréséhez. Egy írásrendszer kereséséhez hívja a [Fonts.getScriptFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) metódust a megfelelő szkriptcímkével. A `getScriptFont` null értéket ad vissza, ha a gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja a [Fonts.setScriptFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) metódust egy leképezés létrehozásához vagy a jelenlegi betűcsalád helyettesítéséhez. Használja a [Fonts.removeScriptFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) metódust egy leképezés eltávolításához.

Az alábbi végponttól‑végpontig tartó példa beolvassa az összes meglévő fő és másodlagos leképezést, megkeresi a japán fő betűt, megváltoztatja a cirill fő betűt, eltávolítja a thaana másodlagos leképezést, elmenti a prezentációt, majd újra megnyitja azt a változások ellenőrzéséhez. Ahhoz, hogy az eltávolítási lépés független legyen a kezdeti témától, a példa csak akkor hoz létre thaana leképezést, ha az még nincs definiálva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    var fontScheme = presentation.getMasterTheme().getFontScheme();
    var majorFonts = fontScheme.getMajor();
    var minorFonts = fontScheme.getMinor();

    console.log("Existing major mappings:");
    var majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        var mapping = majorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    console.log("Existing minor mappings:");
    var minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        var mapping = minorMappings.next();
        console.log("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    var japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        console.log("No major Japanese font is defined.");
    } else {
        console.log("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

var savedPresentation = new aspose.slides.Presentation("script-font-mappings.pptx");
try {
    var savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    var savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    var savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    var savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if (savedCyrillicFont === "Arial") {
        console.log("The Cyrillic mapping was preserved.");
    } else {
        console.log("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        console.log("The Thaana mapping removal was preserved.");
    } else {
        console.log("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Az ellenőrzés ugyanazt a `null` viselkedést használja, mint egy szokványos keresés: a törlés mentése után a `getScriptFont("Thaa")` `null` értéket ad vissza a másodlagos gyűjteményhez.

## **A téma leképezések és a többi betűbeállítás közötti különbségtétel**

Szkript-specifikus téma betűleképezés | Kiválaszt egy fő vagy másodlagos téma betűt egy írásrendszerhez. | Az a szöveg, amely továbbra is a megfelelő téma betűt használja, az új leképezett családra hivatkozhat.
---|---|---
Kifejezetten egy szövegrészhez hozzárendelt betű | Rögzíti a kért betűcsaládot azon a részen, a téma helyett. | A rész változatlan maradhat, mivel a közvetlen formázás felülbírálja a téma választását.
Betűkészlet helyettesítés | Lecserél egy kért betűkészletet, ha az nem érhető el vagy ha egy helyettesítési szabály érvényesül. | A kérés után lép működésbe; nem definiálja újra a téma szkript leképezését.
Betűkészlet visszaesés | Biztosítja azokat a glyppeket, amelyeket a kiválasztott betűkészlet nem tartalmaz, gyakran meghatározott Unicode tartományokhoz. | Kiegészíti a hiányzó glif lefedettséget; nem változtatja meg a tárolt téma leképezést.

További információkért az utóbbi két mechanizmusról, lásd a [Betűkészlet helyettesítés](/slides/hu/nodejs-java/font-substitution/) és a [Visszaeső betűkészletek](/slides/hu/nodejs-java/fallback-font/) oldalakat.

A [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getmastertheme/) metódusban végrehajtott leképezés módosítása csak azokat a tartalmakat érinti, amelyek hatékony formázása továbbra is az adott témára támaszkodik. A szöveg helyette örökölhet téma felülírást egy masterből, elrendezésből vagy diából, vagy használhat kifejezetten hozzárendelt betűt. Vizsgálja meg ezeket a szinteket, ha a látható eredmény nem követi a prezentáció-szintű leképezést.

## **A leképezett betűk elérhetővé tétele és az eredmény ellenőrzése**

Egy szkript leképezés csak a betűcsalád nevét tárolja; nem telepíti vagy tölti be a megfelelő betűkészlet fájlt. A következetes megjelenítés és export érdekében minden leképezett betűt telepíteni kell a környezetben, vagy az Aspose.Slides-nek egy egyedi forráson keresztül kell biztosítani, például a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) vagy a [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) segítségével. Tekintse meg a [Custom Fonts](/slides/hu/nodejs-java/custom-font/) oldalt a rendelkezésre álló betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma-definíció megmaradt. Nem bizonyítja, hogy a betűkészlet elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez egy képre vagy PDF-re, és ellenőrizze a kimenetet. Ez felfedi a hiányzó betűkészleteket, a hiányos glif lefedettséget, a visszaeső viselkedést és az elrendezésváltozásokat, mielőtt a prezentációt terjesztenék. Tekintse meg a [Convert PowerPoint Presentations](/slides/hu/nodejs-java/convert-powerpoint/) oldalt a renderelés és export példákért.

## **GYIK**

**Mi a `getScriptFont` visszatérési értéke, ha egy szkript nincs leképezve?**

A [Fonts.getScriptFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) `null` értéket ad vissza, ha a kért szkript leképezés nincs definiálva az adott fő vagy másodlagos betűgyűjteményben.

**A `setScriptFont` hozzáad egy újabb leképezést, ha a szkript már létezik?**

Nem. A [Fonts.setScriptFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fonts/) létrehozza a leképezést, ha hiányzik, és helyettesíti a leképezett betűcsaládot, ha a ugyanaz a szkriptcímke már létezik.

**Miért nem változott egyes szövegek a téma leképezés módosítása után?**

A szövegnek lehet kifejezetten hozzárendelt betűje, örökölhet egy másik témát felülírással, vagy a renderelés során helyettesítés vagy visszaesés érintheti. Egy prezentáció-szintű szkript leképezés csak azokat a szövegeket szabályozza, amelyek hatékony formázása továbbra is az adott téma betűgyűjteményére hivatkozik.

**Elég-e a mentés és újranyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újranyitás csak a téma adatainak tartósságát ellenőrzi. Emellett rendereljen reprezentatív szöveget minden szükséges írásrendszerről, hogy megerősítse, a leképezett betűkészletek elérhetők és tartalmazzák a szükséges glifeket.