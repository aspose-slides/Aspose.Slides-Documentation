---
title: Zarządzaj motywami prezentacji PowerPoint w Pythonie
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/python-net/presentation-theme/
keywords:
- Motyw PowerPoint
- Motyw prezentacji
- Motyw slajdu
- Ustaw motyw
- Zmień motyw
- Zarządzaj motywem
- Kolor motywu
- Dodatkowa paleta
- Czcionka motywu
- Styl motywu
- Efekt motywu
- PowerPoint
- Prezentacja
- Python
- Aspose.Slides
description: "Opanuj motywy prezentacji w Aspose.Slides dla Pythona poprzez .NET, aby tworzyć, dostosowywać i konwertować pliki PowerPoint zachowując spójną identyfikację wizualną."
---
## **Wprowadzenie**

Motyw prezentacji definiuje właściwości jej elementów projektowych. Wybierając motyw, wybierasz skoordynowany zestaw elementów wizualnych i ich właściwości.

W programie PowerPoint motyw zawiera kolory, [czcionki](/slides/pl/python-net/powerpoint-fonts/), [style tła](/slides/pl/python-net/presentation-background/), oraz efekty.

![theme-constituents](theme-constituents.png)

## **Zmień kolor motywu**

Motyw PowerPoint używa określonego zestawu kolorów dla różnych elementów na slajdzie. Jeśli domyślne ustawienia Ci nie odpowiadają, możesz je zmienić, stosując nowe kolory motywu. Aby umożliwić wybór nowego koloru motywu, Aspose.Slides udostępnia wartości w wyliczeniu [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/).

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Możesz określić efektywną wartość uzyskanego koloru w następujący sposób:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Przykładowe wyjście:
#
# ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

Aby dodatkowo zademonstrować zmianę koloru, tworzymy inny element, przypisujemy mu kolor akcentu z pierwszego kroku, a następnie aktualizujemy kolor motywu.

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Nowy kolor jest automatycznie stosowany do obu elementów.

### **Ustaw kolor motywu z dodatkowej palety**

Gdy stosujesz przekształcenia luminancji do głównego koloru motywu (1), generowane są kolory z dodatkowej palety (2). Następnie możesz ustawiać i pobierać te kolory motywu.

![additional-palette-colors](additional-palette-colors.png)

**1** — Główne kolory motywu

**2** — Kolory z dodatkowej palety

Ten kod w języku Python pokazuje, jak kolory z dodatkowej palety są wyprowadzane z głównego koloru motywu i następnie używane w kształtach:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Akcent 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Akcent 4, jaśniejszy 80%
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Akcent 4, jaśniejszy 60%
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Akcent 4, jaśniejszy 40%
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Akcent 4, ciemniejszy 25%
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Akcent 4, ciemniejszy 50%
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **Mapowanie `SchemeColor` na kolory `ColorScheme`**

