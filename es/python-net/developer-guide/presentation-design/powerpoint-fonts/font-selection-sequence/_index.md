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
description: "Descubra cómo Aspose.Slides para Python mediante .NET selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP—mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas reglas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifican las fuentes de la presentación para confirmar que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se sustituyen — ver [**Reemplazo de fuentes**](https://docs.aspose.com/slides/python-net/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/python-net/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la usa. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más cercana posible a la que usaría PowerPoint.
3. Si se han configurado reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/), se aplican. 

Aspose.Slides permite agregar fuentes al tiempo de ejecución de la aplicación y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/python-net/custom-font/). 

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/python-net/embedded-font/).

Aspose.Slides permite agregar fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes agregar o cargar las fuentes necesarias como **fuentes externas**. 

{{% alert title="Note" color="primary" %}} 
No distribuimos ninguna fuente, ya sea de pago o gratuita. Nuestra API permite cargar fuentes externas e incrustarlas en documentos, pero lo haces con fuentes bajo tu discreción y responsabilidad.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/), para que puedas decidir si [incrustar](/slides/es/python-net/embedded-font/), [reemplazar](/slides/es/python-net/font-replacement/) o agregar [fuentes externas](/slides/es/python-net/custom-font/). Esto ayuda a evitar sustituciones no deseadas durante el renderizado y la exportación.

**¿Puedo agregar directorios de fuentes extra sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/python-net/custom-font/) como carpetas o flujos en memoria para el renderizado y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito un retorno silencioso a una fuente inadecuada cuando falta un glifo?**

Define previamente [reemplazo de fuentes](/slides/es/python-net/font-replacement/) y reglas de [retroceso de fuentes](/slides/es/python-net/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantizas una tipografía consistente y evitas resultados inesperados.