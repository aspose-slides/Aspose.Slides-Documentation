---
title: Z zarządzaniem obiektami atramentu w prezentacji w Pythonie przy użyciu Java
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/python-java/manage-ink/
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
- Java
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla Pythona przez Java."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, która pozwala rysować odręczne pociągnięcia. Atrament można wykorzystać do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.

Aspose.Slides dostarcza typy potrzebne do pracy z obiektami atramentu. Na przykład klasa [Ink](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszej formie kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Więcej informacji znajdziesz w sekcji [Shape Layout Format](/slides/pl/python-java/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) oprócz jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe metody [Shape.getWidth](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getWidth) i [Shape.getHeight](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem służącym do rejestrowania trajektorii pióra, gdy użytkownik zapisuje cyfrowy atrament. Ślad przechowuje sekwencję połączonych punktów.

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, tworzą obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel służy do rysowania linii łączących punkty śladu atramentu. Pędzel ma własny kolor i rozmiar, reprezentowane przez metody [InkBrush.getColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkbrush/#getColor) oraz [InkBrush.getSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkbrush/#getSize).

### **Ustaw kolor pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić kolor pędzla atramentu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod w Pythonie pokazuje, jak ustawić rozmiar pędzla atramentu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest wyszarzona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przyjrzyjmy się ważnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (rama) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

W związku z tym, aby określić widoczny obszar całego obiektu atramentu, należy wziąć pod uwagę rozmiar pędzla jego śladów. Tutaj docelowy obiekt (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramy). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia klasę [InkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/), która pozwala kontrolować, jak obiekty atramentu wyglądają w wyjściu eksportowanym lub renderowanym. Możesz używać jej właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Ink options are available through the export or rendering options for several output types:

| Output | Ink options property |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Metody klasy [InkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/) ujawniają te same dwa ustawienia:

- [getHideInk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#getHideInk) określa, czy obiekty atramentu są uwzględniane w wyjściu. Wartość domyślna to `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) określa, czy operacja maski jest interpretowana jako nieprzezroczystość podczas renderowania pędzla atramentu. Wartość domyślna to `True`; wywołaj [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) z `False`, aby użyć operacji ROP.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Aby uzyskać czyste wyjście bez odręcznych adnotacji lub innych treści atramentu, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#setHideInk) z `True`.

Poniższy przykład w Pythonie eksportuje prezentację do PDF, ukrywając wszystkie obiekty atramentu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ukryj obiekty atramentu podczas renderowania slajdu jako obrazu**

Aby ukryć obiekty atramentu podczas renderowania slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/#getInkOptions) i przekaż opcje renderowania do [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage).

Poniższy przykład w Pythonie renderuje pierwszy slajd jako obraz PNG bez obiektów atramentu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Kontrola renderowania maski atramentu**

Ustawienie [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) kontroluje, jak operacje maski są interpretowane podczas renderowania pędzli atramentu. Wartość domyślna to `True`, co oznacza użycie nieprzezroczystości. Aby zamiast tego użyć operacji ROP, wywołaj [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) z `False`.

Poniższy przykład w Pythonie eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

To samo ustawienie można zastosować za pomocą [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/tiffoptions/#getInkOptions) podczas eksportu prezentacji lub renderowania slajdu do TIFF.

### **Wybierz, czy ukrywać, czy zachować atrament**

Gdy potrzebujesz czystej wersji oznaczonej prezentacji do dystrybucji bez znaczników recenzji, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#setHideInk) z `True` podczas eksportu.

Pozostaw [InkOptions.getHideInk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#getHideInk) z wartością domyślną `False`, gdy adnotacje atramentu są częścią zamierzonej treści, np. komentarze recenzji, odręczne notatki, podświetlenia lub rysunki, które powinny pozostać widoczne w wyjściu eksportu. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnej z tej samej prezentacji bez modyfikacji źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia atramentu?**

Tak. Pobierz ślad za pomocą [Ink.getTraces](https://reference.aspose.com/slides/pl/python-java/aspose.slides/ink/#getTraces), a następnie zmień jego [InkTrace.getBrush](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inktrace/#getBrush). Wywołaj [InkBrush.setColor](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkbrush/#setColor) lub [InkBrush.setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkbrush/#setSize), aby zmienić pędzel.

**Czy ukrycie atramentu zmienia źródłową prezentację?**

Nie. Wywołanie [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/python-java/aspose.slides/inkoptions/#setHideInk) wpływa tylko na wynik renderowany lub eksportowany; nie usuwa ani nie modyfikuje obiektów atramentu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla formatów PDF, HTML, SVG, TIFF oraz obrazów slajdów w formacie bitmapowym, korzystając z odpowiednich opcji eksportu lub renderowania pokazanych powyżej.

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach ogólnie, zobacz sekcję [PowerPoint Shapes](/slides/pl/python-java/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](/slides/pl/python-java/shape-effective-properties/#get-effective-font-height-value).
* Szczegóły eksportu PDF znajdziesz w [Convert PPT and PPTX to PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/).
* Szczegóły eksportu HTML znajdziesz w [Convert PowerPoint Presentations to HTML](/slides/pl/python-java/convert-powerpoint-to-html/).
* Szczegóły eksportu SVG znajdziesz w [Render Presentation Slides as SVG Images](/slides/pl/python-java/render-a-slide-as-an-svg-image/).
* Szczegóły eksportu TIFF znajdziesz w [Convert PowerPoint Presentations to TIFF](/slides/pl/python-java/convert-powerpoint-to-tiff/).
* Szczegóły renderowania slajdów do obrazów znajdziesz w [Convert Presentation Slides to Images](/slides/pl/python-java/convert-slide/).