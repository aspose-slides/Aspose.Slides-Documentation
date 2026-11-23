---
title: Formatowanie tekstu prezentacji w Pythonie
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/python-net/text-formatting/
keywords:
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstęp między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstęp między wierszami
- właściwość autofit
- zakotwienie ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez .NET. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Pythona poprzez .NET. Omówione są kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy między akapitami, zachowanie autofit, zakotwienie tekstu, tabulatory i ustawienia języka.

O ile nie zaznaczono inaczej, przykłady używają [sample.pptx](sample.pptx). Pierwszy kształt na pierwszym slajdzie jest polem tekstowym, a jego pierwszy akapit zawiera tekst pokazany poniżej. Indeksy slajdów i kształtów są zerowe. Przykłady wybierające pogrubione fragmenty używają efektywnego formatowania, w tym dziedziczonego pogrubienia:

![Przykładowy tekst](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/python-net/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) aby ustawić domyślny kolor podświetlenia dla akapitu lub użyj [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) dla poszczególnych fragmentów tekstu.

Poniższy przykład ustawia jasnoszare podświetlenie jako domyślne dla pierwszego akapitu. Jawne kolory podświetlenia w poszczególnych fragmentach mają pierwszeństwo przed tym domyślnym:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana, itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ustaw wyrównanie akapitu na środku.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Wyrównaj czcionki w linii**

Użyj [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) aby pionowo wyrównać fragmenty tekstu o różnych rozmiarach czcionki w jednej linii. To ustawienie dotyczy całego akapitu i kontroluje wyrównanie w każdej jego linii.

Poniższy samodzielny przykład tworzy cztery oznaczone pola tekstowe na jednym slajdzie. Każdy akapit zawiera ten sam tekst w rozmiarach 18, 36 i 54 punktów, z innym wyrównaniem czcionki. Używa Arial, wyłącza autofit i zawijanie oraz utrzymuje ramki tekstowe wystarczająco duże dla jednej linii.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Porównanie wyrównania czcionki: podstawa, góra, środek i dół przy mieszanych rozmiarach czcionki](font_alignment.png)

Wyrównanie czcionki korzysta z metryk czcionki, więc widoczne krawędzie poszczególnych liter nie muszą idealnie się pokrywać. Przykład zawiera zarówno wielką literę, jak i znak z obcięciem, aby pokazać różnicę między wyrównaniem do linii bazowej a do dołu. Dostępność czcionek i ich zamiana, użyte znaki oraz różnica w rozmiarach czcionek wpływają na rezultat. Wymiary ramki, marginesy, odstępy między wierszami, zawijanie i autofit także wpływają na układ; przy porównywaniu trybów używaj tych samych czcionek i ustawień układu.

To ustawienie różni się od [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), które kontroluje poziome wyrównanie akapitu, oraz od [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/), które pozycjonuje blok tekstowy pionowo w jego kształcie. Formatowanie indeksu górnego i dolnego za pomocą [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) przesuwa poszczególne fragmenty względem linii bazowej zamiast ustawiać wyrównanie czcionki dla linii akapitu.

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). W poniższych przykładach `alpha = 50` to wartość alfa ARGB w skali 0–255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ustaw półprzezroczyste czarne wypełnienie dla tekstu.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ustaw przezroczystość fragmentu tekstu.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstępy znaków w tekście**

Użyj [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) aby rozszerzyć lub skurczyć odstępy między znakami w polu tekstowym. Przykłady dodają 3 punkty odstępu; wartości ujemne skurczają tekst.

Poniższy kod Pythona pokazuje, jak rozszerzyć odstępy znaków w **całym akapicie**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Rozszerz odstępy znaków.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Odstępy znaków w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak rozszerzyć odstępy znaków w **fragmentach tekstu z pogrubioną czcionką**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Uwaga: użyj wartości ujemnych, aby skompresować odstępy między znakami.
            portion.portion_format.spacing = 3  # Rozszerz odstępy znaków.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Odstępy znaków w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla konkretnych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Dzieje się tak, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPointa.

Aby w takich przypadkach uzyskać wynik bliższy PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) na wartość większą niż rzeczywisty rozmiar czcionki. Ten przykład wymaga pliku „presentation.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Sprawdza efektywne nazwy czcionek, w tym dziedziczone, i ustawia próg 100 punktów dla fragmentów używających Roboto. To wyłącza kerning dla dopasowanych fragmentów o rozmiarze czcionki poniżej 100 punktów:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Dla dopasowanego tekstu poniżej progu to ustawienie zapobiega kerningowi i może pomóc wyrównać renderowanie Aspose.Slides z wizualnym wynikiem PowerPointa dla czcionek dotkniętych tym specyficznym zachowaniem PowerPointa.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu poprzez [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) lub na poszczególnych fragmentach poprzez [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/).

