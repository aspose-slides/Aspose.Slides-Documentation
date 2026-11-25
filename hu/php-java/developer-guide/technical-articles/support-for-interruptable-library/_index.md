---
title: Hosszú ideig futó prezentációs műveletek megszakítása PHP-ben
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 120
url: /hu/php-java/support-for-interruptable-library/
keywords:
- megszakítási token
- leállítás
- konverziós időkorlát
- dia exportálás
- PowerPoint
- PHP
- Aspose.Slides
description: "Ismerje meg, hogyan lehet egy időzítővel megszakítani a prezentáció konvertálását, és a leállítás előtt exportált diákat visszaadni az Aspose.Slides for PHP via Java használatával."
---
## **Áttekintés**

Az Aspose.Slides for PHP via Java képes megszakítani a hosszú ideig tartó műveleteket, mint például a bemutatók betöltése, mentése és renderelése. Egy egyes diák exportálására irányuló ciklusban ugyanaz a token lehetővé teszi az alkalmazás számára, hogy megálljon a következő dia előtt, és visszaadja a befejezett exportálások listáját.

Mindkét PHP példa azt feltételezi, hogy a bootstrapod meghívja a `define("JAVA_PREFER_VALUES", 1);` parancsot a `Java.inc` betöltése előtt, majd betölti a `aspose.slides.php` fájlt. Ez a beállítás lehetővé teszi, hogy a PHP elkapja a Java kivételeket a hívás során. A példák megvizsgálják a becsomagolt kivétel okát, hogy a többi konverziós hiba eljusson a hívóhoz.

## **Prezentációs művelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), kérje le a tokenjét a [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) metódussal, és adja át a [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken) metódusnak. Adja meg ezeket a beállításokat a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) példány létrehozásakor. A [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) hívás leállítási kérést küld. A futó művelet megáll, amikor észleli a kérést.

### **Konverziós időkorlát beállítása**

Miközben a PHP szinkron betöltésre vagy mentésre vár a PHP/Java Bridge-en keresztül, egy Java időzítő egy külön szálon kérheti a leállítást. Mentse el az alábbi segédfájlt `ConversionTimeout.java` néven, fordítsa le az Aspose.Slides JAR-rel a classpath-ban, és tegye a lefordított osztályt a híd számára elérhetővé a `example.ConversionTimeout` csomagnév alatt.

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

Miután a híd és az Aspose.Slides PHP wrapper betöltődött, futtassa az alábbi példát a `sample.pptx` fájllal a Java folyamat munkakönyvtárában, vagy használjon abszolút útvonalakat, amelyek a folyamathoz elérhetők. A 20 másodperces határérték a betöltést és a PDF exportálást egyaránt lefedi. Ha a konverzió hamarabb befejeződik, a PHP leállítja az időzítőt. Régebbi PowerPoint formátumba 10 másodperces határértékkel való konvertáláshoz használja a `sample.ppt`, a `SaveFormat::Ppt` és a `10000` milliszekundum értékeket.

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

## **Megállás a következő dia feldolgozása előtt**

Ellenőrizze a [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) metódust minden egyes exportálás előtt. A [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) túlterhelés a kijelölt diákhoz 1‑től induló diaköteteket vár. Egy egyelemű tömb átadásával külön PDF-et hozhat létre minden diához.

Használjon egy legalább két diát tartalmazó `sample.pptx` fájlt. A exportálások közötti leállítás bemutatásához a példa azonnal az első dia rögzítése után kéri a leállítást.

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

A példa a `slide-1.pdf` fájlt írja, és a `Completed: [1]` üzenetet jeleníti meg. A második iteráció a leállítási kérést a következő exportálás megkezdése előtt észleli. Ha a mentés közben leállítás történik, a lista csak a korábban megerősített exportálásokat tartalmazza. Egy megszakított mentés hiányos fájlt hagyhat a lemezen.

A leállítás hívóhoz való továbbításához cserélje le a ciklus elején lévő ellenőrzést `$token->throwIfInterruptionRequested();` hívásra, és távolítsa el a belső `try`/`catch` blokkot, megtartva a mentést és az azt követő ellenőrzést. Ugyanazzal a bemenettel a [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) kivételt dob a 2. dia előtt, és a hívó nem kap listát.

## **GYIK**

**Mikor kell leállítást kérni?**

Leállítást kérjen, amikor a határidő lejár, vagy a hívónak már nincs szüksége az eredményre. A művelet befejezése után benyújtott kérés nem érinti az eredményt.

**Miben különbözik a forrás és a token?**

A forrás lehetővé teszi az alkalmazás számára a leállítási kérés indítását. A token pedig az Aspose.Slides és az alkalmazáskód számára, hogy megfigyelje ezt a kérést.

**Több művelet is megoszthat forrást?**

Igen. A kérés minden, ugyanabból a forrásból származó tokennel rendelkező műveletre hat. Külön forrásokat hozzon létre azokhoz a műveletekhez, amelyek független leállítást igényelnek.