---
title: Získání ohraničení odstavců z prezentací v JavaScriptu
linktitle: Odstavec
type: docs
weight: 60
url: /cs/nodejs-java/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v JavaScriptu pomocí Aspose.Slides pro Node.js získat ohraničení odstavců a částí textu a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `getRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Získání souřadnic odstavce a části v TextFrame**
Pomocí Aspose.Slides pro Node.js přes Java mohou vývojáři nyní získat obdélníkové souřadnice odstavce v kolekci odstavců TextFrame. Také umožňuje získat [souřadnice části](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion#getCoordinates--) v kolekci částí odstavce. V tomto tématu pomocí příkladu ukážeme, jak získat obdélníkové souřadnice odstavce spolu s polohou části uvnitř odstavce.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Získání obdélníkových souřadnic odstavce**
Pomocí metody [**getRect()**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Paragraph#getRect--) mohou vývojáři získat obdélník ohraničení odstavce.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Získání velikosti odstavce a části v textovém rámci buňky tabulky**

Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Paragraph) v textovém rámci buňky tabulky můžete použít metody [Portion.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion#getRect--) a [Paragraph.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Paragraph#getRect--) .

Tento ukázkový kód demonstruje popsanou operaci:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**V jakých jednotkách jsou vráceny souřadnice odstavce a částí textu?**

V bodech, kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je v [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) povoleno [wrapping](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/setwraptext/), text se zalomí, aby se vešel do šířky oblasti, což změní skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převést body na pixely pomocí: pixels = points × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení/export.

**Jak získám „efektivní“ parametry formátování odstavce, s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/nodejs-java/shape-effective-properties/); vrací konečné konsolidované hodnoty odsazení, rozestupů, zalamování, RTL a další.