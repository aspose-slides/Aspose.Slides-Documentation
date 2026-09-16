---
title: Gestire i collegamenti ipertestuali della presentazione in PHP
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/php-java/manage-hyperlinks/
keywords:
- aggiungi URL
- aggiungi collegamento ipertestuale
- crea collegamento ipertestuale
- formatta collegamento ipertestuale
- rimuovi collegamento ipertestuale
- aggiorna collegamento ipertestuale
- collegamento ipertestuale di testo
- collegamento ipertestuale di diapositiva
- collegamento ipertestuale di forma
- collegamento ipertestuale di immagine
- collegamento ipertestuale video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per PHP via Java, utilizzando esempi PHP."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito Web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito Web da testo, forma o cornice multimediale.
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides per PHP tramite Java consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o casella di testo. Si assume che PHP/Java Bridge e il wrapper PHP di Aspose.Slides siano inizializzati. I membri dell'API senza una pagina di riferimento PHP puntano all'API Java sottostante.

{{% alert color="info" title="Nota" %}}
È inoltre possibile modificare le presentazioni con l'[editor online gratuito di Aspose PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}} 

## **Aggiungere collegamenti ipertestuali URL**

È possibile assegnare un URL di sito Web a testo, forma o cornice multimediale. L'elemento a cui si assegna il collegamento determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o una cornice collega l'oggetto della diapositiva.

### **Aggiungere collegamenti ipertestuali URL al testo**

Per collegare del testo a un sito Web, passare un [Hyperlink](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/) al metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/portionformat/sethyperlinkclick/) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti ipertestuali URL a forme e cornici multimediali**

Per rendere cliccabile una forma o una cornice, chiamare il suo metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/sethyperlinkclick/). Il collegamento appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio vale per le cornici immagine, audio e video: assegnare il collegamento alla cornice e chiamare [setTooltip](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/settooltip/) se necessario.

L'esempio seguente rende cliccabile un rettangolo:

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

## **Utilizzare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [setInternalHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/setinternalhyperlinkclick/) per collegare il testo “Pagina 2” nella prima diapositiva alla seconda diapositiva.

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

## **Formattare i collegamenti ipertestuali**

### **Colore**

Il metodo [setColorSource](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/setcolorsource/) di [Hyperlink](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/) determina se un collegamento utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzione è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

L'esempio seguente aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo usa un riempimento rosso del testo, mentre il secondo mantiene il colore predefinito del collegamento.

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
### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando viene attivato o interrompere un suono già in riproduzione. Utilizzare i seguenti metodi per configurare questi comportamenti:

- [Hyperlink::setSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/setsound/) specifica l'audio associato al collegamento.
- [Hyperlink::setStopSoundOnClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/setstopsoundonclick/) controlla se l'attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L'esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante nella prima diapositiva. Cliccando il pulsante il suono viene riprodotto e la presentazione passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire alcuna navigazione.

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

#### **Estrarre un suono dal collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l'audio del collegamento della prima forma in memoria tramite [getSound](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/getsound/) e [getBinaryData](https://reference.aspose.com/slides/it/php-java/aspose.slides/audio/getbinarydata/).

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

### **Impostazioni di tooltip e interazione**

È possibile chiamare i seguenti metodi di [Hyperlink](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/) dopo aver assegnato un collegamento a testo o forma:

- [setTooltip](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/settooltip/) imposta il testo che il visualizzatore può mostrare come suggerimento per il collegamento.
- [setTargetFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/settargetframe/) specifica il frame di destinazione all'interno di un frameset HTML genitore, se applicabile.
- [setHistory](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/sethistory/) controlla se l'attivazione del collegamento aggiunge la destinazione all'elenco dei collegamenti visualizzati.
- [setHighlightClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/sethighlightclick/) controlla se il collegamento è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Usare [getAnyHyperlinks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) per raccogliere i contenitori di collegamenti, inclusi i collegamenti alle porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare soltanto [removeHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/); rimuovere l'azione di click non elimina la controparte mouse‑over.

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

Per rimozione incondizionata, [removeAllHyperlinks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/) elimina entrambi i tipi di attivazione nell'ambito selezionato in una sola chiamata. Per una pulizia selettiva che copra master, layout e note, vedere [Segnalare, sanificare e verificare i collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, inventariare le azioni interattive così come i collegamenti web. [getAnyHyperlinks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [getHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) sia [getHyperlinkMouseOver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un rapporto completo può richiedere fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può far perdere i collegamenti associati a porzioni di testo. Interrogare l'ambito appropriato e conservare i contenitori restituiti in modo da poter aggiornare o rimuovere le loro azioni in seguito.

### **Interrogare gli ambiti presentazione, diapositiva e casella di testo**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/) è disponibile tramite [Presentation::getHyperlinkQueries](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/gethyperlinkqueries/), [IBaseSlide::getHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) e [TextFrame::getHyperlinkQueries](https://reference.aspose.com/slides/it/php-java/aspose.slides/textframe/gethyperlinkqueries/). Ogni ambito supporta le stesse query:

