---
title: Správa záhlaví a zápatí prezentace v Pythonu přes Java
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/python-java/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- výtisk
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat zástupné objekty zápatí, datum-čas, číslo snímku a záhlaví na snímcích, stránkách poznámek a výtiscích s Aspose.Slides pro Python přes Java."
---
## **Přehled**

PowerPoint používá různé zástupné objekty záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides pro Python prostřednictvím Javy vám umožňuje řídit text a viditelnost těchto zástupných objektů pomocí tříd správce záhlaví/zápatí.

Dostupné zástupné objekty závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Standardní snímek | Ne | Ano | Ano | Ano |
| Master poznámek | Ano | Ano | Ano | Ano |
| Snímek poznámek | Ano | Ano | Ano | Ano |
| Master výtisků | Ano | Ano | Ano | Ano |

Standardní snímek prezentace nemá zástupný objekt záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a výtiscích. Pro standardní snímky použijte místo toho zástupné objekty zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na použitém správci. Třída [SlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideheaderfootermanager/) řídí jeden standardní snímek. Třída [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslideheaderfootermanager/) řídí jeden snímek poznámek. Správci masteru a rozložení mohou také šířit nastavení na závislé snímky, zatímco třída [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) řídí master výtisků.

## **Nastavení zápatí, data/času a čísel snímků na standardních snímcích**

Pro standardní snímky je základní postup získat správce záhlaví/zápatí každého snímku, nastavit text zápatí a data/času, povolit požadované zástupné objekty a uložit prezentaci. Čísla snímků jsou generována prezentací, takže stačí řídit pouze jejich viditelnost.

Použijte [setFooterText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) a [setDateTimeText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText), abyste nastavili text, a použijte [setFooterVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) a [setSlideNumberVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility), abyste zobrazili odpovídající zástupné objekty.

Následující komplexní příklad aplikuje stejný text zápatí, datum/čas a viditelnost číslování snímků na všechny standardní snímky:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k tomuto snímku přímo pomocí metody [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides), místo iterace přes celou kolekci.

## **Nastavení záhlaví a zápatí v masteru poznámek**

Master poznámek určuje společné formátování a chování zástupných objektů pro stránky poznámek. Použijte třídu [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/), pokud chcete změnit pouze samotný master poznámek.

Následující příklad nastaví záhlaví, zápatí a text datum/čas v masteru poznámek a zobrazí všechny podporované zástupné objekty v tomto masteru:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda `getMasterNotesSlide` vrací `None`, pokud prezentace neobsahuje master poznámek.

## **Použití nastavení masteru poznámek na podřízené snímky poznámek**

Master poznámek může aplikovat nastavení záhlaví a zápatí na sebe samotného i na všechny závislé snímky poznámek. Použijte speciální metody šíření v [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/), pokud mají být stejná nastavení aplikována napříč hierarchií poznámek.

Například [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) a [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aktualizují záhlaví masteru poznámek a všech podřízených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Šířící metody použité výše jsou [setFooterAndChildFootersText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) a [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Nastavení záhlaví a zápatí na jednotlivém snímku poznámek**

Snímek poznámek patří ke konkrétnímu standardnímu snímku. Použijte jeho třídu [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslideheaderfootermanager/), pokud chcete přizpůsobit pouze tuto stránku poznámek.

Metoda [addNotesSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslidemanager/#addNotesSlide) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek spojenou s prvním snímkem prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pokud nejprve rozšíříte nastavení z masteru poznámek a pak změníte konkrétní snímek poznámek, pozdější nastavení na úrovni snímku vám umožní přizpůsobit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a zápatí v masteru výtisků**

Stránky výtisků používají master výtisků pro své zástupné objekty záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení výtisků spravována přes master výtisků, nikoli přes jednotlivé snímky výtisků.

Použijte metodu `getMasterHandoutSlide` pro přístup k masteru výtisků. Pokud není přítomen, zavolejte `setDefaultMasterHandoutSlide`, abyste vytvořili výchozí master výtisků.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Pochopení rozsahu a dědičnosti**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideheaderfootermanager/) mění nastavení zápatí, datum/čas a číslo snímku pro jeden standardní snímek.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslideheaderfootermanager/) řídí snímek rozložení a může šířit podporovaná nastavení na závislé snímky.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslideheaderfootermanager/) řídí master standardního snímku a může šířit podporovaná nastavení na závislé snímky.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masternotesslideheaderfootermanager/) řídí master poznámek a může šířit nastavení na všechny závislé snímky poznámek.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/notesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupný objekt záhlaví kromě zápatí, datum/čas a číslo snímku.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) mění master výtisků a podporuje všechny čtyři typy zástupných objektů.

Použijte šíření z masteru nebo rozložení, pokud má stejné nastavení platit v celé jeho hierarchii. Použijte správce jednotlivého snímku nebo snímku poznámek, pokud potřebujete lokální nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví na standardní snímek?**

Ne. PowerPoint nedefinuje zástupný objekt záhlaví pro standardní snímky. Na standardních snímcích použijte zástupné objekty zápatí, datum/čas a číslo snímku. Zástupné objekty záhlaví jsou k dispozici na stránkách poznámek a výtiscích.

**Co když zástupný objekt zápatí, datum/čas nebo číslo snímku není viditelný?**

Použijte odpovídající správce záhlaví/zápatí k ověření jeho viditelnosti a povolte jej podle potřeby. Například [isFooterVisible](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) uvádí, zda je zástupný objekt zápatí přítomen, a [setFooterVisibility](https://reference.aspose.com/slides/cs/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) mění jeho viditelnost.

**Jak mohu zahájit číslování snímků od hodnoty jiných než 1?**

Zavolejte metodu [setFirstSlideNumber](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#setFirstSlideNumber) prezentace. Zástupné objekty číslování snímků pak použijí aktualizovanou posloupnost číslování.

**Co se stane se záhlavím a zápatím při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu exportované stránky a na nastavení viditelnosti odpovídajících zástupných objektů.