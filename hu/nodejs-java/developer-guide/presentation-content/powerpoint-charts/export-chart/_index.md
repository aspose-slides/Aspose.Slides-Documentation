---
title: Prezentáció diagramjainak exportálása JavaScript-ben
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/nodejs-java/export-chart/
keywords:
- diagram
- diagram képbe
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációk diagramjait az Aspose.Slides for Node.js via Java segítségével, PPT és PPTX formátumokat támogatva, és egyszerűsítheti a jelentéskészítést bármilyen munkafolyamatba."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan lehet a diagramról képet szerezni és menteni, ami akkor hasznos, ha a diagram ábráit újra fel kell használni a PowerPoint bemutatón kívül.

## **Diagramkép lekérése**
Az Aspose.Slides for Node.js via Java támogatja egy adott diagram képének kinyerését. Az alábbi példa bemutatásra kerül.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Exportálhatok egy diagramot vektoros (SVG) formátumban a raszteres kép helyett?**

Igen. A diagram egy alakzat, és a tartalma SVG-ként menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/writeassvg/) segítségével.

**Hogyan állíthatom be a exportált diagram pontos méretét pixelben?**

Használja a képmegjelenítési felülterheléseket, amelyek lehetővé teszik a méret vagy a méretezés megadását – a könyvtár támogatja az objektumok megjelenítését a megadott méretekkel/méretezéssel.

**Mit tegyek, ha a címkék és a jelmagyarázat betűtípusai helytelenül jelennek meg exportálás után?**

[Töltse be a szükséges betűtípusokat](/slides/hu/nodejs-java/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Az exportálás figyelembe veszi a PowerPoint téma, stílusok és effektusok beállításait?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túl elérhető renderelési/exportálási lehetőségek?**

Tekintse meg az [API](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/)/[dokumentációt](/slides/hu/nodejs-java/convert-powerpoint/) a kimeneti célokhoz ([PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállításokat.