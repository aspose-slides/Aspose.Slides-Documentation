---
title: Gyűrűdiagramok testreszabása prezentációkban Python via Java használatával
linktitle: Gyűrűdiagram
type: docs
weight: 30
url: /hu/python-java/doughnut-chart/
keywords:
- gyűrűdiagram
- középső hézag
- lyuk mérete
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat gyűrűdiagramokat az Aspose.Slides for Python via Java segítségével, amelyek támogatják a PowerPoint formátumokat dinamikus prezentációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni egy gyűrűdiagrammal az Aspose.Slides-ben úgy, hogy a diagramot egy diára helyezzük, beállítjuk a középső lyuk méretét, és elmentjük a prezentációt. A [setDoughnutHoleSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) metódusra összpontosít, és bemutatja a kódon belüli diagramtestreszabáshoz szükséges alapvető lépéseket.

A cikk rövid GYIK-ot is tartalmaz, amely a gyűrűdiagrammal kapcsolatos helyzeteket tárgyalja, például több sorozat használatát több gyűrű létrehozásához, a szétrobbanó (exploded) gyűrűdiagramok kezelését, valamint a diagram raszteres kép vagy SVG formátumba exportálását.

## **A központi hézag megadása egy gyűrűdiagramon**

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides for Python via Java támogatja a gyűrűdiagram lyuk méretének megadását. Ez a szakasz bemutatja, hogyan adhatjuk meg a lyuk méretét egy példával.
{{% /alert %}}

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumot.  
2. Adjon egy gyűrűdiagramot a diára.  
3. Adja meg a lyuk méretét a gyűrűdiagramon.  
4. Írja ki a prezentációt a lemezre.  

Az alábbi példa beállítja a lyuk méretét egy gyűrűdiagramon.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Mentse a prezentációt lemezre.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Létrehozhatok több szintű gyűrűdiagramot több gyűrűvel?**

Igen. Több sorozatot adhat egyetlen gyűrűdiagramhoz – minden sorozat egy külön gyűrűvé válik. A gyűrűk sorrendje a sorozatok gyűjteményben való elhelyezkedésétől függ.

**Támogatott a „szétrobbanó” gyűrű (szétválasztott szeletek)?**

Igen. Létezik egy Exploded Doughnut [chart type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) és egy robbanási tulajdonság az adatpontokon; egyes szeleteket szétválaszthat.

**Hogyan kaphatok képet egy gyűrűdiagramról (PNG/SVG) egy jelentéshez?**

A diagram egy [shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/); renderelhető egy [raster image](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) vagy exportálható SVG képként.