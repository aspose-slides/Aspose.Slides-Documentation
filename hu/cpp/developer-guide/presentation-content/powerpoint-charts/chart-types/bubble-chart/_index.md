---
title: "Buborékkördiagramok testreszabása előadásokban a С++ használatával"
linktitle: "Buborékkördiagram"
type: docs
url: /hu/cpp/bubble-chart/
keywords:
- "buborékkördiagram"
- "buborékméret"
- "méret skálázása"
- "méret ábrázolása"
- "PowerPoint"
- "prezentáció"
- "С++"
- "Aspose.Slides"
description: "Könnyedén hozzon létre és testreszabjon hatékony buborékkördiagramokat a PowerPointban az Aspose.Slides for С++ segítségével, hogy javítsa adatmegjelenítését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni buborékkördiagramokkal az Aspose.Slides-ban. Két konkrét testreszabási lehetőséget fed le: a buborékméretek méretezését a `set_BubbleSizeScale` metódussal, valamint a buborékméret értékek megjelenítésének vezérlését a `set_BubbleSizeRepresentation` metódussal.

Az példák bemutatják, hogyan hozhatunk létre buborékkördiagramot, állíthatjuk be a méretezést, és cserélhetjük a buborékméret ábrázolását a szélesség használatára. A cikk egy rövid GyIK részt is tartalmaz, amely tisztázza a “Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a célnak megfelelő PowerPoint verziótól függenek, valamint elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelő motorja által.

## **Buborékkördiagram méretezése**
Aspose.Slides for C++ támogatja a buborékdiagram méretezését. Az Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** és **IChartSeriesGroup.BubbleSizeScale** tulajdonságok hozzá lettek adva. Az alábbi példakód látható. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Adatok megjelenítése buborékkördiagram méretekként**
Új **get_BubbleSizeRepresentation()** metódus került hozzáadásra a **IChartSeries** és **ChartSeries** osztályokhoz. A **BubbleSizeRepresentation** meghatározza, hogyan jelennek meg a buborékméret értékek a buborékkördiagramon. Lehetséges értékek: **BubbleSizeRepresentationType.Area** és **BubbleSizeRepresentationType.Width**. Ennek megfelelően a **BubbleSizeRepresentationType** felsorolt típus lett hozzáadva, hogy meghatározza a lehetséges módokat az adatok buborékkördiagram méretekként való ábrázolására. Az alábbi mintakód látható.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **GYIK**

**Támogatott a „buborékkördiagram 3‑D hatással”, és miben különbözik egy szokásos diagramtól?**

Igen. Van egy külön diagramtípus, a “Bubble with 3-D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X‑Y‑S (méret) formában maradnak. A típus a [chart type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolásban érhető el.

**Van korlátozás a sorozatok és pontok számában egy buborékkördiagramon?**

Az API szintjén nincs szigorú korlát; a korlátozások a teljesítménytől és a célnak megfelelő PowerPoint verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékkördiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszter/vektor formátumok esetén az általános diagramgrafika renderelési szabályok érvényesek (felbontás, élsimítás), ezért nyomtatáshoz válasszon megfelelő DPI‑t.