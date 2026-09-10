---
title: Diagramlegendák testreszabása prezentációkban Python használatával
linktitle: Diagram legenda
type: docs
url: /hu/python-java/chart-legend/
keywords:
- diagramlegenda
- legenda pozíció
- betűméret
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Testreszabhatja a diagramlegendákat az Aspose.Slides for Python via Java segítségével, hogy a PowerPoint prezentációk a legendák egyedi formázásával optimalizálhatók legyenek."
---
## **Áttekintés**

Az Aspose.Slides lehetőségeket biztosít a diagramlegendák testreszabásához a PowerPoint prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy legendát, beállítani a teljes legendához a betűméretet, és formázást alkalmazni egy egyedi legendabejegyzésre.

A GYIK-ban továbbá több kapcsolódó viselkedést is tárgyal, többek között a nem átfedés mód használatát, amely lehetővé teszi, hogy a grafikon terület helyet biztosítson a legendának, a hosszú legendacímkék automatikus vagy sortöréses megtörését, valamint a legendaformázás öröklődését a prezentáció témájából, ha nincs megadva explicit szöveg- vagy kitöltésbeállítás.

## **Legenda elhelyezése**

A legenda tulajdonságainak beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Szerezze be a diára való hivatkozást.  
1. Adjon hozzá egy diagramot a diára.  
1. Állítsa be a legenda tulajdonságait.  
1. Mentse a prezentációt PPTX fájlként.

A következő példa beállítja egy diagramlegenda pozícióját és méretét.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Üres prezentáció létrehozása.
presentation = Presentation()
try:
    # Referenciát szerez a diára.
    slide = presentation.getSlides().get_Item(0)

    # Csoportos oszlopdiagram hozzáadása a diára.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # A legenda tulajdonságainak beállítása.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # A prezentáció mentése a lemezre.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A legenda betűméretének beállítása**

Az Aspose.Slides for Python via Java lehetővé teszi a legenda betűméretének beállítását. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Hozzon létre egy alapértelmezett diagramot.  
1. Állítsa be a betűméretet.  
1. Állítsa be a minimum tengelyértéket.  
1. Állítsa be a maximum tengelyértéket.  
1. Mentse a prezentációt a lemezre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Üres prezentáció létrehozása.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyedi legendabejegyzés betűméretének beállítása**

Az Aspose.Slides for Python via Java lehetővé teszi egyedi legendabejegyzések betűméretének beállítását. Kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Hozzon létre egy alapértelmezett diagramot.  
1. Szerezze meg egy legendabejegyzést.  
1. Állítsa be a betűméretet.  
1. Mentse a prezentációt a lemezre.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Üres prezentáció létrehozása.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Engedélyezhetem a legendát úgy, hogy a diagram automatikusan helyet biztosítson számára, ahelyett, hogy átfedne?**

Igen. Használja a [setOverlay](https://reference.aspose.com/slides/hu/python-java/aspose.slides/legend/#setOverlay) metódust `False` értékkel a nem átfedés mód engedélyezéséhez; ebben az esetben a grafikon terület összezsugorodik, hogy helyet biztosítson a legendának.

**Létrehozhatok több soros legenda címkéket?**

Igen. A hosszú címkék automatikusan sortörnek, ha a hely nem elegendő; kényszerített sortörések a sorozat nevében lévő új sor karakterekkel támogatottak.

**Hogyan biztosíthatom, hogy a legenda kövesse a prezentáció téma színsémáját?**

Ne állítson be explicit színeket, kitöltéseket vagy betűtípusokat a legendához vagy annak szövegéhez. Így azok a témából öröklődnek, és a tervezés változtatásakor megfelelően frissülnek.