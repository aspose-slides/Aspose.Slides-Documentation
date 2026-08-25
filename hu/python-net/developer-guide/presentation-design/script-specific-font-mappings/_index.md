---
title: Szkript-specifikus téma betűtípusok kezelése Pythonban
linktitle: Szkript-specifikus téma betűtípusok
type: docs
weight: 15
url: /hu/python-net/script-specific-font-mappings/
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
- Python
- Aspose.Slides
description: "Ellenőrizze, adjon hozzá, cserélje ki és távolítsa el a szkript-specifikus betűtípus leképezéseket a PowerPoint témákban az Aspose.Slides for Python segítségével .NET-en keresztül."
---
## **Áttekintés**

A prezentációs téma különböző betűcsaládokat választhat különböző írásrendszerekhez. Ez lehetővé teszi, hogy a többnyelvű szöveg, amely továbbra is a téma betűkészleteit használja, egy egységes betűsémát kövessen, miközben a cirill, arab, japán, grúz, thaana és egyéb írásrendszerek számára megfelelő betűket használ.

A téma [FontScheme](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/) egy fő betűkészletet (major) tartalmaz, amelyet általában a címsorokhoz használnak, valamint egy másodlagos betűkészletet (minor), amelyet a törzsszöveghez használnak. A latin és kelet-ázsiai betűtulajdonságok mellett mindkét gyűjtemény a [Fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/) osztályon keresztül biztosítja a írásrendszer címkék betűcsalád-nevekre való leképezését.

Ez a cikk bemutatja, hogyan lehet megvizsgálni és módosítani ezeket a leképezéseket a prezentáció mester témájában, és hogyan ellenőrizhető, hogy a változások megmaradnak-e egy mentés‑újratöltés ciklus után.

## **Írásrendszer-címkék megértése**

A betűtípus-módszerek négybetűs BCP 47 írásrendszer-alalcímkéket (script subtags) használnak az írásrendszerek azonosításához. Gyakori értékek:

| Script tag | Írásrendszer |
|---|---|
| `Cyrl` | Cirill |
| `Arab` | Arab |
| `Hans` | Egyszerűsített kínai |
| `Jpan` | Japán |
| `Geor` | Grúz |
| `Thaa` | Thaana |

Ezek a leképezések a téma betűsémájához tartoznak, nem egyedi szövegrészekhez. Egy prezentáció különböző leképezéseket definiálhat a fő és a másodlagos gyűjteményhez, és egyes írásrendszerekhez akár nem is definiálhat leképezést.

## **Írásrendszer‑betűtípus leképezések elérése és vizsgálata**

