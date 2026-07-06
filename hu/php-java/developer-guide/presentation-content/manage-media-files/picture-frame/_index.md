---
title: "Képkeretek kezelése prezentációkban PHP használatával"
linktitle: "Képkeret"
type: docs
weight: 10
url: /hu/php-java/picture-frame/
keywords:
- "képkeret"
- "képkeret hozzáadása"
- "képkeret létrehozása"
- "kép hozzáadása"
- "kép létrehozása"
- "kép kinyerése"
- "raszter kép"
- "vektor kép"
- "kép vágása"
- "vágott terület"
- "StretchOff tulajdonság"
- "képkeret formázása"
- "képkeret tulajdonságai"
- "relatív méretezés"
- "kép hatás"
- "oldalarány"
- "kép átlátszóság"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "PHP"
- "Aspose.Slides"
description: "Adj hozzá képkereteket PowerPoint és OpenDocument prezentációkhoz az Aspose.Slides for PHP via Java segítségével. Egyszerűsítsd a munkafolyamatot és javítsd a diák megjelenését."
---
## **Bevezetés**

A képkeret egy alakzat, amely képet tartalmaz – ez olyan, mint egy kép a keretben.

Képet adhat hozzá egy diára képkereten keresztül. Így a kép formázását a képkeret formázásával végezheti el.

{{% alert  title="Tipp" color="primary" %}} 

Az Aspose ingyenes konvertereket biztosít – [JPEG to PowerPoint](https://products.aspose.app/slides/hu/import/jpg-to-ppt) és [PNG to PowerPoint](https://products.aspose.app/slides/hu/import/png-to-ppt) – amelyek lehetővé teszik a felhasználók számára, hogy gyorsan prezentációkat hozzanak létre képekből. 

{{% /alert %}} 

## **Képkeret létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján. 
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy képet ad hozzá a prezentáció objektumhoz tartozó [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) gyűjteményhez, amelyet az alakzat kitöltésére használ.
4. Adja meg a kép szélességét és magasságát.
5. Hozzon létre egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumot a kép szélessége és magassága alapján a `addPictureFrame` metódus segítségével, amely a hivatkozott diához tartozó shape objektumon keresztül érhető el.
6. Adjon hozzá egy képkeretet (amely tartalmazza a képet) a diához.
7. Írja ki a módosított prezentációt PPTX fájlként.

Ez a PHP kód megmutatja, hogyan hozhat létre egy képkeretet:

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
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

A képkeretek lehetővé teszik, hogy gyorsan készítsen prezentációs diákat képek alapján. Ha a képkeretet kombinálja az Aspose.Slides mentési beállításaival, manipulálhatja a be- és kimeneti műveleteket a képek formátumkonverziójához. Érdemes megtekinteni ezeket az oldalakat: konvertálás [image to JPG](https://products.aspose.com/slides/hu/php-java/conversion/image-to-jpg/); konvertálás [JPG to image](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-image/); konvertálás [JPG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/jpg-to-png/), konvertálás [PNG to JPG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-jpg/); konvertálás [PNG to SVG](https://products.aspose.com/slides/hu/php-java/conversion/png-to-svg/), konvertálás [SVG to PNG](https://products.aspose.com/slides/hu/php-java/conversion/svg-to-png/).

{{% /alert %}}

## **Képkeret létrehozása relatív méretezéssel**

A kép relatív skálázásának módosításával összetettebb képkeretet hozhat létre. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján. 
3. Adjon képet a prezentáció képgyűjteményéhez.
4. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy képet ad hozzá a [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) gyűjteményhez, amelyet a prezentáció objektum használ a shape kitöltésére.
5. Adja meg a kép relatív szélességét és magasságát a képkeretben.
6. Írja ki a módosított prezentációt PPTX fájlként.

Ez a PHP kód megmutatja, hogyan hozhat létre egy képkeretet relatív skálával:

```php
  # Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
  $pres = new Presentation();
  try {
    # Lekéri az első diát
    $sld = $pres->getSlides()->get_Item(0);
    # Példányosítja az Image osztályt
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Relatív méretezés beállítása szélesség és magasság
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Kiírja a PPTX fájlt a lemezre
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Raster képek kinyerése képkeretekből**

Kinyerhet raster képeket a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumokból, és elmentheti őket PNG, JPG és egyéb formátumokban. Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy képet a „sample.pptx” dokumentumból, és mentse el PNG formátumban.

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

Amikor egy prezentáció SVG grafikákat tartalmaz, amelyek [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) alakzatokba vannak ágyazva, az Aspose.Slides for PHP via Java lehetővé teszi az eredeti vektor képek teljes hitelességével történő visszanyerését. A dia shape gyűjteményének bejárásával azonosíthatja az egyes [PictureFrame] objektumokat, ellenőrizheti, hogy a mögöttes [PPImage] SVG tartalmat tartalmaz‑e, majd elmentheti a képet lemezre vagy stream‑re natív SVG formátumban.

Az alábbi kódrészlet bemutatja, hogyan nyerhet ki egy SVG képet egy képkeretből:

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

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott átlátszósági effektust. Ez a PHP kód demonstrálja a műveletet:

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

## **Kép fényerősségének és kontrasztjának lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy képre alkalmazott fényerő és kontraszt effektust. A [Luminance](https://reference.aspose.com/slides/hu/php-java/aspose.slides/luminance/) osztály képviseli ezt a képtranszformációs hatást.

Ez a PHP kód bemutatja, hogyan kérhető le a fényerő és kontraszt beállítás egy képkeretből:

```php
  $presentation = new Presentation("sample.pptx");

  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $pictureFrame = $shape;

    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransformCount = java_values($imageTransform->size());
    for ($index = 0; $index < $imageTransformCount; $index++) {
      $effect = $imageTransform->get_Item($index);
      if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
        $luminance = $effect->getEffective();
        $brightness = java_values($luminance->getBrightness());
        $contrast = java_values($luminance->getContrast());

        echo("Brightness: " . $brightness . PHP_EOL);
        echo("Contrast: " . $contrast . PHP_EOL);
      }
    }
  } finally {
    $presentation->dispose();
  }
