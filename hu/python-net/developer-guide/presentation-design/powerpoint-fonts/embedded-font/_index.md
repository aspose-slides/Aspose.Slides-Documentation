---
title: Betűtípusok beágyazása prezentációkba Pythonban
linktitle: Beágyazott betűtípusok
type: docs
weight: 40
url: /hu/python-net/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérdezése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Kezelje a PowerPoint‑ban beágyazott betűtípusokat az Aspose.Slides for Python via .NET segítségével. Használja a Python‑t betűtípusok hozzáadásához, lekérdezéséhez, eltávolításához és tömörítéséhez, hogy megőrizze a szöveg megjelenését és csökkentse a fájlméretet."
---
## **Bevezetés**

A betűtípusok beágyazása a betűtípus adatokat egy PowerPoint‑prezentációba helyezi. Ha a megjelenítő támogatja a beágyazott betűtípusokat, akkor a szöveget ezekkel a betűtípusokkal tudja megjeleníteni még akkor is, ha azok nincsenek telepítve a cérrendszeren. Ez segít megőrizni a sortöréseket, a szövegtávolságot és a diaelrendezést.

Az Aspose.Slides for Python via .NET lehetővé teszi a beágyazott betűtípusok lekérdezését, hozzáadását és eltávolítását a [fonts_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/fonts_manager/) tulajdonságon keresztül egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumnál. A beágyazott betűtípusadatok méretét is csökkenthetjük a bemutatóban nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. Betűtípus beágyazása előtt győződjön meg arról, hogy a betűtípus adat elérhető az Aspose.Slides számára, és a licenc engedélyezi a beágyazást.

## **Beágyazott betűtípusok lekérése és eltávolítása**

Használja a [get_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) metódust a prezentációban tárolt betűtípusok listázásához. Egy betűtípus eltávolításához adja át a listából származó betűtípust a [remove_embedded_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/remove_embedded_font/) metódusnak, majd mentse a prezentációt.

Az alábbi példa listázza a `EmbeddedFonts.pptx` beágyazott betűtípusait, és eltávolítja a Calibrít, ha jelen van:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

Egy beágyazott betűtípus eltávolítása a tárolt betűtípusadatokat törli; a szöveghez rendelt betűtípust nem változtatja meg. Ha a betűtípus telepítve van a célrendszeren, a szöveg továbbra is azt használhatja. Ellenkező esetben a megjelenítéshez [font substitution](/slides/hu/python-net/font-substitution/) lehet szükséges, ami befolyásolhatja az elrendezést.

## **Betűtípus adatok és beágyazási engedélyek ellenőrzése**

Használja a [FontsManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/) osztályt a betűtípusok beágyazása előtti vizsgálatához. Hívja a [get_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) metódust a prezentációban használt betűtípusok lekéréséhez. Minden betűtípushoz adjon át egy [FontData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontdata/) objektumot és a kívánt [FontStyleType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontstyletype/) értéket a [get_font_bytes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_font_bytes/) metódusnak. A metódus a betűtípus stílusához tartozó bináris adatot adja vissza, vagy `None`‑t, ha a kért betűtípus vagy stílus nem elérhető. Ne adjon `None` eredményt a [get_font_embedding_level](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_font_embedding_level/) metódusnak, mert az egy byte tömböt vár.

