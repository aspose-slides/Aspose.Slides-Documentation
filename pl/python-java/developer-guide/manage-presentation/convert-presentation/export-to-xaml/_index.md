---
title: Eksportowanie prezentacji do XAML w Pythonie przy użyciu Java
linktitle: Prezentacja do XAML
type: docs
weight: 30
url: /pl/python-java/export-to-xaml/
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
- eksportuj PPT do XAML
- eksportuj PPTX do XAML
- eksportuj ODP do XAML
- Python
- Java
- Aspose.Slides
description: "Eksportuj prezentacje PowerPoint i OpenDocument do XAML przy użyciu Aspose.Slides dla Pythona via Java. Użyj opcji domyślnych lub uwzględnij ukryte slajdy."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak eksportować prezentacje PowerPoint do XAML przy użyciu Aspose.Slides dla Pythona via Java. Zawiera krótkie wprowadzenie do XAML, pokazuje, jak zapisać prezentację do XAML z ustawieniami domyślnymi oraz demonstruje, jak dostosować eksport przy użyciu [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/), w tym eksportowanie ukrytych slajdów. Artykuł odpowiada również na kilka często zadawanych pytań dotyczących czcionek awaryjnych, kompatybilności stosu XAML i zachowania przy eksporcie ukrytych slajdów.

Przykłady wymagają Aspose.Slides dla Pythona via Java oraz zgodnego środowiska Java. Umieść `pres.pptx` w bieżącym katalogu roboczym. Każdy przykład uruchamia JVM tylko wtedy, gdy nie jest już uruchomiony.

## **O XAML**

XAML jest językiem znaczników opartym na XML, używanym do opisywania interfejsów użytkownika w ramach takich jak WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) oraz Xamarin.Forms.

Możesz pracować z plikami XAML w projektancie wizualnym lub pisać i edytować znacznik bezpośrednio.

## **Eksportowanie prezentacji do XAML z opcjami domyślnymi**

Poniższy przykład w Pythonie pokazuje, jak wyeksportować prezentację do XAML z ustawieniami domyślnymi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Domyślnie wyeksportowane slajdy są zapisywane w podfolderze `pres` bieżącego katalogu procesu. Folder jest tworzony automatycznie, a wszystkie wymagane obrazy są tam również zapisywane.

Nazwa folderu wyjściowego jest pobierana z nazwy pliku źródłowego bez rozszerzenia. Dla `pres.pptx` pliki wyjściowe mają nazwy `pres/Slide_1.xaml`, `pres/Slide_2.xaml` i tak dalej. Nawet jeśli przekażesz bezwzględną ścieżkę do prezentacji wejściowej, folder wyjściowy zostanie utworzony względem bieżącego katalogu roboczego, a nie obok pliku wejściowego.

## **Eksportowanie prezentacji do XAML z opcjami niestandardowymi**

Użyj klasy [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/), aby kontrolować, w jaki sposób Aspose.Slides eksportuje prezentację do XAML.

Aby zapisać wynik w niestandardowej lokalizacji, zaimplementuj `IXamlOutputSaver` i przekaż instancję swojej implementacji do metody [setOutputSaver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setOutputSaver) klasy [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/).

Aby uwzględnić ukryte slajdy w wyjściu XAML, wywołaj [setExportHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) z wartością `True`, jak pokazano w poniższym przykładzie w Pythonie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Przechwytywanie wszystkich wygenerowanych artefaktów XAML**

Eksport XAML może generować dokument XAML dla każdego wyeksportowanego slajdu oraz osobne obrazy i zasoby pomocnicze. Przypisz własny `IXamlOutputSaver` do [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setOutputSaver), aby otrzymywać te artefakty zamiast korzystać z domyślnego zapisu na systemie plików. Rozpocznij eksport przy użyciu przeciążenia [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) przyjmującego opcje XAML.

W Pythonie użyj `jpype.JProxy`, aby zaimplementować interfejs Java `IXamlOutputSaver`. Przekonwertuj ścieżkę wywołania zwrotnego na `str` i skopiuj tablicę bajtów Java do Python `bytes` przed zwróceniem, jak pokazano poniżej.

