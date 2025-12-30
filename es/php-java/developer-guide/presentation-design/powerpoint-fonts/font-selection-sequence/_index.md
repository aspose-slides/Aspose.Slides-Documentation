---
title: Secuencia de selección de fuentes en Aspose.Slides para PHP
linktitle: Selección de fuentes
type: docs
weight: 80
url: /es/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para PHP a través de Java selecciona fuentes, garantizando una presentación nítida y coherente de archivos PPT, PPTX y ODP — mejore sus diapositivas ahora."
---

## **Selección de fuentes**

Se aplican ciertas normas a las fuentes en una presentación cuando la presentación se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se comprueban las fuentes de la presentación para verificar que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que faltan las fuentes, se sustituyen — consulta [**Reemplazo de fuentes**](https://docs.aspose.com/slides/php-java/font-replacement/) y [**Sustitución de fuentes**](https://docs.aspose.com/slides/php-java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al trabajar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación.  
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. En caso contrario, Aspose.Slides usa una fuente de sustitución lo más cercana posible a la que usaría PowerPoint.  
3. Si se han establecido reglas de sustitución de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite añadir fuentes al tiempo de ejecución de Aspose y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/php-java/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se denominan [**Fuentes incrustadas**](https://docs.aspose.com/slides/php-java/embedded-font/).

Aspose.Slides te permite añadir fuentes que se aplican *solo* a los documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes incrustadas, puedes añadir o cargar las fuentes necesarias como **Fuentes externas**. 

## **Preguntas frecuentes**

**¿Cómo puedo determinar qué fuentes se usan realmente en una presentación antes de la conversión?**

Aspose.Slides te permite inspeccionar las fuentes usadas mediante el [administrador de fuentes](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/), de modo que puedes decidir si [incrustas](/slides/es/php-java/embedded-font/), [sustituyes](/slides/es/php-java/font-replacement/) o añades [fuentes externas](/slides/es/php-java/custom-font/). Esto te ayuda a evitar sustituciones no deseadas durante la renderización y la exportación.

**¿Puedo añadir directorios de fuentes adicionales sin instalarlos en el sistema operativo?**

Sí. Puedes registrar [fuentes externas](/slides/es/php-java/custom-font/) como carpetas o flujos en memoria para la renderización y la exportación. Esto elimina la dependencia de las fuentes del sistema host y mantiene el diseño predecible.

**¿Cómo evito una sustitución silenciosa a una fuente inadecuada cuando falta un glifo?**

Define por adelantado [sustitución de fuentes](/slides/es/php-java/font-replacement/) y [reglas de reserva de fuentes](/slides/es/php-java/fallback-font/). Al analizar las fuentes usadas y establecer una prioridad controlada para los sustitutos, garantizas una tipografía coherente y evitas resultados inesperados.