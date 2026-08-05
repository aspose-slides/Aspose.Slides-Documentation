---
title: Secuencia de selección de fuentes en Aspose.Slides para C++
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Descubre cómo Aspose.Slides para C++ selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP — mejora tus diapositivas ahora."
---
## **Resumen**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides comprueba si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta alguna fuente requerida, Aspose.Slides selecciona una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.

Aspose.Slides busca primero la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica una fuente de reemplazo adecuada. Cuando las reglas de sustitución de fuentes están definidas mediante `FontSubstRule`, también se tienen en cuenta esas reglas.

También puedes añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas de una presentación o cargar fuentes externas para documentos de salida como archivos PDF.

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes de una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, al intentar convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan, se sustituyen — ver [**Font Replacement**](https://docs.aspose.com/slides/es/cpp/font-replacement/) y [**Font Substitution**](https://docs.aspose.com/slides/es/cpp/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación. 
2. Si la fuente elegida se encuentra, Aspose.Slides la usa. De lo contrario, Aspose.Slides emplea una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de sustitución de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides permite añadir fuentes en tiempo de ejecución de la aplicación y luego utilizarlas. Consulta [**Custom fonts**](https://docs.aspose.com/slides/es/cpp/custom-font/). 

Cuando se insertan fuentes adicionales dentro de una presentación, se denominan [**Embedded fonts**](https://docs.aspose.com/slides/es/cpp/embedded-font/).

Aspose.Slides permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes añadir o cargar las fuentes necesarias como **external fonts**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API permite cargar fuentes externas e incrustarlas en los documentos, pero lo haces con fuentes bajo tu propia discreción y responsabilidad.
{{% /alert %}}

## **FAQ**

**¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas a través del [font manager](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_fontsmanager/), de modo que puedas decidir si [embed](/slides/es/cpp/embedded-font/), [replace](/slides/es/cpp/font-replacement/) o añadir [external sources](/slides/es/cpp/custom-font/). Esto ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo añadir directorios de fuentes extra sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [external font sources](/slides/es/cpp/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema anfitrión y mantiene la disposición predecible.

**¿Cómo evito un fallback silencioso a una fuente inadecuada cuando falta un glifo?**

Define con antelación [font replacement](/slides/es/cpp/font-replacement/) y reglas de [fallBack](/slides/es/cpp/fallback-font/) de fuentes. Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.