Poniższy przykład ustawia domyślną czcionkę pierwszego akapitu na Times New Roman 12‑punktowy z pogrubieniem, kursywą i kreską kreskowaną. Jawne formatowanie poszczególnych fragmentów ma pierwszeństwo przed tymi domyślnymi.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Ustaw właściwości czcionki dla akapitu.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład stosuje Times New Roman 13 punktów, kursywę i kreskę kreskowaną do fragmentów, których efektywne formatowanie jest pogrubione:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Ustaw właściwości czcionki dla fragmentu tekstu.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Kontroluj normalizację wysokości tekstu**

Użyj [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) podczas odtwarzania typografii szablonu lub analizowania różnic w wysokości znaków. W PowerPoint włączenie normalizacji rozciąga lub kompresuje poszczególne znaki pionowo, aby uzyskać jednolitą widoczną wysokość w obrębie fragmentu tekstu. Nie gwarantuje to jednak równej wysokości tekstu między różnymi czcionkami.

Ustaw właściwość na [NullableBool.TRUE lub FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), aby explicite włączyć lub wyłączyć normalizację. `NullableBool.NOT_DEFINED` pozostawia lokalne ustawienie nieustawione, dzięki czemu fragment dziedziczy wartość, np. z [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) akapitu. To nie oznacza `False`. Użyj [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) i odczytaj [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/), aby uzyskać rozwiązany wartość boolowską.

Poniższy samodzielny przykład wymaga zainstalowanego **Arial**. Tworzy dwa bloki tekstu zawierające te same wielkie litery, małe litery, znaki opadające i znaki diakrytyczne w rozmiarze 54 punkty. Oba akapity domyślnie włączają normalizację. Górny fragment wyraźnie ją wyłącza; dolny ją dziedziczy. Rozmiary ramek, marginesy i odstępy akapitu są identyczne, a zawijanie i autofit są wyłączone, aby zachować spójność porównania. Przykład wypisuje `FALSE: False` i `NOT_DEFINED: True`, a następnie zapisuje „text_height_normalization.pptx”.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Porównanie poniżej zostało wyeksportowane z zapisanego prezentacji. Górny wiersz ma wyłączoną normalizację (`FALSE`); dolny wiersz dziedziczy włączone ustawienie (`NOT_DEFINED` → `True`). Aby odtworzyć ten wygląd, pozostaw zainstalowany Arial.

![Tekst Arial 54‑punktowy z wyłączoną normalizacją powyżej i dziedziczoną włączoną poniżej](text_height_normalization.png)

Normalizacja zmienia wysokość znaków bez zmiany przypisanej wartości [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/), która określa rozmiar czcionki w punktach. [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) akapitu kontroluje odstęp między wierszami, natomiast [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) formatu ramki tekstu steruje tym, jak tekst lub jego pojemnik dostosowuje się do rozmiaru. Te ustawienia służą różnym celom i mogą niezależnie wpływać na ogólny układ. Po więcej informacji o formatowaniu akapitów i dziedziczeniu zobacz [Manage Paragraph](/slides/pl/python-net/manage-paragraph/).

## **Zastosuj i usuń przekreślenie**

Użyj [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) na fragmencie tekstu, aby wyświetlić korekty, anulowane terminy lub poprzednie ceny bez usuwania oryginalnego tekstu. Ustaw na [TextStrikethroughType.SINGLE lub DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/), aby uzyskać jedną lub dwie linie przekreślenia.

Aby usunąć przekreślenie, przypisz `TextStrikethroughType.NONE`. To wyraźnie wyłącza efekt, nawet jeśli otaczające formatowanie określa przekreślenie. Natomiast `TextStrikethroughType.NOT_DEFINED` pozostawia lokalne ustawienie niezdefiniowane, co pozwala fragmentowi dziedziczyć formatowanie, np. z akapitu. Nie gwarantuje to usunięcia przekreślenia. Użyj [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), aby odczytać wynikowe formatowanie, w tym wartości dziedziczone.

Poniższy samodzielny przykład tworzy trzy porównania cen. Każdy akapit ma osobne fragmenty dla etykiety, poprzedniej ceny i bieżącej ceny, więc tylko poprzednia cena jest objęta przekreśleniem. W pierwszym wierszu przekreślenie jest zastosowane, a następnie usunięte; pozostałe wiersze zachowują pojedyncze i podwójne przekreślenie. Zmiana tej właściwości zachowuje tekst i jego inne formatowanie, w tym pogrubioną poprzednią cenę.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Zastosuj przekreślenie, a następnie wyraźnie usuń je z pierwszej poprzedniej ceny.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Wynik, od góry do dołu: bez przekreślenia, pojedyncze przekreślenie i podwójne przekreślenie.

