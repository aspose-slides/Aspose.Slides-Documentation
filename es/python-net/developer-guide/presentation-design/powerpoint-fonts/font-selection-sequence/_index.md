---
title: Secuencia de selección de fuentes en Aspose.Slides para Python
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/python-net/font-selection-sequence/
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
- Python
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python mediante .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — consulta [**Font Replacement**](https://docs.aspose.com/slides/python-net/font-replacement/) y [**Font Substitution**](https://docs.aspose.com/slides/python-net/font-substitution/).

Este es el proceso que Aspose.Slides sigue al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que se acerque lo más posible a lo que usaría PowerPoint. 
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides te permite añadir fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Custom fonts**](https://docs.aspose.com/slides/python-net/custom-font/). 

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Embedded fonts**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides te permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Nota" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace con fuentes bajo su discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes utilizadas a través del [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), de modo que pueda decidir si [embed](/slides/es/python-net/embedded-font/), [replace](/slides/es/python-net/font-replacement/) o añadir [external sources](/slides/es/python-net/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [external font sources](/slides/es/python-net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema anfitrión y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente no adecuada cuando falta un glifo?**

Defina explícitamente [font replacement](/slides/es/python-net/font-replacement/) y reglas de [fallBack](/slides/es/python-net/fallback-font/) de fuentes con antelación. Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.