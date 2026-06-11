---
title: Zarządzanie symbolami zastępczymi prezentacji w JavaScript
linktitle: Zarządzaj symbolami zastępczymi
type: docs
weight: 10
url: /pl/nodejs-java/manage-placeholder/
keywords:
- symbol zastępczy
- symbol zastępczy tekstowy
- symbol zastępczy obrazu
- symbol zastępczy wykresu
- tekst podpowiedzi
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Bezproblemowo zarządzaj symbolami zastępczymi w Aspose.Slides dla Node.js via Java: zamieniaj tekst, dostosowuj podpowiedzi i ustawiaj przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia programowe zarządzanie symbolami zastępczymi prezentacji. Ten artykuł wyjaśnia, jak znaleźć symbole zastępcze na slajdach i zmienić ich tekst, ustawić własny tekst podpowiedzi dla układów symboli zastępczych oraz dostosować przezroczystość obrazu używanego jako tło symbolu zastępczego. Zawiera także krótkie FAQ, które wyjaśnia różnicę między podstawowymi symbolami zastępczymi a lokalnymi kształtami, opisuje, jak zmiany symboli zastępczych mogą być stosowane przez układy lub wzorce, oraz wskazuje na zarządzanie symbolami zastępczymi nagłówka i stopki.

## **Zmiana tekstu w symbolu zastępczym**

Używając [Aspose.Slides for Node.js via Java](/slides/pl/nodejs-java/), możesz znajdować i modyfikować symbole zastępcze na slajdach w prezentacjach. Aspose.Slides umożliwia wprowadzanie zmian w tekście symbolu zastępczego.

**Wymagania wstępne**: Potrzebujesz prezentacji zawierającej symbol zastępczy. Możesz taką prezentację utworzyć w standardowej aplikacji Microsoft PowerPoint.

Oto jak używać Aspose.Slides do zastąpienia tekstu w symbolu zastępczym w tej prezentacji:

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) i przekaż prezentację jako argument.
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Iteruj przez kształty, aby znaleźć symbol zastępczy.
4. Rzutuj kształt symbolu zastępczego na [`AutoShape`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame) powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape).
5. Zapisz zmodyfikowaną prezentację.

Ten kod JavaScript pokazuje, jak zmienić tekst w symbolu zastępczym:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Iteruje przez kształty, aby znaleźć symbol zastępczy
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Zmienia tekst w każdym symbolu zastępczym
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Zapisuje prezentację na dysk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawianie tekstu podpowiedzi w symbolu zastępczym**

Standardowe i wstępnie zbudowane układy zawierają teksty podpowiedzi symbolu zastępczego, takie jak ***Kliknij, aby dodać tytuł*** lub ***Kliknij, aby dodać podtytuł***. Korzystając z Aspose.Slides, możesz wstawić własne teksty podpowiedzi do układów symboli zastępczych.

Ten kod JavaScript pokazuje, jak ustawić tekst podpowiedzi w symbolu zastępczym:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Iteruje po slajdzie
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint wyświetla "Click to add title"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Dodaje podtytuł
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawianie przezroczystości obrazu w symbolu zastępczym**

Aspose.Slides umożliwia ustawienie przezroczystości obrazu tła w symbolu zastępczym tekstu. Dostosowując przezroczystość obrazu w takim ramce, możesz wyróżnić tekst lub obraz (w zależności od kolorów tekstu i obrazu).

Ten kod JavaScript pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Czym jest podstawowy symbol zastępczy i czym różni się od lokalnego kształtu na slajdzie?**

Podstawowy symbol zastępczy to oryginalny kształt znajdujący się w układzie lub masterze, z którego dziedziczy kształt slajdu — typ, pozycja i niektóre formatowania pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma podstawowego symbolu zastępczego, dziedziczenie nie ma zastosowania.

**Jak mogę zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiedni symbol zastępczy w układzie lub masterze. Slajdy oparte na tych układach / masterze automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe symbole zastępcze nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zasięgu (zwykłe slajdy, układy, master, notatki/ulotki), aby włączyć lub wyłączyć te symbole zastępcze oraz ustawić ich zawartość.