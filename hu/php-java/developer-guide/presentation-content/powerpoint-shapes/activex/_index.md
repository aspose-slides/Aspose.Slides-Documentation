---
title: ActiveX vezérlők kezelése prezentációkban PHP használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/php-java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Szerkessze az ActiveX szövegmezőket és gombokat, frissítse a vezérlő előnézeteket, és használja újra a Windows Media Player vezérlőt PowerPoint prezentációkban az Aspose.Slides for PHP via Java segítségével."
---
## **Bevezetés**

ActiveX controls give a PowerPoint slide interactive elements such as text boxes, command buttons, and media players. Aspose.Slides for PHP via Java exposes a slide's controls through [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Use this collection to edit a control, move it on the slide, or remove it.

## **Az ActiveX vezérlők listája és tárolt tulajdonságaik**

To inspect an unfamiliar template, open it for reading and iterate through the controls on each slide. The example reports the slide number, control name, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), and each key-value pair in [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). It reads the presentation without activating controls, invoking events or macros, changing values, or saving the file.

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

A `ActiveX.pptm` kiválasztott kimenete egy szövegmezőt és egy parancsgombot mutat.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Üres tulajdonsággyűjtemény `[]` formában jelenik meg. Azoknál a vezérlőknél, amelyek bináris tárolást használnak, a [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) `null` értéket is visszaadhat, amely `Properties unavailable`‑ként jelenik meg. Ha csak a nevekre van szüksége, a `null` ellenőrzés után használja a [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties). A jelentés felsorolja a prezentációból elérhető tulajdonságokat. Egy vezérlő futásidőben további tulajdonságok támogatására is képes lehet.

## **ActiveX vezérlők módosítása**

The example expects a macro-enabled presentation with a text box named `TextBox1` and a command button named `CommandButton1` on the first slide. It uses the [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) to change the text box value and the button caption. Each control also has a static preview that PowerPoint can display before activation. Supply a PNG for each control showing its updated text and appearance. The example assigns these images through [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

The example moves every control on the first slide down by 100 points by setting its frame with [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). It saves the edited presentation in PPTM format, then uses [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) to save a second copy with all ActiveX controls removed from that slide.

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
## **ActiveX médialejátszó vezérlő hozzáadása**

To reuse a configured Windows Media Player control, start with a template whose first slide contains a player named `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) copies the entire slide into a new presentation. The example sets the player's `URL` in its [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) and saves the cloned slide as the only slide in the output. The video stays external, so choose a path the player can access during playback.

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
## **GYIK**

**Meg tudja őrizni az Aspose.Slides az ActiveX vezérlőket anélkül, hogy futtatná őket?**

Igen. Az Aspose.Slides képes a vezérlőket, beleértve azok tulajdonságait és pozícióit, aktiválás nélkül beolvasni és menteni.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól?**

Az ActiveX vezérlők lehetővé teszik a felhasználók számára, hogy interakcióba lépjenek egy diával, például szöveget adjanak meg vagy gombra kattintsanak. Egy [OLE objektum](/slides/hu/php-java/manage-ole/) lehetővé teszi, hogy egy dia tartalmat tartalmazzon vagy hivatkozzon egy másik alkalmazás által kezelt tartalomra, például egy Excel munkafüzetre.

**Az ActiveX események továbbra is elindítják a VBA makrókat, miután elmentem egy prezentációt az Aspose.Slides segítségével?**

Mentse a prezentációt makró‑engedélyezett formátumban, például PPTM‑ben, hogy megőrizze a VBA projektet. A Windows‑ra telepített PowerPoint képes futtatni a meglévő eseménykezelőket, ha a biztonsági beállítások engedélyezik mind az ActiveX vezérlőket, mind a makrókat.