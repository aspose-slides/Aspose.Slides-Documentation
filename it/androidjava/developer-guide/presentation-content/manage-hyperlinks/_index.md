---
title: Gestisci i collegamenti ipertestuali della presentazione su Android
linktitle: Gestisci collegamenti ipertestuali
type: docs
weight: 20
url: /it/androidjava/manage-hyperlinks/
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
- collegamento ipertestuale di video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Aggiungi, formatta, aggiorna e rimuovi i collegamenti ipertestuali in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android tramite Java, utilizzando esempi Java."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali servono comunemente a due scopi:

* Aprire un sito web da testo, forma o riquadro multimediale.
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides for Android via Java consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su singoli elementi e come accedere ai collegamenti a livello di presentazione, diapositiva o riquadro di testo.

{{% alert color="info" title="Note" %}}
Puoi anche modificare le presentazioni con l'[editor PowerPoint online gratuito di Aspose](https://products.aspose.app/slides/it/editor).
{{% /alert %}} 

## **Aggiungere collegamenti ipertestuali URL**

È possibile assegnare un URL di sito web a testo, forma o riquadro multimediale. L'elemento a cui si assegna il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un riquadro collega l'oggetto della diapositiva.

### **Aggiungere collegamenti ipertestuali URL al testo**

Per collegare del testo a un sito web, passare un [Hyperlink](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/hyperlink/) al metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti ipertestuali URL a forme e riquadri multimediali**

Per rendere una forma o un riquadro cliccabile, chiamare il metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Il collegamento appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio vale per riquadri immagine, audio e video: assegnare il collegamento al riquadro e, se necessario, chiamare [setTooltip](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-).

L'esempio seguente rende cliccabile un rettangolo:

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

## **Usare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [setInternalHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) per collegare il testo “Page 2” nella prima diapositiva alla seconda diapositiva.

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

## **Formattare i collegamenti ipertestuali**

### **Colore**

Il metodo [setColorSource](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) di [IHyperlink](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/) determina se un collegamento utilizza il colore dei collegamenti della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, selezionare [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/hyperlinkcolorsource/) e impostare il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

L'esempio seguente aggiunge due collegamenti ipertestuali di testo alla stessa diapositiva. Il primo utilizza un riempimento di testo rosso, mentre il secondo mantiene il colore predefinito dei collegamenti.

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
### **Suono**

Un collegamento ipertestuale può riprodurre un suono quando attivato o fermare un suono già in riproduzione. Utilizzare i seguenti metodi per configurare questi comportamenti:

