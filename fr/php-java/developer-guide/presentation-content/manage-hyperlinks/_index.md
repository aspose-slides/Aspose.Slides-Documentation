---
title: Gestion des hyperliens de présentation en PHP
linktitle: Gestion des hyperliens
type: docs
weight: 20
url: /fr/php-java/manage-hyperlinks/
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
- PHP
- Aspose.Slides
description: "Ajoutez, formatez, mettez à jour et supprimez des hyperliens dans les présentations PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, en utilisant des exemples PHP."
---
## **Introduction**

Un hyperlien relie le contenu d’une présentation à un site Web ou à un emplacement à l’intérieur de la présentation. Dans PowerPoint, les hyperliens servent généralement à deux fins :

* Ouvrir un site Web à partir d’un texte, d’une forme ou d’un cadre multimédia.
* Naviguer vers une autre diapositive, par exemple depuis une table des matières.

Aspose.Slides for PHP via Java vous permet d’ajouter ces liens, de contrôler leur apparence et leur son, de mettre à jour leurs propriétés et de les supprimer. Les exemples ci‑dessous montrent comment travailler avec les hyperliens sur des éléments individuels et comment accéder aux hyperliens au niveau de la présentation, de la diapositive ou du cadre de texte. Ils supposent que le PHP/Java Bridge et le wrapper Aspose.Slides PHP sont initialisés. Les membres de l’API sans page de référence PHP renvoient vers l’API Java sous‑jacente.

{{% alert color="info" title="Note" %}}

