---
title: Otwieranie prezentacji w Javie
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Łatwo otwieraj prezentacje PowerPoint (.pptx, .ppt) oraz OpenDocument (.odp) za pomocą Aspose.Slides dla Javy — szybkie, niezawodne, w pełni funkcjonalne."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia także otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz pobrać informacje o niej, edytować zawartość slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, zainstaluj klasę [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) i przekaż ścieżkę do pliku w jej konstruktorze.

Poniższy przykład w języku Java pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```java
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku w jej konstruktorze.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Wypisz łączną liczbę slajdów w prezentacji.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Gdy musisz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło do metody [setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) klasy [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/), aby odszyfrować i załadować ją. Poniższy kod w języku Java demonstruje tę operację:

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

Aspose.Slides udostępnia opcje — w szczególności metodę [getBlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) w klasie [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/) — aby pomóc w ładowaniu dużych prezentacji.

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
    // Duża prezentacja została załadowana i może być używana, przy niskim zużyciu pamięci.

    // Wprowadź zmiany w prezentacji.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Nie rób tego! Zostanie zgłoszony wyjątek I/O, ponieważ plik jest zablokowany, dopóki obiekt prezentacji nie zostanie zwolniony.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt prezentacji.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Aby obejść pewne ograniczenia przy pracy ze strumieniami, Aspose.Slides może skopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje kopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy o wysokiej rozdzielczości itp.) możesz użyć [Zarządzanie BLOB](/slides/pl/java/manage-blob/) aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrola zasobów zewnętrznych**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/), który pozwala zarządzać zasobami zewnętrznymi. Poniższy kod w języku Java pokazuje, jak używać interfejsu `IResourceLoadingCallback`:

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
                // Wczytaj zamienny obraz.
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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

- Projekt VBA (dostępny poprzez [IPresentation.getVbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Osadzone dane obiektu OLE (dostępne poprzez [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Binarny kod kontrolki ActiveX (dostępny poprzez [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Korzystając z metody [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) możesz załadować prezentację bez żadnych osadzonych obiektów binarnych.

Ta metoda jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w języku Java demonstruje, jak załadować prezentację bez żadnych osadzonych treści binarnych:

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

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Podczas ładowania otrzymasz wyjątek parsowania/validacji formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli podczas otwierania brakują wymagane czcionki?**

Plik zostanie otwarty, ale później [renderowanie/eksport](/slides/pl/java/convert-presentation/) może zastąpić czcionki. [Skonfiguruj zamiany czcionek](/slides/pl/java/font-substitution/) lub [dodaj wymagane czcionki](/slides/pl/java/custom-font/) w środowisku uruchomieniowym.

**Co z osadzonymi mediami (wideo/audio) podczas otwierania?**

Stają się dostępne jako zasoby prezentacji. Jeśli media są odwoływane za pomocą zewnętrznych ścieżek, upewnij się, że te ścieżki są dostępne w twoim środowisku; w przeciwnym razie [renderowanie/eksport](/slides/pl/java/convert-presentation/) może pominąć media.