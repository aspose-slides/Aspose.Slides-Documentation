---
title: Přidání snímků do prezentací pomocí Pythonu
linktitle: Přidat snímek
type: docs
weight: 10
url: /cs/python-net/add-slide-to-presentation/
keywords:
- přidat snímek
- vytvořit snímek
- prázdný snímek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše přidejte snímky do vašich prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET - hladké, efektivní vkládání snímků během několika sekund."
---
## **Přehled**

Před přidáním snímků do prezentace je užitečné pochopit, jak PowerPoint organizuje snímky. Každá prezentace obsahuje hlavní snímek, volitelné snímky rozložení a jeden nebo více běžných snímků. Každý snímek má jedinečné ID a běžné snímky jsou uspořádány podle nulového indexu. Tento článek ukazuje, jak pomocí Aspose.Slides pro Python vytvářet snímky a vybírat vhodná rozložení.

## **Přidání snímků do prezentací**

Aspose.Slides umožňuje připojit nové snímky založené na existujících rozložení snímků. Níže uvedený příklad prochází každé rozložení v prezentaci, přidá snímek, který používá toto rozložení, a poté soubor uloží.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Přistupte k [SlideCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/) .
1. Pro každý prvek v `presentation.layout_slides` zavolejte `add_empty_slide`, abyste přidali snímek používající toto rozložení.
1. Volitelně upravte nově přidané snímky.
1. Uložte prezentaci jako soubor PPTX.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Přistupte ke kolekci snímků.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Přidejte prázdný snímek do kolekce snímků.
        slides.add_empty_slide(layout_slide)

    # Proveďte nějakou práci s nově přidanými snímky.

    # Uložte prezentaci na disk.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Mohu vložit nový snímek na konkrétní pozici, ne jen na konec?**

Ano. Knihovna podporuje operace s kolekcemi snímků a operace [insert](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidecollection/insert_clone/) , takže můžete přidat snímek na požadovaný index místo jen na konec.

**Zachovají se motivy/styly při přidávání snímku založeného na rozložení?**

Ano. Rozložení dědí formátování od svého hlavního snímku a nový snímek dědí od vybraného rozložení a jeho přidruženého hlavního snímku.

**Jaký snímek je přítomný v nové „prázdné“ prezentaci před přidáním snímků?**

Nově vytvořená prezentace již obsahuje jeden prázdný snímek s indexem nula. To je důležité vzít v úvahu při výpočtu indexů vkládání.

**Jak si vybrat „správné“ rozložení pro nový snímek, pokud má hlavní snímek mnoho možností?**

Obvykle vyberte [LayoutSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/layoutslide/) , který odpovídá požadované struktuře ([Title and Content, Two Content, atd.](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slidelayouttype/)). Pokud takové rozložení chybí, můžete ho [přidat do hlavního snímku](/slides/cs/python-net/slide-layout/) a poté jej použít.