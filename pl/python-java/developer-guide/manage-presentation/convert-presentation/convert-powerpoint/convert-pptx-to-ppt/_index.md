---
title: Konwertuj PPTX na PPT w Pythonie
linktitle: PPTX na PPT
type: docs
weight: 21
url: /pl/python-java/convert-pptx-to-ppt/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPTX
- PPTX na PPT
- zapisz PPTX jako PPT
- eksportuj PPTX do PPT
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Konwertuj PPTX do starszego formatu PPT w Pythonie przy użyciu Aspose.Slides for Python via Java. Zawiera przykład kodu oraz uwagi dotyczące kompatybilności i plików zabezpieczonych."
---
## **Omówienie**

Aspose.Slides for Python via Java pozwala konwertować prezentację PPTX do starszego formatu PPT używanego w PowerPoint 97–2003 bez zainstalowanego Microsoft PowerPoint. Wczytaj plik PPTX i zapisz go w formacie PPT, jak pokazano poniżej.

## **Konwertuj PPTX na PPT**

Wczytaj plik źródłowy za pomocą klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wywołaj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z ścieżką wyjściową oraz [SaveFormat.Ppt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Ppt).

Poniższy przykład uruchamia maszynę wirtualną Javy w razie potrzeby i konwertuje `template.pptx` na `output.ppt` przy użyciu domyślnych opcji. Zamień ścieżki na własne nazwy plików. Blok `finally` zwalnia zasoby prezentacji, nawet jeśli zapis się nie powiedzie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Wczytaj prezentację PPTX.
presentation = Presentation("template.pptx")
try:
    # Zapisz prezentację w formacie PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

Argument [SaveFormat.Ppt] wybiera format wyjściowy; samo zmienienie rozszerzenia pliku nie konwertuje prezentacji. Zachowaj oryginalny plik PPTX, aby móc wrócić do niego, jeśli nowsza funkcja nie ma odpowiednika w PPT.

## **Konwertuj PPTX na inne formaty**

Aspose.Slides również obsługuje inne formaty wyjściowe. Zobacz odpowiednie artykuły dotyczące opcji specyficznych dla formatów i przykładów:

- [Konwertuj PowerPoint na PDF w Pythonie](/slides/pl/python-java/convert-powerpoint-to-pdf/)
- [Konwertuj PowerPoint na XPS w Pythonie](/slides/pl/python-java/convert-powerpoint-to-xps/)
- [Konwertuj PowerPoint na HTML w Pythonie](/slides/pl/python-java/convert-powerpoint-to-html/)
- [Zapisz prezentacje jako ODP w Pythonie](/slides/pl/python-java/save-presentation/)
- [Konwertuj PowerPoint na PNG w Pythonie](/slides/pl/python-java/convert-powerpoint-to-png/)

## **FAQ**

**Czy wszystkie efekty i funkcje PPTX przetrwają konwersję do PPT?**

Nie zawsze. Starszy format PPT nie obsługuje wszystkich funkcji dostępnych w PPTX. Niektóre efekty, obiekty lub zachowania mogą zostać uproszczone lub wyświetlone inaczej. Przejrzyj skonwertowaną prezentację w docelowym podglądzie, szczególnie gdy zawiera nowsze funkcje PowerPointa.

**Czy mogę konwertować tylko wybrane slajdy do PPT?**

Zapis do PPT zapisuje całą prezentację. Aby przekonwertować wybrane slajdy, utwórz nową prezentację, usuń jej początkowy pusty slajd, sklonuj wymagane slajdy do niej i zapisz jako PPT. Zobacz [Clone Slides in Python](/slides/pl/python-java/clone-slides/).

**Czy mogę konwertować plik PPTX chroniony hasłem?**

Tak, jeśli podasz prawidłowe hasło podczas wczytywania źródłowej prezentacji. Możesz również skonfigurować ochronę dla pliku wyjściowego. Zobacz [Password-Protected Presentations](/slides/pl/python-java/password-protected-presentation/).