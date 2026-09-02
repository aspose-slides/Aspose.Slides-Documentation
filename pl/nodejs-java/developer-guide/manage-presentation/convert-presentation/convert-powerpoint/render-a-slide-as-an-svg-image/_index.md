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
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w JavaScript i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia za pomocą Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności i automatycznym przetwarzaniu po zakończeniu. Aspose.Slides dla Node.js poprzez Java eksportuje każdy slajd do osobnego pliku SVG i umożliwia kontrolowanie, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/) gdy eksportowane SVG musi być kompaktowe, przewidywalne we wszystkich przeglądarkach lub gotowe do interaktywnego użycia.

## **Eksport slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [Slide.writeAsSvg](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/writeassvg/). Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

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

Nazwa pliku używa [Slide.getSlideNumber](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/getslidenumber/) zamiast indeksu pętli. Możesz również wyeksportować pojedynczy kształt za pomocą [Shape.writeAsSvg](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setuseframesize/) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) określa, czy obrót ramki jest stosowany. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) na `true`, gdy tekst musi być renderowany bez ligatur.

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

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Dzięki temu eliminowane są zależności od czcionek i rezultat wizualny jest bardziej spójny we wszystkich przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwołać się do osobnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencje czcionek przed ich osadzeniem.

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

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setpicturescompression/), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setjpegquality/), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

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

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Przekaż kontroler formatowania do [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/), aby ustawić [SvgShape.setId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgshape/setid/) dla każdego kształtu SVG. Kontroler, który dodatkowo obsługuje fragmenty tekstu, może ustawiać wartości [SvgTSpan.setId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgtspan/setid/) na elementach `tspan` tekstu.

Poniższy kontroler używa [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstu. Dzięki temu wygenerowane identyfikatory są odpowiednie do przetwarzania po zakończeniu niezmienionej prezentacji.

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

## **Dodawanie obsługi zdarzeń SVG**

W kontrolerze formatowania wywołaj [SvgShape.setEventHandler](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgshape/seteventhandler/) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

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

Strona hostująca może zdefiniować funkcję JavaScript odwołującą się do obsługi. Przypisywanie identyfikatorów i obsługi zdarzeń umożliwia przeglądarkom slajdów, udoskonalenia dostępności oraz inne interaktywne przepływy pracy z SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/setvectorizetext/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgexternalfontshandling/), gdy tylko tekst używający czcionek zewnętrznych powinien być konwertowany na grafikę.

**Jaki jest najlepszy sposób na zmniejszenie rozmiaru SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów i wybrania powiązanych plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG oraz wektoryzowany tekst mają różne kompromisy dotyczące jakości i rozmiaru.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz pasujące elementy SVG w swoim narzędziu do przetwarzania po zakończeniu lub w skrypcie przeglądarki.