---
title: Gestire i collegamenti ipertestuali delle presentazioni in Java
linktitle: Gestire i collegamenti ipertestuali
type: docs
weight: 20
url: /it/java/manage-hyperlinks/
keywords:
- aggiungere URL
- aggiungere collegamento ipertestuale
- creare collegamento ipertestuale
- formattare collegamento ipertestuale
- rimuovere collegamento ipertestuale
- aggiornare collegamento ipertestuale
- collegamento ipertestuale nel testo
- collegamento ipertestuale nella diapositiva
- collegamento ipertestuale nella forma
- collegamento ipertestuale immagine
- collegamento ipertestuale video
- collegamento ipertestuale modificabile
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Aggiungere, formattare, aggiornare e rimuovere i collegamenti ipertestuali nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Java, utilizzando esempi Java."
---
## **Introduzione**

Un collegamento ipertestuale collega il contenuto della presentazione a un sito web o a una posizione all'interno della presentazione. In PowerPoint, i collegamenti ipertestuali comunemente servono a due scopi:

* Aprire un sito web da testo, forma o fotogramma multimediale.  
* Navigare a un'altra diapositiva, ad esempio da un indice.

Aspose.Slides for Java consente di aggiungere questi collegamenti, controllarne l'aspetto e il suono, aggiornare le proprietà e rimuoverli. Gli esempi seguenti mostrano come lavorare con i collegamenti ipertestuali su elementi individuali e come accedere ai collegamenti a livello di presentazione, diapositiva o fotogramma di testo.

{{% alert color="info" title="Note" %}}
Puoi anche modificare le presentazioni con l'[editor gratuito online Aspose PowerPoint](https://products.aspose.app/slides/it/editor).
{{% /alert %}} 

## **Aggiungere collegamenti ipertestuali URL**

Puoi assegnare un URL di sito web a testo, forma o fotogramma multimediale. L'elemento a cui assegni il collegamento ipertestuale determina l'area cliccabile: una porzione di testo collega il testo selezionato, mentre una forma o un fotogramma collega l'oggetto della diapositiva.

### **Aggiungere collegamenti ipertestuali URL al testo**

