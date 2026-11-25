---
title: Avbryt långvariga presentationsoperationer i PHP
linktitle: Avbryt presentationsoperationer
type: docs
weight: 120
url: /sv/php-java/support-for-interruptable-library/
keywords:
- avbrottstoken
- avbrytning
- konverteringstimeout
- bildexport
- PowerPoint
- PHP
- Aspose.Slides
description: "Lär dig hur du avbryter en presentationskonvertering med en timer och returnerar bilderna som exporterats innan avbrytning med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java kan avbryta långa operationer såsom inläsning, sparande och rendering av presentationer. I en loop som exporterar en bild i taget låter samma token din applikation stoppa innan nästa bild och returnera en lista över slutförda exporter.

Båda PHP-exemplen förutsätter att ditt bootstrap‑anrop kör `define("JAVA_PREFER_VALUES", 1);` innan bridge‑filen `Java.inc` laddas, och sedan laddas `aspose.slides.php`. Denna inställning låter PHP fånga Java‑undantag under anropet. Exemplen undersöker den omslutna undantagets orsak så att andra konverteringsfel når anroparen.

## **Avbryt en presentationsoperation**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), hämta dess token med [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), och skicka den till [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Ange dessa alternativ när du konstruerar [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Att anropa [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) begär avbrytning. En pågående operation stoppar när den observerar begäran.

### **Ange en konverteringstimeout**

Medan PHP väntar på en synkron inläsning eller sparning via PHP/Java‑bron kan en Java‑timer begära avbrytning på en separat tråd. Spara följande hjälparklass som `ConversionTimeout.java`, kompilera den med Aspose.Slides‑JAR‑filen på klassvägen och gör den kompilerade klassen tillgänglig för bron under dess paketnamn, `example.ConversionTimeout`.

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

När bron och Aspose.Slides PHP‑wrappern är laddade, kör följande exempel med `sample.pptx` i Java‑processens arbetskatalog, eller använd absoluta sökvägar som är åtkomliga för processen. 20‑sekundersgränsen täcker både inläsning och PDF‑export. Om konverteringen avslutas tidigt avbryter PHP timern. För att konvertera till det äldre PowerPoint‑formatet med en 10‑sekundersgräns, använd `sample.ppt`, `SaveFormat::Ppt` och `10000` millisekunder.

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

## **Stoppa innan nästa bild bearbetas**

Kontrollera [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) innan varje export. Överlagringen [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) för valda bilder tar bildnummer som börjar på 1. Skicka en array med ett element för att skriva en separat PDF för varje bild.

Använd en `sample.pptx` med minst två bilder. För att demonstrera avbrytning mellan exporter begär exemplet det omedelbart efter att den första bilden har registrerats.

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

Exemplet skriver `slide-1.pdf` och skriver ut `Completed: [1]`. Den andra iterationen ser begäran innan den påbörjar en ny export. Om avbrytning sker under en sparning innehåller listan endast tidigare bekräftade exporter. En avbruten sparning kan lämna en ofullständig fil på disken.

För att vidarebefordra avbrytning till anroparen, ersätt kontrollen i början av loopen med `$token->throwIfInterruptionRequested();` och ta bort det inre `try`/`catch`, behåll sparandet och kontrollen som följer. Med samma indata kastar [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ett undantag före bild 2 och anroparen får ingen lista.

## **Vanliga frågor**

**När bör jag begära avbrytning?**  
Begär avbrytning när en tidsfrist löper ut eller när anroparen inte längre behöver resultatet. En begäran som görs efter att en operation har slutförts lämnar dess resultat intakt.

**Hur skiljer sig källan och tokenen?**  
Källan låter en applikation begära avbrytning. Tokenen låter Aspose.Slides och applikationskoden observera den begäran.

**Kan flera operationer dela en källa?**  
Ja. En begäran gäller alla operationer som använder token från den källan. Skapa separata källor för operationer som behöver oberoende avbrytning.