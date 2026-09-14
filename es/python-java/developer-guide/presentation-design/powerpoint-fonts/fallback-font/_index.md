---
title: Administrar fuentes de reserva para presentaciones en Python a través de Java
linktitle: Fuente de reserva
type: docs
weight: 50
url: /es/python-java/fallback-font/
keywords:
- fuente de reserva
- fuente disponible
- reemplazo de glifos
- especificar fuente
- especificar regla
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Vea cómo Aspose.Slides para Python a través de Java utiliza fuentes de reserva para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---
## **Introducción**

Las fuentes de reserva se utilizan cuando la fuente especificada para el texto está disponible en el sistema pero no contiene el glifo requerido. En este caso, Aspose.Slides puede usar una de las fuentes de reserva especificadas para sustituir el glifo que falta.

## **Fuente de reserva**

Aspose.Slides le permite crear fuentes de reserva, agregarlas a una colección de fuentes de reserva, establecer la colección de fuentes de reserva para una determinada presentación, eliminar fuentes de reserva de la presentación, especificar las reglas para aplicar fuentes de reserva y realizar otras operaciones relacionadas.

Para familiarizarse con estas características, utilice los siguientes enlaces:

- [Crear fuente de reserva](/slides/es/python-java/create-fallback-font/)
- [Crear colección de fuentes de reserva](/slides/es/python-java/create-fallback-fonts-collection/)
- [Renderizar presentación con fuente de reserva](/slides/es/python-java/render-presentation-with-fallback-font/)

## **Preguntas frecuentes**

**¿En qué se diferencian las fuentes de reserva de la sustitución de fuentes?**

La reserva se aplica por carácter o por rango de Unicode cuando la fuente principal carece de glifos específicos; solo rellena los caracteres que faltan. [Sustitución](/slides/es/python-java/font-substitution/) reemplaza una fuente que falta o no está disponible para todo un tramo o porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan los ajustes de reserva dentro del archivo de la presentación?**

No. La configuración de reserva se mantiene en tiempo de procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reserva.

**¿Afecta la reserva a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canalización de renderizado, por lo que se aplican las mismas reglas de reserva que al texto normal.