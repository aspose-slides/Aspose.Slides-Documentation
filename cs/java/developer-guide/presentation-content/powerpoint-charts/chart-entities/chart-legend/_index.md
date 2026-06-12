---
title: Přizpůsobení legend grafů v prezentacích pomocí Javy
linktitle: Legenda grafu
type: docs
url: /cs/java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Javu a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak nastavit polohu a velikost legendy, nastavit velikost písma pro celou legendu a použít formátování na jednotlivou položku legendy.

Také popisuje několik souvisejících chování v sekci FAQ, včetně použití režimu bez překrytí, aby oblast grafu udělala místo pro legendu, umožnění zalamování dlouhých štítků legendy nebo použití konců řádků a nechat formátování legendy zdědit z motivu prezentace, pokud nejsou použita explicitní nastavení textu a výplně.

## **Umístění legendy**
Pro nastavení vlastností legendy postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Získejte odkaz na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili polohu a velikost legendy grafu.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Získejte odkaz na snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidejte seskupený sloupcový graf na snímek
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Nastavte vlastnosti legendy
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Uložte prezentaci na disk
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení velikosti písma legendy**
Aspose.Slides pro Java umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```java
// Create an instance of Presentation class
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení velikosti písma jednotlivé položky legendy**
Aspose.Slides pro Java umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Vytvořte výchozí graf.
- Získejte přístup k položce legendy.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Can I enable the legend so that the chart automatically allocates space for it instead of overlaying it?**

Ano. Použijte režim bez překrytí ([setOverlay(false)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/legend/#setOverlay-boolean-)); v tomto případě se oblast grafu zmenší, aby udělala místo legendě.

**Can I make multi-line legend labels?**

Ano. Dlouhé štítky se automaticky zalamují, pokud není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku ve jménu řady.

**How do I make the legend follow the presentation theme’s color scheme?**

Nenastavujte explicitní barvy/výplně/písma pro legendu ani její text. Ty pak zdědí motiv a budou se správně aktualizovat při změně designu.