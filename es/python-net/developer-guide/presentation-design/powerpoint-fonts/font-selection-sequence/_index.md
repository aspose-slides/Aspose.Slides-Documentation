---
title: Secuencia de selección de fuentes en presentaciones con Python
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

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que las fuentes faltan, se sustituyen — consulta [**Reemplazo de fuentes**](https://docs.aspose.com/slides/python-net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/python-net/font-substitution/).

Este es el proceso que Aspose.Slides sigue al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/python-net/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides le permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API le permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace con fuentes bajo su discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se utilizan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes utilizadas a través del [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), para que pueda decidir si [incrusta](/slides/es/python-net/embedded-font/), [reemplaza](/slides/es/python-net/font-replacement/) o agrega [fuentes externas](/slides/es/python-net/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/python-net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?**

Defina de forma explícita [reemplazo de fuentes](/slides/es/python-net/font-replacement/) y reglas de [fallback de fuentes](/slides/es/python-net/fallback-font/) con antelación. Al analizar las fuentes utilizadas y establecer una prioridad controlada para los sustitutos, garantiza una tipografía coherente y evita resultados inesperados.