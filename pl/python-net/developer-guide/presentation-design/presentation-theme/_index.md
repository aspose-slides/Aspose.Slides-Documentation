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
description: "Główne motywy prezentacji w Aspose.Slides dla Pythona via .NET, aby tworzyć, dostosowywać i konwertować pliki PowerPoint z spójnym brandowaniem."
---
## **Wstęp**

Szablon prezentacji definiuje spójny zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych wspólnych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, dzięki czemu zmiana motywu może jednocześnie zaktualizować wiele obiektów.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny przez właściwość [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/). Prezentacja może także zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji przy użyciu [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/), układ może nadpisać odziedziczony motyw poprzez [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/), a pojedynczy slajd może zrobić to samo. W praktyce skuteczny motyw slajdu jest wyznaczany poprzez łańcuch dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Komponenty motywu: kolory, czcionki, style tła i efekty](theme-constituents.png)

Poniższe sekcje pokazują najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczytywanie wartości po rozwiązaniu dziedziczenia i nadpisań.

## **Przeglądanie motywu**

Obiekt [MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) udostępnia właściwości [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) i [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/). Przeglądanie tych kolekcji przed ich modyfikacją jest szczególnie przydatne, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje główne właściwości motywu i podaje, ile stylów tła, wypełnień, linii i efektów jest przechowywanych w motywie:

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

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam skuteczny motyw. Przejrzyj master powiązany ze slajdem i użyj workflowu „effective‑theme” opisanego później w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmiana kolorów motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) motywu, wszystkie obiekty, które nadal odwołują się do tego koloru motywu, zostaną rozwiązane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie ulegają zmianie po aktualizacji koloru motywu.

Poniższy kompletny przykład tworzy kształt używający `ACCENT4`, zmienia kolor `accent4` motywu na czerwony, zapisuje prezentację, ponownie ją otwiera i wypisuje skuteczny kolor wypełnienia:

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

Ponieważ prostokąt pozostaje powiązany z `ACCENT4`, po zmianie motywu jego widoczny kolor staje się czerwony. Jeśli zamienisz kolor schematowy na bezpośredni kolor w kształcie, późniejsze zmiany `accent4` nie będą już wpływać na to wypełnienie.

### **Używanie kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty z koloru motywu, stosując przekształcenia kolorów. Aspose.Slides udostępnia te przekształcenia za pośrednictwem wyliczenia [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/).

![Główne kolory motywu oraz jaśniejsze i ciemniejsze kolory wygenerowane z dodatkowej palety](additional-palette-colors.png)

**1** – Główne kolory motywu.  
**2** – Jaśniejsze i ciemniejsze warianty wyprodukowane z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `ACCENT4`, stosuje przekształcenia luminancji do pięciu z nich i zapisuje wynik:

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

Warianty te pozostają oparte na kolorze motywu. Jeśli później zmieni się `accent4`, przekształcone kolory zostaną przeliczone na nową wartość `accent4`.

### **Mapowanie wartości `SchemeColor` na pozycje `ColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) używa `TEXT1`, `BACKGROUND1`, `TEXT2` i `BACKGROUND2`, natomiast [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) udostępnia te same pozycje motywu jako `dark1`, `light1`, `dark2` i `light2`. Mapowanie jest stałe:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Są to alternatywne nazwy tych samych pozycji motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmiana czcionek motywu**

Schemat czcionek motywu zawiera główny zestaw czcionek dla nagłówków i poboczny zestaw dla tekstu podstawowego. Właściwości [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) i [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) udostępniają te zestawy.

Identyfikatory czcionek kompatybilnych z PowerPoint można używać w formatowaniu tekstu:

* `+mn‑lt` – czcionka podstawowa łacińska (Minor Latin Font)
* `+mj‑lt` – czcionka nagłówka łacińska (Major Latin Font)
* `+mn‑ea` – czcionka podstawowa wschodnioazjatycka (Minor East Asian Font)
* `+mj‑ea` – czcionka nagłówka wschodnioazjatycka (Major East Asian Font)
* `+mn‑cs` – czcionka podstawowa skryptów złożonych (Minor Complex Script Font)
* `+mj‑cs` – czcionka nagłówka skryptów złożonych (Major Complex Script Font)

Poniższy przykład tworzy jeden nagłówek używający głównej łacińskiej czcionki motywu oraz jedną linię tekstu podstawowego używającą pobocznej łacińskiej czcionki motywu. Następnie zmienia czcionki motywu i zapisuje wynik:

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

