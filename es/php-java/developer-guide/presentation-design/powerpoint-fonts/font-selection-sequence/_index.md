---
title: Secuencia de selección de fuentes
linktitle: Secuencia de selección de fuentes
type: docs
weight: 80
url: /php-java/font-selection-sequence/
keywords: "Fuente, Selección de fuente, Sustitución de fuente, Reemplazo de fuente, Presentación de PowerPoint, Java, Aspose.Slides para PHP a través de Java"
description: Secuencia de selección de fuente en PowerPoint
---

## Selección de Fuentes

Ciertas reglas se aplican a las fuentes en una presentación cuando se carga, se renderiza o se convierte a otro formato. Por ejemplo, cuando intentas convertir una presentación (sus diapositivas) a imágenes, se verifica que las fuentes elegidas estén disponibles en el sistema operativo. Si se confirma que las fuentes faltan, se reemplazan—consulta [**Reemplazo de Fuentes**](https://docs.aspose.com/slides/php-java/font-replacement/) y [**Sustitución de Fuentes**](https://docs.aspose.com/slides/php-java/font-substitution/).

Este es el proceso que sigue Aspose.Slides al tratar con fuentes:

1. Aspose.Slides busca fuentes en el sistema operativo para encontrar la fuente que coincida con la fuente elegida en la presentación. 
2. Si se encuentra la fuente elegida, Aspose.Slides la utiliza. De lo contrario, Aspose.Slides utiliza una fuente de reemplazo que sea lo más parecida posible a la que usaría PowerPoint. 
3. Si se han establecido reglas de reemplazo de fuentes a través de [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/), se aplican.

Aspose.Slides te permite añadir fuentes al tiempo de ejecución de Aspose y luego usar esas fuentes. Consulta [**Fuentes personalizadas**](https://docs.aspose.com/slides/php-java/custom-font/).

Cuando se colocan fuentes adicionales dentro de una presentación, se les llama [**Fuentes integradas**](https://docs.aspose.com/slides/php-java/embedded-font/).

Aspose.Slides te permite añadir fuentes que se aplican *solo* a documentos de salida. Por ejemplo, si una presentación que deseas convertir a PDF contiene fuentes que faltan en tu sistema y fuentes integradas, puedes añadir o cargar las fuentes necesarias como **Fuentes externas**.