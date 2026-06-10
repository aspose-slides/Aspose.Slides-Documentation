---
title: Alakzatanimációk alkalmazása prezentációkban Python segítségével
linktitle: Alakzat animáció
type: docs
weight: 60
url: /hu/python-net/shape-animation/
keywords:
- alakzat
- animáció
- hatás
- animált alakzat
- animált szöveg
- animáció hozzáadása
- animáció lekérése
- animáció kinyerése
- hatás hozzáadása
- hatás lekérése
- hatás kinyerése
- hatás hangja
- animáció alkalmazása
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan hozhat létre és testreszabhat alakzatanimációkat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével. Tűnjön ki!"
---
## **Bevezetés**

Az animációk vizuális hatások, amelyeket szövegekre, képekre, alakzatokra vagy [diagramokra](/slides/hu/python-net/animated-charts/) lehet alkalmazni. Élettel töltik meg az előadásokat vagy azok elemeit. 

## **Miért használjunk animációkat az előadásokban?**

Az animációk segítségével 

* az információ áramlását vezérelje
* kiemelje a fontos pontokat
* növelje a közönség érdeklődését vagy részvételét
* megkönnyítse a tartalom olvasását, befogadását vagy feldolgozását
* felhívja az olvasók vagy nézők figyelmét az előadás fontos részeire

A PowerPoint sok lehetőséget és eszközt kínál az animációkhoz és animációs hatásokhoz a **belépés**, **kilépés**, **kiemelés** és **mozgási útvonalak** kategóriákban. 

## **Animációk az Aspose.Slides-ban**

* Az Aspose.Slides biztosítja az animációkkal való munkához szükséges osztályokat és típusokat a [Aspose.Slides.Animation](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/) névtérben,
* Az Aspose.Slides több mint **150 animációs hatást** kínál a [EffectType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttype/) felsorolásban. Ezek a hatások lényegében ugyanazok (vagy ekvivalensek), mint a PowerPoint-ban használtak.

## **Animáció alkalmazása szövegdobozra**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy animációt alkalmazz a forma szövegére. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iautoshape/)-t.  
4. Adjon szöveget a `IAutoShape.TextFrame`-hez.  
5. Szerezze meg a fő hatássorozatot.  
6. Adjon animációs hatást a [IAutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iautoshape/)-hez.  
7. Állítsa be a `TextAnimation.BuildType` tulajdonságot a `BuildType` felsorolás értékére.  
8. Írja a prezentációt lemezre PPTX fájlként.  

Ez a Python kód bemutatja, hogyan alkalmazza a `Fade` hatást egy AutoShape-re, és hogyan állítsa be a szöveganimációt a *By 1st Level Paragraphs* értékre:

