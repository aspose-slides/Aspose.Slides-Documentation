---
title: Interrumpir operaciones de presentación de larga duración en Java
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 120
url: /es/java/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo cancelar operaciones de presentación de larga duración en Aspose.Slides para Java y devolver un resultado parcial al exportar diapositivas en un bucle."
---
## **Visión general**

Aspose.Slides for Java puede interrumpir operaciones de larga duración como cargar, guardar y renderizar presentaciones. Su aplicación puede usar el mismo token de interrupción para detener un bucle antes de que comience a procesar la diapositiva siguiente.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), obtenga su token con [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), y pase el token a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Pase las opciones de carga al [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Para solicitar la cancelación, llame a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) en la fuente. Una operación interrumpible se detiene cuando observa la solicitud.

El ejemplo convierte `sample.pptx` a `sample.ppt` en un hilo en segundo plano. El hilo que llama espera hasta 10 segundos para que finalice la conversión. Si la conversión sigue ejecutándose, solicita la cancelación y espera a que el trabajador termine.

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

## **Conectar un tiempo de espera de Java a Aspose.Slides**

Para establecer un límite de tiempo en una operación de presentación, utilice un [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) para llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) cuando expire el tiempo de espera. El ejemplo permite 20 segundos para cargar `sample.pptx` y exportarlo a `sample.pdf`. Si la exportación finaliza antes, la aplicación cancela la solicitud programada.

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

## **Detenerse antes de procesar la diapositiva siguiente**

Utilice el mismo [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) para la presentación y el bucle que exporta sus diapositivas. Verifique [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) antes de cada exportación. Si el llamador puede usar un resultado parcial, devuelva los números de diapositiva de las exportaciones que se completaron con éxito.

Utilice una presentación llamada `sample.pptx` con al menos dos diapositivas. La sobrecarga de [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) que recibe una matriz de números de diapositiva cuenta a partir de 1. El ejemplo guarda cada diapositiva en un PDF separado y solicita la cancelación inmediatamente después de registrar la primera exportación exitosa.

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

El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. El bucle observa la solicitud antes de iniciar la diapositiva 2. Si la cancelación llega durante un guardado, el bucle sale antes de registrar esa diapositiva como completa.

Si el llamador necesita manejar la cancelación, reemplace la verificación y su `break` en la parte superior del bucle por `token.throwIfInterruptionRequested()`. Elimine el `try`/`catch` alrededor del guardado para que la cancelación durante una exportación también llegue al llamador. Con la misma entrada, el ejemplo solo muestra `Starting slide 1` y escribe `slide-1.pdf`. Al comienzo de la segunda iteración, [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) lanza `com.aspose.slides.exceptions.OperationCanceledException` antes de que comience la siguiente exportación. El método no devuelve ninguna lista.

## **Preguntas frecuentes**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando una operación supere su límite de tiempo o cuando su aplicación ya no necesite el resultado.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

La fuente permite que su aplicación solicite la cancelación. El token permite que Aspose.Slides y su aplicación verifiquen esa solicitud.

**¿Puedo cancelar una operación desde un temporizador Java?**

Sí. Programe una llamada a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) en la fuente asociada a la presentación.

**¿Qué operaciones puedo interrumpir?**

Puede interrumpir la carga, el guardado y el renderizado. Pase el token al [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) mediante [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Entonces la presentación podrá observar la cancelación durante operaciones posteriores, como guardar a PDF.

**¿Se detiene una operación inmediatamente?**

La cancelación es cooperativa. Una operación verifica el token periódicamente y se detiene cuando observa la solicitud.

**¿Qué ocurre si llamo a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) después de que una operación finalice?**

La operación completada conserva su resultado.

**¿Pueden varias operaciones compartir un [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Sí. Llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) solicita la cancelación de todas las operaciones que utilizan un token de esa fuente. Utilice una fuente distinta para cada operación que desee cancelar de forma independiente.