---
title: Eksportowanie prezentacji do XAML przy użyciu Pythona
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/python-net/export-to-xaml/
keywords:
- eksport PowerPoint
- eksport OpenDocument
- eksport prezentacji
- konwersja PowerPoint
- konwersja OpenDocument
- konwersja prezentacji
- PowerPoint do XAML
- OpenDocument do XAML
- prezentacja do XAML
- PPT do XAML
- PPTX do XAML
- ODP do XAML
- zapisz PPT jako XAML
- zapisz PPTX jako XAML
- zapisz ODP jako XAML
- eksport PPT do XAML
- eksport PPTX do XAML
- eksport ODP do XAML
- Python
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint i OpenDocument do XAML przy użyciu Pythona i Aspose.Slides — szybkie rozwiązanie bez Office, które zachowuje układ."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację jako XAML z ustawieniami domyślnymi oraz prezentuje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/), w tym eksport ukrytych slajdów. Artykuł odpowiada również na kilka często zadawanych pytań dotyczących czcionek zapasowych, kompatybilności stosu XAML oraz zachowania przy eksporcie ukrytych slajdów.

## **O XAML**

XAML to język znaczników oparty na XML, używany do opisywania interfejsów użytkownika w frameworkach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin.Forms.

Plikami XAML możesz pracować w projektancie wizualnym lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Poniższy przykład w języku Python pokazuje, jak wyeksportować prezentację do XAML przy użyciu ustawień domyślnych:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu roboczego procesu, zwracanym przez [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). Folder jest tworzony automatycznie, a wszystkie wymagane obrazy również są tam zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla `pres.pptx` pliki wyjściowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli podasz bezwzględną ścieżkę do wejściowej prezentacji, folder wyjściowy jest tworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj klasy [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/) aby kontrolować, w jaki sposób Aspose.Slides eksportuje prezentację do XAML.

Aby uwzględnić ukryte slajdy w wyjściu XAML, ustaw właściwość [export_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) na `True`, jak pokazano w poniższym przykładzie w Pythonie:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Zbierz wszystkie wygenerowane artefakty XAML**

Eksport XAML może wygenerować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Zachowaj wszystkie te pliki przy przechowywaniu lub przesyłaniu eksportu.

Poniższe przykłady używają domyślnego zapisu do systemu plików w katalogu tymczasowym, a następnie zbierają wygenerowane pliki.

### **Zrozum cykl życia eksportu**

- Rozpocznij eksport przy użyciu specyficznego dla XAML przeciążenia [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) które przyjmuje opcje XAML. Odczytuj wygenerowane pliki dopiero po pomyślnym zakończeniu wywołania.
- Zachowaj względną ścieżkę każdego artefaktu, ponieważ XAML może odwoływać się do zasobów za pomocą ścieżek względnych.
- Odczytuj artefakty jako bajty. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zgłaszaj ogólny sukces dopiero po zakończeniu zbierania i wszelkich kolejnych operacji przechowywania. Niech błędy przechowywania trafią do wywołującego, a w przypadku niepowodzenia utrwalania usuń częściowy wynik.

[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) domyślnie ma wartość `False`, co powoduje wykluczenie dokumentów XAML dla ukrytych slajdów. Ustawienie jej na `True` uwzględnia je oraz wszystkie zasoby potrzebne do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego pliku na slajd.

{{% alert color="warning" title="Warning" %}}
Przykłady tymczasowo zmieniają bieżący katalog roboczy procesu, co wpływa na wszystkie wątki. Uruchamiaj każdy eksport w dedykowanym procesie roboczym lub upewnij się, że żadne inne operacje w procesie nie zależą od bieżącego katalogu podczas eksportu. Unikalny katalog tymczasowy sam w sobie nie zapewnia bezpieczeństwa równoczesnych eksportów w tym samym procesie.
{{% /alert %}}

