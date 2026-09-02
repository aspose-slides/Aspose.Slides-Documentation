---
title: Renderowanie slajdów prezentacji jako obrazy SVG w .NET
linktitle: Slajd do SVG
type: docs
weight: 50
url: /pl/net/render-a-slide-as-an-svg-image/
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
- .NET
- C#
- Aspose.Slides
description: "Eksportuj slajdy PowerPoint jako obrazy SVG w .NET i kontroluj czcionki, tekst, obrazy, identyfikatory oraz zdarzenia przy użyciu Aspose.Slides."
---
## **Przegląd**

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikacji internetowej, przeglądarkach slajdów, przepływach pracy dostępności oraz automatycznym przetwarzaniu końcowym. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i umożliwia kontrolowanie, w jaki sposób zapisywany jest tekst, czcionki, obrazy i elementy SVG.  

Użyj [SVGOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportowanie slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd prezentacji jako osobny plik SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Nazwa pliku używa [ISlide.SlideNumber](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/slidenumber/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt przy pomocy [IShape.WriteAsSvg](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/writeassvg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfiguracja wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/) kontroluje renderowanie SVG. Dla ramek tekstu, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/useframesize/) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/useframerotation/) określa, czy zastosować obrót ramki. Ustaw [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/disablefontligatures/) na `true`, gdy tekst musi być renderowany bez ligatur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    DisableFontLigatures = true,
    UseFrameSize = true,
    UseFrameRotation = false
};

using var svgStream = File.Create("slide-with-custom-options.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Kontrola tekstu i czcionek**

### **Wektoryzacja całego tekstu**

Ustaw [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/vectorizetext/) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że efekt wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już wybieralny ani przeszukiwalny jako tekst SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    VectorizeText = true
};

using var svgStream = File.Create("slide-with-vectorized-text.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

### **Wybór sposobu obsługi czcionek zewnętrznych**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/externalfontshandling/) używa wartości [SvgExternalFontsHandling](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwoływać się do osobnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować tylko tekst używający czcionek zewnętrznych jako grafikę. Zweryfikuj licencje czcionek przed ich osadzeniem.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var linkedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.AddLinksToFontFiles
};

using var linkedFontsStream = File.Create("slide-with-font-links.svg");
presentation.Slides[0].WriteAsSvg(linkedFontsStream, linkedFontsOptions);

var embeddedFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Embed
};

using var embeddedFontsStream = File.Create("slide-with-embedded-fonts.svg");
presentation.Slides[0].WriteAsSvg(embeddedFontsStream, embeddedFontsOptions);

var vectorizedExternalFontsOptions = new SVGOptions
{
    ExternalFontsHandling = SvgExternalFontsHandling.Vectorize
};

using var vectorizedExternalFontsStream = File.Create("slide-with-vectorized-external-fonts.svg");
presentation.Slides[0].WriteAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
```

## **Zmniejsz rozmiar osadzonych obrazów**

Użyj [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/picturescompression/), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/), aby pominąć przycięte obszary źródłowe, oraz [SVGOptions.JpegQuality](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/jpegquality/), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem jakości obrazu lub zachowanych danych obrazu.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    PicturesCompression = PicturesCompression.Dpi150,
    DeletePicturesCroppedAreas = true,
    JpegQuality = 80
};

using var svgStream = File.Create("compressed-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
```

## **Przypisywanie stabilnych identyfikatorów do kształtów i tekstu**

Użyj [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshapeformattingcontroller/), aby ustawić [ISvgShape.Id](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshape/id/) dla każdego kształtu SVG. Aby także ustawić wartości [ISvgTSpan.Id](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgtspan/id/) na elementach tekstowych `tspan`, zaimplementuj [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Przypisz dowolny kontroler za pomocą [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).

Poniższy kontroler używa [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/officeinteropshapeid/), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego fragmentów tekstowych. Dzięki temu wygenerowane identyfikatory są odpowiednie do przetwarzania po eksportie niezmienionej prezentacji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new StableSvgIdController()
};

using var svgStream = File.Create("slide-with-stable-ids.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class StableSvgIdController : ISvgShapeAndTextFormattingController
{
    private string currentShapeId = string.Empty;
    private int textSpanIndex;

    public ISvgShapeFormattingController AsISvgShapeFormattingController => this;

    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        currentShapeId = $"shape-{shape.OfficeInteropShapeId}";
        textSpanIndex = 0;
        svgShape.Id = currentShapeId;
    }

    public void FormatText(ISvgTSpan svgTSpan, IPortion portion, ITextFrame textFrame)
    {
        svgTSpan.Id = $"{currentShapeId}-text-{textSpanIndex++}";
    }
}
```

## **Dodawanie obsługi zdarzeń SVG**

W [ISvgShapeFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshapeformattingcontroller/) wywołaj [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/pl/net/aspose.slides.export/isvgshape/seteventhandler/) z wartością [SvgEvent](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var svgOptions = new SVGOptions
{
    ShapeFormattingController = new SvgEventController()
};

using var svgStream = File.Create("interactive-slide.svg");
presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);

class SvgEventController : ISvgShapeFormattingController
{
    public void FormatShape(ISvgShape svgShape, IShape shape)
    {
        if (shape.Name == "ActionButton")
        {
            svgShape.Id = "action-button";
            svgShape.SetEventHandler(SvgEvent.OnClick, "handleShapeClick(event)");
        }
    }
}
```

Strona hostująca może zdefiniować funkcję JavaScript odwoływaną przez obsługę zdarzenia. Przypisywanie identyfikatorów i obsługiwaczy zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności oraz inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/vectorizetext/) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgexternalfontshandling/)?**

Użyj [SVGOptions.VectorizeText](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/vectorizetext/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgexternalfontshandling/), gdy tylko tekst używający czcionek zewnętrznych powinien być skonwertowany na grafikę.

**Jaki jest najlepszy sposób, aby zmniejszyć rozmiar SVG?**

Zacznij od kompresji osadzonych obrazów, usunięcia przyciętych obszarów obrazów oraz wyboru linkowanych plików czcionek, gdy środowisko docelowe może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**

Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz pasujące elementy SVG w narzędziu do przetwarzania po wyeksportowaniu lub w skrypcie przeglądarki.