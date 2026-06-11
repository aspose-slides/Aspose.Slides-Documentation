---
title: Eksport wykresów prezentacji w JavaScript
linktitle: Eksport wykresu
type: docs
weight: 90
url: /pl/nodejs-java/export-chart/
keywords:
- wykres
- wykres do obrazu
- wykres jako obraz
- wyodrębnij obraz wykresu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak eksportować wykresy prezentacji przy użyciu Aspose.Slides dla Node.js poprzez Java, obsługując formaty PPT i PPTX, oraz usprawnić raportowanie w dowolnym przepływie pracy."
---
## **Przegląd**

Aspose.Slides umożliwia wyeksportowanie wykresu z prezentacji jako obrazu. W tym artykule pokazano, jak uzyskać obraz wykresu i zapisać go, co jest przydatne, gdy trzeba ponownie wykorzystać wizualizacje wykresu poza prezentacją PowerPoint.

## **Uzyskaj obraz wykresu**
Aspose.Slides dla Node.js za pośrednictwem Java zapewnia obsługę wyodrębniania obrazu konkretnego wykresu. Poniżej podano przykładowy kod.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę wyeksportować wykres jako wektor (SVG) zamiast obrazu rastrowego?**

Tak. Wykres jest kształtem, a jego zawartość można zapisać jako SVG przy użyciu [metody zapisu shape-to-SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/).

**Jak mogę ustawić dokładny rozmiar wyeksportowanego wykresu w pikselach?**

Użyj przeciążeń renderowania obrazu, które pozwalają określić rozmiar lub skalę — biblioteka obsługuje renderowanie obiektów o podanych wymiarach/skali.

**Co zrobić, jeśli czcionki w etykietach i legendzie wyglądają niepoprawnie po eksporcie?**

[Załaduj wymagane czcionki](/slides/pl/nodejs-java/custom-font/) za pomocą [FontsLoader](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/), aby renderowanie wykresu zachowało metryki i wygląd tekstu.

**Czy eksport respektuje motyw, style i efekty PowerPointa?**

Tak. Renderer Aspose.Slides stosuje formatowanie prezentacji (motywy, style, wypełnienia, efekty), więc wygląd wykresu jest zachowany.

**Gdzie mogę znaleźć dostępne możliwości renderowania/eksportu poza obrazami wykresów?**

Zobacz [API](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/)/[dokumentację](/slides/pl/nodejs-java/convert-powerpoint/) dotyczącą celów wyjściowych ([PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/pl/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pl/nodejs-java/convert-powerpoint-to-html/), itp.) oraz powiązane opcje renderowania.