---
title: Otwieranie prezentacji w PHP
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/php-java/open-presentation/
keywords:
- otwórz PowerPoint
- otwórz prezentację
- otwórz PPTX
- otwórz PPT
- otwórz ODP
- załaduj prezentację
- załaduj PPTX
- załaduj PPT
- załaduj ODP
- zabezpieczona prezentacja
- duża prezentacja
- zewnętrzny zasób
- obiekt binarny
- PHP
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w PHP, podawać hasła otwierające, kontrolować ładowanie zasobów oraz zmniejszać zużycie pamięci przy użyciu Aspose.Slides for PHP via Java."
---
## **Wprowadzenie**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/pl/php-java/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji można przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie podczas ładowania można dostosować przy użyciu klasy [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/). Na przykład można podać hasło otwierające, przechowywać duże obiekty binarne poza pamięcią sterty Java, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Po załadowaniu pliku lub strumienia można [określić jego pierwotny format prezentacji](/slides/pl/php-java/detect-presentation-source-format/), aby zdecydować, jak aplikacja go przetworzy.

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Po użyciu zwolnij prezentację, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Poniższy przykład PHP pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Hasło otwierające szyfruje zawartość prezentacji. Aby wczytać całą prezentację, przekaż prawidłowe hasło do [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword) i podaj opcje konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest pominięte lub nieprawidłowe.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

W celu wykrywania, walidacji i szyfrowania haseł zobacz [Password-Protect Presentations](/slides/pl/php-java/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Manage Presentation Properties](/slides/pl/php-java/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) zwraca opcje kontrolujące sposób, w jaki Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Można utrzymać plik źródłowy zablokowany, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod PHP demonstruje ładowanie dużej prezentacji (np. 2 GB):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Przy użyciu [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), plik źródłowy pozostaje zablokowany aż do zwolnienia instancji prezentacji. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Manage BLOBs](/slides/pl/php-java/manage-blob/) po więcej opcji przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) przyjmuje implementację interfejsu Java [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/) poprzez PHP/Java Bridge. Wywołanie zwrotne może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego ładowania lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z regułami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachować. Przykłady obejmują:

- projekty VBA, dostępne poprzez [Presentation::getVbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getVbaProject);
- osadzone dane OLE, dostępne poprzez [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dane kontrolki ActiveX, dostępne poprzez [Control::getActiveXControlBinary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/control/#getActiveXControlBinary).

Ustaw [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz wczytaną prezentację, aby utrwalić oczyszczony rezultat.

Ta opcja zmniejsza ryzyko niepożądanych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani oczyszczania treści.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, gdy brak wymaganych czcionek?**

Prezentacja może nadal zostać załadowana, ale renderowanie i eksport mogą zastąpić czcionki. Można [konfiguruj zastępowanie czcionek](/slides/pl/php-java/font-substitution/) lub [udostępnij własne czcionki](/slides/pl/php-java/custom-font/) aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji ładuje również jej osadzone media?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.