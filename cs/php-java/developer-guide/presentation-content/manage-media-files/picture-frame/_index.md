---
title: Správa rámů obrázků v prezentacích pomocí PHP
linktitle: Rám obrázku
type: docs
weight: 10
url: /cs/php-java/picture-frame/
keywords:
- rám obrázku
- přidat rám obrázku
- vytvořit rám obrázku
- přidat obrázek
- vytvořit obrázek
- extrahovat obrázek
- rastrový obrázek
- vektorový obrázek
- oříznout obrázek
- oříznutá oblast
- vlastnost StretchOff
- formátování rámu obrázku
- vlastnosti rámu obrázku
- relativní měřítko
- efekt obrázku
- poměr stran
- průhlednost obrázku
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Přidejte rámové obrázky do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Zjednodušte svůj pracovní postup a vylepšete návrhy snímků."
---
## **Úvod**

Rám obrazu je tvar, který obsahuje obrázek—je to jako obrázek v rámu.  

Můžete přidat obrázek do snímku pomocí rámu obrazu. Tímto způsobem můžete formátovat obrázek úpravou rámu obrazu.

{{% alert  title="Tip" color="primary" %}} 
Aspose poskytuje bezplatné konvertory—[JPEG do PowerPoint](https://products.aspose.app/slides/cs/import/jpg-to-ppt) a [PNG do PowerPoint](https://products.aspose.app/slides/cs/import/png-to-ppt)—které umožňují rychle vytvářet prezentace z obrázků. 
{{% /alert %}} 

## **Vytvoření rámu obrazu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/), která je součástí objektu prezentace a bude použita k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) na základě šířky a výšky obrázku pomocí metody `addPictureFrame` vystavěné objektem tvaru přidruženým k referencovanému snímku.
6. Přidejte rám obrazu (obsahující obrázek) do snímku.
7. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvoří instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá rám obrázku s odpovídající výškou a šířkou obrázku
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
Rám obrazu vám umožňuje rychle vytvářet snímky prezentace založené na obrázcích. Když spojíte rám obrazu s možnostmi ukládání v Aspose.Slides, můžete manipulovat s operacemi vstupu/výstupu pro konverzi obrázků z jednoho formátu do druhého. Můžete si prohlédnout následující stránky: převod [obrázku na JPG](https://products.aspose.com/slides/cs/php-java/conversion/image-to-jpg/); převod [JPG na obrázek](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-image/); převod [JPG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/jpg-to-png/), převod [PNG na JPG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-jpg/); převod [PNG na SVG](https://products.aspose.com/slides/cs/php-java/conversion/png-to-svg/), převod [SVG na PNG](https://products.aspose.com/slides/cs/php-java/conversion/svg-to-png/). 
{{% /alert %}}

## **Vytvoření rámu obrazu s relativním měřítkem**

Úpravou relativního měřítka obrázku můžete vytvořit složitější rám obrazu. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Přidejte obrázek do kolekce obrázků prezentace.
4. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) související s objektem prezentace, který bude použit k vyplnění tvaru.
5. Určete relativní šířku a výšku obrázku v rámci obrazu.
6. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvoří instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytvoří instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá rámeček obrázku s výškou a šířkou odpovídající obrázku
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Nastavuje relativní měřítko výšky a šířky
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

## **Extrahování rastrových obrázků z rámů obrazu**

Z [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) objektů můžete extrahovat rastrové obrázky a uložit je ve formátech PNG, JPG a dalších. Níže uvedený ukázkový kód demonstruje, jak extrahovat obrázek z dokumentu „sample.pptx“ a uložit jej ve formátu PNG.

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

## **Extrahování SVG obrázků z rámů obrazu**

Když prezentace obsahuje SVG grafiku umístěnou uvnitř tvarů [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), Aspose.Slides pro PHP přes Java vám umožní získat původní vektorové obrázky s plnou věrností. Procházením kolekce tvarů snímku můžete identifikovat každý [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), zkontrolovat, zda podkladový [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) obsahuje SVG obsah, a poté uložit tento obrázek na disk nebo do proudu v jeho nativním SVG formátu.

Následující ukázkový kód demonstruje, jak extrahovat SVG obrázek z rámu obrazu:

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

## **Získání průhlednosti obrázku**

Aspose.Slides vám umožňuje získat efekt průhlednosti aplikovaný na obrázek. Tento PHP kód demonstruje operaci:

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

## **Formátování rámu obrazu**

Aspose.Slides poskytuje mnoho možností formátování, které lze použít na rám obrazu. Pomocí těchto možností můžete upravit rám obrazu tak, aby splňoval konkrétní požadavky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/ppimage/) přidáním obrázku do [ImageCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/imagecollection/) související s objektem prezentace, který bude použit k vyplnění tvaru.
4. Určete šířku a výšku obrázku.
5. Vytvořte `PictureFrame` na základě šířky a výšky obrázku pomocí metody [addPictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/addpictureframe/) vystavěné objektem [ShapeCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/) přidruženým k referencovanému snímku.
6. Přidejte rám obrazu (obsahující obrázek) do snímku.
7. Nastavte barvu čáry rámu obrazu.
8. Nastavte šířku čáry rámu obrazu.
9. Otáčejte rám obrazu zadáním kladné nebo záporné hodnoty.
   * Kladná hodnota otáčí obrázek po směru hodinových ručiček. 
   * Záporná hodnota otáčí obrázek proti směru hodinových ručiček.
