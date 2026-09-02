---
title: PowerPoint prezentációk szövegének keresése és cseréje Pythonban
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/python-net/search-and-replace-text/
keywords:
- keresés szöveg
- kiemelés szöveg
- csere szöveg
- reguláris kifejezés
- szövegkeret
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Keresés, kiemelés és csere szöveget PowerPoint prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET képes keresni, kiemelni és helyettesíteni a szöveget egyetlen szövegkeretben vagy egy teljes prezentáción. Ezek a képességek hasznosak felülvizsgálathoz, sötétítéshez, terminológiai ellenőrzésekhez, sablon-tisztításhoz és más automatizált dokumentumfeldolgozási munkafolyamatokhoz.

Az alábbi első példákban egy **sample.pptx** nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **A keresés hatókörének kiválasztása**

Használja a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) metódusait egy művelet egy szövegkeretre korlátozásához. Használja a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) metódusait a prezentációban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Kiemelés szó szerinti szöveg | [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_text/) |
| Kiemelés reguláris kifejezés egyezések | [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_regex/) |
| Csere szó szerinti szöveg | [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_text/) |
| Csere reguláris kifejezés egyezések | [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_regex/) |

## **Szövegillesztés beállítása**

Szó szerinti szöveg műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/) beállítást a keresés szabályozásához:

- a [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/whole_words_only/) csak teljes szavakra korlátozza a találatokat.
- a [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/case_sensitive/) szabályozza, hogy a kis- és nagybetűknek egyezniük kell‑e.
- a [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/include_notes/) a diák jegyzeteit is belefoglalja a prezentációszintű keresésbe, csere‑ és kiemelési műveletekbe.

Reguláris kifejezéssel végzett műveletek egy mintastringet használnak, ezért a kis‑ és nagybetűk érzékenysége és a szótárolók a kifejezésben vannak definiálva.

## **Szöveg kiemelése**

Használja a [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/) metódust a szó szerinti szöveg egyezéseinek kiemeléséhez egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/) objektumot a keresés szabályozásához.

Az alábbi kódrészlet minden **"try"** előfordulást kiemel, majd csak a teljes **"to"** szót emeli ki.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Kiemeli a "try" minden előfordulását a szövegkeretben.
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

A [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/) metódus kiemeli a reguláris kifejezéssel található egyezéseket egy szövegkeretben.

Az alábbi kód minden olyan szót kiemel, amely legalább hét karaktert tartalmaz:

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

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése egy teljes prezentációban**

Használja a [Presentation.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_text/) és a [Presentation.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/highlight_regex/) metódusokat a prezentáció összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa egy szó szerinti kifejezést és az összes e‑mail címet emeli ki:

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

## **Szöveg helyettesítése egy szövegkeretben**

Használja a [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) metódust szó szerinti szöveghez, és a [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) metódust mintazalapú helyettesítéshez. Ezek a metódusok az egyező szöveget a meglévő szövegkereten belül módosítják, megőrizve a környező rész formázását ahelyett, hogy egyszerű karakterláncból újraépítenék a keretet.

Az alábbi példa egységesíti egy helyesírási változatot, majd lecseréli a verziócímkéket:

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

Ha egy egyezés különböző formázású részeket ölel fel, ellenőrizze a kimenetet, hogy melyik formázást kell alkalmazni a cserére.

## **Szöveg helyettesítése egy prezentációban**

Használja a [Presentation.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_text/) és a [Presentation.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/replace_regex/) metódusokat a műveletek ugyanúgy történő alkalmazásához a teljes prezentáción. Ez sablon‑tisztításhoz, terminológiai frissítésekhez és sötétítéshez hasznos.

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

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze be az alakzat szövegkeretét, és hívja meg a [TextFrame.highlight_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) vagy a [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) metódust azon a szövegkereten. A prezentációszintű metódusok minden alkalmazható szövegkeretet feldolgoznak helyette.

**Hogyan illeszthetek teljes szavakat a megfelelő nagybetű‑érzékenységgel?**

Állítsa be a [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/whole_words_only/) és a [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/case_sensitive/) értékét `True`‑ra, és adja át ezeket a szó szerinti kiemeléshez vagy csere‑metódushoz. Reguláris kifejezéseknél a szóhatárokat és a kis‑ és nagybetűk érzékenységét a mintában definiálja.

**Tartalmazhat a keresés és csere a diák jegyzeteiben lévő szöveget is?**

Igen. Állítsa a [TextSearchOptions.include_notes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textsearchoptions/include_notes/) értékét `True`‑ra, amikor prezentáció‑szintű szó szerinti műveletet hajt végre.

**Megőrzi a szöveg helyettesítése a formázását?**

A [TextFrame.replace_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_text/) és a [TextFrame.replace_regex](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/replace_regex/) módosítja az egyező szöveget a meglévő szövegkereten belül, és megőrzi a környező rész formázását. Ha egy egyezés különböző formázású részeket ölel fel, ellenőrizze az eredményt, hogy a csere a kívánt stílust használja‑e.