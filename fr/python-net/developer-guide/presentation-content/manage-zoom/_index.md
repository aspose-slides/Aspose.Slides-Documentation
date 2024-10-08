---
title: Gérer le Zoom
type: docs
weight: 60
url: /fr/python-net/manage-zoom/
keywords: "Zoom, cadre de zoom, Ajouter un zoom, Formater le cadre de zoom, Résumé de zoom, Présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter des zooms ou des cadres de zoom aux présentations PowerPoint en Python"
---

## **Aperçu**
Les zooms dans PowerPoint vous permettent de sauter vers des diapositives spécifiques, des sections, et des parties d'une présentation. Lorsque vous présentez, cette capacité à naviguer rapidement à travers le contenu peut s'avérer très utile. 

![aperçu](overview.png)

* Pour résumer une présentation entière sur une seule diapositive, utilisez un [Résumé de Zoom](#Résumé-Zoom).
* Pour ne montrer que certaines diapositives, utilisez un [Zoom de Diapositive](#Zoom-de-Diapositive).
* Pour ne montrer qu'une seule section, utilisez un [Zoom de Section](#Zoom-de-Section).

## **Zoom de Diapositive**

Un zoom de diapositive peut rendre votre présentation plus dynamique, vous permettant de naviguer librement entre les diapositives dans n'importe quel ordre de votre choix sans interrompre le flux de votre présentation. Les zooms de diapositives sont excellents pour les courtes présentations sans beaucoup de sections, mais vous pouvez également les utiliser dans différents scénarios de présentation.

Les zooms de diapositives vous aident à approfondir plusieurs morceaux d'information tout en ayant l'impression d'être sur une toile unique. 

![zoom_diapositive](slidezoomsel.png)

Pour les objets de zoom de diapositive, Aspose.Slides fournit l'énumération [ZoomImageType](https://reference.aspose.com/slides/python-net/aspose.slides/zoomimagetype/), l'interface [IZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/izoomframe/) et quelques méthodes de l'interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création de Cadres de Zoom**
Vous pouvez ajouter un cadre de zoom sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives auxquelles vous souhaitez vous lier. 
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) dans la première diapositive.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code exemple vous montre comment créer un cadre de zoom dans une diapositive :
```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoutez de nouvelles diapositives à la présentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Créez un arrière-plan pour la deuxième diapositive
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Créez une zone de texte pour la deuxième diapositive
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Deuxième Diapositive"

    # Créez un arrière-plan pour la troisième diapositive
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Créez une zone de texte pour la troisième diapositive
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Troisième Diapositive"

    #Ajoutez des objets ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Enregistrez la présentation
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Création de Cadres de Zoom avec des Images Personnalisées**
Avec Aspose.Slides pour Python via .NET, vous pouvez créer un cadre de zoom avec une image autre que l'image d'aperçu de la diapositive de cette manière : 
1. Créez une instance de la classe `Presentation`.
2. Créez une nouvelle diapositive à laquelle vous souhaitez vous lier. 
3. Ajoutez un texte d'identification et un arrière-plan à la diapositive créée.
4. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l'objet Presentation qui sera utilisée pour remplir le cadre.
5. Ajoutez des cadres de zoom (contenant la référence à la diapositive créée) dans la première diapositive.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom avec une image différente :

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoutez une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Créez un arrière-plan pour la deuxième diapositive
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Créez une zone de texte pour la troisième diapositive
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Deuxième Diapositive"

    # Créez une nouvelle image pour l'objet zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #Ajoutez l'objet ZoomFrame
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Enregistrez la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatage des Cadres de Zoom**
Dans les sections précédentes (au-dessus), nous vous avons montré comment créer des cadres de zoom simples. Pour créer des cadres de zoom plus compliqués, vous devez modifier le formatage des cadres. Il existe plusieurs paramètres de formatage que vous pouvez appliquer à un cadre de zoom. 

Vous pouvez contrôler le formatage d'un cadre de zoom dans une diapositive de cette manière :

1. Créez une instance de la classe `Presentation`.
2. Créez de nouvelles diapositives à lier.
3. Ajoutez un texte d'identification et un arrière-plan aux diapositives créées.
4. Ajoutez des cadres de zoom (contenant les références aux diapositives créées) dans la première diapositive.
5. Créez un objet [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) en ajoutant une image à la collection Images associée à l'objet Presentation qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour le premier objet de cadre de zoom.
7. Changez le format de ligne pour le deuxième objet de cadre de zoom.
8. Supprimez l'arrière-plan d'une image de l'objet de cadre de zoom.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python d'exemple vous montre comment changer le formatage d'un cadre de zoom : 

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoutez de nouvelles diapositives à la présentation
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Créez un arrière-plan pour la deuxième diapositive
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Créez une zone de texte pour la deuxième diapositive
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Deuxième Diapositive"

    # Créez un arrière-plan pour la troisième diapositive
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Créez une zone de texte pour la troisième diapositive
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Troisième Diapositive"

    #Ajoutez des objets ZoomFrame
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Créez une nouvelle image pour l'objet zoom
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Définissez une image personnalisée pour l'objet zoomFrame1
    zoomFrame1.image = image

    # Définissez un format de cadre de zoom pour l'objet zoomFrame2
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Ne pas afficher l'arrière-plan pour l'objet zoomFrame2
    zoomFrame2.show_background = False

    # Enregistrez la présentation
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```

## **Zoom de Section**

Un zoom de section est un lien vers une section de votre présentation. Vous pouvez utiliser les zooms de section pour revenir aux sections que vous souhaitez vraiment mettre en avant. Ou vous pouvez les utiliser pour souligner comment certaines parties de votre présentation se connectent. 

![zoom_section](seczoomsel.png)

Pour les objets de zoom de section, Aspose.Slides fournit l'interface [ISectionZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isectionzoomframe/) et certaines méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création de Cadres de Zoom de Section**

Vous pouvez ajouter un cadre de zoom de section à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive. 
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom sur une diapositive :

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

### **Création de Cadres de Zoom de Section avec des Images Personnalisées**

En utilisant Aspose.Slides pour Python, vous pouvez créer un cadre de zoom de section avec une image d'aperçu de diapositive différente de cette manière : 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Créez un objet `IPPImage` en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
6. Ajoutez un cadre de zoom de section (contenant une référence à la section créée) à la première diapositive.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de zoom avec une image différente :

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

### **Formatage des Cadres de Zoom de Section**

Pour créer des cadres de zoom de section plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un cadre de zoom de section. 

Vous pouvez contrôler le formatage d'un cadre de zoom de section sur une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez une nouvelle diapositive.
3. Ajoutez un arrière-plan d'identification à la diapositive créée.
4. Créez une nouvelle section à laquelle vous souhaitez lier le cadre de zoom. 
5. Ajoutez un cadre de zoom de section (contenant des références à la section créée) à la première diapositive.
6. Changez la taille et la position de l'objet de zoom de section créé.
7. Créez un objet `IPPImage` en ajoutant une image à la collection Images associée à l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisé pour remplir le cadre.
8. Définissez une image personnalisée pour l'objet de cadre de zoom de section créé.
9. Définissez la possibilité de *retourner à la diapositive d'origine depuis la section liée*. 
10. Supprimez l'arrière-plan d'une image de l'objet de cadre de zoom de section.
11. Changez le format de ligne pour le deuxième objet de cadre de zoom.
12. Changez la durée de la transition.
13. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment changer le formatage d'un cadre de zoom de section :

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle Section à la présentation
    pres.sections.add_section("Section 1", slide)

    # Ajoute un objet SectionZoomFrame
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Formatage pour SectionZoomFrame
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

## **Résumé de Zoom**

Un résumé de zoom est comme une page d'accueil où toutes les pièces de votre présentation sont affichées à la fois. Lorsque vous présentez, vous pouvez utiliser le zoom pour passer d'un endroit de votre présentation à un autre dans l'ordre de votre choix. Vous pouvez faire preuve de créativité, avancer, ou revisiter des morceaux de votre diaporama sans interrompre le flux de votre présentation.

![image_apercu](summaryzoom.png)

Pour les objets de résumé de zoom, Aspose.Slides fournit les interfaces [ISummaryZoomFrame](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomframe/), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/) et [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) ainsi que quelques méthodes sous l'interface [IShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/).

