---
title: Określ domyślne czcionki prezentacji w Javie
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/java/default-font/
keywords:
- domyślna czcionka
- czcionka regularna
- czcionka normalna
- czcionka azjatycka
- eksport PDF
- eksport XPS
- eksport obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla Javy, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS i obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniaturek slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki konfiguruje się za pomocą `LoadOptions` przed załadowaniem prezentacji.

Metoda `setDefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `setDefaultAsianFont` definiuje domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i renderować przy użyciu określonych czcionek.

## **Użyj domyślnych czcionek do renderowania prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę przy renderowaniu prezentacji do PDF, XPS lub miniaturek. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont jako czcionki domyślne. Postępuj zgodnie z poniższymi krokami, aby wczytać czcionki z zewnętrznych katalogów przy użyciu Aspose.Slides for Java API:

1. Utwórz instancję [LoadOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LoadOptions).
1. [Ustaw DefaultRegularFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na żądaną czcionkę. W poniższym przykładzie użyto Wingdings.
1. [Ustaw DefaultAsianFont](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na żądaną czcionkę. W przykładzie użyto Wingdings.
1. Załaduj prezentację używając klasy Presentation i ustawiając opcje ładowania.
1. Następnie wygeneruj miniaturkę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego znajduje się poniżej.

```java
// Użyj opcji ładowania, aby określić domyślne czcionki regularne i azjatyckie
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");

// Załaduj prezentację
Presentation pres = new Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Wygeneruj miniaturę slajdu
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
         // zapisz obraz na dysku.
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }

    // Wygeneruj PDF
    pres.save("output_out.pdf", SaveFormat.Pdf);

    // Wygeneruj XPS
    pres.save("output_out.xps", SaveFormat.Xps);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Co dokładnie wpływa DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniaturki, PDF, XPS, HTML i SVG?**

Uczestniczą w łańcuchu renderowania dla wszystkich obsługiwanych formatów wyjściowych. Obejmuje to miniaturki slajdów, [PDF](/slides/pl/java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/java/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/java/convert-powerpoint-to-png/), [HTML](/slides/pl/java/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/java/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy zwykłym odczycie i zapisie pliku PPTX bez renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych przebiegów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub przetwarzają tekst.

**Jeśli dodam własne foldery czcionek lub dostarczę czcionki z pamięci, czy będą brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/java/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których silnik może korzystać. Domyślne czcionki i wszelkie [fallback rules](/slides/pl/java/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając lepsze pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, advance) i tym samym na podziały linii i zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały linii, zawijanie oraz paginację podczas renderowania. Dla stabilności układu, [embed the original fonts](/slides/pl/java/embedded-font/) lub wybierz domyślne i zapasowe rodziny o zgodnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/java/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal pełnią rolę zabezpieczenia dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.