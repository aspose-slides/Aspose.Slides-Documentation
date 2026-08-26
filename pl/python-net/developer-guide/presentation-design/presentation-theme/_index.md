---
title: Zarządzanie motywami prezentacji PowerPoint w Python
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
- Zewnętrzny motyw
- THMX
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
description: "Główne motywy prezentacji w Aspose.Slides dla Pythona poprzez .NET, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny poprzez właściwość [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji za pomocą [MasterThemeManager.override_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/masterthememanager/override_theme/), layout może nadpisać dziedziczony motyw poprzez [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny motyw slajdu jest ustalany w łańcuchu dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie layoutu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Inspekcja motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/) udostępnia właściwości [color_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/font_scheme/) i [format_scheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/mastertheme/format_scheme/). Przeglądanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i raportuje, ile stylów tła, wypełnienia, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma ten sam skuteczny motyw. Przeanalizuj master powiązany ze slajdem i użyj opisanej później procedury pracy ze skutecznym motywem, gdy mogą występować nadpisania layoutu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/). Kiedy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/colorscheme/) motywu, wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązywane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie zostaną zmienione przez aktualizację koloru motywu.

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

Ponieważ prostokąt pozostaje powiązany z `ACCENT4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint generuje jaśniejsze i ciemniejsze warianty z koloru motywu, stosując transformacje kolorów. Aspose.Slides udostępnia te transformacje poprzez wyliczenie [ColorTransformOperation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** - Główne kolory motywu.  
**2** - Jaśniejsze i ciemniejsze warianty wyprodukowane z głównych kolorów motywu.

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

Warianty te pozostają oparte na kolorze motywu. Jeśli `accent4` zmieni się później, przekształcone kolory zostaną ponownie obliczone na podstawie nowej wartości `accent4`.

### **Mapowanie wartości `SchemeColor` na pozycje `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/python-net/aspose.slides/schemecolor/) używa `TEXT1`, `BACKGROUND1`, `TEXT2` i `BACKGROUND2`, podczas gdy [ColorScheme](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/colorscheme/) udostępnia te same pozycje motywu jako `dark1`, `light1`, `dark2` i `light2`. Mapowanie jest stałe:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Są to alternatywne nazwy tych samych pozycji motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pomocniczych czcionek dla tekstu głównego. Właściwości [FontScheme.major](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/major/) i [FontScheme.minor](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek kompatybilne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` – Czcionka ciała tekstu łacińska (Minor Latin Font)
* `+mj-lt` – Czcionka nagłówka łacińska (Major Latin Font)
* `+mn-ea` – Czcionka ciała tekstu wschodnio‑azjatycka (Minor East Asian Font)
* `+mj-ea` – Czcionka nagłówka wschodnio‑azjatycka (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu ciała używającą pomocniczej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek podąża za czcionką główną, a tekst ciała za czcionką pomocniczą. Tekst, który ma wyraźnie określoną nazwę czcionki zamiast identyfikatora motywu, nie przełączy się automatycznie po zmianie schematu czcionek motywu.

Zestawy czcionek głównych i pomocniczych mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zastępować lub usuwać te mapowania, zobacz [Script‑Specific Theme Fonts](/slides/pl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Wskazówka" %}}
Więcej informacji o czcionkach w prezentacjach znajdziesz w [PowerPoint Fonts](/slides/pl/python-net/powerpoint-fonts/).
{{% /alert %}}

## **Kopiowanie lub zastosowanie motywu**

Poniższe przepływy rozwiązują różne problemy związane z motywem.

### **Zastosowanie zewnętrznego motywu do slajdów zależnych od mastera**

Użyj [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) gdy posiadasz plik motywu PowerPoint (`.thmx`) i chcesz ponownie ostylizować każdy slajd zależny od konkretnego mastera. Wybierz master z kolekcji [Presentation.masters](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/masters/), która implementuje [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy slajd master na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny motyw do nowego mastera.  
1. Przypisuje nowego mastera wszystkim slajdom, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów zależnych od pierwszego mastera i zapisuje prezentację:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxexception/) lub jedną z jego podklas związanych z formatem. Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisywane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie layoutu i slajdu mogą również mieć pierwszeństwo przed wartościami dziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je przez [custom font sources](/slides/pl/python-net/custom-font/), lub skonfiguruj [font substitution](/slides/pl/python-net/font-substitution/).

Jest to bezpośredni przepływ na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu czy layoutu.

### **Zastosowanie różnych zewnętrznych motywów w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, uzyskaj go z reprezentatywnego slajdu poprzez [Slide.layout_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/layout_slide/) i [LayoutSlide.master_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/master_slide/). Przechowaj odniesienia do oryginalnych masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby odnaleźć ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")
            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

Pierwsze wywołanie wpływa tylko na slajdy zależne od `first_group_master`, a drugie wywołanie wpływa tylko na slajdy zależne od `second_group_master`. Slajdy należące do jakiegokolwiek innego mastera nie są przestylizowane.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego oryginalny projekt, sklonuj źródłowy master do prezentacji docelowej przy pomocy [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/add_clone/), a następnie sklonuj slajd przy użyciu [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/) i sklonowanego mastera. To przenosi master, jego layouty oraz powiązany motyw razem.

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

Jest to preferowany przepływ, gdy źródłowy slajd musi wyglądać tak samo w miejscu docelowym. Proste klonowanie zawartości na niezwiązany master docelowy może zmienić kolory, czcionki, tła i efekty napędzane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i layoutcie, zainicjuj nadpisanie na poziomie slajdu z źródłowego motywu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) i [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiują trzy główne komponenty motywu do nadpisania.

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

Zmienia to motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/overridetheme/clear/).

### **Zastosowanie nadpisania motywu do layoutu**

Nadpisanie na poziomie layoutu ma zastosowanie do slajdów używających tego layoutu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjalizacji mogą być użyte poprzez [LayoutSlideThemeManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/layoutslidethememanager/) layoutu:

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

Użyj motywu na poziomie mastera lub prezentacji, gdy wiele layoutów i slajdów ma współdzielić tę samą bazową konstrukcję, nadpisania layoutu, gdy jedna rodzina layoutów potrzebuje odmiennego stylu, oraz nadpisania slajdu wyłącznie dla prawdziwych wyjątków. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint może prezentować w UI więcej opcji tła niż liczba definicji wypełnień fizycznie zapisanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odniesieniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Przed użyciem stylu tła przeanalizuj przechowywaną kolekcję oraz bieżącą wartość [Background.style_index](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/style_index/). `style_index` używa `0` dla braku tematycznego wypełnienia; dodatnie wartości są odwołaniami do stylów tła motywu. To różni się od indeksowania kolekcji w Pythonie, gdzie `[0]` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnień tła.

Poniższy przykład raportuje dostępny licznik wypełnień tła, przypisuje odwołanie do tematycznego tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny wynik zależy od wpisu motywu, na który wskazuje master, oraz od ewentualnych nadpisań tła na poziomie layoutu lub slajdu. Jeśli slajd używa własnego tła, zmiana jedynie tła mastera może nie wpłynąć na ten slajd. Użyj [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}
Nie traktuj `style_index` jako indeks kolekcji zerowy. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie on wyglądał tak samo w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Wskazówka" %}}
Informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła znajdziesz w [Presentation Background](/slides/pl/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FormatScheme.fill_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/line_styles/), oraz [FormatScheme.effect_styles](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien sprawdzać każdą kolekcję zamiast zakładać stałą liczbę elementów.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy odwołujesz się do tych kolekcji w Pythonie, indeks kolekcji jest zerowy: `[0]` to pierwszy zapisany styl, a `[2]` to trzeci. Indeksy referencji stylu w kształcie to odrębny koncept, udostępniany przez [IShapeStyle](https://reference.aspose.com/slides/pl/python-net/aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

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

Dla kształtów odwołujących się do tych slotów, pierwszy tematowy styl linii staje się czerwony, trzeci tematowy styl wypełnienia staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny efekt wizualny wciąż zależy od tego, które sloty stylu odwołują poszczególne kształty i czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Odczyt skutecznych wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Dla tła użyj [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/), a dla wypełnienia [FillFormat.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/get_effective/).

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli analizujesz tylko [Presentation.master_theme](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/master_theme/), możesz przegapić nadpisania mastera, layoutu, slajdu lub kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) przypisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują swoje istniejące motywy.

**Czy mogę zastosować motyw do pojedynczego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji oraz sklonuj slajd z tym masterem przy użyciu [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/add_clone/) i [SlideCollection.add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/add_clone/). Dzięki temu master, layouty i motyw pozostają razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) dla motywu slajdu lub layoutu oraz odpowiednich metod danych skutecznych dla obiektów formatu, takich jak [Background.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/background/get_effective/) i [FillFormat.get_effective](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fillformat/get_effective/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.