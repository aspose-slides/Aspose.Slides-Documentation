---
title: Prezentáció diagramok formázása Java-ban
linktitle: Diagram formázás
type: docs
weight: 60
url: /hu/java/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram entitás
- diagram tulajdonságok
- diagram beállítások
- diagram lehetőségek
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Java-ban, és emelje fel PowerPoint prezentációját professzionális, figyelemfelkeltő stílussal."
---
## **Áttekintés**

Ez a cikk leírja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan testreszabhatók a diagramok kulcsfontosságú elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a rajzterület és a falkitöltések, a diagramadatok megjelenésének és olvashatóságának javítása érdekében.

A cikk bemutatja továbbá, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált és egyéni számformátumok a diagram adataira, valamint hogyan engedélyezhetők a lekerekített sarkok a diagram területén. Ezek a példák együtt azt mutatják, hogyan szabályozható a diagramok megjelenési stílusa és adatmegjelenítése egy prezentációban.

## **Diagramelemek formázása**
Az Aspose.Slides for Java lehetővé teszi a fejlesztőknek, hogy teljesen új diagramokat adjanak a diákhoz. Ez a cikk elmagyarázza, hogyan formázhatók a különböző diagramelemek, beleértve a diagramkategória‑ és értéktengelyt.

Az Aspose.Slides for Java egyszerű API‑t biztosít a különböző diagramelemek kezeléséhez és azok egyéni értékekkel történő formázásához:

1. Hozzon létre egy példányt a [**Presentation**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típusok egyikével (ebben a példában a ChartType.LineWithMarkers típust használjuk).
1. Érje el a diagram Érték‑tengelyét, és állítsa be a következő tulajdonságokat:
   1. A **Line format** beállítása az Érték‑tengely fő rácsvonalaihoz.
   1. A **Line format** beállítása az Érték‑tengely alrácsvonalaihoz.
   1. A **Number Format** beállítása az Érték‑tengelyhez.
   1. A **Min, Max, Major and Minor units** beállítása az Érték‑tengelyhez.
   1. A **Text Properties** beállítása az Érték‑tengely adataihoz.
   1. A **Title** beállítása az Érték‑tengelyhez.
   1. A **Line Format** beállítása az Érték‑tengelyhez.
1. Érje el a diagram Kategória‑tengelyét, és állítsa be a következő tulajdonságokat:
   1. A **Line format** beállítása a Kategória‑tengely fő rácsvonalaihoz.
   1. A **Line format** beállítása a Kategória‑tengely alrácsvonalaihoz.
   1. A **Text Properties** beállítása a Kategória‑tengely adataihoz.
   1. A **Title** beállítása a Kategória‑tengelyhez.
   1. A **Label Positioning** beállítása a Kategória‑tengelyhez.
   1. A **Rotation Angle** beállítása a Kategória‑tengely címkéihez.
1. Érje el a diagram jelmagyarázatát, és állítsa be a **Text Properties** értékét.
1. Állítsa be a diagram jelmagyarázatának megjelenítését úgy, hogy ne fedje át a diagramot.
1. Érje el a diagram **Secondary Value Axis**‑t, és állítsa be a következő tulajdonságokat:
   1. A másodlagos **Value Axis** engedélyezése.
   1. A **Line Format** beállítása a másodlagos Érték‑tengelyhez.
   1. A **Number Format** beállítása a másodlagos Érték‑tengelyhez.
   1. A **Min, Max, Major and Minor units** beállítása a másodlagos Érték‑tengelyhez.
1. Most ábrázolja az első diagram sorozatot a másodlagos Érték‑tengelyen.
1. Állítsa be a diagram háttérfalának kitöltőszínét.
1. Állítsa be a diagram ábrázolási területének kitöltőszínét.
1. Írja a módosított prezentációt egy PPTX fájlba.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Minta diagram hozzáadása
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Diagram címének beállítása
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Az értéktengely fő rácsvonalainak formátumának beállítása
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Az értéktengely alrácsvonalainak formátumának beállítása
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Az értéktengely számformátumának beállítása
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // A diagram maximális és minimális értékeinek beállítása
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Az értéktengely szövegtulajdonságainak beállítása
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Az értéktengely címének beállítása
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // A kategória tengely fő rácsvonalainak formátumának beállítása
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // A kategória tengely alrácsvonalainak formátumának beállítása
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // A kategória tengely szövegtulajdonságainak beállítása
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // A kategória címének beállítása
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // A kategória tengely címkéjének pozíciójának beállítása
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // A kategória tengely címkéjének forgásszögének beállítása
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // A jelmagyarázat szövegtulajdonságainak beállítása
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Állítsa be, hogy a jelmagyarázat ne fedje át a diagramot

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Másodlagos értéktengely beállítása
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Másodlagos értéktengely számformátumának beállítása
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // A diagram maximális és minimális értékeinek beállítása
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // A diagram háttérfal színének beállítása
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // A diagram ábrázolási terület színének beállítása
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Prezentáció mentése
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Betűtípus‑tulajdonságok beállítása egy diagramhoz**
Az Aspose.Slides for Java támogatja a diagram betűtípus‑tulajdonságainak beállítását. Kövesse az alábbi lépéseket a betűtípus‑tulajdonságok beállításához a diagramon.

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályobjektumot.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a betűméretet.
- Mentse el a módosított prezentációt.

Az alábbi példa bemutatja.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Számformátum beállítása**
Az Aspose.Slides for Java egyszerű API‑t biztosít a diagramadat-formátum kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Szerezzen meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típusok egyikével (ebben a példában a **ChartType.ClusteredColumn** típust használjuk).
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.
1. Járja be a diagram adatcelláit minden diagram sorozatban, és állítsa be a diagram adatainak számformátumát.
1. Mentse el a prezentációt.
1. Állítsa be az egyéni számformátumot.
1. Járja be a diagram adatcelláit minden sorozatban, és állítson be eltérő számformátumot.
1. Mentse el a prezentációt.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    // Az első prezentációs dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Alapértelmezett csoportosított oszlopdiagram hozzáadása
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // A diagram sorozatgyűjteményének elérése
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Az összes diagram sorozaton végig iterálás
    for (IChartSeries ser : series) 
    {
        // Az adott sorozat minden adatcelláján végig iterálás
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // A számformátum beállítása
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Prezentáció mentése
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

A lehetséges előre definiált számformátum‑értékek a hozzájuk tartozó indexekkel együtt az alábbiak:

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Lekerekített szegélyek beállítása a diagram területen**
Az Aspose.Slides for Java támogatja a diagram területének beállítását. A [**hasRoundedCorners**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart#hasRoundedCorners--) és a [**setRoundedCorners**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) metódusok hozzá lettek adva az [IChart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChart) interfészhez és a [Chart](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Chart) osztályhoz.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályobjektumot.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram kitöltésének típusát és színét.
1. Állítsa a lekerekített sarok tulajdonságot True‑ra.
1. Mentse el a módosított prezentációt.

Az alábbi példa bemutatja.

```java
// Hozzon létre egy példányt a Presentation osztályból
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopokhoz/területekhez, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, csak a kiválasztott pontokhoz jelenítse meg a címkéket, vagy váltson a „érték + jelmagyarázat” formátumra.

**Alkalmazhatok gradienst vagy mintás kitöltést sorozatokra?**

Igen. Általában elérhetők a tömör és a gradiensek/minták kitöltések is. Gyakorlatban csak mértékkel használja a gradienteket, és kerülje azokat a kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.