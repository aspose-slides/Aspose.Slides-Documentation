---
title: Określ domyślne czcionki prezentacji w PHP
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/php-java/default-font/
keywords:
- domyślna czcionka
- czcionka zwykła
- czcionka standardowa
- czcionka azjatycka
- eksport PDF
- eksport XPS
- eksport obrazów
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla PHP poprzez Java, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS i obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne podczas generowania miniatur slajdów lub eksportowania prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki są konfigurowane za pomocą `LoadOptions` przed załadowaniem prezentacji.

Metoda `setDefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `setDefaultAsianFont` definiuje domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i renderować przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek podczas renderowania prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę podczas renderowania prezentacji do PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont jako domyślne czcionki. Proszę postępować zgodnie z poniższymi krokami, aby wczytać czcionki z zewnętrznych katalogów przy użyciu Aspose.Slides dla PHP poprzez API Java:

1. Utwórz instancję [LoadOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LoadOptions).
1. [Ustaw DefaultRegularFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
1. [Ustaw DefaultAsianFont](https://reference.aspose.com/slides/pl/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
1. Załaduj prezentację przy użyciu klasy Presentation i ustawiając opcje ładowania.
1. Teraz wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego przedstawiona jest poniżej.

```php
  # Użyj opcji ładowania, aby określić domyślne czcionki standardowe i azjatyckie
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Załaduj prezentację
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Wygeneruj miniaturę slajdu
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # Zapisz obraz na dysku.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Wygeneruj PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Wygeneruj XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Co dokładnie wpływa DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Uczestniczą w potoku renderowania dla wszystkich obsługiwanych formatów wyjściowych. Obejmuje to miniatury slajdów, [PDF](/slides/pl/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/php-java/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/php-java/convert-powerpoint-to-png/), [HTML](/slides/pl/php-java/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/php-java/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozdzielania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy jedynie odczycie i zapisaniu pliku PPTX bez żadnego renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być mierzony i rysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych fragmentów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub przetwarzają tekst.

**Czy jeśli dodam własne katalogi czcionek lub dostarczę czcionki z pamięci, będą one brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Niestandardowe źródła czcionek](/slides/pl/php-java/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, które silnik może wykorzystać. Domyślne czcionki oraz wszelkie [reguły zastępowania](/slides/pl/php-java/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając bardziej niezawodne pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, odległości) i tym samym na podziały wierszy i zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały wierszy, zawijanie oraz paginację podczas renderowania. Dla stabilności układu, [osadź oryginalne czcionki](/slides/pl/php-java/embedded-font/) lub wybierz domyślne i zastępcze rodziny czcionek o kompatybilnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [osadzone czcionki](/slides/pl/php-java/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal pomagają jako zabezpieczenie dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.