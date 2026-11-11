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

SVG jest skalowalnym formatem obrazu opartym na XML, który dobrze sprawdza się w publikowaniu w sieci, przeglądarkach slajdów, procesach dostępności oraz automatycznym przetwarzaniu. Aspose.Slides eksportuje każdy slajd do osobnego pliku SVG i pozwala kontrolować, w jaki sposób zapisywany jest tekst, czcionki, obrazy i elementy SVG.  
Użyj [SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) gdy wyeksportowany SVG musi być kompaktowy, przewidywalny w różnych przeglądarkach lub gotowy do interaktywnego użycia.

## **Eksportowanie slajdu jako SVG**

Utwórz [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), wybierz slajd i zapisz go do strumienia. Poniższy przykład eksportuje każdy slajd w prezentacji jako osobny plik SVG.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    using var svgStream = File.Create($"slide-{slide.SlideNumber}.svg");
    slide.WriteAsSvg(svgStream);
}
```

Nazwa pliku używa [ISlide.SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) zamiast indeksu pętli. Możesz także wyeksportować pojedynczy kształt za pomocą [IShape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/ishape/writeassvg/), gdy przeglądarka slajdów lub strona internetowa potrzebuje tylko tego kształtu.

## **Konfigurowanie wyjścia SVG**

[SVGOptions](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/) steruje renderowaniem SVG. Dla ramek tekstowych, [SVGOptions.UseFrameSize](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframesize/) uwzględnia ramkę tekstową w obszarze renderowania, a [SVGOptions.UseFrameRotation](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/useframerotation/) określa, czy obrót ramki jest stosowany. Ustaw [SVGOptions.DisableFontLigatures](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablefontligatures/) na `true`, gdy tekst musi być renderowany bez ligatur.

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

## **Kontrola przycinania linii przy grotach strzałek**

SVG 1.1 nie posiada ustawienia wcięcia markera określającego, gdzie linia ma się zatrzymać pod grotami strzałek. Domyślnie Aspose.Slides skraca wyeksportowaną linię, aby jej obrys nie wystawał poza marker. Ustaw [SVGOptions.DisableLineEndCropping](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/disablelineendcropping/) na `true`, aby narysować obrys aż do pierwotnego punktu końcowego linii. To ustawienie wpływa tylko na wyjście SVG. Linia zachowuje swoją pozycję i długość na slajdzie.  
Przykład rysuje trójkątne i diamentowe groty strzałek na liniach o szerokości 2 i 10 punktów. Eksportuje ten sam slajd dwukrotnie, zmieniając jedynie opcję przycinania.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var y = 40;

foreach (var style in new[] { LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond })
{
    foreach (var width in new[] { 2, 10 })
    {
        var line = slide.Shapes.AddAutoShape(ShapeType.Line, 40, y, 200, 0);
        var format = line.LineFormat;
        format.FillFormat.FillType = FillType.Solid;
        format.FillFormat.SolidFillColor.Color = Color.DarkBlue;
        format.Width = width;
        format.EndArrowheadStyle = style;
        y += 50;
    }
}

var options = new SVGOptions { DisableLineEndCropping = false };
using var cropped = File.Create("cropped.svg");
slide.WriteAsSvg(cropped, options);

options.DisableLineEndCropping = true;
using var uncropped = File.Create("uncropped.svg");
slide.WriteAsSvg(uncropped, options);
```

Porównanie pokazuje trójkątny grot na linii o szerokości 10 punktów. Przy włączonym przycinaniu końcówka jest ostra. Przy wyłączonym przycinaniu obrys wystaje poza nachylone boki markera, pozostawiając płaskie zakończenie.  
![Powiększony trójkąt 10‑punktowy z ostrą końcówką przy włączonym przycinaniu i płaskim zakończeniem przy wyłączonym przycinaniu](line-end-cropping.png)  
W pozostałych liniach z przykładu, wystający obrys jest mniej widoczny na trójkącie o szerokości 2 punktów. Wypełniony diament zakrywa koniec obrysu przy obu szerokościach.

