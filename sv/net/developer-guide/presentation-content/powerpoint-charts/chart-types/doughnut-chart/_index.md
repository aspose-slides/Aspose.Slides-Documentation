---
title: Anpassa munkdiagram i presentationer i .NET
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/net/doughnut-chart/
keywords:
- munkdiagram
- centrumgap
- hålstorlek
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för .NET, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Denna artikel visar hur man arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrumhål och spara presentationen. Den fokuserar på inställningen `DoughnutHoleSize` och demonstrerar de grundläggande stegen som krävs för att anpassa denna diagramtyp i kod.

Den innehåller också en kort FAQ som täcker relaterade scenarier för munkdiagram, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som en rasterbild eller SVG.

## **Ange centrumhålet i ett munkdiagram**
För att ange storleken på hålet i ett munkdiagram. Följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
- Lägg till ett munkdiagram på bilden.
- Ange storleken på hålet i ett munkdiagram.
- Skriv presentationen till disk.

I exemplet nedan har vi angivit storleken på hålet i ett munkdiagram.

```c#
// Skapa en instans av Presentation-klassen
Presentation presentation = new Presentation();

IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

// Skriv presentation till disk
presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **Vanliga frågor**

**Kan jag skapa ett flernivå-munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram—varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

**Stöds ett "exploderat" munkdiagram (separerade skivor)?**

Ja. Det finns en Exploderad Munk [chart type](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/charttype/) och en explosion‑egenskap på datapunkter; du kan separera enskilda skivor.

**Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/).