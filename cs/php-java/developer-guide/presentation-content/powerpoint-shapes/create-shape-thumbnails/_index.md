---
title: Vytvoření miniatur tvarů prezentace v PHP
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/php-java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- renderování tvaru
- vizuální ohraničení
- ohraničení tvaru
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro PHP přes Java – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření souborů prezentací, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením souborů prezentace pomocí Microsoft PowerPoint. Někdy však mohou vývojáři potřebovat zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech Aspose.Slides pomáhá generovat miniatury obrázků tvarů snímků. Jak tuto funkci použít, je popsáno v tomto článku.  
Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Generování miniatury tvaru uvnitř snímku.  
- Generování miniatury tvaru pro snímek s uživatelem definovanými rozměry.  
- Generování miniatury tvaru v mezích vzhledu tvaru.

## **Vytvořit miniaturu tvaru ze snímku**
Pro vytvoření miniatury tvaru z libovolného snímku pomocí Aspose.Slides for PHP via Java proveďte následující:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).  
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.  
1. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) referencovaného snímku v výchozím měřítku.  
1. Uložte miniaturu v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vytvořit miniaturu tvaru ze snímku:

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Vytvořte obrázek v plném měřítku
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Uložte obrázek na disk ve formátu PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvořit miniaturu s uživatelem definovaným měřítkem**
Pro vytvoření miniatury tvaru snímku pomocí Aspose.Slides for PHP via Java proveďte následující:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).  
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.  
1. [Získejte miniaturu tvaru](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) referencovaného snímku s uživatelem definovanými rozměry.  
1. Uložte miniaturu v požadovaném formátu obrázku.

Tento ukázkový kód ukazuje, jak vytvořit miniaturu tvaru na základě definovaného měřítka:

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Vytvořte obrázek v plném měřítku
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Uložte obrázek na disk ve formátu PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vytvořit miniaturu vzhledu tvaru na základě ohraničení**
Tato metoda vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v ohraničení vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena ohraničením snímku. Pro vytvoření miniatury tvaru snímku v jeho vzhledu proveďte následující:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).  
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.  
1. Získejte miniaturu referencovaného snímku s ohraničením tvaru jako vzhled.  
1. Uložte miniaturu v požadovaném formátu obrázku.

Tento ukázkový kód je založen na výše uvedených krocích:

```php
  # Vytvořte instanci třídy Presentation, která představuje soubor prezentace
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Vytvořte obrázek v plném měřítku
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Uložte obrázek na disk ve formátu PNG
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Získat skutečné vizuální ohraničení tvaru**

Vlastnosti rámce třídy [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) — `Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` a `Shape::getHeight()` — popisují obdélník uložený v modelu prezentace. Obsah, který je ve skutečnosti vykreslen, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit zabranou oblast.

Použijte [Shape::getVisualBounds](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getVisualBounds) pro výpočet této zabrané oblasti bez vytváření obrázku. Metoda vrací objekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, když obsah přesahuje počátek snímku.

Následující příklad získává a porovnává rámec a vizuální ohraničení:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Stejný objekt [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) lze použít k zarovnání sousedních tvarů vlevo, vpravo, nahoře nebo dole; rezervovat dostatek místa ve generovaném rozvržení; nebo detekovat obsah mimo povolenou oblast. Vizuální ohraničení je zvláště užitečné pro SmartArt, textová pole, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [Shape::getVisualBounds](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getVisualBounds), když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [Shape::getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage), když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapethumbnailbounds/) `ShapeThumbnailBounds::Shape` určuje velikost obrázku podle ohraničení tvaru včetně nastavení obrysu, zatímco `ShapeThumbnailBounds::Appearance` určuje velikost podle vzhledu tvaru a omezuje výsledek na ohraničení snímku. Naopak `Shape::getVisualBounds` vrací pouze vypočítaný obdélník a neomezuje jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**  

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

** Jaký je rozdíl mezi ohraničením Shape a Appearance při vykreslování miniatury?**  

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/php-java/shape-effect/) (stíny, glóby atd.).

** Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**  

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazování v prezentaci, ale nebrání generování obrázku tvaru.

** Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**  

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

** Ovlivňují systémové fonty kvalitu miniatur textových tvarů?**  

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/php-java/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/php-java/font-substitution/)), aby se předešlo nechtěným náhradám a přetékání textu.