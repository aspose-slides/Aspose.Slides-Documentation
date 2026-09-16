---
title: Gérer les hyperliens de présentation en JavaScript
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/nodejs-java/manage-hyperlinks/
keywords:
- ajouter URL
- ajouter hyperlien
- créer hyperlien
- formater hyperlien
- supprimer hyperlien
- mettre à jour hyperlien
- hyperlien texte
- hyperlien diapositive
- hyperlien forme
- hyperlien image
- hyperlien vidéo
- hyperlien modifiable
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajouter, formater, mettre à jour et supprimer des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java, à l’aide d’exemples JavaScript."
---
## **Introduction**

Un hyperlien relie le contenu d'une présentation à un site web ou à un emplacement au sein de la présentation. Dans PowerPoint, les hyperliens servent généralement deux objectifs :

* Ouvrir un site web à partir d’un texte, d’une forme ou d’un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for Node.js via Java vous permet d’ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Note" %}}
Vous pouvez également modifier des présentations avec l'[éditeur en ligne gratuit Aspose PowerPoint](https://products.aspose.app/slides/fr/editor).
{{% /alert %}} 

## **Ajouter des hyperliens URL**

Vous pouvez attribuer une URL de site web à du texte, à une forme ou à un cadre multimédia. L’élément auquel vous attribuez l’hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu’une forme ou un cadre lie l’objet de la diapositive.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site web, transmettez un [Hyperlink](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink) à la méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) de la portion de texte, comme indiqué ci‑dessous. Seule cette portion de texte devient cliquable.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ajouter des hyperliens URL aux formes et aux cadres multimédia**

Pour rendre une forme ou un cadre cliquable, appelez sa méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#setHyperlinkClick). L’hyperlien appartient à l’objet lui‑même plutôt qu’à une portion de texte à l’intérieur.

La même approche s’applique aux cadres d’image, d’audio et de vidéo : attribuez l’hyperlien au cadre et appelez [setTooltip](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setTooltip) si nécessaire.

L’exemple suivant rend un rectangle cliquable :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d’une table des matières à une diapositive spécifique. L’exemple suivant utilise [setInternalHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formater les hyperliens**

### **Couleur**

La méthode [setColorSource](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setColorSource) de [Hyperlink](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink) détermine si un hyperlien utilise la couleur d’hyperlien de la présentation ou le formatage de la portion de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkColorSource) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n’appliquent pas ce paramètre.

L’exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage de texte rouge, tandis que le second conserve la couleur d’hyperlien par défaut.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Son**

Un hyperlien peut jouer un son lorsqu’il est activé ou arrêter un son déjà en cours de lecture. Utilisez les méthodes suivantes pour configurer ces comportements :

- [Hyperlink.setSound](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setSound) spécifie l’audio associé à l’hyperlien.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) contrôle si l’activation de l’hyperlien arrête le son précédent.

#### **Ajouter un son d’hyperlien**

L’exemple suivant charge `sampleaudio.wav` et l’associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et navigue vers la diapositive suivante. Une seconde forme sur cette diapositive arrête le son précédent lorsqu’on clique dessus, sans effectuer d’action de navigation.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extraire le son d’un hyperlien**

L’exemple suivant ouvre la présentation créée ci‑dessus et lit l’audio de l’hyperlien de la première forme en mémoire via [getSound](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getSound) et [getBinaryData](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Infobulle et paramètres d’interaction**

Vous pouvez appeler les méthodes [Hyperlink](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink) suivantes après avoir attribué un hyperlien à du texte ou à une forme :

- [setTooltip](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setTooltip) définit le texte qu’un visualiseur peut afficher comme indice pour le lien.
- [setTargetFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) spécifie le cadre cible au sein d’un frameset HTML parent, le cas échéant.
- [setHistory](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setHistory) contrôle si l’activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [setHighlightClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) contrôle si l’hyperlien est mis en évidence lorsqu’on clique dessus.

## **Supprimer les hyperliens des présentations**

Utilisez [getAnyHyperlinks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) pour collecter les conteneurs d’hyperliens, y compris les liens de portions de texte, avant de les modifier. L’exemple suivant supprime les deux types d’activation de la première diapositive. Pour ne supprimer qu’un seul type, appelez uniquement [removeHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver) ; la suppression d’une action de clic n’élimine pas son pendant‑sur‑le‑souris correspondant.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Pour une suppression inconditionnelle, [removeAllHyperlinks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) supprime les deux types d’activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif et une couverture des masques, des dispositions et des notes, consultez [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Construire un inventaire complet des hyperliens**

Avant de distribuer une présentation, recensez ses actions interactives ainsi que ses liens web. [getAnyHyperlinks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) renvoie des conteneurs d’hyperliens, pas une liste plate de chaînes URL. Examinez à la fois [getHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getHyperlinkClick) et [getHyperlinkMouseOver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, ainsi un rapport complet peut nécessiter jusqu’à deux lignes par conteneur.

Analyser uniquement les hyperliens au niveau des formes peut manquer les liens attachés aux portions de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Interroger les portées Présentation, Diapositive et Cadre de texte**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries) est accessible via [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) et [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Chaque portée supporte les mêmes requêtes :

- [getHyperlinkClicks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) renvoie les conteneurs avec une action de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) renvoie les conteneurs avec une action de survol.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) renvoie les conteneurs avec l’une ou les deux actions.

L’exemple suivant crée `hyperlink-audit-input.pptx` avec un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de texte survolé et une action macro. Il n’exécute aucune de ces actions. Les mêmes trois requêtes fonctionnent à chaque portée ; les comptes décrivent les conteneurs, pas le total des actions. La portée du cadre de texte exclut les propres liens de la forme englobante.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs avec l’une ou l’autre action. La requête du cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classer les actions et les destinations**

Utilisez [Hyperlink.getActionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getActionType) pour interpréter une action avant d’interpréter sa destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkActionType) couvrent plus que la navigation web :

