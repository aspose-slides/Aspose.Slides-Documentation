---
title: "PowerPoint alakzatok formázása Pythonban"
linktitle: "Alakzat formázása"
type: docs
weight: 20
url: /hu/python-net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakzatvonal
- csatlakozási stílus formázása
- gradiens kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- szilárd szín kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D bevágás hatás
- 3D forgatás hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Pythonban az Aspose.Slides segítségével—állítson be kitöltési, vonal- és effektus stílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes kontrollal."
---
## **Bevezetés**

Formázza az alakzatokat a PowerPointban az outline-ok, kitöltések és effektusok beállításával. Az Aspose.Slides for Python via .NET lehetővé teszi, hogy ezeket a beállításokat programozottan szabályozza, beleértve az átlátszóságot, forgatást és a 3D formázást.

![Alakzat formázási lehetőségek a PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for Python via .NET osztályokat és tulajdonságokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazon beállításokkal.

## **Vonalak formázása**

Használja a [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)‑t a forma körvonalának vezérléséhez. Ez a példa egy kitöltetlen téglalapot hoz létre kék, szaggatott körvonallal. A [LineFormat.style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/style/) vastag‑vékony összetett vonalat választ, míg a [LineFormat.width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) a szélességet 7 pontra állítja, és a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) a szaggatási mintát választja.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.style = slides.LineStyle.THICK_THIN
    shape.line_format.width = 7
    shape.line_format.dash_style = slides.LineDashStyle.DASH
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("formatted_lines.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A formázott vonalak a bemutatóban](formatted-lines.png)

### **Egyéni vonaldiákok mintáinak beállítása**

Használja a [LineFormat.custom_dash_pattern](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/custom_dash_pattern/)‑t, ha az előre definiált vonalstílusok nem biztosítják a szükséges dash‑hosszúságokat és hézagokat, például márkázott körvonalak vagy technikai diagramok esetén. A minta hozzárendelése automatikusan beállítja a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)‑t a [LineDashStyle.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)-ra.

A listaelemek szétváltanak dash‑ és gap‑hosszúságok között, az első dash‑szel kezdve. Minden érték a vonalvastagság többszöröse: `[4, 2]` 3 pont szélességnél 12 pontos dash‑t, majd 6 pontos gap‑et eredményez. Véges, nem negatív értékpárokat használjon a komplett dash‑gap szegmensek meghatározásához. A példa pozitív értékeket használ, hogy minden dash és gap látható legyen.

Ez a példa öt kék vonalat hoz létre azonos hosszúsággal és egyenes sarokkal. Az első három a 3 pont szélességű mintákat hasonlítja össze. A negyedik megismétli az első mintát duplájára növelt szélességgel, így a dash‑ és gap‑hosszok is duplázódnak. Az ötödik egy egyéni mintáról egy szilárd vonalra vált.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(600, 300, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ]

    for i, pattern in enumerate(patterns):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 50 + i * 50, 500, 0)
        line.line_format.width = 6 if i == 3 else 3
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.cap_style = slides.LineCapStyle.FLAT
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.custom_dash_pattern = pattern

    # Az utolsó vonalat visszaállítja szilárd stílusra.
    slide.shapes[4].line_format.dash_style = slides.LineDashStyle.SOLID

    presentation.save("custom_dash_patterns.pptx", slides.export.SaveFormat.PPTX)
