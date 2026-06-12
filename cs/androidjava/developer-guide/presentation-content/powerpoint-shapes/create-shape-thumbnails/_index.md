---
title: Vytvoření miniatur tvarů prezentace na Androidu
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/androidjava/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslení tvaru
- vykreslování tvaru
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro Android prostřednictvím Javy – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides for Android via Java lze použít k vytváření prezentačních souborů, kde každá stránka odpovídá snímku. Snímky lze zobrazit otevřením prezentačních souborů v Microsoft PowerPoint. Vývojáři však někdy potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides for Android via Java pomáhá generovat miniatury obrázků tvarů snímku.

V tomto tématu ukážeme, jak generovat miniatury snímků v různých situacích:

- Generování miniatury tvaru uvnitř snímku.
- Generování miniatury tvaru pro tvar snímku s rozměry definovanými uživatelem.
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Generovat miniaturu tvaru ze snímku**
Pro vygenerování miniatury tvaru z libovolného snímku pomocí Aspose.Slides for Android via Java postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getImage--) referencovaného snímku v výchozím měřítku.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // Vytvořte obraz v plném měřítku
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

## **Generovat miniaturu s uživatelem definovaným faktorem škálování**
Pro vygenerování miniatury tvaru snímku pomocí Aspose.Slides for Android via Java postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referencovaného snímku s rozměry definovanými uživatelem.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

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

## **Vytvořit miniaturu vzhledu tvaru podle ohraničení**
Tento způsob tvorby miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Bere v úvahu všechny efekty tvaru. Vytvořená miniatura tvaru je omezena ohraničením snímku. Pro vygenerování miniatury tvaru snímku v mezích jeho vzhledu postupujte takto:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte miniaturu referencovaného snímku s ohraničením tvaru jako vzhledem.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

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

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při renderování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` bere v úvahu [vizuální efekty](/slides/cs/androidjava/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále renderovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení prezentace, ale nebrání generování obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další komplexní objekty?**

Ano. Každý objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/androidjava/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/androidjava/font-substitution/)), aby se předešlo nechtěným náhradám a přetékaní textu.