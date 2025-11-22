---
title: Fuente de sustitución - API C# de PowerPoint
linktitle: Fuente de sustitución
type: docs
weight: 50
url: /es/net/fallback-font/
keywords: "Fuente de sustitución, fuente, presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: Cuando la fuente no contiene un glifo necesario, la API C# de PowerPoint le permitirá usar una de las fuentes de sustitución especificadas para el reemplazo del glifo.
---

## **Fuente de Reemplazo**
La fuente de reemplazo se utiliza cuando la fuente especificada para el texto está disponible en el sistema, pero esa fuente no contiene un glifo necesario. En este caso, es posible usar una de las fuentes de reemplazo especificadas para reemplazar el glifo.

Aspose.Slides permite crear fuentes de reemplazo, agregarlas a la colección de fuentes de reemplazo, establecer la colección de fuentes de reemplazo para una presentación determinada, eliminar fuentes de reemplazo de la presentación, especificar las reglas para aplicar fuentes de reemplazo y más.

Para familiarizarse con estas funciones, utilice los siguientes enlaces:

- [Crear Fuente de Reemplazo](/slides/es/net/create-fallback-font)
- [Crear Colección de Fuentes de Reemplazo](/slides/es/net/create-fallback-fonts-collection)
- [Renderizar Presentación con Fuente de Reemplazo](/slides/es/net/render-presentation-with-fallback-font)

## **Preguntas frecuentes**

**¿Cómo se diferencian las fuentes de reemplazo de la sustitución de fuentes?**

La fuente de reemplazo se aplica por carácter o por rango de Unicode cuando la fuente primaria carece de glifos específicos; solo rellena los caracteres faltantes. [Sustitución](/slides/es/net/font-substitution/) reemplaza una fuente faltante o no disponible para una ejecución completa o una porción de texto con otra fuente. Pueden combinarse, pero su alcance y lógica de selección son diferentes.

**¿Se guardan las configuraciones de fuente de reemplazo dentro del archivo de presentación?**

No. La configuración de reemplazo vive en el momento del procesamiento/renderizado en la biblioteca y no se serializa en el PPTX. La presentación no almacena sus reglas de reemplazo.

**¿Afecta la fuente de reemplazo a los elementos creados por objetos de PowerPoint (SmartArt, gráficos, WordArt)?**

Sí. El texto dentro de estos objetos pasa por la misma canalización de renderizado, por lo que se aplican las mismas reglas de reemplazo que al texto normal.