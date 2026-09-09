---
title: Konwertuj PPT do PPTX w Pythonie
linktitle: PPT do PPTX
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
description: "Konwertuj starsze pliki PPT do PPTX w Pythonie za pomocą Aspose.Slides. Zawiera przykłady w Pythonie dla konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT jest starszym binarnym formatem PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for Python via Java może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak skonwertować pojedynczy plik lub katalog plików oraz wyjaśnia, co należy sprawdzić po konwersji.

Każdy przykład uruchamia maszynę wirtualną Javy w razie potrzeby i zwalnia prezentację po użyciu. Zamień ścieżki w przykładach na własne ścieżki do plików lub katalogów.

## **Konwertuj plik PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx). Blok `finally` usuwa prezentację i zwalnia jej zasoby.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Załaduj starszą prezentację PPT.
presentation = Presentation("presentation.ppt")
try:
    # Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rozszerzenie pliku nie wybiera formatu wyjściowego samo w sobie; robi to argument [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx). Utrzymuj różne ścieżki wejściowe i wyjściowe, jeśli musisz zachować oryginalny plik PPT.

## **Konwertuj wiele plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc niepowodzenie jednej konwersji nie zatrzymuje reszty wsadu.

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

W środowiskach produkcyjnych należy logować pełne wyjątki, decydować, czy istniejący plik wyjściowy może zostać nadpisany, oraz zapisywać nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki i nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/slides/pl/python-java/password-protected-presentation/) aby dowiedzieć się, jak wczytywać zaszyfrowane pliki.

## **Wierność i funkcje dziedziczone**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie odzwierciedlają każdej funkcji w dokładnie taki sam sposób. Funkcja dziedziczona, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź przekonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone media, rzadko używane czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Ponadto zweryfikuj, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym otwierana lub renderowana będzie przekonwertowana prezentacja.

Dla ważnych dokumentów otwórz ponownie wygenerowany PPTX programowo i sprawdź liczbę slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) jako dowodu, że każda funkcja dziedziczona ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami obsługującymi pakiety Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Przechowuj oryginalny plik PPT jako archiwalną lub zapasową kopię, dopóki skonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz zamiast tego PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z instrukcji specyficznych dla formatu w [Convert Presentations to Multiple Formats](/slides/pl/python-java/convert-presentation/), zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku pojedynczego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Python via Java.

## **Powiązane artykuły**

- [PPT vs PPTX](/slides/pl/python-java/ppt-vs-pptx/)
- [Zapisz prezentacje w Pythonie](/slides/pl/python-java/save-presentation/)
- [Obsługiwane formaty plików](/slides/pl/python-java/supported-file-formats/)
- [Otwórz prezentacje w Pythonie](/slides/pl/python-java/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Python via Java wczytuje i zapisuje pliki prezentacji bez wymaganego Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej funkcji dziedziczonej lub nieobsługiwanej. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, media, specjalistyczne animacje lub rzadko używane czcionki.

**Czy mogę konwertować zabezpieczony hasłem plik PPT?**

Tak, jeśli podasz prawidłowe hasło przy wczytywaniu pliku. Brak hasła lub niepoprawne hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Zapewnia to kopię zapasową, jeśli funkcja dziedziczona zostanie skonwertowana w inny sposób.