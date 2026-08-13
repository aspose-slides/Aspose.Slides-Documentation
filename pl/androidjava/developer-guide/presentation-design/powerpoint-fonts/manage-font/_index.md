---
title: Zarządzaj czcionkami w prezentacjach na Androidzie
linktitle: Zarządzaj czcionkami
type: docs
weight: 10
url: /pl/androidjava/manage-fonts/
keywords:
- zarządzaj czcionkami
- właściwości czcionki
- akapit
- formatowanie tekstu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Kontroluj czcionki w Javie przy użyciu Aspose.Slides for Android: osadzaj, zamieniaj i wczytuj własne czcionki, aby prezentacje PPT, PPTX i ODP były czytelne, zgodne z marką i spójne."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie właściwościami czcionki w tekście prezentacji bezpośrednio z kodu. Możesz uzyskać dostęp do tekstu na slajdach poprzez kształty, ramki tekstowe, akapity i fragmenty, a następnie zastosować formatowanie do wybranego tekstu.

Ten artykuł wyjaśnia, jak konfigurować właściwości związane z czcionką dla istniejącego tekstu w prezentacji, w tym rodzinę czcionki, style pogrubienia i kursywy, wyrównanie akapitu oraz kolor czcionki. Pokazuje również, jak utworzyć pole tekstowe, dodać do niego tekst oraz ustawić właściwości czcionki, takie jak rodzina czcionki, pogrubienie, kursywa, podkreślenie, rozmiar czcionki i kolor, przed zapisaniem wyniku jako pliku PPTX.

## **Zarządzanie właściwościami czcionki**
{{% alert color="info" %}} 

Prezentacje zazwyczaj zawierają zarówno tekst, jak i obrazy. Tekst może być formatowany na różne sposoby, aby podkreślić określone sekcje i słowa lub aby spełniać standardy korporacyjne. Formatowanie tekstu pomaga użytkownikom zmieniać wygląd treści prezentacji. Ten artykuł pokazuje, jak używać Aspose.Slides for Android via Java do konfigurowania właściwości czcionki akapitów tekstu na slajdach.

{{% /alert %}} 

Aby zarządzać właściwościami czcionki akapitu przy użyciu Aspose.Slides for Android via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kształtów [Placeholder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/placeholder/) w slajdzie i rzutuj je na [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/).
1. Pobierz [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/) udostępnionego przez [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/).
1. Justuj akapit.
1. Uzyskaj dostęp do [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) tekstu [Paragraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/paragraph/).
1. Zdefiniuj czcionkę przy użyciu [FontData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontdata/) i ustaw **Font** fragmentu tekstu [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) odpowiednio.
   1. Ustaw czcionkę na pogrubioną.
   1. Ustaw czcionkę na kursywę.
1. Ustaw kolor czcionki przy użyciu [FillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fillformat/) udostępnionego przez obiekt [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej. Przyjmuje ona nieformatowaną prezentację i formatuje czcionki na jednym ze slajdów. Zrzuty ekranu poniżej pokazują plik wejściowy oraz to, jak fragmenty kodu go zmieniają. Kod zmienia czcionkę, kolor i styl czcionki.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Rysunek: Tekst w pliku wejściowym**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Rysunek: Ten sam tekst z zaktualizowanym formatowaniem**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz obiekt Presentation reprezentujący plik PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Dostęp do slajdu za pomocą jego pozycji
	ISlide slide = pres.getSlides().get_Item(0);

	// Dostęp do pierwszego i drugiego symbolu zastępczego na slajdzie oraz rzutowanie go na AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Dostęp do pierwszego akapitu
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Justuj akapit
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Dostęp do pierwszego fragmentu
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Zdefiniuj nowe czcionki
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Przypisz nowe czcionki do fragmentu
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Ustaw czcionkę na pogrubioną
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Ustaw czcionkę na kursywę
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Ustaw kolor czcionki
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Zapisz plik PPTX na dysk
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Ustaw właściwości czcionki tekstu**
{{% alert color="info" %}} 

Jak wspomniano w **Zarządzanie właściwościami czcionki**, [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) służy do przechowywania tekstu o podobnym stylu formatowania w akapicie. Ten artykuł pokazuje, jak używać Aspose.Slides for Android via Java do tworzenia pola tekstowego z tekstem, a następnie definiowania określonej czcionki oraz różnych innych właściwości kategorii rodziny czcionki.

{{% /alert %}} 

Aby utworzyć pole tekstowe i ustawić właściwości czcionki tekstu w nim:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Dodaj do slajdu [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/) typu **Rectangle**.
1. Usuń styl wypełnienia powiązany z [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/).
1. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/) kształtu [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/).
1. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/).
1. Uzyskaj dostęp do obiektu [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) powiązanego z [TextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframe/).
1. Zdefiniuj czcionkę, która ma być użyta dla [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/).
1. Ustaw inne właściwości czcionki, takie jak pogrubienie, kursywa, podkreślenie, kolor i wysokość, korzystając z odpowiednich właściwości udostępnionych przez obiekt [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementacja powyższych kroków jest przedstawiona poniżej.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Rysunek: Tekst z niektórymi ustawionymi właściwościami czcionki przez Aspose.Slides for Android via Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz obiekt Presentation reprezentujący plik PPTX
Presentation pres = new Presentation();
try {
	// Pobierz pierwszy slajd
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Dodaj AutoShape typu Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Usuń wszelkie style wypełnienia powiązane z AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Uzyskaj dostęp do TextFrame powiązanego z AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Uzyskaj dostęp do Portion powiązanego z TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Ustaw czcionkę dla Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Ustaw właściwość pogrubienia (Bold) czcionki
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Ustaw właściwość kursywy (Italic) czcionki
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Ustaw właściwość podkreślenia czcionki
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Ustaw wysokość czcionki
	port.getPortionFormat().setFontHeight(25);
	
	// Ustaw kolor czcionki
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Zapisz prezentację na dysku
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```