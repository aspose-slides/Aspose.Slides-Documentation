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
description: "Descubra cómo Aspose.Slides for C++ selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---
## **Descripción general**

Cuando se carga, renderiza o convierte una presentación a otro formato, Aspose.Slides comprueba si las fuentes utilizadas en la presentación están disponibles en el sistema operativo. Si falta una fuente requerida, Aspose.Slides selecciona una fuente de sustitución lo más parecida posible a la que usaría PowerPoint.

Aspose.Slides busca primero la fuente seleccionada en el sistema operativo. Si la fuente se encuentra, se utiliza. Si no se encuentra, se aplica una sustitución adecuada. Cuando las reglas de sustitución de fuentes se definen mediante `FontSubstRule`, también se tienen en cuenta esas reglas.

También puede añadir fuentes en tiempo de ejecución de la aplicación, usar fuentes incrustadas en una presentación o cargar fuentes externas para documentos de salida como archivos PDF.

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes de una presentación cuando se carga, renderiza o convierte a otro formato. Por ejemplo, al intentar convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que las fuentes faltan, se sustituyen — consulte [**Reemplazo de fuentes**](https://docs.aspose.com/slides/es/cpp/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/es/cpp/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la que coincida con la fuente elegida en la presentación.  
2. Si la fuente elegida se encuentra, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de sustitución lo más parecida posible a la que usaría PowerPoint.  
3. Si se han establecido reglas de sustitución de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsubstrule/), se aplican.  

Aspose.Slides le permite añadir fuentes en tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/es/cpp/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/es/cpp/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="info" %}} 
No distribuimos ninguna fuente, ya sea paga o gratuita. Nuestra API permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace bajo su propia discreción y responsabilidad.
{{% /alert %}}

## **FAQ**

### ¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?

Aspose.Slides le permite inspeccionar las fuentes utilizadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_fontsmanager/), de modo que pueda decidir si [incrustar](/slides/es/cpp/embedded-font/), [reemplazar](/slides/es/cpp/font-replacement/) o añadir [fuentes externas](/slides/es/cpp/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

### ¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?

Sí. Puede registrar [fuentes externas](/slides/es/cpp/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

### ¿Cómo impido un retroceso silencioso a una fuente inadecuada cuando falta un glifo?

Defina de antemano [reglas de sustitución de fuentes](/slides/es/cpp/font-replacement/) y reglas de [retroceso de fuentes](/slides/es/cpp/fallback-font/). Analizando las fuentes usadas y estableciendo una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.