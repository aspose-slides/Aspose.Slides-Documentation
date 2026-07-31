---
title: "Felsorolások és számozott listák kezelése prezentációkban Python nyelven"
linktitle: "Listák kezelése"
type: docs
weight: 70
url: /hu/python-net/manage-lists/
aliases:
  - /python-net/manage-bullet-and-numbered-lists/
keywords:
  - jelölő
  - felsoroláslista
  - számozott lista
  - szimbólum jelölő
  - kép jelölő
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
description: "Ismerje meg, hogyan hozhat létre és formázhat felsorolás-, kép-, többszintű és számozott listákat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET lehetővé teszi felsorolások és számozott listák létrehozását és formázását PowerPoint és OpenDocument bemutatókban. Egy listaelem egy bekezdés, amelynek jelölőbeállításait a bekezdés formátuma vezérli.

Használja a [Paragraph.paragraph_format](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/paragraph_format/) tulajdonságot a bekezdés szintű lista beállítások eléréséhez. A fő belépési pont a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/), amely egy [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) objektumot ad vissza. Ezzel az objektummal beállíthatja a jelölő típusát, szimbólumát, képét, színét, méretét, a számozási stílust és a kezdő számot.

Ez a cikk bemutatja, hogyan:

- hozhat létre egy egyedi szimbólummal ellátott felsorolást
- hozhat létre képjelölőt
- hozhat létre többszintű listát a bekezdés mélységének beállításával
- hozhat létre számozott listát
- vizsgálhatja és módosíthatja a lista formázását egy meglévő bemutatóban

## **Egy felsorolás létrehozása**

Egy felsorolás létrehozásához adjon [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumokat egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-hez, és állítsa be a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét a [BulletType.SYMBOL](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra. Ezután beállíthatja a [BulletFormat.char](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/char/), [BulletFormat.color](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/color/) és [BulletFormat.height](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/height/) tulajdonságokat a jelölő megjelenésének szabályozásához.

Az alábbi Python kód bemutatja, hogyan hozhat létre felsorolást egy dián:

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

![A szimbólum jelölők](symbol_bullets.png)

## **Számozott lista létrehozása**

Használjon számozott listákat, ha az elemek sorrendje számít. Állítsa a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét a [BulletType.NUMBERED](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra. Kiválaszthat egy számozási formátumot a [BulletFormat.numbered_bullet_style](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_style/) segítségével, vagy beállíthatja a [BulletFormat.numbered_bullet_start_with](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/numbered_bullet_start_with/) értékét, ha a lista nem az 1‑től szeretne indulni.

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

![A számozott jelölők](numbered_bullets.png)

## **Képjelölő létrehozása**

Az Aspose.Slides lehetővé teszi a szokásos jelölő szimbólum helyettesítését egy képpel. A képjelölők leginkább egyszerű, kis méretben is olvasható képekkel működnek, például ikonokkal vagy kis átlátszó PNG fájlokkal.

{{% alert color="primary" %}}
Ideális esetben, ha a szokásos jelölő szimbólum helyett képet kíván használni, válasszon egyszerű grafikát átlátszó háttérrel. Az ilyen képek jól szolgálhatnak egyedi jelölő szimbólumként.
{{% /alert %}}

Egy képjelölő létrehozásához adjon képet a [Presentation.images](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/images/) gyűjteményhez, és rendelje hozzá a visszakapott képet a [BulletFormat.picture](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/picture/)-hez. Mielőtt a képet hozzárendeli, állítsa a [BulletFormat.type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/type/) értékét a [BulletType.PICTURE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bullettype/)-ra.

Tegyük fel, hogy van egy „image.png” nevű képünk:

![A kép a jelölőkhöz](picture_for_bullets.png)

Az alábbi Python kód megmutatja, hogyan hozhat létre képjelölőket egy dián:

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

![A képjelölők](picture_bullets.png)

## **Többszintű lista létrehozása**

Használja a [ParagraphFormat.depth](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/depth/) tulajdonságot a listaelemek különböző szinteken való elhelyezéséhez. A 0‑szint a legfelső, az 1‑szint alatta helyezkedik el, és így tovább.

Az alábbi Python kód bemutatja, hogyan hozhat létre egy többszintű felsorolást:

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

Egy meglévő bemutató listaformázásának módosításához érje el a célbekezdéset, és frissítse a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/) beállításait. Az ugyanazok a tulajdonságok, amelyeket listák létrehozásához használ, alkalmazhatók a PPT, PPTX vagy ODP fájlokból betöltött listák vizsgálatára vagy módosítására.

Az alábbi Python kód a szövegkeret első bekezdését számozott lista stílusra állítja:

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

**Exportálhatók a felsorolások és számozott listák PDF‑be vagy képekbe?**

Igen. Az Aspose.Slides megőrzi a listaformázást, ha a célnformátum támogatja a megfelelő szövegelrendezést és jelölő funkciókat.

**Szerkeszthetőek a listák meglévő prezentációkban?**

Igen. Töltse be a prezentációt, érje el a célbekezdést, vizsgálja meg vagy frissítse a [ParagraphFormat.bullet](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/bullet/) beállításait, majd mentse a fájlt.

**Tartalmazhatnak a listák nem latin szöveget?**

Igen. A listaelemek szövege Unicode karaktereket is tartalmazhat, így többnyelvű prezentációkban is létrehozhat listákat. Győződjön meg arról, hogy a prezentációban használt betűkészletek támogatják a szükséges karaktereket.