---
title: Renderowanie slajdów prezentacji jako obrazy SVG w PHP
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/php-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint do SVG
- prezentacja do SVG
- slajd do SVG
- PPT do SVG
- PPTX do SVG
- Opcje eksportu SVG
- interaktywny SVG
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w PHP i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia za pomocą Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności i automatycznym przetwarzaniu po publikacji. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i umożliwia kontrolowanie, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#writeAsSvg). Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());

    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = java_values($slide->getSlideNumber());
        $outputFileName = sprintf("slide-%d.svg", $slideNumber);

        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);
        $slide->writeAsSvg($svgStream);
        $svgStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Nazwa pliku używa [Slide.getSlideNumber](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getSlideNumber), a nie indeksu pętli. Możesz także wyeksportować pojedynczy kształt za pomocą [Shape.writeAsSvg](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#writeAsSvg), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setUseFrameSize) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setUseFrameRotation) określa, czy zastosować rotację ramki. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, gdy tekst musi być renderowany bez ligatur.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setDisableFontLigatures(true);
    $svgOptions->setUseFrameSize(true);
    $svgOptions->setUseFrameRotation(false);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-custom-options.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Kontrola tekstu i czcionek**

### **Wektorowanie całego tekstu**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setVectorizeText) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminują to zależności od czcionek i sprawia, że wynik wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już wybieralny ani przeszukiwalny jako tekst SVG.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setVectorizeText(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-text.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwołać się do oddzielnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Sprawdź licencje czcionek przed ich osadzaniem.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $linkedFontsOptions = new SVGOptions();
    $linkedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::AddLinksToFontFiles);
    $linkedFontsStream = new Java("java.io.FileOutputStream", "slide-with-font-links.svg");
    try {
        $slide->writeAsSvg($linkedFontsStream, $linkedFontsOptions);
    } finally {
        $linkedFontsStream->close();
    }

    $embeddedFontsOptions = new SVGOptions();
    $embeddedFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Embed);
    $embeddedFontsStream = new Java("java.io.FileOutputStream", "slide-with-embedded-fonts.svg");
    try {
        $slide->writeAsSvg($embeddedFontsStream, $embeddedFontsOptions);
    } finally {
        $embeddedFontsStream->close();
    }

    $vectorizedExternalFontsOptions = new SVGOptions();
    $vectorizedExternalFontsOptions->setExternalFontsHandling(SvgExternalFontsHandling::Vectorize);
    $vectorizedExternalFontsStream = new Java("java.io.FileOutputStream", "slide-with-vectorized-external-fonts.svg");
    try {
        $slide->writeAsSvg($vectorizedExternalFontsStream, $vectorizedExternalFontsOptions);
    } finally {
        $vectorizedExternalFontsStream->close();
    }
} finally {
    $presentation->dispose();
}
```

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setPicturesCompression), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setJpegQuality), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $svgOptions = new SVGOptions();
    $svgOptions->setPicturesCompression(PicturesCompression::Dpi150);
    $svgOptions->setDeletePicturesCroppedAreas(true);
    $svgOptions->setJpegQuality(80);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "compressed-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Udostępnij funkcję zwrotną formatowania do [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setShapeFormattingController), aby ustawić [SvgShape.setId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgshape/#setId) dla każdego kształtu SVG. Funkcja zwrotna może również ustawiać wartości [SvgTSpan.setId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgtspan/#setId) na elementach tekstowych `tspan`.

PhpJavaBridge nie może wywołać funkcji zwrotnej PHP z `writeAsSvg`, gdy działa w trybie strumieniowym. Umieść logikę formatowania w małej klasie pomocniczej Java, skompiluj ją i dodaj wygenerowany plik JAR do ścieżki klas mostu. Pomocnik może używać [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getOfficeInteropShapeId), który jest stabilny przez cały czas życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Zobacz [Java implementation of `StableSvgIdController`](/slides/pl/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) aby uzyskać kod pomocnika.

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.StableSvgIdController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "slide-with-stable-ids.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

## **Dodaj obsługiwacze zdarzeń SVG**

W funkcji zwrotnej formatowania wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgshape/#setEventHandler) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgevent/) , aby dodać obsługiwacz zdarzeń JavaScript do wyeksportowanego kształtu. Przypisz funkcję zwrotną za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setShapeFormattingController) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, które hostują wynik.

Podobnie jak w przypadku stabilnych identyfikatorów, zaimplementuj funkcję zwrotną w pomocniku Java, gdy PhpJavaBridge używa trybu strumieniowego. [Java implementation of `SvgEventController`](/slides/pl/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) przypisuje identyfikator i obsługiwacz `OnClick` do kształtu o nazwie `ActionButton`. Skompiluj ten pomocnik, dodaj go do ścieżki klas mostu jako `com.example.slides.SvgEventController` i użyj go z PHP w następujący sposób:

```php
$presentation = new Presentation("presentation.pptx");
$svgStream = null;
try {
    $shapeFormattingController = new Java("com.example.slides.SvgEventController");

    $svgOptions = new SVGOptions();
    $svgOptions->setShapeFormattingController($shapeFormattingController);

    $slide = $presentation->getSlides()->get_Item(0);
    $svgStream = new Java("java.io.FileOutputStream", "interactive-slide.svg");
    $slide->writeAsSvg($svgStream, $svgOptions);
} finally {
    $svgStream->close();
    $presentation->dispose();
}
```

Strona hostująca może zdefiniować funkcję JavaScript, do której odwołuje się obsługiwacz. Przypisywanie identyfikatorów i obsługiwaczy zdarzeń umożliwia przeglądarki slajdów, udoskonalenia dostępności i inne interaktywne przepływy pracy z SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setVectorizeText) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgexternalfontshandling/)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#setVectorizeText), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgexternalfontshandling/), gdy tylko tekst używający czcionek zewnętrznych powinien być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wyboru połączonych plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory za pomocą funkcji zwrotnej formatowania, a następnie wybierz odpowiednie elementy SVG w swoim narzędziu do przetwarzania poeksportowego lub w skrypcie przeglądarki.