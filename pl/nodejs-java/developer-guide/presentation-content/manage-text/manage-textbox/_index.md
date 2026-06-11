---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/nodejs-java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- zaktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js umożliwia łatwe tworzenie, edytowanie i kopiowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację Twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim jakiś tekst. Aspose.Slides for Node.js via Java udostępnia klasę [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape), która pozwala dodać kształt zawierający tekst.

{{% alert title="Info" color="info" %}}

Aspose.Slides udostępnia również klasę [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape), która pozwala dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane przy użyciu klasy `Shape` mogą zawierać tekst. Natomiast kształty dodane przy pomocy klasy [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) mogą zawierać tekst.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Dlatego, gdy pracujesz z kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został rzutowany jako klasa `AutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrame), który jest właściwością klasy `AutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/nodejs-java/manage-textbox/#update-text) na tej stronie.

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) z [ShapeType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/GeometryShape#setShapeType-int-) ustawiony jako `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu `AutoShape`.
4. Dodaj właściwość `TextFrame` do obiektu `AutoShape`, która będzie zawierać tekst. W poniższym przykładzie dodaliśmy ten tekst: *Aspose TextBox*
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod JavaScript — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```javascript
// Tworzy instancję prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var sld = pres.getSlides().get_Item(0);
    // Dodaje AutoShape z typem ustawionym jako Prostokąt
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
    // Zapisuje prezentację na dysk
    pres.save("TextBox_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [isTextBox](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/#isTextBox) z klasy [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), pozwalającą badać kształty i identyfikować pola tekstowe.

![Text box and shape](istextbox.png)

Ten kod JavaScript pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe:

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    java.callStaticMethodSync("ForEach", "shape", presentation, (shape, slide, index) -> {
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var autoShape = shape;
            console.log(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Zauważ, że jeśli po prostu dodasz autokształt przy użyciu metody `addAutoShape` z klasy [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/), metoda `isTextBox` tego autokształtu zwróci `false`. Jednak po dodaniu tekstu do autokształtu metodą `addTextFrame` lub `setText`, właściwość `isTextBox` zwróci `true`.

```javascript
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

## **Dodanie kolumny w polu tekstowym**

Aspose.Slides udostępnia metody [setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) i [setColumnSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnSpacing-double-) z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat), które pozwalają dodać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym i ustawić odstęp w punktach pomiędzy kolumnami.

Ten kod w JavaScript demonstruje opisaną operację: 

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaje AutoShape z typem ustawionym jako Prostokąt
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

## **Dodanie kolumny w ramce tekstowej**

Aspose.Slides for Node.js via Java udostępnia metodę [setColumnCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat#setColumnCount-int-) z klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/TextFrameFormat), która pozwala dodać kolumny w ramkach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej.

Ten kod JavaScript pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```javascript
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", java.getStaticFieldValue("java.lang.Double", "NaN") == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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
        java.callStaticMethodSync("Assert", "assertTrue", 3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        java.callStaticMethodSync("Assert", "assertTrue", 15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
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

Aspose.Slides pozwala zmienić lub zaktualizować tekst zawarty w polu tekstowym lub wszystkie teksty w prezentacji. 

Ten kod JavaScript demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape).
            if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
                var autoShape = shape;
                // Iteruje po akapitach w ramce tekstowej
                for (let j = 0; j < autoShape.getTextFrame().getParagraphs().getCount(); j++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(j);
                    // Iteruje po każdej części w akapicie
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

## **Dodanie pola tekstowego z hiperłączem** 

Możesz wstawić link wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy zostaną przekierowani do otwarcia linku. 

Aby dodać pole tekstowe zawierające link, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odniesienie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym jako `Rectangle` w określonej pozycji na slajdzie i uzyskaj odniesienie do nowo dodanego obiektu AutoShape.
4. Dodaj `TextFrame` do obiektu `AutoShape`, który zawiera *Aspose TextBox* jako domyślny tekst. 
5. Zainstancjuj klasę `HyperlinkManager`. 
6. Przypisz obiekt `HyperlinkManager` do właściwości [HyperlinkClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape#getHyperlinkClick--) powiązanej z wybraną częścią `TextFrame`.
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod JavaScript — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```javascript
// Tworzy instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodaje obiekt AutoShape z typem ustawionym jako Rectangle
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 150, 50);
    // Rzutuje kształt na AutoShape
    var pptxAutoShape = shape;
    // Uzyskuje dostęp do właściwości ITextFrame powiązanej z AutoShape
    pptxAutoShape.addTextFrame("");
    var textFrame = pptxAutoShape.getTextFrame();
    // Dodaje tekst do ramki
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");
    // Ustawia hiperłącze dla tekstu w części
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

**Jaka jest różnica między polem tekstowym a placeholderem tekstu podczas pracy z master slajdami?**

A [placeholder](/slides/pl/nodejs-java/manage-placeholder/) dziedziczy styl/pozycję z [master](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/masterslide/) i może być nadpisany na [layouts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak mogę wykonać masową zamianę tekstu w całej prezentacji, nie dotykając tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do autokształtów, które mają ramki tekstowe, i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/)) poprzez przeglądanie ich kolekcji osobno lub pomijanie tych typów obiektów.