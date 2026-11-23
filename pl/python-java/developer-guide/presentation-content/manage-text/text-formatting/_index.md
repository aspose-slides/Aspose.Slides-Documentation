---
title: Formatuj tekst prezentacji w Pythonie poprzez Java
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/python-java/text-formatting/
keywords:
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstępy między wierszami
- właściwość automatycznego dopasowania
- kotwica ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Java. Dostosuj czcionki, kolory, wyrównanie i więcej."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez Java. Obejmuje kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie automatycznego dopasowania, kotwiczenie tekstu, tabulatory i ustawienia języka.

Jeśli nie podano inaczej, przykłady używają [sample.pptx](sample.pptx). Pierwszy kształt na pierwszym slajdzie jest polem tekstowym, a jego pierwszy akapit zawiera tekst pokazany poniżej. Indeksy slajdów i kształtów są zerowo‑indeksowane. Przykłady zaznaczające pogrubione fragmenty używają efektywnego formatowania, w tym dziedziczonego formatowania pogrubienia:

![Przykładowy tekst](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/python-java/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) dla poszczególnych fragmentów tekstu.

Poniższy przykład ustawia jasnoszare podświetlenie jako domyślne dla pierwszego akapitu. Jawne kolory podświetlenia na poszczególnych fragmentach mają pierwszeństwo przed tym domyślnym:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ustaw wyrównanie akapitu na środek.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Wyrównaj czcionki w wierszu**

Użyj [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment), aby pionowo wyrównać fragmenty tekstu o różnych rozmiarach czcionki w jednym wierszu. Ustawienie to dotyczy całego akapitu i kontroluje wyrównanie w każdej jego linii.

Poniższy, samodzielny przykład tworzy cztery oznaczone pola tekstowe na jednym slajdzie. Każdy akapit zawiera ten sam tekst w rozmiarach 18, 36 i 54 punktów, z różnym wyrównaniem czcionki. Używa Arial, wyłącza automatyczne dopasowanie i zawijanie oraz utrzymuje ramki tekstowe wystarczająco duże dla jednej linii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Porównanie wyrównania bazowego, górnego, środkowego i dolnego przy mieszanych rozmiarach czcionki](font_alignment.png)

Wyrównanie czcionki korzysta z metryk czcionki, więc widoczne krawędzie poszczególnych liter nie muszą idealnie się zgadzać. Przykład zawiera zarówno wielką literę, jak i odgałęzienie, aby pokazać różnicę między wyrównaniem bazowym a dolnym. Dostępność czcionek i ich zamienniki, użyte znaki oraz różnica w rozmiarach czcionek wpływają na wynik. Wymiary ramki, marginesy, odstępy wierszy, zawijanie i automatyczne dopasowanie również wpływają na układ; używaj tych samych czcionek i ustawień układu przy porównywaniu trybów.

To ustawienie różni się od [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment), które kontroluje poziome wyrównanie akapitu, oraz od [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType), które pozycjonuje blok tekstowy pionowo wewnątrz kształtu. Formatowanie indeksu górnego i dolnego przez [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) przesuwa poszczególne fragmenty względem linii bazowej, zamiast ustawiać wyrównanie czcionki dla linii akapitu.

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0‑255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ustaw przezroczystość fragmentu tekstu.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstępy między znakami w tekście**

Użyj [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing), aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym. Przykłady dodają 3 punkty odstępu; wartości ujemne zagęszczają tekst.

Poniższy kod Python pokazuje, jak rozszerzyć odstępy między znakami w **całym akapicie**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Rozszerz odstępy między znakami.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Odstępy znaków w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak rozszerzyć odstępy znaków w **fragmentach tekstu z pogrubioną czcionką**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
            portion.getPortionFormat().setSpacing(3) # Rozszerz odstępy między znakami.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Odstępy znaków w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla konkretnych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco bardziej zwarte niż ten sam tekst wyświetlany w PowerPoint. Może się tak zdarzyć, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPointa.

Aby w takich przypadkach uzyskać wynik bardziej zbliżony do PowerPointa, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na wartość większą niż rzeczywisty rozmiar czcionki. Ten przykład wymaga pliku „presentation.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Sprawdza efektywne nazwy czcionek, w tym dziedziczone, i ustawia próg 100 punktów dla fragmentów używających czcionki Roboto. To wyłącza kerning dla dopasowanych fragmentów o rozmiarze czcionki poniżej 100 punktów:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dla dopasowanego tekstu poniżej progu to ustawienie zapobiega kerningowi i może pomóc wyrównać renderowanie Aspose.Slides z wizualnym wynikiem PowerPointa dla czcionek, które są objęte tym specyficznym zachowaniem PowerPointa.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu poprzez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) lub na poszczególnych fragmentach poprzez [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/).

