---
title: "Hantera ActiveX‑kontroller i presentationer med PHP"
linktitle: "ActiveX"
type: docs
weight: 80
url: /sv/php-java/activex/
keywords:
- "ActiveX"
- "ActiveX‑kontroll"
- "hantera ActiveX"
- "lägga till ActiveX"
- "modifiera ActiveX"
- "mediaspelare"
- "PowerPoint"
- "presentation"
- "PHP"
- "Aspose.Slides"
description: "Redigera ActiveX‑textrutor och -knappar, uppdatera kontrollförhandsvisningar och återanvänd en Windows Media Player‑kontroll i PowerPoint‑presentationer med Aspose.Slides för PHP via Java."
---
## **Introduktion**

ActiveX‑kontroller ger en PowerPoint‑bild interaktiva element såsom textrutor, kommandoknappar och mediespelare. Aspose.Slides för PHP via Java exponerar en bilds kontroller via [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Använd den här samlingen för att redigera en kontroll, flytta den på bilden eller ta bort den.

## **Lista ActiveX‑kontroller och deras lagrade egenskaper**

För att undersöka en okänd mall, öppna den för läsning och iterera genom kontrollerna på varje bild. Exemplet rapporterar bildnumret, kontrollens namn, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId), och varje nyckel‑värde‑par i [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Det läser presentationen utan att aktivera kontroller, utlösa händelser eller makron, ändra värden eller spara filen.

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

Det valda resultatet från `ActiveX.pptm` visar en textruta och en kommandoknapp.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

En tom egenskapskollektion visas som `[]`. För kontroller som använder binär lagring kan [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) returnera `null`, visat som `Properties unavailable`. Om du bara behöver namnen, använd [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) efter null‑kontrollen. Rapporten listar de egenskaper som finns i presentationen. En kontroll kan stödja ytterligare egenskaper vid körning.

## **Modifiera ActiveX‑kontroller**

Exemplet förutsätter en makro‑aktiverad presentation med en textruta med namnet `TextBox1` och en kommandoknapp med namnet `CommandButton1` på den första bilden. Det använder [kontrollens egenskapskollektion](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) för att ändra textrutans värde och knappens rubrik. Varje kontroll har också en statisk förhandsvisning som PowerPoint kan visa innan aktivering. Tillhandahåll en PNG för varje kontroll som visar dess uppdaterade text och utseende. Exemplet tilldelar dessa bilder via [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

Exemplet flyttar varje kontroll på den första bilden nedåt med 100 punkter genom att sätta dess ram med [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Det sparar den redigerade presentationen i PPTM‑format, och använder sedan [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) för att spara en andra kopia där alla ActiveX‑kontroller har tagits bort från den bilden.

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

## **Lägg till en ActiveX‑mediaspelarkontroll**

För att återanvända en konfigurerad Windows Media Player‑kontroll, börja med en mall där den första bilden innehåller en spelare med namnet `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) kopierar hela bilden till en ny presentation. Exemplet sätter spelarens `URL` i dess [egenskapskollektion](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) och sparar den klonade bilden som den enda bilden i utdata. Videon förblir extern, så välj en sökväg som spelaren kan komma åt under uppspelning.

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

**Kan Aspose.Slides bevara ActiveX‑kontroller utan att köra dem?**

Ja. Aspose.Slides kan läsa och spara kontroller, inklusive deras egenskaper och positioner, utan att aktivera dem.

**Hur skiljer sig ActiveX‑kontroller från OLE‑objekt?**

ActiveX‑kontroller låter användare interagera med en bild, till exempel genom att skriva in text eller klicka på en knapp. Ett [OLE‑objekt](/slides/sv/php-java/manage-ole/) låter en bild innehålla eller länka till innehåll som hanteras av ett annat program, såsom ett Excel‑kalkylblad.

**Kommer ActiveX‑händelser fortfarande att trigga VBA‑makron efter att jag sparar en presentation med Aspose.Slides?**

Spara presentationen i ett makro‑aktiverat format såsom PPTM för att behålla dess VBA‑projekt. PowerPoint för Windows kan köra de befintliga händelsehanterarna när dess säkerhetsinställningar tillåter både ActiveX‑kontroller och makron.