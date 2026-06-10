---
title: Diagramok létrehozása VSTO-val és Aspose.Slides for .NET segítségével
linktitle: Diagram létrehozása
type: docs
weight: 80
url: /hu/net/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- diagram létrehozása
- migráció
- VSTO
- Office automatizálás
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan automatizálhatja a PowerPoint diagramok létrehozását C#-ban. Ez a lépésről-lépésre útmutató bemutatja, miért a Aspose.Slides for .NET egy gyorsabb, erősebb alternatíva a Microsoft.Office.Interop-hez képest."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre és testreszabhatunk diagramokat a Microsoft PowerPoint bemutatókban programozottan C# használatával. Az Aspose.Slides for .NET segítségével automatizálhatja a professzionális, adatalapú diagramok előállítását anélkül, hogy a Microsoft Office vagy az Interop könyvtárakra támaszkodna. Az API gazdag funkciókészletet biztosít oszlopdiagramok, kördiagramok, vonaldiagramok és egyéb diagramok létrehozásához – mindezzel teljes irányítást biztosítva a megjelenés, az adatok és az elrendezés felett. Akár jelentéseket, műszerfalakat vagy üzleti prezentációkat generál, az Aspose.Slides segít magas színvonalú vizualizációkat közvetlenül .NET alkalmazásaiból szállítani.

## **VSTO példa**

Ez a szakasz bemutatja, hogyan hozhatunk létre egy diagramot egy Microsoft PowerPoint bemutatóban **VSTO (Visual Studio Tools for Office)** használatával. A VSTO-val programozottan generálhat és testreszabhat diagramokat a PowerPoint és az Excel automatizálásának kombinálásával. A bemutatott példa azt mutatja be, hogyan adhatunk hozzá egy **3D clustered column chart** táblázatot, hogyan töltsük fel adatokal egy Excel munkalapról, hogyan állítsuk be a formázást és az elrendezést, és hogyan mentsük el a végső prezentációt – mindezt egy .NET alkalmazáson belül.

1. Hozzon létre egy Microsoft PowerPoint bemutató példányt.
1. Adjon hozzá egy üres diát a bemutatóhoz.
1. Adjon hozzá egy 3D clustered column chart-ot, és férjen hozzá.
1. Hozzon létre egy új Microsoft Excel munkafüzet példányt, és töltse be a diagram adatokat.
1. Hozzon hozzá a diagram adat munkalaphoz az Excel munkafüzet példány használatával.
1. Állítsa be a diagram tartományt a munkalapon, és távolítsa el a 2. és 3. sorozatot a diagramról.
1. Módosítsa a diagram kategóriaadatait a diagram adat munkalapon.
1. Módosítsa az 1. sorozat adatait a diagram adat munkalapon.
1. Hozzáférjen a diagram címéhez, és állítsa be a betűtípusra vonatkozó tulajdonságokat.
1. Hozzáférjen a diagram értéktengelyéhez, és állítsa be a fő egységet, a mellékegységet, a legnagyobb és a legkisebb értéket.
1. Hozzáférjen a diagram mélységi (sorozati) tengelyéhez, és távolítsa el – ebben a példában csak egy sorozatot használnak.
1. Állítsa be a diagram forgatási szögeit az X és Y irányokban.
1. Mentse a bemutatót.
1. Zárja be a Microsoft Excel és PowerPoint példányokat.

