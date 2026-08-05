---
title: Anpassa munkdiagram i presentationer med C++
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/cpp/doughnut-chart/
keywords:
- munkdiagram
- mitthål
- hålstorlek
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för C++, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur du arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrala hål och spara presentationen. Den fokuserar på metoden `set_DoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa den här diagramtypen i kod.

## **Ange mittgapet i ett munkdiagram**

För att ange storleken på hålet i ett munkdiagram. Följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
- Lägg till ett munkdiagram på bilden.
- Ange storleken på hålet i ett munkdiagram.
- Skriv presentationen till disk.

I exemplet nedan har vi angett storleken på hålet i ett munkdiagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **Vanliga frågor**

**Kan jag skapa ett flernivå-munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram—varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

**Stöds ett “exploderat” munkdiagram (separerade segment)?**

Ja. Det finns en Exploded Doughnut [diagramtyp](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/charttype/) och en explosions‑egenskap på datapunterna; du kan separera enskilda segment.

**Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/).