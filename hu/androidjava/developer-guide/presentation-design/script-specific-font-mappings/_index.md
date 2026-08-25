---
title: Szkript-specifikus téma betűtípusok kezelése Androidon
linktitle: Szkript-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/androidjava/script-specific-font-mappings/
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
- Android
- Java
- Aspose.Slides
description: "Ellenőrizze, adjon hozzá, cserélje ki és távolítsa el a szkript-specifikus betűtípus leképezéseket a PowerPoint témákban az Aspose.Slides for Android segítségével Java-ból."
---
## **Áttekintés**

Egy prezentációs téma különböző betűkészlet-családokat választhat ki különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűkészleteit használja, egy egységes betűtípus-sémát kövessen, miközben a megfelelő betűkészleteket alkalmazza a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez.

A téma [IFontScheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/) tartalmaz egy fő betűkészlet-gyűjteményt, amelyet általában a címsorokhoz használnak, és egy mellék betűkészlet-gyűjteményt, amelyet általában a törzsszöveghez használnak. A latin és kelet-ázsiai betűkészlet-beállításaikon túl mindkét gyűjtemény a [IFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifonts/) interfészen keresztül térképeket tesz elérhetővé az írásrendszer címkéiből a betűkészlet-családnevekre.

Ez a cikk bemutatja, hogyan lehet ezeket a leképezéseket ellenőrizni és módosítani a prezentáció mestertémájában, valamint hogyan ellenőrizhető, hogy a módosítások túlélnek egy mentés‑újratöltés ciklust.

## **Írásrendszer címkék**

A szkript betűtípus metódusok négybetűs BCP 47 szkript al‑címkéket használnak az írásrendszerek azonosítására. Gyakori értékek:

| Script tag | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűtípus‑schema részei, nem pedig az egyes szövegrészeké. Egy prezentáció meghatározhat különböző leképezéseket a fő és a mellék gyűjteményekhez, és bizonyos szkriptekhez elhagyhatja a leképezést.

## **Szkript betűtípus leképezések elérése és ellenőrzése**

