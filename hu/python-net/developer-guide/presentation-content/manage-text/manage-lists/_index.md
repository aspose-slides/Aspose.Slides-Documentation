---
title: Felsorolásjeles és számozott listák kezelése prezentációkban Python használatával
linktitle: Listák kezelése
type: docs
weight: 70
url: /hu/python-net/manage-lists/
keywords:
- jel
- felsorolásjeles lista
- számozott lista
- szimbólum jel
- képes jel
- egyéni jel
- többszintű lista
- jel létrehozása
- jel hozzáadása
- lista hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat felsorolásjeles, képes, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Aspose.Slides for Python via .NET lehetővé teszi, hogy felsorolásjeles és számozott listákat hozzon létre és formázzon PowerPoint és OpenDocument prezentációkban. Egy listaelem egy bekezdés, amelynek a jel‑beállításait a bekezdés formátuma vezérli.

Használja a [Paragraph.paragraph_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/paragraph_format/) tulajdonságot a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/), amely egy [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jel típusát, szimbólumát, képét, színét, méretét, számozási stílusát és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- létrehozni egy felsorolásjeles listát egy egyéni szimbólummal
- létrehozni egy képes jelet
- létrehozni egy többszintű listát a bekezdés mélységének beállításával
- létrehozni egy számozott listát
- ellenőrizni és módosítani a lista formázását egy meglévő prezentációban

## **Felsorolásjeles lista létrehozása**

Felsorolásjeles lista létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) -hez, és állítsa a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.SYMBOL](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra. Ezután beállíthatja a [BulletFormat.char](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/char/), a [BulletFormat.color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/color/) és a [BulletFormat.height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/height/) értékeket a jel megjelenésének szabályozásához.

Az alábbi Python kód bemutatja, hogyan hozhat létre felsorolásjeles listát egy dián:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

def create_paragraph(text):
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = '*'
    paragraph.paragraph_format.indent = 15
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE
    paragraph.paragraph_format.bullet.color.color = draw.Color.indian_red
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

![A szimbólum jelzések](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, amikor az elemek sorrendje fontos. Állítsa a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.NUMBERED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra. A [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_style/) segítségével kiválaszthat egy számozási formátumot, vagy a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) beállításával megadhatja, hogy a lista ne 1‑től, hanem más értéktől induljon.

Az alábbi Python kód megmutatja, hogyan hozhat létre számozott listát egy dián:

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

![A számozott jelzések](numbered_bullets.png)

## **Képes jel létrehozása**

Aspose.Slides lehetővé teszi, hogy egy szabványos felsorolásjelet képpel helyettesítsen. A képes jelzések legjobban egyszerű képekkel működnek, amelyek kis méretben is olvashatóak, például ikonok vagy kis átlátszó PNG fájlok.

 {{% alert color="primary" %}}
Elvileg, ha egy szabványos felsorolásjelet képpel szeretne helyettesíteni, a legjobb, ha egyszerű, átlátszó háttérrel rendelkező grafikát választ. Az ilyen képek jól működnek egyéni felsorolásjeleként.

Ne feledje, hogy a képet nagyon kis méretre méretezik le. Ezért erősen ajánljuk, hogy olyan képet válasszon, amely kicsinyítve is tiszta és vizuálisan hatékony marad a listában lévő jelként.
{{% /alert %}}

Ahhoz, hogy képes jelzést hozzon létre, adjon egy képet a [Presentation.images](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszaadott képobjektumot a [BulletFormat.picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/picture/)-hez. A kép hozzárendelése előtt állítsa a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét [BulletType.PICTURE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra.

Tegyük fel, hogy van egy "image.png" fájlunk:

![Kép a jelzésekhez](picture_for_bullets.png)

Az alábbi Python kód megmutatja, hogyan hozhat létre képes jelzéseket egy dián:

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

![A képes jelzések](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/)‑t a listaelemek különböző szintekre helyezéséhez. A 0‑szint a legfelső szint, az 1‑szint alatta van, és így tovább.

Az alábbi Python kód megmutatja, hogyan hozhat létre többszintű felsorolásjeles listát:

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

![A többszintű lista](multilevel_list.png)

## **Meglévő lista módosítása**

Az meglévő prezentációban a lista formázásának módosításához lépjen a cél bekezdésre, és frissítse annak a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/) beállításait. Azonos tulajdonságokat használhat a listák ellenőrzésére vagy módosítására, amelyeket PPT, PPTX vagy ODP fájlból tölt be.

Az alábbi Python kód megváltoztatja a szövegkeret első bekezdését, hogy számozott lista stílusát használja:

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

## **GYIK**

**Exportálhatók a felsorolásjeles és számozott listák PDF‑be vagy képekbe?**

Igen. Az Aspose.Slides megőrzi a lista formázását, ha a célformátum támogatja a megfelelő szövegelrendezést és jelző funkciókat.

**Szerkeszthetek listákat meglévő prezentációkban?**

Igen. Töltse be a prezentációt, lépjen a cél bekezdésre, ellenőrizze vagy frissítse a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/) beállításait, és mentse a prezentációt.

**Tartalmazhatnak a listák nem latin karaktereket?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg arról, hogy a prezentációban használt betűtípusok támogatják a szükséges karaktereket.