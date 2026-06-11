---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu PHP
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/php-java/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zamień obraz
- zamień zdjęcie
- z sieci
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy pomocy Aspose.Slides dla PHP przez Java, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i interesujące. W Microsoft PowerPoint możesz wstawiać obrazy z pliku, internetu lub innych miejsc na slajdy. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów w Twoich prezentacjach przy użyciu różnych metod. 

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia darmowe konwertery—[JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—pozwalające szybko tworzyć prezentacje z obrazów. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jeśli chcesz dodać obraz jako obiekt ramki — szczególnie jeśli zamierzasz używać standardowych opcji formatowania, aby zmienić jego rozmiar, dodać efekty itd. — zobacz [Ramkę obrazu](/slides/pl/php-java/picture-frame/).
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Możesz manipulować operacjami wejścia/wyjścia obejmującymi obrazy i prezentacje PowerPoint, aby konwertować obraz z jednego formatu na inny. Zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/php-java/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-png/); konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-svg/); konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides obsługuje operacje na obrazach w następujących popularnych formatach: JPEG, PNG, GIF i inne. 

## **Dodaj obrazy przechowywane lokalnie do slajdów**

Możesz dodać jeden lub wiele obrazów z komputera na slajd w prezentacji. Ten przykładowy kod pokazuje, jak dodać obraz do slajdu:

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

## **Dodaj obrazy z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na Twoim komputerze, możesz dodać go bezpośrednio z sieci. 

Ten przykładowy kod pokazuje, jak dodać obraz z sieci do slajdu :

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

## **Dodaj obrazy do mistrza slajdów**

Mistrz slajdu (slide master) jest najważniejszym slajdem, który przechowuje i kontroluje informacje (motyw, układ itp.) o wszystkich slajdach pod nim. Dlatego, gdy dodasz obraz do mistrza slajdu, obraz ten pojawi się na każdym slajdzie pod tym mistrzem. 

Ten przykładowy kod Java pokazuje, jak dodać obraz do mistrza slajdu:

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

## **Dodaj obrazy jako tło slajdu**

Możesz zdecydować się użyć obrazu jako tła dla konkretnego slajdu lub kilku slajdów. W takim przypadku musisz sprawdzić, jak [Ustawić obraz jako tło slajdu](/slides/pl/php-java/presentation-background/#set-an-image-as-a-slide-background).

## **Dodaj SVG do prezentacji**
Możesz dodać lub wstawić dowolny obraz do prezentacji, używając metody [addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/) należącej do klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/).

Aby utworzyć obiekt obrazu na podstawie obrazu SVG, możesz zrobić to w ten sposób:

1. Utwórz obiekt SvgImage, aby wstawić go do ImageShapeCollection
2. Utwórz obiekt PPImage z ISvgImage
3. Utwórz obiekt PictureFrame przy użyciu klasy PPImage

Ten przykładowy kod pokazuje, jak wdrożyć powyższe kroki, aby dodać obraz SVG do prezentacji:
```php
  # Utwórz instancję klasy Presentation reprezentującej plik PPTX
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

## **Konwertuj SVG do zestawu kształtów**
Konwersja SVG do zestawu kształtów w Aspose.Slides jest podobna do funkcji PowerPoint, używanej do pracy z obrazami SVG:

![Menu podręczne PowerPoint](img_01_01.png)

Funkcjonalność jest udostępniana przez jedną z przeciążeń metody [addGroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addgroupshape/) klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/), która przyjmuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) jako pierwszy argument.

Ten przykładowy kod pokazuje, jak użyć opisanej metody do konwersji pliku SVG na zestaw kształtów:

```php
  # Utwórz nową prezentację
  $presentation = new Presentation();
  try {
    # Odczytaj zawartość pliku SVG
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

    # Utwórz obiekt SvgImage
    $svgImage = new SvgImage($svgContent);
    # Pobierz rozmiar slajdu
    $slideSize = $presentation->getSlideSize()->getSize();
    # Konwertuj obraz SVG na grupę kształtów, skalując go do rozmiaru slajdu
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape($svgImage, 0.0, 0.0, $slideSize->getWidth(), $slideSize->getHeight());
    # Zapisz prezentację w formacie PPTX
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Dodaj obrazy jako EMF do slajdów**
Aspose.Slides for PHP via Java umożliwia generowanie obrazów EMF z arkuszy Excel i dodawanie tych obrazów jako EMF na slajdach przy użyciu Aspose.Cells. 

Ten przykładowy kod pokazuje, jak wykonać opisane zadanie:

```php
  $book = new Workbook("chart.xlsx");
  $sheet = $book->getWorksheets()->get(0);
  $options = new ImageOrPrintOptions();
  $options->setHorizontalResolution(200);
  $options->setVerticalResolution(200);
  $options->setImageType(ImageType::EMF);
  # Zapisz skoroszyt do strumienia
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

## **Zastąp obrazy w kolekcji obrazów**

Aspose.Slides pozwala zastąpić obrazy przechowywane w kolekcji obrazów prezentacji (w tym te używane przez kształty slajdów). Ten rozdział prezentuje kilka podejść do aktualizacji obrazów w kolekcji. API udostępnia proste metody zastąpienia obrazu przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) lub innego obrazu już istniejącego w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/).
2. Wczytaj nowy obraz z pliku do tablicy bajtów.
3. Zastąp docelowy obraz nowym obrazem używając tablicy bajtów.
4. W drugim podejściu wczytaj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new Java("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Drugi sposób.
    $newImage = Images::fromFile("image1.png");
    $oldImage = $presentation->getImages()->get_Item(1);
    $oldImage->replaceImage($newImage);
    $newImage->dispose();
    
    // Trzeci sposób.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));
    
    // Zapisz prezentację do pliku.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Korzystając z darmowego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować teksty, tworzyć GIFy z tekstów itp. 
{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [obraz](/slides/pl/php-java/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób, aby jednocześnie zamienić to samo logo na dziesiątkach slajdów?**

Umieść logo na slajdzie mistrza lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany zostaną rozpowszechnione do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony plik SVG można przekonwertować na edytowalne kształty?**

Tak. Możesz przekonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak mogę ustawić obraz jako tło kilku slajdów jednocześnie?**

[Ustaw obraz jako tło](/slides/pl/php-java/presentation-background/) na slajdzie mistrza lub odpowiednim układzie — wszystkie slajdy korzystające z tego mistrza/układu odziedziczą tło.

**Jak zapobiec „rozrostowi” prezentacji z powodu wielu obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i umieszczaj powtarzające się grafiki w mistrzu, gdzie to ma sens.