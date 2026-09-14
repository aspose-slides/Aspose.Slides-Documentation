---
title: Přidání snímků do prezentací v Pythonu
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/python-java/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše přidejte snímky do svých PowerPoint a OpenDocument prezentací pomocí Aspose.Slides for Python via Java - plynulé, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Aspose.Slides umožňuje programově přidávat snímky do prezentací PowerPoint. Prezentace obsahuje hlavní/rozvržení snímky a běžné snímky a běžné snímky jsou uspořádány podle indexu začínajícího nulou. Každý snímek má jedinečné ID a soubory prezentací bez snímků nejsou podporovány.

Tento článek vysvětluje, jak vytvořit objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) , získat jeho kolekci snímků, přidat prázdný snímek, pracovat s nově přidaným snímkem a uložit aktualizovanou prezentaci. Také popisuje související body, jako je vkládání snímků na konkrétní pozici, používání rozvržení a pochopení prázdného snímku, který existuje v nově vytvořené prezentaci.

## **Přidání snímku do prezentace**

Než se zaměříme na přidávání snímků do souborů prezentací, podívejme se na několik faktů o snímcích. Každý soubor prezentace PowerPoint obsahuje **hlavní/rozvržení** snímky a **běžné** snímky. Soubor prezentace obsahuje alespoň jeden snímek. Soubory prezentací bez snímků nejsou podporovány Aspose.Slides for Python via Java. Každý snímek má jedinečné ID a všechny běžné snímky jsou uspořádány v pořadí podle indexu začínajícího nulou.

Aspose.Slides for Python via Java umožňuje vývojářům přidávat prázdné snímky do jejich prezentací. Chcete‑li přidat prázdný snímek do prezentace, postupujte takto:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Získejte odkaz na objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/) pomocí metody [getSlides](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSlides), kterou poskytuje objekt [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Přidejte prázdný snímek na konec kolekce snímků prezentace voláním metody [addEmptySlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#addEmptySlide), kterou poskytuje objekt [SlideCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/).
- Proveďte potřebné operace s nově přidaným prázdným snímkem.
- Nakonec zapište soubor prezentace pomocí objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
presentation = Presentation()
try:
    # Získejte kolekci snímků.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Přidejte prázdný snímek do kolekce snímků.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Proveďte potřebné operace s nově přidaným snímkem.

    # Uložte soubor PPTX na disk.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Mohu vložit nový snímek na konkrétní pozici, nejen na konec?**

Ano. Knihovna podporuje kolekce snímků a operace [insert](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidecollection/#insertClone), takže můžete přidat snímek na požadovaný index místo pouze na konec.

**Zachovají se motivy/styly při přidávání snímku na základě rozvržení?**

Ano. Rozvržení dědí formátování ze svého hlavního snímku a nový snímek dědí formátování vybraného rozvržení a jeho přidruženého hlavního snímku.

**Který snímek je přítomen v nové „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak vybrat „správné“ rozvržení pro nový snímek, pokud má hlavní snímek mnoho možností?**

Obecně zvolte [LayoutSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/layoutslide/), který odpovídá požadované struktuře ([Title and Content, Two Content, atd.](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slidelayouttype/)). Pokud takové rozvržení chybí, můžete jej [add it to the master](/slides/cs/python-java/slide-layout/) a poté jej použít.