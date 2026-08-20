---
title: Zarządzanie ramkami obrazu w prezentacjach przy użyciu PHP
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/php-java/picture-frame/
keywords:
  - ramka obrazu
  - dodaj ramkę obrazu
  - utwórz ramkę obrazu
  - osadzony obraz
  - powiązany obraz
  - wyodrębnij obraz
  - obraz rastrowy
  - obraz SVG
  - przytnij obraz
  - usuń przycięte obszary
  - skompresuj obraz
  - StretchOffset
  - formatowanie ramki obrazu
  - skala względna
  - efekt obrazu
  - proporcje
  - PowerPoint
  - OpenDocument
  - prezentacja
  - PHP
  - Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach za pomocą Aspose.Slides dla PHP poprzez Java."
---
## **Przegląd**

Ramka obrazu to kształt slajdu, który wyświetla obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zarządza osadzonymi zasobami obrazu poprzez swoją [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/), podczas gdy [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) kontroluje położenie obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą także odwoływać się do obrazów powiązanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany, zanim zastosujesz formatowanie lub optymalizację.

## **Dodaj i sformatuj osadzony obraz**

Dla obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu za pomocą [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę o natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $pictureFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pictureFrame->getLineFormat()->setWidth(3);
    $pictureFrame->setRotation(15);

    $presentation->save("picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skalowania względnego**

[PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) udostępnia skalowanie względne szerokości i wysokości ramki za pomocą [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/setrelativescalewidth/) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Wartość `1.0` odpowiada 100 % pierwotnego rozmiaru obrazu. Skalowanie względne jest przydatne, gdy proces wymaga zachowania relacji do rozmiaru źródłowego obrazu zamiast ręcznego obliczania ostatecznych wymiarów.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $image);
    $pictureFrame->setRelativeScaleWidth(1.35);
    $pictureFrame->setRelativeScaleHeight(0.8);

    $presentation->save("relative-scale.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Skalowanie względne zmienia ustawienia skali ramki; nie przetwarza ani nie kompresuje osadzonego obrazu.

## **Obrazy osadzone i powiązane**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod kątem przenośności i przewidywalnego renderowania. Obraz powiązany przechowuje zewnętrzną lokalizację za pomocą metody [Picture::setLinkPathLong](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/setlinkpathlong/) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy powiązane mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zewnętrzne zależności. Powiązany plik musi pozostać dostępny dla aplikacji, która otwiera lub renderuje prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób stanie się niedostępny, powiązany obraz może nie być wyświetlany zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zwykle bardziej niezawodne.

### **Dodaj obraz powiązany**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie powiązań obrazów; powiązania wideo to osobny przepływ multimediów i celowo nie są mieszane w tym przykładzie.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 320, 180, null);
    $linkedImageFile = new Java("java.io.File", "linked-image.jpg");
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong($linkedImageFile->getAbsolutePath());

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Używaj powiązań, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały PPTX z uszkodzonymi zależnościami obrazów jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest rzeczywiście [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) i czy zawiera osadzony obraz. Powiązane ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        if (java_is_null($embeddedImage) || !java_is_null($embeddedImage->getSvgImage())) {
            continue;
        }

        $rasterImage = $embeddedImage->getImage();
        try {
            $rasterImage->save("extracted-image.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($rasterImage)) {
                $rasterImage->dispose();
            }
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Zapisywanie przy użyciu [IImage::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/#save) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie przetworzonego pliku rastrowego, użyj binarnych danych zasobu obrazu.

### **Wyodrębnij obraz SVG**

Dla obrazu SVG, [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) udostępnia obiekt [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast najpierw rasteryzować obraz.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            continue;
        }

        $embeddedImage = $shape->getPictureFormat()->getPicture()->getImage();
        $svgImage = java_is_null($embeddedImage) ? null : $embeddedImage->getSvgImage();
        if ($svgImage === null || java_is_null($svgImage)) {
            continue;
        }

        $outputStream = new Java("java.io.FileOutputStream", "extracted-image.svg");
        try {
            $outputStream->write($svgImage->getSvgData());
        } finally {
            $outputStream->close();
        }
        break;
    }
} finally {
    $presentation->dispose();
}
```

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło wewnątrz prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, koniecznie renderują tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako dokładna kopia oryginalnego osadzonego SVG; użyj danych [SvgImage::getSvgData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/getsvgdata/) gdy wymagany jest sam zasób wektorowy.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia na [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie początkowo nie usuwa ukrytych pikseli z osadzonego obrazu; zmienia tylko widoczny obszar.

Poniższy przykład znajduje ramkę obrazu w bezpieczny sposób i stosuje wartości przycięcia:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $pictureFrame->getPictureFormat()->setCropLeft(23.6);
        $pictureFrame->getPictureFormat()->setCropRight(21.5);
        $pictureFrame->getPictureFormat()->setCropTop(3);
        $pictureFrame->getPictureFormat()->setCropBottom(31);
        $presentation->save("cropped-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie można zmienić później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte obszary mogą być fizycznie usunięte, jak opisano w kolejnej sekcji.

## **Usuń przycięte dane obrazu**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) usuwa dane obrazu spoza bieżącego prostokąta przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji cofania przycięcia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("cropped-image.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $croppedImage = $pictureFrame->getPictureFormat()->deletePictureCroppedAreas();
        if (!java_is_null($croppedImage)) {
            $presentation->save("cropped-data-removed.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest także używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte obszary w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiarem lub przycięty oraz `false`, gdy nie było potrzeby zmian.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturescompression/) gdy wystarczy standardowa docelowa rozdzielczość:

```php
use aspose\slides\PicturesCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $compressed = $pictureFrame->getPictureFormat()->compressImage(true, PicturesCompression::Dpi150);
        echo $compressed ? "The image was compressed." : "No compression was necessary.";
        $presentation->save("compressed-image.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Zamiast wartości predefiniowanej można podać własną dodatnią wartość DPI, gdy wymagana jest konkretna rozdzielczość docelowa.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metafile nie jest zmniejszana przez ten proces kompresji rastrowej. Pamiętaj również, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie faktycznie oglądany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Sprawdź efekty obrazu**

Efekty obrazu są przechowywane na obrazie używanym przez ramkę. Kolekcja transformacji obrazu może zawierać efekty takie jak stała modulacja alfa dla przejrzystości oraz luminancja dla jasności i kontrastu. Poniższy przykład bezpiecznie odczytuje oba rodzaje efektów z pierwszej ramki obrazu na slajdzie:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $effect = $imageTransform->get_Item($index);

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $transparency = 100 - java_values($effect->getAmount());
                echo "Transparency: " . $transparency . PHP_EOL;
            }

            if (java_instanceof($effect, new JavaClass("com.aspose.slides.Luminance"))) {
                $luminance = $effect->getEffective();
                echo "Brightness: " . java_values($luminance->getBrightness()) . PHP_EOL;
                echo "Contrast: " . java_values($luminance->getContrast()) . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Efekty te zmieniają sposób renderowania obrazu w ramce; nie przepisują oryginalnych bajtów osadzonego obrazu.

## **Zablokuj geometrię ramki obrazu**

Ustawienia [PictureFrameLock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframelock/setaspectratiolocked/) zachowuje proporcje kształtu podczas zmiany rozmiaru.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.jpg");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 100, $image->getWidth(), $image->getHeight(), $image);
    $pictureFrame->getPictureFrameLock()->setAspectRatioLocked(true);

    $presentation->save("locked-picture-frame.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona przetworzenia ani trwałej zmiany proporcji obrazu źródłowego.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu to rozciąganie, wartości stretch‑offset na [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Pozytywne procenty tworzą wcięcie od krawędzi, a negatywne procenty tworzą wystawienie.

Jest to różne od przycinania. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w który widoczne wypełnienie obrazu jest rozciągane.

```php
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 400, 300, $image);
    $pictureFrame->getPictureFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $pictureFrame->getPictureFormat()->setStretchOffsetLeft(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetRight(12);
    $pictureFrame->getPictureFormat()->setStretchOffsetTop(8);
    $pictureFrame->getPictureFormat()->setStretchOffsetBottom(8);

    $presentation->save("stretch-offsets.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Używaj offsetów rozciągnięcia do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i kwestie eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Osadzone obrazy** sprawiają, że prezentacja jest samodzielna i są najbardziej niezawodne przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Powiązane obrazy** mogą utrzymać pakiet mniejszy, ale prezentacja zależy od dostępności zewnętrznych plików pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo niedestrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną wyraźnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem rozdzielczości źródłowej. Powinna być stosowana po określeniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać w formacie SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdów do formatu rastrowego zawsze konwertuje renderowany slajd na piksele.
- **Powtarzające się obrazy** powinny ponownie używać istniejącego zasobu [PPImage], gdy to możliwe, zamiast wielokrotnego ładowania tego samego pliku w procesie tworzenia prezentacji.

Dla dużych prezentacji optymalizacja obrazów jest zwykle najskuteczniejsza, gdy jest wykonywana selektywnie: trzymaj logotypy i diagramy jako treść wektorową, kompresuj fotografie zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj zewnętrznych linków, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) reprezentuje zasób obrazu powiązany z prezentacją. [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy powiązywać obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Powiązuj obrazy tylko wtedy, gdy celowe jest przechowywanie plików obrazu poza PPTX i zewnętrzne lokalizacje mogą być utrzymane w sposób niezawodny.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podkładowe piksele. Użyj [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może obniżyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak powinny być obsługiwane obrazy SVG?**

Zachowaj treść SVG jako SVG, gdy zależy Ci na wierności wektorowej. Osadzony [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) można wyodrębnić bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy czytaniu istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Kontrola `java_instanceof` przeciwko [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala obsłużyć slajdy, które nie zawierają ramek obrazu.