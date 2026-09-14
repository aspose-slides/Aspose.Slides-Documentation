---
title: Script-specifikus téma betűtípusok kezelése Pythonban Java-n keresztül
linktitle: Script-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/python-java/script-specific-font-mappings/
keywords:
- script-specifikus betűtípus
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
- Python
- Java
- Aspose.Slides
description: "Vizsgálja, adja hozzá, cserélje ki és távolítsa el a script-specifikus betűtípus leképezéseket a PowerPoint témákban az Aspose.Slides segítségével Pythonban Java-n keresztül."
---
## **Áttekintés**

A prezentáció témája különböző betűcsaládokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűtípusait használja, egy egységes betűsémát kövessen, miközben a cirill, arab, japán, grúz, thaana és egyéb írásrendszerekhez megfelelő betűtípusokat alkalmaz.

A téma [FontScheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontscheme/) egy fő betűtípus-gyűjteményt tartalmaz, amelyet általában a címsorokhoz használnak, és egy mellékelt betűtípus-gyűjteményt, amelyet a törzsszöveghez használnak. A latin és kelet-ázsiai betűtípus-beállításokon túlmindkét gyűjtemény a [Fonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/) osztályon keresztül a írásrendszer címkéktől a betűcsaládnevekhez térképezi fel a kapcsolatot.

Ez a cikk bemutatja, hogyan lehet megvizsgálni és módosítani ezeket a leképezéseket a prezentáció mester‑témájában, és ellenőrizni, hogy a változások túlélnek‑e egy mentés‑újratöltés ciklust.

## **Az írásrendszer címkék megértése**

A szkript betűtípus módszerek négybetűs BCP 47 írásrendszer alalcímkéket használnak az írásrendszerek azonosításához. Gyakori értékek:

| Írásrendszer címke | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűtípus‑sémához tartoznak, nem pedig egyedi szövegrészletekhez. Egy prezentáció különböző leképezéseket definiálhat a fő és a mellék betűtípus-gyűjteményekhez, és egyes írásrendszerekhez hiányozhatnak a leképezések.

## **A szkript betűtípus leképezések elérése és vizsgálata**

