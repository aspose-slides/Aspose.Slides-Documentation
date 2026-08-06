---
title: PowerPoint szövegbekezdések kezelése Pythonban
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/python-net/manage-paragraph/
aliases:
  - /python-net/paragraph/
  - /python-net/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzása
- függőleges behúzás
- bekezdés felsorolás
- számozott lista
- felsorolásos lista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képpé
- szöveg képpé
- bekezdés exportálása
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Mesteri bekezdésformázás az Aspose.Slides for Python segítségével .NET-en keresztül – optimalizálja a kiegyenlítést, távközöket és a stílust PowerPoint és OpenDocument bemutatókban Pythonban, hogy lekösse a nézőket."
---
## **Bevezetés**

Az Aspose.Slides biztosítja az osztályokat, amelyekre a PowerPoint szöveggel Pythonban való munka során szüksége van.

* Aspose.Slides biztosítja a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) osztályt a szövegdoboz objektumok létrehozásához. Egy `TextFrame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés sortöréssel van elválasztva).
* Aspose.Slides biztosítja a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztályt a bekezdés objektumok létrehozásához. Egy `Paragraph` objektum egy vagy több szövegrészt tartalmazhat.
* Aspose.Slides biztosítja a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) osztályt a szövegrészek létrehozásához és formázási tulajdonságaik megadásához.

A `Paragraph` objektum különböző formázási tulajdonságú szöveget kezelhet az alatta lévő `Portion` objektumokon keresztül.

## **Telepítés**

```bash
pip install aspose.slides
```

## **Több bekezdés hozzáadása, amelyek több szövegrészt tartalmaznak**

Ezek a lépések megmutatják, hogyan adhat hozzá egy szövegdobozt, amely három bekezdést tartalmaz, mindegyik három szövegrészt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze meg a cél dia hivatkozását az indexe alapján.
1. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Szerezze meg az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)-hez kapcsolódó [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot.
1. Hozzon létre két [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumot, és adja hozzá őket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a bekezdésgyűjteményéhez (az alapértelmezett bekezdéssel együtt ez három bekezdést eredményez).
1. Minden bekezdéshez hozzon létre három [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot, és adja hozzá az adott bekezdés szövegrész-gyűjteményéhez.
1. Állítsa be az egyes szövegrészek szövegét.
1. Alkalmazzon tetszőleges formázást az egyes szövegrészekre a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) által biztosított tulajdonságok segítségével.
1. Mentse el a módosított bemutatót.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt egy új PPTX fájl létrehozásához.
with slides.Presentation() as presentation:

    # Hozzáférés az első diához.
    slide = presentation.slides[0]

    # Téglalap AutoShape hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

    # Hozzáférés az AutoShape TextFrame-hez.
    text_frame = shape.text_frame

    # Bekezdések és szövegrészek létrehozása; a formázás alább kerül alkalmazásra.
    paragraph0 = text_frame.paragraphs[0]
    portion01 = slides.Portion()
    portion02 = slides.Portion()
    paragraph0.portions.add(portion01)
    paragraph0.portions.add(portion02)

    paragraph1 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph1)
    portion10 = slides.Portion()
    portion11 = slides.Portion()
    portion12 = slides.Portion()
    paragraph1.portions.add(portion10)
    paragraph1.portions.add(portion11)
    paragraph1.portions.add(portion12)

    paragraph2 = slides.Paragraph()
    text_frame.paragraphs.add(paragraph2)
    portion20 = slides.Portion()
    portion21 = slides.Portion()
    portion22 = slides.Portion()
    paragraph2.portions.add(portion20)
    paragraph2.portions.add(portion21)
    paragraph2.portions.add(portion22)

    for i in range(3):
        for j in range(3):
            text_frame.paragraphs[i].portions[j].text = "Portion0" + str(j)
            if j == 0:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.red
                text_frame.paragraphs[i].portions[j].portion_format.font_bold = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
            elif j == 1:
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                text_frame.paragraphs[i].portions[j].portion_format.font_italic = slides.NullableBool.TRUE
                text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

    # PPTX mentése a lemezen.
    presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdés felsorolások kezelése**

A felsorolások segítenek a információ gyors és hatékony szervezésében és bemutatásában. A felsorolt bekezdések gyakran könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférjen a cél diához az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Hozzáférjen a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal.
1. Állítsa be a bekezdés felsorolás típusát `SYMBOL`-ra, és adja meg a felsorolás karakterét.
1. Állítsa be a bekezdés szövegét.
1. Állítsa be a felsorolás behúzást a bekezdéshez.
1. Állítsa be a felsorolás színét.
1. Állítsa be a felsorolás méretét (magasságát).
1. Adja hozzá a bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a bekezdésgyűjteményéhez.
1. Hozzon létre egy második bekezdést, és ismételje meg a 7–12. lépéseket.
1. Mentse el a bemutatót.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Hozzon létre egy prezentációpéldányt.
with slides.Presentation() as presentation:

    # Hozzáférés az első diához.
    slide = presentation.slides[0]

    # AutoShape hozzáadása és elérése.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape szövegdobozának elérése.
    text_frame = shape.text_frame

    # Az alapértelmezett bekezdés eltávolítása.
    text_frame.paragraphs.remove_at(0)

    # Bekezdés létrehozása.
    paragraph = slides.Paragraph()

    # A bekezdés felsorolásstílusának és szimbólumának beállítása.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # A bekezdés szövegének beállítása.
    paragraph.text = "Welcome to Aspose.Slides"

    # A felsorolás behúzásának beállítása.
    paragraph.paragraph_format.indent = 25

    # A felsorolás színének beállítása.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # A felsorolás magasságának beállítása.
    paragraph.paragraph_format.bullet.height = 100

    # A bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph)

    # A második bekezdés létrehozása.
    paragraph2 = slides.Paragraph()

    # A bekezdés felsorolástípusának és -stílusának beállítása.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WD_BLACK_PLAIN

    # A bekezdés szövegének beállítása.
    paragraph2.text = "This is numbered bullet"

    # A felsorolás behúzásának beállítása.
    paragraph2.paragraph_format.indent = 25

    # A felsorolás színének beállítása.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = slides.NullableBool.TRUE

    # A felsorolás magasságának beállítása.
    paragraph2.paragraph_format.bullet.height = 100

    # A bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph2)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép alapú felsorolások kezelése**

A felsorolások segítenek a információ gyors és hatékony szervezésében és bemutatásában. A kép alapú felsorolások könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférjen a cél diához az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Hozzáférjen a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.
1. Hozzon létre egy bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a szövegét.
1. Töltsön be egy képet, és adja hozzá a bemutató képgyűjteményéhez [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) formájában.
1. Állítsa be a felsorolás típusát `PICTURE`-ra, és rendelje hozzá a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/)-t a felsoroláshoz.
1. Állítsa be a felsorolás magasságát.
1. Adja hozzá az új bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a bekezdésgyűjteményéhez.
1. Mentse el a bemutatót.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # Hozzáférés az első diához.
    slide = presentation.slides[0]

    # A felsorolás képfájljának betöltése.
    with slides.Images.from_file("bullets.png") as image:
        pp_image = presentation.images.add_image(image)

    # AutoShape hozzáadása és elérése.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape TextFrame-jének elérése.
    text_frame = auto_shape.text_frame

    # Az alapértelmezett bekezdés eltávolítása.
    text_frame.paragraphs.remove_at(0)

    # Új bekezdés létrehozása.
    paragraph = slides.Paragraph()
    paragraph.text = "Welcome to Aspose.Slides"

    # A bekezdés felsorolástípusának beállítása Képre és a kép hozzárendelése.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # A felsorolás magasságának beállítása.
    paragraph.paragraph_format.bullet.height = 100

    # A bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # A prezentáció mentése PPT fájlként.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Többszintű felsorolások kezelése**

A felsorolások segítenek a információ gyors és hatékony szervezésében és bemutatásában. A többszintű felsorolások könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférjen a cél diához az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Hozzáférjen az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)-nek a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 0-ra.
1. Hozza létre a második bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 1-re.
1. Hozza létre a harmadik bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 2-re.
1. Hozza létre a negyedik bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 3-ra.
1. Adja hozzá az új bekezdéseket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a bekezdésgyűjteményéhez.
1. Mentse el a bemutatót.

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Hozzon létre egy prezentációpéldányt.
with slides.Presentation() as presentation:

    # Hozzáférés az első diához.
    slide = presentation.slides[0]
    
    # AutoShape hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape TextFrame-jének elérése.
    text_frame = shape.text_frame
    
    # Az alapértelmezett bekezdés törlése.
    text_frame.paragraphs.clear()

    # Az első bekezdés hozzáadása.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A felsorolás szintjének beállítása.
    paragraph1.paragraph_format.depth = 0

    # A második bekezdés hozzáadása.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A felsorolás szintjének beállítása.
    paragraph2.paragraph_format.depth = 1

    # A harmadik bekezdés hozzáadása.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A felsorolás szintjének beállítása.
    paragraph3.paragraph_format.depth = 2

    # A negyedik bekezdés hozzáadása.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A felsorolás szintjének beállítása.
    paragraph4.paragraph_format.depth = 3

    # A bekezdések hozzáadása a gyűjteményhez.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni számozott listákkal ellátott bekezdések kezelése**

A [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) osztály a `numbered_bullet_start_with` tulajdonságot (és másokat) biztosítja egyéni számozás és formázás vezérlésére a bekezdéseknél.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférjen ahhoz a diához, amely a bekezdéseket fogja tartalmazni.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Hozzáférjen a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.
1. Hozza létre az első [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/)-t, és állítsa be a `numbered_bullet_start_with` értékét 2-re.
1. Hozza létre a második [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/)-t, és állítsa be a `numbered_bullet_start_with` értékét 3-ra.
1. Hozza létre a harmadik [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/)-t, és állítsa be a `numbered_bullet_start_with` értékét 7-re.
1. Adja hozzá a bekezdéseket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a gyűjteményéhez.
1. Mentse el a bemutatót.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape hozzáadása és elérése.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape TextFrame-jének elérése.
    text_frame = shape.text_frame

    # Az alapértelmezett meglévő bekezdés eltávolítása.
    text_frame.paragraphs.remove_at(0)

    # Az első számozott elem létrehozása (kezdő érték 2, mélységi szint 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # A második számozott elem létrehozása (kezdő érték 3, mélységi szint 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # A harmadik számozott elem létrehozása (kezdő érték 7, mélységi szint 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Első sor behúzásának beállítása egy bekezdéshez**

Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot az első sor behúzásának vezérlésére. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra posztícionálja az első sort, míg a többi sor a bekezdés testhez igazodik.

A teljes bekezdés mozgatásához használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/)-t. Az első sor csak valódi eltolásához használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/)-t.

Az alábbi példa több bekezdést hoz létre, és különböző `indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférjen a cél diához.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse el a módosított bemutatót.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "No first-line indent. Wrapped lines start at the same position as the first line."
    first_paragraph.paragraph_format.margin_left = 20.0
    first_paragraph.paragraph_format.indent = 0.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body."
    second_paragraph.paragraph_format.margin_left = 20.0
    second_paragraph.paragraph_format.indent = 20.0

    third_paragraph = slides.Paragraph()
    third_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    third_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    third_paragraph.text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see."
    third_paragraph.paragraph_format.margin_left = 20.0
    third_paragraph.paragraph_format.indent = 40.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)
    text_frame.paragraphs.add(third_paragraph)

    presentation.save("paragraph_indent.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Függőleges behúzás beállítása egy bekezdéshez**

A függőleges behúzás olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonsággal hozhatja létre. Állítsa a `indent` értékét negatívra, hogy az első sor balra mozduljon a bekezdés testéhez képest.

Gyakorlatban a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdés testének bal pozícióját, a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) pedig az első sor pozícióját ehhez a margóhoz képest. Függőleges behúzás létrehozásához állítson be egy pozitív `margin_left` értéket és egy negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortörés a bekezdés testjéhez, nem pedig az első sor első karakteréhez igazodik.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférjen a cél diához.
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) értéket minden bekezdéshez.
6. Állítson be egy negatív [indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értéket a függőleges behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse el a módosított bemutatót.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 220)
    rectangle.fill_format.fill_type = slides.FillType.NO_FILL
    rectangle.line_format.fill_format.fill_type = slides.FillType.SOLID
    rectangle.line_format.fill_format.solid_fill_color.color = draw.Color.gray

    text_frame = rectangle.add_text_frame("")
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE
    text_frame.paragraphs.remove_at(0)

    first_paragraph = slides.Paragraph()
    first_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    first_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    first_paragraph.text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body."
    first_paragraph.paragraph_format.margin_left = 40.0
    first_paragraph.paragraph_format.indent = -20.0

    second_paragraph = slides.Paragraph()
    second_paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    second_paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    second_paragraph.text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare."
    second_paragraph.paragraph_format.margin_left = 60.0
    second_paragraph.paragraph_format.indent = -30.0

    text_frame.paragraphs.add(first_paragraph)
    text_frame.paragraphs.add(second_paragraph)

    presentation.save("hanging_indent.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Bekezdés végső szakaszformátumának kezelése**

Amikor a bekezdés „végének” stílusát (a legutolsó szövegrész után alkalmazott formázás) kell szabályozni, használja az `end_paragraph_portion_format` tulajdonságot. Az alábbi példa nagyobb Times New Roman betűméretet alkalmaz a második bekezdés végén.

1. Hozzon létre vagy nyisson meg egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) fájlt.
1. Szerezze be a cél diát index szerint.
1. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Használja a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát, és hozzon létre két bekezdést.
1. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) objektumot, amely 48 pt Times New Roman, és alkalmazza a bekezdés end-paragraph portion formátumaként.
1. Rendelje hozzá a bekezdés `end_paragraph_portion_format` tulajdonságához (a második bekezdés végére vonatkozik).
1. Írja ki a módosított bemutatót PPTX fájlként.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

	# Az alapértelmezett bekezdés eltávolítása.
	shape.text_frame.paragraphs.clear()

	paragraph1 = slides.Paragraph()
	paragraph1.portions.add(slides.Portion("Sample text"))

	end_paragraph_portion_format = slides.PortionFormat()
	end_paragraph_portion_format.font_height = 48
	end_paragraph_portion_format.latin_font = slides.FontData("Times New Roman")

	paragraph2 = slides.Paragraph()
	paragraph2.portions.add(slides.Portion("Sample text 2"))
	paragraph2.end_paragraph_portion_format = end_paragraph_portion_format

	shape.text_frame.paragraphs.add(paragraph1)
	shape.text_frame.paragraphs.add(paragraph2)

	presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides fejlett támogatást nyújt a HTML szöveg bekezdésekbe való importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Hozzáférjen a cél diához az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diára.
