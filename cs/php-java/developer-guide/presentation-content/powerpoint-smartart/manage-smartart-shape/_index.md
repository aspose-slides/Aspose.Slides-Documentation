---
title: Správa grafiky SmartArt v prezentacích pomocí PHP
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /cs/php-java/manage-smartart-shape/
keywords:
- objekt SmartArt
- grafika SmartArt
- styl SmartArt
- barva SmartArt
- vytvořit SmartArt
- přidat SmartArt
- upravit SmartArt
- změnit SmartArt
- přistupovat k SmartArt
- typ rozvržení SmartArt
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Automatizujte vytváření, úpravu a stylování SmartArt v PowerPointu v PHP pomocí Aspose.Slides, s krátkými ukázkami kódu a zaměřením na výkon."
---
## **Přehled**

Aspose.Slides vám umožňuje programově vytvářet a spravovat grafiku SmartArt v prezentacích PowerPoint. Tento článek vysvětluje, jak přidat tvar SmartArt na snímek, přistupovat k existujícím tvarům SmartArt, najít SmartArt podle konkrétního typu rozvržení a aktualizovat jeho vzhled změnou stylu SmartArt nebo barevného stylu.

Příklady ukazují, jak pracovat s tvary SmartArt prostřednictvím kolekce tvarů snímku prezentace, zkontrolovat, zda je tvar SmartArt, a poté upravit nebo kontrolovat jeho vlastnosti.

## **Vytvoření tvaru SmartArt**
Aspose.Slides for PHP via Java poskytuje API pro vytváření tvarů SmartArt. Pro vytvoření tvaru SmartArt na snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte tvar SmartArt pomocí [Add a SmartArt shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addSmartArt) nastavením [LayoutType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArtLayoutType).
1. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvořit instanci třídy Presentation
  $pres = new Presentation();
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Přidat tvar SmartArt
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Uložit prezentaci
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: tvar SmartArt přidán na snímek**|

## **Přístup k tvaru SmartArt na snímku**
Následující kód bude použit k přístupu k tvarům SmartArt přidaným do snímku prezentace. Ve vzorovém kódu projdeme všechny tvary uvnitř snímku a zkontrolujeme, zda se jedná o tvar [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt). Pokud je tvar typu SmartArt, přetypujeme jej na instanci [**SmartArt**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt).

```php
  # Načíst požadovanou prezentaci
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Procházet všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Zkontrolovat, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypovat tvar na SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Přístup k tvaru SmartArt s konkrétním typem rozvržení**
Následující ukázkový kód pomůže získat tvar [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt) s konkrétním LayoutType. Všimněte si, že LayoutType SmartArt nelze změnit, protože je jen pro čtení a nastavuje se pouze při přidání tvaru [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt).

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt), a pokud je, přetypujte vybraný tvar na SmartArt.
5. Zkontrolujte tvar SmartArt s konkrétním LayoutType a proveďte požadované operace.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Procházet všechny tvary v prvním snímku
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Zkontrolovat, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypovat tvar na SmartArtEx
        $smart = $shape;
        # Kontrola rozvržení SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Změna stylu tvaru SmartArt**
V tomto příkladu se naučíte změnit rychlý styl libovolného tvaru SmartArt.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt), a pokud je, přetypujte vybraný tvar na SmartArt.
5. Najděte tvar SmartArt s konkrétním Style.
6. Nastavte nový Style pro tvar SmartArt.
7. Uložte prezentaci.

```php
  # Vytvořit instanci třídy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Procházet všechny tvary v prvním snímku
    foreach($slide->getShapes() as $shape) {
      # Zkontrolovat, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypovat tvar na SmartArtEx
        $smart = $shape;
        # Kontrola stylu SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Změna stylu SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Uložit prezentaci
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Obrázek: tvar SmartArt se změněným stylem**|

## **Změna barevného stylu tvaru SmartArt**
V tomto příkladu se naučíte změnit barevný styl libovolného tvaru SmartArt. V následujícím vzorovém kódu přistoupíme k tvaru SmartArt s konkrétním barevným stylem a změníme jej.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation) a načtěte prezentaci s tvarem SmartArt.
2. Získejte referenci na první snímek pomocí jeho indexu.
3. Projděte všechny tvary uvnitř prvního snímku.
4. Zkontrolujte, zda je tvar typu [SmartArt](https://reference.aspose.com/slides/cs/php-java/aspose.slides/SmartArt), a pokud je, přetypujte vybraný tvar na SmartArt.
5. Najděte tvar SmartArt s konkrétním Color Style.
6. Nastavte nový Color Style pro tvar SmartArt.
7. Uložte prezentaci.

```php
  # Vytvořit instanci třídy Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Získat první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Procházet všechny tvary v prvním snímku
    foreach($slide->getShapes() as $shape) {
      # Zkontrolovat, zda je tvar typu SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Přetypovat tvar na SmartArtEx
        $smart = $shape;
        # Kontrola typu barvy SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Změna typu barvy SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Uložit prezentaci
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Obrázek: tvar SmartArt se změněným Color Style**|

## **Často kladené otázky**

**Can I animate SmartArt as a single object?**

Ano. SmartArt je tvar, takže můžete použít [standard animations](/slides/cs/php-java/powerpoint-animation/) prostřednictvím animačního API (vstup, odchod, zdůraznění, trajektorie pohybu) stejně jako u ostatních tvarů.

**How can I find a specific SmartArt on a slide if I don’t know its internal ID?**

Nastavte a použijte alternativní text (AltText) a vyhledejte tvar podle této hodnoty – to je doporučený způsob, jak najít cílový tvar.

**Can I group SmartArt with other shapes?**

Ano. Můžete seskupit SmartArt s ostatními tvary (obrázky, tabulky atd.) a následně [manipulate the group](/slides/cs/php-java/group/).

**How do I get an image of a specific SmartArt (e.g., for a preview or report)?**

Exportujte miniaturu/obrázek tvaru; knihovna může [render individual shapes](/slides/cs/php-java/create-shape-thumbnails/) do rastrových souborů (PNG/JPG/TIFF).

**Will the SmartArt appearance be preserved when converting the whole presentation to PDF?**

Ano. Vykreslovací engine usiluje o vysokou věrnost při [PDF export](/slides/cs/php-java/convert-powerpoint-to-pdf/), s řadou možností kvality a kompatibility.