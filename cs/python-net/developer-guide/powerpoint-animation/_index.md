---
title: Vylepšete prezentace PowerPoint pomocí animací v Pythonu
linktitle: Animace PowerPoint
type: docs
weight: 150
url: /cs/python-net/powerpoint-animation/
keywords:
- přidat animaci
- aktualizovat animaci
- změnit animaci
- odstranit animaci
- spravovat animaci
- ovládat animaci
- efekt animace
- animace PowerPoint
- časová osa animace
- interaktivní animace
- vlastní animace
- animace tvaru
- animovaný graf
- animovaný text
- animovaný tvar
- animovaný OLE objekt
- animovaný obrázek
- animovaná tabulka
- prezentace PowerPoint
- Python
- Aspose.Slides
description: "Prozkoumejte možnosti Aspose.Slides pro Python via .NET při práci s animacemi v PowerPointu. Tento obecný přehled zdůrazňuje klíčové funkce a poskytuje tipy, jak vylepšit vaše prezentace."
---
## **Úvod**

Prezentace jsou navrženy tak, aby předávaly informace, proto jsou jejich vizuální vzhled a interaktivní chování klíčovými faktory při tvorbě.

**PowerPoint animace** hraje důležitou roli při tom, aby byla prezentace poutavá a zajímavá pro diváky. Aspose.Slides for Python via .NET poskytuje širokou škálu možností, jak přidat animaci do prezentace PowerPoint. Můžete:

- Použít různé animační efekty na tvary, grafy, tabulky, OLE objekty a další prvky.
- Použít více animačních efektů na jeden tvar.
- Ovládat efekty prostřednictvím časové osy animace.
- Vytvořit vlastní animace.

V Aspose.Slides for Python via .NET lze animační efekty aplikovat na tvary. Protože každý prvek na snímku — včetně textu, obrázků, OLE objektů a tabulek — je považován za tvar, můžete na jakýkoli prvek na snímku aplikovat animační efekty.

Jmenný prostor [aspose.slides.animation](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/) poskytuje třídy pro práci s animacemi v PowerPointu.

## **Instalace**

```bash
pip install aspose.slides
```

## **Přidání animačního efektu k tvaru v Pythonu**

Animační efekty jsou součástí hlavní sekvence snímku. Přidejte tvar a poté zavolejte `add_effect` na `slide.timeline.main_sequence`, předáním typu efektu, jeho podtypu a spouštěče, který ho spustí.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 100)
    shape.text_frame.text = "Animated shape"

    sequence = slide.timeline.main_sequence
    effect = sequence.add_effect(
        shape,
        slides.animation.EffectType.FLY,
        slides.animation.EffectSubtype.LEFT,
        slides.animation.EffectTriggerType.ON_CLICK,
    )
    effect.timing.duration = 2.0

    presentation.save("animated.pptx", slides.export.SaveFormat.PPTX)
