---
title: ActiveX‑Steuerelemente in Präsentationen mit PHP verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/php-java/activex/
keywords:
- ActiveX
- ActiveX‑Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Media‑Player
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "ActiveX‑Textfelder und -Buttons bearbeiten, Steuerelement‑Vorschauen aktualisieren und ein Windows‑Media‑Player‑Steuerelement in PowerPoint‑Präsentationen mit Aspose.Slides für PHP via Java wiederverwenden."
---
## **Einleitung**

ActiveX‑Steuerelemente geben einer PowerPoint‑Folie interaktive Elemente wie Textfelder, Befehls‑Buttons und Mediaplayer. Aspose.Slides für PHP via Java stellt die Steuerelemente einer Folie über [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls) bereit. Verwenden Sie diese Sammlung, um ein Steuerelement zu bearbeiten, auf der Folie zu verschieben oder zu entfernen.

## **Auflisten von ActiveX‑Steuerelementen und deren gespeicherten Eigenschaften**

Um ein unbekanntes Template zu untersuchen, öffnen Sie es zum Lesen und iterieren über die Steuerelemente jeder Folie. Das Beispiel gibt die Foliennummer, den Steuerelementnamen, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) und jedes Schlüssel‑Wert‑Paar in [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) aus. Es liest die Präsentation, ohne Steuerelemente zu aktivieren, Ereignisse oder Makros auszulösen, Werte zu ändern oder die Datei zu speichern.

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

Ausgewählte Ausgabe von `ActiveX.pptm` zeigt ein Textfeld und einen Befehls‑Button.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Eine leere Eigenschaftensammlung erscheint als `[]`. Für Steuerelemente, die binäre Speicherung verwenden, kann [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) `null` zurückgeben, angezeigt als `Properties unavailable`. Wenn Sie nur die Namen benötigen, verwenden Sie nach der Null‑Prüfung [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties). Der Bericht listet die aus der Präsentation verfügbaren Eigenschaften auf. Ein Steuerelement kann zur Laufzeit zusätzliche Eigenschaften unterstützen.

## **ActiveX‑Steuerelemente bearbeiten**

Das Beispiel erwartet eine makrofähige Präsentation mit einem Textfeld namens `TextBox1` und einem Befehls‑Button namens `CommandButton1` auf der ersten Folie. Es verwendet die [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) zum Ändern des Textfeldwerts und der Beschriftung des Buttons. Jedes Steuerelement hat außerdem eine statische Vorschau, die PowerPoint vor der Aktivierung anzeigen kann. Stellen Sie für jedes Steuerelement ein PNG bereit, das den aktualisierten Text und das Aussehen zeigt. Das Beispiel weist diese Bilder über [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat) zu.

Das Beispiel verschiebt jedes Steuerelement auf der ersten Folie um 100 Punkte nach unten, indem es dessen Rahmen mit [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame) festlegt. Es speichert die bearbeitete Präsentation im PPTM‑Format und verwendet anschließend [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear), um eine zweite Kopie zu speichern, aus der alle ActiveX‑Steuerelemente von dieser Folie entfernt wurden.

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

## **Ein ActiveX‑Media‑Player‑Steuerelement hinzufügen**

Um ein konfiguriertes Windows Media Player‑Steuerelement wiederzuverwenden, beginnen Sie mit einem Template, dessen erste Folie einen Player namens `WindowsMediaPlayer1` enthält. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) kopiert die gesamte Folie in eine neue Präsentation. Das Beispiel setzt die `URL` des Players in seiner [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) und speichert die geklonte Folie als einzige Folie in der Ausgabe. Das Video bleibt extern, wählen Sie also einen Pfad, den der Player während der Wiedergabe erreichen kann.

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

**Kann Aspose.Slides ActiveX‑Steuerelemente erhalten, ohne sie auszuführen?**

Ja. Aspose.Slides kann Steuerelemente lesen und speichern, einschließlich deren Eigenschaften und Positionen, ohne sie zu aktivieren.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten?**

ActiveX‑Steuerelemente ermöglichen es Benutzern, mit einer Folie zu interagieren, zum Beispiel Text einzugeben oder einen Button zu klicken. Ein [OLE‑Objekt](/slides/de/php-java/manage-ole/) ermöglicht es einer Folie, Inhalte zu enthalten oder zu verlinken, die von einer anderen Anwendung verwaltet werden, wie ein Excel‑Arbeitsblatt.

**Lösen ActiveX‑Ereignisse weiterhin VBA‑Makros aus, nachdem ich eine Präsentation mit Aspose.Slides gespeichert habe?**

Speichern Sie die Präsentation in einem makrofähigen Format wie PPTM, um ihr VBA‑Projekt zu erhalten. PowerPoint für Windows kann die vorhandenen Ereignishandler ausführen, wenn die Sicherheitseinstellungen sowohl ActiveX‑Steuerelemente als auch Makros zulassen.