Használja a [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) tulajdonságot a prezentáció‑szintű téma eléréséhez. A [FontScheme.major](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/major/) és a [FontScheme.minor](https://reference.aspose.com/slides/hu/python-net/aspose.slides.theme/fontscheme/minor/) tulajdonságok visszaadják a két [Fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/) gyűjteményt.

Hívja a [Fonts.get_script_font_map](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/get_script_font_map/) metódust a gyűjtemény összes leképezésének lekéréséhez. Egy adott írásrendszer kereséséhez hívja a [Fonts.get_script_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/get_script_font/) metódust a megfelelő script taggel. A `get_script_font` `None`‑t ad vissza, ha a gyűjtemény nem definiálja a kért leképezést.

## **Leképezések módosítása és a tartósság ellenőrzése**

Használja a [Fonts.set_script_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/set_script_font/) metódust egy leképezés létrehozásához vagy a jelenlegi betűcsalád felülírásához. A [Fonts.remove_script_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/remove_script_font/) metódus eltávolít egy leképezést.

Az alábbi végpont‑végpont példakód beolvassa az összes meglévő fő és másodlagos leképezést, lekérdezi a japán fő betűtípust, módosítja a cirill fő betűtípust, eltávolítja a thaana másodlagos leképezést, elmenti a prezentációt, majd újra megnyitja, hogy ellenőrizze mindkét változást. Az eltávolítási lépést függetlené teszi a kezdeti témától, a példa csak akkor hoz létre thaana leképezést, ha az még nincs definiálva.

```python
import aspose.slides as slides


def print_script_font_map(label, fonts):
    print(label)
    for mapping in fonts.get_script_font_map():
        print(f"  {mapping.key}: {mapping.value}")


with slides.Presentation() as presentation:
    font_scheme = presentation.master_theme.font_scheme
    major_fonts = font_scheme.major
    minor_fonts = font_scheme.minor

    print_script_font_map("Existing major mappings:", major_fonts)
    print_script_font_map("Existing minor mappings:", minor_fonts)

    japanese_font = major_fonts.get_script_font("Jpan")
    if japanese_font is None:
        print("No major Japanese font is defined.")
    else:
        print(f"Major Japanese font: {japanese_font}")

    major_fonts.set_script_font("Cyrl", "Arial")

    if minor_fonts.get_script_font("Thaa") is None:
        minor_fonts.set_script_font("Thaa", "Arial")

    minor_fonts.remove_script_font("Thaa")
    presentation.save("script-font-mappings.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("script-font-mappings.pptx") as saved_presentation:
    saved_major_fonts = saved_presentation.master_theme.font_scheme.major
    saved_minor_fonts = saved_presentation.master_theme.font_scheme.minor
    saved_cyrillic_font = saved_major_fonts.get_script_font("Cyrl")
    saved_thaana_font = saved_minor_fonts.get_script_font("Thaa")

    if saved_cyrillic_font == "Arial":
        print("The Cyrillic mapping was preserved.")
    else:
        print("The Cyrillic mapping was not preserved.")

    if saved_thaana_font is None:
        print("The Thaana mapping removal was preserved.")
    else:
        print("The Thaana mapping still exists.")
```

Az ellenőrzés ugyanazt a `None` viselkedést használja, mint egy szokásos keresés: a törlés után mentve a `get_script_font("Thaa")` `None`‑t ad a másodlagos gyűjteményben.

## **A téma leképezéseinek megkülönböztetése a többi betűtípus‑beállítástól**

Az írásrendszer‑specifikus téma leképezések részt vesznek a betűtípus‑kiválasztásban, de más problémát oldanak meg, mint a közvetlen szövegformázás, a helyettesítés és a tartalékbetűtípus:

| Mechanizmus | Cél | A téma leképezés módosításának hatása |
|---|---|---|
| Írásrendszer‑specifikus téma betűtípus leképezés | Kiválaszt egy fő vagy másodlagos téma betűtípust egy írásrendszerhez. | A megfelelő téma betűtípust használó szöveg az új leképezett családra térhet át. |
| Közvetlenül szövegrészhez rendelt betűtípus | A kért betűcsaládot a konkrét részhez rögzíti, a témától függetlenül. | A rész változatlan maradhat, mert a közvetlen formázás felülírja a téma választását. |
| Betűtípus‑helyettesítés | Lecseréli a kért betűtípust, ha az nem érhető el, vagy ha helyettesítési szabály érvényesül. | A betűtípus kérés után lép életbe; nem módosítja a téma írásrendszer‑leképezését. |
| Betűtípus‑tartalék (fallback) | Hiányzó glifákat biztosít a kiválasztott betűtípusban, gyakran adott Unicode‑tartományokra. | Hiányzó glifákat pótol; nem változtatja meg a tárolt téma leképezést. |

A két utóbbi mechanizmusról további információkért lásd a [Font Substitution](/slides/hu/python-net/font-substitution/) és a [Fallback Fonts](/slides/hu/python-net/fallback-font/) oldalakat.

A [Presentation.master_theme](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/master_theme/) leképezésének módosítása csak azokra a tartalmakra van hatással, amelyek hatékony formázása még a témától függ. A szöveg örökölhet egy téma‑felülírást egy mesterből, elrendezésből vagy diából, vagy expliciten egy betűtípust használhat. Vizsgálja meg ezeket a szinteket, ha a látható eredmény nem a prezentáció‑szintű leképezésnek megfelelő.

## **Leképezett betűtípusok rendelkezésre álltatása és az eredmény ellenőrzése**

Egy script leképezés csak a betűcsalád nevét tárolja; nem telepíti vagy tölti be a megfelelő betűtárfájlt. Az egységes megjelenítés és export érdekében minden leképezett betűtípust telepíteni kell a környezetbe, vagy az Aspose.Slides‑nek egy egyedi forráson keresztül kell biztosítani, például a [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/load_external_fonts/) vagy a [LoadOptions.document_level_font_sources](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/document_level_font_sources/) használatával. Lásd a [Custom Fonts](/slides/hu/python-net/custom-font/) oldalt a rendelkezésre álló betöltési lehetőségekért.

A mentett leképezés ellenőrzése csak azt igazolja, hogy a téma definíciója megmaradt. Nem bizonyítja, hogy a betűtípus elérhető, tartalmazza az összes szükséges glifet, vagy a kívánt elrendezést eredményezi. Rendereljen reprezentatív szöveget minden szükséges írásrendszerhez képként vagy PDF‑ként, és ellenőrizze a kimenetet. Ez felfedi a hiányzó betűtípusokat, a hiányos glif‑lefedettséget, a fallback viselkedést és az elrendezés‑változásokat, mielőtt a prezentációt terjesztenék. Lásd a [Convert PowerPoint Presentations](/slides/hu/python-net/convert-powerpoint/) oldalt a renderelési és exportálási példákért.

## **GYIK**

**Mi a `get_script_font` visszatérési értéke, ha egy írásrendszer nincs leképezve?**

[Fonts.get_script_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/get_script_font/) `None`‑t ad vissza, ha a kért írásrendszer leképezése nincs definiálva az adott fő vagy másodlagos betűkészletben.

**A `set_script_font` hozzáad egy második leképezést, ha a script már létezik?**

Nem. [Fonts.set_script_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fonts/set_script_font/) létrehozza a leképezést, ha hiányzik, és felülírja a már meglévő betűcsaládot, ha a script címke már jelen van.

**Miért nem változott meg egyes szövegek, amikor a téma leképezését módosítottam?**

A szöveg lehet, hogy expliciten egy betűtípust kapott, egy másik témát örököl felülírással, vagy helyettesítés vagy fallback hat a megjelenítés során. A prezentáció‑szintű script leképezés csak azokra a szövegekre van hatással, amelyek hatékony formázása még a téma betűkészletére hivatkozik.

**Elég a mentés és újra‑megnyitás a többnyelvű kimenet ellenőrzéséhez?**

Nem. Az újra‑megnyitás csak a téma adatainak megmaradását ellenőrzi. Emellett rendereljen reprezentatív szöveget minden szükséges írásrendszerből, hogy megbizonyosodjon a leképezett betűtípusok elérhetőségéről és a szükséges glifek meglétéről.