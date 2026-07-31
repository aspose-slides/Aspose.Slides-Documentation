---
title: Administrar fuentes de reserva para presentaciones en C++
linktitle: Fuente de reserva
type: docs
weight: 50
url: /es/cpp/fallback-font/
keywords:
- fuente de reserva
- fuente disponible
- reemplazo de glifos
- especificar fuente
- especificar regla
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Vea cómo Aspose.Slides para C++ usa fuentes de reserva para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---
## **Introducción**

Las fuentes de reserva se utilizan cuando la fuente especificada para el texto está disponible en el sistema pero no contiene un glifo requerido. En este caso, Aspose.Slides puede usar una de las fuentes de reserva especificadas para reemplazar el glifo que falta.

## **Fuente de reserva**
La fuente de reserva se utiliza cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de reserva especificadas para el reemplazo del glifo.

Aspose.Slides permite crear fuentes de reserva, agregarlas a la colección de fuentes de reserva, establecer la colección de fuentes de reserva para una presentación determinada, eliminar fuentes de reserva de la presentación, especificar las reglas para aplicar fuentes de reserva y otros.

Para familiarizarse con estas funciones, utilice los enlaces siguientes:

- [Crear fuente de reserva](/slides/es/cpp/create-fallback-font)
- [Crear colección de fuentes de reserva](/slides/es/cpp/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de reserva](/slides/es/cpp/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿En qué se diferencian las fuentes de reserva de la sustitución de fuentes?**

La reserva se aplica por carácter o por rango de Unicode cuando la fuente principal carece de glifos específicos; rellena solo los caracteres que faltan. [Substitution](/slides/es/cpp/font-substitution/) sustituye una fuente que falta o no está disponible para una secuencia completa o una porción de texto con otra fuente. Pueden combinarse, pero su ámbito y lógica de selección son diferentes.

**¿Se guardan los ajustes de reserva dentro del archivo de la presentación?**

No. La configuración de reserva vive en el momento del procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reserva.

**¿Afecta la reserva a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por el mismo proceso de renderizado, por lo que se aplican las mismas reglas de reserva que al texto normal.