### **Création de Résumé de Zoom**

Vous pouvez ajouter un cadre de résumé de zoom à une diapositive de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez le cadre de résumé de zoom à la première diapositive.
4. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment créer un cadre de résumé de zoom sur une diapositive :

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Créez un tableau de diapositives
    for slideNumber in range(5):
        #Ajoutez de nouvelles diapositives à la présentation
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Créez un arrière-plan pour la diapositive
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Créez une zone de texte pour la diapositive
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Diapositive - {num}".format(num = (slideNumber + 2))

    # Créez des objets zoom pour toutes les diapositives dans la première diapositive
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # Définissez la propriété ReturnToParent pour revenir à la première diapositive
        zoomFrame.return_to_parent = True

    # Enregistrez la présentation
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajout et Suppression de Sections de Résumé de Zoom**

Toutes les sections dans un cadre de résumé de zoom sont représentées par des objets [ISummaryZoomFrameSection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsection/), qui sont stockés dans l'objet [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/). Vous pouvez ajouter ou supprimer un objet de section de résumé de zoom à travers l'interface [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/python-net/aspose.slides/isummaryzoomsectioncollection/) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé de zoom dans la première diapositive.
4. Ajoutez une nouvelle diapositive et section à la présentation.
5. Ajoutez la section créée au cadre de résumé de zoom.
6. Supprimez la première section du cadre de résumé de zoom.
7. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment ajouter et supprimer des sections dans un cadre de résumé de zoom :

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

    #Ajoute un objet SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Ajoute une nouvelle diapositive à la présentation
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Ajoute une nouvelle section à la présentation
    section3 = pres.sections.add_section("Section 3", slide)

    # Ajoute une section au Zoom de Résumé
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Supprime la section du Zoom de Résumé
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Enregistre la présentation
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

### **Formatage des Sections de Résumé de Zoom**

Pour créer des objets de section de résumé de zoom plus compliqués, vous devez modifier le formatage d'un cadre simple. Il existe plusieurs options de formatage que vous pouvez appliquer à un objet de section de résumé de zoom. 

Vous pouvez contrôler le formatage d'un objet de section de résumé de zoom dans un cadre de résumé de zoom de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Créez de nouvelles diapositives avec un arrière-plan d'identification et de nouvelles sections pour les diapositives créées.
3. Ajoutez un cadre de résumé de zoom à la première diapositive.
4. Obtenez un objet de section de résumé de zoom pour le premier objet de la `ISummaryZoomSectionCollection`.
5. Créez un objet `IPPImage` en ajoutant une image à la collection d'images associée à l'objet [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui sera utilisée pour remplir le cadre.
6. Définissez une image personnalisée pour l'objet de cadre de section de résumé de zoom créé.
7. Définissez la possibilité de *retourner à la diapositive d'origine depuis la section liée*. 
8. Changez le format de ligne pour le deuxième objet de cadre de zoom.
9. Changez la durée de la transition.
10. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Python vous montre comment changer le formatage pour un objet de section de résumé de zoom :

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

    #Ajoute un objet SummaryZoomFrame
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Obtient le premier objet SummaryZoomSection
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formatage pour l'objet SummaryZoomSection
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