---
title: Správa hypertextových odkazů v prezentacích pomocí Pythonu
linktitle: Správa odkazu
type: docs
weight: 20
url: /cs/python-net/manage-hyperlinks/
keywords:
- přidat URL
- přidat hypertextový odkaz
- vytvořit hypertextový odkaz
- formátovat hypertextový odkaz
- odebrat hypertextový odkaz
- aktualizovat hypertextový odkaz
- textový hypertextový odkaz
- hypertextový odkaz na snímek
- hypertextový odkaz na tvar
- hypertextový odkaz na obrázek
- hypertextový odkaz na video
- měnitelný hypertextový odkaz
- PowerPoint
- OpenDocument
- prezentace
- Python
description: "Jednoduše spravujte hypertextové odkazy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via .NET — zvyšte interaktivitu a efektivitu práce během několika minut."
---
## **Úvod**

Hypertextový odkaz je odkaz na externí zdroj, objekt nebo datovou položku, nebo konkrétní místo v souboru. Mezi běžné typy hypertextových odkazů v prezentacích PowerPoint patří:

* Odkazy na webové stránky vložené do textu, tvarů nebo médií
* Odkazy na snímky

Aspose.Slides for Python via .NET umožňuje širokou škálu operací souvisejících s hypertextovými odkazy v prezentacích.

## **Přidání hypertextových odkazů URL**

V této části je vysvětleno, jak přidávat hypertextové odkazy URL k prvkům snímku při práci s Aspose.Slides. Pokrývá přiřazování adres odkazů k textu, tvarům a obrázkům, aby byla zajištěna plynulá navigace během prezentací.

### **Přidání hypertextových odkazů URL k textu**

Následující ukázkový kód ukazuje, jak přidat hypertextový odkaz na webovou stránku do textu:

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

### **Přidání hypertextových odkazů URL k tvarům nebo rámcům**

Následující ukázkový kód ukazuje, jak přidat hypertextový odkaz na webovou stránku k tvaru:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Přidání hypertextových odkazů URL k médiím**

Aspose.Slides vám umožňuje přidávat hypertextové odkazy k obrázkům, zvukovým a video souborům.

Následující ukázkový kód ukazuje, jak přidat hypertextový odkaz k **obrázku**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidejte obrázek do prezentace.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Vytvořte rámeček obrázku na snímku 1 pomocí dříve přidaného obrázku.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Následující ukázkový kód ukazuje, jak přidat hypertextový odkaz k **audio souboru**:

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

Následující ukázkový kód ukazuje, jak přidat hypertextový odkaz k **videu**:

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
Můžete chtít zobrazit [Správa OLE v prezentacích pomocí Pythonu](/slides/cs/python-net/manage-ole/).
{{% /alert %}}

## **Použití hypertextových odkazů k vytvoření obsahu**

Protože hypertextové odkazy umožňují odkazovat na objekty nebo místa, můžete je použít k vytvoření obsahu.

Ukázkový kód níže ukazuje, jak vytvořit obsah s hypertextovými odkazy:

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

## **Formátování hypertextových odkazů**

V této části je ukázáno, jak formátovat vzhled hypertextových odkazů v Aspose.Slides. Naučíte se ovládat barvu a další možnosti stylů, aby formátování hypertextových odkazů bylo konzistentní v celém textu, tvarech a obrázcích.

### **Barva hypertextového odkazu**

Pomocí vlastnosti [color_source](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/color_source/) třídy [Hyperlink](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/) můžete nastavit barvu hypertextového odkazu a přečíst informace o jeho barvě. Tato funkce byla zavedena v PowerPoint 2019, takže změny provedené pomocí této vlastnosti se nepoužijí na starší verze PowerPointu.

Následující ukázka demonstruje, jak přidat hypertextové odkazy s různými barvami na stejný snímek:

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

## **Odstranění hypertextových odkazů z prezentací**

V této části je vysvětleno, jak odstranit hypertextové odkazy z prezentací při práci s Aspose.Slides. Naučíte se, jak vymazat cíle odkazů z textu, tvarů a obrázků při zachování původního obsahu a formátování.

### **Odstranění hypertextových odkazů z textu**

Následující ukázkový kód ukazuje, jak odstranit hypertextové odkazy z textu na snímku prezentace:

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

### **Odstranění hypertextových odkazů z tvarů nebo rámců**

Následující ukázkový kód ukazuje, jak odstranit hypertextové odkazy z tvarů na snímku prezentace: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Měnitelné hypertextové odkazy**

Třída [Hyperlink](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/) je měnitelná. Pomocí této třídy můžete měnit hodnoty následujících vlastností:

- [target_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Následující útržek kódu ukazuje, jak přidat hypertextový odkaz na snímek a poté upravit jeho tooltip:

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

## **Podporované vlastnosti v IHyperlinkQueries**

Můžete získat přístup k [HyperlinkQueries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/) z prezentace, snímku nebo textu, který hypertextový odkaz obsahuje.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/hyperlink_queries/)

Třída [HyperlinkQueries](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/) podporuje následující metody: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/cs/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Můžete si chtít vyzkoušet jednoduchý, bezplatný online [editor PowerPointu](https://products.aspose.app/slides/cs/editor).
{{% /alert %}}

## **Často kladené otázky**

**Jak mohu vytvořit vnitřní navigaci nejen na snímek, ale i na „sekci“ nebo první snímek sekce?**

Sekce v PowerPointu jsou seskupení snímků; navigace technicky cílí na konkrétní snímek. Pro „navigaci do sekce“ obvykle odkazujete na její první snímek.

**Mohu připojit hypertextový odkaz k prvkům hlavní snímku, aby fungoval na všech snímcích?**

Ano. Prvky hlavního snímku a rozvržení podporují hypertextové odkazy. Tyto odkazy se zobrazí na podřízených snímcích a jsou během prezentace klikatelné.

**Zůstanou hypertextové odkazy zachovány při exportu do PDF, HTML, obrázků nebo videa?**

Při exportu do [PDF](/slides/cs/python-net/convert-powerpoint-to-pdf/) a [HTML](/slides/cs/python-net/convert-powerpoint-to-html/) ano – odkazy jsou obecně zachovány. Při exportu do [obrázků](/slides/cs/python-net/convert-powerpoint-to-png/) a [videí](/slides/cs/python-net/convert-powerpoint-to-video/) klikatelnost není přenositelná kvůli povaze těchto formátů (rasterové snímky/video nepodporují hypertextové odkazy).