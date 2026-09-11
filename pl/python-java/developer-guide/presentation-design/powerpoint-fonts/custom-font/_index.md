---
title: Dostosuj czcionki PowerPoint w Pythonie przy użyciu Java
linktitle: Czcionka niestandardowa
type: docs
weight: 20
url: /pl/python-java/custom-font/
keywords:
- czcionka
- czcionka niestandardowa
- czcionka zewnętrzna
- wczytaj czcionkę
- zarządzaj czcionkami
- folder czcionek
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dostosuj czcionki w slajdach PowerPoint za pomocą Aspose.Slides dla Pythona poprzez Java, aby Twoje prezentacje były wyraźne i spójne na każdym urządzeniu."
---
## **Przegląd**

Aspose.Slides umożliwia używanie niestandardowych czcionek w prezentacjach bez ich instalowania w systemie operacyjnym. Możesz wczytywać czcionki z własnych folderów, podawać czcionki dla konkretnej prezentacji za pomocą źródeł czcionek na poziomie dokumentu lub wczytywać zewnętrzne czcionki bezpośrednio z danych binarnych.

Wczytane czcionki są używane podczas renderowania lub eksportu prezentacji, np. do PDF, obrazów i innych obsługiwanych formatów. Pomaga to zachować spójny wygląd prezentacji w różnych środowiskach. W artykule wyjaśniono również, jak sprawdzić foldery czcionek używane przez Aspose.Slides oraz jak wyczyścić pamięć podręczną czcionek po pracy z czcionkami zewnętrznymi.

Rejestrowanie niestandardowych czcionek do renderowania jest oddzielne od osadzania czcionek w pliku PPTX. Jeśli czcionka ma być przechowywana wewnątrz samej prezentacji, należy używać funkcji osadzania czcionek w sposób explicite.

Motyw prezentacji może odwoływać się do różnych rodzin czcionek dla poszczególnych systemów pisma. Te mapowania przechowują nazwy czcionek, ale nie instalują ani nie wczytują plików czcionek. Zobacz [Czcionki motywów specyficzne dla skryptu](/slides/pl/python-java/script-specific-font-mappings/), aby zarządzać mapowaniami, oraz użyj poniższych opcji wczytywania, aby udostępnić odwoływane czcionki dla spójnego renderowania.

{{% alert color="info" title="Note" %}}
Aspose.Slides umożliwia wczytywanie tych czcionek za pomocą metody [loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFonts):

* Czcionki TrueType (.ttf) i TrueType Collection (.ttc). Zobacz [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Czcionki OpenType (.otf). Zobacz [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Wczytywanie niestandardowych czcionek**

Aspose.Slides umożliwia wczytywanie czcionek używanych w prezentacji bez ich instalowania w systemie. Wpływa to na wynik eksportu — takiego jak PDF, obrazy i inne obsługiwane formaty — tak aby powstałe dokumenty wyglądały spójnie w różnych środowiskach. Czcionki są wczytywane z własnych katalogów.

1. Podaj jeden lub więcej folderów zawierających pliki czcionek.  
2. Wywołaj metodę statyczną [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFonts), aby wczytać czcionki z tych folderów.  
3. Wczytaj i renderuj/eksportuj prezentację.  
4. Wywołaj [FontsLoader.clearCache](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#clearCache), aby wyczyścić pamięć podręczną czcionek.

Poniższy przykład kodu demonstruje proces wczytywania czcionek:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Zdefiniuj foldery zawierające pliki czcionek niestandardowych.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Wczytaj niestandardowe czcionki z podanych folderów.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Renderuj/eksportuj prezentację używając wczytanych czcionek.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Wyczyść pamięć podręczną czcionek po zakończeniu pracy.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFonts) dodaje dodatkowe foldery do ścieżek wyszukiwania czcionek, ale nie zmienia kolejności inicjalizacji czcionek.  
Czcionki są inicjalizowane w następującej kolejności:

1. Domyślna ścieżka czcionek systemu operacyjnego.  
1. Ścieżki wczytane za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Uzyskiwanie niestandardowych folderów czcionek**

Aspose.Slides udostępnia metodę [getFontFolders](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#getFontFolders), aby umożliwić znajdowanie folderów czcionek. Metoda ta zwraca foldery dodane poprzez metodę [loadExternalFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFonts) oraz foldery systemowe czcionek.

Ten kod w Pythonie pokazuje, jak używać [getFontFolders](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#getFontFolders):

```python
from asposeslides.api import FontsLoader

# Pobierz foldery dodane przez loadExternalFonts oraz foldery czcionek systemowych.
font_folders = FontsLoader.getFontFolders()
```

## **Określanie niestandardowych czcionek używanych z prezentacją**

Aspose.Slides udostępnia metodę [getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources), aby umożliwić określenie zewnętrznych czcionek, które będą używane z prezentacją.

Ten kod w Pythonie pokazuje, jak używać metody [getDocumentLevelFontSources](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources):

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Pracuj z prezentacją.
    # CustomFont1, CustomFont2 oraz czcionki z folderów assets/fonts i global/fonts
    # oraz ich podfoldery są dostępne w prezentacji.
    pass
finally:
    presentation.dispose()
```

## **Zarządzanie czcionkami zewnętrznie**

Aspose.Slides udostępnia metodę [loadExternalFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontsloader/#loadExternalFont), aby umożliwić wczytywanie zewnętrznych czcionek z danych binarnych.

Ten kod w Pythonie demonstruje proces wczytywania czcionki z tablicy bajtów:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Zewnętrzne czcionki są ładowane w czasie życia prezentacji.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Czy niestandardowe czcionki wpływają na eksport do wszystkich formatów (PDF, PNG, SVG, HTML)?**

Tak. Powiązane czcionki są używane przez renderujący we wszystkich formatach eksportu.

**Czy niestandardowe czcionki są automatycznie osadzane w wygenerowanym pliku PPTX?**

Nie. Rejestrowanie czcionki do renderowania nie jest tym samym co osadzanie jej w pliku PPTX. Jeśli potrzebujesz, aby czcionka była zawarta w pliku prezentacji, należy używać explicite [funkcji osadzania](/slides/pl/python-java/embedded-font/).

**Czy mogę kontrolować zachowanie fallbacku, gdy niestandardowa czcionka nie posiada niektórych glifów?**

Tak. Skonfiguruj [zastępowanie czcionek](/slides/pl/python-java/font-substitution/), [reguły zamiany](/slides/pl/python-java/font-replacement/) oraz [zestawy fallback](/slides/pl/python-java/fallback-font/), aby określić, która czcionka ma być użyta, gdy żądany glif jest nieobecny.

**Czy mogę używać czcionek w kontenerach Linux/Docker bez instalowania ich systemowo?**

Tak. Wskaż własne foldery czcionek lub wczytuj czcionki z tablic bajtów. Dzięki temu nie masz zależności od systemowych katalogów czcionek w obrazie kontenera.

**A co z licencjonowaniem — czy mogę osadzać dowolną niestandardową czcionkę bez ograniczeń?**

Odpowiedzialność za zgodność z licencją czcionki spoczywa na Tobie. Warunki różnią się; niektóre licencje zakazują osadzania lub komercyjnego użycia. Zawsze sprawdzaj EULA czcionki przed rozpowszechnianiem wyników.