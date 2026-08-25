---
title: Szkript-specifikus téma betűtípusok kezelése Java-ban
linktitle: Szkript-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/java/script-specific-font-mappings/
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
- Java
- Aspose.Slides
description: "Ellenőrizze, adjon hozzá, cserélje le és távolítsa el a szkript-specifikus betűtípus leképezéseket a PowerPoint témákban az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

A prezentációs téma különböző betűtípus‑családokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely a téma betűtípusait használja, egy egységes betűtípus‑sémát kövessen, miközben a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez megfelelő betűtípusokat alkalmazza.

A téma [IFontScheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/) egy fő betűtípus‑gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, és egy mellék betűtípus‑gyűjteményt, amelyet általában a törzsszöveghez használnak. A latin és kelet‑ázsiai betűtípus‑beállításaik mellett mindkét gyűjtemény a [IFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifonts/) felületen keresztül térképeket tesz elérhetővé az írásrendszer‑címkék és betűtípus‑családnevek között.

Ez a cikk bemutatja, hogyan vizsgálhatók és módosíthatók ezek a leképezések a prezentáció mester‑témájában, valamint azt, hogy a módosítások megmaradnak‑e egy mentés‑újratöltés ciklus során.

## **Szkriptcímkék megértése**

A szkriptbetűtípus‑módszerek négybetűs BCP 47 szkript‑alalcímkéket használnak az írásrendszerek azonosításához. Gyakori értékek:

| Szkripttag | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűtípus‑sémájához tartoznak, nem pedig egyedi szövegrészekhez. Egy prezentáció megadhat különböző leképezéseket a fő és mellék gyűjteményekhez, és egyes írásrendszerekhez akár nem is definiálhat leképezést.

## **A szkriptbetűtípus‑leképezések elérése és vizsgálata**

