---
title: Képek kezelésének optimalizálása prezentációkban PHP segítségével
linktitle: Képek kezelése
type: docs
weight: 10
url: /hu/php-java/image/
keywords:
- kép hozzáadása
- kép beszúrása
- bitmap hozzáadása
- kép cseréje
- kép helyettesítése
- webről
- háttér
- PNG hozzáadása
- JPG hozzáadása
- SVG hozzáadása
- EMF hozzáadása
- WMF hozzáadása
- TIFF hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Egyszerűsítse a képek kezelését PowerPoint és OpenDocument dokumentumokban az Aspose.Slides for PHP via Java segítségével, optimalizálva a teljesítményt és automatizálva a munkafolyamatot."
---
## **Bevezetés**

A képek élénkebbé és érdekesebbé teszik az előadásokat. A Microsoft PowerPointban képeket szúrhat be egy fájlból, az internetről vagy más helyekről a diákra. Hasonlóan, az Aspose.Slides lehetővé teszi képek hozzáadását a diákkhoz a prezentációkban különböző módokon.

{{% alert  title="Tipp" color="primary" %}} 

Az Aspose ingyenes konvertereket kínál — [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) — amelyekkel gyorsan készíthet előadásokat képekből. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Ha képet szeretne hozzáadni képkocka objektumként — különösen, ha szabványos formázási lehetőségeket szeretne használni a méretezéshez, hatások hozzáadásához stb. — lásd a(z) [Picture Frame](/slides/hu/php-java/picture-frame/) oldalt.

{{% /alert %}} 

{{% alert title="Megjegyzés" color="warning" %}}

Képek és PowerPoint-prezentációk bemeneti/kimeneti műveleteit kezelve konvertálhat egy képet egyik formátumból a másikba. Lásd ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/php-java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-png/); konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-svg/); konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/svg-to-png/).

{{% /alert %}}

Az Aspose.Slides támogatja a képműveleteket a következő népszerű formátumokban: JPEG, PNG, GIF és egyebek. 

## **Képek helyi tárolásból való hozzáadása a diákhoz**

Egy vagy több képet adhat a számítógépéről egy diához a prezentációban. Az alábbi példakód bemutatja, hogyan adjon képet a diára:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Képek hozzáadása a webről a diákhoz**

Ha a diára felvenni kívánt kép nem érhető el a számítógépén, közvetlenül az internetről adhatja hozzá.

