---
title: Prezentációs néző létrehozása PHP-ben
linktitle: Prezentációs néző
type: docs
weight: 50
url: /hu/php-java/presentation-viewer/
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
- PHP
- Aspose.Slides
description: "Egy egyedi prezentációs néző létrehozása az Aspose.Slides for PHP via Java segítségével. PowerPoint és OpenDocument fájlok egyszerű megjelenítése Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java arra szolgál, hogy diavetítési fájlokat hozzon létre diák segítségével. Ezeket a diákat meg lehet nyitni például a Microsoft PowerPoint programban. Néha azonban a fejlesztőknek szükségük lehet a diák képként történő megtekintésére a kedvenc képmegjelenítőjükben, vagy saját prezentációs nézőt szeretnének készíteni. Ilyen esetekben az Aspose.Slides lehetővé teszi egy adott dia képként való exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép létrehozása diáról**

Az SVG kép generálásához egy prezentációs diából az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Nyisson meg egy fájlfolyamot.  
1. Mentse a diát SVG képként a fájlfolyamra.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream);
$svgStream->close();

$presentation->dispose();
```

## **Egyedi alakzatazonosítóval ellátott SVG létrehozása**

Az Aspose.Slides használható egy [SVG](https://docs.fileformat.com/page-description-language/svg/) generálására egy diából egy egyedi alakzatazonosítóval. Ehhez használja a `setId` metódust a [SvgShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgshape/) osztályból. A `CustomSvgShapeFormattingController` használható az alakzatazonosító beállításához.

```php
$slideIndex = 0;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(0), null, java("com.aspose.slides.ISvgShapeFormattingController"));

$svgOptions = new SVGOptions();
$svgOptions->setShapeFormattingController($shapeFormattingController);

$svgStream = new Java("java.io.FileOutputStream", "output.svg");
$slide->writeAsSvg($svgStream, $svgOptions);
$svgStream->close();

$presentation->dispose();
```
```php
class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    public function __construct($shapeStartIndex) {
        $this->m_shapeIndex = $shapeStartIndex;
    }

    public function formatShape($svgShape, $shape) {
        $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
}
```

## **Dia bélyegkép létrehozása**

Az Aspose.Slides segít a diák bélyegképeinek generálásában. Egy dia bélyegképének létrehozásához az Aspose.Slides használatával, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét egy meghatározott méretarányban.  
1. Mentse a bélyegképet a kívánt képformátumban.

```php
$slideIndex = 0;
$scaleX = 1.0;
$scaleY = $scaleX;

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($scaleX, $scaleY);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Dia bélyegkép létrehozása felhasználó által megadott méretekkel**

Felhasználó által definiált méretekkel rendelkező dia bélyegkép elkészítéséhez kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretekkel.  
1. Mentse a bélyegképet a kívánt képformátumban.

```php
$slideIndex = 0;
$slideSize = new Java("java.awt.Dimension", 1200, 800);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($slideSize);
$image->save("output.jpg", ImageFormat::Jpeg);
$image->dispose();

$presentation->dispose();
```

## **Dia bélyegkép létrehozása előadói jegyzetekkel**

Az előadói jegyzetekkel ellátott dia bélyegképének generálásához az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/) osztályból.  
1. Használja a `RenderingOptions.setSlidesLayoutOptions` metódust az előadói jegyzetek pozíciójának beállításához.  
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.  
1. Mentse a bélyegképet a kívánt képformátumban.

```php
$slideIndex = 0;

$layoutingOptions = new NotesCommentsLayoutingOptions();
$layoutingOptions->setNotesPosition(NotesPositions::BottomTruncated);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutingOptions);

$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item($slideIndex);

$image = $slide->getImage($renderingOptions);
$image->save("output.png", ImageFormat::Png);
$image->dispose();

$presentation->dispose();
```

## **Élő példa**

Próbálja ki a [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **GYIK**

**Be lehet-e ágyazni egy prezentációs nézőt webalkalmazásba?**

Igen. Az Aspose.Slides használható a szerveroldalon a diák képként vagy HTML-ként történő renderelésére, és megjeleníthető a böngészőben. A navigációs és nagyítási funkciók JavaScript segítségével valósíthatók meg egy interaktív élményhez.

**Mi a legjobb módja a diák megjelenítésének egy egyedi nézőben?**

Az ajánlott megközelítés, hogy minden diát képként (például PNG vagy SVG) renderelünk, vagy HTML-re konvertálunk az Aspose.Slides segítségével, majd az eredményt egy képkocka (desktop) vagy egy HTML konténer (web) belsejében jelenítjük meg.

**Hogyan kezeljem a sok diát tartalmazó nagy prezentációkat?**

Nagy prezentációk esetén érdemes késleltetett betöltést vagy igény szerinti renderelést alkalmazni. Ez azt jelenti, hogy a dia tartalmát csak akkor generáljuk, amikor a felhasználó a diára navigál, ezáltal csökkentve a memória- és betöltési időt.