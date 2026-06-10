---
title: Prezentáció diagramok exportálása Pythonban
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/python-net/export-chart/
keywords:
- diagram
- diagram képpé alakítása
- diagram képként
- diagramkép kinyerése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhat prezentációs diagramokat az Aspose.Slides for Python via .NET segítségével, PPT, PPTX és ODP formátumok támogatásával, és egyszerűsítse a jelentéskészítést bármely munkafolyamatba."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan nyerhet képet egy diagramból, és hogyan mentheti el, ami akkor hasznos, ha a diagram vizuális elemeit a PowerPoint bemutatón kívül szeretné felhasználni.

## **Diagramkép lekérése**
Az Aspose.Slides for Python via .NET támogatja egy adott diagram képének kinyerését. Az alábbi példakód látható.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **GYIK**

**Exportálhatok diagramot vektorként (SVG) a raszteres kép helyett?**

Igen. A diagram egy alakzat, és tartalma SVG‑ként menthető a [shape-to-SVG saving method](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/write_as_svg/).

**Hogyan állíthatom be az exportált diagram pontos méretét pixelben?**

Használja a képrétegző függvény túlterheléseit, amelyek lehetővé teszik a méret vagy a méretezés megadását – a könyvtár támogatja az objektumok adott mérettel/méretezéssel történő megjelenítését.

**Mit tegyek, ha a címkékben és a jelmagyarázatban lévő betűtípusok hibásan jelennek meg az export után?**

[Töltse be a szükséges betűtípusokat](/slides/hu/python-net/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Az export tiszteletben tartja a PowerPoint sablont, stílusokat és hatásokat?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, hatások), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túlmenő renderelési/exportálási lehetőségek?**

Tekintse meg az export szekciót az [API](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/)/[dokumentáció](/slides/hu/python-net/convert-powerpoint/) oldalán a kimeneti célokért ([PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-net/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállításokért.