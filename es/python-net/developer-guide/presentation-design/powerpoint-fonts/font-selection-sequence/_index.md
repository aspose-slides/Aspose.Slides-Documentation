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
description: "Descubra cómo Aspose.Slides para Python a través de .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP — mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Algunas reglas se aplican a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intenta convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se reemplazan — ver [**Reemplazo de fuentes**](https://docs.aspose.com/slides/python-net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/python-net/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite añadir fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Ver [**Fuentes personalizadas**](https://docs.aspose.com/slides/python-net/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides le permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede añadir o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos fuentes, ni pagas ni gratuitas. Nuestra API le permite cargar fuentes externas e incrustarlas en documentos, pero lo hace bajo su propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes usadas a través del [administrador de fuentes](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), de modo que pueda decidir si [incrusta](/slides/es/python-net/embedded-font/), [reemplaza](/slides/es/python-net/font-replacement/) o añade [fuentes externas](/slides/es/python-net/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/python-net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema anfitrión y mantiene el diseño predecible.

**¿Cómo evito que se recurra silenciosamente a una fuente inadecuada cuando falta un glifo?**

Defina previamente [reemplazo de fuentes](/slides/es/python-net/font-replacement/) y [reglas de reserva](/slides/es/python-net/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantiza una tipografía consistente y evita resultados inesperados.