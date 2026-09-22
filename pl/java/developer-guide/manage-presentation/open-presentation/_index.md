---
title: Otwieranie prezentacji w Javie
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w Javie, podawać hasła otwierające, kontrolować ładowanie zasobów oraz zmniejszać użycie pamięci przy użyciu Aspose.Slides for Java."
---
## **Wprowadzenie**

[Aspose.Slides for Java](https://products.aspose.com/slides/pl/java/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/). Na przykład możesz podać hasło otwierające, trzymać duże obiekty binarne poza pamięcią sterty Java, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Po załadowaniu pliku lub strumienia możesz [określić jego oryginalny format prezentacji](/slides/pl/java/detect-presentation-source-format/), aby wybrać sposób przetwarzania go przez aplikację.

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Zwolnij prezentację po użyciu, aby szybko zwolnić uchwyty plików, dane tymczasowe i inne zasoby.

Poniższy przykład w Javie pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

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

Hasło otwierające szyfruje zawartość prezentacji. Aby wczytać całą prezentację, przekaż poprawne hasło do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) i podaj opcje konstruktorowi [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub nieprawidłowe.

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

Aby uzyskać informacje o wykrywaniu, walidacji i szyfrowaniu haseł, zobacz [Prezentacje zabezpieczone hasłem](/slides/pl/java/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Zarządzanie właściwościami prezentacji](/slides/pl/java/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) zwraca opcje kontrolujące, jak Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, dźwięk i wideo. Możesz utrzymać plik źródłowy zablokowany, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod w Javie demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

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
Za pomocą [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) plik źródłowy pozostaje zablokowany, dopóki nie zostanie zwolniona instancja prezentacji. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.
{{% /alert %}}

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas jego ładowania. Dla dużych prezentacji ścieżka do pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Zarządzanie BLOBami](/slides/pl/java/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.

## **Kontrola zasobów zewnętrznych**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) akceptuje implementację [IResourceLoadingCallback](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iresourceloadingcallback/). Wywołanie zwrotne może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego ładowania lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają zewnętrzne obrazy, które muszą być rozwiązywane zgodnie z regułami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

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

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachować. Przykłady obejmują:

- projekty VBA, dostępne za pośrednictwem [IPresentation.getVbaProject](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getVbaProject--);
- osadzone dane OLE, dostępne za pośrednictwem [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- dane kontrolki ActiveX, dostępne za pośrednictwem [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icontrol/#getActiveXControlBinary).

Ustaw [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) na `true`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby utrwalić oczyszczony wynik.

Ta opcja zmniejsza ryzyko niepożądanych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

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

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal zostać załadowana, ale renderowanie i eksport mogą zastąpić czcionki. Możesz [konfigurować zamianę czcionek](/slides/pl/java/font-substitution/) lub [dostarczyć własne czcionki](/slides/pl/java/custom-font/), aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji powoduje również ładowanie jej osadzonych mediów?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.