---
title: PowerPoint szöveg bekezdések kezelése Pythonban
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
- pontozott lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-be
- bekezdés HTML-be
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Mestere a bekezdésformázásnak az Aspose.Slides for Python segítségével .NET-en keresztül – optimalizálja az igazítást, a távolságot és a stílust PowerPoint és OpenDocument prezentációkban Pythonban, hogy lekösse a nézőket."
---
## **Bevezetés**

Az Aspose.Slides biztosítja az osztályokat, amelyekre a PowerPoint szöveggel való munkához Pythonban szüksége van.

* Aspose.Slides biztosítja a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) osztályt szövegdoboz objektumok létrehozásához. Egy `TextFrame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés új sor karakterrel van elválasztva).
* Aspose.Slides biztosítja a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztályt bekezdés objektumok létrehozásához. Egy `Paragraph` objektum egy vagy több szövegrészt tartalmazhat.
* Aspose.Slides biztosítja a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) osztályt szövegrészek létrehozásához és formázási tulajdonságaik megadásához.

A `Paragraph` objektum különböző formázási tulajdonságú szöveget kezelhet az alatta lévő `Portion` objektumokon keresztül.

## **Több bekezdés hozzáadása, amelyek több részt tartalmaznak**

Az alábbi lépések bemutatják, hogyan adjon hozzá egy szövegdobozt, amely három bekezdést tartalmaz, mindegyik három részt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát a céldiához az indexe alapján.  
1. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a dián.  
1. Szerezze meg a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot, amely a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)‑hez tartozik.  
1. Hozzon létre két [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) objektumot, és adja hozzá őket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) bekezdésgyűjteményéhez (az alapértelmezett bekezdéssel együtt ez három bekezdést eredményez).  
1. Minden bekezdéshez hozza létre három [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) objektumot, és adja hozzá a bekezdés részegység‑gyűjteményéhez.  
1. Állítsa be a szöveget minden részhez.  
1. Alkalmazzon tetszőleges formázást minden szövegrészre a [Portion](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portion/) által biztosított tulajdonságokkal.  
1. Mentse el a módosított prezentációt.

Az alábbi Python kód valósítja meg ezeket a lépéseket:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

    # Példányosítsa a Presentation osztályt egy új PPTX fájl létrehozásához.
    with slides.Presentation() as presentation:

        # Az első dia elérése.
        slide = presentation.slides[0]

        # Tégla alakú AutoShape hozzáadása.
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 300, 150)

        # Hozzáférés az AutoShape TextFrame-jéhez.
        text_frame = shape.text_frame

        # Bekezdések és részek létrehozása; a formázás alább kerül alkalmazásra.
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
                    text_frame.paragraphs[i].portions[j].portion_format.font_bold = 1
                    text_frame.paragraphs[i].portions[j].portion_format.font_height = 15
                elif j == 1:
                    text_frame.paragraphs[i].portions[j].portion_format.fill_format.fill_type = slides.FillType.SOLID
                    text_frame.paragraphs[i].portions[j].portion_format.fill_format.solid_fill_color.color = draw.Color.blue
                    text_frame.paragraphs[i].portions[j].portion_format.font_italic = 1
                    text_frame.paragraphs[i].portions[j].portion_format.font_height = 18

        # A PPTX mentése lemezre.
        presentation.save("paragraphs_and_portions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdés pontok kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A pontozott bekezdések gyakran könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a céldiát az indexe alapján.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a dián.  
1. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.  
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal.  
1. Állítsa be a bekezdés bullet típusát `SYMBOL`‑ra, és adja meg a bullet karaktert.  
1. Állítsa be a bekezdés szövegét.  
1. Állítsa be a bullet behúzást a bekezdéshez.  
1. Állítsa be a bullet színét.  
1. Állítsa be a bullet méretét (magasság).  
1. Adja hozzá a bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) bekezdésgyűjteményéhez.  
1. Adjon hozzá egy második bekezdést, és ismételje meg a 7‑12. lépéseket.  
1. Mentse el a prezentációt.

Ez a Python kód bemutatja a pontozott bekezdések hozzáadását:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Hozzon létre egy prezentáció példányt.
with slides.Presentation() as presentation:

    # Az első dia elérése.
    slide = presentation.slides[0]

    # AutoShape hozzáadása és elérése.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape szövegdobozának elérése.
    text_frame = shape.text_frame

    # Az alapértelmezett bekezdés eltávolítása.
    text_frame.paragraphs.remove_at(0)

    # Bekezdés létrehozása.
    paragraph = slides.Paragraph()

    # A bekezdés bullet stílusának és szimbólumának beállítása.
    paragraph.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph.paragraph_format.bullet.char = chr(8226)

    # A bekezdés szövegének beállítása.
    paragraph.text = "Welcome to Aspose.Slides"

    # A bullet behúzásának beállítása.
    paragraph.paragraph_format.indent = 25

    # A bullet színének beállítása.
    paragraph.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph.paragraph_format.bullet.color.color = draw.Color.black
    paragraph.paragraph_format.bullet.is_bullet_hard_color = 1 

    # A bullet magasságának beállítása.
    paragraph.paragraph_format.bullet.height = 100

    # Bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph)

    # A második bekezdés létrehozása.
    paragraph2 = slides.Paragraph()

    # A bekezdés bullet típusának és stílusának beállítása.
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    paragraph2.paragraph_format.bullet.numbered_bullet_style = slides.NumberedBulletStyle.BULLET_CIRCLE_NUM_WDBLACK_PLAIN

    # A bekezdés szövegének beállítása.
    paragraph2.text = "This is numbered bullet"

    # A bullet behúzásának beállítása.
    paragraph2.paragraph_format.indent = 25

    # A bullet színének beállítása.
    paragraph2.paragraph_format.bullet.color.color_type = slides.ColorType.RGB
    paragraph2.paragraph_format.bullet.color.color = draw.Color.black
    paragraph2.paragraph_format.bullet.is_bullet_hard_color = 1

    # A bullet magasságának beállítása.
    paragraph2.paragraph_format.bullet.height = 100

    # Bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph2)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kép pontok kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A kép pontok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a céldiát az indexe alapján.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a dián.  
1. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.  
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal.  
1. Töltsön be egy képet egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/)‑be.  
1. Állítsa be a bullet típust [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/)‑re, és rendelje hozzá a képet.  
1. Állítsa be a bekezdés szövegét.  
1. Állítsa be a bekezdés indentálását a bullethez.  
1. Állítsa be a bullet színét.  
1. Állítsa be a bullet magasságát.  
1. Adja hozzá az új bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) bekezdésgyűjteményéhez.  
1. Adjon hozzá egy második bekezdést, és ismételje meg a 8‑12. lépéseket.  
1. Mentse el a prezentációt.

Ez a Python kód mutatja, hogyan adjon hozzá és kezeljen kép pontokat:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:

    # Az első dia elérése.
    slide = presentation.slides[0]

    # Betölti a bullet képet.
    image = draw.Bitmap("bullets.png")
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

    # A bekezdés bullet típusának beállítása Képre, és a kép hozzárendelése.
    paragraph.paragraph_format.bullet.type = slides.BulletType.PICTURE
    paragraph.paragraph_format.bullet.picture.image = pp_image

    # A bullet magasságának beállítása.
    paragraph.paragraph_format.bullet.height = 100

    # Bekezdés hozzáadása a szövegdobozhoz.
    text_frame.paragraphs.add(paragraph)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("picture_bullets_out.pptx", slides.export.SaveFormat.PPTX)
    # A prezentáció mentése PPT fájlként.
    presentation.save("picture_bullets_out.ppt", slides.export.SaveFormat.PPT)
```

