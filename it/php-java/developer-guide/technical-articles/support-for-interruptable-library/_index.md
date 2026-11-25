---
title: Interrompere operazioni di presentazione a lunga durata in PHP
linktitle: Interrompere operazioni di presentazione
type: docs
weight: 120
url: /it/php-java/support-for-interruptable-library/
keywords:
- token di interruzione
- annullamento
- timeout di conversione
- esportazione di diapositive
- PowerPoint
- PHP
- Aspose.Slides
description: "Scopri come annullare una conversione di presentazione con un timer e restituire le diapositive esportate prima dell'annullamento con Aspose.Slides per PHP via Java."
---
## **Panoramica**

Aspose.Slides per PHP via Java può interrompere operazioni a lunga durata come il caricamento, il salvataggio e il rendering delle presentazioni. In un ciclo che esporta una diapositiva alla volta, lo stesso token consente alla tua applicazione di fermarsi prima della diapositiva successiva e restituire un elenco di esportazioni completate.

Entrambi gli esempi PHP presumono che il tuo bootstrap chiami `define("JAVA_PREFER_VALUES", 1);` prima di caricare il `Java.inc` del bridge, poi carichi `aspose.slides.php`. Questa impostazione permette a PHP di catturare le eccezioni Java durante la chiamata. Gli esempi ispezionano la causa dell'eccezione avvolta in modo che altri errori di conversione raggiungano il chiamante.

## **Interrompere un'operazione di presentazione**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), ottieni il suo token con [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), e passalo a [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Fornisci queste opzioni quando costruisci la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Chiamare [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) richiede l'annullamento. Un'operazione in esecuzione si interrompe quando osserva la richiesta.

### **Impostare un timeout di conversione**

Mentre PHP attende un caricamento o salvataggio sincrono attraverso il PHP/Java Bridge, un timer Java può richiedere l'annullamento su un thread separato. Salva il seguente helper come `ConversionTimeout.java`, compila con il JAR Aspose.Slides nel classpath e rendi la classe compilata disponibile al bridge sotto il suo nome di pacchetto, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Con il bridge e il wrapper PHP di Aspose.Slides caricati, esegui l'esempio seguente con `sample.pptx` nella directory di lavoro del processo Java, o usa percorsi assoluti accessibili a quel processo. Il limite di 20 secondi copre sia il caricamento che l'esportazione PDF. Se la conversione termina in anticipo, PHP annulla il timer. Per convertire al formato PowerPoint più vecchio con un limite di 10 secondi, usa `sample.ppt`, `SaveFormat::Ppt` e `10000` millisecondi.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Interrompere prima di elaborare la diapositiva successiva**

Controlla [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) prima di ogni esportazione. La sovraccarico [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) per diapositive selezionate accetta numeri di diapositiva a partire da 1. Passa un array a un elemento per scrivere un PDF separato per ogni diapositiva.

Usa un `sample.pptx` con almeno due diapositive. Per dimostrare l'annullamento tra le esportazioni, l'esempio lo richiede immediatamente dopo aver registrato la prima diapositiva.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

L'esempio scrive `slide-1.pdf` e stampa `Completed: [1]`. La seconda iterazione vede la richiesta prima di iniziare un'altra esportazione. Se l'annullamento avviene durante un salvataggio, l'elenco contiene solo le esportazioni precedentemente confermate. Un salvataggio interrotto può lasciare un file incompleto sul disco.

Per propagare l'annullamento al chiamante, sostituisci il controllo all'inizio del ciclo con `$token->throwIfInterruptionRequested();` e rimuovi il `try`/`catch` interno, mantenendo il salvataggio e il controllo che lo segue. Con lo stesso input, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) genera un'eccezione prima della diapositiva 2 e il chiamante non riceve alcun elenco.

## **FAQ**

**Quando dovrei richiedere l'annullamento?**

Richiedi l'annullamento quando una scadenza scade o il chiamante non ha più bisogno del risultato. Una richiesta effettuata dopo che un'operazione è terminata lascia intatto il suo risultato.

**In che modo la sorgente e il token differiscono?**

La sorgente consente a un'applicazione di richiedere l'annullamento. Il token consente ad Aspose.Slides e al codice dell'applicazione di osservare tale richiesta.

**Possono più operazioni condividere una sorgente?**

Sì. Una richiesta si applica a tutte le operazioni che utilizzano token da quella sorgente. Crea sorgenti separate per le operazioni che necessitano di annullamento indipendente.