---
title: Hantera hyperlänkar i presentationer med Python
linktitle: Hantera hyperlänk
type: docs
weight: 20
url: /sv/python-net/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- texthyperlänk
- bildhyperlänk
- formhyperlänk
- grafikhyperlänk
- videohyperlänk
- muterbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Python
description: "Hantera hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET på ett enkelt sätt - förbättra interaktivitet och arbetsflöde på några minuter."
---
## **Introduktion**

En hyperlänk är en referens till en extern resurs, ett objekt eller ett dataobjekt, eller en specifik plats i en fil. Vanliga hyperlänktyper i PowerPoint-presentationer inkluderar:

* Länkar till webbplatser inbäddade i text, former eller media
* Länkar till bilder

Aspose.Slides för Python via .NET möjliggör ett brett utbud av hyperlänkrelevanta operationer i presentationer.

## **Lägg till URL‑hyperlänkar**

Detta avsnitt förklarar hur du lägger till URL‑hyperlänkar till bild‑element när du arbetar med Aspose.Slides. Det täcker hur du tilldelar länkar till text, former och bilder för att säkerställa smidig navigation under presentationer.

### **Lägg till URL‑hyperlänkar till text**

Följande kodexempel visar hur du lägger till en webbplats‑hyperlänk till text:

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

### **Lägg till URL‑hyperlänkar till former eller ramar**

Följande kodexempel visar hur du lägger till en webbplats‑hyperlänk till en form:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Lägg till URL‑hyperlänkar till media**

Aspose.Slides låter dig lägga till hyperlänkar till bilder, ljud‑ och videofiler.

Följande kodexempel visar hur du lägger till en hyperlänk till en **bild**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Lägg till en bild i presentationen.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Skapa en bildram på bild 1 med bilden som lagts till tidigare.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Följande kodexempel visar hur du lägger till en hyperlänk till en **ljudfil**:

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

Följande kodexempel visar hur du lägger till en hyperlänk till en **video**:

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

{{% alert title="Tips" color="primary" %}}
Du kanske vill se [Hantera OLE i presentationer med Python](/slides/sv/python-net/manage-ole/).
{{% /alert %}}

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Eftersom hyperlänkar låter dig referera till objekt eller platser, kan du använda dem för att bygga en innehållsförteckning.

Exempelkoden nedan visar hur du skapar en innehållsförteckning med hyperlänkar:

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

## **Formatera hyperlänkar**

Detta avsnitt visar hur du formaterar utseendet på hyperlänkar i Aspose.Slides. Du får lära dig att styra färg och andra stilalternativ för att hålla hyperlänkformatering enhetlig för text, former och bilder.

### **Hyperlänkfärg**

Genom att använda egenskapen [color_source](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/color_source/) i klassen [Hyperlink](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/) kan du ange en hyperlänks färg och läsa dess färginformation. Denna funktion introducerades i PowerPoint 2019, så ändringar som görs via denna egenskap gäller inte för tidigare versioner av PowerPoint.

Följande exempel demonstrerar hur du lägger till hyperlänkar med olika färger på samma bild:

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

## **Ta bort hyperlänkar från presentationer**

Detta avsnitt förklarar hur du tar bort hyperlänkar från presentationer när du arbetar med Aspose.Slides. Du får lära dig hur du rensar länkmål från text, former och bilder samtidigt som du bevarar det ursprungliga innehållet och formateringen.

### **Ta bort hyperlänkar från text**

Följande exempel kod visar hur du tar bort hyperlänkar från text på en presentationsbild:

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

### **Ta bort hyperlänkar från former eller ramar**

Följande exempel kod visar hur du tar bort hyperlänkar från former på en presentationsbild: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Muterbara hyperlänkar**

Klassen [Hyperlink](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/) är muterbar. Med denna klass kan du ändra värdena för följande egenskaper:

- [target_frame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Följande kodsnutt visar hur du lägger till en hyperlänk till en bild och sedan redigerar dess verktygstips:

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

## **Stödda egenskaper i IHyperlinkQueries**

Du kan komma åt [HyperlinkQueries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/) från presentationen, bilden eller texten som innehåller hyperlänken.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/textframe/hyperlink_queries/)

Klassen [HyperlinkQueries](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/) stödjer dessa metoder: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/sv/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Du kanske vill kolla in Asposes enkla, kostnadsfria online‑[PowerPoint‑redigerare](https://products.aspose.app/slides/sv/editor).
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag skapa intern navigation inte bara till en bild, utan till en "sektion" eller den första bilden i en sektion?**

Sektioner i PowerPoint är gruppering av bilder; navigationen pekar tekniskt på en specifik bild. För att "navigera till en sektion" länkar du vanligtvis till dess första bild.

**Kan jag bifoga en hyperlänk till master‑bild‑element så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Sådana länkar visas på underordnade bilder och är klickbara under bildspelet.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

I [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/python-net/convert-powerpoint-to-html/) bevaras länkarna generellt. Vid export till [bilder](/slides/sv/python-net/convert-powerpoint-to-png/) och [video](/slides/sv/python-net/convert-powerpoint-to-video/) överförs inte klickbarhet eftersom dessa format (raster‑ramar/video) inte stödjer hyperlänkar.