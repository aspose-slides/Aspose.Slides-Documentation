---
title: Přidání obdélníků do prezentací v Pythonu
linktitle: Obdélník
type: docs
weight: 80
url: /cs/python-net/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- naformátovaný obdélník
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zvýšte kvalitu svých prezentací PowerPoint a OpenDocument přidáním obdélníků pomocí Aspose.Slides pro Python přes .NET — snadno navrhujte a programově upravujte tvary."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat obdélníkové tvary do snímků PowerPointu. Popisuje vytvoření jednoduchého obdélníku, vytvoření naformátovaného obdélníku a uložení aktualizované prezentace jako souboru PPTX. Také uvidíte, jak použít základní formátování obdélníku, například barvu výplně, barvu čáry a šířku čáry. Navíc sekce FAQ v článku odkazuje na související úkoly s obdélníkem, včetně zaoblených rohů, výplní obrázkem, vizuálních efektů, hypertextových odkazů, zamykání tvarů, možností exportu a efektivních vlastností.

## **Vytvoření jednoduchého obdélníku**

Stejně jako předchozí témata i toto se zabývá přidáním tvaru a tentokrát bude diskutován tvar Obdélník. V této kapitole jsme popsali, jak mohou vývojáři přidat jednoduché nebo naformátované obdélníky do svých snímků pomocí Aspose.Slides pro Python přes .NET. Chcete-li přidat jednoduchý obdélník na vybraný snímek prezentace, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)class.
2. Získejte odkaz na snímek pomocí jeho Indexu.
3. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, která je k dispozici v objektu IShapes.
4. Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as pres:
    # Získat první snímek
    sld = pres.slides[0]

    # Přidat automatický tvar typu obdélník
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Zapsat soubor PPTX na disk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vytvoření naformátovaného obdélníku**

Pro přidání naformátovaného obdélníku do snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/)class.
2. Získejte odkaz na snímek pomocí jeho Indexu.
3. Přidejte IAutoShape typu Rectangle pomocí metody AddAutoShape, která je k dispozici v objektu IShapes.
4. Nastavte typ výplně obdélníku na Solid.
5. Nastavte barvu obdélníku pomocí vlastnosti SolidFillColor.Color, která je dostupná v objektu FillFormat přidruženém k objektu IShape.
6. Nastavte barvu čar obdélníku.
7. Nastavte šířku čar obdélníku.
8. Uložte upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as pres:
    # Získat první snímek
    sld = pres.slides[0]

    # Přidat automatický tvar typu obdélník
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Použít nějaké formátování na tvar obdélníku
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Použít nějaké formátování na čáru obdélníku
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Zapsat soubor PPTX na disk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak přidat obdélník se zaoblenými rohy?**

Použijte typ tvaru [shape type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapetype/) s zaoblenými rohy a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí geometrických úprav.

**Jak vyplnit obdélník obrázkem (texturou)?**

Vyberte typ výplně [fill type](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/), zadejte zdroj obrázku a nakonfigurujte [stretching/tiling modes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/python-net/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu převést obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/python-net/manage-hyperlinks/) při kliknutí na tvar (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu chránit obdélník před přesouváním a změnami?**

[Use shape locks](/slides/cs/python-net/applying-protection-to-presentation/): můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravy textu a tak zachovat rozvržení.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](http://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/get_image/) na obrázek s určenou velikostí/škálou nebo [export it as SVG](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/write_as_svg/) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na téma a dědičnost?**

[Use the shape’s effective properties](/slides/cs/python-net/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styl tématu, rozvržení a místní nastavení, což usnadňuje analýzu formátování.