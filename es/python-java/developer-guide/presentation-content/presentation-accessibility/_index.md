---
title: Gestionar la accesibilidad de presentaciones en Python mediante Java
linktitle: Accesibilidad de presentaciones
type: docs
weight: 30
url: /es/python-java/presentation-accessibility/
keywords:
- accesibilidad de presentaciones
- marcar como decorativo
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python mediante Java ayuda a automatizar las comprobaciones de accesibilidad de presentaciones en archivos PPT, PPTX y ODP — mejore la experiencia del lector de pantalla y aumente el cumplimiento."
---
## **Introducción**

La accesibilidad de las presentaciones garantiza que las personas que utilizan tecnologías de asistencia —como lectores de pantalla, pantallas braille o navegación solo con teclado— puedan comprender y navegar tus diapositivas con la misma eficacia que la audiencia con visión y ratón. Las buenas prácticas se centran en un orden de lectura claro, texto alternativo significativo para los elementos visuales informativos, contraste de color suficiente, tipografía legible, texto descriptivo en los enlaces y evitar transmitir significado únicamente mediante color o posición. Cuando la accesibilidad se planifica desde el principio, el resultado es una estructura más limpia, gráficos más coherentes y contenido que llega a todos los espectadores sin soluciones alternativas.

## **Marcar como decorativo**

Marcar como decorativo indica que los elementos visuales son puramente ornamentales, de modo que los lectores de pantalla los omiten, reduciendo el ruido y manteniendo la atención en el contenido relevante. Aplícalo a fondos, adornos y separadores —nunca a gráficos, iconos o imágenes que transmitan información. Aspose.Slides expone esta marca para su detección y validación, lo que permite comprobaciones automáticas de accesibilidad y limpieza.

![Marca como decorativo](mark_as_decorative.png)

El siguiente fragmento de código muestra cómo determinar si una forma está marcada como decorativo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```