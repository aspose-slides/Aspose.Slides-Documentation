---
title: Spravovat sekce snímků v prezentacích s Pythonem
linktitle: Sekce snímků
type: docs
weight: 100
url: /cs/python-net/slide-section/
keywords:
- vytvořit sekci
- přidat sekci
- upravit sekci
- změnit sekci
- název sekce
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zefektivněte sekce snímků v PowerPointu a OpenDocument pomocí Aspose.Slides pro Python — rozdělujte, přejmenovávejte a přeskupujte pro optimalizaci pracovních postupů PPTX a ODP."
---
## **Úvod**

S Aspose.Slides pro Python můžete organizovat prezentaci PowerPoint do sekcí, které seskupují konkrétní snímky.

Můžete chtít vytvořit sekce pro organizaci nebo rozdělení prezentace na logické části v následujících situacích:

- Když pracujete na velké prezentaci s týmem a potřebujete přiřadit určité snímky konkrétním kolegům.
- Když máte prezentaci obsahující mnoho snímků a je pro vás obtížné vše najednou spravovat nebo upravovat.

Ideálně vytvářejte sekce, které seskupují související snímky — ty, které sdílejí téma, obor nebo účel — a každé sekci dejte název, jenž jasně odráží její obsah.

## **Vytvoření sekcí v prezentacích**

Chcete‑li přidat [Sekce](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/), která seskupuje snímky v prezentaci, poskytuje Aspose.Slides metodu [add_section](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectioncollection/add_section/). Umožňuje zadat název sekce a snímek, kde sekce začíná.

Následující příklad v Pythonu ukazuje, jak vytvořit sekci v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides[0]

    slide1 = presentation.slides.add_empty_slide(layout_slide)
    slide2 = presentation.slides.add_empty_slide(layout_slide)
    slide3 = presentation.slides.add_empty_slide(layout_slide)
    slide4 = presentation.slides.add_empty_slide(layout_slide)

    section1 = presentation.sections.add_section("Section 1", slide1)
    # Sekce 1 končí na snímku 2; sekce 2 začíná na snímku 3.
    section2 = presentation.sections.add_section("Section 2", slide3) 
      
    presentation.save("presentation_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.reorder_section_with_slides(section2, 0)
    presentation.save("reordered_sections.pptx", slides.export.SaveFormat.PPTX)
    
    presentation.sections.remove_section_with_slides(section2)
    presentation.sections.append_empty_section("Last empty section")
    presentation.save("presentation_with_empty_section.pptx",slides.export.SaveFormat.PPTX)
```

## **Změna názvů sekcí**

Po vytvoření [Sekce](https://reference.aspose.com/slides/cs/python-net/aspose.slides/section/) v prezentaci PowerPoint můžete rozhodnout o změně jejího názvu.

Následující příklad v Pythonu ukazuje, jak přejmenovat sekci v prezentaci:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   section = presentation.sections[0]
   section.name = "My section"
```

## **Často kladené otázky**

**Jsou sekce zachovány při ukládání do formátu PPT (PowerPoint 97–2003)?**

Ne. Formát PPT nepodporuje metadata sekcí, takže seskupení sekcí se při ukládání do .ppt ztrácí.

**Může být celá sekce „skrytá“?**

Ne. Lze skrýt pouze jednotlivé snímky. Sekce jako entita nemá stav „skrytá“.

**Mohu rychle najít sekci podle snímku a naopak první snímek sekce?**

Ano. Sekce je jednoznačně určena svým úvodním snímkem; pokud znáte snímek, můžete zjistit, do které sekce patří, a u sekce můžete získat její první snímek.