---
title: Alakzat hatékony tulajdonságainak lekérése prezentációkból Python használatával
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/python-net/shape-effective-properties/
keywords:
- alakzati tulajdonságok
- kamera tulajdonságok
- világítási rig
- élvágásos alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan számítja ki és alkalmazza az Aspose.Slides for Python .NET-en keresztül a hatékony alakzati tulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és a **hatékony** tulajdonságok közötti különbséget. Helyi értékek azok az értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. A dián lévő rész (portion) tulajdonságai.
2. A sablon alakzat szövegstílusai egy elrendezésen vagy master diámon, ha a rész szövegkeret alakzatának van ilyen.
3. Globális szövegbeállítások egy prezentációban.

A helyi értékek meghatározhatók vagy kihagyhatók bármely szinten. Amikor az Aspose.Slides-nek a végleges, megjelenített formázásra van szüksége, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. A `get_effective` metódus hívásával a helyi formátumobjektumon megkaphatja őket.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dián az első alakzat egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) szövegkerettel és legalább egy részzel (portion).

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
A hatékony formázási adatok azt a jelenlegi számított formázást képviselik, miután az öröklődés alkalmazásra került. A jelenlegi megvalósításban egyes hatékony adatobjektumok, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iportionformateffectivedata/), lehetnek belsőleg gyorsítótárazva. A `get_effective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem képviselheti a korábbi állapotot. Ha a hatékony értékeket későbbi újrafelhasználásra meg kell őrizni, másolja a szükséges tulajdonságokat, például betűmagasság, kitöltőszín, betűstílus vagy igazítás, a saját adatobjektumába.
{{% /alert %}}

## **A Kamera Hatékony Tulajdonságainak Lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icameraeffectivedata/) típus egy változtathatatlan objektumot képvisel, amely a kamera hatékony tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) hatékony értékeit biztosítja.

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

## **A Light Rig Hatékony Tulajdonságainak Lekérése**

Az Aspose.Slides lehetővé teszi a Light Rig hatékony tulajdonságainak lekérését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ilightrigeffectivedata/) típus egy változtathatatlan objektumot képvisel, amely a Light Rig hatékony tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) hatékony értékeit biztosítja.

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

## **A Bevel Alakzat Hatékony Tulajdonságainak Lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat bevonásának (bevel) hatékony tulajdonságainak lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapebeveleffectivedata/) típus egy változtathatatlan objektumot képvisel, amely a alakzat felületi domborítási tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [ThreeDFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/threedformat/) hatékony értékeit biztosítja.

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

## **A Szövegkeret Hatékony Tulajdonságainak Lekérése**

Az Aspose.Slides használatával lekérheti a szövegkeret hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/itextframeformateffectivedata/) típus hatékony szövegkeret‑formázási tulajdonságokat tartalmaz.

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

## **A Szövegstílus Hatékony Tulajdonságainak Lekérése**

Az Aspose.Slides használatával lekérheti a szövegstílus hatékony tulajdonságait. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/itextstyleeffectivedata/) típus hatékony szövegstílus‑tulajdonságokat tartalmaz.

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

## **A Hatékony Betűmagasság Értékének Lekérése**

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy rész hatékony betűmagassága, miután a helyi betűmagasság‑értékeket különböző prezentációs szerkezet‑szinteken állítják be.

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

## **A Táblázat Hatékony Kitöltési Formátumának Lekérése**

Az Aspose.Slides segítségével lekérheti a táblázat különböző részeinek hatékony kitöltési formátumát. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ifillformateffectivedata/) típus hatékony kitöltési formázási tulajdonságokat tartalmaz. A cella formázása magasabb prioritással bír, mint a sor formázása, a sor formázása magasabb, mint az oszlop formázása, és az oszlop formázása magasabb, mint a teljes táblázat formázása.

Ennek következtében a [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/python-net/aspose.slides/icellformateffectivedata/) tulajdonságait használják a táblázatcellák megrajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formátumát lekérni. Feltételezi, hogy az első dián az első alakzat egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/).

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

## **GYIK**

**Visszaadja a `get_effective` a pillanatfelvételt?**

Nem mindig. A hatékony adatok az öröklődés alkalmazása után kiszámított formázást képviselik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazva lehetnek. Egy későbbi `get_effective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, ezért egy korábban lekért objektumot nem szabad tartós pillanatfelvételnek tekinteni.

**Mikor kell újra beolvasni a hatékony tulajdonságokat?**

Hívja újra a `get_effective`-t a helyi formázás, szülő‑stílusok, elrendezés‑formázás, master‑formázás vagy a prezentáció‑szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát, és a jelenlegi hatékony eredményt adja vissza.

**A layout/master dia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?**

Igen, de a változás a következő `get_effective` hívásra lép hatályba. Ha egy szülő formázási forrás módosul vagy eltávolításra kerül, a korábban lekért hatékony adatok elavulttá válhatnak. Miután a `get_effective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

**Módosíthatok értékeket a hatékony adatobjektumokon keresztül?**

Nem. A hatékony adatobjektumok csak a kiszámított értékeket mutatják. Változtatásokat a helyi formázási objektumokban kell végezni, majd újra le kell kérni a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem a layout/master szinten, sem a globális beállításokban?**

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely tartalmazza a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a feloldott érték a jelenlegi hatékony adatok részévé válik.

**A hatékony betűértékből megállapítható, melyik szint határozta meg a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adat a végső értéket adja vissza. A forrást úgy találhatja meg, ha ellenőrzi a helyi értékeket a rész, bekezdés, szövegkeret és a szövegstílusok szintjein az elrendezésen, masteren és a prezentáción, hogy melyik definíció jelenik meg először.

**Miért tűnnek a hatékony értékek néha azonosnak a helyi értékekkel?**

Mert a helyi érték végül végleges lett (magasabb szintű öröklődés nem volt szükséges). Ilyen esetekben a hatékony érték megegyezik a helyi értékkel.

**Mikor érdemes hatékony tulajdonságokat használni, és mikor csak helyi értékekkel dolgozni?**

Használja a hatékony adatokat, amikor a „megjelenített” eredményre van szüksége az összes öröklődés után, például színek, behúzások vagy méretek egyeztetésénél. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül meg kell őrizni, másolja a szükséges tulajdonságokat a saját objektumába. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, és ha szükséges, olvassa újra a hatékony adatokat a végeredmény ellenőrzéséhez.