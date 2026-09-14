---
title: Betűtípusok beágyazása prezentációkba Pythonon keresztül Java-val
linktitle: Beágyazott betűtípusok
type: docs
weight: 40
url: /hu/python-java/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Kezelje a PowerPoint beágyazott betűtípusait az Aspose.Slides for Python via Java segítségével. Adjon hozzá, kérjen le, távolítson el és tömörítsen betűtípusokat, hogy megőrizze a szöveg megjelenését és csökkentse a fájlméretet."
---
## **Bevezetés**

A betűtípusok beágyazása a betűtípus adatokat egy PowerPoint‑prezentációban tárolja. Ha egy megjelenítő támogatja a beágyazott betűtípusokat, képes a szöveget azokkal megjeleníteni, még akkor is, ha a célrendszeren nincsenek telepítve. Ez segít megőrizni a sortöréseket, a szöveg távolságát és a diák elrendezését.

Az Aspose.Slides for Python via Java lehetővé teszi a beágyazott betűtípusok lekérdezését, hozzáadását és eltávolítását a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztályon keresztül, amelyet a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getFontsManager) ad vissza. Emellett csökkentheti a beágyazott betűtípus adat méretét a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. A betűtípus beágyazása előtt győződjön meg róla, hogy a betűtípus adat elérhető az Aspose.Slides számára, és a licence engedélyezi a beágyazást.

## **Beágyazott betűtípusok lekérése és eltávolítása**

Használja a [getEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) metódust a prezentációban tárolt betűtípusok listázásához. Egy betűtípus eltávolításához adja át a listából a betűtípust a [removeEmbeddedFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) metódusnak, majd mentse a prezentációt.

Az alábbi példa listázza a beágyazott betűtípusokat a `EmbeddedFonts.pptx` fájlban, és eltávolítja a Calibrít, ha jelen van:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

A beágyazott betűtípus eltávolítása törli a tárolt betűtípus adatot; nem változtatja meg a szöveghez rendelt betűtípust. Ha a betűtípus telepítve van a célrendszeren, a szöveg továbbra is használhatja. Ellenkező esetben a megjelenítés betűtípus helyettesítést igényelhet, ami befolyásolhatja az elrendezést.

## **Betűtípusadatok és beágyazási engedélyek ellenőrzése**

Használja a [FontsManager](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/) osztályt a betűtípusok beágyazás előtti ellenőrzéséhez. Hívja a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFonts) metódust a prezentációban használt betűtípusok lekéréséhez. Minden betűtípushoz adjon át egy [FontData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontdata/) objektumot és a szükséges [FontStyleType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontstyletype/) értéket a [FontsManager.getFontBytes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFontBytes) metódusnak. A metódus visszaadja a betűtípus stílus bináris adatait, vagy `None`-t, ha a kért betűtípus vagy stílus nem érhető el. Ne adja át a `None` eredményt a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) metódusnak, mert ez a metódus byte tömböt igényel.

[EmbeddingLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/embeddinglevel/) egy zászló‑enumeráció, amely a betűtípusban tárolt beágyazási korlátozásokat jelzi:

