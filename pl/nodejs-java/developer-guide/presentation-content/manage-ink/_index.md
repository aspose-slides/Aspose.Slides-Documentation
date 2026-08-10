---
title: Zarządzanie obiektami tuszu w prezentacji w JavaScript
linktitle: Zarządzanie tuszem
type: docs
weight: 95
url: /pl/nodejs-java/manage-ink/
keywords:
- tusz
- obiekt tuszu
- ślad tuszu
- zarządzanie tuszem
- rysowanie tuszu
- rysowanie
- eksport tuszu
- renderowanie tuszu
- ukrywanie tuszu
- InkOptions
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zarządzaj obiektami tuszu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd tuszu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla Node.js w języku JavaScript."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję tuszu, która pozwala rysować dowolne pociągnięcia. Tusz może być używany do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.

Aspose.Slides udostępnia typy potrzebne do pracy z obiektami tuszu. Na przykład klasa [Ink](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ink/) reprezentuje obiekt tuszu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami tuszu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszym wydaniu kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Więcej informacji znajdziesz w sekcji [Shape Layout Format](https://docs.aspose.com/slides/pl/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt tuszu, ignoruje wszystkie właściwości ramki obiektu (kontenera) z wyjątkiem jego rozmiaru. Rozmiar obszaru kontenera jest określany przy użyciu standardowych metod [Shape.getWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getWidth--) i [Shape.getHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady tuszu**

Ślad tuszu jest podstawowym elementem służącym do zapisywania trajektorii pióra podczas pisania cyfrowego tuszu. Ślad przechowuje sekwencję połączonych punktów.

Najprostszą formą kodowania jest określenie współrzędnych X i Y każdego punktu próbki. Po wyrenderowaniu wszystkich połączonych punktów powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel służy do rysowania linii łączących punkty śladu tuszu. Pędzel ma własny kolor i rozmiar, reprezentowane przez metody [InkBrush.getColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkbrush/#getColor--) i [InkBrush.getSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Ustawienie koloru pędzla tuszu**

Ten kod JavaScript pokazuje, jak ustawić kolor pędzla tuszu:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Ustawienie rozmiaru pędzla tuszu**

Ten kod JavaScript pokazuje, jak ustawić rozmiar pędzla tuszu:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, dlatego PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest wyszarzona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w następujący sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu tuszu i przyjrzyjmy się istotnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu tuszu, należy wziąć pod uwagę rozmiar pędzla jego śladów. Tutaj docelowy obiekt (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrolowanie wyglądu tuszu podczas eksportu i renderowania**

Aspose.Slides udostępnia klasę [InkOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/), która pozwala kontrolować sposób wyświetlania obiektów tuszu w wyjściu eksportowanym lub renderowanym. Możesz używać jej właściwości, aby całkowicie ukryć tusz lub zmienić sposób interpretacji operacji maski pędzla tuszu.

Opcje tuszu są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjścia:

| Wyjście | Właściwość opcji tuszu |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Obraz slajdu | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Poniższe metody [InkOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/) udostępniają te same dwa ustawienia:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#getHideInk--) określa, czy obiekty tuszu są uwzględniane w wyjściu. Wartość domyślna to `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) określa, czy operacja maski jest interpretowana jako przezroczystość podczas renderowania pędzla tuszu. Wartość domyślna to `true`; wywołaj [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`, aby zamiast tego użyć operacji ROP.

### **Ukrywanie obiektów tuszu w wyjściu PDF**

Domyślnie obiekty tuszu pozostają widoczne podczas eksportu. Aby uzyskać czyste wyjście bez odręcznych adnotacji lub innej treści tuszu, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) z wartością `true`.

Poniższy przykład w JavaScript eksportuje prezentację do formatu PDF, ukrywając wszystkie obiekty tuszu:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ukrywanie obiektów tuszu przy renderowaniu slajdu jako obrazu**

Aby ukryć obiekty tuszu przy renderowaniu slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) i przekaż opcje renderowania do [Slide.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) .

Poniższy przykład w JavaScript renderuje pierwszy slajd jako obraz PNG bez obiektów tuszu:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kontrolowanie renderowania maski tuszu**

Ustawienie [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) steruje tym, jak operacje maski są interpretowane przy renderowaniu pędzli tuszu. Wartość domyślna to `true`, co oznacza użycie przezroczystości. Aby zamiast tego użyć operacji ROP, wywołaj [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`.

Poniższy przykład w JavaScript eksportuje slajd do formatu SVG i wykorzystuje renderowanie oparte na ROP dla operacji maski tuszu:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

To samo ustawienie można zastosować poprzez [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) przy eksporcie prezentacji lub renderowaniu slajdu do formatu TIFF.

### **Wybór, czy ukrywać, czy zachować tusz**

Kiedy potrzebujesz czystej wersji oznaczonej prezentacji do dystrybucji bez znaczników recenzji, wywołaj [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) z wartością `true` podczas eksportu.

Pozostaw [InkOptions.getHideInk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#getHideInk--) przy domyślnej wartości `false`, gdy adnotacje tuszu są częścią zamierzonej treści, np. komentarze recenzji, odręczne notatki, podświetlenia lub rysunki, które powinny pozostać widoczne w wyniku eksportu. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnych z tej samej prezentacji bez modyfikacji źródłowych obiektów tuszu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia tuszu?**

Tak. Pobierz ślad za pomocą [Ink.getTraces](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ink/#getTraces--) i następnie zmień jego [InkTrace.getBrush](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inktrace/#getBrush--). Wywołaj [InkBrush.setColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) lub [InkBrush.setSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) aby zmienić pędzel.

**Czy ukrywanie tuszu zmienia źródłową prezentację?**

Nie. Wywołanie [InkOptions.setHideInk](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) wpływa tylko na wynik renderowany lub eksportowany; nie usuwa ani nie modyfikuje obiektów tuszu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje tuszu?**

Możesz konfigurować opcje tuszu dla PDF, HTML, SVG, TIFF oraz bitmapowych obrazów slajdów poprzez odpowiednie opcje eksportu lub renderowania wymienione powyżej.

**Dalsza lektura**

* Aby przeczytać o kształtach w ogóle, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/nodejs-java/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Aby poznać szczegóły eksportu do PDF, zobacz [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pl/nodejs-java/convert-powerpoint-to-pdf/).
* Aby poznać szczegóły eksportu do HTML, zobacz [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pl/nodejs-java/convert-powerpoint-to-html/).
* Aby poznać szczegóły eksportu do SVG, zobacz [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/).
* Aby poznać szczegóły eksportu do TIFF, zobacz [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pl/nodejs-java/convert-powerpoint-to-tiff/).
* Aby poznać szczegóły renderowania slajdu na obraz, zobacz [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pl/nodejs-java/convert-slide/).