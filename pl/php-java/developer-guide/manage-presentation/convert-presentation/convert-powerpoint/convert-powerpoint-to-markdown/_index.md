---
title: Konwertuj prezentacje PowerPoint na Markdown w PHP
linktitle: PowerPoint na Markdown
type: docs
weight: 140
url: /pl/php-java/convert-powerpoint-to-markdown/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint na MD
- prezentacja na MD
- slajd na MD
- PPT na MD
- PPTX na MD
- zapisz PowerPoint jako Markdown
- zapisz prezentację jako Markdown
- zapisz slajd jako Markdown
- zapisz PPT jako MD
- zapisz PPTX jako MD
- eksportuj PPT do MD
- eksportuj PPTX do MD
- Eksport obrazów Markdown
- linki do obrazów CDN
- PowerPoint
- prezentacja
- Markdown
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PPT i PPTX na Markdown w PHP oraz kontroluj, gdzie zapisywane i odwoływane są wyeksportowane obrazy bitmapowe, metafile i SVG."
---
## **Przegląd**

Aspose.Slides for PHP via Java może konwertować prezentacje PPT i PPTX na Markdown dla dokumentacji, stron statycznych, migracji treści i przepływów pracy kontrolowanych wersją. Możesz wybrać odmianę Markdown, kontrolować sposób renderowania zawartości slajdów oraz decydować, gdzie zapisywane są wyeksportowane obrazy i jak generowany Markdown odwołuje się do nich.

Domyślnie eksport Markdown używa wyjścia wyłącznie tekstowego. Aby wyeksportować zawartość wizualną, ustaw typ eksportu metodą [MarkdownSaveOptions::setExportType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) na wartość `Sequential` lub `Visual` z wyliczenia [MarkdownExportType](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownexporttype/). `Sequential` renderuje elementy slajdu osobno i w kolejności, natomiast `Visual` zachowuje grupowane elementy razem, aby utrzymać ich relację wizualną. Wartość `TextOnly` nie generuje zasobów obrazu, więc wywołania zwrotne zapisu obrazu nie są wywoływane w tym trybie.

## **Konwersja prezentacji do Markdown**

Wczytaj plik źródłowy za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i następnie wywołaj metodę [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) z wartością `Md` z wyliczenia [SaveFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/saveformat/).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **Wybór odmiany Markdown**

Metoda [MarkdownSaveOptions::setFlavor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) kontroluje specyfikację Markdown używaną w wyjściu. Wyliczenie [Flavor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/flavor/) zawiera CommonMark, GitHub Flavored Markdown oraz inne obsługiwane warianty.

Poniższy przykład eksportuje prezentację jako CommonMark:

