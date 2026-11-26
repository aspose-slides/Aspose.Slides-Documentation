---
title: Gérer les contrôles ActiveX dans les présentations à l'aide de JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /fr/nodejs-java/activex/
keywords:
- ActiveX
- contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Modifiez les zones de texte et les boutons ActiveX, mettez à jour les aperçus des contrôles et réutilisez un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides pour Node.js via Java."
---
## **Introduction**

Les contrôles ActiveX offrent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédias. Aspose.Slides pour Node.js via Java expose les contrôles d’une diapositive via [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **Lister les contrôles ActiveX et leurs propriétés stockées**

Pour examiner un modèle inconnu, ouvrez‑le en lecture et parcourez les contrôles de chaque diapositive. L’exemple indique le numéro de diapositive, le nom du contrôle, [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) et chaque paire clé‑valeur dans [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties). Il lit la présentation sans activer les contrôles, sans invoquer d’événements ou de macros, sans modifier de valeurs, et sans enregistrer le fichier.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
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

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent un stockage binaire, [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) peut renvoyer `null`, affiché comme `Properties unavailable`. Si vous avez uniquement besoin des noms, utilisez [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) après la vérification du `null`. Le rapport répertorie les propriétés disponibles dans la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires au moment de l’exécution.

## **Modifier les contrôles ActiveX**

L’exemple suppose une présentation activée par macro contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [collection de propriétés du contrôle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) pour modifier la valeur de la zone de texte et la légende du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l’activation. Fournissez un PNG pour chaque contrôle montrant le texte et l’apparence mis à jour. L’exemple attribue ces images via [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat).

L’exemple déplace chaque contrôle de la première diapositive de 100 points vers le bas en définissant son cadre avec [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame). Il enregistre la présentation modifiée au format PPTM, puis utilise [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) pour sauvegarder une seconde copie sans aucun contrôle ActiveX sur cette diapositive.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```

## **Ajouter un contrôle ActiveX Media Player**

Pour réutiliser un contrôle Windows Media Player configuré, commencez avec un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) copie la diapositive entière dans une nouvelle présentation. L’exemple définit l’`URL` du lecteur dans sa [collection de propriétés](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) et enregistre la diapositive clonée comme unique diapositive du résultat. La vidéo reste externe, choisissez donc un chemin auquel le lecteur peut accéder pendant la lecture.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```

## **FAQ**

**Aspose.Slides peut‑il conserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, ainsi que leurs propriétés et positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [objet OLE](/slides/fr/nodejs-java/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront‑ils encore des macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation dans un format activé par macro tel que PPTM pour conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité autorisent à la fois les contrôles ActiveX et les macros.