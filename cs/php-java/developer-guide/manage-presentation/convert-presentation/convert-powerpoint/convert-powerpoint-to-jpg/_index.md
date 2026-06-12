---
title: Převod PPT a PPTX na JPG v PHP
linktitle: PowerPoint na JPG
type: docs
weight: 60
url: /cs/php-java/convert-powerpoint-to-jpg/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint na JPG
- prezentace na JPG
- snímek na JPG
- PPT na JPG
- PPTX na JPG
- uložit PowerPoint jako JPG
- uložit prezentaci jako JPG
- uložit snímek jako JPG
- uložit PPT jako JPG
- uložit PPTX jako JPG
- exportovat PPT do JPG
- exportovat PPTX do JPG
- PHP
- Aspose.Slides
description: "Převod snímků PowerPoint (PPT, PPTX) do vysoce kvalitních JPG obrázků v PHP pomocí Aspose.Slides pro PHP s rychlými, spolehlivými ukázkami kódu."
---
## **Úvod**

Převod prezentací PowerPoint a OpenDocument do JPG obrázků pomáhá při sdílení snímků, optimalizaci výkonu a vkládání obsahu do webových stránek nebo aplikací. Aspose.Slides vám umožňuje převést soubory PPTX, PPT a ODP na vysoce kvalitní JPEG obrázky. Tento průvodce vysvětluje různé metody převodu.

S těmito funkcemi je snadné implementovat vlastní prohlížeč prezentací a vytvořit náhled pro každý snímek. To může být užitečné, pokud chcete chránit snímky prezentace před kopírováním nebo ukázat prezentaci v režimu jen pro čtení. Aspose.Slides vám umožňuje převést celou prezentaci nebo konkrétní snímek do formátů obrázků.

## **Převod PowerPoint PPT/PPTX na JPG**

Zde jsou kroky pro převod PPT/PPTX na JPG:

1. Vytvořte instanci typu [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
2. Získejte objekt snímku typu [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) z kolekce [Presentation::getSlides()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation#getSlides--) .
3. Vytvořte náhled každého snímku a poté jej převedete na JPG. Metoda [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) se používá k získání náhledu snímku. Metodu [getImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage) je třeba zavolat na požadovaném snímku typu [Slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/), přičemž měřítka výsledného náhledu se předají metodě.
4. Po získání náhledu snímku zavolejte metodu [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)) z objektu náhledu. Předáte jí výsledný název souboru a formát obrázku.

{{% alert color="primary" %}}
**Poznámka**: Převod PPT/PPTX na JPG se liší od převodu na jiné typy v API Aspose.Slides. Pro jiné typy obvykle používáte metodu [**Presentation::Save(String fname, int format, SaveOptions options)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/save/), ale zde potřebujete metodu [**IImage::save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}}

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    foreach($pres->getSlides() as $sld) {
      # Vytvoří obrázek v plném měřítku
      $slideImage = $sld->getImage(1.0, 1.0);
      # Uloží obrázek na disk ve formátu JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Převod PowerPoint PPT/PPTX na JPG s přizpůsobenými rozměry**

Aby bylo možné změnit rozměry výsledného náhledu a JPG obrázku, můžete nastavit hodnoty *ScaleX* a *ScaleY* jejich předáním do metod [**Slide::getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/#getImage):

```php
  $pres = new Presentation("PowerPoint-Presentation.pptx");
  try {
    # Definuje rozměry
    $desiredX = 1200;
    $desiredY = 800;
    # Získá škálované hodnoty X a Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    foreach($pres->getSlides() as $sld) {
      # Vytvoří obrázek v plném měřítku
      $slideImage = $sld->getImage($ScaleX, $ScaleY);
      # Uloží obrázek na disk ve formátu JPEG
      try {
        $slideImage->save(String->format("Slide_%d.jpg", $sld->getSlideNumber()), ImageFormat::Jpeg);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vykreslení komentářů při ukládání snímků jako obrázky**

Aspose.Slides pro PHP přes Java poskytuje funkci, která vám umožní vykreslovat komentáře ve snímcích prezentace při jejich převodu na obrázky. Tento PHP kód demonstruje operaci:

```php
  $pres = new Presentation("presentation.pptx");
  try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomTruncated);
    $opts = new RenderingOptions();
    $opts->setSlidesLayoutOptions($notesOptions);
    foreach($pres->getSlides() as $sld) {
      $slideImage = $sld->getImage($opts, new Java("java.awt.Dimension", 740, 960));
      try {
        $slideImage->save(String->format("Slide_%d.png", $sld->getSlideNumber()));
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose poskytuje [FREE Collage web app](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG to JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG to PNG obrázky, vytvořit [photo grids](https://products.aspose.app/slides/cs/collage/photo-grid) a tak dále. 

Pomocí stejných principů popsaných v tomto článku můžete převádět obrázky z jednoho formátu do druhého. Pro více informací viz tyto stránky: convert [image to JPG](https://products.aspose.com/slides/cs/php-java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/cs/php-java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Podporuje tato metoda dávkový převod?**

Ano, Aspose.Slides umožňuje dávkový převod více snímků do JPG v jedné operaci.

**Podporuje převod SmartArt, grafy a další složité objekty?**

Ano, Aspose.Slides vykresluje veškerý obsah, včetně SmartArt, grafů, tabulek, tvarů a dalších. Přesnost vykreslování se však může mírně lišit oproti PowerPointu, zejména při použití vlastních nebo chybějících fontů.

**Existují nějaká omezení počtu snímků, které lze zpracovat?**

Aspose.Slides sám neklade žádná přísná omezení na počet snímků, které můžete zpracovat. Nicméně můžete narazit na chybu nedostatku paměti při práci s velkými prezentacemi nebo obrázky vysokého rozlišení.

## **Viz také**

Podívejte se na další možnosti převodu PPT/PPTX na obrázek, například:

- [PPT/PPTX to SVG conversion](/slides/cs/php-java/render-a-slide-as-an-svg-image/).