---
title: Fuente de reserva - API de JavaScript para PowerPoint
linktitle: Fuente de reserva
type: docs
weight: 50
url: /es/nodejs-java/fallback-font/
description: La fuente de reserva se utiliza cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible que la API de Java para PowerPoint use una de las fuentes de reserva especificadas para el reemplazo del glifo.
---

## **Fuente de reserva**
La fuente de reserva se usa cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de reserva especificadas para el reemplazo del glifo.

Aspose.Slides permite crear fuentes de reserva, agregarlas a la colección de fuentes de reserva, establecer la colección de fuentes de reserva para una presentación determinada, eliminar fuentes de reserva de la presentación, especificar las reglas para aplicar fuentes de reserva y otras operaciones.

Para familiarizarse con estas funciones, utilice los siguientes enlaces:

- [Crear fuente de reserva](/slides/es/nodejs-java/create-fallback-font)
- [Crear colección de fuentes de reserva](/slides/es/nodejs-java/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de reserva](/slides/es/nodejs-java/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿En qué se diferencian las fuentes de reserva de la sustitución de fuentes?**

La reserva se aplica por carácter o por rango de Unicode cuando la fuente primaria carece de glifos específicos; solo rellena los caracteres faltantes. [Sustitución](/slides/es/nodejs-java/font-substitution/) sustituye una fuente ausente o no disponible para todo un segmento o porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan las configuraciones de reserva dentro del archivo de la presentación?**

No. La configuración de reserva vive en tiempo de procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reserva.

**¿Afecta la reserva a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por el mismo pipeline de renderizado, por lo que las mismas reglas de reserva se aplican tanto a él como al texto normal.