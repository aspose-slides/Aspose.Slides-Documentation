---
title: Operazioni di presentazione a basso codice in JavaScript
linktitle: API a basso codice
type: docs
weight: 50
url: /it/nodejs-java/low-code-presentation-operations/
keywords:
- API di presentazione a basso codice
- convertire presentazione
- unire presentazioni
- iterare slide
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
description: "Utilizza l'API a basso codice di Aspose.Slides in JavaScript per convertire e unire le presentazioni, iterare il contenuto, raccogliere le forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi `aspose.slides` fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Queste utility racchiudono workflow frequenti del modello a oggetti in metodi mirati, così è possibile convertire o unire file, elaborare elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Le utility a basso codice sono più utili quando l'operazione si applica a un intero file o presentazione e il workflow predefinito soddisfa i requisiti. Utilizza il modello a oggetti completo di [Aspose.Slides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/) quando hai bisogno di un controllo fine su slide, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riepiloga le utility disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/) | Convertire una presentazione in un altro formato con una chiamata file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/) | Unire file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) | Eseguire un'azione per ogni slide, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/) | Recuperare le forme da tutta la presentazione per un'elaborazione o analisi ripetuta. |
| [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) | Rimuovere master e layout inutilizzati e ridurre i dati dei font incorporati. |

## **Convertire una presentazione**

Utilizza [Convert.autoByExtension](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/#autoByExtension) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello a oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'utility selezionata. Vedi [Convert Presentation](/nodejs-java/convert-presentation/) per workflow e opzioni specifiche per formato.

## **Unire presentazioni**

Utilizza [Merger.process](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/#process) per combinare file di presentazione completi con una sola chiamata. Le presentazioni in ingresso devono avere lo stesso formato di file.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

L'utility è appropriata quando tutte le slide devono essere aggiunte a un risultato unico senza selezionarle o rimapparle singolarmente. Usa il modello a oggetti completo quando devi unire slide selezionate, applicare un master o layout di destinazione, preservare sezioni esplicitamente o conciliare dimensioni diverse delle slide. Vedi [Merge Presentations](/nodejs-java/merge-presentation/) per questi scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) invoca una callback per ogni tipo richiesto di elemento della presentazione. Evita i cicli annidati di collezioni ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione. In Node.js, crea implementazioni delle interfacce di callback con `java.newProxy`.

L'esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#portion) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, il traversal di forme e testo su tutta la presentazione include slide normali, master e layout. Le overload con un parametro `includeNotes` possono anche elaborare le slide delle note. Usa cicli di collezione diretti quando l'ordine di traversal, l'uscita anticipata, il filtraggio prima della chiamata di callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere forme**

Utilizza [Collect.shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/#shapes) quando ti serve una collezione di tutte le forme in una presentazione anziché una callback per ogni forma. È utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

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

Usa [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) rimuove le slide di layout non referenziate da alcuna slide normale.
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

Rimuovi i layout inutilizzati prima dei master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso anch'esso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, layout o dei dati completi dei font incorporati. Per ulteriori dettagli, vedi [Slide Master](/nodejs-java/slide-master/) e [Embedded Font](/nodejs-java/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API a basso codice invece del modello a oggetti completo?**

Usa le utility a basso codice quando un'operazione standard si applica a un file o presentazione completo e non richiede un controllo dettagliato su singoli elementi. Usa il modello a oggetti completo quando devi selezionare slide specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti che l'utility non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/merger/#process) richiede presentazioni in ingresso nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/convert/#autoByExtension), quindi unisci i file convertiti.

**ForEach elabora slide master, layout e note?**

[ForEach.slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#slide) itera le slide normali della presentazione. Le operazioni su tutta la presentazione di [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#portion) includono di default slide normali, master e layout. Usa le loro overload con `includeNotes` impostato a `true` per includere le slide delle note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/#shape) per elaborare ogni forma immediatamente tramite una callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/collect/#shapes) quando ti serve un risultato iterabile da conservare, filtrare, contare o attraversare più volte.

**Compress riduce sempre le dimensioni del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Queste utility operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback di [ForEach](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#save) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/nodejs-java/convert-presentation/)
- [Merge Presentations](/nodejs-java/merge-presentation/)
- [Slide Master](/nodejs-java/slide-master/)
- [Manage Text Box](/nodejs-java/manage-textbox/)
- [Embedded Font](/nodejs-java/embedded-font/)