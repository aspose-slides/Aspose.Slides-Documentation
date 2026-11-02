---
title: Gestire i collegamenti ipertestuali della presentazione in JavaScript
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/nodejs-java/manage-hyperlinks/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java, utilizzando esempi JavaScript."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da testo, forma o fotogramma multimediale.
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides for Node.js via Java ti consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Note" %}}
Puoi anche modificare le presentazioni con il [gratuito editor online di Aspose PowerPoint](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Aggiungere collegamenti URL**

Puoi assegnare un URL di sito web a testo, forma o fotogramma multimediale. L'elemento a cui assegni il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un fotogramma collega l'oggetto della diapositiva.

Per presentazioni contenenti collegamenti ipertestuali relativi, consulta [Gestisci la base del collegamento ipertestuale](/slides/it/nodejs-java/presentation-properties/#manage-the-hyperlink-base) per leggere, modificare o cancellare la base a livello di documento.

### **Aggiungere collegamenti URL a testo**

Per collegare il testo a un sito web, passa un [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) al metodo [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti URL a forme e fotogrammi multimediali**

Per rendere una forma o un fotogramma cliccabile, chiama il suo metodo [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick). Il collegamento ipertestuale appartiene all'oggetto stesso piuttosto che a una porzione di testo al suo interno.

Lo stesso approccio si applica a fotogrammi di immagini, audio e video: assegna il collegamento ipertestuale al fotogramma e chiama [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) se necessario.

L'esempio seguente rende un rettangolo cliccabile:

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

## **Utilizzare i collegamenti per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) per collegare il testo “Page 2” nella prima diapositiva alla seconda diapositiva.

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

## **Formattare i collegamenti ipertestuali**

### **Colore**

Il metodo [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) di [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) determina se un collegamento ipertestuale utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore del testo personalizzato, seleziona [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) e imposta il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

L'esempio seguente aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito del collegamento.

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
### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando viene attivato o fermare un suono già in riproduzione. Usa i seguenti metodi per configurare questi comportamenti:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) specifica l’audio associato al collegamento ipertestuale.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) controlla se l’attivazione del collegamento ipertestuale interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L'esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante nella prima diapositiva. Cliccando il pulsante si riproduce il suono e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire alcuna azione di navigazione.

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

#### **Estrarre un suono dal collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l’audio del collegamento ipertestuale della prima forma in memoria tramite [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) e [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **Impostazioni di tooltip e interazione**

Puoi chiamare i seguenti metodi di [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) dopo aver assegnato un collegamento ipertestuale a testo o a una forma:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) imposta il testo che un visualizzatore può mostrare come suggerimento per il collegamento.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) specifica il fotogramma di destinazione all'interno di un frameset HTML padre, quando applicabile.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) controlla se l’attivazione del collegamento aggiunge la destinazione all'elenco dei collegamenti ipertestuali visualizzati.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) controlla se il collegamento ipertestuale è evidenziato quando cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Usa [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) per raccogliere i contenitori di collegamenti ipertestuali, inclusi i collegamenti delle porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiama solo [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); rimuovere un'azione di click non rimuove la sua controparte al passaggio del mouse.

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

Per rimozione incondizionata, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) rimuove entrambi i tipi di attivazione nell'ambito selezionato con una sola chiamata. Per una pulizia selettiva e copertura di master, layout e note, vedi [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, crea un inventario delle sue azioni interattive così come dei suoi collegamenti web. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) restituisce contenitori di collegamenti ipertestuali, non una semplice lista di stringhe URL. Ispeziona sia [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) che [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo richiede fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può perdere i collegamenti allegati a porzioni di testo. Interroga invece l'ambito appropriato e conserva i contenitori restituiti in modo da poter successivamente aggiornare o rimuovere le loro azioni.

### **Interrogare gli ambiti di presentazione, diapositiva e riquadro di testo**

