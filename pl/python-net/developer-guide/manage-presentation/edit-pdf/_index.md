---
title: Edycja dokumentów PDF w Pythonie
linktitle: Edycja PDF
type: docs
weight: 65
url: /pl/python-net/edit-pdf/
keywords:
- edytuj PDF
- zastąp tekst PDF
- PDF do PPTX
- PPTX do PDF
- Python
- Aspose.Slides
description: "Edytuj dokumenty PDF w Pythonie, importując je do Aspose.Slides, zastępując tekst i zapisując zmodyfikowaną prezentację z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for Python via .NET umożliwia edytowanie zawartości PDF poprzez importowanie jego stron jako slajdów, modyfikację prezentacji i eksport z powrotem do PDF. Ten artykuł przedstawia proste zastąpienie tekstu. Prezentacja pozostaje w pamięci, więc zapisywanie pośredniego pliku PPTX jest opcjonalne.

## **Zastąp tekst w pliku PDF**

Użyj [add_from_pdf](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_from_pdf/) aby zaimportować strony, [replace_text](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/replace_text/) aby zaktualizować tekst oraz [save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/) aby wyeksportować wynik.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje ono to słowo na „Final” i zapisuje `edited.pdf`. Wyczyść początkowy slajd przed importem, aby uniknąć dodatkowej pustej strony w wyniku. Wyszukiwanie dopasowuje całe słowa z zachowaniem wielkości liter; `None` oznacza, że nie jest potrzebny żaden callback wyników.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Aby uzyskać więcej opcji, zobacz [Search and Replace Text](/slides/pl/python-net/search-and-replace-text/) oraz [Convert PowerPoint to PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zastąpienie tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego należy sprawdzić wynik, szczególnie gdy tekst zastępczy jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed wyeksportowaniem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować jej edycję w PowerPoint; zobacz [Save Presentations](/slides/pl/python-net/save-presentation/).

**Dlaczego niektóry tekst może pozostać niezmieniony?**

Przykład dopasowuje całe słowo „Draft” z dokładnym uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub podzielony na oddzielne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną zawartość i dostosuj wyszukiwanie do swojego dokumentu.