```

## **Képkeret formázása**

Az Aspose.Slides számos formázási lehetőséget kínál, amelyeket egy képkeretre alkalmazhat. Ezekkel a lehetőségekkel módosíthatja a képkeretet úgy, hogy megfeleljen a specifikus követelményeknek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján. 
3. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/php-java/aspose.slides/ppimage/) objektumot úgy, hogy képet ad hozzá a [ImageCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/imagecollection/) gyűjteményhez, amelyet a prezentáció objektum a shape kitöltésére használ.
4. Adja meg a kép szélességét és magasságát.
5. Hozzon létre egy `PictureFrame` objektumot a kép szélessége és magassága alapján a [addPictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/addpictureframe/) metódus segítségével, amely a [ShapeCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/) objektumon keresztül érhető el a hivatkozott dián.
6. Adja hozzá a képkeretet (amely tartalmazza a képet) a diához.
7. Állítsa be a képkeret vonalszínét.
8. Állítsa be a képkeret vonalvastagságát.
9. Forgassa el a képkeretet egy pozitív vagy negatív értékkel.
   * A pozitív érték azonnal óramutató járásával megegyező irányba forgatja a képet. 
   * A negatív érték az ellenkező irányba forgatja.
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
    # Hozzáad egy képkeretet a kép magasságával és szélességével megegyezően
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

Az Aspose nemrég fejlesztett egy [ingyenes Collage Maker](https://products.aspose.app/slides/hu/collage) alkalmazást. Ha valaha JPG/JPEG vagy PNG képeket kell összefésülnie, vagy fotó‑rácsokat szeretne létrehozni, használhatja ezt a szolgáltatást. 

{{% /alert %}}

## **Kép hozzáadása hivatkozásként**

A nagy méretű prezentációk elkerülése érdekében képeket (vagy videókat) hivatkozásokként adhat hozzá ahelyett, hogy közvetlenül beágyazná a fájlokat. Ez a PHP kód megmutatja, hogyan adhat hozzá egy képet és egy videót egy helykitöltőhöz:

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

Ez a PHP kód bemutatja, hogyan vághat le egy meglévő képet egy dián:

```php
  $pres = new Presentation();
  # Új képobjektumot hoz létre
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
    # Képkeretet ad egy diához
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Levágja a képet (százalék értékek)
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

## **Képkeret vágott területeinek törlése**

Ha egy keretben lévő kép vágott területeit szeretné eltávolítani, használja a [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metódust. Ez a metódus a vágott képet vagy az eredeti képet adja vissza, ha a vágás nem szükséges.

Ez a PHP kód demonstrálja a műveletet:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Lekéri a PictureFrame-et az első diáról
    $picFrame = $slide->getShapes()->get_Item(0);
    # Törli a PictureFrame kép vágott területeit és visszaadja a vágott képet
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

A [deletePictureCroppedAreas()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) metódus hozzáadja a vágott képet a prezentáció képgyűjteményéhez. Ha a képet csak a feldolgozott [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) használja, ez a beállítás csökkentheti a prezentáció méretét. Ellenkező esetben a végleges prezentációban a képek száma nőni fog.

Ez a metódus a WMF/EMF metafájlokat raster PNG képpé konvertálja a vágási művelet során. 

{{% /alert %}}

## **Képek tömörítése**

A kép tömöríthető egy prezentációban a [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) metódus segítségével. Ez a metódus a kép méretét csökkenti a shape mérete és a megadott felbontás alapján, opcionálisan a vágott területek törlésével.

A kép méretét és felbontását úgy módosítja, mint a PowerPoint **Picture Format → Compress Pictures → Resolution** funkciója.

Az alábbi PHP példák bemutatják, hogyan lehet tömöríteni egy képet a prezentációban célfelbontás megadásával, és opcionálisan a vágott területek eltávolításával:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Tömöríti a képet 150 DPI (web felbontás) célfelbontással, és eltávolítja a vágott területeket.
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

Vagy egyéni DPI érték közvetlen használatával:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Tömöríti a képet 150 DPI-re (web felbontás), és eltávolítja a vágott területeket.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

A metódus a képet alacsonyabb felbontásra konvertálja a shape mérete és a megadott DPI alapján. A vágott területek is törölhetők a fájlméret optimalizálása érdekében.  
Ha a kép metafájl (WMF/EMF) vagy SVG, a tömörítés nem kerül alkalmazásra. A JPEG minőség megmarad vagy enyhén csökken a felbontás függvényében, ahogyan a PowerPoint kezeli a nagy felbontású JPEG‑eket.

{{% /alert %}}

## **Oldalarány zárolása**

Ha azt szeretné, hogy egy képet tartalmazó shape megőrizze az arányait akkor is, ha megváltoztatja a kép méretét, használja a [setAspectRatioLocked](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) metódust az *Oldalarány zárolása* beállítás aktiválásához.

Ez a PHP kód megmutatja, hogyan lehet zárolni egy shape oldalarányát:

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
    # állítsa be a shape-et, hogy a méretezéskor megőrizze az oldalarányt
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="MEGJEGYZÉS" color="warning" %}} 

