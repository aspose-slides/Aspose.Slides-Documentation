---
title: Konwertuj prezentacje OpenDocument w Pythonie
linktitle: Konwertuj OpenDocument
type: docs
weight: 10
url: /pl/python-java/convert-openoffice-odp/
keywords:
- konwertuj ODP
- ODP do PDF
- ODP do HTML
- ODP do TIFF
- ODP do PPT
- ODP do PPTX
- ODP do XPS
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Konwertuj prezentacje OpenDocument (ODP) do PDF, HTML i innych formatów przy użyciu Aspose.Slides for Python via Java, bez instalowania OpenOffice ani LibreOffice."
---
## **Wprowadzenie**

Aspose.Slides for Python via Java umożliwia konwertowanie prezentacji OpenDocument (ODP) do formatów takich jak PDF, HTML, TIFF, XPS, PPT i PPTX. Konwersja ODP wykorzystuje to samo API co konwersja PowerPoint: załaduj plik źródłowy przy pomocy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wybierz format wyjściowy przy użyciu [SaveFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/).

## **Konwertuj ODP do PDF**

Postępuj zgodnie z [instrukcje instalacji](/slides/pl/python-java/installation/) przed uruchomieniem przykładu. Umieść prezentację ODP o nazwie `pres.odp` w katalogu roboczym. Poniższy kod uruchamia JVM w razie potrzeby, ładuje prezentację i zapisuje ją jako `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Prezentacja OpenDocument w różnych aplikacjach**

Prezentacja ODP może wyglądać inaczej w PowerPoint oraz LibreOffice/OpenOffice Impress, ponieważ aplikacje te obsługują różne funkcje prezentacji i zachowania renderowania. Przeglądaj przekonwertowane prezentacje, gdy ich układ zależy od złożonego formatowania.

Różnice w kompatybilności mogą wpływać na:

- Tabele, w tym ich kolejność nakładania względem innych kształtów oraz obsługa wypełnień obrazami.
- Rotację i wyrównanie tekstu.
- Wypełnienia obrazem, gradientowe i wzorcowe stosowane do tekstu.
- Listy numerowane i wypunktowane.

Poniższy obrazek przedstawia listę utworzoną w LibreOffice Impress:

![Przykład listy ODP w LibreOffice Impress](odp-list-example.png)

Aspose.Slides zapisuje listy ODP w celu zapewnienia kompatybilności z LibreOffice/OpenOffice Impress.

Szczegóły dotyczące kompatybilności funkcji znajdziesz w [przewodnik Microsoftu dotyczący formatu prezentacji OpenDocument](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Co zrobić, jeśli formatowanie mojego pliku ODP zmienia się po konwersji?**

ODP i PowerPoint korzystają z różnych modeli prezentacji. Tabele, czcionki i style wypełnień mogą być renderowane inaczej. Upewnij się, że wymagane czcionki są dostępne, sprawdź wynik i w razie potrzeby dostosuj układ lub formatowanie.

**Czy potrzebuję zainstalowanego OpenOffice lub LibreOffice, aby konwertować pliki ODP?**

Nie. Aspose.Slides for Python via Java przetwarza prezentacje bez żadnej z tych aplikacji. Wymagane jest środowisko Java kompatybilne oraz pakiet Python.

**Czy mogę dostosować wyjście PDF przy konwersji prezentacji ODP?**

Tak. Użyj [PdfOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/), aby skonfigurować ustawienia eksportu PDF, takie jak jakość obrazu i kompresja.

**Czy mogę konwertować prezentacje ODP na serwerze lub w kontenerze?**

Tak. Zainstaluj pakiet Python, kompatybilne środowisko Java oraz czcionki wymagane przez Twoje prezentacje w środowisku docelowym. Nie jest potrzebna żadna aplikacja biurowa.