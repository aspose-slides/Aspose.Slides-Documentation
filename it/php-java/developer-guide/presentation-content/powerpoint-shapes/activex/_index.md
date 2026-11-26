---
title: Gestisci i controlli ActiveX nelle presentazioni usando PHP
linktitle: ActiveX
type: docs
weight: 80
url: /it/php-java/activex/
keywords:
- ActiveX
- controllo ActiveX
- gestire ActiveX
- aggiungere ActiveX
- modificare ActiveX
- lettore multimediale
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Modifica caselle di testo e pulsanti ActiveX, aggiorna le anteprime dei controlli e riutilizza un controllo Windows Media Player nelle presentazioni PowerPoint con Aspose.Slides per PHP tramite Java."
---
## **Introduzione**

I controlli ActiveX forniscono a una diapositiva PowerPoint elementi interattivi come caselle di testo, pulsanti di comando e lettori multimediali. Aspose.Slides per PHP tramite Java espone i controlli di una diapositiva tramite [BaseSlide::getControls](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getControls). Utilizza questa raccolta per modificare un controllo, spostarlo sulla diapositiva o rimuoverlo.

## **Elenco dei controlli ActiveX e delle loro proprietà memorizzate**

Per esaminare un modello sconosciuto, aprilo in lettura e itera attraverso i controlli di ogni diapositiva. L'esempio restituisce il numero della diapositiva, il nome del controllo, [getClassId](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getClassId) e ogni coppia chiave-valore in [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties). Legge la presentazione senza attivare i controlli, invocare eventi o macro, modificare valori o salvare il file.

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

L'output selezionato da `ActiveX.pptm` mostra una casella di testo e un pulsante di comando.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

Una raccolta di proprietà vuota compare come `[]`. Per i controlli che utilizzano la memorizzazione binaria, [getProperties](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getProperties) può restituire `null`, visualizzato come `Properties unavailable`. Se ti servono solo i nomi, usa [getNamesOfProperties](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) dopo il controllo di null. Il report elenca le proprietà disponibili nella presentazione. Un controllo può supportare proprietà aggiuntive a runtime.

## **Modifica dei controlli ActiveX**

L'esempio richiede una presentazione con macro abilitata contenente una casella di testo denominata `TextBox1` e un pulsante di comando denominato `CommandButton1` nella prima diapositiva. Utilizza la [control properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) per modificare il valore della casella di testo e la didascalia del pulsante. Ogni controllo ha anche un'anteprima statica che PowerPoint può visualizzare prima dell'attivazione. Fornisci un PNG per ciascun controllo che mostri il testo e l'aspetto aggiornati. L'esempio assegna queste immagini tramite [Control::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getSubstitutePictureFormat).

L'esempio sposta ogni controllo nella prima diapositiva verso il basso di 100 punti impostando il suo frame con [Control::setFrame](https://reference.aspose.com/slides/php-java/aspose.slides/control/#setFrame). Salva la presentazione modificata in formato PPTM, quindi utilizza [ControlCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/controlcollection/#clear) per salvare una seconda copia con tutti i controlli ActiveX rimossi da quella diapositiva.

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

## **Aggiungi un controllo ActiveX Media Player**

Per riutilizzare un controllo Windows Media Player configurato, inizia con un modello la cui prima diapositiva contiene un lettore denominato `WindowsMediaPlayer1`. [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) copia l'intera diapositiva in una nuova presentazione. L'esempio imposta l'`URL` del lettore nella sua [properties collection](https://reference.aspose.com/slides/php-java/aspose.slides/controlpropertiescollection/) e salva la diapositiva clonata come unica diapositiva nell'output. Il video rimane esterno, quindi scegli un percorso accessibile al lettore durante la riproduzione.

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

**Aspose.Slides può preservare i controlli ActiveX senza eseguirli?**

Sì. Aspose.Slides può leggere e salvare i controlli, incluse le loro proprietà e posizioni, senza attivarli.

**In che modo i controlli ActiveX differiscono dagli oggetti OLE?**

I controlli ActiveX consentono agli utenti di interagire con una diapositiva, ad esempio inserendo testo o facendo clic su un pulsante. Un [OLE object](/slides/it/php-java/manage-ole/) permette a una diapositiva di contenere o collegare contenuti gestiti da un'altra applicazione, come un foglio di lavoro Excel.

**Gli eventi ActiveX attiveranno ancora le macro VBA dopo aver salvato una presentazione con Aspose.Slides?**

Salva la presentazione in un formato con macro abilitato, come PPTM, per conservare il progetto VBA. PowerPoint per Windows può eseguire i gestori di eventi esistenti quando le impostazioni di sicurezza consentono sia i controlli ActiveX sia le macro.