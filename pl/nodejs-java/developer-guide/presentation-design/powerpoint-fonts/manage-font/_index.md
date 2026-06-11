---
title: Zarządzanie czcionkami w prezentacjach przy użyciu JavaScript
linktitle: Zarządzanie czcionkami
type: docs
weight: 10
url: /pl/nodejs-java/manage-fonts/
keywords:
- zarządzanie czcionkami
- właściwości czcionki
- akapit
- formatowanie tekstu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Kontroluj czcionki za pomocą Aspose.Slides for Node.js via Java: osadzaj, zamieniaj i wczytuj własne czcionki, aby prezentacje PPT, PPTX i ODP były czytelne i spójne."
---
## **Wstęp**

Prezentacje zazwyczaj zawierają zarówno tekst, jak i obrazy. Tekst może być formatowany na różne sposoby, aby podkreślić określone sekcje i słowa lub aby dostosować się do stylu korporacyjnego. Formatowanie tekstu pomaga użytkownikom zmieniać wygląd i odczucia zawartości prezentacji. Ten artykuł pokazuje, jak używać Aspose.Slides for Node.js via Java do konfigurowania właściwości czcionki akapitów tekstu na slajdach.

## **Zarządzanie właściwościami czcionki**

Aby zarządzać właściwościami czcionki akapitu przy użyciu Aspose.Slides for Node.js via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kształtów [Placeholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/placeholder/) w slajdzie i rzutuj je na [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
1. Pobierz [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) udostępnionego przez [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
1. Justuj akapit.
1. Uzyskaj dostęp do tekstu [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) w [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/).
1. Zdefiniuj czcionkę przy użyciu [FontData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontdata/) i ustaw **Font** tekstu [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) odpowiednio.
   1. Ustaw czcionkę na pogrubioną.
   1. Ustaw czcionkę na kursywę.
1. Ustaw kolor czcionki przy użyciu [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/) udostępnionego przez obiekt [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Implementacja powyższych kroków jest podana poniżej. Pobiera ona nieformatowaną prezentację i formatuje czcionki na jednym ze slajdów. Zrzuty ekranu poniżej pokazują plik wejściowy oraz to, jak fragmenty kodu go zmieniają. Kod zmienia czcionkę, kolor i styl czcionki.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Rysunek: Tekst w pliku wejściowym**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Rysunek: Ten sam tekst z zaktualizowanym formatowaniem**|

```javascript
// Utwórz obiekt Presentation reprezentujący plik PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Uzyskiwanie slajdu przy użyciu jego pozycji
    var slide = pres.getSlides().get_Item(0);
    // Uzyskiwanie pierwszego i drugiego placeholdera na slajdzie i rzutowanie go na AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // Uzyskiwanie pierwszego akapitu
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // Justowanie akapitu
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // Uzyskiwanie pierwszej części
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // Zdefiniuj nowe czcionki
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // Przypisz nowe czcionki do części
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // Ustaw czcionkę na pogrubioną
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ustaw czcionkę na kursywę
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ustaw kolor czcionki
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // Zapisz PPTX na dysku
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw właściwości czcionki tekstu**
{{% alert color="primary" %}} 

Jak wspomniano w **Zarządzanie właściwościami czcionki**, [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) jest używany do przechowywania tekstu o podobnym stylu formatowania w akapicie. Ten artykuł pokazuje, jak używać Aspose.Slides for Node.js via Java do utworzenia pola tekstowego z pewnym tekstem, a następnie określić konkretną czcionkę oraz różne inne właściwości kategorii rodziny czcionek.

{{% /alert %}} 

Aby utworzyć pole tekstowe i ustawić właściwości czcionki tekstu w nim:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) typu **Rectangle** do slajdu.
1. Usuń styl wypełnienia powiązany z [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
1. Uzyskaj dostęp do [TextFrame] obiektu [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
1. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
1. Uzyskaj dostęp do obiektu [Portion] powiązanego z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
1. Zdefiniuj czcionkę używaną dla [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/).
1. Ustaw inne właściwości czcionki, takie jak pogrubienie, kursywa, podkreślenie, kolor i wysokość, używając odpowiednich właściwości udostępnionych przez obiekt [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementacja powyższych kroków jest podana poniżej.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Rysunek: Tekst z niektórymi właściwościami czcionki ustawionymi przez Aspose.Slides for Node.js via Java**|

```javascript
// Utwórz obiekt Presentation reprezentujący plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Usuń wszelki styl wypełnienia powiązany z AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Uzyskaj dostęp do TextFrame powiązanego z AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Uzyskaj dostęp do Portion powiązanego z TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Ustaw czcionkę dla Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ustaw właściwość pogrubienia czcionki
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Ustaw właściwość kursywy czcionki
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ustaw właściwość podkreślenia czcionki
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Ustaw wysokość czcionki
    port.getPortionFormat().setFontHeight(25);
    // Ustaw kolor czcionki
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Zapisz prezentację na dysku
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```