### **Eksport do pamięci i inspekcja artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, eksportuje go do katalogu tymczasowego, zbiera każdy artefakt w słowniku z nazwami względnymi i bajtami oraz wypisuje jego nazwę, typ i liczbę bajtów. Zachowuje strukturę katalogów oraz usuwa pliki tymczasowe po zbiorze. Ścieżka wejściowa jest rozwiązywana przed zmianą katalogu roboczego.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest inspekcja tekstowa.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Sprawdzanie rozszerzeń jest przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy przechowywaniu lub przesyłaniu. Dekoduj tylko XAML, który wymaga przetwarzania tekstowego. To podejście wykorzystuje tymczasową przestrzeń dyskową oraz pamięć dla zebranych danych eksportu.

### **Spakuj zebrane artefakty w archiwum ZIP**

Ten niezależny przykład gromadzi eksport, weryfikuje jego nazwy i zapisuje oryginalne bajty do archiwum ZIP. Unikalna nazwa archiwum rozdziela zadania eksportu. Wpisy ZIP używają ukośników i zachowują katalogi względne. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed jego zapisaniem.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # Katalog ZIP został sfinalizowany przed zgłoszeniem powodzenia.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

Przykład używa [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile), aby zapisać jedno lokalne archiwum po zebranie tymczasowego eksportu. W przypadku przechowywania zdalnego, zastąp etap zapisu archiwum przesyłaniem zebranych bajtów. Użyj identyfikatora zadania eksportu oraz pełnej względnej nazwy artefaktu jako klucza obiektu, lub przechowuj identyfikator zadania, nazwę względną i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesyłek lub zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli utrwalenie się nie powiedzie.

W przypadku dużych prezentacji przetwarzaj tymczasowe pliki pojedynczo po eksporcie, zamiast zbierać wszystkie ich bajty w słowniku. To unika dodatkowej kopii całego eksportu w pamięci, ale nie eliminuje wymagań pamięciowych samego eksportera.

### **Zachowaj nazwy zasobów i zweryfikuj odwołania**

- Normalizuj separatory ścieżek, gdy wymaga tego miejsce docelowe, ale zachowuj katalogi względne. Nie zachowuj tylko końcowej nazwy pliku, chyba że każda wygenerowana nazwa jest unikalna i odwołania do zasobów pozostają prawidłowe.
- Zastosuj walidację nazw specyficzną dla miejsca docelowego. Przy zapisie luźnych plików odrzuć ścieżki bezwzględne i segmenty traversalu, rozwiąż miejsce docelowe i zweryfikuj, że znajduje się pod zamierzonym katalogiem eksportu. Używaj katalogu kontrolowanego przez aplikację, bez linków symbolicznych, które mogłyby przekierowywać zapisy.
- Użyj oddzielnej przestrzeni nazw przechowywania dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatorów oraz zgodnie z regułami wielkości liter w miejscu docelowym.
- Przed publikacją przeanalizuj każdy dokument XAML jako XML i sprawdź jego odniesienia do zasobów plikowych, takie jak atrybuty `Source` lub `ImageSource` obrazu. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj otrzymaną nazwę przechowywania i potwierdź, że istnieje odpowiadający klucz słownika, wpis ZIP lub obiekt przechowywany. Traktuj zewnętrzne URI i wyrażenia znaczników XAML oddzielnie od nazw plików względnych.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, zapisany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie jedynie `image1.png` przerwałoby tę zależność. W przypadku przechowywania obiektowego zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te adresy URL zasobów konsumentowi XAML. Otwórz ponownie ukończone archiwum ZIP, aby zweryfikować nazwy wpisów i bajty zasobów, oraz wczytaj przykładowe slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozpoznawanie obrazów.

## **FAQ**

**Jak zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**

Ustaw [default_regular_font](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) w [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/) — jest ona używana jako czcionka zapasowa podczas eksportu, gdy oryginalna jest nieobecna. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki zapasowej ani że czcionka jest dostępna na docelowym urządzeniu. Upewnij się, że czcionki odwoływane przez XAML są dostępne w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany również w innych stosach XAML?**

Aspose.Slides wyprowadza XAML dla WPF poprzez publiczne API. Zgodność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**

Domyślnie ukryte slajdy nie są uwzględniane. Możesz sterować tym zachowaniem za pomocą [export_hidden_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) w [XamlOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export.xaml/xamloptions/) — pozostaw je wyłączone, jeśli nie musisz ich eksportować.