10. Přidejte rám obrazu (obsahující obrázek) do snímku.
11. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytváří instanci třídy Presentation, která představuje PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $sld = $pres->getSlides()->get_Item(0);
    # Vytváří instanci třídy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Přidá rám obrázku s výškou a šířkou odpovídající obrázku
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
Aspose nedávno vyvinulo [bezplatný Collage Maker](https://products.aspose.app/slides/cs/collage). Pokud někdy potřebujete [sloučit JPG/JPEG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG obrázky, [vytvořit mřížky ze fotografií](https://products.aspose.app/slides/cs/collage/photo-grid), můžete tento službu využít. 
{{% /alert %}}

## **Přidání obrázku jako odkazu**

Aby se předešlo velkým velikostem prezentací, můžete přidávat obrázky (nebo videa) pomocí odkazů místo vkládání souborů přímo do prezentací. Tento PHP kód vám ukazuje, jak přidat obrázek a video do zástupce:

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

## **Oříznutí obrázků**

Tento PHP kód vám ukazuje, jak oříznout existující obrázek na snímku:

```php
  $pres = new Presentation();
  # Vytváří nový objekt obrázku
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
    # Přidá PictureFrame do snímku
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

## **Odstranění oříznutých oblastí z rámu obrazu**

Pokud chcete odstranit oříznuté oblasti obrázku obsaženého v rámci, můžete použít metodu [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Tato metoda vrací oříznutý obrázek nebo originální obrázek, pokud není ořez nutný.

Tento PHP kód demonstruje operaci:

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
Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) přidává oříznutý obrázek do kolekce obrázků prezentace. Pokud je obrázek použit pouze v zpracovaném [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/), může toto nastavení snížit velikost prezentace. V opačném případě se počet obrázků v výsledné prezentaci zvýší.

Tato metoda při operaci ořezávání převádí metafily WMF/EMF na rastrový PNG obrázek. 
{{% /alert %}}

## **Komprese obrázků**

Můžete komprimovat obrázek v prezentaci pomocí metody [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) . Tato metoda komprimuje obrázek snížením jeho velikosti podle velikosti tvaru a zadaného rozlišení, s možností odstranit oříznuté oblasti.

Upravuje velikost a rozlišení obrázku podobně jako funkce PowerPointu **Formát obrázku -> Komprimovat obrázky -> Rozlišení**.

Následující PHP příklady ukazují, jak komprimovat obrázek v prezentaci zadáním cílového rozlišení a volitelně odstraněním oříznutých oblastí:

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

Nebo přímo použitím vlastní hodnoty DPI:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Zkomprimuje obrázek na 150 DPI (webové rozlišení) a odstraní oříznuté oblasti.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 
Metoda převádí obrázek na nižší rozlišení na základě velikosti tvaru a zadaného DPI. Oříznuté oblasti lze také odstranit pro optimalizaci velikosti souboru.  
Pokud je obrázek metafilem (WMF/EMF) nebo SVG, komprese se nepoužije. Kvalita JPEG je zachována nebo mírně snížena v závislosti na rozlišení, podobně jako PowerPoint zachází s JPEG obrázky vysokého rozlišení. 
{{% /alert %}}

## **Zamčení poměru stran**

Pokud chcete, aby tvar obsahující obrázek zachoval svůj poměr stran i po změně rozměrů obrázku, můžete použít metodu [setAspectRatioLocked](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) , která nastaví volbu *Lock Aspect Ratio*.

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
    # nastavit tvar, aby při změně velikosti zachovával poměr stran
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 
Toto nastavení *Lock Aspect Ratio* zachovává pouze poměr stran tvaru, nikoli obrázku, který obsahuje. 
{{% /alert %}}

## **Použití vlastnosti StretchOff**

Pomocí metod [setStretchOffsetLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) a [setStretchOffsetBottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) ze třídy [PictureFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/picturefillformat/), můžete určit výplňový obdélník.

Když je pro obrázek specifikováno roztahování, zdrojový obdélník je měněn tak, aby zapadl do zadaného výplňového obdélníku. Každý okraj výplňového obdélníku je definován procentuální odchylkou od odpovídajícího okraje ohraničujícího rámečku tvaru. Kladné procento určuje vnitřní odsazení, záporné procento pak vnější odsazení.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte obdélník `AutoShape`. 
4. Vytvořte obrázek.
5. Nastavte typ výplně tvaru.
6. Nastavte režim výplně obrázkem tvaru.
7. Přidejte nastavený obrázek pro výplň tvaru.
8. Určete odsazení obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
9. Uložte upravenou prezentaci jako soubor PPTX.

```php
  # Vytvoří instanci třídy Presentation, která představuje soubor PPTX
  $pres = new Presentation();
  try {
    # Získá první snímek
    $slide = $pres->getSlides()->get_Item(0);
    # Vytvoří instanci třídy ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Přidá AutoShape nastavený na Rectangle
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Nastaví typ výplně tvaru
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Nastaví režim výplně obrázkem tvaru
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Nastaví obrázek, který vyplní tvar
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Určí odsazení obrázku od odpovídajícího okraje ohraničujícího rámečku tvaru
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

## **FAQ**

**Jak zjistím, které formáty obrázků jsou podporovány pro PictureFrame?**

Aspose.Slides podporuje jak rastrové obrázky (PNG, JPEG, BMP, GIF atd.), tak vektorové obrázky (například SVG) prostřednictvím objektu obrázku přiřazeného k [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/). Seznam podporovaných formátů obecně překrývá možnosti motoru pro konverzi snímků a obrázků.

**Jaký vliv bude mít přidání desítek velkých obrázků na velikost a výkon PPTX?**

Vkládání velkých obrázků zvyšuje velikost souboru a spotřebu paměti; propojení obrázků pomáhá udržet velikost prezentace nízkou, ale vyžaduje, aby externí soubory zůstaly přístupné. Aspose.Slides poskytuje možnost přidávat obrázky pomocí odkazu pro snížení velikosti souboru.

**Jak mohu zamknout objekt obrázku před náhodným přesunutím/změnou velikosti?**

Použijte [shape locks](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/getpictureframelock/) pro [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) (například zakázáním přesunu nebo změny velikosti). Mechanismus zamykání je podporován pro různé typy tvarů, včetně [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/).

**Je zachována vektorová věrnost SVG při exportu prezentace do PDF/obrázků?**

Aspose.Slides umožňuje extrahovat SVG z [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) jako originální vektor. Při [exportu do PDF](/slides/cs/php-java/convert-powerpoint-to-pdf/) nebo [rasterových formátů](/slides/cs/php-java/convert-powerpoint-to-png/) může být výsledek rasterizován v závislosti na nastavení exportu; fakt, že původní SVG je uložen jako vektor, je potvrzen chováním extrakce.