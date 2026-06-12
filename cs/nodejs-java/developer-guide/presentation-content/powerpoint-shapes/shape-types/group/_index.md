---
title: Skupinové tvary v prezentaci v JavaScriptu
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/nodejs-java/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se seskupovat a rozdělovat tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Java — rychlý, krok za krokem průvodce s bezplatným JavaScriptovým kódem."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar do snímku, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak získat přístup k tvarům uloženým ve skupině a přečíst jejich hodnoty `AlternativeText`. Navíc článek stručně pokrývá související funkce skupinových tvarů, jako jsou vnořené skupiny, z-order a možnosti zamykání.

## **Přidání skupinového tvaru**
Aspose.Slides podporuje práci se skupinovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides pro Node.js přes Java podporuje přidávání nebo přístup ke skupinovým tvarům. Je možné přidávat tvary do přidaného skupinového tvaru, aby byl naplněn, nebo přistupovat k libovolné jeho vlastnosti. Pro přidání skupinového tvaru do snímku pomocí Aspose.Slides pro Node.js přes Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho Indexu
1. Přidejte skupinový tvar do snímku.
1. Přidejte tvary do přidaného skupinového tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získání prvního snímku
    var sld = pres.getSlides().get_Item(0);
    // Přístup ke kolekci tvarů snímků
    var slideShapes = sld.getShapes();
    // Přidání skupinového tvaru na snímek
    var groupShape = slideShapes.addGroupShape();
    // Přidání tvarů do přidaného skupinového tvaru
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 300, 100, 100);
    // Přidání rámečku skupinového tvaru
    groupShape.setFrame(new aspose.slides.ShapeFrame(100, 300, 500, 40, aspose.slides.NullableBool.False, aspose.slides.NullableBool.False, 0));
    // Uložení souboru PPTX na disk
    pres.save("GroupShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k vlastnosti AltText**
Toto téma ukazuje jednoduché kroky, doplněné příklady kódu, pro přidání skupinového tvaru a přístup k vlastnosti AltText skupinových tvarů na snímcích. Pro přístup k AltText skupinového tvaru ve snímku pomocí Aspose.Slides pro Node.js přes Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), která představuje soubor PPTX.
1. Získejte referenci na snímek pomocí jeho Indexu.
1. Přístup k kolekci tvarů snímků.
1. Přístup ke skupinovému tvaru.
1. Vyvolejte vlastnost [getAlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getAlternativeText--).

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation("AltText.pptx");
try {
    // Získání prvního snímku
    var sld = pres.getSlides().get_Item(0);
    for (var i = 0; i < sld.getShapes().size(); i++) {
        // Přístup ke kolekci tvarů snímků
        var shape = sld.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            // Přístup ke skupinovému tvaru.
            var grphShape = shape;
            for (var j = 0; j < grphShape.getShapes().size(); j++) {
                var shape2 = grphShape.getShapes().get_Item(j);
                // Přístup k vlastnosti AltText
                console.log(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/) má metodu [getParentGroup](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getparentgroup/), která přímo naznačuje podporu hierarchie (skupina může být podřízena jiné skupině).

**Jak mohu řídit z-order skupiny vzhledem k jiným objektům na snímku?**

Použijte metodu [getZOrderPosition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getzorderposition/) třídy [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/), abyste zjistili její pozici v zásobníku zobrazení.

**Mohu zabránit přesunu/editaci/odskupování?**

Ano. Sekce zamykání skupiny je přístupná prostřednictvím [GroupShapeLock](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/getgroupshapelock/), která umožňuje omezit operace nad objektem.