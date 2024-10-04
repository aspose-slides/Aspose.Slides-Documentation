---
title: Secuencia de selección de fuentes en Java
linktitle: Secuencia de selección de fuentes en Java
type: docs
weight: 80
url: /java/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- Java
- Aspose.Slides para Java
description: Secuencia de selección de fuentes de PowerPoint en Java
---

## Selección de fuentes

Ciertas reglas se aplican a las fuentes en una presentación cuando se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes seleccionadas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — consulta [**Reemplazo de fuentes**](https://docs.aspose.com/slides/java/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente seleccionada en la presentación.
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que es lo más cercana posible a lo que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/java/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se les llama [**Fuentes embebidas**](https://docs.aspose.com/slides/java/embedded-font/).

Aspose.Slides te permite agregar fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes embebidas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API te permite cargar fuentes externas e incrustarlas en documentos, pero lo haces con fuentes a tu discreción y responsabilidad.
{{% /alert %}}