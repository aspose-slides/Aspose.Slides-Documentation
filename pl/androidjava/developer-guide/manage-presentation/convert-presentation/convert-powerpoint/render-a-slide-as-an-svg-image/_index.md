---
title: Renderowanie slajdów prezentacji jako obrazy SVG na Androidzie
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/androidjava/render-a-slide-as-an-svg-image/
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
- Android
- Java
- Aspose.Slides
description: Eksportuj slajdy PowerPoint jako obrazy SVG na Androidzie i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia za pomocą Aspose.Slides.
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikowaniu w sieci, przeglądarkach slajdów, przepływach pracy dostępności i automatycznym przetwarzaniu poeksportowym. Aspose.Slides for Android via Java eksportuje każdy slajd do oddzielnego pliku SVG i umożliwia kontrolowanie, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.

Użyj [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportowanie slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Poniższy przykład eksportuje każdy slajd w prezentacji jako oddzielny plik SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        String outputFileName = String.format("slide-%d.svg", slide.getSlideNumber());

        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            slide.writeAsSvg(svgStream);
        }
    }
} finally {
    presentation.dispose();
}
```

Nazwa pliku używa [ISlide.getSlideNumber](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getSlideNumber--) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt za pomocą [IShape.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) , gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) określa, czy rotacja ramki jest stosowana. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, gdy tekst musi być renderowany bez ligatur.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-custom-options.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kontrola tekstu i czcionek**

Podczas eksportowania slajdów do SVG możesz kontrolować, czy tekst pozostaje jako tekst, czy jest konwertowany na grafikę wektorową, oraz w jaki sposób zewnętrzne czcionki są włączane lub odwoływane. Poniższe opcje pomagają zrównoważyć spójność wizualną, możliwość zaznaczania tekstu i zależności od czcionek w wyeksportowanym SVG.

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. To eliminuje zależności od czcionek i sprawia, że wynik wizualny jest bardziej spójny w przeglądarkach, ale tekst nie jest już wybieralny ani przeszukiwalny jako tekst SVG.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setVectorizeText(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-vectorized-text.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

### **Wybierz sposób obsługi zewnętrznych czcionek**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), aby odwoływać się do oddzielnych plików czcionek, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), aby dołączyć dane czcionki do SVG, lub [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/), aby renderować tylko tekst używający zewnętrznych czcionek jako grafikę. Zweryfikuj licencje czcionek przed ich osadzaniem.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    SVGOptions linkedFontsOptions = new SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.AddLinksToFontFiles);
    try (FileOutputStream linkedFontsStream = new FileOutputStream("slide-with-font-links.svg")) {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    }

    SVGOptions embeddedFontsOptions = new SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Embed);
    try (FileOutputStream embeddedFontsStream = new FileOutputStream("slide-with-embedded-fonts.svg")) {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    }

    SVGOptions vectorizedExternalFontsOptions = new SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(SvgExternalFontsHandling.Vectorize);
    try (FileOutputStream vectorizedExternalFontsStream = new FileOutputStream("slide-with-vectorized-external-fonts.svg")) {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Zredukuj rozmiar osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) , aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-) , aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) , aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setPicturesCompression(PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("compressed-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Kontrola rozdzielczości rasteryzacji metafili**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setMetafileRasterizationDpi-int-) ustawia dolny limit rozdzielczości przy rasteryzacji metafili podczas eksportu SVG. Użyj go, aby zrównoważyć szczegóły i rozmiar pliku, gdy obraz EMF lub WMF jest rasteryzowany. Nie definiuje on globalnego DPI dla SVG ani nie zmusza każdego obiektu na slajdzie do przekształcenia w obraz rastrowy.

Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z blisko rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje jego pierwszy slajd w trzech rozdzielczościach rasteryzacji przy użyciu [ISlide.writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-). Wszystkie pozostałe ustawienia eksportu pozostają identyczne, aby wyniki można było porównać.

```java
import com.aspose.slides.PicturesCompression;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("metafile-rasterization.pptx");
try {
    for (int dpi : new int[] { 72, 150, 300 }) {
        SVGOptions svgOptions = new SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        String outputFileName = String.format("slide-%d.svg", dpi);
        try (FileOutputStream svgStream = new FileOutputStream(outputFileName)) {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        }
    }
} finally {
    presentation.dispose();
}
```

W wyniku EMF został zamieniony na jeden osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie są ogólną formułą przeliczania DPI na wymiary pikseli.

| Rasteryzacja metafili DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy takiej samej powiększonej wielkości wyświetlania. Linijki ukośne wykazują widoczną pikselizację przy 72 DPI i gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy rozmiar pliku SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy szczegół ani nie zmienia każdego wyeksportowanego obrazu.

![Zwiększony szczegół linii ukośnych przy 72, 150 i 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-) kontroluje redukcję rozdzielczości obrazu i może maskować efekt zmiany rozdzielczości rasteryzacji metafili. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-) kontroluje jakość kodowania JPEG, a nie rozdzielczość rasteryzacji metafili.

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Użyj [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) , aby ustawić [ISvgShape.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) dla każdego kształtu SVG. Aby także ustawić wartości [ISvgTSpan.setId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) na elementach tekstowych `tspan`, zaimplementuj [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Przypisz dowolny z kontrolerów za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).

Poniższy kontroler używa [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) , który jest stabilny przez cały czas istnienia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstowych. Dzięki temu wygenerowane identyfikatory są odpowiednie do post-processingu niezmienionej prezentacji.

```java
class StableSvgIdController implements ISvgShapeAndTextFormattingController {
    private String currentShapeId = "";
    private int textSpanIndex;

    public void formatShape(ISvgShape svgShape, IShape shape) {
        currentShapeId = String.format("shape-%d", shape.getOfficeInteropShapeId());
        textSpanIndex = 0;
        svgShape.setId(currentShapeId);
    }

    public void formatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame) {
        svgTSpan.setId(String.format("%s-text-%d", currentShapeId, textSpanIndex++));
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new StableSvgIdController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("slide-with-stable-ids.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

## **Dodawanie obsługi zdarzeń SVG**

W [ISvgShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) wywołaj [ISvgShape.setEventHandler](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) z wartością [SvgEvent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgevent/) , aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

```java
class SvgEventController implements ISvgShapeFormattingController {
    public void formatShape(ISvgShape svgShape, IShape shape) {
        if ("ActionButton".equals(shape.getName())) {
            svgShape.setId("action-button");
            svgShape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.setShapeFormattingController(new SvgEventController());

    ISlide slide = presentation.getSlides().get_Item(0);
    try (FileOutputStream svgStream = new FileOutputStream("interactive-slide.svg")) {
        slide.writeAsSvg(svgStream, svgOptions);
    }
} finally {
    presentation.dispose();
}
```

Strona hostująca może zdefiniować funkcję JavaScript odwołującą się do obsługi. Przypisywanie identyfikatorów i obsługi zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności i inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/)?**

Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) , gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgexternalfontshandling/) , gdy tylko tekst używający zewnętrznych czcionek powinien być konwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów i wyboru powiązanych plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy jakości i rozmiaru.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz odpowiadające elementy SVG w swoim narzędziu do post-processingu lub skrypcie przeglądarki.