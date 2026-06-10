---
title: Diagram jelmagyarázatok testreszabása prezentációkban .NET-ben
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/net/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Testreszabott diagram jelmagyarázatok az Aspose.Slides for .NET segítségével, hogy a PowerPoint prezentációk a jelmagyarázat formázásával optimalizálhatók legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetőségeket kínál a diagramok jelmagyarázatának testreszabására PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet pozicionálni és méretezni egy jelmagyarázatot, beállítani a teljes jelmagyarázat betűméretét, valamint formázni egy egyéni jelmagyarázat bejegyzést.

A GYIK-ban további kapcsolódó viselkedéseket is bemutat, többek között a nem‑átfedés mód használatát, hogy a diagramterület helyet biztosítson a jelmagyarázatnak, a hosszú jelmagyarázat‑címkék automatikus sortördelését vagy sorvégi töréseket, valamint azt, hogy a jelmagyarázat formázása a prezentáció témájától örököljön, ha nem kerülnek megadva explicit szöveg‑ és kitöltési beállítások.

## **Jelmagyarázat pozicionálása**
A jelmagyarázat tulajdonságainak beállításához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
- Szerezze meg a dia hivatkozását.
- Diagram hozzáadása a diára.
- A jelmagyarázat tulajdonságainak beállítása.
- Írja a prezentációt PPTX fájlként.

Az alább megadott példában beállítottuk a diagram jelmagyarázatának pozícióját és méretét.

```c#
// Hozzon létre egy példányt a Presentation osztályból
Presentation presentation = new Presentation();

// Get reference of the slide
ISlide slide = presentation.Slides[0];

// Add a clustered column chart on the slide
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Set Legend Properties
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

// Write presentation to disk
presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```



## **A jelmagyarázat betűméretének beállítása**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára a jelmagyarázat betűméretének beállítását. Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy `Presentation` példányt.
- Alapértelmezett diagram létrehozása.
- A betűméret beállítása.
- Minimális tengelyérték beállítása.
- Maximális tengelyérték beállítása.
- A prezentáció mentése lemezen.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```


## **Egyedi jelmagyarázat bejegyzés betűméretének beállítása**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára az egyedi jelmagyarázat‑bejegyzések betűméretének beállítását. Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy `Presentation` példányt.
- Alapértelmezett diagram létrehozása.
- Hozzáférés a jelmagyarázat bejegyzéséhez.
- A betűméret beállítása.
- Minimális tengelyérték beállítása.
- Maximális tengelyérték beállítása.
- A prezentáció mentése lemezen.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**Engedélyezhetem a jelmagyarázatot úgy, hogy a diagram automatikusan helyet biztosítson neki ahelyett, hogy átfedésben legyen?**

Igen. Használja a nem‑átfedés módot ([Overlay](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/legend/overlay/) = `false`); ebben az esetben a diagramterület összezsugorodik, hogy helyet biztosítson a jelmagyarázatnak.

**Készíthetek többsoros jelmagyarázat‑címkéket?**

Igen. A hosszú címkék automatikusan sortörnek, ha a hely nem elegendő; a sorok kényszerített megtörését a sorozat nevében található új sor karakterek támogatják.

**Hogyan tehetem úgy, hogy a jelmagyarázat a prezentáció témájának színsémáját kövesse?**

Ne állítson be explicit színeket/kitöltéseket/betűtípusokat a jelmagyarázat vagy annak szövege számára. Ezek ekkor a témából öröklődnek, és a tervezés módosulásakor helyesen frissülnek.