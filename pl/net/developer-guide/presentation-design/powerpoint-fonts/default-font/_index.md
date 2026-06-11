---
title: Określ domyślne czcionki prezentacji w .NET
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/net/default-font/
keywords:
- domyślna czcionka
- czcionka zwykła
- czcionka normalna
- czcionka azjatycka
- eksport PDF
- eksport XPS
- eksport obrazu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla .NET, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS oraz obrazów."
---
## **Przegląd**

Aspose.Slides pozwala określić domyślne czcionki używane podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki są konfigurowane za pomocą `LoadOptions` przed załadowaniem prezentacji.

Właściwość `DefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `DefaultAsianFont` określa domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i renderować przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek do renderowania prezentacji**
Aspose.Slides umożliwia ustawienie domyślnej czcionki do renderowania prezentacji do formatu PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont do użycia jako domyślne czcionki. Proszę wykonać poniższe kroki, aby załadować czcionki z zewnętrznych katalogów przy użyciu API Aspose.Slides dla .NET:

1. Utwórz instancję klasy LoadOptions.  
2. Ustaw właściwość DefaultRegularFont na żądaną czcionkę. W poniższym przykładzie użyto czcionki Wingdings.  
3. Ustaw właściwość DefaultAsianFont na żądaną czcionkę. W poniższym przykładzie użyto czcionki Wingdings.  
4. Załaduj prezentację przy użyciu klasy Presentation, ustawiając opcje ładowania.  
5. Teraz wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementację powyższego podano poniżej.

```c#
// Użyj opcji ładowania, aby określić domyślne czcionki zwykłe i azjatyckie
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **FAQ**

**Co dokładnie wpływa DefaultRegularFont i DefaultAsianFont — tylko eksport, czy również miniatury, PDF, XPS, HTML i SVG?**

Uczestniczą w potoku renderowania dla wszystkich obsługiwanych wyjść. Obejmuje to miniatury slajdów, [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [XPS](/slides/pl/net/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/net/convert-powerpoint-to-png/), [HTML](/slides/pl/net/convert-powerpoint-to-html/), i [SVG](/slides/pl/net/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów dla tych celów.

**Czy domyślne czcionki są stosowane podczas prostego odczytu i zapisu pliku PPTX bez renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Proste otwarcie i zapisanie prezentacji nie zmienia zapisanych fragmentów czcionek ani struktury pliku. Domyślne czcionki są wykorzystywane podczas operacji, które renderują lub przetwarzają tekst.

**Jeśli dodam własne foldery czcionek lub dostarczę czcionki z pamięci, czy zostaną one uwzględnione przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/net/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których może korzystać silnik. Domyślne czcionki oraz wszelkie [fallback rules](/slides/pl/net/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając bardziej niezawodne pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, advance) i w konsekwencji na podziały wierszy oraz zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpłynąć na podziały wierszy, zawijanie i paginację podczas renderowania. Dla stabilności układu, [embed the original fonts](/slides/pl/net/embedded-font/) lub wybierz metrycznie kompatybilne domyślne i zapasowe rodziny czcionek.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/net/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal są przydatne jako zabezpieczenie dla znaków, które nie są objęte osadzonym podzestawem, lub gdy plik miesza teksty osadzone i nieosadzone.