---
title: Soporte Para Biblioteca Interrumpible
type: docs
weight: 120
url: /php-java/support-for-interruptable-library/
---

## **Biblioteca Interrumpible**
Ahora en Aspose.Slides se han añadido las estructuras InterruptionToken y la clase InterruptionTokenSource. Estos tipos admiten la interrupción de tareas de larga duración, como la deserialización, la serialización o el renderizado. InterruptionTokenSource representa la fuente del token o múltiples tokens pasados a **ILoadOptions.InterruptionToken**. Cuando ILoadOptions.InterruptionToken está establecido y esta instancia de LoadOptions se pasa al constructor de Presentation, cualquier tarea de larga duración relacionada con esta Presentación se interrumpirá cuando se invoque el método InterruptionTokenSource.Interrupt.

El fragmento de código a continuación demuestra la interrupción de una tarea en ejecución.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Properties-SupportForInterrupt-SupportForInterrupt.java" >}}