```python
import aspose.slides as slides

# Létrehozza a prezentációt reprezentáló osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Új AutoShape-et ad hozzá szöveggel
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Lekéri a dia fő szekvenciáját.
    sequence = sld.timeline.main_sequence

    # Fade animációs hatást ad hozzá az alakzathoz
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Az alakzat szövegét az első szintű bekezdések szerint animálja
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

A szövegre alkalmazott animációk mellett animációkat alkalmazhat egyetlen [Paragraph](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iparagraph/) elemre is. Lásd [**Animált szöveg**](/slides/hu/python-net/animated-text/).

{{% /alert %}} 

## **Animáció alkalmazása PictureFrame-re**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon hozzá vagy szerezze meg a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) elemet a dián.  
4. Szerezze meg a fő hatássorozatot.  
5. Adjon animációs hatást a [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/)-hez.  
6. Mentse a prezentációt lemezre PPTX fájlként.  

Ez a Python kód bemutatja, hogyan alkalmazza a `Fly` hatást egy képkeretre:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as pres:
    # Betölti a képet, amelyet a prezentáció képtárához adunk hozzá
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Képkockát ad hozzá a diára
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Lekéri a dia fő szekvenciáját.
    sequence = pres.slides[0].timeline.main_sequence

    # Fly from Left animációs hatást ad a képkockához
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Animáció alkalmazása alakzatra**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy `rectangle` [IAutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iautoshape/)-t.  
4. Adjon hozzá egy `Bevel` [IAutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/iautoshape/) elemet (amikor ez az objektumra kattintanak, az animáció lejátszásra kerül).  
5. Hozzon létre egy hatássorozatot a bevel alakzaton.  
6. Hozzon létre egy egyedi `UserPath`-t.  
7. Adjon parancsokat a `UserPath`-ra való mozgáshoz.  
8. Mentse a prezentációt lemezre PPTX fájlként.  

Ez a Python kód bemutatja, hogyan alkalmazza a `PathFootball` (path football) hatást egy alakzatra:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Létrehozza a PathFootball hatást a meglévő alakzatra a nulláról.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Hozzáadja a PathFootBall animációs hatást.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Létrehoz egyfajta "gombot".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Létrehoz egy hatássorozatot a gombhoz.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Létrehoz egy egyéni felhasználói útvonalat. Az objektumunk csak a gomb megnyomása után lesz mozgatva.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Parancsokat ad a mozgáshoz, mivel a létrehozott útvonal üres.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Alkalmazott animációs hatások lekérése alakzatra**

Az alábbi példák bemutatják, hogyan használja a `get_effects_by_shape` metódust a [Sequence](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/sequence/) osztályból, hogy lekérje az adott alakzatra alkalmazott összes animációs hatást.

**Példa 1: Animációs hatások lekérése egy alakzatra egy normál dián**

Korábban megtanulta, hogyan adjon animációs hatásokat alakzatokhoz a PowerPoint előadásokban. Az alábbi mintakód bemutatja, hogyan kérje le az első alakzatra az első normál dián a `AnimExample_out.pptx` prezentációban alkalmazott hatásokat.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Lekéri a dia fő animációs sorozatát.
    sequence = first_slide.timeline.main_sequence

    # Lekéri az első alakzatot az első dián.
    shape = first_slide.shapes[0]

    # Lekéri az alakzatra alkalmazott animációs hatásokat.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Példa 2: Az összes animációs hatás lekérése, beleértve a helyőrzőkből örökölt hatásokat is**

Ha egy alakzat egy normál dián helyőrzőkkel rendelkezik, amelyek a layout dián és/vagy a mester dián találhatók, és ezekhez a helyőrzőkhöz animációs hatásokat adtak hozzá, akkor az alakzat összes hatása le lesz játszva a diavetítés során, beleértve a helyőrzőkből örökölt hatásokat is.

Tegyük fel, hogy van egy `sample.pptx` PowerPoint prezentációfájlunk, amely egyetlen diát tartalmaz, azon egy lábléc alakzatot a "Made with Aspose.Slides" szöveggel, és a **Random Bars** hatás van alkalmazva az alakzatra.

![Slide shape animation effect](slide-shape-animation.png)

Tegyük fel továbbá, hogy a **Split** hatás a **layout** dián lévő lábléc helyőrzőre van alkalmazva.

![Layout shape animation effect](layout-shape-animation.png)

Végül a **Fly In** hatás a **master** dián lévő lábléc helyőrzőre van alkalmazva.

![Master shape animation effect](master-shape-animation.png)

Az alábbi mintakód bemutatja, hogyan használja a `get_base_placeholder` metódust a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályból, hogy hozzáférjen a forma helyőrzőkhöz, és lekérje a lábléc alakzatra alkalmazott animációs hatásokat, beleértve a layout és master diák helyőrzőiből örökölt hatásokat is.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # A normális dián lévő alakzat animációs hatásainak lekérése.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # A layout dián lévő helyőrző animációs hatásainak lekérése.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # A master dián lévő helyőrző animációs hatásainak lekérése.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Animációs hatás időzítési tulajdonságainak módosítása**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy módosítsa egy animációs hatás időzítési tulajdonságait.

Ez a Microsoft PowerPoint animációs időzítési ablaka:

![example1_image](shape-animation.png)

Ezek a megfeleltetések a PowerPoint időzítés és az `Effect.Timing` tulajdonságok között:

- A PowerPoint időzítés **Start** legördülő listája megfelel a [Effect.Timing.TriggerType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/effecttriggertype/) tulajdonságnak.  
- A PowerPoint időzítés **Duration** megfelel az `Effect.Timing.Duration` tulajdonságnak. Egy animáció időtartama (másodpercben) az az össz idő, amely alatt az animáció befejeződik egy ciklusban.  
- A PowerPoint időzítés **Delay** megfelel az `Effect.Timing.TriggerDelayTime` tulajdonságnak.  

Ez a módja annak, hogyan változtathatja meg az Effect Timing tulajdonságokat:

1. Alkalmazza ([Apply](#apply-animation-to-shape)) vagy szerezze meg az animációs hatást.  
2. Állítsa be a szükséges `Effect.Timing` tulajdonságok új értékeit.  
3. Mentse a módosított PPTX fájlt.  

Ez a Python kód demonstrálja a műveletet:

```python
import aspose.slides as slides

# Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Lekéri a dia fő sorozatát.
    sequence = pres.slides[0].timeline.main_sequence

    # Lekéri a fő sorozat első hatását.
    effect = sequence[0]

    # Módosítja a hatás TriggerType-át, hogy kattintásra induljon
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Módosítja a hatás időtartamát
    effect.timing.duration = 3

    # Módosítja a hatás TriggerDelayTime-ot
    effect.timing.trigger_delay_time = 0.5

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Animációs hatás hangja**

Az Aspose.Slides ezekkel a tulajdonságokkal teszi lehetővé a hangok kezelését animációs hatásokban: 

- `sound`
- `stop_previous_sound`

### **Animációs hatás hangjának hozzáadása**

Ez a Python kód bemutatja, hogyan adjon hozzá egy animációs hatás hangot, és hogyan állítsa le, amikor a következő hatás elindul:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Hozzáad egy hangfájlt a prezentáció audio gyűjteményéhez
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Lekéri a dia fő sorozatát.
    sequence = first_slide.timeline.main_sequence

    # Lekéri a fő sorozat első hatását.
    first_effect = sequence[0]

    # Ellenőrzi, hogy a hatásnak nincs hangja
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Hozzáad hangot az első hatáshoz
        first_effect.sound = effect_sound

    # Lekéri a dia első interaktív sorozatát.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Beállítja a hatás "Előző hang leállítása" jelzőjét
    interactive_sequence[0].stop_previous_sound = True

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Animációs hatás hangjának kinyerése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Szerezze meg a dia referenciáját az indexe alapján.  
3. Szerezze meg a fő hatássorozatot.  
4. Kinyerje a `sound` beágyazott hangot minden animációs hatásból.  

Ez a Python kód bemutatja, hogyan nyerje ki az animációs hatásba beágyazott hangot:

```python
import aspose.slides as slides

# Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Lekéri a dia fő sorozatát.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Kinyeri a hatás hangját bájttömbként
        audio = effect.sound.binary_data
```

## **Animáció után**

Az Aspose.Slides for .NET lehetővé teszi, hogy módosítsa egy animációs hatás „After animation” tulajdonságát.

Ez a Microsoft PowerPoint animációs hatás ablaka és kiterjesztett menüje:

![example1_image](shape-after-animation.png)

A PowerPoint Effect **After animation** legördülő listája a következő tulajdonságoknak felel meg: 

