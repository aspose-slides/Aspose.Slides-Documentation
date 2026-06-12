---
title: Přizpůsobení tabulek dat grafu v prezentacích na Androidu
linktitle: Datová tabulka
type: docs
url: /cs/androidjava/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafu v jazyce Java pro soubory PPT a PPTX pomocí Aspose.Slides pro Android a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat grafu v Aspose.Slides. Ukazuje, jak zobrazit datovou tabulku pro graf a přizpůsobit formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení datové tabulky grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

## **Nastavení vlastností písma pro datovou tabulku grafu**
Aspose.Slides pro Android via Java poskytuje podporu pro změnu barvy kategorií v barvě řady.

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. nastavit tabulku grafu.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

```java
// Vytvoření prázdné prezentace
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v datové tabulce grafu?**

Ano. Datová tabulka podporuje [legendové klíče](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) a můžete je zapnout nebo vypnout.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/androidjava/convert-powerpoint-to-html/)/[image](/slides/cs/androidjava/convert-powerpoint-to-png/) obsahuje graf s jeho datovou tabulkou.

**Jsou datové tabulky podporovány pro grafy pocházející ze šablonového souboru?**

Ano. Pro jakýkoli graf načtený z existující prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#hasDataTable--).

**Jak mohu rychle zjistit, které grafy v souboru mají povolenou datovou tabulku?**

Prohlédněte vlastnost každého grafu, která udává, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chart/#hasDataTable--), a projděte snímky, abyste identifikovali grafy, u kterých je povolena.