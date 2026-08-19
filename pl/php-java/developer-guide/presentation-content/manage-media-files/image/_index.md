---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu PHP
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/php-java/image/
keywords:
- dodaj obraz
- dodaj grafikę
- zamień obraz
- kolekcja obrazów
- ramka obrazu
- obraz linkowany
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie wykorzystywać, linkować, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP via Java."
---
## **Wprowadzenie**

Aspose.Slides for PHP via Java oferuje kilka sposobów pracy z obrazami, przy czym każdy służy innemu celowi. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać go jako tło slajdu, linkować do zewnętrznego obrazu, zamienić współdzielony zasób obrazu lub przekonwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazu i ich wykorzystaniu w całej prezentacji. Informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu znajdziesz w sekcji [Picture Frame](/slides/pl/php-java/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie są wymienne:

- Kolekcja obrazów prezentacji ([presentation image collection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/)) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection::addImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) aby dodać dane obrazu i uzyskać zasób [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/).
- [picture frame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) jest kształtem wyświetlającym obraz na slajdzie, układzie lub szablonie. Użyj [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addpictureframe/) aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się jak ramka obrazu.
- [PPImage::replaceImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) zastępuje zasób obrazu. Jeśli kilka elementów prezentacji używa tego zasobu, wszystkie korzystają z zamiany.
- Konwersja SVG na kształty tworzy edytowalne kształty slajdu. Po konwersji zawartość nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji obrazów, otrzymaj [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/), a następnie użyj tego zasobu w jednej lub wielu ramkach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić obraz lokalny, załaduj plik, dodaj go do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego `PPImage`.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Gdy obraz jest dostępny poprzez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób jak obrazu lokalnego.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

W długotrwałych aplikacjach ponownie wykorzystuj klienta HTTP lub strategię zarządzania połączeniami odpowiednią dla aplikacji, zamiast wielokrotnie tworzyć niepotrzebną infrastrukturę sieciową. Również weryfikuj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji jednokrotnie i ponownie użyj zwróconego [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) przy tworzeniu kolejnych ramek obrazu. To eliminuje wielokrotne ładowanie tych samych danych źródłowych i wyraźnie określa zależność między współdzielonym zasobem obrazu a jego użyciem.

W przypadku grafik, które mają pojawiać się automatycznie na wielu slajdach, takich jak logo firmy, rozważ umieszczenie ramki obrazu na [slide master](/slides/pl/php-java/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tło slajdu**

Obraz tła jest przypisany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jak zwykły obiekt slajdu.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aby poznać dodatkowe opcje tła, w tym tła szablonu i układu, zobacz [Presentation Background](/slides/pl/php-java/presentation-background/).

## **Obrazy osadzone i obrazy linkowane**

Obrazy osadzone i linkowane mają różne kompromisy dotyczące przenośności i wielkości pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku obejmuje dane obrazu.
- **Obraz linkowany:** prezentacja przechowuje ścieżkę lub adres URL do zewnętrznego obrazu. To może zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny podczas otwierania lub renderowania prezentacji.

Obraz linkowany można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [Picture::setLinkPathLong](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picture/) zamiast osadzania danych obrazu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Używaj obrazów linkowanych tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny do ikon, diagramów i innych grafik, które powinny skalować się bez takiej utraty szczegółów jak obrazy rastrowe. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść wynikowy zasób obrazu w ramce obrazu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Pliki SVG z zasobami zewnętrznymi**

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [ExternalResourceResolver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/externalresourceresolver/) oraz bazowy URI. Resolver może mapować względny URI na dozwolony bezwzględny URI i zwrócić strumień żądanego zasobu.

Resolver udostępnia zewnętrzne zasoby podczas przetwarzania SVG przez Aspose.Slides, ale nie przekształca SVG w dokument samodzielny. Jeśli SVG musi pozostać przenośny, osadź wymagane zasoby w samym SVG, na przykład używając URI `data:` dla linkowanych obrazów.

Gdy pliki SVG pochodzą z niepewnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może mieć dostęp. Resolverzy sieciowi powinni także stosować limity czasu, rozmiaru odpowiedzi i weryfikację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może przekonwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiednia komenda w PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Użyj przeciążenia [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addgroupshape/) które przyjmuje [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) aby wykonać konwersję.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Użyj konwersji SVG na kształty, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być jedynie wyświetlany, zachowanie go jako obrazu jest prostsze i unika tworzenia wielu oddzielnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [PPImage::replaceImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/) gdy chcesz zastąpić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak logotypy.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Jeśli wiele ramek obrazu, tła, szablonów lub układów używa tego samego zasobu obrazu, jego zastąpienie aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz inny obraz do tej ramki zamiast zastępować współdzielony zasób.

`PPImage::replaceImage` zapewnia także przeciążenia przyjmujące tablicę bajtów lub inny [PPImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/).

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą sprawić, że prezentacja będzie niepotrzebnie duża. Używaj obrazów źródłowych o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, w miarę możliwości ponownie używaj współdzielonych zasobów obrazów i unikaj osadzania powtarzających się kopii tej samej grafiki w pełnej rozdzielczości.

W przypadku obrazów rastrowych, które już zostały umieszczone w ramkach obrazów, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/picturefillformat/) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycinania. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Picture Frame](/slides/pl/php-java/picture-frame/) po informacje o powiązanych operacjach formatowania.

