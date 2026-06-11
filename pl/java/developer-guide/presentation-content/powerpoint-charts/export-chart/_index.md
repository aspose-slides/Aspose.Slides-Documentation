---
title: Eksport wykresów prezentacji w Javie
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/java/export-chart/
keywords:
- wykres
- wykres na obraz
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy z prezentacji przy użyciu Aspose.Slides dla Javy, obsługując formaty PPT i PPTX, oraz usprawnić raportowanie w dowolnym procesie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia eksportowanie wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz z wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie użyć wizualizacji wykresu poza prezentacją PowerPoint.

Oprócz podstawowego procesu eksportu obrazu, artykuł porusza również typowe pytania związane z eksportem, w tym zapisywanie treści wykresu jako SVG, kontrolowanie rozmiaru wyjścia za pomocą opcji renderowania, ładowanie czcionek w celu zachowania wyglądu etykiet i legendy oraz utrzymanie oryginalnego formatowania prezentacji, takiego jak motywy, style, wypełnienia i efekty podczas renderowania.

## **Uzyskaj obraz wykresu**
Aspose.Slides for Java zapewnia wsparcie dla wyodrębniania obrazu konkretnego wykresu. Poniżej podany jest przykładowy kod.

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisywania shape-to-SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Jak mogę ustawić dokładny rozmiar wyeksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które umożliwiają określenie rozmiaru lub skali — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, jeśli czcionki w etykietach i legendzie wyglądają nieprawidłowo po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/java/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport zachowuje motyw PowerPoint, style i efekty?**

Tak. Renderer Aspose.Slides respektuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), więc wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz [API](https://reference.aspose.com/slides/pl/java/com.aspose.slides/)/[dokumentację](/slides/pl/java/convert-powerpoint/) dotyczącą celów wyjściowych ([PDF](/slides/pl/java/convert-powerpoint-to-pdf/), [SVG](/slides/pl/java/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/java/convert-powerpoint-to-xps/), [HTML](/slides/pl/java/convert-powerpoint-to-html/), itp.) oraz powiązane opcje renderowania.