Poniższy przykład ustawia domyślną czcionkę pierwszego akapitu na Times New Roman 12‑punktów z pogrubieniem, kursywą i przerywaną podkreśleniem. Jawne formatowanie poszczególnych fragmentów ma pierwszeństwo przed tymi domyślnymi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Ustaw właściwości czcionki dla akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład stosuje Times New Roman 13‑punktów, kursywę i przerywaną podkreślenie do fragmentów, których efektywne formatowanie jest pogrubione:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Ustaw właściwości czcionki dla fragmentu tekstu.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Kontroluj normalizację wysokości tekstu**

Użyj [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight), gdy odtwarzasz typografię szablonu lub badasz różnice w wysokości znaków. W PowerPoint włączenie normalizacji rozciąga lub kompresuje poszczególne znaki pionowo, aby uzyskać jednolitą widoczną wysokość w obrębie fragmentu tekstu. Nie gwarantuje to jednak równej wysokości tekstu między różnymi czcionkami.

Ustaw właściwość na [NullableBool.True_ lub False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/), aby wyraźnie włączyć lub wyłączyć normalizację. `NullableBool.NotDefined` pozostawia lokalne ustawienie nieustawione, tak że fragment dziedziczy wartość, np. z [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) akapitu. To nie oznacza `False`. Użyj [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) i odczytaj `getNormaliseHeight` w zwróconym efektywnym formacie, aby uzyskać rozwiązany wartość logiczną.

Poniższy, samodzielny przykład wymaga zainstalowanego **Arial**. Tworzy dwa bloki tekstu zawierające te same wielkie litery, małe litery, odgałęzienia i znaki diakrytyczne w rozmiarze 54 punktów. Oba akapity domyślnie włączają normalizację. Górny fragment wyraźnie ją wyłącza; dolny ją dziedziczy. Rozmiary ramek, marginesy i odstępy akapitów są identyczne, a zawijanie i automatyczne dopasowanie są wyłączone, aby utrzymać spójność porównania. Przykład wypisuje `False: False` i `NotDefined: True`, a następnie zapisuje „text_height_normalization.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Porównanie poniżej zostało wyeksportowane z zapisanego prezentacji. Górny wiersz ma wyłączoną normalizację (`False`); dolny wiersz dziedziczy włączone ustawienie (`NotDefined` → `True`). Zachowaj zainstalowany Arial, aby odtworzyć ten wygląd.

![Tekst Arial 54‑punkty z wyłączoną normalizacją u góry i dziedziczoną normalizacją poniżej](text_height_normalization.png)

Normalizacja zmienia wysokość znaku bez zmiany przypisanej wartości [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight), która określa rozmiar czcionki w punktach. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) kontroluje odstęp między wierszami, natomiast [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) reguluje, jak tekst lub jego pojemnik dostosowuje się do rozmiaru. Ustawienia te służą różnym celom i mogą niezależnie wpływać na ogólny układ. Po więcej informacji o formatowaniu akapitów i dziedziczeniu zobacz [Manage Paragraph](/slides/pl/python-java/manage-paragraph/).

## **Zastosuj i usuń przekreślenie**

Użyj [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) na fragmencie tekstu, aby wyświetlić korekty, anulowane terminy lub poprzednie ceny bez usuwania oryginalnego tekstu. Ustaw go na [TextStrikethroughType.Single lub Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) dla jednej lub dwóch linii przekreślenia.

Aby usunąć przekreślenie, podaj [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None). To wyraźnie wyłącza efekt, nawet jeśli otaczające formatowanie określa przekreślenie. Natomiast [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) pozostawia lokalne ustawienie nieokreślone, pozwalając fragmentowi dziedziczyć formatowanie, np. z akapitu. Nie gwarantuje to usunięcia przekreślenia. Użyj [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), aby odczytać wynikowe formatowanie, w tym dziedziczone wartości.

Poniższy, samodzielny przykład tworzy trzy porównania cen. Każdy akapit ma osobne fragmenty dla etykiety, poprzedniej ceny i bieżącej ceny, więc tylko poprzednia cena jest poddana zmianie. W pierwszym wierszu najpierw stosuje się przekreślenie, a potem je usuwa; pozostałe wiersze zachowują pojedyncze i podwójne przekreślenie. Zmiana tego ustawienia zachowuje tekst i jego pozostałe formatowanie, w tym pogrubioną poprzednią cenę.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Zastosuj przekreślenie, a następnie wyraźnie usuń je z pierwszej poprzedniej ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik, od góry do dołu: brak przekreślenia, pojedyncze przekreślenie i podwójne przekreślenie.