| Valeurs | Signification pour un audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; inspectez l’URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive particulière. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation de diaporama intégrée, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Terminer le diaporama actuel ou démarrer un diaporama personnalisé. |
| `StartMacro` | Exécuter une macro. |
| `StartProgram` | Lancer un programme. |
| `OpenFile`, `OpenPresentation` | Ouvrir un fichier ou une autre présentation ; à examiner séparément des URL web. |
| `StartStopMedia` | Démarrer ou arrêter la lecture multimédia. |
| `NoAction`, `Unknown` | Aucune action de navigation, ou une action non reconnue nécessitant un examen. |

Lisez les destinations externes à partir de [getExternalUrl](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) et les destinations internes spécifiques à partir de [getTargetSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Les actions internes et les commandes intégrées peuvent ne pas avoir d’URL externe ; une URL vide ne signifie pas que le conteneur n’a aucune action. Conservez la valeur renvoyée par [getExternalUrlOriginal](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) lorsqu’elle diffère de l’URL normalisée, et incluez l’infobulle renvoyée par [getTooltip](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Hyperlink#getTooltip) lorsqu’elle est disponible.

### **Rapporter, assainir et vérifier les hyperliens**

L’exemple JavaScript suivant lit une présentation existante (utilisez le fichier créé ci‑dessus), écrit `hyperlink-audit.json`, applique une politique, sauvegarde `hyperlink-sanitized.pptx` et la rouvre pour vérifier à nouveau les deux types d’activation. Il collecte les conteneurs avant de les modifier et utilise l’égalité de référence pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l’échelle du package, il interroge également explicitement les masques, les dispositions, les notes et les masques de notes et de documents d’accompagnement lorsqu’ils sont présents.

Le rapport enregistre un index de diapositive basé sur 1 et [getSlideId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/BaseSlide#getSlideId) lorsqu’il est disponible. [getSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getSlide) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les masques, dispositions et notes n’ont pas d’index de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de formatage de portion de texte sont étiquetés séparément ; les autres types de conteneurs conservent leur nom de type à l’exécution. Chaque conteneur reçoit un ID local au rapport afin que ses deux actions puissent être corrélées. Le rapport stocke les types d’actions sous forme de constantes entières définies par l’énumération HyperlinkActionType.

Cette politique d’application délibérément restrictive autorise uniquement les URL HTTPS absolues et les cibles de diapositive internes valides. Elle rejette les macros, programmes, actions de fichiers, autres actions de diaporama, actions inconnues et autres schémas d’URL. Ces rejets sont des décisions de politique, pas un verdict de sécurité d’Aspose.Slides. HTTPS seul n’établit pas la confiance : ajoutez des listes blanches d’hôtes et d’autres vérifications pour votre application. Les URL externes d’origine et normalisées sont toutes deux vérifiées. L’exemple vérifie les métadonnées sans suivre les liens ni exécuter les actions.

Pour la remédiation, le [getHyperlinkManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/Shape#getHyperlinkManager) du conteneur prend en charge [setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) et [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Ici, les liens cliquables externes interdits sont remplacés par une page d’atterrissage HTTPS fixe ; les autres clics interdits et les actions de survol interdites sont supprimés indépendamment. Définissez `replaceExternalClicks` à `false` pour supprimer toutes les violations de politique. Choisissez une page de remplacement appartenant à l’application avant le déploiement.

Le drapeau d’exportation du rapport utilise une politique de révision PDF conservatrice : il signale les actions de survol et tout ce qui n’est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s’agit d’une indication de révision, pas d’un test de capacité ou d’une garantie que les liens non signalés survivront à l’exportation. Les exportations PDF et HTML prises en charge peuvent préserver les hyperliens, selon l’action, les options d’exportation et le visualiseur. Les [images](/slides/fr/nodejs-java/convert-powerpoint-to-png/) et [vidéos](/slides/fr/nodejs-java/convert-powerpoint-to-video/) raster ne peuvent pas préserver les hyperliens interactifs ; signalez chaque action lors de l’audit pour ces sorties.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Avec l’entrée créée ci‑dessus, le rapport contient cinq lignes d’action. Le lien de survol de fichier et le clic macro sont supprimés, tandis que les liens HTTPS et la navigation interne de diapositive restent. La vérification indique zéro action interdite. Une entrée contenant une URL de clic externe interdite exerce également la branche de remplacement. Un conteneur avec un clic autorisé et un survol interdit conserve son action de clic.

Ce nettoyage sélectif diffère de [removeAllHyperlinks](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), qui supprime les deux types d’activation dans toute la portée sélectionnée, quelle que soit la politique. La vérification ici ne contrôle que les actions d’hyperlien ; elle ne supprime pas les projets VBA intégrés, les objets OLE ou tout autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis‑je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez‑la à la première diapositive de cette section.

**Puis‑je attacher un hyperlien aux éléments du masque de diapositive pour qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du masque de diapositive et des dispositions prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le masque ou la disposition correspondants.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Les exportations PDF et HTML prises en charge peuvent préserver les hyperliens ; les images raster et les vidéos ne le peuvent pas. Voir les considérations d’exportation dans [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).