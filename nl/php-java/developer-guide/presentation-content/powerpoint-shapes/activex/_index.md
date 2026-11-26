---
title: Beheer ActiveX-besturingselementen in presentaties met PHP
linktitle: ActiveX
type: docs
weight: 80
url: /nl/php-java/activex/
keywords:
- ActiveX
- ActiveX-besturingselement
- ActiveX beheren
- ActiveX toevoegen
- ActiveX wijzigen
- mediaspeler
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Bewerk ActiveX-tekstvakken en -knoppen, werk voorbeeldweergaven van besturingselementen bij, en hergebruik een Windows Media Player-besturingselement in PowerPoint-presentaties met Aspose.Slides voor PHP via Java."
---
## **Inleiding**

ActiveX‑besturingselementen geven een PowerPoint‑dia interactieve elementen zoals tekstvakken, commando‑knoppen en mediaspelers. Aspose.Slides for PHP via Java stelt de besturingselementen van een dia bloot via [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Gebruik deze collectie om een besturingselement te bewerken, het op de dia te verplaatsen of te verwijderen.

## **Lijst van ActiveX‑besturingselementen en hun opgeslagen eigenschappen**

Om een onbekende sjabloon te inspecteren, open je deze voor lezen en doorloop je de besturingselementen op elke dia. Het voorbeeld meldt het slidennummer, de naam van het besturingselement, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), en elk sleutel‑waarde‑paar in [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Het leest de presentatie zonder besturingselementen te activeren, gebeurtenissen of macro's aan te roepen, waarden te wijzigen of het bestand op te slaan.

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

Geselecteerde uitvoer van `ActiveX.pptm` toont een tekstvak en een commando‑knop.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Een lege eigenschapencollectie verschijnt als `[]`. Voor besturingselementen die binaire opslag gebruiken, kan [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) `null` retourneren, weergegeven als `Properties unavailable`. Als je alleen de namen nodig hebt, gebruik dan [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) na de null‑controle. Het rapport somt de eigenschappen op die beschikbaar zijn in de presentatie. Een besturingselement kan tijdens runtime extra eigenschappen ondersteunen.

## **ActiveX‑besturingselementen wijzigen**

Het voorbeeld verwacht een macro‑ingeschakelde presentatie met een tekstvak genaamd `TextBox1` en een commando‑knop genaamd `CommandButton1` op de eerste dia. Het maakt gebruik van de [collectie van besturingseigenschappen](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) om de waarde van het tekstvak en het bijschrift van de knop te wijzigen. Elk besturingselement heeft ook een statische voorbeeldweergave die PowerPoint kan tonen vóór activatie. Voorzie een PNG voor elk besturingselement dat de bijgewerkte tekst en weergave toont. Het voorbeeld wijst deze afbeeldingen toe via [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Het voorbeeld verplaatst elk besturingselement op de eerste dia 100 punten naar beneden door het kader in te stellen met [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Het slaat de bewerkte presentatie op in PPTM‑formaat en gebruikt vervolgens [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) om een tweede kopie op te slaan waarbij alle ActiveX‑besturingselementen van die dia zijn verwijderd.

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
## **Een ActiveX‑mediaplayer‑besturingselement toevoegen**

Om een geconfigureerd Windows Media Player‑besturingselement opnieuw te gebruiken, begin je met een sjabloon waarvan de eerste dia een speler bevat genaamd `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) kopieert de volledige dia naar een nieuwe presentatie. Het voorbeeld stelt de `URL` van de speler in via zijn [eigenschapencollectie](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) en slaat de gekloonde dia op als de enige dia in de uitvoer. De video blijft extern, kies dus een pad dat de speler tijdens het afspelen kan benaderen.

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

**Kan Aspose.Slides ActiveX‑besturingselementen behouden zonder ze uit te voeren?**

Ja. Aspose.Slides kan besturingselementen lezen en opslaan, inclusief hun eigenschappen en posities, zonder ze te activeren.

**Hoe verschillen ActiveX‑besturingselementen van OLE‑objecten?**

ActiveX‑besturingselementen laten gebruikers interactie hebben met een dia, bijvoorbeeld door tekst in te voeren of op een knop te klikken. Een [OLE‑object](/slides/nl/php-java/manage-ole/) laat een dia inhoud bevatten of linken naar inhoud die beheerd wordt door een andere toepassing, zoals een Excel‑werkblad.

**Zullen ActiveX‑gebeurtenissen nog steeds VBA‑macro's activeren nadat ik een presentatie opsla met Aspose.Slides?**

Sla de presentatie op in een macro‑ingeschakeld formaat zoals PPTM om het VBA‑project te behouden. PowerPoint voor Windows kan de bestaande gebeurtenis‑handlers uitvoeren wanneer de beveiligingsinstellingen zowel ActiveX‑besturingselementen als macro's toestaan.