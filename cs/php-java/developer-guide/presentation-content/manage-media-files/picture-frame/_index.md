---
title: "Správa obrázkových rámů v prezentacích pomocí PHP"
linktitle: "Obrázkový rám"
type: docs
weight: 10
url: /cs/php-java/picture-frame/
keywords:
- obrázkový rám
- přidat obrázkový rám
- vytvořit obrázkový rám
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování obrázkového rámu
- vlastnosti obrázkového rámu
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přidejte obrázkové rámy do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Zjednodušte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Obrázkový rám je tvar, který obsahuje obrázek – je to jako obrázek v rámu. 

Můžete přidat obrázek do snímku pomocí obrázkového rámu. Tímto způsobem můžete formátovat obrázek formátováním obrázkového rámu.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje zdarma převodníky—[JPEG do PowerPointu](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPointu](https://products.aspose.app/slides/cs/import/png-to-ppt)—které uživatelům umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvořit obrázkový rám**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) na základě šířky a výšky obrázku pomocí metody `addPictureFrame`, která je k dispozici u objektu tvaru přidruženého k odkazovanému snímku.
6. Přidejte obrázkový rám (obsahující obrázek) na snímek.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód vám ukazuje, jak vytvořit obrázkový rám:

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvoří instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá obrázkový rám se stejnou výškou a šířkou obrázku
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Zapíše soubor PPTX na disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 
Obrázkové rámy vám umožňují rychle vytvářet snímky prezentace založené na obrázcích. Když spojíte obrázkový rám s volbami ukládání Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu k převodu obrázků z jednoho formátu do druhého. Můžete si také prohlédnout tyto stránky: převést [obrázek do JPG](https://products.aspose.com/slides/cs/php-java/conversion/image-to-jpg/); převést [JPG na obrázek](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-image/); převést [JPG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-png/); převést [PNG na JPG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-jpg/); převést [PNG na SVG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-svg/); převést [SVG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Vytvořit obrázkový rám s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější obrázkový rám. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) související s objektem prezentace, který bude použit k vyplnění tvaru.
5. Zadejte relativní šířku a výšku obrázku v obrázkovém rámu.
6. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód vám ukazuje, jak vytvořit obrázkový rám s relativním měřítkem:

```php
  # Vytvořit instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvořit instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá obrázkový rám se stejnou výškou a šířkou jako obrázek
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Nastavuje relativní měřítko šířky a výšky
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Zapíše soubor PPTX na disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Extrahovat rastrové obrázky z obrázkových rámů**

Můžete extrahovat rastrové obrázky z objektů [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) a uložit je ve formátech PNG, JPG a dalších. Níže uvedený příklad kódu ukazuje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahovat SVG obrázky z obrázkových rámů**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) obsahuje SVG obsah, a poté tento obrázek uložit na disk nebo do proudu v jeho nativním SVG formátu.

Následující příklad kódu demonstruje, jak extrahovat SVG obrázek z obrázkového rámu:

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

## **Získat průhlednost obrázku**

Aspose.Slides umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento PHP kód demonstruje operaci:

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

## **Získat jas a kontrast obrázku**

Aspose.Slides umožňuje získat efekt jasu a kontrastu aplikovaný na obrázek. Třída [Luminance](https://reference.aspose.com/slides/cs/php-java/aspose.slides/luminance/) reprezentuje tento transformátor obrázku.

Tento PHP kód demonstruje, jak získat nastavení jasu a kontrastu z obrázkového rámu:

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

## **Formátování obrázkového rámu**

Aspose.Slides poskytuje mnoho možností formátování, které lze aplikovat na obrázkový rám. Pomocí těchto možností můžete upravit obrázkový rám tak, aby splňoval konkrétní požadavky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) související s objektem prezentace, který bude použit k vyplnění tvaru.
4. Zadejte šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) vystavené objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/) přidruženým k odkazovanému snímku.
6. Přidejte obrázkový rám (obsahující obrázek) na snímek.
7. Nastavte barvu čáry obrázkového rámu.
8. Nastavte šířku čáry obrázkového rámu.
9. Otočte obrázkový rám zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte obrázkový rám (obsahující obrázek) na snímek.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód demonstruje proces formátování obrázkového rámu:

```php
  # Vytvoří instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvoří instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá obrázkový rám se stejnou výškou a šířkou jako obrázek
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Aplikuje určité formátování na PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Zapíše soubor PPTX na disk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}
Aspose nedávno vyvinulo [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud někdy potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky z fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete tento servis použít. 
{{% /alert %}}

## **Přidat obrázek jako odkaz**

Aby se předešlo velkým velikostem prezentací, můžete obrázky (nebo videa) přidávat prostřednictvím odkazů místo vložení souborů přímo do prezentací. Tento PHP kód vám ukazuje, jak přidat obrázek a video do zástupce:

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

## **Oříznout obrázky**

Tento PHP kód vám ukazuje, jak oříznout existující obrázek na snímku:

```php
  $pres = new Presentation();
  # Vytvoří nový objekt obrázku
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
    # Přidá obrázkový rám na snímek
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Ořízne obrázek (procentuální hodnoty)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Uloží výsledek
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Smazat oříznuté oblasti obrázku**

Pokud chcete smazat oříznuté oblasti obrázku obsaženého v rámu, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Tato metoda vrátí oříznutý obrázek nebo původní obrázek, pokud oříznutí není nutné.

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Získá PictureFrame z prvního snímku
    $picFrame = $slide->getShapes()->get_Item(0);
    # Odstraní oříznuté oblasti obrázku PictureFrame a vrátí oříznutý obrázek
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Uloží výsledek
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v zpracovávaném [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se počet obrázků ve výsledné prezentaci zvýší.

Metoda převádí WMF/EMF metafily na rastrový PNG obrázek během ořezávací operace. 
{{% /alert %}}

## **Komprimovat obrázky**

Můžete komprimovat obrázek v prezentaci pomocí metody [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Tato metoda komprimuje obrázek snížením jeho velikosti na základě velikosti tvaru a zadaného rozlišení, s možností smazat oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Picture Format -> Compress Pictures -> Resolution**.

Následující PHP příklady demonstrují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelným odstraněním oříznutých oblastí:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimuje obrázek s cílovým rozlišením 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Zkontroluje výsledek komprese.
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

Nebo přímo použitím vlastního DPI hodnoty:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Komprimuje obrázek na 150 DPI (webové rozlišení), odstraňuje oříznuté oblasti.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také smazat pro optimalizaci velikosti souboru.  
Pokud je obrázek metafile (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG je také zachována nebo mírně snížena podle rozlišení, podobně jako PowerPoint zachází s vysoce rozlišenými JPEGy. 
{{% /alert %}}

## **Zamknout poměr stran**

Pokud chcete, aby tvar obsahující obrázek si zachoval poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) k nastavení volby *Lock Aspect Ratio*.

Tento PHP kód vám ukazuje, jak zamknout poměr stran tvaru:

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
    # nastavit tvar, aby zachoval poměr stran při změně velikosti
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru a ne obrázku, který obsahuje. 
{{% /alert %}}

## **Použít vlastnost StretchOff**

Pomocí metod [setStretchOffsetLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) a [setStretchOffsetBottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/) můžete specifikovat výplňový obdélník.

Když je pro obrázek specifikováno natahování, zdrojový obdélník je měněn tak, aby zaplnil zadaný výplňový obdélník. Každá hrana výplňového obdélníku je definována procentuálním posunem od odpovídající hrany ohraničovacího rámečku tvaru. Kladné procento určuje vnitřní odsazení, zatímco záporné procento určuje vnější výstupek.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek pro výplň tvaru.
8. Určete posuny obrázku od odpovídající hrany ohraničovacího rámečku tvaru.
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento PHP kód demonstruje proces, ve kterém je použita vlastnost StretchOff:

```php
  # Instancuje třídu Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Instancuje třídu ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá AutoShape nastavený na obdélník
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Nastaví typ výplně tvaru
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Nastaví režim výplně obrázkem tvaru
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Nastaví obrázek pro výplň tvaru
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Určí posuny obrázku od odpovídající hrany ohraničujícího rámečku tvaru
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Zapíše soubor PPTX na disk
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Často kladené otázky**

**Jak zjistit, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (např. SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá schopnosti motoru pro snímky a konverzi obrázků.

**Jaký dopad bude mít přidání desítek velkých obrázků na velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; prolinkování obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly přístupné. Aspose.Slides poskytuje možnost přidávat obrázky pomocí odkazu ke snížení velikosti souboru.

**Jak mohu zamknout objekt obrázku před neúmyslným posunutím nebo změnou velikosti?**

Použijte [shape locks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/getpictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) (např. zakázat posun nebo změnu velikosti). Zamykací mechanismus je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/).

**Zůstane vektorová věrnost SVG zachována při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) jako originální vektor. Při [exportu do PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/php-java/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastaveních exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním při extrakci.