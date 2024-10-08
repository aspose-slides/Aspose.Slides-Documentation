---
title: Gérer les Hyperliens
type: docs
weight: 20
url: /fr/python-net/manage-hyperlinks/
keywords: "Ajouter un hyperlien, Présentation PowerPoint, Hyperlien PowerPoint, hyperlien texte, hyperlien diapositive, hyperlien forme, hyperlien image, hyperlien vidéo, Python"
description: "Ajouter un hyperlien à une présentation PowerPoint en Python"
---

Un hyperlien est une référence à un objet ou à des données ou à un endroit dans quelque chose. Voici des hyperliens courants dans les présentations PowerPoint :

* Liens vers des sites web dans des textes, des formes ou des médias
* Liens vers des diapositives

Aspose.Slides pour Python via .NET vous permet d'effectuer de nombreuses tâches impliquant des hyperliens dans les présentations. 

{{% alert color="primary" %}} 

Vous pouvez consulter l'éditeur PowerPoint en ligne simple et [gratuit d'Aspose.](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **Ajout d'Hyperliens URL**

### **Ajout d'Hyperliens URL à des Textes**

Ce code Python vous montre comment ajouter un hyperlien de site web à un texte :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose : API de format de fichier")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32
    
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajout d'Hyperliens URL à des Formes ou Cadres**

Ce code exemple en Python vous montre comment ajouter un hyperlien de site web à une forme :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajout d'Hyperliens URL à des Médias**

Aspose.Slides vous permet d'ajouter des hyperliens à des images, des fichiers audio et des fichiers vidéo. 

Ce code exemple vous montre comment ajouter un hyperlien à une **image** :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Ajoute une image à la présentation
    with open("img.jpeg", "rb") as fs:
        data = fs.read()
        image = pres.images.add_image(data)
        
        # Crée un cadre d'image sur la diapositive 1 basé sur l'image précédemment ajoutée
        pictureFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

        pictureFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        pictureFrame.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 Ce code exemple vous montre comment ajouter un hyperlien à un **fichier audio** :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("audio.mp3", "rb") as fs:
        data = fs.read()
        audio = pres.audios.add_audio(data)
        
        audioFrame = pres.slides[0].shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

        audioFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        audioFrame.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

 Ce code exemple vous montre comment ajouter un hyperlien à une **vidéo** :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("video.avi", "rb") as fs:
        data = fs.read()
        video = pres.videos.add_video(data)
        
        videoFrame = pres.slides[0].shapes.add_video_frame(10, 10, 100, 100, video)

        videoFrame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
        videoFrame.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert  title="Astuce"  color="primary"  %}} 

Vous pouvez consulter *[Gérer les OLE](https://docs.aspose.com/slides/python-net/manage-ole/)*.

{{% /alert %}}



## **Utilisation des Hyperliens pour Créer une Table des Matières**

Étant donné que les hyperliens vous permettent d'ajouter des références à des objets ou des lieux, vous pouvez les utiliser pour créer une table des matières. 

Ce code exemple vous montre comment créer une table des matières avec des hyperliens :

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
    paragraph.text = "Titre de la diapositive 2 .......... "

    linkPortion = slides.Portion()
    linkPortion.text = "Page 2"
    linkPortion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(linkPortion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```



## **Formatage des Hyperliens**

### **Couleur**

Avec la propriété [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/) dans l'interface [IHyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/), vous pouvez définir la couleur des hyperliens et aussi obtenir des informations de couleur à partir des hyperliens. La fonctionnalité a été introduite pour la première fois dans PowerPoint 2019, donc les changements impliquant la propriété ne s'appliquent pas aux anciennes versions de PowerPoint.

Ce code exemple montre une opération où des hyperliens avec différentes couleurs ont été ajoutés à la même diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Ceci est un exemple d'hyperlien coloré.")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.fill_type = slides.FillType.SOLID
    shape1.text_frame.paragraphs[0].portions[0].portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("Ceci est un exemple d'hyperlien habituel.")
    shape2.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```



## **Suppression des Hyperliens dans les Présentations**

### **Suppression des Hyperliens des Textes**

Ce code Python vous montre comment supprimer l'hyperlien d'un texte dans une diapositive de présentation :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    portion.portion_format.hyperlink_manager.remove_hyperlink_click()
    pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **Suppression des Hyperliens des Formes ou Cadres**

Ce code Python vous montre comment supprimer l'hyperlien d'une forme dans une diapositive de présentation : 

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as pres:
   slide = pres.slides[0]
   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()
   pres.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```



## **Hyperlien Mutable**

La classe [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink) est mutable. Avec cette classe, vous pouvez changer les valeurs de ces propriétés :

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.History](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlink/)

Le code exemple montre comment ajouter un hyperlien à une diapositive et modifier son tooltip par la suite :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape1 = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("Aspose : API de format de fichier")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape1.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click.tooltip = "Plus de 70 % des entreprises du Fortune 100 font confiance aux API d'Aspose"
    shape1.text_frame.paragraphs[0].portions[0].portion_format.font_height = 32

    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Propriétés Supportées dans IHyperlinkQueries**

Vous pouvez accéder à IHyperlinkQueries à partir d'une présentation, d'une diapositive ou d'un texte pour lequel l'hyperlien est défini. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/)

La classe IHyperlinkQueries prend en charge ces méthodes et propriétés : 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkqueries/)