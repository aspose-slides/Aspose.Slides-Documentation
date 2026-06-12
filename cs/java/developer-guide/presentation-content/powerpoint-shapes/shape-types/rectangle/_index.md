---
title: Přidání obdélníků do prezentací v Javě
linktitle: Obdélník
type: docs
weight: 80
url: /cs/java/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vylepšete své PowerPoint prezentace přidáním obdélníků pomocí Aspose.Slides pro Java – snadno navrhujte a programově upravujte tvary."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat tvary obdélníku do snímků PowerPointu. Pokrývá vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako souboru PPTX. Také uvidíte, jak použít základní formátování obdélníku, jako je výplň plnou barvou, barva čáry a šířka čáry. Navíc FAQ článku odkazuje na související úkoly s obdélníky, včetně zaoblených rohů, výplně obrázkem, vizuálních efektů, hypertextových odkazů, zamykání tvarů, možností exportu a efektivních vlastností.

## **Přidat obdélník na snímek**
Chcete-li přidat jednoduchý obdélník do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) zveřejněné objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Zapsat soubor PPTX na disk
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidat formátovaný obdélník na snímek**
Chcete-li přidat formátovaný obdélník na snímek, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) zveřejněné objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Nastavte [Fill Type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/FillType) obdélníku na Solid.
- Nastavte barvu obdélníku pomocí metody [SolidFillColor.setColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) zveřejněné objektem [IFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFillFormat), který je spojen s objektem [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape).
- Nastavte barvu čar obdélníku.
- Nastavte šířku čar obdélníku.
- Zapište upravenou prezentaci jako PPTX soubor.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získá první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Použít formátování na tvar elipsy
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Použít formátování na čáru elipsy
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

**Jak přidat obdélník se zaoblenými rohy?**

Použijte typ tvaru s zaoblenými rohy [shape type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapetype/) a upravte poloměr rohu ve vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí geometrických úprav.

**Jak vyplnit obdélník obrázkem (texturou)?**

Vyberte typ výplně obrázkem [fill type](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/), poskytněte zdroj obrázku a nakonfigurujte režimy [stretching/tiling modes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/java/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu převést obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/java/manage-hyperlinks/) k události kliknutí na tvar (přejít na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu chránit obdélník před přesouváním a změnami?**

[Use shape locks](/slides/cs/java/applying-protection-to-presentation/): můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravu textu, aby byl zachován rozvrh.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getImage-int-float-float-) na obrázek se zadanou velikostí/škálou nebo jej [export it as SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) pro vektorové použití.

**Jak rychle získat skutečné (efektivní) vlastnosti obdélníku s ohledem na téma a dědičnost?**

[Use the shape’s effective properties](/slides/cs/java/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují style tématu, rozvržení a místní nastavení, což zjednodušuje analýzu formátování.