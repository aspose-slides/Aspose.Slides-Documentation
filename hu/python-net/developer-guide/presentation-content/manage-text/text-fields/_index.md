---
title: Szövegmezők kezelése PowerPoint prezentációkban Pythonban
linktitle: Szövegmezők
type: docs
weight: 52
url: /hu/python-net/text-fields/
keywords:
- szövegmező
- automatikus szöveg
- diacím
- dátum és idő
- fejléc
- lábléc
- szövegrész
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Hozzon létre, ellenőrizzen, módosítson és távolítson el szövegmezőket PowerPoint prezentációkban az Aspose.Slides for Python .NET segítségével. Tartsa meg a formázást, és ellenőrizze a mentett PPTX és PPT fájlokat."
---
## **Áttekintés**

Egy szöveg bekezdés részekből áll. Egy hétköznapi [Rész](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) szó szerinti szöveget tartalmaz; egy mező része továbbá egy [Mező](https://reference.aspose.com/slides/hu/python-net/aspose.slides/field/) is, amelynek típusa automatikusan frissített értéket jelöl, például diacím vagy dátum. Két rész is megjelenítheti ugyanazokat a karaktereket, de csak az egyik tartalmaz mezőt.

Használja a [Portion.field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/field/) tulajdonságot a megkülönböztetéshez: szokásos szöveg esetén `None`. A [Portion.add_field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/add_field/) átalakít egy meglévő részt mezővé. Tartsa a címkét és a dinamikus értéket külön részekben, hogy az érték átalakítása ne helyettesítse a címkét is.

Ez az útmutató a szövegben lévő mezőket, azok formázását és a PPTX illetve PPT mentését tárgyalja. A szövegkeretek és bekezdések kezelése a [Szöveg kezelése](/slides/hu/python-net/manage-text/) oldalán található.

## **Diacím mező létrehozása**

Az alábbi teljes példa egy szövegdobozt hoz létre, amely egy szöveges `Slide ` címkét tartalmaz, majd egy automatikusan frissített számot. Beállítja a szám méretét, súlyát és színét a mező hozzáadása előtt, majd újra megnyitja a mentett prezentációt, és ellenőrzi a mező típusát, szövegét és formázását. Nem szükséges bemeneti fájl.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

Az új prezentáció az 1. diával indul, így a szöveg `Slide 1`, és mindkét ellenőrzés `True` értéket ad. A szám a megnyitás után is mező marad; nem szó szerinti `1`. Az ellenőrzésben szereplő indexek az ebben a példában létrehozott alakzatot és részeket jelölik.

## **Mező típusának kiválasztása**

A [FieldType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/) a következő előre definiált értékeket biztosítja. A megfelelő értéket adja át a [add_field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/add_field/) metódusnak.

| Value | Purpose |
|---|---|
| [slide_number](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/slide_number/) | Az aktuális diacím. |
| [date_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time/) | Dátum/idő az alkalmazás alapértelmezett formátumában. |
| [date_time1](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time9/) | Előre definiált dátum- vagy kombinált dátum/idő formátumok. |
| [date_time10](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time13/) | Előre definiált időformátumok, másodperc és 12‑órás óra lehetőséggel. |
| [header](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/header/) | Fejlécmező; lásd az alábbi helyőrző‑ és formátumkorlátozásokat. |
| [footer](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/footer/) | Lábjegyzetmező. |

Például a [date_time3](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/date_time3/) egy napot, a teljes hónap nevét és az évet jeleníti meg angolul. Ezek előre definiált mezőformátumok, nem tetszőleges Python dátumformátum‑karakterláncok. A rész [language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/language_id/) beállítása és az alkalmazás, amely a prezentációt feldolgozza, befolyásolhatja a megjelenített eredményt.

## **Mező létrehozása belső karakterláncból**

A [add_field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/add_field/) karakterlánc‑túlterhelése egy belső mezőazonosítót fogad. Akkor használja, ha egy másik alkalmazás által megadott azonosítót kell megőrizni, amelynek nincs előre definiált értéke. Készíthet egy [FieldType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/__init__/) objektumot is az azonosítóból. A [FieldType.internal_string](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fieldtype/internal_string/) az azonosítót teszi elérhetővé ellenőrzés céljából.

Ez a példa egy alkalmazás‑specifikus `custom-report-id` mezőt tárol a tartalék szöveggel `Report-042`. Az azonosító nem regisztrál számítást: az Aspose.Slides nem generál jelentés‑azonosítókat ismeretlen típushoz. A jelentést értelmező alkalmazásnak kell biztosítania a jelentés jelentését és frissítenie a mező értékét.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

A PPTX körúttal visszaolvasás után a típus `custom-report-id`, a szöveg pedig `Report-042`. Egy `%Y-%m-%d` karakterlánc átadása mezőtípus‑nevet eredményezne, nem egy egyéni dátumformátumot. Rögzített dátum tetszőleges formátumban egyszerű szövegként kell megadni.

## **Dátum/Idő mezők vizsgálata, módosítása és eltávolítása**

Olvassa és módosítsa a meglévő mezőt a [Field.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/field/type/) segítségével. Ellenőrizze, hogy a mező létezik‑e, mielőtt a típusához hozzáférne. Az automatikus frissítések leállításához hívja meg a [Portion.remove_field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/remove_field/) metódust. Ez megőrzi a részt és a jelenlegi szöveget, miközben eltávolítja a mezőkapcsolatot. Ha egy konkrét rögzített értékre van szükség, a mező eltávolítása után állítsa be azt a szöveget.

A dátum/idő mezők feldolgozásához kapcsolódó API‑beállítást lásd a [Presentation.current_date_time](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/current_date_time/) oldalon. Az alábbi példa egy kifejezett jóváhagyási dátumot használ, amikor a mezőt szokásos szöveggé konvertálja. Egy angol hónap‑nevekből álló tuple biztosítja, hogy a rögzített dátum független legyen a rendszer nyelvi beállításától.

Töltse le a [sample.pptx](sample.pptx) fájlt, és helyezze a munkakönyvtárba. A fájl két elnevezett szövegalakzatot tartalmaz, `UpdatedAt` és `ApprovedDate`‑t, mindkettőn dátum/idő mező található, valamint szokásos szövegcímkék. Az alábbi példa minden felső‑szintű szövegalakzatot bejár a normál diákon. A dátum/idő mezőket hosszú dátumformátumra alakítja, dőlt betűvé teszi, miközben a többi formázást megőrzi. Csak a `ApprovedDate` mező lesz rögzített szöveg.

A minta felismeri a beépített belső azonosítókat `datetime`‑től `datetime13`‑ig. Csoportok, táblázatok, megjegyzések, elrendezések és mester‑diák saját szövegtárolóikat igénylik, így ez az példa keretén kívül marad.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

A megnyitás után az `UpdatedAt` típusa `datetime3`, és dinamikus marad. Az `ApprovedDate` mezője eltűnt, a szöveg `05 April 2030`. Mindkét dátumrész dőlt, eredeti betűméret, félkövér beállítás és szín változatlan. A szokásos szövegcímkék nem változnak. Az ellenőrzés a két ismert alakzat első részét olvassa be a mellékelt mintában.

## **Szövegformázás megőrzése**

Dolgozzon a meglévő résszel, amikor mezőt ad hozzá, a típusát módosítja vagy eltávolítja. Ezek a műveletek megtartják a rész formázását. Használja a [Portion.portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/portion_format/)‑t csak a szükséges tulajdonságok módosításához, ahogyan a példák a szín vagy a dőlt betű esetén is teszik.

Kerülje el egy teljes szövegkeret újbóli felépítését csak egy mező frissítése miatt: ez elveszítheti az eredeti részhatárokat és azok egyedi formázását. Emellett különböztesse a kifejezetten beállított formázást a bekezdésből, elrendezésből vagy témából örökölt formázástól. Tekintse meg a [Szöveg formázása](/slides/hu/python-net/text-formatting/) oldalt a szélesebb formázási lehetőségekért.

## **Mezők és fejléc/lábléc helyőrzők**

Egy mező egy szövegrész része. Egy helyőrző egy prezentációs szereppel rendelkező alakzat, például lábléc vagy diacím. Egy mező hozzáadása egy szokásos szövegdobozhoz nem változtatja azt helyőrzővé.

A fejléc/lábléc kezelők a helyőrző szöveget és láthatóságot szabályozzák a diákon, elrendezéseken és mestereken, beleértve a függő diákra való kiterjesztést. Egy egyéni szövegdobozban lévő számmező ezért hasznos lehet még akkor is, ha nem használja a diacím helyőrzőt. Ezzel szemben a helyőrző láthatóságának módosítása nem távolít el egy mezőt egy nem kapcsolódó szövegdobozból.

Az előre definiált fejléc‑ és lábléc típusok nem hoznak létre megfelelő helyőrzőket, és nem biztosítják a tartalmukat. Különösen, egy szokványos PowerPoint dia nem tartalmaz fejléc‑helyőrzőt; a fejlécek a jegyzetoldalakhoz és kézjegyzetekhez tartoznak. Ne tévúton gondolja, hogy egy fejléc‑ vagy láblécmező egy tetszőleges alakzatban automatikusan megkapja a helyőrző‑kezelő által beállított szöveget. Erről a munkafolyamatról lásd a [Prezentáció fejléc és lábléc](/slides/hu/python-net/presentation-header-and-footer/) oldalt.

## **PPTX és PPT korlátai**

Ellenőrizze mind a mező típusát, mind a mentés után megjelenő szöveget. Egy azonosító megőrzése önmagában nem bizonyítja, hogy egy alkalmazás képes számítani vagy megjeleníteni annak értékét.

| Format | Field behavior and limitations |
|---|---|
| PPTX | Belső mezőazonosítókat tárol a mezőszöveggel együtt. A körútes ellenőrzések során az előre definiált típusok és a fent használt egyedi azonosító is megmaradt a mentés és újranyitás után. Az ismeretlen egyedi típus a tartalék szövegét megtartotta; nem kapott automatikus számítási logikát. Egy másik alkalmazás másként kezelheti a nem támogatott azonosítókat. |
| PPT | Régi mezőábrázolást használ, és korlátozottabb kompatibilitással rendelkezik. A körútes ellenőrzések során a diacím és az előre definiált dátum/idő mezők megmaradtak. Egy egyedi mező egy szokásos szövegdobozban azonosítóval, de `*` szöveggel nyílt meg; egy fejlécmező ugyanabban a kontextusban is `*`‑ot adott. Ne számítson arra, hogy egyedi mezők vagy nem támogatott mezőkontextusok megőrzik a látható szövegüket. |

Az hordozható, rögzített kimenet érdekében konvertálja a nem támogatott mezőket szokásos szöveggé, és a mentés előtt adja meg a kívánt értéket. Ez megőrzi a kiválasztott szöveget, de szándékosan leállítja az automatikus frissítéseket. Tesztelje a célnyelvi alkalmazást is, ha annak saját mezőújraszámítása része a munkafolyamatnak.

## **GYIK**

**Hogyan tudom megállapítani, hogy egy megjelenített szám vagy dátum mező?**

Vizsgálja meg a [Portion.field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/field/) értékét. A `None`‑tól eltérő érték mezőt jelez; a megjelenő szöveg önmagában nem elég.

**Eltávolítja a mező eltávolítása a szöveget vagy a formázást?**

Nem. A [remove_field](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/remove_field/) a meglévő részt szokásos szöveggé alakítja. Ha egy meghatározott fagyasztott dátumra vagy tartalékértékre van szüksége, azt a mező eltávolítása után adja meg.

**Definiálhat-e egy belső karakterlánc új dátumformátumot vagy képletet?**

Nem. Csak egy mező típusát azonosítja. Egy ismeretlen azonosító nem biztosít kiértékelőt vagy Python dátumformátum‑mintát. Használjon támogatott előre definiált típust, vagy formázza a kívánt értéket egyszerű szövegként.

**Miért ellenőrizze újra a prezentációt a mentés után?**

A mezőazonosítók, a számított szöveg és a formázás külön ellenőrzendő elemek. A formátumkonverzió megváltoztathatja a látható eredményt, még ha a mezőazonosító továbbra is jelen van.