```

Az előre definiált szaggatott stílus visszaállításához állítsa a [LineDashStyle.DASH](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)-t a [LineFormat.dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/)-ra. A kiválasztott stílus határozza meg a vonal megjelenését.

Az eredmény PowerPointban, felülről lefelé: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; és **Szilárd, 3 pt**.

![Három egyéni dash‑minta, egy szélesebb vonal az első mintával és egy szilárd vonal a PowerPointban](custom-dash-patterns.png)

### **Vonalak végeinek beállítása**

Használja a [LineFormat.cap_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/cap_style/)‑t a nyitott vonal végének beállításához. A [LineCapStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linecapstyle/) felsorolás három kifejezett cap‑stílust biztosít:

- `FLAT`: A vonal a végpontnál leáll.
- `ROUND`: Félkör alakú cap húzódik a végponttól a vonalvastagság felével.
- `SQUARE`: Négyzetes cap húzódik a végponttól a vonalvastagság felével.

A felsorolás tartalmazza a `NOT_DEFINED` értéket is, ami azt jelenti, hogy nincs kifejezetten hozzárendelt cap‑stílus.

A cap‑ek különböznek a nyilak végétől, amelyek szimbólumot adnak a vonal végéhez, és az ívek (joins)‑től, amelyek a vonal szegmensek közti sarkokat szabályozzák. Ez a példa letiltja a nyilakat a [LineFormat.begin_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/begin_arrowhead_style/) és a [LineFormat.end_arrowhead_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/end_arrowhead_style/) használatával, így csak a cap‑alakok kerülnek összehasonlításra.

A következő példa három egyébként azonos vízszintes vonalat hoz létre, 20 pont széles. Felülről lefelé lapos, kerek és négyzetes cap‑eket használnak. Végpontjaiknak ugyanaz a vízszintes koordinátájuk; a kerek és négyzetes cap‑ek 10 ponttal túlnyúlnak minden végponton.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 240, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    cap_styles = [slides.LineCapStyle.FLAT, slides.LineCapStyle.ROUND, slides.LineCapStyle.SQUARE]

    for i, cap_style in enumerate(cap_styles):
        line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 100, 50 + i * 70, 300, 0)
        line.line_format.width = 20
        line.line_format.fill_format.fill_type = slides.FillType.SOLID
        line.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        line.line_format.dash_style = slides.LineDashStyle.SOLID
        line.line_format.cap_style = cap_style
        line.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.NONE
        line.line_format.end_arrowhead_style = slides.LineArrowheadStyle.NONE

    presentation.save("line_caps.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény PowerPointban, felülről lefelé: **Flat**, **Round**, és **Square**.

![Lapos, kerek és négyzetes cap‑ek azonos vastag vonalakon a PowerPointban](line-caps.png)

## **Vázlatos effektek alkalmazása az alakzatvonalakra**

A vázlatos effektus egy alakzatvonalat kézzel rajzoltként jelenít meg. Használja a [Shape.line_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/line_format/)‑t a vonal beállítások eléréséhez, a [LineFormat.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/sketch_format/)‑t a vázlat beállításokhoz, és a [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/)‑t a [LineSketchType](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) felsorolásból történő érték kiválasztásához.

A következő Python kód azt mutatja, hogyan alkalmazzon egy [LineSketchType.CURVED](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) effektust, olvassa ki a kifejezetten hozzárendelt értéket, és távolítsa el az effektust a [LineSketchType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/linesketchtype/) használatával:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)

    sketch_format = shape.line_format.sketch_format
    sketch_format.sketch_type = slides.LineSketchType.CURVED
    explicit_sketch_type = sketch_format.sketch_type
    print(f"Explicit sketch type: {explicit_sketch_type}")
    sketch_format.sketch_type = slides.LineSketchType.NONE
```

