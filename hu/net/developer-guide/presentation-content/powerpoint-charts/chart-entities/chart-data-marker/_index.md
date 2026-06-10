---
title: Diagram adatjelölők kezelése bemutatókban .NET-ben
linktitle: Adatjelölő
type: docs
url: /hu/net/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltési típus
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diagram adatjelölőket az Aspose.Slides for .NET-ben, növelve a bemutató hatását a PPT és PPTX formátumokban egyértelmű C# kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagram adatjelölőkkel az Aspose.Slides-ban. Megmutatja, hogyan hozhatunk létre diagramot, érhetünk el egy sorozatot és annak adatpontjait, alkalmazhatunk képes kitöltést a jelölőkre adatpont szinten, állíthatjuk a jelölő méretét, és menthetjük a frissített bemutatót. Megjegyzi azt is, hogy az alapértelmezett jelölőformák a `MarkerStyleType` felsorolásban érhetők el, és a jelölő megjelenése megmarad a diagramok raszteres formátumokra vagy SVG-re exportálásakor.

## **Diagram jelölőbeállítások megadása**
A jelölőket egy adott sorozaton belüli diagram adatpontokra lehet beállítani. A diagram jelölőbeállítások meghatározásához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályt.
- Alapértelmezett diagram létrehozása.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Új adatpont hozzáadása.
- A bemutató kiírása a lemezre.

Az alább bemutatott példában a diagram jelölőbeállításokat adatpont szinten állítottuk be.

```c#
// Hozzon létre egy példányt a Presentation osztályból
using Presentation presentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Alapértelmezett diagram létrehozása
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 0, 0, 400, 400);

// Az alapértelmezett diagram adatlap indexének lekérése
int defaultWorksheetIndex = 0;

// A diagram adatlap lekérése
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

// Demó sorozat törlése
chart.ChartData.Series.Clear();

// Új sorozat hozzáadása
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);

// Kép beállítása
using IImage image1 = Images.FromFile("aspose-logo.jpg");
IPPImage imgx1 = presentation.Images.AddImage(image1);

// Kép beállítása
using IImage image2 = Images.FromFile("Tulips.jpg");
IPPImage imgx2 = presentation.Images.AddImage(image2);

// Az első diagram sorozat kivétele
IChartSeries series = chart.ChartData.Series[0];

// Új pont hozzáadása (1:3) ott.
IChartDataPoint point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, (double)2.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, (double)3.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx1;

point = series.DataPoints.AddDataPointForLineSeries(fact.GetCell(defaultWorksheetIndex, 4, 1, (double)4.5));
point.Marker.Format.Fill.FillType = FillType.Picture;
point.Marker.Format.Fill.PictureFillFormat.Picture.Image = imgx2;

// A diagram sorozat jelölőjének módosítása
series.Marker.Size = 15;

// Bemutató mentése a lemezre
presentation.Save("MarkOptions_out.pptx", SaveFormat.Pptx);
```

## **GYIK**

**Milyen jelölőformák érhetők el alapból?**

Az alapértelmezett formák (kör, négyzet, rombusz, háromszög stb.) elérhetők; a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/markerstyletype/) felsorolásban van definiálva. Ha nem szabványos formára van szüksége, használjon képes kitöltésű jelölőt a saját vizuális megjelenés szimulálásához.

**Megmaradnak a jelölők, ha a diagramot képre vagy SVG-re exportálják?**

Igen. Diagramok raszteres formátumokra [raster formats](/slides/hu/net/convert-powerpoint-to-png/) történő renderelésekor vagy a [shapes as SVG](/slides/hu/net/render-a-slide-as-an-svg-image/) mentésekor a jelölők megőrzik megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.