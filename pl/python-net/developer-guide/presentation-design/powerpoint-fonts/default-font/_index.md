---
title: Dostosuj domyślne czcionki w prezentacjach przy użyciu Pythona
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/python-net/default-font/
keywords:
- domyślna czcionka
- zwykła czcionka
- normalna czcionka
- czcionka azjatycka
- eksport PDF
- eksport XPS
- eksport obrazów
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla Pythona, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS oraz obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniaturek slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki konfiguruje się za pośrednictwem `LoadOptions` przed załadowaniem prezentacji.

Właściwość `default_regular_font` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `default_asian_font` określa domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i renderować przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek do renderowania prezentacji**
Aspose.Slides pozwala ustawić domyślną czcionkę przy renderowaniu prezentacji do PDF, XPS lub miniaturek. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont jako domyślne czcionki. Postępuj zgodnie z poniższymi krokami, aby ładować czcionki z zewnętrznych katalogów przy użyciu Aspose.Slides for Python via .NET API:

1. Utwórz instancję LoadOptions.  
2. Ustaw DefaultRegularFont na wybraną czcionkę. W poniższym przykładzie użyto Wingdings.  
3. Ustaw DefaultAsianFont na wybraną czcionkę. W przykładowym kodzie również użyto Wingdings.  
4. Załaduj prezentację przy użyciu Presentation i ustawiając opcje ładowania.  
5. Wygeneruj miniaturkę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego jest podana poniżej.

```py
import aspose.slides as slides

# Użyj opcji ładowania, aby określić domyślne czcionki zwykłe i azjatyckie# Użyj opcji ładowania, aby określić domyślne czcionki zwykłe i azjatyckie
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Załaduj prezentację
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Wygeneruj miniaturkę slajdu
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Wygeneruj PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Wygeneruj XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **FAQ**

**Co dokładnie wpływa `default_regular_font` i `default_asian_font` — tylko eksport, czy także miniaturki, PDF, XPS, HTML i SVG?**

Uczestniczą w potoku renderowania dla wszystkich obsługiwanych wyjść. Obejmuje to miniaturki slajdów, [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-net/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/python-net/convert-powerpoint-to-png/), [HTML](/slides/pl/python-net/convert-powerpoint-to-html/), oraz [SVG](/slides/pl/python-net/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozpoznawania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy zwykłym odczycie i zapisie pliku PPTX bez renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych przebiegów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji renderujących lub przeliczających tekst.

**Jeśli dodam własne katalogi czcionek lub dostarczę czcionki z pamięci, czy będą brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/python-net/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, które silnik może wykorzystać. Domyślne czcionki i wszelkie [reguły zastępowania](/slides/pl/python-net/fallback-font/) będą najpierw rozwiązywać się w odniesieniu do tych źródeł, zapewniając lepsze pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, odstępy) i tym samym na podziały linii i zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały linii, zawijanie oraz paginację podczas renderowania. Dla stabilności układu warto [osadzić oryginalne czcionki](/slides/pl/python-net/embedded-font/) lub wybrać domyślne i zastępcze rodziny o kompatybilnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/python-net/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal mogą pełnić rolę zabezpieczenia dla znaków nieobjętych osadzonym podzbiorem lub gdy plik łączy tekst osadzony i nieosadzony.