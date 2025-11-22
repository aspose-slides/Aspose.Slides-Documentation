---
title: Secuencia de selección de fuentes en JavaScript
linktitle: Secuencia de selección de fuentes
type: docs
weight: 80
url: /es/nodejs-java/font-selection-sequence/
keywords:
- fuente
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- presentación de PowerPoint
- Java
- Aspose.Slides para Node.js mediante Java
description: Secuencia de selección de fuentes de PowerPoint en JavaScript
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se representa o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan fuentes, se reemplazan — ver [**Reemplazo de fuentes**](https://docs.aspose.com/slides/nodejs-java/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/nodejs-java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación.  
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides usa una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.  
3. Si se han configurado reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides permite agregar fuentes al tiempo de ejecución de la aplicación y luego usarlas. Ver [**Fuentes personalizadas**](https://docs.aspose.com/slides/nodejs-java/custom-font/).

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/nodejs-java/embedded-font/).

Aspose.Slides permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API permite cargar fuentes externas y incrustarlas en los documentos, pero lo haces con fuentes bajo tu discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/), para que puedas decidir si [incrustas](/slides/es/nodejs-java/embedded-font/), [reemplazas](/slides/es/nodejs-java/font-replacement/) o agregas [fuentes externas](/slides/es/nodejs-java/custom-font/). Esto ayuda a prevenir sustituciones no deseadas durante la representación y exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/nodejs-java/custom-font/) como carpetas o flujos en memoria para la representación y exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?**

Define de antemano [reglas de reemplazo de fuentes](/slides/es/nodejs-java/font-replacement/) y reglas de [caída de fuentes](/slides/es/nodejs-java/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.