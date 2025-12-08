---
title: ActiveX
type: docs
weight: 80
url: /fr/nodejs-java/activex/
---

{{% alert color="primary" %}} 

Les contrôles ActiveX sont utilisés dans les présentations. Aspose.Slides for Node.js via Java vous permet d’ajouter et de gérer des contrôles ActiveX, mais ils sont un peu plus compliqués à gérer comparés aux formes de présentation normales. Nous avons implémenté la prise en charge de l’ajout du contrôle Active Media Player dans Aspose.Slides. Notez que les contrôles ActiveX ne sont pas des formes ; ils ne font pas partie du [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) de la présentation. Ils font partie du [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/) distinct. Dans ce sujet, nous vous montrerons comment les utiliser.

{{% /alert %}} 

## **Ajout du contrôle ActiveX Media Player à la diapositive**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et générez une instance de présentation vide.  
1. Accédez à la diapositive cible dans [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).  
1. Ajoutez le contrôle ActiveX Media Player en utilisant la méthode [addControl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) exposée par [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/).  
1. Accédez au contrôle ActiveX Media Player et définissez le chemin de la vidéo en utilisant ses propriétés.  
1. Enregistrez la présentation au format PPTX.  

```javascript
// Créer une instance de présentation vide
var pres = new aspose.slides.Presentation();
try {
    // Ajouter le contrôle ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Accéder au contrôle ActiveX Media Player et définir le chemin de la vidéo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Enregistrer la présentation
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Modification du contrôle ActiveX**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) et chargez la présentation contenant des contrôles ActiveX.  
1. Obtenez une référence de diapositive par son indice.  
1. Accédez aux contrôles ActiveX de la diapositive en accédant au [ControlCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/).  
1. Accédez au contrôle ActiveX TextBox1 en utilisant l’objet [Control](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/).  
1. Modifiez les propriétés du contrôle ActiveX TextBox1, notamment le texte, la police, la hauteur de police et la position du cadre.  
1. Accédez au deuxième contrôle d’accès appelé CommandButton1.  
1. Modifiez la légende du bouton, la police et la position.  
1. Déplacez la position des cadres des contrôles ActiveX.  
1. Écrivez la présentation modifiée dans un fichier PPTX.  

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Accéder à la présentation avec des contrôles ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Accéder à la première diapositive de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Modification du texte du TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Changement de l'image de substitution. PowerPoint remplacera cette image lors de l'activation d'ActiveX,
        // donc parfois il est acceptable de laisser l'image inchangée.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Modification de la légende du bouton
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Modification du substitut
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // Déplacement de 100 points vers le bas
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // Suppression des contrôles
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Aspose.Slides préserve-t-il les contrôles ActiveX lors de la lecture et de la ré‑enregistrement s’ils ne peuvent pas être exécutés dans l’environnement d’exécution Python ?**  

Oui. Aspose.Slides les considère comme faisant partie de la présentation et peut lire/modifier leurs propriétés et leurs cadres ; l’exécution des contrôles eux‑mêmes n’est pas nécessaire pour les préserver.

**En quoi les contrôles ActiveX diffèrent-ils des objets OLE dans une présentation ?**  

Les contrôles ActiveX sont des contrôles interactifs gérés (boutons, zones de texte, lecteur multimédia), tandis que [OLE](/slides/fr/nodejs-java/manage-ole/) désigne des objets d’application incorporés (par exemple, une feuille de calcul Excel). Ils sont stockés et traités différemment et possèdent des modèles de propriétés distincts.

**Les événements ActiveX et les macros VBA fonctionnent-ils si le fichier a été modifié par Aspose.Slides ?**  

Aspose.Slides préserve le balisage et les métadonnées existants ; cependant, les événements et les macros ne s’exécutent que dans PowerPoint sous Windows lorsque la sécurité le permet. La bibliothèque n’exécute pas le VBA.