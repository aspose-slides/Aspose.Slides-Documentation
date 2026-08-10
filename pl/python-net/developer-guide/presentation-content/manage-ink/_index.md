---
title: Zarządzanie obiektami atramentu w prezentacji w Pythonie
linktitle: Zarządzanie atramentem
type: docs
weight: 95
url: /pl/python-net/manage-ink/
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
- InkOptions
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Wstęp**

PowerPoint udostępnia funkcję atramentu, która pozwala rysować dowolne odcinki. Atrament może być używany do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.

Przestrzeń nazw [aspose.slides.ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/) zawiera klasy potrzebne do pracy z obiektami atramentu. Na przykład klasa [Ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/ink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszej formie kształt jest kontenerem, który definiuje obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Więcej informacji znajdziesz w [Format układu kształtu](https://docs.aspose.com/slides/pl/python-net/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) oprócz jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe właściwości [Ink.width](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/ink/width/) i [Ink.height](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem służącym do rejestrowania trajektorii pióra, gdy użytkownik zapisuje cyfrowy atrament. Ślad przechowuje sekwencję połączonych punktów.

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Po wyrenderowaniu wszystkich połączonych punktów tworzą one obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel jest używany do rysowania linii łączących punkty śladu atramentu. Jego właściwości [InkBrush.color](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/inkbrush/color/) i [InkBrush.size](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/inkbrush/size/) kontrolują kolor i rozmiar.

### **Ustaw kolor pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić kolor pędzla atramentu:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić rozmiar pędzla atramentu:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Z reguły szerokość i wysokość pędzla nie są zgodne, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest przygaszona). Gdy szerokość i wysokość pędzla są zgodne, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przyjrzyjmy się ważnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli – zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu atramentu, należy wziąć pod uwagę rozmiar pędzla jego śladów. W tym miejscu obiekt docelowy (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia klasę [InkOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/), aby kontrolować, jak obiekty atramentu pojawiają się w wyjściu eksportowanym lub renderowanym. Możesz używać jej właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Opcje atramentu są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjść:

| Wyjście | Właściwość opcji atramentu |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Te same dwa ustawienia są dostępne poprzez te właściwości:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/hide_ink/) określa, czy obiekty atramentu są uwzględniane w wyjściu. Domyślna wartość to `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) określa, czy operacja maski jest interpretowana jako nieprzezroczystość podczas renderowania pędzla atramentu. Domyślna wartość to `True`; ustaw `False`, aby używać operacji ROP zamiast tego.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Ustaw [InkOptions.hide_ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/hide_ink/) na `True`, gdy potrzebujesz czystego wyjścia bez odręcznych adnotacji lub innej zawartości atramentu.

Poniższy przykład w Pythonie eksportuje prezentację do formatu PDF, ukrywając wszystkie obiekty atramentu:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ukryj obiekty atramentu przy renderowaniu slajdu jako obrazu**

Aby ukryć obiekty atramentu przy renderowaniu slajdów jako obrazów bitmapowych, skonfiguruj [RenderingOptions.ink_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/ink_options/) i przekaż opcje renderowania do metody [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/).

Poniższy przykład w Pythonie renderuje pierwszy slajd jako obraz PNG bez obiektów atramentu:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Kontrola renderowania maski atramentu**

Właściwość [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) kontroluje, jak operacje maski są interpretowane podczas renderowania pędzli atramentu. Domyślna wartość to `True`, co oznacza użycie nieprzezroczystości. Ustaw właściwość na `False`, aby używać operacji ROP zamiast tego.

Poniższy przykład w Pythonie eksportuje slajd do formatu SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

To samo ustawienie można zastosować poprzez [TiffOptions.ink_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/tiffoptions/ink_options/) przy eksportowaniu prezentacji lub renderowaniu slajdu do formatu TIFF.

### **Wybierz, czy ukrywać, czy zachować atrament**

Ustaw [InkOptions.hide_ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/hide_ink/) na `True`, gdy wyeksportowany plik ma być czystą wersją adnotowanej prezentacji, na przykład ostateczną kopią przeznaczoną do dystrybucji bez znaczników recenzji.

Pozostaw [InkOptions.hide_ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/hide_ink/) przy domyślnej wartości `False`, gdy adnotacje atramentu są częścią zamierzonej treści, takiej jak komentarze recenzji, odręczne notatki, podświetlenia lub rysunki, które mają pozostać widoczne w wyniku eksportu. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnych z tej samej prezentacji bez modyfikowania źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego odcinka atramentu?**

Tak. Pobierz ślad z [Ink.traces](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/ink/traces/), a następnie zmień jego [InkTrace.brush](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/inktrace/brush/). Możesz ustawić właściwości [InkBrush.color](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/inkbrush/color/) i [InkBrush.size](https://reference.aspose.com/slides/pl/python-net/aspose.slides.ink/inkbrush/size/).

**Czy ukrywanie atramentu zmienia źródłową prezentację?**

Nie. [InkOptions.hide_ink](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/inkoptions/hide_ink/) wpływa tylko na wynik renderowania lub eksportu; nie usuwa ani nie modyfikuje obiektów atramentu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla PDF, HTML, SVG, TIFF oraz obrazów slajdów bitmapowych poprzez odpowiednie opcje eksportu lub renderowania wymienione powyżej.

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach ogólnie, zobacz sekcję [Kształty PowerPoint]([https://docs.aspose.com/slides/pl/python-net/powerpoint-shapes/]).
* Więcej informacji o wartościach efektywnych znajdziesz w [Właściwości efektywne kształtu]([https://docs.aspose.com/slides/pl/python-net/shape-effective-properties/#get-effective-font-height-value]).
* Szczegóły dotyczące eksportu do PDF znajdziesz w [Konwertuj PPT i PPTX do PDF]([https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-pdf/]).
* Szczegóły dotyczące eksportu do HTML znajdziesz w [Konwertuj prezentacje PowerPoint do HTML]([https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-html/]).
* Szczegóły dotyczące eksportu do SVG znajdziesz w [Renderuj slajdy prezentacji jako obrazy SVG]([https://docs.aspose.com/slides/pl/python-net/render-a-slide-as-an-svg-image/]).
* Szczegóły dotyczące eksportu do TIFF znajdziesz w [Konwertuj prezentacje PowerPoint do TIFF]([https://docs.aspose.com/slides/pl/python-net/convert-powerpoint-to-tiff/]).
* Szczegóły dotyczące renderowania slajdu jako obrazu znajdziesz w [Konwertuj slajdy prezentacji na obrazy]([https://docs.aspose.com/slides/pl/python-net/convert-slide/]).