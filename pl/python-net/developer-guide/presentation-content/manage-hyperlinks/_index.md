---
title: Zarządzaj hiperłączami w prezentacjach przy użyciu Pythona
linktitle: Zarządzaj hiperłączem
type: docs
weight: 20
url: /pl/python-net/manage-hyperlinks/
keywords:
- dodaj URL
- dodaj hiperłącze
- utwórz hiperłącze
- formatuj hiperłącze
- usuń hiperłącze
- zaktualizuj hiperłącze
- hiperłącze tekstowe
- hiperłącze slajdu
- hiperłącze kształtu
- hiperłącze obrazu
- hiperłącze wideo
- modyfikowalne hiperłącze
- PowerPoint
- OpenDocument
- prezentacja
- Python
description: "Łatwo zarządzaj hiperłączami w prezentacjach PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona poprzez .NET — zwiększ interaktywność i efektywność pracy w kilka minut."
---
## **Wprowadzenie**

Hiperłącze to odwołanie do zasobu zewnętrznego, obiektu lub elementu danych, albo konkretnego miejsca w pliku. Typowe rodzaje hiperłączy w prezentacjach PowerPoint obejmują:

* Linki do witryn internetowych osadzone w tekście, kształtach lub mediach
* Linki do slajdów

Aspose.Slides dla Pythona poprzez .NET umożliwia szeroki zakres operacji związanych z hiperłączami w prezentacjach.

## **Dodawanie hiperłączy URL**

Ta sekcja wyjaśnia, jak dodać hiperłącza URL do elementów slajdu podczas pracy z Aspose.Slides. Obejmuje przydzielanie adresów linków do tekstu, kształtów i obrazów, aby zapewnić płynne nawigowanie podczas prezentacji.

### **Dodawanie hiperłączy URL do tekstu**

Poniższy przykład kodu pokazuje, jak dodać hiperłącze do witryny w tekście:

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

### **Dodawanie hiperłączy URL do kształtów lub ramek**

Poniższy przykład kodu pokazuje, jak dodać hiperłącze do witryny w kształcie:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Dodawanie hiperłączy URL do mediów**

Aspose.Slides umożliwia dodawanie hiperłączy do plików obrazów, audio i wideo.

Poniższy przykład kodu pokazuje, jak dodać hiperłącze do **obrazu**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Dodaj obraz do prezentacji.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Utwórz ramkę obrazu na slajdzie 1, używając wcześniej dodanego obrazu.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Poniższy przykład kodu pokazuje, jak dodać hiperłącze do **pliku audio**:

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

Poniższy przykład kodu pokazuje, jak dodać hiperłącze do **wideo**:

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
Możesz chcieć zobaczyć [Zarządzanie OLE w prezentacjach przy użyciu Pythona](/slides/pl/python-net/manage-ole/).
{{% /alert %}}

## **Używanie hiperłączy do tworzenia spisu treści**

Ponieważ hiperłącza pozwalają odwoływać się do obiektów lub lokalizacji, możesz ich używać do budowania spisu treści.

Poniższy kod przykładowy pokazuje, jak stworzyć spis treści z hiperłączami:

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

## **Formatowanie hiperłączy**

Ta sekcja pokazuje, jak formatować wygląd hiperłączy w Aspose.Slides. Nauczysz się kontrolować kolor i inne opcje stylu, aby zachować spójne formatowanie hiperłączy w tekście, kształtach i obrazach.

### **Kolor hiperłącza**

Używając właściwości [color_source](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/color_source/) klasy [Hyperlink](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/), możesz ustawić kolor hiperłącza i odczytać informacje o jego kolorze. Funkcja ta została wprowadzona w PowerPoint 2019, więc zmiany dokonane za pomocą tej właściwości nie obowiązują w wcześniejszych wersjach PowerPoint.

Poniższy przykład demonstruje, jak dodać hiperłącza o różnych kolorach do tego samego slajdu:

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

## **Usuwanie hiperłączy z prezentacji**

Ta sekcja wyjaśnia, jak usuwać hiperłącza z prezentacji podczas pracy z Aspose.Slides. Nauczysz się, jak wyczyścić cele linków w tekście, kształtach i obrazach, zachowując pierwotną zawartość i formatowanie.

### **Usuwanie hiperłączy z tekstu**

Poniższy przykładowy kod pokazuje, jak usunąć hiperłącza z tekstu na slajdzie prezentacji:

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

### **Usuwanie hiperłączy z kształtów lub ramek**

Poniższy przykładowy kod pokazuje, jak usunąć hiperłącza z kształtów na slajdzie prezentacji: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Modyfikowalne hiperłącza**

Klasa [Hyperlink](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/) jest modyfikowalna. Korzystając z tej klasy, możesz zmienić wartości następujących właściwości:

- [target_frame](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Poniższy fragment kodu pokazuje, jak dodać hiperłącze do slajdu, a następnie edytować jego podpowiedź (tooltip):

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

## **Obsługiwane właściwości w IHyperlinkQueries**

Możesz uzyskać dostęp do [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/) z prezentacji, slajdu lub tekstu zawierającego hiperłącze.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/textframe/hyperlink_queries/)

Klasa [HyperlinkQueries](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/) obsługuje następujące metody: 

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/pl/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Możesz chcieć sprawdzić prosty, darmowy edytor [PowerPoint online od Aspose](https://products.aspose.app/slides/pl/editor).
{{% /alert %}}

## **FAQ**

**Jak mogę utworzyć wewnętrzną nawigację nie tylko do slajdu, ale do „sekcji” lub pierwszego slajdu sekcji?**

Sekcje w PowerPoint to grupy slajdów; nawigacja technicznie odnosi się do konkretnego slajdu. Aby „nawigować do sekcji”, zwykle linkujesz do jej pierwszego slajdu.

**Czy mogę dołączyć hiperłącze do elementów slajdu wzorcowego, aby działało na wszystkich slajdach?**

Tak. Elementy slajdu wzorcowego i układu obsługują hiperłącza. Takie linki pojawiają się na slajdach podrzędnych i są klikalne podczas pokazu slajdów.

**Czy hiperłącza będą zachowane przy eksportowaniu do PDF, HTML, obrazów lub wideo?**

W [PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/) i [HTML](/slides/pl/python-net/convert-powerpoint-to-html/) tak — linki są zazwyczaj zachowane. Przy eksporcie do [obrazów](/slides/pl/python-net/convert-powerpoint-to-png/) i [wideo](/slides/pl/python-net/convert-powerpoint-to-video/), możliwość klikania nie zostanie przeniesiona ze względu na charakter tych formatów (klatki rastrowe/wideo nie obsługują hiperłączy).