## **Kontrola tekstu i czcionek**

Podczas eksportowania slajdów do SVG możesz kontrolować, czy tekst pozostaje tekstem czy zostaje przekształcony w grafikę wektorową, oraz jak czcionki zewnętrzne są włączane lub odwoływane. Poniższe opcje pomagają zrównoważyć spójność wizualną, możliwość zaznaczania tekstu oraz zależności od czcionek w wyeksportowanym SVG.

### **Wektorowanie całego tekstu**

Ustaw [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) na `true`, aby zapisać cały tekst slajdu jako grafikę wektorową. Eliminuje to zależności od czcionek i sprawia, że efekt wizualny jest bardziej spójny w różnych przeglądarkach, ale tekst nie jest już możliwy do zaznaczenia ani wyszukiwania jako tekst SVG.

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

### **Wybierz sposób obsługi czcionek zewnętrznych**

[SVGOptions.ExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/externalfontshandling/) wykorzystuje wartość [SvgExternalFontsHandling](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/) dla czcionek ładowanych zewnętrznie. Wybierz `AddLinksToFontFiles`, aby odwoływać się do oddzielnych plików czcionek, `Embed`, aby dołączyć dane czcionki do SVG, lub `Vectorize`, aby renderować jako grafikę tylko tekst używający czcionek zewnętrznych. Sprawdź licencję czcionki przed jej osadzeniem.

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

## **Zmniejszanie rozmiaru osadzonych obrazów**

Użyj [SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/), aby zmniejszyć rozdzielczość osadzonych obrazów, [SVGOptions.DeletePicturesCroppedAreas](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/deletepicturescroppedareas/), aby pominąć przycięte fragmenty źródłowe, oraz [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/), aby kontrolować jakość kodowania JPEG. Te ustawienia zmniejszają rozmiar pliku kosztem wierności obrazu lub zachowanych danych obrazu.

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

## **Kontrola rozdzielczości rastrowania metafili**

[SVGOptions.MetafileRasterizationDpi](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/metafilerasterizationdpi/) ustawia dolny limit rozdzielczości przy rastrowaniu metafili podczas eksportu SVG. Użyj go, aby zrównoważyć szczegółowość i rozmiar pliku, gdy obraz EMF lub WMF jest rastrowany. Nie definiuje on globalnego DPI dla SVG ani nie wymusza, aby każdy obiekt na slajdzie stał się obrazem rastrowym.  
Pobierz [metafile-rasterization.pptx](metafile-rasterization.pptx), który zawiera obraz EMF z blisko rozmieszczonymi liniami ukośnymi. Poniższy przykład eksportuje jego pierwszy slajd w trzech rozdzielczościach rastrowania za pomocą [ISlide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/islide/writeassvg/). Wszystkie pozostałe ustawienia eksportu pozostają takie same, aby wyniki można było porównać.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("metafile-rasterization.pptx");

