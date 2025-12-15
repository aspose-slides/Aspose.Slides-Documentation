---
title: Secuencia de selección de fuentes en Aspose.Slides para Android mediante Java
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/androidjava/font-selection-sequence/
keywords:
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- regla de sustitución
- fuente disponible
- fuente faltante
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Android mediante Java selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Algunas reglas se aplican a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se comprueban las fuentes de la presentación para verificar que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — ver [**Reemplazo de fuentes**](https://docs.aspose.com/slides/androidjava/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/androidjava/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación.  
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides usa una fuente de reemplazo que se acerque lo máximo posible a lo que usaría PowerPoint.  
3. Si se han establecido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Ver [**Fuentes personalizadas**](https://docs.aspose.com/slides/androidjava/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos fuentes, sean de pago o gratuitas. Nuestra API permite cargar fuentes externas e incrustarlas en documentos, pero lo haces bajo tu propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/), de modo que puedas decidir si [incrustas](/slides/es/androidjava/embedded-font/), [reemplazas](/slides/es/androidjava/font-replacement/) o agregas [fuentes externas](/slides/es/androidjava/custom-font/). Esto ayuda a evitar sustituciones no deseadas durante la renderización y exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/androidjava/custom-font/) como carpetas o flujos en memoria para la renderización y exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?**

Define con antelación [reglas de reemplazo de fuentes](/slides/es/androidjava/font-replacement/) y [reglas de reserva de fuentes](/slides/es/androidjava/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantizas una tipografía consistente y evitas resultados inesperados.