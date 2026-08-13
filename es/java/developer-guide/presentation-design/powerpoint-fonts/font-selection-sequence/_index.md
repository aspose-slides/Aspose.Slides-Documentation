---
title: Secuencia de selección de fuentes en Aspose.Slides para Java
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/java/font-selection-sequence/
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
- Java
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para Java selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---
## **Visión general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides verifica si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta una fuente requerida, Aspose.Slides selecciona una fuente de sustitución lo más parecida posible a la que usaría PowerPoint.

Aspose.Slides busca primero la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica una sustitución adecuada. Cuando las reglas de sustitución de fuentes se definen mediante `FontSubstRule`, también se tienen en cuenta esas reglas.

También puede añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas de una presentación o cargar fuentes externas para documentos de salida, como archivos PDF.

## **Selección de fuentes**

Se aplican determinadas reglas a las fuentes de una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, al intentar convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se sustituyen — vea [**Reemplazo de fuentes**](https://docs.aspose.com/slides/es/java/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/es/java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al gestionar fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincide con la fuente elegida en la presentación. 
2. Si la fuente elegida se encuentra, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de sustitución lo más parecida posible a la que usaría PowerPoint.
3. Si se han establecido reglas de sustitución de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Vea [**Fuentes personalizadas**](https://docs.aspose.com/slides/es/java/custom-font/). 

Cuando se incluyen fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/es/java/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Nota" color="info" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace con fuentes bajo su propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

### ¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?

Aspose.Slides le permite inspeccionar las fuentes utilizadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/es/java/com.aspose.slides/fontsmanager/), de modo que pueda decidir si [incrusta](/slides/es/java/embedded-font/), [reemplaza](/slides/es/java/font-replacement/) o añade [fuentes externas](/slides/es/java/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante la renderización y la exportación.

### ¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?

Sí. Puede registrar [fuentes externas](/slides/es/java/custom-font/) como carpetas o flujos en memoria para la renderización y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

### ¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?

Defina de forma explícita [reemplazo de fuentes](/slides/es/java/font-replacement/) y reglas de [fuentes de reserva](/slides/es/java/fallback-font/) con antelación. Analizando las fuentes utilizadas y estableciendo una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.