---
title: Zarządzaj obiektami atramentu w prezentacji na Androidzie
linktitle: Zarządzaj atramentem
type: docs
weight: 95
url: /pl/androidjava/manage-ink/
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj obiektami atramentu w PowerPoint, edytuj ślady i właściwości pędzla oraz kontroluj wygląd atramentu podczas eksportu PDF, HTML, SVG, TIFF i obrazów przy użyciu Aspose.Slides dla Androida."
---
## **Wprowadzenie**

PowerPoint zapewnia funkcję atramentu, która pozwala rysować dowolne pociągnięcia. Atrament może być używany do podświetlania innych obiektów, pokazywania połączeń i procesów oraz zwracania uwagi na określone elementy na slajdzie.

Aspose.Slides udostępnia typy potrzebne do pracy z obiektami atramentu. Na przykład interfejs [IInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iink/) reprezentuje obiekt atramentu na slajdzie.

## **Różnice między zwykłymi obiektami a obiektami atramentu**

Obiekty na slajdzie PowerPoint są zazwyczaj reprezentowane przez obiekty kształtu. W najprostszym ujęciu kształt jest kontenerem definiującym obszar samego obiektu (jego ramkę) wraz z właściwościami takimi jak rozmiar kontenera, kształt i tło. Aby uzyskać więcej informacji, zobacz [Format układu kształtu](https://docs.aspose.com/slides/pl/androidjava/shape-manipulations/#access-layout-formats-for-shape).

Jednak gdy PowerPoint obsługuje obiekt atramentu, ignoruje wszystkie właściwości ramki obiektu (kontenera) oprócz jego rozmiaru. Rozmiar obszaru kontenera jest określany przez standardowe metody [IShape.getWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getWidth--) i [IShape.getHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Ślady atramentu**

Ślad atramentu jest podstawowym elementem używanym do rejestrowania trajektorii pióra, gdy użytkownik pisze cyfrowym atramentem. Ślad przechowuje sekwencję połączonych punktów.

Najprostsza forma kodowania określa współrzędne X i Y każdego punktu próbki. Gdy wszystkie połączone punkty zostaną wyrenderowane, powstaje obraz podobny do tego:

![ink_powerpoint2](ink_powerpoint2.png)

## **Właściwości pędzla do rysowania**

Pędzel jest używany do rysowania linii łączących punkty śladu atramentu. Pędzel ma własny kolor i rozmiar, reprezentowane przez metody [IInkBrush.getColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkbrush/#getColor--) i [IInkBrush.getSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Ustaw kolor pędzla atramentu**

Ten kod w języku Java pokazuje, jak ustawić kolor pędzla atramentu:

```java
import android.graphics.Color;
import com.aspose.slides.*;

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
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Z reguły szerokość i wysokość pędzla nie są równe, więc PowerPoint nie wyświetla rozmiaru pędzla (odpowiednia sekcja danych jest przygaszona). Gdy szerokość i wysokość pędzla są równe, PowerPoint wyświetla jego rozmiar w ten sposób:

![ink_powerpoint3](ink_powerpoint3.png)

Dla jasności zwiększmy wysokość obiektu atramentu i przeanalizujmy ważne wymiary:

![ink_powerpoint4](ink_powerpoint4.png)

Kontener (ramka) nie uwzględnia rozmiaru pędzli — zawsze zakłada, że grubość linii wynosi zero (zobacz poprzedni obraz).

Dlatego, aby określić widoczny obszar całego obiektu atramentu, należy uwzględnić rozmiar pędzla jego śladów. Tutaj docelowy obiekt (ślad ręcznego tekstu) został przeskalowany do rozmiaru kontenera (ramki). Gdy rozmiar kontenera się zmienia, rozmiar pędzla pozostaje stały i odwrotnie.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint stosuje podobne zachowanie dla obiektów tekstowych:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrola wyglądu atramentu podczas eksportu i renderowania**

Aspose.Slides udostępnia interfejs [IInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/) służący do kontrolowania, jak obiekty atramentu wyglądają w wyjściu eksportowanym lub renderowanym. Możesz używać jego właściwości, aby całkowicie ukryć atrament lub zmienić sposób interpretacji operacji maski pędzla atramentu.

Opcje atramentu są dostępne poprzez opcje eksportu lub renderowania dla kilku typów wyjścia:

| Wyjście | Właściwość opcji atramentu |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Poniższe metody [IInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/) udostępniają te same dwa ustawienia:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) określa, czy obiekty atramentu są uwzględniane w wyjściu. Domyślna wartość to `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) określa, czy operacja maski jest interpretowana jako nieprzezroczystość podczas renderowania pędzla atramentu. Domyślna wartość to `true`; wywołaj [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`, aby zamiast tego użyć operacji ROP.

### **Ukryj obiekty atramentu w wyjściu PDF**

Domyślnie obiekty atramentu pozostają widoczne podczas eksportu. Aby uzyskać czyste wyjście bez ręcznych adnotacji lub innej zawartości atramentu, wywołaj [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) z wartością `true`.

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

### **Ukryj obiekty atramentu podczas renderowania slajdu jako obrazu**

Aby ukryć obiekty atramentu podczas renderowania slajdów jako obrazy bitmapowe, skonfiguruj [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) i przekaż opcje renderowania do [ISlide.getImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

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

### **Kontroluj renderowanie maski atramentu**

Ustawienie [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) kontroluje, jak operacje maski są interpretowane przy renderowaniu pędzli atramentu. Domyślna wartość to `true`, co używa nieprzezroczystości. Aby zamiast tego użyć operacji ROP, wywołaj [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) z wartością `false`.

Poniższy przykład w języku Java eksportuje slajd do SVG i używa renderowania opartego na ROP dla operacji maski atramentu:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

To samo ustawienie można zastosować poprzez [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) przy eksportowaniu prezentacji lub renderowaniu slajdu do TIFF.

### **Wybierz, czy ukryć, czy zachować atrament**

Gdy potrzebujesz czystej wersji oznaczonej prezentacji do dystrybucji bez znaczników recenzji, wywołaj [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) z wartością `true` podczas eksportu.

Pozostaw [IInkOptions.getHideInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) na domyślnej wartości `false`, gdy adnotacje atramentowe są częścią zamierzonej treści, takiej jak komentarze recenzji, ręczne notatki, podświetlenia lub rysunki, które powinny pozostać widoczne w wyjściu eksportowanym. Umożliwia to aplikacjom generowanie oddzielnych wersji recenzji i finalnych z tej samej prezentacji bez modyfikowania źródłowych obiektów atramentu.

## **FAQ**

**Czy mogę zmienić kolor lub rozmiar istniejącego pociągnięcia atramentu?**

Tak. Pobierz ślad przy użyciu [IInk.getTraces](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iink/#getTraces--), następnie zmień jego [IInkTrace.getBrush](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinktrace/#getBrush--). Wywołaj [IInkBrush.setColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) lub [IInkBrush.setSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-), aby zmienić pędzel.

**Czy ukrywanie atramentu zmienia źródłową prezentację?**

Nie. Wywołanie [IInkOptions.setHideInk](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) wpływa tylko na wynik renderowany lub eksportowany; nie usuwa ani nie modyfikuje obiektów atramentu w źródłowej prezentacji.

**Które formaty eksportu obsługują opcje atramentu?**

Możesz konfigurować opcje atramentu dla PDF, HTML, SVG, TIFF oraz obrazów bitmapowych slajdów poprzez odpowiednie opcje eksportu lub renderowania pokazane powyżej.

**Dalsza lektura**

* Aby przeczytać o kształtach w ogóle, zobacz sekcję [Kształty PowerPoint](https://docs.aspose.com/slides/pl/androidjava/powerpoint-shapes/).
* Aby uzyskać więcej informacji o wartościach efektywnych, zobacz [Właściwości efektywne kształtu](https://docs.aspose.com/slides/pl/androidjava/shape-effective-properties/#get-effective-font-height-value).
* Aby dowiedzieć się więcej o eksporcie PDF, zobacz [Konwertuj PPT i PPTX do PDF](https://docs.aspose.com/slides/pl/androidjava/convert-powerpoint-to-pdf/).
* Aby dowiedzieć się więcej o eksporcie HTML, zobacz [Konwertuj prezentacje PowerPoint do HTML](https://docs.aspose.com/slides/pl/androidjava/convert-powerpoint-to-html/).
* Aby dowiedzieć się więcej o eksporcie SVG, zobacz [Renderuj slajdy prezentacji jako obrazy SVG](https://docs.aspose.com/slides/pl/androidjava/render-a-slide-as-an-svg-image/).
* Aby dowiedzieć się więcej o eksporcie TIFF, zobacz [Konwertuj prezentacje PowerPoint do TIFF](https://docs.aspose.com/slides/pl/androidjava/convert-powerpoint-to-tiff/).
* Aby dowiedzieć się więcej o renderowaniu slajdów na obrazy, zobacz [Konwertuj slajdy prezentacji na obrazy](https://docs.aspose.com/slides/pl/androidjava/convert-slide/).