![Poprzednie ceny bez przekreślenia, z pojedynczym przekreśleniem i z podwójnym przekreśleniem](strikethrough.png)

## **Ustaw obrót tekstu**

Użyj [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType), aby ustawić predefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/), co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Wyświetl cyfry obok siebie w pionowym tekście**

Aby zachować cyfry dwucyfrowej liczby obok siebie w pionicznej japońskiej etykiecie, umieść obie cyfry w jednym fragmencie tekstu i wywołaj [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) na tym fragmencie. Obie etykiety w tym przykładzie używają [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) oraz 40‑punktowego MS Gothic. Jedynie ustawienie [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) dla cyfr się różni.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

W PowerPoint lewa etykieta (`True`) pokazuje cyfry pionowo i obok siebie pomiędzy znakami 和 i 年. W prawej etykiecie (`False`) para jest obrócona o 90 stopni zgodnie z ruchem wskazówek zegara. Otaczające japońskie znaki pozostają pionowe w obu etykietach.

![Porównanie pionowych etykiet dat w PowerPoint z pionowymi cyframi po lewej i obróconymi cyframi po prawej.](vertical_date.png)

## **Ustaw niestandardowy obrót ramki tekstowej**

Użyj [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle), aby ustawić własny kąt obrotu dla [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w kształcie:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw odstępy między wierszami w akapitach**

Aspose.Slides udostępnia [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) oraz [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin), aby kontrolować odstępy akapitów. Właściwości te są używane w następujący sposób:

* Użyj dodatniej wartości, aby określić odstęp wierszy jako procent wysokości wiersza.
* Użyj ujemnej wartości, aby określić odstęp w punktach.

Poniższy przykład ustawia odstęp wewnątrz pierwszego akapitu na 200 % wysokości wiersza (podwójny odstęp):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Odstęp wierszy w akapicie](line_spacing.png)

## **Kontroluj łamanie wierszy**

Zasady łamania wierszy w akapicie są przydatne w wąskich blokach tekstowych i prezentacjach, które mieszają tekst łaciński i wschodnioazjatycki. Poniższe metody należą do [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/), więc mają zastosowanie do całego akapitu:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) kontroluje zasady łamania tekstu łacińskiego. W mieszanym tekście zmiana tej opcji może także zmienić miejsce, w którym otaczający tekst wschodnioazjatycki i interpunkcja się zawijają.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) kontroluje zasady łamania tekstu wschodnioazjatyckiego, w tym ograniczenia znaków na początku i końcu wiersza.

Te zasady nie zastępują [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText), które włącza automatyczne zawijanie w ramce tekstowej. Wpływają na układ, gdy zachodzi zawijanie; nie wstawiają znaków łamania wiersza. Jawne łamanie wiersza wymusza nową linię w akapicie niezależnie od dostępnej szerokości.

Poniższy, samodzielny przykład tworzy wąski blok tekstowy zawierający chiński i łaciński tekst. Ustawia oba opcje łamania wierszy explicite i zapisuje „line_breaking.pptx”. Aby eksperymentować z dowolną regułą, zmień odpowiednią wartość, pozostawiając drugie ustawienia bez zmian. Przykład używa Arial 24‑punktowego i SimSun przy szerokości ramki 160 punktów oraz zerowych poziomych marginesów ramki tekstowej. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) jest wywoływany z [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/), aby rozmiar tekstu i wymiary ramki pozostały stałe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontroluj zwieszanie interpunkcji**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) pozwala dopuszczalnej interpunkcji wystawać poza prawą krawędź linii tekstu zamiast zajmować następną linię. Dotyczy całego akapitu i różni się od wcięcia zwieszonego.

