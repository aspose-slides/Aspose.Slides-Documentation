---
title: Konwertuj PPT do PPTX w Pythonie
linktitle: PPT do PPTX
type: docs
weight: 20
url: /pl/python-net/convert-ppt-to-pptx/
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
- Aspose.Slides
description: "Konwertuj starsze pliki PPT do PPTX w Pythonie przy użyciu Aspose.Slides. Zawiera przykłady konwersji pojedynczych plików i wsadowej, obsługę błędów oraz uwagi dotyczące wierności."
---
## **Przegląd**

PPT to starszy binarny format PowerPoint, natomiast PPTX jest nowszym formatem Open XML. Aspose.Slides for Python via .NET może wczytać plik PPT i zapisać go jako PPTX bez Microsoft PowerPoint. Ten artykuł pokazuje, jak konwertować jeden plik lub katalog plików oraz wyjaśnia, co należy zweryfikować po konwersji.

## **Konwertowanie pliku PPT do PPTX**

Wczytaj plik źródłowy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/), a następnie wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) z [SaveFormat.PPTX](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/). Instrukcja `with` zwalnia prezentację i zwalnia jej zasoby po zakończeniu bloku.

```python
import aspose.slides as slides

# Wczytaj starszą prezentację PPT.
with slides.Presentation("presentation.ppt") as presentation:
    # Zapisz prezentację w formacie PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Rozszerzenie pliku nie określa formatu wyjściowego samo w sobie; parametr [SaveFormat.PPTX](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/saveformat/) to robi. Utrzymuj różne ścieżki wejścia i wyjścia, jeśli potrzebujesz zachować oryginalny plik PPT.

## **Konwertowanie wielu plików PPT**

Poniższy przykład konwertuje każdy plik `.ppt` w jednym katalogu. Każdy plik jest przetwarzany niezależnie, więc jedna nieudana konwersja nie zatrzyma pozostałych w partii.

```python
from pathlib import Path

import aspose.slides as slides

input_directory = Path("input")
output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

for input_path in input_directory.glob("*.ppt"):
    output_path = output_directory / f"{input_path.stem}.pptx"

    try:
        with slides.Presentation(str(input_path)) as presentation:
            presentation.save(str(output_path), slides.export.SaveFormat.PPTX)
        print(f"Converted: {input_path}")
    except Exception as exception:
        print(f"Failed: {input_path} ({exception})")
```

W środowiskach produkcyjnych rejestruj pełny wyjątek, zdecyduj, czy istniejący plik wyjściowy może zostać nadpisany, i zapisuj nazwy nieudanych plików do kolejki ponownego przetworzenia lub przeglądu. Uszkodzone pliki, pliki zabezpieczone hasłem otwierane bez wymaganego hasła, niedostępne ścieżki oraz nieobsługiwana zawartość mogą spowodować niepowodzenie konwersji. Zobacz [Password-Protected Presentations](/python-net/password-protected-presentation/) w celu wczytania zaszyfrowanych plików.

## **Wierność i funkcje starsze**

Konwersja zazwyczaj zachowuje slajdy, mastery, układy, tekst, kształty, obrazy, tabele i wykresy. Jednak PPT i PPTX nie reprezentują każdej funkcji w dokładnie ten sam sposób. Funkcja starsza, która nie ma odpowiednika w PPTX lub nie jest obsługiwana przez bibliotekę, może zostać znormalizowana, pominięta lub wyświetlona inaczej.

Sprawdź skonwertowany plik, gdy zawiera animacje, przejścia, osadzone lub powiązane obiekty OLE, kontrolki ActiveX, osadzone multimedia, rzadkie czcionki lub makra VBA. Zwykły plik PPTX nie jest formatem obsługującym makra, więc użyj odpowiedniego przepływu pracy obsługującego makra, gdy VBA musi pozostać dostępne. Zweryfikuj także, czy wymagane czcionki i zasoby zewnętrzne są dostępne w środowisku, w którym skonwertowana prezentacja zostanie otwarta lub renderowana.

W przypadku ważnych dokumentów ponownie otwórz wygenerowany PPTX programowo i sprawdź kluczowe liczby slajdów oraz zawartość, a następnie porównaj jego wygląd i zachowanie pokazu slajdów w docelowej przeglądarce. Nie traktuj udanego wywołania [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) jako dowodu, że każda starsza funkcja ma dokładny odpowiednik w PPTX.

## **Kiedy używać PPTX**

Używaj PPTX, gdy prezentacja będzie edytowana w aktualnych wersjach PowerPoint, wymieniana z systemami pracującymi z pakietami Open XML lub przechowywana w formacie łatwiejszym do przeglądania i odzyskiwania niż starszy binarny PPT. Zachowaj oryginalny PPT jako archiwalną lub przywracalną kopię, dopóki skonwertowana prezentacja nie przejdzie Twoich kontroli wierności.

Jeśli potrzebujesz PDF, HTML, obrazów, XPS lub innego typu wyjścia, skorzystaj z wytycznych specyficznych dla formatu w [Convert Presentations to Multiple Formats](/python-net/convert-presentation/) zamiast zakładać, że wszystkie cele zachowują edytowalne funkcje PowerPoint.

## **Konwerter online**

W przypadku pojedynczego pliku lub szybkiego porównania możesz użyć [online PPT to PPTX converter](https://products.aspose.app/slides/pl/conversion/ppt-to-pptx). Do powtarzalnych konwersji, przetwarzania wsadowego lub obsługi błędów na poziomie aplikacji użyj API Pythona.

## **Powiązane artykuły**

- [PPT vs PPTX](/python-net/ppt-vs-pptx/)
- [Save Presentations in Python](/python-net/save-presentation/)
- [Supported File Formats](/python-net/supported-file-formats/)
- [Open Presentations in Python](/python-net/open-presentation/)

## **FAQ**

**Czy mogę konwertować PPT do PPTX bez zainstalowanego Microsoft PowerPoint?**

Tak. Aspose.Slides for Python via .NET wczytuje i zapisuje pliki prezentacji bez wymogu posiadania Microsoft PowerPoint.

**Czy konwersja PPT do PPTX zachowa całą zawartość dokładnie?**

Zachowuje ona typową zawartość prezentacji, ale dokładna wierność nie jest gwarantowana dla każdej starszej lub nieobsługiwanej funkcji. Przejrzyj wygenerowany plik, gdy zawiera makra, obiekty OLE lub ActiveX, multimedia, specjalistyczne animacje lub rzadkie czcionki.

**Czy mogę konwertować plik PPT zabezpieczony hasłem?**

Tak, jeśli podasz poprawne hasło podczas wczytywania pliku. Brak lub nieprawidłowe hasło powoduje niepowodzenie operacji wczytywania.

**Czy powinienem usunąć plik PPT po konwersji?**

Zachowaj oryginał, dopóki nie zweryfikujesz PPTX w przeglądarkach i przepływach pracy, które są dla Ciebie istotne. Zapewnia to kopię przywracania w razie różnic w konwersji starszych funkcji.