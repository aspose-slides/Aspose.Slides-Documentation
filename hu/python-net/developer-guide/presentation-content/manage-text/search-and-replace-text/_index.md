---
title: Keresés és csere szöveg PowerPoint prezentációkban Python használatával
linktitle: Keresés és csere szöveg
type: docs
weight: 55
url: /hu/python-net/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- szövegkeret
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Keresés, kiemelés és szövegcsere PowerPoint prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes keresni, kiemelni és cserélni a szöveget egyetlen szövegkeretben vagy egy egész prezentációban. Ezek a lehetőségek hasznosak áttekintéshez, adateltávolításhoz, terminológiai ellenőrzésekhez, sablonok tisztításához és más automatizált dokumentumfeldolgozási munkafolyamatokhoz.

Az alábbi első példákban egy „sample.pptx” nevű fájlt használunk, amely az első dia egyetlen szövegdobozát tartalmazza a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Válassza ki a keresés hatókörét**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) metódusait, hogy egy műveletet egy szövegkeretre korlátozzon. Használja a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) metódusait, hogy a prezentációban minden alkalmazható szöveget feldolgozzon.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Szó szerinti szöveg kiemelése | [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_text/) |
| Reguláris kifejezés egyezéseinek kiemelése | [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_regex/) |
| Szó szerinti szöveg cseréje | [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_text/) |
| Reguláris kifejezés egyezéseinek cseréje | [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_regex/) |

## **Szöveg egyezés konfigurálása**

Szó szerinti műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/) osztályt az egyezés szabályozásához:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/whole_words_only/) korlátozza a találatot teljes szavakra.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/case_sensitive/) szabályozza, hogy a karakterek nagy‑ és kisbetűi meg kell-e egyezzenek.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/include_notes/) bevonja a diák megjegyzéseit a prezentációszintű keresés, csere és kiemelés műveletekbe.

A reguláris kifejezésekkel végzett műveleteknek mintaszövege van, így az olyan szabályok, mint a kis‑ és nagybetűkérzékenység vagy a szóhatárok, a kifejezésben vannak meghatározva.

## **Azonosítsa a szövegkeret tulajdonosát**

Az általános szövegfeldolgozó munkafolyamatok gyakran egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot kapnak, miközben keresnek, cserélnek, ellenőriznek vagy exportálnak szöveget. Használja a [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) és a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) tulajdonságokat annak meghatározásához, hogy melyik prezentációs objektum birtokolja a szövegkeretet.

A várt értékek a tulajdonostól függenek:

| Szövegkeret tulajdonosa | `parent_shape` | `parent_cell` |
|---|---|---|
| AutoShape vagy egy másik szöveget tartalmazó alakzat | A tulajdonos [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) | `None` |
| Egy táblázat cella | `None` | A tulajdonos [Cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/) |

Mindkét tulajdonság csak‑olvasású navigációs tulajdonság. Olvasásuk nem mozgatja a szövegkeretet, illetve nem változtatja meg a tulajdonost. Az általános kódban ellenőrizni kell mindkét értéket `None`‑ra, és kezelni kell azt a lehetőséget, hogy egyik tulajdonos sem áll rendelkezésre.

A következő példa a [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/get_all_text_frames/) segítségével iterál a prezentáció szövegkeretei között. Alakzatok esetén a forma nevét, a Python futásidejű típusát és a tartalmazó diát jelenti. Táblázat cellák esetén a nulla‑bázisú oszlop‑ és sor‑koordinátákat, valamint a tartalmazó diát jelenti.

```python
import aspose.slides as slides


def get_slide_label(base_slide):
    if isinstance(base_slide, slides.Slide):
        return f"slide {base_slide.slide_number}"

    if isinstance(base_slide, slides.NotesSlide):
        return f"notes for slide {base_slide.parent_slide.slide_number}"

    return type(base_slide).__name__


with slides.Presentation("presentation.pptx") as presentation:
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, False)

    for text_frame in text_frames:
        owner_shape = text_frame.parent_shape
        if owner_shape is not None:
            shape_name = owner_shape.name or "(unnamed)"
            shape_type = type(owner_shape).__name__
            slide_label = get_slide_label(owner_shape.slide)
            print(f"Shape: {shape_name}; type: {shape_type}; {slide_label}")
            continue

        owner_cell = text_frame.parent_cell
        if owner_cell is not None:
            slide_label = get_slide_label(owner_cell.slide)
            print(f"Table cell: column {owner_cell.first_column_index}, row {owner_cell.first_row_index}; {slide_label}")
            continue

        print("The text frame owner is not available as a shape or table cell.")
```