```php
use aspose\slides\Flavor;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.md";
$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setFlavor(Flavor::CommonMark);

    $presentation->save($outputPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

## **Eksport obrazów przy użyciu domyślnego zachowania lokalnego zapisu**

Klasa [MarkdownSaveOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) udostępnia dwie metody konfigurowania lokalnie zapisywanych obrazów:

- [setBasePath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) określa katalog bazowy dla dokumentu Markdown i jego zasobów.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) określa podkatalog obrazów. Jego domyślną wartością jest `Images`.

Poniższy przykład renderuje zawartość wizualną, zapisuje obrazy do `output/assets` i tworzy względne odwołania do obrazów w dokumencie Markdown:

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("assets");

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

To zachowanie służy również jako plan awaryjny, gdy niestandardowy obsługujący zapis obrazu zwróci `false`.

## **Dostosowanie zapisu obrazów i linków Markdown**

Użyj metody [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) aby zarejestrować wywołanie zwrotne dla zasobów bitmap i metafili nie‑SVG emitowanych podczas eksportu Markdown. Wywołanie zwrotne `MarkdownImageSavingHandler` otrzymuje obiekt [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/), jego wartość [ImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/) oraz wygenerowany link Markdown jako jednowymiarową tablicę Java stringów. Zapisz lub prześlij obraz w podanym formacie i zamień `$link[0]` na odwołanie, które ma pojawić się w wyjściu Markdown.

Zasoby emitowane w formacie SVG są obsługiwane osobno. Zarejestruj wywołanie zwrotne metodą [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/). Jego wywołanie zwrotne `MarkdownSvgImageSavingHandler` otrzymuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/isvgimage/) oraz jednowymiarową tablicę Java stringów `$link`. SVG nie posiada argumentu `ImageFormat`; zamiast tego zapisz lub prześlij jego dane XML metodą [ISvgImage::getSvgData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/isvgimage/). W zależności od trybu eksportu i grupowania wizualnego, SVG w źródłowej prezentacji może zostać zrastryzowane lub połączone z inną zawartością; wynikowy zasób nie‑SVG jest wtedy przekazywany do wywołania zwrotnego zapisu obrazu. Zarejestruj oba wywołania zwrotne, gdy każdy wyeksportowany zasób wizualny wymaga własnej obróbki.

W PHP via Java zaimplementuj każde wywołanie zwrotne w klasie PHP i użyj `java_closure`, aby udostępnić ten obiekt jako odpowiedni interfejs Java.

{{% alert color="info" title="Uwaga" %}}

Zainicjalizuj most PHP/Java z włączonym `JAVA_PREFER_VALUES` przed załadowaniem `Java.inc`. Metoda [Presentation::save](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) zwraca `void`, a domyślny tryb strumienia mostu nie może wywołać wywołania zwrotnego PHP podczas tego zakolejkowanego wywołania. Pełny przykład poniżej zawiera wymaganą inicjalizację.

{{% /alert %}}

Wartość zwracana przez obsługującego określa, kto przetwarza obraz:

- Zwróć `true` po zapisaniu, przesłaniu, przekształceniu lub innej obróbce obrazu oraz po przypisaniu prawidłowej wartości do `$link[0]`. Aspose.Slides zapisze tę wartość w dokumencie Markdown i nie wykona domyślnego lokalnego zapisu.
- Zwróć `false`, aby pozwolić Aspose.Slides zapisać obraz lokalnie i wygenerować link zgodnie z wartościami ustawionymi w [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) oraz [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Ważne" %}}

Obsługujący, który zwróci `true`, przejmuje odpowiedzialność za obraz. Jeśli zwróci `true` bez przypisania prawidłowego, niepustego linku, eksport zakończy się niepowodzeniem z `InvalidOperationException`.

{{% /alert %}}

### **Zapis obrazów do katalogu CDN i użycie zewnętrznych URL**

Poniższy przykład traktuje `cdn-origin/presentations/quarterly-report` jako zamontowany lub zsynchronizowany katalog CDN. Każdy obsługujący wyodrębnia wygenerowaną nazwę pliku, zapisuje obraz w tym niestandardowym katalogu i zamienia lokalne odwołanie na publiczny URL CDN. Sam przykład nie wykonuje przesyłania sieciowego: URL staje się prawidłowy dopiero po zamontowaniu katalogu jako źródło CDN lub po opublikowaniu jego plików w CDN. Dla magazynu obiektowego zamień zapis do systemu plików na operację uploadu SDK i przypisz `$link[0]` dopiero po pomyślnym przesłaniu.

```php
use aspose\slides\MarkdownExportType;
use aspose\slides\MarkdownSaveOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

define("JAVA_PREFER_VALUES", 1);
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once("lib/aspose.slides.php");

function getFileNameFromLink($generatedLink)
{
    $urlCompatibleLink = str_replace("\\", "/", java_values($generatedLink));
    return basename($urlCompatibleLink);
}

function buildPublicUrl($publicBaseUrl, $fileName)
{
    return rtrim($publicBaseUrl, "/") . "/" . rawurlencode($fileName);
}

class CustomImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($image, $format, $link)
    {
        if (java_values($image->getWidth()) < 128 || java_values($image->getHeight()) < 128) {
            return false;
        }

        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $image->save($storagePath, $format);
        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

class CustomSvgImageSavingHandler
{
    private $storageDirectory;
    private $publicBaseUrl;

    function __construct($storageDirectory, $publicBaseUrl)
    {
        $this->storageDirectory = $storageDirectory;
        $this->publicBaseUrl = $publicBaseUrl;
    }

    function invoke($svgImage, $link)
    {
        $fileName = getFileNameFromLink($link[0]);
        $storagePath = $this->storageDirectory . DIRECTORY_SEPARATOR . $fileName;
        $outputStream = null;
        try {
            $outputStream = new Java("java.io.FileOutputStream", $storagePath);
            $outputStream->write($svgImage->getSvgData());
        } catch (Throwable $exception) {
            fwrite(STDERR, "Could not save the SVG image: " . $exception->getMessage() . PHP_EOL);
            return false;
        } finally {
            if ($outputStream !== null) {
                $outputStream->close();
            }
        }

        $link[0] = buildPublicUrl($this->publicBaseUrl, $fileName);
        return true;
    }
}

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputDirectory = __DIR__ . DIRECTORY_SEPARATOR . "output";
$publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
$storageDirectory = __DIR__ . DIRECTORY_SEPARATOR . "cdn-origin" . DIRECTORY_SEPARATOR . "presentations" . DIRECTORY_SEPARATOR . "quarterly-report";
if (!is_dir($outputDirectory)) {
    mkdir($outputDirectory, 0777, true);
}
if (!is_dir($storageDirectory)) {
    mkdir($storageDirectory, 0777, true);
}

$presentation = new Presentation($inputPath);
try {
    $options = new MarkdownSaveOptions();
    $options->setExportType(MarkdownExportType::Visual);
    $options->setBasePath($outputDirectory);
    $options->setImagesSaveFolderName("fallback-images");

    $imageSavingHandler = java_closure(new CustomImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler'));
    $svgImageSavingHandler = java_closure(new CustomSvgImageSavingHandler($storageDirectory, $publicBaseUrl), null, java('com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler'));
    $options->setImageSaving($imageSavingHandler);
    $options->setSvgImageSaving($svgImageSavingHandler);

    $markdownPath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.md";
    $presentation->save($markdownPath, SaveFormat::Md, $options);
} finally {
    $presentation->dispose();
}
```

Obsługujący bitmapy celowo zwraca `false` dla obrazów mniejszych niż 128 × 128 pikseli, więc Aspose.Slides zapisuje te obrazy w `output/fallback-images` przy użyciu domyślnego zachowania. Większe zasoby bitmap i metafili, a także zasoby SVG, są obsługiwane przez kod niestandardowy. Na przykład wygenerowane lokalne odwołanie `fallback-images/image1.png` staje się `https://cdn.example.com/presentations/quarterly-report/image1.png`. Obsługujący używają ścieżek systemu operacyjnego wyłącznie przy zapisie plików; linki zapisywane w Markdown używają ukośników (`/`) i nazw plików ucieczkowanych w URL. Stosuj tę samą regułę przy budowaniu względnych linków: używaj `/`, nie separatora specyficznego dla platformy.

## **FAQ**

**Czy jeden obsługujący może przetwarzać zarówno obrazy rastrowe, jak i SVG?**

Nie. Użyj [MarkdownSaveOptions::setImageSaving](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) dla emitowanych zasobów bitmap i metafili oraz [MarkdownSaveOptions::setSvgImageSaving](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) dla zasobów emitowanych jako SVG. Pierwsza metoda dostarcza obiekt [IImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/iimage/) i wartość [ImageFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/imageformat/); druga dostarcza obiekt [ISvgImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/isvgimage/), którego dane SVG można odczytać metodą [ISvgImage::getSvgData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/isvgimage/). Źródłowy SVG, który zostanie zrastryzowany podczas eksportu, jest przetwarzany przez wywołanie zwrotne zapisu obrazu.

**Co się dzieje, gdy obsługujący zapis obrazu zwróci `false`?**

Aspose.Slides używa domyślnego zachowania lokalnego zapisu. Lokalizacja obrazu i wygenerowane odwołanie są kontrolowane przez wartości ustawione w [MarkdownSaveOptions::setBasePath](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/) oraz [MarkdownSaveOptions::setImagesSaveFolderName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/markdownsaveoptions/).

**Czy obsługujący może podać URL bez zapisywania obrazu lokalnie?**

Tak. Obsługujący może przesłać obraz do magazynu obiektowego lub przekazać go innej usłudze, przypisać uzyskany URL do `$link[0]` i zwrócić `true`. Obsługujący musi samodzielnie zakończyć przetwarzanie; zwrócenie `true` zapobiega domyślnemu lokalnemu zapisowi.

**Dlaczego eksport Markdown wyrzuca `InvalidOperationException` z obsługującego?**

Ten wyjątek występuje, gdy obsługujący zwróci `true`, ale nie poda prawidłowego linku. Przypisz względną ścieżkę lub zewnętrzny URL, który ma zostać zapisany w Markdown, przed zwróceniem `true`.

**Jakiego separatora ścieżki powinny używać linki do obrazów?**

Używaj ukośników (`/`) w linkach Markdown i URL. `DIRECTORY_SEPARATOR` używaj wyłącznie w ścieżkach systemu plików, a następnie oddzielnie twórz lub normalizuj odwołania w Markdown.

**Czy hiperłącza są zachowywane podczas eksportu Markdown?**

Tak. Tekstowe [hiperłącza](/slides/pl/php-java/manage-hyperlinks/) są zachowywane jako standardowe linki Markdown. [Przejścia](/slides/pl/php-java/slide-transition/) i [animacje](/slides/pl/php-java/powerpoint-animation/) slajdów nie są konwertowane.

**Czy prezentacje można konwertować do Markdown równolegle?**

Możesz przetwarzać różne pliki prezentacji równolegle, ale nie współdzielić tej samej instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) pomiędzy wątkami. Postępuj zgodnie z [wytycznymi dotyczącymi wielowątkowości](/slides/pl/php-java/multithreading/) i używaj oddzielnej instancji dla każdego pliku.