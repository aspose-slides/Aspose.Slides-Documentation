---
title: Onderbreek langdurige presentatiebewerkingen in PHP
linktitle: Onderbreek presentatiewerkzaamheden
type: docs
weight: 120
url: /nl/php-java/support-for-interruptable-library/
keywords:
- onderbrekingstoken
- annulering
- conversietimeout
- dia-export
- PowerPoint
- PHP
- Aspose.Slides
description: "Leer hoe u een presentatieconversie kunt annuleren met een timer en de dia's kunt retourneren die vóór de annulering zijn geëxporteerd met Aspose.Slides voor PHP via Java."
---
## **Overzicht**

Aspose.Slides voor PHP via Java kan langdurige bewerkingen zoals het laden, opslaan en renderen van presentaties onderbreken. In een lus die één dia per keer exporteert, laat hetzelfde token uw toepassing stoppen vóór de volgende dia en een lijst met voltooide exporten teruggeven.

Beide PHP‑voorbeelden gaan ervan uit dat uw bootstrap `define("JAVA_PREFER_VALUES", 1);` aanroept vóór het laden van de bridge‑bestand `Java.inc`, waarna `aspose.slides.php` wordt geladen. Deze instelling zorgt ervoor dat PHP Java‑exceptions kan opvangen tijdens de oproep. De voorbeelden inspecteren de oorzaak van de ingepakte exception zodat andere conversiefouten bij de aanroeper terechtkomen.

## **Onderbreek een Presentatie‑bewerking**

Maak een [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), verkrijg zijn token met [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), en geef het door aan [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Geef deze opties op bij het construeren van de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Het aanroepen van [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) vraagt om annulering. Een lopende bewerking stopt zodra het de aanvraag constateert.

### **Stel een Conversietime‑out in**

Terwijl PHP wacht op een synchroon laden of opslaan via de PHP/Java Bridge, kan een Java‑timer annulering aanvragen vanaf een aparte thread. Sla de volgende helper op als `ConversionTimeout.java`, compileer deze met de Aspose.Slides‑JAR op het classpath, en maak de gecompileerde klasse beschikbaar voor de bridge onder zijn pakketnaam, `example.ConversionTimeout`.

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

Met de bridge en de Aspose.Slides PHP‑wrapper geladen, voert u het volgende voorbeeld uit met `sample.pptx` in de werkmap van het Java‑proces, of gebruik absolute paden die voor dat proces toegankelijk zijn. De limiet van 20 seconden bestrijkt zowel het laden als de PDF‑export. Als de conversie vroegtijdig voltooid is, annuleert PHP de timer. Om te converteren naar het oudere PowerPoint‑formaat met een limiet van 10 seconden, gebruikt u `sample.ppt`, `SaveFormat::Ppt` en `10000` milliseconden.

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

## **Stop vóór het verwerken van de volgende dia**

Controleer [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) vóór elke export. De overload van [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) voor geselecteerde dia’s accepteert diavernummers beginnend bij 1. Geef een één‑element array door om voor elke dia een afzonderlijke PDF te schrijven.

Gebruik een `sample.pptx` met minstens twee dia's. Om annulering tussen exporten te demonstreren, vraagt het voorbeeld dit direct na het opnemen van de eerste dia.

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

Het voorbeeld schrijft `slide-1.pdf` en print `Completed: [1]`. De tweede iteratie ziet de aanvraag vóórdat het een nieuwe export start. Als annulering plaatsvindt tijdens een opslaan, bevat de lijst alleen eerder bevestigde exporten. Een onderbroken opslaan kan een onvolledig bestand op de schijf achterlaten.

Om de annulering naar de aanroeper door te geven, vervangt u de controle aan het begin van de lus door `$token->throwIfInterruptionRequested();` en verwijdert u de interne `try`/`catch`, terwijl u de opslaan‑opdracht en de daaropvolgende controle behoudt. Met dezelfde invoer [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) gooit een uitzondering vóór dia 2 en ontvangt de aanroeper geen lijst.

## **FAQ**

**Wanneer moet ik een annulering aanvragen?**

Vraag annulering aan wanneer een deadline verstrijkt of de aanroeper het resultaat niet meer nodig heeft. Een aanvraag die wordt gedaan nadat een bewerking is voltooid, laat het resultaat ongewijzigd.

**Hoe verschillen de source en het token?**

De source stelt een toepassing in staat een annulering aan te vragen. Het token laat Aspose.Slides en applicatiecode de aanvraag waarnemen.

**Kunnen meerdere bewerkingen dezelfde source delen?**

Ja. Een aanvraag geldt voor alle bewerkingen die tokens van die source gebruiken. Maak afzonderlijke sources voor bewerkingen die onafhankelijke annulering nodig hebben.