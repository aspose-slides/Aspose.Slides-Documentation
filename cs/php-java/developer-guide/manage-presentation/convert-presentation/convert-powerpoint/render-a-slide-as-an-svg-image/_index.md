---
title: Vykreslení snímků prezentace jako SVG obrázky v PHP
linktitle: Snímek na SVG
type: docs
weight: 50
url: /cs/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint na SVG
- prezentace na SVG
- snímek na SVG
- PPT na SVG
- PPTX na SVG
- uložit PPT jako SVG
- uložit PPTX jako SVG
- exportovat PPT do SVG
- exportovat PPTX do SVG
- vykreslit snímek
- převést snímek
- exportovat snímek
- vektorový obrázek
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak vykreslovat PowerPoint snímky jako SVG obrázky pomocí Aspose.Slides pro PHP přes Java. Vysoce kvalitní vizuály s jednoduchými ukázkami kódu."
---
## **Přehled**

Tento článek vysvětluje, jak vykreslovat snímky prezentace jako SVG obrázky pomocí Aspose.Slides. Popisuje formát SVG a jeho výhody, včetně škálovatelnosti, přístupnosti a vhodnosti pro vývoj webových aplikací.

Dozvíte se, jak načíst soubor prezentace, projít jeho snímky a uložit každý snímek jako samostatný SVG soubor. Článek pokrývá formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, ODP a PPS, a ukazuje, jak provést konverzi programově pomocí třídy `Presentation` a metody `writeAsSvg`.

## **Formát SVG**

SVG — akronym pro Scalable Vector Graphics — je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s detaily, které definují jejich chování nebo vzhled.

SVG je jedním z mála formátů obrázků, který splňuje velmi vysoké standardy v těchto ohledech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů se běžně používá ve webovém vývoji.

Můžete chtít používat SVG soubory, když potřebujete

- **vytisknout prezentaci ve *velmi velkém formátu*.** SVG obrázky lze škálovat na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků tolikrát, kolik je potřeba, aniž byste obětovali kvalitu.
- **používat grafy a diagramy ze svých snímků v *různých médiích nebo platformách*.** Většina čteček dokáže interpretovat SVG soubory.
- **používat *co nejmenší velikosti obrázků*.** SVG soubory jsou obecně menší než jejich vysokorozlišovací ekvivalenty v jiných formátech, zejména v formátech založených na bitmapách (JPEG nebo PNG).

## **Vykreslení snímku jako SVG obrázku**

Aspose.Slides for PHP via Java vám umožňuje exportovat snímky v prezentacích jako SVG obrázky. Proveďte následující kroky k vygenerování SVG obrázků:

1. Vytvořte instance třídy Presentation.
2. Projděte všechny snímky v prezentaci.
3. Zapište každý snímek do vlastního SVG souboru pomocí FileOutputStream.

{{% alert color="primary" %}} 

Můžete si vyzkoušet naši [bezplatná webová aplikace](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT do SVG z Aspose.Slides for PHP via Java.

{{% /alert %}} 

Tento ukázkový kód vám ukazuje, jak převést PPT do SVG pomocí Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    for($index = 0; $index < java_values($pres->getSlides()->size()) ; $index++) {
      $slide = $pres->getSlides()->get_Item($index);
      $fileStream = new Java("java.io.FileOutputStream", "slide-" . $index . ".svg");
      try {
        $slide->writeAsSvg($fileStream);
      } finally {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Proč může výstupní SVG vypadat v různých prohlížečích odlišně?**

Podpora specifických funkcí SVG je v různých prohlížečových enginech implementována odlišně. Parametry [SVGOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/svgoptions/) pomáhají vyrovnat nekompatibility.

**Je možné exportovat nejen snímky, ale i jednotlivé tvary do SVG?**

Ano. Každý [tvar lze uložit jako samostatný SVG](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/writeassvg/), což je vhodné pro ikony, piktogramy a opětovné použití grafiky.

**Lze spojit více snímků do jediného SVG (strip/dokument)?**

Standardní scénář je jeden snímek → jedno SVG. Kombinace několika snímků do jediného SVG plátna je krok následné úpravy prováděný na úrovni aplikace.