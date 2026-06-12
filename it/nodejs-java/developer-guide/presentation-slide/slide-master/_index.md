---
title: Gestisci i master delle diapositive della presentazione in JavaScript
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/nodejs-java/slide-master/
keywords:
- master diapositiva
- master diapositiva
- master diapositiva PPT
- più master diapositive
- confronta master diapositive
- sfondo
- segnaposto
- clona master diapositiva
- copia master diapositiva
- duplica master diapositiva
- master diapositiva non usata
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci i master delle diapositive in Aspose.Slides per Node.js via Java: accedi, modifica, clona, confronta e rimuovi i master delle diapositive nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **master diapositiva** definisce le impostazioni di progettazione condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un master diapositiva è il modo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per Node.js via Java supporta lo stesso modello. Una presentazione può contenere uno o più master diapositive, e ogni master diapositiva può contenere diversi layout diapositive. Le diapositive normali di solito non fanno riferimento direttamente a un master diapositiva. Invece, una diapositiva normale utilizza un layout diapositiva, e quel layout appartiene a un master diapositiva.

La gerarchia è:

1. **Master diapositiva** - definisce il design e il tema condivisi.  
1. **Diapositiva layout** - definisce una disposizione specifica di segnaposti e formattazione a livello di layout.  
1. **Diapositiva normale** - contiene il contenuto effettivo della presentazione e utilizza un layout.

![La gerarchia di master diapositive, layout diapositive e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, un master diapositiva è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/). Tutti i master diapositive in una presentazione sono disponibili tramite la collezione `Presentation.getMasters()`.

{{% alert color="info" title="Ereditarietà" %}}
Quando la stessa proprietà è definita su più di un livello, prevale il livello più specifico. Per esempio, se un master diapositiva e un layout diapositiva definiscono entrambi uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sui layout diapositive, vedere [Applica o modifica layout delle diapositive](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Accedere ai master diapositive**

In PowerPoint, puoi aprire la vista **Visualizza** > **Master diapositiva**.

![Il comando Master diapositiva nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, usa la collezione `getMasters()` per accedere ai master diapositive:

```javascript
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

Puoi anche ottenere il master diapositiva usato da una diapositiva normale attraverso il suo layout:

```javascript
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

## **Cosa contiene un master diapositiva**

Un master diapositiva è un oggetto simile a una diapositiva. Eredita il comportamento comune delle diapositive da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà di diapositiva usate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/).

I membri più comunemente usati sono:

| Membro | Scopo |
| --- | --- |
| `getBackground()` | Imposta lo sfondo a livello di master. |
| `getShapes()` | Memorizza le forme posizionate sul master, come loghi, cornici immagine e testo condiviso. |
| `getLayoutSlides()` | Memorizza i layout diapositive appartenenti al master. |
| `getThemeManager()` | Fornisce l'accesso alle API del tema master. |
| `getHeaderFooterManager()` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides()` | Restituisce le diapositive normali che dipendono dal master attraverso i loro layout. |

## **Aggiungere un'immagine a un master diapositiva**

Quando aggiungi un'immagine a un master diapositiva, essa appare sulle diapositive che usano layout da quel master. È utile per loghi, filigrane, bande decorative e altri elementi visuali ripetuti.

Il seguente esempio aggiunge un logo al primo master diapositiva:

```javascript
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

Per ulteriori informazioni sulle cornici immagine, vedere [Cornice immagine](/nodejs-java/picture-frame/).

## **Lavorare con i segnaposti**

I segnaposti sono normalmente definiti sui layout diapositive. Il master diapositiva fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella vista **Master diapositiva**.

![Il comando Inserisci segnaposto nella vista Master diapositiva di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavora sul layout diapositiva che appartiene al master:

```javascript
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

Puoi anche formattare le forme segnaposto già presenti su un master diapositiva. Il seguente esempio trova il segnaposto titolo e applica un riempimento a gradiente lineare:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Segnaposto titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Imposta testo di prompt nel segnaposto](/nodejs-java/manage-placeholder/) e [Formattazione del testo](/nodejs-java/text-formatting/).

## **Modificare lo sfondo di un master diapositiva**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master diapositiva:

```javascript
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

Per argomenti correlati, vedere [Sfondo della presentazione](/nodejs-java/presentation-background/) e [Tema della presentazione](/nodejs-java/presentation-theme/).

## **Clonare un master diapositiva in un'altra presentazione**

Usa `MasterSlideCollection.addClone` per copiare un master diapositiva in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```javascript
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

Se devi clonare diapositive normali insieme al loro master, vedere [Clona diapositive](/nodejs-java/clone-slides/).

## **Aggiungere più master diapositive**

Una presentazione può contenere più master diapositive. È utile quando sezioni diverse richiedono branding, struttura della pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire master diapositive](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```javascript
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

## **Confrontare i master diapositive**

I master diapositive possono essere confrontati con il metodo `equals` ereditato da [BaseSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/). Il confronto verifica struttura e contenuti statici, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori univoci, come gli ID delle diapositive, o valori dinamici dei segnaposti, come la data corrente.

```javascript
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

Per ulteriori informazioni, vedere [Confronta diapositive della presentazione](/nodejs-java/compare-slides/).

## **Impostare la vista Master diapositiva come vista predefinita**

Usa il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/viewproperties/) per controllare la vista che PowerPoint apre per prima. Il seguente esempio apre la presentazione in vista **Master diapositiva**:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per altre impostazioni di visualizzazione, vedere [Salva presentazione](/nodejs-java/save-presentation/).

## **Rimuovere i master diapositive non utilizzati**

Le presentazioni a volte contengono master diapositive che non sono più usati da alcuna diapositiva normale. Rimuovere i master non usati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Usa `removeUnused` per rimuovere i master non usati dalla collezione `getMasters()`:

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra un master diapositiva e un layout diapositiva?**  
Un master diapositiva definisce le impostazioni di progettazione condivise come tema, sfondo, forme comuni e stili di testo. Un layout diapositiva appartiene a un master diapositiva e definisce una disposizione specifica di segnaposti. Una diapositiva normale usa un layout diapositiva, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi master diapositive?**  
Sì. Una presentazione può contenere diversi master diapositive. Usa più master quando sezioni diverse necessitano di sistemi visivi o branding differenti.

**Devo aggiungere i segnaposti a un master diapositiva o a un layout diapositiva?**  
Nella maggior parte dei casi, aggiungi i segnaposti ai layout diapositive. Metti gli elementi visuali condivisi e la formattazione comune sul master diapositiva, quindi aggiungi i segnaposti di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare un master diapositiva che è ancora in uso?**  
No. Un master diapositiva con diapositive dipendenti non può essere rimosso direttamente in modo sicuro. Prima sposta quelle diapositive su layout sotto un altro master, o usa un metodo di pulizia dei master non usati che rimuove solo i master non in uso.