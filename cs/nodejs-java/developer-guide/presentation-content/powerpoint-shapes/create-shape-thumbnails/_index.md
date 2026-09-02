---
title: Vytvoření miniatur tvarů prezentace v JavaScriptu
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/nodejs-java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- vykreslování tvaru
- vizuální meze
- meze tvaru
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí JavaScriptu a Aspose.Slides pro Node.js – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření prezentačních souborů, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením prezentačních souborů v aplikaci Microsoft PowerPoint. Ale někdy mohou vývojáři potřebovat zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides pomáhá generovat miniatury obrázků tvarů na snímcích. Jak tuto funkci použít, je popsáno v tomto článku.  
Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Generování miniatury tvaru uvnitř snímku.  
- Generování miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.  
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Generování miniatur tvarů ze snímků**

Chcete‑li vygenerovat miniaturu tvaru z libovolného snímku pomocí Aspose.Slides pro Node.js přes Java, postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getImage--) odkazovaného snímku ve výchozím měřítku.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru ze snímku:

```javascript
// Instancujte třídu Presentation, která představuje soubor prezentace
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

## **Generování miniatur tvarů s uživatelem definovaným měřítkovým faktorem**

Chcete‑li vygenerovat miniaturu tvaru snímku pomocí Aspose.Slides pro Node.js přes Java, postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) odkazovaného snímku s uživatelem definovanými rozměry.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru na základě definovaného měřítkového faktoru:

```javascript
// Instancujte třídu Presentation, která představuje soubor prezentace
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

Tato metoda vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Bere v úvahu všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena mezemi snímku. Chcete‑li vygenerovat miniaturu tvaru snímku v mezích jeho vzhledu, postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte miniaturu odkazovaného snímku s mezemi tvaru jako vzhledem.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

Tento ukázkový kód je založen na výše uvedených krocích:

```javascript
// Instancujte třídu Presentation, která představuje soubor prezentace
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

## **Získání skutečných vizuálních mezí tvaru**

Vlastnosti rámce [Tvaru](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) — jeho metody `getX()`, `getY()`, `getWidth()` a `getHeight()` — popisují obdélník uložený v modelu prezentace. Obsah, který je skutečně vykreslen, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetékaný text, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit zabranou oblast.  
Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getVisualBounds--) k výpočtu této zabrané oblasti bez vytváření obrázku. Metoda vrací objekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, pokud obsah přesahuje počátek snímku.  

Následující příklad získává a porovnává rám a vizuální meze:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Stejný obdélník lze použít k zarovnání blízkých tvarů na jeho levý, pravý, horní nebo spodní okraj; vyhradit dostatek místa ve vytvořeném rozvržení; nebo detekovat obsah mimo povolenou oblast. Vizuální meze jsou zvláště užitečné pro SmartArt, textová pole, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.  
Při potřebě souřadnic pro rozvržení nebo validaci a bez potřeby bitmapy použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getVisualBounds--). Když potřebujete tvar vykreslit, použijte [Shape.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage--). S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.Shape` určuje velikost obrázku podle mezí tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds.Appearance` určuje velikost podle vzhledu tvaru a omezuje výsledek na meze snímku. Naopak [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getVisualBounds--) vrací pouze vypočítaný obdélník a neorezuje jej na snímek.

## **FAQ**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/writeassvg/) uložení obsahu tvaru jako SVG.

**Jaký je rozdíl mezi mezemi Shape a Appearance při vykreslování miniatury?**  
`Shape` používá geometrii tvaru; `Appearance` bere v úvahu [vizuální efekty](/slides/cs/nodejs-java/shape-effect/) (stíny, záře apod.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**  
Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání v generování obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**  
Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/), a [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur textových tvarů?**  
Ano. Měli byste [poskytnout požadované fonty](/slides/cs/nodejs-java/custom-font/) (nebo [nastavit substituce fontů](/slides/cs/nodejs-java/font-substitution/)), aby nedošlo k nechtěným náhradám a přetečení textu.