```

Uložený soubor obsahuje na prvním snímku jeden efekt: obdélník přiletí zleva během dvou sekund po kliknutí prezentátora. Po opětovném otevření a načtení `slide.timeline.main_sequence` se vrátí tento efekt, takže animace přežije celý proces a neexistuje jen v paměti.

## **Animační efekty**

Aspose.Slides podporuje **více než 150 animačních efektů**, včetně základních efektů jako Bounce, PathFootball a Zoom, stejně jako specializovaných efektů jako OLEObjectShow a OLEObjectOpen. Kompletní seznam najdete v enumeraci [EffectType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttype/).

Tyto animační efekty lze také kombinovat s následujícími efekty:

- [ColorEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/coloreffect/)
- [CommandEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/commandeffect/)
- [FilterEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/filtereffect/)
- [MotionEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/motioneffect/)
- [PropertyEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/propertyeffect/)
- [RotationEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/rotationeffect)
- [ScaleEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/scaleeffect/)
- [SetEffect](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/seteffect/)

## **Vlastní animace**

Pro kompletní příklady v Pythonu, které vytvářejí, kontrolují a upravují chování a editovatelné trajektorie pohybu, viz [Vlastní animace](/slides/cs/python-net/custom-animation/).

V Aspose.Slides můžete vytvořit vlastní **vlastní animace** kombinací více chování do jednoho efektu.

[Behavior](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/behavior/) je stavební blok animačního efektu v PowerPointu. Kombinujte chování pro přizpůsobení efektu nebo přidejte chování pro rozšíření předdefinovaného efektu. Opakování se nastavuje pomocí časových nastavení, nikoli pomocí samostatného opakovacího chování.

[Animation Point](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/point/) označuje okamžik nebo pozici, ve které je chování aplikováno (klíčový snímek).

## **Časová osa animace**

[Sequence](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/sequence/) je kolekce animačních efektů, které mohou cílit na různé tvary.

[Timeline](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/animationtimeline/) je sada sekvencí používaných na konkrétním snímku. Byla zavedena v PowerPointu 2002. Ve starších verzích PowerPointu bylo přidávání animačních efektů obtížné a často vyžadovalo obejití. Timeline nahrazuje starou třídu `AnimationSettings` a poskytuje přehlednější objektový model pro animace v PowerPointu. Každý snímek může mít pouze jednu časovou osu animace.

## **Interaktivní animace**

[Trigger](https://reference.aspose.com/slides/cs/python-net/aspose.slides.animation/effecttriggertype/) vám umožňuje definovat uživatelské akce (např. kliknutí na tlačítko), které spustí konkrétní animaci. Spouštěče byly přidány až v nejnovějších verzích PowerPointu.

## **Animace tvarů**

Aspose.Slides vám umožňuje aplikovat animace na tvary — například text, obdélníky, čáry, rámečky, OLE objekty a další.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animaci tvarů**](/slides/cs/python-net/shape-animation/).
{{% /alert %}}

## **Animované grafy**

Pro vytvoření animovaných grafů použijte stejné třídy jako u tvarů. Nicméně animace v PowerPointu lze aplikovat pouze na kategorie grafu nebo řady grafu. Můžete také aplikovat animační efekt na jednotlivý prvek kategorie nebo řady.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaných grafech**](/slides/cs/python-net/animated-charts/).
{{% /alert %}}

## **Animovaný text**

Kromě animace textu můžete aplikovat animaci i na odstavec.

{{% alert color="info" title="Note" %}}
Přečtěte si více [**O animovaném textu**](/slides/cs/python-net/animated-text/).
{{% /alert %}}

## **Často kladené otázky**

**Zůstanou animace zachovány při exportu do PDF?**

Ne. PDF je statický formát, proto se animace a [přechody snímků](/slides/cs/python-net/slide-transition/) nepřehrávají. Pokud potřebujete pohyb, exportujte místo toho do [HTML5](/slides/cs/python-net/export-to-html5/), [animovaného GIFu](/slides/cs/python-net/convert-powerpoint-to-animated-gif/) nebo [videa](/slides/cs/python-net/convert-powerpoint-to-video/).

**Mohu převést animovanou prezentaci na video a ovládat snímkovou frekvenci a velikost snímků?**

Ano. Můžete [vykreslit prezentaci jako snímky](/slides/cs/python-net/convert-powerpoint-to-video/) a zakódovat je do videa (např. pomocí ffmpeg), s volbou FPS a rozlišení. Během vykreslování se přehrávají animace i přechody snímků.

**Zůstanou animace zachovány při práci s ODP (nejen PPTX)?**

Formáty PPT, PPTX a ODP jsou podporovány pro [čtení](/slides/cs/python-net/open-presentation/) a [zápis](/slides/cs/python-net/save-presentation/), avšak to nezaručuje zachování animací. Data vlastních animací mohou být při konverzi do ODP ztracena. Viz [Vlastní animace](/slides/cs/python-net/custom-animation/) pro příklady a doporučení, jak zkontrolovat kompatibilitu formátu.