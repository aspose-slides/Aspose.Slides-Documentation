---
title: Gérer les hyperliens de présentation sur Android
linktitle: Gérer les hyperliens
type: docs
weight: 20
url: /fr/androidjava/manage-hyperlinks/
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
- hyperlien mutable
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajouter, formater, mettre à jour et supprimer des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour Android via Java, à l'aide d'exemples Java."
---
## **Introduction**

Un hyperlien relie le contenu d’une présentation à un site Web ou à un emplacement au sein de la présentation. Dans PowerPoint, les hyperliens servent généralement deux objectifs :

* Ouvrir un site Web depuis du texte, une forme ou un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for Android via Java vous permet d’ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte.

{{% alert color="info" title="Note" %}}

Vous pouvez également modifier des présentations avec l’[éditeur PowerPoint en ligne gratuit d’Aspose](https://products.aspose.app/slides/fr/editor).

{{% /alert %}} 

## **Ajouter des hyperliens URL**

Vous pouvez associer une URL de site Web à du texte, une forme ou un cadre multimédia. L’élément auquel vous attribuez l’hyperlien détermine la zone cliquable : une portion de texte lie le texte sélectionné, tandis qu’une forme ou un cadre lie l’objet de la diapositive.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site Web, transmettez un [Hyperlink](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/hyperlink/) à la méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) de la portion de texte, comme illustré ci‑dessous. Seule cette portion devient cliquable.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ajouter des hyperliens URL aux formes et aux cadres multimédia**

Pour rendre une forme ou un cadre cliquable, appelez sa méthode [setHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). L’hyperlien appartient à l’objet lui‑même plutôt qu’à une portion de texte à l’intérieur.

La même approche s’applique aux cadres image, audio et vidéo : affectez l’hyperlien au cadre et appelez [setTooltip](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) si nécessaire.

L’exemple suivant rend un rectangle cliquable :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d’une table des matières à une diapositive spécifique. L’exemple suivant utilise [setInternalHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formater les hyperliens**

### **Couleur**

La méthode [setColorSource](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) de [IHyperlink](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/) détermine si un hyperlien utilise la couleur d’hyperlien de la présentation ou le formatage de la portion de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la portion. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n’appliquent pas ce paramètre.

L’exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage texte rouge, le second conserve la couleur d’hyperlien par défaut.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Son**

Un hyperlien peut jouer un son lorsqu’il est activé ou arrêter un son déjà en cours de lecture. Utilisez les méthodes suivantes pour configurer ces comportements :

- [IHyperlink.setSound](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) indique le fichier audio associé à l’hyperlien.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) contrôle si l’activation de l’hyperlien arrête le son précédent.

#### **Ajouter un son d’hyperlien**

L’exemple suivant charge `sampleaudio.wav` et l’associe à un bouton sur la première diapositive. Cliquer sur le bouton joue le son et navigue vers la diapositive suivante. Une deuxième forme sur cette diapositive arrête le son précédent lorsqu’on clique dessus, sans effectuer d’action de navigation.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Extraire le son d’un hyperlien**

