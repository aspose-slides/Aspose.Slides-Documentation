---
title: Otwieranie prezentacji w JavaScript
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/nodejs-java/open-presentation/
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
- zasób zewnętrzny
- obiekt binarny
- Node.js
- JavaScript
- Aspose.Slides
description: "Otwieraj prezentacje PowerPoint (.pptx, .ppt) oraz OpenDocument (.odp) bez wysiłku przy użyciu Aspose.Slides dla Node.js w Java - szybko, niezawodnie, w pełni funkcjonalnie."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia również otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz pobrać informacje o niej, edytować treść slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i przekaż do jej konstruktora ścieżkę do pliku.

Poniższy przykład w JavaScript pokazuje, jak otworzyć prezentację i uzyskać liczbę jej slajdów:

```js
// Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku do jej konstruktora.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Wypisz łączną liczbę slajdów w prezentacji.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Gdy potrzebujesz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło metodą [setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword) klasy [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/), aby odszyfrować i załadować ją. Poniższy kod w JavaScript demonstruje tę operację:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Wykonaj operacje na odszyfrowanej prezentacji.
} finally {
    presentation.dispose();
}
```

## **Otwieranie dużych prezentacji**

Aspose.Slides udostępnia opcje — w szczególności metodę [getBlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) w klasie [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/) — które pomagają w ładowaniu dużych prezentacji.

Poniższy kod w JavaScript demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez cały czas życia
// instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Duża prezentacja została załadowana i można ją używać, przy jednoczesnym niskim zużyciu pamięci.
    
    // Wprowadź zmiany w prezentacji.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Nie rób tego! Zostanie zgłoszony wyjątek I/O, ponieważ plik jest zablokowany aż do zwolnienia obiektu prezentacji.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Można to zrobić tutaj. Źródłowy plik nie jest już zablokowany przez obiekt prezentacji.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Aby obejść niektóre ograniczenia przy pracy ze strumieniami, Aspose.Slides może kopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje kopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy musisz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.), możesz użyć [BLOB management](/slides/pl/nodejs-java/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Kontrolowanie zasobów zewnętrznych**

Aspose.Slides udostępnia interfejs [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/), który pozwala zarządzać zasobami zewnętrznymi. Poniższy kod w JavaScript pokazuje, jak używać interfejsu `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Załaduj zastępczy obraz.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Ustaw zastępczy URL.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Pomiń wszystkie pozostałe obrazy.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy osadzonych obiektów binarnych:

- projekt VBA (dostępny za pośrednictwem [Presentation.getVbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getVbaProject));
- osadzone dane obiektu OLE (dostępne za pośrednictwem [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- binarne dane kontrolki ActiveX (dostępne za pośrednictwem [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Za pomocą metody [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) możesz załadować prezentację bez żadnych osadzonych obiektów binarnych.

Ta metoda jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w JavaScript demonstruje, jak załadować prezentację bez żadnych osadzonych treści binarnych:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Wykonaj operacje na prezentacji.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może być otwarty?**

Podczas ładowania otrzymasz wyjątek parsowania/validacji formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli podczas otwierania brakują wymagane czcionki?**

Plik zostanie otwarty, ale później [rendering/export](/slides/pl/nodejs-java/convert-presentation/) może zastąpić czcionki. [Configure font substitutions](/slides/pl/nodejs-java/font-substitution/) lub [add the required fonts](/slides/pl/nodejs-java/custom-font/) w środowisku uruchomieniowym.

**Co z osadzonymi mediami (wideo/audio) przy otwieraniu?**

Stają się dostępne jako zasoby prezentacji. Jeśli media są odwoływane przez ścieżki zewnętrzne, upewnij się, że te ścieżki są dostępne w Twoim środowisku; w przeciwnym razie [rendering/export](/slides/pl/nodejs-java/convert-presentation/) może pominąć media.