Nagłówek korzysta z czcionki głównej, a tekst podstawowy z czcionki pobocznej. Tekst, który ma explicite nazwę czcionki zamiast identyfikatora motywu, nie przełączy się automatycznie po zmianie schematu czcionek motywu.

Zbiory czcionek głównych i pobocznych mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zastępować lub usuwać te mapowania, zobacz [Script‑Specific Theme Fonts](/slides/pl/python-net/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Po więcej informacji o czcionkach w prezentacjach zobacz [Czcionki PowerPoint](/slides/pl/python-net/powerpoint-fonts/).
{{% /alert %}}

### **Rozwiązywanie odwołań do czcionek motywu**

Podczas przeglądania tekstu [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) może zawierać odwołanie do motywu, np. `+mn‑lt`, zamiast nazwy rodziny czcionek. Wywołaj [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) z odpowiednim [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/), aby rozwiązać to odwołanie. Prefiksy `+mj` i `+mn` wybierają odpowiednio główne i poboczne zestawy czcionek; przyrostki `-lt`, `-ea` i `-cs` wybierają ich wersje łacińskie, wschodnioazjatyckie i skryptów złożonych.

Uzyskaj skuteczny motyw przez [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) na obiekcie, którego motyw ma zastosowanie do przeglądanego tekstu. Dla zwykłego tekstu na slajdzie użyj `slide.create_theme_effective`, aby kontekst obejmował odziedziczony motyw slajdu i lokalne nadpisania. Podczas przeglądania samego układu lub mastera użyj ich własnego skutecznego motywu. Nie zakładaj, że motyw pierwszego mastera obowiązuje wszystkie slajdy.

Poniższy przykład tworzy fragment tekstu, który explicite odwołuje się do pobocznej czcionki łacińskiej. Inicjalizuje schemat czcionek slajdu poprzez [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) i ustawia główne oraz poboczne rodziny łacińskie na `Arial` i `Calibri`, co sprawia, że wynik jest odtwarzalny bez pliku wejściowego.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

Wynik to `+mn‑lt -> Calibri` a następnie `Verdana -> Verdana`. Przechowywane odwołanie pozostaje niezmienione, natomiast explicite podana nazwa rodziny jest zwracana w takiej formie. Gdyby fragment używał `+mj‑lt`, rozwiązałby się do `Arial` w tym motywie.

Rozwiązywanie odwołania do motywu identyfikuje rodzinę czcionki określoną przez motyw. Nie sprawdza dostępności czcionki ani nie określa pliku czcionki ostatecznie używanego po podstawieniu lub odwołaniu do glifów podczas renderowania. Zobacz [Font Selection Sequence](/slides/pl/python-net/font-selection-sequence/) i [Font Substitution](/slides/pl/python-net/font-substitution/) dla tych odrębnych kroków.

## **Kopiowanie lub zastosowanie motywu**

Poniższe workflowy rozwiązują różne problemy związane z motywami.

### **Zastosowanie zewnętrznego motywu do slajdów zależnych od mastera**

Użyj [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz zmienić styl wszystkich slajdów zależnych od określonego mastera. Wybierz master z kolekcji [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy master slajd na podstawie wybranego mastera.  
1. Zastosowuje zewnętrzny motyw do nowego mastera.  
1. Przypisuje nowy master do wszystkich slajdów, które wcześniej zależały od wybranego mastera.  
1. Zwraca nowo utworzony [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów zależnych od pierwszego mastera i zapisuje prezentację:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) lub jedną z jego podklas związanych z formatem. Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Tylko slajdy zależne od wybranego mastera są ponownie przypisywane. Slajdy powiązane z innymi masterami zachowują swoje istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przypisane kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą także mieć pierwszeństwo przed wartościami odziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Dla spójnego renderowania i eksportu zainstaluj wymagane czcionki, udostępnij je przez [custom font sources](/slides/pl/python-net/custom-font/), lub skonfiguruj [font substitution](/slides/pl/python-net/font-substitution/).

To bezpośredni workflow na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosowanie różnych zewnętrznych motywów w prezentacji wielomastrmasterowej**

Gdy właściwy master nie jest znany z góry, uzyskaj go z reprezentatywnego slajdu poprzez [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) oraz [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/). Przechowaj pierwotne odwołania do masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje inny zewnętrzny motyw do każdej grupy:

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

Pierwsze wywołanie wpływa tylko na slajdy zależne od `first_group_master`, a drugie wywołanie wpływa tylko na slajdy zależne od `second_group_master`. Slajdy należące do innych masterów nie są zmieniane.

### **Zachowanie źródłowego motywu przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny wygląd, sklonuj źródłowy master do docelowej prezentacji przy użyciu [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/), a następnie sklonuj slajd przy użyciu [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) i sklonowanego mastera. Dzięki temu master, jego układy i powiązany motyw zostaną przeniesione razem.

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

Jest to preferowany workflow, gdy źródłowy slajd musi wyglądać identycznie w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane przez motyw.

### **Zastosowanie wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu na podstawie źródłowego motywu. Metody [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) i [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) kopiują trzy główne komponenty motywu do nadpisania.

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

Zmienia to motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/).

### **Zastosowanie nadpisania motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, chyba że konkretny slajd ma własne nadpisanie. Te same metody inicjujące mogą być użyte przez [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/):

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

Używaj motywu na poziomie mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję, nadpisania układu, gdy jedna rodzina układów wymaga innego stylu, oraz nadpisania slajdu tylko w prawdziwych wyjątkach. Nadmierna liczba nadpisań na poziomie slajdu utrudnia późniejsze globalne zmiany motywu.

## **Aktualizacja stylów tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba rzeczywiście przechowywanych definicji w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![Galeria stylów tła PowerPoint dla motywu prezentacji](presentation-design_8.png)

Zanim użyjesz stylu tła, przejrzyj przechowywaną kolekcję i bieżącą wartość [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/). `style_index` używa `0` dla braku wypełnienia motywu; wartości dodatnie są odwołaniami do stylów tła motywu. Jest to inne niż indeksowanie kolekcji Pythona, gdzie `[0]` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera taką samą liczbę stylów wypełnienia tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie do motywu tła pierwszemu masterowi i zapisuje prezentację:

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

Widoczny rezultat zależy od wpisu motywu, do którego odwołuje się master, oraz od ewentualnych nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana tylko tła mastera może nie wpłynąć na ten slajd. Użyj [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Warning" %}}
Nie traktuj `style_index` jako indeksu zerowego kolekcji. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie on wyglądał tak samo w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Po informacje o bezpośrednim formatowaniu tła i dziedziczeniu tła zobacz [Presentation Background](/slides/pl/python-net/presentation-background/).
{{% /alert %}}

## **Aktualizacja efektów motywu**

Schemat formatowania motywu zawiera oddzielne kolekcje [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) oraz [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien przeglądać każdą kolekcję zamiast zakładać stałą liczbę.

![Subtelne, umiarkowane i intensywne efekty motywu zastosowane do tego samego kształtu](presentation-design_10.png)

Kiedy uzyskujesz dostęp do tych kolekcji w Pythonie, indeks kolekcji jest zerowy: `[0]` to pierwszy zapisany styl, a `[2]` to trzeci. Indeksy odniesień stylu w kształcie to odrębna koncepcja, udostępniana przez [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/). Modyfikacja stylu motywu wpływa na kształty, które odwołują się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, trzeci styl wypełnienia oraz włącza zewnętrzny cień w trzecim stylu efektu, a następnie zapisuje wynik:

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

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym zielonym lasem, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wygląd nadal zależy od tego, które sloty stylów każdy kształt odwołuje oraz czy bezpośrednie formatowanie nadpisuje motyw.

![Style efektów motywu po zmianie linii, wypełnienia i ustawień cienia](presentation-design_11.png)

## **Wybór stylów wypełnienia i linii motywu dla kształtu**

Kształt może niezależnie wybierać wypełnienie i kontur poprzez [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) oraz [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/). Dla obu właściwości indeks `1` wybiera pierwszy wpis w odpowiadającej kolekcji motywu (`fill_styles[0]` lub `line_styles[0]`), a indeks `2` wybiera drugi wpis.

Poniższy przykład definiuje dwa wypełnienia (złote i niebieskie niebo) oraz dwa kontury (ciemnoniebieski 6 pt i ciemnoczerwony 12 pt) w domyślnym motywie nowej prezentacji. Zapisuje slajd w trzech etapach, abyś mógł porównać wyniki w PowerPoint.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| Style początkowe | Zmiana prawego konturu | Edycja pierwszego wypełnienia motywu |
|:---:|:---:|:---:|
| ![Złote i niebieskie niebo prostokąty z dopasowanymi cienkimi ciemnoniebieskimi konturami](theme-style-initial.png) | ![Prostokąt niebieski ma teraz grubą ciemnoczerwoną obwódkę](theme-style-line-changed.png) | ![Lewy prostokąt jest teraz zielony, a oba kontury pozostają niezmienione](theme-style-fill-changed.png) |

Wybranie innego stylu linii zmienia tylko obwódkę prawego prostokąta. Edycja pierwszego wypełnienia motywu aktualizuje każdy kształt, który go używa. Tutaj tylko lewy prostokąt zmienia się na zielony.

Na istniejącym kształcie lokalny kolor wypełnienia, kolor linii lub grubość linii może nadpisać tę część stylu motywu. Jeśli zmiana indeksu stylu nie przynosi widocznego efektu, sprawdź [direct formatting](/slides/pl/python-net/shape-formatting/).

## **Określenie, czy skuteczne wypełnienie stałe używa koloru motywu**

Wypełnienie może być zapisane bezpośrednio na obiekcie lub odziedziczone z akapitu, układu, mastera, stylu motywu lub innego poziomu formatowania. Wywołaj [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) aby rozwiązać tę hierarchię w niezmienny [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/). Najpierw sprawdź [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/). Tylko gdy jest `FillType.SOLID`, należy odczytać właściwości stałego wypełnienia.

Dla stałego wypełnienia, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) zwraca ostateczną wartość RGB po dziedziczeniu, wyszukiwaniu w motywie i zastosowaniu przekształceń kolorów. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) zwraca odpowiadający logiczny slot [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/), np. `TEXT1` lub `ACCENT6`. Wartość `SchemeColor.NOT_DEFINED` oznacza, że skuteczne wypełnienie stałe nie jest oparte na kolorze schematu. W workflowie, w którym wypełnienia są albo kolorami motywu, albo bezpośrednimi kolorami RGB, ta wartość identyfikuje wypełnienie RGB.

Nie używaj wyłącznie lokalnej wartości [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) do klasyfikacji wypełnienia. Na przykład fragment tekstu może nie mieć lokalnie zdefiniowanego koloru schematu, więc jego lokalna wartość to `NOT_DEFINED`, podczas gdy skuteczne wypełnienie dziedziczy kolor motywu i rozwiązuje się do `TEXT1` lub `ACCENT6`. Z drugiej strony, `solid_fill_scheme_color` informuje, który logiczny slot motywu wygenerował skuteczny kolor, ale nie mówi, czy slot ten pochodzi z obiektu, akapitu, układu, mastera czy innego poziomu hierarchii.

Poniższy przykład ładuje prezentację, audytuje zarówno wypełnienia kształtów, jak i wypełnienia fragmentów tekstu, wypisuje każdą ostateczną wartość RGB i powiązany kolor schematu oraz oznacza stałe wypełnienia, które nie będą podążały za zmianami kolorów motywu:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

Gałąź `NOT_DEFINED` dostarcza listę audytu stałych wypełnień, które nie będą reagować na zmiany slotów kolorów motywu. Przejrzyj te obiekty, gdy prezentacja musi podążać za nową paletą marki. Zgłoszona wartość RGB nadal pokazuje bieżący wygląd, a wartość schematu wyjaśnia, czy ten wygląd jest połączony z motywem.

Obiekty skutecznego formatu są migawkami. Po zmianie motywu prezentacji, nadpisania motywu lub dowolnego dziedziczonego formatowania, ponownie wywołaj `get_effective` i odczytaj nowy obiekt `IFillFormatEffectiveData` przed porównaniem lub raportowaniem kolorów.

## **Odczyt skutecznych wartości motywu**

Surowe obiekty motywu mówią, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozwiązaniu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/). Dla tła użyj [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), a dla wypełnienia [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/).

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

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz tylko [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/), możesz przeoczyć nadpisania mastera, układu, slajdu lub kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) przepisuje tylko slajdy zależne od wybranego mastera. Slajdy używające innych masterów zachowują istniejące motywy.

**Czy mogę zastosować motyw do jednego slajdu bez zmiany mastera?**

Tak. Użyj [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) oraz [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/). Dzięki temu master, układy i motyw pozostają razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) dla slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatowania, takich jak [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) i [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/). Te API zwracają rozwiązywane wartości po zastosowaniu dziedziczenia i nadpisań.