---
title: Správa záhlaví a zápatí prezentace v Pythonu
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/python-net/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- podklady
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat zástupné symboly zápatí, data-času, čísla snímku a záhlaví na snímcích, stránkách poznámek a podkladech pomocí Aspose.Slides pro Python via .NET."
---
## **Přehled**

PowerPoint používá různé zástupné symboly záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides for Python via .NET vám umožňuje ovládat text a viditelnost těchto zástupných symbolů pomocí tříd správce záhlaví/zápatí.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Normální snímek | Ne | Ano | Ano | Ano |
| Mistr poznámek | Ano | Ano | Ano | Ano |
| Snímek poznámek | Ano | Ano | Ano | Ano |
| Mistr podkladů | Ano | Ano | Ano | Ano |

Normální snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a podkladech. Pro normální snímky použijte místo toho zástupné symboly zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na správci, který použijete. Třída [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slideheaderfootermanager/) ovládá jeden normální snímek. Třída [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslideheaderfootermanager/) ovládá jeden snímek poznámek. Správci mistra a rozvržení mohou také propagovat nastavení na závislé snímky, zatímco třída [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) ovládá mistr podkladů.

## **Nastavení zápatí, data/času a čísel snímků na běžných snímcích**

Pro běžné snímky je základní postup získat správce záhlaví/zápatí každého snímku, nastavit text zápatí a data/času, povolit požadované zástupné symboly a uložit prezentaci. Čísla snímků jsou generována prezentací, takže je třeba řídit jen jejich viditelnost.

Použijte [`set_footer_text`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) a [`set_date_time_text`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) pro nastavení textu a použijte [`set_footer_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), a [`set_slide_number_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) pro zobrazení odpovídajících zástupných symbolů.

Následující příklad od začátku až do konce použije stejný text zápatí, data/času a viditelnost čísel snímků na všech běžných snímcích:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Pokud potřebujete aktualizovat jen jeden snímek, přistupujte k tomuto snímku přímo přes kolekci [`slides`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/slides/cs/) místo iterace celé kolekce.

## **Nastavení záhlaví a zápatí na mistru poznámek**

Mistr poznámek definuje společné formátování a chování zástupných symbolů pro stránky poznámek. Použijte třídu [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/) když chcete změnit pouze samotný mistr poznámek.

Následující příklad nastaví záhlaví, zápatí a text data/času na mistru poznámek a zobrazí všechny podporované zástupné symboly na tomto mistru:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Prezentace nemusí obsahovat mistr poznámek, takže před změnou ověřte, že vrácená hodnota není `None`.

## **Použít nastavení mistra poznámek na podřízené snímky poznámek**

Mistr poznámek může aplikovat nastavení záhlaví a zápatí na sebe i na všechny závislé snímky poznámek. Použijte dedikované metody propagace na [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/) když mají být stejná nastavení použita napříč hierarchií poznámek.

Například [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) a [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) aktualizují záhlaví mistra poznámek i všech podřízených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Metody propagace použité výše jsou [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), a [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Nastavení záhlaví a zápatí na jednotlivém snímku poznámek**

Snímek poznámek patří ke konkrétnímu běžnému snímku. Použijte jeho třídu [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslideheaderfootermanager/) když chcete upravit jen tuto stránku poznámek.

Metoda [`add_notes_slide`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslidemanager/add_notes_slide/) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek spojenou s prvním snímkem prezentace:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Pokud nejprve propagujete nastavení z mistra poznámek a následně změníte jednotlivý snímek poznámek, pozdější nastavení na úrovni snímku vám umožní upravit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a zápatí na mistru podkladů**

Stránky podkladů používají mistr podkladů pro své zástupné symboly záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení podkladů spravována prostřednictvím mistra podkladů, nikoli jednotlivých snímků podkladů.

Použijte vlastnost [`master_handout_slide`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) pro přístup k mistru podkladů. Pokud není přítomen, zavolejte [`set_default_master_handout_slide`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) pro vytvoření výchozího mistra podkladů.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Pochopit rozsah a dědičnost**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slideheaderfootermanager/) mění nastavení zápatí, data/času a čísel snímků pro jeden běžný snímek.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslideheaderfootermanager/) ovládá snímek rozvržení a může propagovat podporovaná nastavení na závislé snímky.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslideheaderfootermanager/) ovládá běžný mistr snímků a může propagovat podporovaná nastavení na závislé snímky.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/) ovládá mistr poznámek a může propagovat nastavení na všechny závislé snímky poznámek.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupný symbol záhlaví kromě zápatí, data/času a čísla snímku.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) mění mistr podkladů a podporuje všechny čtyři typy zástupných symbolů.

Používejte propagaci z mistra nebo rozvržení, když má být stejné nastavení použito v celé hierarchii. Používejte individuální správce snímku nebo poznámkového snímku, když potřebujete lokální nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví na běžný snímek?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro běžné snímky. Na běžných snímcích použijte zástupné symboly zápatí, datum/čas a číslo snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a podkladech.

**Co když zástupný symbol zápatí, datum/čas nebo číslo snímku není viditelný?**

Použijte odpovídajícího správce záhlaví/zápatí pro kontrolu jeho viditelnosti a povolení podle potřeby. Například [`is_footer_visible`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) udává, zda je zástupný symbol zápatí přítomen, a [`set_footer_visibility`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) mění jeho viditelnost.

**Jak nastavit číslování snímků od hodnoty jiného než 1?**

Nastavte vlastnost [`first_slide_number`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/first_slide_number/) prezentace. Poté zástupné symboly čísel snímků použijí aktualizovanou číselnou sekvenci.

**Co se stane se záhlavím a zápatím při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu stránky, který se exportuje, a na nastaveních viditelnosti odpovídajících zástupných symbolů.