A SmartArt tartalom esetén iteráljon a [SmartArtNode.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartartnode/shapes/) alakzatai között, és érje el minden [ISmartArtShape.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/ismartartshape/text_frame/) elemet. A szövegkeret a [TextFrame.parent_shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_shape/) segítségével követhető vissza a hozzá tartozó alakzatra, míg a [TextFrame.parent_cell](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/parent_cell/) értéke `None`. Ezért a példában a forma ága szintén a SmartArt csomópontok szövegét kezeli.

## **Szöveg kiemelése**

Használja a [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/) metódust a szó szerinti egyezések kiemelésére egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/) beállításait a keresés szabályozásához.

Az alábbi kódrészlet kiemeli a **„try”** karaktereket, majd csak a teljes **„to”** szót emeli ki.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Kiemeli a "try" szövegrész minden előfordulását a szövegkeretben.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Kiemeli csak a teljes "to" szót.
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

A [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/) metódus kiemeli a reguláris kifejezéssel megtalált szövegegyezéseket egy szövegkeretben.

Az alábbi kód kiemeli az összes olyan szót, amely legalább hét karaktert tartalmaz:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    word_pattern = r"\b[^\s]{7,}\b"

    shape.text_frame.highlight_regex(word_pattern, draw.Color.yellow, None)

    presentation.save(
        "highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX
    )
```

Az eredmény:

![A kiemelt szöveg reguláris kifejezéssel](highlighted_text_using_regex.png)

## **Szöveg kiemelése prezentáción keresztül**

Használja a [Presentation.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_text/) és a [Presentation.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_regex/) metódusokat a prezentációban alkalmazható összes szövegkeret kereséséhez. A következő példa kiemel egy szó szerinti kifejezést és az összes e‑mail címet:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    presentation.highlight_text(
        "confidential", draw.Color.orange, search_options, None
    )

    email_pattern = r"(?i)\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b"
    presentation.highlight_regex(email_pattern, draw.Color.yellow)

    presentation.save(
        "highlighted_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **Szöveg cseréje egy szövegkeretben**

Használja a [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) metódust szó szerinti szöveghez, illetve a [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) metódust mintára alapozott cseréhez. Ezek a metódusok a megtalált szöveget a meglévő szövegkereten belül frissítik, amely megőrzi a környező részformázást a sima karakterláncból történő újraépítés helyett.

Az alábbi példa egységesíti egy helyesírási változatot, majd verziócímkéket cserél:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = False

    shape.text_frame.replace_text(
        "colour", "color", search_options, None
    )

    version_pattern = r"(?i)\bv\d+(?:\.\d+)*\b"
    shape.text_frame.replace_regex(version_pattern, "current version")

    presentation.save(
        "updated_text_frame.pptx", slides.export.SaveFormat.PPTX
    )
```

Ha egy egyezés több, különböző formázású részt ölel fel, ellenőrizze a kimenetet, hogy melyik formázás legyen alkalmazva a csere szövegére.

## **Szöveg cseréje prezentáción keresztül**

Használja a [Presentation.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_text/) és a [Presentation.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_regex/) metódusokat, hogy ugyanazokat a műveleteket a teljes prezentáción alkalmazza. Ez hasznos sablonok tisztításához, terminológiai frissítésekhez és adateltávolításhoz.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True

    presentation.replace_text(
        "Contoso", "Example Corp", search_options, None
    )

    account_number_pattern = r"\bACCT-\d{6}\b"
    presentation.replace_regex(account_number_pattern, "ACCT-REDACTED")

    presentation.save(
        "updated_presentation.pptx", slides.export.SaveFormat.PPTX
    )
```

## **GYIK**

**Hogyan kereshetek csak egy szövegdobozban az egész prezentáció helyett?**

Szerezze be az alakzat szövegkeretét, és hívja meg a [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) vagy [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) metódusok egyikét azon a szövegkereten. A prezentációszintű metódusok az összes alkalmazható szövegkeretet dolgozzák fel.

**Hogyan egyeztessek teljes szavakat a helyes nagybetűkkel?**

Állítsa a [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/whole_words_only/) és a [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/case_sensitive/) értékét `True`‑ra, majd adja át a beállításokat egy szó szerinti kiemelés vagy csere metódusnak. Reguláris kifejezéseknél határozza meg a szóhatárokat és a nagy‑ és kisbetű‑érzékenységet magában a mintában.

**A keresés és csere magában foglalhatja a diák megjegyzéseiben lévő szöveget?**

Igen. Állítsa a [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/include_notes/) értékét `True`‑ra, amikor prezentációszintű szó szerinti műveletet használ.

**Megőrzi a szövegformázást a csere során?**

A [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) és a [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megőrzi a környező részek formázását. Ha egy egyezés több, különböző formázású részt ölel fel, vizsgálja meg az eredményt, hogy a csere a kívánt stílust használja‑e.