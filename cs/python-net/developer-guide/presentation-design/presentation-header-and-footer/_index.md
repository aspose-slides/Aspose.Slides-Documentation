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
- výtisk
- poznámky
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Pomocí Aspose.Slides pro Python přes .NET přidejte a přizpůsobte záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides for Python vám umožňuje řídit zástupné symboly záhlaví a zápatí napříč prezentací s přesným rozsahem. Text zápatí, datum/čas a čísla snímků jsou spravovány na úrovni masteru a mohou být použity globálně nebo upraveny pro jednotlivé snímky. Záhlaví jsou podporována v poznámkách a výstupech, kde můžete přepínat viditelnost a nastavit text pro záhlaví, zápatí, datum/čas a čísla stránek pomocí speciálního správce záhlaví a zápatí na master snímku poznámek nebo jednotlivých snímcích poznámek. Tento článek popisuje klíčové vzory pro aktualizaci těchto zástupných symbolů a konzistentní šíření změn v celé prezentaci.

## **Správa textu záhlaví a zápatí**

V této sekci se naučíte, jak spravovat obsah záhlaví a zápatí v prezentaci — povolit nebo upravit zápatí, datum a čas a čísla snímků. Stručně nastíníme rozsahy pro použití těchto nastavení (celá prezentace, jednotlivé snímky a pohledy poznámek/výstupů) a ukážeme, jak použít Aspose.Slides API k rychlé a jednotné aktualizaci.

```py
import aspose.slides as slides

# Funkce pro nastavení textu záhlaví.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Načtěte prezentaci.
with slides.Presentation("sample.pptx") as presentation:
    # Nastavte zápatí.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Přístup a aktualizace záhlaví.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Uložte prezentaci.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa záhlaví a zápatí na snímcích poznámek**

V této sekci se naučíte, jak spravovat záhlaví a zápatí konkrétně pro snímky poznámek v Aspose.Slides. Probereme povolení příslušných zástupných symbolů, nastavení textu pro zápatí, datum/čas a čísla stránek a aplikaci těchto změn konzistentně napříč masterem poznámek a jednotlivými stránkami poznámek.

Postupujte podle následujících kroků:

1. Načtěte soubor prezentace.
1. Získejte master snímek poznámek a jeho [header & footer manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masternotesslideheaderfootermanager/).
1. Na master snímku poznámek povolte viditelnost záhlaví, zápatí, čísla snímku a datum/čas pro master a všechny podřízené snímky poznámek.
1. Na master snímku poznámek nastavte text pro záhlaví, zápatí a datum/čas pro master a všechny podřízené snímky poznámek.
1. Získejte snímek poznámek pro první snímek prezentace a jeho [header & footer manager](https://reference.aspose.com/slides/cs/python-net/aspose.slides/notesslideheaderfootermanager/).
1. Pro tento první snímek poznámek zajistěte, aby byly viditelné záhlaví, zápatí, číslo snímku a datum/čas (zapněte všechny, které jsou vypnuté).
1. Pro tento první snímek poznámek nastavte text pro záhlaví, zápatí a datum/čas.
1. Uložte prezentaci ve formátu PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Zobrazit master snímek poznámek a všechny podřízené zástupné symboly záhlaví, zápatí, čísla snímku a datum/čas.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Nastavit text na master snímku poznámek a všechny podřízené zástupné symboly záhlaví, zápatí a datum/čas.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Změnit nastavení záhlaví, zápatí, čísla snímku a datum/čas pouze pro první snímek poznámek.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Zajistit, aby byly zástupné symboly záhlaví, zápatí, čísla snímku a datum/čas viditelné.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Nastavit text na zástupných symbolech záhlaví, zápatí a datum/čas v snímku poznámek.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Uložit prezentaci.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu přidat "záhlaví" do běžných snímků?**

V PowerPointu existuje „Záhlaví“ jen pro poznámky a výstupy; na běžných snímcích jsou podporovány pouze zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví jen pro poznámky/výstupy a na snímcích — Footer/DateTime/SlideNumber.

**Co když rozvržení neobsahuje oblast zápatí — mohu její viditelnost „zapnout“?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví a zápatí a podle potřeby ji povolte. Tyto indikátory a metody API jsou navrženy pro případy, kdy je zástupný symbol chybějící nebo skrytý.

**Jak nastavit, aby číslo snímku začínalo hodnotou jinou než 1?**

Nastavte [first slide number](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/first_slide_number/) prezentace; poté je všechna číslování přepočítáno. Například můžete začít od 0 nebo 10 a číslo na úvodním snímku skrýt.

**Co se stane se záhlavími/zápatími při exportu do PDF/obrázků/HTML?**

Budou renderovány jako běžné textové prvky prezentace. To znamená, že pokud jsou tyto prvky viditelné na snímcích nebo stránkách poznámek, objeví se také ve výstupním formátu spolu se zbytkem obsahu.