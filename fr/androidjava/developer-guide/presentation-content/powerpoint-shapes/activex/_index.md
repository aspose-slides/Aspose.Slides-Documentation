---
title: ActiveX
type: docs
weight: 80
url: /androidjava/activex/
---


{{% alert color="primary" %}} 

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides pour Android via Java vous permet d'ajouter et de gérer des contrôles ActiveX, mais ils sont un peu plus difficiles à gérer par rapport aux formes de présentation normales. Nous avons implémenté le support pour l'ajout du contrôle ActiveX Media Player dans Aspose.Slides. Notez que les contrôles ActiveX ne sont pas des formes ; ils ne font pas partie de la [IShapeCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IShapeCollection) de la présentation. Ils font plutôt partie de la [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection) séparée. Dans ce sujet, nous allons vous montrer comment travailler avec eux.

{{% /alert %}} 

## **Ajouter un contrôle ActiveX Media Player à une diapositive**
Pour ajouter un contrôle ActiveX Media Player, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et générez une instance de présentation vide.
1. Accédez à la diapositive cible dans [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Ajoutez le contrôle ActiveX Media Player en utilisant la méthode [addControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) exposée par [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Accédez au contrôle ActiveX Media Player et définissez le chemin de la vidéo en utilisant ses propriétés.
1. Sauvegardez la présentation en tant que fichier PPTX.

Ce code d'exemple, basé sur les étapes ci-dessus, montre comment ajouter un contrôle ActiveX Media Player à une diapositive :

```java
// Créer une instance de présentation vide
Presentation pres = new Presentation();
try {
    // Ajout du contrôle ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Accéder au contrôle ActiveX Media Player et définir le chemin de la vidéo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Sauvegarder la présentation
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modifier un contrôle ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides pour Android via Java 7.1.0 et les versions plus récentes sont équipées de composants pour gérer les contrôles ActiveX. Vous pouvez accéder au contrôle ActiveX déjà ajouté dans votre présentation et le modifier ou le supprimer par le biais de ses propriétés.

{{% /alert %}} 

Pour gérer un simple contrôle ActiveX comme une zone de texte et un bouton de commande simple sur une diapositive, procédez comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) et chargez la présentation avec des contrôles ActiveX.
1. Obtenez une référence à la diapositive par son index.
1. Accédez aux contrôles ActiveX dans la diapositive en accédant à [IControlCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControlCollection).
1. Accédez au contrôle ActiveX TextBox1 en utilisant l'objet [IControl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IControl).
1. Modifiez les propriétés du contrôle ActiveX TextBox1, y compris le texte, la police, la hauteur de la police et la position du cadre.
1. Accédez au deuxième contrôle d'accès appelé CommandButton1.
1. Modifiez la légende du bouton, la police et la position.
1. Déplacez la position des cadres des contrôles ActiveX.
1. Écrivez la présentation modifiée dans un fichier PPTX.

Ce code d'exemple, basé sur les étapes ci-dessus, montre comment gérer un simple contrôle ActiveX : 

```java
// Accéder à la présentation avec les contrôles ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Accéder à la première diapositive de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // changer le texte de TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Texte modifié";
        control.getProperties().set_Item("Value", newText);

        // Changer l'image de substitution. PowerPoint remplacera cette image lors de l'activation d'ActiveX,
        // donc il est parfois acceptable de laisser l'image inchangée.
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

    // Changement de la légende du bouton
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Afficher MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Changement de la substitution
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

            // décaler 100 points vers le bas
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // supprimer les contrôles
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```