---
title: Zarządzanie ramkami obrazu w prezentacjach za pomocą PHP
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/php-java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- dodaj obraz
- utwórz obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz wektorowy
- przytnij obraz
- przycięty obszar
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skalowanie względne
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides for PHP via Java. Usprawnij swoją pracę i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramka obrazu to kształt, który zawiera obraz - jest to jak zdjęcie w ramce.  

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 

Aspose udostępnia darmowe konwertery —[JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które umożliwiają szybkie tworzenie prezentacji z obrazów. 

{{% /alert %}} 

## **Utworzenie ramki obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) na podstawie szerokości i wysokości obrazu przy użyciu metody `addPictureFrame` udostępnionej przez obiekt shape powiązany z wybranym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod PHP pokazuje, jak utworzyć ramkę obrazu:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Tworzy instancję klasy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Dodaje ramkę obrazu z wysokością i szerokością odpowiadającą obrazowi
    $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Zapisuje plik PPTX na dysk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="warning" %}} 

Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji na podstawie obrazów. Łącząc ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny. Możesz także zobaczyć te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/php-java/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/php-java/conversion/svg-to-png/). 

{{% /alert %}}

## **Utworzenie ramki obrazu ze skalowaniem względnym**

Modyfikując względne skalowanie obrazu, możesz stworzyć bardziej złożoną ramkę obrazu.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Dodaj obraz do kolekcji obrazów prezentacji.  
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod PHP pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobierz pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Utwórz instancję klasy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Dodaj ramkę obrazu z wysokością i szerokością równą obrazowi
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Ustawianie względnej skali szerokości i wysokości
    $pf->setRelativeScaleHeight(0.8);
    $pf->setRelativeScaleWidth(1.35);
    # Zapisz plik PPTX na dysk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu pokazuje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

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

## **Wyodrębnianie obrazów SVG z ramek obrazu**

