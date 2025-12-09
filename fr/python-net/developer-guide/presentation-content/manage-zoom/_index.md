---
title: Gérer les zooms dans les présentations avec Python
linktitle: Zoom
type: docs
weight: 60
url: /fr/python-net/manage-zoom/
keywords:
- zoom
- cadre de zoom
- zoom de diapositive
- zoom de section
- zoom de synthèse
- ajouter un zoom
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Créez et personnalisez le Zoom avec Aspose.Slides pour Python via .NET — sautez entre les sections, ajoutez des miniatures et des transitions aux présentations PPT, PPTX et ODP."
---

## **Vue d'ensemble**
Les zooms dans PowerPoint vous permettent de passer d’une diapositive, d’une section ou d’une partie spécifique d’une présentation à une autre. Lorsque vous présentez, cette capacité à naviguer rapidement dans le contenu peut s’avérer très utile. 

![aperçu](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez le [Summary Zoom](#Summary-Zoom).
* Pour n'afficher que des diapositives sélectionnées, utilisez le [Slide Zoom](#Slide-Zoom).
* Pour n'afficher qu'une seule section, utilisez le [Section Zoom](#Section-Zoom).

## **Zoom de diapositive**

Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans l’ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositive sont idéaux pour des présentations courtes sans trop de sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les zooms de diapositive vous aident à approfondir plusieurs informations tout en donnant l’impression d’être sur une seule toile. 

![zoomdiapositive](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l’énumération [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), l’interface [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) et certaines méthodes de l’interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création de cadres de zoom**
Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives vers lesquelles vous avez l’intention de créer un lien. 
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) dans la première diapositive.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code d’exemple montre comment créer un cadre de zoom dans une diapositive :
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajouter de nouvelles diapositives à la présentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #Créer un arrière‑plan pour la deuxième diapositive
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #Créer une zone de texte pour la deuxième diapositive
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #Créer un arrière‑plan pour la troisième diapositive
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #Créer une zone de texte pour la troisième diapositive
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Ajouter des objets ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #Enregistrer la présentation
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```

### **Création de cadres de zoom avec images personnalisées**
Avec Aspose.Slides for Python via .NET, vous pouvez créer un cadre de zoom avec une image autre que l’image d’aperçu de la diapositive de cette façon : 
1. Créez une instance de la classe `Presentation`.
2. Créez une nouvelle diapositive vers laquelle vous avez l’intention de créer un lien. 
3. Ajoutez un texte d’identification et un arrière‑plan à la diapositive créée.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet Presentation qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) dans la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un cadre de zoom avec une image différente :
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajouter une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Créer un arrière-plan pour la deuxième diapositive
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Créer une zone de texte pour la troisième diapositive
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Créer une nouvelle image pour l'objet Zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Ajouter l'objet ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Enregistrer la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Mise en forme des cadres de zoom**
Dans les sections précédentes, nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus complexes, vous devez modifier la mise en forme des cadres. Plusieurs paramètres de mise en forme peuvent être appliqués à un cadre de zoom. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom dans une diapositive de cette manière :

1. Créez une instance de la classe `Presentation`.
2. Créez de nouvelles diapositives vers lesquelles créer un lien.
3. Ajoutez un texte d’identification et un arrière‑plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) dans la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l’objet Presentation qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l’arrière‑plan d’une image du deuxième objet de cadre de zoom.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment modifier la mise en forme d’un cadre de zoom : 
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajouter de nouvelles diapositives à la présentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Créer un arrière-plan pour la deuxième diapositive
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Créer une zone de texte pour la deuxième diapositive
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Créer un arrière-plan pour la troisième diapositive
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Créer une zone de texte pour la troisième diapositive
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #Ajouter des objets ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Créer une nouvelle image pour l'objet zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Définir une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.image = image

    # Définir un format de cadre zoom pour l'objet zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Ne pas afficher l'arrière-plan pour l'objet zoomFrame2
    zoomFrame2.show_background = False

    # Enregistrer la présentation
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```


## **Zoom de section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir à des sections que vous souhaitez vraiment mettre en avant. Vous pouvez également vous en servir pour souligner la façon dont certaines parties de votre présentation sont reliées. 

![zoomsection](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l’interface [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) et certaines méthodes sous l’interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création de cadres de zoom de section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous avez l’intention de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un cadre de zoom sur une diapositive :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 1", slide)

    # Ajoute un objet SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Création de cadres de zoom de section avec images personnalisées**

En utilisant Aspose.Slides for Python, vous pouvez créer un cadre de zoom de section avec une image d’aperçu de diapositive différente de cette façon : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous avez l’intention de lier le cadre de zoom. 
5. Créez un objet `IPPImage` en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un cadre de zoom avec une image différente :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 1", slide)

    # Crée une nouvelle image pour l'objet zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # Ajoute un objet SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Mise en forme des cadres de zoom de section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un cadre de zoom de section. 

Vous pouvez contrôler la mise en forme d’un cadre de zoom de section dans une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière‑plan d’identification à la diapositive créée.
4. Créez une nouvelle section vers laquelle vous avez l’intention de lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant les références à la section créée) à la première diapositive.
6. Modifiez la taille et la position de l’objet de zoom de section créé.
7. Créez un objet `IPPImage` en ajoutant une image à la collection Images associée à l’objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
8. Définissez une image personnalisée pour l’objet de cadre de zoom de section créé.
9. Activez la capacité *retour à la diapositive d’origine depuis la section liée*. 
10. Supprimez l’arrière‑plan d’une image de l’objet de cadre de zoom de section.
11. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
12. Modifiez la durée de la transition.
13. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment modifier la mise en forme d’un cadre de zoom de section :
```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 1", slide)

    # Ajoute un objet SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Mise en forme pour SectionZoomFrame
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **Zoom de synthèse**

Un zoom de synthèse ressemble à une page d’accueil où tous les éléments de votre présentation sont affichés en même temps. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d’un endroit de votre présentation à un autre dans l’ordre de votre choix. Vous pouvez faire preuve de créativité, sauter en avant ou revenir sur des parties de votre diaporama sans interrompre le flux de votre présentation.

![image_apercu](summaryzoom.png)

Pour les objets de zoom de synthèse, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) ainsi que plusieurs méthodes sous l’interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création d'un zoom de synthèse**

Vous pouvez ajouter un cadre de zoom de synthèse à une diapositive de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de zoom de synthèse à la première diapositive.
4. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment créer un cadre de zoom de synthèse sur une diapositive :
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Créer un tableau de diapositives
    for slideNumber in range(5):
        #Ajouter de nouvelles diapositives à la présentation
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Créer un arrière-plan pour la diapositive
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Créer une zone de texte pour la diapositive
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Créer des objets de zoom pour toutes les diapositives dans la première diapositive
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Définir la propriété ReturnToParent pour retourner à la première diapositive
        zoomFrame.return_to_parent = True

    # Enregistrer la présentation
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```


### **Ajout et suppression de sections de zoom de synthèse**

Toutes les sections d’un cadre de zoom de synthèse sont représentées par des objets [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), stockés dans l’objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). Vous pouvez ajouter ou supprimer un objet de section de zoom de synthèse via l’interface [ISummaryZoomSectionCollection] de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de synthèse dans la première diapositive.
4. Ajoutez une nouvelle diapositive et une nouvelle section à la présentation.
5. Ajoutez la section créée au cadre de zoom de synthèse.
6. Supprimez la première section du cadre de zoom de synthèse.
7. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment ajouter et supprimer des sections dans un cadre de zoom de synthèse :
``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 1", slide)

    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 2", slide)

    # Ajoute l'objet SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    section3 = pres.sections.add_section("Section 3", slide)

    # Ajoute une section au Summary Zoom
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Supprime la section du Summary Zoom
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


### **Mise en forme des sections du zoom de synthèse**

Pour créer des objets de section de zoom de synthèse plus complexes, vous devez modifier la mise en forme d’un cadre simple. Plusieurs options de mise en forme peuvent être appliquées à un objet de section de zoom de synthèse. 

Vous pouvez contrôler la mise en forme d’un objet de section de zoom de synthèse dans un cadre de zoom de synthèse de cette façon :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière‑plan d’identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de zoom de synthèse à la première diapositive.
4. Récupérez un objet de section de zoom de synthèse pour le premier objet depuis le `ISummaryZoomSectionCollection`.
5. Créez un objet `IPPImage` en ajoutant une image à la collection d’images associée à l’objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour l’objet de cadre de section de zoom créé.
7. Activez la capacité *retour à la diapositive d’origine depuis la section liée*. 
8. Modifiez le format de ligne pour le deuxième objet de cadre de zoom.
9. Modifiez la durée de la transition.
10. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code Python montre comment modifier la mise en forme d’un objet de section de zoom de synthèse :
```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 1", slide)

    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    pres.sections.add_section("Section 2", slide)

    # Ajoute un objet SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Obtient le premier objet SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Mise en forme de l'objet SummaryZoomSection
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je contrôler le retour à la diapositive « parent » après l'affichage de la cible ?**

Oui. Le [Zoom frame](https://reference.aspose.com/slides/python-net/aspose.slides/zoomframe/) ou le [section](https://reference.aspose.com/slides/python-net/aspose.slides/sectionzoomframe/) possède un comportement `return_to_parent` qui, lorsqu’il est activé, renvoie les spectateurs à la diapositive d’origine après qu’ils ont consulté le contenu cible.

**Puis-je ajuster la « vitesse » ou la durée de la transition du Zoom ?**

Oui. Le Zoom prend en charge la définition d’un `transition_duration` afin que vous puissiez contrôler la durée de l’animation de saut.

**Existe-t-il des limites au nombre d'objets Zoom qu'une présentation peut contenir ?**

Il n’y a pas de limite d’API documentée. Les limites pratiques dépendent de la complexité globale de la présentation et des performances du visualiseur. Vous pouvez ajouter de nombreux cadres de zoom, mais il faut tenir compte de la taille du fichier et du temps de rendu.