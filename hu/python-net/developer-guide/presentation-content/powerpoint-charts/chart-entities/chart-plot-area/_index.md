---
title: "A prezentáció diagramjainak plot területeinek testreszabása Pythonban"
linktitle: "Plot terület"
type: docs
url: /hu/python-net/chart-plot-area/
keywords:
- "diagram"
- "plot terület"
- "plot terület szélessége"
- "plot terület magassága"
- "plot terület mérete"
- "elrendezési mód"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Fedezze fel, hogyan testreszabhatja a diagram plot területeit PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Javítsa diái megjelenését könnyedén."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk a diagram plot területén az Aspose.Slides-ben. Elmagyarázza, hogyan lehet lekérni a terület tényleges pozícióját és méretét a diagramelrendezés validálásával, majd elolvasva az X, Y, szélesség és magasság értékeket.

Azt is bemutatja, hogyan lehet beállítani a plot terület elrendezési módját, amikor az elrendezés manuálisan van megadva, a `LayoutTargetType` használatával meghatározva, hogy a plot területet a belső régió vagy a külső régió, a tengelyekkel és tengelycímkékkel együtt számítják‑e.

## **A diagram plot terület szélességének és magasságának lekérése**
Az Aspose.Slides for Python via .NET egyszerű API‑t nyújt a .

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Érje el az első diát.  
3. Adjon hozzá diagramot az alapértelmezett adatokkal.  
4. Hívja meg az IChart.ValidateChartLayout() metódust a tényleges értékek lekérése előtt.  
5. Lekéri a diagram elem tényleges X helyzetét (bal), a diagram bal felső sarkához viszonyítva.  
6. Lekéri a diagram elem tényleges felső pozícióját a diagram bal felső sarkához viszonyítva.  
7. Lekéri a diagram elem tényleges szélességét.  
8. Lekéri a diagram elem tényleges magasságát.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Mentse a prezentációt diagrammal
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **A diagram plot terület elrendezési módjának beállítása**
Az Aspose.Slides for Python via .NET egy egyszerű API‑t biztosít a diagram plot terület elrendezési módjának beállításához. A **LayoutTargetType** tulajdonság hozzá lett adva a **ChartPlotArea** és **IChartPlotArea** osztályokhoz. Ha a plot terület elrendezését manuálisan definiálják, ez a tulajdonság megadja, hogy a plot területet a belső (a tengelyek és tengelycímkék nélkül) vagy a külső (tengelyekkel és tengelycímkékkel együtt) rész alapján kell‑e elrendezni. Két lehetséges érték van, amely a **LayoutTargetType** felsorolóban van definiálva.

- **LayoutTargetType.Inner** – azt határozza meg, hogy a plot terület mérete határozza meg a plot terület méretét, a jelölőket és tengelycímkéket nem tartalmazva.  
- **LayoutTargetType.Outer** – azt határozza meg, hogy a plot terület mérete határozza meg a plot terület, a jelölők és a tengelycímkék méretét.  

Az alábbiakban mintakód található.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Milyen egységekben vannak visszaadva a actual_x, actual_y, actual_width és actual_height értékek?**  
Pontban; 1 hüvelyk = 72 pont. Ezek az Aspose.Slides koordinátaegységek.

**Miben különbözik a Plot Area a Chart Area tartalma szempontjából?**  
A Plot Area a diagram adatábrázolási területe (sorozatok, rácsvonalak, trendvonalak stb.); a Chart Area magában foglalja a környező elemeket (cím, jelmagyarázat stb.). 3D diagramok esetén a Plot Area a falakat/alsót és a tengelyeket is tartalmazza.

**Hogyan értelmezzük a Plot Area X, Y, Width és Height értékeit, amikor az elrendezés manuális?**  
Ezek a diagram teljes méretének törtjelei (0–1); ebben a módban az automatikus pozicionálás le van tiltva, és a megadott törtek kerülnek felhasználásra.

**Miért változott a Plot Area pozíciója a jelmagyarázat hozzáadása/mozgatása után?**  
A jelmagyarázat a diagram területén, a Plot Area‑n kívül helyezkedik el, de befolyásolja az elrendezést és a rendelkezésre álló helyet, ezért a Plot Area eltolódhat, ha az automatikus pozicionálás aktív. (Ez a PowerPoint diagramok standard viselkedése.)