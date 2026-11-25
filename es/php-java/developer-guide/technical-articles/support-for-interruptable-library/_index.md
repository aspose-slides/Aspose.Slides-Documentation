---
title: Interrumpir operaciones de presentación de larga duración en PHP
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 120
url: /es/php-java/support-for-interruptable-library/
keywords:
- token de interrupción
- cancelación
- tiempo de espera de conversión
- exportación de diapositivas
- PowerPoint
- PHP
- Aspose.Slides
description: "Aprenda a cancelar una conversión de presentación mediante un temporizador y a devolver las diapositivas exportadas antes de la cancelación con Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Aspose.Slides for PHP via Java puede interrumpir operaciones de larga duración como la carga, el guardado y la renderización de presentaciones. En un bucle que exporta una diapositiva a la vez, el mismo token permite que su aplicación se detenga antes de la siguiente diapositiva y devuelva una lista de exportaciones completadas.

Ambos ejemplos PHP asumen que su bootstrap ejecuta `define("JAVA_PREFER_VALUES", 1);` antes de cargar el `Java.inc` del puente, y luego carga `aspose.slides.php`. Esta configuración permite que PHP capture excepciones Java durante la llamada. Los ejemplos inspeccionan la causa de la excepción envuelta para que otros errores de conversión lleguen al llamador.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), obtenga su token con [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken), y páselo a [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Proporcione estas opciones al crear el [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Llamar a [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) solicita la cancelación. Una operación en ejecución se detiene cuando observa la solicitud.

### **Establecer un tiempo de espera de conversión**

Mientras PHP espera una carga o guardado sincrónico a través del PHP/Java Bridge, un temporizador Java puede solicitar la cancelación en un hilo separado. Guarde el siguiente helper como `ConversionTimeout.java`, complílelo con el JAR de Aspose.Slides en el classpath y haga que la clase compilada esté disponible para el puente bajo su nombre de paquete, `example.ConversionTimeout`.

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

Con el puente y el wrapper PHP de Aspose.Slides cargados, ejecute el siguiente ejemplo con `sample.pptx` en el directorio de trabajo del proceso Java, o utilice rutas absolutas accesibles para ese proceso. El límite de 20 segundos cubre tanto la carga como la exportación a PDF. Si la conversión termina antes, PHP cancela el temporizador. Para convertir al formato PowerPoint más antiguo con un límite de 10 segundos, use `sample.ppt`, `SaveFormat::Ppt` y `10000` milisegundos.

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

## **Detener antes de procesar la siguiente diapositiva**

Compruebe [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportación. La sobrecarga de [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) para diapositivas seleccionadas acepta números de diapositiva a partir de 1. Pase una matriz de un solo elemento para escribir un PDF separado para cada diapositiva.

Utilice un `sample.pptx` con al menos dos diapositivas. Para demostrar la cancelación entre exportaciones, el ejemplo la solicita inmediatamente después de registrar la primera diapositiva.

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

El ejemplo escribe `slide-1.pdf` y muestra `Completed: [1]`. La segunda iteración ve la solicitud antes de iniciar otra exportación. Si la cancelación ocurre durante un guardado, la lista contiene solo las exportaciones confirmadas previamente. Un guardado interrumpido puede dejar un archivo incompleto en el disco.

Para propagar la cancelación al llamador, reemplace la comprobación al inicio del bucle con `$token->throwIfInterruptionRequested();` y elimine el `try`/`catch` interno, manteniendo el guardado y la comprobación que le sigue. Con la misma entrada, [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) lanza una excepción antes de la diapositiva 2 y el llamador no recibe lista.

## **Preguntas frecuentes**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando expire una fecha límite o el llamador ya no necesite el resultado. Una solicitud realizada después de que una operación finalice deja su resultado intacto.

**¿En qué se diferencian la fuente y el token?**

La fuente permite que una aplicación solicite la cancelación. El token permite que Aspose.Slides y el código de la aplicación observen esa solicitud.

**¿Pueden varias operaciones compartir una fuente?**

Sí. Una solicitud se aplica a todas las operaciones que usan tokens de esa fuente. Cree fuentes separadas para operaciones que necesiten cancelación independiente.