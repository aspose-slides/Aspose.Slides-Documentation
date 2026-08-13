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
description: "Descubre cómo Aspose.Slides para .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP — mejora tus diapositivas ahora."
---
## **Visión general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides verifica si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta una fuente requerida, Aspose.Slides selecciona una fuente de reemplazo que sea lo más cercana posible a la que usaría PowerPoint.

Aspose.Slides primero busca la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica un reemplazo adecuado. Cuando las reglas de sustitución de fuentes se definen mediante `FontSubstRule`, esas reglas también se tienen en cuenta.

También puedes añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas de una presentación o cargar fuentes externas para documentos de salida como archivos PDF.

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes de una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se comprueba si las fuentes elegidas están disponibles en el sistema operativo. Si se confirma que faltan, se reemplazan — vea [**Reemplazo de fuentes**](https://docs.aspose.com/slides/es/net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/es/net/font-substitution/).

Este es el proceso que Aspose.Slides sigue al gestionar fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si la fuente elegida se encuentra, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides usa una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han configurado reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides te permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/es/net/custom-font/). 

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/es/net/embedded-font/).

Aspose.Slides te permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="info" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API te permite cargar fuentes externas e incrustarlas en documentos, pero lo haces con fuentes bajo tu propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?

Aspose.Slides te permite inspeccionar las fuentes usadas a través del [gestor de fuentes](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/fontsmanager/), para que puedas decidir si [incrustar](/slides/es/net/embedded-font/), [reemplazar](/slides/es/net/font-replacement/) o añadir [fuentes externas](/slides/es/net/custom-font/). Esto te ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

### ¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?

Sí. Puedes registrar [fuentes externas](/slides/es/net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

### ¿Cómo evito un retroceso silencioso a una fuente inadecuada cuando falta un glifo?

Define de antemano [reemplazo de fuentes](/slides/es/net/font-replacement/) y reglas de [retroceso de fuentes](/slides/es/net/fallback-font/). Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.