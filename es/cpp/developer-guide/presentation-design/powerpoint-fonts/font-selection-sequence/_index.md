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
description: "Descubra cómo Aspose.Slides para C++ selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes de la presentación estén disponibles en el sistema operativo. Si se confirma que faltan fuentes, se sustituyen — ver [**Reemplazo de fuentes**](https://docs.aspose.com/slides/cpp/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/cpp/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si la fuente elegida se encuentra, Aspose.Slides la usa. De lo contrario, Aspose.Slides usa una fuente de reemplazo lo más cercana posible a la que usaría PowerPoint.
3. Si se han establecido reglas de reemplazo de fuentes mediante [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides le permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulte [**Fuentes personalizadas**](https://docs.aspose.com/slides/cpp/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/cpp/embedded-font/).

Aspose.Slides le permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que desea convertir a PDF contiene fuentes que faltan en su sistema y fuentes incrustadas, puede agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos fuentes, ya sean de pago o gratuitas. Nuestra API le permite cargar fuentes externas e incrustarlas en los documentos, pero lo hace bajo su propia discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides le permite inspeccionar las fuentes usadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/), para que pueda decidir si [incrusta](/slides/es/cpp/embedded-font/), [reemplaza](/slides/es/cpp/font-replacement/) o agrega [fuentes externas](/slides/es/cpp/custom-font/). Esto le ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo agregar directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puede registrar [fuentes externas](/slides/es/cpp/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito un retorno silencioso a una fuente inadecuada cuando falta un glifo?**

Defina de antemano [reglas de reemplazo de fuentes](/slides/es/cpp/font-replacement/) y reglas de [fallback de fuentes](/slides/es/cpp/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantiza una tipografía constante y evita resultados inesperados.