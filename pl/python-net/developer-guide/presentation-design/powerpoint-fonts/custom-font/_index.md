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
- ładowanie czcionki
- zarządzanie czcionkami
- folder czcionek
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Osadź niestandardowe czcionki w slajdach PowerPoint za pomocą Aspose.Slides dla Pythona poprzez .NET, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides for Python umożliwia podawanie własnych czcionek w trakcie działania, dzięki czemu prezentacje są renderowane prawidłowo, nawet gdy wymagane czcionki nie są zainstalowane w systemie docelowym. Podczas eksportu do PDF lub obrazów można podać foldery czcionek lub dane czcionek w pamięci, aby zachować układ tekstu, metryki glifów i typografię. Zapewnia to przewidywalne renderowanie po stronie serwera w różnych środowiskach, eliminuje zależności od czcionek systemowych i zapobiega niepożądanym zastąpieniom lub zmianom układu. W artykule przedstawiono, jak zarejestrować źródła czcionek.

Aspose.Slides pozwala ładować następujące czcionki przy użyciu metod `load_external_font` i `load_external_fonts` klasy [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/):

- Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Ładowanie niestandardowych czcionek**

Aspose.Slides umożliwia ładowanie czcionek używanych w prezentacji bez ich instalacji w systemie. Ma to wpływ na eksport – np. do PDF, obrazów i innych obsługiwanych formatów – dzięki czemu powstałe dokumenty wyglądają spójnie w różnych środowiskach. Czcionki są ładowane z własnych katalogów.

1. Określ jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj statyczną metodę [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/load_external_fonts/) aby załadować czcionki z tych folderów.  
3. Załaduj i renderuj/wyeksportuj prezentację.  
4. Wywołaj [FontsLoader.clear_cache](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/clear_cache/) aby wyczyścić pamięć podręczną czcionek.

```py
import aspose.slides as slides

# Określ foldery zawierające niestandardowe pliki czcionek.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Załaduj niestandardowe czcionki z określonych folderów.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Renderuj/eksportuj prezentację (np. do PDF, obrazów lub innych formatów) używając załadowanych czcionek.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Uwaga" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/load_external_fonts/) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.  
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.  
1. Ścieżki załadowane za pośrednictwem [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/).  
{{%/alert %}}

## **Uzyskaj folder niestandardowych czcionek**

Aspose.Slides udostępnia metodę `get_font_folders`, aby pobrać foldery czcionek. Zwraca ona zarówno foldery dodane przez `load_external_fonts`, jak i foldery czcionek systemowych.

Poniższy kod w języku Python pokazuje, jak używać `get_font_folders`:

```python
import aspose.slides as slides

# To wywołanie zwraca foldery sprawdzane pod kątem plików czcionek.
# Obejmuje to foldery dodane metodą load_external_fonts oraz systemowe foldery czcionek.
font_folders = slides.FontsLoader.get_font_folders()
```

## **Określ niestandardowe czcionki dla prezentacji**

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
    # CustomFont1, CustomFont2 i czcionki z folderów assets\fonts i global\fonts (oraz ich podfolderów) są dostępne w prezentacji.
    # ...
    print(len(presentation.slides))
```

## **Ładowanie zewnętrznych czcionek z danych binarnych**

Aspose.Slides udostępnia metodę `load_external_font`, aby ładować zewnętrzne czcionki z danych binarnych.

Poniższy przykład w Pythonie demonstruje ładowanie czcionki z tablicy bajtów:

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Załaduj zewnętrzne czcionki z tablic bajtów.
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

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**  
Tak. Połączone czcionki są używane przez renderer we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w wynikowym pliku PPTX?**  
Nie. Zarejestrowanie czcionki do renderowania nie jest równoznaczne z osadzeniem jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, musisz użyć wyraźnych [funkcje osadzania](/slides/pl/python-net/embedded-font/).

**Czy mogę kontrolować zachowanie zastępowania, gdy niestandardowa czcionka nie zawiera niektórych glifów?**  
Tak. Skonfiguruj [substitucję czcionek](/slides/pl/python-net/font-substitution/), [reguły zastępowania](/slides/pl/python-net/font-replacement/) oraz [zestawy zastępcze](/slides/pl/python-net/fallback-font/), aby dokładnie określić, która czcionka zostanie użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalacji ich systemowo?**  
Tak. Wskaż własne foldery czcionek lub ładuj czcionki z tablic bajtów. Usuwa to zależność od katalogów czcionek systemowych w obrazie kontenera.

**A co z licencjami — czy mogę osadzać dowolną czcionkę bez ograniczeń?**  
Odpowiedzialność za zgodność z licencjami czcionek spoczywa na Tobie. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze przeglądaj umowę licencyjną czcionki (EULA) przed rozpowszechnianiem wyników.