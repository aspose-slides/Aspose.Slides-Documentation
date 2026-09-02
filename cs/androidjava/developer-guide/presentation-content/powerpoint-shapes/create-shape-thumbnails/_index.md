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
- renderování tvaru
- vizuální meze
- meze tvaru
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides for Android via Java – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides for Android via Java lze použít k vytváření souborů prezentací, kde každá stránka odpovídá snímku. Snímky lze zobrazit otevřením souboru prezentace v Microsoft PowerPoint. Vývojáři však někdy potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides for Android via Java pomáhá generovat miniatury obrázků tvarů snímků.

V tomto tématu ukážeme, jak generovat miniatury snímků v různých situacích:

- Generování miniatury tvaru uvnitř snímku.
- Generování miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Generovat miniaturu tvaru ze snímku**
Chcete-li vygenerovat miniaturu tvaru z libovolného snímku pomocí Aspose.Slides for Android via Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
3. [Získejte miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getImage--) referencovaného snímku ve výchozím měřítku.
4. Uložte miniaturu do vámi preferovaného formátu obrázku.

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

## **Generovat miniaturu s uživatelem definovaným měřítkovým faktorem**
Chcete-li vygenerovat miniaturu tvaru snímku pomocí Aspose.Slides for Android via Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
3. [Získejte miniaturu obrázku tvaru](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) referencovaného snímku s uživatelem definovanými rozměry.
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

## **Vytvořit miniaturu vzhledu tvaru založenou na mezích**
Tento způsob vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v mezích vzhledu tvaru. Bere v úvahu všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena mezemi snímku. Chcete-li vygenerovat miniaturu tvaru snímku v mezích jeho vzhledu, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
2. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
3. Získejte miniaturu obrázku referencovaného snímku s mezemi tvaru jako vzhledem.
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

## **Získat skutečné vizuální meze tvaru**

Vlastnosti rámce rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) — jeho metody `getX()`, `getY()`, `getWidth()` a `getHeight()` — popisují obdélník uložený v modelu prezentace. Obsah, který se skutečně vykresluje, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit obsazenou plochu.

Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getVisualBounds--) k výpočtu této obsazené oblasti bez vytváření obrázku. Metoda vrací objekt [RectF](https://developer.android.com/reference/android/graphics/RectF) ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, pokud obsah přesahuje počátek snímku.

[Shape.getVisualBounds](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getVisualBounds--) není v současnosti deklarována v rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/). Proto uchovejte tvar získaný ze sbírky tvarů snímku jako hodnotu rozhraní a přetypujte jej až při volání metody.

Následující příklad získá a porovná rámcové a vizuální meze:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Stejný [RectF](https://developer.android.com/reference/android/graphics/RectF) lze použít k zarovnání sousedních tvarů k jeho levému, pravému, hornímu nebo dolnímu okraji; rezervovat dostatek místa v generovaném rozvržení; nebo detekovat obsah mimo povolenou oblast. Vizuální meze jsou obzvláště užitečné pro SmartArt, textová pole, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getVisualBounds--) když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [IShape.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getImage--) když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` určuje velikost obrázku podle mezí tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds.Appearance` určuje velikost podle vzhledu tvaru a omezuje výsledek na meze snímku. Naproti tomu [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getVisualBounds--) vrací pouze vypočítaný obdélník a neomezuje jej na snímek.

## **FAQ**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektor SVG](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Jaký je rozdíl mezi mezemi Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` bere v úvahu [vizuální efekty](/slides/cs/androidjava/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále renderovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být renderován; příznak skrytí ovlivňuje zobrazení při prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány grupové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/smartart/)) může být uložen jako miniatura nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur pro textové tvary?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/androidjava/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/androidjava/font-substitution/)), aby nedocházelo k nechtěným náhradám a přetékanému textu.