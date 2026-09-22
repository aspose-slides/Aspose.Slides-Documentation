---
title: Otwieranie prezentacji w Pythonie
linktitle: Otwieranie prezentacji
type: docs
weight: 20
url: /pl/python-net/open-presentation/
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
- chroniona prezentacja
- duża prezentacja
- zewnętrzny zasób
- obiekt binarny
- Python
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w Pythonie, podawać hasła otwierające oraz zmniejszać zużycie pamięci za pomocą Aspose.Slides for Python via .NET."
---
## **Wprowadzenie**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/pl/python-net/) może ładować prezentacje PowerPoint i OpenDocument z plików oraz strumieni. Po załadowaniu prezentacji możesz przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w pierwotnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/). Na przykład możesz podać hasło otwierające, trzymać duże obiekty binarne poza pamięcią lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Po załadowaniu pliku lub strumienia możesz [określić jego pierwotny format prezentacji](/slides/pl/python-net/detect-presentation-source-format/), aby wybrać sposób przetwarzania go przez aplikację.

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Użyj instrukcji `with`, aby uchwyty plików, dane tymczasowe i inne zasoby zostały zwolnione niezwłocznie.

Poniższy przykład w Pythonie pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Otwieranie prezentacji chronionych hasłem**

Hasło otwierające szyfruje zawartość prezentacji. Aby załadować całą prezentację, przypisz prawidłowe hasło do [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest nieobecne lub nieprawidłowe.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

W celu wykrywania, weryfikacji i szyfrowania haseł zapoznaj się z artykułem [Password-Protect Presentations](/slides/pl/python-net/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, można odczytać te właściwości bez hasła; zobacz [Manage Presentation Properties](/slides/pl/python-net/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/blob_management_options/) kontroluje sposób, w jaki Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Możesz utrzymać plik źródłowy w stanie zablokowanym, zezwolić na pliki tymczasowe oraz ograniczyć ilość danych BLOB przechowywanych w pamięci.

Ten kod w Pythonie demonstruje ładowanie dużej prezentacji (na przykład 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Note" %}}
Przy `PresentationLockingBehavior.KEEP_LOCKED` plik źródłowy pozostaje zablokowany, aż obiekt `Presentation` zostanie zwolniony. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, dopóki ten obiekt istnieje.
{{% /alert %}}

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas jego ładowania. W przypadku dużych prezentacji ścieżka do pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Zarządzaj BLOB‑ami](/slides/pl/python-net/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachowywać. Przykłady obejmują:

- projekty VBA, dostępne poprzez [Presentation.vba_project](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/vba_project/);
- osadzone dane OLE, dostępne poprzez [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- dane kontroli ActiveX, dostępne poprzez [Control.active_x_control_binary](https://reference.aspose.com/slides/pl/python-net/aspose.slides/control/active_x_control_binary/).

Ustaw [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) na `True`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować wyczyszczony wynik.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię osobno od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie poinformować o przyczynie.

**Co się stanie, jeśli brakuje wymaganych czcionek?**

Prezentacja może się nadal ładować, ale renderowanie i eksport mogą zastępować czcionki. Możesz [skonfiguruj podstawianie czcionek](/slides/pl/python-net/font-substitution/) lub [zapewnij własne czcionki](/slides/pl/python-net/custom-font/), aby wynik był bardziej przewidywalny.

**Czy ładowanie prezentacji powoduje również ładowanie jej osadzonych mediów?**

Osadzone dźwięki i wideo stają się dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z domyślnym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie da się uzyskać.