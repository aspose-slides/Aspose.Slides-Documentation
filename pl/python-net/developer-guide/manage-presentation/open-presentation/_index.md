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
- załaduj prezentację
- załaduj PPTX
- załaduj PPT
- załaduj ODP
- zabezpieczona prezentacja
- duża prezentacja
- zasób zewnętrzny
- obiekt binarny
- Python
- Aspose.Slides
description: "Otwieraj prezentacje PowerPoint (.pptx, .ppt) oraz OpenDocument (.odp) z łatwością przy użyciu Aspose.Slides dla Pythona poprzez .NET — szybko, niezawodnie, w pełni funkcjonalnie."
---
## **Wprowadzenie**

Poza tworzeniem prezentacji PowerPoint od podstaw, Aspose.Slides umożliwia również otwieranie istniejących prezentacji. Po załadowaniu prezentacji możesz odczytać informacje o niej, edytować zawartość slajdów, dodawać nowe slajdy, usuwać istniejące i wiele więcej.

## **Otwieranie prezentacji**

Aby otworzyć istniejącą prezentację, utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i przekaż ścieżkę do pliku w konstruktorze.

Poniższy przykład w Pythonie pokazuje, jak otworzyć prezentację i uzyskać liczbę slajdów:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation i przekaż ścieżkę do pliku w jej konstruktorze.
with slides.Presentation("sample.pptx") as presentation:
    # Wydrukuj całkowitą liczbę slajdów w prezentacji.
    print(presentation.slides.length)
```

## **Otwieranie prezentacji zabezpieczonych hasłem**

Kiedy musisz otworzyć prezentację zabezpieczoną hasłem, przekaż hasło poprzez właściwość [password](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/password/) klasy [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/) w celu odszyfrowania i załadowania jej. Poniższy kod w Pythonie demonstruje tę operację:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Wykonaj operacje na odszyfrowanej prezentacji.
```

## **Otwieranie dużych prezentacji**

Aspose.Slides oferuje opcje — w szczególności właściwość [blob_management_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/blob_management_options/) klasy [LoadOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/) — które pomagają w ładowaniu dużych prezentacji.

Ten kod w Pythonie pokazuje, jak załadować dużą prezentację (na przykład 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Wybierz zachowanie KeepLocked — plik prezentacji pozostanie zablokowany przez cały czas życia 
# instancji Presentation, ale nie musi być ładowany do pamięci ani kopiowany do pliku tymczasowego.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Duża prezentacja została załadowana i może być używana, przy jednoczesnym niskim zużyciu pamięci.

    # Wprowadź zmiany w prezentacji.
    presentation.slides[0].name = "Large presentation"

    # Zapisz prezentację do innego pliku. Zużycie pamięci pozostaje niskie podczas tej operacji.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Nie rób tego! Zostanie rzucony wyjątek I/O, ponieważ plik jest zablokowany aż do zwolnienia obiektu prezentacji.
    os.remove(file_path)

# Można to zrobić tutaj. Plik źródłowy nie jest już zablokowany przez obiekt prezentacji.
os.remove(file_path)
```

{{% alert color="info" title="Informacja" %}}
Aby obejść pewne ograniczenia przy pracy ze strumieniami, Aspose.Slides może skopiować zawartość strumienia. Ładowanie dużej prezentacji ze strumienia powoduje skopiowanie prezentacji i może spowolnić ładowanie. Dlatego, gdy potrzebujesz załadować dużą prezentację, zdecydowanie zalecamy użycie ścieżki do pliku prezentacji zamiast strumienia.

Podczas tworzenia prezentacji zawierającej duże obiekty (wideo, audio, obrazy wysokiej rozdzielczości itp.) możesz użyć [zarządzania BLOB](/slides/pl/python-net/manage-blob/), aby zmniejszyć zużycie pamięci.
{{%/alert %}}

## **Ładowanie prezentacji bez wbudowanych obiektów binarnych**

Prezentacja PowerPoint może zawierać następujące typy wbudowanych obiektów binarnych:

- projekt VBA (dostępny przez [Presentation.vba_project](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/vba_project/));
- dane wbudowanego obiektu OLE (dostępne przez [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- dane binarne kontroli ActiveX (dostępne przez [Control.active_x_control_binary](https://reference.aspose.com/slides/pl/python-net/aspose.slides/control/active_x_control_binary/)).

Używając właściwości [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/pl/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) możesz załadować prezentację bez żadnych wbudowanych obiektów binarnych.

Ta właściwość jest przydatna do usuwania potencjalnie złośliwych treści binarnych. Poniższy kod w Pythonie demonstruje, jak załadować prezentację bez wbudowanych treści binarnych:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Wykonaj operacje na prezentacji.
```

## **FAQ**

**Jak mogę stwierdzić, że plik jest uszkodzony i nie może zostać otwarty?**

Podczas ładowania zostanie zgłoszony wyjątek parsowania/validacji formatu. Takie błędy często wskazują na nieprawidłową strukturę ZIP lub uszkodzone rekordy PowerPoint.

**Co się stanie, jeśli wymagane czcionki są brakujące podczas otwierania?**

Plik zostanie otwarty, ale późniejsze [renderowanie/eksportowanie](/slides/pl/python-net/convert-presentation/) może zastąpić czcionki. [Skonfiguruj podstawienia czcionek](/slides/pl/python-net/font-substitution/) lub [dodaj wymagane czcionki](/slides/pl/python-net/custom-font/) do środowiska uruchomieniowego.

**Co z wbudowanymi mediami (wideo/audio) podczas otwierania?**

Stają się one dostępne jako zasoby prezentacji. Jeśli media są odwoływane przez zewnętrzne ścieżki, upewnij się, że te ścieżki są dostępne w twoim środowisku; w przeciwnym razie [renderowanie/eksportowanie](/slides/pl/python-net/convert-presentation/) może pominąć media.