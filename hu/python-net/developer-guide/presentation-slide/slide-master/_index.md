---
title: Prezentáció slide master-ek kezelése Pythonban
linktitle: Dia Master
type: docs
weight: 80
url: /hu/python-net/slide-master/
keywords:
- dia master
- master dia
- PPT master dia
- több master dia
- master diák összehasonlítása
- háttér
- helyőrző
- master dia klónozása
- master dia másolása
- master dia megkettőzése
- nem használt master dia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Az Aspose.Slides for Python via .NET segítségével kezelje a slide master-eket: hozzáférés, szerkesztés, klónozás, összehasonlítás és a master diák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **slide master** meghatározza a közös tervezési beállításokat egy diárcsoport számára. Tartalmazhat közös alakzatokat, logókat, háttérképeket, szövegstílusokat, téma‑beállításokat és lábléc‑beállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy egy bemutató egységes maradjon anélkül, hogy minden dián ugyanazt a formázást ismételnénk.

Az Aspose.Slides for Python via .NET ugyanazt a modellt támogatja. Egy prezentáció egy vagy több master diát tartalmazhat, és minden master dia több elrendezésdát is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy master diára. Ehelyett egy normál dia egy elrendezésdiát használ, és az elrendezésdia egy master diához tartozik.

A hierarchia:

1. **Slide master** – meghatározza a közös tervezést és a témát.  
1. **Layout slide** – meghatároz egy adott helyőrző‑elrendezést és elrendezési‑szintű formázást.  
1. **Normal slide** – a tényleges bemutatótartalmat tartalmazza, és egy elrendezésdiát használ.

![A master diák, elrendezésdiák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slidesban egy slide master a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) osztállyal van reprezentálva. A prezentáció összes master diája a `Presentation.masters` gyűjteményen keresztül érhető el.

{{% alert color="info" title="Inheritance" %}}
Amikor ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy master dia és egy elrendezésdia is meghatároz egy hátteret, akkor az arra épülő diák az elrendezés háttérét használják. A elrendezésdiákról további információkat a [Apply or Change Slide Layouts](/slides/hu/python-net/slide-layout/) oldalon talál.
{{% /alert %}}

## **A Slide Master elérése**

PowerPointban a **Nézet** > **Dia Master** menüponttal nyithatja meg a Slide Master nézetet.

![A Slide Master parancs a PowerPoint Nézet lapján](slide-master_3.jpg)

Az Aspose.Slidesban a `masters` gyűjtemény segítségével érheti el a master diákat:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

A normál dia által használt master diát a saját elrendezésén keresztül is lekérdezheti:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Mi található egy Slide Masterben**

A master dia egy dia‑szerű objektum. A [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztálytól örököl közös dia‑viselkedést, ezért számos, a normál és elrendezésdíáknál használt dia‑tulajdonságot is elérhetővé tesz. A master‑specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) API oldalon vannak felsorolva.

Gyakran használt master dia tagok:

| Tag | Cél |
| --- | --- |
| `background` | Beállítja a master‑szintű dia hátterét. |
| `shapes` | A masterre helyezett alakzatokat tárolja, például logókat, képkockákat és megosztott szöveget. |
| `layout_slides` | A masterhez tartozó elrendezésdíákat tárolja. |
| `theme_manager` | Hozzáférést biztosít a master téma API‑khoz. |
| `header_footer_manager` | A master és annak gyermekelrendezései fejlécét, láblécét, dátumát és dia számait szabályozza. |
| `get_depending_slides` | Visszaadja azokat a normál diákat, amelyek elrendezésükön keresztül a masterre támaszkodnak. |

## **Kép hozzáadása egy Slide Masterhez**

Amikor egy képet ad hozzá egy master diához, az a master‑hez tartozó elrendezéseket használó diákon is megjelenik. Ez logók, vízjelekkel, díszbannerekkel és egyéb ismétlődő vizuális elemek esetén hasznos.

Az alábbi példa egy logót ad az első master diához:

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

A képkockákról további információkat a [Picture Frame](/slides/hu/python-net/picture-frame/) oldalon talál.

## **Munkavégzés a helyőrzőkkel**

A helyőrzőket általában az elrendezésdíákon definiálják. A master dia biztosítja a közös stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés dönti el, hogy milyen helyőrzők állnak rendelkezésre és hová kerülnek.

PowerPointban a helyőrző‑parancsok a Slide Master nézetben érhetők el.

