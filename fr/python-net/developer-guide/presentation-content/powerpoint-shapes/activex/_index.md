---
title: ActiveX
type: docs
weight: 80
url: /fr/python-net/activex/
keywords: "ActiveX, contrôles ActiveX, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Gérer les contrôles ActiveX dans une présentation PowerPoint en Python"
---

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour Python via .NET vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente des formes de présentation normales. À partir de Aspose.Slides pour Python via .NET 6.9.0, le composant prend en charge la gestion des contrôles ActiveX. Pour le moment, vous pouvez accéder aux contrôles ActiveX déjà ajoutés dans votre présentation et les modifier ou les supprimer en utilisant leurs différentes propriétés. N'oubliez pas que les contrôles ActiveX ne sont pas des formes et ne font pas partie de l'IShapeCollection de la présentation, mais de la collection distincte IControlCollection. Cet article montre comment travailler avec eux.
## **Modifier les contrôles ActiveX**
Pour gérer un simple contrôle ActiveX comme une zone de texte et un bouton de commande simple sur une diapositive :

1. Créez une instance de la classe Presentation et chargez la présentation avec les contrôles ActiveX.
1. Obtenez une référence à la diapositive par son index.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à l'IControlCollection.
1. Accédez au contrôle ActiveX TextBox1 en utilisant l'objet ControlEx.
1. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de la police et la position du cadre.
1. Accédez au deuxième contrôle d'accès appelé CommandButton1.
1. Changez la légende du bouton, la police et la position.
1. Déplacez la position des cadres des contrôles ActiveX.
1. Écrivez la présentation modifiée dans un fichier PPTX.

L'extrait de code ci-dessous met à jour les contrôles ActiveX sur les diapositives de présentation comme indiqué ci-dessous.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accès à la présentation avec les contrôles ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accéder à la première diapositive de la présentation
    slide = presentation.slides[0]

    # changer le texte de la TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Texte modifié"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # changer l'image de substitution. PowerPoint remplacera cette image lors de l'activation d'ActiveX, donc parfois il est acceptable de laisser l'image inchangée.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # changer la légende du bouton
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # changer l'image de substitution
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Déplacer les cadres ActiveX de 100 points vers le bas
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Enregistrer la présentation avec les contrôles ActiveX modifiés
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Maintenant, supprimer les contrôles
    slide.controls.clear()

    # Enregistrement de la présentation avec les contrôles ActiveX supprimés
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Ajouter un contrôle ActiveX lecteur multimédia**
Pour ajouter un contrôle ActiveX lecteur multimédia, veuillez effectuer les étapes suivantes :

1. Créez une instance de la classe Presentation et chargez la présentation d'exemple contenant des contrôles ActiveX lecteur multimédia.
1. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.
1. Clonez la diapositive avec le contrôle ActiveX lecteur multimédia dans la présentation modèle vers la présentation cible.
1. Accédez à la diapositive clonée dans la présentation cible.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à l'IControlCollection.
1. Accédez au contrôle ActiveX lecteur multimédia et définissez le chemin de la vidéo en utilisant ses propriétés.
1. Enregistrez la présentation dans un fichier PPTX.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Créer une instance de présentation vide
    with slides.Presentation() as newPresentation:

        # Supprimer la diapositive par défaut
        newPresentation.slides.remove_at(0)

        # Cloner la diapositive avec le contrôle ActiveX lecteur multimédia
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Accéder au contrôle ActiveX lecteur multimédia et définir le chemin de la vidéo
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Enregistrer la présentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```