### **Zrozumienie cyklu życia wywołań zwrotnych**

Eksporter wywołuje `IXamlOutputSaver.save` osobno dla każdego wygenerowanego artefaktu:

- `path` identyfikuje artefakt i może zawierać względne katalogi. Zachowaj tę informację, ponieważ XAML może odwoływać się do zasobów przy użyciu ścieżek względnych.
- `data` zawiera bajty artefaktu. Obrazy i inne zasoby binarne nie powinny być dekodowane jako tekst.
- Zapisujący jest odpowiedzialny za zachowanie lub utrwalenie danych przed zwróceniem. Przykłady kopiują każdą tablicę bajtów do pamięci należącej do aplikacji.
- Traktuj eksport jako udany tylko wtedy, gdy operacja zapisu prezentacji zwróciła się i każdy wywołanie zwrotne zakończyło się pomyślnie. Nie ukrywaj błędów przechowywania ani nie rozpoczynaj nieobserwowanych zapisów w tle. Jeśli trwałość nastąpi później, zgłaszaj ogólny sukces dopiero po pomyślnym zakończeniu tego kroku.

[**XamlOptions.setExportHiddenSlides**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) ma również zastosowanie do własnego zapisu. Domyślne ustawienie, `False`, wyklucza dokumenty XAML ukrytych slajdów. Przekazanie `True` uwzględnia je oraz wszystkie zasoby potrzebne do ich eksportu. Liczba zasobów zależy od prezentacji; nie zakładaj jednego wywołania zwrotnego na slajd ani stałej kolejności wywołań.

### **Eksport do pamięci i przeglądanie artefaktów**

Ten kompletny przykład ładuje `pres.pptx`, zbiera każdy artefakt w słowniku Pythona z nazwami i niezmiennymi wartościami `bytes`, a następnie wypisuje nazwę, typ i liczbę bajtów. Zachowuje dokładnie podane nazwy. Zduplikowane nazwy oznaczają, że kolekcja jest nieprawidłowa, zamiast cicho nadpisywać artefakt. Przykład sprawdza to przed użyciem wyników.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Dekoduj tylko XAML i tylko wtedy, gdy potrzebna jest inspekcja tekstowa.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Sprawdzanie rozszerzeń jest przydatne przy inspekcji; zachowaj wszystkie artefakty, w tym nieznane typy zasobów. Pozostaw bajty niezmienione przy przechowywaniu lub przesyłaniu. Używaj `bytes.decode` z UTF-8 wyłącznie dla XAML, który wymaga przetwarzania tekstowego.

### **Pakowanie zebranych artefaktów w archiwum ZIP**

Ten niezależny przykład zbiera eksport, weryfikuje nazwy i zapisuje oryginalne bajty do archiwum ZIP. Unikalna nazwa archiwum oddziela jednoczesne zadania eksportu. Pozycje ZIP używają ukośników i zachowują względne katalogi. Niebezpieczne nazwy lub nazwy kolidujące po normalizacji odrzucają cały pakiet przed jego zapisaniem.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # Zamykanie finalizuje katalog ZIP przed zgłoszeniem sukcesu.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

Przykład używa `zipfile.ZipFile` z Pythona, aby zapisać lokalne archiwum; sam eksporter nie zapisuje luźnych plików XAML ani obrazów. W przypadku zdalnego przechowywania zamień etap zapisu archiwum na przesyłanie zebranych tablic bajtów. Użyj identyfikatora zadania eksportu plus pełnej względnej nazwy artefaktu jako klucza blob lub przechowuj identyfikator zadania, względną nazwę i dane binarne w wierszu bazy danych. Publikuj zadanie dopiero po zakończeniu wszystkich przesłań lub zatwierdzeniu transakcji bazy danych. Usuń częściowy wynik, jeśli utrwalenie się nie powiedzie.