- `after_animation_type` tulajdonság, amely leírja az After animation típust:
  * A PowerPoint **More Colors** a [COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
  * A PowerPoint **Don't Dim** elem a [DO_NOT_DIM](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típusnak felel meg (az alapértelmezett after animation típus);
  * A PowerPoint **Hide After Animation** elem a [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
  * A PowerPoint **Hide on Next Mouse Click** elem a [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típusnak felel meg;
- `after_animation_color` tulajdonság, amely egy after animation színformátumot definiál. Ez a tulajdonság a [COLOR](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/afteranimationtype/) típussal együtt működik. Ha a típust másikra változtatja, az after animation szín törlődik.

Ez a Python kód bemutatja, hogyan módosítsa az after animation hatást:

```python
import aspose.slides as slides

# Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Lekéri a fő sorozat első hatását
    first_effect = first_slide.timeline.main_sequence[0]

    # Megváltoztatja az after animation típusát Color-re
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Beállítja az after animation sötétítő színt
    first_effect.after_animation_color.color = Color.alice_blue

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Szöveg animálása**

Az Aspose.Slides ezekkel a tulajdonságokkal teszi lehetővé, hogy egy animációs hatás *Animate text* blokkját kezelje:

- `animate_text_type` amely leírja az animációs hatás *Animate text* típusát. A forma szövege animálható:
  - Egyszerre ([ALL_AT_ONCE](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/animatetexttype/) típus)
  - Szónként ([BY_WORD](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/animatetexttype/) típus)
  - Betűnként ([BY_LETTER](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/animatetexttype/) típus)
- `delay_between_text_parts` késleltetést állít be az animált szövegrészek (szavak vagy betűk) között. A pozitív érték a hatás időtartamának százalékát adja meg. A negatív érték késleltetést másodpercben határoz meg.

Ez a módja annak, hogyan változtathatja meg az Effect Animate text tulajdonságokat:

1. Alkalmazza ([Apply](#apply-animation-to-shape)) vagy szerezze meg az animációs hatást.  
2. Állítsa be a `build_type` tulajdonságot az [AS_ONE_OBJECT](https://reference.aspose.com/slides/hu/python-net/aspose.slides.animation/buildtype/) értékre, hogy kikapcsolja a *By Paragraphs* animációs módot.  
3. Állítson be új értékeket a `animate_text_type` és `delay_between_text_parts` tulajdonságokhoz.  
4. Mentse a módosított PPTX fájlt.  

Ez a Python kód demonstrálja a műveletet:

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Lekéri a fő sorozat első hatását
    first_effect = first_slide.timeline.main_sequence[0]

    # Megváltoztatja a hatás szöveganimáció típusát "As One Object"-ra
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Megváltoztatja a hatás Animate text típusát "By word"-ra
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Beállítja a szavak közötti késleltetést a hatás időtartamának 20%-ára
    first_effect.delay_between_text_parts = 20

    # Elmenti a PPTX fájlt a lemezre
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **GYIK**

**Hogyan biztosíthatom, hogy az animációk megmaradjanak a prezentáció webre közzétételekor?**

[Export to HTML5](/slides/hu/python-net/export-to-html5/) és engedélyezze a [beállításokat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/), amelyek a [shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_shapes/) és a [transition](https://reference.aspose.com/slides/hu/python-net/aspose.slides.export/html5options/animate_transitions/) animációkat kezelik. A sima HTML nem játssza le a diák animációit, míg a HTML5 igen.

**Hogyan befolyásolja az animációt az alakzatok z-sorrendjének (rétegsorrendjének) módosítása?**

Az animációs és a rajzolási sorrend független egymástól: egy hatás szabályozza a megjelenés/tűnés időzítését és típusát, míg a [z-sorrend](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/z_order_position/) meghatározza, mi takarja meg a másikat. A látható eredmény ezek kombinációjából származik. (Ez a PowerPoint általános viselkedése; az Aspose.Slides animáció‑és alakzatmodellje ugyanazt a logikát követi.)

**Vannak korlátozások az animációk videóra konvertálásakor bizonyos hatások esetén?**

Általánosságban a [animációk támogatottak](/slides/hu/python-net/convert-powerpoint-to-video/), de ritka esetekben vagy speciális hatások esetén eltérő módon jelenhetnek meg. Ajánlott a használt hatásokkal és a könyvtár verziójával tesztelni.