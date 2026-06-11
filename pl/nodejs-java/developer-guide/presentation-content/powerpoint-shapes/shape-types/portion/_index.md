---
title: Zarządzanie fragmentami tekstu w prezentacjach przy użyciu JavaScript
linktitle: Fragment tekstu
type: docs
weight: 70
url: /pl/nodejs-java/portion/
keywords:
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak zarządzać fragmentami tekstu w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js poprzez Java, zwiększając wydajność i możliwości dostosowania."
---
## **Przegląd**

Fragment tekstu reprezentuje konkretny fragment tekstu wewnątrz akapitu i umożliwia pracę z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można wykorzystać, gdy potrzebujesz pobrać pozycję fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać współrzędne początku fragmentu przy użyciu metody `getCoordinates()`. Przedstawia także typowe scenariusze związane z fragmentami, takie jak stosowanie hiperlinku do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane przez fragment, akapit, ramkę tekstową i dziedziczenie motywu, oraz obsługę sytuacji, gdy określona czcionka jest niedostępna. Dodatkowo zauważa, że wypełnienie tekstu, kolor i przezroczystość mogą być ustawione inaczej dla poszczególnych fragmentów w tym samym akapicie.

## **Uzyskanie współrzędnych pozycji fragmentu**
[**getCoordinates()**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion#getCoordinates--) metoda została dodana do klasy [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) , co umożliwia pobranie współrzędnych początku fragmentu.

```javascript
// Utwórz klasę Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Modyfikowanie kontekstu prezentacji
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę zastosować hiperlink tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperlink](/slides/pl/nodejs-java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, a nie cały akapit.

**Jak działa dziedziczenie stylów: co nadpisuje fragment, a co jest pobierane z akapitu/ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/), silnik pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/); jeśli nie jest ustawiona tam również, z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) lub stylu [theme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowym komputerze/serwerze?**

Obowiązują [zasady podstawiania czcionek](/slides/pl/nodejs-java/font-selection-sequence/). Tekst może ulec przemieszczeniu: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przezroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu, niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przezroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.