Kiedy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/), Aspose.Slides for PHP via Java umożliwia pobranie oryginalnych obrazów wektorowych z pełną wiernością. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/), sprawdzić, czy powiązany [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w jego natywnym formacie SVG.

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

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

## **Uzyskanie przezroczystości obrazu**

Aspose.Slides pozwala uzyskać efekt przezroczystości zastosowany do obrazu. Ten kod PHP demonstruje operację:

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

## **Uzyskanie jasności i kontrastu obrazu**

Aspose.Slides pozwala uzyskać efekty jasności i kontrastu zastosowane do obrazu. Klasa [Luminance](https://reference.aspose.com/slides/pl/php-java/aspose.slides/luminance/) reprezentuje tę transformację obrazu.

Ten kod PHP demonstruje, jak uzyskać ustawienia jasności i kontrastu z ramki obrazu:

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

## **Formatowanie ramki obrazu**

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmodyfikować ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przez dodanie obrazu do [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu przy użyciu metody [addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/) powiązany z wybranym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Ustaw kolor linii ramki obrazu.  
8. Ustaw szerokość linii ramki obrazu.  
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.  
   * Wartość dodatnia obraca obraz zgodnie z ruchem wskazówek zegara.  
   * Wartość ujemna obraca obraz przeciwnie do ruchu wskazówek zegara.  
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod PHP demonstruje proces formatowania ramki obrazu:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd
    $sld = $pres->getSlides()->get_Item(0);
    # Tworzy instancję klasy Image
    $imgx = $pres->getImages()->addImage(new Java("java.io.FileInputStream", new Java("java.io.File", "asp1.jpg")));
    # Dodaje ramkę obrazu z wysokością i szerokością równą obrazowi
    $pf = $sld->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 150, $imgx->getWidth(), $imgx->getHeight(), $imgx);
    # Zastosowuje pewne formatowanie do PictureFrameEx
    $pf->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pf->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pf->getLineFormat()->setWidth(20);
    $pf->setRotation(45);
    # Zapisuje plik PPTX na dysk
    $pres->save("RectPicFrame.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Tip" color="primary" %}}

Aspose niedawno opracował darmowy [Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli potrzebujesz połączyć obrazy JPG/JPEG lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 

{{% /alert %}}

## **Dodanie obrazu jako odnośnika**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodawać obrazy (lub wideo) za pomocą odnośników zamiast osadzania plików bezpośrednio w prezentacjach. Ten kod PHP pokazuje, jak dodać obraz i wideo do placeholdera:

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

## **Przycinanie obrazów**

Ten kod PHP pokazuje, jak przyciąć istniejący obraz na slajdzie:

```php
  $pres = new Presentation();
  # Tworzy nowy obiekt obrazu
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
    # Dodaje ramkę obrazu do slajdu
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 100, 100, 420, 250, $picture);
    # Przycina obraz (wartości procentowe)
    $picFrame->getPictureFormat()->setCropLeft(23.6);
    $picFrame->getPictureFormat()->setCropRight(21.5);
    $picFrame->getPictureFormat()->setCropTop(3);
    $picFrame->getPictureFormat()->setCropBottom(31);
    # Zapisuje wynik
    $pres->save($outPptxFile, SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Usuwanie przyciętych obszarów ramki obrazu**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas). Metoda zwraca przycięty obraz lub obraz oryginalny, jeśli przycinanie nie jest konieczne.

Ten kod PHP demonstruje operację:

```php
  $presentation = new Presentation("PictureFrameCrop.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Pobiera ramkę obrazu z pierwszego slajdu
    $picFrame = $slide->getShapes()->get_Item(0);
    # Usuwa przycięte obszary obrazu w ramce obrazu i zwraca przycięty obraz
    $croppedImage = $picFrame->getPictureFormat()->deletePictureCroppedAreas();
    # Zapisuje wynik
    $presentation->save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany tylko w przetwarzanej [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/), takie rozwiązanie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.

Metoda konwertuje metafile WMF/EMF na rastrowy obraz PNG w trakcie operacji przycinania. 

{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji przy użyciu metody [PictureFillFormat::compressImage()](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_). Metoda ta kompresuje obraz, zmniejszając jego rozmiar w zależności od rozmiaru kształtu i określonej rozdzielczości, z opcją usunięcia przyciętych obszarów.

Działa to podobnie jak funkcja PowerPoint **Picture Format -> Compress Pictures -> Resolution**.

Poniższe przykłady PHP demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Skompresuj obraz do docelowej rozdzielczości 150 DPI (rozdzielczość sieciowa) i usuń przycięte obszary.
    $result = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);

    # Sprawdź wynik kompresji.
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

Lub używając bezpośrednio własnej wartości DPI:

```php
$presentation = new Presentation("demo.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->get_Item(0);

    # Skompresuj obraz do 150 DPI (rozdzielczość sieciowa), usuwając przycięte obszary.
    $pictureFrame->getPictureFormat()->compressImage(true, 150.0);

    $presentation->save("CompressedImage.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w zależności od rozmiaru kształtu i podanego DPI. Przycięte fragmenty mogą także zostać usunięte w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.

{{% /alert %}}

## **Zablokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) w celu ustawienia opcji *Lock Aspect Ratio*.

Ten kod PHP pokazuje, jak zablokować proporcje kształtu:

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
    # ustaw kształt, aby zachował proporcje przy skalowaniu
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="NOTE" color="warning" %}} 

Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje kształtu, a nie obrazu, który zawiera. 

{{% /alert %}}

## **Użycie właściwości StretchOff**

Korzystając z metod [setStretchOffsetLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/setstretchoffsetleft/), [setStretchOffsetTop](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/setstretchoffsettop/), [setStretchOffsetRight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/setstretchoffsetright/) oraz [setStretchOffsetBottom](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/setstretchoffsetbottom/) z klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/), możesz określić prostokąt wypełnienia.

Gdy określone jest rozciąganie obrazu, prostokąt źródłowy jest skalowany, aby dopasować się do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana jako procentowy offset od odpowiedniej krawędzi ramki ograniczającej kształt. Procent dodatni określa wcięcie, a ujemny występ.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Dodaj prostokąt `AutoShape`.  
4. Utwórz obraz.  
5. Ustaw typ wypełnienia kształtu.  
6. Ustaw tryb wypełnienia obrazu kształtu.  
7. Dodaj ustawiony obraz, aby wypełnić kształt.  
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt.  
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod PHP demonstruje proces, w którym używana jest właściwość StretchOff:

```php
  # Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
  $pres = new Presentation();
  try {
    # Pobiera pierwszy slajd
    $slide = $pres->getSlides()->get_Item(0);
    # Tworzy instancję klasy ImageEx
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Dodaje AutoShape ustawiony jako prostokąt
    $aShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);
    # Ustawia typ wypełnienia kształtu
    $aShape->getFillFormat()->setFillType(FillType::Picture);
    # Ustawia tryb wypełnienia obrazu kształtu
    $aShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Ustawia obraz, aby wypełnił kształt
    $aShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Określa przesunięcia obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetLeft(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetRight(25);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetTop(-20);
    $aShape->getFillFormat()->getPictureFillFormat()->setStretchOffsetBottom(-10);
    # Zapisuje plik PPTX na dysk
    $pres->save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Jak mogę sprawdzić, które formaty obrazów są obsługiwane przez PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i wektorowe (np. SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać mniejszy rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne były dostępne. Aspose.Slides umożliwia dodawanie obrazów jako odnośników, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przesuwaniem lub skalowaniem?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/getpictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) (np. wyłączenia przesuwania lub skalowania). Mechanizm blokady jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksportowaniu do PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/php-java/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzony przez zachowanie przy wyodrębnianiu.