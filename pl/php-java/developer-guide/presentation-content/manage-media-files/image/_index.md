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
- zewnętrzne zasoby SVG
- rozwiązywacz SVG
- powiązane obrazy SVG
- czcionki SVG
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
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla PHP poprzez Java, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i wizualnie atrakcyjne. W programie Microsoft PowerPoint możesz wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides pozwala dodawać obrazy do slajdów prezentacji na kilka sposobów.

{{% alert  title="Tip" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery—[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—pozwalające szybko tworzyć prezentacje ze zdjęć. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jeśli chcesz dodać obraz jako ramkę obrazu—szczególnie jeśli planujesz jego zmianę rozmiaru, zastosowanie efektów lub użycie innych standardowych opcji formatowania—zobacz [Picture Frame](/slides/pl/php-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwersja [image to JPG](https://products.aspose.com/slides/pl/php-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pl/php-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pl/php-java/conversion/png-to-svg/) oraz [SVG to PNG](https://products.aspose.com/slides/pl/php-java/conversion/svg-to-png/). 

{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy przykładowy kod PHP pokazuje, jak dodać obraz do slajdu:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na komputerze, możesz go dodać bezpośrednio z sieci. 

Poniższy przykładowy kod PHP pokazuje, jak dodać obraz z sieci do slajdu:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
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
    $pres->dispose();
}
```

## **Dodawanie obrazów do wzorców slajdów**

Wzorzec slajdu przechowuje i kontroluje informacje, takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do wzorca slajdu, obraz pojawia się na każdym slajdzie opartym na tym wzorcu. 

Poniższy przykładowy kod PHP pokazuje, jak dodać obraz do wzorca slajdu:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
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
    $pres->dispose();
}
```

## **Dodawanie obrazów jako tła slajdów**

Możesz użyć obrazu jako tła dla jednego lub kilku slajdów. Szczegóły znajdziesz w *[Setting Images as Backgrounds for Slides](/slides/pl/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/). Utworzony obiekt obrazu SVG może później zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki obrazu. 

Poniższy przykład PHP importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby używane przez ten SVG są osadzone bezpośrednio w treści SVG. 

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importowanie zawartości SVG z zasobami zewnętrznymi**

Pliki SVG wyeksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon oraz potoków internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki. 

Aby zaimportować taką zawartość SVG, utwórz implementację [ExternalResourceResolver](https://reference.aspose.com/slides/pl/php-java/aspose.slides/externalresourceresolver/) i przekaż ją, wraz z bazowym URI, do odpowiedniego konstruktora [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/). Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania względnych odnośników. 

Obiekt obrazu SVG zapewnia dostęp do informacji o zaimportowanym SVG: 

- `getSvgContent()` zwraca znacznik SVG jako ciąg znaków. 
- `getSvgData()` zwraca zawartość SVG jako tablicę bajtów. 
- `getBaseUri()` zwraca bazowy URI używany dla względnych odnośników. 
- `getExternalResourceResolver()` zwraca rezolver przypisany do obrazu SVG. 

### **Implementacja rezolwera zasobów zewnętrznych**

Rezolver posiada dwie metody: 

- `resolveUri` łączy bazowy URI i względny odnośnik zasobu, zwracając bezwzględny URI. Zwraca `null`, gdy odnośnik nie może być rozwiązany lub jest niedozwolony. 
- `getEntity` zwraca strumień do odczytu dla bezwzględnego URI zasobu. Zwraca `null`, gdy zasób jest nieobecny, zablokowany lub niedostępny. W razie potrzeby może zostać zwrócony strumień zastępczy. 

Poniższy rezolver ładuje powiązane zasoby wyłącznie z dozwolonego lokalnego katalogu. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zastępczy jest zwracany dla nierozwiązanych odnośników do obrazów. 

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Ten rezolver celowo zezwala tylko na pliki lokalne.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Użyj obrazu zastępczego tylko dla zasobów obrazów. Zwrócenie strumienia obrazu
            // dla brakującej czcionki lub arkusza stylów nie byłoby prawidłowe.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Rozwiązywanie powiązanych zasobów podczas importu SVG**

Załóżmy, że `assets/diagram.svg` zawiera względne odniesienie, takie jak: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład PHP przekazuje URI pliku SVG jako bazowy URI i dostarcza własny rezolver. Rezolver konwertuje względny odnośnik do obrazu na bezwzględny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG. 

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// Bazowy URI reprezentuje lokalizację dokumentu SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// Obiekt obrazu SVG udostępnia zawartość źródłową, dane binarne, bazowy URI oraz rezolver.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Klasa `SvgImage` oferuje także przeciążenia, które przyjmują dane SVG jako tablicę bajtów lub strumień wejściowy, wraz z rezolverem zasobów zewnętrznych oraz bazowym URI. 

{{% alert title="Important" color="warning" %}}

Rezolver zasobów udostępnia zasoby zewnętrzne podczas przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje on oryginalnego znacznika SVG ani nie osadza automatycznie rozwiązanych zasobów w nim.

Gdy obraz SVG zostanie dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno oryginalną reprezentację SVG, jak i rastrowy obraz zastępczy. Powiązany zasób może pojawić się w wygenerowanym obrazie zastępczym, podczas gdy względny odnośnik, taki jak `images/photo.png`, pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną zawartość, gdy pierwotny zasób zewnętrzny jest niedostępny. 

{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG, który nie zależy od zewnętrznych plików, przygotuj SVG jako samodzielny przed stworzeniem `SvgImage`. Na przykład zamień powiązane adresy URL obrazów na URI `data:`, które zawierają dane obrazu: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie. 

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `resolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może zostać rozwiązany. Zwróć `null` z `getEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, gdy to możliwe. 

Strumień zastępczy może zostać zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwracaj strumień obrazu tylko dla brakującego obrazu, nie dla czcionki czy arkusza stylów. 

{{% alert title="Security" color="warning" %}}

Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niepewnych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych stosuj także limity czasu połączenia, rozmiaru odpowiedzi oraz weryfikację treści. 

{{% /alert %}}

## **Konwertowanie SVG na zestaw kształtów**

Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiednia funkcja w programie PowerPoint: 

![PowerPoint Popup Menu](img_01_01.png)

Ta funkcjonalność jest udostępniana przez przeciążenie metody [addGroupShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/addgroupshape/) klasy [ShapeCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/), które przyjmuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgimage/) jako pierwszy argument. 

Poniższy przykładowy kod PHP pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów: 

```php
// Nazwa pliku źródłowego SVG.
$svgFileName = "sample.svg";

// Nazwa pliku wyjściowego prezentacji.
$outPptxPath = "presentation.pptx";

// Utwórz nową prezentację.
$presentation = new Presentation();
try {
    // Odczytaj zawartość pliku SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Utwórz obiekt SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Pobierz rozmiar slajdu.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Konwertuj obraz SVG na grupę kształtów i skaluj go do rozmiaru slajdu.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Zapisz prezentację w formacie PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Dodawanie obrazów jako EMF do slajdów**

Aspose.Slides for PHP via Java umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji. 

Poniższy przykładowy kod PHP pokazuje, jak to zrobić: 

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Zapisz skoroszyt do strumienia.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Dodaj plik w oryginalnej formie, aby obraz pozostał wektorowym EMF zamiast zostać zrastryzowany.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides umożliwia zastępowanie obrazów przechowywanych w kolekcji obrazów prezentacji, w tym obrazów używanych przez kształty slajdów. Ta sekcja opisuje różne sposoby aktualizacji obrazów w kolekcji. Możesz zastąpić obraz używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) lub innego obrazu, który już znajduje się w kolekcji. 

Postępuj zgodnie z poniższymi krokami: 

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). 
1. Załaduj nowy obraz z pliku do tablicy bajtów. 
1. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów. 
1. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem. 
1. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji. 
1. Zapisz zmodyfikowaną prezentację jako plik PPTX. 

```php
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
$presentation = new Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // Drugi sposób.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

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

Dzięki bezpłatnemu konwerterowi Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) możesz łatwo animować tekst i tworzyć GIF-y z tekstu. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/php-java/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie. 

**Jaki jest najlepszy sposób na jednoczesne zastąpienie tego samego logo na dziesiątkach slajdów?**

Umieść logo na master slajdzie lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany zostaną propagowane do wszystkich elementów korzystających z tego zasobu. 

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. Możesz przekonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów. 

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Ustaw obraz jako tło](/slides/pl/php-java/presentation-background/) na master slajdzie lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło. 

**Jak zapobiec nadmiernemu rozmiarowi prezentacji spowodowanemu dużą liczbą obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i umieszczaj powtarzające się grafiki na masterze, gdy to stosowne.