Az [EmbeddingLevel](https://reference.aspose.com/slides/hu/python-net/aspose.slides/embeddinglevel/) egy zászló‑enumeráció, amely a betűtípusban tárolt beágyazási korlátozásokat jelzi:

- `INSTALLABLE` engedélyezi a beágyazást és a végleges telepítést egy másik rendszeren, a betűtípus licencétől függően.
- `RESTRICTED` megtiltja a beágyazást, hacsak a betűtípus jogtulajdonosától nem kap engedélyt, ha ez az egyetlen használati‑engedély zászló.
- `PREVIEW_PRINT` ideiglenes használatot enged meg megtekintésre és nyomtatásra; a betűtípust tartalmazó dokumentumnak csak olvasható legyen.
- `EDITABLE` ideiglenes használatot enged, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NO_SUBSETTING` egy további korlátozás, amely megtiltja a betűtípus csak egy részhalmazának beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BITMAP_ONLY` egy további korlátozás, amely csak bitmap‑változatok beágyazását engedélyezi, nem az ívbetű adatot. Ha a betűtípusnak nincs bitmap‑változata, nem ágyazható be.

Az első négy érték a használati engedélyt írja le, míg a `NO_SUBSETTING` és a `BITMAP_ONLY` kombinálható velük. Ellenőrizze a módosítókat bitwise műveletekkel. Mivel a `INSTALLABLE` értéke nulla, maszkolja a használati‑engedély biteket, és hasonlítsa össze az eredményt a `INSTALLABLE`‑nal. A jelenlegi betűtípusoknak legfeljebb egy használati‑engedély bitet kell beállítaniuk. Régebbi betűtípusok esetén, amelyek több engedélyt is beállítanak, az alábbi segédfüggvény a legkevésbé szigorú engedélyt választja: `EDITABLE`, majd `PREVIEW_PRINT`, majd `RESTRICTED`.

Az alábbi példa auditálja a minden betűtípusra vonatkozó normál, félkövér, dőlt és félkövér‑dőlt adatokat, amelyet a `get_fonts` visszaad. Kihagyja a nem elérhető stílusokat, a korlátozott betűtípusokat, a csak bitmap‑betűtípusokat, a csak előnézet‑nyomtatásra korlátozott betűtípusokat, mert a kimenet szerkeszthető marad, valamint a már beágyazott betűtípusokat. Ha bármely elérhető stílus rendelkezik `NO_SUBSETTING`‑kel, az összes karaktert beágyazza az adott betűtípuscsaládhoz.

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Ez az ellenőrzés jelentést ad a betűtípusfájlokban kódolt korlátozásokról. Nem ad licencet, nem bizonyítja, hogy a betűtípust legálisan szerezte be, és nem helyettesíti a betűtípus licencszerződésének ellenőrzését, mielőtt beágyazott másolatot terjesztene.

## **Beágyazott betűtípusok hozzáadása**

Használja a [add_embedded_font](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/add_embedded_font/) metódust betűtípus beágyazásához. A túlterhelések elfogadnak vagy egy [FontData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontdata/) objektumot, vagy egy byte tömböt, amely a betűtípus adatot tartalmazza. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/embedfontcharacters/) enumeráció szabályozza, mely karakterek kerülnek beágyazásra:

- [ALL](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/embedfontcharacters/) az összes karaktert beágyazza a betűtípusban. Ezt akkor használja, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell beírniuk.
- [ONLY_USED](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be, hogy csökkentse a fájlméretet. Válassza ezt a beállítást befejezett, elsősorban megtekintésre szánt prezentáció esetén.

Az alábbi példa a [get_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_fonts/) metódust használja a `Fonts.pptx` fájlban használt betűtípusok lekéréséhez, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűtípusoknak elérhetőnek kell lenniük a kódot futtató gépen. A már beágyazott betűtípusok megtartják a jelenlegi karakterkészletüket.

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **Beágyazott betűtípusok tömörítése**

A [compress_embedded_fonts](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) a beágyazott betűtípus adatot csökkenti a nem használt karakterek eltávolításával. Olyan betűtípusokon működik, amelyek már be vannak ágyazva, ezért a méretcsökkenés a prezentációban lévő fel nem használt betűtípusadat mennyiségétől függ.

Az alábbi példa tömöríti a `EmbeddedFonts.pptx` fájl betűtípusait, és a végeredményt külön fájlba menti:

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

Tartsa meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem érhetők el a beágyazott betűtípusból, még akkor sem, ha eredetileg az összes karaktert beágyazta.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűtípus helyettesítésre kerül-e a megjelenítés során?**

Hívja a [get_substitutions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsmanager/get_substitutions/) metódust abban a környezetben, ahol a prezentációt rendereli, hogy megtudja, mely betűtípusokat cseréli le az Aspose.Slides. Ellenőrizze a [font substitution](/slides/hu/python-net/font-substitution/) beállításait és a [font fallback](/slides/hu/python-net/fallback-font/) szabályait is. A tartalék a hiányzó karaktereket kezeli, ezért a betűtípus beágyazása nem oldja meg azokat a karaktereket, amelyek a betűtípusban nincsenek.

**Be kellene-e ágyaznom gyakori betűtípusokat, mint az Arial és a Calibri?**

A döntést a célkörnyezet alapján hozza meg. Ha a szükséges betűtípusok minden gépen elérhetőek, amely megnyitja vagy rendereli a prezentációt, akkor a beágyazás csak felesleges fájlméretet ad hozzá. Ha a címzettek vagy a szerverek esetleg hiányolják ezeket a betűtípusokat, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve, hogy a licenc megengedi.