---
title: Přizpůsobení tabulek dat grafů v prezentacích pomocí JavaScriptu
linktitle: Tabulka dat
type: docs
url: /cs/nodejs-java/chart-data-table/
keywords:
- data grafu
- tabulka dat
- vlastnosti písma
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafů v JavaScriptu pro PPT a PPTX pomocí Aspose.Slides pro Node.js přes Java a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat v grafech v Aspose.Slides. Ukazuje, jak zobrazit datovou tabulku pro graf a přizpůsobit její formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení datové tabulky grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

Také obsahuje stručné odpovědi na často kladené otázky o zobrazování legendových klíčů v datové tabulce grafu, zachování datové tabulky během exportu, práci s grafy načtenými ze stávajících prezentací nebo šablon a identifikaci grafů, u kterých je datová tabulka povolena.

## **Nastavení vlastností písma pro tabulku dat grafu**

Aspose.Slides pro Node.js přes Java poskytuje podporu pro změnu barvy kategorií v barvě řady. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte graf do snímku.
1. nastavte tabulku grafu.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad. 

```javascript
// Vytvoření prázdné prezentace
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu zobrazit malé legendové klíče vedle hodnot v datové tabulce grafu?**

Ano. Datová tabulka podporuje [legendové klíče](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/datatable/setshowlegendkey/), a můžete je zapnout nebo vypnout.

**Zůstane datová tabulka zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/cs/nodejs-java/convert-powerpoint-to-png/) obsahuje graf s jeho datovou tabulkou.

**Jsou datové tabulky podporovány pro grafy pocházející ze šablony?**

Ano. U libovolného grafu načteného ze stávající prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/hasdatatable/).

**Jak mohu rychle zjistit, které grafy v souboru mají povolenou datovou tabulku?**

Prohlédněte vlastnost každého grafu, která uvádí, zda je datová tabulka [zobrazena](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/hasdatatable/), a projděte snímky, abyste identifikovali grafy, u nichž je povolena.