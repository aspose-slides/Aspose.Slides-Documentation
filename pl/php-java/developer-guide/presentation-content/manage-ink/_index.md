---
title: Zarządzanie obiektami atramentu w prezentacji w PHP
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/php-java/manage-ink/
keywords:
- atrament
- obiekt atramentu
- ślad atramentu
- zarządzanie atramentem
- rysowanie atramentu
- rysowanie
- eksport atramentu
- renderowanie atramentu
- ukrywanie atramentu
- InkOptions
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla PHP poprzez Java."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, która umożliwia rysowanie dowolnych pociągnięć. Atrament można używać do podświetlania innych obiektów, pokazywania połączeń i procesów oraz przyciągania uwagi do konkretnych elementów na slajdzie.

Aspose.Slides dostarcza typy potrzebne do pracy z obiektami atramentu. Na przykład klasa [Ink](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/). W najprostszej formie kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Po więcej informacji zobacz [Shape Layout Format](https://docs.aspose.com/slides/pl/php-java/shape-manipulations/#access-layout-formats-for-shape).

Jednakże, gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) poza jego rozmiarem. Rozmiar obszaru kontenera jest określany przez standardowe metody [Shape.getWidth](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getWidth) i [Shape.getHeight](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem służącym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślad przechowuje sekwencję połączonych punktów.

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel jest używany do rysowania linii łączących punkty śladu atramentu. Pędzel ma własny kolor i rozmiar, reprezentowane przez metody [InkBrush.getColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkbrush/#getColor) oraz [InkBrush.getSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkbrush/#getSize).

### **Ustaw kolor pędzla atramentu**

Ten kod PHP pokazuje, jak ustawić kolor pędzla atramentu:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod PHP pokazuje, jak ustawić rozmiar pędzla atramentu:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

Zazwyczaj szerokość i wysokość pędzla nie są takie same, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest wyszarzona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przeanalizujmy istotne wymiary:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu atramentu, należy uwzględnić rozmiar pędzla jego śladów. Tutaj docelowy obiekt (ślad ręcznie pisanego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrolowanie wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia klasę [InkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/), która pozwala kontrolować, jak obiekty atramentu pojawiają się w wyjściu eksportowanym lub renderowanym. Można używać jej właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Ink options są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjścia:

| Wyjście | Właściwość opcji atramentu |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Poniższe metody klasy [InkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/) udostępniają te same dwa ustawienia:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#getHideInk) określa, czy obiekty atramentu są włączane do wyjścia. Domyślna wartość to `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) określa, czy operacja maski jest interpretowana jako przezroczystość podczas renderowania pędzla atramentu. Domyślna wartość to `true`; wywołaj [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) z `false`, aby użyć operacji ROP.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Aby uzyskać czyste wyjście bez odręcznych adnotacji lub innej treści atramentu, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#setHideInk) z `true`.

Ten przykład PHP eksportuje prezentację do PDF, ukrywając wszystkie obiekty atramentu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ukryj obiekty atramentu podczas renderowania slajdu jako obrazu**

Aby ukryć obiekty atramentu podczas renderowania slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/renderingoptions/#getInkOptions) i przekaż opcje renderowania do [Slide.getImage](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slide/#getImage).

Ten przykład PHP renderuje pierwszy slajd jako obraz PNG bez obiektów atramentu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Kontroluj renderowanie maski atramentu**

Ustawienie [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) kontroluje, jak operacje maski są interpretowane podczas renderowania pędzli atramentu. Domyślna wartość to `true`, co oznacza użycie przezroczystości. Aby zamiast tego użyć operacji ROP, wywołaj [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) z `false`.

Ten przykład PHP eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

To samo ustawienie można zastosować za pomocą [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/php-java/aspose.slides/tiffoptions/#getInkOptions) przy eksporcie prezentacji lub renderowaniu slajdu do TIFF.

### **Wybierz, czy ukrywać czy zachować atrament**

Gdy potrzebujesz czystej wersji oznaczonej prezentacji do dystrybucji bez znaczników recenzji, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#setHideInk) z `true` podczas eksportu.

Pozostaw [InkOptions.getHideInk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#getHideInk) przy domyślnej wartości `false`, gdy adnotacje atramentowe są częścią zamierzonej treści, np. komentarze recenzji, odręczne notatki, podświetlenia lub rysunki, które powinny pozostać widoczne w wyeksportowanym wyniku. Umożliwia to aplikacjom generowanie osobnych wyjść recenzji i finalnych z tej samej prezentacji bez modyfikacji źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia atramentu?**

Tak. Pobierz ślad za pomocą [Ink.getTraces](https://reference.aspose.com/slides/pl/php-java/aspose.slides/ink/#getTraces), a następnie zmień jego [InkTrace.getBrush](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inktrace/#getBrush). Wywołaj [InkBrush.setColor](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkbrush/#setColor) lub [InkBrush.setSize](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkbrush/#setSize), aby zmienić pędzel.

**Czy ukrywanie atramentu zmienia prezentację źródłową?**

Nie. Wywołanie [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/php-java/aspose.slides/inkoptions/#setHideInk) wpływa tylko na wyrenderowany lub wyeksportowany wynik; nie usuwa ani nie modyfikuje obiektów atramentu w prezentacji źródłowej.

**Które formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla PDF, HTML, SVG, TIFF oraz obrazów slajdów w formacie bitmapowym za pomocą odpowiednich opcji eksportu lub renderowania przedstawionych powyżej.

**Dalsza lektura**

* Aby dowiedzieć się więcej o kształtach, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/php-java/powerpoint-shapes/).
* Po więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/php-java/shape-effective-properties/#get-effective-font-height-value).
* Szczegóły eksportu PDF znajdziesz w [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pl/php-java/convert-powerpoint-to-pdf/).
* Szczegóły eksportu HTML znajdują się w [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pl/php-java/convert-powerpoint-to-html/).
* Szczegóły eksportu SVG znajdziesz w [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pl/php-java/render-a-slide-as-an-svg-image/).
* Szczegóły eksportu TIFF znajdziesz w [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pl/php-java/convert-powerpoint-to-tiff/).
* Szczegóły renderowania slajdów na obrazy znajdziesz w [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pl/php-java/convert-slide/).