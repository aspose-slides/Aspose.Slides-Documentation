---
title: Interrumpir operaciones de presentación de larga duración en Python
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 120
url: /es/python-java/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprenda a cancelar operaciones de presentación de larga duración en Aspose.Slides para Python mediante Java y a devolver un resultado parcial al exportar diapositivas en un bucle."
---
## **Visión general**

Aspose.Slides for Python via Java puede interrumpir operaciones de larga duración como la carga, el guardado y el renderizado de presentaciones. Su aplicación puede utilizar el mismo token de interrupción para detener un bucle antes de que comience a procesar la diapositiva siguiente.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), obtenga su token con [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken) y pase el token a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Pase las opciones de carga al [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Para solicitar la cancelación, llame a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) en la fuente. Una operación interrumpible se detiene cuando observa la solicitud. Utilice `jpype.JClass` para capturar la excepción Java `com.aspose.slides.exceptions.OperationCanceledException` en Python.

El ejemplo convierte `sample.pptx` a `sample.ppt` en un hilo en segundo plano. El hilo que llama espera hasta 10 segundos a que termine la conversión. Si la conversión sigue en ejecución, solicita la cancelación y espera a que el trabajador finalice.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Conectar un tiempo de espera de Python a Aspose.Slides**

Para establecer un límite de tiempo en una operación de presentación, utilice un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) para llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) cuando el tiempo de espera expire. El ejemplo permite 20 segundos para cargar `sample.pptx` y exportarlo a `sample.pdf`. Si la exportación finaliza antes, la aplicación cancela la solicitud programada.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Detener antes de procesar la diapositiva siguiente**

Utilice el mismo [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) para la presentación y el bucle que exporta sus diapositivas. Compruebe [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) antes de cada exportación. Si el llamador puede usar un resultado parcial, devuelva los números de diapositiva de las exportaciones que se completaron con éxito.

Utilice una presentación llamada `sample.pptx` con al menos dos diapositivas. La sobrecarga de [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) que acepta un `int[]` Java usa números de diapositiva que comienzan en 1. Utilice `jpype.JArray(jpype.JInt)` para construir esa matriz en Python. El ejemplo guarda cada diapositiva en un PDF separado y solicita la cancelación inmediatamente después de registrar la primera exportación exitosa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. El bucle observa la solicitud antes de iniciar la diapositiva 2. Si la cancelación llega durante una guardada, el bucle sale antes de registrar esa diapositiva como completa.

Si el llamador necesita gestionar la cancelación, sustituya la comprobación y su `break` al principio del bucle por `token.throwIfInterruptionRequested()`. Elimine el `try`/`except` alrededor del guardado para que la cancelación durante una exportación también llegue al llamador. Con la misma entrada, el ejemplo muestra solo `Starting slide 1` y escribe `slide-1.pdf`. Al inicio de la segunda iteración, [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) genera `com.aspose.slides.exceptions.OperationCanceledException` antes de que comience la siguiente exportación. La excepción se propaga al llamador antes de que la función pueda devolver la lista.

## **Preguntas frecuentes**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando una operación supere su límite de tiempo o cuando su aplicación ya no necesite el resultado.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

La fuente permite que su aplicación solicite la cancelación. El token permite que Aspose.Slides y su aplicación comprueben esa solicitud.

**¿Puedo cancelar una operación desde un temporizador de Python?**

Sí. Programe una llamada a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) en la fuente asociada a la presentación.

**¿Qué operaciones puedo interrumpir?**

Puede interrumpir la carga, el guardado y el renderizado. Pase el token al [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) mediante [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). La presentación podrá observar la cancelación durante operaciones posteriores, como guardar en PDF.

**¿Se detiene una operación inmediatamente?**

La cancelación es cooperativa. Una operación verifica el token periódicamente y se detiene cuando observa la solicitud.

**¿Qué ocurre si llamo a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) después de que una operación termine?**

La operación completada mantiene su resultado.

**¿Pueden varias operaciones compartir un [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**

Sí. Llamar a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) solicita la cancelación de todas las operaciones que utilizan un token de esa fuente. Utilice una fuente separada para cada operación que desee cancelar de forma independiente.