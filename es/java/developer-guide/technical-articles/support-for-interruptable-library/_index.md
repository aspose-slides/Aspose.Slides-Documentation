---
title: Soporte para la biblioteca interrumpible
type: docs
weight: 120
url: /es/java/support-for-interruptable-library/
keywords:
- biblioteca interrumpible
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Haga que las tareas de larga duración sean cancelables con Aspose.Slides para Java. Interrumpa el renderizado y las conversiones de PowerPoint y OpenDocument de forma segura, con ejemplos."
---

## **Biblioteca Interrumpible**

En [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), introdujimos las clases [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/). Permiten interrumpir tareas de larga duración como deserialización, serialización y renderizado.

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) es la fuente del(los) token(s) pasado(s) a [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Cuando se establece [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) y la instancia de [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) se pasa al constructor de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), invocar [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) interrumpe cualquier tarea de larga duración asociada a esa [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // ejecuta la acción en un hilo separado
Thread.sleep(10000);     // tiempo de espera
tokenSource.interrupt(); // detener la conversión
```


## **Preguntas frecuentes**

**¿Cuál es el propósito de la biblioteca de interrupción de Aspose.Slides?**

Proporciona un mecanismo para interrumpir operaciones de larga duración —como cargar, guardar o renderizar presentaciones— antes de que finalicen. Esto es útil cuando el tiempo de procesamiento debe ser limitado o la tarea ya no es necesaria.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` se pasa a la API de Aspose.Slides y se verifica durante operaciones de larga duración.
- `InterruptionTokenSource` se usa en su código para crear tokens y activar interrupciones llamando a `Interrupt()`.

**¿Qué tareas pueden ser interrumpidas?**

Cualquier tarea de Aspose.Slides que acepte un [InterruptionToken] —como cargar una presentación con `Presentation(path, loadOptions)` o guardar con `Presentation.save(...)`— puede ser interrumpida.

**¿La interrupción ocurre inmediatamente?**

No. La interrupción es cooperativa: la operación verifica periódicamente el token y se detiene tan pronto como detecta que se ha llamado a [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--).

**¿Qué sucede si llamo a [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) después de que una tarea ya haya finalizado?**

Nada: la llamada no tiene efecto si la tarea correspondiente ya ha finalizado.

**¿Puedo reutilizar el mismo [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) para múltiples tareas?**

Sí, pero después de llamar a [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) en esa fuente, todas las tareas que usen sus tokens serán interrumpidas. Utilice fuentes de tokens separadas para gestionar las tareas de forma independiente.