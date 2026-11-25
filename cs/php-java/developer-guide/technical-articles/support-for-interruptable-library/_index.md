---
title: "Přerušení dlouho běžících operací s prezentací v PHP"
linktitle: "Přerušení operací s prezentací"
type: docs
weight: 120
url: /cs/php-java/support-for-interruptable-library/
keywords:
- "token přerušení"
- "zrušení"
- "časový limit konverze"
- "export snímků"
- "PowerPoint"
- "PHP"
- "Aspose.Slides"
description: "Zjistěte, jak zrušit konverzi prezentace pomocí časovače a vrátit snímky exportované před zrušením s Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Aspose.Slides for PHP přes Java může přerušit dlouho běžící operace, jako je načítání, ukládání a vykreslování prezentací. V cyklu, který exportuje jeden snímek po druhém, stejné token umožňuje vaší aplikaci zastavit se před dalším snímkem a vrátit seznam dokončených exportů.

Oba PHP příklady předpokládají, že váš bootstrap zavolá `define("JAVA_PREFER_VALUES", 1);` před načtením mostu `Java.inc`, poté načte `aspose.slides.php`. Toto nastavení umožňuje PHP zachytit výjimky Java během volání. Příklady kontrolují příčinu zabalené výjimky, aby ostatní chyby při konverzi byly předány volajícímu.

## **Přerušení operace s prezentací**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), získáte jeho token pomocí [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) a předáte jej do [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Tyto možnosti poskytněte při vytváření [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Voláním [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) požádáte o zrušení. Běžící operace se zastaví, jakmile požadavek zaznamená.

### **Nastavení časového limitu konverze**

Zatímco PHP čeká na synchronní načtení nebo uložení přes PHP/Java Bridge, Java časovač může požádat o zrušení na samostatném vlákně. Uložte následující pomocnou třídu jako `ConversionTimeout.java`, zkompilujte ji s Aspose.Slides JAR na classpath a zpřístupněte zkompilovanou třídu mostu pod jejím názvem balíčku, `example.ConversionTimeout`.

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

Po načtení mostu a PHP obalu Aspose.Slides spusťte následující příklad se souborem `sample.pptx` v pracovním adresáři Java procesu, nebo použijte absolutní cesty přístupné tomuto procesu. Limit 20 sekund pokrývá jak načítání, tak export do PDF. Pokud konverze skončí dříve, PHP zruší časovač. Pro konverzi do staršího formátu PowerPoint s 10‑sekundovým limitem použijte `sample.ppt`, `SaveFormat::Ppt` a `10000` milisekund.

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

## **Zastavte se před zpracováním dalšího snímku**

Před každým exportem zkontrolujte [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested). Přetížení [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) pro vybrané snímky přijímá čísla snímků začínající od 1. Předávejte jednoprvkový pole, aby se pro každý snímek vytvořil samostatný PDF.

Použijte `sample.pptx` s alespoň dvěma snímky. Pro demonstraci zrušení mezi exporty požaduje příklad zrušení okamžitě po zaznamenání prvního snímku.

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

Příklad zapíše `slide-1.pdf` a vytiskne `Completed: [1]`. Druhá iterace vidí požadavek před zahájením dalšího exportu. Pokud dojde k zrušení během uložení, seznam obsahuje jen dříve potvrzené exporty. Přerušení uložení může na disku zanechat neúplný soubor.

Pro předání zrušení volajícímu nahraďte kontrolu na začátku smyčky `$token->throwIfInterruptionRequested();` a odstraňte vnitřní `try`/`catch`, přičemž zachovejte uložení a následující kontrolu. Se stejným vstupem [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) vyvolá výjimku před snímkem 2 a volající nedostane žádný seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když vyprší termín nebo volající již výsledek nepotřebuje. Požadavek učiněný po dokončení operace ponechá její výsledek nedotčený.

**Jak se liší zdroj a token?**

Zdroj umožňuje aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i kódu aplikace sledovat tento požadavek.

**Mohou různé operace sdílet stejný zdroj?**

Ano. Požadavek se vztahuje na všechny operace využívající tokeny z daného zdroje. Pro operace, které vyžadují nezávislé zrušení, vytvořte samostatné zdroje.