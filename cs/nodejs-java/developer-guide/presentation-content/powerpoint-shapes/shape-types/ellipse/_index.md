---
title: Přidat elipsy do prezentací v JavaScriptu
linktitle: Elipsa
type: docs
weight: 30
url: /cs/nodejs-java/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s eliptickými tvary v Aspose.Slides pro Node.js v prezentacích PPT i PPTX—příklady kódu v JavaScriptu jsou zahrnuty."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat eliptické tvary do snímků PowerPoint. Pokrývá vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Také se dotýká souvisejících otázek, jako je práce s polohou a velikostí elipsy, řízení pořadí vrstvení a použití animačních efektů.

## **Vytvořit elipsu**
Chcete‑li přidat jednoduchou elipsu do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Získáte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali elipsu na první snímek

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získat první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu elipsa
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Zapište soubor PPTX na disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vytvořit formátovanou elipsu**
Chcete‑li přidat lépe formátovanou elipsu na snímek, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
- Získáte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Nastavte typ výplně elipsy na Solid.
- Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color, kterou vystavuje objekt [FillFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FillFormat) spojený s objektem [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape).
- Nastavte barvu čar elipsy.
- Nastavte šířku čar elipsy.
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získat první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidat AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Použít určité formátování na tvar elipsy
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Použít určité formátování na čáru elipsy
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Zapsat soubor PPTX na disk
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **Často kladené otázky**

**Jak nastavit přesnou polohu a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a rozměry se typicky uvádějí **v bodech**. Pro předvídatelné výsledky založte své výpočty na velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládat pořadí vrstvení)?**

Upravte pořadí kreslení objektu tím, že jej přenesete dopředu nebo dozadu. To umožní, aby elipsa překrývala jiné objekty nebo odhalovala ty pod ní.

**Jak animovat zobrazení nebo zvýraznění elipsy?**

[Apply](/slides/cs/nodejs-java/shape-animation/) vstupní, zvýrazňovací nebo výstupní efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo určeno, kdy a jak se animace přehrává.