- [IHyperlink.setSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specifica l'audio associato al collegamento.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) controlla se l'attivazione del collegamento interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L'esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante nella prima diapositiva. Cliccando il pulsante il suono viene riprodotto e si passa alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente quando viene cliccata, senza eseguire alcuna azione di navigazione.

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

#### **Estrarre il suono di un collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l'audio del collegamento della prima forma in memoria tramite [getSound](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getSound--) e [getBinaryData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Impostazioni di tooltip e interazione**

È possibile chiamare i seguenti metodi di [IHyperlink](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/) dopo aver assegnato un collegamento a testo o forma:

- [setTooltip](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) imposta il testo che lo spettatore può visualizzare come suggerimento per il collegamento.
- [setTargetFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) specifica il frame di destinazione all'interno di un frameset HTML genitore, se applicabile.
- [setHistory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) controlla se l'attivazione del collegamento aggiunge la destinazione all'elenco dei collegamenti visualizzati.
- [setHighlightClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) controlla se il collegamento è evidenziato quando viene cliccato.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Utilizzare [getAnyHyperlinks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) per raccogliere i contenitori di collegamenti, inclusi i collegamenti di porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiamare solo [removeHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); rimuovere l'azione di click non rimuove la corrispondente azione di mouse-over.

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

Per una rimozione incondizionata, [removeAllHyperlinks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) rimuove entrambi i tipi di attivazione nello scope selezionato con una singola chiamata. Per una pulizia selettiva e una copertura di master, layout e note, vedere [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, effettuare l'inventario delle sue azioni interattive così come dei suoi collegamenti web. [getAnyHyperlinks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispezionare sia [getHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) sia [getHyperlinkMouseOver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) su ogni contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un rapporto completo richiede fino a due righe per contenitore.

Scansionare solo i collegamenti a livello di forma può far perdere i collegamenti allegati a porzioni di testo. Interrogare lo scope appropriato e conservare i contenitori restituiti in modo da poter aggiornare o rimuovere le loro azioni in seguito.

### **Interrogare i scope di presentazione, diapositiva e riquadro di testo**

L'interfaccia [IHyperlinkQueries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/) è disponibile tramite [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) e [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Ogni scope supporta le stesse interrogazioni:

- [getHyperlinkClicks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) restituisce i contenitori con un'azione di click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) restituisce i contenitori con un'azione di mouse-over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) restituisce i contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento click esterno, un collegamento file mouse-over, navigazione interna diapositive, un collegamento mouse-over su testo e un'azione macro. Non esegue nessuna di queste azioni. Le tre stesse interrogazioni funzionano in ogni scope; i conteggi descrivono contenitori, non il totale delle azioni. Lo scope del riquadro di testo esclude i collegamenti della forma contenente.

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

Per questo esempio, le interrogazioni su presentazione e diapositiva riportano ciascuna tre contenitori click, due contenitori mouse-over e tre contenitori con almeno una delle due azioni. L'interrogazione sul riquadro di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usare [IHyperlink.getActionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getActionType--) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; ispeziona l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione della presentazione incorporata, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termina lo spettacolo corrente o avvia uno spettacolo personalizzato. |
| `StartMacro` | Esegue una macro. |
| `StartProgram` | Avvia un programma. |
| `OpenFile`, `OpenPresentation` | Apri un file o un'altra presentazione; da esaminare separatamente dagli URL web. |
| `StartStopMedia` | Avvia o ferma la riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggere le destinazioni esterne da [getExternalUrl](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) e le destinazioni interne specifiche da [getTargetSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Le azioni interne e i comandi incorporati possono non avere un URL esterno; un URL vuoto non significa che il contenitore non abbia azione. Conservare il valore restituito da [getExternalUrlOriginal](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) quando differisce dall'URL normalizzato, e includere il tooltip restituito da [getTooltip](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) se disponibile.

### **Report, sanificare e verificare i collegamenti ipertestuali**

L'esempio Java seguente legge una presentazione esistente (utilizzare il file creato sopra), scrive `hyperlink-audit.json`, applica una politica, salva `hyperlink-sanitized.pptx` e lo riapre per controllare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e usa l'uguaglianza di riferimento per evitare di processare lo stesso contenitore due volte. Le interrogazioni su presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, intervengono anche esplicitamente su master, layout, note e sui master di note e di handout quando presenti.

Il report registra un indice di diapositiva basato su 1 e [getSlideId](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) dove disponibile. [ISlideComponent.getSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecomponent/#getSlide--) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati per scope. I contenitori di forma e i contenitori di formattazione di porzioni di testo sono etichettati separatamente; altri tipi di contenitore mantengono il nome del tipo a runtime. Ogni contenitore ottiene un ID locale al report così le sue due azioni possono essere correlate. Il report memorizza i tipi di azione come costanti intere definite dall'enumerazione Java.

Questa politica applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e destinazioni diapositive interne valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di politica, non un giudizio di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungi liste di host consentiti e altri controlli per la tua applicazione. Sia gli URL esterni originali sia quelli normalizzati sono verificati. L'esempio esamina i metadati senza seguire i collegamenti o eseguire azioni.

Per la correzione, il [getHyperlinkManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) del contenitore supporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Qui, i collegamenti click esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; gli altri click proibiti e le azioni mouse-over proibite sono rimossi in modo indipendente. Impostare `replaceExternalClicks` a `false` per rimuovere tutte le violazioni di politica. Scegli una pagina di sostituzione gestita dall'applicazione prima del dispiegamento.

Il flag di esportazione del report utilizza una politica di revisione PDF conservativa: segnala le azioni mouse-over e tutto ciò che non è un collegamento esterno o un salto di diapositiva specifico come potenzialmente non supportato. È un suggerimento di revisione, non un test di capacità o una garanzia che i collegamenti non segnalati sopravviveranno all'esportazione. Le esportazioni PDF e HTML supportate possono preservare i collegamenti, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Immagini raster e video non possono preservare collegamenti interattivi; segnala ogni azione quando esegui l'audit per questi output.

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

    // Serializza le righe piatte di questo report senza una dipendenza JSON aggiuntiva.
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

Con l'input creato sopra, il report contiene cinque righe di azione. Il collegamento file mouse-over e la macro click sono rimossi, mentre i collegamenti HTTPS e la navigazione interna rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL click esterno proibito esercita anche il ramo di sostituzione. Un contenitore con click consentito e mouse-over proibito conserva la sua azione click.

Questa pulizia selettiva differisce da [removeAllHyperlinks](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), che rimuove entrambi i tipi di attivazione in tutti gli scope selezionati indipendentemente dalla politica. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altri contenuti attivi, né convalida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegarmi a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collegarsi alla prima diapositiva di quella sezione.

**Posso allegare un collegamento ipertestuale agli elementi del master slide in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master slide e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video non possono. Vedi le considerazioni sull'esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).