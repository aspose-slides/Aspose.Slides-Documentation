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
- rimuovere master slide inutilizzati
- rimuovere layout slide inutilizzati
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides in Java per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il pacchetto [com.aspose.slides](https://reference.aspose.com/slides/it/java/com.aspose.slides/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Queste utility avvolgono flussi di lavoro dell'object‑model usati frequentemente in metodi mirati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Le utility low‑code sono più utili quando l'operazione si applica a un intero file o presentazione e il flusso di lavoro predefinito corrisponde ai requisiti. Usa il modello di oggetti completo [Aspose.Slides object model](https://reference.aspose.com/slides/it/java/com.aspose.slides/) quando hai bisogno di un controllo più fine su diapositive individuali, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume le utility disponibili:

| Helper | Utilizzo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/) | Convertire una presentazione in un altro formato con una chiamata file‑to‑file diretta. |
| [Merger](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/) | Unire file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) | Eseguire un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/) | Recuperare le forme dall'intera presentazione per un'elaborazione o analisi ripetuta. |
| [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) | Rimuovere master e layout inutilizzati e ridurre i dati dei font incorporati. |

## **Converti una presentazione**

Utilizza [Convert.autoByExtension](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando l'estensione del file di output è sufficiente a selezionare il formato di esportazione. Il metodo apre la presentazione sorgente, determina il formato richiesto dal percorso di output e scrive il risultato.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello di oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dalla utility selezionata. Consulta [Convert Presentation](/java/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unisci presentazioni**

Utilizza [Merger.process](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) per combinare file di presentazione completi con una sola chiamata. Le presentazioni in ingresso devono avere lo stesso formato di file.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

La utility è appropriata quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Usa il modello di oggetti completo quando hai bisogno di unire solo diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o riconciliare dimensioni di diapositiva diverse. Consulta [Merge Presentations](/java/merge-presentation/) per questi scenari.

## **Itera sugli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) invoca un callback per ogni tipo di elemento della presentazione richiesto. Evita cicli annidati di raccolta ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L'esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, l'attraversamento di forme e testo a livello di presentazione include diapositive normali, master e layout. Le overload con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa cicli di raccolta diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata al callback o il controllo dettagliato genitore‑figlio sono importanti.

## **Raccogli forme**

Utilizza [Collect.shapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve una collezione di tutte le forme in una presentazione anziché un callback per ciascuna forma. È utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

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

Usa [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimi il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) può rimuovere elementi strutturali inutilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) rimuove le diapositive di layout a cui nessuna diapositiva normale fa riferimento.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) rimuove i master non più utilizzati.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) rimuove i caratteri inutilizzati dai font incorporati.

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

Rimuovi i layout inutilizzati prima dei master inutilizzati, così un master che diventa non referenziato dopo la pulizia dei layout può essere rimosso anch'esso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, dei layout originali o dei dati completi dei font incorporati. Per ulteriori dettagli, consulta [Slide Master](/java/slide-master/) e [Embedded Font](/java/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece del modello di oggetti completo?**

Usa le utility low‑code quando un'operazione standard si applica a un file o una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello di oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dalla utility.

**Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) richiede che le presentazioni in ingresso siano nello stesso formato. Converti prima i file in ingresso in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e poi unisci i file convertiti.

**ForEach elabora master, layout e diapositive delle note?**

[ForEach.slide](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera sulle diapositive normali della presentazione. Le operazioni a livello di presentazione [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro overload con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre il file della presentazione più piccolo?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le relative operazioni di [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) potrebbero non ridurre le dimensioni del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. queste utility operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) caricato in memoria. Dopo aver modificato elementi in un callback di [ForEach](https://reference.aspose.com/slides/it/java/com.aspose.slides/foreach/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/), chiama [Presentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)