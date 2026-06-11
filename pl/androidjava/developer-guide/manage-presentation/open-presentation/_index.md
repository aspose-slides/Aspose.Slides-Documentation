---
title: Otwieranie prezentacji na Androidzie
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/androidjava/open-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Łatwo otwieraj prezentacje PowerPoint (.pptx, .ppt) i OpenDocument (.odp) za pomocą Aspose.Slides for Android w Javie — szybkie, niezawodne, w pełni funkcjonalne."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia także otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz pobrać informacje o niej, edytować zawartość slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) i przekaż ścieżkę do pliku do jej konstruktora.

Poniższy przykład w języku Java pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```java
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku do jej konstruktora.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Wypisz całkowitą liczbę slajdów w prezentacji.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otwieranie zabezpieczonych hasłem prezentacji**

Gdy musisz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło poprzez metodę [setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) klasy [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/), aby odszyfrować i załadować ją. Poniższy kod w języku Java demonstruje tę operację:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Wykonaj operacje na odszyfrowanej prezentacji.
} finally {
    presentation.dispose();
}
```

## **Otwieranie dużych prezentacji**

Aspose.Slides udostępnia opcje — w szczególności metodę [getBlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) w klasie [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/) — aby pomóc w ładowaniu dużych prezentacji.

Poniższy kod w języku Java demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez cały okres życia
// instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Duża prezentacja została załadowana i może być używana, przy jednoczesnym niskim zużyciu pamięci.

    // Wprowadź zmiany w prezentacji.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nie rób tego! Zostanie rzucony wyjątek I/O, ponieważ plik jest zablokowany aż do zwolnienia obiektu prezentacji.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt prezentacji.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Aby obejść pewne ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje skopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.), możesz użyć [BLOB management](/slides/pl/androidjava/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrola zewnętrznych zasobów**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iresourceloadingcallback/), który pozwala zarządzać zewnętrznymi zasobami. Poniższy kod w języku Java pokazuje, jak używać interfejsu `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Załaduj zamienny obraz.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Użyj dowolnej metody, aby uzyskać bajty
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ustaw zamienny adres URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Pomiń wszystkie pozostałe obrazy.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy osadzonych obiektów binarnych:

- Projekt VBA (dostępny przez [IPresentation.getVbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Osadzone dane obiektu OLE (dostępne przez [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Danych binarnych kontrolki ActiveX (dostępne przez [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Korzystając z metody [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), możesz załadować prezentację bez żadnych osadzonych obiektów binarnych.

Ta metoda jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w języku Java demonstruje, jak załadować prezentację bez jakiejkolwiek osadzonej treści binarnej:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Wykonaj operacje na prezentacji.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może być otwarty?**

Podczas ładowania otrzymasz wyjątek walidacji parsowania/formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli wymagane czcionki są brakujące podczas otwierania?**

Plik zostanie otwarty, ale później podczas [renderowania/eksportu](/slides/pl/androidjava/convert-presentation/) mogą zostać zastąpione czcionki. [Skonfiguruj zamiany czcionek](/slides/pl/androidjava/font-substitution/) lub [dodaj wymagane czcionki](/slides/pl/androidjava/custom-font/) do środowiska uruchomieniowego.

**A co z osadzonymi mediami (wideo/audio) podczas otwierania?**

Stają się dostępne jako zasoby prezentacji. Jeśli media są odwoływane przez zewnętrzne ścieżki, upewnij się, że są dostępne w Twoim środowisku; w przeciwnym razie podczas [renderowania/eksportu](/slides/pl/androidjava/convert-presentation/) media mogą zostać pominięte.