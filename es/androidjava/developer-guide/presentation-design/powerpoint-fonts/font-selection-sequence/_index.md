---
title: Secuencia de Selección de Fuentes en Java
linktitle: Secuencia de Selección de Fuentes en Java
type: docs
weight: 80
url: /androidjava/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- Java
- Aspose.Slides para Android a través de Java
description: Secuencia de selección de fuentes de PowerPoint en Java
---

## Selección de Fuentes

Se aplican ciertas reglas a las fuentes en una presentación cuando se carga, renderiza o convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) en imágenes, se verifica que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que las fuentes faltan, se reemplazan — véase [**Reemplazo de Fuentes**](https://docs.aspose.com/slides/androidjava/font-replacement/) y [**Sustitución de Fuentes**](https://docs.aspose.com/slides/androidjava/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más cercana posible a lo que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Fuentes Personalizadas**](https://docs.aspose.com/slides/androidjava/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se llaman [**Fuentes Incrustadas**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides te permite agregar fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes faltantes en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API te permite cargar fuentes externas e incrustarlas en documentos, pero lo haces con fuentes a tu discreción y responsabilidad.
{{% /alert %}}