---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu JavaScript
linktitle: Zarządzanie polem tekstowym
type: docs
weight: 20
url: /pl/nodejs-java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- aktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz, identyfikuj, formatuj i aktualizuj pola tekstowe w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js za pośrednictwem Java."
---
## **Wprowadzenie**

W Aspose.Slides dla Node.js za pośrednictwem Java tekst slajdu jest przechowywany w ramach tekstowych, które należą do kształtów. Klasa [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia go poprzez metodę [AutoShape.getTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#getTextFrame).

{{% alert color="info" title="Note" %}}
Każdy automatyczny kształt dziedziczy po klasie [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), ale nie każdy kształt jest automatycznym kształtem ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji należy sprawdzić, czy kształt jest instancją [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) przed dostępem do jego tekstu.
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj automatyczny kształt do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Współrzędne i wymiary przekazywane do [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addAutoShape) są podawane w punktach. [AutoShape.addTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#addTextFrame) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzanie, czy kształt jest polem tekstowym**

Użyj metody [AutoShape.isTextBox](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#isTextBox), aby określić, czy automatyczny kształt jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne automatyczne kształty.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład sprawdza każdy automatyczny kształt w prezentacji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 150, 10, 40, 40);

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const currentSlide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < currentSlide.getShapes().size(); shapeIndex++) {
            const shape = currentSlide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                console.log(shape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nowo dodany automatyczny kształt nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Tekst można dostarczyć poprzez [AutoShape.addTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#addTextFrame) lub [TextFrame.setText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#setText). Dodanie lub przypisanie pustego łańcucha pozostawia metodę [AutoShape.isTextBox](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#isTextBox) zwracającą `false`:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    console.log(shape1.isTextBox());

    const shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    console.log(shape2.isTextBox());

    const shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    console.log(shape3.isTextBox());

    const shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    console.log(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Pierwsze dwa wywołania wypisują `true`; ostatnie dwa wypisują `false`.

## **Znajdowanie kształtu, który jest właścicielem ramki tekstowej**

Ogólny kod przetwarzający tekst może otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) bez wiedzy, który obiekt prezentacji go zawiera. Użyj tylko do odczytu metody [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentShape), aby wrócić do jego właściciela — obiektu [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/).

Dla ramki tekstowej będącej własnością automatycznego kształtu lub innego kształtu zawierającego tekst, [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentShape) zwraca właściciela, a [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentCell) zwraca `null`. Sprawdź zwróconą wartość przed jej użyciem. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabeli, włącznie z kształtami powiązanymi z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/nodejs-java/search-and-replace-text/).

## **Dodawanie kolumn do pola tekstowego**

Metoda [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setColumnCount) dzieli ramkę tekstową na kolumny, a [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing) ustawia odstęp między kolumnami w punktach. Oba ustawienia należą do [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/) i można je zmienić poprzez ramkę tekstową istniejącego pola tekstowego. Tekst jest dzielony między kolumny wewnątrz tego samego kształtu; nie przechodzi do innego kształtu.

Poniższy przykład tworzy pole tekstowe z trzema kolumnami i odstępem 10 punktów między kolumnami, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    const textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", aspose.slides.SaveFormat.Pptx);

    const savedPresentation = new aspose.slides.Presentation("TextBoxColumns.pptx");
    try {
        const savedTextBox = savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        console.log("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie tekstu z poszczególnych kolumn**

Użyj [TextFrame.splitTextByColumns](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#splitTextByColumns), aby uzyskać tekst przypisany do każdej wizualnej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden łańcuch dla każdej kolumny, w kolejności odczytu kolumnowej. Ramka tekstowa jednopunktowa zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym łańcuchem. Łańcuchy zawierają wyłącznie zwykły tekst; formatowanie na poziomie fragmentu nie jest zachowywane.

Jest to przydatne, gdy trzeba:

- Wyodrębnić tekst zachowując kolejność odczytu opartą na kolumnach.
- Zindeksować lub porównać zawartość slajdów wielokolumnowych.
- Wyeksportować każdą kolumnę do osobnego pliku, pola bazy danych lub innego miejsca docelowego.
- Zbadać, jak tekst jest redystrybuowany po zmianie liczby kolumn za pomocą [TextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setColumnCount), odstępu za pomocą [TextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setColumnSpacing), czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozłożony w bieżącym [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/); nie powoduje automatycznego przepływu tekstu między oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, więc upewnij się, że wymagane czcionki są dostępne, gdy istotna jest spójność wyników.

Poniższy przykład ładuje prezentację, znajduje pierwszy automatyczny kształt wielokolumnowy z ramką tekstową, odczytuje skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do osobnego pliku. Kształty nieposiadające ramki tekstowej są pomijane.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("MultiColumnText.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let textBox = null;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            const textFrame = shape.getTextFrame();
            if (textFrame != null) {
                const columnCount = textFrame.getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = shape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        console.log("No multi-column text frame was found.");
    } else {
        const textFrame = textBox.getTextFrame();
        const configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        const columnTexts = textFrame.splitTextByColumns();

        console.log("Configured columns: " + configuredColumnCount);

        for (let columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            const columnNumber = columnIndex + 1;
            const columnText = columnTexts[columnIndex];
            console.log("Column " + columnNumber + ": " + columnText);
            const outputPath = "Column-" + columnNumber + ".txt";
            try {
                fs.writeFileSync(outputPath, columnText, "utf8");
            } catch (error) {
                console.log("Could not write column " + columnNumber + ": " + error.message);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aktualizacja tekstu**

Aby zaktualizować tekst w całej prezentacji, iteruj po slajdach i kształtach, wybieraj automatyczne kształty i edytuj ich fragmenty tekstu. Praca na poziomie fragmentu pozwala zmienić zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zastępuje każde wystąpienie `years` słowem `months` w tekście automatycznych kształtów i pogrubia każdy zmieniony fragment:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const fontBold = java.newByte(aspose.slides.NullableBool.True);
const presentation = new aspose.slides.Presentation("Text.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                continue;
            }

            const textFrame = shape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < textFrame.getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const text = portion.getText();
                    if (text != null && text.includes("years")) {
                        portion.setText(text.replace(/years/g, "months"));
                        portion.getPortionFormat().setFontBold(fontBold);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ta iteracja aktualizuje tekst wyłącznie w automatycznych kształtach. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga przeglądu ich własnych kolekcji.

## **Dodanie pola tekstowego z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, dzięki czemu tylko ten fragment działa jako klikalny odnośnik. Użyj [HyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), aby powiązać fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    const textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu na slajdzie głównym lub układowym?**

[Placeholder](/slides/pl/nodejs-java/manage-placeholder/) może dziedziczyć pozycję i formatowanie z [master slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) lub [layout slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone i nie przejmuje zachowania symbolu zastępczego po zmianie układu.

**Jak wymienić tekst bez zmiany tekstu w wykresach, tabelach lub SmartArt?**

Ogranicz przeglądanie do kształtów będących instancjami [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), tak jak pokazano w przykładzie Aktualizacji tekstu. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektowych, więc nie są modyfikowane przez tę pętlę.