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
## **Descripción general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides comprueba si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta una fuente requerida, Aspose.Slides selecciona una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.

Aspose.Slides busca primero la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica un reemplazo adecuado. Cuando las reglas de sustitución de fuentes se definen mediante `FontSubstRule`, esas reglas también se tienen en cuenta.

También puede añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas de una presentación o cargar fuentes externas para documentos de salida como archivos PDF.

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes de una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, cuando intenta convertir una presentación (sus diapositivas) a imágenes, se comprueban las fuentes de la presentación para verificar que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — vea [**Reemplazo de fuentes**](https://docs.aspose.com/slides/es/androidjava/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/es/androidjava/font-substitution/).

Este es el proceso que Aspose.Slides sigue al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides le permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Vea [**Fuentes personalizadas**](https://docs.aspose.com/slides/es/androidjava/custom-font/).

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/es/androidjava/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *únicamente* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Nota" color="info" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace con las fuentes bajo su discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?

Aspose.Slides le permite inspeccionar las fuentes usadas a través del [font manager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsmanager/), para que pueda decidir si [incrustar](/slides/es/androidjava/embedded-font/), [reemplazar](/slides/es/androidjava/font-replacement/) o añade [fuentes externas](/slides/es/androidjava/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante la renderización y la exportación.

### ¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?

Sí. Puede registrar [orígenes de fuentes externas](/slides/es/androidjava/custom-font/) como carpetas o flujos en memoria para la renderización y la exportación. Esto elimina la dependencia de las fuentes del sistema anfitrión y mantiene el diseño predecible.

### ¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?

Defina de forma explícita el [reemplazo de fuentes](/slides/es/androidjava/font-replacement/) y las [reglas de sustitución](/slides/es/androidjava/fallback-font/) de fuentes con antelación. Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.