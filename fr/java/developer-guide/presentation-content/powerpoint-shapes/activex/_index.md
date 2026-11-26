---
title: Gérer les contrôles ActiveX dans les présentations en Java
linktitle: ActiveX
type: docs
weight: 80
url: /fr/java/activex/
keywords:
- ActiveX
- Contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Modifier les zones de texte et les boutons ActiveX, mettre à jour les aperçus des contrôles, et réutiliser un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides for Java."
---
## **Introduction**

Les contrôles ActiveX donnent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédia. Aspose.Slides for Java expose les contrôles d’une diapositive via [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **Liste des contrôles ActiveX et de leurs propriétés stockées**

Pour inspecter un modèle inconnu, ouvrez-le en lecture et parcourez les contrôles de chaque diapositive. L'exemple indique le numéro de la diapositive, le nom du contrôle, [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--), et chaque paire clé-valeur dans [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--). Il lit la présentation sans activer les contrôles, déclencher des événements ou des macros, modifier des valeurs ou enregistrer le fichier.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

La sortie sélectionnée de `ActiveX.pptm` montre une zone de texte et un bouton de commande.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent un stockage binaire, [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) peut renvoyer `null`, affiché comme `Properties unavailable`. Si vous ne avez besoin que des noms, utilisez [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) après la vérification de null. Le rapport répertorie les propriétés disponibles dans la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires à l'exécution.

## **Modifier les contrôles ActiveX**

L'exemple attend une présentation avec macros contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) pour modifier la valeur de la zone de texte et le texte du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l'activation. Fournissez un PNG pour chaque contrôle montrant son texte et son apparence mis à jour. L'exemple attribue ces images via [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--).

L'exemple déplace chaque contrôle de la première diapositive vers le bas de 100 points en définissant son cadre avec [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). Il enregistre la présentation modifiée au format PPTM, puis utilise [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) pour enregistrer une seconde copie avec tous les contrôles ActiveX supprimés de cette diapositive.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Ajouter un contrôle ActiveX Media Player**

Pour réutiliser un contrôle Windows Media Player configuré, partez d’un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) copie la diapositive entière dans une nouvelle présentation. L'exemple définit l'`URL` du lecteur dans sa [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) et enregistre la diapositive clonée comme unique diapositive du résultat. La vidéo reste externe, choisissez donc un chemin accessible au lecteur pendant la lecture.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");
        
        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **FAQ**

**Aspose.Slides peut-il conserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, y compris leurs propriétés et positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent-ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [OLE object](/slides/fr/java/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront-ils toujours les macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation dans un format activé pour les macros tel que PPTM afin de conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité autorisent à la fois les contrôles ActiveX et les macros.