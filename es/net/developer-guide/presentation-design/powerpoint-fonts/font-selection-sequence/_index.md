---
title: Secuencia de selección de fuentes en C#
linktitle: Secuencia de selección de fuentes en C#
type: docs
weight: 80
url: /net/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- C#
- Csharp
- Aspose.Slides para .NET
description: Secuencia de selección de fuentes de PowerPoint en C#
---

## Selección de Fuentes

Ciertas reglas se aplican a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifican las fuentes de la presentación para comprobar que las fuentes elegidas están disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — véase [**Reemplazo de Fuentes**](https://docs.aspose.com/slides/net/font-replacement/) y [**Sustitución de Fuentes**](https://docs.aspose.com/slides/net/font-substitution/).

Este es el proceso que Aspose.Slides sigue al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides permite agregar fuentes al tiempo de ejecución de la aplicación y luego utilizar esas fuentes. Véase [**Fuentes personalizadas**](https://docs.aspose.com/slides/net/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se les llama [**Fuentes integradas**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides permite agregar fuentes que se aplican *solamente* a documentos de salida. Por ejemplo, si una presentación que estás buscando convertir a PDF contiene fuentes que faltan en tu sistema y fuentes integradas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API te permite cargar fuentes externas e integrarlas en documentos, pero lo haces con fuentes bajo tu criterio y responsabilidad.
{{% /alert %}}