---
title: Diagramok formázása PowerPoint-prezentációkban JavaScriptben
linktitle: Diagram formázása
type: docs
weight: 60
url: /hu/nodejs-java/chart-formatting/
keywords:
- diagram formázása
- diagram formázása
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Node.js JavaScript-ben, és emelje prezentációját professzionális, szemrevaló stílussal."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet formázni diagramokat PowerPoint‑prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan lehet testreszabni a diagram kulcsfontosságú elemeit, például a tengelyeket, rácsvonalakat, címeket, jelmagyarázatot, a diagramterületet és a fal kitöltését, a diagramadatok megjelenésének és olvashatóságának javítása érdekében.  

Az is bemutatja, hogyan lehet beállítani a diagram szövegének betűtípus‑tulajdonságait, előre definiált és egyéni numerikus formátumokat alkalmazni a diagram adataira, illetve lekerekített sarkokat engedélyezni a diagram területén. Ezek a példák együtt azt mutatják, hogyan lehet vezérelni a diagramok vizuális stílusát és adatmegjelenítését egy prezentációban.

## **Diagramelemek formázása**

Az Aspose.Slides for Node.js via Java lehetővé teszi a fejlesztők számára, hogy az elejétől egyedi diagramokat adjanak a diákhoz. Ez a cikk elmagyarázza, hogyan lehet formázni különböző diagramelemeket, beleértve a diagram kategória‑ és értéktengelyeit.

Az Aspose.Slides for Node.js via Java egyszerű API‑t biztosít a különböző diagramelemek kezeléséhez és egyéni értékekkel való formázásához:

