---
title: Hiperhivatkozások kezelése a prezentációkban Python segítségével
linktitle: Hiperhivatkozás kezelése
type: docs
weight: 20
url: /hu/python-net/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Python
description: "Könnyedén kezelheti a hiperhivatkozásokat PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével — növelje az interaktivitást és a munkafolyamatot percek alatt."
---
## **Bevezetés**

A hiperhivatkozás egy hivatkozás külső erőforrásra, objektumra vagy adatpontra, vagy egy fájlon belüli konkrét helyre. A PowerPoint‑prezentációkban gyakori hiperhivatkozástípusok:

* Weboldalakra mutató hivatkozások, beágyazva szövegbe, alakzatba vagy médiába
* Diákra mutató hivatkozások

Az Aspose.Slides for Python via .NET széleskörű hiperhivatkozással kapcsolatos műveleteket tesz lehetővé a prezentációkban.

## **URL‑hiperhivatkozások hozzáadása**

Ez a szakasz bemutatja, hogyan adhatunk URL‑hiperhivatkozásokat diák elemeihez az Aspose.Slides használata közben. Kitér arra, hogyan rendelhetünk hivatkozási címeket szöveghez, alakzatokhoz és képekhez a zökkenőmentes navigáció érdekében a prezentációk során.

### **URL‑hiperhivatkozások hozzáadása szöveghez**

A következő kódrészlet bemutatja, hogyan lehet weboldal‑hiperhivatkozást hozzáadni szöveghez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑hiperhivatkozások hozzáadása alakzatokhoz vagy keretekhez**

A következő kódrészlet bemutatja, hogyan lehet weboldal‑hiperhivatkozást hozzáadni egy alakzathoz:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **URL‑hiperhivatkozások hozzáadása médiához**

Az Aspose.Slides lehetővé teszi hiperhivatkozások hozzáadását képekhez, hang- és videofájlokhoz.

A következő kódrészlet bemutatja, hogyan lehet **képre** hiperhivatkozást adni:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Kép hozzáadása a prezentációhoz.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Képkocka létrehozása az 1. dián a korábban hozzáadott kép felhasználásával.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

A következő kódrészlet bemutatja, hogyan lehet **hangfájlra** hiperhivatkozást adni:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

A következő kódrészlet bemutatja, hogyan lehet **videóra** hiperhivatkozást adni:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
Érdemes lehet megnézni a [OLE kezelését a prezentációkban Python használatával](/slides/hu/python-net/manage-ole/).
{{% /alert %}}

## **Hiperhivatkozások használata tartalomjegyzék létrehozásához**

Mivel a hiperhivatkozások lehetővé teszik objektumok vagy helyek hivatkozását, felhasználhatók tartalomjegyzék építésére.

Az alábbi mintakód bemutatja, hogyan hozhatunk létre hiperhivatkozásokkal ellátott tartalomjegyzéket:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperhivatkozások formázása**

Ez a szakasz bemutatja, hogyan formázhatjuk a hiperhivatkozások megjelenését az Aspose.Slides‑ben. Megtanulja, hogyan szabályozhatja a színt és egyéb stílusbeállításokat, hogy a hiperhivatkozások formázása egységes maradjon a szövegben, alakzatokban és képekben.

### **Hiperhivatkozás színe**

A [color_source](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/color_source/) tulajdonság használatával a [Hyperlink](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/) osztályban beállíthatja egy hiperhivatkozás színét, illetve lekérdezheti annak színinformációit. Ez a funkció a PowerPoint 2019‑ben került bevezetésre, ezért a tulajdonságon keresztül végzett módosítások nem érintik a korábbi PowerPoint‑verziókat.

A következő példa bemutatja, hogyan lehet különböző **színű** hiperhivatkozásokat hozzáadni ugyanahhoz a diához:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hiperhivatkozások eltávolítása a prezentációkból**

Ez a szakasz bemutatja, hogyan távolíthatók el a hiperhivatkozások a prezentációkból az Aspose.Slides használata során. Megtanulja, hogyan törölheti a hivatkozási célokat a szövegből, alakzatokból és képekből, miközben megőrzi az eredeti tartalmat és formázást.

### **Hiperhivatkozások eltávolítása szövegből**

Az alábbi mintakód bemutatja, hogyan lehet hiperhivatkozásokat eltávolítani egy prezentációs dián lévő szövegből:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Hiperhivatkozások eltávolítása alakzatokból vagy keretekből**

Az alábbi mintakód bemutatja, hogyan lehet hiperhivatkozásokat eltávolítani egy prezentációs dián lévő alakzatokból:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Módosítható hiperhivatkozások**

A [Hyperlink](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/) osztály módosítható. Ezzel az osztállyal a következő tulajdonságok értékeit változtathatja meg:

- [target_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Az alábbi kódrészlet bemutatja, hogyan adhatunk hiperhivatkozást egy diára, majd szerkeszthetjük a tooltip‑jét:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Támogatott tulajdonságok az IHyperlinkQueries‑ben**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/) elérhető a prezentációból, a diámból vagy a hiperhivatkozást tartalmazó szövegből.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/hyperlink_queries/)

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/) osztály a következő metódusokat támogatja:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Érdemes megnézni az Aspose egyszerű, ingyenes online [PowerPoint szerkesztőjét](https://products.aspose.app/slides/hu/editor).
{{% /alert %}}

## **GYIK**

**Hogyan hozhatok létre belső navigációt nem csak egy diára, hanem egy „szakaszra” vagy a szakasz első diájára?**

A PowerPoint‑szakaszok a diák csoportjai; a navigáció technikailag egy adott diára mutat. „Szakaszra navigáláshoz” általában az első diájára kell hivatkozni.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Az ilyen hivatkozások a gyerekdiákon is megjelennek, és a bemutató közben kattinthatók.

**Megmaradnak a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-net/convert-powerpoint-to-html/) esetén igen — a hivatkozások általában megmaradnak. A [képek](/slides/hu/python-net/convert-powerpoint-to-png/) és a [videó](/slides/hu/python-net/convert-powerpoint-to-video/) exportálásakor a kattinthatóság nem őrzi meg, mivel a rasterképek és a videókeretek nem támogatják a hiperhivatkozásokat.