A [SketchFormat.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/sketchformat/sketch_type/) által visszaadott érték a formára közvetlenül beállított konfigurációt jelenti. Ha a vonalformázást egy téma, mesterdia vagy elrendezés dia örökölheti, használja a [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/)-t, érje el az [ILineFormatEffectiveData.sketch_format](https://reference.aspose.com/slides/python-net/aspose.slides/ilineformateffectivedata/sketch_format/)-t, és olvassa a [ISketchFormatEffectiveData.sketch_type](https://reference.aspose.com/slides/python-net/aspose.slides/isketchformateffectivedata/sketch_type/)-t. A hatékony érték tükrözi a formázást, amelyet ténylegesen alkalmaznak az öröklődés feloldása után. Ez a példa egy létező prezentációt igényel, amelynek első diáján legalább egy alakzata van, és kiírja mindkét értéket:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    line_format = shape.line_format
    explicit_sketch_type = line_format.sketch_format.sketch_type
    effective_line_format = line_format.get_effective()
    effective_sketch_type = effective_line_format.sketch_format.sketch_type

    print(f"Explicit sketch type: {explicit_sketch_type}")
    print(f"Effective sketch type: {effective_sketch_type}")
```

## **Csatlakozási stílusok formázása**

Itt vannak a három csatlakozási típus opciói:

* Round
* Miter
* Bevel

A csatlakozási stílus szabályozza, hogyan találkoznak két körvonal szegmens a saroknál. Használja a **Round**‑t a lekerekített sarkokhoz, a **Miter**‑t a éles sarkokhoz, vagy a **Bevel**‑t a lelapított sarkokhoz.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Ez a példa három fekete téglalapot hoz létre kék, 15 pont széles körvonallal. Beállítja a [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/)‑t a miter, bevel és round értékekre a [LineJoinStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/)-ból, hogy összehasonlítsa, hogyan rajzolódnak a sarkok.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    miter_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 75)
    bevel_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 210, 20, 150, 75)
    round_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 135, 150, 75)

    miter_shape.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.fill_format.solid_fill_color.color = draw.Color.black
    bevel_shape.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.fill_format.solid_fill_color.color = draw.Color.black
    round_shape.fill_format.fill_type = slides.FillType.SOLID
    round_shape.fill_format.solid_fill_color.color = draw.Color.black

    miter_shape.line_format.width = 15
    bevel_shape.line_format.width = 15
    round_shape.line_format.width = 15

    miter_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    miter_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    bevel_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    bevel_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    round_shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    round_shape.line_format.fill_format.solid_fill_color.color = draw.Color.blue

    miter_shape.line_format.join_style = slides.LineJoinStyle.MITER
    bevel_shape.line_format.join_style = slides.LineJoinStyle.BEVEL
    round_shape.line_format.join_style = slides.LineJoinStyle.ROUND

    miter_shape.text_frame.text = "Miter Join Style"
    bevel_shape.text_frame.text = "Bevel Join Style"
    round_shape.text_frame.text = "Round Join Style"

    presentation.save("join_styles.pptx", slides.export.SaveFormat.PPTX)
```

### **Miter csatlakozások korlátozása éles sarkoknál**

Használja a [LineFormat.miter_limit](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/miter_limit/)‑t a [LineFormat.join_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/join_style/)‑vel beállítva a [LineJoinStyle.MITER](https://reference.aspose.com/slides/python-net/aspose.slides/linejoinstyle/)-ra, hogy korlátozza, milyen messzire nyúlhat egy éles sarok.

A limit a csatlakozás belső és külső sarkai közti távolság és a vonalvastagság aránya. Például a `8` érték legfeljebb nyolcszoros vonalvastagságú miter‑hosszt engedélyez; ez nem pontban mérve. Ha a sarok meghaladná a limitet, a PowerPoint lelapítja a sarkot. Nagyobb limit élesebb pontokat eredményez. Ez a beállítás csak a miter csatlakozásokra vonatkozik, és nincs látható hatása, ha a sarok a limiteken belül marad.

Ez a példa két azonos, kitöltetlen háromszöget hoz létre 20 pont széles körvonallal. A bal háromszög `2` limitet, a jobb `8`‑at használ. Mindkét háromszög 80 pont széles és 160 pont magas, így a felső sarok körülbelül `4,12`‑es miter‑hossz/vastagság arányt ad. Ennek következtében a PowerPoint a bal csúcsot lelapítja, a jobb csúcsot megőrzi.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(500, 320, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    miter_limits = [2.0, 8.0]

    for i, miter_limit in enumerate(miter_limits):
        triangle = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 90 + i * 240, 110, 80, 160)
        triangle.fill_format.fill_type = slides.FillType.NO_FILL
        triangle.line_format.width = 20
        triangle.line_format.fill_format.fill_type = slides.FillType.SOLID
        triangle.line_format.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
        triangle.line_format.join_style = slides.LineJoinStyle.MITER
        triangle.line_format.miter_limit = miter_limit

    presentation.save("miter_limits.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény PowerPointban: **Miter limit 2** a bal oldalon és **miter limit 8** a jobb oldalon.

![Egy lelapított csúcs miter limit 2-vel és egy hegyes csúcs miter limit 8-cal a PowerPointban](miter-limits.png)

## **Gradiens kitöltés**

A gradiens kitöltés színeket kever egy alakzatban. Ez a példa egy ellipszist tölt be lineáris gradienssel 45 fokos szögben a pirostól a lila felé a [FillFormat.gradient_format](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/gradient_format/)- segítségével. A [GradientStopCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/gradientstopcollection/add/) metódus a színállomásokat 0‑nál és 1‑nél, a gradiens elején és végén helyezi el. A meglévő állomások törlése biztosítja, hogy csak ez a két szín legyen használva.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
    shape.fill_format.gradient_format.linear_gradient_angle = 45
    shape.fill_format.gradient_format.gradient_stops.clear()
    shape.fill_format.gradient_format.gradient_stops.add(1.0, slides.PresetColor.PURPLE)
    shape.fill_format.gradient_format.gradient_stops.add(0.0, slides.PresetColor.RED)

    presentation.save("gradient_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az ellipszis gradiens kitöltéssel](gradient-fill.png)

Ha egy gradiens másként néz ki egy exportált képen, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/python-net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy megjelenítési stílust a gradiens kitöltés módosítása nélkül.

### **Lineáris gradiens szög beállítása**

Használja a [GradientFormat.linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/)‑t a [GradientShape.LINEAR](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) kitöltés orientációjának szabályozásához. A szöget fokban mérik, és az óramutató járása szerint növekszik: `0` balról jobbra, `90` fentről lefele, `180` jobbról balra, `270` lentről felfelé. Tört szögeket is támogat. A `[0, 360)` tartományon kívüli véges szögeket egy teljes körre normalizálják; például a `-45` `315`‑t, a `360` `0`‑t eredményez.

Ez a példa hat téglalapot hoz létre azonos piros, zöld és kék állomásokkal a `0`, `0.5` és `1` pozíciókban. A méretezés le van tiltva, hogy a szöget a téglalapok arányaitól függetlenül lehessen összehasonlítani. A szögek, balról jobbra: `0`, `45` és `90` az első sorban, valamint `135`, `180` és `270` a második sorban.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    angles = [0, 45, 90, 135, 180, 270]

    for i, angle in enumerate(angles):
        x = 30 + (i % 3) * 230
        y = 30 + (i // 3) * 190

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 200, 150)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.FALSE
        gradient.linear_gradient_angle = angle

    presentation.save("linear_gradient_angles.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény PowerPointban:

![Lineáris gradiens 0, 45 és 90 fokban a felső sorban, valamint 135, 180 és 270 fokban az alsó sorban](linear-gradient-angles.png)

### **Gradiens méretezése az alakzattal**

A [GradientFormat.linear_gradient_scaled](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_scaled/) egy [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) értéket fogad. Állítsa explicit `FALSE`‑ra, hogy a geometriai gradiens szög megmaradjon a forma arányainak változása mellett, vagy `TRUE`‑ra, hogy a gradiens a forma szélességével és magasságával méreteződjön. Méretezés engedélyezése esetén a látható szög eltérhet a hozzárendelt szögtől nem négyzetes alakzatnál.

A következő példa `45` fokos szöget és ugyanazokat a színállomásokat használja, mint a szögek összehasonlításánál. A bal oszlop `FALSE`‑t, a jobb oszlop `TRUE`‑t használ. Minden oszlop egy széles téglalapot tartalmaz a tetején, egy magas téglalapot alul. Mindkettő ugyanazzal a széles mérettel indul; a második téglalap szélességének és magasságának módosítása azt mutatja, hogyan reagál a kitöltés a méretezésre anélkül, hogy megváltoztatná a gradiens beállításait.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 460, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    scaling_options = [slides.NullableBool.FALSE, slides.NullableBool.TRUE]

    for column, scaling in enumerate(scaling_options):
        for row in range(2):
            x = 30 + column * 360
            y = 30 if row == 0 else 150

            shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 300, 90)
            shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
            shape.fill_format.fill_type = slides.FillType.GRADIENT

            gradient = shape.fill_format.gradient_format
            gradient.gradient_shape = slides.GradientShape.LINEAR
            gradient.gradient_stops.clear()
            gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
            gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
            gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
            gradient.linear_gradient_angle = 45
            gradient.linear_gradient_scaled = scaling

            if row == 1:
                shape.width = 90
                shape.height = 280

    presentation.save("linear_gradient_scaling.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény PowerPointban, bal oldalon a méretezés letiltva, jobb oldalon engedélyezve:

![Széles és magas téglalapok 45 fokos gradienssel, a bal oldalon a linear_gradient_scaled FALSE, a jobb oldalon TRUE](linear-gradient-scaling.png)

Méretezés letiltásakor a átlós színcsíkok ugyanazt az orientációt tartják mindkét téglalapban. Méretezés engedélyezésekor a csíkok a forma arányaihoz igazodnak. Ez segít reprodukálni egy sablon gradiensét, amikor az alakzatot más méretre alakítják. Négyzetes alakzat esetén a méretezés engedélyezése nem változtatja meg a `45` fokos gradiens megjelenését.

Mind a szög, mind a méretezés beállítás a lineáris gradiensre vonatkozik. Nem befolyásolják a [GradientShape.RADIAL vagy GradientShape.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/gradientshape/) kitöltéseket.

### **Szög kombinálása a gradiens irányával**

A [GradientFormat.gradient_direction](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/gradient_direction/) egy gradiens stílust választ a [GradientDirection](https://reference.aspose.com/slides/python-net/aspose.slides/gradientdirection/) felsorolásból; ez nem helyettesíti a numerikus szöget. Lineáris gradiensnél a sarokstílusok megváltoztathatják a színek eloszlási területét anélkül, hogy a [linear_gradient_angle](https://reference.aspose.com/slides/python-net/aspose.slides/gradientformat/linear_gradient_angle/)-t módosítaná. Tartsa a irányt változatlanul, amikor szögeket vagy méretezést hasonlít.

A következő példa ugyanazt a beállítást fordított sorrendben alkalmazza. A két téglalap ugyanúgy néz ki: a irány előtti vagy utáni szög beállítása nem változtatja az eredményt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    for i in range(2):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 30 + i * 140, 320, 100)
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        shape.fill_format.fill_type = slides.FillType.GRADIENT

        gradient = shape.fill_format.gradient_format
        gradient.gradient_shape = slides.GradientShape.LINEAR
        gradient.gradient_stops.clear()
        gradient.gradient_stops.add(0.0, slides.PresetColor.RED)
        gradient.gradient_stops.add(0.5, slides.PresetColor.LIME)
        gradient.gradient_stops.add(1.0, slides.PresetColor.BLUE)
        gradient.linear_gradient_scaled = slides.NullableBool.TRUE

        if i == 0:
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1
            gradient.linear_gradient_angle = 30
        else:
            gradient.linear_gradient_angle = 30
            gradient.gradient_direction = slides.GradientDirection.FROM_CORNER1

    presentation.save("linear_gradient_direction.pptx", slides.export.SaveFormat.PPTX)
```

## **Minta kitöltés**

Egy minta kitöltés két színű dizájnt alkalmaz, például pontokat, csíkokat vagy kockákat. Ez a példa a [PatternFormat.pattern_style](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/pattern_style/)‑t használja egy trellis minta kiválasztásához. A [PatternFormat.back_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/back_color/) a világosszürke hátteret, a [PatternFormat.fore_color](https://reference.aspose.com/slides/python-net/aspose.slides/patternformat/fore_color/) a sárga minta színt adja.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.PATTERN
    shape.fill_format.pattern_format.pattern_style = slides.PatternStyle.TRELLIS
    shape.fill_format.pattern_format.back_color.color = draw.Color.light_gray
    shape.fill_format.pattern_format.fore_color.color = draw.Color.yellow

    presentation.save("pattern_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Képkönyv kitöltés**

A képkönyv kitöltés egy képet használ egy alakzaton belül. Ez a példa helyi képet igényel, és a [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/)‑t használja a bemutató képkönyvtárába történő betöltéshez. A [PictureFillFormat.picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/) beállítása a csempézett módra ismétli a képet a téglalapon belül. Az alább látható forráskép:

![A lotus kép](lotus.png)

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 255, 130)
    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE

    with slides.Images.from_file("lotus.png") as image:
        presentation_image = presentation.images.add_image(image)
    shape.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("picture_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A forma képkönyv kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha egy csempézett képet textúraként szeretne beállítani, és testre szabni a csempézési viselkedést, használhatja a következő tulajdonságokat a [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) osztályból:

- [picture_fill_mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture_fill_mode/): A képkönyv mód beállítása – `TILE` vagy `STRETCH`.
- [tile_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_alignment/): A csempék igazítása az alakzaton belül.
- [tile_flip](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_flip/): A csempe vízszintes, függőleges vagy mindkét irányban történő tükrözésének vezérlése.
- [tile_offset_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_x/): A csempe vízszintes eltolása (pontban) az alakzat eredetétől.
- [tile_offset_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_offset_y/): A csempe függőleges eltolása (pontban) az alakzat eredetétől.
- [tile_scale_x](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_x/): A csempe vízszintes méretezésének meghatározása százalékban.
- [tile_scale_y](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/tile_scale_y/): A csempe függőleges méretezésének meghatározása százalékban.

Ez a példa helyi képet igényel és a [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/)‑t úgy konfigurálja, hogy 50%-ban ismételje az eredeti méret felét. A `‑32` pont eltolások a csempéket vízszintesen és függőlegesen eltolják; a jobb‑alsó igazítás és a mindkét irányú tükrözés határozza meg, hogyan rendeződik az ismételt textúra.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]

    shape = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 190, 95)
    shape.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("lotus.png") as source_image:
        presentation_image = presentation.images.add_image(source_image)

    picture_fill_format = shape.fill_format.picture_fill_format
    picture_fill_format.picture.image = presentation_image
    picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    picture_fill_format.tile_offset_x = -32
    picture_fill_format.tile_offset_y = -32
    picture_fill_format.tile_scale_x = 50
    picture_fill_format.tile_scale_y = 50
    picture_fill_format.tile_alignment = slides.RectangleAlignment.BOTTOM_RIGHT
    picture_fill_format.tile_flip = slides.TileFlip.FLIP_BOTH

    presentation.save("tile.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Szilárd szín kitöltés**

A szilárd kitöltés egyetlen, egységes színt ad az alakzatnak. Ez a példa a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)‑t a szilárd kitöltés módra állítja, és a [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)-t sárgára állítja, majd elmenti a téglalapot egy prezentációban.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.yellow

    presentation.save("solid_color_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A forma szilárd szín kitöltéssel](solid-color-fill.png)

### **Színek másolása téma‑referenciák megőrzésével**

Használja a [ColorFormat.copy_from](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/copy_from/)‑t egy színdefiníció másolásához, beleértve a szín típusát, a téma‑referenciát és a transzformációkat. Ez akkor hasznos, ha egy kitöltő színt kíván áthelyezni alakzatok között, amelyeknek továbbra is a prezentáció témáját kell követniük. A metódus csak a színt másolja: nem másolja a kitöltés típusát, körvonalat vagy egyéb alakzatformázást. Állítsa be a célnak a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)‑t explicit módon.

Ez a példa három téglalapot hoz létre balról jobbra: a forrást, egy téma‑tudatos másolatot, és egy fix RGB másolatot. A forrás a [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/)‑t használja az első akcentus színre hivatkozva, és egy árnyalatot ad hozzá a [ColorOperationCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/coloroperationcollection/add/)-val. Az RGB másolat a forrás hatékony kitöltő színét használja, így háromuk eleinte ugyanolyan megjelenésű. A [ColorFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color/) beállítása rögzített RGB értéket ad, és törli a meglévő színtranszformációkat.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(660, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    presentation.master_theme.color_scheme.accent1.color = draw.Color.royal_blue

    source = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 40, 180, 140)
    theme_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 240, 40, 180, 140)
    rgb_copy = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 450, 40, 180, 140)

    for shape in (source, theme_copy, rgb_copy):
        shape.fill_format.fill_type = slides.FillType.SOLID
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    source_color = source.fill_format.solid_fill_color
    source_color.scheme_color = slides.SchemeColor.ACCENT1
    source_color.color_transform.add(slides.ColorTransformOperation.TINT, 0.75)

    theme_copy.fill_format.solid_fill_color.copy_from(source_color)
    rgb_copy.fill_format.solid_fill_color.color = source.fill_format.get_effective().solid_fill_color

    with slide.get_image(1.0, 1.0) as before:
        before.save("color-copy-before.png", slides.ImageFormat.PNG)

    # A téma referenciák követik az új akcentus színt; a rögzített RGB érték nem.
    presentation.master_theme.color_scheme.accent1.color = draw.Color.orange_red

    with slide.get_image(1.0, 1.0) as after:
        after.save("color-copy-after.png", slides.ImageFormat.PNG)
    presentation.save("copied_colors.pptx", slides.export.SaveFormat.PPTX)
```

A téma változás előtt mindhárom kitöltés megegyezik:

![Forrás, copy_from cél és fix RGB cél azonos kék kitöltésekkel](color-copy-before.png)

A téma változás után a forrás és a téma‑tudatos másolat az új akcentus színt követi és megtartja árnyalatát. A fix RGB másolat kék marad:

![Forrás és copy_from cél narancssárga kitöltésekkel, míg a fix RGB cél kék marad](color-copy-after.png)

A másolt definíció független a forrástól. A forrás téma‑referenciájának, egy másik szín hozzárendelésének vagy transzformációk hozzáadásának/eltávolításának későbbi módosítása nem változtatja meg a célt. A téma változás továbbra is hatással van mindkét alakzatra, mivel mindegyik önállóan hivatkozik ugyanarra a téma színre.

A PPTX mentése és újra megnyitása megőrzi a másolt [ColorFormat.color_type](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_type/), téma‑referenciát és a [ColorFormat.color_transform](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/color_transform/) gyűjteményt; nem lapítja le a definíciót RGB‑re.

Különböző téma kontextusok között másoláskor, például különböző akcentus palettákkal rendelkező prezentációk esetén, a másolt referencia a céltéma szerint oldódik fel. Ugyanaz a referencia és transzformációk ezért különböző látható színt eredményezhetnek. Lásd a [Presentation Theme](/slides/hu/python-net/presentation-theme/) oldalt a téma színek konfigurálásáról.

## **A dia háttér használata alakzat kitöltésként**

Használja a [AutoShape.use_background_fill](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/use_background_fill/)‑t, ha az alakzatnak meg kell egyeznie a dia háttérrel, például egy prezentáció sablonban. Állítsa a [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/)‑t a [FillType.NOT_DEFINED](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)-ra, hogy eltávolítsa az esetleges explicit kitöltést. Ezzel a kombinációval az alakzat a dia hátterét használja a saját stílus kitöltése helyett. A jelző önmagában nem távolítja el a meglévő explicit kitöltést.

Ez eltér a [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/)-től: a háttér kitöltés a forma mögötti objektumokat takarja el a dia megfelelő területével, míg a no fill a látható objektumokat hagyja. A gradiens a diára igazodik, nem indul újra minden alakzaton belül.

A következő példa egy mester háttérrel, a diára örökölt háttérrel hoz létre, és egy bíbor színű sávot helyez három téglalap mögé. A bal téglalap a hátteret használja, a középső téglalap nincs kitöltve, a jobb téglalap a háttér kitöltésről egy explicit narancssárga kitöltésre vált.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 400, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    # Örökölje a gradienset a mesterből.
    slide.background.type = slides.BackgroundType.NOT_DEFINED
    slide.layout_slide.background.type = slides.BackgroundType.NOT_DEFINED
    background = slide.layout_slide.master_slide.background
    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.GRADIENT
    gradient = background.fill_format.gradient_format
    gradient.gradient_shape = slides.GradientShape.LINEAR
    gradient.linear_gradient_angle = 0
    gradient.gradient_stops.clear()
    gradient.gradient_stops.add(0, draw.Color.dark_blue)
    gradient.gradient_stops.add(1, draw.Color.light_sky_blue)

    # Adja hozzá ezt az objektumot először, hogy a téglalapok mögött jelenjen meg.
    band = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 25, 150, 670, 100)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.magenta
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    background_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 100, 160, 200)
    background_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    background_shape.use_background_fill = True

    no_fill_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 280, 100, 160, 200)
    no_fill_shape.fill_format.fill_type = slides.FillType.NO_FILL

    explicit_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 510, 100, 160, 200)
    explicit_shape.fill_format.fill_type = slides.FillType.NOT_DEFINED
    explicit_shape.use_background_fill = True

    # Kapcsolja ki a háttér kitöltést, mielőtt explicit kitöltést alkalmazna.
    explicit_shape.use_background_fill = False
    explicit_shape.fill_format.fill_type = slides.FillType.SOLID
    explicit_shape.fill_format.solid_fill_color.color = draw.Color.orange

    presentation.save("background_fill.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény, balról jobbra: **háttér kitöltés**, **nincs kitöltés**, és **explicit kitöltés**. A bíbor sáv rejtve van a bal és jobb téglalap mögött, de a középső téglalapon látható.

![Háttér kitöltés, nincs kitöltés és explicit narancssárga kitöltés egy bíbor sáv felett](background-fill.png)

Ugyanez a viselkedés vonatkozik a diára közvetlenül definiált vagy egy elrendezésből örökölt háttérre. Az alakzat a dia feloldott hátterét használja; a példa a dia és elrendezés hátterét nem definiálja, így a mester szolgáltatja.

## **Átlátszóság beállítása**

Szilárd kitöltés esetén a szín alfa komponense szabályozza az átlátszóságot: 0 teljesen átlátszó, 255 teljesen átlátszatlan. Ez a példa 128-as alfa értéket használ egy sárga téglalaphoz, körülbelül 50%-os átlátszóságot eredményezve, így az alatta lévő téglalap látható marad. A színt a [FillFormat.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/)-on keresztül állítja be.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

alpha = 128

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    solid_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)

    transparent_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 150, 75)
    transparent_shape.fill_format.fill_type = slides.FillType.SOLID
    transparent_shape.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.yellow)

    presentation.save("shape_transparency.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Használja a [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/)‑t egy alakzat forgatásához a dia síkjában. A szög fokban mérve; ez a példa egy téglalapot 5 fokkal óramutató járásával megegyező irányban forgat és elmenti a prezentációt.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    shape.rotation = 5

    presentation.save("shape_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A forma forgatása](shape-rotation.png)

## **3D bevágás effektusok hozzáadása**

Használja a [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/)‑t, hogy egy alakzat mélységet és bevált éleket kapjon. Ez a példa egy zöld ellipszist hoz létre narancssárga körvonalkal, beállítja a [ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/)‑t 4 pontra, és egy kör alakú felső bevágást alkalmaz 6 pont szélesség és magasság segítségével a [ThreeDFormat.bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/)-on keresztül. Egy frontális ortográfiai kamera és hárompontos megvilágítás teszi a bevágást láthatóvá.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.green
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.orange
    shape.line_format.width = 2.0
    shape.three_d_format.depth = 4
    shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    shape.three_d_format.bevel_top.height = 6
    shape.three_d_format.bevel_top.width = 6
    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.THREE_PT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP

    presentation.save("3D_bevel_effect.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A 3D bevágás effektus](3D-bevel-effect.png)

## **3D forgórás effektusok hozzáadása**

Egy alakzat 3D nézete a kamera beállításain keresztül szabályozható. Ez a példa a [Camera.set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/)‑t használja a szélességi (latitude), hosszúsági (longitude) és revolúciós (revolution) szögekkel 40, 35 és 20 fokban. A [Camera.camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) segítségével izometrikus kamerát választ, a [LightRig.light_type](https://reference.aspose.com/slides/python-net/aspose.slides/lightrig/light_type/)-val kiegyensúlyozott megvilágítást, majd elmenti a formázott téglalapot.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 75)
    auto_shape.text_frame.text = "Hello, Aspose!"
    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.ISOMETRIC_LEFT_UP
    auto_shape.three_d_format.camera.set_rotation(40, 35, 20)
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED

    presentation.save("3D_rotation_effect.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A 3D forgatás effektus](3D-rotation-effect.png)

## **Fekete‑fehér megjelenítés vezérlése alakzatoknál**

A [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/) tulajdonság meghatározza, hogyan jelenik meg egy egyedi alakzat fekete-fehér módban, amikor a prezentációt fekete-fehér módon tekintik vagy dolgozzák fel. Nem engedélyezi a fekete-fehér megjelenítést magától, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színes módban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/python-net/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `AUTOMATIC` hagyja, hogy a renderelő alkalmazás válassza a konverziót, a `GRAY` és a `LIGHT_GRAY` szürke színezést alkalmaz, a `BLACK_WHITE` csak feketét és fehéret használ, a `BLACK` és `WHITE` egyetlen színt kényszerít, a `COLOR` megőrzi a normál színezést, a `HIDDEN` kihagyja az alakzatot fekete-fehér módban. A `NOT_DEFINED` azt jelenti, hogy nincs alakzat‑szintű mód hozzárendelve.

Ez a példa egy narancssárga téglalapot hoz létre, és a [Shape.black_white_mode](https://reference.aspose.com/slides/python-net/aspose.slides/shape/black_white_mode/)‑t szürkére állítja. A mentett alakzat megtartja a narancssárga kitöltést normál színes megjelenítésnél, és a szürke színezést kéri azoktól az alkalmazásoktól, amelyek tisztességesen betartják a fekete-fehér megjelenítési beállításokat:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 200, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.orange
    shape.black_white_mode = slides.BlackWhiteMode.GRAY

    presentation.save("shape_black_white_mode.pptx", slides.export.SaveFormat.PPTX)
```

Normál színes módban a téglalap megtartja a narancssárga kitöltést. Fekete‑fehér megjelenítési munkafolyamatban a szürke színezést használja, mivel módja `GRAY`‑re van állítva. Ez lehetővé teszi, hogy a teljes színes diákat őrizzük, miközben egyedi megjelenést definiálunk nyomtatáshoz, előnézethez vagy más munkafolyamatokhoz, amelyek betartják a prezentáció fekete‑fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Használja a [Slide.reset](https://reference.aspose.com/slides/python-net/aspose.slides/slide/reset/)‑t a diák helyzetének, méretének és formázásának helyreállításához a layout‑hoz kapcsolódó helyőrzőkből. Ez a példa egy létező prezentációt igényel, amelynek layout‑hoz kapcsolódó helyőrzői vannak, és minden dia felül resetül, mielőtt elmenti. Az alakzatok, amelyek nem rendelkeznek layout‑helyőrzővel, nem kerülnek visszaállításra.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    for slide in presentation.slides:
        slide.reset()

    presentation.save("reset_formatting.pptx", slides.export.SaveFormat.PPTX)
```

## **GYK**

**Befolyásolja a forma formázása a végleges prezentáció fájlméretét?**

A színek, vonalstílusok és effektus beállítások általában kevés adatot adnak hozzá a beágyazott képekhez és médiához képest. A képkönyv kitöltés növelheti a fájlméretet, mivel a képeket a prezentációban tárolják.

**Hogyan tudok felismerni egy dián azonos formázással rendelkező alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait — kitöltés, vonal és effektus beállítások. Ha minden megfelelő érték egyezik, tekintse őket azonos stílusúnak, és logikailag csoportosítsa őket, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek egy egyedi alakzatstílus-gyűjteményt egy külön fájlba, hogy újra felhasználhassam más prezentációkban?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon-diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázást ahol szükséges.