Használja a [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasterTheme) metódust a prezentáció‑szintű téma eléréséhez. A [FontScheme.getMajor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontscheme/#getMajor) és a [FontScheme.getMinor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontscheme/#getMinor) metódusok visszaadják a két [Fonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/) gyűjteményt.

A [Fonts.getScriptFontMap](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#getScriptFontMap) segítségével lekérhető egy gyűjtemény összes leképezése. Egy adott írásrendszer kereséséhez hívja a [Fonts.getScriptFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#getScriptFont) metódust a megfelelő írásrendszer címkével. A `getScriptFont` `None`‑t ad vissza, ha az adott gyűjteményben nincs definiálva a kért leképezés.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja a [Fonts.setScriptFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#setScriptFont) metódust egy leképezés létrehozásához vagy a jelenlegi betűcsalád lecseréléséhez. A [Fonts.removeScriptFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#removeScriptFont) metódussal egy leképezést eltávolíthat.

Az alábbi vég‑től‑végig példa beolvassa az összes meglévő fő és mellék leképezést, megkeresi a japán fő betűtípust, módosítja a cirill fő betűtípust, eltávolítja a thaana mellék leképezést, elmenti a prezentációt, majd újra megnyitja a változások ellenőrzéséhez. A eltávolítási lépést függetleníti a kezdeti témától azáltal, hogy a példa csak akkor hoz létre thaana leképezést, ha még nincs definiálva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    font_scheme = presentation.getMasterTheme().getFontScheme()
    major_fonts = font_scheme.getMajor()
    minor_fonts = font_scheme.getMinor()

    print("Existing major mappings:")
    major_mappings = major_fonts.getScriptFontMap().iterator()
    while major_mappings.hasNext():
        mapping = major_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    print("Existing minor mappings:")
    minor_mappings = minor_fonts.getScriptFontMap().iterator()
    while minor_mappings.hasNext():
        mapping = minor_mappings.next()
        print(f"  {mapping.getKey()}: {mapping.getValue()}")

    japanese_font = major_fonts.getScriptFont("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.setScriptFont("Cyrl", "Arial")

    if minor_fonts.getScriptFont("Thaa") is None:
        minor_fonts.setScriptFont("Thaa", "Arial")

    minor_fonts.removeScriptFont("Thaa")
    presentation.save("script-font-mappings.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("script-font-mappings.pptx")
try:
    saved_major_fonts = saved_presentation.getMasterTheme().getFontScheme().getMajor()
    saved_minor_fonts = saved_presentation.getMasterTheme().getFontScheme().getMinor()
    saved_cyrillic_font = saved_major_fonts.getScriptFont("Cyrl")
    saved_thaana_font = saved_minor_fonts.getScriptFont("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
finally:
    saved_presentation.dispose()
```

A validálás ugyanazt a `None` viselkedést használja, mint egy szokásos lekérdezés: az eltávolítás után a `getScriptFont("Thaa")` `None`‑t ad vissza a mellék gyűjteményben.

## **A téma leképezések megkülönböztetése a többi betűtípus beállítástól**

Az írásrendszer‑specifikus téma leképezések részt vesznek a betűtípus‑kiválasztásban, de más problémát oldanak meg, mint a közvetlen szövegformázás, helyettesítés és visszalépés:

| Mechanizmus | Cél | A téma leképezés megváltoztatásának hatása |
|---|---|---|
| Az írásrendszer‑specifikus téma betűtípus leképezés | Kiválaszt egy fő vagy mellék téma betűtípust egy írásrendszerhez. | A szöveg, amely továbbra is a megfelelő téma betűtípust használja, az új leképezett családra térhet át. |
| Kifejezetten egy szövegrészhez rendelt betűtípus | Rögzíti a kért betűcsaládot azon a részen, ahelyett, hogy a témára támaszkodna. | A részlet változatlan maradhat, mert a közvetlen formázás felülírja a téma választását. |
| Betűtípus helyettesítés | Lecserél egy kért betűtípust, ha az nem érhető el vagy ha egy helyettesítési szabály érvényesül. | A betűtípus lekérdezése után lép fel; nem definiálja újra a téma írásrendszer‑leképezését. |
| Betűtípus tartalék | Olyan glifeket biztosít, amelyeket a kiválasztott betűtípus nem tartalmaz, gyakran specifikus Unicode‑tartományokhoz. | Kitölti a hiányzó glif‑lefedettséget; nem módosítja a tárolt téma leképezést. |

További információért az utóbbi két mechanizmusról lásd a [Font Substitution](/slides/hu/python-java/font-substitution/) és a [Fallback Fonts](/slides/hu/python-java/fallback-font/) oldalakat.

A [Presentation.getMasterTheme](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getMasterTheme) leképezés módosítása csak azon tartalmat érinti, amelynek a hatékony formázása még a témára támaszkodik. A szöveg örökölhet téma‑felülbírálást egy mester‑, elrendezés‑ vagy diatémából, vagy kifejezetten egy betűtípust használhat. Ellenőrizze ezeket a szinteket, ha a látható eredmény nem a prezentáció‑szintű leképezést követi.

## **A leképezett betűtípusok elérhetővé tétele és az eredmény validálása**

Egy szkript leképezés csak a betűcsalád nevét tárolja; nem telepíti vagy tölti be a megfelelő betűtípus‑fájlt. A következetes megjelenítés és exportálás érdekében minden leképezett betűtípust telepíteni kell a környezetben, vagy az Aspose.Slides‑nek egy egyéni forráson keresztül biztosítani, például a [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsloader/#loadExternalFonts) vagy a [LoadOptions.getDocumentLevelFontSources](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) használatával. Lásd a [Custom Fonts](/slides/hu/python-java/custom-font/) oldalt a rendelkezésre álló betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma definíciója megmaradt. Nem bizonyítja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Készítsen reprezentatív szövegeket minden szükséges írásrendszerhez képként vagy PDF‑ként, és ellenőrizze a kimenetet. Ez felderíti a hiányzó betűtípusokat, a hiányos glif‑lefedettséget, a visszalépési viselkedést és az elrendezési változásokat a prezentáció terjesztése előtt. Lásd a [Convert PowerPoint Presentations](/slides/hu/python-java/convert-powerpoint/) oldalt a renderelési és exportálási példákért.

## **GYIK**

**Miért ad `getScriptFont` `None`‑t, ha egy írásrendszer nincs leképezve?**

A [Fonts.getScriptFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#getScriptFont) `None`‑t ad vissza, ha a kért írásrendszer leképezése nincs definiálva az adott fő vagy mellék betűtípus‑gyűjteményben.

**A `setScriptFont` hozzáad egy második leképezést, ha a szkript már létezik?**

Nem. A [Fonts.setScriptFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fonts/#setScriptFont) létrehozza a leképezést, ha hiányzik, és lecseréli a már meglévő betűcsaládot, ha a szkript címke már jelen van.

**Miért nem változott meg egyes szövegek a téma leképezés módosítása után?**

A szöveg lehet, hogy kifejezetten egy betűtípust kapott, másik témát örököl egy felülbírálás révén, vagy a renderelés során helyettesítés vagy visszalépés érintette. Egy prezentáció‑szintű szkript leképezés csak azokra a szövegekre hat, amelyek hatékony formázása még a téma betűtípus‑gyűjteményére támaszkodik.

**Elég-e a mentés és újra‑megnyitás a többnyelvű kimenet validálásához?**

Nem. Az újra‑megnyitás csak a téma adatainak megmaradását ellenőrzi. Emellett rendereljen reprezentatív szöveget minden szükséges írásrendszerből, hogy megerősítse, a leképezett betűtípusok elérhetők és tartalmazzák a szükséges glifeket.