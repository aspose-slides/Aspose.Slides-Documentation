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
description: "Aspose.Slides dla Node.js umożliwia łatwe tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację Twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for Node.js via Java udostępnia klasę [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape), która pozwala dodać kształt zawierający tekst.

{{% alert title="Info" color="info" %}}

Aspose.Slides udostępnia także klasę [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape), która pozwala dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane przy użyciu klasy `Shape` mogą zawierać tekst. Natomiast kształty dodane przy użyciu klasy [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) mogą zawierać tekst.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Dlatego, gdy pracujesz z kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został on rzutowany przy użyciu klasy `AutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame), które jest właściwością klasy `AutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/nodejs-java/manage-textbox/#update-text) na tej stronie.

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) z ustawionym [ShapeType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu `AutoShape`.
4. Dodaj właściwość `TextFrame` do obiektu `AutoShape`, w której będzie zawarty tekst. W poniższym przykładzie dodaliśmy tekst: *Aspose TextBox*
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod JavaScript — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Inicjuje prezentację
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var sld = pres.getSlides().get_Item(0);
    // Dodaje AutoShape z typem ustawionym jako Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Dodaje TextFrame do prostokąta
    ashp.addTextFrame(" ");
    // Uzyskuje dostęp do ramki tekstowej
    var txtFrame = ashp.getTextFrame();
    // Tworzy obiekt Paragraph dla ramki tekstowej
    var para = txtFrame.getParagraphs().get_Item(0);
    // Tworzy obiekt Portion dla akapitu
    var portion = para.getPortions().get_Item(0);
    // Ustawia tekst
    portion.setText("Aspose TextBox");
    // Zapisuje prezentację na dysku
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sprawdzanie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [isTextBox](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#isTextBox) klasy [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), pozwalającą badać kształty i identyfikować pola tekstowe.

![Text box and shape](istextbox.png)

Ten kod JavaScript pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (var slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        var slide = presentation.getSlides().get_Item(slideIndex);
        for (var shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            var shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Zauważ, że jeśli po prostu dodasz autoshape przy użyciu metody `addAutoShape` klasy [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/), metoda `isTextBox` autoshape zwróci `false`. Jednak po dodaniu tekstu do autoshape za pomocą metody `addTextFrame` lub `setText`, właściwość `isTextBox` zwróci `true`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() zwraca false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() zwraca true

var shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() zwraca false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() zwraca true

var shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() zwraca false
shape3.addTextFrame("");
// shape3.isTextBox() zwraca false

var shape4 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() zwraca false
shape4.getTextFrame().setText("");
// shape4.isTextBox() zwraca false
```

## **Znajdowanie kształtu, który posiada ramkę tekstową**

W ogólnym kodzie przetwarzającym tekst możesz otrzymać obiekt [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj metody [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentShape--) aby przejść z powrotem do właściciela — [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/).

Dla ramki tekstowej należącej do [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) lub innego kształtu zawierającego tekst, [TextFrame.getParentShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentShape--) zwraca właściciela, a [TextFrame.getParentCell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParentCell--) zwraca `null`. Obie metody zapewniają tylko odczyt, więc ich wywołanie nie zmienia własności. Zawsze sprawdzaj zwróconą wartość pod kątem `null` przed dostępem do kształtu.

Kompletny przykład identyfikujący właścicieli kształtów i komórek tabel, w tym kształtów powiązanych z węzłami SmartArt, znajduje się w artykule [Search and Replace Text](/slides/pl/nodejs-java/search-and-replace-text/).

## **Dodawanie kolumn w polu tekstowym**

Aspose.Slides udostępnia metody [setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) i [setColumnSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat), które pozwalają dodawać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz ustawić odstęp w punktach pomiędzy kolumnami.

Ten kod w JavaScript demonstruje opisaną operację: 

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaje AutoShape z typem ustawionym jako Rectangle
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Dodaje TextFrame do prostokąta
    aShape.addTextFrame((("All these columns are limited to be within a single text container -- " + "you can add or delete text and the new or remaining text automatically adjusts ") + "itself to flow within the container. You cannot have text flow from one container ") + "to other though -- we told you PowerPoint's column options for text are limited!");
    // Pobiera format tekstu z TextFrame
    var format = aShape.getTextFrame().getTextFrameFormat();
    // Określa liczbę kolumn w TextFrame
    format.setColumnCount(3);
    // Określa odstęp między kolumnami
    format.setColumnSpacing(10);
    // Zapisuje prezentację
    pres.save("ColumnCount.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie kolumn w ramce tekstowej**

Aspose.Slides for Node.js via Java udostępnia metodę [setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat), która pozwala dodawać kolumny w ramkach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej.

Ten kod JavaScript pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const assert = require("assert");

var outPptxFileName = "ColumnsTest.pptx";
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    var format = shape1.getTextFrame().getTextFrameFormat();
    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " + "you can add or delete text - and the new or remaining text automatically adjusts " + "itself to stay within the container. You cannot have text spill over from one container " + "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        // Odstęp między kolumnami nie został nigdy ustawiony, więc jest zgłaszany jako NaN.
        assert.ok(Number.isNaN(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing()));
    } finally {
        if (test != null) {
            test.dispose();
        }
    }
    format.setColumnSpacing(20);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test1 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test1.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 2);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 20);
    } finally {
        if (test1 != null) {
            test1.dispose();
        }
    }
    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, aspose.slides.SaveFormat.Pptx);
    var test2 = new aspose.slides.Presentation(outPptxFileName);
    try {
        var autoShape = test2.getSlides().get_Item(0).getShapes().get_Item(0);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnCount(), 3);
        assert.strictEqual(autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing(), 15);
    } finally {
        if (test2 != null) {
            test2.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aktualizacja tekstu**

Aspose.Slides umożliwia zmianę lub aktualizację tekstu zawartego w polu tekstowym lub wszystkich tekstów w prezentacji. 

Ten kod JavaScript demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Iteruje przez akapity w ramce tekstowej
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Iteruje przez każdą część w akapicie
                    for (let k = 0; k < paragraph.getPortions().getCount(); k++) {
                        let portion = paragraph.getPortions().get_Item(k);
                        portion.setText(portion.getText().replace("years", "months"));// Zmienia tekst
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// Zmienia formatowanie
                    }
                }
            }
        }
    }
    // Zapisuje zmodyfikowaną prezentację
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie pola tekstowego z hiperłączem** 

Możesz wstawić link wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy zostaną przekierowani do otwarcia linku. 

Aby dodać pole tekstowe zawierające link, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu AutoShape.
4. Dodaj `TextFrame` do obiektu `AutoShape` i ustaw tekst jego pierwszej części. W poniższym przykładzie użyliśmy tekstu: *Aspose.Slides*
5. Uzyskaj `HyperlinkManager` tej części poprzez jej `PortionFormat`.
6. Wywołaj `setExternalHyperlinkClick` na `HyperlinkManager`, aby dołączyć link do części.
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod JavaScript — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaje obiekt AutoShape z typem ustawionym na Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Rzutuje kształt na AutoShape
    var pptxAutoShape = shape;
    // Uzyskuje dostęp do własności ITextFrame powiązanej z AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Dodaje tekst do ramki
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ustawia hiperłącze dla tekstu części
    var hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");
    // Zapisuje prezentację PPTX
    pres.save("hLink_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu przy pracy z slajdami wzorcowymi?**

[Placeholder](/slides/pl/nodejs-java/manage-placeholder/) dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) i może być nadpisany w [układach](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/), natomiast zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie dotykając tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do auto‑kształtów, które mają ramki tekstowe, i wyklucz wbudowane obiekty ([charts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/)) przeglądając ich kolekcje osobno lub pomijając te typy obiektów.