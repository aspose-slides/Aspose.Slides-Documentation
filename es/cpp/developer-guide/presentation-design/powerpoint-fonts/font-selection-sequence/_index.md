---
title: Secuencia de selección de fuente en C++
linktitle: Secuencia de selección de fuente en C++
type: docs
weight: 80
url: /cpp/font-selection-sequence/
keywords:
- fuente
- selección de fuente
- sustitución de fuente
- reemplazo de fuente
- presentación de PowerPoint
- C++
- Aspose.Slides para C++
description: "Secuencia de selección de fuente de PowerPoint en C++"
---

## Selección de fuente

Se aplican ciertas reglas a las fuentes en una presentación cuando se carga, renderiza o convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, las fuentes de la presentación se verifican para confirmar que las fuentes elegidas están disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — consulta [**Reemplazo de fuente**](https://docs.aspose.com/slides/cpp/font-replacement/) y [**Sustitución de fuente**](https://docs.aspose.com/slides/cpp/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación.
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más parecida posible a lo que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuente a través de [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/cpp/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se les llama [**Fuentes incrustadas**](https://docs.aspose.com/slides/cpp/embedded-font/).

Aspose.Slides te permite agregar fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratis. Nuestra API te permite cargar fuentes externas e incrustarlas en documentos, pero lo haces con fuentes a tu criterio y responsabilidad.
{{% /alert %}}