```c#
EnsurePowerPointIsRunning(true, true);

// Példányosítsa a diát objektumként.
Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;

// Hozzáférés az első prezentációs diához.
objSlide = objPres.Slides[1];

// Válassza ki az első diát, és állítsa be annak elrendezését.
objSlide.Select();
objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutBlank;

// Alapértelmezett diagram hozzáadása a diához.
objSlide.Shapes.AddChart(Microsoft.Office.Core.XlChartType.xl3DColumn, 20, 30, 400, 300);

// A hozzáadott diagram elérése.
Microsoft.Office.Interop.PowerPoint.Chart ppChart = objSlide.Shapes[1].Chart;

// A diagram adatainak elérése.
Microsoft.Office.Interop.PowerPoint.ChartData chartData = ppChart.ChartData;

// Excel munkafüzet példány létrehozása a diagram adataival való munkához.
Microsoft.Office.Interop.Excel.Workbook dataWorkbook = (Microsoft.Office.Interop.Excel.Workbook)chartData.Workbook;

// A diagram adat munkalapjának elérése.
Microsoft.Office.Interop.Excel.Worksheet dataSheet = dataWorkbook.Worksheets[1];

// A diagram adat tartományának beállítása.
Microsoft.Office.Interop.Excel.Range tRange = dataSheet.Cells.get_Range("A1", "B5");

// A megadott tartomány alkalmazása a diagram adat táblázatára.
Microsoft.Office.Interop.Excel.ListObject tbl1 = dataSheet.ListObjects["Table1"];
tbl1.Resize(tRange);

// Kategóriák és a megfelelő sorozat adatok értékeinek beállítása.
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A2"))).FormulaR1C1 = "Bikes";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A3"))).FormulaR1C1 = "Accessories";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A4"))).FormulaR1C1 = "Repairs";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("A5"))).FormulaR1C1 = "Clothing";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B2"))).FormulaR1C1 = "1000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B3"))).FormulaR1C1 = "2500";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B4"))).FormulaR1C1 = "4000";
((Microsoft.Office.Interop.Excel.Range)(dataSheet.Cells.get_Range("B5"))).FormulaR1C1 = "3000";

// A diagram címének beállítása.
ppChart.ChartTitle.Font.Italic = true;
ppChart.ChartTitle.Text = "2007 Sales";
ppChart.ChartTitle.Font.Size = 18;
ppChart.ChartTitle.Font.Color = Color.Black.ToArgb();
ppChart.ChartTitle.Format.Line.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
ppChart.ChartTitle.Format.Line.ForeColor.RGB = Color.Black.ToArgb();

// A diagram értéktengelyének elérése.
Microsoft.Office.Interop.PowerPoint.Axis valaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlValue, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);

// Az tengely egységek értékeinek beállítása.
valaxis.MajorUnit = 2000.0F;
valaxis.MinorUnit = 1000.0F;
valaxis.MinimumScale = 0.0F;
valaxis.MaximumScale = 4000.0F;

// A diagram mélységi tengelyének elérése.
Microsoft.Office.Interop.PowerPoint.Axis Depthaxis = ppChart.Axes(Microsoft.Office.Interop.PowerPoint.XlAxisType.xlSeriesAxis, Microsoft.Office.Interop.PowerPoint.XlAxisGroup.xlPrimary);
Depthaxis.Delete();

// A diagram forgatásának beállítása.
ppChart.Rotation = 20;   // Y-érték
ppChart.Elevation = 15;  // X-érték
ppChart.RightAngleAxes = false;

// A prezentáció mentése PPTX fájlként.
objPres.SaveAs("VSTO_Sample_Chart.pptx", Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsDefault, MsoTriState.msoTrue);

// A munkafüzet és a prezentáció bezárása.
dataWorkbook.Application.Quit();
objPres.Application.Quit();
```

```c#
public static void EnsurePowerPointIsRunning(bool blnAddPresentation)
{
    EnsurePowerPointIsRunning(blnAddPresentation, false);
}

public static void EnsurePowerPointIsRunning()
{
    EnsurePowerPointIsRunning(false, false);
}

public static void EnsurePowerPointIsRunning(bool blnAddPresentation, bool blnAddSlide)
{
    string strName = null;

    // Próbálja meg elérni a Name tulajdonságot. Ha kivételt dob, indítson új PowerPoint példányt.
    try
    {
        strName = objPPT.Name;
    }
    catch (Exception ex)
    {
        StartPowerPoint();
    }

    // A blnAddPresentation azért van használva, hogy biztosítson egy betöltött prezentációt.
    if (blnAddPresentation == true)
    {
        try
        {
            strName = objPres.Name;
        }
        catch (Exception ex)
        {
            objPres = objPPT.Presentations.Add(MsoTriState.msoTrue);
        }
    }

    // A blnAddSlide azért van használva, hogy biztosítsa, hogy a prezentációban legyen legalább egy dia.
    if (blnAddSlide)
    {
        try
        {
            strName = objPres.Slides[1].Name;
        }
        catch (Exception ex)
        {
            Microsoft.Office.Interop.PowerPoint.Slide objSlide = null;
            Microsoft.Office.Interop.PowerPoint.CustomLayout objCustomLayout = null;
            objCustomLayout = objPres.SlideMaster.CustomLayouts[1];
            objSlide = objPres.Slides.AddSlide(1, objCustomLayout);
            objSlide.Layout = Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText;
            objCustomLayout = null;
            objSlide = null;
        }
    }
}
```

Az eredmény:

![A VSTO-val létrehozott diagram](chart-created-using-VSTO.png)

## **Aspose.Slides for .NET példa**

