---
title: "Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach przy użyciu Pythona via Java"
linktitle: "Zarządzanie listami"
type: docs
weight: 60
url: /pl/python-java/manage-lists/
keywords:
- "punkt"
- "lista wypunktowana"
- "lista numerowana"
- "symbol wypunktowania"
- "obrazkowe wypunktowanie"
- "niestandardowe wypunktowanie"
- "lista wielopoziomowa"
- "utwórz wypunktowanie"
- "dodaj wypunktowanie"
- "dodaj listę"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, wypunktowania obrazkowe, listy wielopoziomowe oraz listy numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona via Java."
---
## **Przegląd**

Aspose.Slides for Python via Java umożliwia tworzenie i formatowanie list wypunktowanych i numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy to akapit, którego ustawienia wypunktowania są kontrolowane przez format akapitu.

Użyj metody [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat), aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), który zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/). Za pomocą tego obiektu możesz ustawić typ wypunktowania, symbol, obraz, kolor, rozmiar, styl numeracji i początkowy numer.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć wypunktowanie za pomocą obrazu
- utworzyć listę wielopoziomową ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji
- odczytać rzeczywiste znaczniki i numery listy wraz z tekstem akapitu

## **Utwórz listę wypunktowaną**

Aby utworzyć listę wypunktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) i ustaw [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Symbol](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Symbol). Następnie możesz użyć [BulletFormat.setChar](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setChar), [BulletFormat.getColor](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getColor) oraz [BulletFormat.setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setHeight), aby kontrolować wygląd wypunktowania.

Poniższy kod Python demonstruje, jak utworzyć listę wypunktowaną na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NullableBool, Paragraph, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    bullet_color = Color(205, 92, 92)

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    first_paragraph.getParagraphFormat().getBullet().setChar('*')
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    first_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    second_paragraph.getParagraphFormat().getBullet().setChar('*')
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True_)
    second_paragraph.getParagraphFormat().getBullet().getColor().setColor(bullet_color)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Symbole wypunktowania](symbol_bullets.png)

## **Utwórz listę numerowaną**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Numbered](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Numbered). Możesz również wybrać format numeracji za pomocą [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStyle) lub użyć [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setNumberedBulletStartWith), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod Python pokazuje, jak utworzyć listę numerowaną na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    first_paragraph.setText("Apple")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    second_paragraph.setText("Orange")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    third_paragraph.setText("Banana")
    text_frame.getParagraphs().add(third_paragraph)

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Wypunktowania numerowane](numbered_bullets.png)

## **Utwórz wypunktowanie obrazkowe**

Aspose.Slides pozwala zamienić zwykły symbol wypunktowania na obraz. Wypunktowania obrazkowe działają najlepiej z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="info" title="Note" %}}
Jeśli planujesz zamienić zwykły symbol wypunktowania na obraz, wybierz prostą grafikę z przezroczystym tłem. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole wypunktowania.
{{% /alert %}}

Aby utworzyć wypunktowanie obrazkowe, dodaj obraz do [Presentation.getImages](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getImages), i przypisz zwrócony obiekt obrazu do [BulletFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#getPicture). Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/python-java/aspose.slides/bulletformat/#setType) na [BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/#Picture) przed przypisaniem obrazu.

Załóżmy, że mamy obraz o nazwie "image.png":

![Obraz do wypunktowania](picture_for_bullets.png)

Poniższy kod Python pokazuje, jak utworzyć wypunktowania obrazkowe na slajdzie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Images, Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    image = Images.fromFile("image.png")
    try:
        bullet_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    first_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    first_paragraph.getParagraphFormat().setIndent(15)
    first_paragraph.getParagraphFormat().getBullet().setHeight(100)
    first_paragraph.setText("The first paragraph")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture)
    second_paragraph.getParagraphFormat().getBullet().getPicture().setImage(bullet_image)
    second_paragraph.getParagraphFormat().setIndent(15)
    second_paragraph.getParagraphFormat().getBullet().setHeight(100)
    second_paragraph.setText("The second paragraph")
    text_frame.getParagraphs().add(second_paragraph)

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Wypunktowania obrazkowe](picture_bullets.png)

## **Utwórz listę wielopoziomową**

Użyj [ParagraphFormat.setDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDepth), aby umieścić elementy listy na różnych poziomach. Poziom 0 jest najwyższym poziomem, poziom 1 jest zagnieżdżony pod nim, i tak dalej.

