---
title: Gérer les hyperliens dans les présentations avec Python
linktitle: Gérer l'hyperlien
type: docs
weight: 20
url: /fr/python-net/developer-guide/presentation-content/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter un hyperlien
- créer un hyperlien
- formater un hyperlien
- supprimer un hyperlien
- mettre à jour un hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- Python
description: "Gérez facilement les hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET — améliorez l’interactivité et le flux de travail en quelques minutes."
---

## **Vue d'ensemble**

Un hyperlien est une référence à une ressource externe, à un objet ou à un élément de données, ou à un emplacement spécifique dans un fichier. Les types d'hyperliens courants dans les présentations PowerPoint comprennent :

* Liens vers des sites web intégrés dans le texte, les formes ou les médias
* Liens vers des diapositives

Aspose.Slides pour Python via .NET permet d’effectuer un large éventail d’opérations liées aux hyperliens dans les présentations.

## **Ajouter des hyperliens URL**

Cette section explique comment ajouter des hyperliens URL aux éléments de diapositive lors de l’utilisation d’Aspose.Slides. Elle couvre l’attribution d’adresses de liens au texte, aux formes et aux images afin d’assurer une navigation fluide pendant les présentations.

### **Ajouter des hyperliens URL au texte**

L’exemple de code suivant montre comment ajouter un hyperlien vers un site web à du texte :

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

### **Ajouter des hyperliens URL aux formes ou aux cadres**

L’exemple de code suivant montre comment ajouter un hyperlien vers un site web à une forme :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajouter des hyperliens URL aux médias**

Aspose.Slides vous permet d’ajouter des hyperliens aux images, aux fichiers audio et vidéo.

L’exemple de code suivant montre comment ajouter un hyperlien à une **image** :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an image to the presentation.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # Create a picture frame on slide 1 using the image added earlier.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

L’exemple de code suivant montre comment ajouter un hyperlien à un **fichier audio** :

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

L’exemple de code suivant montre comment ajouter un hyperlien à une **vidéo** :

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
Vous pourriez vouloir consulter [Gérer OLE dans les présentations avec Python](/slides/fr/python-net/manage-ole/).
{{% /alert %}}

## **Utiliser les hyperliens pour créer une table des matières**

Parce que les hyperliens vous permettent de référencer des objets ou des emplacements, vous pouvez les utiliser pour créer une table des matières.

L’exemple de code ci‑dessous montre comment créer une table des matières avec des hyperliens :

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

## **Formater les hyperliens**

Cette section montre comment formater l’apparence des hyperliens dans Aspose.Slides. Vous apprendrez à contrôler la couleur et d’autres options de style afin de maintenir un format d’hyperlien cohérent sur le texte, les formes et les images.

### **Couleur de l'hyperlien**

En utilisant la propriété [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) de la classe [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/), vous pouvez définir la couleur d’un hyperlien et lire ses informations de couleur. Cette fonctionnalité a été introduite dans PowerPoint 2019, de sorte que les modifications apportées via cette propriété ne s’appliquent pas aux versions antérieures de PowerPoint.

L’exemple suivant démontre comment ajouter des hyperliens de différentes couleurs sur la même diapositive :

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

## **Supprimer les hyperliens des présentations**

Cette section explique comment supprimer les hyperliens des présentations lorsque vous travaillez avec Aspose.Slides. Vous apprendrez comment effacer les cibles de lien du texte, des formes et des images tout en préservant le contenu et le format d’origine.

### **Supprimer les hyperliens du texte**

Le code d’exemple suivant montre comment supprimer les hyperliens du texte sur une diapositive de présentation :

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

### **Supprimer les hyperliens des formes ou des cadres**

Le code d’exemple suivant montre comment supprimer les hyperliens des formes sur une diapositive de présentation :

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperliens mutables**

La classe [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) est mutable. En utilisant cette classe, vous pouvez modifier les valeurs de ces propriétés :

- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

Le fragment de code suivant montre comment ajouter un hyperlien à une diapositive puis modifier son info-bulle :

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

## **Propriétés prises en charge dans IHyperlinkQueries**

Vous pouvez accéder à [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) depuis la présentation, la diapositive ou le texte contenant l’hyperlien.

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/)

La classe [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) prend en charge ces méthodes :

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/)

{{% alert color="primary" %}}
Vous pourriez vouloir découvrir l’éditeur PowerPoint simple et gratuit en ligne d’Aspose : [PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **FAQ**

**How can I create internal navigation not just to a slide, but to a "section" or the first slide of a section?**  
Les sections dans PowerPoint sont des regroupements de diapositives ; la navigation cible techniquement une diapositive précise. Pour « naviguer vers une section », on lie généralement à sa première diapositive.

**Can I attach a hyperlink to master slide elements so it works on all slides?**  
Oui. Les éléments maître et de disposition prennent en charge les hyperliens. Ces liens apparaissent sur les diapositives enfant et sont cliquables pendant le diaporama.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**  
Dans les [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), oui — les liens sont généralement conservés. Lors de l’exportation vers des [images](/slides/fr/python-net/convert-powerpoint-to-png/) et [vidéo](/slides/fr/python-net/convert-powerpoint-to-video/), la cliquabilité n’est pas conservée en raison de la nature de ces formats (cadres raster/vidéo ne supportent pas les hyperliens).