Poniższy, samodzielny przykład włącza zwieszanie interpunkcji w ramce tekstowej o szerokości 100 punktów i zapisuje „hanging_punctuation.pptx”. Przy Arial 24‑punktowym i zerowych poziomych marginesach ramki, kropka końcowa pozostaje po słowie „sentence” i wystaje poza prawą krawędź tekstu. Ustaw właściwość na [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/), aby porównać: przy tych ustawieniach kropka zajmuje osobną linię. Zawijanie jest włączone, a automatyczne dopasowanie wyłączone, aby zachować stałą dostępną szerokość.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nie każda znak interpunkcyjny może się zwiesić. [Warunki czcionki i układu opisane powyżej](#control-line-breaking) mają również zastosowanie do tego porównania: zmiana czcionki, dostępnej szerokości, marginesów lub ustawień automatycznego dopasowania może usunąć widoczną różnicę.

## **Ustaw typ automatycznego dopasowania dla ramek tekstowych**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst się kurczy, wypływa poza ramkę, czy automatycznie zmienia rozmiar kształtu. Poniższy przykład konfiguruje kształt tak, aby zmieniał rozmiar w celu dopasowania tekstu i zapisuje wynik jako „autofit_type.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby policzyć wiersze po automatycznym zawijaniu i zobaczyć, jak zmiana szerokości tekstu lub kształtu wpływa na wynik, zobacz [Count Rendered Lines](/slides/pl/python-java/manage-paragraph/). Samo liczenie wierszy nie wskazuje, czy tekst wypływa poza kontener.

## **Ustaw kotwicę ramek tekstowych**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. na górze, w środku lub na dole. Poniższy przykład kotwiczy tekst do dołu pierwszego kształtu i zapisuje wynik jako „text_anchor.pptx”.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw tabulację tekstu**

Użyj [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) i [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs), aby skonfigurować tabulatory w akapicie. Poniższy przykład ustawia domyślną odległość tabulacji na 100 punktów oraz dodaje tabulację wyrównaną do lewej w pozycji 30 punktów. Te ustawienia wpływają na tekst zawierający znaki tabulacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Wynik:

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId), który pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład wymaga „presentation.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie oraz co najmniej jednego akapitu. Zastępuje zawartość pierwszego akapitu tekstem „1。”, ustawia SimSun jako czcionkę i przypisuje język korekty chiński uproszczony (`zh-CN`). Zapisuje wynik jako „proofing_language.pptx”:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Ustaw Id języka korekty.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kopiuj metadane językowe**

Podczas kopiowania wielojęzycznego tekstu z szablonu zachowaj zarówno [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId), jak i [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Poniższy, samodzielny przykład tworzy fragment źródłowy z językiem amerykańskiego angielskiego i językiem francuskim jako językiem alternatywnym oraz kopiuje tekst i identyfikatory do fragmentu w nowej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Jeśli źródło nie ma języka alternatywnego, None czyści wartość docelową.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aby wypróbować źródło bez języka alternatywnego, pomiń przypisanie „fr-FR”. Alternatywny identyfikator będzie wtedy `None`, a to samo polecenie kopiowania zachowuje jego brak bez wprowadzania wartości domyślnej, nawet jeśli miejsce docelowe wcześniej miało przypisany język alternatywny.

Te identyfikatory przechowują metadane językowe. Zachowanie ich nie ustala, który słownik PowerPoint wybierze do sprawdzania pisowni lub gramatyki.

## **Ustaw domyślny język**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage), aby określić domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji. Poniższy przykład tworzy prezentację z domyślnym językiem tekstu amerykański angielski, dodaje pole tekstowe i wypisuje `en-US` dla pierwszego fragmentu tekstu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt prostokątny z tekstem.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Sprawdź język pierwszego fragmentu.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Poniższy przykład ustawia czcionkę 14‑punktową pogrubioną jako domyślną dla akapitów najwyższego poziomu w nowej prezentacji i zapisuje ją jako „default_text_style.pptx”. Tekst może dziedziczyć te wartości domyślne, chyba że bardziej szczegółowe formatowanie je nadpisze.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Pobierz format akapitu najwyższego poziomu.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint zastosowanie efektu **All Caps** sprawia, że tekst wyświetlany jest wielkimi literami na slajdzie, nawet jeśli został wpisany małymi literami. Kiedy pobierasz taki fragment tekstu przy pomocy Aspose.Slides, biblioteka zwraca dokładnie taki tekst, jaki został wprowadzony. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) i zamień zwrócony ciąg na wielkie litery, gdy wartość to `All`.

Ten przykład wymaga „sample2.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Jego pierwszy akapit, pierwszy fragment zawiera „Hello, Aspose!” z zastosowanym efektem All Caps, jak pokazano poniżej.

![Efekt All Caps](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Przeglądaj komórki i aktualizuj każdą komórkę poprzez [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) oraz formatowanie akapitu poprzez [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak zastosować gradientowy kolor do tekstu na slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat). Ustaw [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.