W przypadku dużych prezentacji własny zapis może utrwalać każdy artefakt bezpośrednio w magazynie aplikacji, aby uniknąć przechowywania dodatkowej kopii całego eksportu w pamięci aplikacji. Utrzymuj każde wywołanie zwrotne synchroniczne z perspektywy eksportera: zwracaj dopiero po zaakceptowaniu bajtów przez odbiorcę i pozwól, aby błędy dotarły do wywołującego.

### **Zachowanie nazw zasobów i weryfikacja odwołań**

- Normalizuj separatory ścieżek, gdy wymaga tego docelowe miejsce, ale zachowuj względne katalogi. Nie używaj wyłącznie `pathlib.Path.name`, chyba że każdy wygenerowany identyfikator jest znany jako unikalny i odwołania zasobów pozostają prawidłowe.
- Zastosuj walidację nazw specyficzną dla docelowego miejsca. Przy zapisie luźnych plików odrzuć ścieżki bezwzględne i segmenty traversalu, rozwiąż docelową ścieżkę przy pomocy `pathlib.Path.resolve` i zweryfikuj, że pozostaje pod zamierzonym katalogiem eksportu, uwzględniając separator katalogu w sprawdzaniu zawartości. Używaj kontrolowanego przez aplikację katalogu bez dowiązań symbolicznych, które mogłyby przekierować zapisy.
- Używaj oddzielnego zapisu i przestrzeni nazw magazynu dla każdego zadania eksportu. Wykrywaj kolizje po normalizacji separatora i zgodnie z zasadami rozróżniania wielkości liter w docelowym miejscu.
- Przed publikacją przetwarzaj każdy dokument XAML jako XML i sprawdzaj jego odwołania do zasobów opartych na plikach, takich jak atrybuty `Source` lub `ImageSource` obrazów. Rozwiąż każdy względny URI względem katalogu zawierającego artefakt XAML, znormalizuj powstałą nazwę magazynu i potwierdź, że odpowiedni klucz mapy, pozycja ZIP lub przechowywany obiekt istnieje. Traktuj zewnętrzne URI i wyrażenia markup XAML oddzielnie od nazw plików względnych.

Na przykład, jeśli `pres/Slide_1.xaml` odwołuje się do `images/image1.png`, przechowywany zasób musi być dostępny jako `pres/images/image1.png`. Zachowanie wyłącznie `image1.png` przerwałoby to powiązanie. Dla przechowywania obiektowego zachowaj tę samą strukturę pod prefiksem zadania i udostępnij te URL‑e zasobów konsumentowi XAML. Otwórz ponownie ukończone ZIP, aby zweryfikować nazwy pozycji i bajty zasobów, oraz załaduj przykładowe slajdy w docelowym środowisku XAML, aby potwierdzić prawidłowe rozwiązywanie obrazów.

## **FAQ**

**Jak mogę zapewnić przewidywalne czcionki, jeśli oryginalna czcionka nie jest dostępna na komputerze?**  
Wywołaj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) w [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/) — jest on używany jako czcionka awaryjna podczas eksportu, gdy oryginał jest brakujący. Nie gwarantuje to, że wygenerowany XAML odwołuje się do czcionki awaryjnej lub że czcionka będzie dostępna na docelowej maszynie. Upewnij się, że czcionki wymienione w XAML są zainstalowane w środowisku, w którym jest wyświetlany.

**Czy wyeksportowany XAML jest przeznaczony wyłącznie dla WPF, czy może być używany w innych stosach XAML?**  
Aspose.Slides eksportuje XAML WPF poprzez publiczne API. Kompatybilność z innymi stosami XAML, takimi jak UWP i Xamarin.Forms, nie jest gwarantowana. Przetestuj wygenerowany znacznik w docelowym środowisku.

**Czy ukryte slajdy są obsługiwane i jak mogę zapobiec ich domyślnemu eksportowi?**  
Domyślnie ukryte slajdy nie są uwzględniane. Możesz kontrolować to zachowanie za pomocą [setExportHiddenSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) w [XamlOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/xamloptions/) — pozostaw je wyłączone, jeśli nie musisz ich eksportować.