La classe [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) è disponibile tramite [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) e [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Ogni ambito supporta le stesse query:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) restituisce contenitori con un'azione di click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) restituisce contenitori con un'azione al passaggio del mouse.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) restituisce contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento click esterno, un collegamento mouse-over a file, navigazione interna della diapositiva, un collegamento mouse-over di testo e un'azione macro. Non esegue nessuna di queste azioni. Le stesse tre query funzionano in ogni ambito; i conteggi descrivono i contenitori, non il totale delle azioni. L'ambito del riquadro di testo esclude i collegamenti propri della forma contenente.

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

Per questo esempio, le query di presentazione e di diapositiva riportano ciascuna tre contenitori di click, due contenitori di mouse-over e tre contenitori con una delle due azioni. La query del riquadro di testo riporta un contenitore in ogni categoria.

### **Classificare azioni e destinazioni**

Usa [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) coprono più della navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; ispeziona l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione incorporata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termina lo spettacolo corrente o avvia uno spettacolo personalizzato. |
| `StartMacro` | Esegue una macro. |
| `StartProgram` | Avvia un programma. |
| `OpenFile`, `OpenPresentation` | Apri un file o un'altra presentazione; rivedi separatamente dagli URL web. |
| `StartStopMedia` | Avvia o interrompe la riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggi le destinazioni esterne da [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) e le destinazioni interne specifiche da [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Le azioni interne e i comandi incorporati possono non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia azioni. Conserva il valore restituito da [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) quando differisce dall'URL normalizzato, e includi il tooltip restituito da [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) quando disponibile.

### **Segnalare, sanificare e verificare i collegamenti ipertestuali**

L'esempio JavaScript seguente legge una presentazione esistente (usa il file creato sopra), scrive `hyperlink-audit.json`, applica una policy, salva `hyperlink-sanitized.pptx` e lo riapre per verificare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di elaborare lo stesso contenitore due volte. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, interroga esplicitamente anche master, layout, note e i master di note e handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) dove disponibile. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati dal loro ambito. I contenitori di forma e i contenitori di formattazione delle porzioni di testo sono etichettati separatamente; altri tipi di contenitore mantengono il loro nome di tipo runtime. Ogni contenitore riceve un ID locale al report in modo che le sue due azioni possano essere correlate. Il report memorizza i tipi di azione come le costanti intere definite dall'enumerazione HyperlinkActionType.

Questa policy applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e destinazioni di diapositive interne valide. Rifiuta macro, programmi, azioni su file, altre azioni della presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di policy, non un giudizio di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce la fiducia: aggiungi whitelist di host e altri controlli per la tua applicazione. Sia gli URL esterni originali che quelli normalizzati sono controllati. L'esempio verifica i metadati senza seguire i collegamenti o eseguire azioni.

Per la rimedio, il [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) del contenitore supporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Qui, i collegamenti click esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; gli altri click proibiti e le azioni mouse-over proibite sono rimossi in modo indipendente. Imposta `replaceExternalClicks` su `false` per rimuovere tutte le violazioni di policy. Scegli una pagina di sostituzione di proprietà dell'applicazione prima del deployment.

La bandiera di esportazione del report utilizza una policy di revisione PDF conservativa: segnala le azioni mouse-over e tutto ciò che non sia un collegamento esterno o un salto a diapositiva specifica come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravvivano all'esportazione. Le esportazioni supportate di [PDF](/slides/it/nodejs-java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/nodejs-java/convert-powerpoint-to-html/) possono preservare i collegamenti ipertestuali, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le [immagini](/slides/it/nodejs-java/convert-powerpoint-to-png/) raster e i [video](/slides/it/nodejs-java/convert-powerpoint-to-video/) non possono preservare collegamenti ipertestuali interattivi; segnala ogni azione quando esegui audit per tali output.

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

Con l'input creato sopra, il report contiene cinque righe di azione. Il collegamento mouse-over al file e il click macro sono rimossi, mentre i collegamenti HTTPS e la navigazione interna della diapositiva rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL click esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un click consentito e un mouse-over proibito mantiene la sua azione di click.

Questa pulizia selettiva differisce da [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), che rimuove entrambi i tipi di attivazione in tutto l'ambito selezionato indipendentemente dalla policy. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altro contenuto attivo, e non valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione verso una sezione, collega alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi di master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi di master slide e layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali verranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedi le considerazioni sull'esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).