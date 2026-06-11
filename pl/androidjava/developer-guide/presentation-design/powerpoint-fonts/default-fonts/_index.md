---
title: Określenie domyślnych czcionek prezentacji w Androidzie
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/androidjava/default-font/
keywords:
- domyślna czcionka
- czcionka regularna
- czcionka normalna
- czcionka azjatycka
- eksport PDF
- eksport XPS
- eksport obrazów
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla Androida za pomocą Java, aby zapewnić poprawną konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS oraz obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki są konfigurowane za pomocą `LoadOptions` przed załadowaniem prezentacji.

Metoda `setDefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `setDefaultAsianFont` definiuje domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentacja może zostać załadowana i renderowana przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek do renderowania prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę przy renderowaniu prezentacji do PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont jako domyślne czcionki. Proszę postępować zgodnie z poniższymi krokami, aby wczytać czcionki z zewnętrznych katalogów przy użyciu Aspose.Slides for Android za pośrednictwem Java API:

1. Utwórz instancję [LoadOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LoadOptions).
2. [Ustaw DefaultRegularFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
3. [Ustaw DefaultAsianFont](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
4. Załaduj prezentację przy użyciu klasy Presentation i ustawiając opcje ładowania.
5. Teraz wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego jest podana poniżej.

```java
// Użyj opcji ładowania, aby określić domyślne czcionki standardowe i azjatyckie
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

**Co dokładnie wpływa DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Biorą udział w potoku renderowania dla wszystkich obsługiwanych formatów wyjściowych. Obejmuje to miniatury slajdów, [PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pl/androidjava/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/androidjava/convert-powerpoint-to-png/), [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów we wszystkich tych docelach.

**Czy domyślne czcionki są stosowane przy zwykłym odczycie i zapisie pliku PPTX bez żadnego renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych ciągów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub przetwarzają tekst.

**Jeśli dodam własne foldery z czcionkami lub dostarczam czcionki z pamięci, czy będą brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/androidjava/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, które silnik może używać. Domyślne czcionki oraz wszelkie [fallback rules](/slides/pl/androidjava/fallback-font/) będą najpierw rozwiązywane względem tych źródeł, co zapewnia większe pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, odległości) i tym samym na podziały linii oraz zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały linii, zawijanie i paginację podczas renderowania. Dla stabilności układu [osadz oryginalne czcionki](/slides/pl/androidjava/embedded-font/) lub wybierz domyślne i zapasowe rodziny czcionek o kompatybilnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/androidjava/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal mogą pełnić rolę zabezpieczenia dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.