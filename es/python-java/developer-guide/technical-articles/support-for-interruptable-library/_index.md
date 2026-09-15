---
title: Soporte para una biblioteca interrumpible
type: docs
weight: 120
url: /es/python-java/support-for-interruptable-library/
keywords:
- biblioteca interrumpible
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
description: "Haz que las tareas de larga duración sean cancelables con Aspose.Slides para Python a través de Java. Interrumpe de forma segura el renderizado y las conversiones de PowerPoint y OpenDocument, con ejemplos."
---
## **Visión general**

Aspose.Slides proporciona un mecanismo de procesamiento interrumpible para tareas de presentación de larga duración, como deserialización, serialización y renderizado. Este mecanismo se basa en las clases [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/).

Un [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/) puede asignarse a [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/) y pasarse al constructor de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/). Cuando se llama a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt), la tarea de larga duración asociada se interrumpe.

## **Biblioteca interrumpible**

Aspose.Slides para Python a través de Java proporciona las clases [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/). Permiten interrumpir tareas de larga duración como deserialización, serialización y renderizado.

- [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/) es la fuente del (de los) token(s) que se pasa(n) a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Cuando se llama a [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setInterruptionToken) y la instancia de [LoadOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/) se pasa al constructor de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), invocar [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt) interrumpe cualquier tarea de larga duración asociada a ese [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).

El siguiente fragmento de código muestra cómo interrumpir una tarea en ejecución:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Ejecuta la acción en un hilo separado.
    time.sleep(10)  # Tiempo de espera.
    token_source.interrupt()  # Detener la conversión.
    conversion_task.result()
```

## **Preguntas frecuentes**

**¿Cuál es el propósito de la biblioteca de interrupción de Aspose.Slides?**

Proporciona un mecanismo para interrumpir operaciones de larga duración —como cargar, guardar o renderizar presentaciones— antes de que finalicen. Esto es útil cuando el tiempo de procesamiento debe limitarse o la tarea ya no es necesaria.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/) se pasa a la API de Aspose.Slides y se verifica durante las operaciones de larga duración.
- [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/) se utiliza en el código para crear tokens y desencadenar interrupciones llamando a [interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt).

**¿Qué tareas pueden interrumpirse?**

Cualquier tarea de Aspose.Slides que acepte un [InterruptionToken](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontoken/), como cargar una presentación con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) o guardar con [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save), puede interrumpirse.

**¿La interrupción ocurre de inmediato?**

No. La interrupción es cooperativa: la operación comprueba periódicamente el token y se detiene tan pronto como detecta que se ha llamado a [interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt).

**¿Qué ocurre si llamo a [interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt) después de que una tarea ya haya finalizado?**

Nada: la llamada no tiene efecto si la tarea correspondiente ya ha concluido.

**¿Puedo reutilizar el mismo [InterruptionTokenSource](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/) para varias tareas?**

Sí, pero después de llamar a [interrupt](https://reference.aspose.com/slides/es/python-java/aspose.slides/interruptiontokensource/#interrupt) en esa fuente, todas las tareas que utilicen sus tokens serán interrumpidas. Use fuentes de tokens separadas para gestionar las tareas de forma independiente.