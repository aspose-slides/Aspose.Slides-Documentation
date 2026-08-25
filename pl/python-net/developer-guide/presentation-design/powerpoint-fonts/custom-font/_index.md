---
title: Dostosuj czcionki PowerPoint w Pythonie
linktitle: Niestandardowa czcionka
type: docs
weight: 20
url: /pl/python-net/custom-font/
keywords:
- czcionka
- niestandardowa czcionka
- zewnętrzna czcionka
- wczytaj czcionkę
- zarządzaj czcionkami
- folder czcionek
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Osadź niestandardowe czcionki w slajdach PowerPoint przy użyciu Aspose.Slides dla Pythona przez .NET, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides dla Pythona umożliwia podawanie własnych czcionek w czasie wykonywania, dzięki czemu prezentacje są renderowane prawidłowo, nawet jeśli wymagane czcionki nie są zainstalowane w systemie hosta. Podczas eksportu do PDF lub obrazów można dostarczyć foldery z czcionkami lub czcionki w pamięci, aby zachować układ tekstu, metryki glifów i typografię. Dzięki temu renderowanie po stronie serwera jest przewidywalne w różnych środowiskach, usuwa zależności od czcionek systemowych i zapobiega niepożądanym zastąpieniom lub przetwarzaniu tekstu. W artykule pokazano, jak zarejestrować źródła czcionek.

Motyw prezentacji może odnosić się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie ładują plików czcionek. Zobacz [Script-Specific Theme Fonts](/slides/pl/python-net/script-specific-font-mappings/), aby zarządzać mapowaniami, oraz użyj opcji ładowania poniżej, aby udostępnić odwoływane czcionki do spójnego renderowania.

Aspose.Slides pozwala ładować następujące czcionki przy użyciu metod `load_external_font` i `load_external_fonts` klasy [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/):

- Czcionki TrueType (.ttf) i kolekcje TrueType (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Wczytywanie niestandardowych czcionek**

Aspose.Slides umożliwia wczytanie czcionek używanych w prezentacji bez ich instalowania w systemie. Ma to wpływ na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są wczytywane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.
2. Wywołaj statyczną metodę [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/load_external_fonts/), aby wczytać czcionki z tych folderów.
3. Wczytaj i renderuj/wyeksportuj prezentację.
4. Wywołaj [FontsLoader.clear_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/clear_cache/), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces wczytywania czcionek:

```py
import aspose.slides as slides

# Zdefiniuj foldery zawierające niestandardowe pliki czcionek.
font_folders = ["fonts", "external_fonts"]

# Wczytaj niestandardowe czcionki z określonych folderów.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając wczytanych czcionek.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Uwaga" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/load_external_fonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.
1. Ścieżki wczytane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Uzyskanie folderu niestandardowych czcionek**

Aspose.Slides udostępnia metodę `get_font_folders`, aby pobrać foldery czcionek. Zwraca ona zarówno foldery dodane za pomocą `load_external_fonts`, jak i foldery czcionek systemowych.

Ten kod w Pythonie pokazuje, jak używać `get_font_folders`:

```python
import aspose.slides as slides

# To wywołanie zwraca foldery sprawdzane pod kątem plików czcionek.
# Obejmuje to foldery dodane metodą load_external_fonts oraz foldery czcionek systemowych.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Określanie niestandardowych czcionek dla prezentacji**

Aspose.Slides udostępnia właściwość `document_level_font_sources`, która pozwala określić zewnętrzne czcionki używane w prezentacji.

Poniższy przykład w Pythonie pokazuje, jak używać `document_level_font_sources`:

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Pracuj z prezentacją.
    # CustomFont1, CustomFont2 oraz czcionki z folderów assets\fonts i global\fonts (oraz ich podfolderów) są dostępne dla prezentacji.
    # ...
    print(len(presentation.slides))
```

## **Wczytywanie zewnętrznych czcionek z danych binarnych**

Aspose.Slides udostępnia metodę `load_external_font` do wczytywania zewnętrznych czcionek z danych binarnych.

Poniższy przykład w Pythonie demonstruje wczytywanie czcionki z tablicy bajtów:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Wczytaj zewnętrzne czcionki z tablic bajtów.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Zewnętrzne czcionki są dostępne przez cały czas życia tej instancji prezentacji.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **FAQ**

### Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?

Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

### Czy niestandardowe czcionki są automatycznie osadzane w powstałym pliku PPTX?

Nie. Zarejestrowanie czcionki do renderowania nie jest tym samym co osadzenie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnych [funkcji osadzania](/slides/pl/python-net/embedded-font/).

### Czy mogę kontrolować zachowanie w razie braku niektórych glifów w niestandardowej czcionce?

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/python-net/font-substitution/), [reguły zamiany](/slides/pl/python-net/font-replacement/), oraz [zestawy zapasowe](/slides/pl/python-net/fallback-font/), aby dokładnie określić, jaka czcionka ma być użyta, gdy żądany glif jest nieobecny.

### Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji ich w całym systemie?

Tak. Wskaż własne foldery z czcionkami lub wczytuj czcionki z tablic bajtów. Usuwa to wszelkie zależności od katalogów czcionek systemowych w obrazie kontenera.

### Jak wygląda kwestia licencjonowania — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?

Jesteś odpowiedzialny za zgodność z licencją czcionki. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj umowę EULA czcionki przed dystrybucją wyników.