1. Hozzon létre egy példányt a [**Presentation**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.  
1. Szerzessen be egy dia hivatkozását index alapján.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típus valamelyikével (ebben a példában a ChartType.LineWithMarkers típusú diagramot használjuk).  
1. Érje el a diagram Értéktengelyét, és állítsa be a következő tulajdonságokat:
   1. A Value Axis fő rácsvonalaihoz **Line format** beállítása  
   1. A Value Axis alacsonyabb rácsvonalaihoz **Line format** beállítása  
   1. A Value Axis **Number Format** beállítása  
   1. A Value Axis **Min, Max, Major and Minor units** beállítása  
   1. A Value Axis adataihoz **Text Properties** beállítása  
   1. A Value Axis **Title** beállítása  
   1. A Value Axis **Line Format** beállítása  
1. Érje el a diagram Kategória‑tengelyét, és állítsa be a következő tulajdonságokat:
   1. A Category Axis fő rácsvonalaihoz **Line format** beállítása  
   1. A Category Axis alacsonyabb rácsvonalaihoz **Line format** beállítása  
   1. A Category Axis adataihoz **Text Properties** beállítása  
   1. A Category Axis **Title** beállítása  
   1. A Category Axis **Label Positioning** beállítása  
   1. A Category Axis címkék **Rotation Angle** beállítása  
1. Érje el a diagram jelmagyarázatát, és állítsa be a **Text Properties** tulajdonságokat.  
1. Állítsa be a diagram jelmagyarázatának megjelenítését úgy, hogy ne fedje egymást a diagram.  
1. Érje el a diagram **Secondary Value Axis**‑t, és állítsa be a következő tulajdonságokat:
   1. A másodlagos **Value Axis** engedélyezése  
   1. A másodlagos Value Axis **Line Format** beállítása  
   1. A másodlagos Value Axis **Number Format** beállítása  
   1. A másodlagos Value Axis **Min, Max, Major and Minor units** beállítása  
1. Most ábrázolja az első diagram sorozatot a másodlagos Value Axis‑on.  
1. Állítsa be a diagram hátfal kitöltőszínét.  
1. Állítsa be a diagram ábrázolási területének kitöltőszínét.  
1. Írja a módosított prezentációt egy PPTX fájlba.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Minta diagram hozzáadása
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Diagram címének beállítása
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Fő rácsvonalak formátumának beállítása az értéktengelyhez
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Kisebb rácsvonalak formátumának beállítása az értéktengelyhez
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Értéktengely számformátumának beállítása
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Diagram maximum és minimum értékeinek beállítása
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Értéktengely szövegtulajdonságainak beállítása
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Értéktengely címének beállítása
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Fő rácsvonalak formátumának beállítása a kategória tengelyhez
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Kisebb rácsvonalak formátumának beállítása a kategória tengelyhez
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Kategória tengely szövegtulajdonságainak beállítása
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Kategória címének beállítása
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Kategória tengely címke pozíciójának beállítása
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Kategória tengely címke forgatási szögének beállítása
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Jelmagyarázat szövegtulajdonságainak beállítása
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Állítsa be a jelmagyarázat megjelenítését átfedés nélkül
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Másodlagos értéktengely beállítása
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Másodlagos értéktengely számformátumának beállítása
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Diagram maximum és minimum értékeinek beállítása
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Diagram hátfal színének beállítása
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ábrázolási terület színének beállítása
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Prezentáció mentése
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Diagram betűtípus‑tulajdonságainak beállítása**

Az Aspose.Slides for Node.js via Java támogatja a diagram betűtípus‑kapcsolatos tulajdonságainak beállítását. Kérjük, kövesse az alábbi lépéseket a diagram betűtípus‑tulajdonságainak beállításához.

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályobjektumot.  
- Adjon hozzá diagramot a diára.  
- Állítsa be a betűmagasságot.  
- Mentse a módosított prezentációt.

Az alábbi mintapélda szerepel.

```javascript
// Hozzon létre egy Presentation osztály példányt
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numerikus formátum beállítása**

Az Aspose.Slides for Node.js via Java egyszerű API‑t biztosít a diagram adatformátum kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályból.  
1. Szerzessen be egy dia hivatkozását index alapján.  
1. Adjon hozzá egy diagramot alapértelmezett adatokkal és a kívánt típus valamelyikével (ez a példa a **ChartType.ClusteredColumn** típust használja).  
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.  
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítsa be a diagram adat számformátumát.  
1. Mentse a prezentációt.  
1. Állítsa be az egyéni számformátumot.  
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítson be különböző számformátumot.  
1. Mentse a prezentációt.

```javascript
// Presentation osztály példány létrehozása
var pres = new aspose.slides.Presentation();
try {
    // Az első prezentációs dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Alapértelmezett csoportosított oszlop diagram hozzáadása
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // A diagram sorozatgyűjteményének elérése
    var series = chart.getChartData().getSeries();
    // Az összes diagram sorozaton való iterálás
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Az adott sorozat minden adatcellájának bejárása
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // A számformátum beállítása
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0,00%
        }
    }
    // Prezentáció mentése
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Az alább felsorolt lehetséges előre definiált számformátum‑értékek a hozzájuk tartozó indexszámokkal együtt használhatók:

|**0**|Általános|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Kerekített szegélyek beállítása a diagram területén**

Az Aspose.Slides for Node.js via Java támogatja a diagramterület beállítását. A [**hasRoundedCorners**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) és a [**setRoundedCorners**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) metódusok hozzá lettek adva a [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart) osztályhoz.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályobjektumot.  
1. Adjon hozzá diagramot a diára.  
1. Állítsa be a diagram kitöltésének típusát és színét.  
1. Állítsa be a lekerekített sarkok tulajdonságát True‑ra.  
1. Mentse a módosított prezentációt.

Az alábbi mintapélda szerepel.  

```javascript
// Presentation osztály példány létrehozása
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Beállíthatok félig átlátszó kitöltést oszlopokhoz/területekhez, miközben a szegély átlátszatlan marad?**  

Igen. A kitöltés átlátszósága és a körvonal külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**  

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, szükség esetén csak a kiválasztott pontoknak mutassa a címkéket, vagy váltsa át a formátumot "érték + jelmagyarázat"-ra.

**Alkalmazhatok fokozat- vagy mintakitet a sorozatokra?**  

Igen. Mindaz egyenletes, mind a fokozat‑ vagy mintakiközök általában elérhetők. Gyakorlati tanácsként a fokozatokat visszafogottan használja, és kerülje azokat a kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.