![Poprzednie ceny bez przekreślenia, z pojedynczym przekreśleniem i z podwójnym przekreśleniem](strikethrough.png)

## **Ustaw obrót tekstu**

Użyj [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) aby ustawić predefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/), co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Wyświetl cyfry obok siebie w pionowym tekście**

Aby dwucyfrową liczbę utrzymać razem w pionowej japońskiej etykiecie, umieść oba cyfry w jednym fragmencie tekstu i ustaw [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) na tym fragmencie. Przykład tworzy dwie etykiety w nowej prezentacji przy użyciu [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) i czcionki MS Gothic 40 punktów. Jedyna różnica to wartość [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) przypisana do cyfrowego fragmentu.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

W PowerPoint po lewej etykiecie (`TRUE`) cyfry są pionowo ustawione obok siebie między znakami 和 i 年. Po prawej etykiecie (`FALSE`) para jest obrócona o 90 stopni zgodnie z ruchem wskazówek zegara. Otaczające znaki japońskie pozostają pionowe w obu etykietach.

![Porównanie etykiet dat pionowych w PowerPoint: cyfry pionowo po lewej i obrócone po prawej.](vertical_date.png)

## **Ustaw niestandardowy obrót ramki tekstowej**

Użyj [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) aby ustawić własny kąt obrotu dla [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w kształcie:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw odstępy wierszy w akapitach**

Aspose.Slides udostępnia [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) i [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/), aby kontrolować odstępy akapitów. Właściwości te stosuje się w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp wierszy jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp w punktach.

Poniższy przykład ustawia odstęp wewnątrz pierwszego akapitu na 200 % wysokości wiersza (podwójny odstęp):

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Odstęp wierszy w akapicie](line_spacing.png)

## **Kontroluj łamanie linii**

Reguły łamania linii w akapicie są przydatne w wąskich blokach tekstu i prezentacjach, które łączą tekst łaciński i wschodnioazjatycki. Poniższe właściwości należą do [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/), więc dotyczą całego akapitu:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) steruje regułami łamania linii łacińskich. W mieszanym tekście zmiana tej opcji może także zmienić miejsce, w którym otaczający tekst wschodnioazjatycki i interpunkcja się zawijają.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) steruje regułami łamania linii wschodnioazjatyckich, w tym ograniczeniami znaków na początku i końcu wiersza.

Te reguły nie zastępują [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/), które włącza automatyczne zawijanie w ramce tekstowej. Wpływają na układ, gdy zawijanie następuje; nie wstawiają znaków końca linii. Jawne wymuszenie nowej linii powoduje nowy wiersz w akapicie niezależnie od dostępnej szerokości.

Poniższy samodzielny przykład tworzy wąski blok tekstu zawierający chiński i łaciński tekst. Ustawia oba właściwości łamania linii explicite i zapisuje „line_breaking.pptx”. Aby eksperymentować z dowolną regułą, zmień wartość tej właściwości, pozostawiając drugą niezmienioną. Przykład używa Arial 24 punkty i SimSun przy szerokości ramki 160 punktów oraz zerowych poziomych marginesów ramki tekstowej. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) jest ustawione na [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/), aby rozmiar tekstu i wymiary ramki pozostały stałe.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontroluj wieszające interpunkcje**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) pozwala dopuszczalnym znakom interpunkcyjnym wystawać poza prawą krawędź linii tekstu zamiast zajmować następną linię. Ma zastosowanie do całego akapitu i różni się od wieszającego wcięcia.

