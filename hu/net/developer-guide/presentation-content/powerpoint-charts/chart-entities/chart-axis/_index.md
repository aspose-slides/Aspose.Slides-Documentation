---
title: Diagram tengelyek testreszabása prezentációkban .NET-ben
linktitle: Diagram tengely
type: docs
url: /hu/net/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságai
- maximális érték
- minimális érték
- tengely vonal
- dátumformátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for .NET-et diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk céljából."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan testreszabhatók a diagram tengelyei az Aspose.Slides-ban. Megmutatja, hogyan lehet lekérni a tényleges tengelyértékeket, cserélni az adatokat a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, módosítani a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni egy tengelycímkét, beállítani a tengely pozícióját, valamint megjeleníteni egy egységcímkét az érték tengelyen.

## **A függőleges tengely maximális értékeinek lekérése diagramokon**
Az Aspose.Slides for .NET lehetővé teszi a minimális és maximális értékek lekérését egy függőleges tengelyen. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal.
1. Szerezze meg a tényleges maximális értéket a tengelyen.
1. Szerezze meg a tényleges minimális értéket a tengelyen.
1. Szerezze meg a tényleges fő egységet a tengelyen.
1. Szerezze meg a tényleges alsegységet a tengelyen.
1. Szerezze meg a tényleges fő egység skáláját a tengelyen.
1. Szerezze meg a tényleges alsegység skáláját a tengelyen.

Ez a minta kód – a fenti lépések megvalósítása – megmutatja, hogyan lehet lekérni a szükséges értékeket C#-ban:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// A prezentáció mentése
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Az adatok cseréje a tengelyek között**
Az Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y-tengely) megjelenő adatok áthelyeződnek a vízszintes tengelyre (x-tengely) és fordítva.

Ez a C# kód megmutatja, hogyan hajtható végre az adatok cseréje a tengelyek között egy diagramon:

```c#
 // Létrehoz egy üres prezentációt
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// Sorok és oszlopok felcserélése
		   
	 // A prezentáció mentése
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Függőleges tengely letiltása vonaldiagramoknál**

Ez a C# kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramon:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramon:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Kategória tengely módosítása**

A **CategoryAxisType** tulajdonság használatával megadhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a C# kód demonstrálja a műveletet:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Dátumformátum beállítása a kategória tengely értékeihez**
Az Aspose.Slides for .NET lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A műveletet ez a C# kód mutatja be:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Forgatási szög beállítása egy diagramtengely címéhez**
Az Aspose.Slides for .NET lehetővé teszi a forgatási szög beállítását egy diagramtengely címéhez. Ez a C# kód szemlélteti a műveletet:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Tengelypozíció beállítása kategória vagy érték tengelyen**
Az Aspose.Slides for .NET lehetővé teszi a tengely pozíciójának beállítását egy kategória vagy érték tengelyen. Ez a C# kód megmutatja, hogyan hajtható végre a feladat:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Egységcímke megjelenítésének engedélyezése a diagram érték tengelyen**
Az Aspose.Slides for .NET lehetővé teszi, hogy egy diagramot úgy konfiguráljon, hogy egységcímkét jelenítsen meg a diagram érték tengelyén. Ez a C# kód bemutatja a műveletet:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely áthalad a másikon (tengelykereszteződés)?**

A tengelyek [crossing setting](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/axis/crosstype/) beállítást kínálnak: választhat, hogy a tengely nullánál, a maximális kategória/értéknél vagy egy adott numerikus értéknél keresse keresztezi. Ez hasznos az X-tengely felfelé vagy lefelé történő eltolásához vagy egy alapvonal kiemeléséhez.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest (mellett, kívül, belül)?**

Állítsa be a [label position](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/axis/majortickmark/) értékét "cross", "outside" vagy "inside"-ra. Ez befolyásolja az olvashatóságot és segít helyet megtakarítani, különösen kis diagramok esetén.