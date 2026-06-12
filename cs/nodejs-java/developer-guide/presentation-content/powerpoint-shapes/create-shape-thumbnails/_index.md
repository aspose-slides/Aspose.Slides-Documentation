---
title: Vytváření miniatur tvarů prezentace v JavaScriptu
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- renderování tvaru
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí JavaScriptu a Aspose.Slides pro Node.js – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření souborů prezentací, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením souborů prezentace v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides pomůže vygenerovat miniatury obrázků tvarů snímků. Jak tuto funkci použít, je popsáno v tomto článku.

Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Vytvoření miniatury tvaru uvnitř snímku.
- Vytvoření miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Vytvoření miniatury tvaru v mezích vzhledu tvaru.

## **Generování miniatur tvarů ze snímků**

Pro vygenerování miniatury tvaru z libovolného snímku pomocí Aspose.Slides pro Node.js přes Java proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getImage--) referencovaného snímku v základním měřítku.
4. Uložte miniaturu v preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru ze snímku:

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Uložte obrázek na disk ve formátu PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generování miniatur tvarů s uživatelem definovaným škálovacím faktorem**

Pro vygenerování miniatury tvaru snímku pomocí Aspose.Slides pro Node.js přes Java proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) referencovaného snímku s uživatelem definovanými rozměry.
4. Uložte miniaturu v preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru na základě definovaného škálovacího faktoru:

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Uložte obrázek na disk ve formátu PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Generování miniatury tvaru v mezích**

Tento způsob vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena hranicemi snímku. Pro vygenerování miniatury tvaru snímku v mezích jeho vzhledu proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury referencovaného snímku s mezemi tvaru jako vzhled.
4. Uložte miniaturu v preferovaném formátu obrázku.

Tento ukázkový kód je založen na výše uvedených krocích:

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Uložte obrázek na disk ve formátu PNG
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/), a další. Tvary mohou být také [exportovány jako vektorové SVG](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi mezemi Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/nodejs-java/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude stále vykreslen jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání vytvoření obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémové fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/nodejs-java/custom-font/) (nebo [nastavit náhradu fontů](/slides/cs/nodejs-java/font-substitution/)), abyste se vyhnuli nechtěným náhradám a přetékání textu.