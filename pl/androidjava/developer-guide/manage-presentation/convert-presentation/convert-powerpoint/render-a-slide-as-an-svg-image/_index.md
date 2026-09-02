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
description: "Eksportuj slajdy PowerPoint jako obrazy SVG na Androidzie i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia przy pomocy Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu po zakończeniu. Aspose.Slides for Android via Java eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, jak zapisywany jest tekst, czcionki, obrazy i elementy SVG.  
Użyj [SVGOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportuj slajd jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia za pomocą [ISlide.writeAsSvg](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#writeAsSvg-java.io.OutputStream-). Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

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

Nazwa pliku używa [ISlide.getSlideNumber](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getSlideNumber--) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy użyciu [IShape.writeAsSvg](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Skonfiguruj wyjście SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/) steruje renderowaniem SVG. Dla ramek tekstowych, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setUseFrameSize-boolean-) włącza ramkę tekstową w obszar renderowania, a [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setUseFrameRotation-boolean-) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setDisableFontLigatures-boolean-) na `true`, gdy tekst ma być renderowany bez ligatur.

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

## **Kontroluj tekst i czcionki**

### **Wektoryzuj cały tekst**

Ustaw [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. To eliminuje zależności od czcionek i sprawia, że wynik wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

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

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setExternalFontsHandling-int-) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz [SvgExternalFontsHandling.AddLinksToFontFiles](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/), aby odwoływać się do oddzielnych plików czcionek, [SvgExternalFontsHandling.Embed](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/), aby dołączyć dane czcionki do SVG, lub [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/), aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencje czcionek przed ich osadzeniem.

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

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setPicturesCompression-int-), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setDeletePicturesCroppedAreas-boolean-), aby pominąć przycięte fragmenty źródłowe, oraz [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setJpegQuality-int-), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

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

## **Przypisz stabilne identyfikatory do kształtów i tekstu**

Użyj [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshapeformattingcontroller/), aby ustawić [ISvgShape.setId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshape/#setId-java.lang.String-) dla każdego kształtu SVG. Aby również ustawić wartości [ISvgTSpan.setId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgtspan/#setId-java.lang.String-) w elementach tekstowych `tspan`, zaimplementuj [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshapeandtextformattingcontroller/). Przypisz dowolny kontroler przy użyciu [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-).  
Poniższy kontroler używa [IShape.getOfficeInteropShapeId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--), który jest stabilny przez cały czas życia kształtu, oraz powtarzalnego licznika dla jego segmentów tekstowych. Dzięki temu wygenerowane identyfikatory są odpowiednie do przetwarzania po zakończeniu niezmienionej prezentacji.

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

## **Dodaj obsługę zdarzeń SVG**

W [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshapeformattingcontroller/) wywołaj [ISvgShape.setEventHandler](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgshape/#setEventHandler-int-java.lang.String-) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler przy użyciu [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setShapeFormattingController-com.aspose.slides.ISvgShapeFormattingController-) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

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

Strona hostująca może zdefiniować funkcję JavaScript odwoływaną przez obsługę. Przypisywanie identyfikatorów i obsługi zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności oraz inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/)?**  
Użyj [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#setVectorizeText-boolean-), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgexternalfontshandling/), gdy tylko tekst używający czcionek zewnętrznych powinien być przekształcony w grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**  
Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów i wyboru linkowanych plików czcionek, gdy docelowe środowisko może je udostępniać. Przetestuj rezultat, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po ich wyeksportowaniu?**  
Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz pasujące elementy SVG w narzędziu do przetwarzania po eksporcie lub w skrypcie przeglądarki.