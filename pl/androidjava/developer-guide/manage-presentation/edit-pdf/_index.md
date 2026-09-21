---
title: Edytuj dokumenty PDF na Androidzie
linktitle: Edytuj PDF
type: docs
weight: 65
url: /pl/androidjava/edit-pdf/
keywords:
- edytuj PDF
- zastąp tekst PDF
- PDF do PPTX
- PPTX do PDF
- Android
- Java
- Aspose.Slides
description: "Edytuj dokumenty PDF na Androidzie za pomocą Javy, importując je do Aspose.Slides, zastępując tekst i zapisując zmodyfikowaną prezentację z powrotem do formatu PDF."
---
## **Przegląd**

Aspose.Slides for Android via Java umożliwia edycję treści PDF poprzez importowanie jego stron jako slajdów, modyfikowanie prezentacji i eksportowanie jej z powrotem do PDF. Ten artykuł pokazuje proste zastąpienie tekstu. Prezentacja pozostaje w pamięci, więc zapisanie pośredniego pliku PPTX jest opcjonalne.

## **Zastąpienie tekstu w pliku PDF**

Użyj [addFromPdf](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) do zaimportowania stron, [replaceText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) do aktualizacji tekstu i [save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) do wyeksportowania wyniku.

Poniższy przykład zakłada, że `input.pdf` zawiera słowo „Draft” jako edytowalny tekst po imporcie. Zastępuje to słowo słowem „Final” i zapisuje `edited.pdf`. Wyczyść początkowy slajd przed importem, aby zapobiec dodatkowej pustej stronie w wyniku. Wyszukiwanie dopasowuje całe słowa z taką samą wielkością liter; `null` oznacza, że nie jest potrzebny żaden callback wyniku.

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

Aby uzyskać więcej opcji, zobacz [Wyszukiwanie i zamiana tekstu](/slides/pl/androidjava/search-and-replace-text/) oraz [Konwersja PowerPoint do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Zastąpienie tekstu działa na zaimportowanym tekście, a nie na tekście znajdującym się w zeskanowanych obrazach. Konwersja może wpływać na układ i formatowanie, dlatego należy sprawdzić wynik, szczególnie gdy zastępowany tekst jest dłuższy niż oryginalny.
{{% /alert %}}

## **FAQ**

**Czy muszę zapisać plik PPTX przed eksportem do PDF?**

Nie. Możesz edytować i wyeksportować tę samą prezentację w pamięci. Zapisz kopię PPTX tylko wtedy, gdy chcesz kontynuować jej edycję w programie PowerPoint; zobacz [Zapisz prezentacje](/slides/pl/androidjava/save-presentation/).

**Dlaczego niektóry tekst może pozostać niezmieniony?**

Przykład dopasowuje całe słowo „Draft” z dokładnym uwzględnieniem wielkości liter. Tekst zaimportowany jako obraz lub podzielony na oddzielne ramki tekstowe niekoniecznie zostanie dopasowany. Sprawdź zaimportowaną treść i dostosuj wyszukiwanie do swojego dokumentu.