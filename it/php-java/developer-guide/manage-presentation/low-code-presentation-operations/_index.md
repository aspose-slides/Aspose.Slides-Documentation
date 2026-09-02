---
title: Operazioni di presentazione low-code in PHP
linktitle: API low-code
type: docs
weight: 50
url: /it/php-java/low-code-presentation-operations/
keywords:
- API presentazione low-code
- convertire presentazione
- unire presentazioni
- iterare diapositive
- iterare forme
- iterare testo
- raccogliere forme
- comprimere presentazione
- rimuovere diapositive master inutilizzate
- rimuovere diapositive layout inutilizzate
- comprimere font incorporati
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Usa l'API low-code di Aspose.Slides in PHP per convertire e unire presentazioni, scorrere il contenuto, raccogliere forme e ridurre le dimensioni della presentazione."
---
## **Panoramica**

Lo spazio dei nomi [aspose.slides](https://reference.aspose.com/slides/it/php-java/aspose.slides/) fornisce classi di supporto statiche per operazioni comuni sulle presentazioni. Questi helper incapsulano i flussi di lavoro più usati del modello a oggetti in metodi focalizzati, così è possibile convertire o unire file, elaborare elementi della presentazione, raccogliere forme e rimuovere contenuti non utilizzati con meno codice.

Gli helper low‑code sono più utili quando l'operazione si applica a un intero file o a una presentazione e il flusso di lavoro predefinito corrisponde ai requisiti. Utilizza il modello completo di oggetti [Aspose.Slides](https://reference.aspose.com/slides/it/php-java/aspose.slides/) quando hai bisogno di un controllo più fine su diapositive individuali, master, layout, forme, impostazioni di esportazione o relazioni tra gli elementi della presentazione.

La tabella seguente riassume gli helper disponibili:

| Helper | Per cosa usarlo |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/it/php-java/aspose.slides/convert/) | Conversione di una presentazione in un altro formato con una chiamata file‑to‑file. |
| [Merger](https://reference.aspose.com/slides/it/php-java/aspose.slides/merger/) | Unione di file di presentazione completi dello stesso formato. |
| [ForEach_](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/) | Esecuzione di un callback per ogni diapositiva, forma, paragrafo o porzione di testo. |
| [Collect](https://reference.aspose.com/slides/it/php-java/aspose.slides/collect/) | Recupero delle forme dall'intera presentazione per elaborazioni o analisi ripetute. |
| [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/) | Rimozione di master e layout non usati e riduzione dei dati dei font incorporati. |

## **Convertire una presentazione**

Usa [Convert::autoByExtension](https://reference.aspose.com/slides/it/php-java/aspose.slides/convert/#autoByExtension) quando l'estensione del file di output è sufficiente per selezionare il formato di esportazione. Il metodo apre la presentazione sorgente, determina il formato richiesto dal percorso di output e scrive il risultato.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

La classe [Convert](https://reference.aspose.com/slides/it/php-java/aspose.slides/convert/) fornisce anche metodi dedicati per output PDF, SVG, JPEG, PNG e TIFF. Usa il modello completo di oggetti quando devi ispezionare o modificare la presentazione prima dell'esportazione o configurare un'opzione di esportazione non esposta dall'helper selezionato. Vedi [Convert Presentation](/php-java/convert-presentation/) per flussi di lavoro e opzioni specifiche per formato.

## **Unire presentazioni**

Usa [Merger::process](https://reference.aspose.com/slides/it/php-java/aspose.slides/merger/#process) per combinare file di presentazione completi con una sola chiamata. Le presentazioni di input devono avere lo stesso formato di file.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

L'helper è appropriato quando tutte le diapositive devono essere aggiunte a un unico risultato senza selezionarle o rimapparle individualmente. Usa il modello completo di oggetti quando devi unire diapositive selezionate, applicare un master o layout di destinazione, preservare sezioni in modo esplicito o conciliare diverse dimensioni delle diapositive. Vedi [Merge Presentations](/php-java/merge-presentation/) per questi scenari.

## **Iterare sugli elementi della presentazione**

La classe [ForEach_](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/) invoca un callback per ogni tipo richiesto di elemento della presentazione. Evita loop nidificati su collezioni ed è comoda per ispezioni o modifiche di formattazione a livello di presentazione.

L'esempio seguente utilizza [ForEach_::slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#paragraph) e [ForEach_::portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#portion) per ispezionare gli elementi corrispondenti:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Per impostazione predefinita, il traversal di forme e testo a livello di presentazione includono diapositive normali, master e layout. Le sovraccariche con un parametro `includeNotes` possono anche elaborare le diapositive delle note. Usa loop di collezione diretti quando l'ordine di traversal, l'uscita anticipata, il filtraggio prima della chiamata del callback o il controllo dettagliato padre‑figlio sono importanti.

## **Raccogliere forme**

Usa [Collect::shapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/collect/#shapes) quando ti serve una raccolta di tutte le forme in una presentazione anziché un callback per ogni forma. È utile quando lo stesso insieme verrà filtrato, contato o elaborato più volte.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Utilizza [ForEach_::shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#shape) invece quando ogni forma può essere gestita immediatamente e non è necessario conservare il risultato raccolto.

## **Comprimere il contenuto della presentazione**

La classe [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/) può rimuovere elementi strutturali non usati e ridurre i dati dei font incorporati:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) rimuove i layout non referenziati da alcuna diapositiva normale.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedMasterSlides) rimuove i master non più utilizzati.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#compressEmbeddedFonts) rimuove i caratteri inutilizzati dai font incorporati.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Rimuovi prima i layout non usati e poi i master non usati, così un master che diventa non referenziato dopo la pulizia dei layout può anch'esso essere eliminato. Salva la presentazione ottimizzata in un nuovo file se potresti aver bisogno in seguito dei master, layout o dei dati completi dei font incorporati originali. Per maggiori dettagli, vedi [Slide Master](/php-java/slide-master/) e [Embedded Font](/php-java/embedded-font/).

## **FAQ**

**Quando dovrei usare l'API low‑code invece del modello object completo?**

Usa gli helper low‑code quando un'operazione standard si applica a un file o a una presentazione completa e non richiede un controllo dettagliato sugli elementi individuali. Usa il modello completo di oggetti quando devi selezionare diapositive specifiche, controllare le relazioni tra master e layout, ispezionare lo stato intermedio o configurare comportamenti non esposti dall'helper.

**Merger può combinare presentazioni in formati di file diversi?**

No. [Merger::process](https://reference.aspose.com/slides/it/php-java/aspose.slides/merger/#process) richiede che le presentazioni di input siano nello stesso formato. Converti prima i file di input in un formato comune, ad esempio con [Convert::autoByExtension](https://reference.aspose.com/slides/it/php-java/aspose.slides/convert/#autoByExtension), e poi unisci i file convertiti.

**ForEach_ elabora le diapositive master, layout e note?**

[ForEach_::slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#slide) itera solo le diapositive normali della presentazione. Le operazioni a livello di presentazione di [ForEach_::shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#paragraph) e [ForEach_::portion](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#portion) includono diapositive normali, master e layout per impostazione predefinita. Usa le loro sovraccariche con `includeNotes` impostato a `true` per includere le diapositive delle note.

**Qual è la differenza tra ForEach_::shape e Collect::shapes?**

Usa [ForEach_::shape](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/#shape) per elaborare ogni forma immediatamente tramite un callback. Usa [Collect::shapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/collect/#shapes) quando ti serve un risultato iterabile che può essere conservato, filtrato, contato o attraversato più volte.

**Compress rende sempre più piccolo il file della presentazione?**

Non necessariamente. Il risultato dipende dal fatto che la presentazione contenga layout inutilizzati, master inutilizzati o font incorporati con caratteri non usati. Se nessuno di questi elementi è presente, le operazioni corrispondenti di [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/) potrebbero non ridurre la dimensione del file.

**Le modifiche apportate da ForEach_ o Compress vengono salvate automaticamente?**

No. Questi helper operano sull'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) caricato in memoria. Dopo aver modificato gli elementi in un callback di [ForEach_](https://reference.aspose.com/slides/it/php-java/aspose.slides/foreach_/) o aver eseguito [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/), chiama [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) per scrivere il risultato.

## **Articoli correlati**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)