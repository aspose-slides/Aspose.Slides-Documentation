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
- opcje eksportu SVG
- interaktywny SVG
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w PHP i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia przy użyciu Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu po zakończeniu. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, w jaki sposób zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/), gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportowanie slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia przy użyciu [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#writeAsSvg). Poniższy przykład eksportuje każdy slajd z prezentacji jako osobny plik SVG.

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

Nazwa pliku używa [Slide.getSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getSlideNumber) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy użyciu [Shape.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfigurowanie wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameSize) włącza ramkę tekstową w obszar renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setUseFrameRotation) określa, czy obrót ramki jest stosowany. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, gdy tekst musi być renderowany bez ligatur.

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

## **Kontrola przycinania końców linii przy grotach strzałek**

SVG 1.1 nie posiada ustawienia wcięcia znacznika, które określałoby, gdzie linia ma się zatrzymać pod grotami strzałki. Domyślnie Aspose.Slides skraca wyeksportowaną linię, aby jej obrys nie wystawał poza znacznik. Wywołaj [SVGOptions::setDisableLineEndCropping](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setdisablelineendcropping/) z wartością `true`, aby narysować obrys aż do oryginalnego punktu końcowego linii. To ustawienie wpływa tylko na wyjście SVG. Linia zachowuje swoją pozycję i długość na slajdzie.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use aspose\slides\SVGOptions;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $y = 40;

    foreach ([LineArrowheadStyle::Triangle, LineArrowheadStyle::Diamond] as $style) {
        foreach ([2, 10] as $width) {
            $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 40, $y, 200, 0);
            $format = $line->getLineFormat();
            $format->getFillFormat()->setFillType(FillType::Solid);
            $color = new Java("java.awt.Color", 0, 0, 139);
            $format->getFillFormat()->getSolidFillColor()->setColor($color);
            $format->setWidth($width);
            $format->setEndArrowheadStyle($style);
            $y += 50;
        }
    }

    $options = new SVGOptions();
    $options->setDisableLineEndCropping(false);
    $cropped = new Java("java.io.FileOutputStream", "cropped.svg");
    try {
        $slide->writeAsSvg($cropped, $options);
    } finally {
        $cropped->close();
    }

    $options->setDisableLineEndCropping(true);
    $uncropped = new Java("java.io.FileOutputStream", "uncropped.svg");
    try {
        $slide->writeAsSvg($uncropped, $options);
    } finally {
        $uncropped->close();
    }
} finally {
    $presentation->dispose();
}
```

Przykład rysuje trójkątne i rombowe groty strzałek na liniach o szerokości 2 i 10 punktów. Eksportuje ten sam slajd dwukrotnie, zmieniając tylko opcję przycinania.

![Powiększony trójkąt 10‑punktowy z ostrym końcem, gdy przycinanie jest włączone, oraz płaskim końcem, gdy przycinanie jest wyłączone](line-end-cropping.png)

W pozostałych liniach z przykładu wystający obrys jest mniej widoczny przy trójkącie 2‑punktowym. Wypełniony romb pokrywa koniec obrysu przy obu szerokościach.

## **Kontrola tekstu i czcionek**

Podczas eksportowania slajdów do SVG możesz kontrolować, czy tekst pozostaje tekstem czy jest konwertowany na grafikę wektorową, oraz w jaki sposób zewnętrzne czcionki są dołączane lub odwoływane. Poniższe opcje pomogą Ci zrównoważyć spójność wizualną, możliwość zaznaczania tekstu oraz zależności czcionek w wyeksportowanym SVG.

### **Wektoryzacja całego tekstu**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminują to zależności od czcionek i sprawia, że efekt wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

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

### **Wybór sposobu obsługi zewnętrznych czcionek**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setExternalFontsHandling) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwoływać się do oddzielnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst korzystający zewnętrznych czcionek jako grafikę. Sprawdź licencjonowanie czcionek przed ich dołączeniem.

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

## **Zmniejszanie rozmiaru osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setPicturesCompression), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas), aby pominąć przycięte fragmenty źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setJpegQuality), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

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

## **Kontrola rozdzielczości rasteryzacji metaplików**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) ustawia dolny limit rozdzielczości rasteryzacji metaplików podczas eksportu SVG. Użyj go, aby wyważyć szczegóły i rozmiar pliku, gdy obraz EMF lub WMF jest rasteryzowany. Nie definiuje on globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z ściśle rozmieszczonymi liniami diagonalnymi. Poniższy przykład eksportuje jego pierwszy slajd w trzech rozdzielczościach rasteryzacji przy użyciu [Slide.writeAsSvg](https://reference.aspose.com/slides/php-java/aspose.slides/slide/writeassvg/). Wszystkie pozostałe ustawienia eksportu pozostają identyczne, aby wyniki można było porównać.

```php
$presentation = new Presentation("metafile-rasterization.pptx");

