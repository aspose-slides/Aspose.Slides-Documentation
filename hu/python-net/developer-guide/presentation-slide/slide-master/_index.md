---
title: Prezentációs diákmesterek kezelése Pythonban
linktitle: Diákmester
type: docs
weight: 80
url: /hu/python-net/slide-master/
keywords:
- diákmester
- mesterdia
- PPT mesterdia
- több mesterdia
- mesterdiák összehasonlítása
- háttér
- helyettesítő
- mesterdia klónozása
- mesterdia másolása
- mesterdia megkettőzése
- használaton kívüli mesterdia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével kezelje a diákmestereket: hozzáférjen, szerkessze, klónozza, hasonlítsa össze és távolítsa el a mesterdiákat PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Egy **diákmester** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, sablonszabályokat és láblécbeállításokat. A PowerPointban a diákmester szerkesztése a szokásos módja annak, hogy a prezentáció egységes maradjon anélkül, hogy minden dián meg kellene ismételni ugyanazt a formázást.

Az Aspose.Slides for Python via .NET ugyanezt a modellt támogatja. Egy prezentáció egy vagy több diákmestert tartalmazhat, és minden diákmester több elrendezési diát (layout slide) is magában foglalhat. A normál diák általában nem hivatkoznak közvetlenül egy diákmesterre. Ehelyett egy normál dia egy elrendezési diát használ, amely egy diákmesterhez tartozik.

A hierarchia:

1. **Diákmester** – meghatározza a közös tervezést és sablont.
1. **Elrendezési dia** – meghatároz egy adott helykitöltő- és elrendezési szintű formázást.
1. **Normál dia** – a tényleges prezentációs tartalmat tartalmazza, és egy elrendezési diát használ.

![A diákmesterek, elrendezési diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban a diákmestert a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) osztály képviseli. A prezentáció összes diákmestere a `Presentation.masters` gyűjteményen keresztül érhető el.

{{% alert color="info" title="Öröklődés" %}}
Amikor egy tulajdonság több szinten is meghatározásra kerül, a specifikusabb szint nyer. Például ha egy diákmester és egy elrendezési dia is meghatároz egy háttérszínt, akkor a layout-ot alapuló diákok a layout hátterét használják. Az elrendezési diákról további információk a [Diákelrendezések alkalmazása vagy módosítása](/python-net/slide-layout/) oldalon találhatók.
{{% /alert %}}

## **Diákmesterek elérése**

A PowerPointban a **Nézet** > **Diákmester** menüpontból nyithatja meg a Diákmester nézetet.

![A Diákmester parancs a PowerPoint Nézet lapon](slide-master_3.jpg)

Az Aspose.Slides-ban a `masters` gyűjteményt használja a diákmesterek eléréséhez:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

A normál dia által használt diákmestert a layoutján keresztül is lekérdezheti:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Mi található egy diákmesterben**

A diákmester egy dia-szerű objektum. A [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályból örökli a közös dia viselkedést, ezért sok olyan dia tulajdonságot is tartalmaz, amely a normál és az elrendezési diákon is elérhető. A diákmester-specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) API oldalon vannak felsorolva.

A leggyakrabban használt diákmester tagok:

| Tag | Cél |
| --- | --- |
| `background` | A diákmester szintű diaháttér beállítása. |
| `shapes` | A diákmesten elhelyezett alakzatok tárolása, például logók, képkeretek és megosztott szöveg. |
| `layout_slides` | A diákmesterhez tartozó elrendezési diák tárolása. |
| `theme_manager` | Hozzáférés a diákmester témához kapcsolódó API-khoz. |
| `header_footer_manager` | Fejlécek, láblécek, dátumok és diaszámok kezelése a diákmester és annak aláértelmezett elrendezései számára. |
| `get_depending_slides` | Visszaadja a normál diákokat, amelyek a diákmesterhez layoutjaikon keresztül kapcsolódnak. |

## **Kép hozzáadása egy diákmesterhez**

Amikor képet ad hozzá egy diákmesterhez, az megjelenik azon diákokon, amelyek az adott mesterhez tartozó layoutokat használják. Ez logók, vízjelek, díszbannerek és egyéb ismétlődő vizuális elemek esetén hasznos.

Az alábbi példa egy logót ad az első diákmesterhez:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

A képkeretekkel kapcsolatos további információk a [Képkeret](/python-net/picture-frame/) oldalon érhetők el.

## **Helyettesítő objektumok kezelése**

A helyettesítő objektumok (placeholder) általában az elrendezési diákon vannak definiálva. A diákmester biztosítja a közös stílust és sablont, amelyet a layoutok örökölnek, míg minden layout eldönti, hogy mely helyettesítők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyettesítő parancsok a Diákmester nézetben érhetők el.

