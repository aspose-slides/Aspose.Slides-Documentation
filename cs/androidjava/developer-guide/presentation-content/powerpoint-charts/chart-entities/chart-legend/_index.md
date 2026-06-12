---
title: Přizpůsobení legend grafů v prezentacích na Androidu
linktitle: Legenda grafu
type: docs
url: /cs/androidjava/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí Aspose.Slides pro Android prostřednictvím Javy a optimalizujte prezentace PowerPoint s cíleným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti pro přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak nastavit polohu a velikost legendy, nastavit velikost písma pro celou legendu a použít formátování na jednotlivý záznam legendy. 

Také se zabývá několika souvisejícími chováními v sekci Často kladené otázky, včetně používání režimu bez překrytí, aby oblast grafu uvolnila místo pro legendu, umožnění dlouhých popisků legendy zalomit nebo použít zalomení řádku a nechat formátování legendy dědit ze schématu motivu prezentace, pokud nejsou nastaveny explicitní nastavení textu a výplně. 

## **Umístění legendy**
Aby bylo možné nastavit vlastnosti legendy, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte referenci na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili polohu a velikost legendy grafu.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Získejte referenci na snímek
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Přidejte do snímku seskupený sloupcový graf
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
Aspose.Slides pro Android pomocí Javy umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle níže uvedených kroků:

- Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```java
// Vytvořte instanci třídy Presentation
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
Aspose.Slides pro Android pomocí Javy umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle níže uvedených kroků:

- Instancujte třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
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

**Mohu povolit legendu tak, aby graf automaticky vyčlenil místo pro ni místo překrytí?**

Ano. Použijte režim bez překrytí ([setOverlay(false)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); v tomto případě se oblast grafu zmenší, aby poskytla místo pro legendu.

**Mohu vytvořit víceřádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalomí, pokud není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu řady.

**Jak zajistit, aby legenda následovala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy/výplně/písma pro legendu ani její text. Ty pak budou dědit z motivu a správně se aktualizují při změně designu.