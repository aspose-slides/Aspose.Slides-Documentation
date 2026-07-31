---
title: Określ domyślne czcionki prezentacji w C++
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/cpp/default-font/
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
- C++
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla C++, aby zapewnić poprawną konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS i obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki konfiguruje się za pośrednictwem `LoadOptions` przed załadowaniem prezentacji.

Metoda `set_DefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `set_DefaultAsianFont` definiuje domyślną czfontę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i renderować przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek do renderowania prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę przy renderowaniu prezentacji do PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont do użycia jako domyślne czcionki. Proszę postępować zgodnie z poniższymi krokami, aby ładować czcionki z zewnętrznych katalogów przy użyciu API Aspose.Slides dla C++:

1. Utwórz instancję LoadOptions.
1. Ustaw DefaultRegularFont na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
1. Ustaw DefaultAsianFont na żądaną czcionkę. W poniższym przykładzie użyłem Wingdings.
1. Załaduj prezentację za pomocą klasy Presentation, ustawiając opcje ładowania.
1. Teraz wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego jest podana poniżej.

```cpp
// Użyj opcji ładowania, aby określić domyślne czcionki regularne i azjatyckie
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

**Co dokładnie wpływa DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Uczestniczą w potoku renderowania dla wszystkich obsługiwanych formatów wyjściowych. Obejmuje to miniatury slajdów, [PDF](/slides/pl/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pl/cpp/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/cpp/convert-powerpoint-to-png/), [HTML](/slides/pl/cpp/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy prostym odczycie i zapisaniu pliku PPTX bez żadnego renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych ciągów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub przepływają tekst.

**Jeśli dodam własne foldery czcionek lub dostarczę czcionki z pamięci, czy będą one brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/cpp/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których silnik może korzystać. Domyślne czcionki oraz wszelkie [fallback rules](/slides/pl/cpp/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, co zapewnia bardziej niezawodne pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, przyrosty) i tym samym na podziały linii i zawijanie?**

Tak. Zmiana czcionki modyfikuje metryki glifów i może zmienić podziały linii, zawijanie oraz paginację podczas renderowania. Dla stabilności układu zaleca się [embed the original fonts](/slides/pl/cpp/embedded-font/) lub wybór domyślnych i zapasowych rodzin czcionek o metrycznej kompatybilności.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/cpp/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal mogą działać jako zabezpieczenie dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.