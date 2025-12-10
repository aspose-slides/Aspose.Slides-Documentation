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
description: "Descubra cómo Aspose.Slides para Java selecciona fuentes, asegurando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, renderiza o convierte a otro formato. Por ejemplo, cuando intenta convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan fuentes, se sustituyen — vea [**Reemplazo de fuentes**](https://docs.aspose.com/slides/java/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/java/font-substitution/).

Este es el proceso que Aspose.Slides sigue al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida por la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides usa una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de sustitución de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/java/com.aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite añadir fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Vea [**Fuentes personalizadas**](https://docs.aspose.com/slides/java/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/java/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en documentos, pero lo hace con las fuentes bajo su discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes utilizadas a través del [administrador de fuentes](https://reference.aspose.com/slides/java/com.aspose.slides/fontsmanager/), de modo que pueda decidir si [incrusta](/slides/es/java/embedded-font/), [reemplaza](/slides/es/java/font-replacement/) o añade [fuentes externas](/slides/es/java/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo añadir directorios de fuentes extra sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/java/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema anfitrión y mantiene el diseño predecible.

**¿Cómo evito un retroceso silencioso a una fuente inadecuada cuando falta un glifo?**

Defina de forma explícita [reemplazo de fuentes](/slides/es/java/font-replacement/) y [reglas de retroceso de fuentes](/slides/es/java/fallback-font/) con anticipación. Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, asegura una tipografía coherente y evita resultados inesperados.