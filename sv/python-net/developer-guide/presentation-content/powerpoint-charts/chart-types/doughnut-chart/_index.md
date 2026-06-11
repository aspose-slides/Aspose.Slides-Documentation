---
title: Anpassa munkdiagram i presentationer med Python
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/python-net/doughnut-chart/
keywords:
- munkdiagram
- centrumgap
- hålstorlek
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för Python via .NET, med stöd för PowerPoint- och OpenDocument-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrala hål och spara presentationen. Den fokuserar på inställningen `doughnut_hole_size` och demonstrerar de grundläggande stegen som krävs för att anpassa denna diagramtyp i kod.

Den innehåller också en kort FAQ som täcker relaterade munkdiagramsscenarier, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som en rasterbild eller SVG.

## **Ange centrumgap i munkdiagram**
För att ange storleken på hålet i ett munkdiagram. Följ stegen nedan:

- Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/).
- Lägg till ett munkdiagram på bilden.
- Ange storleken på hålet i ett munkdiagram.
- Skriv presentationen till disk.

I exemplet nedan har vi angett storleken på hålet i ett munkdiagram.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Skapa en instans av Presentation-klassen
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Spara presentationen till disk
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan jag skapa ett flernivå‑munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram—varje serie blir en separat ring. Ringordningen bestäms av serienas ordning i samlingen.

**Stöds ett "exploderat" munkdiagram (separerade bitar)?**

Ja. Det finns en Exploded Doughnut [chart type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/) och en explosions‑egenskap på datapunkter; du kan separera enskilda bitar.

**Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en form; du kan rendera det till en [rasterbild](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/get_image/) eller exportera diagrammet till en [SVG‑bild](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/write_as_svg/).