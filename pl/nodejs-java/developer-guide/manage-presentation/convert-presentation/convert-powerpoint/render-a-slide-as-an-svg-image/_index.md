---
title: Renderowanie slajdów prezentacji jako obrazy SVG w JavaScript
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/nodejs-java/render-a-slide-as-an-svg-image/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w JavaScript i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia przy użyciu Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu pośrednim. Aspose.Slides for Node.js via Java eksportuje każdy slajd do oddzielnego pliku SVG i umożliwia kontrolowanie sposobu zapisu tekstu, czcionek, obrazów i elementów SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Poniższy przykład eksportuje każdy slajd w prezentacji jako oddzielny plik SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

Nazwa pliku używa [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy pomocy [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) steruje renderowaniem SVG. Dla ramek tekstowych [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) obejmuje ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) określa, czy obrót ramki ma być zastosowany. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, gdy tekst musi być renderowany bez ligatur.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Kontrola tekstu i czcionek**

Podczas eksportu slajdów do SVG możesz kontrolować, czy tekst pozostaje jako tekst, czy zostaje przekonwertowany na grafikę wektorową oraz w jaki sposób zewnętrzne czcionki są dołączane lub odwoływane. Poniższe opcje pomagają zrównoważyć spójność wizualną, możliwość zaznaczania tekstu i zależności czcionek w wyeksportowanym SVG.

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminujesz zależności od czcionek i zapewniasz większą spójność wizualną w przeglądarkach, ale tekst nie będzie już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) przyjmuje wartość [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwoływać się do oddzielnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Przed dołączeniem czcionek sprawdź ich licencję.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/), aby obniżyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/), aby pominąć przycięte fragmenty źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/), aby kontrolować jakość kodowania JPEG. Ustawienia te zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Kontrola rozdzielczości rastrowania metafilu**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) określa dolny limit rozdzielczości przy rastrowaniu metafili podczas eksportu SVG. Użyj go, aby zrównoważyć szczegółowość i rozmiar pliku, gdy obraz EMF lub WMF jest rastrowany. Nie definiuje on globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z blisko rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje pierwszy slajd przy trzech rozdzielczościach rastrowania za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). Wszystkie pozostałe ustawienia eksportu pozostają niezmienione, aby wyniki można było porównać.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

W wyniku EMF został zamieniony na jeden osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie stanowią ogólnej formuły konwersji DPI na wymiary pikseli.

| Rozdzielczość rastrowania metafilu DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy tym samym powiększonym rozmiarze wyświetlania. Linie ukośne wykazują widoczną pikselację przy 72 DPI i gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy plik SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy szczegół ani nie zmienia każdego wyeksportowanego obrazu.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) kontroluje redukcję rozdzielczości obrazu i może maskować efekt zmiany rozdzielczości rastrowania metafilu. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) kontroluje jakość kodowania JPEG, nie rozdzielczość rastrowania metafilu.

## **Przypisz stabilne identyfikatory kształtom i tekstowi**

Przekaż kontroler formatowania do [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), aby ustawić [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) dla każdego kształtu SVG. Kontroler, który obsługuje także fragmenty tekstu, może ustawić wartości [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) na elementach `tspan`.

Poniższy kontroler używa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Dzięki temu wygenerowane identyfikatory nadają się do przetwarzania po wyeksportowaniu niezmienionej prezentacji.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Dodaj obsługę zdarzeń SVG**

W kontrolerze formatowania wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) z wartością [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/), aby dodać obsługę zdarzeń JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) i zdefiniuj funkcję JavaScript w stronie lub dokumencie SVG, który hostuje wynik.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

Strona hostująca może definiować funkcję JavaScript odwołującą się do obsługi zdarzenia. Przypisywanie identyfikatorów i obsługi zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności i inne interaktywne scenariusze SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/), gdy tylko tekst wykorzystujący czcionki zewnętrzne ma być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów oraz wyboru linkowanych plików czcionek, gdy środowisko docelowe może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy jakości i rozmiaru.

**Czy mogę modyfikować elementy SVG po wyeksportowaniu?**

Tak. Przypisz identyfikatory przy użyciu kontrolera formatowania, a następnie wybierz pasujące elementy SVG w narzędziu do przetwarzania po eksporcie lub w skrypcie przeglądarki.