## **Többszintű pontok kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A többszintű pontok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a céldiát az indexe alapján.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a dián.  
1. Szerezze meg a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.  
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 0‑ra.  
1. Hozza létre a második bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 1‑re.  
1. Hozza létre a harmadik bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 2‑re.  
1. Hozza létre a negyedik bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal, és állítsa be a mélységét 3‑ra.  
1. Adja hozzá az új bekezdéseket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) bekezdésgyűjteményéhez.  
1. Mentse el a prezentációt.

Az alábbi Python kód mutatja, hogyan adjon hozzá és kezeljen többszintű pontokat:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Hozzon létre egy prezentáció példányt.
with slides.Presentation() as presentation:

    # Az első dia elérése.
    slide = presentation.slides[0]
    
    # AutoShape hozzáadása.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape TextFrame-jének elérése.
    text_frame = auto_shape.text_frame
    
    # Az alapértelmezett bekezdés törlése.
    text_frame.paragraphs.clear()

    # Az első bekezdés hozzáadása.
    paragraph1 = slides.Paragraph()
    paragraph1.text = "Content"
    paragraph1.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph1.paragraph_format.bullet.char = chr(8226)
    paragraph1.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph1.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A bullet szintjének beállítása.
    paragraph1.paragraph_format.depth = 0

    # A második bekezdés hozzáadása.
    paragraph2 = slides.Paragraph()
    paragraph2.text = "Second Level"
    paragraph2.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph2.paragraph_format.bullet.char = '-'
    paragraph2.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph2.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A bullet szintjének beállítása.
    paragraph2.paragraph_format.depth = 1

    # A harmadik bekezdés hozzáadása.
    paragraph3 = slides.Paragraph()
    paragraph3.text = "Third Level"
    paragraph3.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph3.paragraph_format.bullet.char = chr(8226)
    paragraph3.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph3.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A bullet szintjének beállítása.
    paragraph3.paragraph_format.depth = 2

    # A negyedik bekezdés hozzáadása.
    paragraph4 = slides.Paragraph()
    paragraph4.text = "Fourth Level"
    paragraph4.paragraph_format.bullet.type = slides.BulletType.SYMBOL
    paragraph4.paragraph_format.bullet.char = '-'
    paragraph4.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph4.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    # A bullet szintjének beállítása.
    paragraph4.paragraph_format.depth = 3

    # A bekezdések hozzáadása a gyűjteményhez.
    text_frame.paragraphs.add(paragraph1)
    text_frame.paragraphs.add(paragraph2)
    text_frame.paragraphs.add(paragraph3)
    text_frame.paragraphs.add(paragraph4)

    # A prezentáció mentése PPTX fájlként.
    presentation.save("multilevel_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyedi számozott listák kezelése bekezdésekben**

A [BulletFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/bulletformat/) osztály a `numbered_bullet_start_with` tulajdonságot (és másokat) biztosítja az egyedi számozás és formázás szabályozásához bekezdéseknél.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a bekezdéseket tartalmazó diát.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.  
1. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.  
1. Hozza létre az első [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) bekezdést, és állítsa be a `numbered_bullet_start_with` értékét 2‑re.  
1. Hozza létre a második [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) bekezdést, és állítsa be a `numbered_bullet_start_with` értékét 3‑ra.  
1. Hozza létre a harmadik [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) bekezdést, és állítsa be a `numbered_bullet_start_with` értékét 7‑re.  
1. Adja hozzá a bekezdéseket a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) gyűjteményéhez.  
1. Mentse el a prezentációt.

