---
title: Gérer les contrôles ActiveX dans les présentations avec PHP
linktitle: ActiveX
type: docs
weight: 80
url: /fr/php-java/activex/
keywords:
- ActiveX
- contrôle ActiveX
- gérer ActiveX
- ajouter ActiveX
- modifier ActiveX
- lecteur multimédia
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Modifier les zones de texte et les boutons ActiveX, mettre à jour les aperçus des contrôles et réutiliser un contrôle Windows Media Player dans les présentations PowerPoint avec Aspose.Slides for PHP via Java."
---
## **Introduction**

Les contrôles ActiveX offrent à une diapositive PowerPoint des éléments interactifs tels que des zones de texte, des boutons de commande et des lecteurs multimédias. Aspose.Slides for PHP via Java expose les contrôles d’une diapositive via [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Utilisez cette collection pour modifier un contrôle, le déplacer sur la diapositive ou le supprimer.

## **Lister les contrôles ActiveX et leurs propriétés stockées**

Pour examiner un modèle inconnu, ouvrez‑le en lecture et parcourez les contrôles de chaque diapositive. L’exemple indique le numéro de diapositive, le nom du contrôle, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), et chaque paire clé‑valeur de [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Il lit la présentation sans activer les contrôles, déclencher des événements ou des macros, modifier des valeurs ou enregistrer le fichier.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("ActiveX.pptm");
try {
    $slides = $presentation->getSlides();
    for ($i = 0; $i < java_values($slides->size()); $i++) {
        $controls = $slides->get_Item($i)->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            printf("Slide %d | %s | %s\n", $i + 1, $control->getName(), $control->getClassId());
            $properties = $control->getProperties();
            if (java_is_null($properties)) {
                echo "  Properties unavailable\n";
                continue;
            }
            if (java_values($properties->getCount()) === 0) {
                echo "  []\n";
                continue;
            }
            $names = $properties->getNamesOfProperties()->iterator();
            while (java_values($names->hasNext())) {
                $name = $names->next();
                printf("  %s = %s\n", $name, $properties->get_Item($name));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Le résultat sélectionné de `ActiveX.pptm` montre une zone de texte et un bouton de commande.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Une collection de propriétés vide apparaît sous la forme `[]`. Pour les contrôles qui utilisent un stockage binaire, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) peut renvoyer `null`, affiché comme `Properties unavailable`. Si vous avez seulement besoin des noms, utilisez [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) après la vérification de null. Le rapport répertorie les propriétés disponibles dans la présentation. Un contrôle peut prendre en charge des propriétés supplémentaires au moment de l’exécution.

## **Modifier les contrôles ActiveX**

L’exemple suppose une présentation activée par macro contenant une zone de texte nommée `TextBox1` et un bouton de commande nommé `CommandButton1` sur la première diapositive. Il utilise la [collection de propriétés de contrôle](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) pour modifier la valeur de la zone de texte et la légende du bouton. Chaque contrôle possède également un aperçu statique que PowerPoint peut afficher avant l’activation. Fournissez un PNG pour chaque contrôle montrant son texte et son apparence mis à jour. L’exemple assigne ces images via [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

L’exemple déplace chaque contrôle de la première diapositive vers le bas de 100 points en définissant son cadre avec [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Il enregistre la présentation modifiée au format PPTM, puis utilise [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) pour enregistrer une seconde copie avec tous les contrôles ActiveX supprimés de cette diapositive.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("ActiveX.pptm");
try {
    $controls = $presentation->getSlides()->get_Item(0)->getControls();
    $textBox = null;
    $button = null;
    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $name = (string) $control->getName();
        if ($name === "TextBox1") {
            $textBox = $control;
        } elseif ($name === "CommandButton1") {
            $button = $control;
        }
    }
    if ($textBox === null || $button === null || java_is_null($textBox->getProperties()) || java_is_null($button->getProperties())) {
        echo "The first slide must contain both named controls with editable properties.\n";
        return;
    }

    foreach ([[$textBox, "text-box-preview.png"], [$button, "button-preview.png"]] as [$control, $path]) {
        $image = Images::fromFile($path);
        try {
            $preview = $presentation->getImages()->addImage($image);
            $control->getSubstitutePictureFormat()->getPicture()->setImage($preview);
        } finally {
            $image->dispose();
        }
    }
    $textBox->getProperties()->set_Item("Value", "Changed text");
    $button->getProperties()->set_Item("Caption", "Show message");

    for ($j = 0; $j < java_values($controls->size()); $j++) {
        $control = $controls->get_Item($j);
        $frame = $control->getFrame();
        $newY = java_values($frame->getY()) + 100;
        $moved = new ShapeFrame($frame->getX(), $newY, $frame->getWidth(), $frame->getHeight(), $frame->getFlipH(), $frame->getFlipV(), $frame->getRotation());
        $control->setFrame($moved);
    }
    $presentation->save("edited-controls.pptm", SaveFormat::Pptm);

    $controls->clear();
    $presentation->save("removed-controls.pptm", SaveFormat::Pptm);
} finally {
    $presentation->dispose();
}
```

## **Ajouter un contrôle ActiveX Media Player**

Pour réutiliser un contrôle Windows Media Player configuré, commencez avec un modèle dont la première diapositive contient un lecteur nommé `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) copie la diapositive entière dans une nouvelle présentation. L’exemple définit l’`URL` du lecteur dans sa [collection de propriétés](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) et enregistre la diapositive clonée comme la seule diapositive du résultat. La vidéo reste externe, choisissez donc un chemin accessible au lecteur pendant la lecture.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$template = new Presentation("template.pptx");
try {
    $presentation = new Presentation();
    try {
        $slides = $presentation->getSlides();
        $sourceSlide = $template->getSlides()->get_Item(0);
        $slide = $slides->addClone($sourceSlide);
        $player = null;
        $controls = $slide->getControls();
        for ($j = 0; $j < java_values($controls->size()); $j++) {
            $control = $controls->get_Item($j);
            if ((string) $control->getName() === "WindowsMediaPlayer1") {
                $player = $control;
                break;
            }
        }
        if ($player === null || java_is_null($player->getProperties())) {
            echo "The template slide must contain a named media player with editable properties.\n";
            return;
        }
        $player->getProperties()->set_Item("URL", "Wildlife.mp4");
        $slides->removeAt(0);
        $presentation->save("linked-video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $template->dispose();
}
```

## **FAQ**

**Aspose.Slides peut‑il conserver les contrôles ActiveX sans les exécuter ?**

Oui. Aspose.Slides peut lire et enregistrer les contrôles, y compris leurs propriétés et positions, sans les activer.

**En quoi les contrôles ActiveX diffèrent‑ils des objets OLE ?**

Les contrôles ActiveX permettent aux utilisateurs d’interagir avec une diapositive, par exemple en saisissant du texte ou en cliquant sur un bouton. Un [objet OLE](/slides/fr/php-java/manage-ole/) permet à une diapositive de contenir ou de lier du contenu géré par une autre application, comme une feuille de calcul Excel.

**Les événements ActiveX déclencheront‑ils toujours les macros VBA après avoir enregistré une présentation avec Aspose.Slides ?**

Enregistrez la présentation au format activé par macro tel que PPTM pour conserver son projet VBA. PowerPoint pour Windows peut exécuter les gestionnaires d’événements existants lorsque ses paramètres de sécurité autorisent à la fois les contrôles ActiveX et les macros.