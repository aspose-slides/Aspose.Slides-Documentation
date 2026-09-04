---
title: Otwieranie prezentacji na Androidzie
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/androidjava/open-presentation/
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
- zewnętrzny zasób
- obiekt binarny
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument na Androidzie, podawać hasła otwierające, kontrolować ładowanie zasobów oraz zmniejszać zużycie pamięci przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Wprowadzenie**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/pl/androidjava/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/). Na przykład możesz podać hasło otwierające, przechowywać duże obiekty binarne poza pamięcią sterty Java, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Żeby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Zwolnij obiekt prezentacji po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Następujący przykład w języku Java pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Hasło otwierające szyfruje zawartość prezentacji. Aby załadować całą prezentację, przekaż prawidłowe hasło do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) i podaj opcje konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub niepoprawne.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Dla wykrywania haseł, ich walidacji oraz procesów szyfrowania zobacz [Password‑Protect Presentations](/slides/pl/androidjava/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, można odczytać te właściwości bez hasła; zobacz [Manage Presentation Properties](/slides/pl/androidjava/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) zwraca opcje kontrolujące, jak Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Możesz utrzymać plik źródłowy w stanie zablokowanym, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod w języku Java demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Przy użyciu [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) plik źródłowy pozostaje zablokowany, dopóki nie zostanie zwolniony obiekt prezentacji. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka do pliku jest zazwyczaj wydajniejsza niż strumień. Zobacz [Manage BLOBs](/slides/pl/androidjava/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) akceptuje implementację [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iresourceloadingcallback/). Wywołanie zwrotne może dostarczyć dane zamienne, przekierować zasób, użyć domyślnego ładowarki lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z zasadami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, których aplikacja nie potrzebuje lub nie chce przechowywać. Przykłady:

- projekty VBA, dostępne poprzez [IPresentation.getVbaProject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- osadzone dane OLE, dostępne poprzez [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- dane kontroli ActiveX, dostępne poprzez [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Ustaw [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować oczyszczony wynik.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest kompletnym systemem wykrywania malware ani sanitizacji treści.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatowy podczas ładowania. Obsłuż tę niepowodzenie osobno od błędu niewłaściwego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal zostać załadowana, ale renderowanie i eksport mogą podmienić czcionki. Możesz [konfigurację zamiany czcionek](/slides/pl/androidjava/font-substitution/) lub [dostarczyć własne czcionki](/slides/pl/androidjava/custom-font/) aby wyniki były bardziej przewidywalne.

**Czy ładowanie prezentacji ładuje również jej osadzone media?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie ze skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.