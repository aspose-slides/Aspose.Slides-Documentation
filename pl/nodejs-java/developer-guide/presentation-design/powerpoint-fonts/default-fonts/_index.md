---
title: Określ domyślne czcionki prezentacji w JavaScript
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/nodejs-java/default-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla Node.js za pomocą Java, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS i obrazów."
---
## **Przegląd**

Aspose.Slides pozwala określić domyślne czcionki używane podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki są konfigurowane za pomocą `LoadOptions` przed załadowaniem prezentacji.

Metoda `setDefaultRegularFont` definiuje domyślną czcionkę dla zwykłego tekstu, natomiast `setDefaultAsianFont` definiuje domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można załadować i wyrenderować przy użyciu określonych czcionek.

## **Używanie domyślnych czcionek do renderowania prezentacji**
Aspose.Slides umożliwia ustawienie domyślnej czcionki przy renderowaniu prezentacji do PDF, XPS lub miniatur. Ten artykuł pokazuje, jak zdefiniować DefaultRegularFont i DefaultAsianFont do użycia jako czcionki domyślne. Postępuj zgodnie z poniższymi krokami, aby ładować czcionki z zewnętrznych katalogów przy użyciu Aspose.Slides dla Node.js poprzez interfejs Java API:

1. Utwórz instancję [LoadOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LoadOptions).
2. [Ustaw DefaultRegularFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) na wybraną czcionkę. W poniższym przykładzie użyto Wingdings.
3. [Ustaw DefaultAsianFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) na wybraną czcionkę. W przykładzie użyto Wingdings.
4. Załaduj prezentację przy użyciu klasy Presentation i ustawiając opcje ładowania.
5. Teraz wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

Implementacja powyższego znajduje się poniżej.

```javascript
// Użyj opcji ładowania, aby zdefiniować domyślne czcionki regularne i azjatyckie
var loadOptions = new aspose.slides.LoadOptions(aspose.slides.LoadFormat.Auto);
loadOptions.setDefaultRegularFont("Wingdings");
loadOptions.setDefaultAsianFont("Wingdings");
// Wczytaj prezentację
var pres = new aspose.slides.Presentation("DefaultFonts.pptx", loadOptions);
try {
    // Wygeneruj miniaturę slajdu
    var slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    try {
        // zapisz obraz na dysku.
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Wygeneruj PDF
    pres.save("output_out.pdf", aspose.slides.SaveFormat.Pdf);
    // Wygeneruj XPS
    pres.save("output_out.xps", aspose.slides.SaveFormat.Xps);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Co dokładnie wpływają DefaultRegularFont i DefaultAsianFont — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Uczestniczą w potoku renderowania dla wszystkich obsługiwanych wyjść. Obejmuje to miniatury slajdów, [PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/nodejs-java/convert-powerpoint-to-png/), [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/) i [SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozwiązywania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy zwykłym odczycie i zapisie pliku PPTX bez renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi być zmierzony i narysowany. Bezpośrednie otwarcie i zapisanie prezentacji nie zmienia zapisanych przebiegów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub ponownie układają tekst.

**Jeśli dodam własne foldery czcionek lub dostarczę czcionki z pamięci, czy będą brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/nodejs-java/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których może korzystać silnik. Domyślne czcionki oraz wszelkie [fallback rules](/slides/pl/nodejs-java/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając bardziej niezawodne pokrycie na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, odległości) i tym samym na podziały linii i zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały linii, zawijanie i paginację podczas renderowania. Dla stabilności układu warto [embed the original fonts](/slides/pl/nodejs-java/embedded-font/) lub wybrać domyślne i zapasowe rodziny czcionek o kompatybilnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/nodejs-java/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal są przydatne jako zabezpieczenie dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.