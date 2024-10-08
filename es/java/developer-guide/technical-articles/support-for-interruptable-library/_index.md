---
title: Soporte para la Biblioteca Interrumpible
type: docs
weight: 120
url: /es/java/support-for-interruptable-library/
---

## **Biblioteca Interrumpible**
Ahora en Aspose.Slides se han añadido las estructuras InterruptionToken y la clase InterruptionTokenSource. Estos tipos soportan la interrupción de tareas de larga duración, como deserialización, serialización o renderizado. InterruptionTokenSource representa la fuente del token o múltiples tokens pasados a **ILoadOptions.InterruptionToken**. Cuando ILoadOptions.InterruptionToken está configurado y esta instancia de LoadOptions se pasa al constructor de Presentation, cualquier tarea de larga duración relacionada con esta Presentación será interrumpida cuando se invoque el método InterruptionTokenSource.Interrupt.

El fragmento de código a continuación demuestra la interrupción de una tarea en ejecución.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}