Podczas pracy z [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/), możesz zauważyć, że zawiera następujące wartości kolorów motywu:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1`, i `TEXT2`.

Jednak `Presentation.master_theme.color_scheme` zwraca [ColorScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/colorscheme/), który udostępnia odpowiadające kolory jako:

`dark1`, `dark2`, `light1`, i `light2`.

Różnica ta dotyczy wyłącznie nazewnictwa. Te wartości odnoszą się do tych samych slotów kolorów motywu, a mapowanie jest stałe:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Nie ma dynamicznej konwersji pomiędzy `TEXT`/`BACKGROUND` a `dark`/`light`. Są to po prostu alternatywne nazwy tych samych kolorów motywu.

Różnica w nazewnictwie wynika z terminologii Microsoft Office. Starsze wersje Office używały `Dark 1`, `Light 1`, `Dark 2` i `Light 2`, natomiast nowsze wersje interfejsu wyświetlają te same sloty jako `Text 1`, `Background 1`, `Text 2` i `Background 2`.

## **Zmień czcionkę motywu**

Aby umożliwić wybór czcionek dla motywów i innych celów, Aspose.Slides używa następujących specjalnych identyfikatorów (podobnych do tych w PowerPoint):

- **+mn-lt** — Czcionka tekstu głównego łacińska (Minor Latin Font)
- **+mj-lt** — Czcionka nagłówka łacińska (Major Latin Font)
- **+mn-ea** — Czcionka ciała wschodnioazjatycka (Minor East Asian Font)
- **+mj-ea** — Czcionka nagłówka wschodnioazjatycka (Major East Asian Font)

Ten kod w Pythonie pokazuje, jak przypisać czcionkę łacińską do elementu motywu:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Ten przykład w Pythonie pokazuje, jak zmienić czcionkę motywu prezentacji:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Wszystkie pola tekstowe zostaną zaktualizowane do nowej czcionki.

{{% alert color="primary" title="Wskazówka" %}}
Aby uzyskać więcej informacji, zobacz [Główne czcionki PowerPoint w Pythonie](/slides/pl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Zmień styl tła motywu**

Domyślnie PowerPoint udostępnia 12 wstępnie zdefiniowanych teł, ale typowa prezentacja przechowuje tylko 3 z nich.

![todo:image_alt_text](presentation-design_8.png)

Na przykład, po zapisaniu prezentacji w PowerPoint, możesz uruchomić poniższy kod w Pythonie, aby określić, ile wstępnie zdefiniowanych teł zawiera:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
Używając właściwości `background_fill_styles` z klasy [FormatScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/), możesz dodawać lub uzyskiwać dostęp do stylów tła w motywie PowerPoint.
{{% /alert %}}

Ten przykład w Pythonie pokazuje, jak ustawić tło prezentacji:

```python
presentation.masters[0].background.style_index = 2  # 0 oznacza brak wypełnienia; indeksowanie zaczyna się od 1.
```

{{% alert color="primary" title="Wskazówka" %}}
Aby uzyskać więcej informacji, zobacz [Zarządzanie tłami prezentacji w Pythonie](/slides/pl/python-net/presentation-background/).
{{% /alert %}}

## **Zmień efekty motywu**

Motyw PowerPoint zazwyczaj zawiera trzy wartości w każdej tablicy stylów. Tablice te łączą się w trzy poziomy efektów: subtelny, umiarkowany i intensywny. Na przykład, oto wynik, gdy te efekty zostaną zastosowane do konkretnego kształtu:

![todo:image_alt_text](presentation-design_10.png)

Korzystając z trzech właściwości — `FillStyles`, `LineStyles` i `EffectStyles` — z klasy [FormatScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/), możesz modyfikować elementy motywu (nawet bardziej elastycznie niż w PowerPoint).

Ten kod w Pythonie pokazuje, jak zmienić efekt motywu, modyfikując części tych elementów:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Powstałe zmiany obejmują aktualizacje koloru wypełnienia, typu wypełnienia, efektu cienia oraz innych właściwości:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Aspose.Slides obsługuje nadpisywanie motywu na poziomie slajdu, więc możesz zastosować lokalny motyw tylko do tego slajdu, zachowując niezmieniony motyw master (przez [SlideThemeManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/slidethememanager/)).

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

[Klonuj slajdy](/slides/pl/python-net/clone-slides/) wraz z ich masterem do docelowej prezentacji. Zachowuje to pierwotny master, układy i powiązany motyw, dzięki czemu wygląd pozostaje spójny.

**Jak mogę zobaczyć „efektywne” wartości po wszystkich dziedziczeniach i nadpisaniach?**

Użyj widoków ["efektywne" widoki](/slides/pl/python-net/shape-effective-properties/) dla motywu/koloru/czcionki/efektu. Zwracają one rozwiązane, ostateczne właściwości po zastosowaniu mastera oraz wszelkich lokalnych nadpisań.