---
title: Anpassa munkdiagram i presentationer med Python via Java
linktitle: Munkdiagram
type: docs
weight: 30
url: /sv/python-java/doughnut-chart/
keywords:
- munkdiagram
- mittengap
- hålstorlek
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck hur du skapar och anpassar munkdiagram i Aspose.Slides för Python via Java, med stöd för PowerPoint-format för dynamiska presentationer."
---
## **Översikt**

Den här artikeln visar hur man arbetar med ett munkdiagram i Aspose.Slides genom att lägga till diagrammet på en bild, ange storleken på dess centrala hål och spara presentationen. Den fokuserar på metoden [setDoughnutHoleSize](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) och demonstrerar de grundläggande stegen som krävs för att anpassa den här diagramtypen i kod.

Den innehåller också en kort FAQ som täcker relaterade munkdiagram‑scenarier, såsom att använda flera serier för att skapa flera ringar, arbeta med exploderade munkdiagram och exportera ett diagram som en rasterbild eller SVG.

## **Ange det centrala gapet i ett munkdiagram**

{{% alert color="info" title="Note" %}}
Aspose.Slides för Python via Java stöder att ange storleken på hålet i ett munkdiagram. Denna sektion demonstrerar hur man anger hålstorleken med ett exempel.
{{% /alert %}}

För att ange storleken på hålet i ett munkdiagram, följ dessa steg:

1. Skapa ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) objekt.  
2. Lägg till ett munkdiagram på bilden.  
3. Ange storleken på hålet i munkdiagrammet.  
4. Spara presentationen till disk.

Följande exempel anger storleken på hålet i ett munkdiagram.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Skriv presentationen till disk.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag skapa ett flernivå‑munkdiagram med flera ringar?**

Ja. Lägg till flera serier i ett enda munkdiagram – varje serie blir en separat ring. Ringordningen bestäms av ordningen på serierna i samlingen.

**Stöds ett "exploderat" munkdiagram (separerade sektorer)?**

Ja. Det finns en Exploded Doughnut [chart type](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/) och en explosions‑egenskap på datapunkter; du kan separera enskilda sektorer.

**Hur kan jag få en bild av ett munkdiagram (PNG/SVG) för en rapport?**

Ett diagram är en [shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/); du kan rendera det till en [raster image](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#getImage) eller exportera diagrammet till en SVG‑bild.