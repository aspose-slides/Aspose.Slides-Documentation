---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v Pythonu
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/python-net/search-and-replace-text/
keywords:
- vyhledávání textu
- zvýraznění textu
- nahrazení textu
- regulární výraz
- textový rámeček
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Aspose.Slides pro Python prostřednictvím .NET může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámečku nebo v celé prezentaci. Tyto možnosti jsou užitečné pro kontrolu, redakci, kontrolu terminologie, úklid šablon a další automatizované pracovní postupy zpracování dokumentů.

V prvních níže uvedených příkladech používáme soubor s názvem "sample.pptx", který obsahuje jednu textovou oblast na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) k omezení operace na jeden textový rámec. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) ke zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_text/) |
| Zvýraznit shody regulárního výrazu | [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_regex/) |
| Nahradit doslovný text | [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_text/) |
| Nahradit shody regulárního výrazu | [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_regex/) |

## **Nastavení porovnávání textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/) ke kontrole porovnávání:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/whole_words_only/) omezuje shody na celá slova.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/case_sensitive/) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/include_notes/) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárními výrazy používají řetězec vzoru, takže pravidla porovnávání, jako je citlivost na velikost písmen a hranice slov, jsou definována samotným výrazem.

## **Identifikace vlastníka textového rámce**

Obecné pracovní postupy pro zpracování textu často získají [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) při vyhledávání, nahrazování, validaci nebo exportu textu. Použijte [TextFrame.parent_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_shape/) a [TextFrame.parent_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_cell/) k určení, který objekt prezentace vlastní daný textový rámec.

Očekávané hodnoty závisí na vlastníkovi:

| Vlastník textového rámce | `parent_shape` | `parent_cell` |
|---|---|---|
| Automatický tvar nebo jiný tvar obsahující text | Vlastní [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/) | `None` |
| Buňka tabulky | `None` | Vlastní [Cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides/cell/) |

Obě vlastnosti jsou jen pro čtení a slouží jako navigační. Čtení nemění pozici textového rámce ani jeho vlastníka. Obecný kód by měl kontrolovat obě hodnoty na `None` a ošetřit možnost, že žádný vlastník není dostupný.

Následující příklad používá [SlideUtil.get_all_text_frames](https://reference.aspose.com/slides/cs/python-net/aspose.slides.util/slideutil/get_all_text_frames/) k iteraci přes všechny textové rámce v prezentaci. Pro tvary vypisuje název tvaru, typ v Pythonu a snímek, ve kterém se nachází. Pro buňky tabulky vypisuje souřadnice sloupce a řádku (od nuly) a snímek, ve kterém jsou obsaženy.

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

Pro obsah SmartArt iterujte přes tvary v [SmartArtNode.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartartnode/shapes/) a přistupujte k jednotlivým [ISmartArtShape.text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/ismartartshape/text_frame/). Textový rámec lze zpětně navázat na svůj asociovaný tvar pomocí [TextFrame.parent_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_shape/), zatímco [TextFrame.parent_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/parent_cell/) je `None`. Proto větev tvarů v ukázce také zpracovává text ze SmartArt uzlů.

## **Zvýraznit text**

Použijte metodu [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/) k zvýraznění doslovných shod v textovém rámečku. Při volání předávejte [TextSearchOptions] pro řízení vyhledávání.

Níže uvedený ukázkový kód zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní jen úplné slovo **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Zvýraznit každý výskyt "try" v textovém rámečku.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Zvýraznit pouze úplné slovo "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/) zvýrazní textové shody nalezené regulárním výrazem v textovém rámečku.

Následující kód zvýrazní všechna slova obsahující sedm a více znaků:

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

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [Presentation.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_text/) a [Presentation.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_regex/) k vyhledání ve všech relevantních textových rámečcích v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

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

## **Nahradit text v textovém rámečku**

Použijte [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) pro doslovný text a [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) pro nahrazení na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámečku, přičemž si zachovávají formátování okolních částí místo přepisování celého rámce z prostého řetězce.

Následující příklad sjednotí variantu pravopisu a poté nahradí štítky verze:

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

Pokud jedna shoda zasahuje do částí s různým formátováním, zkontrolujte výstup, abyste potvrdili, které formátování by se mělo použít pro nahrazený text.

## **Nahradit text v celé prezentaci**

Použijte [Presentation.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_text/) a [Presentation.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_regex/) k provedení stejných operací napříč celou prezentací. To je užitečné pro úklid šablon, aktualizaci terminologie a redakci.

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

## **Často kladené otázky**

**Jak mohu vyhledávat jen v jednom textovém rámečku místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) nebo [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) na tomto textovém rámečku. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámečky místo toho.

**Jak mohu shodovat úplná slova s přesnou kapitalizací?**

Nastavte [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/whole_words_only/) a [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/case_sensitive/) na `True` a předávejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte hranice slov a citlivost na velikost písmen přímo ve vzoru.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.include_notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/include_notes/) na `True` při použití operace doslovného textu na úrovni celé prezentace.

**Zachovává nahrazení textu jeho formátování?**

[TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) a [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) upravují nalezený text v existujícím textovém rámečku a zachovávají formátování okolních částí. Pokud shoda zahrnuje části s různým formátováním, prohlédněte výsledek a ujistěte se, že nahrazení používá požadovaný styl.