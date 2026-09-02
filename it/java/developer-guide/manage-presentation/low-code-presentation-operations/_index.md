---
title: Operazioni di presentazione a basso codice in Java
linktitle: API a basso codice
type: docs
weight: 50
url: /it/java/low-code-presentation-operations/
keywords:
- API di presentazione a basso codice
- convertire presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere master non utilizzati
- rimuovere layout non utilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Utilizza l'API a basso codice di Aspose.Slides in Java per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il pacchetto [com.aspose.slides](https://reference.aspose.com/slides/it/java/com.aspose.slides/) fornisce classi di utilità statiche per operazioni comuni sulle presentazioni. questi helper avvolgono i flussi di lavoro più frequenti del modello a oggetti in metodi mirati, così è possibile convertire o unire file, elaborare elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Gli helper a basso codice sono più utili quando l’operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Usa il modello a oggetti completo di [Aspose.Slides](https://reference.aspose.com/slides/it/java/com.aspose.slides/) quando hai bisogno di un controllo granulare su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume gli helper disponibili:

| Helper | Per cosa usarlo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata file‑to‑file diretta. |
| [Merger](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/) | Unione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) | Esecuzione di un’azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/) | Recupero delle forme da tutta la presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) | Rimozione di master e layout inutilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert.autoByExtension](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando l’estensione del file di output è sufficiente a selezionare il formato di esportazione. il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello a oggetti completo quando devi ispezionare o modificare la presentazione prima dell’esportazione o configurare un’opzione di esportazione non esposta dall’helper selezionato. Vedi [Convert Presentation](/slides/it/java/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Usa [Merger.process](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

L’helper è appropriato quando tutte le diapositive devono essere aggiunte a un unico risultato senza selezionarle o rimapparle singolarmente. Usa il modello a oggetti completo quando devi unire diapositive selezionate, applicare un master o un layout di destinazione, preservare sezioni in modo esplicito o riconciliare dimensioni di diapositiva diverse. Vedi [Merge Presentations](/slides/it/java/merge-presentation/) per questi scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) invoca un callback per ciascun tipo richiesto di elemento della presentazione. Evita loop nidificati di raccolte ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L’esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) per ispezionare gli elementi corrispondenti:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Per impostazione predefinita, l’attraversamento di forme e testi a livello di presentazione include diapositive normali, master e layout. Le sovraccariche con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa loop di raccolta diretti quando l’ordine di attraversamento, l’uscita anticipata, il filtraggio prima della chiamata al callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve una collezione di tutte le forme in una presentazione anziché un callback per ogni forma. Ciò è utile quando lo stesso insieme sarà filtrato, contato o elaborato più volte.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Usa [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) invece quando ogni forma può essere gestita subito e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) rimuove le diapositive layout non referenziate da alcuna diapositiva normale.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) rimuove i master non più utilizzati.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) elimina i caratteri inutilizzati dai font incorporati.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rimuovi prima i layout inutilizzati e poi i master, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout o dei dati completi dei font incorporati originali. Per ulteriori dettagli, vedi [Slide Master](/slides/it/java/slide-master/) e [Embedded Font](/slides/it/java/embedded-font/).

## **FAQ**

**Quando dovrei usare l’API a basso codice invece del modello a oggetti completo?**

Usa gli helper a basso codice quando un’operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello a oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dall’helper.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), quindi unisci i file convertiti.

**ForEach elabora master, layout e diapositive delle note?**

[ForEach.slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera solo le diapositive normali della presentazione. Le operazioni a livello di presentazione [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro sovraccariche con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre più piccolo il file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master non usati o font incorporati con caratteri non utilizzati. Se nessuno di questi elementi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. questi helper operano sull’oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in un callback di [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/slides/it/java/convert-presentation/)
- [Merge Presentations](/slides/it/java/merge-presentation/)
- [Slide Master](/slides/it/java/slide-master/)
- [Manage Text Box](/slides/it/java/manage-textbox/)
- [Embedded Font](/slides/it/java/embedded-font/)