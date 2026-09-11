---
title: Określenie domyślnych czcionek prezentacji w Pythonie przez Java
linktitle: Domyślna czcionka
type: docs
weight: 30
url: /pl/python-java/default-font/
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
- Python
- Java
- Aspose.Slides
description: "Ustaw domyślne czcionki w Aspose.Slides dla Pythona przez Java, aby zapewnić prawidłową konwersję PowerPoint (PPT, PPTX) i OpenDocument (ODP) do PDF, XPS oraz obrazów."
---
## **Przegląd**

Aspose.Slides umożliwia określenie domyślnych czcionek używanych podczas renderowania prezentacji. Jest to przydatne przy generowaniu miniatur slajdów lub eksportowaniu prezentacji do formatów takich jak PDF i XPS. Domyślne czcionki są konfigurowane za pośrednictwem [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/) przed wczytaniem prezentacji.

Metoda [setDefaultRegularFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) określa domyślną czcionkę dla zwykłego tekstu, natomiast [setDefaultAsianFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) określa domyślną czcionkę dla tekstu azjatyckiego. Po ustawieniu tych opcji prezentację można wczytać i renderować przy użyciu określonych czcionek.

## **Użycie domyślnych czcionek do renderowania prezentacji**

Aspose.Slides pozwala ustawić domyślne czcionki przy renderowaniu prezentacji do PDF, XPS lub miniatur. Ten fragment pokazuje, jak zdefiniować domyślne czcionki dla tekstu zwykłego i azjatyckiego za pomocą Aspose.Slides dla Pythona poprzez Javę:

1. Utwórz instancję [LoadOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/).
2. Użyj [setDefaultRegularFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultRegularFont), aby określić żądaną czcionkę. Poniższy przykład używa czcionki Wingdings.
3. Użyj [setDefaultAsianFont](https://reference.aspose.com/slides/pl/python-java/aspose.slides/loadoptions/#setDefaultAsianFont), aby określić żądaną czcionkę. Poniższy przykład również używa czcionki Wingdings.
4. Wczytaj prezentację przy użyciu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) z opcjami ładowania.
5. Wygeneruj miniaturę slajdu, PDF i XPS, aby zweryfikować wyniki.

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Użyj opcji ładowania, aby określić domyślne czcionki regularne i azjatyckie.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Wczytaj prezentację.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Wygeneruj miniaturę slajdu.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Zapisz obraz na dysku.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Wygeneruj PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Wygeneruj dokument XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **Najczęściej zadawane pytania**

**Co dokładnie wpływają domyślne czcionki regularne i azjatyckie — tylko eksport, czy także miniatury, PDF, XPS, HTML i SVG?**

Uczestniczą w pipeline renderowania dla wszystkich obsługiwanych formatów wyjściowych. Obejmuje to miniatury slajdów, [PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/pl/python-java/convert-powerpoint-to-xps/), [obrazy rastrowe](/slides/pl/python-java/convert-powerpoint-to-png/), [HTML](/slides/pl/python-java/convert-powerpoint-to-html/), i [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/), ponieważ Aspose.Slides używa tej samej logiki układu i rozpoznawania glifów we wszystkich tych celach.

**Czy domyślne czcionki są stosowane przy jedynie odczytaniu i zapisaniu pliku PPTX bez renderowania?**

Nie. Domyślne czcionki mają znaczenie, gdy tekst musi zostać zmierzony i narysowany. Proste otwarcie‑zapisanie prezentacji nie zmienia zapisanych ciągów czcionek ani struktury pliku. Domyślne czcionki wchodzą w grę podczas operacji, które renderują lub przetwarzają tekst.

**Jeśli dodam własne foldery z czcionkami lub dostarczę czcionki z pamięci, czy będą brane pod uwagę przy wyborze domyślnych czcionek?**

Tak. [Custom font sources](/slides/pl/python-java/custom-font/) rozszerzają katalog dostępnych rodzin i glifów, z których silnik może korzystać. Domyślne czcionki oraz wszelkie [fallback rules](/slides/pl/python-java/fallback-font/) będą najpierw rozwiązywać się względem tych źródeł, zapewniając bardziej niezawodną obsługę na serwerach i w kontenerach.

**Czy domyślne czcionki wpływają na metryki tekstu (kerning, advance) i tym samym na podziały linii oraz zawijanie?**

Tak. Zmiana czcionki zmienia metryki glifów i może wpływać na podziały linii, zawijanie i paginację podczas renderowania. Dla stabilności układu warto [embed the original fonts](/slides/pl/python-java/embedded-font/) lub wybrać domyślne i zastępcze rodziny czcionek o zgodnych metrykach.

**Czy ma sens ustawianie domyślnych czcionek, jeśli wszystkie czcionki użyte w prezentacji są osadzone?**

Często nie jest to konieczne, ponieważ [embedded fonts](/slides/pl/python-java/embedded-font/) już zapewniają spójny wygląd. Domyślne czcionki nadal mogą pełnić rolę zabezpieczenia dla znaków nieobjętych osadzonym podzbiorem lub gdy plik miesza tekst osadzony i nieosadzony.