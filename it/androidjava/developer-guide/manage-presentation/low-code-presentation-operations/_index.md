---
title: Operazioni di presentazione Low-Code su Android
linktitle: API Low-Code
type: docs
weight: 50
url: /it/androidjava/low-code-presentation-operations/
keywords:
- API di presentazione low-code
- convertire presentazione
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
- Android
- Java
- Aspose.Slides
description: "Usa l'API low-code di Aspose.Slides su Android per convertire e unire presentazioni, iterare i contenuti, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il pacchetto [com.aspose.slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Queste classi avvolgono flussi di lavoro dell'object model usati frequentemente in metodi mirati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

I helper low-code sono più utili quando l'operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza il modello di oggetti completo di [Aspose.Slides object model](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/) quando hai bisogno di un controllo dettagliato su singole diapositive, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume i helper disponibili:

| Helper | Per cosa usarlo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretta file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/) | Combinazione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/) | Esecuzione di un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/) | Recupero delle forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) | Rimozione di master e layout inutilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert.autoByExtension](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/) fornisce inoltre metodi dedicati per l'output in PDF, SVG, JPEG, PNG e TIFF. Usa il modello di oggetti completo quando è necessario ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dal helper selezionato. Vedi [Convert Presentation](/slides/it/androidjava/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire le presentazioni**

Usa [Merger.process](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

Il helper è appropriato quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa il modello di oggetti completo quando hai bisogno di unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni esplicitamente o riconciliare diverse dimensioni delle diapositive. Vedi [Merge Presentations](/slides/it/androidjava/merge-presentation/) per questi scenari.

## **Iterare attraverso gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/) richiede un callback per ogni tipo richiesto di elemento della presentazione. Evita loop di raccolta annidati ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

Il seguente esempio utilizza [ForEach.slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), e [ForEach.portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, l'attraversamento di forme e testo a livello di presentazione include diapositive normali, master e layout. Le overload con un parametro `includeNotes` possono anche elaborare diapositive note. Usa loop di raccolta diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata del callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere forme**

Usa [Collect.shapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando hai bisogno di una collezione di tutte le forme in una presentazione anziché di un callback per ogni forma. Questo è utile quando lo stesso set sarà filtrato, contato o elaborato più volte.

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

Usa [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) rimuove le diapositive di layout che non sono riferite da alcuna diapositiva normale.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) rimuove i master slide che non sono più usati.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) rimuove i caratteri inutilizzati dai font incorporati.

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

Rimuovi i layout inutilizzati prima dei master inutilizzati così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno dei master, dei layout originali o dei dati completi dei font incorporati in seguito. Per maggiori dettagli, vedi [Slide Master](/slides/it/androidjava/slide-master/) e [Embedded Font](/slides/it/androidjava/embedded-font/).

## **FAQ**

**Quando dovrei utilizzare l'API low-code invece del modello di oggetti completo?**

Usa i helper low-code quando un'operazione standard si applica a un file o a una presentazione completa e non richiede controllo dettagliato su elementi singoli. Usa il modello di oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare un comportamento che il helper non espone.

**Il Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) richiede presentazioni di input nello stesso formato. Converte prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e poi unisci i file convertiti.

**ForEach elabora master, layout e diapositive note?**

[ForEach.slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera attraverso le diapositive normali della presentazione. Le operazioni a livello di presentazione [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), e [ForEach.portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro overload con `includeNotes` impostato a `true` per includere le diapositive note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre il file della presentazione più piccolo?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in un callback [ForEach] o aver eseguito [Compress], chiama [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere il risultato.

## **Articoli correlati**

- [Convertire la presentazione](/slides/it/androidjava/convert-presentation/)
- [Unire le presentazioni](/slides/it/androidjava/merge-presentation/)
- [Master delle diapositive](/slides/it/androidjava/slide-master/)
- [Gestire la casella di testo](/slides/it/androidjava/manage-textbox/)
- [Font incorporato](/slides/it/androidjava/embedded-font/)