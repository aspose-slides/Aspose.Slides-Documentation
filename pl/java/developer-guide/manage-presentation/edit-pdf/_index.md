---
title: Edycja dokumentów PDF w Javie
linktitle: Edycja PDF
type: docs
weight: 65
url: /pl/java/edit-pdf/
keywords:
- edycja PDF
- zamiana tekstu PDF
- PDF do PPTX
- PPTX do PDF
- Java
- Aspose.Slides
description: "Edytuj dokumenty PDF w Javie, importując je do Aspose.Slides, zamieniając tekst i zapisując zmodyfikowaną prezentację z powrotem do PDF."
---
## **Przegląd**

Aspose.Slides for Java umożliwia edytowanie zawartości PDF poprzez importowanie jego stron jako slajdy, modyfikowanie prezentacji i ponowne eksportowanie do PDF. Ten artykuł pokazuje proste zamienianie tekstu. Prezentacja pozostaje w pamięci, więc zapisywanie pośredniego pliku PPTX jest opcjonalne.

## **Zamiana tekstu w PDF**

Użyj [addFromPdf](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) aby zaimportować strony, [replaceText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) aby zaktualizować tekst oraz [save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/#save-java.lang.String-int-) aby wyeksportować wynik.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje to słowo „Final” i zapisuje `edited.pdf`. Wyczyść początkowy slajd przed importem, aby uniknąć dodatkowej pustej strony w wyniku. Wyszukiwanie dopasowuje całe słowa z zachowaniem wielkości liter; `null` oznacza, że nie jest potrzebny zwrotny wywołanie wyniku.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Aby uzyskać więcej opcji, zobacz [Search and Replace Text](/slides/pl/java/search-and-replace-text/) i [Convert PowerPoint to PDF](/slides/pl/java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

Zamiana tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego warto sprawdzić wynik, szczególnie gdy zamieniany tekst jest dłuższy niż oryginalny.

{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować edycję w programie PowerPoint; zobacz [Save Presentations](/slides/pl/java/save-presentation/).

**Dlaczego niektóry tekst pozostaje niezmieniony?**

Przykład dopasowuje całe słowo „Draft” z dokładną wielkością liter. Tekst zaimportowany jako obraz lub podzielony na oddzielne ramki tekstowe niekoniecznie zostanie dopasowany do wyszukiwania. Sprawdź zaimportowaną treść i dostosuj wyszukiwanie do swojego dokumentu.