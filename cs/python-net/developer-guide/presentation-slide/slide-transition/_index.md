---
title: Správa přechodů snímků v prezentacích pomocí Pythonu
linktitle: Přechod snímku
type: docs
weight: 90
url: /cs/python-net/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- aplikovat přechod snímku
- pokročilý přechod snímku
- Morph přechod
- typ přechodu
- efekt přechodu
- Python
- Aspose.Slides
description: "Objevte, jak přizpůsobit přechody snímků v Aspose.Slides pro Python pomocí .NET, s podrobným návodem krok za krokem pro prezentace PowerPoint a OpenDocument."
---
## **Přehled**

Aspose.Slides for Python poskytuje plnou kontrolu nad přechody snímků, od výběru typu přechodu po nastavení načasování a spouštěčů jako součásti automatizovaných pracovních postupů prezentací. Můžete nastavit posun snímků na kliknutí a/nebo po uplynutí určeného zpoždění a doladit vizuální chování pomocí efektů, jako jsou přechody z černé nebo vstupy ze směru. Knihovna také podporuje přechod Morph, zavedený v PowerPoint 2019, včetně režimů, které morphují podle objektu, slova nebo znaku, a vytvářejí tak plynulý soudržný pohyb mezi snímky.

## **Přidání přechodů snímků**

Aby bylo snazší pochopit, tento příklad ukazuje, jak použít Aspose.Slides for Python k řízení jednoduchých přechodů snímků. Vývojáři mohou aplikovat různé efekty přechodu na snímky a přizpůsobit jejich chování. Pro vytvoření jednoduchého přechodu snímku postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Aplikujte přechod snímku pomocí jednoho z efektů z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/).
1. Uložte upravený soubor prezentace.

```py
import aspose.slides as slides

    # Vytvořte instanci třídy Presentation pro načtení souboru prezentace.
    with slides.Presentation("sample.pptx") as presentation:
        # Použijte kruhový přechod na snímek 1.
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

        # Použijte přechod comb na snímek 2.
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        # Uložte prezentaci na disk.
        presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání pokročilých přechodů snímků**

V této části jsme použili jednoduchý efekt přechodu na snímek. Aby byl tento efekt kontrolovanější a vylepšený, postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Aplikujte přechod snímku pomocí jednoho z efektů z výčtu [TransitionType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitiontype/).
1. Nakonfigurujte přechod tak, aby se posunul při kliknutí, po uplynutí určitého časového intervalu, nebo obojí.
1. Uložte upravený soubor prezentace.

Pokud je povoleno **Advance On Click**, snímek se posune pouze po kliknutí uživatele. Pokud je nastavená vlastnost **Advance After Time**, snímek se posune automaticky po zadaném intervalu.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation pro otevření souboru prezentace.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Použijte kruhový přechod na snímek 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Povolte posun po kliknutí a nastavte automatický posun po 3 sekundách.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Použijte přechod comb na snímek 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Povolte posun po kliknutí a nastavte automatický posun po 5 sekundách.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Použijte přechod zoom na snímek 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Povolte posun po kliknutí a nastavte automatický posun po 7 sekundách.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Uložte prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Morph přechod**

Aspose.Slides for Python podporuje [Morph transition](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/morphtransition/), který animuje plynulý pohyb z jednoho snímku na další. Tato část vysvětluje, jak použít Morph přechod. Pro jeho efektivní využití potřebujete dva snímky s alespoň jedním společným objektem. Nejjednodušší přístup je duplikovat snímek a poté přesunout objekt na jiné místo na druhém snímku.

Následující úryvek kódu ukazuje, jak klonovat snímek obsahující text a aplikovat Morph přechod na druhý snímek.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Zkopírujte první snímek a vytvořte druhý snímek se stejnými tvary pro kontinuitu Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Vyberte stejný obdélník na druhém snímku a změňte jeho pozici a velikost.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Povolte Morph přechod na druhém snímku, aby se změny tvaru plynule animovaly.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Typy Morph přechodů**

Výčet [TransitionMorphType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionmorphtype/) představuje různé typy Morph přechodů snímků.

Následující úryvek kódu ukazuje, jak aplikovat Morph přechod na snímek a změnit typ morphu:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení efektů přechodu**

Aspose.Slides for Python vám umožňuje nastavit efekty přechodu, jako jsou **From Black**, **From Left**, **From Right** a další. Pro konfiguraci efektu přechodu postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Získejte referenci na snímek.
1. Nastavte požadovaný efekt přechodu.
1. Uložte prezentaci jako soubor PPTX.

V níže uvedeném příkladu nastavujeme několik efektů přechodu.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation pro otevření souboru prezentace.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Použijte přechod Cut a povolte From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Uložte prezentaci na disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu řídit rychlost přehrávání přechodu snímku?**

Ano. Nastavte [speed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/speed/) přechodu pomocí nastavení [TransitionSpeed](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/transitionspeed/) (např. slow/medium/fast).

**Mohu k přechodu připojit zvuk a nastavit jeho opakování?**

Ano. Můžete vložit zvuk pro přechod a ovládat chování pomocí nastavení, jako jsou režim zvuku a smyčka (např. [sound](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), plus metadata jako [sound_is_built_in](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) a [sound_name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Jaký je nejrychlejší způsob, jak aplikovat stejný přechod na každý snímek?**

Nakonfigurujte požadovaný typ přechodu v nastavení přechodu každého snímku; přechody jsou uloženy per snímek, takže aplikace stejného typu na všechny snímky poskytne konzistentní výsledek.

**Jak mohu zjistit, který přechod je aktuálně nastaven na snímku?**

Prozkoumejte [transition settings](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/slide_show_transition/) snímku a přečtěte jeho [transition type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.slideshow/slideshowtransition/type/); tato hodnota vám přesně řekne, který efekt je aplikován.