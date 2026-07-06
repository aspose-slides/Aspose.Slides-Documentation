---
title: Pobierz granice fragmentu tekstu z prezentacji w JavaScript
linktitle: Granice fragmentu
type: docs
weight: 47
url: /pl/nodejs-java/portion-bounds/
keywords:
- granice fragmentu tekstu
- fragment tekstu
- część tekstu
- współrzędne tekstu
- pozycja tekstu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice fragmentów tekstu w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Node.js za pośrednictwem Javy."
---
## **Przegląd**

Fragment tekstu reprezentuje określony fragment tekstu wewnątrz akapitu i pozwala pracować z tym fragmentem niezależnie od otaczającej treści. W Aspose.Slides fragmenty można używać, gdy trzeba pobrać granice fragmentu tekstu, zastosować formatowanie tylko do części akapitu lub kontrolować zachowanie tekstu na bardziej szczegółowym poziomie.

Ten artykuł pokazuje, jak uzyskać prostokąt ograniczający fragment za pomocą [Portion.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getrect/). Pokazuje również, jak uzyskać współrzędne początku fragmentu za pomocą [Portion.getCoordinates](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getcoordinates/). Ponadto podkreśla typowe scenariusze związane z fragmentami, takie jak zastosowanie hiperłącza do pojedynczego fragmentu tekstu, zrozumienie, jak formatowanie jest rozwiązywane poprzez dziedziczenie w poziomie fragmentu, akapitu, ramki tekstowej i motywu oraz obsługę przypadków, gdy podana czcionka jest niedostępna.

## **Uzyskaj granice fragmentu tekstu**

Użyj [Portion.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getrect/) aby pobrać prostokąt ograniczający fragment tekstu:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Uzyskaj współrzędne fragmentu tekstu**

Użyj [Portion.getCoordinates](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getcoordinates/) aby pobrać współrzędne początku fragmentu tekstu:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy mogę zastosować hiperłącze tylko do części tekstu w jednym akapicie?**

Tak, możesz [przypisać hiperłącze](/slides/pl/nodejs-java/manage-hyperlinks/) do pojedynczego fragmentu; tylko ten fragment będzie klikalny, nie cały akapit.

**Jak działa dziedziczenie stylów: co fragment nadpisuje, a co jest pobierane z akapitu lub ramki tekstowej?**

Właściwości na poziomie fragmentu mają najwyższy priorytet. Jeśli właściwość nie jest ustawiona w [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/), Aspose.Slides pobiera ją z [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/). Jeśli nie jest ustawiona tam również, Aspose.Slides używa stylu [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) lub [theme](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/theme/).

**Co się stanie, jeśli czcionka określona dla fragmentu jest nieobecna na docelowym komputerze lub serwerze?**

[Zasady podstawiania czcionek](/slides/pl/nodejs-java/font-selection-sequence/) mają zastosowanie. Tekst może ulec przetworzeniu: metryki, dzielenie wyrazów i szerokość mogą się zmienić, co ma znaczenie przy precyzyjnym pozycjonowaniu.

**Czy mogę ustawić przeźroczystość wypełnienia tekstu lub gradient specyficzny dla fragmentu niezależnie od reszty akapitu?**

Tak, kolor tekstu, wypełnienie i przeźroczystość na poziomie [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) mogą różnić się od sąsiednich fragmentów.