Az alábbi Python kód bemutatja az egyedi számozott listákkal rendelkező bekezdések hozzáadását és kezelését.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    # AutoShape hozzáadása és elérése.
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)

    # A létrehozott AutoShape TextFrame-jének elérése.
    text_frame = shape.text_frame

    # Az alapértelmezett meglévő bekezdés eltávolítása.
    text_frame.paragraphs.remove_at(0)

    # Az első számozott elem létrehozása (kezdés 2, mélység 4).
    paragraph1 = slides.Paragraph()
    paragraph1.text = "bullet 2"
    paragraph1.paragraph_format.depth = 4 
    paragraph1.paragraph_format.bullet.numbered_bullet_start_with = 2
    paragraph1.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph1)

    # A második számozott elem létrehozása (kezdés 3, mélység 4).
    paragraph2 = slides.Paragraph()
    paragraph2.text = "bullet 3"
    paragraph2.paragraph_format.depth = 4
    paragraph2.paragraph_format.bullet.numbered_bullet_start_with = 3 
    paragraph2.paragraph_format.bullet.type = slides.BulletType.NUMBERED  
    text_frame.paragraphs.add(paragraph2)

    # A harmadik számozott elem létrehozása (kezdés 7, mélység 4).
    paragraph5 = slides.Paragraph()
    paragraph5.text = "bullet 7"
    paragraph5.paragraph_format.depth = 4
    paragraph5.paragraph_format.bullet.numbered_bullet_start_with = 7
    paragraph5.paragraph_format.bullet.type = slides.BulletType.NUMBERED
    text_frame.paragraphs.add(paragraph5)

    presentation.save("custom_bullets_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Első sor behúzása bekezdéshez**

Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot az első sor behúzásának szabályozásához. Ez a tulajdonság csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolják az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) tulajdonságot, ha a teljes bekezdést kell eltolni. Használja a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságot, ha csak az első sor beállítására van szükség.

