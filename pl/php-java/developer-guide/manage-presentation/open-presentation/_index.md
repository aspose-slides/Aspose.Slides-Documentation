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
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w PHP, podawać hasła otwarcia, kontrolować ładowanie zasobów i zmniejszać zużycie pamięci przy użyciu Aspose.Slides for PHP via Java."
---
## **Wprowadzenie**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/pl/php-java/) może ładować prezentacje PowerPoint i OpenDocument z plików i strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/). Na przykład możesz podać hasło otwarcia, przechowywać duże obiekty binarne poza pamięcią sterty Java, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Zwolnij prezentację po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Następujący przykład PHP pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

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

Hasło otwarcia szyfruje zawartość prezentacji. Aby wczytać pełną prezentację, przekaż właściwe hasło do [LoadOptions::setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword) i podaj opcje konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/). Ładowanie nie powiedzie się, jeśli hasło jest brakujące lub niepoprawne.

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

Dla wykrywania haseł, ich walidacji i procesów szyfrowania, zobacz [Password-Protect Presentations](/slides/pl/php-java/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, można je odczytać bez hasła; zobacz [Manage Presentation Properties](/slides/pl/php-java/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) zwraca opcje kontrolujące, jak Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Możesz utrzymać plik źródłowy w stanie zablokowanym, zezwolić na pliki tymczasowe oraz ograniczyć ilość danych BLOB przechowywanych w pamięci.

Następujący kod PHP demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

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
Z [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked), plik źródłowy pozostaje zablokowany, dopóki nie zostanie zwolniona instancja prezentacji. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka do pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Manage BLOBs](/slides/pl/php-java/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) przyjmuje implementację interfejsu Java [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/) poprzez PHP/Java Bridge. Funkcja zwrotna może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego loadera lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z regułami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

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

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachować. Przykłady:

- projekty VBA, dostępne przez [Presentation::getVbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getVbaProject);
- osadzone dane OLE, dostępne przez [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dane kontrolki ActiveX, dostępne przez [Control::getActiveXControlBinary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/control/#getActiveXControlBinary).

Ustaw [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz wczytaną prezentację, aby zachować oczyszczony wynik.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

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

**Jak mogę stwierdzić, że plik jest uszkodzony i nie można go otworzyć?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę niepowodzenie osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja nadal może się wczytać, ale renderowanie i eksport mogą podstawić czcionki. Możesz [konfiguruj zamianę czcionek](/slides/pl/php-java/font-substitution/) lub [udostępnij własne czcionki](/slides/pl/php-java/custom-font/), aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji ładuje także jej osadzone multimedia?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można odczytać.