Per collegare del testo a un sito web, passa un [Hyperlink](https://reference.aspose.com/slides/it/java/com.aspose.slides/hyperlink/) al metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) della porzione di testo, come mostrato di seguito. Solo quella porzione di testo diventa cliccabile.

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

### **Aggiungere collegamenti ipertestuali URL a forme e fotogrammi multimediali**

Per rendere una forma o un fotogramma cliccabile, chiama il suo metodo [setHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-). Il collegamento ipertestuale appartiene all'oggetto stesso anziché a una porzione di testo al suo interno.

Lo stesso approccio si applica a fotogrammi di immagine, audio e video: assegna il collegamento al fotogramma e chiama [setTooltip](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) se necessario.

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

## **Utilizzare i collegamenti ipertestuali per creare un indice**

I collegamenti ipertestuali interni consentono ai lettori di passare da un indice a una diapositiva specifica. L'esempio seguente utilizza [setInternalHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) per collegare il testo “Page 2” sulla prima diapositiva alla seconda diapositiva.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Il metodo [setColorSource](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setColorSource-int-) di [IHyperlink] determina se un collegamento ipertestuale utilizza il colore dei collegamenti ipertestuali della presentazione o la formattazione della porzione di testo. Per applicare un colore di testo personalizzato, seleziona [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/hyperlinkcolorsource/) e imposta il colore di riempimento della porzione. Questa funzionalità è stata introdotta in PowerPoint 2019; le versioni precedenti non applicano questa impostazione.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Un collegamento ipertestuale può riprodurre un suono quando attivato o interrompere un suono già in riproduzione. Usa i seguenti metodi per configurare questi comportamenti:

- [IHyperlink.setSound](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specifica l'audio associato al collegamento ipertestuale.  
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) controlla se l'attivazione del collegamento ipertestuale interrompe il suono precedente.

#### **Aggiungere un suono al collegamento ipertestuale**

L'esempio seguente carica `sampleaudio.wav` e lo associa a un pulsante sulla prima diapositiva. Il clic sul pulsante riproduce il suono e naviga alla diapositiva successiva. Una seconda forma su quella diapositiva interrompe il suono precedente al clic, senza effettuare alcuna azione di navigazione.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

#### **Estrarre un suono da un collegamento ipertestuale**

L'esempio seguente apre la presentazione creata sopra e legge l'audio del collegamento ipertestuale della prima forma in memoria tramite [getSound](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getSound--) e [getBinaryData](https://reference.aspose.com/slides/it/java/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Suggerimento e impostazioni di interazione**

Puoi chiamare i seguenti metodi di [IHyperlink] dopo aver assegnato un collegamento ipertestuale a testo o forma:

- [setTooltip](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) imposta il testo che un visualizzatore può mostrare come suggerimento per il collegamento.  
- [setTargetFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) specifica il fotogramma di destinazione all'interno di un frameset HTML padre, quando applicabile.  
- [setHistory](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) controlla se l'attivazione del collegamento aggiunge la sua destinazione all'elenco dei collegamenti ipertestuali visualizzati.  
- [setHighlightClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) controlla se il collegamento è evidenziato al clic.

## **Rimuovere i collegamenti ipertestuali dalle presentazioni**

Usa [getAnyHyperlinks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) per raccogliere i contenitori di collegamenti, inclusi i collegamenti di porzioni di testo, prima di modificarli. L'esempio seguente rimuove entrambi i tipi di attivazione dalla prima diapositiva. Per rimuovere solo un tipo, chiama solo [removeHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) o [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); la rimozione di un'azione di clic non elimina la controparte al passaggio del mouse.

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

Per una rimozione incondizionata, [removeAllHyperlinks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) rimuove entrambi i tipi di attivazione nello scope selezionato in una singola chiamata. Per una pulizia selettiva e la copertura di master, layout e note, vedi [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Creare un inventario completo dei collegamenti ipertestuali**

Prima di distribuire una presentazione, inventaria le sue azioni interattive così come i collegamenti web. [getAnyHyperlinks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) restituisce oggetti [IHyperlinkContainer](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/), non un elenco piatto di stringhe URL. Ispeziona sia [getHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) sia [getHyperlinkMouseOver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) su ciascun contenitore. Sono indipendenti: lo stesso contenitore può esporre entrambe le azioni, quindi un report completo richiede fino a due righe per contenitore.

L'analisi solo a livello di forma può omettere collegamenti allegati a porzioni di testo. Interroga lo scope appropriato invece, e conserva i contenitori restituiti così da poterli aggiornare o rimuovere successivamente.

### **Interrogare gli ambiti di presentazione, diapositiva e fotogramma di testo**

L'interfaccia [IHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/) è disponibile tramite [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) e [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/it/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Ogni ambito supporta le stesse query:

- [getHyperlinkClicks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) restituisce contenitori con un'azione di clic.  
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) restituisce contenitori con un'azione al passaggio del mouse.  
- [getAnyHyperlinks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) restituisce contenitori con una o entrambe le azioni.

L'esempio seguente crea `hyperlink-audit-input.pptx` con un collegamento di clic esterno, un collegamento al passaggio del mouse su un file, una navigazione interna di diapositiva, un collegamento al passaggio del mouse su testo e un'azione macro. Non esegue nessuna di queste azioni. Le tre query funzionano in ogni ambito; i conteggi descrivono contenitori, non totali di azioni. Lo scope del fotogramma di testo esclude i collegamenti della forma contenitrice.

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

Per questo esempio, le query di presentazione e diapositiva riportano ciascuna tre contenitori di clic, due di passaggio del mouse e tre contenitori con una delle due azioni. La query del fotogramma di testo riporta un contenitore in ciascuna categoria.

### **Classificare azioni e destinazioni**

Usa [IHyperlink.getActionType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getActionType--) per interpretare un'azione prima di interpretare la sua destinazione. I valori di [HyperlinkActionType](https://reference.aspose.com/slides/it/java/com.aspose.slides/hyperlinkactiontype/) coprono più della semplice navigazione web:

| Valori | Significato per un audit |
| --- | --- |
| `Hyperlink` | Collegamento ipertestuale esterno; ispeziona l'URL e il suo schema. |
| `JumpSpecificSlide` | Navigazione interna a una diapositiva specifica. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Navigazione integrata della presentazione, risolta nel contesto della presentazione. |
| `JumpEndShow`, `StartCustomSlideShow` | Termine della presentazione corrente o avvio di una presentazione personalizzata. |
| `StartMacro` | Esecuzione di una macro. |
| `StartProgram` | Avvio di un programma. |
| `OpenFile`, `OpenPresentation` | Apertura di un file o di un'altra presentazione; da revisionare separatamente dagli URL web. |
| `StartStopMedia` | Avvio o interruzione della riproduzione multimediale. |
| `NoAction`, `Unknown` | Nessuna azione di navigazione, o un'azione non riconosciuta che richiede revisione. |

Leggi le destinazioni esterne da [getExternalUrl](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getExternalUrl--) e le destinazioni interne specifiche da [getTargetSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Le azioni interne e i comandi integrati potrebbero non avere un URL esterno; un URL vuoto non significa che il contenitore sia privo di azione. Conserva il valore restituito da [getExternalUrlOriginal](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) quando differisce dall'URL normalizzato, e includi il suggerimento restituito da [getTooltip](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlink/#getTooltip--) quando disponibile.

### **Report, Sanitize, and Verify Hyperlinks**

L'esempio Java seguente legge una presentazione esistente (usa il file creato sopra), scrive `hyperlink-audit.json`, applica una policy, salva `hyperlink-sanitized.pptx` e lo riapre per controllare nuovamente entrambi i tipi di attivazione. Raccoglie i contenitori prima di modificarli e utilizza l'uguaglianza di riferimento per evitare di processare lo stesso contenitore più volte. Le query di presentazione coprono le diapositive ordinarie; per un inventario a livello di pacchetto, vengono interrogati esplicitamente master, layout, note e i master di note e di dispense quando presenti.

Il report registra un indice di diapositiva basato su 1 e [getSlideId](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getSlideId--) dove disponibile. [ISlideComponent.getSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidecomponent/#getSlide--) fornisce la diapositiva proprietaria per i contenitori supportati. I master, i layout e le note non hanno un indice di diapositiva ordinario e sono identificati per il loro ambito. I contenitori di forma e i contenitori di formattazione di porzioni di testo sono etichettati separatamente; gli altri tipi di contenitore mantengono il loro nome di tipo a runtime. Ogni contenitore ottiene un ID locale al report così le sue due azioni possono essere correlate. Il report memorizza i tipi di azione come le costanti intere definite dall'enumerazione Java.

Questa policy applicativa deliberatamente restrittiva consente solo URL HTTPS assoluti e destinazioni interne di diapositiva valide. Rifiuta macro, programmi, azioni su file, altre azioni di presentazione, azioni sconosciute e altri schemi URL. Questi rifiuti sono decisioni di policy, non un verdetto di sicurezza di Aspose.Slides. HTTPS da solo non stabilisce fiducia: aggiungi whitelist di host e altri controlli per la tua applicazione. Sia gli URL esterni originali che quelli normalizzati sono verificati. L'esempio controlla i metadati senza seguire i link o eseguire azioni.

Per la rimedizione, il [getHyperlinkManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) del contenitore supporta [setExternalHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) e [removeHyperlinkMouseOver](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Qui, i collegamenti di clic esterni proibiti sono sostituiti con una pagina di destinazione HTTPS fissa; gli altri clic proibiti e le azioni di passaggio del mouse proibite sono rimossi indipendentemente. Imposta `replaceExternalClicks` a `false` per rimuovere tutte le violazioni di policy. Scegli una pagina di sostituzione di proprietà dell'applicazione prima della distribuzione.

Il flag di esportazione del report utilizza una policy di revisione PDF conservativa: segna le azioni di passaggio del mouse e qualsiasi cosa diversa da un collegamento esterno o da un salto di diapositiva specifico come potenzialmente non supportata. È un suggerimento di revisione, non un test di capacità o una garanzia che i link non segnalati sopravvivranno all'esportazione. Le esportazioni PDF e HTML supportate ([PDF](/slides/it/java/convert-powerpoint-to-pdf/) e [HTML](/slides/it/java/convert-powerpoint-to-html/)) possono preservare i collegamenti ipertestuali, a seconda dell'azione, delle opzioni di esportazione e del visualizzatore. Le immagini raster ([images](/slides/it/java/convert-powerpoint-to-png/)) e i video ([video](/slides/it/java/convert-powerpoint-to-video/)) non possono preservare collegamenti interattivi; segna ogni azione quando effettui l'audit per tali output.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

Con l'input creato sopra, il report contiene cinque righe di azione. Il collegamento di passaggio del mouse su file e il clic macro sono rimossi, mentre i link HTTPS e la navigazione interna di diapositiva rimangono. La verifica stampa zero azioni proibite. Un input contenente un URL di clic esterno proibito esercita anche il ramo di sostituzione. Un contenitore con un clic consentito e un passaggio del mouse proibito mantiene il suo clic.

Questa pulizia selettiva differisce da [removeAllHyperlinks](https://reference.aspose.com/slides/it/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), che rimuove entrambi i tipi di attivazione nello scope selezionato indipendentemente dalla policy. La verifica qui controlla solo le azioni dei collegamenti ipertestuali; non rimuove progetti VBA incorporati, oggetti OLE o altri contenuti attivi, e non valida un file PDF o HTML esportato.

## **FAQ**

**Come posso collegare a una sezione o alla sua prima diapositiva?**

Le sezioni in PowerPoint raggruppano le diapositive, ma un collegamento ipertestuale interno punta a una singola diapositiva. Per creare una navigazione a una sezione, collega alla prima diapositiva di quella sezione.

**Posso aggiungere un collegamento ipertestuale agli elementi del master in modo che funzioni su tutte le diapositive?**

Sì. Gli elementi del master e del layout supportano i collegamenti ipertestuali. I collegamenti su questi elementi sono disponibili durante la presentazione sulle diapositive che utilizzano il master o il layout corrispondente.

**I collegamenti ipertestuali saranno preservati durante l'esportazione in PDF, HTML, immagini o video?**

Le esportazioni PDF e HTML supportate possono preservare i collegamenti ipertestuali; le immagini raster e i video no. Vedi le considerazioni sull'esportazione in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).