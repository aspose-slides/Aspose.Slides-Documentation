---
title: Operazioni di presentazione low-code in JavaScript
linktitle: API low-code
type: docs
weight: 50
url: /it/nodejs-java/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- conversione presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master slide inutilizzati
- rimuovere layout slide inutilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in JavaScript per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi `aspose.slides` fornisce classi helper statiche per le operazioni comuni sulle presentazioni. Questi helper incapsulano i flussi di lavoro dell’object‑model più usati in metodi mirati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Gli helper low‑code sono più utili quando l’operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza l’intero [Aspose.Slides object model](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/) quando hai bisogno di un controllo granulare su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga gli helper disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretto file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/) | Combinazione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) | Esecuzione di un’azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/) | Recupero delle forme dall’intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) | Rimozione di master e layout inutilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Utilizza [Convert.autoByExtension](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/#autoByExtension) quando l’estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato necessario dal percorso di output e scrive il risultato.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/) fornisce inoltre metodi dedicati per l’output PDF, SVG, JPEG, PNG e TIFF. Utilizza l’intero object model quando è necessario ispezionare o modificare la presentazione prima dell’esportazione o configurare un’opzione di esportazione non esposta dall’helper selezionato. Vedi [Convert Presentation](/slides/it/nodejs-java/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Utilizza [Merger.process](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/#process) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

L’helper è appropriato quando tutte le diapositive devono essere aggiunte a un unico risultato senza selezionarle o rimapparle individualmente. Usa l’intero object model quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o riconciliare dimensioni di diapositiva diverse. Vedi [Merge Presentations](/slides/it/nodejs-java/merge-presentation/) per tali scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) invoca una callback per ogni tipo richiesto di elemento della presentazione. Evita i cicli di raccolta nidificati ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione. In Node.js, crea implementazioni delle interfacce di callback con `java.newProxy`.

L’esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#portion) per ispezionare gli elementi corrispondenti:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Per impostazione predefinita, la traversata di forme e testo a livello di presentazione include diapositive normali, master e layout. Le overload con un parametro `includeNotes` possono inoltre elaborare le diapositive delle note. Usa cicli di raccolta diretti quando l’ordine di traversata, l’uscita anticipata, il filtraggio prima della chiamata della callback o il controllo dettagliato genitore‑figlio sono importanti.

## **Raccogliere forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/#shapes) quando ti serve una collezione di tutte le forme in una presentazione anziché una callback per ogni forma. È utile quando lo stesso insieme sarà filtrato, contato o elaborato più volte.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Utilizza [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) rimuove le diapositive di layout non referenziate da alcuna diapositiva normale.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) rimuove i master non più utilizzati.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) rimuove i caratteri inutilizzati dai font incorporati.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rimuovi prima i layout inutilizzati e poi i master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso anch’esso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout o dei dati completi dei font incorporati originali. Per maggiori dettagli, vedi [Slide Master](/slides/it/nodejs-java/slide-master/) e [Embedded Font](/slides/it/nodejs-java/embedded-font/).

## **FAQ**

**Quando dovrei usare l’API low‑code invece dell’intero object model?**

Usa gli helper low‑code quando un’operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato sui singoli elementi. Usa l’intero object model quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti che l’helper non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/#process) richiede che le presentazioni di input siano nello stesso formato. Converte prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/#autoByExtension), e poi unisci i file convertiti.

**ForEach elabora master, layout e diapositive delle note?**

[ForEach.slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#slide) itera le diapositive di presentazione normali. Le operazioni a livello di presentazione di [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#portion) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro overload con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape) per elaborare ogni forma immediatamente tramite una callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/#shapes) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre il file della presentazione più piccolo?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi elementi è presente, le relative operazioni di [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi helper operano sull’oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/slides/it/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/it/nodejs-java/merge-presentation/)
- [Slide Master](/slides/it/nodejs-java/slide-master/)
- [Manage Text Box](/slides/it/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/it/nodejs-java/embedded-font/)