Az alábbi példa több bekezdést hoz létre, és különböző `indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a céldiát.  
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.  
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre több bekezdést, és állítson be különböző [indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értékeket.  
6. Adja hozzá a bekezdéseket a szövegdobozhoz.  
7. Mentse el a módosított prezentációt.

Ez a kód bemutatja, hogyan állítható be a bekezdés behúzása:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függőleges (hanging) behúzás bekezdéshez**

A függőleges behúzás olyan bekezdéselrendezés, ahol az első sor balra indul a többi sorhoz képest. Az Aspose.Slides‑ben ezt a hatást a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) tulajdonságával érhetjük el. Állítsa az `indent` értékét negatívra, hogy az első sort balra mozgassa a bekezdés törzséhez képest.

Gyakorlatban a [ParagraphFormat.margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) határozza meg a bekezdés törzsének bal pozícióját, míg a [ParagraphFormat.indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) definiálja az első sor helyzetét ehhez a margóhoz képest. Függőleges behúzáshoz állítson pozitív `margin_left` értéket és negatív `indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szótárbejegyzések és egyéb olyan bekezdések esetén, ahol a törött soroknak a bekezdés törzsének alá kell illeszkedniük, nem pedig az első sor első karakteréhez.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a céldiát.  
3. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.  
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.  
5. Hozzon létre bekezdéseket, és minden bekezdéshez állítson be pozitív [margin_left](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/margin_left/) értéket.  
6. Állítson be negatív [indent](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/indent/) értéket a függőleges behúzás létrehozásához.  
7. Adja hozzá a bekezdéseket a szövegdobozhoz.  
8. Mentse el a módosított prezentációt.

Ez a kód bemutatja, hogyan állítható be a függőleges behúzás egy bekezdéshez:

