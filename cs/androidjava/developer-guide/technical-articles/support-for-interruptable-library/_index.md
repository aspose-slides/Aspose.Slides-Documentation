---
title: Přerušení dlouho běžících operací s prezentací na Androidu
linktitle: Přerušení operací s prezentací
type: docs
weight: 120
url: /cs/androidjava/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- dlouho běžící úkol
- přerušit úkol
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak zrušit dlouho běžící operace s prezentací v Aspose.Slides pro Android pomocí Java a vrátit částečný výsledek při exportu snímků ve smyčce."
---
## **Přehled**

Aspose.Slides pro Android pomocí Java může přerušit dlouho běžící operace, jako je načítání, ukládání a vykreslování prezentací. Vaše aplikace může použít stejný token přerušení k zastavení smyčky před tím, než začne zpracovávat další snímek.

## **Přerušení operace s prezentací**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), získejte jeho token pomocí [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), a předávejte token metodě [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Předávejte možnosti načítání [konstruktoru Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Pro požádání o zrušení zavolejte [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na zdroj. Přerušitelná operace se zastaví, když zaznamená požadavek.

Příklad převádí `sample.pptx` na `sample.ppt` na vlákně na pozadí. Volající vlákno čeká až 10 sekund na dokončení převodu. Pokud převod stále běží, požádá o zrušení a čeká, až pracovník ukončí.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
        // Zavolejte z vlákna na pozadí a předáte context.getFilesDir(), který obsahuje sample.pptx.
        public static void run(File directory) throws InterruptedException {
                File input = new File(directory, "sample.pptx");
                File output = new File(directory, "sample.ppt");
                InterruptionTokenSource source = new InterruptionTokenSource();
                Thread worker = new Thread(() -> {
                        LoadOptions options = new LoadOptions();
                        options.setInterruptionToken(source.getToken());
                        try {
                                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                                try {
                                        presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
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
        }
}
```

## **Propojení časového limitu Java s Aspose.Slides**

Pro nastavení časového limitu na operaci s prezentací použijte [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService), který zavolá [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) když časový limit vyprší. Příklad umožňuje 20 sekund načíst `sample.pptx` a exportovat jej do `sample.pdf`. Pokud se export dokončí dříve, aplikace zruší naplánovaný požadavek.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Zavolejte z vlákna na pozadí a předáte context.getFilesDir(), který obsahuje sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Zastavení před zpracováním dalšího snímku**

Použijte stejný [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) pro prezentaci i smyčku, která exportuje její snímky. Před každým exportem zkontrolujte [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) zda nebylo požádáno o přerušení. Pokud může volající použít částečný výsledek, vraťte čísla snímků, které byly úspěšně exportovány.

Použijte prezentaci pojmenovanou `sample.pptx` s alespoň dvěma snímky. Přetížení [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) , které přijímá pole čísel snímků, počítá od 1. Příklad uloží každý snímek do samostatného PDF a požádá o zrušení ihned po záznamu prvního úspěšného exportu.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
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

    // Zavolejte z vlákna na pozadí a předáte context.getFilesDir(), který obsahuje sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Příklad zapíše `slide-1.pdf` a vytiskne `Starting slide 1` následované `Completed: [1]`. Smyčka zaznamená požadavek před zahájením snímku 2. Pokud během ukládání dorazí zrušení, smyčka ukončí před záznamem, že snímek byl dokončen.

Pokud volající potřebuje zrušení zpracovat, nahraďte kontrolu a její `break` na začátku smyčky voláním `token.throwIfInterruptionRequested()`. Odstraňte `try`/`catch` kolem ukládání, aby zrušení během exportu také dosáhlo volajícího. Se stejným vstupem příklad vytiskne pouze `Starting slide 1` a zapíše `slide-1.pdf`. Na začátku druhé iterace [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) vyhodí `com.aspose.slides.exceptions.OperationCanceledException` před zahájením dalšího exportu. Metoda nevrací žádný seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**

Požádejte o zrušení, když operace překročí váš časový limit nebo když vaše aplikace už výsledek nepotřebuje.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Zdroj umožňuje vaší aplikaci požádat o zrušení. Token umožňuje Aspose.Slides i vaší aplikaci kontrolovat, zda byl požadavek podán.

**Mohu zrušit operaci z časovače Java?**

Ano. Naplánujte volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) na zdroj spojený s prezentací.

**Které operace mohu přerušit?**

Můžete přerušit načítání, ukládání a vykreslování. Předávejte token konstruktoru [konstruktor Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) pomocí [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Prezentace pak může zaznamenat zrušení během následných operací, například ukládání do PDF.

**Zastaví se operace okamžitě?**

Zrušení je kooperativní. Operace pravidelně kontroluje token a zastaví se, když zaznamená požadavek.

**Co se stane, když zavolám [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) po dokončení operace?**

Dokončená operace si ponechá svůj výsledek.

**Mohou si více operací sdílet [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Ano. Zavolání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Pro každou operaci, kterou chcete zrušit nezávisle, použijte samostatný zdroj.