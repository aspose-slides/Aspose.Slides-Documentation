---
title: Bemutató Néző Létrehozása JavaScript-ben
linktitle: Bemutató Néző
type: docs
weight: 50
url: /hu/nodejs-java/presentation-viewer/
keywords:
- bemutató megtekintése
- bemutató néző
- bemutató néző létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Egy egyéni bemutató néző létrehozása JavaScript-ben az Aspose.Slides for Node.js segítségével. PowerPoint és OpenDocument fájlok egyszerű megjelenítése Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Aspose.Slides for Node.js via Java a diákat tartalmazó bemutatófájlok létrehozására szolgál. Ezek a diák megtekinthetők például a Microsoft PowerPointban. Néha azonban a fejlesztőknek szükségük lehet a diák képként történő megtekintésére a kedvenc képnézőjükkel, vagy saját bemutatónéző létrehozására. Ilyen esetekben az Aspose.Slides lehetővé teszi egyetlen dia képként való exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép generálása diából**

Az Aspose.Slides használatával SVG képet generálhat egy bemutatódiából, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diára mutató hivatkozást az indexe alapján.
1. Nyisson meg egy fájlfolyamot.
1. Mentse a diát SVG képként a fájlfolyamba.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Egyedi alakzatazonosítóval rendelkező SVG generálása**

Az Aspose.Slides használható egy [SVG](https://docs.fileformat.com/page-description-language/svg/) generálására egy diáról egy egyedi alakzatazonosítóval. Ehhez használja a `setId` metódust a [SvgShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/svgshape/) osztályból. A `CustomSvgShapeFormattingController` használható az alakzatazonosító beállításához.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **Dia bélyegkép létrehozása**

Az Aspose.Slides segít bélyegképek generálásában a diákhoz. A dia bélyegképének generálásához az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diára mutató hivatkozást az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét egy meghatározott méretarányban.
1. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Dia bélyegkép létrehozása felhasználó által meghatározott méretekkel**

Felhasználó által meghatározott méretekkel rendelkező dia bélyegkép létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diára mutató hivatkozást az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretekkel.
1. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Dia bélyegkép létrehozása előadói jegyzetekkel**

A dia előadói jegyzetekkel ellátott bélyegképének generálásához az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/renderingoptions/) osztályból.
1. Használja a `RenderingOptions.setSlidesLayoutOptions` metódust az előadói jegyzetek pozíciójának beállításához.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a diára mutató hivatkozást az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.
1. Mentse a bélyegképet a kívánt képadatformátumban.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Élő példa**

Próbálja ki az [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint megjelenítő](online-PowerPoint-viewer.png)

## **GYIK**

**Beágyazhatok-e egy bemutató nézőt egy Node.js webalkalmazásba?**

Igen. Az Aspose.Slides használható a szerveroldalon a diák képekké vagy HTML-é renderelésére, majd megjelenítésére a böngészőben. A navigációs és nagyítási funkciók JavaScript segítségével implementálhatók egy interaktív élményhez.

**Mi a legjobb módja a diák megjelenítésének egy egyedi nézőben?**

Az ajánlott megközelítés, hogy minden diát képként (például PNG vagy SVG) renderel, vagy HTML-é konvertál az Aspose.Slides segítségével, majd a kimenetet egy képkockában (asztali) vagy HTML konténerben (web) jeleníti meg.

**Hogyan kezeljem a sok diát tartalmazó nagy bemutatókat?**

Nagy bemutatók esetén vegye fontolóra a lusta betöltést vagy igény szerinti renderelést. Ez azt jelenti, hogy a dia tartalmát csak akkor generálja, amikor a felhasználó arra navigál, ezáltal csökkentve a memória- és betöltési időt.