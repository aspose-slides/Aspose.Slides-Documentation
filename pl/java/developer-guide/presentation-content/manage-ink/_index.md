---
title: Zarządzanie obiektami atramentu w prezentacji w Java
linktitle: Zarządzanie atramentem
type: docs
weight: 95
url: /pl/java/manage-ink/
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
- Java
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu do PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla Java."
---
## **Wprowadzenie**

PowerPoint udostępnia funkcję atramentu, która pozwala rysować dowolne pociągnięcia. Atrament można wykorzystać do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na konkretne elementy na slajdzie.

Aspose.Slides dostarcza typy potrzebne do pracy z obiektami atramentu. Na przykład interfejs [IInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPointa są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszym wydaniu kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) oraz właściwości takie jak rozmiar kontenera, kształt i tło. Aby uzyskać więcej informacji, zobacz [Format układu kształtu](https://docs.aspose.com/slides/pl/java/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) oprócz jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe metody [IShape.getWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ishape/#getWidth--) i [IShape.getHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem służącym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślad przechowuje sekwencję połączonych punktów.

Najprostszą formą kodowania jest określenie współrzędnych X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obrazek podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel służy do rysowania linii łączących punkty śladu atramentu. Pędzel posiada własny kolor i rozmiar, które są reprezentowane przez metody [IInkBrush.getColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkbrush/#getColor--) i [IInkBrush.getSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkbrush/#getSize--) .

### **Ustaw kolor pędzla atramentu**

Ten kod w języku Java pokazuje, jak ustawić kolor pędzla atramentu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Ustaw rozmiar pędzla atramentu**

Ten kod w języku Java pokazuje, jak ustawić rozmiar pędzla atramentu:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Zazwyczaj szerokość i wysokość pędzla nie są równe, dlatego PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest przyciemniona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla przejrzystości zwiększmy wysokość obiektu atramentu i przyjrzyjmy się istotnym wymiarom:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Zatem, aby określić widoczny obszar całego obiektu atramentu, należy wziąć pod uwagę rozmiar pędzla jego śladów. W tym przypadku docelowy obiekt (ślad odręcznego tekstu) został skalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia interfejs [IInkOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/) , który umożliwia kontrolowanie wyglądu obiektów atramentu w wyjściu eksportowanym lub renderowanym. Możesz używać jego właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Opcje atramentu są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjścia:

| Wyjście | Właściwość opcji atramentu |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/pl/java/com.aspose.slides.pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/pl/java/com.aspose.slides.htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/pl/java/com.aspose.slides.svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/pl/java/com.aspose.slides.tiffoptions/#getInkOptions--) |
| Slide image | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/pl/java/com.aspose.slides.renderingoptions/#getInkOptions--) |

Poniższe metody [IInkOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/) udostępniają te same dwa ustawienia:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#getHideInk--) określa, czy obiekty atramentu są uwzględniane w wyniku. Domyślna wartość to `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#getInterpretMaskOpAsOpacity--) określa, czy operacja maski jest interpretowana jako przezroczystość podczas renderowania pędzla atramentu. Domyślna wartość to `true`; wywołaj [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`, aby zamiast tego użyć operacji ROP.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Aby uzyskać czysty wynik bez odręcznych adnotacji lub innej treści atramentowej, wywołaj [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) z wartością `true`.

Poniższy przykład w języku Java eksportuje prezentację do PDF, ukrywając wszystkie obiekty atramentu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ukryj obiekty atramentu przy renderowaniu slajdu jako obrazu**

Aby ukryć obiekty atramentu przy renderowaniu slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides.renderingoptions/#getInkOptions--) i przekaż opcje renderowania do [ISlide.getImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides.islide/#getImage-com.aspose.slides.IRenderingOptions-).

Poniższy przykład w języku Java renderuje pierwszy slajd jako obraz PNG bez obiektów atramentu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Kontrola renderowania maski atramentu**

Ustawienie [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#getInterpretMaskOpAsOpacity--) kontroluje, jak operacje maski są interpretowane przy renderowaniu pędzli atramentu. Domyślna wartość to `true`, co oznacza użycie przezroczystości. Aby zamiast tego użyć operacji ROP, wywołaj [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`.

Poniższy przykład w języku Java eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

To samo ustawienie można zastosować poprzez [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/java/com.aspose.slides.tiffoptions/#getInkOptions--) przy eksporcie prezentacji lub renderowaniu slajdu do TIFF.

### **Wybierz, czy ukrywać czy zachowywać atrament**

Gdy potrzebujesz czystej wersji oznaczonej prezentacji do dystrybucji bez znaczników recenzji, wywołaj [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) z wartością `true` podczas eksportu.

Pozostaw [IInkOptions.getHideInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#getHideInk--) przy domyślnej wartości `false`, gdy adnotacje atramentowe są częścią zamierzonej treści, np. komentarze recenzenckie, odręczne notatki, podkreślenia lub rysunki, które powinny pozostać widoczne w wyeksportowanym wyniku. Umożliwia to aplikacjom generowanie osobnych wersji recenzji i finalnej z tej samej prezentacji bez modyfikowania źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia atramentowego?**

Tak. Pobierz ślad z [IInk.getTraces](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iink/#getTraces--) , a następnie zmień jego [IInkTrace.getBrush](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinktrace/#getBrush--). Wywołaj [IInkBrush.setColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkbrush/#setColor-java.awt.Color-) lub [IInkBrush.setSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkbrush/#setSize-java.awt.geom.Dimension2D-) , aby zmienić pędzel.

**Czy ukrywanie atramentu zmienia źródłową prezentację?**

Nie. Wywołanie [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) wpływa wyłącznie na wynik renderowania lub eksportu; nie usuwa ani nie modyfikuje obiektów atramentu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla PDF, HTML, SVG, TIFF oraz bitmapowych obrazów slajdów poprzez odpowiednie opcje eksportu lub renderowania przedstawione powyżej.

**Dalsza lektura**

* Aby poznać kształty ogólnie, zobacz sekcję [PowerPoint Shapes](https://docs.aspose.com/slides/pl/java/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Shape Effective Properties](https://docs.aspose.com/slides/pl/java/shape-effective-properties/#get-effective-font-height-value).
* Szczegóły eksportu do PDF znajdziesz w [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pl/java/convert-powerpoint-to-pdf/).
* Szczegóły eksportu do HTML znajdziesz w [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pl/java/convert-powerpoint-to-html/).
* Szczegóły eksportu do SVG znajdziesz w [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pl/java/render-a-slide-as-an-svg-image/).
* Szczegóły eksportu do TIFF znajdziesz w [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pl/java/convert-powerpoint-to-tiff/).
* Szczegóły renderowania slajdu na obraz znajdziesz w [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pl/java/convert-slide/).