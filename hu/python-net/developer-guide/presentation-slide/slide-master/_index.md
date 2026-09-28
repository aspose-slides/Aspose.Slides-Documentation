---
title: Prezentáció dia-mesterek kezelése Pythonban
linktitle: Dia-mester
type: docs
weight: 80
url: /hu/python-net/slide-master/
keywords:
- dia-mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helykitöltő
- mester dia klónozása
- mester dia másolása
- mester dia duplikálása
- nem használt mester dia
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Dia-mesterek kezelése az Aspose.Slides for Python via .NET segítségével: hozzáférés, szerkesztés, klónozás, összehasonlítás és a mesterdiák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **dia-mester** meghatározza a közös tervezési beállításokat egy diacsoport számára. Tartalmazhat általános alakzatokat, logókat, háttérképeket, szövegstílusokat, téma beállításokat és lábléc beállításokat. PowerPointban a dia-mester szerkesztése a szokásos módja annak, hogy a bemutató egységes legyen anélkül, hogy minden dián újra és újra ugyanazt a formázást alkalmaznánk.

Aspose.Slides for Python via .NET támogatja ugyanazt a modellt. Egy bemutató tartalmazhat egy vagy több dia-mestert, és minden dia-mester több elrendezés-diát tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy dia-mesterre. Ehelyett egy normál dia egy elrendezés-diat használ, amely egy dia-mesterhez tartozik.

1. **Dia-mester** – meghatározza a közös tervezést és a témát.
1. **Elrendezés-diát** – meghatározza a helykitöltők és az elrendezés-szintű formázás konkrét elrendezését.
1. **Normál dia** – tartalmazza a tényleges bemutató tartalmat, és egy elrendezés-diat használ.

![A dia-mesterek, elrendezés-diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ben a dia-mestert a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) osztály képviseli. A bemutató összes dia-mestere elérhető a `Presentation.masters` gyűjteményen keresztül.

{{% alert color="info" title="Inheritance" %}}
Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyer. Például, ha egy dia-mester és egy elrendezés-dia egyaránt meghatároz egy hátteret, az azon az elrendezésen alapuló diák az elrendezés hátterét használják. További információért az elrendezés-diákról lásd a [Diaelrendezések alkalmazása vagy módosítása](/slides/hu/python-net/slide-layout/) oldalt.
{{% /alert %}}

## **Dia-mesterek elérése**

PowerPointban a Dia-mester nézetet a **Nézet** > **Dia-mester** menüből nyithatod meg.

![A Dia-mester parancs a PowerPoint Nézet fülön](slide-master_3.jpg)

Az Aspose.Slides-ben használd a `masters` gyűjteményt a mester-diák eléréséhez:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

A normál dia által használt mester-diát a saját elrendezésén keresztül is lekérheted:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Mi található egy Dia-mesterben**