1. Hozzáférjen az [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)-nek a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.
1. Olvassa be a forrás HTML fájlt.
1. Adja hozzá a HTML tartalmat a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-nek a bekezdésgyűjteményéhez.
1. Mentse el a módosított bemutatót.

```python
import aspose.slides as slides

# Hozzon létre egy üres Presentation példányt.
with slides.Presentation() as presentation:

    # Hozzáférés a bemutató első diájához.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # AutoShape hozzáadása a HTML tartalom elhelyezéséhez.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # A hozzáadott szövegdoboz összes bekezdésének törlése.
    shape.text_frame.paragraphs.clear()

    # HTML fájl betöltése.
    with open("file.html", "rt") as html_stream:
        # Szöveg hozzáadása a HTML fájlból a szövegdobozhoz.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # A bemutató mentése.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides fejlett támogatást nyújt a szöveg HTML-be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a cél bemutatót.
1. Hozzáférjen a kívánt diához az indexe alapján.
1. Válassza ki a szöveget tartalmazó formát.
1. Hozzáférjen a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-éhez.
1. Nyisson fájlfolyamot a HTML kimenet írásához.
1. Adja meg a kezdő indexet, és exportálja a kívánt bekezdéseket.

```python
import aspose.slides as slides

# Töltsük be a bemutató fájlt.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # Hozzáférés a bemutató első diájához.
    slide = presentation.slides[0]

    # Cél alak index.
    index = 0

    # Hozzáférés az alakhoz index alapján.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Írja ki a bekezdés adatokat HTML-be, megadva a kezdő bekezdés indexet és az exportálandó bekezdések összes számát.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Bekezdés mentése képként**