L’exemple suivant ouvre la présentation créée ci‑dessus et lit l’audio d’hyperlien de la première forme en mémoire grâce à [getSound](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getSound--) et [getBinaryData](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Infobulle et paramètres d’interaction**

Après avoir affecté un hyperlien à du texte ou à une forme, vous pouvez appeler les méthodes suivantes de [IHyperlink](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/) :

- [setTooltip](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) définit le texte qu’un affichage peut présenter comme indice pour le lien.
- [setTargetFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) indique le cadre cible au sein d’un ensemble de cadres HTML parent, le cas échéant.
- [setHistory](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) contrôle si l’activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [setHighlightClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) contrôle si l’hyperlien est mis en évidence lors du clic.

## **Supprimer les hyperliens des présentations**

Utilisez [getAnyHyperlinks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) pour collecter les conteneurs d’hyperliens, y compris les liens de portions de texte, avant de les modifier. L’exemple suivant supprime les deux types d’activation de la première diapositive. Pour ne supprimer qu’un type, appelez uniquement [removeHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); la suppression d’une action de clic n’élimine pas son pendant‑sur‑souris correspondant.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Pour une suppression inconditionnelle, [removeAllHyperlinks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) supprime les deux types d’activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif couvrant les masques, les dispositions et les notes, consultez [Rapport, assainissement et vérification des hyperliens](#report-sanitize-and-verify-hyperlinks).

## **Construire un inventaire complet des hyperliens**

Avant de diffuser une présentation, inventoriez ses actions interactives ainsi que ses liens Web. [getAnyHyperlinks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) renvoie des objets [IHyperlinkContainer](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkcontainer/), pas une liste plate de chaînes URL. Inspectez à la fois [getHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) et [getHyperlinkMouseOver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, si bien qu’un rapport complet nécessite jusqu’à deux lignes par conteneur.

Examiner uniquement les hyperliens au niveau des formes peut laisser de côté les liens attachés aux portions de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs retournés afin de pouvoir mettre à jour ou supprimer leurs actions ultérieurement.

### **Interroger les portées Présentation, Diapositive et Cadre de texte**

L’interface [IHyperlinkQueries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/) est accessible via [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), et [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Chaque portée prend en charge les mêmes requêtes :

- [getHyperlinkClicks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) renvoie les conteneurs avec une action de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) renvoie les conteneurs avec une action pendant‑sur‑souris.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) renvoie les conteneurs contenant l’une ou les deux actions.

L’exemple suivant crée `hyperlink-audit-input.pptx` avec un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de survol de texte et une action macro. Aucune de ces actions n’est exécutée. Les trois requêtes fonctionnent à chaque portée ; les comptes décrivent des conteneurs, pas le nombre total d’actions. La portée du cadre de texte exclut les liens propres à la forme qui l’enveloppe.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dans cet exemple, les requêtes de présentation et de diapositive rapportent chacune trois conteneurs de clic, deux de survol et trois contenant l’une ou l’autre des actions. La requête de cadre de texte rapporte un conteneur dans chaque catégorie.

### **Classer les actions et les destinations**

Utilisez [IHyperlink.getActionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getActionType--) pour interpréter une action avant d’en interpréter la destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/hyperlinkactiontype/) couvrent davantage que la navigation Web :

| Valeurs | Signification pour un audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; examinez l’URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive précise. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation intégrée du diaporama, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Terminer le diaporama en cours ou démarrer un diaporama personnalisé. |
| `StartMacro` | Exécuter une macro. |
| `StartProgram` | Lancer un programme. |
| `OpenFile`, `OpenPresentation` | Ouvrir un fichier ou une autre présentation ; à examiner séparément des URL Web. |
| `StartStopMedia` | Démarrer ou arrêter la lecture multimédia. |
| `NoAction`, `Unknown` | Aucun acte de navigation, ou un acte non reconnu nécessitant une révision. |

Lisez les destinations externes via [getExternalUrl](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) et les destinations internes spécifiques via [getTargetSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Les actions internes et les commandes intégrées peuvent ne pas avoir d’URL externe ; une URL vide ne signifie pas que le conteneur est dépourvu d’action. Conservez la valeur renvoyée par [getExternalUrlOriginal](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) lorsqu’elle diffère de l’URL normalisée, et incluez l’infobulle renvoyée par [getTooltip](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) lorsqu’elle est disponible.

### **Rapporter, assainir et vérifier les hyperliens**

L’exemple Java suivant lit une présentation existante (utilisez le fichier créé ci‑dessus), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et le rouvre pour vérifier à nouveau les deux types d’activation. Il collecte les conteneurs avant de les modifier et utilise l’égalité de référence pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l’échelle du paquet, il interroge également explicitement les masques, les dispositions, les notes et les masques de notes et de prospectus lorsqu’ils existent.

Le rapport enregistre un indice de diapositive basé sur 1 et [getSlideId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) lorsqu’il est disponible. [ISlideComponent.getSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/islidecomponent/#getSlide--) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les masques, les dispositions et les notes n’ont pas d’indice de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de format de portion de texte sont étiquetés séparément ; les autres types conservent leur nom de type d’exécution. Chaque conteneur reçoit un ID local au rapport afin que ses deux actions puissent être corrélées. Le rapport stocke les types d’action sous forme d’entiers définis par l’énumération Java.

Cette politique d’application délibérément restrictive n’autorise que les URL HTTPS absolues et les cibles de diapositive internes valides. Elle rejette les macros, programmes, actions de fichier, autres actions de diaporama, actions inconnues et autres schémas d’URL. Ces rejets sont des décisions de politique, pas un verdict de sécurité Aspose.Slides. HTTPS seul n’établit pas la confiance : ajoutez des listes blanches d’hôtes et d’autres vérifications propres à votre application. Les URL externes originales et normalisées sont toutes deux contrôlées. L’exemple audite les métadonnées sans suivre les liens ni exécuter d’actions.

Pour la remédiation, le [getHyperlinkManager](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager-) du conteneur prend en charge [setExternalHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) et [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Ici, les liens de clic externes interdits sont remplacés par une page d’atterrissage HTTPS fixe ; les autres clics interdits et les actions de survol sont supprimés indépendamment. Définissez `replaceExternalClicks` à `false` pour supprimer toutes les violations de politique. Choisissez une page de remplacement appartenant à votre application avant le déploiement.

Le drapeau d’exportation du rapport utilise une politique conservatrice d’examen PDF : il signale les actions de survol et tout ce qui n’est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s’agit d’une indication d’examen, pas d’un test de capacité ou d’une garantie que les liens non signalés survivront à l’exportation. Les exports PDF et HTML pris en charge ([PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/androidjava/convert-powerpoint-to-html/)) peuvent conserver les hyperliens, selon l’action, les options d’export et le visualiseur. Les [images](/slides/fr/androidjava/convert-powerpoint-to-png/) raster et les [vidéos](/slides/fr/androidjava/convert-powerpoint-to-video/) ne peuvent pas conserver les hyperliens interactifs ; signalez chaque action lors d’un audit destiné à ces sorties.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Sérialiser les lignes plates de ce rapport sans dépendance JSON supplémentaire.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Avec l’entrée créée ci‑dessus, le rapport contient cinq lignes d’action. Le lien de survol de fichier et la macro de clic sont supprimés, tandis que les liens HTTPS et la navigation interne restent. La vérification affiche zéro action prohibée. Une entrée contenant une URL de clic externe prohibée exerce également la branche de remplacement. Un conteneur avec un clic autorisé et un survol prohibé conserve son action de clic.

Ce nettoyage sélectif diffère de [removeAllHyperlinks](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) qui supprime les deux types d’activation dans la portée sélectionnée, quelle que soit la politique. La vérification ici ne contrôle que les actions d’hyperlien ; elle ne supprime pas les projets VBA embarqués, les objets OLE ou autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis‑je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour naviguer vers une section, créez un lien vers la première diapositive de cette section.

**Puis‑je attacher un hyperlien aux éléments du masque de diapositive afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du masque de diapositive et des dispositions prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le masque ou la disposition correspondante.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Les exports PDF et HTML pris en charge peuvent conserver les hyperliens ; les images raster et les vidéos ne le peuvent pas. Voir les considérations d’exportation dans [Rapport, assainissement et vérification des hyperliens](#report-sanitize-and-verify-hyperlinks).