Egy dia-mester egy diára hasonlító objektum. A közös dia-viselkedést a [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályból örökli, így ugyanazokat a dia-tulajdonságokat teszi elérhetővé, amelyeket a normál és az elrendezés-diák használnak. A mester-specifikus tagok a [MasterSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslide/) API oldalon találhatók.

A gyakran használt dia-mester tagok a következők:

| Tag | Cél |
| --- | --- |
| `background` | Beállítja a mester-szintű dia háttérét. |
| `shapes` | A mesterre helyezett alakzatokat tárolja, például logókat, képkereteket és megosztott szöveget. |
| `layout_slides` | Tárolja a mesterhez tartozó elrendezés-diákat. |
| `theme_manager` | Hozzáférést biztosít a mester téma API-khoz. |
| `header_footer_manager` | Kezeli a fejléceket, lábléceket, dátumokat és dia számokat a mester és annak alatti elrendezések számára. |
| `get_depending_slides` | Visszaadja a normál diákat, amelyek a mesterre a saját elrendezéseiken keresztül támaszkodnak. |

## **Kép hozzáadása egy Dia-mesterhez**

Ha képet adsz hozzá egy dia-mesterhez, az megjelenik azokon a diákon, amelyek az adott mester elrendezéseit használják. Ez hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

A következő példa egy logót ad hozzá az első dia-mesterhez:

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

További információért a képkeretekről lásd a [Képkeret](/slides/hu/python-net/picture-frame/) oldalt.

## **A mester grafika láthatóságának vezérlése**

Használd a [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/show_master_shapes/) metódust, hogy elrejtsd az örökölt mestergrafikát, például logókat vagy díszalakzatokat, anélkül, hogy törölnéd őket a mestertől. Állítsd a [Slide.show_master_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/show_master_shapes/) értékét `False`‑ra azon a dián, amelyik el szeretné hagyni ezeket a grafikákat, és `True`‑ra azokon a diákon, amelyek meg akarják jeleníteni őket.

A következő önálló példa egy kék díszszalagot hoz létre egy mesteren, valamint két diát, amelyek ugyanazt az üres elrendezést használják. A szalag az első dián látható, a másodikon rejtett. Bemutató vagy kép bemenet nincs szükség.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

A példa az új bemutatóval érkező **Blank** (Üres) elrendezést használja, és eltávolítja az első dia saját helykitöltőit.

### **Válaszd ki a beállítás hatókörét**

Egy normál dia a mesterét a [Slide.layout_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/slide/layout_slide/) és a [LayoutSlide.master_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/master_slide/) segítségével használja. Egy adott dián a tulajdonság beállítása csak arra a diára hat. A [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/show_master_shapes/) `False`‑ra állítása elrejti a mester grafikát azoknál a diák között, amelyek az adott közös elrendezést használják, még akkor is, ha azok beállítása `True`. Egyetlen dia grafikájának elrejtéséhez módosítsd a dia tulajdonságát, és hagyd változatlanul a közös elrendezést.

A beállítás nem támogatott láthatóság‑vezérlőként a dia-mesteren magán. Egy mesteren mindig `False`‑t ad vissza, és a `True` hozzárendelése kivételt vált ki. Alkalmazd normál diára vagy elrendezésre inkább.

### **A grafika és a háttér megkülönböztetése**

| Művelet | Hatás |
| --- | --- |
| Mestergrafika elrejtése | Az örökölt mesteralakzatok láthatóságát szabályozza, anélkül hogy törölné őket vagy módosítaná a dia saját alakzatait. |
| Dia háttér kitöltésének módosítása | Megváltoztatja a háttér színét, színátmenetét vagy képét. A mestergrafikák külön alakzatok, és láthatók maradhatnak a háttér felett. Lásd a [Prezentáció háttér](/slides/hu/python-net/presentation-background/) oldalt. |
| Mesterből alakzat törlése | Eltávolítja a megosztott forrásalakzatot, így már nem áll rendelkezésre semmilyen, a mestert használó dia számára. |

## **Helykitöltők kezelése**

A helykitöltőket általában elrendezés-diákon definiálják. A dia-mester biztosítja a közös stílust és témát, amelyet ezek az elrendezések örökölnek, míg minden elrendezés eldönti, mely helykitöltők érhetők el és hol helyezkednek el.

PowerPointban a helykitöltő parancsok a Dia-mester nézetben érhetők el.

![A Helykitöltő beszúrása parancs a PowerPoint Dia-mester nézetben](slide-master_5.png)

Az új helykitöltők hozzáadásához az Aspose.Slides segítségével dolgozz az elrendezés-diával, amely a mesterhez tartozik:

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

A már létező helykitöltő-alakzatokat is formázhatod a dia-mesteren. A következő példa megkeresi a cím helykitöltőt és lineáris színátmenetes kitöltést alkalmaz rá:

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

![Formázott cím helykitöltő, amely a normál diákra öröklődik](slide-master_8.png)

További helykitöltő- és szövegformázási lehetőségekért lásd a [Kérdés szöveg beállítása a helykitöltőben](/slides/hu/python-net/manage-placeholder/) és a [Szövegformázás](/slides/hu/python-net/text-formatting/) oldalakat.

## **Dia-mester háttér módosítása**

Egy mesterháttér az elrendezések és a diák által öröklődik, amelyek nem írják felül. A következő példa egy szilárd háttérszínt állít be az első dia-mesterhez:

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

Kapcsolódó témákért lásd a [Prezentáció háttér](/slides/hu/python-net/presentation-background/) és a [Prezentáció téma](/slides/hu/python-net/presentation-theme/) oldalakat.

## **Dia-mester klónozása egy másik bemutatóba**

Használd a `add_clone` metódust a [MasterSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterslidecollection/) osztályon, hogy egy dia-mestert másik bemutatóba másolj. A másolt mester ezután a cél bemutató elrendezései és diái által használható.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Ha a normál diákot a mesterrel együtt kell klónozni, lásd a [Diák klónozása](/slides/hu/python-net/clone-slides/) oldalt.

## **Több Dia-mester hozzáadása**

Egy bemutató tartalmazhat több dia-mestert. Ez akkor hasznos, ha a különböző szakaszok különböző márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok dia-mesterek beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mestert, a klónnak más háttérszínt ad, egy üres elrendezést kap a klónozott mester alatt, és egy új diát ad hozzá ehhez az elrendezéshez:

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

## **Dia-mesterek összehasonlítása**

A dia-mestereket a [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) osztályból örökölt `equals` metódussal lehet összehasonlítani. Az összehasonlítás ellenőrzi a struktúrát és a statikus tartalmat, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, például a dia ID-ket, vagy a dinamikus helykitöltő értékeket, mint a jelenlegi dátum.

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

További információért lásd a [Prezentáció diák összehasonlítása](/slides/hu/python-net/compare-slides/) oldalt.

## **Dia-mester nézet beállítása alapértelmezett nézetként**

Használd a `last_view` tulajdonságot a bemutató [ViewProperties](https://reference.aspose.com/slides/hu/python-net/aspose.slides/viewproperties/) osztályán, hogy a PowerPoint elsőként megnyitott nézetét irányítsd. A következő példa a bemutatót a Dia-mester nézetben nyitja meg:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

További nézetbeállításokért lásd a [Bemutató mentése](/slides/hu/python-net/save-presentation/) oldalt.

## **Nem használt Dia-mesterek eltávolítása**

A bemutatók néha tartalmaznak olyan dia-mestereket, amelyeket már egyetlen normál dia sem használ. A nem használt mesterek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablonkarbantartást.

Használd a `remove_unused`‑t, hogy a nem használt mestereket a `masters` gyűjteményből eltávolítsd:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Alacsony kóddal is használhatod a `remove_unused_master_slides` metódust a [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztályból:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a dia-mester és az elrendezés-dia között?**

Egy dia-mester közös tervezési beállításokat határoz meg, mint a téma, háttér, közös alakzatok és szövegstílusok. Egy elrendezés-dia egy dia-mesterhez tartozik, és egy konkrét helykitöltő elrendezést definiál. Egy normál dia egy elrendezés-diát használ, így mind az elrendezésből, mind a mesterből örököl.

**Tartalmazhat egy bemutató több dia-mestert?**

Igen. Egy bemutató több dia-mestert is tartalmazhat. Használj több mestert, ha a különböző szakaszok különböző vizuális rendszereket vagy márkázást igényelnek.

**Hová tegyek helykitöltőket, a dia-mesterbe vagy az elrendezés-diába?**

A legtöbb esetben az elrendezés-diákba kell helykitöltőket adni. A közös vizuális elemeket és a közös formázást a dia-mesterre helyezd, a tartalomhelykitöltőket pedig azokra az elrendezésekre, amelyeket a normál diák használnak.

**Törölhetek egy még használt dia-mestert?**

Nem. Egy olyan dia-mester, amelynek vannak függő diái, nem távolítható el biztonságosan közvetlenül. Először helyezd át ezeket a diákat egy másik mester alá lévő elrendezésekbe, vagy használj egy nem használt mester takarítási módszert, amely csak a nem használt mestereket távolítja el.