Az alábbi példakód bemutatja, hogyan adjon egy képet az internetről egy diára :

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $imageUrl = new URL("[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new java_class("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    try {
      $buffer = $Array->newInstance($Byte, 1024);
      $read;
      while ($read = $inputStream->read($buffer, 0, $Array->getLength($buffer)) != -1) {
        $outputStream->write($buffer, 0, $read);
      } 
      $outputStream->flush();
      $image = $pres->getImages()->addImage($outputStream->toByteArray());
      $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
      if (!java_is_null($inputStream)) {
        $inputStream->close();
      }
      $outputStream->close();
    }
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Képek hozzáadása dia-mesterekhez**

A dia-mester a legfelső dia, amely az alatta lévő összes dia (téma, elrendezés stb.) információit tárolja és szabályozza. Így, ha képet ad a dia-mesterhez, az a kép minden alatta lévő dián megjelenik. 

Az alábbi Java példakód bemutatja, hogyan adjon képet egy dia-mesterhez:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Képek hozzáadása diák háttérként**

Elhatározhatja, hogy egy képet használ háttérként egy adott dián vagy több dián. Ebben az esetben tekintse meg, hogyan [Set an Image as a Slide Background](/slides/hu/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **SVG hozzáadása a prezentációkhoz**
Bármely képet hozzáadhat vagy beilleszthet egy prezentációhoz a [addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) metódus használatával, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztályhoz tartozik.

SVG képen alapuló képobjektum létrehozásához ezt a módot követheti:

1. Hozzon létre SvgImage objektumot az ImageShapeCollection-be való beszúráshoz
2. Hozzon létre PPImage objektumot az ISvgImage-ből
3. Hozzon létre PictureFrame objektumot a PPImage osztály használatával

Az alábbi példakód bemutatja, hogyan valósítsa meg a fenti lépéseket egy SVG kép hozzáadásához a prezentációhoz:
```php
  # Példányosítsa a Presentation osztályt, amely a PPTX fájlt képviseli
  $pres = new Presentation();
  try {
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = new String($bytes);

    $svgImage = new SvgImage($svgContent);
    $ppImage = $pres->getImages()->addImage($svgImage);
    $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SVG konvertálása alakzatok halmazára**
Az Aspose.Slides SVG konvertálása alakzatok halmazára hasonló a PowerPoint SVG képekkel való munkához használt funkcióhoz:

![PowerPoint felugró menü](img_01_01.png)

A funkcionalitást a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) osztály egyik [addGroupShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addgroupshape/) metódusának túlterhelése biztosítja, amely az első argumentumként egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot várja.

Az alábbi példakód bemutatja, hogyan használja a leírt módszert egy SVG fájl alakzatok halmazára történő konvertálásához:

```php
  # Új prezentáció létrehozása
  $presentation = new Presentation();
  try {
    # SVG fájl tartalmának beolvasása
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "image.svg"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $svgContent = $bytes;

    # SvgImage objektum létrehozása
    $svgImage = new SvgImage($svgContent);
    # Diák méretének lekérése
    $slideSize = $presentation->getSlideSize()->getSize();
    # SVG kép átalakítása alakzatcsoporttá, a diák méretére skálázva
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Prezentáció mentése PPTX formátumban
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Képek hozzáadása EMF-ként a diákhoz**
Az Aspose.Slides for PHP via Java lehetővé teszi EMF képek generálását Excel-munkalapokból, és a képek EMF-ként való hozzáadását a diákhoz az Aspose.Cells segítségével. 

Az alábbi példakód bemutatja, hogyan hajtsa végre a leírt feladatot:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # A munkafüzet mentése adatfolamba
  $sr = new SheetRender($sheet, $options);
  $pres = new Presentation();
  try {
    $pres->getSlides()->removeAt(0);
    $EmfSheetName = "";
    for($j = 0; $j < java_values($sr->getPageCount()) ; $j++) {
      $EmfSheetName = "test" . $sheet->getName() . " Page" . $j + 1 . ".out.emf";
      $sr->toImage($j, $EmfSheetName);
      $picture;
      $image = Images->fromFile($EmfSheetName);
      try {
        $picture = $pres->getImages()->addImage($image);
      } finally {
        if (!java_is_null($image)) {
          $image->dispose();
        }
      }
      $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
      $m = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, $pres->getSlideSize()->getSize()->getWidth(), $pres->getSlideSize()->getSize()->getHeight(), $picture);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Képek cseréje a képgyűjteményben**

Az Aspose.Slides lehetővé teszi a prezentáció képgyűjteményében (beleértve a diák alakzataiban használt képeket) tárolt képek cseréjét. Ez a rész több megközelítést mutat be a gyűjteményben lévő képek frissítésére. Az API egyszerű módszereket kínál egy kép nyers bájtadatok, egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) példány vagy egy már a gyűjteményben létező kép használatával történő cseréjére.

Kövesse az alábbi lépéseket:

1. Töltse be a képeket tartalmazó prezentációs fájlt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal.
2. Töltsön be egy új képet egy fájlból egy bájttömbbe.
3. Cserélje le a célképet az új képre a bájttömb használatával.
4. A második módszerben töltse be a képet egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumba, és cserélje le a célképet ezzel az objektummal.
5. A harmadik módszerben cserélje le a célképet egy már a prezentáció képgyűjteményében létező képre.
6. Írja ki a módosított prezentációt PPTX fájlként.

```php
// A Presentation osztály példányosítása, amely egy prezentációs fájlt reprezentál.
$presentation = new Presentation("sample.pptx");
try {
    // Az első mód.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // A második mód.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // A harmadik mód.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // A prezentáció mentése fájlba.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}

Az Aspose ingyenes [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konverterrel könnyedén animálhat szövegeket, GIF-eket hozhat létre szövegekből stb. 

{{% /alert %}}

## **FAQ**

**Megmarad az eredeti kép felbontása a beillesztés után?**

Igen. A forrás pixelek megmaradnak, de a végső megjelenés attól függ, hogyan van a [picture](/slides/hu/php-java/picture-frame/) méretezve a dián, illetve a mentéskor alkalmazott tömörítéstől.

**Mi a legjobb módja a logó cseréjének egyszerre több tucat dián?**

Helyezze a logót a mesterdia vagy egy elrendezés felé, és cserélje azt a prezentáció képgyűjteményében – a frissítések minden, az erőforrást használó elemre kiterjednek.

**Átalakítható-e egy beillesztett SVG szerkeszthető alakzatokká?**

Igen. Egy SVG-t konvertálhat egy alakzatcsoportba, amely után az egyes részek szerkeszthetők lesznek a szokásos alakzat tulajdonságokkal.

**Hogyan állíthatom be egy képet háttérként egyszerre több diára?**

[Assign the image as the background](/slides/hu/php-java/presentation-background/) a mesterdián vagy a megfelelő elrendezésen – minden, azt a mestert/elrendezést használó dia örökli a háttérképet.

**Hogyan kerülhetem el, hogy a prezentáció sok kép miatt nagyon naggyá nőjön?**

Használjon egyetlen képforrást többszörös példányok helyett, válasszon ésszerű felbontásokat, alkalmazzon tömörítést mentéskor, és a gyakran ismétlődő grafikákat a mesteren tartsa, ahol szükséges.