---
title: Prezentációs néző létrehozása Java-ban
linktitle: Prezentációs néző
type: docs
weight: 50
url: /hu/java/presentation-viewer/
keywords:
- prezentáció megtekintése
- prezentációs néző
- prezentációs néző létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Egy egyedi prezentációs néző létrehozása Java-ban az Aspose.Slides használatával. Könnyedén megjelenítheti a PowerPoint és OpenDocument fájlokat a Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Az Aspose.Slides for Java-t prezentációs fájlok diák létrehozására használják. Ezek a diák megtekinthetők például a Microsoft PowerPoint‑ban való megnyitással. Néha azonban a fejlesztőknek szükségük lehet a diák képként történő megtekintésére a kedvenc képnézegetőjükben, vagy saját prezentációs nézőt készíteni. Ilyen esetekben az Aspose.Slides lehetővé teszi egy egyedi dia exportálását képként. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép generálása diáról**

Az Aspose.Slides segítségével SVG képet generálni egy prezentáció diákról, kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia hivatkozását a indexe alapján.  
3. Nyisson meg egy fájlfolyamot.  
4. Mentse el a diát SVG képként a fájlfolyamba.  

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Egyéni alakzat-azonosítóval rendelkező SVG generálása**

Aspose.Slides használható egy [SVG](https://docs.fileformat.com/page-description-language/svg/) generálására egy egyéni alakzat-azonosítóval rendelkező diáról. Ehhez használja az `setId` metódust a [ISvgShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isvgshape/)‑ból. A `CustomSvgShapeFormattingController` használható az alakzat azonosítójának beállításához.  

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Dia bélyegkép létrehozása**

Aspose.Slides segít a diáknak bélyegkép képeket generálni. A dia bélyegképének generálásához az Aspose.Slides használatával, kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia hivatkozását a indexe alapján.  
3. Szerezze meg a hivatkozott dia bélyegképét egy meghatározott méretarányban.  
4. Mentse el a bélyegképet a kívánt képformátumban.  

```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Dia bélyegkép létrehozása felhasználó által meghatározott méretekkel**

Dia bélyegkép kép létrehozásához felhasználó által meghatározott méretekkel, kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia hivatkozását a indexe alapján.  
3. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretekkel.  
4. Mentse el a bélyegképet a kívánt képformátumban.  

```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Dia bélyegkép létrehozása előadói jegyzetekkel**

A dia bélyegképének generálásához előadói jegyzetekkel az Aspose.Slides használatával, kérjük, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/renderingoptions/) osztályból.  
2. Használja a `RenderingOptions.setSlidesLayoutOptions` metódust az előadói jegyzetek pozíciójának beállításához.  
3. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.  
4. Szerezze meg a dia hivatkozását a indexe alapján.  
5. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.  
6. Mentse el a bélyegképet a kívánt képformátumban.  

```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **GYIK**

**Beágyazhatok-e egy prezentációs nézőt webalkalmazásba?**

Igen. Az Aspose.Slides-t használhatja a szerver oldalon a diák képekké vagy HTML‑é konvertálására, majd megjelenítheti őket a böngészőben. A navigációs és nagyítós funkciók JavaScript‑kel megvalósíthatók egy interaktív élményért.

**Mi a legjobb módja a diák megjelenítésének egy egyéni nézőben?**

A javasolt megközelítés, hogy minden diát képként (például PNG vagy SVG) renderel, vagy HTML‑re konvertálja az Aspose.Slides segítségével, majd a kimenetet egy képkocka (asztali) vagy HTML‑konténer (webes) belsejében jeleníti meg.

**Hogyan kezelem a sok diát tartalmazó nagy prezentációkat?**

Nagy prezentációk esetén fontolja meg a lusta betöltést vagy igény szerinti renderelést. Ez azt jelenti, hogy egy dia tartalma csak akkor kerül generálásra, amikor a felhasználó rá navigál, ezáltal csökkentve a memória- és betöltési időt.