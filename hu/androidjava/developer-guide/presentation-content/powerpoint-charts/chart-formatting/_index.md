---
title: Androidon lévő prezentációs diagramok formázása
linktitle: Diagram formázás
type: docs
weight: 60
url: /hu/androidjava/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Android via Java segítségével, és emelje prezentációját PowerPointban professzionális, szemrevaló stílusokkal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, mint például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a fal kitöltései, a diagramadatok megjelenésének és olvashatóságának javítása érdekében.

Továbbá bemutatja, hogyan állíthatók be a betűtípus‑tulajdonságok a diagram szövegéhez, hogyan alkalmazhatók előre definiált és egyéni numerikus formátumok a diagram adataihoz, valamint hogyan engedélyezhetők a lekerekített sarkok a diagramterületen. Ezek a példák együtt mutatják, hogyan szabályozható a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagram elemek formázása**
Az Aspose.Slides for Android via Java lehetővé teszi a fejlesztők számára, hogy saját diagramokat adjanak hozzá diákhoz a semmiből. Ez a cikk bemutatja, hogyan formázhatók a különböző diagram elemek, beleértve a diagramkategória‑ és értéktengelyt.

Az Aspose.Slides for Android via Java egyszerű API‑t biztosít a különböző diagram elemek kezeléséhez és azok egyéni értékekkel történő formázásához:

1. Hozzon létre egy példányt a [**Presentation**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását index alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben a példában a ChartType.LineWithMarkers‑t használjuk).
1. Nyissa meg a diagram Érték‑tengelyét, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása az Érték‑tengely fő rácsvonalaihoz
   1. **Line format** beállítása az Érték‑tengely alárendelt rácsvonalaihoz
   1. **Number Format** beállítása az Érték‑tengelyhez
   1. **Min, Max, Major and Minor units** beállítása az Érték‑tengelyhez
   1. **Text Properties** beállítása az Érték‑tengely adatainak
   1. **Title** beállítása az Érték‑tengelyhez
   1. **Line Format** beállítása az Érték‑tengelyhez
1. Nyissa meg a diagram Kategória‑tengelyét, és állítsa be a következő tulajdonságokat:
   1. **Line format** beállítása a Kategória‑tengely fő rácsvonalaihoz
   1. **Line format** beállítása a Kategória‑tengely alárendelt rácsvonalaihoz
   1. **Text Properties** beállítása a Kategória‑tengely adatainak
   1. **Title** beállítása a Kategória‑tengelyhez
   1. **Label Positioning** beállítása a Kategória‑tengelyhez
   1. **Rotation Angle** beállítása a Kategória‑tengely címkéihez
1. Nyissa meg a diagram Jelmagyarázatát, és állítsa be a **Text Properties**‑t számukra
1. Állítsa be, hogy a diagram jelmagyarázata ne fedje át a diagramot
1. Nyissa meg a diagram **Secondary Value Axis**‑t, és állítsa be a következő tulajdonságokat:
   1. Engedélyezze a másodlagos **Value Axis**‑t
   1. **Line Format** beállítása a másodlagos Érték‑tengelyhez
   1. **Number Format** beállítása a másodlagos Érték‑tengelyhez
   1. **Min, Max, Major and Minor units** beállítása a másodlagos Érték‑tengelyhez
1. Most ábrázolja az első diagram sorozatot a másodlagos Érték‑tengelyen
1. Állítsa be a diagram hátsó falának kitöltőszínét
1. Állítsa be a diagram diagramterületének kitöltőszínét
1. Írja a módosított prezentációt PPTX fájlba

