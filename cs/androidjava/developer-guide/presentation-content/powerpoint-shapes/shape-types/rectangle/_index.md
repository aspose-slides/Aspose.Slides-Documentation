---
title: Přidání obdélníků do prezentací na Androidu
linktitle: Obdélník
type: docs
weight: 80
url: /cs/androidjava/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zvyšte úroveň svých prezentací PowerPoint přidáním obdélníků pomocí Aspose.Slides pro Android v Javě – snadno navrhujte a upravujte tvary programově."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat do snímků PowerPointu tvary obdélníků. Pokrývá vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako soubor PPTX. Také uvidíte, jak použít základní formátování obdélníku, jako je plná barva výplně, barva čáry a šířka čáry. Navíc FAQ článku odkazuje na související úkoly s obdélníky, včetně zaoblených rohů, výplní obrázky, vizuálních efektů, hypertextových odkazů, zamykání tvarů, možností exportu a efektivních vlastností.

## **Přidat obdélník do snímku**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection) .
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Zapsat soubor PPTX na disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidat formátovaný obdélník do snímku**
- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection) .
- Nastavte [Fill Type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FillType) obdélníku na Solid.
- Nastavte barvu obdélníku pomocí [SolidFillColor.setColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) vystavené objektem [IFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFillFormat) spojeným s objektem [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape) .
- Nastavte barvu čar obdélníku.
- Nastavte šířku čar obdélníku.
- Zapište upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Aplikovat formátování na tvar elipsy
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Aplikovat formátování na čáru elipsy
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Zapsat soubor PPTX na disk
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak přidám obdélník se zaoblenými rohy?**

Použijte typ tvaru se zaoblenými rohy [shape type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapetype/) a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí úprav geometrie.

**Jak vyplním obdélník obrázkem (texturou)?**

Vyberte typ výplně obrázkem [fill type](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/), zadejte zdroj obrázku a nakonfigurujte režimy [stretching/tiling modes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Vnější/vnitřní stín, záře a měkké hrany](/slides/cs/androidjava/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu proměnit obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Přiřaďte hypertextový odkaz](/slides/cs/androidjava/manage-hyperlinks/) ke kliknutí na tvar (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu chránit obdélník před přesouváním a změnami?**

Použijte zamykání tvarů: můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravu textu, aby byl zachován rozvrh.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [vykreslit tvar](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) do obrázku se zadanou velikostí/měřítkem nebo jej [exportovat jako SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na téma a dědičnost?**

[Použijte efektivní vlastnosti tvaru](/slides/cs/androidjava/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styly tématu, rozvržení a místní nastavení, což usnadňuje analýzu formátování.