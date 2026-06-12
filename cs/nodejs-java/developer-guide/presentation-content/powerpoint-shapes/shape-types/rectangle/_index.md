---
title: Přidání obdélníků do prezentací v JavaScriptu
linktitle: Obdélník
type: docs
weight: 80
url: /cs/nodejs-java/rectangle/
keywords:
- přidat obdélník
- vytvořit obdélník
- tvar obdélníku
- jednoduchý obdélník
- formátovaný obdélník
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vylepšete své PowerPoint prezentace přidáním obdélníků pomocí JavaScriptu a Aspose.Slides pro Node.js -- snadno navrhujte a programově upravujte tvary."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat obdélníkové tvary do snímků PowerPointu. Pokrývá vytvoření jednoduchého obdélníku, vytvoření formátovaného obdélníku a uložení aktualizované prezentace jako soubor PPTX.

Také uvidíte, jak použít základní formátování obdélníku, jako je plná barva výplně, barva čáry a šířka čáry. Navíc sekce FAQ v článku odkazuje na související úkoly s obdélníky, včetně zaoblených rohů, výplní obrázkem, vizuálních efektů, hypertextových odkazů, zamykání tvarů, možností exportu a efektivních vlastností.

## **Přidání obdélníku na snímek**

Stejně jako předchozí témata se i toto týká přidávání tvaru a tentokrát bude diskutován tvar Obdélník. V tomto tématu jsme popsali, jak mohou vývojáři pomocí Aspose.Slides přidávat jednoduché nebo formátované obdélníky do svých snímků.

Chcete-li přidat jednoduchý obdélník do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) zveřejněné objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali jednoduchý obdélník na první snímek prezentace.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Uložte soubor PPTX na disk
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání formátovaného obdélníku na snímek**

Chcete-li přidat formátovaný obdélník na snímek, postupujte podle níže uvedených kroků:

- Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) typu Rectangle pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) zveřejněné objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Nastavte [Fill Type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FillType) obdélníku na Solid.
- Nastavte barvu obdélníku pomocí metody [SolidFillColor.setColor](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) zveřejněné objektem [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FillFormat) spojeným s objektem [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape).
- Nastavte barvu čar obdélníku.
- Nastavte šířku čar obdélníku.
- Uložte upravenou prezentaci jako soubor PPTX.

Výše uvedené kroky jsou implementovány v níže uvedeném příkladu.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Použijte nějaké formátování na tvar elipsy
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Použijte nějaké formátování na čáru elipsy
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Uložte soubor PPTX na disk
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jak přidám obdélník se zaoblenými rohy?**

Použijte typ tvaru [shape type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapetype/) se zaoblenými rohy a upravte poloměr rohu v vlastnostech tvaru; zaoblení lze také aplikovat na jednotlivé rohy pomocí úprav geometrie.

**Jak vyplním obdélník obrázkem (texturou)?**

Vyberte typ výplně [fill type](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/), zadejte zdroj obrázku a nakonfigurujte [stretching/tiling modes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/picturefillmode/).

**Může mít obdélník stín a záři?**

Ano. [Outer/inner shadow, glow, and soft edges](/slides/cs/nodejs-java/shape-effect/) jsou k dispozici s nastavitelnými parametry.

**Mohu převést obdélník na tlačítko s hypertextovým odkazem?**

Ano. [Assign a hyperlink](/slides/cs/nodejs-java/manage-hyperlinks/) na kliknutí tvaru (přechod na snímek, soubor, webovou adresu nebo e‑mail).

**Jak mohu ochránit obdélník před posunem a úpravami?**

Použijte zamykání tvarů: můžete zakázat přesouvání, změnu velikosti, výběr nebo úpravu textu, aby se zachoval rozvrh.

**Mohu převést obdélník na rastrový obrázek nebo SVG?**

Ano. Můžete [render the shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage) na obrázek s určenou velikostí/škálou nebo jej [export it as SVG](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) pro vektorové použití.

**Jak rychle získám skutečné (efektivní) vlastnosti obdélníku s ohledem na motiv a dědičnost?**

[Use the shape’s effective properties](/slides/cs/nodejs-java/shape-effective-properties/): API vrací vypočtené hodnoty, které zohledňují styl motivu, rozvržení a místní nastavení, což usnadňuje analýzu formátování.