Poniższy kod Python pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110)

    text_frame = auto_shape.getTextFrame()
    text_frame.getParagraphs().clear()

    first_paragraph = Paragraph()
    first_paragraph.getParagraphFormat().setDepth(0)
    first_paragraph.setText("My text - Depth 0")
    text_frame.getParagraphs().add(first_paragraph)

    second_paragraph = Paragraph()
    second_paragraph.getParagraphFormat().setDepth(1)
    second_paragraph.setText("My text - Depth 1")
    text_frame.getParagraphs().add(second_paragraph)

    third_paragraph = Paragraph()
    third_paragraph.getParagraphFormat().setDepth(2)
    third_paragraph.setText("My text - Depth 2")
    text_frame.getParagraphs().add(third_paragraph)

    fourth_paragraph = Paragraph()
    fourth_paragraph.getParagraphFormat().setDepth(3)
    fourth_paragraph.setText("My text - Depth 3")
    text_frame.getParagraphs().add(fourth_paragraph)

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmień istniejącą listę**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet). Te same właściwości używane do tworzenia list mogą być użyte do przeglądania lub modyfikacji list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod Python zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, NumberedBulletStyle, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod)
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(1)
    paragraph.getParagraphFormat().setMarginLeft(30)
    paragraph.getParagraphFormat().setIndent(-20)

    presentation.save("updated_list.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Odczytaj rzeczywiste wartości wypunktowania**

Podczas wyodrębniania zawartości prezentacji zachowuj znaczniki listy wraz z tekstem akapitu. Wywołaj [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), i uzyskaj dostęp do `getBullet`, aby otrzymać efektywny format wypunktowania. Sprawdź jego `getType` przed odczytaniem `getActualBulletValue`.

Dla list numerowanych rozróżnij te trzy wartości:

- `getNumberedBulletStyle` określa format, np. arabskie liczby zakończone kropką lub małe litery zakończone kropką.
- `getNumberedBulletStartWith` określa początkową liczbę dla grupy numerowanych akapitów.
- `getActualBulletValue` zwraca sformatowany znacznik dla określonego akapitu. Na przykład drugi element listy zaczynającej się od 5 zwróci `6.`.

Zachowaj [getDepth](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDepth), aby każdy akapit zachował swój poziom zagnieżdżenia. Rzeczywisty znacznik nie koduje pełnej hierarchii: element zagnieżdżony może zwrócić `c.` zamiast połączonej etykiety takiej jak `6.c.`.

Poniższy samodzielny przykład tworzy listy, zapisuje je do prezentacji i ponownie wczytuje prezentację, aby zgłosić tekst, głębokość, typ wypunktowania i rzeczywistą wartość każdego akapitu. Mały niebieski znacznik obrazkowy jest tworzony z osadzonego SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, FillType, NullableBool, NumberedBulletStyle, Paragraph, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, SvgImage
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # Utwórz znacznik obrazu bez zewnętrznego pliku obrazu.
    svg = SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.getImages().addImage(svg)

    def add_paragraph(text, depth, bullet_type, start, style):
        paragraph = Paragraph()
        paragraph.setText(text)

        paragraph_format = paragraph.getParagraphFormat()
        paragraph_format.setDepth(depth)
        paragraph_format.setMarginLeft(30 + depth * 40)
        paragraph_format.setIndent(-28)
        paragraph_format.setSpaceAfter(8)
        paragraph_format.getDefaultPortionFormat().setFontHeight(22)
        paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        paragraph_format.getBullet().setType(bullet_type)
        paragraph_format.getBullet().setBulletHardColor(NullableBool.True_)
        paragraph_format.getBullet().getColor().setColor(Color.BLACK)
        if bullet_type == BulletType.Numbered:
            paragraph_format.getBullet().setNumberedBulletStyle(style)
            paragraph_format.getBullet().setNumberedBulletStartWith(start)
        elif bullet_type == BulletType.Symbol:
            paragraph_format.getBullet().setChar('\u2022')
        elif bullet_type == BulletType.Picture:
            paragraph_format.getBullet().getPicture().setImage(bullet_image)

        text_frame.getParagraphs().add(paragraph)

    add_paragraph("First item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Second item", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Next nested item", 1, BulletType.Numbered, 3, NumberedBulletStyle.BulletAlphaLCPeriod)
    add_paragraph("Deep item", 2, BulletType.Numbered, 4, NumberedBulletStyle.BulletRomanLCPeriod)
    add_paragraph("Back to top level", 0, BulletType.Numbered, 5, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Symbol marker", 0, BulletType.Symbol, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("No bullet", 0, BulletType.None_, 1, NumberedBulletStyle.BulletArabicPeriod)
    add_paragraph("Picture marker", 0, BulletType.Picture, 1, NumberedBulletStyle.BulletArabicPeriod)
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

loaded_presentation = Presentation("actual_bullet_values.pptx")
try:
    loaded_shape = loaded_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    type_names = {
        BulletType.Numbered: "Numbered",
        BulletType.Symbol: "Symbol",
        BulletType.None_: "None",
        BulletType.Picture: "Picture",
    }
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.getTextFrame().getParagraphs():
        bullet = paragraph.getParagraphFormat().getEffective().getBullet()
        bullet_type = bullet.getType()
        if bullet_type in (BulletType.Numbered, BulletType.Symbol):
            marker = bullet.getActualBulletValue()
        elif bullet_type == BulletType.None_:
            marker = f"{bullet.getActualBulletValue()} (no bullet)"
        elif bullet_type == BulletType.Picture:
            marker = f"{bullet.getActualBulletValue()} (image required)"
        else:
            marker = "unsupported bullet type"
        type_name = type_names.get(bullet_type, "Unknown")
        print(f"{paragraph.getText()} | {paragraph.getParagraphFormat().getDepth()} | {type_name} | {marker}")
finally:
    loaded_presentation.dispose()
```

Poniżej pokazano listy źródłowe.

![Listy zaczynające się od 5, elementy zagnieżdżone literowe i rzymskie, znacznik symboliczny, akapit bez wypunktowania i niebieski znacznik obrazkowy](actual_bullet_values.png)

Raport odpowiada znacznikom wyświetlanym w PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | None (no bullet)
Picture marker | 0 | Picture | None (image required)
```

Dla [BulletType.None_ and BulletType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/bullettype/), `getActualBulletValue` zwraca `None` (Java `null`), a nie pusty ciąg znaków. Obsługuj te typy osobno: pierwszy nie ma znacznika, natomiast drugi wymaga osobnego wyodrębnienia obrazu wypunktowania. Wypunktowanie obrazkowe nie może być odtworzone wyłącznie przez wyodrębnienie znacznika tekstowego.

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do formatu PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie układanie tekstu i funkcje wypunktowania.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [ParagraphFormat.getBullet](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getBullet), i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.