foreach (var dpi in new[] { 72, 150, 300 })
{
    var svgOptions = new SVGOptions
    {
        MetafileRasterizationDpi = dpi,
        PicturesCompression = PicturesCompression.Dpi330,
        JpegQuality = 90
    };

    using var svgStream = File.Create($"slide-{dpi}.svg");
    presentation.Slides[0].WriteAsSvg(svgStream, svgOptions);
}
```

W wyniku EMF został zamieniony na jeden osadzony PNG w każdym pliku SVG. Poniższe pomiary dotyczą dostarczonej prezentacji; nie są one ogólną formułą przeliczania DPI na wymiary w pikselach.

| Rozdzielczość rastrowania metafili DPI | Wymiary osadzonego PNG | Rozmiar pliku SVG (bajty) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Poniższe porównanie pokazuje ten sam obszar osadzonego rastra przy tym samym powiększonym rozmiarze wyświetlania. Linie ukośne wykazują widoczną pikselację przy 72 DPI oraz gładsze krawędzie przy wyższych rozdzielczościach, podczas gdy plik SVG rośnie. Zwiększenie wartości niekoniecznie poprawia każdy szczegół ani nie zmienia każdego wyeksportowanego obrazu.  
![Powiększony szczegół linii ukośnych przy 72, 150 i 300 DPI](metafile-rasterization-comparison.png)  
[SVGOptions.PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/picturescompression/) kontroluje redukcję rozdzielczości obrazu i może maskować wpływ zmiany rozdzielczości rastrowania metafili. [SVGOptions.JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/jpegquality/) kontroluje jakość kodowania JPEG, a nie rozdzielczość rastrowania metafili.

## **Przypisywanie stałych identyfikatorów do kształtów i tekstu**

Użyj [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/), aby ustawić [ISvgShape.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/id/) dla każdego kształtu SVG. Aby również ustawić wartości [ISvgTSpan.Id](https://reference.aspose.com/slides/net/aspose.slides.export/isvgtspan/id/) w elementach `tspan` tekstu, zaimplementuj [ISvgShapeAndTextFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeandtextformattingcontroller/). Przypisz dowolny kontroler za pomocą [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/).  

Poniższy kontroler używa [IShape.OfficeInteropShapeId](https://reference.aspose.com/slides/net/aspose.slides/ishape/officeinteropshapeid/), który jest stabilny przez cały okres życia kształtu, oraz powtarzalnego licznika dla jego tekstowych spanów. Dzięki temu generowane identyfikatory są odpowiednie do przetwarzania poeksportowego niezmienionej prezentacji.

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

W [ISvgShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshapeformattingcontroller/) wywołaj [ISvgShape.SetEventHandler](https://reference.aspose.com/slides/net/aspose.slides.export/isvgshape/seteventhandler/) z wartością [SvgEvent](https://reference.aspose.com/slides/net/aspose.slides.export/svgevent/), aby dodać obsługę zdarzenia JavaScript do wyeksportowanego kształtu. Przypisz kontroler za pomocą [SVGOptions.ShapeFormattingController](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/shapeformattingcontroller/) i zdefiniuj funkcję JavaScript na stronie lub w dokumencie SVG, który hostuje wynik.

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

Strona hostująca może zdefiniować funkcję JavaScript odwołującą się do obsługi. Przypisywanie identyfikatorów i obsługi zdarzeń umożliwia przeglądarki slajdów, ulepszenia dostępności i inne interaktywne przepływy pracy SVG.

## **FAQ**

**Kiedy powinienem używać [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/) zamiast [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/)?**  
Użyj [SVGOptions.VectorizeText](https://reference.aspose.com/slides/net/aspose.slides.export/svgoptions/vectorizetext/), gdy cały tekst musi być niezależny od czcionek. Użyj [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/net/aspose.slides.export/svgexternalfontshandling/), gdy tylko tekst wykorzystujący czcionki zewnętrzne powinien być przekształcony w grafikę.

**Jaki jest najlepszy sposób na zmniejszenie rozmiaru SVG?**  
Rozpocznij od kompresji osadzonych obrazów, usunięcia przyciętych fragmentów obrazów oraz wyboru linkowanych plików czcionek, gdy środowisko docelowe może je udostępniać. Przetestuj wynik, ponieważ niższa rozdzielczość obrazu, niższa jakość JPEG i wektoryzowany tekst mają różne kompromisy między jakością a rozmiarem.

**Czy mogę modyfikować wyeksportowane elementy SVG po eksporcie?**  
Tak. Przypisz identyfikatory za pomocą kontrolera formatowania, a następnie wybierz pasujące elementy SVG w swoim narzędziu do przetwarzania poeksportowego lub w skrypcie przeglądarki.