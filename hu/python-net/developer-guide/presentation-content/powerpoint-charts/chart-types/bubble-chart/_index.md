---
title: Buborékdiagramok testreszabása prezentációkban Python segítségével
linktitle: Buborékdiagram
type: docs
url: /hu/python-net/bubble-chart/
keywords:
- buborékdiagram
- buborékméret
- méretezés
- méret ábrázolás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén hozzon létre és testreszabjon hatékony buborékdiagramokat PowerPointban és OpenDocumentben az Aspose.Slides for Python via .NET segítségével, hogy javítsa adatmegjelenítését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet buborékkárokat használni az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget fed le: a buborékméretek méretezését a `bubble_size_scale` tulajdonsággal, valamint a buborékméret‑értékek ábrázolásának szabályozását a `bubble_size_representation` tulajdonsággal.

A példák bemutatják, hogyan lehet buborékkárt létrehozni, a méretezést beállítani, és a buborékméret ábrázolását szélességre cserélni. A cikk egy rövid GyIK részt is tartalmaz, amely tisztázza a “Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítmény és a cél PowerPoint verzió függvényei, illetve elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelő motorjával.

## **Buborékdiagram Méretezése**
Az Aspose.Slides for Python via .NET támogatja a buborékdiagram méretezését. Az Aspose.Slides for Python via .NET‑ben hozzá lettek adva a **ChartSeries.bubble_size_scale** és **ChartSeriesGroup.bubble_size_scale** tulajdonságok. Az alábbi mintapélda látható.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Az Adatok Ábrázolása Buborékdiagram Méretekként**
A **bubble_size_representation** tulajdonságot hozzáadták a ChartSeries és ChartSeriesGroup osztályokhoz. A **bubble_size_representation** meghatározza, hogyan jelennek meg a buborékméret-értékek a buborékdiagramon. Lehetséges értékek: **BubbleSizeRepresentationType.AREA** és **BubbleSizeRepresentationType.WIDTH**. Ennek megfelelően a **BubbleSizeRepresentationType** felsorolt típus is hozzá lett adva, hogy meghatározza a lehetséges módokat az adatok buborékdiagram méretekként való ábrázolására. Az alábbiakban mintakód látható.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Támogatott-e a “buborékdiagram 3-D hatással”, és miben különbözik a szokásos változattól?**

Igen. Létezik egy külön diagramtípus, a “Bubble with 3‑D”. A buborékokra 3‑D stílust alkalmaz, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában vannak. A típus elérhető a [chart type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) felsorolásban.

**Van-e korlát a sorozatok és pontok számában egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátokat a teljesítmény és a cél PowerPoint verzió határozza meg. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékdiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszter/vektor formátumok esetén általános diagramgrafikai renderelési szabályok érvényesek (felbontás, anti‑aliasing), ezért nyomtatáshoz megfelelő DPI‑t válasszon.