---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint v Pythonu
linktitle: Vyhledat a nahradit text
type: docs
weight: 55
url: /cs/python-net/search-and-replace-text/
keywords:
- vyhledávání textu
- zvýraznění textu
- nahrazení textu
- regulární výraz
- textový rámec
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím .NET."
---
## **Přehled**

Aspose.Slides pro Python pomocí .NET dokáže vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Tyto funkce jsou užitečné při revizi, redakci, kontrole terminologie, úklidu šablon a dalších automatizovaných pracovních tocích zpracování dokumentů.

V prvních ukázkách níže používáme soubor s názvem "sample.pptx", který obsahuje jediný textový rámeček na první slide s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte oblast hledání**

Použijte metody na [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) k omezení operace na jeden textový rámec. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) k zpracování veškerého relevantního textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/) | [Presentation.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_text/) |
| Zvýraznit shody regulárního výrazu | [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/) | [Presentation.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_regex/) |
| Nahradit doslovný text | [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) | [Presentation.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_text/) |
| Nahradit shody regulárního výrazu | [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) | [Presentation.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_regex/) |

## **Nastavení porovnávání textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/) k řízení porovnávání:

- [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/whole_words_only/) omezuje shody na celá slova.
- [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/case_sensitive/) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions.include_notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/include_notes/) zahrnuje poznámky ke snímkům při operacích vyhledávání, nahrazování a zvýrazňování na úrovni celé prezentace.

Operace s regulárním výrazem používají řetězec vzoru, takže pravidla porovnání, jako je citlivost na velikost písmen a hranice slov, jsou definována výrazem.

## **Zvýraznění textu**

Použijte metodu [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/) k zvýraznění doslovných shod v textovém rámci. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/) pro řízení vyhledávání.

Příklad kódu níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    substring_search_options = slides.TextSearchOptions()
    substring_search_options.case_sensitive = False

    # Zvýraznit každý výskyt "try" v textovém rámci.
    shape.text_frame.highlight_text(
        "try", draw.Color.light_blue, substring_search_options, None
    )

    whole_word_search_options = slides.TextSearchOptions()
    whole_word_search_options.whole_words_only = True
    whole_word_search_options.case_sensitive = False

    # Zvýraznit pouze celé slovo "to".
    shape.text_frame.highlight_text(
        "to", draw.Color.violet, whole_word_search_options, None
    )

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/) zvýrazní shody textu nalezené regulárním výrazem v textovém rámci.

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

## **Zvýraznění textu v celé prezentaci**

Použijte [Presentation.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_text/) a [Presentation.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/highlight_regex/) k prohledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy:

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

## **Nahrazení textu v textovém rámci**

Použijte [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) pro doslovný text a [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) pro náhradu založenou na vzoru. Tyto metody aktualizují odpovídající text v existujícím textovém rámci, přičemž zachovávají formátování okolních částí místo přestavby celého rámce z prostého řetězce.

Následující příklad standardizuje variantu pravopisu a poté nahradí označení verzí:

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

Pokud jedna shoda zahrnuje části s odlišným formátováním, zkontrolujte výstup, abyste potvrdili, které formátování by mělo být použito pro nahrazený text.

## **Nahrazení textu v celé prezentaci**

Použijte [Presentation.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_text/) a [Presentation.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/replace_regex/) k provedení stejných operací v celé prezentaci. To je užitečné při úklidu šablon, aktualizacích terminologie a redakci.

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

**Jak mohu vyhledávat pouze jeden textový rámeček místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte na tomto rámci metodu [TextFrame.highlight_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_text/), [TextFrame.highlight_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/highlight_regex/), [TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) nebo [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) . Metody na úrovni prezentace zpracovávají všechny relevantní textové rámečky.

**Jak mohu shodovat celá slova s správnou kapitalizací?**

Nastavte [TextSearchOptions.whole_words_only](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/whole_words_only/) a [TextSearchOptions.case_sensitive](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/case_sensitive/) na `True` a předávejte tyto možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. U regulárních výrazů definujte hranice slov a citlivost na velikost písmen přímo ve vzoru.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.include_notes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textsearchoptions/include_notes/) na `True` při použití operace doslovného textu na úrovni prezentace.

**Zachovává nahrazování textu jeho formátování?**

[TextFrame.replace_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_text/) a [TextFrame.replace_regex](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/replace_regex/) upravují odpovídající text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud jedna shoda zahrnuje části s různým formátováním, prohlédněte výsledek, aby bylo zajištěno, že nahrazený text používá požadovaný styl.