---
title: Přizpůsobení tabulek dat grafů v prezentacích pomocí PHP
linktitle: Datová tabulka
type: docs
url: /cs/php-java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafů pro PPT a PPTX pomocí Aspose.Slides pro PHP přes Java a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat grafů v Aspose.Slides. Ukazuje, jak zobrazit tabulku dat pro graf a přizpůsobit formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení tabulky dat grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

Obsahuje také stručné odpovědi na časté otázky o zobrazování legendových klíčů v tabulce dat grafu, zachování tabulky dat při exportu, práci s grafy načtenými z existujících prezentací nebo šablon a identifikaci grafů, kde je tabulka dat povolena.

## **Nastavení vlastností písma pro tabulku dat grafu**
Aspose.Slides pro PHP přes Java poskytuje podporu pro změnu barvy kategorií v barvě série.  

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation).  
1. Přidejte graf na snímek.  
1. nastavte tabulku grafu.  
1. Nastavte výšku písma.  
1. Uložte upravenou prezentaci.  

Níže je uveden ukázkový příklad.  

```php
  # Vytvoření prázdné prezentace
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v tabulce dat grafu?**

Ano. Tabulka dat podporuje [legendové klíče](https://reference.aspose.com/slides/cs/php-java/aspose.slides/datatable/setshowlegendkey/), a můžete je zapnout nebo vypnout.

**Bude tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/php-java/convert-powerpoint-to-html/)/[obrázek](/slides/cs/php-java/convert-powerpoint-to-png/) obsahuje graf s jeho tabulkou dat.

**Jsou tabulky dat podporovány pro grafy pocházející ze souboru šablony?**

Ano. Pro jakýkoli graf načtený z existující prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je tabulka dat [zobrazená](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/hasdatatable/).

**Jak mohu rychle najít, které grafy v souboru mají povolenou tabulku dat?**

Prozkoumejte vlastnost každého grafu, která udává, zda je tabulka dat [zobrazená](https://reference.aspose.com/slides/cs/php-java/aspose.slides/chart/hasdatatable/), a projděte snímky, abyste identifikovali grafy, kde je povolena.