Ez az *Oldalarány zárolása* beállítás csak a shape arányát őrzi meg, nem pedig a benne lévő képet.

{{% /alert %}}

## **StretchOff tulajdonság használata**

A [setStretchOffsetLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) és [setStretchOffsetBottom](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) metódusok a [PictureFillFormat](https://reference.aspose.com/slides/hu/php-java/aspose.slides/picturefillformat/) osztályból lehetővé teszik egy kitöltési téglalap meghatározását.

Amikor egy képhez nyújtást adunk meg, egy forrástéglalap skálázódik, hogy illeszkedjen a megadott kitöltési téglalaphoz. A kitöltési téglalap minden oldala egy százalékos eltolással van definiálva a shape határoló dobozának megfelelő oldalához képest. A pozitív százalékos érték befelé tolást, a negatív pedig kifelé tolást jelent.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/presentation/) osztályból.
2. Szerezze meg egy dia hivatkozását az indexe alapján.
3. Adjon hozzá egy `AutoShape` téglalapot. 
4. Hozzon létre egy képet.
5. Állítsa be a shape kitöltési típusát.
6. Állítsa be a shape kép kitöltési módját.
7. Adjon hozzá egy képet a shape kitöltéséhez.
8. Adja meg a kép eltolásait a shape határoló dobozának megfelelő oldalához képest.
9. Írja ki a módosított prezentációt PPTX fájlként.

Ez a PHP kód demonstrálja a StretchOff tulajdonság használatát egy folyamatban:

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
    # Automatikus alakzatot ad hozzá, amely Rechteck típusú
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Beállítja az alakzat kitöltésének típusát
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Beállítja az alakzat kép kitöltési módját
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Beállítja a képet az alakzat kitöltéséhez
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Megadja a kép eltolásait a shape határoló dobozának megfelelő oldalhoz képest
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

**Hogyan deríthetem ki, mely képformátumok támogatottak a PictureFrame‑hez?**

Az Aspose.Slides támogatja a raszter képeket (PNG, JPEG, BMP, GIF stb.) és a vektor képeket (például SVG) a [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) objektumhoz rendelt képobjektumon keresztül. A támogatott formátumok listája általában átfedi a slide és a kép konverziós motor képességeit.

**Hogyan befolyásolja a tucatnyi nagy kép hozzáadása a PPTX méretét és teljesítményét?**

A nagy képek beágyazása növeli a fájlméretet és a memóriahasználatot; a képek hivatkozásként való hozzáadása segít a prezentáció méretének csökkentésében, ám a külső fájloknak elérhetőnek kell maradniuk. Az Aspose.Slides lehetőséget biztosít a képek hivatkozásként való hozzáadására a fájlméret csökkentése érdekében.

**Hogyan zárolhatok egy képobjektumot a véletlen mozgatás/átméretezés ellen?**

Használja a [shape locks](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/getpictureframelock/) lehetőséget egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/) esetén (például a mozgatás vagy átméretezés letiltásával). A zárási mechanizmus különböző shape típusoknál támogatott, beleértve a [PictureFrame] objektumokat is.

**Megmarad-e az SVG vektorhitelesség exportáláskor PDF‑be/képekbe?**

Az Aspose.Slides lehetővé teszi egy SVG kinyerését egy [PictureFrame](https://reference.aspose.com/slides/hu/php-java/aspose.slides/pictureframe/)‑ből eredeti vektorként. PDF‑re ([export to PDF](/slides/hu/php-java/convert-powerpoint-to-pdf/)) vagy raszter formátumra ([export to PNG](/slides/hu/php-java/convert-powerpoint-to-png/)) történő exportáláskor az eredmény függhet az export beállításaitól; az SVG eredeti vektorként tárolása azonban a kinyerési viselkedés által megerősített.