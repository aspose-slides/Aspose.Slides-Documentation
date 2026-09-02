---
title: Vytvoření náhledů tvarů prezentace v Javě
linktitle: Náhledy tvarů
type: docs
weight: 70
url: /cs/java/create-shape-thumbnails/
keywords:
- náhled tvaru
- obrázek tvaru
- vykreslení tvaru
- renderování tvaru
- vizuální hranice
- hranice tvaru
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Generujte vysoce kvalitní náhledy tvarů z PowerPoint snímků pomocí Aspose.Slides pro Java – snadno vytvořte a exportujte náhledy prezentací."
---
## **Úvod**

Aspose.Slides for Java lze použít k vytváření prezentačních souborů, kde každá stránka odpovídá snímku. Snímky lze zobrazit otevřením prezentačních souborů v Microsoft PowerPoint. Vývojáři však někdy potřebují zobrazit obrazy tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides for Java pomáhá generovat náhledové obrázky tvarů snímků.

Tento článek vysvětluje, jak generovat náhledy snímků různými způsoby:

- Generování náhledového obrázku tvaru uvnitř snímku.
- Generování náhledového obrázku tvaru snímku s uživatelem definovanými rozměry.
- Generování náhledového obrázku tvaru v mezích vzhledu tvaru.

## **Generovat náhled tvaru ze snímku**
Chcete-li generovat náhled tvaru z libovolného snímku pomocí Aspose.Slides for Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte náhledový obrázek tvaru](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage--) odkazovaného snímku v výchozím měřítku.
4. Uložte náhledový obrázek v preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak generovat náhled tvaru ze snímku:

```java
// Instanciujte třídu Presentation, která představuje soubor prezentace
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

## **Generovat náhled s uživatelsky definovaným měřítkem**
Chcete-li vygenerovat náhled tvaru snímku pomocí Aspose.Slides for Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. [Získejte náhledový obrázek tvaru](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage-int-float-float-) odkazovaného snímku s uživatelem definovanými rozměry.
4. Uložte náhledový obrázek v preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak generovat náhled tvaru na základě definovaného měřítkového faktoru:

```java
// Instanciujte třídu Presentation, která představuje soubor prezentace
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

## **Vytvořit náhled vzhledu tvaru na základě mezí**
Tato metoda vytváření náhledů tvarů umožňuje vývojářům generovat náhled v mezích vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaný náhled tvaru je omezen mezemi snímku. Chcete-li vygenerovat náhled tvaru snímku v mezích jeho vzhledu, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte náhledový obrázek odkazovaného snímku s mezemi tvaru jako vzhledem.
4. Uložte náhledový obrázek v preferovaném formátu obrázku.

Tento ukázkový kód je založen na výše uvedených krocích:

```java
// Instanciujte třídu Presentation, která představuje soubor prezentace
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

## **Získat aktuální vizuální hranice tvaru**

Vlastnosti rámce rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) — jeho metody `getX()`, `getY()`, `getWidth()` a `getHeight()` — popisují obdélník uložený v prezentačním modelu. Obsah, který je ve skutečnosti vykreslen, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit obsazenou oblast.

K výpočtu této obsazené oblasti bez vytváření obrázku použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getVisualBounds--). Metoda vrací [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, pokud obsah přesahuje počátek snímku.

[Shape.getVisualBounds](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getVisualBounds--) v současnosti není deklarována v rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/). Proto uchovávejte tvar získaný ze sbírky tvarů snímku jako hodnotu rozhraní a přetypovávejte jej až při volání metody.

Následující příklad získává a porovnává rámcové a vizuální hranice:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

Stejný [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) lze použít k zarovnání sousedních tvarů k jeho levému, pravému, hornímu nebo dolnímu okraji; rezervovat dostatek místa v generovaném rozvržení; nebo detekovat obsah mimo povolenou oblast. Vizuální hranice jsou zvláště užitečné pro SmartArt, textové rámečky, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getVisualBounds--), když potřebujete souřadnice pro rozvržení nebo validaci a ne potřebujete bitmapu. Použijte [IShape.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage--) v případě, že potřebujete vykreslit tvar. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds.Shape` nastavuje velikost obrázku podle mezí tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds.Appearance` nastavuje velikost podle vzhledu tvaru a omezuje výsledek na mezery snímku. Naopak [Shape.getVisualBounds](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getVisualBounds--) vrací jen vypočtený obdélník a neomezuje jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání náhledů tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) uložením jejich obsahu jako SVG.

**Jaký je rozdíl mezi mezemi Shape a Appearance při vykreslování náhledu?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/java/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se i přesto vykreslovat jako náhled?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/java/com.aspose.slides/smartart/)) lze uložit jako náhled nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu náhledů textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/java/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/java/font-substitution/)), aby nedocházelo k nechtěným náhradám a přetečení textu.