```java
// Presentation osztály példányának létrehozása
Presentation pres = new Presentation();
try {
    // Az első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Minta diagram hozzáadása
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Diagram cím beállítása
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Fő rácsvonalak formátumának beállítása az érték‑tengelyhez
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Alárendelt rácsvonalak formátumának beállítása az érték‑tengelyhez
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Érték‑tengely számformátumának beállítása
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Diagram maximális és minimális értékek beállítása
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Érték‑tengely szövegtulajdonságainak beállítása
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Érték‑tengely címének beállítása
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Fő rácsvonalak formátumának beállítása a kategória‑tengelyhez
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Alárendelt rácsvonalak formátumának beállítása a kategória‑tengelyhez
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Kategória‑tengely szövegtulajdonságainak beállítása
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Kategória‑tengely címének beállítása
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Kategória‑tengely címke pozíciójának beállítása
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Kategória‑tengely címke forgatási szöge
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Jelmagyarázat szövegtulajdonságainak beállítása
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Diagram jelmagyarázatának megjelenítése a diagram átfedése nélkül

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Másodlagos érték‑tengely beállítása
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Másodlagos érték‑tengely számformátumának beállítása
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Diagram maximális és minimális értékek beállítása
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Diagram hátfal színének beállítása
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Ábrázolási terület színének beállítása
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Prezentáció mentése
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Diagram betűtípus‑tulajdonságainak beállítása**
Az Aspose.Slides for Android via Java támogatja a diagram betűtípus‑tulajdonságainak beállítását. Kövesse az alábbi lépéseket a diagram betűtípus‑tulajdonságainak megadásához.

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztálypéldányt.
- Adjon hozzá egy diagramot a diára.
- Állítsa be a betűtípus magasságát.
- Mentse a módosított prezentációt.

Az alábbi minta példa ezt szemlélteti.

```java
// Presentation osztály példányának létrehozása
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

## **Numerikus formátum beállítása**
Az Aspose.Slides for Android via Java egyszerű API‑t biztosít a diagramadat‑formátum kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze meg a dia hivatkozását index alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal a kívánt típussal (ebben a példában a **ChartType.ClusteredColumn**‑t használjuk).
1. Állítsa be az előre definiált számformátumot az elérhető értékek közül.
1. Járja végig a diagram adatcelláit minden diagram sorozatban, és állítsa be a diagram adat‑számformátumát.
1. Mentse a prezentációt.
1. Állítsa be az egyéni számformátumot.
1. Járja végig a diagram adatcelláit minden diagram sorozatban, és állítson be különböző számformátumot.
1. Mentse a prezentációt.

```java
// Presentation osztály példányának létrehozása
Presentation pres = new Presentation();
try {
    // Az első prezentációs dia elérése
    ISlide slide = pres.getSlides().get_Item(0);

    // Alapértelmezett csoportos oszlopdiagram hozzáadása
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // A diagram sorozatgyűjteményének elérése
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Minden diagram sorozaton való iteráció
    for (IChartSeries ser : series) 
    {
        // Sorozat minden adatcellájának iterációja
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // A számformátum beállítása
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    // Prezentáció mentése
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Az elérhető előre definiált számformátum‑értékek a hozzájuk tartozó indexekkel együtt az alábbiak:

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

## **Lekerekített sarkok beállítása a diagram területén**
Az Aspose.Slides for Android via Java támogatja a diagram területének beállítását. A [**hasRoundedCorners**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) és a [**setRoundedCorners**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) metódusok hozzá lettek adva az [IChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart) interfészhez és a [Chart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Chart) osztályhoz.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztálypéldányt.
1. Adjon hozzá egy diagramot a diára.
1. Állítsa be a diagram kitöltésének típusát és színét
1. Állítsa be a lekerekített sarok tulajdonságát igazra.
1. Mentse a módosított prezentációt.

Az alábbi minta példa ezt szemlélteti.

```java
// Presentation osztály példányának létrehozása
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

**Hogyan kezeljem a felülcsúszó adatcímkéket?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke eltolását/pozícióját, ha szükséges, csak a kiválasztott pontok címkéit mutassa, vagy váltson a „érték + jelmagyarázat” formátumra.

**Alkalmazhatok‑e színátmenetes vagy mintás kitöltéseket sorozatokra?**

Igen. Mind a szilárd, mind a színátmenetes/mintás kitöltések általában elérhetők. A gyakorlatban használjon színátmeneteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.