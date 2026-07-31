---
title: Buborékdiagramok testreszabása prezentációkban C++ használatával
linktitle: Buborékdiagram
type: docs
url: /hu/cpp/bubble-chart/
keywords:
- buborékdiagram
- buborék méret
- méret skálázás
- méret ábrázolás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Készítsen és testreszabjon hatékony buborékdiagramokat PowerPointban az Aspose.Slides for C++ segítségével, hogy egyszerűen javítsa adatmegjelenítését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet buborékdiagramokkal dolgozni az Aspose.Slides-ben. Két konkrét testreszabási lehetőséget fed le: a buborékméretek méretezését a `set_BubbleSizeScale` metódus segítségével, valamint a buborékméret-értékek ábrázolásának vezérlését a `set_BubbleSizeRepresentation` metódus által.  

Az példák bemutatják, hogyan hozhatunk létre egy buborékdiagramot, hogyan állíthatjuk be a méretezést, és hogyan válthatjuk át a buborékméret ábrázolását szélesség használatára. A cikk egy rövid GYIK szekciót is tartalmaz, amely tisztázza a “Bubble with 3-D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a cél PowerPoint verziótól függenek, valamint elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelő motorjával.

## **Buborékdiagram Méret Méretezése**
Az Aspose.Slides for C++ támogatja a buborékdiagram méretének méretezését. Az Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** és **IChartSeriesGroup.BubbleSizeScale** tulajdonságok hozzá lettek adva. Az alábbi minta példa szerepel. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Adatok Ábrázolása Buborékdiagram Méretekként**
Új **get_BubbleSizeRepresentation()** metódus került hozzáadásra a **IChartSeries** és **ChartSeries** osztályokhoz. A **BubbleSizeRepresentation** megadja, hogyan jelennek meg a buborékméret-értékek a buborékdiagramon. Lehetséges értékek: **BubbleSizeRepresentationType.Area** és **BubbleSizeRepresentationType.Width**. Ennek megfelelően a **BubbleSizeRepresentationType** enum is hozzá lett adva, hogy meghatározza a lehetséges módokat az adatok buborékdiagramméretekként való ábrázolására. Az alábbiakban minta kód található.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **GYIK**

**Támogatott-e a "buborékdiagram 3-D hatással", és miben különbözik egy szokásos diagramtól?**

Igen. Van egy külön diagramtípus, a "Bubble with 3-D". 3-D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra is X-Y-S (méret) formában maradnak. A típus elérhető a [chart type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) enumerációban.

**Van korlátozás a sorozatok és pontok számában egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátozások a teljesítménytől és a cél PowerPoint verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az export a buborékdiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raster/vektor formátumok esetén általános diagramgrafika renderelési szabályok érvényesek (felbontás, anti-aliasing), ezért nyomtatáshoz megfelelő DPI-t válasszon.