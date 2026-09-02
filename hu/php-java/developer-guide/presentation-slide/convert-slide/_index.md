---
title: Prezentációs diák képpé konvertálása PHP-ben
linktitle: Dia kép
type: docs
weight: 35
url: /hu/php-java/convert-slide/
keywords:
- dia konvertálása
- dia exportálása
- dia képpé
- dia mentése képként
- dia EMF-be
- dia PNG-be
- dia JPEG-be
- dia bitmap-be
- dia TIFF-be
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "PPT, PPTX és ODP prezentációkból származó diák konvertálása PNG, JPEG, GIF, TIFF, EMF és egyéb képformátumokba PHP-ben az Aspose.Slides használatával."
---
## **Bevezetés**

Az Aspose.Slides for PHP via Java képes egyes diák renderelésére PowerPoint és OpenDocument prezentációkból PNG, JPEG, GIF, TIFF és egyéb képadatformátumokban.

Hogy egy diát képpé alakítsunk, kövessük az alábbi lépéseket:

1. Töltsük be a prezentációt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztállyal.
2. Válasszuk ki a renderezni kívánt diát.
3. Szükség esetén konfiguráljuk a renderelést a [RenderingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/) vagy a [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztállyal.
4. Hívjuk meg a [Slide::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) metódust. Ez egy [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektumot ad vissza.
5. Hívjuk meg az [IImage::save](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/#save) metódust, és adjuk meg a kimeneti formátumot egy [ImageFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imageformat/) értékkel.

## **Diák PNG képpé konvertálása**

A legegyszerűbb konverzió az alapértelmezett renderelési beállításokat használja. A kapott [IImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/iimage/) objektum feldolgozható memóriában vagy elmenthető fájlba.

Az alábbi PHP példa rendereli az első diát, és PNG képként menti el:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage();
    try {
        $image->save("Slide_0.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Diák képpé konvertálása egyéni méretekkel**

Használjuk a [Slide::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) túlterhelést, amely egy [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html) értéket fogad el, hogy a diát pontos pixelméretekkel rendereljük.

Az alábbi példa 1820 × 1040 JPEG képet hoz létre:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$imageSize = new Java("java.awt.Dimension", 1820, 1040);

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($imageSize);
    try {
        $image->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Diák konvertálása jegyzetekkel és megjegyzésekkel képekké**

Alapértelmezés szerint a diaképek nem tartalmazzák a jegyzeteket vagy megjegyzéseket. Adjunk át egy [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/) objektumot a [RenderingOptions::setSlidesLayoutOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) metódusnak, hogy szabályozzuk, hol jelenjenek meg a jegyzetek és megjegyzések.

Az alábbi példa a levágott jegyzeteket a dia alá, a megjegyzéseket pedig jobbra helyezi:

```php
use aspose\slides\CommentsPositions;
use aspose\slides\ImageFormat;
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$scaleX = 2;
$scaleY = $scaleX;

$commentsAreaColor = new Java("java.awt.Color", 250, 235, 215);

$layoutOptions = new NotesCommentsLayoutingOptions();
$layoutOptions->setNotesPosition(NotesPositions::BottomTruncated);
$layoutOptions->setCommentsPosition(CommentsPositions::Right);
$layoutOptions->setCommentsAreaWidth(500);
$layoutOptions->setCommentsAreaColor($commentsAreaColor);

$renderingOptions = new RenderingOptions();
$renderingOptions->setSlidesLayoutOptions($layoutOptions);

$presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($renderingOptions, $scaleX, $scaleY);
    try {
        $image->save("Image_with_notes_and_comments_0.gif", ImageFormat::Gif);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
A diát képpé konvertálásakor ne adjuk át a [BottomFull](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notespositions/) értéket a [NotesCommentsLayoutingOptions::setNotesPosition](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) metódusnak. A jegyzetek több szöveget tartalmazhatnak, mint amennyit a rögzített képméret befogad. Ehelyett használjuk a [BottomTruncated](https://reference.aspose.com/slides/hu/php-java/aspose.slides/notespositions/) értéket.
{{% /alert %}}

## **Diák képpé konvertálása TIFF beállításokkal**

A [TiffOptions](https://reference.aspose.com/slides/hu/php-java/aspose.slides/tiffoptions/) osztály lehetővé teszi a renderelt TIFF kép méretének, felbontásának és egyéb tulajdonságainak szabályozását.

Az alábbi példa az első diát 2160 × 2880 TIFF képként, 300 DPI felbontással rendereli:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\TiffOptions;

$imageSize = new Java("java.awt.Dimension", 2160, 2880);

$tiffOptions = new TiffOptions();
$tiffOptions->setImageSize($imageSize);
$tiffOptions->setDpiX(300);
$tiffOptions->setDpiY(300);

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = $slide->getImage($tiffOptions);
    try {
        $image->save("output.tiff", ImageFormat::Tiff);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert title="Warning" color="warning" %}}
A TIFF támogatás nem garantált a JDK 9 előtti Java verziókban.
{{% /alert %}}

## **Az összes dia képpé konvertálása**

Iteráljunk a diágyűjteményen, hogy a teljes prezentációt képsorozattá alakítsuk. A rejtett diákat is beleértjük, hacsak nem hagyjuk ki őket kifejezetten.

Az alábbi példa minden diát JPEG képként renderel, vízszintes és függőleges skálafaktorral 2:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$scaleX = 2;
$scaleY = $scaleX;

$presentation = new Presentation("Presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("Slide_" . $index . ".jpg", ImageFormat::Jpeg);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Fejlett metafájl kimenet létrehozása**

A Enhanced Metafile (EMF) akkor hasznos, ha vektoralapú grafikákat kell cserélni a Microsoft Office-szal vagy más, Windows metafájlokat támogató Windows alkalmazásokkal. A pixelalapú képpel ellentétben egy EMF megőrizheti a vektoros rajz műveleteket, amelyek méretezve nem vesztenek élességükből. Az EMF azonban elsősorban kompatibilitási formátum Windows metafájl támogatással rendelkező alkalmazások számára, nem univerzális csereformátum. Emellett a komplex diá tartalom, például bitmap képek és bizonyos effektusok, rasterizált elemekként tárolhatók a vektor metafájl tárolóban.

### **Dia exportálása EMF-be**

A [Slide::writeAsEmf](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#writeAsEmf) metódus egy diát EMF formátumban egy célfolyamra ír. Az alábbi példa beolvas egy prezentációt, kiválasztja az első diát, és EMF fájlfolyamba írja:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.FileOutputStream", "Slide_0.emf");
    try {
        $slide->writeAsEmf($emfStream);
    } finally {
        $emfStream->close();
    }
} finally {
    $presentation->dispose();
}
```

A hívó birtokolja a [Slide::writeAsEmf](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#writeAsEmf) metódusnak átadott folyamot, és felel a lezárásáért, ahogy a fent mutattuk.

### **SVG kép konvertálása EMF-be és hozzáadása egy prezentációhoz**

Használja a [SvgImage::writeAsEmf](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/#writeAsEmf) metódust az SVG tartalom EMF-be konvertálásához. A kapott bájtok a [ImageCollection::addImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/#addImage) segítségével hozzáadhatók a prezentációhoz, és a [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addPictureFrame) használatával egy diára helyezhetők.

Az alábbi példa SVG jelölésből létrehoz egy [SvgImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/) objektumot, memóriában EMF formátumba konvertálja, az első diára beilleszti a metafájlt, és elmenti a prezentációt:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$svgContent = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>';
$svgImage = new SvgImage($svgContent);

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $emfStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $svgImage->writeAsEmf($emfStream);

        $emfData = $emfStream->toByteArray();
        $image = $presentation->getImages()->addImage($emfData);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 100, $image);
    } finally {
        $emfStream->close();
    }

    $presentation->save("Presentation_with_emf.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az [SvgImage::writeAsEmf](https://reference.aspose.com/slides/hu/php-java/aspose.slides/svgimage/#writeAsEmf) nem veszi át a célfolyam tulajdonjogát. A [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) az összes generált adatot memóriában tárolja, így a `toByteArray` hívása előtt nem szükséges a pozíció visszaállítása. A visszakapott bájt tömb a folyamat lezárása után is érvényes marad.

Az EMF generálás elérhető az Aspose.Slides for PHP via Java által támogatott operációs rendszereken és JDK beállításokkal, de a renderelés platformonként eltérhet, ha a betűkészletek vagy grafikai függőségek nem állnak rendelkezésre. Telepítse a forrás tartalom által használt betűkészleteket, vagy állítson be megfelelő helyettesítőket, kövesse az [platform követelményeket](/slides/hu/php-java/system-requirements/) az Aspose.Slides for PHP via Java-hez, és ellenőrizze az eredményt a cél EMF-ot fogyasztó alkalmazásban. A Linux és macOS alkalmazások gyakran korlátozott vagy inkonzisztens támogatást nyújtanak a Windows metafájlok megjelenítéséhez és szerkesztéséhez.

## **Színes Emoji renderelés**

{{% alert title="Note" color="info" %}}
A színes emoji-k helyes rendereléséhez a prezentációban használt emoji betűkészleteket telepíteni kell, és elérhetőnek kell lenniük azon a rendszeren, amely a konverziót végzi. Például, ha a prezentáció a **Segoe UI Emoji** betűkészletet használja, de ez hiányzik, az emoji-k monokrómokként jelenhetnek meg a kimeneti képeken.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides a diák animációval történő renderelését?**

Nem. A [Slide::getImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/slide/#getImage) metódus statikus képet renderel a diákról, és nem exportál animációkat.

**Exportálhatók-e a rejtett diák képként?**

Igen. A rejtett diákat ugyanolyanul renderelhetjük, mint a normál diákat. Vegyük őket bele a feldolgozási ciklusba, ahogyan a fenti példában látható.

**Megmaradnak-e a árnyékok és egyéb effektusok a diákképekben?**

Igen. Az Aspose.Slides a diaképekben rendereli az árnyékokat, átlátszóságot és egyéb támogatott grafikai effektusokat.