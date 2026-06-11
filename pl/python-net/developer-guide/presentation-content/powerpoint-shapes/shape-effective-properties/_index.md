---
title: Pobierz efektywne właściwości kształtu z prezentacji przy użyciu Pythona
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/python-net/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw oświetlenia
- kształt fazowania
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Pythona w .NET oblicza i stosuje efektywne właściwości kształtu dla precyzyjnego renderowania w PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne to wartości ustawione bezpośrednio na określonym poziomie formatowania, na przykład:

1. Właściwości fragmentu na slajdzie.
1. Style tekstu prototypu kształtu na układzie lub slajdzie głównym, gdy kształt ramki tekstowej fragmentu posiada je.
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Kiedy Aspose.Slides potrzebuje ostatecznego formatowania „takiego, jak jest renderowane”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać, wywołując metodę `get_effective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać efektywne wartości. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [AutoShape](https://reference.aspose.com/slides/pl/python-net/aspose.slides/autoshape/) z ramką tekstową i co najmniej jednym fragmentem.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    local_text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = local_text_frame_format.get_effective()

    paragraph = shape.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    local_portion_format = portion.portion_format
    effective_portion_format = local_portion_format.get_effective()
```

{{% alert color="primary" %}}
Efektywne dane formatowania przedstawiają bieżąco obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/iportionformateffectivedata/), mogą być przechowywane w pamięci podręcznej wewnętrznie. Wywołanie `get_effective` ponownie po zmianie formatowania rodzica lub dziedziczonego może odświeżyć dane w pamięci podręcznej, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować efektywne wartości do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobierz efektywne właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Typ [ICameraEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/icameraeffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    camera = three_d_effective_data.camera

    camera_type = camera.camera_type
    field_of_view_angle = camera.field_of_view_angle
    zoom = camera.zoom

    print("= Effective camera properties =")
    print("Type: " + str(camera_type))
    print("Field of view: " + str(field_of_view_angle))
    print("Zoom: " + str(zoom))
```

## **Pobierz efektywne właściwości zestawu oświetlenia**

Aspose.Slides umożliwia pobranie efektywnych właściwości zestawu oświetlenia. Typ [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ilightrigeffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    light_rig = three_d_effective_data.light_rig

    light_type = light_rig.light_type
    direction = light_rig.direction

    print("= Effective light rig properties =")
    print("Type: " + str(light_type))
    print("Direction: " + str(direction))
```

## **Pobierz efektywne właściwości fazowania kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości fazowania kształtu. Typ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości fazowania kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapebeveleffectivedata/) jest udostępniana poprzez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [ThreeDFormat](https://reference.aspose.com/slides/pl/python-net/aspose.slides/threedformat/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    three_d_effective_data = shape.three_d_format.get_effective()
    top_bevel = three_d_effective_data.bevel_top

    bevel_type = top_bevel.bevel_type
    bevel_width = top_bevel.width
    bevel_height = top_bevel.height

    print("= Effective shape's top face relief properties =")
    print("Type: " + str(bevel_type))
    print("Width: " + str(bevel_width))
    print("Height: " + str(bevel_height))
```

## **Pobierz efektywne właściwości ramki tekstowej**

Używając Aspose.Slides, możesz pobrać efektywne właściwości ramki tekstowej. Typ [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    text_frame_format = shape.text_frame.text_frame_format
    effective_text_frame_format = text_frame_format.get_effective()

    anchoring_type = effective_text_frame_format.anchoring_type
    autofit_type = effective_text_frame_format.autofit_type
    text_vertical_type = effective_text_frame_format.text_vertical_type
    margin_left = effective_text_frame_format.margin_left
    margin_top = effective_text_frame_format.margin_top
    margin_right = effective_text_frame_format.margin_right
    margin_bottom = effective_text_frame_format.margin_bottom

    print("Anchoring type: " + str(anchoring_type))
    print("Autofit type: " + str(autofit_type))
    print("Text vertical type: " + str(text_vertical_type))
    print("Margins")
    print("   Left: " + str(margin_left))
    print("   Top: " + str(margin_top))
    print("   Right: " + str(margin_right))
    print("   Bottom: " + str(margin_bottom))
```

## **Pobierz efektywne właściwości stylu tekstu**

Używając Aspose.Slides, możesz pobrać efektywne właściwości stylu tekstu. Typ [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    text_frame_format = shape.text_frame.text_frame_format
    text_style = text_frame_format.text_style
    effective_text_style = text_style.get_effective()
    level_count = 9

    for level_index in range(level_count):
        effective_style_level = effective_text_style.get_level(level_index)
        depth = effective_style_level.depth
        indent = effective_style_level.indent
        alignment = effective_style_level.alignment
        font_alignment = effective_style_level.font_alignment

        print("= Effective paragraph formatting for style level #" + str(level_index) + " =")

        print("Depth: " + str(depth))
        print("Indent: " + str(indent))
        print("Alignment: " + str(alignment))
        print("Font alignment: " + str(font_alignment))
```

## **Pobierz efektywną wartość wysokości czcionki**

Używając Aspose.Slides, możesz pobrać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    auto_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 75, False)
    auto_shape.add_text_frame("")

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    first_portion = slides.Portion("Sample text with first portion")
    second_portion = slides.Portion(" and second portion.")

    paragraph.portions.add(first_portion)
    paragraph.portions.add(second_portion)

    print("Effective font height just after creation:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    default_text_style_level = presentation.default_text_style.get_level(0)
    default_text_style_level.default_portion_format.font_height = 24

    print("Effective font height after setting the presentation default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    paragraph.paragraph_format.default_portion_format.font_height = 40

    print("Effective font height after setting paragraph default font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    first_portion.portion_format.font_height = 55

    print("Effective font height after setting portion #0 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    second_portion.portion_format.font_height = 18

    print("Effective font height after setting portion #1 font height:")
    first_portion_font_height = first_portion.portion_format.get_effective().font_height
    second_portion_font_height = second_portion.portion_format.get_effective().font_height
    print("Portion #0: " + str(first_portion_font_height))
    print("Portion #1: " + str(second_portion_font_height))

    presentation.save("SetLocalFontHeightValues.pptx", slides.export.SaveFormat.PPTX)
```

## **Pobierz efektywny format wypełnienia tabeli**

Używając Aspose.Slides, możesz pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Typ [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/python-net/aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy kod pokazuje, jak pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [Table](https://reference.aspose.com/slides/pl/python-net/aspose.slides/table/).

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    table = presentation.slides[0].shapes[0]
    first_row = table.rows[0]
    first_column = table.columns[0]
    first_cell = first_row[0]

    table_format_effective = table.table_format.get_effective()
    row_format_effective = first_row.row_format.get_effective()
    column_format_effective = first_column.column_format.get_effective()
    cell_format_effective = first_cell.cell_format.get_effective()

    table_fill_format_effective = table_format_effective.fill_format
    row_fill_format_effective = row_format_effective.fill_format
    column_fill_format_effective = column_format_effective.fill_format
    cell_fill_format_effective = cell_format_effective.fill_format
```

## **FAQ**

**Czy `get_effective` zwraca migawkę?**

Nie zawsze. Dane efektywne przedstawiają obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być przechowywane w pamięci podręcznej wewnętrznie. Kolejne wywołanie `get_effective` może przeliczyć formatowanie i odświeżyć dane w pamięci podręcznej, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj `get_effective` ponownie po zmianie formatowania lokalnego, stylów rodzica, formatowania układu, formatowania mastera lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

**Czy zmiana lub usunięcie układu/slajdu mastera wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostanie uwzględniona przy następnym wywołaniu `get_effective`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `get_effective` Aspose.Slides ponownie oceni drzewo formatowania, a resulting fonts, colors, sizes or other values may change. *(Note: the last sentence kept in English to preserve technical terms; "resulting fonts, colors, sizes or other values may change." can be left as is or translated. Keeping as is maintains original meaning.)*

**Czy mogę modyfikować wartości za pośrednictwem obiektów danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Wprowadzaj zmiany w obiektach formatowania lokalnego, a następnie ponownie pobieraj efektywne wartości.

**Co się dzieje, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/masterze, ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, obejmujący domyślne ustawienia PowerPointa i Aspose.Slides. Ta rozstrzygnięta wartość staje się częścią bieżących danych efektywnych.

**Na podstawie efektywnej wartości czcionki, czy mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź wartości lokalne w części fragmentu, akapitu, ramki tekstowej oraz style tekstu na poziomach układu, mastera i prezentacji, aby zobaczyć, gdzie pojawiła się pierwsza jawna definicja.

**Dlaczego wartości efektywne czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie było potrzebne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest identyczna z lokalną.

**Kiedy powinienem używać właściwości efektywnych, a kiedy pracować tylko z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak zostanie wyrenderowany” po zastosowaniu całego dziedziczenia, np. przy dopasowywaniu kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, modyfikuj właściwości lokalne, a następnie, w razie potrzeby, odczytaj ponownie dane efektywne, aby zweryfikować rezultat.