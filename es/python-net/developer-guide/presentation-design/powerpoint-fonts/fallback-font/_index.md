---
title: Administrar fuentes de respaldo para presentaciones en Python
linktitle: Fuente de respaldo
type: docs
weight: 50
url: /es/python-net/fallback-font/
keywords:
- fuente de respaldo
- fuente disponible
- reemplazo de glifo
- especificar fuente
- especificar regla
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Vea cómo Aspose.Slides para Python a través de .NET utiliza fuentes de respaldo para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---

## **Fuente de respaldo**
La fuente de respaldo se utiliza cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de respaldo especificadas para el reemplazo de glifos.

Aspose.Slides permite crear fuentes de respaldo, añadirlas a la colección de fuentes de respaldo, establecer la colección de fuentes de respaldo para una presentación determinada, eliminar fuentes de respaldo de la presentación, especificar las reglas para aplicar fuentes de respaldo y otras funcionalidades.

Para familiarizarse con estas funciones, use los siguientes enlaces:

- [Crear fuente de respaldo](/slides/es/python-net/create-fallback-font)
- [Crear colección de fuentes de respaldo](/slides/es/python-net/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de respaldo](/slides/es/python-net/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿En qué se diferencian las fuentes de respaldo de la sustitución de fuentes?**

La fuente de respaldo se aplica por carácter o por rango de Unicode cuando la fuente primaria carece de glifos específicos; sólo rellena los caracteres faltantes. [Substitution](/slides/es/python-net/font-substitution/) reemplaza una fuente ausente o no disponible para una secuencia completa o una porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan los ajustes de respaldo dentro del archivo de la presentación?**

No. La configuración de respaldo se mantiene en tiempo de procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de respaldo.

**¿Afecta la fuente de respaldo a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canalización de renderizado, por lo que las mismas reglas de respaldo se aplican al mismo que al texto normal.