![A Helyőrző Beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides használatával dolgozzon a masterhez tartozó elrendezésdíával:

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

Már meglévő helyőrző alakzatok formázása is lehetséges egy master dián. Az alábbi példa megtalálja a címsor‑helyőrzőt és lineáris színátmenetes kitöltést alkalmaz rá:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Formázott címsor‑helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző- és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/python-net/manage-placeholder/) és a [Text Formatting](/slides/hu/python-net/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér öröklődik az elrendezésekre és a diákra, amelyik nem írja felül. Az alábbi példa egy egyszínű háttérszínt állít be az első master diára:

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

Kapcsolódó témák: [Presentation Background](/slides/hu/python-net/presentation-background/) és [Presentation Theme](/slides/hu/python-net/presentation-theme/).

## **Slide Master klónozása egy másik prezentációba**

Használja a `add_clone` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) osztályon, hogy egy master diát egy másik prezentációba másoljon. A másolt master ezután az új prezentáció elrendezései és diái által használható.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Ha normál diákot is klónozni kell a saját masterével együtt, lásd a [Clone Slides](/slides/hu/python-net/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy prezentáció több master diát is tartalmazhat. Ez akkor hasznos, ha különböző szakaszok különböző márkaarculatot, oldalstruktúrát vagy téma‑beállításokat igényelnek.

![PowerPoint parancsok master diák beszúrásához és kezeléséhez](slide-master_9.jpg)

Az alábbi példa a visszairányított master klónozását, más háttérrel ellátását, egy üres elrendezés lekérését a klónozott master alatt, majd egy új dia hozzáadását a szóban forgó elrendezés alapján mutatja be:

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

## **Slide Master összehasonlítása**

A master diák összehasonlíthatók a [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályból örökölt `equals` metódussal. Az összehasonlítás a szerkezetet és a statikus tartalmat (alakzatok, szöveg, formázás, animációk, egyéb dia‑beállítások) vizsgálja. Nem hasonlítja össze az egyedi azonosítókat, például a dia‑azonosítókat, vagy a dinamikus helyőrző‑értékeket, például az aktuális dátumot.

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

További információkért lásd a [Compare Presentation Slides](/slides/hu/python-net/compare-slides/) oldalt.

## **Slide Master nézet beállítása alapértelmezett nézetnek**

A prezentáció [ViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) osztályának `last_view` tulajdonságával szabályozható, hogy a PowerPoint milyen nézetben nyissa meg a fájlt először. Az alábbi példa a prezentációt Slide Master nézetben nyitja meg:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/python-net/save-presentation/) oldalt.

## **Nem használt master diákok eltávolítása**

Előfordulhat, hogy egy prezentáció olyan master diákat tartalmaz, amelyeket már egyetlen normál dia sem használ. A nem használt master diák eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használja a `remove_unused` metódust a `masters` gyűjteményből a nem használt master diák eltávolítására:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Alacsony‑kódszintű megoldásként használhatja a [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztály `remove_unused_master_slides` metódusát is:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

### Mi a különbség a slide master és az layout slide között?

A slide master közös tervezési beállításokat határoz meg, például témát, hátteret, közös alakzatokat és szövegstílusokat. Egy layout slide egy master diához tartozik, és egy adott helyőrző‑elrendezést definiál. Egy normál dia egy layout slide‑ot használ, így a layout és a master is öröklődik.

### Tartalmazhat egy prezentáció több slide mastert is?

Igen. Egy prezentáció több slide mastert is tartalmazhat. Több master használata akkor ajánlott, ha különböző szakaszok különböző vizuális rendszereket vagy márkaarculatot igényelnek.

### Hol helyezzek elhelyezőket – a master diába vagy az layout diába?

A legtöbb esetben az elrendezésdíákba helyezzen elhelyezőket. A közös vizuális elemeket és a közös formázást a master diába tegye, a tartalom helyőrzőket pedig azokra az elrendezésdíákra, amelyeket a normál diák használnak.

### Törölhetem-e egy master diát, amelyet még használnak?

Nem. Egy master diát, amelynek függő diái vannak, nem lehet biztonságosan közvetlenül eltávolítani. Előbb mozgassa át azokat a diákat egy másik masterhez tartozó elrendezés alá, vagy használjon olyan tisztító módszert, amely csak a nem használt master diákat távolítja el.