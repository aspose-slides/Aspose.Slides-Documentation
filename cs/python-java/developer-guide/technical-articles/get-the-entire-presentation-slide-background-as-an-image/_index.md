---
title: Získat celé pozadí snímku z prezentace jako obrázek
linktitle: Celé pozadí snímku
type: docs
weight: 95
url: /cs/python-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- pozadí snímku
- konečné pozadí
- extrahovat pozadí
- celé pozadí
- pozadí na obrázek
- PPT pozadí
- PPTX pozadí
- ODP pozadí
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Extrahujte úplná pozadí snímků jako obrázky z PowerPoint a OpenDocument prezentací pomocí Aspose.Slides pro Python via Java, zjednodušující vizuální pracovní postupy."
---
## **Přehled**

V prezentacích PowerPoint může být pozadí snímku tvořeno z několika prvků, včetně obrázku pozadí snímku, motivu prezentace, schématu barev a objektů umístěných na hlavním snímku nebo snímku rozvržení.

Tento článek ukazuje, jak extrahovat celé pozadí snímku jako obrázek pomocí Aspose.Slides for Python via Java. Protože neexistuje jediná metoda pro tento úkol, postup zahrnuje klonování vybraného snímku do dočasné prezentace, odstranění tvarů snímku a následnou konverzi výsledného pozadí snímku na obrázek.

## **Získat celé pozadí snímku**

Aspose.Slides for Python via Java neposkytuje jednoduchou metodu pro extrakci celého pozadí snímku prezentace jako obrázku, ale můžete postupovat podle následujících kroků:

1. Načtěte prezentaci pomocí třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte velikost snímku z prezentace.
1. Vyberte snímek.
1. Vytvořte dočasnou prezentaci.
1. Nastavte stejnou velikost snímku v dočasné prezentaci.
1. Zklonujte vybraný snímek do dočasné prezentace.
1. Odstraňte tvary ze zklonovaného snímku.
1. Převeďte zklonovaný snímek na obrázek.

Následující ukázkový kód extrahuje celé pozadí snímku prezentace jako obrázek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, ImageFormat

slide_index = 0
image_scale = 1.0

presentation = Presentation("sample.pptx")
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(slide_index)

    temp_presentation = Presentation()
    try:
        slide_width = jpype.JFloat(slide_size.getWidth())
        slide_height = jpype.JFloat(slide_size.getHeight())
        temp_presentation.getSlideSize().setSize(slide_width, slide_height, SlideSizeScaleType.DoNotScale)

        cloned_slide = temp_presentation.getSlides().addClone(slide)
        cloned_slide.getShapes().clear()

        background = cloned_slide.getImage(image_scale, image_scale)
        try:
            background.save("output.png", ImageFormat.Png)
        finally:
            background.dispose()
    finally:
        temp_presentation.dispose()
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Zůstanou složité gradienty, textury nebo výplně obrázky z hlavního snímku zachovány v vytvářeném obrázku pozadí?**

Ano. Aspose.Slides vykresluje gradientní, obrázkové a texturované výplně definované na snímku, rozvržení nebo hlavním snímku. Pokud potřebujete izolovat vzhled od zděděných hlav, [nastavte vlastní pozadí](/slides/cs/python-java/presentation-background/) na aktuálním snímku před exportem.

**Mohu přidat vodoznak do výsledného obrázku pozadí před jeho uložením?**

Ano. Můžete [přidat vodoznak](/slides/cs/python-java/watermark/) jako tvar nebo obrázek na pracovní [kopii snímku](/slides/cs/python-java/clone-slides/) (umístěnou pod ostatní obsah) a poté exportovat. Tím získáte obrázek pozadí s vodoznakem vloženým.

**Mohu získat pozadí pro konkrétní rozvržení nebo hlavní snímek bez vazby na existující snímek?**

Ano. Získejte požadovaný hlavní snímek nebo rozvržení, aplikujte jej na [dočasný snímek](/slides/cs/python-java/clone-slides/) s požadovanou velikostí a exportujte tento snímek, abyste získali pozadí odvozené od daného rozvržení nebo hlavního snímku.

**Existují licenční omezení, která ovlivňují export obrázků?**

Vykreslovací funkce jsou plně dostupné s [platnou licencí](/slides/cs/python-java/licensing/). V režimu hodnocení může výstup obsahovat omezení, například vodoznak. Aktivujte licenci jednou na proces před provedením dávkových exportů.