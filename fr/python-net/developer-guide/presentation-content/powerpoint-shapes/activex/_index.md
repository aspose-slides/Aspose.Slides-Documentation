---
title: Gérer les contrôles ActiveX dans les présentations avec Python
linktitle: ActiveX
type: docs
weight: 80
url: /fr/python-net/activex/
keywords:
- ActiveX
- contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Python via .NET exploite ActiveX pour automatiser et améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides for Python via .NET vous permet de gérer les contrôles ActiveX, mais leur gestion est un peu plus délicate et différente des formes classiques des présentations. À partir d'Aspose.Slides for Python via .NET 6.9.0, le composant prend en charge la gestion des contrôles ActiveX. Pour l’instant, vous pouvez accéder aux contrôles ActiveX déjà ajoutés dans votre présentation et les modifier ou les supprimer en utilisant leurs différentes propriétés. Rappelez vous, les contrôles ActiveX ne sont pas des formes et ne font pas partie de IShapeCollection de la présentation, mais du IControlCollection séparé. Cet article montre comment les utiliser.
## **Modifier les contrôles ActiveX**
1. Créez une instance de la classe Presentation et chargez la présentation contenant des contrôles ActiveX.  
2. Obtenez une référence à la diapositive par son indice.  
3. Accédez aux contrôles ActiveX de la diapositive en accédant à IControlCollection.  
4. Accédez au contrôle ActiveX TextBox1 en utilisant l’objet ControlEx.  
5. Modifiez les différentes propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de police et la position du cadre.  
6. Accédez au deuxième contrôle d’accès nommé CommandButton1.  
7. Modifiez la légende du bouton, la police et la position.  
8. Déplacez la position des cadres des contrôles ActiveX.  
9. Enregistrez la présentation modifiée dans un fichier PPTX.  

L'extrait de code ci-dessous met à jour les contrôles ActiveX des diapositives de la présentation comme illustré ci-dessous.
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Accès à la présentation avec des contrôles ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Accès à la première diapositive de la présentation
    slide = presentation.slides[0]

    # modification du texte de la zone de texte
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # modification de l'image de substitution. PowerPoint remplacera cette image lors de l'activation ActiveX, donc il est parfois acceptable de laisser l'image inchangée.

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

    # modification de la légende du bouton
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # modification de la substitution
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
    
    # Déplacement des cadres ActiveX de 100 points vers le bas
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

    # Enregistrement de la présentation avec les contrôles ActiveX modifiés
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Suppression des contrôles
    slide.controls.clear()

    # Enregistrement de la présentation avec les contrôles ActiveX supprimés
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **Ajouter le contrôle ActiveX Media Player**
1. Créez une instance de la classe Presentation et chargez la présentation d'exemple contenant des contrôles ActiveX Media Player.  
2. Créez une instance de la classe Presentation cible et générez une instance de présentation vide.  
3. Clonez la diapositive contenant le contrôle ActiveX Media Player de la présentation modèle vers la présentation cible.  
4. Accédez à la diapositive clonée dans la présentation cible.  
5. Accédez aux contrôles ActiveX de la diapositive en accédant à IControlCollection.  
6. Accédez au contrôle ActiveX Media Player et définissez le chemin vidéo en utilisant ses propriétés.  
7. Enregistrez la présentation dans un fichier PPTX.  
```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente le fichier PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Créer une instance de présentation vide
    with slides.Presentation() as newPresentation:

        # Supprimer la diapositive par défaut
        newPresentation.slides.remove_at(0)

        # Cloner la diapositive avec le contrôle ActiveX Media Player
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Accéder au contrôle ActiveX Media Player et définir le chemin vidéo
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Enregistrer la présentation
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Aspose.Slides conserve-t-il les contrôles ActiveX lors de la lecture et du réenregistrement s'ils ne peuvent pas être exécutés dans l'environnement Python ?**  
Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et leurs cadres ; il n’est pas nécessaire d’exécuter les contrôles eux‑mêmes pour les conserver.

**Comment les contrôles ActiveX diffèrent-ils des objets OLE dans une présentation ?**  
Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/python-net/manage-ole/) désigne des objets d’application intégrés (par exemple, une feuille de calcul Excel). Ils sont stockés et traités différemment et possèdent des modèles de propriétés distincts.

**Les événements ActiveX et les macros VBA fonctionnent‑ils si le fichier a été modifié par Aspose.Slides ?**  
Aspose.Slides conserve le balisage et les métadonnées existants ; cependant, les événements et les macros ne s’exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n’exécute pas VBA.