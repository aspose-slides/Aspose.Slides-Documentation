---
title: Gestionar fuentes de reserva para presentaciones en Python
linktitle: Fuente de reserva
type: docs
weight: 50
url: /es/python-net/fallback-font/
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
- Aspose.Slides
description: "Vea cómo Aspose.Slides para Python via .NET usa fuentes de reserva para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---

## **Fuente de reserva**
La fuente de reserva se usa cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de reserva especificadas para el reemplazo del glifo.

Aspose.Slides permite crear fuentes de reserva, agregarlas a la colección de fuentes de reserva, establecer la colección de fuentes de reserva para una presentación determinada, eliminar fuentes de reserva de la presentación, especificar las reglas para aplicar fuentes de reserva y otras acciones.

Para familiarizarse con estas funciones, utilice los siguientes enlaces:

- [Crear fuente de reserva](/slides/es/python-net/create-fallback-font)
- [Crear colección de fuentes de reserva](/slides/es/python-net/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de reserva](/slides/es/python-net/render-presentation-with-fallback-font)

## **Preguntas frecuentes**
**¿En qué se diferencian las fuentes de reserva de la sustitución de fuentes?**

La reserva se aplica por carácter o por rango de Unicode cuando la fuente principal carece de glifos específicos; solo rellena los caracteres faltantes. [Sustitución](/slides/es/python-net/font-substitution/) reemplaza una fuente faltante o no disponible para una secuencia completa o una porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan las configuraciones de reserva dentro del archivo de la presentación?**

No. La configuración de reserva vive en tiempo de procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reserva.

**¿Afecta la reserva a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canal de renderizado, por lo que las mismas reglas de reserva se aplican al mismo que al texto normal.