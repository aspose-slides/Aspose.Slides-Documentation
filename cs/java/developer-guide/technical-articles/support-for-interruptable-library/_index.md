---
title: Přerušit dlouho běžící operace s prezentací v Javě
linktitle: Přerušit operace s prezentací
type: docs
weight: 120
url: /cs/java/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Zjistěte, jak zrušit dlouho běžící operace s prezentací v Aspose.Slides pro Java a vrátit částečný výsledek při exportu snímků ve smyčce."
---
## **Přehled**

Aspose.Slides for Java může přerušovat dlouho běžící operace, jako je načítání, ukládání a vykreslování prezentací. Vaše aplikace může použít stejný token přerušení k zastavení smyčky předtím, než začne zpracovávat další snímek.

## **Přerušení operace s prezentací**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), získejte jeho token pomocí [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), a předávejte token metodě [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Předejte možnosti načítání do konstruktoru [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Pro požádání o zrušení zavolejte [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na zdroji. Přerušitelná operace se zastaví, jakmile požadavek zaznamená.

Příklad převádí `sample.pptx` na `sample.ppt` na vlákně na pozadí. Volající vlákno čeká až 10 sekund na dokončení převodu. Pokud převod stále běží, požádá o zrušení a čeká, až pracovník skončí.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
        } finally {
            presentation.dispose();
        }
    } catch (OperationCanceledException canceled) {
        System.out.println("Conversion canceled");
    }
});

worker.start();
worker.join(10000);
if (worker.isAlive()) {
    source.interrupt();
    worker.join();
}
```

## **Napojení časového limitu Java na Aspose.Slides**

Pro nastavení časového limitu operace s prezentací použijte [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) k volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) po vypršení časového limitu. Příklad umožňuje 20 sekund k načtení `sample.pptx` a exportu do `sample.pdf`. Pokud export skončí dříve, aplikace zruší naplánovaný požadavek.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Zastavení před zpracováním dalšího snímku**

Použijte stejný [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) pro prezentaci i pro smyčku, která exportuje její snímky. Před každým exportem zkontrolujte [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) . Pokud může volající použít částečný výsledek, vraťte čísla snímků, které byly úspěšně exportovány.

Použijte prezentaci pojmenovanou `sample.pptx` s alespoň dvěma snímky. Přetížení [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) přijímající pole čísel snímků počítá od 1. Příklad ukládá každý snímek do samostatného PDF a požaduje zrušení okamžitě po záznamu prvního úspěšného exportu.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Příklad zapíše `slide-1.pdf` a vytiskne `Starting slide 1` následované `Completed: [1]`. Smyčka zaznamená požadavek před zahájením snímku 2. Pokud zrušení přijde během ukládání, smyčka skončí předtím, než označí tento snímek jako dokončený.

Pokud volající potřebuje zpracovat zrušení, nahraďte kontrolu a její `break` na začátku smyčky voláním `token.throwIfInterruptionRequested()`. Odstraňte `try`/`catch` kolem ukládání, aby zrušení během exportu také dorazilo k volajícímu. Se stejným vstupem příklad vytiskne jen `Starting slide 1` a zapíše `slide-1.pdf`. Na začátku druhé iterace [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) vyvolá `com.aspose.slides.exceptions.OperationCanceledException` před zahájením dalšího exportu. Metoda nevrátí žádný seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když operace překročí váš časový limit nebo když vaše aplikace již výsledek nepotřebuje.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Zdroj umožňuje vaší aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i vaší aplikaci kontrolovat, zda byl takový požadavek učiněn.

**Mohu zrušit operaci z časovače v Javě?**

Ano. Naplánujte volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) na zdroj spojený s prezentací.

**Které operace mohu přerušit?**

Můžete přerušit načítání, ukládání i vykreslování. Předávejte token konstruktoru [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) přes [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Prezentace pak může během následných operací, jako je ukládání do PDF, sledovat zrušení.

**Zastaví se operace okamžitě?**

Zrušení je kooperativní. Operace periodicky kontroluje token a zastaví se, jakmile požadavek zaznamená.

**Co se stane, když zavolám [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) po dokončení operace?**

Dokončená operace si ponechá svůj výsledek.

**Může více operací sdílet [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Ano. Volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Použijte samostatný zdroj pro každou operaci, kterou chcete rušit nezávisle.