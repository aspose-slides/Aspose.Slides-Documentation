---
title: Prezentációs diagramok exportálása Java-ban
linktitle: Diagram exportálása
type: docs
weight: 90
url: /hu/java/export-chart/
keywords:
- diagram
- diagram képpé
- diagram képként
- diagramkép kinyerése
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan exportálhat prezentációs diagramokat az Aspose.Slides for Java segítségével, PPT és PPTX formátumok támogatásával, és egyszerűsítheti a jelentéskészítést bármely munkafolyamatban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy diagramot a prezentációból képként exportálja. Ez a cikk bemutatja, hogyan lehet a diagramról képet előállítani és menteni, ami akkor hasznos, ha a diagram ábrákat a PowerPoint-prezentáción kívül szeretné újra felhasználni.

Az alapvető képexport munkafolyamat mellett a cikk a gyakori exporttal kapcsolatos kérdésekre is választ ad, többek között a diagram tartalmának SVG‑ként mentésére, a kimeneti méret szabályozására a megjelenítési beállításokkal, betűtípusok betöltésére a címkék és a jelmagyarázat megjelenésének megőrzéséhez, valamint az eredeti prezentáció formázásának – témák, stílusok, kitöltések és effektusok – megtartására a renderelés során.

## **Diagramkép lekérése**
Az Aspose.Slides for Java támogatja egy adott diagram képként történő kinyerését. Az alábbi példa bemutatásra kerül.

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

**Exportálhatok egy diagramot vektorként (SVG) a raszteres kép helyett?**  
Igen. A diagram egy alakzat, és a tartalma SVG‑ként menthető a [shape-to-SVG mentési módszer](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Hogyan állíthatom be a exportált diagram pontos méretét pixelben?**  
Használja a képrenderelés felülterheléseit, amelyek lehetővé teszik a méret vagy a méretezés megadását – a könyvtár támogatja az objektumok megadott mérettel vagy méretezéssel történő renderelését.

**Mit tegyek, ha a címkékben és a jelmagyarázatban használt betűtípusok hibásan jelennek meg az export után?**  
[Töltsön be a szükséges betűtípusokat](/slides/hu/java/custom-font/) a [FontsLoader](https://reference.aspose.com/slides/hu/java/com.aspose.slides/fontsloader/) segítségével, hogy a diagram renderelése megőrizze a metrikákat és a szöveg megjelenését.

**Tiszteletben tartja-e az export a PowerPoint téma, stílusok és effektusok beállításait?**  
Igen. Az Aspose.Slides renderelője követi a prezentáció formázását (témák, stílusok, kitöltések, effektusok), így a diagram megjelenése megmarad.

**Hol találhatók a diagramképeken túl elérhető renderelési/exportálási lehetőségek?**  
Tekintse meg az [API](https://reference.aspose.com/slides/hu/java/com.aspose.slides/)/[dokumentációt](/slides/hu/java/convert-powerpoint/) a kimeneti célokhoz ([PDF](/slides/hu/java/convert-powerpoint-to-pdf/), [SVG](/slides/hu/java/render-a-slide-as-an-svg-image/), [XPS](/slides/hu/java/convert-powerpoint-to-xps/), [HTML](/slides/hu/java/convert-powerpoint-to-html/), stb.) és a kapcsolódó renderelési beállítások.