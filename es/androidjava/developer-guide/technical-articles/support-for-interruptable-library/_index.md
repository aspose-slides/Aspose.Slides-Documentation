---
title: Interrumpir operaciones de presentación de larga duración en Android
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 120
url: /es/androidjava/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo cancelar operaciones de presentación de larga duración en Aspose.Slides para Android mediante Java y devolver un resultado parcial al exportar diapositivas en un bucle."
---
## **Descripción general**

Aspose.Slides for Android via Java puede interrumpir operaciones de larga duración, como cargar, guardar y renderizar presentaciones. Su aplicación puede usar el mismo token de interrupción para detener un bucle antes de que comience a procesar la diapositiva siguiente.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), obtenga su token con [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), y pase el token a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Pase las opciones de carga al [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Para solicitar la cancelación, llame a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) en la fuente. Una operación interrumpible se detiene cuando observaa la solicitud.

El ejemplo convierte `sample.pptx` a `sample.ppt` en un hilo en segundo plano. El hilo que llama espera hasta 10 segundos a que termine la conversión. Si la conversión sigue en ejecución, solicita la cancelación y espera a que el trabajador finalice.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Llame desde un hilo en segundo plano y pase context.getFilesDir(), que contiene sample.pptx.
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

## **Conectar un tiempo de espera de Java a Aspose.Slides**

Para establecer un límite de tiempo en una operación de presentación, use un [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) para llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) cuando el tiempo de espera expire. El ejemplo permite 20 segundos para cargar `sample.pptx` y exportarlo a `sample.pdf`. Si la exportación finaliza antes, la aplicación cancela la solicitud programada.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Llame desde un hilo en segundo plano y pase context.getFilesDir(), que contiene sample.pptx.
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

## **Detenerse antes de procesar la diapositiva siguiente**

Utilice el mismo [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) para la presentación y el bucle que exporta sus diapositivas. Compruebe [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) antes de cada exportación. Si el llamador puede usar un resultado parcial, devuelva los números de diapositiva de las exportaciones que se completaron con éxito.

Use una presentación llamada `sample.pptx` con al menos dos diapositivas. La sobrecarga de [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) que acepta una matriz de números de diapositiva cuenta a partir de 1. El ejemplo guarda cada diapositiva en un PDF separado y solicita la cancelación inmediatamente después de registrar la primera exportación exitosa.

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

    // Llame desde un hilo en segundo plano y pase context.getFilesDir(), que contiene sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. El bucle observa la solicitud antes de iniciar la diapositiva 2. Si la cancelación llega durante una guardada, el bucle sale antes de registrar esa diapositiva como completada.

Si el llamador necesita gestionar la cancelación, reemplace la comprobación y su `break` al comienzo del bucle por `token.throwIfInterruptionRequested()`. Elimine el `try`/`catch` alrededor de la guardada para que la cancelación durante una exportación también llegue al llamador. Con la misma entrada, el ejemplo muestra solo `Starting slide 1` y escribe `slide-1.pdf`. Al inicio de la segunda iteración, [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lanza `com.aspose.slides.exceptions.OperationCanceledException` antes de que comience la siguiente exportación. El método no devuelve ninguna lista.

## **FAQ**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando una operación supere su límite de tiempo o cuando su aplicación ya no necesite el resultado.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

La fuente permite que su aplicación solicite la cancelación. El token permite que Aspose.Slides y su aplicación verifiquen esa solicitud.

**¿Puedo cancelar una operación desde un temporizador de Java?**

Sí. Programe una llamada a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) en la fuente asociada a la presentación.

**¿Qué operaciones puedo interrumpir?**

Puede interrumpir la carga, el guardado y el renderizado. Pase el token al [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) mediante [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). La presentación podrá observar la cancelación durante operaciones posteriores, como guardar en PDF.

**¿Una operación se detiene inmediatamente?**

La cancelación es cooperativa. Una operación comprueba el token periódicamente y se detiene cuando observa la solicitud.

**¿Qué ocurre si llamo a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) después de que una operación haya finalizado?**

La operación completada conserva su resultado.

**¿Pueden varias operaciones compartir un [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/)?**

Sí. Llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) solicita la cancelación para cada operación que use un token de esa fuente. Utilice una fuente distinta para cada operación que desee cancelar de forma independiente.