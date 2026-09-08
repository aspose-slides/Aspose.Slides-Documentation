---
title: Otwieranie prezentacji w Pythonie za pośrednictwem Java
linktitle: Otwórz prezentację
type: docs
weight: 20
url: /pl/python-java/open-presentation/
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
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w Pythonie za pośrednictwem Java, podawać hasła otwierające, kontrolować ładowanie zasobów oraz zmniejszać zużycie pamięci przy użyciu Aspose.Slides dla Pythona za pośrednictwem Java."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować przy użyciu klasy [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/). Na przykład możesz podać hasło otwierające, przechowywać duże obiekty binarne poza pamięcią sterty Java, kontrolować zasoby zewnętrzne lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Zwolnij prezentację po użyciu, aby uchwyty plików, dane tymczasowe i inne zasoby zostały szybko zwolnione.

Poniższy przykład w Pythonie pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Otwieranie zabezpieczonych hasłem prezentacji**

Hasło otwierające szyfruje zawartość prezentacji. Aby załadować pełną prezentację, podaj poprawne hasło do [LoadOptions.setPassword](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setPassword) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/). Ładowanie kończy się niepowodzeniem, gdy hasło jest nieobecne lub nieprawidłowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

W celu wykrywania, weryfikacji haseł i procesów szyfrowania zobacz [Zabezpieczanie prezentacji hasłem](/slides/pl/python-java/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, te właściwości można odczytać bez hasła; zobacz [Zarządzanie właściwościami prezentacji](/slides/pl/python-java/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) zwraca opcje kontrolujące sposób, w jaki Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, dźwięk i wideo. Możesz utrzymać plik źródłowy zablokowany, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

Poniższy kod w Pythonie demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Przy użyciu PresentationLockingBehavior.KeepLocked plik źródłowy pozostaje zablokowany aż do zwolnienia instancji prezentacji. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ta instancja jest aktywna.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka pliku jest zazwyczaj wydajniejsza niż strumień. Zobacz [Zarządzanie BLOB-ami](/slides/pl/python-java/manage-blob/) w celu uzyskania dodatkowych opcji przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Kontrola zasobów zewnętrznych**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) akceptuje proxy JPype implementujące interfejs Java callbacku ładowania zasobów. Callback może dostarczyć dane zastępcze, przekierować zasób, użyć domyślnego loadera lub pominąć zasób. Jest to przydatne, gdy prezentacje zawierają obrazy zewnętrzne, które muszą być rozwiązywane zgodnie z zasadami bezpieczeństwa lub przechowywania specyficznymi dla aplikacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachowywać. Przykłady obejmują:

- projekty VBA, dostępne przez [Presentation.getVbaProject](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getVbaProject);
- osadzone dane OLE, dostępne przez [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- dane kontrolki ActiveX, dostępne przez [Control.getActiveXControlBinary](https://reference.aspose.com/slides/pl/python-java/aspose.slides/control/#getActiveXControlBinary).

Ustaw [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `True`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować odsanowaną wersję.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię oddzielnie od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal zostać załadowana, ale renderowanie i eksport mogą zastąpić czcionki. Możesz skonfigurować substytucję czcionek lub dostarczyć własne czcionki, aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji ładuje również jej osadzone media?**

Osadzone audio i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z skonfigurowanym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.