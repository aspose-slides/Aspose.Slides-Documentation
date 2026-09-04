---
title: Otwieranie prezentacji w JavaScript
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/nodejs-java/open-presentation/
keywords:
- otwórz PowerPoint
- otwórz prezentację
- otwórz PPTX
- otwórz PPT
- otwórz ODP
- wczytaj prezentację
- wczytaj PPTX
- wczytaj PPT
- wczytaj ODP
- zabezpieczona prezentacja
- duża prezentacja
- zasób zewnętrzny
- obiekt binarny
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w JavaScript, podawać hasła otwierające, kontrolować ładowanie zasobów i zmniejszać zużycie pamięci przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Wprowadzenie**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/pl/nodejs-java/) może ładować prezentacje PowerPoint i OpenDocument z plików i strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować przy pomocy klasy [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/). Na przykład możesz podać hasło otwierające, trzymać duże obiekty binarne poza pamięcią Node.js, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Zwolnij prezentację po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Poniższy przykład JavaScript pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Hasło otwierające szyfruje zawartość prezentacji. Aby załadować całą prezentację, przekaż prawidłowe hasło do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setPassword) i podaj opcje konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub nieprawidłowe.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

W celu wykrywania, weryfikacji i szyfrowania haseł zobacz [Password-Protect Presentations](/slides/pl/nodejs-java/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Manage Presentation Properties](/slides/pl/nodejs-java/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) zwraca opcje kontrolujące, jak Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, dźwięk i wideo. Możesz utrzymać plik źródłowy zablokowany, zezwolić na pliki tymczasowe oraz ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod JavaScript demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Uwaga" %}}
Przy użyciu [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) plik źródłowy pozostaje zablokowany, dopóki instancja prezentacji nie zostanie zwolniona. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas jego ładowania. Dla dużych prezentacji ścieżka pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Manage BLOBs](/slides/pl/nodejs-java/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) przyjmuje implementację [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/). Wywołanie zwrotne może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego ładowania lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają obrazy zewnętrzne, które muszą być rozwiązywane zgodnie z regułami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, których aplikacja nie potrzebuje lub nie chce zachować. Przykłady obejmują:

- projekty VBA, dostępne przez [Presentation.getVbaProject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getVbaProject);
- osadzone dane OLE, dostępne przez [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dane kontrolki ActiveX, dostępne przez [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Ustaw [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować wyczyszczony wynik.

Ta opcja zmniejsza ryzyko niepożądanych osadzonych ładunków, ale nie jest kompletnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie poinformować o przyczynie.

**Co się stanie, jeśli brak będzie wymaganych czcionek?**

Prezentacja nadal może się załadować, ale renderowanie i eksport mogą podmienić czcionki. możesz [skonfigurować podstawianie czcionek](/slides/pl/nodejs-java/font-substitution/) lub [dostarczyć własne czcionki](/slides/pl/nodejs-java/custom-font/), aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji powoduje również ładowanie osadzonych mediów?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.