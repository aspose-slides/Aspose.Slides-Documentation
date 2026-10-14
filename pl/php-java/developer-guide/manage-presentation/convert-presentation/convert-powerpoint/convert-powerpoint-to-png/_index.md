---
title: Konwertuj slajdy PowerPoint na PNG w PHP
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/php-java/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- PHP
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides for PHP via Java, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides for PHP via Java. Możesz wczytywać prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Przykłady poniżej demonstrują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwersja PowerPoint do PNG**

Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów za pośrednictwem kolekcji [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides). Przykład renderuje każdy slajd przy użyciu [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) bez parametrów, aby utworzyć miniaturę. Następnie wywołuje [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save) z [ImageFormat::Png](https://reference.aspose.com/slides/php-java/aspose.slides/imageformat/#Png), aby zapisać każdy wyrenderowany slajd jako obraz PNG.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage();
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Przeciążenie [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) bez parametrów renderuje w skali 0.2. Na przykład slajd o wymiarach 720 × 540 punktów generuje miniaturę 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skali lub explicite określonym rozmiarem obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwersja PowerPoint do PNG z niestandardowymi wymiarami**

Przekaż poziome i pionowe współczynniki skali do [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage), aby kontrolować renderowane wymiary. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 Г— 540 punktów generuje obraz 1440 Г— 1080 pikseli. Równe współczynniki skali zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save).

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $scaleX = 2.0;
    $scaleY = $scaleX;

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($scaleX, $scaleY);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Konwersja PowerPoint do PNG z niestandardowym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage) zamiast współczynników skali. Ten przykład renderuje każdy slajd w wymiarach 960 Г— 720 pikseli i zapisuje wynik przy użyciu [IImage::save](https://reference.aspose.com/slides/php-java/aspose.slides/iimage/#save). Wybierz wymiary, które odpowiadają proporcjom slajdu, aby uniknąć rozciągania obrazu.

```php
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $imageSize = new Java("java.awt.Dimension", 960, 720);

    $slideCount = java_values($presentation->getSlides()->size());
    for ($index = 0; $index < $slideCount; $index++) {
        $slide = $presentation->getSlides()->get_Item($index);
        $image = $slide->getImage($imageSize);
        try {
            $image->save("slide_" . $index . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Wybór stylu renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym pliku PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Możesz użyć metody [SaveOptions::setGradientStyle](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setGradientStyle) dziedziczonej po [RenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz plik [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jego pierwszy slajd zawiera dwa gradienty liniowe: od cyjanu do pomarańczu u góry oraz od niebieskiego do żółtego u dołu. Każdy gradient ma dwa punkty zatrzymania, przy 0% i 100%.

Poniższy przykład ładuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [Slide::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#getImage).

```php
use aspose\slides\GradientStyle;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;

$presentation = new Presentation("gradient-styles.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $gradientStyles = [GradientStyle::Default, GradientStyle::PowerPointUI];
    foreach ($gradientStyles as $style) {
        $options = new RenderingOptions();
        $options->setGradientStyle($style);

        $styleName = $style == GradientStyle::Default ? "Default" : "PowerPointUI";
        $image = $slide->getImage($options, 1.0, 1.0);
        try {
            $image->save("gradient-" . $styleName . ".png", ImageFormat::Png);
        } finally {
            $image->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Poniższe obrazy pokazują wynik z tego samego slajdu, z oboma gradientami w każdym obrazie:

| Default | PowerPointUI |
| --- | --- |
| ![Gradienty od cyjanu do pomarańczu oraz od niebieskiego do żółtego renderowane stylem Default](gradient-Default.png) | ![Te same gradienty renderowane stylem PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` generuje jaśniejsze kolory pośrednie, podczas gdy `PowerPointUI` generuje ciemniejsze kolory pośrednie. Różnica zależy od kolorów i punktów zatrzymania w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Wypróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z zamierzonym rezultatem; żaden tryb nie jest uniwersalnie lepszy.

## **FAQ**

**Jak mogę wyeksportować konkretny kształt, taki jak wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/php-java/create-shape-thumbnails/), umożliwiając renderowanie kształtu jako obrazu PNG.

**Czy konwersja równoległa jest wspierana na serwerze?**

Tak. Używaj oddzielnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji pomiędzy wątkami](/slides/pl/php-java/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksporcie do PNG?**

Tryb ewaluacyjny dodaje znak wodny do wyjściowych obrazów i stosuje [inne ograniczenia](/slides/pl/php-java/licensing/), dopóki nie zostanie zastosowana licencja.