---
title: Vytvoření miniatur tvarů prezentace v Java
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslování tvaru
- renderování tvaru
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro Java – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides pro Java lze použít k vytváření souborů prezentací, ve kterých každá stránka odpovídá snímku. Snímky je možné zobrazit otevřením souborů prezentace pomocí Microsoft PowerPoint. Vývojáři však někdy potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides pro Java pomáhá generovat miniatury obrázků tvarů snímku.

Cílem tohoto článku je vysvětlit, jak generovat miniatury snímků různými způsoby:

- Generování miniatury tvaru uvnitř snímku.
- Generování miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Generovat miniaturu tvaru ze snímku**
Chcete-li vygenerovat miniaturu tvaru z libovolného snímku pomocí Aspose.Slides pro Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získat miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getImage--) referencovaného snímku v výchozím měřítku.
4. Uložte miniaturu obrázku v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vygenerovat miniaturu tvaru ze snímku:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // Uložte obrázek na disk ve formátu PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Generovat miniaturu s uživatelsky definovaným škálovacím faktorem**
Chcete-li vygenerovat miniaturu tvaru snímku pomocí Aspose.Slides pro Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získat miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getImage-int-float-float-) referencovaného snímku s uživatelsky definovanými rozměry.
4. Uložte miniaturu obrázku v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vygenerovat miniaturu tvaru na základě definovaného škálovacího faktoru:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // Uložte obrázek na disk ve formátu PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvořit miniaturu vzhledu tvaru založenou na ohraničení**
Cesta vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena mezemi snímku. Chcete-li vygenerovat miniaturu tvaru snímku v mezích jeho vzhledu, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získat miniaturu obrázku referencovaného snímku s ohraničením tvaru jako vzhledem.
4. Uložte miniaturu obrázku v požadovaném formátu obrázku.

Tento ukázkový kód je založen na výše uvedených krocích:

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Vytvořte obrázek v plném měřítku
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // Uložte obrázek na disk ve formátu PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi mezemi Shape a Appearance při vytváření miniatury?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/java/shape-effect/) (stíny, záření atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení prezentace, ale nebrání generování obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovliňují systémově nainstalované fonty kvalitu miniatur pro textové tvary?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/java/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/java/font-substitution/)), aby se předešlo nechtěným náhradám a přetečení textu.