try {
    foreach ([72, 150, 300] as $dpi) {
        $svgOptions = new SVGOptions();
        $svgOptions->setMetafileRasterizationDpi($dpi);
        $svgOptions->setPicturesCompression(PicturesCompression::Dpi330);
        $svgOptions->setJpegQuality(90);

        $outputFileName = sprintf("slide-%d.svg", $dpi);
        $svgStream = new Java("java.io.FileOutputStream", $outputFileName);

        try {
            $presentation->getSlides()->get_Item(0)->writeAsSvg($svgStream, $svgOptions);
        } finally {
            $svgStream->close();
        }
    }
} finally {
    $presentation->dispose();
}
```

W wyniku wyjściowym EMF został zamieniony na pojedynczy osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie są ogólną formułą konwersji DPI na wymiary w pikselach.

| Rasteryzacja metapliku DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy tej samej powiększonej wielkości wyświetlania. Linie diagonalne wykazują widoczną pikselację przy 72 DPI oraz gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy rozmiar pliku SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy detal ani nie zmienia każdego wyeksportowanego obrazu.

![Powiększone szczegóły linii diagonalnych przy 72, 150 i 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setpicturescompression/) kontroluje zmniejszanie rozdzielczości obrazu i może maskować efekt zmiany rozdzielczości rasteryzacji metapliku. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/setjpegquality/) kontroluje jakość kodowania JPEG, a nie rozdzielczość rasteryzacji metapliku.

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Podaj funkcję zwrotną formatowania do [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController), aby ustawić [SvgShape.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setId) dla każdego kształtu SVG. Funkcja zwrotna może także ustawić wartości [SvgTSpan.setId](https://reference.aspose.com/slides/php-java/aspose.slides/svgtspan/#setId) w elementach `tspan` tekstu.

PhpJavaBridge nie może wywołać zwrotnego wywołania PHP z `writeAsSvg`, gdy działa w trybie strumieniowym. Umieść logikę formatowania w małej klasie pomocniczej Java, skompiluj ją i dodaj powstały plik JAR do ścieżki klas mostu. Pomocnik może używać [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getOfficeInteropShapeId), który jest stabilny przez cały czas życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Zobacz [Java implementation of `StableSvgIdController`](/slides/pl/java/render-a-slide-as-an-svg-image/#assign-stable-ids-to-shapes-and-text) aby uzyskać kod pomocnika.

Po dodaniu skompilowanej klasy `com.example.slides.StableSvgIdController` do ścieżki klas mostu, utwórz jej instancję z PHP i przypisz ją do `SVGOptions`:

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

## **Dodawanie obsługi zdarzeń SVG**

W funkcji zwrotnej formatowania wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/php-java/aspose.slides/svgshape/#setEventHandler) z wartością [SvgEvent](https://reference.aspose.com/slides/php-java/aspose.slides/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz funkcję zwrotną za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setShapeFormattingController) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który zawiera wynik.

Podobnie jak w przypadku stabilnych identyfikatorów, zaimplementuj funkcję zwrotną w pomocniku Java, gdy PhpJavaBridge używa trybu strumieniowego. [Java implementation of `SvgEventController`](/slides/pl/java/render-a-slide-as-an-svg-image/#add-svg-event-handlers) przypisuje identyfikator i obsługę `OnClick` do kształtu o nazwie `ActionButton`. Skompiluj tego pomocnika, dodaj go do ścieżki klas mostu jako `com.example.slides.SvgEventController` i użyj go z PHP w następujący sposób:

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

Strona hosta może zdefiniować funkcję JavaScript odwoływaną przez obsługę. Przypisywanie identyfikatorów i obsług zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności oraz inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/php-java/aspose.slides/svgoptions/#setVectorizeText), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/php-java/aspose.slides/svgexternalfontshandling/), gdy tylko tekst wykorzystujący zewnętrzne czcionki ma być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usuwania przyciętych fragmentów obrazu i wyboru plików czcionek z odnośnikami, gdy środowisko docelowe może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy jakości i rozmiaru.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory za pomocą funkcji zwrotnej formatowania, a następnie wybierz pasujące elementy SVG w swoim narzędziu do post‑procesingu lub w skrypcie przeglądarki.