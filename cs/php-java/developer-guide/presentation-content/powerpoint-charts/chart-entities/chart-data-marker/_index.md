---
title: Správa ukazatelů dat grafu v prezentacích pomocí PHP
linktitle: Ukazatel dat
type: docs
url: /cs/php-java/chart-data-marker/
keywords:
- graf
- datový bod
- ukazatel
- volby ukazatele
- velikost ukazatele
- typ výplně
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte, jak přizpůsobit ukazatele dat grafu v Aspose.Slides pro PHP, což zvyšuje dopad prezentací v formátech PPT a PPTX pomocí jasných ukázek kódu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s ukazateli dat v grafech v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k řadě a jejím datovým bodům, aplikovat výplň obrázkem na ukazatele na úrovni datových bodů, upravit velikost ukazatele a uložit aktualizovanou prezentaci. Také poznamenává, že standardní tvary ukazatelů jsou k dispozici prostřednictvím výčtu `MarkerStyleType` a že vzhled ukazatele je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení možností ukazatelů grafu**
Ukazatele lze nastavit na datových bodech grafu v konkrétní řadě. Pro nastavení možností ukazatelů grafu postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte obrázek.
- Vyberte první řadu grafu.
- Přidejte nový datový bod.
- Zapište prezentaci na disk.

V ukázce uvedené níže jsme nastavili možnosti ukazatelů grafu na úrovni datových bodů.

```php
  # Vytvoření prázdné prezentace
  $pres = new Presentation();
  try {
    # Přístup k prvnímu snímku
    $slide = $pres->getSlides()->get_Item(0);
    # Vytvoření výchozího grafu
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 0, 0, 400, 400);
    # Získání indexu výchozího listu dat grafu
    $defaultWorksheetIndex = 0;
    # Získání listu dat grafu
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Odstranění ukázkové řady
    $chart->getChartData()->getSeries()->clear();
    # Přidání nové řady
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    # Načtení obrázku 1
    $imgx1 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Desert.jpg")));
    # Načtení obrázku 2
    $imgx2 = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "Tulips.jpg")));
    # Vybrání první řady grafu
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # Add new point (1:3) there.
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 2.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 3.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx1);
    $point = $series->getDataPoints()->addDataPointForLineSeries($fact->getCell($defaultWorksheetIndex, 4, 1, 4.5));
    $point->getMarker()->getFormat()->getFill()->setFillType(FillType::Picture);
    $point->getMarker()->getFormat()->getFill()->getPictureFillFormat()->getPicture()->setImage($imgx2);
    # Změna ukazatele řady grafu
    $series->getMarker()->setSize(15);
    # Uložení prezentace s grafem
    $pres->save("ScatterChart.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jaké tvary ukazatelů jsou k dispozici přímo z krabice?**

K dispozici jsou standardní tvary (kruh, čtverec, diamant, trojúhelník atd.); seznam je definován třídou [MarkerStyleType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte ukazatel s výplní obrázkem pro napodobení vlastních vizuálů.

**Zůstávají ukazatele zachovány při exportu grafu jako obrázek nebo SVG?**

Ano. Při vykreslování grafů do [raster formats](/slides/cs/php-java/convert-powerpoint-to-png/) nebo ukládání [shapes as SVG](/slides/cs/php-java/render-a-slide-as-an-svg-image/), ukazatele si zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.