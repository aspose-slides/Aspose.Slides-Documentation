---
title: Hosszú ideig futó prezentációs műveletek megszakítása Androidon
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 120
url: /hu/androidjava/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- leállítási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet megszakítani a hosszú ideig futó prezentációs műveleteket az Aspose.Slides for Android via Java-ban, és hogyan adhat vissza részleges eredményt a diák ciklusos exportálása során."
---
## **Áttekintés**

Aspose.Slides for Android via Java megszakíthatja a hosszú ideig futó műveleteket, például a prezentációk betöltését, mentését és renderelését. Az alkalmazás ugyanazzal a megszakítási tokennel le tudja állítani a ciklust, mielőtt a következő diát feldolgozná.

## **Prezentáció művelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), szerezze meg a tokenjét a [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--) metódussal, és adja át a tokent a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) metódusnak. Adja át a betöltési beállításokat a [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) metódusnak. A leállítás kéréséhez hívja meg a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) metódust a forráson. Egy megszakítható művelet leáll, amikor észleli a kérést.

A példa a `sample.pptx` fájlt `sample.ppt`-re konvertálja egy háttérszálon. A hívó szál legfeljebb 10 másodpercig vár a konverzió befejezésére. Ha a konverzió még fut, leállítási kérést küld, majd várja, hogy a munkás kilépjen.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Hívja egy háttérszálról, és adja át a context.getFilesDir()-t, amely a sample.pptx fájlt tartalmazza.
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

## **Java időkorlát csatlakoztatása az Aspose.Slides-hez**

Egy prezentációs művelet időkorlátjának beállításához használjon egy [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService)-t, amely a határidő lejártakor meghívja a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) metódust. A példa 20 másodpercet engedélyez a `sample.pptx` betöltésére és `sample.pdf`-ként való exportálására. Ha az export korábban befejeződik, az alkalmazás törli a tervezett kérést.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Hívja egy háttérszálról, és adja át a context.getFilesDir()-t, amely a sample.pptx fájlt tartalmazza.
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

## **Állítsa le a következő dia feldolgozása előtt**

Használja ugyanazt az [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) objektumot a prezentációhoz és a diák exportálásáért felelős ciklushoz. Ellenőrizze a [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) állapotát minden exportálás előtt. Ha a felhasználó részleges eredményt tud elfogadni, adja vissza az azoknak megfelelő dia számokat, amelyek sikeresen exportálódtak.

Használjon egy `sample.pptx` nevű prezentációt, amely legalább két diát tartalmaz. A [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) túlterhelés, amely diaszámokat vár tömbként, az 1‑től számít. A példa minden diát külön PDF-be ment, és az első sikeres export után azonnal kéri a megszakítást.

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

    // Hívja egy háttérszálról, és adja át a context.getFilesDir()-t, amely a sample.pptx fájlt tartalmazza.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

A példa `slide-1.pdf`‑t ír ki, és a `Starting slide 1` üzenetet követi a `Completed: [1]` kimenet. A ciklus a kérés észlelése után nem kezdi el a 2. diát. Ha a megszakítás a mentés közben érkezik, a ciklus kilép, mielőtt a diát befejezettként jelölné.

Ha a hívónak kezelnie kell a leállítást, cserélje le az ellenőrzést és a `break`‑et a ciklus elején a `token.throwIfInterruptionRequested()` hívásra. Távolítsa el a `try`/`catch`‑t a mentés körül, hogy a leállítás is elérje a hívót. Ugyanazzal a bemenettel a példa csak a `Starting slide 1` sort írja ki és a `slide-1.pdf` fájlt hozza létre. A második iteráció elején a [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException` kivételt dob, mielőtt a következő export elkezdődne. A metódus nem ad vissza listát.

## **GYIK**

**Mikor kell leállítást kérni?**

Kérjen leállítást, ha egy művelet túllépi az időkorlátját, vagy ha az alkalmazás már nem szükséges az eredményre.

**Mi a különbség a [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) és a [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/) között?**

A forrás lehetővé teszi a leállítás kérését az alkalmazás számára. A tokenet az Aspose.Slides és az alkalmazás ellenőrzi a kérés meglétéért.

**Leforgathatok egy műveletet egy Java időzítőről?**

Igen. Ütemezzen egy hívást a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) metódusra a prezentációval összekapcsolt forráson.

**Mely műveleteket lehet megszakítani?**

Betöltést, mentést és renderelést lehet megszakítani. Adja át a tokent a [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) meghívásakor a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) segítségével. A prezentáció ezután a későbbi műveletek, például a PDF‑mentés során észlelheti a leállítást.

**Azonnal leáll a művelet?**

A leállítás együttműködő. A művelet időközönként ellenőrzi a tokent, és a kérés észlelésekor megáll.

**Mi történik, ha a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) hívást a művelet befejezése után hajtom végre?**

A már befejezett művelet megőrizze az eredményét.

**Több művelet is oszthat egy [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)-t?**

Igen. A [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) minden olyan műveletet leállít, amely az adott forrás tokenjét használja. Ha egyes műveleteket függetlenül szeretne leállítani, használjon külön forrást minden művelethez.