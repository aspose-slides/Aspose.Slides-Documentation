---
title: Interrumpir operaciones de presentación de larga duración en Python
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 150
url: /es/python-net/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
- token de interrupción
- cancelar exportación de PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Aprende cómo cancelar una conversión de presentación en Python y devolver la lista de diapositivas que terminaron de exportarse antes de la cancelación."
---
## **Visión general**

Aspose.Slides para Python a través de .NET admite la cancelación cooperativa durante operaciones de larga duración, como cargar, guardar y renderizar presentaciones. Cuando exportas diapositivas individualmente, también puedes comprobar la cancelación entre diapositivas y devolver los números de las diapositivas que terminaron de exportarse.

## **Cancelar una conversión de presentación**

Crea un [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), asigna su [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) a [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), y pasa las opciones al [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). El token se aplica a la presentación durante todo su ciclo de vida. Para solicitar la cancelación desde tu aplicación, llama a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

El ejemplo convierte `sample.pptx` a `sample.pdf`. Un [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) llama a `source.interrupt` después de 20 segundos. Iniciar el temporizador antes de abrir el archivo hace que el tiempo de espera se aplique tanto a la carga como al guardado. Una aplicación con un botón Cancelar puede llamar al mismo método desde su controlador de eventos.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

La comprobación explícita después de cargar omite la exportación si el tiempo de espera ya ha transcurrido. Si la carga o el guardado observan la solicitud, la excepción de cancelación llega al llamador. Un guardado también puede finalizar antes de observar la solicitud, en cuyo caso el PDF está completo.

## **Detener antes de procesar la siguiente diapositiva**

Comprueba [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) antes de cada exportación. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) acepta una lista de números de diapositiva comenzando en 1. Añade un número a la lista de completados sólo después de que su PDF se haya guardado correctamente.

Utiliza un archivo llamado `sample.pptx` con al menos dos diapositivas. Para que el resultado sea reproducible, el ejemplo solicita la cancelación tan pronto como la diapositiva 1 termine. En una aplicación, la solicitud puede provenir de otro hilo mientras se guarda una diapositiva.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. La siguiente iteración detecta la solicitud antes de iniciar la diapositiva 2. Si la cancelación interrumpe un guardado, el controlador de excepciones devuelve los números registrados por iteraciones anteriores. Otros errores de exportación llegan al llamador.

Si el llamador debe manejar la cancelación como una excepción, sustituye la comprobación y su `break` al inicio del bucle por [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). También elimina el `try`/`except` alrededor del guardado. Con la misma entrada, la diapositiva 1 se guarda y la segunda iteración lanza una excepción de cancelación antes de iniciar la diapositiva 2.

## **Preguntas frecuentes**

**¿Cuándo entra en vigor una solicitud de cancelación?**

Una operación que puede ser interrumpida verifica su token periódicamente. Se detiene cuando observa la solicitud. Una operación que ya ha finalizado conserva su resultado.

**¿Cuál es la diferencia entre la fuente y el token?**

La fuente permite que tu aplicación solicite la cancelación. El token permite que tanto la presentación como tu propio código comprueben esa solicitud.

**¿Pueden varias operaciones compartir una fuente?**

Sí. Llamar a `interrupt` solicita la cancelación de todas las operaciones que usan un token de esa fuente. Asigna a cada operación su propia fuente si necesitas cancelarla de forma independiente.