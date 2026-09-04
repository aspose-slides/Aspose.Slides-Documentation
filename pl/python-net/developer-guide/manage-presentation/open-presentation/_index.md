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
- zabezpieczona prezentacja
- duża prezentacja
- zewnętrzny zasób
- obiekt binarny
- Python
- Aspose.Slides
description: "Dowiedz się, jak otwierać prezentacje PowerPoint i OpenDocument w Pythonie, podawać hasła otwierające oraz zmniejszać zużycie pamięci przy użyciu Aspose.Slides for Python via .NET."
---
## **Wprowadzenie**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/pl/python-net/) może ładować prezentacje PowerPoint i OpenDocument z plików i strumieni. Po załadowaniu prezentacji można przeglądać jej strukturę, edytować slajdy, zarządzać zasobami i zapisać ją w oryginalnym lub innym obsługiwanym formacie.

Zachowanie ładowania można dostosować za pomocą klasy [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/). Na przykład można podać hasło otwarcia, przechowywać duże obiekty binarne poza pamięcią lub pominąć osadzone dane binarne.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, przekaż jej ścieżkę pliku do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Użyj instrukcji `with`, aby uchwyty plików, tymczasowe dane i inne zasoby zostały szybko zwolnione.

Poniższy przykład w Pythonie pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Hasło otwarcia szyfruje zawartość prezentacji. Aby załadować pełną prezentację, przypisz prawidłowe hasło do [LoadOptions.password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/) i przekaż opcje do konstruktora [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/). Ładowanie nie powiedzie się, gdy hasło jest brakujące lub nieprawidłowe.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Aby uzyskać informacje o wykrywaniu, weryfikacji i szyfrowaniu haseł, zobacz [Password-Protect Presentations](/slides/pl/python-net/password-protected-presentation/). Jeśli zaszyfrowana prezentacja została celowo zapisana z publicznymi właściwościami dokumentu, można odczytać te właściwości bez hasła; zobacz [Manage Presentation Properties](/slides/pl/python-net/presentation-properties/).

## **Otwieranie dużych prezentacji**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/blob_management_options/) kontroluje, jak Aspose.Slides obsługuje duże obiekty binarne, takie jak obrazy, audio i wideo. Można utrzymać plik źródłowy zablokowany, zezwolić na pliki tymczasowe i ograniczyć ilość danych BLOB przechowywanych w pamięci.

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
Z `PresentationLockingBehavior.KEEP_LOCKED` plik źródłowy pozostaje zablokowany, aż obiekt `Presentation` zostanie zwolniony. Nie przenoś, nie nadpisuj ani nie usuwaj pliku źródłowego, gdy ten obiekt jest aktywny.

Aspose.Slides może kopiować zawartość strumienia wejściowego podczas ładowania. Dla dużych prezentacji ścieżka pliku jest zazwyczaj bardziej wydajna niż strumień. Zobacz [Manage BLOBs](/slides/pl/python-net/manage-blob/) po dodatkowe opcje przechowywania i zarządzania pamięcią.
{{% /alert %}}

## **Ładowanie prezentacji bez osadzonych obiektów binarnych**

Prezentacja może zawierać osadzone dane binarne, które aplikacja nie potrzebuje lub nie chce zachować. Przykłady obejmują:
- projekty VBA, dostępne przez [Presentation.vba_project](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/vba_project/);
- osadzone dane OLE, dostępne przez [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- dane kontrolek ActiveX, dostępne przez [Control.active_x_control_binary](https://reference.aspose.com/slides/pl/python-net/aspose.slides/control/active_x_control_binary/).

Ustaw [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) na `True`, aby usunąć te dane binarne podczas ładowania. Zapisz załadowaną prezentację, aby zachować oczyszczony wynik.

Ta opcja zmniejsza ryzyko niechcianych osadzonych ładunków, ale nie jest pełnym systemem wykrywania złośliwego oprogramowania ani sanitizacji treści.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może być otwarty?**

Aspose.Slides zgłasza wyjątek parsowania lub formatu podczas ładowania. Obsłuż tę awarię oddzielnie od błędu nieprawidłowego hasła, aby aplikacja mogła dokładnie zgłosić przyczynę.

**Co się stanie, jeśli brak wymaganych czcionek?**

Prezentacja może nadal zostać załadowana, ale renderowanie i eksport mogą zastąpić czcionki. Możesz [configure font substitution](/slides/pl/python-net/font-substitution/) lub [provide custom fonts](/slides/pl/python-net/custom-font/) aby uzyskać bardziej przewidywalny wynik.

**Czy ładowanie prezentacji powoduje również ładowanie jej osadzonych mediów?**

Osadzone audio i wideo są dostępne poprzez model obiektowy prezentacji. Zasoby zewnętrzne są rozwiązywane zgodnie z domyślnym zachowaniem ładowania zasobów i mogą być niedostępne, jeśli ich lokalizacji nie można uzyskać.