```py
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

![A bekezdések függőleges behúzása](hanging_indent.png)

## **Bekezdés végének részformátumának kezelése**

Amikor a bekezdés „végének” formázását kell szabályozni (az utolsó szövegrész után alkalmazott formázás), használja az `end_paragraph_portion_format` tulajdonságot. Az alábbi példa egy nagyobb Times New Roman betűtípust alkalmaz a második bekezdés végére.

1. Hozzon létre vagy nyisson meg egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) fájlt.  
1. Szerezze meg a céldiát index szerint.  
1. Adjon hozzá egy téglalap alakú [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.  
1. Használja a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát, és hozza létre a két bekezdést.  
1. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/) objektumot, amely 48 pontos Times New Roman, és alkalmazza a bekezdés end‑paragraph portion formátumaként.  
1. Rendelje hozzá a bekezdés `end_paragraph_portion_format` tulajdonságához (a második bekezdés végére vonatkozik).  
1. Írja ki a módosított prezentációt PPTX fájlként.

Ez a Python kód megmutatja, hogyan állítható be a bekezdés végének formázása a második bekezdésnél:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
	shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 200, 250)

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

Az Aspose.Slides kibővített támogatást nyújt a HTML szöveg bekezdésekbe való importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
1. Szerezze meg a céldiát index szerint.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) elemet a diához.  
1. Szerezze meg a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumot a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/)‑ból.  
1. Távolítsa el az alapértelmezett bekezdést a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/)-ből.  
1. Olvassa be a forrás HTML fájlt.  
1. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztállyal.  
1. Adja hozzá a HTML tartalmat a [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) bekezdésgyűjteményéhez.  
1. Mentse el a módosított prezentációt.

Az alábbi Python kód megvalósítja ezeket a lépéseket a HTML szöveg bekezdésekbe importálásához.

```python
import aspose.slides as slides

# Hozzon létre egy üres Presentation példányt.
with slides.Presentation() as presentation:

    # A prezentáció első diájának elérése.
    slide = presentation.slides[0]

    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    # AutoShape hozzáadása a HTML tartalom befogadásához.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, slide_width - 20, slide_height - 10)

    # Az hozzáadott szövegdobozban lévő összes bekezdés törlése.
    shape.text_frame.paragraphs.clear()

    # HTML fájl betöltése.
    with open("file.html", "rt") as html_stream:
        # Szöveg hozzáadása a HTML fájlból a szövegdobozhoz.
        shape.text_frame.paragraphs.add_from_html(html_stream.read())

    # A prezentáció mentése.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Bekezdés szöveg exportálása HTML‑be**

Az Aspose.Slides kibővített támogatást nyújt a szöveg HTML‑be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból, és töltse be a célprezentációt.  
1. Szerezze meg a kívánt diát index szerint.  
1. Válassza ki a szöveget tartalmazó formát.  
1. Szerezze meg a forma [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) objektumát.  
1. Nyisson meg egy fájlfolyamot a HTML kimenet írásához.  
1. Adja meg a kezdő indexet, és exportálja a szükséges bekezdéseket.

Ez a Python példa bemutatja, hogyan exportáljon bekezdés szöveget HTML‑be.

```python
import aspose.slides as slides

# Töltsd be a prezentáció fájlt.
with slides.Presentation("exporting_HTML_text.pptx") as presentation:
    # A prezentáció első diájának elérése.
    slide = presentation.slides[0]

    # Cél forma index.
    index = 0

    # A forma elérése index alapján.
    shape = slide.shapes[index]

    with open("output.html", "w") as html_stream:
        # Bekezdés adatainak írása HTML-be a kiinduló bekezdés index és az exportálandó bekezdések számának megadásával.
        html_stream.write(shape.text_frame.paragraphs.export_to_html(0, shape.text_frame.paragraphs.count, None))
```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát vizsgálunk meg, amelyek bemutatják, hogyan menthetünk egy szöveges bekezdést, amelyet a [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraph/) osztály képvisel, képként. Mindkét példa a bekezdést tartalmazó forma képének lekérését, a bekezdés határainak kiszámítását a forma szövegdobozában, majd bitmap képként való exportálását tartalmazza. Ezek a megközelítések lehetővé teszik a PowerPoint‑prezentációkból származó szövegrészek kivonását és különálló képként való mentését, ami különböző forgatókönyvekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első forma egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a prezentáció első diájának formájának képét kinyerjük, majd kiszámítjuk a második bekezdés határait a forma szövegdobozában. A bekezdést egy új bitmap képre rajzoljuk, majd PNG formátumban mentjük. Ez a módszer különösen akkor hasznos, ha egy adott bekezdést különálló képként szeretnénk menteni, miközben a szöveg pontos méreteit és formázását megőrizzük.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Mentse a formát memóriában bitmapként.
    with first_shape.get_image() as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Hozzon létre egy shape bitmap-et a memóriából.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Számítsa ki a második bekezdés határait.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()

    # Számítsa ki a kimeneti kép koordinátáit és méretét (minimum méret - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Vágja le a shape bitmap-et, hogy csak a bekezdés bitmap-et kapja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában a korábbi megközelítést kiterjesztjük a bekezdés képének skálázási tényezőkkel való ellátásával. A forma a prezentációból kinyerésre kerül, és a kép skálázási tényezője `2`‑re van állítva, ami nagyobb felbontású kimenetet biztosít. A bekezdés határait ezután a skálázás figyelembevételével számoljuk ki. A skálázás különösen hasznos, amikor részletesebb képre van szükség, például magas minőségű nyomtatott anyagokhoz.