### **Wybór między zawartością osadzoną a linkowaną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie wymagane dane obrazu znajdują się w pliku. Linkowanie może zmniejszyć rozmiar pliku, ale wprowadza zewnętrzną zależność. Używaj linków tylko wtedy, gdy ta zależność jest akceptowalna i stabilna.

### **Ponowne użycie wspólnej identyfikacji wizualnej**

W przypadku wielokrotnie używanych logotypów, znaków wodnych lub grafik dekoracyjnych, użyj jednego zasobu obrazu i ponownie go wykorzystaj. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdu, umieść ją w szablonie lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymuj zasoby SVG przenośne**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania w sposób jednolity niż SVG zależny od plików zewnętrznych lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użyj nowoczesnego, wieloplatformowego API obrazu**

W nowym kodzie PHP via Java używaj API Aspose.Slides [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) i [Images](https://reference.aspose.com/slides/pl/php-java/aspose.slides/images/) zamiast starszego publicznego API opartego na `java.awt.image.BufferedImage`. Zobacz [Modern API](/slides/pl/php-java/modern-api/) po wskazówki dotyczące migracji.

Formaty WMF i EMF wymagają specjalnego traktowania. Gdy są przekazywane przez [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) konwertuje metafile na reprezentację rastrową PNG przed wstawieniem. Jeśli zachowanie danych metafile jest istotne, zamiast tego użyj przeciążenia [ImageCollection::addImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imagecollection/) opartego na strumieniu. Generowanie treści EMF z arkuszy kalkulacyjnych lub innych produktów jest osobnym procesem integracji i wykracza poza zakres tego artykułu.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnego użytku zasoby obrazów. Ramka obrazu jest kształtem slajdu wyświetlającym jeden z tych zasobów i zapewnia specyficzne dla obrazu formatowanie, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo wszędzie?**

Jeśli logo jest już współdzielone jako jeden zasób obrazu, zastąp ten zasób przy użyciu [PPImage::replaceImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ppimage/). W celu markowania całej prezentacji, umieszczenie logo w szablonie lub układzie może również zmniejszyć powieloną treść slajdów.

**Dlaczego obraz linkowany znika na innym komputerze?**

Obraz linkowany zależy od swojego zewnętrznego pliku lub adresu URL. Jeśli zasób nie jest dostępny z innego komputera, obraz linkowany może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Przekonwertuj SVG za pomocą [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addgroupshape/); wynikowa grupa zawiera edytowalne kształty slajdu zamiast jednego obrazu SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami w mniejszym rozmiarze?**

Ponownie używaj współdzielonych zasobów obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w razie potrzeby, umieszczaj powtarzające się elementy identyfikacji wizualnej w szablonach lub układach oraz używaj obrazów linkowanych tylko wtedy, gdy zewnętrzna zależność jest akceptowalna.