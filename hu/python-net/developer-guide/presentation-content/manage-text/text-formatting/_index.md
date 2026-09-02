---
title: Prezentáció szövegének formázása Pythonban
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/python-net/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttere
- szöveg átlátszóság
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sortávolság
- automatikus méretezés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Szöveg formázása és stílusának beállítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Testreszabhatja betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatunk szöveget PowerPoint- és OpenDocument‑prezentációkban az Aspose.Slides for Python via .NET segítségével. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdés‑távolságra, automatikus méretezésre, szöveg‑horgonyozásra, tabulátor‑állásokra és nyelvi beállításokra.

Az alábbi példákban egy „sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezéssel egyező részek megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/python-net/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [PortionFormat.highlight_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/highlight_color/) metódust az egyedi szövegdarabokhoz.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a teljes bekezdés kiemelés színét.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **félkövér betűtípusú szövegdarabok** számára:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegdarab kiemelés színét.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegdarabok](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a bekezdés igazítását középre.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóságának beállítása**

Az átlátszóságot a [PortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/fill_format/) színének alfa komponensén keresztül lehet szabályozni. Az alábbi példákban a `alpha = 50` egy ARGB alfa‑csatorna érték 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható a átlátszóság a **teljes bekezdés**re:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a szöveg kitöltő színét átlátszó színre.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazható a átlátszóság a **félkövér betűtípusú szövegdarabokra**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegdarab átlátszóságát.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó szövegdarabok](transparent_text_portions.png)

## **Karaktertávolság beállítása a szövegben**

Használja a [BasePortionFormat.spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/spacing/) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Python‑kód bemutatja, hogyan növelhető a karaktertávolság a **teljes bekezdés**ben:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karaktertávolság a **félkövér betűtípusú szövegdarabok**ban:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
            portion.portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a szövegdarabokban](character_spacing_in_text_portions.png)

### **Kerning letiltása meghatározott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabb lehet, mint a PowerPoint‑ban megjelenő. Ennek oka lehet, hogy a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve van a kerning.

Ahhoz, hogy a renderelt kimenet közelebb kerüljön a PowerPointhez, letilthatja a kerninget azon szövegdaraboknál, amelyek az érintett betűtípust használják. Állítsa a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűméretnél jóval nagyobbra:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegdarabokra, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában azokra a betűtípusokra, amelyekre ez a PowerPoint‑specifikus viselkedés hatással van.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/) segítségével, vagy egyedi darabokra a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a **teljes bekezdés** számára: betűméretet, félkövér, dőlt, pontozott aláhúzást és a Times New Roman betűtípust alkalmaz minden darabra a bekezdésben.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a betűtulajdonságokat a bekezdéshez.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A betűtulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz a **félkövér betűtípusú szövegdarabokra**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a betűtulajdonságokat a szövegdarabhoz.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A betűtulajdonságok a szövegdarabokhoz](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/text_vertical_type/) metódust egy előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szövegorientációt a alakzatban `VERTICAL270`‑re állítja, ami **90 fokkal óramutatóval ellentétesen** forgatja a szöveget:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/rotation_angle/) metódust egy egyedi forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutatóval azonos irányban forgatja az alakzatban:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Az Aspose.Slides a [ParagraphFormat.space_after](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_within/) segítségével szabályozza a bekezdés távolságát. Ezeket a tulajdonságokat a következőképpen használjuk:

* Pozitív értékkel a sortávolság a sormagasság százalékában adható meg.
* Negatív értékkel a sortávolság pontban adható meg.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sortávolság a bekezdésen belül:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Automatikus méretezés típusának beállítása szövegkereteknél**

A [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/autofit_type/) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kilógjon vagy a forma automatikusan átméreteződjön.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Szövegkeretek horgonypontjának beállítása**

A [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/anchoring_type/) határozza meg, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például felül, középen vagy alul.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/tabs/) metódusokat a tabulátorok beállításához egy bekezdésben.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) segítségével lehetővé teszi a helyesírási nyelv beállítását egy szövegdarabhoz. A helyesírási nyelv meghatározza, mely nyelvet használja a PowerPoint a helyesírás- és nyelvtan-ellenőrzéshez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a helyesírási nyelv egy szövegdarabhoz:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Állítsa be a helyesírási nyelv azonosítóját.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/) metódust, hogy meghatározza a prezentáció betöltése vagy létrehozása közben létrehozott szöveg alapértelmezett nyelvét.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Új téglalap alakzat hozzáadása szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első rész nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

Alapértelmezett szövegformázás alkalmazásához a prezentáción szintjén használja a [Presentation.default_text_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/default_text_style/) metódust.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betű 14 pt mérettel minden szöveghez az új prezentáció diáin.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Szerezze meg a legfelső szintű bekezdésformátumot.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg kinyerése nagybetűs effektussal**

A PowerPointban a **All Caps** (Nagybetűs) betűhatás alkalmazása a szöveget nagybetűsen jeleníti meg a dián, még akkor is, ha eredetileg kisbetűkkel írták. Amikor az Aspose.Slides‑kel ilyen szövegdarabot kérünk le, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez illeszkedő eredmény eléréséhez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textcaptype/) értékét, és a visszakapott karakterláncot konvertálja nagybetűssé, ha az érték `ALL`.

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosítható a szöveg egy dián lévő táblázatban?**

A szöveg módosításához egy táblázatban egy dián használja a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) elemet. Iteráljon a cellákon, és frissítse minden cellát a [Cell.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/text_frame/) és a bekezdésformázást a [Paragraph.paragraph_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/paragraph_format/) segítségével.

**Hogyan alkalmazhatók átmenet színek a szövegre egy PowerPoint-dián?**

Az átmenetes szín alkalmazásához a szövegre használja a [PortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/fill_format/) metódust. Állítsa a [FillFormat.fill_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/fill_type/) értékét a [FillType.GRADIENT](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) típusra, és konfigurálja az átmenet állomásait, irányát és átlátszóságát.