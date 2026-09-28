---
title: Gestire i master delle diapositive della presentazione in JavaScript
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/nodejs-java/slide-master/
keywords:
- master diapositiva
- slide master
- slide master PPT
- slide master multipli
- confronta slide master
- sfondo
- segnaposto
- clona slide master
- copia slide master
- duplica slide master
- slide master non utilizzata
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i master delle diapositive in Aspose.Slides per Node.js via Java: accedi, modifica, clona, confronta e rimuovi le slide master nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare uno slide master è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Node.js via Java supporta lo stesso modello. Una presentazione può contenere una o più slide master, e ogni slide master può contenere diverse slide di layout. Le slide normali di solito non fanno riferimento direttamente a uno slide master. Invece, una slide normale utilizza una slide di layout, e quella slide di layout appartiene a uno slide master.

La gerarchia è:

1. **Slide master** - definisce il design condiviso e il tema.  
1. **Layout slide** - definisce una disposizione specifica di segnaposto e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto reale della presentazione e utilizza una slide di layout.  

![La gerarchia di slide master, layout slide e slide normali](slide-master_2.jpg)

In Aspose.Slides, uno slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/). Tutte le slide master in una presentazione sono disponibili tramite la collezione `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, vince il livello più specifico. Per esempio, se uno slide master e una layout slide definiscono entrambi uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle slide di layout, vedere [Applica o Cambia Layout Diapositive](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Accedi agli Slide Master**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda View di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizzare la collezione `getMasters()` per accedere alle slide master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

È inoltre possibile ottenere lo slide master usato da una slide normale tramite il suo layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Cosa contiene uno Slide Master**

Uno slide master è un oggetto simile a una diapositiva. Eredita il comportamento comune delle diapositive da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà delle diapositive usate dalle slide normali e di layout. I membri specifici del master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/).

I membri più comunemente usati includono:

| Membro | Scopo |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della slide a livello di master. |
| `getShapes()` | Memorizza le forme posizionate sul master, come loghi, cornici immagine e testo condiviso. |
| `getLayoutSlides()` | Memorizza le slide di layout che appartengono al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema del master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le slide normali che dipendono dal master tramite i loro layout. |

## **Aggiungi un'immagine a uno Slide Master**

Quando aggiungi un'immagine a uno slide master, essa appare sulle diapositive che utilizzano i layout di quel master. Questo è utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo al primo slide master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori informazioni sui riquadri immagine, vedere [Riquadro Immagine](/nodejs-java/picture-frame/).

## **Controlla la visibilità della grafica del Master**

Utilizza [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) per nascondere la grafica master ereditata, come loghi o forme decorative, senza eliminarla dal master. Passa `false` a [Slide.setShowMasterShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#setShowMasterShapes) sulla diapositiva che deve omettere tali grafiche e mantienilo `true` sulle diapositive che devono visualizzarle.

Il seguente esempio autonomo crea una banda decorativa blu su un master e due diapositive che utilizzano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposto della diapositiva iniziale.

### **Scegliere l'ambito dell'impostazione**

Una slide normale utilizza il suo master tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `false` a [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) nasconde la grafica del master per le diapositive che usano quel layout condiviso, anche se la loro impostazione è `true`. Per nascondere la grafica su una sola diapositiva, modifica la proprietà della diapositiva e lascia invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sullo slide master stesso. Su un master, [getShowMasterShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) restituisce sempre `false`, e passare `true` a [setShowMasterShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) genera un'eccezione. Applicala invece a una slide normale o a un layout.

### **Distinguere la grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondi la grafica del master | Controlla la visibilità delle forme master ereditate senza eliminarle o modificare le forme proprie della diapositiva. |
| Cambia il riempimento di sfondo della diapositiva | Cambia il colore, il gradiente o l'immagine di sfondo. La grafica del master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedi [Presentation Background](/slides/it/nodejs-java/presentation-background/). |
| Elimina una forma dal master | Rimuove la forma sorgente condivisa, così non è più disponibile per nessuna diapositiva che usa quel master. |

## **Lavorare con i segnaposto**

I segnaposto sono normalmente definiti sulle slide di layout. Lo slide master fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposto sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposto sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposto con Aspose.Slides, lavora con la slide di layout che appartiene al master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

È inoltre possibile formattare forme segnaposto già presenti su uno slide master. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Segnaposto titolo formattato ereditato dalle slide normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposto e testo, vedere [Imposta Testo di Prompt nel Segnaposto](/nodejs-java/manage-placeholder/) e [Formattazione del Testo](/nodejs-java/text-formatting/).

## **Modifica lo sfondo di uno Slide Master**

Uno sfondo master è ereditato dai layout e dalle diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo slide master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per argomenti correlati, vedere [Sfondo della Presentazione](/nodejs-java/presentation-background/) e [Tema della Presentazione](/nodejs-java/presentation-theme/).

## **Clona uno Slide Master in un'altra presentazione**

Usa `MasterSlideCollection.addClone` per copiare uno slide master in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Se hai bisogno di clonare le diapositive normali insieme al loro master, vedere [Clona Diapositive](/nodejs-java/clone-slides/).

## **Aggiungi più Slide Master**

Una presentazione può contenere più slide master. Questo è utile quando diverse sezioni richiedono branding, struttura di pagina o impostazioni di tema differenti.

![Comandi PowerPoint per inserire e gestire slide master](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Confronta gli Slide Master**

Gli slide master possono essere confrontati con il metodo `equals` ereditato da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori univoci, come gli ID delle diapositive, né valori dinamici dei segnaposto, come la data corrente.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Per ulteriori informazioni, vedere [Confronta Diapositive della Presentazione](/slides/it/nodejs-java/compare-slides/).

## **Imposta la visualizzazione Slide Master come visualizzazione predefinita**

Usa il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. Il seguente esempio apre la presentazione in visualizzazione Slide Master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per ulteriori impostazioni di visualizzazione, vedere [Salva Presentazione](/slides/it/nodejs-java/save-presentation/).

## **Rimuovi Slide Master non utilizzate**

Le presentazioni a volte contengono slide master che non sono più usati da alcuna slide normale. Rimuovere i master non usati può ridurre le dimensioni del file e semplificare la manutenzione del modello.

Usa `removeUnused` per rimuovere i master non usati dalla collezione `getMasters()`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Puoi anche usare il metodo low‑code `Compress.removeUnusedMasterSlides`:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra uno slide master e una layout slide?**  
Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a uno slide master e definisce una disposizione specifica di segnaposto. Una slide normale usa una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi slide master?**  
Sì. Una presentazione può contenere diversi slide master. Usa più master quando diverse sezioni necessitano di sistemi visivi o branding differenti.

**Dovrei aggiungere segnaposto a uno slide master o a una layout slide?**  
Nella maggior parte dei casi, aggiungi i segnaposto alle layout slide. Metti gli elementi visivi condivisi e la formattazione condivisa sullo slide master, poi inserisci i segnaposto di contenuto sui layout che le slide normali utilizzeranno.

**Posso eliminare uno slide master ancora in uso?**  
No. Uno slide master che ha diapositive dipendenti non può essere rimosso in modo sicuro direttamente. Prima sposta quelle diapositive a layout sotto un altro master, oppure utilizza un metodo di pulizia dei master non usati che rimuove solo i master che non sono in uso.