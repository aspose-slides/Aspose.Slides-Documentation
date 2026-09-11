---
title: Gestion des contrôles ActiveX dans les présentations avec Python
linktitle: ActiveX
type: docs
weight: 80
url: /fr/python-java/activex/
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
description: "Découvrez comment Aspose.Slides for Python via Java utilise ActiveX pour automatiser et améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---
## **Introduction**

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides for Python via Java vous permet d'ajouter et de gérer des contrôles ActiveX, mais ils sont un peu plus difficiles à gérer comparés aux formes normales des présentations. Aspose.Slides prend en charge l'ajout de contrôles ActiveX Media Player. Notez que les contrôles ActiveX ne sont pas des formes; ils ne font pas partie du [ShapeCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/) de la présentation. Ils font partie du [ControlCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/controlcollection/) distinct. Dans cet article, nous vous montrerons comment les utiliser.

## **Ajouter un contrôle ActiveX Media Player à une diapositive**

Pour ajouter un contrôle ActiveX Media Player, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et générez une présentation vide.
1. Accédez à la diapositive cible dans [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Ajoutez le contrôle ActiveX Media Player à l’aide de la méthode [addControl](https://reference.aspose.com/slides/fr/python-java/aspose.slides/controlcollection/#addControl) exposée par [ControlCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/controlcollection/).
1. Accédez au contrôle ActiveX Media Player et définissez le chemin vidéo en utilisant ses propriétés.
1. Enregistrez la présentation au format PPTX.

Ce code d'exemple, basé sur les étapes ci‑dessus, montre comment ajouter un contrôle ActiveX Media Player à une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Créer une présentation vide.
presentation = Presentation()
try:
    # Ajouter le contrôle ActiveX Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Définir le chemin de la vidéo.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Enregistrer la présentation.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modifier un contrôle ActiveX**

{{% alert color="info" title="Remarque" %}}
Aspose.Slides for Python via Java fournit des composants pour gérer les contrôles ActiveX. Vous pouvez accéder au contrôle ActiveX déjà ajouté dans votre présentation et le modifier ou le supprimer via ses propriétés.
{{% /alert %}}

Pour gérer un contrôle ActiveX simple comme une zone de texte et un bouton de commande simple sur une diapositive, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant des contrôles ActiveX.
1. Obtenez une référence à la diapositive par son indice.
1. Accédez aux contrôles ActiveX de la diapositive en accédant au [ControlCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/controlcollection/).
1. Accédez au contrôle ActiveX TextBox1 à l’aide de l’objet [Control](https://reference.aspose.com/slides/fr/python-java/aspose.slides/control/).
1. Modifiez les propriétés du contrôle ActiveX TextBox1, notamment le texte, la police, la hauteur de police et la position du cadre.
1. Accédez au second contrôle ActiveX nommé CommandButton1.
1. Modifiez le libellé du bouton, la police et la position.
1. Déplacez la position des cadres des contrôles ActiveX.
1. Enregistrez la présentation modifiée au format PPTM.

Ce code d'exemple, basé sur les étapes ci‑dessus, montre comment gérer un contrôle ActiveX simple :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Charger la présentation avec des contrôles ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Accéder à la première diapositive.
        slide = presentation.getSlides().get_Item(0)

        # Modifier le texte de la zone de texte.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Modifier l'image de substitution. PowerPoint la remplace lors de l'activation d'ActiveX,
            # ce qui peut parfois rester inchangé.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Modifier le libellé du bouton.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Modifier l'image de substitution.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Déplacer les contrôles vers le bas de 100 points.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Supprimer les contrôles.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides conserve-t-il les contrôles ActiveX lors de la lecture et de la ré‑enregistrement s’ils ne peuvent pas être exécutés dans l'environnement Python ?**

Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et leurs cadres ; il n'est pas nécessaire d'exécuter les contrôles eux‑mêmes pour les conserver.

**En quoi les contrôles ActiveX diffèrent-ils des objets OLE dans une présentation ?**

Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/python-java/manage-ole/) désigne des objets d'application intégrés (par exemple, une feuille de calcul Excel). Ils sont stockés et traités différemment et possèdent des modèles de propriétés différents.

**Les événements ActiveX et les macros VBA fonctionnent-ils si le fichier a été modifié par Aspose.Slides ?**

Aspose.Slides conserve le balisage et les métadonnées existants ; toutefois, les événements et les macros ne s'exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n'exécute pas le VBA.