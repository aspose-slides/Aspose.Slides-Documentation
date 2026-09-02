---
title: Gestire i master slide della presentazione in JavaScript
linktitle: Master slide
type: docs
weight: 70
url: /it/nodejs-java/slide-master/
keywords:
- master slide
- master slide
- master slide PPT
- master slide multipli
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide inutilizzato
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestire i master slide in Aspose.Slides per Node.js via Java: accedere, modificare, clonare, confrontare e rimuovere i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare uno slide master è il modo abituale per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Node.js tramite Java supporta lo stesso modello. Una presentazione può contenere una o più master slide, e ogni master slide può contenere diverse layout slide. Le slide normali di solito non fanno riferimento direttamente a un master slide. Invece, una slide normale usa una layout slide, e quella layout slide appartiene a un master slide.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Normal slide** – contiene il contenuto effettivo della presentazione e usa una layout slide.

![La gerarchia di master slide, layout slide e slide normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/). Tutti i master slide in una presentazione sono disponibili tramite la collezione `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Quando la stessa proprietà è definita a più di un livello, vince il livello più specifico. Per esempio, se un master slide e una layout slide definiscono entrambe uno sfondo, le slide basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Accedi ai Master Slide**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usare la collezione `getMasters()` per accedere ai master slide:

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

È inoltre possibile ottenere il master slide utilizzato da una slide normale tramite il suo layout:

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

## **Cosa contiene un Slide Master**

Un master slide è un oggetto simile a una diapositiva. Eredita il comportamento comune delle diapositive da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà usate da slide normali e layout slide. I membri specifici del master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/).

I membri del master slide più comunemente usati includono:

| Member | Purpose |
| --- | --- |
| `getBackground()` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes()` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `getLayoutSlides()` | Memorizza le layout slide che appartengono al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figlio. |
| `getDependingSlides()` | Restituisce le slide normali che dipendono dal master attraverso i loro layout. |

## **Aggiungi un'immagine a uno Slide Master**

Quando si aggiunge un'immagine a un master slide, essa appare sulle slide che usano i layout di quel master. È utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

Il seguente esempio aggiunge un logo al primo master slide:

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

Per ulteriori informazioni sulle cornici di immagini, vedere [Picture Frame](/nodejs-java/picture-frame/).

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella vista Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sulla layout slide che appartiene al master:

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

È inoltre possibile formattare le forme segnaposto già presenti su un master slide. Il seguente esempio trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

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

Per altre opzioni di formattazione di segnaposti e testo, vedere [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) e [Text Formatting](/nodejs-java/text-formatting/).

## **Modifica lo sfondo di uno Slide Master**

Uno sfondo master è ereditato da layout e slide che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master slide:

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

Per argomenti correlati, vedere [Presentation Background](/nodejs-java/presentation-background/) e [Presentation Theme](/nodejs-java/presentation-theme/).

## **Clona uno Slide Master in un'altra presentazione**

Usare `MasterSlideCollection.addClone` per copiare un master slide in un'altra presentazione. Il master copiato può quindi essere usato da layout e slide nella presentazione di destinazione.

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

Se è necessario clonare slide normali insieme al loro master, vedere [Clone Slides](/nodejs-java/clone-slides/).

## **Aggiungi più Slide Master**

Una presentazione può contenere più master slide. È utile quando diverse sezioni richiedono brandizzazioni, strutture di pagina o impostazioni di tema differenti.

![Comandi PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea una layout sotto quel master clonato e aggiunge una nuova slide basata su quel layout:

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

## **Confronta Slide Master**

I master slide possono essere confrontati con il metodo `equals` ereditato da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della slide. Non confronta identificatori univoci, come gli ID delle slide, né valori dinamici dei segnaposti, come la data corrente.

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

Per ulteriori informazioni, vedere [Compare Presentation Slides](/slides/it/nodejs-java/compare-slides/).

## **Imposta la vista Slide Master come vista predefinita**

Usare il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/) per controllare la vista che PowerPoint apre per prima. Il seguente esempio apre la presentazione in visualizzazione Slide Master:

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

Per altre impostazioni di visualizzazione, vedere [Save Presentation](/slides/it/nodejs-java/save-presentation/).

## **Rimuovi i master slide inutilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da alcuna slide normale. Rimuovere i master inutilizzati può ridurre le dimensioni del file e semplificare la manutenzione dei modelli.

Usare `removeUnused` per rimuovere i master inutilizzati dalla collezione `getMasters()`:

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

È inoltre possibile utilizzare il metodo low‑code `Compress.removeUnusedMasterSlides`:

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

### Qual è la differenza tra uno slide master e una layout slide?

Uno slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a un master slide e definisce una disposizione specifica di segnaposti. Una slide normale usa una layout slide, quindi eredita sia dal layout sia dal master.

### Può una presentazione contenere più slide master?

Sì. Una presentazione può contenere più slide master. Usare più master quando diverse sezioni necessitano di sistemi visivi o branding differenti.

### Dovrei aggiungere segnaposti a un master slide o a una layout slide?

Nella maggior parte dei casi, aggiungere segnaposti alle layout slide. Mettere gli elementi visivi condivisi e la formattazione comune sul master slide, quindi inserire i segnaposti di contenuto sulle layout che le slide normali utilizzeranno.

### Posso eliminare un master slide ancora in uso?

No. Un master slide che ha slide dipendenti non può essere rimosso in modo sicuro direttamente. Prima sposta quelle slide su layout sotto un altro master, oppure usa un metodo di pulizia dei master inutilizzati che rimuove soltanto i master non in uso.