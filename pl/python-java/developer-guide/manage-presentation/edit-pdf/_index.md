---
title: Edytuj dokumenty PDF w Pythonie za pośrednictwem Java
linktitle: Edytuj PDF
type: docs
weight: 65
url: /pl/python-java/edit-pdf/
keywords:
- edytuj PDF
- zastąp tekst PDF
- PDF do PPTX
- PPTX do PDF
- Python
- Java
- Aspose.Slides
description: "Edytuj dokumenty PDF w Pythonie za pośrednictwem Java, importując je do Aspose.Slides, zastępując tekst i zapisując zmodyfikowaną prezentację z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia edytowanie zawartości PDF poprzez importowanie jego stron jako slajdów, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. Ten artykuł pokazuje prostą zamianę tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zamiana tekstu w pliku PDF**

Użyj [addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromPdf) do zaimportowania stron, [replaceText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#replaceText) do zaktualizowania tekstu i [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) do wyeksportowania wyniku.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje to słowo na „Final” i zapisuje plik `edited.pdf`. Usunięcie początkowego slajdu przed importem zapobiega dodatkowej pustej stronie w wyjściu. Wyszukiwanie dopasowuje całe słowa zachowując wielkość liter; `None` oznacza, że nie jest potrzebny zwrotny wywołanie wyniku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Aby uzyskać więcej opcji, zobacz [Search and Replace Text](/slides/pl/python-java/search-and-replace-text/) i [Convert PowerPoint to PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zamiana tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego należy przejrzeć wynik, szczególnie gdy zamieniany tekst jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Kopię PPTX zapisz tylko wtedy, gdy chcesz kontynuować jej edycję w programie PowerPoint; zobacz [Save Presentations](/slides/pl/python-java/save-presentation/).

**Dlaczego niektóre fragmenty tekstu mogą pozostać niezmienione?**

Przykład dopasowuje całe słowo „Draft” z uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub rozdzielony na osobne ramki tekstowe niekoniecznie zostanie dopasowany do wyszukiwania. Sprawdź zaimportowaną zawartość i dostosuj wyszukiwanie do swojego dokumentu.