---
title: Konwertuj slajdy PowerPoint na PNG w JavaScript
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/nodejs-java/convert-powerpoint-to-png/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Szybko konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG w JavaScript przy użyciu Aspose.Slides dla Node.js, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować slajdy prezentacji na obrazy PNG przy użyciu Aspose.Slides dla Node.js w języku Java. Możesz wczytywać prezentacje w formatach takich jak PPT, PPTX i ODP, renderować każdy slajd i zapisywać go jako osobny obraz PNG.

Poniższe przykłady pokazują renderowanie w domyślnej skali, zwiększanie skali, określanie wymiarów wyjściowych w pikselach oraz wybór stylu renderowania gradientu.

## **Konwertuj PowerPoint do PNG**

Załaduj prezentację przy użyciu klasy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do jej slajdów poprzez kolekcję [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). Przykład renderuje każdy slajd za pomocą [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) bez parametrów, aby utworzyć miniaturkę. Następnie wywołuje [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) z [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png), aby zapisać każdy wyrenderowany slajd jako obraz PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Uwaga" %}}
Przeciążenie [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) bez parametrów renderuje w skali 0,2. Na przykład slajd o wymiarach 720 × 540 punktów generuje miniaturkę 144 × 108 pikseli. Aby kontrolować wymiary wyjściowe, użyj przeciążeń ze współczynnikami skali lub podaj explicite rozmiar obrazu, jak pokazano poniżej.
{{% /alert %}}

## **Konwertuj PowerPoint do PNG z własnymi wymiarami**

Przekaż poziome i pionowe współczynniki skali do [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage), aby kontrolować wymiary renderowanego obrazu. W tym przykładzie oba współczynniki wynoszą 2, więc slajd o wymiarach 720 × 540 punktów generuje obraz 1440 × 1080 pikseli. Równe współczynniki skali zachowują proporcje slajdu. Każdy obraz jest zapisywany w formacie PNG przy użyciu [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Konwertuj PowerPoint do PNG z niestandardowym rozmiarem**

Aby określić wymiary wyjściowe w pikselach, przekaż rozmiar do [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) zamiast współczynników skali. Ten przykład renderuje każdy slajd w rozmiarze 960 × 720 pikseli i zapisuje wynik przy użyciu [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Dobierz wymiary tak, aby zachować proporcje slajdu, aby uniknąć rozciągnięcia obrazu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **Wybierz styl renderowania gradientu**

Załóżmy, że slajd zawiera wypełnienia gradientowe, ale przejścia w wyeksportowanym PNG wyglądają jaśniej lub inaczej niż w PowerPoint. Możesz użyć metody [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) dziedziczonej po [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/), aby wybrać sposób renderowania gradientów.

Pobierz [gradient-styles.pptx](gradient-styles.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera dwa gradienty liniowe: cyjan do pomarańczowego u góry oraz niebieski do żółtego na dole. Każdy gradient ma dwa przystanki, przy 0 % i 100 %.

Poniższy przykład wczytuje tę prezentację i renderuje ten sam pierwszy slajd w obu trybach przy użyciu [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Obrazy poniżej prezentują wynik tego samego slajdu, z oboma gradientami w każdym obrazie:

| Default | PowerPointUI |
| --- | --- |
| ![Cyan-to-orange and blue-to-yellow gradients rendered with Default](gradient-Default.png) | ![The same gradients rendered with PowerPointUI](gradient-PowerPointUI.png) |

W tym przykładzie `Default` generuje jaśniejsze kolory pośrednie, natomiast `PowerPointUI` – ciemniejsze. Różnica zależy od kolorów i przystanków w gradiencie.

Wybierz `Default`, gdy standardowy wynik Aspose.Slides spełnia Twoje potrzeby. Spróbuj `PowerPointUI`, gdy priorytetem jest dopasowanie wyglądu do PowerPoint. Porównaj oba wyniki z oczekiwanym rezultatem; żaden tryb nie jest uniwersalnie lepszy.

## **FAQ**

**Jak mogę wyeksportować konkretny kształt, np. wykres lub obraz, zamiast całego slajdu?**

Aspose.Slides obsługuje [generowanie miniatur dla poszczególnych kształtów](/slides/pl/nodejs-java/create-shape-thumbnails/), umożliwiając renderowanie wybranego kształtu jako obrazu PNG.

**Czy konwersja równoległa jest wspierana na serwerze?**

Tak. Używaj osobnej instancji prezentacji dla każdego wątku lub procesu; [nie udostępniaj jednej instancji między wątkami](/slides/pl/nodejs-java/multithreading/).

**Jakie są ograniczenia wersji ewaluacyjnej przy eksporcie do PNG?**

Tryb ewaluacyjny dodaje znak wodny do wyjściowych obrazów i nakłada [inne ograniczenia](/slides/pl/nodejs-java/licensing/), dopóki nie zostanie zastosowana licencja.