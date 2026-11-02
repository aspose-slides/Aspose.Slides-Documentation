---
title: "Felsorolt és számozott listák kezelése prezentációkban Pythonban"
linktitle: "Listák kezelése"
type: docs
weight: 70
url: /hu/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
  - jelölő
  - felsorolt lista
  - számozott lista
  - szimbólum jelölő
  - képes jelölő
  - egyedi jelölő
  - többszintű lista
  - jelölő létrehozása
  - jelölő hozzáadása
  - lista hozzáadása
  - PowerPoint
  - OpenDocument
  - prezentáció
  - Python
  - Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolt, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi felsorolások és számozott listák létrehozását és formázását PowerPoint és OpenDocument prezentációkban. A listaelem egy bekezdés, amelynek a jelölő beállításait a bekezdés formátuma vezérli.

Használja a [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) tulajdonságot a bekezdés‑szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/), amely egy [BulletFormat](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jelölő típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozhat létre felsorolást egy egyedi szimbólummal
- hozhat létre képes jelölőt
- hozhat létre több szintű listát a bekezdés mélységének beállításával
- hozhat létre számozott listát
- vizsgálja és módosítsa a listaformázást egy meglévő prezentációban
- olvassa ki a tényleges listajelölőket és számokat a bekezdés szövege mellett

## **Felsorolás létrehozása**

Felsorolás létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑hez, és állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.SYMBOL](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Ezután beállíthatja a [BulletFormat.char](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/color/) és [BulletFormat.height](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/height/) értékeket a jelölő megjelenésének szabályozásához.

Az alábbi Python kód bemutatja, hogyan hozható létre felsorolás egy dián:

```py
import aspose.slides as slides

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = slides.Color.indian_red
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = create_paragraph("The first paragraph")
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph")
    text_frame.paragraphs.add(paragraph2)

    presentation.save("symbol_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The symbol bullets](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje lényeges. Állítsa a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.NUMBERED](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/). Kiválaszthat egy számozási formátumot a [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_style/) segítségével, vagy beállíthatja a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékét, ha a lista nem az 1‑től kezdődik.

Az alábbi Python kód megmutatja, hogyan hozható létre számozott lista egy dián:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 90, 80)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph1.text = "Apple"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.text = "Orange"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph3.text = "Banana"
    text_frame.paragraphs.add(paragraph3)

    presentation.save("numbered_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The numbered bullets](numbered_bullets.png)

## **Képes jelölő létrehozása**

Az Aspose.Slides lehetővé teszi, hogy a szokásos jelölő szimbólumot egy képpel helyettesítse. A képes jelölők legjobban egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="info" title="Note" %}}
Ideális esetben, ha a szokásos jelölő szimbólumot egy képpel szeretné helyettesíteni, válasszon egy egyszerű grafikát átlátszó háttérrel. Az ilyen képek jól használhatók egyedi jelölő szimbólumként.
  
Ne feledje, hogy a képet nagyon kicsire méretezzük le. Emiatt erősen ajánljuk, hogy olyan képet válasszon, amely a lista jelölőjeként is tisztán és vizuálisan hatékonyan jelenik meg.
{{% /alert %}}

Képes jelölő létrehozásához adjon egy képet a [Presentation.images](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszakapott képet a [BulletFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/picture/) tulajdonsághoz. Mielőtt a képet hozzárendelné, állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/)-ra.

Tegyük fel, hogy van egy „image.png” nevű fájlunk:

![A picture for the bullets](picture_for_bullets.png)

Az alábbi Python kód megmutatja, hogyan hozhatók létre képes jelölők egy dián:

```py
import aspose.slides as slides

def create_paragraph(text, image):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = image
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.height = 100
    paragraph.text = text
    return paragraph


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 50)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    with open("image.png", "rb") as image_stream:
        bullet_image = presentation.images.add_image(image_stream)

    paragraph1 = create_paragraph("The first paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = create_paragraph("The second paragraph", bullet_image)
    text_frame.paragraphs.add(paragraph2)

    presentation.save("picture_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The picture bullets](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [ParagraphFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) tulajdonságot a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső, az 1‑szint alatta, és így tovább. A mélység csak a behúzást szabályozza; ha a szinteken is kell jelölő, állítsa be a [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) értékét az egyes bekezdéseknél.

Az alábbi Python kód mutatja a többszintű lista létrehozását:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 260, 110)

    text_frame = auto_shape.text_frame
    text_frame.paragraphs.clear()

    paragraph1 = slides.Paragraph()
    paragraph1.paragraph_format.depth = 0
    paragraph1.text = "My text - Depth 0"
    text_frame.paragraphs.add(paragraph1)

    paragraph2 = slides.Paragraph()
    paragraph2.paragraph_format.depth = 1
    paragraph2.text = "My text - Depth 1"
    text_frame.paragraphs.add(paragraph2)

    paragraph3 = slides.Paragraph()
    paragraph3.paragraph_format.depth = 2
    paragraph3.text = "My text - Depth 2"
    text_frame.paragraphs.add(paragraph3)

    paragraph4 = slides.Paragraph()
    paragraph4.paragraph_format.depth = 3
    paragraph4.text = "My text - Depth 3"
    text_frame.paragraphs.add(paragraph4)

    presentation.save("multilevel_bullets.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The multilevel list](multilevel_list.png)

## **Meglévő lista módosítása**

Egy meglévő prezentáció listaformázásának módosításához érje el a cél bekezdést, és frissítse annak a [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) beállításait. A listák létrehozásához használt ugyanazok a tulajdonságok használhatók a PPT, PPTX vagy ODP fájlból betöltött listák vizsgálatára vagy módosítására.

Az alábbi Python kód a szövegkeret első bekezdését számozott lista stílusra változtatja:

```py
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_ROMAN_UC_PERIOD
    paragraph.paragraph_format.bullet.numbered_bullet_start_with = 1
    paragraph.paragraph_format.margin_left = 30
    paragraph.paragraph_format.indent = -20

    presentation.save("updated_list.pptx", slides.export.SaveFormat.PPTX)
```

## **Tényleges jelölőértékek olvasása**

Prezentációtartalom kinyerésekor tartsa meg a listajelölőket a bekezdés szövege mellett. Hívja meg a [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/) metódust, és érje el az [IParagraphFormatEffectiveData.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraphformateffectivedata/bullet/) tulajdonságot a tényleges jelölőformátum lekéréséhez. Olvassa el a [type](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/type/) értéket, mielőtt a [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) értéket kérné.

Számozott listák esetén három értéket kell megkülönböztetni:

- a [numbered_bullet_style](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_style/) határozza meg a formátumot, például arab számokat ponttal vagy kisbetűs betűket ponttal.
- a [numbered_bullet_start_with](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/numbered_bullet_start_with/) adja meg a kezdő számot a számozott bekezdések csoportjában.
- a [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) visszaadja egy adott bekezdés formázott jelölőjét. Például egy 5‑ről induló lista második eleme `6.`‑ot ad vissza.

Tartsa meg a [depth](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/depth/) értéket minden bekezdésnél, hogy a beágyazási szint megmaradjon. A tényleges jelölő nem kódolja a teljes hierarchiát: egy beágyazott elem `c.`‑t adhat vissza a `6.c.` helyett.

Az alábbi önálló példa listákat hoz létre, menti őket egy prezentációba, majd újratölti a prezentációt, és minden bekezdés szövegét, mélységét, jelölőtípusát és tényleges értékét jelenteni. A kis kék képjelölő inline SVG‑ből jön létre.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 440, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20, 660, 400)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.paragraphs.clear()

    # Készítsen egy képes jelölőt külső képfájl nélkül.
    svg = slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>")
    bullet_image = presentation.images.add_image(svg)

    def add_paragraph(text, depth, bullet_type, start=1, style=slides.NumberedBulletStyle.BULLET_ARABIC_PERIOD):
        paragraph = slides.Paragraph()
        paragraph.text = text

        paragraph_format = paragraph.paragraph_format
        paragraph_format.depth = depth
        paragraph_format.margin_left = 30 + depth * 40
        paragraph_format.indent = -28
        paragraph_format.space_after = 8
        paragraph_format.default_portion_format.font_height = 22
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = slides.Color.black
        paragraph_format.bullet.type = bullet_type
        paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
        paragraph_format.bullet.color.color = slides.Color.black
        if bullet_type == slides.BulletType.NUMBERED:
            paragraph_format.bullet.numbered_bullet_style = style
            paragraph_format.bullet.numbered_bullet_start_with = start
        elif bullet_type == slides.BulletType.SYMBOL:
            paragraph_format.bullet.char = "\u2022"
        elif bullet_type == slides.BulletType.PICTURE:
            paragraph_format.bullet.picture.image = bullet_image

        text_frame.paragraphs.add(paragraph)

    add_paragraph("First item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Second item", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Next nested item", 1, slides.BulletType.NUMBERED, 3, slides.NumberedBulletStyle.BULLET_ALPHA_LC_PERIOD)
    add_paragraph("Deep item", 2, slides.BulletType.NUMBERED, 4, slides.NumberedBulletStyle.BULLET_ROMAN_LC_PERIOD)
    add_paragraph("Back to top level", 0, slides.BulletType.NUMBERED, 5)
    add_paragraph("Symbol marker", 0, slides.BulletType.SYMBOL)
    add_paragraph("No bullet", 0, slides.BulletType.NONE)
    add_paragraph("Picture marker", 0, slides.BulletType.PICTURE)
    presentation.save("actual_bullet_values.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("actual_bullet_values.pptx") as loaded_presentation:
    loaded_shape = loaded_presentation.slides[0].shapes[0]
    bullet_type_names = {slides.BulletType.NUMBERED: "NUMBERED", slides.BulletType.SYMBOL: "SYMBOL", slides.BulletType.NONE: "NONE", slides.BulletType.PICTURE: "PICTURE"}
    print("Text | Depth | Type | Actual value")
    for paragraph in loaded_shape.text_frame.paragraphs:
        bullet = paragraph.paragraph_format.get_effective().bullet
        if bullet.type in (slides.BulletType.NUMBERED, slides.BulletType.SYMBOL):
            marker = bullet.actual_bullet_value
        elif bullet.type == slides.BulletType.NONE:
            marker = f"{bullet.actual_bullet_value} (no bullet)"
        elif bullet.type == slides.BulletType.PICTURE:
            marker = f"{bullet.actual_bullet_value} (image required)"
        else:
            marker = "unsupported bullet type"
        bullet_type_name = bullet_type_names.get(bullet.type, "UNKNOWN")
        print(f"{paragraph.text} | {paragraph.paragraph_format.depth} | {bullet_type_name} | {marker}")
```

Az alábbiakban a forráslisták láthatók.

![Lists starting at 5, nested letter and Roman-number items, a symbol marker, a paragraph without a bullet, and a blue picture marker](actual_bullet_values.png)

A jelentés megegyezik a PowerPoint‑ban megjelenő jelölőkkel:

```text
Text | Depth | Type | Actual value
First item | 0 | NUMBERED | 5.
Second item | 0 | NUMBERED | 6.
Nested item | 1 | NUMBERED | c.
Next nested item | 1 | NUMBERED | d.
Deep item | 2 | NUMBERED | iv.
Back to top level | 0 | NUMBERED | 7.
Symbol marker | 0 | SYMBOL | •
No bullet | 0 | NONE | None (no bullet)
Picture marker | 0 | PICTURE | None (image required)
```

A [BulletType.NONE and BulletType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/bullettype/) esetén az [actual_bullet_value](https://reference.aspose.com/slides/python-net/aspose.slides/ibulletformateffectivedata/actual_bullet_value/) `None`‑t ad vissza, nem üres stringet. Kezelje ezeket a típusokat külön: az előbbinek nincs jelölője, az utóbbinak külön kell kinyerni a képet. A képes jelölő nem reprodukálható kizárólag szöveges jelölő kinyerésével.

## **GYIK**

**Exportálhatók a felsorolt és számozott listák PDF‑re vagy képekre?**

Igen. Az Aspose.Slides megőrzi a listaformázást, ha a célformátum támogatja a megfelelő szövegelrendezést és jelölőfunkciókat.

**Szerkeszthetők a listák meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a cél bekezdést, vizsgálja vagy frissítse a [ParagraphFormat.bullet](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/bullet/) beállításait, és mentse a prezentációt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelem szövege Unicode karaktereket is tartalmazhat, így többnyelvű listák is létrehozhatók. Győződjön meg arról, hogy a prezentációban használt betűkészletek támogatják a szükséges karaktereket.