- `Installable` engedélyezi a beágyazást és a betűtípus állandó telepítését egy másik rendszeren, a betűtípus licencétől függően.
- `Restricted` tilos a beágyazás, kivéve ha a betűtípus jogi tulajdonosától engedélyt szereznek, amikor ez az egyetlen használati‑engedély zászló.
- `PreviewPrint` ideiglenes használatot enged meg a megtekintéshez és nyomtatáshoz; a betűtípust tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` ideiglenes használatot enged, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` egy további korlátozás, amely megtiltja a csak egy részhalmaz beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` egy további korlátozás, amely csak bitmap változatok beágyazását engedélyezi, nem az outline adatokat. Ha a betűtípusnak nincs bitmap változata, nem lehet beágyazni.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és a `BitmapOnly` kombinálható velük. A módosítókat bitműveletekkel ellenőrizze. Mivel az `Installable` értéke nulla, maszkolja a használati‑engedély biteket, és hasonlítsa az eredményt az `Installable` értékével ahelyett, hogy zászlóként vizsgálná. A jelenlegi betűtípusoknak legfeljebb egy használati‑engedély bitet kell beállítaniuk. Az alábbi segédprogram a régebbi, több engedélyt beállító betűtípusok kompatibilitására a legkevésbé korlátozó engedélyt választja: `Editable`, majd `PreviewPrint`, majd `Restricted`.

Az alábbi példa auditálja a normál, félkövér, dőlt és félkövér‑dőlt adatokat, amelyek minden a `getFonts` által visszaadott betűtípushoz elérhetők. Kihagyja a nem elérhető stílusokat, a korlátozott betűtípusokat, a csak‑bitmap betűtípusokat, a csak előnézet‑nyomtatásra korlátozott betűtípusokat, mivel a kimenet szerkeszthető marad, valamint a már beágyazott betűtípusokat. Ha bármely elérhető stílusnak `NoSubsetting` beállítása van, akkor az adott betűtípuscsalád minden karakterét beágyazza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez az ellenőrzés a betűtípusfájlokban kódolt korlátozásokat jelenti. Nem biztosít licencet, nem bizonyítja, hogy a betűtípust legálisan szerezték be, és nem helyettesíti a betűtípus licencszerződésének ellenőrzését a beágyazott példány terjesztése előtt.

## **Beágyazott betűtípusok hozzáadása**

Használja az [addEmbeddedFont](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) metódust egy betűtípus beágyazásához. A túlterhelései vagy egy [FontData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontdata/) objektumot, vagy a betűtípus adatot tartalmazó byte tömböt fogadnak. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/python-java/aspose.slides/embedfontcharacters/) enumeráció szabályozza, hogy mely karakterek legyenek beágyazva:

- [All](https://reference.aspose.com/slides/hu/python-java/aspose.slides/embedfontcharacters/) beágyazza a betűtípus összes karakterét. Ezt a beállítást használja, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell bevinniük.
- [OnlyUsed](https://reference.aspose.com/slides/hu/python-java/aspose.slides/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be a fájlméret csökkentése érdekében. Válassza ezt a beállítást egy elkészült, főként megtekintésre szánt prezentációhoz.

Az alábbi példa a [getFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getFonts) metódust használja a `Fonts.pptx` fájlban használt betűtípusok lekéréséhez, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűtípusoknak elérhetőnek kell lenniük a kódot futtató gépen. A már meglévő beágyazott betűtípusok megtartják jelenlegi karakterkészletüket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Beágyazott betűtípusok tömörítése**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compress/#compressEmbeddedFonts) csökkenti a beágyazott betűtípus adatok méretét a nem használt karakterek eltávolításával. Már beágyazott betűtípusokon működik, így a méretcsökkenés függ attól, mennyi nem használt betűtípus adat van a prezentációban.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` fájlban lévő betűtípusokat, és a eredményt külön fájlba menti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tartsa meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem érhetők el a beágyazott betűtípusból, még akkor sem, ha eredetileg az összes karaktert beágyazta.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűtípust a megjelenítés során még mindig helyettesítenek‑e?**

Hívja meg a [getSubstitutions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontsmanager/#getSubstitutions) metódust abban a környezetben, ahol a prezentációt rendereli, hogy lássa, mely betűtípusokat fogja az Aspose.Slides helyettesíteni. Ellenőrizze a betűtípus helyettesítési beállításokat és a betűtípus fallback szabályokat is. A fallback a hiányzó karaktereket kezeli, így a betűtípus beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűtípus önmagában nem tartalmaz.

**Be kellene ágyaznom olyan általános betűtípusokat, mint az Arial és a Calibri?**

A döntést a célkörnyezet alapján hozza meg. Ha a szükséges betűtípusok minden gépen elérhetők, amely megnyitja vagy rendereli a prezentációt, a beágyazás felesleges fájlméret növekedést okozhat. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűtípusokkal, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencük ezt engedélyezi.