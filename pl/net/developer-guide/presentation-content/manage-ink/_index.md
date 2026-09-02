---
title: Zarządzanie obiektami atramentu w prezentacji w .NET
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/net/manage-ink/
keywords:
- atrament
- obiekt atramentu
- ślad atramentu
- zarządzaj atramentem
- rysuj atrament
- rysowanie
- eksport atramentu
- renderowanie atramentu
- ukryj atrament
- IInkOptions
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla .NET."
---
## **Wstęp**

PowerPoint udostępnia funkcję atramentu, która pozwala rysować dowolne kreski. Atrament może być używany do podświetlania innych obiektów, pokazywania połączeń i procesów oraz przyciągania uwagi do konkretnych elementów na slajdzie.

Przestrzeń nazw [Aspose.Slides.Ink](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/) zawiera klasy i interfejsy potrzebne do pracy z obiektami atramentu. Na przykład interfejs [IInk](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszej formie kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Więcej informacji znajdziesz w [Shape Layout Format](https://docs.aspose.com/slides/pl/net/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) poza jego rozmiarem. Rozmiar obszaru kontenera określany jest przez standardowe właściwości [IShape.Width](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/width/) i [IShape.Height](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem służącym do rejestrowania trajektorii pióra podczas pisania cyfrowego atramentu. Ślad przechowuje sekwencję połączonych punktów.

Najprostszą formą kodowania jest określenie współrzędnych X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel jest używany do rysowania linii łączących punkty śladu atramentu. Pędzel ma własny kolor i rozmiar, reprezentowane przez właściwości [IInkBrush.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iinkbrush/color/) i [IInkBrush.Size](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iinkbrush/size/).

### **Ustaw kolor pędzla atramentu**

Ten kod C# pokazuje, jak ustawić kolor pędzla atramentu:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Color = Color.Red;
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod C# pokazuje, jak ustawić rozmiar pędzla atramentu:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Ink;

using var presentation = new Presentation("pres.pptx");
var ink = (IInk)presentation.Slides[0].Shapes[0];
var brush = ink.Traces[0].Brush;
brush.Size = new SizeF(5f, 10f);
```

Z reguły szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest przygaszona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przeanalizujmy ważne wymiary:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu atramentu, należy wziąć pod uwagę rozmiar pędzla jego śladów. Tutaj obiekt docelowy (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia interfejs [IInkOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/), który pozwala kontrolować, jak obiekty atramentu pojawiają się w wyjściu eksportu lub renderingu. Możesz używać jego właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Opcje atramentu są dostępne poprzez opcje eksportu lub renderingu dla kilku typów wyjścia:

| Wyjście | Właściwość opcji atramentu |
| --- | --- |
| PDF | [`PdfOptions.InkOptions`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/pdfoptions/inkoptions/) |
| HTML | [`HtmlOptions.InkOptions`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/htmloptions/inkoptions/) |
| SVG | [`SVGOptions.InkOptions`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/svgoptions/inkoptions/) |
| TIFF | [`TiffOptions.InkOptions`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/inkoptions/) |
| Slide image | [`RenderingOptions.InkOptions`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/inkoptions/) |

Te same dwa ustawienia są dostępne poprzez wymienione właściwości:

- [`HideInk`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/hideink/) określa, czy obiekty atramentu są uwzględniane w wyjściu. Domyślna wartość to `false`.
- [`InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) określa, czy operacja maski jest interpretowana jako krycie przy renderowaniu pędzla atramentu. Domyślna wartość to `true`; ustaw `false`, aby zamiast tego użyć operacji ROP.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Ustaw [IInkOptions.HideInk](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/hideink/) na `true`, gdy potrzebny jest czysty wynik bez odręcznych adnotacji lub innej zawartości atramentu.

Poniższy przykład C# eksportuje prezentację do PDF, ukrywając wszystkie obiekty atramentu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var pdfOptions = new PdfOptions();
pdfOptions.InkOptions.HideInk = true;

presentation.Save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Ukryj obiekty atramentu podczas renderowania slajdu jako obrazu**

Aby ukryć obiekty atramentu przy renderowaniu slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.InkOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/renderingoptions/inkoptions/) i przekaż opcje renderingu do metody [ISlide.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/).

