---
title: Szöveg formázása prezentációban Pythonban
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/python-net/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílus
- szöveg háttér
- szöveg átlátszóság
- karakter távolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illeszkedés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Testreszabhatja betűtípusokat, színeket, igazítást és egyebet."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a szövegek a PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdés távolságokra, automatikus illeszkedés viselkedésére, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban a "sample.pptx" nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A keresés és csere szövegértékek megtalálásához és kiemeléséhez lásd a [Keresés és csere szöveg](/slides/hu/python-net/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [PortionFormat.highlight_color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/highlight_color/) metódust az egyes szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** esetén:

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

A kódrészlet alább bemutatja, hogyan állítható be a háttérszín a **szövegrészekre félkövér betűvel**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész kiemelés színét.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) beállítást a bekezdés igazításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés a **középre**:

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

A szöveg átlátszóságát a [PortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/fill_format/) színhez rendelt alfa komponens szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0‑255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Állítsa be a szöveg kitöltőszínét áttetsző színre.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **szövegrészekre félkövér betűvel**:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a szövegrész átlátszóságát.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakter távolság beállítása a szövegben**

Használja a [BasePortionFormat.spacing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/spacing/) beállítást a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Python kód bemutatja, hogyan növelhető a karaktertávolság a **teljes bekezdés** esetén:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

A kódrészlet alább bemutatja, hogyan növelhető a karaktertávolság a **szövegrészekre félkövér betűvel**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
            portion.portion_format.spacing = 3  # Karaktertávolság növelése.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg kissé szorosabbnak tűnhet, mint a PowerPoint-ban megjelenített ugyanez. Ez akkor fordulhat elő, ha a PowerPoint egyes betűtípusok kerning adatait figyelmen kívül hagyja, még akkor is, ha a betűtípusban valós kerning információk vannak, és a PowerPoint beállításaiban a kerning engedélyezett.

Ahhoz, hogy az ilyen esetekben a megjelenített kimenet közelebb legyen a PowerPoint-hoz, letilthatja a kerninget a megfelelő betűtípust használó szövegrészeknél. Állítsa be a [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) értékét a tényleges betűméretnél jóval nagyobbra:

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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides megjelenítésének a PowerPoint vizuális kimenetéhez igazításában azoknál a betűtípusoknál, amelyekre ez a PowerPoint-specifikus viselkedés hat.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_portion_format/) segítségével, vagy egyedi részekre a [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) használatával.

Az alábbi kód beállítja a betűt és a szövegstílust a teljes bekezdésre: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást és a Times New Roman betűt minden részre a bekezdésben.

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

![A betűtulajdonságok a bekezdésben](font_properties_for_paragraph.png)

A kódrészlet alább hasonló tulajdonságokat alkalmaz a **szövegrészekre félkövér betűvel**:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Állítsa be a betűtulajdonságokat a szövegrészhez.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A betűtulajdonságok a szövegrészeknél](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja a [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/text_vertical_type/) beállítást előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet beállítja a szövegorientációt az alakzatban `VERTICAL270` értékre, amely **90 fokkal az óramutató járásával ellentétesen** forgatja a szöveget:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása a szövegkereteknél**

Használja a [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/rotation_angle/) beállítást, hogy egyedi forgatási szöget állítson be egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) számára.

A kódrészlet alább 3 fokkal az óramutató járásával megegyező irányban forgatja a szövegkeretet az alakzatban:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Aspose.Slides biztosítja a [ParagraphFormat.space_after](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_before/) és [ParagraphFormat.space_within](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/space_within/) beállításokat a bekezdés távolság szabályozásához. Ezeket a tulajdonságokat az alábbiak szerint használjuk:

* Használjon pozitív értéket a sortávolság a sor magasságának százalékában megadásához.
* Használjon negatív értéket a sortávolság pontban megadásához.

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

## **Automatikus illeszkedés típusának beállítása szövegkereteknél**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/autofit_type/) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja ezt a beállítást annak szabályozására, hogy a szöveg zsugorodjon, kitöltse a teret vagy automatikusan átméretezze az alakzatot.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

A sorok számolásához automatikus sortördelés után, és annak megtekintéséhez, hogy a szöveg vagy az alakzat szélessége hogyan változik, lásd a [Megjelenített sorok számlálása](/slides/hu/python-net/manage-paragraph/). Maga a sorok száma nem mutatja meg, hogy a szöveg túllépi-e a tárolót.

## **Szövegkeretek rögzítésének beállítása**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/anchoring_type/) meghatározza, hogyan helyezkedik el függőlegesen a szöveg egy alakzaton belül, például a tetején, közepén vagy alján.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg tabuláció beállítása**

Használja a [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/default_tab_size/) és a [ParagraphFormat.tabs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/tabs/) elemeket a tabulátorok konfigurálásához egy bekezdésben.

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

## **Ellenőrző nyelv beállítása**

Aspose.Slides biztosítja a [PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) beállítást, amely lehetővé teszi a szövegrész ellenőrző nyelvének megadását. Az ellenőrző nyelv határozza meg a helyesírás- és nyelvtanellenőrzés nyelvét a PowerPointban.

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

    # Állítsa be a nyelvvizsgálati nyelv azonosítóját.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.default_text_language](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/default_text_language/) beállítást, hogy meghatározza az alapértelmezett nyelvet a betöltés vagy a prezentáció létrehozása során létrehozott szövegekhez.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Adj hozzá egy új téglalap alakzatot szöveggel.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # Ellenőrizze az első szakasz nyelvét.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Alapértelmezett szövegstílus beállítása**

Alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén, használja a [Presentation.default_text_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/default_text_style/) beállítást.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betű 14 pt mérettel minden szöveghez a diákon egy új prezentációban.

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

## **Szöveg kinyerése nagybetűs hatással**

A PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűs formában jeleníti meg a dián, még ha eredetileg kisbetűkkel lett beírva is. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték `ALL`.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdobozunk van.

![A nagybetűs hatás](all_caps_effect.png)

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

**Hogyan módosítsuk a szöveget egy táblázatban egy dián?**

A szöveg módosításához egy táblázatban egy dián, használja a [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/). Iteráljon a cellákon, és frissítse minden cellát a [Cell.text_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/cell/text_frame/) segítségével, valamint a bekezdésformázást a [Paragraph.paragraph_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/paragraph_format/) segítségével.

**Hogyan alkalmazzunk színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához a szövegre használja a [PortionFormat.fill_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/fill_format/). Állítsa a [FillFormat.fill_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/fillformat/fill_type/) értékét a [FillType.GRADIENT](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) típusra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.