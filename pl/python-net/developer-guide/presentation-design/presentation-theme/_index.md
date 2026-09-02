---
title: Zarządzanie motywami prezentacji PowerPoint w Pythonie
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
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj tematy prezentacji w Aspose.Slides dla Pythona poprzez .NET, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, więc zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji dostępny jest przez właściwość [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przy użyciu [MasterThemeManager.override_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/masterthememanager/override_theme/), układ może nadpisać dziedziczony motyw przy użyciu [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny motyw slajdu jest ustalany w łańcuchu dziedziczenia: motyw prezentacji, nadpisanie master, nadpisanie układu i nadpisanie slajdu.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub stosowanie motywu, aktualizacja stylów tła i efektów oraz odczytywanie skutecznych wartości po rozwiązywaniu dziedziczenia i nadpisań.

## **Przeglądanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/) udostępnia właściwości [color_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/font_scheme/) i [format_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/format_scheme/). Przeglądanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i podaje, ile stylów tła, wypełnień, linii i efektów jest zapisanych w motywie:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme
    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Przeglądnij master powiązany ze slajdem i użyj przepływu pracy ze skutecznym motywem, pokazanego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/colorscheme/) motywu, wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną przeliczone na nową wartość. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

Poniższy przykład end‑to‑end tworzy kształt używający `ACCENT4`, zmienia kolor motywu `accent4` na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    presentation.master_theme.color_scheme.accent4.color = draw.Color.red
    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Ponieważ prostokąt pozostaje powiązany z `ACCENT4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor na kształcie, późniejsze zmiany `accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje przez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Główne kolory motywu.

**2** - Jaśniejsze i ciemniejsze warianty wygenerowane z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `ACCENT4`, stosuje transformacje luminancji do pięciu z nich i zapisuje wynik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)
    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Te warianty pozostają oparte na kolorze motywu. Jeśli `accent4` zmieni się później, przekształcone kolory zostaną ponownie obliczone z nowej wartości `accent4`.

### **Mapowanie wartości `SchemeColor` na sloty `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/) używa `TEXT1`, `BACKGROUND1`, `TEXT2` i `BACKGROUND2`, podczas gdy [ColorScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/colorscheme/) udostępnia te same sloty motywu jako `dark1`, `light1`, `dark2` i `light2`. Mapowanie jest stałe:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw czcionek pomocniczych dla tekstu podstawowego. Właściwości [FontScheme.major](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/major/) i [FontScheme.minor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` - Body Font Latin (Minor Latin Font)
* `+mj-lt` - Heading Font Latin (Major Latin Font)
* `+mn-ea` - Body Font East Asian (Minor East Asian Font)
* `+mj-ea` - Heading Font East Asian (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki łacińskiej motywu oraz jedną linię tekstu podstawowego używającą czcionki pomocniczej łacińskiej. Następnie zmienia czcionki motywu i zapisuje wynik:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")
    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")
    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Nagłówek podąża za czcionką główną, a tekst podstawowy za czcionką pomocniczą. Tekst, który ma explicite podaną nazwę czcionki zamiast identyfikatora motywu, nie przełączy się automatycznie po zmianie schematu czcionek motywu.

Zbiory czcionek głównych i pomocniczych mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zamieniać lub usuwać te mapowania, zobacz [Script-Specific Theme Fonts](/slides/pl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Wskazówka" %}}
Więcej informacji o czcionkach w prezentacji znajdziesz w [PowerPoint Fonts](/slides/pl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub stosowanie motywu**

Istnieją dwa typowe przepływy pracy, rozwiązujące różne problemy.

### **Zachowanie motywu źródłowego przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj master źródłowy do docelowej prezentacji przy użyciu [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/add_clone/), a następnie sklonuj slajd przy użyciu [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) i sklonowanego mastera. To przenosi master, jego układy i powiązany motyw razem.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]
        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Jest to zalecany przepływ, gdy slajd źródłowy musi wyglądać tak samo w miejscu docelowym. Proste klonowanie zawartości na niezwiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd ma pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) i [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiują trzy główne komponenty motywu do nadpisania.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

To zmienia motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/clear/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji można użyć przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/layoutslidethememanager/):

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)
        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, i nadpisania slajdu tylko dla rzeczywistych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają przewidywanie późniejszych globalnych zmian motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Przed użyciem stylu tła przeglądnij przechowywaną kolekcję oraz bieżącą właściwość [Background.style_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/style_index/). `style_index` używa `0` dla braku wypełnienia motywowego; wartości dodatnie to odwołania do stylu tła motywu. Jest to inne znaczenie niż indeksowanie kolekcji w Pythonie, gdzie `[0]` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie do motywowego tła pierwszemu masterowi i zapisuje prezentację:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")
    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")
    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1
    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Widoczny rezultat zależy od wpisu motywu odwoływanego przez master oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. Użyj [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie traktuj `style_index` jako indeksu zero‑bazowego kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Wskazówka" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FormatScheme.fill_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/line_styles/) i [FormatScheme.effect_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien przeglądać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Podczas dostępu do tych kolekcji w Pythonie indeksowanie jest zero‑bazowe: `[0]` to pierwszy zapisany styl, a `[2]` to trzeci. Indeksy odwołań stylów kształtu to odrębna koncepcja, eksponowana przez [IShapeStyle](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty odwołujące się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")
    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10
    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Dla kształtów odwołujących się do tych slotów pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu otrzymuje zewnętrzny cień z odległością 10 punktów. Dokładny wygląd nadal zależy od tego, które sloty stylu każdy kształt odwołuje i czy bezpośrednie formatowanie nadpisuje motyw.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Odczytywanie skutecznych wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, czego rzeczywiście używa slajd lub kształt po rozstrzygnięciu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Dla tła użyj [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/), a dla wypełnienia [FillFormat.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/get_effective/).

Poniższy przykład odczytuje skuteczny motyw, tło i pierwsze wypełnienie kształtu ze slajdu:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]
    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()
    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")
    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Używaj skutecznych danych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz tylko [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/), możesz przeoczyć nadpisanie mastera, układu, slajdu lub kształtu, które zmienia ostateczny wygląd.

## **FAQ**

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy dalej dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj master źródłowy do docelowej prezentacji i sklonuj slajd z tym masterem przy użyciu [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/add_clone/) oraz [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/). Dzięki temu master, układy i motyw pozostają razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) dla motywu slajdu lub układu oraz odpowiednich metod zwracających dane skuteczne dla obiektów formatowania, takich jak [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/) i [FillFormat.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/get_effective/). API zwracają rozstrzygnięte wartości po zastosowaniu dziedziczenia i nadpisań.