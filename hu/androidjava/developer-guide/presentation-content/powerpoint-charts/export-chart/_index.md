---
title: Diagramok exportálása prezentációkból Androidon
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/androidjava/export-chart/
keywords:
- diagram
- diagram képbe
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhatja a prezentációs diagramokat az Aspose.Slides for Android via Java segítségével, támogatva a PPT és PPTX formátumokat, és egyszerűsítse a jelentéstételt bármely munkafolyamatba."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a bemutatóból képként exportálja. Ez a cikk bemutatja, hogyan lehet képet kapni egy diagramról és menteni azt, ami akkor hasznos, ha a diagram vizuális elemeit a PowerPoint bemutatón kívül szeretné újra felhasználni.

Az alapvető képexportálási munkameneten túl a cikk a gyakori exportálással kapcsolatos kérdésekre is válaszol, többek között a diagram tartalmának SVG-be mentésére, a kimeneti méret vezérlésére a renderelési beállítások segítségével, a betűkészletek betöltésére a címkék és a jelmagyarázat megjelenésének megőrzése érdekében, valamint a eredeti bemutató formázásának (témák, stílusok, kitöltések és effektusok) megtartására a renderelés során.

## **Diagramkép lekérése**
Az Aspose.Slides for Android via Java támogatja a konkrét diagram képként történő kinyerését. Az alábbi példakód bemutatja.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Exportálhatok egy diagramot vektorként (SVG) ahelyett, hogy raszterképet kapnék?**

Igen. A diagram egy alakzat, és tartalma SVG‑ként is menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) segítségével.

**Hogyan állíthatom be a exportált diagram pontos pixelméretét?**

Használja a képrenderelés túlterheléseit, amelyek lehetővé teszik a méret vagy a méretarány megadását – a könyvtár támogatja az objektumok megadott méretekkel/skálával történő renderelését.

**Mit tehetek, ha a címkék és a jelmagyarázat betűtípusa helytelenül jelenik meg exportálás után?**

[Töltsük be a szükséges betűtípusokat](/slides/hu/androidjava/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Az exportálás tiszteletben tartja a PowerPoint téma, stílusok és effektusok beállításait?**

Igen. Az Aspose.Slides renderelője követi a bemutató formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túlmutató renderelési/exportálási lehetőségek?**

Lásd az [API](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/)/[dokumentációt](/slides/hu/androidjava/convert-powerpoint/) a kimeneti célpontokhoz ([PDF](/slides/hu/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/hu/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/hu/androidjava/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállítások tekintetében.