Használja a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getMasterTheme--) metódust a prezentáció szintű téma eléréséhez. A [IFontScheme.getMajor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/#getMajor--) és [IFontScheme.getMinor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifontscheme/#getMinor--) metódusok visszaadják a két [IFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifonts/) gyűjteményt.

Hívja meg az [IFonts.getScriptFontMap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#getScriptFontMap--) metódust a gyűjtemény összes leképezésének lekéréséhez. Egy írásrendszer kereséséhez hívja meg az [IFonts.getScriptFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) metódust a megfelelő szkript címkével. A `getScriptFont` `null` értéket ad vissza, ha az adott gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja az [IFonts.setScriptFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) metódust egy leképezés létrehozásához vagy a jelenlegi betűkészlet-család cseréjéhez. Használja az [IFonts.removeScriptFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#removeScriptFont-java.lang.String-) metódust egy leképezés eltávolításához.

A következő teljes körű példa beolvassa az összes létező fő és mellék leképezést, lekéri a japán fő betűtípust, megváltoztatja a cirill fő betűtípust, eltávolítja a Thaana mellék leképezést, elmenti a prezentációt, majd újra megnyitja azt a változások ellenőrzéséhez. Az eltávolítási lépést a kezdeti témától függetlené tenni, a példa csak akkor hoz létre Thaana leképezést, ha az még nincs definiálva.

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

Az ellenőrzés ugyanazt a `null` viselkedést használja, mint egy egyszerű lekérdezés: a törlés elmentése után a `getScriptFont("Thaa")` `null` értéket ad vissza a mellék gyűjtemény esetén.

## **A téma leképezések megkülönböztetése más betűtípus beállításoktól**

A szkript specifikus téma leképezések részt vesznek a betűtípus kiválasztásában, de más problémát oldanak meg, mint a közvetlen szövegformázás, helyettesítés és tartalék:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Script-specific theme font mapping | Kiválaszt egy fő vagy mellék téma betűtípust egy írásrendszerhez. | A szöveg, amely továbbra is a megfelelő téma betűtípust használja, az új leképezett családra oldódik fel. |
| Font assigned explicitly to a text portion | Megerősíti a kért betűkészlet-családot azon a részen a téma használata helyett. | A rész változatlan maradhat, mert a közvetlen formázása felülírja a téma választását. |
| Font substitution | Kicseréli a kért betűtípust, ha az nem érhető el vagy ha egy helyettesítési szabály érvényesül. | A betűtípus kérése után lép működésbe; nem definiálja újra a téma szkript leképezését. |
| Font fallback | Biztosítja azokat a glifeket, amelyeket a kiválasztott betűtípus nem tartalmaz, gyakran bizonyos Unicode tartományokhoz. | Kitölti a hiányzó glif lefedettséget; nem módosítja a tárolt téma leképezést. |

További információért az utóbbi két mechanizmust lásd a [Font Substitution](/slides/hu/androidjava/font-substitution/) és a [Fallback Fonts](/slides/hu/androidjava/fallback-font/) című oldalakon.

Egy leképezés módosítása a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/#getMasterTheme--) metódusban csak arra a tartalomra hat, amelynek a hatékony formázása még függ a témától. A szöveg helyette örökölhet egy téma felülbírálást egy masterről, elrendezésről vagy diáról, vagy kifejezetten hozzárendelt betűtípust használhat. Ellenőrizze ezeket a szinteket, ha a látható eredmény nem követi a prezentáció szintű leképezést.

## **A leképezett betűtípusok elérhetővé tétele és az eredmény ellenőrzése**

A szkript leképezés egy betűkészlet-család nevet tárol; nem telepíti vagy tölti be a megfelelő betűtípus fájlt. A konzisztens megjelenítés és export érdekében minden leképezett betűtípust telepíteni kell a környezetben vagy biztosítani kell az Aspose.Slides számára egy egyéni forráson keresztül, például a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) vagy a [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#getDocumentLevelFontSources--) segítségével. Lásd a [Custom Fonts](/slides/hu/androidjava/custom-font/) oldalt a rendelkezésre álló betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma definíciója megmaradt. Nem bizonyítja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést produkálja. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez egy képre vagy PDF-re, és ellenőrizze a kimenetet. Ez felfedezi a hiányzó betűtípusokat, a hiányos glif lefedettséget, a tartalék viselkedést és az elrendezés változásait, még mielőtt a prezentációt terjesztenék. Lásd a [Convert PowerPoint Presentations](/slides/hu/androidjava/convert-powerpoint/) oldalt a renderelés és export példákért.

## **GYIK**

**Mi a visszatérési értéke a `getScriptFont`‑nek, ha egy szkript nincs leképezve?**

[IFonts.getScriptFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#getScriptFont-java.lang.String-) `null`‑t ad vissza, amikor a kért szkript leképezése nincs definiálva az adott fő vagy mellék betűkészlet‑gyűjteményben.

**A `setScriptFont` második leképezést ad hozzá, ha a szkript már létezik?**

Nem. [IFonts.setScriptFont](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fonts/#setScriptFont-java.lang.String-java.lang.String-) létrehozza a leképezést, ha hiányzik, és felülírja a már meglévő betűkészlet‑családot, ha a szkript címke már jelen van.

**Miért nem változott meg néhány szöveg a téma leképezés módosítása után?**

A szöveg lehet kifejezetten hozzárendelt betűtípussal, örökölhet egy másik témát egy felülbírálás révén, vagy a renderelés során helyettesítés vagy tartalék hatás érvényesül. Egy prezentáció‑szintű szkript leképezés csak arra a szövegre van hatással, amelynek a hatékony formázása még a téma betűkészlet‑gyűjteményére hivatkozik.

**Elég a mentés és újranyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újranyitás csak a téma adatainak fennmaradását igazolja. Emellett minden szükséges írásrendszerhez rendereljen reprezentatív szöveget, hogy megerősítse, hogy a leképezett betűtípusok elérhetők és tartalmazzák a szükséges glifeket.