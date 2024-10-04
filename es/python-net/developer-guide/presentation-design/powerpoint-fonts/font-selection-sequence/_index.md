---
title: Secuencia de selección de fuentes en Python
linktitle: Secuencia de selección de fuentes en Python
type: docs
weight: 80
url: /python-net/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- Python
- Aspose.Slides para Python
description: "Secuencia de selección de fuentes de PowerPoint en Python"
---

## Selección de fuentes

Ciertas reglas se aplican a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) en imágenes, se verifica que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que las fuentes faltan, se reemplazan — consulta [**Reemplazo de fuentes**](https://docs.aspose.com/slides/python-net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/python-net/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación.
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más cercana posible a lo que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/python-net/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se les llama [**Fuentes incrustadas**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides te permite agregar fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que estás buscando convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuitas. Nuestra API te permite cargar fuentes externas e incrustarlas en documentos, pero lo haces bajo tu propio criterio y responsabilidad.
{{% /alert %}}