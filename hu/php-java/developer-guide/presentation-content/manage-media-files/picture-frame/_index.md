---
title: Képkeretek kezelése prezentációkban PHP használatával
linktitle: Képkeret
type: docs
weight: 10
url: /hu/php-java/picture-frame/
keywords:
- képkeret
- képkeret hozzáadása
- képkeret létrehozása
- kép hozzáadása
- kép létrehozása
- kép kinyerése
- raszter kép
- vektor kép
- kép vágása
- levágott terület
- StretchOff tulajdonság
- képkeret formázása
- képkeret tulajdonságai
- relatív méretezés
- kép effektus
- arány
- kép átlátszóság
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Képkeretek hozzáadása PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for PHP via Java segítségével. Egyszerűsítse a munkafolyamatot és javítsa a diák tervezését."
---
## **Bevezetés**

A képkeret egy alakzat, amely egy képet tartalmaz – ez olyan, mint egy kép egy keretben.

Képet adhat hozzá egy diára egy képkereten keresztül. Így a kép formázását a képkeret formázásával végezheti el.

{{% alert  title="Tipp" color="primary" %}} 

Az Aspose ingyenes konvertereket kínál – [JPEG a PowerPoint-ba](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG a PowerPoint-ba](https://products.aspose.app/slides/hu/import/png-to-ppt) –, amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat hozzanak létre képekből. 

{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referencia indexe alapján.  
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a prezentáció objektumhoz tartozó [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) kép hozzáadásával, amelyet az alakzat kitöltéséhez használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumot a kép szélessége és magassága alapján a `addPictureFrame` metódus segítségével, amelyet a hivatkozott dia alakzata objektuma biztosít.  
6. Adjon egy képkeretet (amely tartalmazza a képet) a diához.  
7. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a PHP kód bemutatja, hogyan hozhat létre egy képkeretet:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Példányosítja az Image osztályt
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Hozzáad egy képkeretet a kép megfelelő magasságával és szélességével
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Elmenti a PPTX fájlt a lemezre
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

A képkeretek lehetővé teszik, hogy gyorsan hozzon létre prezentációs diákat képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, kezelheti a bemeneti/kimeneti műveleteket, hogy képeket konvertáljon egyik formátumból a másikba. Érdemes megnézni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/php-java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív méretezésének módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referencia indexe alapján.  
3. Adjon hozzá egy képet a prezentáció képgyűjteményéhez.  
4. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a prezentáció objektumhoz tartozó [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) kép hozzáadásával, amelyet az alakzat kitöltéséhez használ.  
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.  
6. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a PHP kód bemutatja, hogyan hozhat létre egy képkeretet relatív méretezéssel:

```php
  # Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Példányosítja az Image osztályt
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Hozzáad egy képkeretet a kép magasságával és szélességével megegyező mérettel
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Relatív méretezés szélességének és magasságának beállítása
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Elmenti a PPTX fájlt a lemezre
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rasterképek kinyerése képkeretekből**

Rasterképeket nyerhet ki a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumokból, és elmentheti PNG, JPG és egyéb formátumokban. Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy képet a „sample.pptx” dokumentumból, és mentse PNG formátumban.

```php
  $presentation = new Presentation("sample.pptx");
  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $firstShape = $firstSlide->getShapes()->get_Item(0);
    if (java_instanceof($firstShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
      $pictureFrame = $firstShape;
      try {
        $slideImage = $pictureFrame->getPictureFormat()->getPicture()->getImage()->getImage();
        $slideImage->save("slide_1_shape_1.png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } catch (JavaException $e) {
  } finally {
    $presentation->dispose();
  }
```

## **SVG képek kinyerése képkeretekből**

Amikor egy prezentáció SVG grafikákat tartalmaz, melyek [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) alakzatokban helyezkednek el, az Aspose.Slides for PHP via Java lehetővé teszi az eredeti vektor képek teljes hűséggel történő lekérését. A dia alakzatgyűjteményének bejárásával azonosíthat minden [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)-et, ellenőrizheti, hogy a mögöttes [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) SVG tartalmat hordoz-e, majd elmentheti azt natív SVG formátumban lemezre vagy streambe.

Az alábbi kódrészlet bemutatja, hogyan nyerjen ki egy SVG képet egy képkeretből:

```php
$presentation = new Presentation("sample.pptx");

try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $svgImage = $shape->getPictureFormat()->getPicture()->getImage()->getSvgImage();

        if ($svgImage !== null) {
            file_put_contents("output.svg", $svgImage->getSvgData());
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Kép átlátszóságának lekérése**

Az Aspose.Slides lehetővé teszi a képre alkalmazott átlátszósági effektus lekérését. Ez a PHP kód demonstrálja a műveletet:

```php
  $presentation = new Presentation("Test.pptx");
  $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
  foreach($imageTransform as $effect) {
    if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $alphaModulateFixed = $effect;
      $transparencyValue = 100 - $alphaModulateFixed->getAmount();
      echo("Picture transparency: " . $transparencyValue);
    }
  }
```

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre alkalmazhat. Ezekkel a beállításokkal módosíthatja a képkeretet, hogy megfeleljen a konkrét követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referencia indexe alapján.  
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot a prezentáció objektumhoz tartozó [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) kép hozzáadásával, amelyet az alakzat kitöltéséhez használ.  
4. Adja meg a kép szélességét és magasságát.  
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) metódus segítségével, amelyet a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektum biztosít a hivatkozott dián.  
6. Adja hozzá a képkeretet (amely tartalmazza a képet) a diához.  
7. Állítsa be a képkeret vonalszínét.  
8. Állítsa be a képkeret vonalszélességét.  
9. Forgassa el a képkeretet pozitív vagy negatív érték megadásával.  
   * A pozitív érték az ábrát az óramutató járásával megegyező irányba forgatja.  
   * A negatív érték az ábrát az óramutató járásával ellentétes irányba forgatja.  
10. Adja hozzá a képkeretet (amely tartalmazza a képet) a diához.  
11. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a PHP kód demonstrálja a képkeret formázási folyamatát:

```php
  # Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Példányosítja az Image osztályt
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Hozzáad egy képkeretet, amelynek magassága és szélessége megegyezik a képpel
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Alkalmaz némi formázást a PictureFrameEx-re
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tipp" color="primary" %}}

Az Aspose nemrég kifejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást. Ha JPG/JPEG vagy PNG képeket szeretne összevonni, vagy fényképekből rácsot készíteni, használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása linkként**

A nagyméretű prezentációk elkerülése érdekében a képeket (vagy videókat) linkekkel adhatja hozzá ahelyett, hogy a fájlokat közvetlenül beágyazná. Ez a PHP kód megmutatja, hogyan adjon képet és videót egy helyőrzőhöz:

```php
  $presentation = new Presentation("input.pptx");
  try {
    $shapesToRemove = new Java("java.util.ArrayList");
    $shapesCount = $presentation->getSlides()->get_Item(0)->getShapes()->size();
    for($i = 0; $i < java_values($shapesCount) ; $i++) {
      $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item($i);
      if (java_is_null($autoShape->getPlaceholder())) {
        continue;
      }
      switch ($autoShape->getPlaceholder()->getType()) {
        case PlaceholderType::Picture :
          $pictureFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, $autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), null);
          $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $shapesToRemove->add($autoShape);
          break;
        case PlaceholderType::Media :
          $videoFrame = $presentation->getSlides()->get_Item(0)->getShapes()->addVideoFrame($autoShape->getX(), $autoShape->getY(), $autoShape->getWidth(), $autoShape->getHeight(), "");
          $videoFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
          $videoFrame->setLinkPathLong("https://youtu.be/t_1LYZ102RA");
          $shapesToRemove->add($autoShape);
          break;
      }
    }
    foreach($shapesToRemove as $shape) {
      $presentation->getSlides()->get_Item(0)->getShapes()->remove($shape);
    }
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Képek vágása**

Ez a PHP kód bemutatja, hogyan lehet egy meglévő képet vágni egy dián:

```php
  $pres = new Presentation();
  # Létrehoz egy új képobjektumot
  try {
    $picture;
    $image = Images->fromFile($imagePath);
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Képkeretet ad egy diára
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Levágja a képet (százalékos értékek)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Elmenti az eredményt
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **A képkeretben levágott területek törlése**

Ha egy keretben lévő kép levágott területeit szeretné eltávolítani, használhatja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metódust. Ez a metódus a levágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a PHP kód demonstrálja a műveletet:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Lekéri a PictureFrame-et az első diáról
    $picFrame = $slide->getShapes()->get_Item(0);
    # Törli a PictureFrame kép levágott területeit és visszaadja a levágott képet
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Elmenti az eredményt
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metódus a levágott képet hozzáadja a prezentáció képgyűjteményéhez. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)-ben használják, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a keletkezett prezentációban a képek száma nőni fog.

Ez a metódus a vágás során a WMF/EMF metafájlokat PNG raszterképpé konvertálja. 

{{% /alert %}}

## **Képek tömörítése**

A prezentációban egy képet a [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) metódussal tömöríthet. Ez a metódus a kép méretét a forma mérete és a megadott felbontás alapján csökkenti, opcionálisan a levágott területek törlésével.

A képméretet és felbontást a PowerPoint **Képformátum -> Képek tömörítése -> Felbontás** funkciójával hasonló módon állítja be.

Az alábbi PHP példák bemutatják, hogyan tömöríthet egy képet egy prezentációban célfelbontás megadásával és opcionálisan a levágott területek eltávolításával:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Tömöríti a képet 150 DPI (web felbontás) célfelbontással és eltávolítja a levágott területeket.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Ellenőrzi a tömörítés eredményét.
    if ($result) {
        echo "Image successfully compressed.";
    } else {
        echo "Image compression failed or no changes were necessary.";
    }

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Vagy közvetlenül egyéni DPI érték megadásával:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Tömöríti a képet 150 DPI-re (web felbontás), eltávolítva a levágott területeket.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

A metódus a kép felbontását a forma mérete és a megadott DPI alapján alacsonyabbra konvertálja. A levágott területek is törölhetők a fájlméret optimalizálásához.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem lesz alkalmazva. Emellett a JPEG minőség megmarad vagy enyhén csökken a felbontás függvényében, ahogyan a PowerPoint kezeli a nagy felbontású JPEG-eket.

{{% /alert %}}

## **Arány rögzítése**

Ha azt szeretné, hogy egy képet tartalmazó alakzat megtartsa az arányát a kép méretének módosítása után is, használhatja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) metódust az *Arány rögzítése* beállítás megadásához.

Ez a PHP kód mutatja be, hogyan rögzítheti egy forma arányát:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $layout = $pres->getLayoutSlides()->getByType(SlideLayoutType::Custom);
    $emptySlide = $pres->getSlides()->addEmptySlide($layout);
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pictureFrame = $emptySlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $presImage->getWidth(), $presImage->getHeight(), $picture);
    # állítsa be az alakzatot, hogy a méretezéskor megőrizze az arányt
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

Ez az *Arány rögzítése* beállítás csak a forma arányát őrzi meg, nem pedig a benne lévő képet.

{{% /alert %}}

## **A StretchOff tulajdonság használata**

A [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) osztályból származó [setStretchOffsetLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) és [setStretchOffsetBottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) metódusok segítségével egy kitöltési téglalapot adhat meg.

Ha egy képhez nyújtási beállítás van megadva, egy forrástéglalap méreteződik, hogy illeszkedjen a megadott kitöltési téglalapba. A kitöltési téglalap minden oldalát a forma határától számított százalékos eltolás határozza meg. A pozitív százalékos érték beszúrást, a negatív pedig kinyújtást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.  
2. Szerezze meg egy dia referencia indexe alapján.  
3. Adjon hozzá egy `AutoShape` téglalapot.  
4. Hozzon létre egy képet.  
5. Állítsa be a forma kitöltés típusát.  
6. Állítsa be a forma képkitöltési módját.  
7. Adjon hozzá egy képet a forma kitöltéséhez.  
8. Adja meg a kép eltolásait a forma határának megfelelő oldalához viszonyítva.  
9. Írja ki a módosított prezentációt PPTX fájlként.  

Ez a PHP kód demonstrálja egy StretchOff tulajdonságot használó folyamatot:

```php
  # Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $slide = $pres->getSlides()->get_Item(0);
    # Példányosítja az ImageEx osztályt
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Hozzáad egy AutoShape-et, amely Rectangle típusú
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Beállítja az alakzat kitöltési típusát
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Beállítja az alakzat képkitöltési módját
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Beállítja a képet az alakzat kitöltéséhez
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Megadja a kép eltolásait az alakzat határoló dobozának megfelelő oldalához viszonyítva
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **GYIK**

**Hogyan tudom megtudni, hogy milyen képformátumok támogatottak a PictureFrame esetén?**

Az Aspose.Slides támogatja mind a raszterképeket (PNG, JPEG, BMP, GIF stb.), mind a vektor képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumhoz rendelt kép objektumon keresztül. A támogatott formátumok listája általában átfedésben van a dia és a kép konvertáló motor képességeivel.

**Milyen hatással lesz a több tucat nagy méretű kép PPTX méretére és teljesítményére?**

A nagy képek beágyazása megnöveli a fájlméretet és a memóriahasználatot; a képek linkként történő hozzáadása segít csökkenteni a prezentáció méretét, de a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít a képek linkkel való hozzáadására a fájlméret csökkentése érdekében.

**Hogyan lehet egy képobjektust megakadályozni a véletlen mozgatásban/átméretezésben?**

Használjon [forma zárolásokat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/getpictureframelock/) egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)-hez (például a mozgatás vagy átméretezés letiltásával). A zárolási mechanizmus többféle forma típushoz támogatott, beleértve a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)-et is.

**Megmarad-e az SVG vektor hűsége a prezentáció PDF/ képek formátumba exportálása során?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)-ből eredeti vektorként. PDF-be ([exportálás PDF-be](/slides/hu/php-java/convert-powerpoint-to-pdf/)) vagy raszterformátumokba ([exportálás PNG-be](/slides/hu/php-java/convert-powerpoint-to-png/)) történő exportáláskor az eredmény a beállított export opcióktól függően rasterizálódhat; a kiinduló SVG vektor formátuma a kinyerési művelet során megerősítést nyer.