Poniższy samodzielny przykład włącza wieszającą interpunkcję w ramce tekstowej o szerokości 100 punktów i zapisuje „hanging_punctuation.pptx”. Przy Arial 24 punkty i zerowych poziomych marginesach ramki tekstowej, końcowa kropka pozostaje po słowie „sentence” i wystaje poza prawą krawędź tekstu. Ustaw właściwość na [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), aby porównać: przy tych ustawieniach kropka zajmuje osobną linię. Zawijanie jest włączone, a autofit wyłączony, aby utrzymać stałą dostępną szerokość.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Nie każda znak interpunkcyjny może wisieć. Widoczny rezultat zależy od [warunków czcionki i układu](#control-line-breaking): zmiana czcionki, dostępnej szerokości, marginesów lub ustawień autofit może usunąć widoczną różnicę.

## **Ustaw typ autofit dla ramek tekstowych**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) określa, jak tekst zachowuje się, gdy przekracza granice swojego pojemnika. Użyj go, aby kontrolować, czy tekst się zmniejsza, przelewa, czy automatycznie zmienia rozmiar kształtu. Poniższy przykład konfiguruje kształt tak, aby zmieniał rozmiar w celu dopasowania tekstu i zapisuje wynik jako „autofit_type.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Aby policzyć wiersze po automatycznym zawijaniu i zobaczyć, jak zmiana szerokości tekstu lub kształtu wpływa na wynik, zobacz [Count Rendered Lines](/slides/pl/python-net/manage-paragraph/). Samej liczby wierszy nie wystarczy, aby określić, czy tekst przelewa się poza pojemnik.

## **Ustaw zakotwienie ramek tekstowych**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. u góry, w środku lub na dole. Poniższy przykład zakotwicza tekst na dole pierwszego kształtu i zapisuje wynik jako „text_anchor.pptx”.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Ustaw tabulację tekstu**

Użyj [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) i [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) aby skonfigurować tabulatory w akapicie. Poniższy przykład ustawia domyślny odstęp tabulacji na 100 punktów i dodaje lewostronny tabulator przy 30 punktach. Te ustawienia wpływają na tekst zawierający znaki tabulacji.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustaw język proofingu**

Aspose.Slides udostępnia [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), który pozwala ustawić język proofingu dla fragmentu tekstu. Język proofingu określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład wymaga pliku „presentation.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie i przynajmniej jednego akapitu. Zastępuje zawartość pierwszego akapitu tekstem „1。”, ustawia SimSun jako czcionkę i przypisuje język proofingu Chiński uproszczony (`zh-CN`). Zapisuje wynik jako „proofing_language.pptx”:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Ustaw język proofingu na chiński uproszczony.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Kopiuj metadane językowe**

Podczas kopiowania tekstu wielojęzycznego z szablonu zachowaj zarówno [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/), jak i [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/). Poniższy samodzielny przykład tworzy fragment źródłowy z językiem US English i językiem alternatywnym French i kopiuje tekst oraz identyfikatory do fragmentu w nowej prezentacji.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Jeśli źródło nie ma języka alternatywnego, None usuwa wartość w docelowym.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Aby wypróbować źródło bez języka alternatywnego, pomiń przypisanie `"fr-FR"`. Alternatywny identyfikator będzie wtedy `None`, a to samo polecenie kopii zachowa jego brak bez wprowadzania wartości domyślnej, nawet jeśli docelowy fragment wcześniej miał przypisany język alternatywny.

Te identyfikatory przechowują metadane językowe. Zachowanie ich nie ustala, którego słownika PowerPoint wybierze do sprawdzania pisowni lub gramatyki.

## **Ustaw domyślny język**

Użyj [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/), aby określić domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji. Poniższy przykład tworzy prezentację z domyślnym językiem tekstu US English, dodaje pole tekstowe i wypisuje `en-US` dla jego pierwszego fragmentu tekstu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Dodaj nowy prostokątny kształt z tekstem.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Sprawdź język pierwszego fragmentu.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/).

Poniższy przykład ustawia czcionkę 14‑punktową pogrubioną jako domyślną dla akapitów najwyższego poziomu w nowej prezentacji i zapisuje ją jako „default_text_style.pptx”. Tekst może dziedziczyć te ustawienia, chyba że bardziej szczegółowe formatowanie je nadpisze.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Pobierz format akapitu najwyższego poziomu.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint zastosowanie efektu czcionki **All Caps** powoduje, że tekst wyświetlany jest wielkimi literami na slajdzie, nawet jeśli został wpisany małymi. Gdy pobierasz taki fragment tekstu za pomocą Aspose.Slides, biblioteka zwraca tekst dokładnie tak, jak został wprowadzony. Aby dopasować go do wyświetlanej wersji, sprawdź [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) i zamień zwrócony ciąg na wielkie litery, gdy wartość to `ALL`.

Przykład wymaga pliku „sample2.pptx” z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Jego pierwszy akapit, pierwszy fragment zawiera „Hello, Aspose!” z zastosowanym efektem All Caps, jak pokazano poniżej.

![Efekt All Caps](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/). Iteruj przez komórki i aktualizuj każdą komórkę za pomocą [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) oraz formatowanie akapitu przez [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/).

**Jak zastosować gradientowy kolor do tekstu na slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/). Ustaw [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) na [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.

Powiązana funkcja: [Format text within slides](/slides/pl/features/text-formatting/).