- [getHyperlinkClicks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/gethyperlinkclicks/) restituisce contenitori con un'azione di click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/gethyperlinkmouseovers/) restituisce contenitori con un'azione mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/getanyhyperlinks/) restituisce contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento click esterno, un collegamento mouse‑over a file, navigazione interna a diapositiva, un collegamento mouse‑over al testo e un'azione macro. Non esegue nessuna di queste azioni. Le tre query funzionano in ogni ambito; i conteggi descrivono contenitori, non il numero totale di azioni. L'ambito della casella di testo esclude i collegamenti della forma contenitrice.

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

Per questo esempio, le query su presentazione e diapositiva riportano tre contenitori click, due contenitori mouse‑over e tre contenitori con una qualsiasi delle azioni. La query sulla casella di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usare [Hyperlink::getActionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/getactiontype/) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; esaminare l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione integrata della presentazione, risolta nel contesto dello slideshow. |
| `JumpEndShow`, `StartCustomSlideShow` | Terminare lo show corrente o avviare uno show personalizzato. |
| `StartMacro` | Eseguire una macro. |
| `StartProgram` | Avviare un programma. |
| `OpenFile`, `OpenPresentation` | Aprire un file o un'altra presentazione; esaminarli separatamente dagli URL web. |
| `StartStopMedia` | Avviare o arrestare la riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [getExternalUrl](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/getexternalurl/) e le destinazioni interne specifiche da [getTargetSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/gettargetslide/). Le azioni interne e i comandi integrati possono non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia alcuna azione. Conservare il valore restituito da [getExternalUrlOriginal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) quando differisce dall'URL normalizzato e includere il tooltip restituito da [getTooltip](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlink/gettooltip/) se disponibile.

### **Segnalare, sanificare e verificare i collegamenti ipertestuali**

L'esempio PHP seguente legge una presentazione esistente (usare il file creato sopra), scrive `hyperlink-audit.json`, applica una politica, salva `hyperlink-sanitized.pptx` e lo riapre per verificare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di processare lo stesso contenitore due volte. Le query sulla presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga esplicitamente master, layout, note e i master di note e handout quando presenti.

Il rapporto registra un indice di diapositiva basato su 1 e [getSlideId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getSlideId--) dove disponibile. [ISlideComponent::getSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecomponent/#getSlide--) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati per ambito. I contenitori forma e i contenitori di formattazione delle porzioni di testo sono etichettati separatamente; altri tipi di contenitore mantengono il nome del tipo di runtime. Ogni contenitore ottiene un ID locale al rapporto in modo che le sue due azioni possano essere correlate. Il rapporto memorizza i tipi di azione come costanti intere definite dall'enumerazione PHP.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e target di diapositiva interni validi. Rifiuta macro, programmi, azioni su file, altre azioni slideshow, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di politica, non un verdetto di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungere whitelist di host e altri controlli per la propria applicazione. Sia gli URL esterni originali che quelli normalizzati sono verificati. L'esempio esegue un audit dei metadati senza seguire i collegamenti o eseguire azioni.

Per la risanamento, il [getHyperlinkManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) del contenitore supporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/setexternalhyperlinkclick/), [removeHyperlinkClick](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/removehyperlinkclick/) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkmanager/removehyperlinkmouseover/). Qui, i collegamenti click esterni proibiti sono sostituiti da una pagina di atterraggio HTTPS fissa; gli altri click proibiti e le azioni mouse‑over proibite sono rimossi indipendentemente. Impostare `$replaceExternalClicks` a `false` per rimuovere tutte le violazioni di politica. Scegliere una pagina di sostituzione di proprietà dell'applicazione prima del deployment.

Il flag di esportazione del rapporto utilizza una politica conservativa di revisione PDF: segnalare le azioni mouse‑over e tutto ciò che non è un collegamento esterno o un salto a diapositiva specifica come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravviveranno all'esportazione. Le esportazioni PDF e HTML supportate ([PDF](/slides/it/php-java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/php-java/convert-powerpoint-to-html/)) possono preservare i collegamenti ipertestuali, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/php-java/convert-powerpoint-to-png/) raster e i [video](/slides/it/php-java/convert-powerpoint-to-video/) non possono preservare i collegamenti interattivi; segnalare ogni azione quando si effettua un audit per tali output.

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

Con l'input creato sopra, il rapporto contiene cinque righe di azioni. Il collegamento mouse‑over al file e la macro click sono rimossi, mentre i collegamenti HTTPS e la navigazione interna alla diapositiva rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL click esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un click consentito e un mouse‑over proibito conserva la sua azione click.

Questo tipo di pulizia selettiva differisce da [removeAllHyperlinks](https://reference.aspose.com/slides/it/php-java/aspose.slides/hyperlinkqueries/removeallhyperlinks/), che rimuove entrambi i tipi di attivazione in tutto l'ambito selezionato indipendentemente dalla politica. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altri contenuti attivi, né valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collegare alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedi le considerazioni sull'esportazione in [Segnalare, sanificare e verificare i collegamenti ipertestuali](#report-sanitize-and-verify-hyperlinks).