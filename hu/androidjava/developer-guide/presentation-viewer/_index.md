---
title: Prezentáció megjelenítő létrehozása Androidon
linktitle: Prezentáció megjelenítő
type: docs
weight: 50
url: /hu/androidjava/presentation-viewer/
keywords:
- prezentáció megtekintése
- prezentáció megjelenítő
- prezentáció megjelenítő létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Egy egyéni prezentáció megjelenítőt hozhat létre Java-ban az Aspose.Slides for Android használatával. Könnyedén megjelenítheti a PowerPoint és OpenDocument fájlokat a Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Az Aspose.Slides for Android via Java a diavetítési fájlok létrehozására szolgál diák segítségével. Ezek a diák megtekinthetők például a Microsoft PowerPoint programban történő megnyitással. Néha azonban a fejlesztőknek szükségük lehet a diák képként való megtekintésére a kedvenc képmegjelenítőjükben, vagy saját prezentációs megjelenítő létrehozására. Ilyen esetekben az Aspose.Slides lehetővé teszi egy adott dia képként történő exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép létrehozása diából**

Az Aspose.Slides segítségével egy prezentációs diából SVG képet előállításhoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezze be a dia hivatkozását a megfelelő index alapján.  
1. Nyisson meg egy fájlfolyamot.  
1. Mentse a diát SVG képként a fájlfolyamba.

```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **Egyedi alakzati azonosítóval ellátott SVG létrehozása**

Az Aspose.Slides segítségével egy diából egyedi alakzati azonosítóval rendelkező [SVG](https://docs.fileformat.com/page-description-language/svg/) generálható. Ehhez használja az `setId` metódust a [ISvgShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isvgshape/) osztályból. A `CustomSvgShapeFormattingController` használható az alakzat azonosítójának beállításához.

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
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController
{
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController()
    {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex)
    {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape)
    {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```

## **Dia bélyegkép létrehozása**

Az Aspose.Slides segít a diák bélyegképeinek előállításában. Egy dia bélyegképének az Aspose.Slides használatával történő előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezze be a dia hivatkozását a megfelelő index alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét egy meghatározott méretarányban.  
1. Mentse el a bélyegképet a kívánt képtformátumban.

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

## **Dia bélyegkép létrehozása felhasználó által definiált méretekkel**

A felhasználó által definiált méretekkel rendelkező dia bélyegkép előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezze be a dia hivatkozását a megfelelő index alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a megadott méretekkel.  
1. Mentse el a bélyegképet a kívánt képtformátumban.

```java
int slideIndex = 0;
Size slideSize = new Size(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **Dia bélyegkép létrehozása előadói megjegyzésekkel**

Az Aspose.Slides használatával egy dia előadói megjegyzésekkel ellátott bélyegképének előállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/renderingoptions/) osztályból.  
1. Használja a `RenderingOptions.setSlidesLayoutOptions` metódust az előadói megjegyzések pozíciójának beállításához.  
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezze be a dia hivatkozását a megfelelő index alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.  
1. Mentse el a bélyegképet a kívánt képtformátumban.

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

Próbálja ki az ingyenes [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint megjelenítő](online-PowerPoint-viewer.png)

## **GYIK**

**Beágyazhatok prezentációs megjelenítőt egy webalkalmazásba?**

Igen. Használhatja az Aspose.Slides szolgáltatást a szerveroldalon a diák képként vagy HTML-ként történő rendereléséhez, majd megjelenítheti őket a böngészőben. A navigációs és nagyítási funkciók JavaScript segítségével valósíthatók meg egy interaktív élményhez.

**Mi a legjobb módja a diák megjelenítésének egy egyedi megjelenítőben?**

Az ajánlott megközelítés minden diát képként (pl. PNG vagy SVG) renderelni, vagy Aspose.Slides segítségével HTML-re konvertálni, majd a kimenetet egy képmezőben (asztali alkalmazás esetén) vagy HTML tárolóban (webes esetben) megjeleníteni.

**Hogyan kezeljem a sok diát tartalmazó nagy prezentációkat?**

Nagy méretű prezentációk esetén érdemes a diák késleltetett betöltését vagy igény szerinti renderelését alkalmazni. Ez azt jelenti, hogy egy dia tartalma csak akkor kerül előállításra, amikor a felhasználó rá navigál, ezáltal csökkentve a memória- és betöltési időt.