Poniższy przykład C# renderuje pierwszy slajd jako obraz PNG bez obiektów atramentu:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var renderingOptions = new RenderingOptions();
renderingOptions.InkOptions.HideInk = true;

using var image = presentation.Slides[0].GetImage(renderingOptions);
image.Save("slide_without_ink.png", ImageFormat.Png);
```

### **Kontroluj renderowanie maski atramentu**

Właść `[IInkOptions.InterpretMaskOpAsOpacity`](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/interpretmaskopasopacity/) kontroluje, jak operacje maski są interpretowane przy renderowaniu pędzli atramentu. Domyślna wartość to `true`, co oznacza użycie krycia. Ustaw właściwość na `false`, aby zamiast tego użyć operacji ROP.

Poniższy przykład C# eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```c#
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var svgOptions = new SVGOptions();
svgOptions.InkOptions.InterpretMaskOpAsOpacity = false;

using var stream = File.Create("slide.svg");
presentation.Slides[0].WriteAsSvg(stream, svgOptions);
```

To samo ustawienie można zastosować poprzez [TiffOptions.InkOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/tiffoptions/inkoptions/) przy eksportowaniu prezentacji lub renderowaniu slajdu do formatu TIFF.

### **Wybierz, czy ukrywać czy zachować atrament**

Użyj [IInkOptions.HideInk](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/hideink/) ustawionego na `true`, gdy wyeksportowany plik ma być czystą wersją prezentacji z adnotacjami, na przykład ostateczną kopią przeznaczoną do dystrybucji bez znaczników recenzji.

Pozostaw [IInkOptions.HideInk](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/hideink/) przy domyślnej wartości `false`, gdy adnotacje atramentowe są częścią zamierzonej treści, takiej jak komentarze recenzji, odręczne notatki, podświetlenia lub rysunki, które powinny pozostać widoczne w wyniku eksportu. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnych z tej samej prezentacji bez modyfikowania źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego odcinka atramentu?**

Tak. Pobierz ślad z [IInk.Traces](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iink/traces/), a następnie zmień jego [IInkTrace.Brush](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iinktrace/brush/). Możesz ustawić właściwości [IInkBrush.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iinkbrush/color/) i [IInkBrush.Size](https://reference.aspose.com/slides/pl/net/aspose.slides.ink/iinkbrush/size/).

**Czy ukrywanie atramentu zmienia źródłową prezentację?**

Nie. [IInkOptions.HideInk](https://reference.aspose.com/slides/pl/net/aspose.slides.export/iinkoptions/hideink/) wpływa wyłącznie na wynik renderingu lub eksportu; nie usuwa ani nie modyfikuje obiektów atramentu w źródłowej prezentacji.

**Jakie formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla PDF, HTML, SVG, TIFF oraz obrazów slajdów w formacie bitmapowym poprzez odpowiednie opcje eksportu lub renderingu przedstawione powyżej.

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/net/powerpoint-shapes/).
* Aby uzyskać informacje o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/net/shape-effective-properties/#get-effective-font-height-value).
* Aby poznać szczegóły eksportu do PDF, zobacz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pl/net/convert-powerpoint-to-pdf/).
* Aby poznać szczegóły eksportu do HTML, zobacz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pl/net/convert-powerpoint-to-html/).
* Aby poznać szczegóły eksportu do SVG, zobacz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pl/net/render-a-slide-as-an-svg-image/).
* Aby poznać szczegóły eksportu do TIFF, zobacz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pl/net/convert-powerpoint-to-tiff/).
* Aby poznać szczegóły renderowania slajdów na obrazy, zobacz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pl/net/convert-slide/).