Ebben a részben két példát mutatunk be, amelyek bemutatják, hogyan menthetünk egy szövegbekezdést, amelyet a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztály képvisel, képként. Mindkét példában a bekezdést tartalmazó forma képét a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztály `get_image` metódusaival nyerjük ki, kiszámítjuk a bekezdés határait a formában, és bitmapként exportáljuk. Ezek a megközelítések lehetővé teszik a PowerPoint-bemutatók szövegének specifikus részeinek képként való kinyerését és mentését, ami különféle felhasználási esetekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű bemutatófájlunk, egy diával, ahol az első forma egy három bekezdést tartalmazó szövegdoboz.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a bemutató első diájának formájának képét nyerjük ki, majd kiszámítjuk a második bekezdés határait a forma szövegdobozában. A bekezdést ezután egy új bitmap képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként szeretne menteni, miközben megőrzi a szöveg pontos méreteit és formázását.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Mentse el az alakot memóriában bitmapként.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Hozzon létre egy alak bitmapet memóriából.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Számítsa ki a második bekezdés határait.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Számítsa ki a koordinátákat és a méretet a kimeneti képhez (minimum méret - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Vágja le az alak bitmapet, hogy csak a bekezdés bitmapet kapja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Az eredmény:

![The paragraph image](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában a korábbi megközelítést kiterjesztjük a bekezdés képre vonatkozó méretezési tényezők hozzáadásával. A forma a bemutatóból kerül kinyerésre, és a kép egy `2`-es méretezési tényezővel kerül mentésre. Ez lehetővé teszi a nagyobb felbontású kimenetet a bekezdés exportálásakor. A bekezdés határait ezután a méretezés figyelembevételével számítjuk ki. A nagyobb felbontású kép különösen hasznos lehet, például nyomtatott anyagokban.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Mentse el az alakot memóriában bitmapként.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Hozzon létre egy alak bitmapet memóriából.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Számítsa ki a második bekezdés határait.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Számítsa ki a koordinátákat és a méretet a kimeneti képhez (minimum méret - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Vágja le az alak bitmapet, hogy csak a bekezdés bitmapet kapja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **GYIK**

### Lehet-e teljesen letiltani a sortörést a szövegdobozon belül?

Igen. Használja a szövegdoboz `wrap_text` beállítását ([wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/)) a sortörés kikapcsolásához, így a sorok nem törnek meg a doboz szélén.

### Hogyan kaphatom meg egy adott bekezdés pontos helyét a dián?

Lekérdezheti a bekezdés (és akár egyetlen szövegrész) határoló téglalapját, hogy megtudja a pontos pozícióját és méretét a dián.

### Hol van a bekezdés igazítása (bal/jobbra/középre/nyomtatott) vezérelve?

Az [Alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) a [ParagraphFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/) bekezdés-szintű beállítása; a teljes bekezdésre vonatkozik, függetlenül az egyes részformázásoktól.

### Beállítható-e helyesírás-ellenőrzési nyelv csak a bekezdés egy részére (például egy szóra)?

Igen. A nyelv a [PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/) szinten van beállítva, ezért egy bekezdésen belül több nyelv is coexistálhat.