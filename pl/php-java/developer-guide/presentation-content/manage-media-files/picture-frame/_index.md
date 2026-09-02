---
title: Zarządzanie ramkami obrazów w prezentacjach przy użyciu PHP
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/php-java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- obraz osadzony
- obraz linkowany
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- kompresuj obraz
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
description: "Twórz, formatuj, linkuj, przycinaj, wyodrębniaj i kompresuj ramki obrazów w prezentacjach za pomocą Aspose.Slides dla PHP przez Java."
---
## **Przegląd**

Obrazek‑ramka jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt wyświetlający go są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) posiada osadzone zasoby obrazu poprzez swoją [ImageCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/), natomiast [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu oraz inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/), i użyj tego zasobu obrazu przy tworzeniu kolejnych ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz wektorowe obrazy SVG. Mogą także odwoływać się do obrazów linkowanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie eksportu, dlatego warto zdecydować, jak obraz ma być przechowywany, zanim zastosujesz formatowanie lub optymalizację.

## **Dodawanie i formatowanie obrazu osadzonego**

W przypadku obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy pomocy [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

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

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów pikselowych przechowywanych w osadzonym zasobie obrazu. To rozróżnienie jest ważne przy późniejszym przycinaniu lub kompresji obrazu.

## **Używanie skali względnej**

[PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) udostępnia skalowanie względne szerokości i wysokości ramki poprzez [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/setrelativescalewidth/) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/setrelativescaleheight/). Wartość `1.0` odpowiada 100 % pierwotnego rozmiaru obrazu. Skala względna jest przydatna, gdy proces wymaga zachowania proporcji względem rozmiaru źródłowego obrazu zamiast ręcznego obliczania wymiarów końcowych.

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

Skala względna zmienia ustawienia skali ramki; nie przetwarza ani nie kompresuje osadzonego obrazu.

## **Obrazy osadzone i linkowane**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz linkowany przechowuje zewnętrzną lokalizację za pomocą metody [Picture::setLinkPathLong](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/setlinkpathlong/) zamiast osadzania danych obrazu w tym samym miejscu.

Obrazy linkowane mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zależność zewnętrzną. Plik linkowany musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, obraz linkowany może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które mają być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodawanie obrazu linkowanego**

Poniższy przykład tworzy ramkę obrazu i wskazuje na lokalny plik obrazu. Dotyczy on wyłącznie linkowania obrazów; linkowanie wideo to odrębny proces medialny i celowo nie jest mieszane w tym przykładzie.

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

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich wyłącznie jako zamiennika kompresji: mały PPTX z uszkodzonymi zależnościami obrazów jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnianie obrazów z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest faktycznie [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) i czy zawiera osadzony obraz. Ramki obrazów linkowanych mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnianie obrazu rastrowego**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony rastrowy obraz na slajdzie i zapisuje go jako PNG:

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

Zapisanie przy pomocy [IImage::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/#save) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie przekonwertowanego pliku rastrowego, użyj binarnych danych zasobu obrazu.

### **Wyodrębnianie obrazu SVG**

Dla obrazu SVG, [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) udostępnia obiekt [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast rasteryzować obraz najpierw.

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

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG czy JPEG, muszą renderować tę zawartość wektorową do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowane grafiki nie powinny być traktowane jako dokładna kopia osadzonego SVG; użyj danych [SvgImage::getSvgData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/getsvgdata/) gdy wymagana jest oryginalna wektorowa treść.

## **Przycinanie obrazu**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje ramkę obrazu i stosuje wartości przycięcia:

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

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku jest ważniejszy niż odwracalność, przycięte obszary można fizycznie usunąć, jak opisano w następnej sekcji.

## **Usuwanie przyciętych danych obrazu**

[PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) usuwa dane obrazu poza bieżącym prostokątem przycięcia i zwraca nowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji odprzycinania.

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

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli pierwotny obraz jest używany także przez inne ramki, te ramki nadal potrzebują istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie treści WMF lub EMF przy użyciu tej metody rasteryzuje przycięty wynik do PNG.

## **Kompresja obrazów rastrowych**

[PictureFillFormat::compressImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#compressImage_boolean_int_) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim jest wyświetlany. Może również usuwać przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został przeskalowany lub przycięty oraz `false`, gdy nie było konieczności zmiany.

Użyj wbudowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturescompression/) gdy wystarcza standardowa docelowa rozdzielczość:

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

Zamiast wartości wbudowanej można przekazać własną dodatnią wartość DPI, gdy wymagana jest konkretna rozdzielczość docelowa.

Kompresja jest przeznaczona dla obrazów rastrowych. Treść SVG i metaplików nie jest zmniejszana przez ten proces kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte obszary nie mogą zostać odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie rzeczywiście wyświetlany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Zarządzanie efektami transformacji obrazu**

Kompletny przepływ pracy obejmujący jasność, kontrast, przekształcenia kolorów, rozmycie, efekty alfa, łańcuchy uporządkowane, inspekcję, usuwanie i weryfikację dwukierunkową znajduje się w [Image Transform Effects](/slides/pl/php-java/image-transform-effects/).

## **Blokowanie geometrii ramki obrazu**

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

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona przetworzenia źródłowego obrazu ani trwałej zmiany jego proporcji.

## **Dostosowywanie wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [PictureFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) określają prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

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

Używaj offsetów rozciągnięcia do rozmieszczania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i uwagi dotyczące eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu traktowane są oddzielnie:

- **Obrazy osadzone** sprawiają, że prezentacja jest samodzielna i są najbardziej niezawodne przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy linkowane** mogą utrzymać mniejszy pakiet, ale prezentacja zależy od dostępności zewnętrznych plików pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** początkowo nie jest destrukcyjne. Ukryte piksele pozostają osadzone, aż do momentu wyraźnego usunięcia przyciętych obszarów lub usunięcia ich podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródła. Powinna być stosowana po ustaleniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać w formacie SVG, gdy ważne jest zachowanie wektorowości. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdu do formatu rastrowego zawsze konwertuje renderowany slajd do pikseli.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) zamiast wielokrotnego ładowania tego samego pliku w procesie tworzenia prezentacji.

W dużych prezentacjach optymalizacja obrazów jest najskuteczniejsza, gdy jest stosowana selektywnie: trzymaj logotypy i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) reprezentuje zasób obrazu powiązany z prezentacją. [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) jest kształtem na slajdzie wyświetlającym obraz i przechowującym geometrię oraz formatowanie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać, czy linkować obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Linkuj obrazy tylko wtedy, gdy umieszczenie plików obrazu poza PPTX jest zamierzone i zewnętrzne lokalizacje mogą być utrzymywane w sposób niezawodny.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują ukryte piksele. Użyj [PictureFillFormat::deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele można trwale usunąć.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może obniżyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Trzymaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak powinny być obsługiwane obrazy SVG?**

Trzymaj treść SVG jako SVG, gdy zależy Ci na wierności wektorowej. Osadzony [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) można wyodrębnić bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczycie istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Kontrola `java_instanceof` przeciwko [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala obsłużyć slajdy, które nie zawierają ramek obrazu.