---
title: Přizpůsobení tabulek dat grafu v prezentacích pomocí Javy
linktitle: Datová tabulka
type: docs
url: /cs/java/chart-data-table/
keywords:
- data grafu
- datová tabulka
- vlastnosti písma
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte tabulky dat grafů v Javě pro PPT a PPTX pomocí Aspose.Slides a zvyšte efektivitu a atraktivitu prezentací."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tabulkami dat grafu v Aspose.Slides. Ukazuje, jak zobrazit tabulku dat pro graf a přizpůsobit formátování textu nastavením vlastností písma, jako je tučný styl a výška písma. Příklad demonstruje načtení prezentace, přidání grafu, povolení tabulky dat grafu, aplikaci nastavení písma a uložení aktualizované prezentace.

Obsahuje také stručné odpovědi na běžné otázky týkající se zobrazení legendových klíčů v tabulce dat grafu, zachování tabulky dat při exportu, práce s grafy načtenými ze stávajících prezentací nebo šablon a identifikace grafů, u nichž je tabulka dat povolena.

## **Nastavit vlastnosti písma pro tabulku dat grafu**
Aspose.Slides pro Java poskytuje podporu pro změnu barvy kategorií v barvě řady.  

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Nastavte tabulku grafu.
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

**Mohu zobrazit malé legendové klíče vedle hodnot v tabulce dat grafu?**

Ano. Tabulka dat podporuje [legendové klíče](https://reference.aspose.com/slides/cs/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) a můžete je zapnout nebo vypnout.

**Zůstane tabulka dat zachována při exportu prezentace do PDF, HTML nebo obrázků?**

Ano. Aspose.Slides vykresluje graf jako součást snímku, takže exportovaný [PDF](/slides/cs/java/convert-powerpoint-to-pdf/)/[HTML](/slides/cs/java/convert-powerpoint-to-html/)/[obrázek](/slides/cs/java/convert-powerpoint-to-png/) obsahuje graf s jeho tabulkou dat.

**Jsou tabulky dat podporovány pro grafy, které pocházejí ze souboru šablony?**

Ano. Pro jakýkoli graf načtený ze stávající prezentace nebo šablony můžete pomocí vlastností grafu zkontrolovat a změnit, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#hasDataTable--).

**Jak mohu rychle zjistit, které grafy v souboru mají povolenou tabulku dat?**

Prozkoumejte vlastnost každého grafu, která uvádí, zda je tabulka dat [zobrazena](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chart/#hasDataTable--), a projděte snímky, abyste identifikovali grafy, u nichž je povolena.