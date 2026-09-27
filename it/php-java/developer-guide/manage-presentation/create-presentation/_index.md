---
title: Crea presentazioni in PHP
linktitle: Crea presentazione
type: docs
weight: 10
url: /it/php-java/create-presentation/
keywords:
- crea presentazione
- nuova presentazione
- crea PPT
- nuovo PPT
- crea PPTX
- nuovo PPTX
- crea ODP
- nuovo ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Crea presentazioni con Aspose.Slides per PHP via Java — produci file PPT, PPTX e ODP e salvali programmaticamente per risultati affidabili."
---
## **Panoramica**

Questo articolo mostra come creare una presentazione in Aspose.Slides, aggiungere una casella di testo alla sua prima diapositiva e salvare il risultato come file. Mostra anche come creare e salvare una presentazione vuota e come aprire una presentazione esistente in un formato supportato e salvarla in un altro formato. Una breve FAQ alla fine copre le domande comuni su formati, modelli, dimensioni delle diapositive, unità, utilizzo della memoria, threading, licenze, firme digitali e supporto VBA.

Prima di iniziare, installa Aspose.Slides per PHP via Java con Composer e avvia PHP/Java Bridge in Apache Tomcat. Consulta [Installazione](/slides/it/php-java/installation/) per la configurazione completa. Gli esempi seguenti presumono che Tomcat sia in esecuzione su `localhost:8080` e che la cartella `vendor` di Composer sia accanto allo script.

## **Crea una presentazione PowerPoint**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Una nuova presentazione contiene già una diapositiva vuota.  
2. Ottieni quella diapositiva dalla collezione restituita da [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), usando il suo indice, 0.  
3. Aggiungi un rettangolo con il metodo [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) e imposta il suo testo con [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).  
4. Salva la presentazione come file PPTX con il metodo [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le due righe `require_once` caricano il client PHP/Java Bridge da Tomcat e le classi Aspose.Slides dal pacchetto Composer. L'angolo superiore sinistro del rettangolo è a 50 punti dal bordo sinistro e a 50 punti dal bordo superiore della diapositiva, e il rettangolo è largo 400 punti e alto 100 punti. Il file salvato contiene una diapositiva con quel rettangolo e il suo testo. Senza licenza, Aspose.Slides aggiunge anche una filigrana di valutazione a ogni diapositiva salvata; vedi [Licenze](/slides/it/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides legge e scrive file all'interno di Tomcat, non nel tuo processo PHP, quindi un percorso relativo come `"hello.pptx"` viene risolto rispetto alla cartella di lavoro di Tomcat. Gli esempi in questa pagina costruiscono percorsi assoluti con `__DIR__`, così i file vengono letti e salvati accanto allo script.
{{% /alert %}}

## **Crea e salva una presentazione**

Per creare una presentazione vuota e salvarla, crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) e salvala in qualsiasi formato dell'enumerazione [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/). Il risultato è una presentazione con una diapositiva vuota.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Apri e salva una presentazione**

Per convertire una presentazione da un formato all'altro, aprila passando il suo percorso al costruttore [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), quindi salvala nel formato di destinazione. Aspose.Slides rileva il formato di input, come PPT, PPTX o ODP, dal file stesso.

L'esempio seguente presume una presentazione OpenDocument denominata *Sample.odp* accanto allo script e la salva come PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/it/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

### Quali formati posso utilizzare per salvare una nuova presentazione?

Puoi salvare in [PPTX, PPT e ODP](/slides/it/php-java/save-presentation/), e esportare in [PDF](/slides/it/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/it/php-java/convert-powerpoint-to-xps/), [HTML](/slides/it/php-java/convert-powerpoint-to-html/), [SVG](/slides/it/php-java/render-a-slide-as-an-svg-image/), e [immagini](/slides/it/php-java/convert-powerpoint-to-png/), tra gli altri.

### Posso partire da un modello (POTX/POTM) e salvarlo come un PPTX normale?

Sì. Carica il modello e salvalo nel formato desiderato; i formati POTX/POTM/PPTM e simili [sono supportati](/slides/it/php-java/supported-file-formats/).

### Come controllo la dimensione del diapositiva/rapporto d'aspetto quando creo una presentazione?

Imposta la [dimensione della diapositiva](/slides/it/php-java/slide-size/) (comprese le impostazioni predefinite come 4:3 e 16:9 o dimensioni personalizzate) e scegli come scalare il contenuto.

### In quali unità sono misurate le dimensioni e le coordinate?

In punti: 1 pollice corrisponde a 72 unità.

### Come gestire presentazioni molto grandi (con molti file multimediali) per ridurre l'uso della memoria?

Utilizza le [strategie di gestione BLOB](/slides/it/php-java/manage-blob/), limita l'archiviazione in memoria sfruttando file temporanei e preferisci flussi di lavoro basati su file rispetto a stream puramente in memoria.

### Posso creare/salvare presentazioni in parallelo?

Non è possibile operare sulla stessa istanza di [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) da [thread multipli](/slides/it/php-java/multithreading/). Esegui istanze separate e isolate per thread o processo.

### Come rimuovo la filigrana di prova e le limitazioni?

[Applica una licenza](/slides/it/php-java/licensing/) una volta per processo. L'XML della licenza deve rimanere non modificato e la configurazione della licenza dovrebbe essere sincronizzata se più thread sono coinvolti.

### Posso firmare digitalmente il PPTX che creo?

Sì. Le [firme digitali](/slides/it/php-java/digital-signature-in-powerpoint/) (creazione e verifica) sono supportate per le presentazioni.

### Sono supportate le macro (VBA) nelle presentazioni create?

Sì. È possibile [creare/modificare progetti VBA](/slides/it/php-java/presentation-via-vba/) e salvare file con macro abilitata come PPTM/PPSM.