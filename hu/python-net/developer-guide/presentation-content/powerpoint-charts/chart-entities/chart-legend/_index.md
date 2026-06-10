---
title: Diagramlegendák testreszabása prezentációkban Python segítségével
linktitle: Diagramlegenda
type: docs
url: /hu/python-net/chart-legend/
keywords:
- diagramlegenda
- legenda pozíció
- betűméret
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Testreszabja a diagramlegendákat az Aspose.Slides for Python és .NET használatával, hogy optimalizálja a PowerPoint és OpenDocument prezentációkat a testreszabott legendaformázással."
---
## **Áttekintés**

Az Aspose.Slides for Python teljes irányítást biztosít a diagramlegendák felett, így az adatcímkék egyértelműek és bemutatóra kész állapotúak lehetnek. Megjelenítheti vagy elrejtheti a legendát, kiválaszthatja annak pozícióját a dián, és a felépítést úgy állíthatja be, hogy elkerülje a átfedést a rajzterülettel. Az API lehetővé teszi a szöveg és a jelölők formázását, a belső margók és a háttér finomhangolását, valamint a keretek és kitöltések formázását, hogy illeszkedjenek a témához. A fejlesztők egyes legendabejegyzéseket is elérhetnek, átnevezhetnek vagy szűrhetnek, biztosítva, hogy csak a legrelevánsabb sorozatok jelenjenek meg. Ezekkel a képességekkel diagramjai olvashatóak, következetesek maradnak, és összhangban állnak a bemutató tervezési szabványaival.

## **Legenda elhelyezése**

Az Aspose.Slides segítségével gyorsan szabályozhatja, hogy a diagramlegenda hol jelenik meg, és hogyan illeszkedik a dia elrendezéséhez. Ismerje meg, hogyan helyezze el pontosan a legendát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezzen hivatkozást a diára.  
1. Adjon hozzá egy diagramot a diához.  
1. Állítsa be a legenda tulajdonságait.  
1. Mentse a bemutatót PPTX fájlként.  

Az alábbi példában a diagramlegendának a pozícióját és méretét állítjuk be:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Hozzon létre egy példányt a Presentation osztályból.
with slides.Presentation() as presentation:

    # Szerezzen hivatkozást a diára.
    slide = presentation.slides[0]

    # Adjon hozzá egy csoportosított oszlopdiagramot a diához.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 300)

    # Állítsa be a legenda tulajdonságait.
    chart.legend.x = 80 / chart.width
    chart.legend.y = 20 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    # Mentse a bemutatót a lemezre.
    presentation.save("legend_positioning.pptx", slides.export.SaveFormat.PPTX)
```

## **A legenda betűméretének beállítása**

A diagramlegenda legyen olyan olvasható, mint az általa magyarázott adatok. Ez a szakasz bemutatja, hogyan állíthatja be a legenda betűméretét, hogy illeszkedjen a bemutató tipográfiájához és javítsa a hozzáférhetőséget.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.  
1. Hozzon létre egy diagramot.  
1. Állítsa be a betűméretet.  
1. Mentse a bemutatót a lemezre.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.legend.text_format.portion_format.font_height = 20

    presentation.save("font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Egy legendaelem betűméretének beállítása**

Az Aspose.Slides lehetővé teszi a diagramlegendák megjelenésének finomhangolását egyes bejegyzések formázásával. Az alábbi példa megmutatja, hogyan célozzon meg egy konkrét legendaelemet, és állítsa be annak tulajdonságait anélkül, hogy a többi legendát módosítaná.

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.  
1. Hozzon létre egy diagramot.  
1. Hozzon létre hivatkozást egy legendabejegyzésre.  
1. Állítsa be a bejegyzés tulajdonságait.  
1. Mentse a bemutatót a lemezre.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    text_format = chart.legend.entries[1].text_format

    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Engedélyezhetem a legendát úgy, hogy a diagram automatikusan helyet biztosítson számára a felülírás helyett?**  
Igen. Használja a nem‑átfedés módot ([overlay](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/legend/overlay/)=`false`); ebben az esetben a rajzterület zsugorodni fog a legenda befogadásához.

**Létrehozhatok több soros legenda címkéket?**  
Igen. A hosszú címkék automatikusan sortördülnek, ha a hely nem elegendő; kényszerített sortöréseket a sorozat nevében lévő újsor karakterekkel lehet megadni.

**Hogyan tehetem úgy, hogy a legenda kövesse a bemutató téma színsémáját?**  
Ne állítson be kifejezett színeket/kitöltéseket/betűtípusokat a legendához vagy a szövegéhez. Ezek ekkor öröklik a témát, és helyesen frissülnek, amikor a tervezés megváltozik.