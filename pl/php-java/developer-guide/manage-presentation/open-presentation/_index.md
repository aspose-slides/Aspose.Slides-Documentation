---
title: Otwieranie prezentacji w PHP
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/php-java/open-presentation/
keywords:
- otwórz PowerPoint
- otwórz OpenDocument
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
description: "Otwieraj prezentacje PowerPoint (.pptx, .ppt) oraz OpenDocument (.odp) bez wysiłku dzięki Aspose.Slides dla PHP przez Java — szybko, niezawodnie, w pełni funkcjonalne."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides pozwala również otwierać istniejące prezentacje. Po załadowaniu prezentacji możesz pobrać informacje o niej, edytować zawartość slajdów, dodawać nowe slajdy, usuwać istniejące i wiele innych.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/) i przekaż ścieżkę do pliku do jej konstruktora.

Poniższy przykład w PHP pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```php
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku do jej konstruktora.
$presentation = new Presentation("Sample.pptx");
try {
    // Wyświetl całkowitą liczbę slajdów w prezentacji.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Kiedy potrzebujesz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło metodą [setPassword](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setPassword) klasy [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/), aby odszyfrować i załadować ją. Poniższy kod PHP demonstruje tę operację:

```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // Wykonaj operacje na odszyfrowanej prezentacji.
} finally {
    $presentation->dispose();
}
```

## **Otwieranie dużych prezentacji**

Aspose.Slides udostępnia opcje — w szczególności metodę [getBlobManagementOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) w klasie [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/) — aby pomóc w ładowaniu dużych prezentacji.

Poniższy kod PHP demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez cały okres życia
// instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // Duża prezentacja została załadowana i może być używana, przy jednoczesnym niskim zużyciu pamięci.

    // Wprowadź zmiany w prezentacji.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// Nie rób tego! Zostanie rzucony wyjątek I/O, ponieważ plik jest zablokowany do momentu zwolnienia obiektu prezentacji.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt prezentacji.
unlink($filePath);
```

{{% alert color="info" title="Info" %}}
Aby obejść niektóre ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje kopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.), możesz użyć [BLOB management](/slides/pl/php-java/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrola zasobów zewnętrznych**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/), który pozwala zarządzać zasobami zewnętrznymi. Poniższy kod PHP pokazuje, jak używać interfejsu `IResourceLoadingCallback`:

```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // Załaduj zastępczy obraz.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // Ustaw zastępczy adres URL.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // Pomiń wszystkie pozostałe obrazy.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy osadzonych obiektów binarnych:

- projekt VBA (dostępny przez [Presentation.getVbaProject](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/#getVbaProject));
- osadzone dane obiektu OLE (dostępne przez [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- binarne dane kontroli ActiveX (dostępne przez [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/control/#getActiveXControlBinary)).

Korzystając z metody [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), możesz załadować prezentację bez żadnych osadzonych obiektów binarnych.

Ta metoda jest przydatna do usuwania potencjalnie złośliwej treści binarnej. Poniższy kod PHP demonstruje, jak załadować prezentację bez żadnych osadzonych obiektów binarnych:

```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // Wykonaj operacje na prezentacji.
} finally {
    $presentation->dispose();
}
```

## **Najczęściej zadawane pytania**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Podczas ładowania otrzymasz wyjątek związany z parsowaniem/validacją formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli przy otwieraniu brakują wymagane czcionki?**

Plik zostanie otwarty, ale później [renderowanie/eksport](/slides/pl/php-java/convert-presentation/) może podmienić czcionki. [Skonfiguruj zamienniki czcionek](/slides/pl/php-java/font-substitution/) lub [dodaj wymagane czcionki](/slides/pl/php-java/custom-font/) do środowiska uruchomieniowego.

**Co z osadzonymi mediami (wideo/audio) przy otwieraniu?**

Stają się dostępne jako zasoby prezentacji. Jeśli media są odwoływane za pomocą zewnętrznych ścieżek, upewnij się, że te ścieżki są dostępne w Twoim środowisku; w przeciwnym razie [renderowanie/eksport](/slides/pl/php-java/convert-presentation/) może pominąć media.