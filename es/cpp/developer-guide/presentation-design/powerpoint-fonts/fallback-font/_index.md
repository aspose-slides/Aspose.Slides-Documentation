---
title: Administrar fuentes de respaldo para presentaciones en C++
linktitle: Fuente de respaldo
type: docs
weight: 50
url: /es/cpp/fallback-font/
keywords:
- fuente de respaldo
- fuente disponible
- reemplazo de glifos
- especificar fuente
- especificar regla
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Vea cómo Aspose.Slides para C++ utiliza fuentes de respaldo para mantener el texto legible en presentaciones de PowerPoint y OpenDocument cuando las fuentes originales no están disponibles."
---

## **Fuente de respaldo**
La fuente de respaldo se utiliza cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de respaldo especificadas para el reemplazo del glifo.

Aspose.Slides permite crear fuentes de respaldo, añadirlas a la colección de fuentes de respaldo, establecer la colección de fuentes de respaldo para una presentación determinada, eliminar fuentes de respaldo de la presentación, especificar las reglas para aplicar fuentes de respaldo y demás.

Para familiarizarse con estas funciones, utilice los siguientes enlaces:

- [Crear fuente de respaldo](/slides/es/cpp/create-fallback-font)
- [Crear colección de fuentes de respaldo](/slides/es/cpp/create-fallback-fonts-collection)
- [Renderizar presentación con fuente de respaldo](/slides/es/cpp/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿Cómo se diferencian las fuentes de respaldo de la sustitución de fuentes?**

La fuente de respaldo se aplica por carácter o por rango Unicode cuando la fuente primaria carece de glifos específicos; solo cubre los caracteres que faltan. [Sustitución](/slides/es/cpp/font-substitution/) reemplaza una fuente ausente o no disponible para una ejecución completa o una porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan los ajustes de respaldo dentro del archivo de la presentación?**

No. La configuración de respaldo existe durante el procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de respaldo.

**¿Afecta la fuente de respaldo a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canalización de renderizado, por lo que las mismas reglas de respaldo se aplican tanto a él como al texto normal.