Vous pouvez également modifier les présentations avec l’[éditeur PowerPoint en ligne gratuit d’Aspose](https://products.aspose.app/slides/editor).

{{% /alert %}} 

## **Ajouter des hyperliens URL**

Vous pouvez affecter une URL de site Web à du texte, à une forme ou à un cadre multimédia. L’élément auquel vous affectez l’hyperlien détermine la zone cliquable : une partie de texte lie le texte sélectionné, tandis qu’une forme ou un cadre lie l’objet de la diapositive.

Pour les présentations contenant des hyperliens relatifs, consultez [Gérer la base d’hyperlien](/slides/fr/php-java/presentation-properties/#manage-the-hyperlink-base) pour lire, modifier ou effacer la base au niveau du document.

### **Ajouter des hyperliens URL au texte**

Pour lier du texte à un site Web, transmettez un [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) à la méthode [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/sethyperlinkclick/) de la partie de texte, comme indiqué ci‑dessous. Seule cette partie de texte devient cliquable.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $textShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
    $textShape->addTextFrame("Aspose: File Format APIs");
    $portionFormat = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $portionFormat->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");
    $portionFormat->setFontHeight(32);

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Ajouter des hyperliens URL aux formes et aux cadres multimédias**

Pour rendre une forme ou un cadre cliquable, appelez sa méthode [setHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/shape/sethyperlinkclick/). L’hyperlien appartient à l’objet lui‑même plutôt qu’à une partie de texte à l’intérieur de celui‑ci.

La même approche s’applique aux cadres d’image, audio et vidéo : affectez l’hyperlien au cadre et appelez [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) si nécessaire.

L’exemple suivant rend un rectangle cliquable :

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

    $shape->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $shape->getHyperlinkClick()->setTooltip("Explore Aspose file format APIs");

    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Utiliser les hyperliens pour créer une table des matières**

Les hyperliens internes permettent aux lecteurs de passer d’une table des matières à une diapositive précise. L’exemple suivant utilise [setInternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) pour lier le texte « Page 2 » de la première diapositive à la deuxième diapositive.

```php
use aspose\slides\FillType;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $tableOfContents = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
    $tableOfContents->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $tableOfContents->getTextFrame()->getParagraphs()->clear();

    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $paragraph->setText("Title of slide 2 .......... ");

    $linkPortion = new Portion();
    $linkPortion->setText("Page 2");
    $linkPortion->getPortionFormat()->getHyperlinkManager()->setInternalHyperlinkClick($secondSlide);

    $paragraph->getPortions()->add($linkPortion);
    $tableOfContents->getTextFrame()->getParagraphs()->add($paragraph);

    $presentation->save("link_to_slide.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Formater les hyperliens**

### **Couleur**

La méthode [setColorSource](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setcolorsource/) de [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) détermine si un hyperlien utilise la couleur d’hyperlien de la présentation ou le formatage de la partie de texte. Pour appliquer une couleur de texte personnalisée, sélectionnez [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkcolorsource/) et définissez la couleur de remplissage de la partie. Cette fonctionnalité a été introduite dans PowerPoint 2019 ; les versions antérieures n’appliquent pas ce réglage.

L’exemple suivant ajoute deux hyperliens texte à la même diapositive. Le premier utilise un remplissage texte rouge, tandis que le deuxième conserve la couleur d’hyperlien par défaut.

```php
use aspose\slides\FillType;
use aspose\slides\Hyperlink;
use aspose\slides\HyperlinkColorSource;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $coloredShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
    $coloredShape->addTextFrame("This hyperlink uses a custom color.");
    $coloredPortionFormat = $coloredShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $coloredPortionFormat->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    $coloredPortionFormat->getHyperlinkClick()->setColorSource(HyperlinkColorSource::PortionFormat);
    $coloredPortionFormat->getFillFormat()->setFillType(FillType::Solid);
    $coloredPortionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $defaultShape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
    $defaultShape->addTextFrame("This hyperlink uses the default color.");
    $defaultShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    $presentation->save("presentation-out-hyperlink.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```
### **Son**

Un hyperlien peut lire un son lorsqu’il est activé ou arrêter un son déjà en cours de lecture. Utilisez les méthodes suivantes pour configurer ces comportements :

- [Hyperlink::setSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setsound/) spécifie l’audio associé à l’hyperlien.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/setstopsoundonclick/) contrôle si l’activation de l’hyperlien arrête le son précédent.

#### **Ajouter un son à un hyperlien**

L’exemple suivant charge `sampleaudio.wav` et le lie à un bouton sur la première diapositive. Cliquer sur le bouton lit le son et navigue vers la diapositive suivante. Une seconde forme sur cette diapositive arrête le son précédent lorsqu’elle est cliquée, sans effectuer d’action de navigation.

```php
use aspose\slides\Hyperlink;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $audioFile = new Java("java.io.File", "sampleaudio.wav");
    $audioPath = $audioFile->toPath();
    $audioData = java("java.nio.file.Files")->readAllBytes($audioPath);
    $hyperlinkSound = $presentation->getAudios()->addAudio($audioData);

    $firstSlide = $presentation->getSlides()->get_Item(0);

    $playButton = $firstSlide->getShapes()->addAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
    $playButton->setHyperlinkClick(Hyperlink::getNextSlide());

    if (!java_values($playButton->getHyperlinkClick()->getStopSoundOnClick()) && java_is_null($playButton->getHyperlinkClick()->getSound()))
    {
        $playButton->getHyperlinkClick()->setSound($hyperlinkSound);
    }

    $secondSlide = $presentation->getSlides()->addEmptySlide($firstSlide->getLayoutSlide());

    $stopButton = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
    $stopButton->setHyperlinkClick(Hyperlink::getNoAction());

    $stopButton->getHyperlinkClick()->setStopSoundOnClick(true);

    $presentation->save("hyperlink-sound.pptx", SaveFormat::Pptx);
} catch (JavaException $exception) {
    echo "Unable to read the audio file: " . $exception->getMessage() . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

#### **Extraire le son d’un hyperlien**

L’exemple suivant ouvre la présentation créée ci‑avantage et lit l’audio de l’hyperlien de la première forme en mémoire via [getSound](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getsound/) et [getBinaryData](https://reference.aspose.com/slides/php-java/aspose.slides/audio/getbinarydata/).

```php
use aspose\slides\Presentation;

$presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0 && java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) > 0) {
        $hyperlink = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getHyperlinkClick();
        $sound = java_is_null($hyperlink) ? null : $hyperlink->getSound();
        if (!java_is_null($sound)) {
            $audioData = $sound->getBinaryData();
            echo "Extracted " . strlen(java_values($audioData)) . " bytes of hyperlink audio." . PHP_EOL;
        } else {
            echo "The first shape has no hyperlink sound." . PHP_EOL;
        }
    } else {
        echo "The presentation has no first slide or shape to inspect." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **Infobulle et paramètres d’interaction**

Vous pouvez appeler les méthodes suivantes de [Hyperlink](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/) après avoir affecté un hyperlien à du texte ou à une forme :

- [setTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settooltip/) définit le texte qu’un visualiseur peut afficher comme indice pour le lien.
- [setTargetFrame](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/settargetframe/) indique le cadre cible au sein d’un frameset HTML parent, le cas échéant.
- [setHistory](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethistory/) contrôle si l’activation du lien ajoute sa destination à la liste des hyperliens consultés.
- [setHighlightClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/sethighlightclick/) contrôle si l’hyperlien est mis en évidence lorsqu’il est cliqué.

## **Supprimer les hyperliens des présentations**

Utilisez [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) pour collecter les conteneurs d’hyperliens, y compris les liens de parties de texte, avant de les modifier. L’exemple suivant supprime les deux types d’activation de la première diapositive. Pour ne supprimer qu’un seul type, appelez uniquement [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) ou [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/) ; la suppression d’une action de clic ne supprime pas son pendant‑survol.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    if (java_values($presentation->getSlides()->size()) > 0) {
        $containers = [];
        foreach ($presentation->getSlides()->get_Item(0)->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $containers[] = $container;
        }
        foreach ($containers as $container) {
            $container->getHyperlinkManager()->removeHyperlinkClick();
            $container->getHyperlinkManager()->removeHyperlinkMouseOver();
        }
        $presentation->save("pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
    } else {
        echo "The presentation has no slides to process." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Pour une suppression inconditionnelle, [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) supprime les deux types d’activation dans la portée sélectionnée en un seul appel. Pour un nettoyage sélectif couvrant les maîtres, les mises en page et les notes, consultez [Rapporter, nettoyer et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).

## **Construire un inventaire complet des hyperliens**

Avant de diffuser une présentation, répertoriez ses actions interactives ainsi que ses liens Web. [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) renvoie des objets [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/), pas une liste plate de chaînes URL. Examinez à la fois [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) et [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) sur chaque conteneur. Ils sont indépendants : le même conteneur peut exposer les deux actions, de sorte qu’un rapport complet nécessite jusqu’à deux lignes par conteneur.

Analyser uniquement les hyperliens au niveau des formes peut manquer les liens attachés aux parties de texte. Interrogez plutôt la portée appropriée et conservez les conteneurs renvoyés afin de pouvoir les mettre à jour ou les supprimer ultérieurement.

### **Interroger les portées Présentation, Diapositive et Cadre de texte**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/) est accessible via [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) et [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/gethyperlinkqueries/). Chaque portée prend en charge les mêmes requêtes :

- [getHyperlinkClicks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) renvoie les conteneurs avec une action de clic.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) renvoie les conteneurs avec une action de survol.
- [getAnyHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) renvoie les conteneurs avec l’une ou l’autre des actions.

L’exemple suivant crée `hyperlink-audit-input.pptx` contenant un lien de clic externe, un lien de survol de fichier, une navigation interne de diapositive, un lien de survol de texte et une action macro. Il n’exécute aucune de ces actions. Les trois requêtes fonctionnent à chaque portée ; les décomptes décrivent des conteneurs, pas le nombre total d’actions. La portée du cadre de texte exclut les liens propres à la forme englobante.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function printQueryCounts($scope, $queries) {
    $clickCount = java_values($queries->getHyperlinkClicks()->size());
    $mouseOverCount = java_values($queries->getHyperlinkMouseOvers()->size());
    $anyCount = java_values($queries->getAnyHyperlinks()->size());
    echo "$scope: click=$clickCount, mouse-over=$mouseOverCount, any=$anyCount" . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $destination = $presentation->getSlides()->addEmptySlide($slide->getLayoutSlide());
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Click the text to go to slide 2");
    $shape->getHyperlinkManager()->setExternalHyperlinkClick("https://example.com/");
    $shape->getHyperlinkClick()->setTooltip("Public website");
    $shape->getHyperlinkManager()->setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    $portionFormat = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
    $portionFormat->getHyperlinkManager()->setInternalHyperlinkClick($destination);
    $portionFormat->getHyperlinkManager()->setExternalHyperlinkMouseOver("https://example.com/help");
    $macroButton = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
    $macroButton->getHyperlinkManager()->setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", $presentation->getHyperlinkQueries());
    printQueryCounts("Slide 1", $slide->getHyperlinkQueries());
    printQueryCounts("Text frame", $shape->getTextFrame()->getHyperlinkQueries());
    $presentation->save("hyperlink-audit-input.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Dans cet exemple, les requêtes présentation et diapositive renvoient chacune trois conteneurs de clic, deux conteneurs de survol et trois conteneurs avec l’une ou l’autre des actions. La requête cadre de texte renvoie un conteneur dans chaque catégorie.

### **Classer les actions et les destinations**

Utilisez [Hyperlink::getActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getactiontype/) pour interpréter une action avant d’interpréter sa destination. Les valeurs de [HyperlinkActionType](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkactiontype/) couvrent plus que la navigation Web :

| Values | Signification pour un audit |
| --- | --- |
| `Hyperlink` | Hyperlien externe ; inspectez l’URL et son schéma. |
| `JumpSpecificSlide` | Navigation interne vers une diapositive précise. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigation de diaporama intégrée, résolue dans le contexte du diaporama. |
| `JumpEndShow`, `StartCustomSlideShow` | Terminer le diaporama actuel ou démarrer un diaporama personnalisé. |
| `StartMacro` | Exécuter une macro. |
| `StartProgram` | Lancer un programme. |
| `OpenFile`, `OpenPresentation` | Ouvrir un fichier ou une autre présentation ; examiner séparément des URL Web. |
| `StartStopMedia` | Démarrer ou arrêter la lecture multimédia. |
| `NoAction`, `Unknown` | Aucun acte de navigation, ou action non reconnue nécessitant une révision. |

Lisez les destinations externes avec [getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) et les destinations internes spécifiques avec [getTargetSlide](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettargetslide/). Les actions internes et les commandes intégrées peuvent ne pas avoir d’URL externe ; une URL vide ne signifie pas que le conteneur n’a aucune action. Conservez la valeur renvoyée par [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) lorsqu’elle diffère de l’URL normalisée, et incluez l’infobulle renvoyée par [getTooltip](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/gettooltip/) lorsqu’elle est disponible.

### **Rapporter, nettoyer et vérifier les hyperliens**

L’exemple PHP suivant lit une présentation existante (utilisez le fichier créé ci‑dessus), écrit `hyperlink-audit.json`, applique une politique, enregistre `hyperlink-sanitized.pptx` et la rouvre pour vérifier à nouveau les deux types d’activation. Il collecte les conteneurs avant de les modifier et utilise l’égalité de référence pour éviter de traiter deux fois le même conteneur. Les requêtes de présentation couvrent les diapositives ordinaires ; pour un inventaire à l’échelle du package, il interroge également explicitement les maîtres, les mises en page, les notes et les maîtres de notes et de documents lorsque présents.

Le rapport enregistre un index de diapositive basé sur 1 et [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) lorsqu’il est disponible. [ISlideComponent::getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) fournit la diapositive propriétaire pour les conteneurs pris en charge. Les maîtres, mises en page et notes n’ont pas d’indice de diapositive ordinaire et sont identifiés par leur portée. Les conteneurs de forme et les conteneurs de formatage de partie de texte sont étiquetés séparément ; les autres types de conteneurs conservent leur nom de type d’exécution. Chaque conteneur obtient un ID local au rapport afin que ses deux actions puissent être corrélées. Le rapport stocke les types d’action sous forme d’entiers définis par l’énumération PHP.

Cette politique d’application volontairement restrictive autorise uniquement les URL HTTPS absolues et les cibles internes de diapositive valides. Elle rejette les macros, programmes, actions de fichier, autres actions de diaporama, actions inconnues et autres schémas d’URL. Ces rejets sont des décisions de politique, pas un verdict de sécurité d’Aspose.Slides. HTTPS seul n’établit pas la confiance : ajoutez des listes blanches d’hôtes et d’autres contrôles pour votre application. Les URL externes originales et normalisées sont toutes deux vérifiées. L’exemple audite les métadonnées sans suivre les liens ni exécuter d’actions.

Pour la remédiation, le [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) du conteneur prend en charge [setExternalHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) et [removeHyperlinkMouseOver](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Ici, les liens de clic externes interdits sont remplacés par une page de destination HTTPS fixe ; les autres clics et survols interdits sont supprimés indépendamment. Réglez `$replaceExternalClicks` à `false` pour supprimer toutes les violations de politique. Choisissez une page de remplacement appartenant à l’application avant le déploiement.

Le drapeau d’exportation du rapport utilise une politique d’examen PDF conservatrice : il signale les actions de survol et tout ce qui n’est pas un lien externe ou un saut de diapositive spécifique comme potentiellement non pris en charge. Il s’agit d’une indication d’examen, pas d’un test de capacité ou d’une garantie que les liens non signalés survivront à l’exportation. Les exports PDF et HTML pris en charge ([PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/) et [HTML](/slides/fr/php-java/convert-powerpoint-to-html/)) peuvent préserver les hyperliens selon l’action, les options d’exportation et le visualiseur. Les [images](/slides/fr/php-java/convert-powerpoint-to-png/) et [vidéos](/slides/fr/php-java/convert-powerpoint-to-video/) raster ne peuvent pas conserver d’hyperliens interactifs ; signalez chaque action lors d’un audit pour ces sorties.

```php
use aspose\slides\HyperlinkActionType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

class HyperlinkAudit {
    public function slideIndex($presentation, $slide) {
        if (java_is_null($slide)) return null;
        for ($index = 0; $index < java_values($presentation->getSlides()->size()); $index++) {
            if (java_values($presentation->getSlides()->get_Item($index)->equals($slide))) return $index + 1;
        }
        return null;
    }

    public function isHttps($value) {
        if ($value === null || $value === '') return false;
        $parts = parse_url($value);
        return $parts !== false && isset($parts['scheme'], $parts['host']) && strcasecmp($parts['scheme'], 'https') === 0 && $parts['host'] !== '';
    }

    public function policyViolation($link) {
        if (java_is_null($link)) return null;
        $action = java_values($link->getActionType());
        if ($action === HyperlinkActionType::JumpSpecificSlide) {
            return java_is_null($link->getTargetSlide()) ? 'Missing target slide' : null;
        }
        if ($action !== HyperlinkActionType::Hyperlink) return 'Action is not allowed';
        if (!$this->isHttps(java_values($link->getExternalUrl()))) return 'Normalized URL is not absolute HTTPS';
        $original = java_values($link->getExternalUrlOriginal());
        if ($original !== null && $original !== '' && !$this->isHttps($original)) return 'Original URL is not absolute HTTPS';
        return null;
    }

    public function addScope(&$found, $slide) {
        if (!java_is_null($slide)) {
            foreach ($slide->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
                $found[] = $container;
            }
        }
    }

    public function collectContainers($presentation) {
        $found = [];
        foreach ($presentation->getHyperlinkQueries()->getAnyHyperlinks() as $container) {
            $found[] = $container;
        }
        $masters = $presentation->getMasters();
        for ($index = 0; $index < java_values($masters->size()); $index++) {
            $this->addScope($found, $masters->get_Item($index));
        }
        $layouts = $presentation->getLayoutSlides();
        for ($index = 0; $index < java_values($layouts->size()); $index++) {
            $this->addScope($found, $layouts->get_Item($index));
        }
        $slides = $presentation->getSlides();
        for ($index = 0; $index < java_values($slides->size()); $index++) {
            $this->addScope($found, $slides->get_Item($index)->getNotesSlideManager()->getNotesSlide());
        }
        $this->addScope($found, $presentation->getMasterNotesSlideManager()->getMasterNotesSlide());
        $this->addScope($found, $presentation->getMasterHandoutSlideManager()->getMasterHandoutSlide());
        $seen = new Java('java.util.IdentityHashMap');
        $unique = [];
        foreach ($found as $container) {
            if (!java_values($seen->containsKey($container))) {
                $seen->put($container, true);
                $unique[] = $container;
            }
        }
        return $unique;
    }

    public function addRow(&$rows, $presentation, $link, $activation, $container, $containerId) {
        if (java_is_null($link)) return;
        $ownerSlide = java_instanceof($container, java('com.aspose.slides.ISlideComponent')) ? $container->getSlide() : null;
        $targetSlide = $link->getTargetSlide();
        $violation = $this->policyViolation($link);
        $ownerType = java_instanceof($container, java('com.aspose.slides.IShape')) ? 'Shape' : (java_instanceof($container, java('com.aspose.slides.IPortionFormat')) ? 'Text portion' : java_values($container->getClass()->getSimpleName()));
        $action = java_values($link->getActionType());
        $ordinaryAction = $action === HyperlinkActionType::Hyperlink || $action === HyperlinkActionType::JumpSpecificSlide;
        $externalUrl = java_values($link->getExternalUrl());
        $originalUrl = java_values($link->getExternalUrlOriginal());
        $rows[] = [
            'ContainerId' => $containerId,
            'SlideIndex' => $this->slideIndex($presentation, $ownerSlide),
            'SlideId' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getSlideId()),
            'Scope' => java_is_null($ownerSlide) ? null : java_values($ownerSlide->getClass()->getSimpleName()),
            'OwnerType' => $ownerType,
            'Activation' => $activation,
            'ActionType' => $action,
            'ExternalUrl' => $externalUrl,
            'TargetSlideIndex' => $this->slideIndex($presentation, $targetSlide),
            'TargetSlideId' => java_is_null($targetSlide) ? null : java_values($targetSlide->getSlideId()),
            'Tooltip' => java_values($link->getTooltip()),
            'OriginalExternalUrl' => $originalUrl === $externalUrl ? null : $originalUrl,
            'PotentiallyUnsafe' => $violation !== null,
            'PolicyViolation' => $violation,
            'TargetExport' => 'PDF',
            'PotentiallyUnsupportedByExport' => $activation === 'mouse-over' || !$ordinaryAction
        ];
    }
}

$replaceExternalClicks = true;
$replacementUrl = 'https://example.com/blocked-link';
$audit = new HyperlinkAudit();
$presentation = new Presentation('hyperlink-audit-input.pptx');
try {
    $containers = $audit->collectContainers($presentation);
    $rows = [];
    foreach ($containers as $index => $container) {
        $audit->addRow($rows, $presentation, $container->getHyperlinkClick(), 'click', $container, $index + 1);
        $audit->addRow($rows, $presentation, $container->getHyperlinkMouseOver(), 'mouse-over', $container, $index + 1);
    }
    $json = json_encode($rows, JSON_PRETTY_PRINT | JSON_UNESCAPED_SLASHES);
    if ($json === false) {
        echo 'Unable to encode the audit report: ' . json_last_error_msg() . PHP_EOL;
    } elseif (file_put_contents('hyperlink-audit.json', $json . PHP_EOL) === false) {
        echo 'Unable to write the audit report.' . PHP_EOL;
    } else {
        foreach ($containers as $container) {
            $click = $container->getHyperlinkClick();
            if ($audit->policyViolation($click) !== null) {
                if ($replaceExternalClicks && java_values($click->getActionType()) === HyperlinkActionType::Hyperlink) {
                    $container->getHyperlinkManager()->setExternalHyperlinkClick($replacementUrl);
                } else {
                    $container->getHyperlinkManager()->removeHyperlinkClick();
                }
            }
            if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) {
                $container->getHyperlinkManager()->removeHyperlinkMouseOver();
            }
        }
        $presentation->save('hyperlink-sanitized.pptx', SaveFormat::Pptx);

        $reopened = new Presentation('hyperlink-sanitized.pptx');
        try {
            $remainingContainers = $audit->collectContainers($reopened);
            $violations = 0;
            foreach ($remainingContainers as $container) {
                if ($audit->policyViolation($container->getHyperlinkClick()) !== null) $violations++;
                if ($audit->policyViolation($container->getHyperlinkMouseOver()) !== null) $violations++;
            }
            echo 'Audit rows: ' . count($rows) . '; prohibited actions after reopening: ' . $violations . PHP_EOL;
            if ($violations !== 0) {
                echo 'Verification failed: do not distribute the saved presentation.' . PHP_EOL;
            }
        } finally {
            $reopened->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

Avec l’entrée créée ci‑dessus, le rapport contient cinq lignes d’action. Le lien de survol de fichier et la macro de clic sont supprimés, tandis que les liens HTTPS et la navigation interne de diapositive restent. La vérification indique zéro action interdite. Une entrée contenant une URL de clic externe interdite exerce également la branche de remplacement. Un conteneur avec un clic autorisé et un survol interdit conserve son action de clic.

Ce nettoyage sélectif diffère de [removeAllHyperlinks](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), qui supprime les deux types d’activation dans la portée sélectionnée indépendamment de la politique. La vérification ici ne porte que sur les actions d’hyperlien ; elle ne supprime pas les projets VBA intégrés, les objets OLE ou autre contenu actif, et elle ne valide pas un fichier PDF ou HTML exporté.

## **FAQ**

**Comment puis‑je créer un lien vers une section ou sa première diapositive ?**

Les sections dans PowerPoint regroupent les diapositives, mais un hyperlien interne cible une diapositive individuelle. Pour créer une navigation vers une section, liez‑vous à la première diapositive de cette section.

**Puis‑je attacher un hyperlien aux éléments de la diapositive maître afin qu’il fonctionne sur toutes les diapositives ?**

Oui. Les éléments du maître et des mises en page prennent en charge les hyperliens. Les liens sur ces éléments sont disponibles pendant le diaporama sur les diapositives qui utilisent le maître ou la mise en page correspondante.

**Les hyperliens seront‑ils conservés lors de l’exportation vers PDF, HTML, images ou vidéo ?**

Les exports PDF et HTML pris en charge peuvent conserver les hyperliens ; les images raster et les vidéos ne le peuvent pas. Consultez les considérations d’exportation dans [Rapporter, nettoyer et vérifier les hyperliens](#report-sanitize-and-verify-hyperlinks).