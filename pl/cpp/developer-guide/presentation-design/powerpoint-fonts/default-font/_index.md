---
title: Określ domyślne czcionki prezentacji w C++
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla C++, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS oraz obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek domyślnych, które są używane podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Czcionki domyślne są konfigurowane za pomocą `LoadOptions` przed załadowaniem prezentacji.

Metoda `set_DefaultRegularFont` definiuje czcionkę domyślną dla zwykłego tekstu, natomiast `set_DefaultAsianFont` definiuje czcionkę domyślną dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentacja może być załadowana i renderowana przy użyciu określonych czcionek.

## **Używanie czcionek domyślnych przy renderowaniu prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę przy renderowaniu prezentacji do PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont do użycia jako czcionki domyślne. Postępuj zgodnie z poniższymi krokami, aby załadować czcionki z zewnętrznych katalogów przy użyciu API Aspose.Slides dla C++:

1. Utwórz instancję klasy LoadOptions.
1. Ustaw DefaultRegularFont na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
1. Ustaw DefaultAsianFont na żądaną czcionkę. W kolejnej próbce użyłem Wingdings.
1. Załaduj prezentację przy użyciu klasy Presentation, ustawiając opcje ładowania.
1. Następnie wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego znajduje się poniżej.

```cpp
// Użyj opcji ładowania, aby określić domyślne czcionki zwykłe i azjatyckie
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **FAQ**

**Co dokładnie wpływa na DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Biorą udział w potoku renderowania dla wszystkich obsługiwanych wyjść. Obejmuje to miniatury slajdów, [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pl/cpp/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/cpp/convert-powerpoint-to-png/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów we wszystkich tych docelach.

**Czy czcionki domyślne są stosowane przy prostym odczycie i zapisie pliku PPTX bez renderowania?**

Nie. Czcionki domyślne mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie‑zapisanie prezentacji nie zmienia zapisanych fragmentów czcionek ani struktury pliku. Czcionki domyślne wchodzą w grę podczas operacji, które renderują lub przetwarzają tekst.

**Jeśli dodam własne foldery z czcionkami lub dostarczę czcionki z pamięci, czy będą brane pod uwagę przy wyborze czcionek domyślnych?**

Tak. [Custom font sources](/slides/pl/cpp/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których może korzystać silnik. Czcionki domyślne oraz wszelkie [fallback rules](/slides/pl/cpp/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając bardziej niezawodne pokrycie na serwerach i w kontenerach.

**Czy czcionki domyślne wpływają na metryki tekstu (kerning, przesunięcia), a tym samym na podziały wierszy i zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały wierszy, zawijanie oraz paginację podczas renderowania. Dla stabilności układu, [embed the original fonts](/slides/pl/cpp/embedded-font/) lub wybierz metrycznie kompatybilne rodziny domyślne i zapasowe.

**Czy ma sens ustawianie czcionek domyślnych, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/cpp/embedded-font/) już zapewniają spójny wygląd. Czcionki domyślne nadal mogą służyć jako zabezpieczenie dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.