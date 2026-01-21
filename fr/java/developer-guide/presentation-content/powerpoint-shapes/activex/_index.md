---
title: Gérer les contrôles ActiveX dans les présentations avec Java
linktitle: ActiveX
type: docs
weight: 80
url: /fr/java/activex/
keywords:
- ActiveX
- contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment Aspose.Slides for Java exploite ActiveX pour automatiser et améliorer les présentations PowerPoint, offrant aux développeurs un contrôle puissant sur les diapositives."
---

{{% alert color="primary" %}} 

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides for Java vous permet d'ajouter et de gérer les contrôles ActiveX, mais ils sont un peu plus difficiles à gérer comparés aux formes normales d'une présentation. Nous avons implémenté la prise en charge de l'ajout du contrôle Active Media Player dans Aspose.Slides. Notez que les contrôles ActiveX ne sont pas des formes ; ils ne font pas partie de la [IShapeCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/). Ils font partie de la [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/) distincte. Dans ce sujet, nous vous montrons comment travailler avec eux. 

{{% /alert %}} 

## **Ajouter un contrôle ActiveX Media Player à une diapositive**
Pour ajouter un contrôle Media Player ActiveX, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et générez une présentation vide.  
2. Accédez à la diapositive cible dans [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).  
3. Ajoutez le contrôle Media Player ActiveX en utilisant la méthode [addControl](https://reference.aspose.com/slides/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) exposée par [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).  
4. Accédez au contrôle Media Player ActiveX et définissez le chemin vidéo en utilisant ses propriétés.  
5. Enregistrez la présentation au format PPTX.  

Ce code d'exemple, basé sur les étapes ci‑dessus, montre comment ajouter le contrôle Media Player ActiveX à une diapositive :
```java
// Créer une instance de présentation vide
Presentation pres = new Presentation();
try {
    // Ajouter le contrôle ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Accéder au contrôle ActiveX Media Player et définir le chemin vidéo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Enregistrer la présentation
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Modifier un contrôle ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for Java 7.1.0 et les versions ultérieures sont équipés de composants pour gérer les contrôles ActiveX. Vous pouvez accéder au contrôle ActiveX déjà ajouté dans votre présentation et le modifier ou le supprimer via ses propriétés.

{{% /alert %}} 

Pour gérer un contrôle ActiveX simple comme une zone de texte et un bouton de commande simple sur une diapositive, procédez ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) et chargez la présentation contenant des contrôles ActiveX.  
2. Obtenez une référence à la diapositive par son index.  
3. Accédez aux contrôles ActiveX de la diapositive en accédant à la [IControlCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/).  
4. Accédez au contrôle ActiveX TextBox1 à l'aide de l'objet [IControl](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/).  
5. Modifiez les propriétés du contrôle ActiveX TextBox1, notamment le texte, la police, la hauteur de police et la position du cadre.  
6. Accédez au deuxième contrôle d'accès appelé CommandButton1.  
7. Modifiez la légende du bouton, la police et la position.  
8. Déplacez la position des cadres des contrôles ActiveX.  
9. Enregistrez la présentation modifiée au format PPTX.  

Ce code d'exemple, basé sur les étapes ci‑dessus, montre comment gérer un contrôle ActiveX simple :
```java
// Accès à la présentation avec des contrôles ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accès à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Modification du texte de la zone de texte
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Modification de l'image de substitution. PowerPoint remplacera cette image lors de l'activation ActiveX,
        // il est parfois acceptable de laisser l'image inchangée.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Modification de la légende du bouton
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Modification du substitut
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // déplacement de 100 points vers le bas
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // suppression des contrôles
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Aspose.Slides préserve-t-il les contrôles ActiveX lors de la lecture et de la réenregistrement s'ils ne peuvent pas être exécutés dans le runtime Java ?**

Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et cadres ; l'exécution des contrôles eux‑mêmes n'est pas requise pour les préserver.

**En quoi les contrôles ActiveX diffèrent-ils des objets OLE dans une présentation ?**

Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/java/manage-ole/) fait référence à des objets d'application intégrés (par exemple, une feuille de calcul Excel). Ils sont stockés et gérés différemment et possèdent des modèles de propriétés différents.

**Les événements ActiveX et les macros VBA fonctionnent-ils si le fichier a été modifié par Aspose.Slides ?**

Aspose.Slides conserve le balisage et les métadonnées existants ; cependant, les événements et les macros ne s'exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n'exécute pas de VBA.