Használja a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasterTheme--) metódust a prezentáció‑szintű téma eléréséhez. Az [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/#getMajor--) és az [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifontscheme/#getMinor--) metódusok visszaadják a két [IFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifonts/) gyűjteményt.

Hívja meg az [IFonts.getScriptFontMap](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#getScriptFontMap--) metódust a gyűjtemény összes leképezésének lekéréséhez. Egy adott írásrendszer kereséséhez hívja meg az [IFonts.getScriptFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) metódust a szkriptcímkénél. A `getScriptFont` `null`‑t ad vissza, ha az adott gyűjtemény nem tartalmazza a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja az [IFonts.setScriptFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) metódust egy leképezés létrehozásához vagy a jelenlegi betűtípus‑család felülírásához. A [IFonts.removeScriptFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) metódussal egy leképezést távolíthat el.

Az alábbi vég‑vég példaprogram beolvassa az összes meglévő fő és mellék leképezést, megkeresi a japán fő betűtípust, megváltoztatja a cirill fő betűtípust, eltávolítja a thaana mellék leképezést, elmenti a prezentációt, majd újra megnyitja azt, hogy ellenőrizze mindkét módosítást. Az eltávolítási lépést függetlenné teszi a kiinduló témától azzal, hogy a példaprogram csak akkor hoz létre thaana leképezést, ha még nincs definiálva.

```java
import com.aspose.slides.*;
import com.aspose.slides.Collections.Generic.Dictionary;
import com.aspose.slides.Collections.Generic.KeyValuePair;

Presentation presentation = new Presentation();
try {
    IFontScheme fontScheme = presentation.getMasterTheme().getFontScheme();
    IFonts majorFonts = fontScheme.getMajor();
    IFonts minorFonts = fontScheme.getMinor();

    System.out.println("Existing major mappings:");
    Dictionary.Enumerator<String, String> majorMappings = majorFonts.getScriptFontMap().iterator();
    while (majorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = majorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    System.out.println("Existing minor mappings:");
    Dictionary.Enumerator<String, String> minorMappings = minorFonts.getScriptFontMap().iterator();
    while (minorMappings.hasNext()) {
        KeyValuePair<String, String> mapping = minorMappings.next();
        System.out.println("  " + mapping.getKey() + ": " + mapping.getValue());
    }

    String japaneseFont = majorFonts.getScriptFont("Jpan");
    if (japaneseFont == null) {
        System.out.println("No major Japanese font is defined.");
    } else {
        System.out.println("Major Japanese font: " + japaneseFont);
    }

    majorFonts.setScriptFont("Cyrl", "Arial");

    if (minorFonts.getScriptFont("Thaa") == null) {
        minorFonts.setScriptFont("Thaa", "Arial");
    }

    minorFonts.removeScriptFont("Thaa");
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    IFonts savedMajorFonts = savedPresentation.getMasterTheme().getFontScheme().getMajor();
    IFonts savedMinorFonts = savedPresentation.getMasterTheme().getFontScheme().getMinor();
    String savedCyrillicFont = savedMajorFonts.getScriptFont("Cyrl");
    String savedThaanaFont = savedMinorFonts.getScriptFont("Thaa");

    if ("Arial".equals(savedCyrillicFont)) {
        System.out.println("The Cyrillic mapping was preserved.");
    } else {
        System.out.println("The Cyrillic mapping was not preserved.");
    }

    if (savedThaanaFont == null) {
        System.out.println("The Thaana mapping removal was preserved.");
    } else {
        System.out.println("The Thaana mapping still exists.");
    }
} finally {
    savedPresentation.dispose();
}
```

Az ellenőrzés ugyanazt a `null` viselkedést használja, mint egy szokásos lekérdezés: a távolítás mentése után a `getScriptFont("Thaa")` `null`‑t ad vissza a mellék gyűjteményre.

## **A téma leképezések megkülönböztetése más betűtípus‑beállításoktól**

A szkript‑specifikus téma leképezések részt vesznek a betűtípus‑kiválasztásban, de más problémát oldanak meg, mint a közvetlen szövegformázás, helyettesítés vagy visszaeső betűtípus:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Szkript‑specifikus téma betűtípus‑leképezés | Kiválaszt egy fő vagy mellék téma betűtípust egy írásrendszerhez. | A megfelelő téma betűtípust használó szöveg feloldható az új leképezett családra. |
| Közvetlenül egy szövegrészhez hozzárendelt betűtípus | A kért betűtípus‑családot az adott részhez rögzíti, a témától függetlenül. | A rész változatlan maradhat, mert a közvetlen formázás felülírja a téma választását. |
| Betűtípus‑helyettesítés | Kicseréli a kért betűtípust, ha az nem elérhető vagy helyettesítési szabály alkalmazandó. | A betűtípus kérés után lép életbe; nem módosítja a téma szkript‑leképezését. |
| Betűtípus‑visszaesés | Olyan glifeket biztosít, amelyeket a kiválasztott betűtípus nem tartalmaz, gyakran speciális Unicode‑tartományokhoz. | Hiányzó glifek lefedését biztosítja; nem változtatja meg a tárolt téma leképezést. |

További információk a két utolsó mechanizmusról: [Font Substitution](/slides/hu/java/font-substitution/) és [Fallback Fonts](/slides/hu/java/fallback-font/).

A [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#getMasterTheme--) módosítása csak azokra a tartalmakra hat, amelyek hatékony formázása még mindig az adott témától függ. A szöveg helyette örökölhet téma‑felülírást egy mester‑, elrendezés‑ vagy diatémától, vagy kifejezetten hozzárendelt betűtípust használhat. Vizsgálja meg ezeket a szinteket, ha a látható eredmény nem követi a prezentáció‑szintű leképezést.

## **Leképezett betűtípusok elérhetővé tétele és az eredmény ellenőrzése**

Egy szkript‑leképezés csak egy betűtípus‑családnevet tárol; nem telepíti vagy tölti be a megfelelő betűtípus‑fájlt. A konzisztens megjelenítés és export érdekében minden leképezett betűtípust telepíteni kell a környezetben, vagy az Aspose.Slides‑nek egy egyéni forráson keresztül kell biztosítani, például a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) vagy a [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) használatával. Lásd a [Custom Fonts](/slides/hu/java/custom-font/) oldalt a rendelkezésre álló betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt bizonyítja, hogy a téma‑definíció megmaradt. Nem igazolja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez egy képre vagy PDF‑re, és vizsgálja meg a kimenetet. Ez felfedi a hiányzó betűtípusokat, a nem teljes glif‑lefedettséget, a visszaesés viselkedését és az elrendezés‑változásokat, mielőtt a prezentációt terjesztenék. Lásd a [Convert PowerPoint Presentations](/slides/hu/java/convert-powerpoint/) oldalt a renderelési és exportálási példákért.

## **GYIK**

**Mit ad vissza a `getScriptFont`, ha egy szkript nincs leképezve?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) `null`‑t ad vissza, ha a kért szkript leképezése nincs definiálva az adott fő vagy mellék betűtípus‑gyűjteményben.

**A `setScriptFont` második leképezést hoz létre, ha a szkript már létezik?**

Nem. [IFonts.setScriptFont](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) létrehozza a leképezést, ha hiányzik, és felülírja a már meglévő betűtípus‑családot, ha a szkriptcímke már jelen van.

**Miért nem változott meg a szöveg, amikor a téma leképezést módosítottam?**

A szöveg lehet, hogy kifejezetten hozzárendelt betűtípussal rendelkezik, egy másik témát örököl egy felülírás miatt, vagy a renderelés során helyettesítés vagy visszaesés hat rá. A prezentáció‑szintű szkript‑leképezés csak azokra a szövegekre vonatkozik, amelyek hatékony formázása még mindig az adott téma betűtípus‑gyűjteményére hivatkozik.

**Elég-e a mentés és újra­nyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újra­nyitás csak a téma adatok tartósságát ellenőrzi. Emellett minden szükséges írásrendszerből rendereljen reprezentatív szöveget, hogy megbizonyosodjon arról, hogy a leképezett betűtípusok elérhetők és tartalmazzák a szükséges glifeket.