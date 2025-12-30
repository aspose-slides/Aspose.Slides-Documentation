---
title: Gestionar fuentes de reserva para presentaciones en PHP
linktitle: Fuente de reserva
type: docs
weight: 50
url: /es/php-java/fallback-font/
keywords:
- fuente de reserva
- fuente disponible
- reemplazo de glifos
- especificar fuente
- especificar regla
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Descubra cómo Aspose.Slides para PHP utiliza fuentes de reserva para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---

## **Fuente de reserva**
La fuente de reserva se usa cuando la fuente especificada para el texto está disponible en el sistema, pero esta fuente no contiene el glifo necesario. En este caso, es posible utilizar una de las fuentes de reserva especificadas para el reemplazo del glifo.

Aspose.Slides permite crear fuentes de reserva, añadirlas a la colección de fuentes de reserva, establecer la colección de fuentes de reserva para una presentación determinada, eliminar fuentes de reserva de la presentación, especificar las reglas para aplicar fuentes de reserva y otras operaciones.

Para familiarizarse con estas funciones, utilice los siguientes enlaces:

- [Crear fuente de reserva](/slides/es/php-java/create-fallback-font)
- [Crear colección de fuentes de reserva](/slides/es/php-java/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de reserva](/slides/es/php-java/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿En qué se diferencian las fuentes de reserva de la sustitución de fuentes?**

La fuente de reserva se aplica por carácter o por rango de Unicode cuando la fuente principal carece de glifos específicos; solo rellena los caracteres que faltan. [Sustitución](/slides/es/php-java/font-substitution/) reemplaza una fuente que falta o no está disponible para toda una serie o porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan los ajustes de reserva dentro del archivo de presentación?**

No. La configuración de reserva se mantiene en tiempo de procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reserva.

**¿Afecta la reserva a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canalización de renderizado, por lo que se aplican las mismas reglas de reserva que al texto normal.