![A Helyettesítő beszúrása parancs a PowerPoint Diákmester nézetben](slide-master_5.png)

Új helyettesítő objektumok hozzáadásához az Aspose.Slides-ban a diákmesterhez tartozó elrendezési diát kell módosítania:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Már létező helyettesítő alakzatok formázása is lehetséges. Az alábbi példa megtalálja a cím helyettesítőt és lineáris színátmenetes kitöltést alkalmaz rá:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formázott címhelyettesítő, amely a normál diákon öröklődik](slide-master_8.png)

A helyettesítők és a szövegformázás további lehetőségeiről lásd a [Helyettesítő szöveg beállítása](/python-net/manage-placeholder/) és a [Szövegformázás](/python-net/text-formatting/) oldalakat.

## **Diákmester háttér módosítása**

A diákmester háttér öröklődik az elrendezések és azok a diák számára, amelyek nem felülírják azt. Az alábbi példa egy egységes háttérszínt állít be az első diákmesterhez:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Kapcsolódó témák: [Prezentáció háttér](/python-net/presentation-background/) és [Prezentációs sablon](/python-net/presentation-theme/).

## **Diákmester klónozása egy másik prezentációba**

A [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) osztály `add_clone` metódusával másolhat egy diákmestert egy másik prezentációba. A másolt mester ezután használható a célprezentáció elrendezései és diái számára.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Ha normál diákokat is szeretne klónozni a mesterükkel együtt, lásd a [Diákok klónozása](/python-net/clone-slides/) oldalt.

## **Több diákmester hozzáadása**

Egy prezentáció több diákmestert is tartalmazhat. Ez akkor hasznos, ha a különböző szakaszok eltérő márkázást, oldalstruktúrát vagy sablonbeállításokat igényelnek.

![PowerPoint parancsok diákmesterek beszúrásához és kezeléséhez](slide-master_9.jpg)

Az alábbi példa klónozza az alapértelmezett mestert, a klónnak másik hátteret ad, egy üres elrendezést kér le a klónozott mester alá, és egy új diát hoz létre ezen elrendezésből:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Diákmesterek összehasonlítása**

A diákmestereket a [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályból örökölt `equals` metódussal lehet összehasonlítani. Az összehasonlítás ellenőrzi a szerkezetet és a statikus tartalmat, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, mint a dia ID-k, vagy a dinamikus helyettesítő értékeket, például az aktuális dátumot.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

További információk: [Prezentációs diák összehasonlítása](/python-net/compare-slides/).

## **Diákmester nézet beállítása alapértelmezett nézetnek**

A prezentáció [ViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) osztályának `last_view` tulajdonságával szabályozhatja, hogy a PowerPoint mely nézetet nyissa meg először. Az alábbi példa a prezentációt Diákmester nézetben nyitja meg:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

További nézetbeállítások: [Prezentáció mentése](/python-net/save-presentation/).

## **Használaton kívüli diákmesterek eltávolítása**

Előfordulhat, hogy egy prezentáció olyan diákmestereket tartalmaz, amelyeket már egyetlen normál dia sem használ. A használaton kívüli mesterek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használja a `remove_unused` metódust a `masters` gyűjteményből a használaton kívüli mesterek eltávolításához:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

A low‑code `remove_unused_master_slides` metódus a [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztályban is elérhető:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a diákmester és az elrendezési dia között?**

A diákmester a közös tervezési beállításokat, például a sablont, hátteret, közös alakzatokat és szövegstílusokat határozza meg. Az elrendezési dia egy diákmesterhez tartozik, és egy konkrét helykitöltő elrendezést definiál. A normál dia egy elrendezési diát használ, így mind az elrendezés, mind a mester beállításait örökli.

**Tartalmazhat egy prezentáció több diákmestert is?**

Igen. Egy prezentáció több diákmestert is tartalmazhat. Használjon több mestert, ha a különböző szakaszok eltérő vizuális rendszereket vagy márkázást igényelnek.

**Hol kell helyettesítő objektumokat hozzáadni – a diákmesterhez vagy az elrendezési diához?**

A legtöbb esetben az elrendezési diákhoz kell hozzáadni a helyettesítőket. A közös vizuális elemeket és formázásokat a diákmesteren helyezze el, a tartalmi helyettesítőket pedig az elrendezéseken, amelyeket a normál diákok használnak.

**Törölhetek olyan diákmestert, amelyik még használatban van?**

Nem. Egy diákmester, amelynek vannak függő diái, nem távolítható el biztonságosan. Először mozgassa át ezeket a diákat egy másik mester alá tartozó layoutokra, vagy használja a használaton kívüli mesterek tisztító módszert, amely csak a nem használt mestereket távolítja el.