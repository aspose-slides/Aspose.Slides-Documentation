---
title: Eksport wykresów prezentacji na Androidzie
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/androidjava/export-chart/
keywords:
- wykres
- wykres do obrazu
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy prezentacji przy użyciu Aspose.Slides for Android via Java, obsługując formaty PPT i PPTX oraz usprawniając raportowanie w dowolnym procesie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia eksport wykresu z prezentacji jako obrazu. Ten artykuł pokazuje, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizacje wykresu poza prezentacją PowerPoint.

Oprócz podstawowego procesu eksportu obrazu, artykuł omawia także typowe pytania związane z eksportem, w tym zapisywanie zawartości wykresu w formacie SVG, kontrolowanie rozmiaru wyjścia za pomocą opcji renderowania, ładowanie czcionek w celu zachowania wyglądu etykiet i legendy oraz zachowanie pierwotnego formatowania prezentacji, takiego jak motywy, style, wypełnienia i efekty podczas renderowania.

## **Pobierz obraz wykresu**
Aspose.Slides for Android via Java zapewnia wsparcie dla wyodrębniania obrazu konkretnego wykresu. Poniżej podano przykładowy kod. 

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

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG używając [metody zapisu kształtu do SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**Jak mogę ustawić dokładny rozmiar wyeksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które pozwalają określić rozmiar lub skalę — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, jeśli czcionki w etykietach i legendzie wyglądają nieprawidłowo po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/androidjava/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport zachowuje temat, style i efekty PowerPointa?**

Tak. Renderer Aspose.Slides respektuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), więc wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz [API](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/)/[dokumentację](/slides/pl/androidjava/convert-powerpoint/) dotyczącą celów wyjściowych ([PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pl/androidjava/convert-powerpoint-to-html/), itp.) oraz powiązanych opcji renderowania.