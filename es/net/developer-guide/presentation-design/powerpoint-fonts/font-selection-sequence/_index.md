---
title: Secuencia de selección de fuentes en Aspose.Slides para .NET
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/net/font-selection-sequence/
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
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se sustituyen — consulta [**Reemplazo de fuentes**](https://docs.aspose.com/slides/net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/net/font-substitution/).

Este es el proceso que Aspose.Slides sigue al manejar fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/net/custom-font/). 

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/net/embedded-font/).

Aspose.Slides le permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos ninguna fuente, ni de pago ni gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace con fuentes bajo su propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes utilizadas a través del [administrador de fuentes](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), para que pueda decidir si [incrusta](/slides/es/net/embedded-font/), [reemplaza](/slides/es/net/font-replacement/) o agrega [fuentes externas](/slides/es/net/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante la renderización y exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/net/custom-font/) como carpetas o flujos en memoria para la renderización y exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?**

Defina de antemano [reemplazo de fuentes](/slides/es/net/font-replacement/) y reglas de [retroceso de fuentes](/slides/es/net/fallback-font/). Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.