```py
import aspose.slides as slides
import math
import io
from PIL import Image

image_scale_x = 2
image_scale_y = image_scale_x

with slides.Presentation("sample.pptx") as presentation:
    first_shape = presentation.slides[0].shapes[0]

    # Mentse a formát memóriában bitmapként.
    with first_shape.get_image(slides.ShapeThumbnailBounds.SHAPE, image_scale_x, image_scale_y) as shape_image:
        shape_image_stream = io.BytesIO()
        shape_image.save(shape_image_stream, slides.ImageFormat.PNG)

    # Hozzon létre egy shape bitmap-et a memóriából.
    shape_image_stream.seek(0)
    shape_bitmap = Image.open(shape_image_stream)

    # Számítsa ki a második bekezdés határait.
    second_paragraph = first_shape.text_frame.paragraphs[1]
    paragraph_rectangle = second_paragraph.get_rect()
    paragraph_rectangle.x *= image_scale_x
    paragraph_rectangle.y *= image_scale_y
    paragraph_rectangle.width *= image_scale_x
    paragraph_rectangle.height *= image_scale_y

    # Számítsa ki a kimeneti kép koordinátáit és méretét (minimum méret - 1x1 pixel).
    image_left = math.floor(paragraph_rectangle.x)
    image_top = math.floor(paragraph_rectangle.y)
    image_right = image_left + max(1, math.ceil(paragraph_rectangle.width))
    image_bottom = image_top + max(1, math.ceil(paragraph_rectangle.height))

    # Vágja le a shape bitmap-et, hogy csak a bekezdés bitmap-et kapja.
    paragraph_bitmap = shape_bitmap.crop((image_left, image_top, image_right, image_bottom))

    paragraph_bitmap.save("paragraph.png")
```

## **GYIK**

**Teljesen letilthatom a sorok megtörését egy szövegdobozban?**

Igen. Használja a szövegdoboz [wrap_text](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframeformat/wrap_text/) beállítását a továbblépés kikapcsolásához, így a sorok nem törnek meg a keret szélein.

**Hogyan kaphatom meg egy adott bekezdés pontos diára vonatkozó határait?**

A bekezdés (és akár egyetlen szövegrész) körülvett téglalap lekérdezésével pontosan megismerheti annak pozícióját és méretét a dián.

**Hol van szabályozva a bekezdés igazítása (bal/jobbra/közép/justified)?**

Az [Alignment](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/alignment/) a [ParagraphFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides/paragraphformat/) beállítása, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szövegrészek formázásától.

**Beállíthatok helyesírás-ellenőrzési nyelvet csak a bekezdés egy részére (pl. egy szóhoz)?**

Igen. A nyelv a szövegrész szintjén van beállítva ([PortionFormat.language_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/language_id/)), így egy bekezdésen belül több nyelv is megjelenhet.