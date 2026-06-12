---
title: Vytvořte miniatury tvarů prezentace v PHP
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/php-java/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- vykreslit tvar
- vykreslování tvaru
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Vytvořte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro PHP přes Java – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides se používá k vytváření prezentačních souborů, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením prezentačního souboru v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides pomůže vygenerovat miniatury obrázků tvarů snímku. Jak tuto funkci použít, je popsáno v tomto článku.

Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Vytvoření miniatury tvaru uvnitř snímku.
- Vytvoření miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Vytvoření miniatury tvaru v mezích vzhledu tvaru.

## **Vytvoření miniatury tvaru ze snímku**
Chcete-li vygenerovat miniaturu tvaru z libovolného snímku pomocí Aspose.Slides pro PHP přes Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. [Získat obrázek miniatury tvaru](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) referencovaného snímku ve výchozím měřítku.
1. Uložte obrázek miniatury ve vámi preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru ze snímku:

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

## **Vytvoření miniatury s uživatelem definovaným měřítkem**
Chcete-li vygenerovat miniaturu tvaru snímku pomocí Aspose.Slides pro PHP přes Java, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. [Získat obrázek miniatury tvaru](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getImage) referencovaného snímku s uživatelem definovanými rozměry.
1. Uložte obrázek miniatury ve vámi preferovaném formátu obrázku.

Tento ukázkový kód vám ukazuje, jak vygenerovat miniaturu tvaru na základě definovaného měřítka:

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

## **Vytvoření miniatury vzhledu tvaru na základě ohraničení**
Tato metoda vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v rámci ohraničení vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vytvořená miniatura tvaru je omezena ohraničením snímku. Chcete-li vygenerovat miniaturu tvaru snímku v ohraničení jeho vzhledu, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation).
1. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
1. Získat obrázek miniatury referencovaného snímku s ohraničením tvaru jako vzhledem.
1. Uložte obrázek miniatury ve vámi preferovaném formátu obrázku.

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

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imageformat/), a další. Tvar lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při vykreslování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` bere v úvahu [vizuální efekty](/slides/cs/php-java/shape-effect/) (stíny, záře, atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání vytvoření obrázku tvaru.

**Jsou podporovány seskupené tvary, grafy, SmartArt a další komplexní objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/), a [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/php-java/custom-font/) (nebo [konfigurovat náhrady fontů](/slides/cs/php-java/font-substitution/)), aby se předešlo nechtěným náhradám a přeskupení textu.