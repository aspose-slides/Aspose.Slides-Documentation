---
title: Operazioni di Presentazione Low-Code su Android
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
- rimuovere master diapositive non utilizzati
- rimuovere diapositive layout non utilizzate
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Utilizza l'API low-code di Aspose.Slides su Android per convertire e unire presentazioni, iterare il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Il pacchetto [com.aspose.slides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Queste classi avvolgono flussi di lavoro del modello di oggetti frequentemente usati in metodi mirati, così è possibile convertire o unire file, elaborare gli elementi della presentazione, raccogliere forme e rimuovere contenuti inutilizzati con meno codice.

Gli assistenti low‑code sono più utili quando l'operazione si applica a un intero file o a un'intera presentazione e il flusso di lavoro predefinito soddisfa i requisiti. Utilizza il modello di oggetti completo di [Aspose.Slides object model](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/) quando hai bisogno di un controllo dettagliato su diapositive individuali, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume gli assistenti disponibili:

| Assistente | Utilizzalo per |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata diretta file‑a‑file. |
| [Merger](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/) | Combinazione di file di presentazione completi dello stesso formato. |
| [ForEach](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/) | Esecuzione di un'azione per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/) | Recupero delle forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) | Rimozione di master e layout non utilizzati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Utilizza [Convert.autoByExtension](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione di origine, determina il formato richiesto dal percorso di output e scrive il risultato.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/) fornisce anche metodi dedicati per l'output PDF, SVG, JPEG, PNG e TIFF. Utilizza il modello di oggetti completo quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'assistente selezionato. Vedi [Convert Presentation](/androidjava/convert-presentation/) per flussi di lavoro e opzioni specifici per formato.

## **Unire presentazioni**

Utilizza [Merger.process](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) per combinare file di presentazione completi con una singola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

L'assistente è appropriato quando tutte le diapositive devono essere aggiunte a un risultato unico senza selezionarle o rimapparle individualmente. Utilizza il modello di oggetti completo quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare esplicitamente le sezioni o riconciliare diverse dimensioni di diapositiva. Vedi [Merge Presentations](/androidjava/merge-presentation/) per questi scenari.

## **Iterare tra gli elementi della presentazione**

La classe [ForEach](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/) invoca una callback per ogni tipo di elemento della presentazione richiesto. Evita cicli di collezioni nidificate ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L'esempio seguente utilizza [ForEach.slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), e [ForEach.portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) per ispezionare gli elementi corrispondenti:

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

Per impostazione predefinita, l'attraversamento di forme e testo a livello di presentazione include diapositive normali, master e layout. Le sovraccariche con un parametro `includeNotes` possono anche elaborare le diapositive note. Utilizza cicli di collezione diretti quando l'ordine di attraversamento, l'uscita anticipata, il filtraggio prima della chiamata della callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere forme**

Utilizza [Collect.shapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando hai bisogno di una collezione di tutte le forme in una presentazione anziché una callback per ogni forma. Questo è utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

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

Usa invece [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) quando ogni forma può essere gestita immediatamente e non hai bisogno di conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) può rimuovere elementi strutturali non utilizzati e ridurre i dati dei font incorporati:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) rimuove le diapositive layout che nessuna diapositiva normale riferisce.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) rimuove le diapositive master che non sono più usate.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) rimuove i caratteri non utilizzati dai font incorporati.

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

Rimuovi i layout non utilizzati prima dei master non utilizzati, in modo che un master che diventa non referenziato dopo la pulizia dei layout possa essere rimosso. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno dei master, dei layout originali o dei dati completi dei font incorporati in seguito. Per maggiori dettagli, consulta [Slide Master](/androidjava/slide-master/) e [Embedded Font](/androidjava/embedded-font/).

## **FAQ**

**Quando dovrei utilizzare l'API low‑code invece del modello di oggetti completo?**

Utilizza gli assistenti low‑code quando un'operazione standard si applica a un file o a una presentazione completa e non richiede controllo dettagliato sugli elementi individuali. Utilizza il modello di oggetti completo quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti che l'assistente non espone.

**Merger può combinare presentazioni in formati di file diversi?**

No. [Merger.process](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) richiede presentazioni di input nello stesso formato. Converte prima i file di input in un formato comune, ad esempio con [Convert.autoByExtension](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e poi unisci i file convertiti.

**ForEach elabora diapositive master, layout e note?**

[ForEach.slide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera attraverso le diapositive normali della presentazione. Le operazioni a livello di presentazione [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro sovraccariche con `includeNotes` impostato a `true` per includere le diapositive note.

**Qual è la differenza tra ForEach.shape e Collect.shapes?**

Usa [ForEach.shape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) per elaborare ogni forma immediatamente tramite una callback. Usa [Collect.shapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress riduce sempre le dimensioni del file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout non utilizzati, master non utilizzati o font incorporati con caratteri inutilizzati. Se nessuno di questi è presente, le operazioni corrispondenti di [Compress] potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach o Compress vengono salvate automaticamente?**

No. Questi assistenti operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in una callback [ForEach] o aver eseguito [Compress], chiama [Presentation.save](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) per scrivere il risultato.

## **Articoli correlati**

- [Converti presentazione](/androidjava/convert-presentation/)
- [Unisci presentazioni](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Gestire casella di testo](/androidjava/manage-textbox/)
- [Font incorporato](/androidjava/embedded-font/)