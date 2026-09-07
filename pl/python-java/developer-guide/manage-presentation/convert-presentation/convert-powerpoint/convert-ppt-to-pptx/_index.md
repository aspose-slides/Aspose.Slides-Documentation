---
title: Konwertuj PPT na PPTX w Pythonie
linktitle: PPT na PPTX
type: docs
weight: 20
url: /pl/python-java/convert-ppt-to-pptx/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- PPT do PPTX
- zapisz PPT jako PPTX
- eksportuj PPT do PPTX
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Konwertuj starsze pliki PPT na PPTX w Pythonie za pomocą Aspose.Slides. Zawiera przykłady w Pythonie dla konwersji jednego pliku oraz wsadowej, obsługę błędów i uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, podczas gdy PPTX jest nowszym formatem Open XML. Aspose.Slides for Python via Java może wczytać plik PPT i zapisać go jako PPTX bez potrzeby posiadania programu Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

Każdy przykład uruchamia wirtualną maszynę Javy w razie potrzeby i zwalnia prezentację po użyciu. Zastąp przykładowe ścieżki własnymi ścieżkami do plików lub katalogów.

## **Konwertuj plik PPT na PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z argumentem [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx). Blok `finally` usuwa prezentację i zwalnia jej zasoby.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Wczytaj starszą prezentację PPT.
presentation = Presentation("presentation.ppt")
try:
    # Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx]. Zachowaj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje pozostałych w partii.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

W środowiskach produkcyjnych loguj pełne wyjątki, decyduj, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisuj nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, nieosiągalne ścieżki i nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Prezentacje chronione hasłem](/slides/pl/python-java/password-protected-presentation/) w celu wczytywania zaszyfrowanych plików.

## **Wierność i funkcje legacy**

Konwersja zazwyczaj zachowuje slajdy, wzorce, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie reprezentują każdej funkcji dokładnie w ten sam sposób. Funkcja legacy, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub połączone obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

W przypadku ważnych dokumentów ponownie otwórz wygenerowany PPTX programistycznie i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) jako dowodu, że każda funkcja legacy ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPointa, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny plik PPT jako kopię archiwalną lub awaryjną, dopóki przekonwertowana prezentacja nie przejdzie weryfikacji wierności.

Jeśli potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjściowego, skorzystaj z zaleceń specyficznych dla formatu w sekcji [Konwertowanie prezentacji do wielu formatów](/slides/pl/python-java/convert-presentation/) zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPointa.

## **Konwerter online**

W przypadku jednorazowego pliku lub szybkiego porównania możesz skorzystać z [konwertera online PPT na PPTX](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Python via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/python-java/ppt-vs-pptx/)
- [Zapisz prezentacje w Pythonie](/slides/pl/python-java/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/python-java/supported-file-formats/)
- [Otwórz prezentacje w Pythonie](/slides/pl/python-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT na PPTX bez zainstalowanego programu Microsoft PowerPoint?**

Tak. Aspose.Slides for Python via Java wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT‑to‑PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale nie gwarantuje pełnej wierności dla każdej funkcji legacy lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**

Tak, pod warunkiem podania prawidłowego hasła podczas wczytywania pliku. Brak lub niepoprawne hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i procesach, które są dla Ciebie istotne. Zapewni to kopię awaryjną, gdy funkcja legacy zostanie przekonwertowana inaczej.