Az alábbi példa azt mutatja be, hogyan hozhatunk létre egy egyszerű diagramot egy PowerPoint bemutatóban az Aspose.Slides for .NET segítségével. A kód bemutatja, hogyan adhatunk hozzá egy **3D clustered column chart** táblázatot, hogyan töltsük fel mintaadatokkal, és hogyan testreszabjuk a megjelenését. Néhány sor kóddal dinamikusan generálhat diagramokat, és integrálhatja őket a bemutatóiba a Microsoft Office használata nélkül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát az első diára.
1. Adjon hozzá egy 3D clustered column chart-ot, és férjen hozzá.
1. Hozzáférjen a diagram adataihoz.
1. Távolítsa el a nem használt 2. és 3. sorozatokat.
1. Módosítsa a diagram kategóriáit a címkék frissítésével.
1. Frissítse az 1. sorozat értékeit.
1. Hozzáférjen a diagram címéhez, és állítsa be a betűtípus tulajdonságait.
1. Állítsa be a diagram értéktengelyét, beleértve a fő egységet, a mellékegységet, a maximumot és a minimumot.
1. Állítsa be a diagram forgatási szögeit az X és Y tengelyen.
1. Mentse a bemutatót PPTX formátumban.

```cs
// Üres prezentáció létrehozása.
using (Presentation presentation = new Presentation())
{
    // Az első dia elérése.
    ISlide slide = presentation.Slides[0];

    // Alapértelmezett diagram hozzáadása.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn3D, 20, 30, 400, 300);

    // Diagram adatainak lekérése.
    IChartData chartData = chart.ChartData;

    // A felesleges alapértelmezett sorozatok eltávolítása.
    chartData.Series.RemoveAt(1);
    chartData.Series.RemoveAt(1);

    // Diagram kategórianév módosítása.
    chartData.Categories[0].AsCell.Value = "Bikes";
    chartData.Categories[1].AsCell.Value = "Accessories";
    chartData.Categories[2].AsCell.Value = "Repairs";
    chartData.Categories[3].AsCell.Value = "Clothing";

    // A diagram adat munkalap indexének beállítása.
    int worksheetIndex = 0;

    // Diagram adat munkafüzet lekérése.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Diagram sorozat értékeinek módosítása.
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 1000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2500));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 4000));
    chartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 3000));

    // Diagram címének beállítása.
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("2007 Sales");
    IPortionFormat format = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0].PortionFormat;
    format.FontItalic = NullableBool.True;
    format.FontHeight = 18;
    format.FillFormat.FillType = FillType.Solid;
    format.FillFormat.SolidFillColor.Color = Color.Black;

    // Tengely beállításainak megadása.
    chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
    chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;

    chart.Axes.VerticalAxis.MaxValue = 4000.0F;
    chart.Axes.VerticalAxis.MinValue = 0.0F;
    chart.Axes.VerticalAxis.MajorUnit = 2000.0F;
    chart.Axes.VerticalAxis.MinorUnit = 1000.0F;
    chart.Axes.VerticalAxis.TickLabelPosition = TickLabelPositionType.NextTo;

    // Diagram forgatásának beállítása.
    chart.Rotation3D.RotationX = 15;
    chart.Rotation3D.RotationY = 20;

    // Prezentáció mentése PPTX fájlként.
    presentation.Save("Aspose_Sample_Chart.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az Aspose.Slides for .NET‑val létrehozott diagram](chart-created-using-aspose-slides.png)

## **GYIK**

**Létrehozhatok más típusú diagramokat, például kör-, vonal- vagy oszlopdiagramokat az Aspose.Slides segítségével?**

Igen. Az Aspose.Slides for .NET széles körű [diagramtípusokat](/slides/hu/net/create-chart/) támogat, beleértve a kördiagramokat, vonaldiagramokat, oszlopdiagramokat, szórási diagramokat, buborékdiagramokat és még sok mást. A kívánt diagramtípust a [ChartType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/charttype/) felsorolás használatával adhatja meg diagram hozzáadásakor.

**Alkalmazhatok egyéni stílusokat vagy témákat a diagramra?**

Igen. Teljesen testreszabhatja a diagram megjelenését, beleértve a színeket, betűtípusokat, kitöltéseket, körvonalakat, rácsvonalakat és az elrendezést. Azonban az Office témák pontos, PowerPoint‑ban látható alkalmazása manuális egyes stílusok beállítását igényli.

**Exportálhatom a diagramot képként külön a diától?**

Igen, az Aspose.Slides lehetővé teszi, hogy bármely alakzatot – beleértve a diagramokat – külön képként (például PNG, JPEG) exportáljon a diagram [shape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) `GetImage` metódusával.