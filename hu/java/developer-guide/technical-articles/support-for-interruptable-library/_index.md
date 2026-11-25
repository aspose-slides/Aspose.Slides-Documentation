---
title: Hosszú ideig futó prezentációs műveletek megszakítása Java-ban
linktitle: Prezentációs műveletek megszakítása
type: docs
weight: 120
url: /hu/java/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- leállítási token
- hosszú ideig futó feladat
- feladat megszakítása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet megszakítani a hosszú ideig futó prezentációs műveleteket az Aspose.Slides for Java-ban, és részleges eredményt visszaadni a diák ciklikus exportálása során."
---
## **Áttekintés**

Az Aspose.Slides for Java képes megszakítani a hosszú ideig futó műveleteket, például a prezentációk betöltését, mentését és renderelését. Az alkalmazása ugyanazt az megszakítási tokent használhatja a ciklus leállításához, mielőtt a következő diát feldolgozná.

## **Prezentációs művelet megszakítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), szerezze meg a tokenjét a [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--)- segítségével, és adja át a tokent a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)-nek. Adja át a betöltési beállításokat a [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)-nek. A megszakítás kéréséhez hívja meg a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)‑t a forráson. Egy megszakítható művelet leáll, amikor észleli a kérést.

Az példa a `sample.pptx` fájlt `sample.ppt`‑re konvertálja egy háttérszálon. A hívó szál legfeljebb 10 másodpercig vár a konverzió befejezésére. Ha a konverzió még fut, a példa megszakítást kér és várja, hogy a munkavégző szál kilépjen.

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

## **Java időkorlát csatlakoztatása az Aspose.Slides-hez**

A prezentációs művelet időkorlátának beállításához használjon egy [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html)-t, amely a időkorlát lejártakor meghívja a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)‑t. A példa 20 másodpercet engedélyez a `sample.pptx` betöltésére és `sample.pdf`‑ként való exportálására. Ha az export korábban befejeződik, az alkalmazás leállítja az időzített kérést.

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

## **Álljon meg a következő dia feldolgozása előtt**

Használja ugyanazt a [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/)‑t a prezentációhoz és ahhoz a ciklushoz, amely a diákat exportálja. Ellenőrizze a [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) metódust minden export előtt. Ha a hívó részleges eredményt tud felhasználni, adja vissza a sikeresen befejezett exportok diaszámait.

Használjon egy `sample.pptx` nevű prezentációt, amely legalább két diát tartalmaz. A [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-)‑nak az a túlterhelése, amely diák számait tartalmazó tömböt vár, az 1‑től számlál. A példa minden diát külön PDF‑be ment, és a első sikeres export rögzítése után azonnal kéri a megszakítást.

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

A példa a `slide-1.pdf` fájlt írja, és kiírja a `Starting slide 1` üzenetet, majd a `Completed: [1]`‑et. A ciklus a kérést a 2. dia indítása előtt észleli. Ha a megszakítás a mentés közben érkezik, a ciklus kilép, mielőtt a diát befejezettként rögzítené.

Ha a hívónak kezelnie kell a megszakítást, cserélje le a ciklus elején lévő ellenőrzést és annak `break`‑jét a `token.throwIfInterruptionRequested()`‑re. Távolítsa el a `try`/`catch` blokkot a mentés körül, hogy az export közbeni megszakítás is eljusson a hívóhoz. Ugyanazzal a bemenettel a példa csak a `Starting slide 1` üzenetet írja ki, és a `slide-1.pdf` fájlt hozza létre. A második iteráció elején a [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) `com.aspose.slides.exceptions.OperationCanceledException`‑t dob, mielőtt a következő export elindulna. A metódus nem ad vissza listát.

## **GYIK**

**Mikor kérjek megszakítást?**

Kérjen megszakítást, ha egy művelet meghaladja az időkorlátját, vagy ha az alkalmazása már nem igényli az eredményt.

**Mi a különbség az [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) és az [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) között?**

A forrás lehetővé teszi, hogy az alkalmazása megszakítást kérjen. A token pedig az Aspose.Slides és az alkalmazása számára ellenőrzésre ad lehetőséget.

**Törölhetek‑e egy műveletet egy Java időzítőből?**

Igen. Ütemezzen egy hívást a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) metódusra a prezentációhoz tartozó forráson.

**Milyen műveleteket szakthatok meg?**

Megszakíthatja a betöltést, a mentést és a renderelést. Adja át a tokent a [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-)‑nek a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-)‑en keresztül. A prezentáció ezután a későbbi műveletek, például a PDF‑ba mentés során is észlelheti a megszakítást.

**Áll le egy művelet azonnal?**

A megszakítás együttműködésen alapul. A művelet időközönként ellenőrzi a tokent, és a kérés észlelésekor leáll.

**Mi történik, ha a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--)‑t a művelet befejezése után hívom?**

Az befejezett művelet megtartja az eredményét.

**Több művelet megoszthatja ugyanazt az [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)‑t?**

Igen. A [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) hívása a forrásból származó tokent használó összes műveletet megszakításra kéri. Használjon külön forrást minden olyan művelethez, amelyet önállóan kíván megszakítani.