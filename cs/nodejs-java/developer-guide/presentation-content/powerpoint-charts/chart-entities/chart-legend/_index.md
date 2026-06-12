---
title: Přizpůsobení legend grafů v prezentacích pomocí JavaScriptu
linktitle: Legenda grafu
type: docs
url: /cs/nodejs-java/chart-legend/
keywords:
- legenda grafu
- pozice legendy
- velikost písma
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte legendy grafů pomocí JavaScriptu a Aspose.Slides pro Node.js a optimalizujte prezentace PowerPoint s upraveným formátováním legend."
---
## **Přehled**

Aspose.Slides poskytuje možnosti přizpůsobení legend grafů v prezentacích PowerPoint. Tento článek ukazuje, jak umístit a nastavit velikost legendy, nastavit velikost písma pro celou legendu a použít formátování na jednotlivou položku legendy.

Také pokrývá několik souvisejících chování v častých dotazech (FAQ), včetně použití režimu bez překrývání, aby oblast grafu vytvořila místo pro legendu, umožnění dlouhých popisků legendy zalomit nebo použít konce řádků, a nechat formátování legendy dědit z motivu prezentace, pokud nejsou nastaveny explicitní textové a výplňové hodnoty.

## **Umístění legendy**

Pro nastavení vlastností legendy postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek.
- Přidejte graf na snímek.
- Nastavte vlastnosti legendy.
- Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme nastavili polohu a velikost legendy grafu.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získejte referenci na snímek
    var slide = pres.getSlides().get_Item(0);
    // Přidejte seskupený sloupcový graf na snímek
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Nastavte vlastnosti legendy
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Uložte prezentaci na disk
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení velikosti písma legendy**

Aspose.Slides pro Node.js via Java umožňuje vývojářům nastavit velikost písma legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení velikosti písma jednotlivé položky legendy**

Aspose.Slides pro Node.js via Java umožňuje vývojářům nastavit velikost písma jednotlivých položek legendy. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Vytvořte výchozí graf.
- Získejte přístup k položce legendy.
- Nastavte velikost písma.
- Nastavte minimální hodnotu osy.
- Nastavte maximální hodnotu osy.
- Uložte prezentaci na disk.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Časté dotazy**

**Mohu povolit legendu tak, aby graf automaticky vyčlenil místo pro ni místo překrývání?**

Ano. Použijte režim bez překrývání ([setOverlay(false)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/legend/setoverlay/)); v tomto případě se oblast grafu zmenší, aby vytvořila místo pro legendu.

**Mohu vytvořit víceřádkové popisky legendy?**

Ano. Dlouhé popisky se automaticky zalamují, pokud není dostatek místa; vynucené zalomení řádku je podporováno pomocí znaků nového řádku v názvu řady.

**Jak mohu, aby legenda následovala barevné schéma motivu prezentace?**

Nenastavujte explicitní barvy/výplně/písma pro legendu nebo její text. Pak budou dědit z motivu a při změně designu se správně aktualizují.