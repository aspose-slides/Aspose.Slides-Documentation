---
title: Secuencia de selección de fuentes en Aspose.Slides para Python mediante Java
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/python-java/font-selection-sequence/
keywords:
- selección de fuentes
- sustitución de fuentes
- reemplazo de fuentes
- regla de sustitución
- fuente disponible
- fuente ausente
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Python mediante Java selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---
## **Visión general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides comprueba si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta una fuente requerida, Aspose.Slides selecciona una fuente de sustitución que se acerque lo más posible a la que usaría PowerPoint.

Aspose.Slides primero busca la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica una sustitución adecuada. Cuando las reglas de sustitución de fuentes se definen mediante [FontSubstRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsubstrule/), también se tienen en cuenta esas reglas.

También puedes añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas en una presentación o cargar fuentes externas para documentos de salida, como archivos PDF.

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes de una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, al intentar convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan, se reemplazan —consulta [Font Replacement](/slides/es/python-java/font-replacement/) y [Font Substitution](/slides/es/python-java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la que coincida con la fuente elegida en la presentación.
2. Si la fuente elegida se encuentra, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de sustitución que se acerque lo más posible a la que usaría PowerPoint.
3. Si se han establecido reglas de sustitución de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [Custom fonts](/slides/es/python-java/custom-font/).

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [Embedded fonts](/slides/es/python-java/embedded-font/).

Aspose.Slides permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF utiliza fuentes que no están instaladas en tu sistema ni están incrustadas en la presentación, puedes añadir o cargar las fuentes necesarias como **fuentes externas**.

{{% alert title="Note" color="info" %}}
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API permite cargar fuentes externas e incrustarlas en los documentos, pero lo haces bajo tu propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas mediante el [font manager](https://reference.aspose.com/slides/es/python-java/aspose.slides/fontsmanager/), de modo que puedas decidir si [incrustar](/slides/es/python-java/embedded-font/), [reemplazar](/slides/es/python-java/font-replacement/) o añadir [fuentes externas](/slides/es/python-java/custom-font/). Esto ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/python-java/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito un retroceso silencioso a una fuente inadecuada cuando falta un glifo?**

Define previamente [reemplazo de fuentes](/slides/es/python-java/font-replacement/) y reglas de [fuentes de reserva](/slides/es/python-java/fallback-font/). Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.