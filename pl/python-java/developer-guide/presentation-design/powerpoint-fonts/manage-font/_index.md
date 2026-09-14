---
title: Zarządzanie czcionkami w prezentacjach przy użyciu Pythona przez Java
linktitle: Zarządzanie czcionkami
type: docs
weight: 10
url: /pl/python-java/manage-fonts/
keywords:
- zarządzanie czcionkami
- właściwości czcionek
- akapit
- formatowanie tekstu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Kontroluj czcionki w Pythonie przez Java za pomocą Aspose.Slides: osadzaj, zastępuj i wczytuj własne czcionki, aby prezentacje PPT, PPTX i ODP były czytelne, zgodne z wizerunkiem marki i spójne."
---
## **Przegląd**

Aspose.Slides umożliwia zarządzanie właściwościami czcionki w tekście prezentacji bezpośrednio z kodu. Możesz uzyskać dostęp do tekstu w slajdach poprzez kształty, ramki tekstowe, akapity i fragmenty, a następnie zastosować formatowanie do wybranego tekstu.

W tym artykule wyjaśniono, jak konfigurować właściwości związane z czcionką dla istniejącego tekstu w prezentacji, w tym rodzinę czcionki, pogrubienie i kursywę, wyrównanie akapitu oraz kolor czcionki. Pokazano również, jak utworzyć pole tekstowe, dodać do niego tekst oraz ustawić właściwości czcionki, takie jak rodzina czcionki, pogrubienie, kursywa, podkreślenie, rozmiar i kolor, przed zapisaniem wyniku jako plik PPTX.

## **Zarządzanie właściwościami czcionki**
{{% alert color="info" title="Uwaga" %}} 

Prezentacje zazwyczaj zawierają zarówno tekst, jak i obrazy. Tekst może być formatowany na różne sposoby, aby wyróżnić określone sekcje i słowa lub dostosować go do stylów korporacyjnych. Formatowanie tekstu pomaga użytkownikom zróżnicować wygląd treści prezentacji. Ten artykuł pokazuje, jak używać Aspose.Slides for Python via Java do konfigurowania właściwości czcionki akapitów tekstu na slajdach.

{{% /alert %}} 

Aby zarządzać właściwościami czcionki akapitu przy użyciu Aspose.Slides for Python via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kształtów [Placeholder](https://reference.aspose.com/slides/pl/python-java/aspose.slides/placeholder/) w slajdzie jako [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
1. Pobierz [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/) z [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) udostępnionego przez [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
1. Wyrównaj akapit (justify).
1. Uzyskaj dostęp do [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) tekstu w [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/).
1. Zdefiniuj czcionkę za pomocą [FontData](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontdata/) i ustaw **Font** fragmentu tekstu [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) odpowiednio.
   1. Ustaw czcionkę jako pogrubioną.
   1. Ustaw czcionkę jako kursywę.
1. Ustaw kolor czcionki za pomocą [FillFormat](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fillformat/) udostępnionego przez obiekt [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementację powyższych kroków podano poniżej. Przykład przyjmuje nieformatowaną prezentację i formatuje czcionki na jednym ze slajdów. Zrzuty ekranu poniżej pokazują plik wejściowy oraz zmiany wprowadzone przez fragmenty kodu. Kod zmienia czcionkę, kolor i styl czcionki.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Rysunek: Tekst w pliku wejściowym**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Rysunek: Ten sam tekst po zaktualizowaniu formatowania**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Załaduj prezentację.
presentation = Presentation("FontProperties.pptx")
try:
    # Uzyskaj dostęp do pierwszego slajdu oraz ramek tekstowych jego pierwszych dwóch zastępców.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Uzyskaj dostęp do pierwszego akapitu w każdej ramce tekstowej.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Uzyskaj dostęp do pierwszego fragmentu w każdym akapicie.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Zdefiniuj i przypisz nowe czcionki.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Ustaw czcionki jako pogrubione i kursywą.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Ustaw kolory czcionek.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Zapisz prezentację.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawianie właściwości czcionki tekstu**
{{% alert color="info" title="Uwaga" %}} 

Jak wspomniano w sekcji **Zarządzanie właściwościami czcionki**, [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) służy do przechowywania tekstu o podobnym stylu formatowania w akapicie. Ten artykuł pokazuje, jak używać Aspose.Slides for Python via Java do utworzenia pola tekstowego z pewnym tekstem i zdefiniowania konkretnej czcionki oraz różnych innych właściwości czcionki.

{{% /alert %}} 

Aby utworzyć pole tekstowe i ustawić właściwości czcionki tekstu w nim:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Dodaj do slajdu [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu **Rectangle**.
1. Usuń styl wypełnienia powiązany z [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
1. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) kształtu [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/).
1. Dodaj trochę tekstu do [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).
1. Uzyskaj dostęp do obiektu [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/) powiązanego z [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/).
1. Zdefiniuj czcionkę, która ma być użyta w [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/).
1. Ustaw inne właściwości czcionki, takie jak pogrubienie, kursywa, podkreślenie, kolor i wysokość, korzystając z odpowiednich właściwości udostępnionych przez obiekt [Portion](https://reference.aspose.com/slides/pl/python-java/aspose.slides/portion/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Implementację powyższych kroków podano poniżej.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Rysunek: Tekst z wybranymi właściwościami czcionki ustawionymi przez Aspose.Slides for Python via Java**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Pobierz pierwszy slajd i dodaj prostokąt.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Usuń wypełnienie kształtu.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Dodaj tekst do ramki tekstowej kształtu.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # Ustaw rodzinę czcionki.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Ustaw pogrubienie, kursywę, podkreślenie i rozmiar czcionki.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # Ustaw kolor czcionki.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Zapisz prezentację.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```